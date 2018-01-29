using System;
using System.Collections.Generic;

namespace Museum
{
    public class Painting : ArtPiece
    {
        public Painting()
        {
        }

        public Painting(Dictionary<string, string> dictionary)
        {
        }

        private int id { get; set; }

        public int PaintingId
        {
            get => id;
            set => id = value;
        }

        public override string GetInformation()
        {
            throw new NotImplementedException();
        }

        public override void Save()
        {
            var table = "items";
            var keys = new[] {NameProperty, DescriptionProperty};
            var values = new[] {Name, Description};
            var insertItems = SqlOperations.Instance.Insert(table, keys, values);
            DBConnection.Instance.Execute(insertItems);

            table = "photagraphies";
            keys = new[] {SizeProperty, "items_id"};
            values = new[] {Size.ToString(), Id.ToString()};
            var insertPhotographies = SqlOperations.Instance.Insert(table, keys, values);
            DBConnection.Instance.Execute(insertPhotographies);
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
                else if (table == Paitings)
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