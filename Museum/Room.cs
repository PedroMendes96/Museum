using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;

namespace Museum
{
    public class Room
    {
        public int Id { get; set; }
        public float Size { get; set; }
        public string Description { get; set; }
        public IList ArtPiecesList { get; set; }

        public Room(string size, string description)
        {
            ArtPiecesList = new List<ArtPiece>();
            Size = float.Parse(size);
            Description = description;
        }

        public Room(Dictionary<string, string> room)
        {
            var roomAdapter = new DictionaryAdapter(room);
            Id = int.Parse(roomAdapter.GetValue("id"));
            Size = float.Parse(roomAdapter.GetValue("size"));
            Description = roomAdapter.GetValue("description");
            ArtPiecesList = new List<ArtPiece>();
        }

        public override string ToString()
        {
            return Id + " ";
        }

        public void Save()
        {
            Id = DbQuery.InsertRoom(Size.ToString(CultureInfo.CurrentCulture), Description);
        }

        public void Update(string changeProperties, string changeValues)
        {
            var properties = changeProperties.Split('-');
            var values = changeValues.Split('-');
            var error = false;
            foreach (var property in properties)
                if (property != DbQuery.SizeProperty && property != DbQuery.DescriptionProperty &&
                    property != DbQuery.EventProperty)
                    error = true;

            if (error)
            {
                Console.WriteLine(@"Falta preencher coisas!!!!");
            }
            else
            {
//                var update = SqlOperations.Instance.Update(Id, "rooms", properties, values);
//                DbConnection.Instance.Execute(update);
                DbQuery.UpdateSequence(Id, "rooms", properties, values);
            }
        }
    }
}