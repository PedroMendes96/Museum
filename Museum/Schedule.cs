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

        public Schedule(string firstDay,string firstMonth,string firstYear, string lastDay,string lastMonth,string lastYear, string startTime, string endTime)
        {
            id = null;
            FirstDay = firstDay;
            FirstMonth = firstMonth;
            FirstYear = firstYear;
            LastDay = lastDay;
            LastMonth = lastMonth;
            LastYear = lastYear;
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

        private string firstMonth { get; set; }

        public string FirstMonth
        {
            get => firstMonth;
            set => firstMonth = value;
        }

        private string firstYear { get; set; }

        public string FirstYear
        {
            get => firstYear;
            set => firstYear = value;
        }

        private string lastDay { get; set; }

        public string LastDay
        {
            get => lastDay;
            set => lastDay = value;
        }

        private string lastMonth { get; set; }

        public string LastMonth
        {
            get => lastMonth;
            set => lastMonth = value;
        }

        private string lastYear { get; set; }

        public string LastYear
        {
            get => lastYear;
            set => lastYear = value;
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
            var table = "schedules";                                                     
            var keys = new [] {FirstDayProperty,LastDayProperty,StartTimeProperty,EndTimeProperty};
            var values = new [] {firstDay,lastDay,startTime,endTime};
            var insertSchedule = SqlOperations.Instance.Insert(table, keys, values);
            DBConnection.Instance.Execute(insertSchedule);
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
                var update = SqlOperations.Instance.Update(Id, "schedules", properties, values);
                DBConnection.Instance.Execute(update);
            }
        }
    }
}