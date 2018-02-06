using System;
using System.Collections.Generic;
using System.Globalization;

namespace Museum
{
    public class Painting : ArtPiece
    {
        public static readonly string SizeProperty = "size";

        public int PaintingId { get; set; }
        public double Size { get; set; }

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

        public override void SetDimension(string size)
        {
            try
            {
                Size = double.Parse(size);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public override string GetInformation()
        {
            var text = nameof(Painting) + "-" + Name + "-" + Description + "-" + Size + "¬";
            if (Element != null)
                return text + Element.GetInformation();
            return text;
        }

        public override void Save()
        {
            Id = DbQuery.InsertArtPiece(Name,Description, Exhibitor.IdExhibitor.ToString());
            PaintingId = DbQuery.InsertSpecificArtPiece(DbQuery.Paitings,Size.ToString(CultureInfo.CurrentCulture), Id.ToString(),SizeProperty); 
        }

        public override void Update(string changeProperties, string changeValues, string table)
        {
            var properties = changeProperties.Split('-');
            var values = changeValues.Split('-');
            var error = false;
            foreach (var property in properties)
                if (table == DbQuery.Items)
                {
                    if (property != DbQuery.NameProperty && property != DbQuery.DescriptionProperty &&
                        property != DbQuery.RoomProperty) error = true;
                }
                else if (table == DbQuery.Paitings)
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
                DbQuery.UpdateSequence(Id,table, properties, values);
        }
    }
}