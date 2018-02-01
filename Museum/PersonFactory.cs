using System.Collections.Generic;

namespace Museum
{
    public class PersonFactory : IFactory
    {
        public static readonly string Exhibitor = "Exhibitor";
        public static readonly string Employee = "Employee";

        public object Create(string type)
        {
            Person person;
            if (type == Exhibitor)
                person = new Exhibitor();
            else if (type == Employee)
                person = new Employee();
            else
                return null;
            return person;
        }

        public object ImportData(string type, Dictionary<string, string> dictionary)
        {
            Person person;
            if (type == Exhibitor)
                person = new Exhibitor(dictionary);
            else if (type == Employee)
                person = new Employee(dictionary);
            else
                return null;
            return person;
        }
    }
}