using System;

namespace Museum
{
    public class Permanent : Events
    {
        public Permanent(IDecorator element)
        {
            this.element = element;
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
            var insertEvent = "INSERT INTO events (description) VALUES (" + Description + ")";
            var dbConnection = new DBConnection();
            dbConnection.Execute(insertEvent);
            var insertPermanent = "INSERT INTO permanents (events_id) VALUES (" + base.Id + ")";
            dbConnection.Execute(insertPermanent);
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