using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Museum
{
    public class Message
    {
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

        public Dictionary<string, string> Save(string receiverId)
        {
            Id = DbQuery.InsertMessage(Content, Sender.Id.ToString(), Title);
            DbQuery.AssociatePersonMessage(receiverId, Id.ToString());
            var list = DbQuery.GetPeopleById(receiverId);
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
                if (property != DbQuery.ContentProperty)
                    error = true;

            if (error)
            {
                Console.WriteLine(@"Falta preencher coisas!!!!");
            }
            else
            {
                DbQuery.UpdateSequence(Id, "messages", properties, values);
//                var update = SqlOperations.Instance.Update(Id, "messages", properties, values);
//                DbConnection.Instance.Execute(update);
            }
        }
    }
}