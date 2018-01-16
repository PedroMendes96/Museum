using System;
using System.Collections.Generic;

namespace Museum
{
    public class Exhibitor : Person
    {
        public static readonly string TypeProperty = "type";

        private int idExhibitor { get; set; }

        public int IdExhibitor
        {
            get => idExhibitor;
            set => idExhibitor = value;
        }

        private string type { get; set; }

        public string Type
        {
            get => type;
            set => type = value;
        }

        private Process process { get; set; }

        public Process Process
        {
            get => process;
            set => process = value;
        }

        public Exhibitor()
        {
            
        }

        public Exhibitor(Dictionary<string,string> dictionary)
        {
            DictonaryAdapter dictionaryAdapter = new DictonaryAdapter(dictionary);
            //Person
            Id = int.Parse(dictionaryAdapter.GetValue("persons_id"));
            Name = dictionaryAdapter.GetValue("name");
            Password = dictionaryAdapter.GetValue("password");
            Phone = int.Parse(dictionaryAdapter.GetValue("phone"));
            Mail = dictionaryAdapter.GetValue("mail");
//            Notifications =;//Ainda e preciso ver como sera
            //Role
            IdExhibitor = int.Parse(dictionaryAdapter.GetValue("exhibitors_id"));
            Type = dictionaryAdapter.GetValue("salary");
        }

        public List<int> IdItems { get; set; } = new List<int>();

        public void AddItem(string type)
        {
            var artFactory = FactoryCreator.Instance.CreateFactory(FactoryCreator.ArtPieceFactory);
            ArtPiece artPiece;
            if (type == ArtpieceFactory.painting)
            {
                artPiece = (Painting) artFactory.Create(type);
            }
            else if (type == ArtpieceFactory.photography)
            {
                artPiece = (Photography) artFactory.Create(type);
            }
            else if (type == ArtpieceFactory.sculpture)
            {
                artPiece = (Sculpture) artFactory.Create(type);
            }
            else
            {
                Console.WriteLine("Some error occour");
                return;
            }

            //Para ir buscar os campos ao windows forms
            artPiece.Name = "Arte";
            artPiece.Description = "Arte";
            artPiece.Exhibitor = this;
            artPiece.Size = 12.2;
            artPiece.Save();
        }

        public override int RoleId()
        {
            return IdExhibitor;
        }

        public override bool SubmitData()
        {
            var table = "persons";
            var keys = new[] { PasswordProperty, NameProperty, PhoneProperty, MailProperty };
            var values = new[] { Password, Name, Phone.ToString(), Mail };
            var insertPersons = SqlOperations.Instance.Insert(table, keys, values);
            Console.WriteLine(insertPersons);
            Id = (int)DBConnection.Instance.Execute(insertPersons);

            table = "exhibitors";
            keys = new[] { TypeProperty, "persons_id" };
            values = new[] { Type, Id.ToString() };
            var insertExhibitors = SqlOperations.Instance.Insert(table, keys, values);
            Console.WriteLine(insertExhibitors);
            DBConnection.Instance.Execute(insertExhibitors);
            return true;
        }

        public override void Update(string changeProperties, string changeValues, string table)
        {
            var properties = changeProperties.Split('-');
            var values = changeValues.Split('-');
            var error = false;
            for (var i = 0; i < properties.Length; i++)
                if (table == Itself)
                {
                    if (properties[i] != PasswordProperty && properties[i] != NameProperty &&
                        properties[i] != PhoneProperty && properties[i] != MailProperty) error = true;
                }
                else if (table == Exhibitor)
                {
                    if (properties[i] != TypeProperty) error = true;
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

        public void CreateProcess()
        {
            var startDay = 0;
            var endDay = 0;
            var startTime = 0;
            var endTime = 0;
            var idRoom = 0;
            if (startDay == 1 && endDay == 1 && startTime == 1 && endTime == 1 && idRoom == 1)
            {
                process.Exhibitor = this;
                var properties = new [] { "*" };
                var table = new [] { "employees" };
                var employeesQuery = SqlOperations.Instance.Select(properties,table);
                var employees = DBConnection.Instance.Query(employeesQuery);
                var id = 0;
                var numberProcesses = 0;
                foreach (var employee in employees)
                {
                    var dictionary = new DictonaryAdapter(employee);
                    properties = new [] { "*" };
                    table = new [] { "processes" };
                    var keys = new [] {"employees_id"};
                    var values = new [] {dictionary.GetValue("id")};
                    var employeeProcess = SqlOperations.Instance.Select(properties, table, keys, values);
                    var result = DBConnection.Instance.Query(employeeProcess);
                    if (id == 0)
                    {
                        id = int.Parse(dictionary.GetValue("employees_id"));
                        numberProcesses = result.Count;
                    }
                    else
                    {
                        if (result.Count < numberProcesses)
                        {
                            id = int.Parse(dictionary.GetValue("employees_id"));
                            numberProcesses = result.Count;
                        }
                    }
                }
                var personFactory = FactoryCreator.Instance.CreateFactory(FactoryCreator.PersonFactory);
                properties = new [] { "*" };
                table = new [] { "persons","employees" };
                var column = new[] { "persons.id","employees.id" };
                var contents = new[] { "employees.persons_id",id.ToString() };
                var employeeSQL = SqlOperations.Instance.Select(properties,table,column,contents);
                var selectedEmployee = DBConnection.Instance.Query(employeeSQL);
                var chosenEmployee = (Employee) personFactory.ImportData(PersonFactory.employee,selectedEmployee[0]);
                
                //Falta ver isto da sala como vai ser feita, preciso de um select box no windows forms
                var room = new Room();
                //Com dados do windows Forms
                var schedule = new Schedule("1/1/2017", "8/1/2017", "11:00", "13:00");
                Process = new Process(this, chosenEmployee, schedule, room);
                process.Save();
            }
            else
            {
                Console.WriteLine("Falta preencher campos para a validacao do seu processo!");
                //Dizer que falta preencher algo
            }
        }
    }
}