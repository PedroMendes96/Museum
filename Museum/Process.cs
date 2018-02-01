﻿using System;
using System.Collections.Generic;

namespace Museum
{
    public class Process
    {
        public static readonly string PriceProperty = "price";
        public static readonly string ResultProperty = "result";
        public static readonly string ActiveProperty = "active";
        public static readonly string ScheduleProperty = "schedule_id";
        public static readonly string NameProperty = "name";
        public static readonly string DescriptionProperty = "description";
        public static readonly string TitleProperty = "title";

        public Process(Exhibitor exhibitor, Employee employee, Schedule schedule, IList<Room> room, string name,
            string description, string title, string img)
        {
            ///////////////INPUTS////////////////
            Exhibitor = exhibitor;
            Employee = employee;
            Schedule = schedule;
            Room = room;
            Name = name;
            Description = description;
            Title = title;
            Img = img;
            /////////////////////////////////////
            Price = null;
            Result = null;
            Active = 1;

            pendent = new Pendent(this);
            approved = new Approved(this);
            denied = new Denied(this);
            confirmed = new Confirmed(this);
            Actual = pendent;
        }

        public Process(Dictionary<string, string> process, Exhibitor exhibitor, Employee employee, Schedule schedule,
            IList<Room> room)
        {
            var adapter = new DictionaryAdapter(process);
            Description = adapter.GetValue("description");
            LastUpdate = adapter.GetValue("lastUpdate");
            ///////////////INPUTS////////////////
            Id = int.Parse(adapter.GetValue("id"));
            try
            {
                Price = float.Parse(adapter.GetValue("price"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Price = null;
            }

            try
            {
                Result = int.Parse(adapter.GetValue("result"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Result = null;
            }

            Active = int.Parse(adapter.GetValue("active"));
            Exhibitor = exhibitor;
            Employee = employee;
            Schedule = schedule;
            Room = room;

            pendent = new Pendent(this);
            approved = new Approved(this);
            denied = new Denied(this);
            confirmed = new Confirmed(this);


            if (Result == null)
                Actual = Pendent;
            else if (Result != 0)
                if (Active != 0)
                    Actual = approved;
                else
                    Actual = confirmed;
            else
                Actual = denied;
        }

        private int id { get; set; }

        public int Id
        {
            get => id;
            set => id = value;
        }

        private string lastUpdate { get; set; }

        public string LastUpdate
        {
            get => lastUpdate;
            set => lastUpdate = value;
        }

        private string description { get; set; }

        public string Description
        {
            get => description;
            set => description = value;
        }

        private string name { get; set; }

        public string Name
        {
            get => name;
            set => name = value;
        }

        private string title { get; set; }

        public string Title
        {
            get => title;
            set => title = value;
        }

        private string img { get; set; }

        public string Img
        {
            get => img;
            set => img = value;
        }

        private float? price { get; set; }

        public float? Price
        {
            get => price;
            set => price = value;
        }

        private int? result { get; set; }

        public int? Result
        {
            get => result;
            set => result = value;
        }

        private int active { get; set; }

        public int Active
        {
            get => active;
            set => active = value;
        }

        private IList<Room> room { get; set; }

        public IList<Room> Room
        {
            get => room;
            set => room = value;
        }

        private Exhibitor exhibitor { get; set; }

        public Exhibitor Exhibitor
        {
            get => exhibitor;
            set => exhibitor = value;
        }

        private Employee employee { get; set; }

        public Employee Employee
        {
            get => employee;
            set => employee = value;
        }

        private Schedule schedule { get; set; }

        public Schedule Schedule
        {
            get => schedule;
            set => schedule = value;
        }

        private Events temporary { get; set; }

        public Events Temporary
        {
            get => temporary;
            set => temporary = value;
        }

        private IState pendent { get; }
        public IState Pendent => pendent;

        private IState approved { get; }
        public IState Approved => approved;

        private IState denied { get; }
        public IState Denied => denied;

        private IState confirmed { get; }
        public IState Confirmed => confirmed;

        private IState actual { get; set; }

        public IState Actual
        {
            get => actual;
            set => actual = value;
        }

        public List<ArtPiece> ArtPieces { get; set; } = new List<ArtPiece>();

        public static IList<Dictionary<string,string>> GetProcessesById(string id)
        {
            var processesSql = "SELECT * FROM processes WHERE id=" + id;
            return DbConnection.Instance.Query(processesSql);
        }

        public static IList<Dictionary<string, string>> GetProcessesByEmployeeIdandActive(string id)
        {
            var processes = "SELECT * FROM processes WHERE active=true and employees_id=" + id;
            return DbConnection.Instance.Query(processes);
        }

        public static IList<Dictionary<string, string>> GetProcessByScheduleId(string id)
        {
            var processEvent ="SELECT title,name FROM processes WHERE schedule_id=" +id;
            return DbConnection.Instance.Query(processEvent);
        }

        public void Save()
        {
            var table = "processes";
            var keys = new[]
                {ActiveProperty, "description", "img", "title", "name", "employees_id", "exhibitors_id", "schedule_id"};
            var values = new[]
            {
                Active.ToString(), Description, "img", Title, Name, Employee.RoleId().ToString(),
                Exhibitor.RoleId().ToString(), Schedule.Id.ToString()
            };
            var insertProcess = SqlOperations.Instance.Insert(table, keys, values);
            Console.WriteLine(insertProcess);
            Id = DbConnection.Instance.Execute(insertProcess);

            foreach (var item in Room)
            {
                var associateProcessRoom = "INSERT INTO processes_has_rooms (processes_id,rooms_id) VALUES (" + Id +
                                           "," + item.Id + ")";
                DbConnection.Instance.Execute(associateProcessRoom);
            }
        }

        public void Update(string changeProperties, string changeValues)
        {
            var properties = changeProperties.Split('-');
            var values = changeValues.Split('-');
            var error = false;
            for (var i = 0; i < properties.Length; i++)
                if (properties[i] != PriceProperty && properties[i] != ResultProperty && properties[i] != NameProperty
                    && properties[i] != DescriptionProperty && properties[i] != TitleProperty &&
                    properties[i] != ActiveProperty && properties[i] != ScheduleProperty)
                    error = true;
            if (error)
            {
                Console.WriteLine(@"Falta preencher coisas!!!!");
            }
            else
            {
                var update = SqlOperations.Instance.Update(Id, "processes", properties, values);
                DbConnection.Instance.Execute(update);
            }
        }
    }
}