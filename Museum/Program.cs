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

        public void Login()
        {
            var mail = "0"; //valor do input do texto
            var password = "0"; // valor do input da password

            var properties = new [] { "*" };
            var table = new [] { "persons" };
            var keys = new [] {Person.MailProperty};
            var values = new [] {mail};
            var checkEmailAvailability = SqlOperations.Instance.Select(properties, table, keys, values);
            var checkEmailAvailabilityResult = DBConnection.Instance.Query(checkEmailAvailability);
            if (checkEmailAvailabilityResult.Count == 1)
            {
                var adapter = new DictonaryAdapter(checkEmailAvailabilityResult[0]);
                if (adapter.GetValue("password").Equals(password))
                {
                    properties = new [] { "*" };
                    table = new [] { "exhibitors" };
                    keys = new [] {"person_id"};
                    values = new [] {adapter.GetValue("id")};
                    var getExhibitorData = SqlOperations.Instance.Select(properties, table, keys, values);
                    var exhibitorResult = DBConnection.Instance.Query(getExhibitorData);
                    var adapterExhibitors = new DictonaryAdapter(exhibitorResult[0]);
                    
                    properties = new [] { "*" };
                    table = new [] { "persons_has_messages","messages" };
                    keys = new [] {"id","persons_id"};
                    values = new [] {"messages_id",adapter.GetValue("id")};
                    var messagesSQL = SqlOperations.Instance.Select(properties, table, keys, values);
                    var messagesDictonary = DBConnection.Instance.Query(messagesSQL);
                    var messagesList = new List<Message>();
                    foreach (var message in messagesDictonary)
                    {
                        Message newMessage = new Message(message);
                        messagesList.Add(newMessage);
                    }
                    if (exhibitorResult.Count > 0)
                    {
                        Exhibitor exhibitor = new Exhibitor();
                        exhibitor.Name = adapter.GetValue("name");
                        exhibitor.Mail = adapter.GetValue("mail");
                        exhibitor.Phone = int.Parse(adapter.GetValue("phone"));
                        exhibitor.Notifications = messagesList;
                        exhibitor.Type = adapterExhibitors.GetValue("type");
                    }
                    else
                    {
                        properties = new [] { "*" };
                        table = new [] { "employees" };
                        keys = new [] {"person_id"};
                        values = new [] {adapter.GetValue("id")};
                        var getEmployeeData = SqlOperations.Instance.Select(properties, table, keys, values);
                        var employeeResult = DBConnection.Instance.Query(getEmployeeData);
                        var adapterEmployees = new DictonaryAdapter(employeeResult[0]);
                        Employee employee = new Employee();
                        employee.Salary = double.Parse(adapterEmployees.GetValue("name"));
                        employee.Mail = adapter.GetValue("mail");
                        employee.Name = adapter.GetValue("name");
                        employee.Phone = int.Parse(adapter.GetValue("name"));
                        employee.Notifications = messagesList;
                    }
                }
                else
                {
                    Console.WriteLine("The data that you inserted is incorrect!");
                }
            }
            else
            {
                Console.WriteLine("Doesnt exist this email in the system");
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
            var table = new [] { "exhibitors" };
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
                Events newEvents = (Permanent)FactoryCreator.Instance.CreateFactory(FactoryCreator.ExhibitionFactory).Create(ExhibitionFactory.permanent);
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