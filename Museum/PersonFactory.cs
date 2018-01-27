using System.Collections.Generic;

namespace Museum
{
    public class PersonFactory : IFactory
    {
        public static readonly string exhibitor = "Exhibitor";
        public static readonly string employee = "Employee";

        public object Create(string type)
        {
            Person person;
            if (type == exhibitor)
                person = new Exhibitor();
            else if (type == employee)
                person = new Employee();
            else
                return null;
            return person;
        }

        public object ImportData(string type, Dictionary<string, string> dictionary)
        {
            Person person;
            if (type == exhibitor)
                person = new Exhibitor(dictionary);
            else if (type == employee)
                person = new Employee(dictionary);
            else
                return null;
            return person;
        }
    }
}