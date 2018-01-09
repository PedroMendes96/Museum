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
            var dbConnection = new DBConnection();
            var startIndex = (index - 1) * 5 + 1;
            var endIndex = (index - 1) * 5 + 5;
            var messages = "SELECT * FROM persons_has_messages WHERE person_id={0} and ROWNUM >= {1} and ROWNUM < {2}";
            messages = string.Format(messages, startIndex, endIndex);
            var chosenMessages = dbConnection.Query(messages);
            var messageList = new List<Message>();
            foreach (var message in chosenMessages)
            {
                var dictonaryAdapter = new DictonaryAdapter(message);
                var messageInstance = new Message();
                messageInstance.Id = int.Parse(dictonaryAdapter.GetValue("id"));
                messageInstance.Content = dictonaryAdapter.GetValue("content");
//                Falta fazer o importar nas funcoes para isto funcionar
//                messageInstance.Sender = Int32.Parse(dictonaryAdapter.GetValue("sender_id"));
                messageList.Add(messageInstance);
            }

            return messageList;
        }

        public int GetMaxMessagesPages()
        {
            var messages = "SELECT * FROM persons_has_messages WHERE person_id={0}";
            messages = string.Format(messages, Id);
            var dbConnection = new DBConnection();
            var result = dbConnection.Query(messages);
            var quantity = Math.Ceiling((double) result.Count / 5);
            return (int) quantity;
        }

        public List<Process> GetProcesses(int index, string type)
        {
            var dbConnection = new DBConnection();
            var startIndex = (index - 1) * 5 + 1;
            var endIndex = (index - 1) * 5 + 5;
            var processes = "";
            if (type == Employee)
                processes += "SELECT * FROM processes WHERE employees_id={0}";
            else if (type == Employee)
                processes += "SELECT * FROM processes WHERE exhibitor_id={0}";
            else
                Console.WriteLine("Efetuou algum erro na atribuicao do tipo da pessoa1");
            processes = string.Format(processes, RoleId());
            var chosenProcesses = dbConnection.Query(processes);
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
            var processes = "SELECT * FROM processes WHERE";
            if (type == Employee)
            {
                processes += " employees_id={0}";
            }
            else if (type == Exhibitor)
            {
                processes += " exhibitors_id={0}";
            }
            else
            {
                Console.WriteLine("Ocorreu algum erro na definicao do tipo de pessoa!");
                return 0;
            }

            processes = string.Format(processes, RoleId());
            var dbConnection = new DBConnection();
            var result = dbConnection.Query(processes);
            var quantity = Math.Ceiling((double) result.Count / 5);
            return (int) quantity;
        }

        public abstract void GetData();

        public abstract void SubmitData();

        public abstract bool CheckAvailability();

        public abstract void Save();

        public abstract void Update(string properties, string values, string table);

        public abstract Person ImportData(string SQL);

        public void UpdateSequence(string table, string[] properties, string[] values)
        {
            var update = "UPDATE INTO " + table + " SET ";
            for (var i = 0; i < properties.Length; i++)
                if (i == properties.Length - 1)
                    update += properties[i] + "=" + values[i];
                else
                    update += properties[i] + "=" + values[i] + ", ";
            update += " WHERE id=" + id;
            var dbConnection = new DBConnection();
            dbConnection.Execute(update);
        }
    }
}