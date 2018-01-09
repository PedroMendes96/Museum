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

        public List<int> IdItems { get; set; } = new List<int>();

        public void CreateAccount()
        {
            if (CheckAvailability())
                CreateAccountMethod();
            else
                Console.WriteLine("Nao e possivel criar uma conta com esses dados");
        }

        // Nao esta a ser usado, para ser retirado
//        public void NewProcess()
//        {
////            if (se os campos tiverem os minimos de requisitos)
//            if (id == 0)
//            {
//                var employees = "SELECT * FROM employees";
//                DBConnection dbConnection = new DBConnection();
//                var result = dbConnection.Query(employees);
//                // resultado para o ids
//                int selectedId;
//                int numberProcesses;
//                int index = 0;
//                foreach (var id in ids)
//                {
//                    if (index == 0)
//                    {
//                        //numrows da query; algo deste tipo numberProcesses = numrows(employees);
//                        selectedId = id;
//                    }
//                    else
//                    {
//                        var processes = "SELECT * FROM processes WHERE employees_id=" + selectedId;
//                        result = dbConnection.Query(employees);
//                            
//                        if (processes.numrows < numberProcesses)
//                        {
//                            selectedId = employees.id;
//                        }
//    
//                    }
//                    index++;
//                }
//                var employeeSQL = "SELECT * FROM employees WHERE id=" + selectedId;
//                result = dbConnection.Query(employeeSQL);
//                IFactory personFactory = FactoryCreator.Instance.CreateFactory(FactoryCreator.PersonFactory);
//                Employee employee = (Employee) personFactory.Create(PersonFactory.employee);
//                employee.ImportData(employeeSQL);
//                /*
//                 * Tenho de ir buscar os valores que estao nos menus do windows forms e por nos campos do schedule
//                 */
//                Schedule schedule = new Schedule("11/12/2017","12/11/2018","12","12");
//                
//                Process newProcess = new Process(this,employee,schedule);
//                newProcess.Save();
//            }else{
//                //Dizer os campos que falta preencher
//            }
//        }

        public void AddItem()
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

        public override void GetData()
        {
            //if (campos estao preenchidos)
            if (true)
            {
                Type = "Type"; //Devia ser do formulario do windows forms isto tudo
                Mail = "Mail";
                Password = "password";
                Phone = 123213312;
                Name = "Pedro";
            }
            else
            {
                //por algo aqui para nao deixar passar no SubmitData
                Console.WriteLine("Necessita de preencher todos os campos!");
            }
        }

        public override void SubmitData()
        {
            var dbConnection = new DBConnection();
            var sql = "INSERT INTO persons (password,name,phone,mail) VALUES ({1},{2},{3},{4})";
            sql = string.Format(sql, Password, Name, Phone, Mail);
            dbConnection.Execute(sql);

            sql = "INSERT INTO exhibitors (type,persons_id) VALUES ({1},{2})";
            sql = string.Format(sql, Type, Id);
            dbConnection.Execute(sql);
        }

        public override bool CheckAvailability()
        {
            var person = "SELECT * FROM persons WHERE mail=" + Mail;
            var dbConnection = new DBConnection();
            var persons = dbConnection.Query(person);
            if (persons.Count > 0)
                return false;
            return true;
        }

        public override void Save()
        {
            var insertPersons = "INSERT INTO persons (password,name,phone,mail) VALUES (" + Password + "," + Name +
                                "," + Phone + "," + Mail + ")";
            var dbConnection = new DBConnection();
            dbConnection.Execute(insertPersons);
            var insertExhibitors = "INSERT INTO exhibitors (type,persons_id) VALUES (" + Type + "," + Id + ")";
            dbConnection.Execute(insertExhibitors);
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

        public override Person ImportData(string SQL)
        {
            throw new NotImplementedException();
        }

        public void CreateProcess()
        {
            //Verifica se os campos nao sao null
            var startDay = 0;
            var endDay = 0;
            var startTime = 0;
            var endTime = 0;
            var idRoom = 0;
            if (startDay == 1 && endDay == 1 && startTime == 1 && endTime == 1 && idRoom == 1)
            {
                var dbConnection = new DBConnection();
                process.Exhibitor = this;
                var employeesQuery = "SELECT * FROM employee";
                var employees = dbConnection.Query(employeesQuery);
                var id = 0;
                var numberProcesses = 0;
                foreach (var employee in employees)
                {
                    var dictionary = new DictonaryAdapter(employee);
                    var employeeProcess = "SELECT * FROM processes WHERE employees_id=" +
                                          int.Parse(dictionary.GetValue("id"));
                    var result = dbConnection.Query(employeeProcess);
                    if (id == 0)
                    {
                        id = int.Parse(dictionary.GetValue("id"));
                        numberProcesses = result.Count;
                    }
                    else
                    {
                        if (result.Count < numberProcesses)
                        {
                            id = int.Parse(dictionary.GetValue("id"));
                            numberProcesses = result.Count;
                        }
                    }
                }

                var personFactory = FactoryCreator.Instance.CreateFactory(FactoryCreator.PersonFactory);
                var chosenEmployee = (Employee) personFactory.Create(PersonFactory.employee);
                //TEM DE SER room = IMPORTDATA() PARA DAR CERTO ENQUANTO
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