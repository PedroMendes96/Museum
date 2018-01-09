using System;

namespace Museum
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var personFactory = FactoryCreator.Instance.CreateFactory(FactoryCreator.PersonFactory);
            var employee = (Employee) personFactory.Create(PersonFactory.employee);
            Console.WriteLine(employee.IdEmployee);
        }

        //        public void Login()
        //        {
        //            var mail = 0; //valor do input do texto
        //            var password = 0; // valor do input da password
        //
        //            var sql = "SELECT * FROM persons WHERE mail=" + mail + " and password=" + mail;
        //            DBConnection dbConnection = new DBConnection();
        //            var result = dbConnection.Query(sql);
        //            if (result)
        //            {
        //                // Muda a view e armazena os dados do utilizador  no programa.
        //                // Irei ter de certeza um id
        //                var id = 1;
        //                var sql1 = "SELECT * FROM exhibitors where person_id="+id;
        //                result = dbConnection.Query(sql);
        //                if (result1)
        //                {
        //                    Exhibitor exhibitor = (Exhibitor)new Exhibitor();
        //                    exhibitor.Name = result.name;
        //                    exhibitor.Email = result.email;
        //                    exhibitor.Phone = result.phone;
        //                    exhibitor.Notifications = result.notifications;
        //                    exhibitor.Type = result1.type;
        //                }
        //                else
        //                {
        //                    Employee employee = new Employee();
        //                    employee.Salary = result1.salary;
        //                    employee.Email = result.email;
        //                    employee.Name = result.name;
        //                    employee.Phone = result.phone;
        //                    employee.Notifications = result.notifications;
        //                }
        //            }
        //            else
        //            {
        //                // Retorna uma diferente mensagem de erro
        //                if (result.Count > 0)
        //                {
        //                    //Dizer que a passowrd insirida esta incorreta
        //                }
        //                else
        //                {
        //                    // Dizer que nao existe esse email no sistema
        //                }
        //            }
        //        }
    }
}