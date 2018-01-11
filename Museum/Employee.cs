using System;
using System.Collections.Generic;

namespace Museum
{
    public class Employee : Person
    {
        public static readonly string SalaryProperty = "salary";

        public Employee()
        {
        }

        public Employee(Dictionary<string,string> dictionary)
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
            IdEmployee = int.Parse(dictionaryAdapter.GetValue("employees_id"));
            Salary = double.Parse(dictionaryAdapter.GetValue("salary"));
            
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

        public override void Save()
        {
            var table = "persons";
            var keys = new [] {PasswordProperty,NameProperty,PhoneProperty,Mail};
            var values = new [] {Password,Name,Phone.ToString(),Mail};
            var insertPersons = SqlOperations.Instance.Insert(table, keys, values);
            DBConnection.Instance.Execute(insertPersons);
            
            table = "employees";                                                     
            keys = new [] {SalaryProperty,"persons_id"};
            values = new [] {Salary.ToString(),Id.ToString()};           
            var insertEmployees = SqlOperations.Instance.Insert(table,keys,values);
            DBConnection.Instance.Execute(insertEmployees);
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
                        properties[i] != PhoneProperty && properties[i] != MailProperty) 
                        error = true;
                }
                else if (table == Employee)
                {
                    if (properties[i] != SalaryProperty) 
                        error = true;
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
    }
}