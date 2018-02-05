using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Museum
{
    public class Message
    {
        public static readonly string ContentProperty = "content";
        public static readonly string TitleProperty = "title";

        public string LastUpdate { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Person Sender { get; set; }

        public Message(Dictionary<string, string> data, Person sender)
        {
            var dictonaryAdapter = new DictionaryAdapter(data);
            Id = int.Parse(dictonaryAdapter.GetValue("messages_id"));
            Content = dictonaryAdapter.GetValue("content");
            Title = dictonaryAdapter.GetValue("title");
            LastUpdate = dictonaryAdapter.GetValue("lastUpdate");
            Sender = sender;
        }

        public Message()
        {
        }

        public static IList<Dictionary<string, string>> GetMessageLastUpdate(string id)
        {
            var selvals = new[] {"lastUpdate"};
            var tables = new[] {"messages"};
            var keys = new[] {"id"};
            var values = new[] {id};
            var select = SqlOperations.Instance.Select(selvals, tables, keys, values);
            return DbConnection.Instance.Query(select);
        }

        public Dictionary<string, string> Save(string receiverId)
        {
            var so = SqlOperations.Instance;
            var db = DbConnection.Instance;
            var table = "messages";
            var keys = new[] {ContentProperty, "sender_id", TitleProperty};
            var values = new[] {Content, Sender.Id.ToString(), Title};
            var insertMessages = so.Insert(table, keys, values);
            var messageId = db.Execute(insertMessages);
            Id = messageId;

            table = "persons_has_messages";
            keys = new[] {"persons_id", "messages_id"};
            values = new[] {receiverId, messageId.ToString()};
            var insert = so.Insert(table, keys, values);
            Debug.WriteLine(insert);
            db.Execute(insert);

            var props = new[] {"*"};
            string[] tables = {"persons"};
            keys = new[] {"id"};
            values = new[] {receiverId};
            var select = so.Select(props, tables, keys, values);
            var list = db.Query(select);
            Debug.WriteLine(list.Count);
            Dictionary<string, string> dict = null;
            foreach (var d in list) //dicionario com o receiver
                dict = d;
            return dict;
        }


        public void Update(string changeProperties, string changeValues) // retirar?
        {
            var properties = changeProperties.Split('-');
            var values = changeValues.Split('-');
            var error = false;
            foreach (var property in properties)
                if (property != ContentProperty)
                    error = true;

            if (error)
            {
                Console.WriteLine(@"Falta preencher coisas!!!!");
            }
            else
            {
                var update = SqlOperations.Instance.Update(Id, "messages", properties, values);
                DbConnection.Instance.Execute(update);
            }
        }
    }
}