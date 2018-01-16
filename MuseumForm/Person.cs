using System;
using System.Collections.Generic;

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

        private IList<Message> notifications { get; set; } = new List<Message>();

        public IList<Message> Notifications
        {
            get => notifications;
            set => notifications = value;
        }

        public abstract int RoleId();

        public void CreateAccountMethod()
        {
            GetData();
            SubmitData();
        }

        public List<Message> GetMessages(int index)
        {
            var startIndex = (index - 1) * 5 + 1;
            var endIndex = (index - 1) * 5 + 5;
            var messages = "SELECT * FROM persons_has_messages WHERE person_id={0} and ROWNUM >= {1} and ROWNUM < {2}";
            messages = string.Format(messages, startIndex, endIndex);
            var chosenMessages = DBConnection.Instance.Query(messages);
            var messageList = new List<Message>();
            foreach (var message in chosenMessages)
            {
                var dictonaryAdapter = new DictonaryAdapter(message);
                var messageInstance = new Message();
                messageInstance.Id = int.Parse(dictonaryAdapter.GetValue("id"));
                messageInstance.Content = dictonaryAdapter.GetValue("content");
//                Falta fazer o importar nas funcoes para isto funcionar
//                messageInstance.Sender = int.Parse(dictonaryAdapter.GetValue("sender_id"));
                messageList.Add(messageInstance);
            }

            return messageList;
        }

        public int GetMaxMessagesPages()
        {
            var properties = new [] { "*" };
            var table = new [] { "persons_has_messages" };
            var keys = new [] {"person_id"};
            var values = new [] {Id.ToString()};
            var messages = SqlOperations.Instance.Select(properties, table, keys, values);
            var result = DBConnection.Instance.Query(messages);
            var quantity = Math.Ceiling((double) result.Count / 5);
            return (int) quantity;
        }

        public List<Process> GetProcesses(int index, string type)
        {
            var startIndex = (index - 1) * 5 + 1;
            var endIndex = (index - 1) * 5 + 5;
            var properties = new [] { "*" };
            var table = new [] { "processes" };
            var values = new [] {RoleId().ToString()};
            var keys = new[] {""};
            if (type == Employee)
                keys = new [] {"employees_id"};
            else if (type == Employee)
                keys = new[] {"exhibitors_id"};
            else
            {
                Console.WriteLine("Efetuou algum erro na atribuicao do tipo da pessoa1");
                return null;
            }
            var processes = SqlOperations.Instance.Select(properties, table, keys, values);
            var chosenProcesses = DBConnection.Instance.Query(processes);
            var processList = new List<Process>();
            foreach (var process in chosenProcesses)
            {
//       TODO         O PROCESSO ESTA COM MUITAS DEPENDENCIAS CUIDADO
//       TODO         Process processInstance = new Process();
//       TODO         processList.Add(processInstance);
            }

            return processList;
        }

        public int GetMaxProcessesPages(string type)
        {
            var properties = new [] { "*" };
            var table = new [] { "processes" };
            var keys = new [] {""};
            var values = new [] {RoleId().ToString()};
            if (type == Employee)
            {
                keys[0] = "employees_id";
            }
            else if (type == Exhibitor)
            {
                keys[0] = "exhibitors_id";
            }
            else
            {
                Console.WriteLine("Ocorreu algum erro na definicao do tipo de pessoa!");
                return 0;
            }
            var processes = SqlOperations.Instance.Select(properties, table, keys, values);
            var result = DBConnection.Instance.Query(processes);
            var quantity = Math.Ceiling((double) result.Count / 5);
            return (int) quantity;
        }

        public abstract void GetData();

        public abstract void SubmitData();

        public bool CheckAvailability()
        {
            var properties = new [] { "*" };
            var table = new [] { "persons" };
            var keys = new [] {MailProperty};
            var values = new [] {Mail};
            var person = SqlOperations.Instance.Select(properties, table, keys, values);
            var persons = DBConnection.Instance.Query(person);
            if (persons.Count > 0)
                return false;
            return true;
        }

        public abstract void Save();

        public abstract void Update(string properties, string values, string table);

        public void UpdateSequence(string table, string[] properties, string[] values)
        {
            var update = SqlOperations.Instance.Update(Id, table, properties, values);
            DBConnection.Instance.Execute(update);
        }
    }
}