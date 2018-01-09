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

        public Process(Exhibitor exhibitor, Employee employee, Schedule schedule, Room room)
        {
            ///////////////INPUTS////////////////
            Exhibitor = exhibitor;
            Employee = employee;
            Schedule = schedule;
            Room = room;
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

        private int id { get; set; }

        public int Id
        {
            get => id;
            set => id = value;
        }

        public double? Price { get; set; }

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

        private Room room { get; set; }

        public Room Room
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

        public void SaveArtPieces()
        {
            foreach (var artPiece in ArtPieces)
            {
                artPiece.GetInformation();
                artPiece.Save();
            }
        }

        public void InsertArtPiece()
        {
            var artPieceFactory = FactoryCreator.Instance.CreateFactory(FactoryCreator.ArtPieceFactory);
            var type = ArtpieceFactory.painting; //Devera ser o que esta no windows form
            var artPiece = (Painting) artPieceFactory.Create(type);
            artPiece.Size = 12.0;
            artPiece.Description = "OLAOLA";
            artPiece.Name = "OLA";
            ArtPieces.Add(artPiece);
        }

        public void Save()
        {
            var insertProcess = "INSERT INTO processes (active,employees_id,exhibitors_id,schedules_id) VALUES (" +
                                Active +
                                ", " + Employee.Id + ", " + Exhibitor.Id + ", " + Schedule.Id + ")";
            var message = new Message();
            message.Receivers.Add(Employee);
            message.Sender = Exhibitor;
            message.Save();
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
                var update = "UPDATE INTO processes SET ";
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