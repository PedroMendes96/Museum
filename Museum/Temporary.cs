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

        private int id { get; set; }

        public int Id
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

        private IDecorator element { get; set; }

        public IDecorator Element
        {
            get => element;
            set => element = value;
        }

        public override string GetInformation()
        {
            throw new NotImplementedException();
        }

        public override void Save()
        {
            var insertEvent = "INSERT INTO events (description) VALUES (" + Description + ")";
            var dbConnection = new DBConnection();
            dbConnection.Execute(insertEvent);
            var insertTemporary = "INSERT INTO temporaries (events_id) VALUES (" + base.Id + ")";
            dbConnection.Execute(insertTemporary);
        }

        public override void Update(string changeProperties, string changeValues, string table)
        {
            var properties = changeProperties.Split('-');
            var values = changeValues.Split('-');
            var error = false;
            for (var i = 0; i < properties.Length; i++)
                if (table == Event)
                {
                    if (properties[i] != DescriptionProperty) error = true;
                }
                else if (table == Temporary)
                {
                    if (properties[i] != ScheduleProperty) error = true;
                }
                else
                {
                    error = true;
                }

            if (error)
                Console.WriteLine("Nao e possivel efetuar essa operacao!");
            else
                UpdateSequence(table, properties, values);
        }
    }
}