using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Museum
{
    public class Employee : Person
    {
        public string LastUpdateSalary { get; set; }
        public int IdEmployee { get; set; }
        public double Salary { get; set; }

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
            Salary = dictionaryAdapter.GetValue("salary") == null
                ? 0
                : double.Parse(dictionaryAdapter.GetValue("salary"));
            IdEmployee = int.Parse(dictionaryAdapter.GetValue("employees_id"));
            LastUpdateSalary = dictionaryAdapter.GetValue("empLastUpdate");
        }

        public override int RoleId()
        {
            return IdEmployee;
        }

        public override void GetData(Dictionary<string, string> values)
        {
            var dictionaryAdapter = new DictionaryAdapter(values);
            Name = dictionaryAdapter.GetValue(DbQuery.NameProperty);
            Password = dictionaryAdapter.GetValue(DbQuery.PasswordProperty);
            Phone = int.Parse(dictionaryAdapter.GetValue(DbQuery.PhoneProperty));
            Mail = dictionaryAdapter.GetValue(DbQuery.MailProperty);
            Debug.WriteLine(dictionaryAdapter.GetValue(DbQuery.SalaryProperty));
            Salary = double.Parse(dictionaryAdapter.GetValue(DbQuery.SalaryProperty));
        }

        public override bool SubmitData()
        {
            Id = DbQuery.InsertPerson(Password, Name, Phone.ToString(), Mail);
            IdEmployee = DbQuery.InsertEmployee(Salary.ToString(),Id.ToString());
            return true;
        }

        public override void Update(string changeProperties, string changeValues, string table)
        {
            var error = false;
            if (table.Equals(DbQuery.Itself))
            {
                Console.WriteLine(changeProperties + "-" + DbQuery.PasswordProperty);
                Console.WriteLine(changeProperties + "-" + DbQuery.NameProperty);
                Console.WriteLine(changeProperties + "-" + DbQuery.PhoneProperty);
                Console.WriteLine(changeProperties + "-" + DbQuery.MailProperty);
                if (!changeProperties.Equals(DbQuery.PasswordProperty) && !changeProperties.Equals(DbQuery.NameProperty) &&
                    !changeProperties.Equals(DbQuery.PhoneProperty) && !changeProperties.Equals(DbQuery.MailProperty))
                    error = true;
            }
            else if (table.Equals(DbQuery.Employee))
            {
                if (changeProperties != DbQuery.SalaryProperty)
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