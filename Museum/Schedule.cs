using System;
using System.Collections.Generic;

namespace Museum
{
    public class Schedule
    {
        public static readonly string FirstDayProperty = "firstDay";
        public static readonly string LastDayProperty = "lastDay";
        public static readonly string StartTimeProperty = "startTime";
        public static readonly string EndTimeProperty = "endTime";

        public Schedule(string firstDay, string lastDay, string startTime, string endTime)
        {
            id = null;
            FirstDay = firstDay;
            LastDay = lastDay;
            StartTime = startTime;
            EndTime = endTime;
        }

        public Schedule(Dictionary<string,string> schedule)
        {
            
        }

        private int? id { get; set; }

        public int? Id
        {
            get => id;
            set => id = value;
        }

        private string firstDay { get; set; }

        public string FirstDay
        {
            get => firstDay;
            set => firstDay = value;
        }

        private string lastDay { get; set; }

        public string LastDay
        {
            get => lastDay;
            set => lastDay = value;
        }

        private string startTime { get; set; }

        public string StartTime
        {
            get => startTime;
            set => startTime = value;
        }

        private string endTime { get; set; }

        public string EndTime
        {
            get => endTime;
            set => endTime = value;
        }

        public void Save()
        {
            var insertSchedule = "INSERT INTO schedules (startDay, endDay, startTime, endTime) VALUES (" + firstDay +
                                 "," + lastDay + "," + startTime + "," + endTime + ")";
            var dbConnection = new DBConnection();
            dbConnection.Execute(insertSchedule);
        }

        public void Update(string changeProperties, string changeValues)
        {
            var properties = changeProperties.Split('-');
            var values = changeValues.Split('-');
            var error = false;
            for (var i = 0; i < properties.Length; i++)
                if (properties[i] != FirstDayProperty && properties[i] != LastDayProperty &&
                    properties[i] != StartTimeProperty && properties[i] != EndTimeProperty)
                    error = true;
            if (error)
            {
                Console.WriteLine("Nao e possivel efetuar essa operacao!");
            }
            else
            {
                var update = "UPDATE INTO schedules SET ";
                for (var i = 0; i < properties.Length; i++)
                    if (i == properties.Length - 1)
                        update += properties[i] + "=" + values[i];
                    else
                        update += properties[i] + "=" + values[i] + ", ";
                update += " WHERE id=" + id;
                var dbConnection = new DBConnection();
                dbConnection.Execute(update);
            }
        }
    }
}