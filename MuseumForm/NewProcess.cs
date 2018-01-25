using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Museum;

namespace MuseumForm
{
    public partial class NewProcess : UserControl
    {
        private List<int> roomsIdList = new List<int>();
        private string imgPath;
        public NewProcess()
        {
            InitializeComponent();
            AddBoxValues();
            GetYear();
            ListRooms();
        }

        public void ListRooms()
        {
            comboBoxRooms.Items.Clear();
            var attr = new[] { "id" };
            var tables = new[] { "rooms" };
            var roomsSQL = SqlOperations.Instance.Select(attr, tables);
            Console.WriteLine(roomsSQL);
            var roomsList = DBConnection.Instance.Query(roomsSQL);
            if (roomsList != null)
            {
                foreach (var room in roomsList)
                {
                    var dictionaryAdapter = new DictonaryAdapter(room);
                    var comboItem = new ComboboxItem();
                    comboItem.Text = "Room " + dictionaryAdapter.GetValue("id");
                    comboItem.Value = int.Parse(dictionaryAdapter.GetValue("id"));
                    comboBoxRooms.Items.Add(comboItem);
                }
            }
        }

        private void addButtonRoom_Click(object sender, EventArgs e)
        {
            var value = comboBoxRooms.Text;
            if (!value.Trim().Equals(""))
            {
                var split = value.Split(' ');
                var id = int.Parse(split[1]);
                roomsIdList.Add(id);
            }
        }

        private void AddBoxValues()
        {
            for (int i = 9; i < 20; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    if (i != 19)
                    {
                        string value = i + ":";
                        double valueDouble = 0.0;
                        if (j == 0)
                        {
                            value += "00";
                            valueDouble = i;
                        }
                        else
                        {
                            value += "30";
                            valueDouble = i + 1;
                        }
                        ComboboxItem comboboxItem = new ComboboxItem();
                        comboboxItem.Text = value;
                        comboboxItem.doubleValue = valueDouble;
                        startBox.Items.Add(comboboxItem);
                        endBox.Items.Add(comboboxItem);
                    }
                    else
                    {
                        if (j == 0)
                        {
                            string value = i + ":";
                            double valueDouble = 0.0;
                            value += "00";
                            valueDouble = i;

                            ComboboxItem comboboxItem = new ComboboxItem();
                            comboboxItem.Text = value;
                            comboboxItem.doubleValue = valueDouble;
                            startBox.Items.Add(comboboxItem);
                            endBox.Items.Add(comboboxItem);
                        }
                    }
                }
            }
        }

        private bool CheckFields()
        {
            var result = true;
            if (startBox.Text.Equals(null) || endBox.Text.Equals(null) || textBoxName.Text.Trim().Equals("")
                || textBoxDescription.Text.Trim().Equals("") || textBoxTitle.Text.Trim().Equals(""))
            {
                result = false;
            }

            return result;
        }

        private bool CheckRoomAvailbility(List<int> RoomsId)
        {
            var desiredStartDayMonthYear = new[] {dayStart.Text, monthStart.Text, yearStart.Text};
            var desiredEndDayMonthYear = new[] { dayEnd.Text, monthEnd.Text, yearEnd.Text };
            var desiredStartTime = startBox.Text.Split(':');
            var desiredEndTime = endBox.Text.Split(':');
            foreach (var room in RoomsId)
            {
                var roomsEvents = "SELECT * FROM rooms_has_events WHERE rooms_id=" + room;
                var roomsEventsResult = DBConnection.Instance.Query(roomsEvents);

                if (roomsEventsResult != null)
                {
                    foreach (var events in roomsEventsResult)
                    {
                        var eventAdapter = new DictonaryAdapter(events);

                        var scheduleEvent = "SELECT * FROM schedules WHERE id="
                                            + eventAdapter.GetValue("schedule_id") + " ORDER BY lastUpdate DESC";
                        var scheduleEventResult = DBConnection.Instance.Query(scheduleEvent);

                        if (scheduleEventResult != null)
                        {
                            foreach (var schedule in scheduleEventResult)
                            {
                                var scheduleAdapter = new DictonaryAdapter(schedule);
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
                                            return false;
                                        }
                                        else if (int.Parse(startDayMonthYear[0]) == int.Parse(desiredEndDayMonthYear[0]))
                                        {
                                            if (!CheckTimeConflict(desiredStartTime, desiredEndTime, startHourMin, endHourMin))
                                            {
                                                return false;
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
                                            return false;
                                        }
                                        else if (int.Parse(endDayMonthYear[0]) == int.Parse(desiredStartDayMonthYear[0]))
                                        {
                                            if (!CheckTimeConflict(desiredStartTime, desiredEndTime, startHourMin, endHourMin))
                                            {
                                                return false;
                                            }
                                        }
                                    }
                                    else if (int.Parse(endDayMonthYear[0]) == int.Parse(desiredStartDayMonthYear[0]))
                                    {
                                        if (!CheckTimeConflict(desiredStartTime, desiredEndTime, startHourMin, endHourMin))
                                        {
                                            return false;
                                        }
                                    }
                                    else
                                    {
                                        return false;
                                    }
                                }
                                else if (endDayMonthYear[1].Equals(desiredStartDayMonthYear[1]))
                                {
                                    if (int.Parse(endDayMonthYear[0]) < int.Parse(desiredStartDayMonthYear[0]))
                                    {
                                    }
                                    else if (int.Parse(endDayMonthYear[0]) > int.Parse(desiredStartDayMonthYear[0]))
                                    {
                                        return false;
                                    }
                                    else if (int.Parse(endDayMonthYear[0]) == int.Parse(desiredStartDayMonthYear[0]))
                                    {
                                        if (!CheckTimeConflict(desiredStartTime, desiredEndTime, startHourMin, endHourMin))
                                        {
                                            return false;
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
                                        return false;
                                    }
                                    else if (int.Parse(endDayMonthYear[0]) == int.Parse(desiredStartDayMonthYear[1]))
                                    {
                                        if (!CheckTimeConflict(desiredStartTime, desiredEndTime, startHourMin, endHourMin))
                                        {
                                            return false;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return true;
        }

        public IList<Schedule> GetSchedules()
        {
            // Time now
            DateTime date = new DateTime();
            var day = date.Day;
            var month = date.Month;
            var year = date.Year;

            // Schedules
            var properties = new[] { "*" };
            var table = new[] { "schedules" };
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

            var properties = new[] { "*" };
            var table = new[] { "permanents" };
            var permanentEvents = SqlOperations.Instance.Select(properties, table);
            var permanentDictionary = DBConnection.Instance.Query(permanentEvents);
            foreach (var permanent in permanentDictionary)
            {
                Events newEvents = (Permanent)FactoryCreator.Instance.CreateFactory(FactoryCreator.ExhibitionFactory).ImportData(ExhibitionFactory.permanent, permanent);
                events.Add(newEvents);
            }
            return events;
        }

        public void GetYear()
        {
            var dateTime = new DateTime().Date;
            
            ComboboxItem comboboxItem = new ComboboxItem();
            comboboxItem.Text = dateTime.Year.ToString();
            comboboxItem.Value = dateTime.Year;

            ComboboxItem comboboxItem1 = new ComboboxItem();
            comboboxItem.Text = (dateTime.Year+1).ToString();
            comboboxItem.Value = dateTime.Year + 1;

            //yearStart.Items.Add(comboboxItem);
            //yearStart.Items.Add(comboboxItem1);
            //yearEnd.Items.Add(comboboxItem);
            //yearEnd.Items.Add(comboboxItem1);
        }

        //public IList<Room> GetAvailableRooms(Schedule schedule)
        //{
        //    var roomsAvailable = new List<Room>();
        //    var desiredStartDayMonthYear = schedule.FirstDay.Split('-');
        //    var desiredEndDayMonthYear = schedule.LastDay.Split('-');

        //    var desiredStartTime = schedule.StartTime.Split(':');
        //    var desiredEndTime = schedule.EndTime.Split(':');

        //    //Adiciona as salas vazias que nao possuem eventos
        //    var properties = new[] { "*" };
        //    var table = new[] { "rooms" };
        //    var keys = new[] { "events_id" };
        //    var values = new[] { "null" };
        //    var Rooms = SqlOperations.Instance.Select(properties, table, keys, values);
        //    var roomsList = DBConnection.Instance.Query(Rooms);
        //    foreach (var room in roomsList)
        //    {
        //        var availableRoom = new Room(room);
        //        roomsAvailable.Add(availableRoom);
        //    }
        //    table[0] = "temporaries";
        //    var temporarySQL = SqlOperations.Instance.Select(properties, table);
        //    var temporaryEventsDictionary = DBConnection.Instance.Query(temporarySQL);
        //    foreach (var temporaryEvent in temporaryEventsDictionary)
        //    {
        //        var adapter = new DictonaryAdapter(temporaryEvent);
        //        properties = new[] { "*" };
        //        table = new[] { "schedule" };
        //        keys = new[] { "id" };
        //        values = new[] { adapter.GetValue("schedules_id") };

        //        var specificScheduleSQL = SqlOperations.Instance.Select(properties, table, keys, values);
        //        var schedules = DBConnection.Instance.Query(specificScheduleSQL);
        //        var available = true;
        //        foreach (var individualSchedule in schedules)
        //        {
        //            var scheduleAdapter = new DictonaryAdapter(individualSchedule);
        //            var startDateValue = scheduleAdapter.GetValue("firstDay");
        //            var lastDateValue = scheduleAdapter.GetValue("lastDay");

        //            var startTime = scheduleAdapter.GetValue("startTime");
        //            var endTime = scheduleAdapter.GetValue("endTime");

        //            var startHourMin = startTime.Split(':');
        //            var endHourMin = endTime.Split(':');

        //            var startDayMonthYear = startDateValue.Split('-');
        //            var endDayMonthYear = lastDateValue.Split('-');

        //            if (startDayMonthYear[1].Equals(desiredStartDayMonthYear[1]) &&
        //                endDayMonthYear[1].Equals(desiredEndDayMonthYear[1]))
        //            {
        //                if (int.Parse(startDayMonthYear[0]) > int.Parse(desiredStartDayMonthYear[0]))
        //                {
        //                    if (int.Parse(startDayMonthYear[0]) < int.Parse(desiredEndDayMonthYear[0]))
        //                    {
        //                    }
        //                    else if (int.Parse(startDayMonthYear[0]) > int.Parse(desiredEndDayMonthYear[0]))
        //                    {
        //                        available = false;
        //                        break;
        //                    }
        //                    else if (int.Parse(startDayMonthYear[0]) == int.Parse(desiredEndDayMonthYear[0]))
        //                    {
        //                        if (!CheckTimeConflict(desiredStartTime, desiredEndTime, startHourMin, endHourMin))
        //                        {
        //                            available = false;
        //                            break;
        //                        }
        //                    }
        //                }
        //                else if (int.Parse(startDayMonthYear[0]) < int.Parse(desiredStartDayMonthYear[0]))
        //                {
        //                    if (int.Parse(startDayMonthYear[0]) < int.Parse(desiredEndDayMonthYear[0]))
        //                    {
        //                    }
        //                    else if (int.Parse(endDayMonthYear[0]) > int.Parse(desiredStartDayMonthYear[0]))
        //                    {
        //                        available = false;
        //                        break;
        //                    }
        //                    else if (int.Parse(endDayMonthYear[0]) == int.Parse(desiredStartDayMonthYear[0]))
        //                    {
        //                        if (!CheckTimeConflict(desiredStartTime, desiredEndTime, startHourMin, endHourMin))
        //                        {
        //                            available = false;
        //                            break;
        //                        }
        //                    }
        //                }
        //                else if (int.Parse(endDayMonthYear[0]) == int.Parse(desiredStartDayMonthYear[0]))
        //                {
        //                    if (!CheckTimeConflict(desiredStartTime, desiredEndTime, startHourMin, endHourMin))
        //                    {
        //                        available = false;
        //                        break;
        //                    }
        //                }
        //                else
        //                {
        //                    available = false;
        //                    break;
        //                }
        //            }
        //            else if (endDayMonthYear[1].Equals(desiredStartDayMonthYear[1]))
        //            {
        //                if (int.Parse(endDayMonthYear[0]) < int.Parse(desiredStartDayMonthYear[0]))
        //                {
        //                }
        //                else if (int.Parse(endDayMonthYear[0]) > int.Parse(desiredStartDayMonthYear[0]))
        //                {
        //                    available = false;
        //                    break;
        //                }
        //                else if (int.Parse(endDayMonthYear[0]) == int.Parse(desiredStartDayMonthYear[0]))
        //                {
        //                    if (!CheckTimeConflict(desiredStartTime, desiredEndTime, startHourMin, endHourMin))
        //                    {
        //                        available = false;
        //                        break;
        //                    }
        //                }
        //            }
        //            else if (startDayMonthYear[1].Equals(desiredEndDayMonthYear[1]))
        //            {
        //                if (int.Parse(desiredEndDayMonthYear[1]) < int.Parse(startDayMonthYear[1]))
        //                {
        //                }
        //                else if (int.Parse(desiredEndDayMonthYear[1]) > int.Parse(startDayMonthYear[1]))
        //                {
        //                    available = false;
        //                    break;
        //                }
        //                else if (int.Parse(endDayMonthYear[0]) == int.Parse(desiredStartDayMonthYear[1]))
        //                {
        //                    if (!CheckTimeConflict(desiredStartTime, desiredEndTime, startHourMin, endHourMin))
        //                    {
        //                        available = false;
        //                        break;
        //                    }
        //                }
        //            }
        //        }
        //        if (!available)
        //        {
        //            AddRoomAvailable(adapter.GetValue("events_id"), roomsAvailable);
        //        }
        //    }
        //    return roomsAvailable;
        //}

        //public void AddRoomAvailable(string idEvent, IList<Room> roomsAvailable)
        //{
        //    var properties = new[] { "*" };
        //    var table = new[] { "rooms" };
        //    var keys = new[] { "events_id" };
        //    var values = new[] { idEvent };
        //    var roomSQL = SqlOperations.Instance.Select(properties, table, keys, values);
        //    var roomDictonaryList = DBConnection.Instance.Query(roomSQL);
        //    foreach (var roomDictonary in roomDictonaryList)
        //    {
        //        Room newRoom = new Room(roomDictonary);
        //        roomsAvailable.Add(newRoom);
        //    }
        //}

        //false se nao der
        // true se der
        public bool CheckTimeConflict(string[] desiredStart, string[] desiredEnd, string[] start, string[] end)
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

        private void Submit_Click(object sender, EventArgs e)
        {
            if (CheckFields())
            {
                if (CheckRoomAvailbility(roomsIdList))
                {
                    var index = this.ParentForm.Controls.IndexOfKey(AppForms.Dashboard_Control);
                    var dashboardControl = (DashboardControl)this.ParentForm.Controls[index];

                    var exhibitorSQL = "SELECT persons.id as persons_id, exhibitors.id as exhibitors_id," +
                                       "name,password,phone,mail FROM persons,exhibitors WHERE " +
                                       "exhibitors.persons_id=persons.id and persons.id="+dashboardControl.Person.Id;
                    var exhibitorResult = DBConnection.Instance.Query(exhibitorSQL);
                    var exhibitor = (Exhibitor)FactoryCreator.Instance.CreateFactory(FactoryCreator.PersonFactory)
                        .ImportData(PersonFactory.exhibitor,exhibitorResult[0]);

                    List<Room> rooms = new List<Room>();
                    var roomsSQl = "SELECT * FROM rooms WHERE ";

                    for (int i = 0; i < roomsIdList.Count; i++)
                    {
                        if (i == roomsIdList.Count - 1)
                        {
                            roomsSQl += "id=" + roomsIdList[i];
                        }
                        else
                        {
                            roomsSQl += "id=" + roomsIdList[i] + " OR ";
                        }
                    }

                    var roomsResult = DBConnection.Instance.Query(roomsSQl);
                    foreach (var room in roomsResult)
                    {
                        var newRoom = new Room(room);
                        rooms.Add(newRoom);
                    }

                    var schedule = new Schedule(dayStart.Text,monthStart.Text,yearStart.Text, dayEnd.Text, monthEnd.Text, yearEnd.Text, startBox.Text,endBox.Text);
                    schedule.Save();

                    var allEmployee = "SELECT * FROM employees";
                    var employeesResult = DBConnection.Instance.Query(allEmployee);

                    int number = 0;
                    int chosenId = 0;

                    for (int i = 0; i < employeesResult.Count; i++)
                    {
                        var adapterEmployee = new DictonaryAdapter(employeesResult[i]);
                        var processes = "SELECT * FROM processes WHERE active=true and employees_id="+adapterEmployee.GetValue("id");
                        var processesResult = DBConnection.Instance.Query(processes);
                        if (i == 0)
                        {
                            number = processesResult.Count;
                            chosenId = int.Parse(adapterEmployee.GetValue("id"));
                        }
                        else
                        {
                            if (number > processesResult.Count)
                            {
                                number = processesResult.Count;
                                chosenId = int.Parse(adapterEmployee.GetValue("id"));
                            }
                        }
                    }

                    var employeeSQL = "SELECT persons.id as persons_id, employees.id as employees_id," +
                                      "name,password,phone,mail FROM persons,employees WHERE " +
                                      "employees.persons_id=persons.id and employees.id=" + chosenId;

                    var employeeResult = DBConnection.Instance.Query(employeeSQL);
                    var employee = (Employee)FactoryCreator.Instance.CreateFactory(FactoryCreator.PersonFactory)
                        .ImportData(PersonFactory.employee, employeeResult[0]);

                    var process = new Process(exhibitor, employee, schedule, rooms,textBoxName.Text,textBoxDescription.Text, textBoxTitle.Text, "img");
                    process.Save();
                    var indexOf = this.ParentForm.Controls.IndexOfKey(AppForms.ProcessesExhibitorControl);
                    var processesExhibitorControl = (ProcessesExhibitorControl)this.ParentForm.Controls[indexOf];
                    processesExhibitorControl.GetProcesses();
                    processesExhibitorControl.ResetProcesses();
                    processesExhibitorControl.GetProcesses();
                    processesExhibitorControl.ListProcesses();
                    processesExhibitorControl.BringToFront();
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            var index = this.ParentForm.Controls.IndexOfKey(AppForms.ProcessesExhibitorControl);
            this.ParentForm.Controls[index].BringToFront();
        }
    }
}
