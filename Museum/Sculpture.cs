using System;

namespace Museum
{
    public class Sculpture : ArtPiece
    {
        public Sculpture()
        {
            element = null;
        }

        public Sculpture(IDecorator element)
        {
            this.element = element;
        }

        private int id { get; set; }

        public int Id
        {
            get => id;
            set => id = value;
        }

        private double volume { get; set; }

        public double Volume
        {
            get => volume;
            set => volume = value;
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
            var insertItems = "INSERT INTO items (name,description) VALUES (" + Name + "," + Description + ")";
            var dbConnection = new DBConnection();
            dbConnection.Execute(insertItems);
            var insertSculptures = "INSERT INTO sculptures (volume, items_id) VALUES (" + Volume + "," + id + ")";
            dbConnection.Execute(insertSculptures);
        }

        public override void Update(string changeProperties, string changeValues, string table)
        {
            var properties = changeProperties.Split('-');
            var values = changeValues.Split('-');
            var error = false;
            for (var i = 0; i < properties.Length; i++)
                if (table == Items)
                {
                    if (properties[i] != NameProperty && properties[i] != DescriptionProperty &&
                        properties[i] != RoomProperty) error = true;
                }
                else if (table == Sculptures)
                {
                    if (properties[i] != SizeProperty) error = true;
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