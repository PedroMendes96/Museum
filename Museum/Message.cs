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

//        Nao sei se sera necessario
        private List<Person> receivers { get; set; }

        public List<Person> Receivers
        {
            get => receivers;
            set => receivers = value;
        }

        public Message(Dictionary<string,string> data, Person sender)
        {
            DictonaryAdapter dictonaryAdapter = new DictonaryAdapter(data);
            Id = int.Parse(dictonaryAdapter.GetValue("messages_id"));
            Content = dictonaryAdapter.GetValue("content");
            Sender = sender;
        }

        public Message()
        {
            
        }

        public void Save()
        {
            var table = "messages";                                                     
            var keys = new [] {ContentProperty,"sender_id"};
            var values = new [] {Content,sender.Id.ToString()};
            var insertMessages = SqlOperations.Instance.Insert(table, keys, values);
            DBConnection.Instance.Execute(insertMessages);

            table = "persons_has_messages";
            keys = new [] {"persons_id","messages_id"};
            foreach (var receiver in receivers)
            {
                values = new [] {receiver.Id.ToString(), id.ToString()};
                var notificationUser = SqlOperations.Instance.Insert(table, keys, values);
                DBConnection.Instance.Execute(notificationUser);
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
                var update = SqlOperations.Instance.Update(id, "messages", properties, values);
                DBConnection.Instance.Execute(update);
            }
        }
    }
}