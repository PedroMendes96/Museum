using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Museum
{
    public class Employee : Person
    {
        public static readonly string SalaryProperty = "salary";

        public Employee()
        {
        }

        public Employee(Dictionary<string, string> dictionary)
        {
            var dictionaryAdapter = new DictionaryAdapter(dictionary);
            //Person
            Id = int.Parse(dictionaryAdapter.GetValue("persons_id"));
            Name = dictionaryAdapter.GetValue("name");
            Password = dictionaryAdapter.GetValue("password");
            Phone = int.Parse(dictionaryAdapter.GetValue("phone"));
            Mail = dictionaryAdapter.GetValue("mail");
            if (dictionaryAdapter.GetValue("salary") == null)
            {
                Salary = 0;
            }
            else
            {
                Salary = double.Parse(dictionaryAdapter.GetValue("salary"));
            }
            IdEmployee = int.Parse(dictionaryAdapter.GetValue("employees_id"));
            LastUpdateSalary = dictionaryAdapter.GetValue("empLastUpdate");
            // Salary = double.Parse(dictionaryAdapter.GetValue("salary"));
        }

        private string lastUpdateSalary { get; set; }

        public string LastUpdateSalary
        {
            get => lastUpdateSalary;
            set => lastUpdateSalary = value; 
            
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

        public override void GetData(Dictionary<string, string> values)
        {
            var dictionaryAdapter = new DictionaryAdapter(values);
            Name = dictionaryAdapter.GetValue(NameProperty);
            Password = dictionaryAdapter.GetValue(PasswordProperty);
            Phone = int.Parse(dictionaryAdapter.GetValue(PhoneProperty));
            Mail = dictionaryAdapter.GetValue(MailProperty);
            Debug.WriteLine(dictionaryAdapter.GetValue(SalaryProperty));
            Salary = double.Parse(dictionaryAdapter.GetValue(SalaryProperty));
        }

        public override bool SubmitData()
        {
            var table = "persons";
            var keys = new[] {PasswordProperty, NameProperty, PhoneProperty, MailProperty};
            var values = new[] {Password, Name, Phone.ToString(), Mail};
            var insertPersons = SqlOperations.Instance.Insert(table, keys, values);
            Console.WriteLine(insertPersons);
            Id = DBConnection.Instance.Execute(insertPersons);

            table = "employees";
            keys = new[] {SalaryProperty, "persons_id"};
            values = new[] {Salary.ToString(), Id.ToString()};
            var insertEmployees = SqlOperations.Instance.Insert(table, keys, values);
            Console.WriteLine(insertEmployees);
            DBConnection.Instance.Execute(insertEmployees);
            return true;
        }

        public override void Update(string changeProperties, string changeValues, string table)
        {
            var error = false;
            if (table.Equals(Itself))
            {
                Console.WriteLine(changeProperties + "-" + PasswordProperty);
                Console.WriteLine(changeProperties + "-" + NameProperty);
                Console.WriteLine(changeProperties + "-" + PhoneProperty);
                Console.WriteLine(changeProperties + "-" + MailProperty);
                if (!changeProperties.Equals(PasswordProperty) && !changeProperties.Equals(NameProperty) &&
                    !changeProperties.Equals(PhoneProperty) && !changeProperties.Equals(MailProperty))
                {
                    error = true;
                }
            }
            else if (table.Equals(Employee))
            {
                if (changeProperties != SalaryProperty)
                    error = true;
            }
            else
            {
                error = true;
            }

            var properties = new[] {changeProperties};
            var values = new[] {changeValues};

            if (error)
                Console.WriteLine("Nao e possivel efetuar essa operacao!");
            else
                UpdateSequence(table, properties, values);
        }
    }
}