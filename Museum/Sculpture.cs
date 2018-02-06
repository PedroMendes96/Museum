using System;
using System.Collections.Generic;
using System.Globalization;

namespace Museum
{
    public class Sculpture : ArtPiece
    {
        public int SculptureId { get; set; }
        public double Volume { get; set; }

        public Sculpture()
        {
            Element = null;
        }

        public Sculpture(Dictionary<string, string> dictionary)
        {
            Element = null;
            //
            var adapter = new DictionaryAdapter(dictionary);
            Id = int.Parse(adapter.GetValue("itemId"));
            SculptureId = int.Parse(adapter.GetValue("specificId"));
            Volume = double.Parse(adapter.GetValue("volume"));
            Name = adapter.GetValue("name");
            Description = adapter.GetValue("description");
        }

        public override void SetDimension(string size)
        {
            try
            {
                Volume = double.Parse(size);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public override string GetInformation()
        {
            var text = nameof(Sculpture) + "-" + Name + "-" + Description + "-" + Volume + "¬";
            if (Element != null)
                return text + Element.GetInformation();
            return text;
        }

        public override void Save()
        {
            Id = DbQuery.InsertArtPiece(Name, Description, Exhibitor.IdExhibitor.ToString());
            SculptureId = DbQuery.InsertSpecificArtPiece("sculptures", Volume.ToString(CultureInfo.CurrentCulture), Id.ToString(), DbQuery.VolumeProperty);
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
                else if (table == DbQuery.Sculptures)
                {
                    if (property != DbQuery.VolumeProperty) error = true;
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