using System;
using System.Collections.Generic;

namespace Museum
{
    public class Exhibitor : Person
    {
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

        public override int RoleId()
        {
            return IdExhibitor;
        }

        public override void GetData(Dictionary<string, string> values)
        {
            var dictionaryAdapter = new DictionaryAdapter(values);
            Name = dictionaryAdapter.GetValue(DbQuery.NameProperty);
            Password = dictionaryAdapter.GetValue(DbQuery.PasswordProperty);
            Phone = int.Parse(dictionaryAdapter.GetValue(DbQuery.PhoneProperty));
            Mail = dictionaryAdapter.GetValue(DbQuery.MailProperty);
            Type = dictionaryAdapter.GetValue(DbQuery.TypeProperty);
        }

        public override bool SubmitData()
        {
            Id = DbQuery.InsertPerson(Password, Name, Phone.ToString(), Mail);
            IdExhibitor = DbQuery.InsertExhibitor(Type, Id.ToString());
            return true;
        }

        public override void Update(string changeProperties, string changeValues, string table)
        {
            var properties = changeProperties.Split('-');
            var values = changeValues.Split('-');
            var error = false;
            foreach (var property in properties)
                if (table == DbQuery.Itself)
                {
                    if (property != DbQuery.PasswordProperty && property != DbQuery.NameProperty &&
                        property != DbQuery.PhoneProperty && property != DbQuery.MailProperty) error = true;
                }
                else if (table == DbQuery.Exhibitor)
                {
                    if (property != DbQuery.TypeProperty) error = true;
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