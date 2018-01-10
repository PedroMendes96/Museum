using System;
using System.Collections;
using System.Collections.Generic;

namespace Museum
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //var personFactory = FactoryCreator.Instance.CreateFactory(FactoryCreator.PersonFactory);
            //var employee = (Employee) personFactory.Create(PersonFactory.employee);
            //Console.WriteLine(employee.IdEmployee);
            DateTime date1 = DateTime.Now;
            Console.WriteLine(date1.Day);
            Console.ReadLine();
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

        public IList<Schedule> GetSchedules()
        {
            // Time now
            DateTime date = new DateTime();
            var day = date.Day;
            var month = date.Day;
            var year = date.Day;

            // Schedules
            var schedulesSQL = "SELECT * FROM schedules";
            var dbConnection = new DBConnection();
            var schedules = dbConnection.Query(schedulesSQL);
            List<Schedule> schedulesList = new List<Schedule>();
            foreach (var schedule in schedules)
            {
                var scheduleAdapter = new DictonaryAdapter(schedule);
                var startDateValue = scheduleAdapter.GetValue("firstDay");
                var lastDateValue = scheduleAdapter.GetValue("lastDay");

                var startDayMonthYear = startDateValue.Split('-');
                var endDayMonthYear = lastDateValue.Split('-');

                if (month.ToString().Equals(startDayMonthYear[1]) && year.ToString().Equals(endDayMonthYear[2]))
                {
                    if (day.ToString().Equals(startDayMonthYear[0]))
                    {
                        var selectedSchedule = new Schedule(schedule);
                        schedulesList.Add(selectedSchedule);
                    }
                }
            }

            if ( schedulesList.Count == 0 )
            {
                return null;
            }
            else
            {
                return schedulesList;
            }
        }

        public IList<Events> GetPermanentList()
        {
            List<Events> events = new List<Events>();

            var permanentEvents = "SELECT * FROM permanents";
            DBConnection dbConnection = new DBConnection();
            var permanentDictionary = dbConnection.Query(permanentEvents);
            foreach (var permanent in permanentDictionary)
            {
                Events newEvents = Permanent.ImportData(permanent);
                events.Add(newEvents);
            }
            return events;
        }

        public IList<Room> GetAvailableRooms(Schedule schedule)
        {
            var roomsAvailable = new List<Room>();
            var RoomsSQL = "SELECT * FROM rooms WHERE events_id=null";
            var dbConnection = new DBConnection();
            dbConnection.Query();

        }
    }
}