using System;
using System.Collections.Generic;

namespace Museum
{
    public class Photography : ArtPiece
    {
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
            Id = DbQuery.InsertArtPiece(Name,Description, Exhibitor.IdExhibitor.ToString());
            PhotographyId = DbQuery.InsertSpecificArtPiece(DbQuery.Photographies,Size.ToString(),Id.ToString(), DbQuery.SizeProperty);
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
                else if (table == DbQuery.Photographies)
                {
                    if (property != DbQuery.SizeProperty) error = true;
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