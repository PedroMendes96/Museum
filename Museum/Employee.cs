using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;

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
            Id = int.Parse(dictionaryAdapter.GetValue("persons_id"));
            Name = dictionaryAdapter.GetValue("name");
            Password = dictionaryAdapter.GetValue("password");
            Phone = int.Parse(dictionaryAdapter.GetValue("phone"));
            Mail = dictionaryAdapter.GetValue("mail");
            if (dictionaryAdapter.GetValue("salary") == null)
                Salary = 0;
            else
                Salary = double.Parse(dictionaryAdapter.GetValue("salary"));
            IdEmployee = int.Parse(dictionaryAdapter.GetValue("employees_id"));
            LastUpdateSalary = dictionaryAdapter.GetValue("empLastUpdate");
        }

        public static IList<Dictionary<string, string>> GetEmployeeByRoleId(string id)
        {
            var personRole =
                "SELECT persons.id as persons_id, employees.id As employees_id, name, password, phone, mail FROM persons, employees" +
                " WHERE persons_id=persons.id AND employees.id=" + id;
            return DbConnection.Instance.Query(personRole);
        }

        public static IList<Dictionary<string, string>> GetEmployeeByPersonId(string id)
        {
            var query = "SELECT persons.id as persons_id, employees.id As employees_id, name, password, phone, mail FROM persons, employees" +
                        " WHERE persons_id=persons.id AND persons.id=" + id;
            return DbConnection.Instance.Query(query);
        }

        public static IList<Dictionary<string, string>> GetAllEmployees()
        {
            var allEmployee = "SELECT * FROM employees";
            return DbConnection.Instance.Query(allEmployee);
        }

        public static IList<Dictionary<string, string>> GetAllEmployeesOrderedByLastUpdate()
        {
            string select =
                "SELECT persons.name AS name,persons.password AS password,persons.mail AS mail,persons.phone AS phone, persons.id AS persons_id,employees.id AS employees_id,employees.salary AS salary,employees.lastUpdate AS empLastUpdate FROM employees,persons WHERE persons.id = employees.persons_id ORDER BY empLastUpdate ASC";
            return DbConnection.Instance.Query(select);
        }

        public static IList<Dictionary<string, string>> GetAllEmployeesByRoleId(string id)
        {
            var employeeSql = "SELECT persons.id as persons_id, employees.id as employees_id," +
                              "name,password,phone,mail FROM persons,employees WHERE " +
                              "employees.persons_id=persons.id and employees.id=" + id;

            return DbConnection.Instance.Query(employeeSql);
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
            Id = DbConnection.Instance.Execute(insertPersons);

            table = "employees";
            keys = new[] {SalaryProperty, "persons_id"};
            values = new[] {Salary.ToString(CultureInfo.CurrentCulture), Id.ToString()};
            var insertEmployees = SqlOperations.Instance.Insert(table, keys, values);
            Console.WriteLine(insertEmployees);
            DbConnection.Instance.Execute(insertEmployees);
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
                    error = true;
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
                Console.WriteLine(@"Falta preencher coisas!!!!");
            else
                UpdateSequence(table, properties, values);
        }
    }
}