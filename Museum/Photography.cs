using System;
using System.Collections.Generic;
using System.Globalization;

namespace Museum
{
    public class Photography : ArtPiece
    {
        public static readonly string SizeProperty = "size";

        public Photography()
        {
        }

        public Photography(Dictionary<string, string> dictionary)
        {
        }

        private int id { get; set; }

        public int PhotographyId
        {
            get => id;
            set => id = value;
        }

        private double size { get; set; }

        public double Size
        {
            get => size;
            set => size = value;
        }

        public override void SetDimension(string newSize)
        {
            Size = double.Parse(newSize);
        }

        public override string GetInformation()
        {
            throw new NotImplementedException();
        }

        public override void Save()
        {
            var table = "items";
            var keys = new[] {NameProperty, DescriptionProperty, "exhibitors_id"};
            var values = new[] {Name, Description, Exhibitor.IdExhibitor.ToString()};
            var insertItems = SqlOperations.Instance.Insert(table, keys, values);
            Id = DbConnection.Instance.Execute(insertItems);

            table = "photographies";
            keys = new[] {SizeProperty, "items_id"};
            values = new[] {Size.ToString(CultureInfo.CurrentCulture), Id.ToString()};
            var insertPhotographies = SqlOperations.Instance.Insert(table, keys, values);
            DbConnection.Instance.Execute(insertPhotographies);
        }

        public override void Update(string changeProperties, string changeValues, string table)
        {
            var properties = changeProperties.Split('-');
            var values = changeValues.Split('-');
            var error = false;
            foreach (var property in properties)
                if (table == Items)
                {
                    if (property != NameProperty && property != DescriptionProperty &&
                        property != RoomProperty) error = true;
                }
                else if (table == Photographies)
                {
                    if (property != SizeProperty) error = true;
                }
                else
                {
                    error = true;
                }

            if (error)
                Console.WriteLine(@"Falta preencher coisas!!!!");
            else
                UpdateSequence(table, properties, values);
        }
    }
}