using System;
using System.Collections.Generic;

namespace Museum
{
    public class Process : IDecorator
    {
        public static readonly string PriceProperty = "price";
        public static readonly string ResultProperty = "result";
        public static readonly string ActiveProperty = "active";
        public static readonly string ScheduleProperty = "schedule_id";
        public static readonly string NameProperty = "name";
        public static readonly string DescriptionProperty = "description";
        public static readonly string TitleProperty = "title";

        public IDecorator Element { get; set; }
        public int Id { get; set; }
        public string LastUpdate { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Img { get; set; }
        public float? Price { get; set; }
        public int? Result { get; set; }
        public int Active { get; set; }
        public IList<Room> Room { get; set; }
        public Exhibitor Exhibitor { get; set; }
        public Employee Employee { get; set; }
        public Schedule Schedule { get; set; }
        public Events Temporary { get; set; }
        public IState Pendent { get; }
        public IState Approved { get; }
        public IState Denied { get; }
        public IState Confirmed { get; }
        public IState Actual { get; set; }
        public List<ArtPiece> ArtPieces { get; set; } = new List<ArtPiece>();

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

            Pendent = new Pendent(this);
            Approved = new Approved(this);
            Denied = new Denied(this);
            Confirmed = new Confirmed(this);
            Actual = Pendent;
        }

        public Process(Dictionary<string, string> process, Exhibitor exhibitor, Employee employee, Schedule schedule,
            IList<Room> room)
        {
            var adapter = new DictionaryAdapter(process);
            Description = adapter.GetValue(DescriptionProperty);
            Title = adapter.GetValue(TitleProperty);
            Name = adapter.GetValue(NameProperty);
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

            Pendent = new Pendent(this);
            Approved = new Approved(this);
            Denied = new Denied(this);
            Confirmed = new Confirmed(this);


            if (Result == null)
                Actual = Pendent;
            else if (Result != 0)
                Actual = Active != 0 ? Approved : Confirmed;
            else
                Actual = Denied;
        }

        public string GetInformation()
        {
            return Name + "-" + Description + "-" + Title + "-" + Schedule.FirstDay + "/" + Schedule.FirstMonth + "/" +
                   Schedule.FirstYear + "-" + Schedule.LastDay + "/" + Schedule.LastMonth + "/" + Schedule.LastYear;
        }

        public void SetElement(IDecorator newElement)
        {
            Element = newElement;
        }

        public IDecorator GetElement()
        {
            return Element;
        }

        public static IList<Dictionary<string, string>> GetProcessesById(string id)
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
            var processEvent = "SELECT title,name FROM processes WHERE schedule_id=" + id;
            return DbConnection.Instance.Query(processEvent);
        }

        public void DecorateWithArtPiece(ArtPiece item)
        {
            IDecorator elem = this;
            while (elem.GetElement() != null) elem = elem.GetElement();
            elem.SetElement(item);
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
            foreach (var property in properties)
                if (property != PriceProperty && property != ResultProperty && property != NameProperty
                    && property != DescriptionProperty && property != TitleProperty &&
                    property != ActiveProperty && property != ScheduleProperty)
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