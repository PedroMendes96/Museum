using System;
using System.Collections.Generic;

namespace Museum
{
    public class Message
    {
        public static readonly string ContentProperty = "content";

        private int id { get; set; }

        public int Id
        {
            get => id;
            set => id = value;
        }

        private string content { get; set; }

        public string Content
        {
            get => content;
            set => content = value;
        }

        private Person sender { get; set; }

        public Person Sender
        {
            get => sender;
            set => sender = value;
        }

        private List<Person> receivers { get; set; }

        public List<Person> Receivers
        {
            get => receivers;
            set => receivers = value;
        }

        public void Save()
        {
            var insertMessages = "INSERT INTO messages (content,sender_id) VALUES ({0},{1})";
            insertMessages = string.Format(insertMessages, Content, sender.Id);
            var dbConnection = new DBConnection();
            dbConnection.Execute(insertMessages);
            foreach (var receiver in receivers)
            {
                var notificationUser = "INSERT INTO persons_has_messages (persons_id,messages_id) VALUES ({1},{2})";
                notificationUser = string.Format(notificationUser, receiver.Id, id);
                dbConnection.Execute(notificationUser);
            }
        }

        public void Update(string changeProperties, string changeValues)
        {
            var properties = changeProperties.Split('-');
            var values = changeValues.Split('-');
            var error = false;
            for (var i = 0; i < properties.Length; i++)
                if (properties[i] != ContentProperty)
                    error = true;
            if (error)
            {
                Console.WriteLine("Nao e possivel efetuar essa operacao!");
            }
            else
            {
                var update = "UPDATE INTO messages SET ";
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
}