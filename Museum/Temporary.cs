using System;
using System.Collections;
using System.Collections.Generic;

namespace Museum
{
    public class Temporary : Events
    {
        public static readonly string ScheduleProperty = "schedule_id";

        public Temporary()
        {
            scheduleList = new List<Schedule>();
        }

        public Temporary(Dictionary<string, string> dictionary)
        {
        }

        private int id { get; set; }

        public int TemporaryId
        {
            get => id;
            set => id = value;
        }

        private IList scheduleList { get; set; }

        public IList Schedule
        {
            get => scheduleList;
            set => scheduleList = value;
        }

        public override string GetInformation()
        {
            throw new NotImplementedException();
        }

        public static IList<Dictionary<string, string>> GetTemporariesInEvents(string id)
        {
            var isTemporary = "SELECT * FROM temporaries WHERE events_id=" + id;
            return DbConnection.Instance.Query(isTemporary);
        }

        public override void Save()
        {
            var table = "events";
            var keys = new[] {DescriptionProperty};
            var values = new[] {Process.Description};
            var insertEvent = SqlOperations.Instance.Insert(table, keys, values);
            Id = DbConnection.Instance.Execute(insertEvent);

            table = "temporaries";
            keys = new[] {"events_id", "processes_id", "schedule_id"};
            values = new[] {Id.ToString(), Process.Id.ToString(), Process.Schedule.Id.ToString()};
            var insertTemporaries = SqlOperations.Instance.Insert(table, keys, values);
            DbConnection.Instance.Execute(insertTemporaries);
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
                else if (table == Temporary)
                {
                    if (property != ScheduleProperty) error = true;
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