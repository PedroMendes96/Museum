using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Museum
{
    public class Message
    {
        public static readonly string ContentProperty = "content";
        public static readonly string TitleProperty = "title";


        public Message(Dictionary<string, string> data, Person sender)
        {
            var dictonaryAdapter = new DictonaryAdapter(data);
            Id = int.Parse(dictonaryAdapter.GetValue("messages_id"));
            Content = dictonaryAdapter.GetValue("content");
            Title = dictonaryAdapter.GetValue("title");
            LastUpdate = dictonaryAdapter.GetValue("lastUpdate");
            Sender = sender;
        }

        public Message()
        {
        }

        private string lastUpdate { get; set; }
        private int id { get; set; }
        private string title { get; set; }

        public int Id
        {
            get => id;
            set => id = value;
        }

        public string LastUpdate
        {
            get => lastUpdate;
            set => lastUpdate = value;
        }

        private string content { get; set; }

        public string Title
        {
            get => title;
            set => title = value;
        }

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

        public Dictionary<string, string> Save(string receiver_id)
        {
            var so = SqlOperations.Instance;
            var db = DBConnection.Instance;
            var table = "messages";
            var keys = new[] {ContentProperty, "sender_id", TitleProperty};
            var values = new[] {Content, sender.Id.ToString(), Title};
            var insertMessages = so.Insert(table, keys, values);
            var message_id = db.Execute(insertMessages);
            Id = (int) message_id;

            table = "persons_has_messages";
            keys = new[] {"persons_id", "messages_id"};
            values = new[] {receiver_id, message_id.ToString()};
            var insert = so.Insert(table, keys, values);
            Debug.WriteLine(insert);
            db.Execute(insert);

            var props = new[] {"*"};
            string[] tables = {"persons"};
            keys = new[] {"id"};
            values = new[] {receiver_id};
            var select = so.Select(props, tables, keys, values);
            var list = db.Query(select);
            Debug.WriteLine(list.Count);
            Dictionary<string, string> dict = null;
            foreach (var d in list) //dicionario com o receiver
                dict = d;
            return dict;
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