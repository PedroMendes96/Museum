using System;

namespace Museum
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //var personFactory = FactoryCreator.Instance.CreateFactory(FactoryCreator.PersonFactory);
            //var employee = (Employee) personFactory.Create(PersonFactory.employee);
            //Console.WriteLine(employee.IdEmployee);
            var sql =
                "SELECT employees.id AS employees_id,persons.id AS persons_id,name,password,phone,mail,salary FROM employees,persons WHERE mail = 'pedro@gmail.com'";
            var data = DBConnection.Instance.Query(sql);
            Console.WriteLine(data.Count);
        }
    }
}