using System;
using System.Collections.Generic;

namespace Museum
{
    public class Permanent : Events
    {
        public Permanent()
        {
        }

        public Permanent(Dictionary<string, string> dictionary)
        {
        }



        private int id { get; set; }

        public int PermanentId
        {
            get => id;
            set => id = value;
        }

        private string name { get; set; }

        public string Name
        {
            get => name;
            set => name = value;
        }

        private string description { get; set; }

        public string Description
        {
            get => description;
            set => description = value;
        }

        private string title { get; set; }

        public string Title
        {
            get => title;
            set => title = value;
        }

        private IList<int> idRooms { get; set; }

        public IList<int> IdRooms
        {
            get => idRooms;
            set => idRooms = value;
        }

        private bool CheckRoomAvailability()
        {
            foreach (var specificId in idRooms)
            {
                var isRoomOcuppied = "SELECT * FROM processes_has_rooms WHERE rooms_id=" + specificId;
                var isRoomOcuppiedResult = DbConnection.Instance.Query(isRoomOcuppied);
                if (isRoomOcuppiedResult.Count > 0)
                {
                    return false;
                }
            }
            return true;
        }

        public override void Save()
        {

            if (CheckRoomAvailability())
            {
                var table = "events";
                var keys = new[] {DescriptionProperty, NameProperty, TitleProperty};
                var values = new[] {Description, Name, Title};
                var insertEvent = SqlOperations.Instance.Insert(table, keys, values);
                Id = DbConnection.Instance.Execute(insertEvent);

                table = "permanents";
                keys = new[] {"events_id"};
                values = new[] {Id.ToString()};
                var insertPermanent = SqlOperations.Instance.Insert(table, keys, values);
                DbConnection.Instance.Execute(insertPermanent);

                foreach (var idRoom in idRooms)
                {
                    table = "rooms_has_events";
                    keys = new[] {"events_id", "rooms_id"};
                    values = new[] {Id.ToString(), idRoom.ToString()};
                    var insertRoomsEvents = SqlOperations.Instance.Insert(table, keys, values);
                    DbConnection.Instance.Execute(insertRoomsEvents);
                }
            }
        }

        public static IList<Dictionary<string, string>> GetPermanentsInEvents(string id)
        {
            var isPermanent = "SELECT title,name,description FROM permanents,events WHERE events.id=" +
                              id + " AND events.id=permanents.events_id";
            return DbConnection.Instance.Query(isPermanent);
        }

        public static IList<Dictionary<string, string>> GetAllPermanents()
        {
            var properties = new[] { "*" };
            var table = new[] { "permanents" };
            var permanentEvents = SqlOperations.Instance.Select(properties, table);
            return DbConnection.Instance.Query(permanentEvents);
        }

        public override void Update(string changeProperties, string changeValues, string table)
        {
            var properties = changeProperties.Split('-');
            var values = changeValues.Split('-');
            var error = false;
            foreach (var property in properties)
                if (table == Event)
                {
                    if (property != DescriptionProperty) error = true;
                }
                else if (table == Permanent)
                {
                    error = true;
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