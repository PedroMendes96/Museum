using System;
using System.Collections.Generic;

namespace Museum
{
    public class Permanent : Events
    {
        public Permanent(IDecorator element)
        {
            this.element = element;
        }
        
        public Permanent(Dictionary<string,string> dictionary)
        {
            
        }

        public Permanent()
        {
            element = null;
        }

        private int id { get; set; }

        public int Id
        {
            get => id;
            set => id = value;
        }

        private IDecorator element { get; set; }

        public IDecorator Element
        {
            get => element;
            set => element = value;
        }

        public override string GetInformation()
        {
            throw new NotImplementedException();
        }

        public override void Save()
        {
            var table = "events";                                                     
            var keys = new [] {DescriptionProperty};
            var values = new [] {Description};
            var insertEvent  = SqlOperations.Instance.Insert(table, keys, values);
            DBConnection.Instance.Execute(insertEvent);
            
            table = "permanents";                                                     
            keys = new [] {"events_id"};
            values = new [] {base.Id.ToString()};
            var insertPermanent  = SqlOperations.Instance.Insert(table, keys, values);
            DBConnection.Instance.Execute(insertPermanent);
        }
        
        public override void Update(string changeProperties, string changeValues, string table)
        {
            var properties = changeProperties.Split('-');
            var values = changeValues.Split('-');
            var error = false;
            for (var i = 0; i < properties.Length; i++)
                if (table == Event)
                {
                    if (properties[i] != DescriptionProperty) error = true;
                }
                else if (table == Permanent)
                {
//                    if ()
//                    {
                    error = true;
//                    }
                }
                else
                {
                    error = true;
                }

            if (error)
                Console.WriteLine("Nao e possivel efetuar essa operacao!");
            else
                UpdateSequence(table, properties, values);
        }
    }
}