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
    }
}