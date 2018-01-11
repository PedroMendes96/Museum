using System;
using System.Collections;
using System.Collections.Generic;

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

        public Person Login()
        {
            var mail = "0"; //valor do input do texto
            var password = "0"; // valor do input da password

            var properties = new [] { "*" };
            var table = new [] { "persons" };
            var keys = new [] {Person.MailProperty};
            var values = new [] {mail};
            var checkEmailAvailability = SqlOperations.Instance.Select(properties, table, keys, values);
            var checkEmailAvailabilityResult = DBConnection.Instance.Query(checkEmailAvailability);
            if (checkEmailAvailabilityResult.Count > 0)
            {
                var adapter = new DictonaryAdapter(checkEmailAvailabilityResult[0]);
                if (adapter.GetValue(Person.PasswordProperty).Equals(password))
                {
                    properties = new [] { "*" };
                    table = new [] { "exhibitors" };
                    keys = new [] {"person_id"};
                    values = new [] {adapter.GetValue("id")};
                    var getExhibitorData = SqlOperations.Instance.Select(properties, table, keys, values);
                    var exhibitorResult = DBConnection.Instance.Query(getExhibitorData);
                    
                    properties = new [] { "*" };
                    table = new [] { "persons_has_messages","messages" };
                    keys = new [] {"id","persons_id"};
                    values = new [] {"messages_id",adapter.GetValue("id")};
                    var messagesSQL = SqlOperations.Instance.Select(properties, table, keys, values);
                    var messagesDictonary = DBConnection.Instance.Query(messagesSQL);
                    var messagesList = new List<Message>();
                    foreach (var message in messagesDictonary)
                    {
                        var messagesAdapter = new DictonaryAdapter(messagesDictonary[0]);
                        properties = new [] { "employees.id AS employees_id","persons.id AS persons_id", 
                            Person.NameProperty, Person.PasswordProperty, Person.PhoneProperty, Person.MailProperty,
                            Employee.SalaryProperty };
                        table = new [] { "employees","persons" };
                        keys = new [] {"persons_id"};
                        values = new [] {messagesAdapter.GetValue("id")};
                        var employeeSQL = SqlOperations.Instance.Select(properties, table, keys, values);
                        var result = DBConnection.Instance.Query(employeeSQL);
                        Person person;
                        if (result.Count > 0)
                        {
                            person = new Employee(result[0]);
                        }
                        else
                        {
                            properties = new [] { "exhibitors.id AS exhibitors_id","persons.id AS persons_id", "name", "password", "phone", "mail", "type" };
                            table = new [] { "exhibitors, persons" };
                            keys = new [] {"persons_id"};
                            values = new [] {messagesAdapter.GetValue("id")};
                            var exhibitorsSQL = SqlOperations.Instance.Select(properties, table, keys, values);
                            result = DBConnection.Instance.Query(exhibitorsSQL);
                            person = new Exhibitor(result[0]);
                        }
                        Message newMessage = new Message(message, person);
                        messagesList.Add(newMessage);
                    }
                    Person user = null;
                    if (exhibitorResult.Count > 0)
                    {
                        properties = new [] { "exhibitors.id AS exhibitors_id","persons.id AS persons_id",Person.NameProperty,
                            Person.PasswordProperty, Person.PhoneProperty, Person.MailProperty, Exhibitor.TypeProperty };
                        table = new [] { "exhibitors, persons" };
                        keys = new [] {"persons_id"};
                        values = new [] {adapter.GetValue("id")};
                        var exhibitorsSQL = SqlOperations.Instance.Select(properties, table, keys, values);
                        var userData = DBConnection.Instance.Query(exhibitorsSQL);
                        user = new Exhibitor(userData[0]);
                    }
                    else
                    {
                        properties = new [] { "employees.id AS employees_id","persons.id AS persons_id", 
                            Person.NameProperty, Person.PasswordProperty, Person.PhoneProperty, Person.MailProperty,
                            Employee.SalaryProperty };
                        table = new [] { "employees","persons" };
                        keys = new [] {"persons_id"};
                        values = new [] {adapter.GetValue("id")};
                        var employeesSQL = SqlOperations.Instance.Select(properties, table, keys, values);
                        var userData = DBConnection.Instance.Query(employeesSQL);
                        user = new Employee(userData[0]);
                    }
                    return user;
                }
                else
                {
                    Console.WriteLine("The data that you inserted is incorrect!");
                    return null;
                }
            }
            else
            {
                Console.WriteLine("Doesnt exist this email in the system");
                return null;
            }
        }

        public IList<Schedule> GetSchedules()
        {
            // Time now
            DateTime date = new DateTime();
            var day = date.Day;
            var month = date.Month;
            var year = date.Year;

            // Schedules
            var properties = new [] { "*" };
            var table = new [] { "schedules" };
            var schedulesSQL = SqlOperations.Instance.Select(properties, table);
            var schedules = DBConnection.Instance.Query(schedulesSQL);
            List<Schedule> schedulesList = new List<Schedule>();
            foreach (var schedule in schedules)
            {
                var scheduleAdapter = new DictonaryAdapter(schedule);
                var startDateValue = scheduleAdapter.GetValue("firstDay");
                var lastDateValue = scheduleAdapter.GetValue("lastDay");

                var startDayMonthYear = startDateValue.Split('-');
                var endDayMonthYear = lastDateValue.Split('-');

                if (month.ToString().Equals(startDayMonthYear[1]) && year.ToString().Equals(endDayMonthYear[1]))
                {
                    if (day.ToString().Equals(startDayMonthYear[0]) || day.ToString().Equals(endDayMonthYear[0]))
                    {
                        var selectedSchedule = new Schedule(schedule);
                        schedulesList.Add(selectedSchedule);
                    }
                    else if (day > int.Parse(startDayMonthYear[0]) && day < int.Parse(endDayMonthYear[0]))
                    {
                        var selectedSchedule = new Schedule(schedule);
                        schedulesList.Add(selectedSchedule);
                    }
                }
            }

            if (schedulesList.Count == 0)
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

            var properties = new [] { "*" };
            var table = new [] { "permanents" };
            var permanentEvents = SqlOperations.Instance.Select(properties, table);
            var permanentDictionary = DBConnection.Instance.Query(permanentEvents);
            foreach (var permanent in permanentDictionary)
            {
                Events newEvents = (Permanent)FactoryCreator.Instance.CreateFactory(FactoryCreator.ExhibitionFactory).ImportData(ExhibitionFactory.permanent,permanent);
                events.Add(newEvents);
            }
            return events;
        }

        public IList<Room> GetAvailableRooms(Schedule schedule)
        {
            var roomsAvailable = new List<Room>();
            var desiredStartDayMonthYear = schedule.FirstDay.Split('-');
            var desiredEndDayMonthYear = schedule.LastDay.Split('-');

            var desiredStartTime = schedule.StartTime.Split(':');
            var desiredEndTime = schedule.EndTime.Split(':');

            //Adiciona as salas vazias que nao possuem eventos
            var properties = new [] { "*" };
            var table = new [] { "rooms" };
            var keys = new [] {"events_id"};
            var values = new [] {"null"};
            var Rooms = SqlOperations.Instance.Select(properties, table, keys, values);
            var roomsList = DBConnection.Instance.Query(Rooms);
            foreach (var room in roomsList)
            {
                var availableRoom = new Room(room);
                roomsAvailable.Add(availableRoom);
            }
            table[0] = "temporaries";
            var temporarySQL = SqlOperations.Instance.Select(properties, table);
            var temporaryEventsDictionary = DBConnection.Instance.Query(temporarySQL);
            foreach (var temporaryEvent in temporaryEventsDictionary)
            {
                var adapter = new DictonaryAdapter(temporaryEvent);
                properties = new [] { "*" };
                table = new [] { "schedule" };
                keys = new [] {"id"};
                values = new [] {adapter.GetValue("schedules_id")};

                var specificScheduleSQL = SqlOperations.Instance.Select(properties, table, keys, values);
                var schedules = DBConnection.Instance.Query(specificScheduleSQL);
                var available = true;
                foreach (var individualSchedule in schedules)
                {
                    var scheduleAdapter = new DictonaryAdapter(individualSchedule);
                    var startDateValue = scheduleAdapter.GetValue("firstDay");
                    var lastDateValue = scheduleAdapter.GetValue("lastDay");

                    var startTime = scheduleAdapter.GetValue("startTime");
                    var endTime = scheduleAdapter.GetValue("endTime");

                    var startHourMin = startTime.Split(':');
                    var endHourMin = endTime.Split(':');

                    var startDayMonthYear = startDateValue.Split('-');
                    var endDayMonthYear = lastDateValue.Split('-');

                    if (startDayMonthYear[1].Equals(desiredStartDayMonthYear[1]) &&
                        endDayMonthYear[1].Equals(desiredEndDayMonthYear[1]))
                    {
                        if (int.Parse(startDayMonthYear[0]) > int.Parse(desiredStartDayMonthYear[0]))
                        {
                            if (int.Parse(startDayMonthYear[0]) < int.Parse(desiredEndDayMonthYear[0]))
                            {
                            }
                            else if (int.Parse(startDayMonthYear[0]) > int.Parse(desiredEndDayMonthYear[0]))
                            {
                                available = false;
                                break;
                            }
                            else if (int.Parse(startDayMonthYear[0]) == int.Parse(desiredEndDayMonthYear[0]))
                            {
                                if (!CheckTimeConflict(desiredStartTime, desiredEndTime, startHourMin, endHourMin ))
                                {
                                    available = false;
                                    break;
                                }
                            }
                        }
                        else if (int.Parse(startDayMonthYear[0]) < int.Parse(desiredStartDayMonthYear[0]))
                        {
                            if (int.Parse(startDayMonthYear[0]) < int.Parse(desiredEndDayMonthYear[0]))
                            {
                            }
                            else if (int.Parse(endDayMonthYear[0]) > int.Parse(desiredStartDayMonthYear[0]))
                            {
                                available = false;
                                break;
                            }
                            else if (int.Parse(endDayMonthYear[0]) == int.Parse(desiredStartDayMonthYear[0]))
                            {
                                if (!CheckTimeConflict(desiredStartTime, desiredEndTime, startHourMin, endHourMin))
                                {
                                    available = false;
                                    break;
                                }
                            }
                        }
                        else if (int.Parse(endDayMonthYear[0]) == int.Parse(desiredStartDayMonthYear[0]))
                        {
                            if (!CheckTimeConflict(desiredStartTime, desiredEndTime, startHourMin, endHourMin))
                            {
                                available = false;
                                break;
                            }
                        }
                        else
                        {
                            available = false;
                            break;
                        }
                    }
                    else if (endDayMonthYear[1].Equals(desiredStartDayMonthYear[1]))
                    {
                        if (int.Parse(endDayMonthYear[0]) < int.Parse(desiredStartDayMonthYear[0]))
                        {
                        }
                        else if (int.Parse(endDayMonthYear[0]) > int.Parse(desiredStartDayMonthYear[0]))
                        {
                            available = false;
                            break;
                        }
                        else if (int.Parse(endDayMonthYear[0]) == int.Parse(desiredStartDayMonthYear[0]))
                        {
                            if (!CheckTimeConflict(desiredStartTime, desiredEndTime, startHourMin, endHourMin))
                            {
                                available = false;
                                break;
                            }
                        }
                    }
                    else if (startDayMonthYear[1].Equals(desiredEndDayMonthYear[1]))
                    {
                        if (int.Parse(desiredEndDayMonthYear[1]) < int.Parse(startDayMonthYear[1]))
                        {
                        }
                        else if (int.Parse(desiredEndDayMonthYear[1]) > int.Parse(startDayMonthYear[1]))
                        {
                            available = false;
                            break;
                        }
                        else if (int.Parse(endDayMonthYear[0]) == int.Parse(desiredStartDayMonthYear[1]))
                        {
                            if (!CheckTimeConflict(desiredStartTime, desiredEndTime, startHourMin, endHourMin))
                            {
                                available = false;
                                break;
                            }
                        }
                    }
                }
                if (!available)
                {
                    AddRoomAvailable(adapter.GetValue("events_id"),roomsAvailable);
                }
            }
            return roomsAvailable;
        }

        public void AddRoomAvailable(string idEvent,IList<Room> roomsAvailable)
        {
            var properties = new [] { "*" };
            var table = new [] { "rooms" };
            var keys = new [] {"events_id"};
            var values = new [] {idEvent};
            var roomSQL = SqlOperations.Instance.Select(properties, table, keys, values);
            var roomDictonaryList = DBConnection.Instance.Query(roomSQL);
            foreach (var roomDictonary in roomDictonaryList)
            {
                Room newRoom = new Room(roomDictonary);
                roomsAvailable.Add(newRoom);
            }
        }

        //Acho que tenho de ver isto denovo
        //false se nao der
        // true se der
        public bool CheckTimeConflict(string[] desiredStart, string[] desiredEnd, string[] start, string [] end)
        {
            if (int.Parse(desiredStart[0]) > int.Parse(start[0]))
            {
                if (int.Parse(end[0]) < int.Parse(desiredStart[0]))
                {
                    return true;
                }
                else if (int.Parse(end[0]) == int.Parse(desiredStart[0]))
                {
                    //Preciso ver os minutos
                    if (int.Parse(end[1]) <= int.Parse(desiredStart[1]))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else if (int.Parse(desiredStart[0]) < int.Parse(start[0]))
            {
                if (int.Parse(desiredEnd[0]) < int.Parse(start[0]))
                {
                    return true;
                }
                else if (int.Parse(desiredEnd[0]) == int.Parse(start[0]))
                {
                    if (int.Parse(desiredEnd[1]) <= int.Parse(start[1]))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}