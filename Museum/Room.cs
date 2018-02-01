using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;

namespace Museum
{
    public class Room
    {
        public static readonly string SizeProperty = "size";
        public static readonly string DescriptionProperty = "description";
        public static readonly string EventProperty = "events_id";

        public static IList<Dictionary<string, string>> GetAllRooms()
        {
            var attr = new[] { "id" };
            var tables = new[] { "rooms" };
            var roomsSql = SqlOperations.Instance.Select(attr, tables);
            Console.WriteLine(roomsSql);
            return DbConnection.Instance.Query(roomsSql);
        }

        public static IList<Dictionary<string, string>> GetAllRoomsByProcess(string id)
        {
            var roomsSql = "SELECT * FROM processes_has_rooms WHERE processes_id=" + id;
            return DbConnection.Instance.Query(roomsSql);
        }

        public static IList<Dictionary<string, string>> GetAllRoomsById(string id)
        {
            var specRoom = "SELECT * FROM rooms WHERE id=" + id;
            return DbConnection.Instance.Query(specRoom);
        }

        public static IList<Dictionary<string, string>> GetAllRoomsByIds(List<int> ids)
        {
            var roomsSQl = "SELECT * FROM rooms WHERE ";

            for (var i = 0; i < ids.Count; i++)
                if (i == ids.Count - 1)
                    roomsSQl += "id=" + ids[i];
                else
                    roomsSQl += "id=" + ids[i] + " OR ";

            return DbConnection.Instance.Query(roomsSQl);
        }

        public static IList<Dictionary<string, string>> GetEventsByRoom(string id)
        {
            var roomsEvents = "SELECT * FROM rooms_has_events WHERE rooms_id=" + id;
            return DbConnection.Instance.Query(roomsEvents);
        }

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

        private int id { get; set; }

        public int Id
        {
            get => id;
            set => id = value;
        }

        private float size { get; set; }

        public float Size
        {
            get => size;
            set => size = value;
        }

        private string description { get; set; }

        public string Description
        {
            get => description;
            set => description = value;
        }

        public IList ArtPiecesList { get; set; }

        public override string ToString()
        {
            return Id + " ";
        }

        public void Save()
        {
            var table = "rooms";
            var keys = new[] {SizeProperty, DescriptionProperty};
            var values = new[] {Size.ToString(CultureInfo.CurrentCulture), Description};
            var insertRoom = SqlOperations.Instance.Insert(table, keys, values);
            Id = DbConnection.Instance.Execute(insertRoom);
        }

        public void Update(string changeProperties, string changeValues)
        {
            var properties = changeProperties.Split('-');
            var values = changeValues.Split('-');
            var error = false;
            foreach (var property in properties)
                if (property != SizeProperty && property != DescriptionProperty &&
                    property != EventProperty)
                    error = true;

            if (error)
            {
                Console.WriteLine(@"Falta preencher coisas!!!!");
            }
            else
            {
                var update = SqlOperations.Instance.Update(Id, "rooms", properties, values);
                DbConnection.Instance.Execute(update);
            }
        }
    }
}