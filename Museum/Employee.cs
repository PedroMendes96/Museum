using System;

namespace Museum
{
    public class Employee : Person
    {
        public static readonly string SalaryProperty = "salary";

        public Employee()
        {
            Id = 12;
        }

        private int idEmployee { get; set; }

        public int IdEmployee
        {
            get => idEmployee;
            set => idEmployee = value;
        }

        private double salary { get; set; }

        public double Salary
        {
            get => salary;
            set => salary = value;
        }

        public override int RoleId()
        {
            return idEmployee;
        }

        public override void GetData()
        {
            Console.WriteLine("Funciona");
        }

        public override void SubmitData()
        {
            //vou busbar os valores dos dados
        }

        public override bool CheckAvailability()
        {
            var checkEmail = "SELECT * FROM persons WHERE mail=" + Mail;
            var dbConnection = new DBConnection();
            var persons = dbConnection.Query(checkEmail);
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
            var insertEmployees = "INSERT INTO employees (salary,persons_id) VALUES (" + Salary + "," + Id + ")";
            dbConnection.Execute(insertEmployees);
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
                else if (table == Employee)
                {
                    if (properties[i] != SalaryProperty) error = true;
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
    }
}