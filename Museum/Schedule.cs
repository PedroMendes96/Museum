﻿using System;
using System.Collections.Generic;

namespace Museum
{
    public class Schedule
    {
        public static readonly string StartDayProperty = "startDay";
        public static readonly string StartMonthProperty = "startMonth";
        public static readonly string StartYearProperty = "startYear";
        public static readonly string EndDayProperty = "endDay";
        public static readonly string EndMonthProperty = "endMonth";
        public static readonly string EndYearProperty = "endYear";
        public static readonly string StartTimeProperty = "startTime";
        public static readonly string EndTimeProperty = "endTime";

        public Schedule(string firstDay, string firstMonth, string firstYear, string lastDay, string lastMonth,
            string lastYear, string startTime, string endTime)
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
            var keys = new[]
            {
                StartDayProperty, StartMonthProperty, StartYearProperty, EndDayProperty, EndMonthProperty,
                EndYearProperty, StartTimeProperty, EndTimeProperty
            };
            var values = new[] {firstDay, firstMonth, firstYear, lastDay, lastMonth, lastYear, startTime, endTime};
            var insertSchedule = SqlOperations.Instance.Insert(table, keys, values);
            Id = DbConnection.Instance.Execute(insertSchedule);
        }

        public static IList<Dictionary<string, string>> GetScheduleByIdOrderByLastUpdateDesc(string id)
        {
            var scheduleEvent = "SELECT * FROM schedules WHERE id="
                                + id + " ORDER BY lastUpdate DESC";
            return DbConnection.Instance.Query(scheduleEvent);
        }

        public static IList<Dictionary<string, string>> GetAllSchedules()
        {
            var properties = new[] { "*" };
            var table = new[] { "schedules" };
            var schedulesSql = SqlOperations.Instance.Select(properties, table);
            return DbConnection.Instance.Query(schedulesSql);
        }

        public static IList<Dictionary<string, string>> GetSchedulesById(string id)
        {
            var scheduleSql = "SELECT * FROM schedules WHERE id=" + id;
            return DbConnection.Instance.Query(scheduleSql);
        }

        public static IList<Dictionary<string, string>> GetSchedulesByIds(IList<int> ids, int day, int month, int year)
        {
            var sqlSchedules = "SELECT * FROM schedules WHERE ";

            for (var i = 0; i < ids.Count; i++)
                if (ids.Count - 1 == i)
                    sqlSchedules += "id=" + ids[i] + " AND startDay <=" + day + " AND endDay >=" + day +
                                    " AND " +
                                    "startMonth <= " + month + " AND endMonth >= " + month + " AND " +
                                    "startYear<=" + year + " AND endYear>=" + year +
                                    " ORDER BY endTime ASC";
                else
                    sqlSchedules += "id=" + ids[i] + " OR ";

            return DbConnection.Instance.Query(sqlSchedules);
        }

        public void Update(string changeProperties, string changeValues)
        {
            var properties = changeProperties.Split('-');
            var values = changeValues.Split('-');
            var error = false;
            foreach (var property in properties)
                if (property != StartDayProperty && property != StartMonthProperty &&
                    property != StartYearProperty
                    && property != EndDayProperty && property != EndMonthProperty &&
                    property != EndYearProperty && property != StartTimeProperty &&
                    property != EndTimeProperty)
                    error = true;

            if (error)
            {
                Console.WriteLine(@"Falta preencher coisas!!!!");
            }
            else
            {
                var update = SqlOperations.Instance.Update(Id, "schedules", properties, values);
                DbConnection.Instance.Execute(update);
            }
        }
    }
}