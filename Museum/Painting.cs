using System;
using System.Collections.Generic;
using System.Globalization;

namespace Museum
{
    public class Painting : ArtPiece
    {
        public static readonly string SizeProperty = "size";

        public Painting()
        {
            Element = null;
        }

        public Painting(Dictionary<string, string> dictionary)
        {
            Element = null;
            //
            var adapter = new DictionaryAdapter(dictionary);
            Id = int.Parse(adapter.GetValue("itemId"));
            PaintingId = int.Parse(adapter.GetValue("specificId"));
            Size = double.Parse(adapter.GetValue("size"));
            Name = adapter.GetValue("name");
            Description = adapter.GetValue("description");
        }

        private int id { get; set; }

        public int PaintingId
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

        public override void SetDimension(string size)
        {
            Size = double.Parse(size);
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
            var insertPainting = SqlOperations.Instance.Insert(table, keys, values);
            PaintingId = DbConnection.Instance.Execute(insertPainting);
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
                else if (table == Paitings)
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