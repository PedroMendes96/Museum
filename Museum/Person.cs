using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Museum
{
    public abstract class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int Phone { get; set; }
        public string Mail { get; set; }
        public IList<Message> Messages { get; set; } = new List<Message>();


        public abstract int RoleId();

        public bool CreateAccountMethod(Dictionary<string, string> values)
        {
            var adapter = new DictionaryAdapter(values);
            if (CheckAvailability(adapter.GetValue(DbQuery.MailProperty)))
            {
                GetData(values);
                return SubmitData();
            }

            return false;
        }

        public void GetMessages()
        {

            var l = DbQuery.GetPeopleMessage(Id.ToString());
            foreach (var dmessages in l) //dicionario com as msgs
            {
                var dam = new DictionaryAdapter(dmessages);
                var senderId = dam.GetValue("sender_id");
                if (senderId != null)
                {
                    var li = DbQuery.GetPeopleById(senderId);
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
            var exhibitorResult = DbQuery.GetExhibitorByPersonId(personId);
            Person user;
            var personFactory = FactoryCreator.Instance.CreateFactory("PersonFactory");
            if (exhibitorResult.Count > 0)
            {
                user = (Exhibitor) personFactory.ImportData("Exhibitor", exhibitorResult[0]);
            }
            else
            {
                var userData = DbQuery.GetEmployeeByPersonId(personId);
                user = (Employee) personFactory.ImportData("Employee", userData[0]);
            }

            return user;
        }

        public static Person Login(string mailInserted, string passwordInserted)
        {
            var mail = mailInserted;
            var password = passwordInserted;
            var checkEmailAvailabilityResult = DbQuery.GetPeopleByMail(mail);
            if (checkEmailAvailabilityResult != null)
                if (checkEmailAvailabilityResult.Count > 0)
                {
                    //Debug.WriteLine("Tem n linhas:"+ checkEmailAvailabilityResult.Count);
                    var adapter = new DictionaryAdapter(checkEmailAvailabilityResult[0]);
                    if (adapter.GetValue(DbQuery.PasswordProperty).Equals(password))
                    {
                        var exhibitorResult = DbQuery.GetExhibitorByPersonId(adapter.GetValue("id"));

                        Person user;
                        if (exhibitorResult.Count > 0)
                        {
                            user = new Exhibitor(exhibitorResult[0]);
                        }
                        else
                        {
                            var userData = DbQuery.GetEmployeeByPersonId(adapter.GetValue("id"));
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
            var result = DbQuery.GetPeopleMessage(Id.ToString());
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
            var persons = DbQuery.GetPeopleByMail(insertedMail);
            Debug.WriteLine(persons.Count);
            return persons.Count <= 0;
        }

        public abstract void Update(string properties, string values, string table);

        public void UpdateSequence(string table, string[] properties, string[] values)
        {
//            var update = SqlOperations.Instance.Update(Id, table, properties, values);
//            Debug.WriteLine(update);
//            DbConnection.Instance.Execute(update);
            DbQuery.UpdateSequence(Id, table, properties, values);
        }
    }
}