using System;
using System.Collections;
using System.Collections.Generic;

namespace Museum
{
    public class Temporary : Events
    {
        public static readonly string ScheduleProperty = "schedule_id";

        public Process Process { get; set; }
        public int TemporaryId { get; set; }
        public IList ScheduleList { get; set; }

        public Temporary()
        {
            ScheduleList = new List<Schedule>();
        }

        public Temporary(Dictionary<string, string> dictionary)
        {
        }

        public override void Save()
        {
            Id = DbQuery.InsertEvent(Process.Description, Process.Name, Process.Title);
            TemporaryId = DbQuery.InsertTemporary(Id.ToString(), Process.Id.ToString(), Process.Schedule.Id.ToString());
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
                DbQuery.UpdateSequence(Id,table, properties, values);
        }
    }
}