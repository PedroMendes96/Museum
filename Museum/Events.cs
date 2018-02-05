using System.Collections.Generic;

namespace Museum
{
    public abstract class Events
    {
        public static readonly string DescriptionProperty = "description";
        public static readonly string Permanent = "permanents";
        public static readonly string Temporary = "temporaries";
        public static readonly string Event = "events";
        public static readonly string TitleProperty = "title";
        public static readonly string NameProperty = "name";

        public int Id { get; set; }

        public static IList<Dictionary<string, string>> GetAllEventsOrderedByLast()
        {
            var exhibitions = "SELECT * FROM events ORDER BY lastUpdate DESC";
            return DbConnection.Instance.Query(exhibitions);
        }

        public static IList<Dictionary<string, string>> GetEventsByRoom(string id)
        {
            var properties = new[] {"events_id"};
            var tables = new[] {"rooms_has_events"};
            var keys = new[] {"rooms_id"};
            var values = new[] {id};

            var eventsSql = SqlOperations.Instance.Select(properties, tables, keys, values);
            return DbConnection.Instance.Query(eventsSql);
        }

        public abstract void Save();

        public abstract void Update(string properties, string values, string table);

        public void UpdateSequence(string table, string[] properties, string[] values)
        {
            var update = SqlOperations.Instance.Update(Id, table, properties, values);
            DbConnection.Instance.Execute(update);
        }
    }
}