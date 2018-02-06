using System;
using System.Collections.Generic;

namespace Museum
{
    public class Schedule
    { 
        public int Id { get; set; }
        public string FirstDay { get; set; }
        public string FirstMonth { get; set; }
        public string FirstYear { get; set; }
        public string LastDay { get; set; }
        public string LastMonth { get; set; }
        public string LastYear { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }

        public Schedule(string firstDay, string firstMonth, string firstYear, string lastDay, string lastMonth,
            string lastYear, string startTime, string endTime)
        {
            FirstDay = firstDay;
            FirstMonth = firstMonth;
            FirstYear = firstYear;
            LastDay = lastDay;
            LastMonth = lastMonth;
            LastYear = lastYear;
            StartTime = startTime;
            EndTime = endTime;
        }

        public Schedule(Dictionary<string, string> schedule)
        {
            var adapter = new DictionaryAdapter(schedule);
            Id = int.Parse(adapter.GetValue("id"));
            FirstDay = adapter.GetValue("startDay");
            FirstMonth = adapter.GetValue("startMonth");
            FirstYear = adapter.GetValue("startYear");
            LastDay = adapter.GetValue("endDay");
            LastMonth = adapter.GetValue("endMonth");
            LastYear = adapter.GetValue("endYear");
            StartTime = adapter.GetValue("startTime");
            EndTime = adapter.GetValue("endTime");
        }

        public void Save()
        {
            Id = DbQuery.InsertSchedule(FirstDay, FirstMonth, FirstYear, LastDay, LastMonth, LastYear, StartTime, EndTime);
        }

        public void Update(string changeProperties, string changeValues)
        {
            var properties = changeProperties.Split('-');
            var values = changeValues.Split('-');
            var error = false;
            foreach (var property in properties)
                if (property != DbQuery.StartDayProperty && property != DbQuery.StartMonthProperty &&
                    property != DbQuery.StartYearProperty
                    && property != DbQuery.EndDayProperty && property != DbQuery.EndMonthProperty &&
                    property != DbQuery.EndYearProperty && property != DbQuery.StartTimeProperty &&
                    property != DbQuery.EndTimeProperty)
                    error = true;

            if (error)
            {
                Console.WriteLine(@"Falta preencher coisas!!!!");
            }
            else
            {
//                var update = SqlOperations.Instance.Update(Id, "schedules", properties, values);
//                DbConnection.Instance.Execute(update);
                DbQuery.UpdateSequence(Id, "schedules", properties, values);
            }
        }
    }
}