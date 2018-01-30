using System.Collections.Generic;

namespace Museum
{
    public abstract class Events : IDecorator
    {
        public static readonly string DescriptionProperty = "description";
        public static readonly string Permanent = "permanents";
        public static readonly string Temporary = "temporaries";
        public static readonly string Event = "events";

        private int id { get; set; }

        public int Id
        {
            get => id;
            set => id = value;
        }

        public Process Process { get; set; }

        public abstract string GetInformation();

        public static IList<Dictionary<string, string>> GetAllEventsOrderedByLast()
        {
            var exhibitions = "SELECT * FROM events ORDER BY lastUpdate DESC";
            return DBConnection.Instance.Query(exhibitions);
        }

        public static IList<Dictionary<string, string>> GetEventsByRoom(string id)
        {
            var properties = new[] { "events_id" };
            var tables = new[] { "rooms_has_events" };
            var keys = new[] { "rooms_id" };
            var values = new[] { id };

            var eventsSQL = SqlOperations.Instance.Select(properties, tables, keys, values);
            return DBConnection.Instance.Query(eventsSQL);
        }

        public abstract void Save();

        public abstract void Update(string properties, string values, string table);

        public void UpdateSequence(string table, string[] properties, string[] values)
        {
            var update = SqlOperations.Instance.Update(Id, table, properties, values);
            DBConnection.Instance.Execute(update);
        }
    }
}