using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Museum
{
    public abstract class Person
    {
        public static readonly string NameProperty = "name";
        public static readonly string PasswordProperty = "password";
        public static readonly string PhoneProperty = "phone";
        public static readonly string MailProperty = "mail";
        public static readonly string Itself = "persons";
        public static readonly string Exhibitor = "exhibitors";
        public static readonly string Employee = "employees";

        private int id { get; set; }

        public int Id
        {
            get => id;
            set => id = value;
        }

        private string name { get; set; }

        public string Name
        {
            get => name;
            set => name = value;
        }

        private string password { get; set; }

        public string Password
        {
            get => password;
            set => password = value;
        }

        private int phone { get; set; }

        public int Phone
        {
            get => phone;
            set => phone = value;
        }

        private string mail { get; set; }

        public string Mail
        {
            get => mail;
            set => mail = value;
        }

        private IList<Message> messages { get; set; } = new List<Message>();

        public IList<Message> Messages
        {
            get => messages;
            set => messages = value;
        }

        public abstract int RoleId();

        public bool CreateAccountMethod(Dictionary<string, string> values)
        {
            var adapter = new DictionaryAdapter(values);
            if (CheckAvailability(adapter.GetValue(MailProperty)))
            {
                GetData(values);
                return SubmitData();
            }

            return false;
        }

        public static IList<Dictionary<string, string>> GetAllPeople()
        {
            var selQuery = "SELECT * FROM persons";
            return DbConnection.Instance.Query(selQuery);
        }

        public static IList<Dictionary<string, string>> GetPeopleById(string id)
        {
            var personSql = "SELECT * FROM persons WHERE id=" + id;
            return DbConnection.Instance.Query(personSql);
        }

        public static IList<Dictionary<string, string>> GetPeopleByMail(string mail)
        {
            var properties = new[] { "*" };
            var tables = new[] { "persons" };
            var keys = new[] { MailProperty };
            var values = new[] { mail };

            var personSql = SqlOperations.Instance.Select(properties, tables, keys, values);
            return DbConnection.Instance.Query(personSql);
        }

        public static int UpdatePersonPassword(string id, string newPassword)
        {
            var table = "persons";
            var keys = new[] { PasswordProperty };
            var values = new[] { newPassword };
            var updatePersonSql = SqlOperations.Instance.Update(int.Parse(id), table, keys, values);
            return DbConnection.Instance.Execute(updatePersonSql);
        }

        public void GetMessages()
        {
            var so = SqlOperations.Instance;
            var db = DbConnection.Instance;
            string[] selvals = {"*"};
            string[] tables = {"messages", "persons_has_messages"};
            string[] keys = {"persons_has_messages.persons_id", "persons_has_messages.messages_id"};
            string[] values = {"" + Id + "", "messages.id ORDER BY lastUpdate ASC"};
            var select = so.Select(selvals, tables, keys, values);
            Debug.WriteLine(select);
            var l = db.Query(select);
            foreach (var dmessages in l) //dicionario com as msgs
            {
                var dam = new DictionaryAdapter(dmessages);
                var senderId = dam.GetValue("sender_id");
                if (senderId != null)
                {
                    string[] selval = {"*"};
                    string[] tab = {"persons"};
                    string[] k = {"persons.id"};
                    string[] v = {senderId};
                    var sel = so.Select(selval, tab, k, v);
                    Debug.WriteLine(sel);
                    var li = db.Query(sel);
                    Debug.WriteLine("l:" + l.Count + "li:" + li.Count);
                    foreach (var dperson in li) //dicionario com a pessoa dessa msg
                    {
                        var dap = new DictionaryAdapter(dperson);
                        var did = dap.GetValue("id");

                        var sender = CheckRole(did);

                        var msg = new Message(dmessages, sender);
                        var dictad = new DictionaryAdapter(dmessages);
                        var containsMessage = false;
                        foreach (var message in Messages)
                            if (message.Id == int.Parse(dictad.GetValue("id"))
                            ) // se ja existir essa msg nas messages da pessoa
                                containsMessage = true;
                        if (containsMessage == false) // se a msg nao existir adiciona-a
                            Messages.Insert(0, msg);
                    }
                }
            }
        }

        public Person CheckRole(string personId)
        {
            //Verifica se é um exhibitor ou um employee
            var properties = new[] {"*"};
            var table = new[] {"exhibitors"};
            var k = new[] {"persons_id"};
            var v = new[] {personId};
            var getExhibitorData = SqlOperations.Instance.Select(properties, table, k, v);
            var exhibitorResult = DbConnection.Instance.Query(getExhibitorData);
            Person user;
            var personFactory = FactoryCreator.Instance.CreateFactory("PersonFactory");
            if (exhibitorResult.Count > 0)
            {
                properties = new[]
                {
                    "exhibitors.id AS exhibitors_id", "persons.id AS persons_id", NameProperty,
                    PasswordProperty, PhoneProperty, MailProperty, Museum.Exhibitor.TypeProperty
                };
                table = new[] {"exhibitors, persons"};
                k = new[] {"persons.id"};
                v = new[] {personId};
                var exhibitorsSql = SqlOperations.Instance.Select(properties, table, k, v);
                Debug.WriteLine(exhibitorsSql);
                var userData = DbConnection.Instance.Query(exhibitorsSql);
                user = (Exhibitor) personFactory.ImportData("Exhibitor", userData[0]);
            }
            else
            {
                properties = new[]
                {
                    "employees.id AS employees_id", "persons.id AS persons_id",
                    NameProperty, PasswordProperty, PhoneProperty, MailProperty,
                    Museum.Employee.SalaryProperty
                };
                table = new[] {"employees", "persons"};
                k = new[] {"persons.id"};
                v = new[] {personId};
                var employeesSql = SqlOperations.Instance.Select(properties, table, k, v);
                Debug.WriteLine(employeesSql);
                var userData = DbConnection.Instance.Query(employeesSql);

                user = (Employee) personFactory.ImportData("Employee", userData[0]);
            }

            return user;
        }

        public static Person Login(string mailInserted, string passwordInserted)
        {
            var mail = mailInserted;
            var password = passwordInserted;

            var properties = new[] {"*"};
            var table = new[] {"persons"};
            var keys = new[] {MailProperty};
            var values = new[] {mail};
            var checkEmailAvailability = SqlOperations.Instance.Select(properties, table, keys, values);
            Debug.WriteLine(checkEmailAvailability);
            var checkEmailAvailabilityResult = DbConnection.Instance.Query(checkEmailAvailability);
            if (checkEmailAvailabilityResult != null)
                if (checkEmailAvailabilityResult.Count > 0)
                {
                    //Debug.WriteLine("Tem n linhas:"+ checkEmailAvailabilityResult.Count);
                    var adapter = new DictionaryAdapter(checkEmailAvailabilityResult[0]);
                    if (adapter.GetValue(PasswordProperty).Equals(password))
                    {
                        properties = new[] {"*"};
                        table = new[] {"exhibitors"};
                        keys = new[] {"persons_id"};
                        values = new[] {adapter.GetValue("id")};
                        var getExhibitorData = SqlOperations.Instance.Select(properties, table, keys, values);
                        var exhibitorResult = DbConnection.Instance.Query(getExhibitorData);

                        Person user;
                        if (exhibitorResult.Count > 0)
                        {
                            properties = new[]
                            {
                                "exhibitors.id AS exhibitors_id", "persons.id AS persons_id", NameProperty,
                                PasswordProperty, PhoneProperty, MailProperty, Museum.Exhibitor.TypeProperty
                            };
                            table = new[] {"exhibitors, persons"};
                            keys = new[] {"mail"};
                            values = new[] {adapter.GetValue("mail")};
                            var exhibitorsSql = SqlOperations.Instance.Select(properties, table, keys, values);
                            var userData = DbConnection.Instance.Query(exhibitorsSql);
                            user = new Exhibitor(userData[0]);
                        }
                        else
                        {
                            properties = new[]
                            {
                                "employees.id AS employees_id", "persons.id AS persons_id",
                                NameProperty, PasswordProperty, PhoneProperty, MailProperty,
                                Museum.Employee.SalaryProperty
                            };
                            table = new[] {"employees", "persons"};
                            keys = new[] {"mail"};
                            values = new[] {adapter.GetValue("mail")};
                            var employeesSql = SqlOperations.Instance.Select(properties, table, keys, values);
                            //Debug.WriteLine(employeesSQL);
                            var userData = DbConnection.Instance.Query(employeesSql);
                            user = new Employee(userData[0]);
                        }

                        return user;
                    }

                    Console.WriteLine(@"Falta preencher coisas!!!!");
                    return null;
                }
                else
                {
                    Console.WriteLine(@"Falta preencher coisas!!!!");
                    return null;
                }

            return null;
        }

        public int GetMaxMessagesPages()
        {
            var properties = new[] {"*"};
            var table = new[] {"persons_has_messages"};
            var keys = new[] {"persons_id"};
            var values = new[] {Id.ToString()};
            var messages = SqlOperations.Instance.Select(properties, table, keys, values);
            var result = DbConnection.Instance.Query(messages);
            int quantity;
            if (result == null)
                quantity = 1;
            else
                quantity = (int) Math.Ceiling((double) result.Count / 5);
            return quantity;
        }

        public abstract void GetData(Dictionary<string, string> values);

        public abstract bool SubmitData();

        public bool CheckAvailability(string insertedMail)
        {
            var properties = new[] {"*"};
            var table = new[] {"persons"};
            var keys = new[] {MailProperty};
            var values = new[] {insertedMail};
            var person = SqlOperations.Instance.Select(properties, table, keys, values);
            var persons = DbConnection.Instance.Query(person);
            Debug.WriteLine(persons.Count);
            if (persons.Count > 0)
                return false;
            return true;
        }

        public abstract void Update(string properties, string values, string table);

        public void UpdateSequence(string table, string[] properties, string[] values)
        {
            var update = SqlOperations.Instance.Update(Id, table, properties, values);
            Debug.WriteLine(update);
            DbConnection.Instance.Execute(update);
        }
    }
}