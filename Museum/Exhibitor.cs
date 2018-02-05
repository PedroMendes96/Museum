using System;
using System.Collections.Generic;

namespace Museum
{
    public class Exhibitor : Person
    {
        public static readonly string TypeProperty = "type";

        public int IdExhibitor { get; set; }
        public string Type { get; set; }
        public Process Process { get; set; }
        public List<int> IdItems { get; set; } = new List<int>();

        public Exhibitor()
        {
        }

        public Exhibitor(Dictionary<string, string> dictionary)
        {
            var dictionaryAdapter = new DictionaryAdapter(dictionary);
            Id = int.Parse(dictionaryAdapter.GetValue("persons_id"));
            Name = dictionaryAdapter.GetValue("name");
            Password = dictionaryAdapter.GetValue("password");
            Phone = int.Parse(dictionaryAdapter.GetValue("phone"));
            Mail = dictionaryAdapter.GetValue("mail");
            IdExhibitor = int.Parse(dictionaryAdapter.GetValue("exhibitors_id"));
            Type = dictionaryAdapter.GetValue("type");
        }

        public static IList<Dictionary<string, string>> GetExhibitorByPersonId(string id)
        {
            var sel = "SELECT persons.id as persons_id, exhibitors.id as exhibitors_id," +
                      "name,password,phone,mail,type FROM persons,exhibitors WHERE " +
                      "exhibitors.persons_id=persons.id and persons.id=" + id;
            return DbConnection.Instance.Query(sel);
        }

        public static IList<Dictionary<string, string>> GetExhibitorByRoleId(string id)
        {
            var personRole =
                "SELECT persons.id as persons_id, exhibitors.id AS exhibitors_id, name, password, phone, mail, type FROM persons, exhibitors" +
                " WHERE persons_id=persons.id AND exhibitors.id=" + id;
            return DbConnection.Instance.Query(personRole);
        }

        public override int RoleId()
        {
            return IdExhibitor;
        }

        public override void GetData(Dictionary<string, string> values)
        {
            var dictionaryAdapter = new DictionaryAdapter(values);
            Name = dictionaryAdapter.GetValue(NameProperty);
            Password = dictionaryAdapter.GetValue(PasswordProperty);
            Phone = int.Parse(dictionaryAdapter.GetValue(PhoneProperty));
            Mail = dictionaryAdapter.GetValue(MailProperty);
            Type = dictionaryAdapter.GetValue(TypeProperty);
        }

        public override bool SubmitData()
        {
            var table = "persons";
            var keys = new[] {PasswordProperty, NameProperty, PhoneProperty, MailProperty};
            var values = new[] {Password, Name, Phone.ToString(), Mail};
            var insertPersons = SqlOperations.Instance.Insert(table, keys, values);
            Console.WriteLine(insertPersons);
            Id = DbConnection.Instance.Execute(insertPersons);

            table = "exhibitors";
            keys = new[] {TypeProperty, "persons_id"};
            values = new[] {Type, Id.ToString()};
            var insertExhibitors = SqlOperations.Instance.Insert(table, keys, values);
            Console.WriteLine(insertExhibitors);
            DbConnection.Instance.Execute(insertExhibitors);
            return true;
        }

        public static IList<Dictionary<string, string>> GetExhibitorsById(string id)
        {
            var exhibitorSql = "SELECT * FROM exhibitors WHERE id=" + id;
            return DbConnection.Instance.Query(exhibitorSql);
        }

        public override void Update(string changeProperties, string changeValues, string table)
        {
            var properties = changeProperties.Split('-');
            var values = changeValues.Split('-');
            var error = false;
            foreach (var property in properties)
                if (table == Itself)
                {
                    if (property != PasswordProperty && property != NameProperty &&
                        property != PhoneProperty && property != MailProperty) error = true;
                }
                else if (table == Exhibitor)
                {
                    if (property != TypeProperty) error = true;
                }
                else
                {
                    error = true;
                }

            if (error)
                Console.WriteLine(@"Falta preencher coisas!!!!");
            else
                UpdateSequence(table, properties, values);
        }
    }
}