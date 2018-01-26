using System;
using System.Collections.Generic;
using Museum_Console.Classes;

namespace Museum
{
    public class Process
    {
        public static readonly string PriceProperty = "price";
        public static readonly string ResultProperty = "result";
        public static readonly string ActiveProperty = "active";
        public static readonly string ScheduleProperty = "schedule_id";

        public Process(Exhibitor exhibitor, Employee employee, Schedule schedule, IList<Room> room,string name,string description,string title,string img)
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
            Active = true;

            pendent = new Pendent(this);
            approved = new Approved(this);
            denied = new Denied(this);
            confirmed = new Confirmed(this);
            Actual = pendent;
        }

        public Process(Dictionary<string,string> process, Exhibitor exhibitor, Employee employee, Schedule schedule, IList<Room> room)
        {
            DictonaryAdapter adapter = new DictonaryAdapter(process);
            Description = adapter.GetValue("description");
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
                Result = bool.Parse(adapter.GetValue("result"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Result = null;
            }
            Active = bool.Parse(adapter.GetValue("active"));
            Exhibitor = exhibitor;
            Employee = employee;
            Schedule = schedule;
            Room = room;

            pendent = new Pendent(this);
            approved = new Approved(this);
            denied = new Denied(this);
            confirmed = new Confirmed(this);


            if (Result == null)
            {
                Actual = Pendent;
            }
            else if(Result == true)
            {
                if (Active == true)
                {
                    Actual = approved;
                }
                else
                {
                    Actual = confirmed;
                }
            }
            else
            {
                Actual = denied;
            }
        }

        private int id { get; set; }

        public int Id
        {
            get => id;
            set => id = value;
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

        private bool? result { get; set; }

        public bool? Result
        {
            get => result;
            set => result = value;
        }

        private bool active { get; set; }

        public bool Active
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

//        public void SaveArtPieces()
//        {
//            foreach (var artPiece in ArtPieces)
//            {
//                artPiece.GetInformation();
//                artPiece.Save();
//            }
//        }

//        public void InsertArtPiece()
//        {
//            var artPieceFactory = FactoryCreator.Instance.CreateFactory(FactoryCreator.ArtPieceFactory);
//            var type = ArtpieceFactory.painting; //Devera ser o que esta no windows form
//            var artPiece = (Painting) artPieceFactory.Create(type);
//            artPiece.Size = 12.0;
//            artPiece.Description = "OLAOLA";
//            artPiece.Name = "OLA";
//            ArtPieces.Add(artPiece);
//        }

        public void Save()
        {
            var table = "processes";                                                     
            var keys = new [] {ActiveProperty,"description","img","title","name","employees_id","exhibitors_id","schedule_id"};
            var active = Active == true ? 1 : 0;
            var values = new [] {active.ToString(),Description,"img",Title,Name,Employee.RoleId().ToString(),Exhibitor.RoleId().ToString(),Schedule.Id.ToString()};
            var insertProcess = SqlOperations.Instance.Insert(table, keys, values);
            Console.WriteLine(insertProcess);
            Id = (int)DBConnection.Instance.Execute(insertProcess);

            foreach (var item in Room)
            {
                var associateProcessRoom = "INSERT INTO processes_has_rooms (processes_id,rooms_id) VALUES ("+Id+","+item.Id+")";
                DBConnection.Instance.Execute(associateProcessRoom);
            }
            var message = new Message();
            //message.Receivers.Add(Employee);
            //message.Sender = Exhibitor;
            //message.Save();
        }

        public void Update(string changeProperties, string changeValues)
        {
            var properties = changeProperties.Split('-');
            var values = changeValues.Split('-');
            var error = false;
            for (var i = 0; i < properties.Length; i++)
                if (properties[i] != PriceProperty && properties[i] != ResultProperty &&
                    properties[i] != ActiveProperty && properties[i] != ScheduleProperty)
                    error = true;
            if (error)
            {
                Console.WriteLine("Nao e possivel efetuar essa operacao!");
            }
            else
            {
                var update = SqlOperations.Instance.Update(Id, "processes", properties, values);
                DBConnection.Instance.Execute(update);
            }
        }
    }
}