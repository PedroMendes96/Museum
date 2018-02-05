using System;
using System.Collections.Generic;
using System.Globalization;

namespace Museum
{
    public class Photography : ArtPiece
    {
        public static readonly string SizeProperty = "size";

        public int PhotographyId { get; set; }
        public double Size { get; set; }

        public Photography()
        {
            Element = null;
        }

        public Photography(Dictionary<string, string> dictionary)
        {
            Element = null;
            //
            var adapter = new DictionaryAdapter(dictionary);
            Id = int.Parse(adapter.GetValue("itemId"));
            PhotographyId = int.Parse(adapter.GetValue("specificId"));
            Size = double.Parse(adapter.GetValue("size"));
            Name = adapter.GetValue("name");
            Description = adapter.GetValue("description");
        }

        public override void SetDimension(string newSize)
        {
            try
            {
                Size = double.Parse(newSize);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public override string GetInformation()
        {
            var text = nameof(Photography) + "-" + Name + "-" + Description + "-" + Size + "¬";
            if (Element != null)
                return text + Element.GetInformation();
            return text;
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
            PhotographyId = DbConnection.Instance.Execute(insertPhotographies);
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