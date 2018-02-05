using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Museum;

namespace MuseumForm
{
    public partial class NewProcessControl : UserControl
    {
//        private string imgPath;
        private readonly List<int> _roomsIdList = new List<int>();

        public NewProcessControl()
        {
            InitializeComponent();
            AddBoxValues();
        }

        public void ListRooms()
        {
            comboBoxRooms.Items.Clear();
            var roomsList = Room.GetAllRooms();
            if (roomsList != null)
                foreach (var room in roomsList)
                {
                    var dictionaryAdapter = new DictionaryAdapter(room);
                    var comboItem = new ComboboxItem
                    {
                        Text = "Room " + dictionaryAdapter.GetValue("id"),
                        Value = int.Parse(dictionaryAdapter.GetValue("id"))
                    };
                    comboBoxRooms.Items.Add(comboItem);
                }
        }

        private bool checkExistence(IList<int> list, int value)
        {
            foreach (var item in list)
                if (item == value)
                    return true;

            return false;
        }

        private void addButtonRoom_Click(object sender, EventArgs e)
        {
            var myTimer = new Timer { Interval = 1000 };
            var value = comboBoxRooms.Text;
            if (!value.Trim().Equals(""))
            {
                var split = value.Split(' ');
                var id = int.Parse(split[1]);
                if (!checkExistence(_roomsIdList, id))
                {
                    _roomsIdList.Add(id);
                    Information.Text = "You insert the room " + id;
                    Information.Visible = true;
                    myTimer.Tick += HideSucess;
                }
                else
                {
                    InvalidValue.Text = "You tried to insert again the room " + id;
                    InvalidValue.Visible = true;
                    myTimer.Tick += HideFail;
                }
                myTimer.Start();
            }
            
        }

        private void HideSucess(object sender, EventArgs e)
        {
            Information.Visible = false;
            var timer = (Timer)sender;
            timer.Enabled = false;
        }

        private void HideFail(object sender, EventArgs e)
        {
            InvalidValue.Visible = false;
            var timer = (Timer)sender;
            timer.Enabled = false;
        }

        private void AddBoxValues()
        {
            for (var i = 9; i < 20; i++)
                for (var j = 0; j < 2; j++)
                    if (i != 19)
                    {
                        var value = i + ":";
                        double valueDouble;
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

                        var comboboxItem = new ComboboxItem
                        {
                            Text = value,
                            DoubleValue = valueDouble
                        };
                        startBox.Items.Add(comboboxItem);
                        endBox.Items.Add(comboboxItem);
                    }
                    else
                    {
                        if (j == 0)
                        {
                            var value = i + ":";
                            value += "00";
                            double valueDouble = i;

                            var comboboxItem = new ComboboxItem
                            {
                                Text = value,
                                DoubleValue = valueDouble
                            };
                            startBox.Items.Add(comboboxItem);
                            endBox.Items.Add(comboboxItem);
                        }
                    }
        }

        private bool CheckFields()
        {
            bool result = !(startBox.Text.Equals(null) || endBox.Text.Equals(null) || textBoxName.Text.Trim().Equals("")
                || textBoxDescription.Text.Trim().Equals("") || textBoxTitle.Text.Trim().Equals(""));

            return result;
        }

        private bool CheckRoomAvailbility(List<int> roomsId)
        {
            var date = FromPicker.Value;
            var dayStart = date.Day;
            var monthStart = date.Month;
            var yearStart = date.Year;

            date = UntilPicker.Value;
            var dayEnd = date.Day;
            var monthEnd = date.Month;
            var yearEnd = date.Year;


            var desiredStartDayMonthYear = new[] { dayStart.ToString(), monthStart.ToString(), yearStart.ToString() };
            var desiredEndDayMonthYear = new[] { dayEnd.ToString(), monthEnd.ToString(), yearEnd.ToString() };
            var desiredStartTime = startBox.Text.Split(':');
            var desiredEndTime = endBox.Text.Split(':');
            foreach (var room in roomsId)
            {
                var roomsEventsResult = Room.GetEventsByRoom(room.ToString());

                if (roomsEventsResult != null)
                    foreach (var events in roomsEventsResult)
                    {
                        var eventAdapter = new DictionaryAdapter(events);

                        var temporaries = Temporary.GetTemporariesInEvents(eventAdapter.GetValue("events_id"));

                        var temporariesAdapter = new DictionaryAdapter(temporaries[0]);

                        var scheduleEventResult = Schedule.GetScheduleByIdOrderByLastUpdateDesc(temporariesAdapter.GetValue("schedule_id"));

                        if (scheduleEventResult != null)
                            foreach (var schedule in scheduleEventResult)
                            {
                                var scheduleAdapter = new DictionaryAdapter(schedule);

                                var startDayValue = scheduleAdapter.GetValue("startDay");
                                var startMonthValue = scheduleAdapter.GetValue("startMonth");
                                var startYearValue = scheduleAdapter.GetValue("startMonth");

                                var lastDayValue = scheduleAdapter.GetValue("endDay");
                                var lastMonthValue = scheduleAdapter.GetValue("endMonth");
                                var lastYearValue = scheduleAdapter.GetValue("endYear");

                                var startTime = scheduleAdapter.GetValue("startTime");
                                var endTime = scheduleAdapter.GetValue("endTime");

                                var startHourMin = startTime.Split(':');
                                var endHourMin = endTime.Split(':');
                                if(int.Parse(desiredEndDayMonthYear[2]) == int.Parse(startYearValue) 
                                   || int.Parse(desiredEndDayMonthYear[2]) == int.Parse(lastYearValue)
                                   || int.Parse(desiredStartDayMonthYear[2]) == int.Parse(startYearValue)
                                   || int.Parse(desiredStartDayMonthYear[2]) == int.Parse(lastYearValue))
                                {
                                    if (startMonthValue.Equals(desiredStartDayMonthYear[1]) && lastMonthValue.Equals(desiredEndDayMonthYear[1]))
                                    {
                                        if (int.Parse(startDayValue) > int.Parse(desiredStartDayMonthYear[0]))
                                        {
                                            if (int.Parse(startDayValue) < int.Parse(desiredEndDayMonthYear[0]))
                                            {
                                            }
                                            else if (int.Parse(startDayValue) > int.Parse(desiredEndDayMonthYear[0]))
                                            {
                                                return false;
                                            }
                                            else if (int.Parse(startDayValue) ==
                                                     int.Parse(desiredEndDayMonthYear[0]))
                                            {
                                                if (!CheckTimeConflict(desiredStartTime, desiredEndTime, startHourMin,
                                                    endHourMin)) return false;
                                            }
                                        }
                                        else if (int.Parse(startDayValue) < int.Parse(desiredStartDayMonthYear[0]))
                                        {
                                            if (int.Parse(startDayValue) < int.Parse(desiredEndDayMonthYear[0]))
                                            {
                                            }
                                            else if (int.Parse(lastDayValue) > int.Parse(desiredStartDayMonthYear[0]))
                                            {
                                                return false;
                                            }
                                            else if (int.Parse(lastDayValue) ==
                                                     int.Parse(desiredStartDayMonthYear[0]))
                                            {
                                                if (!CheckTimeConflict(desiredStartTime, desiredEndTime, startHourMin,
                                                    endHourMin)) return false;
                                            }
                                        }
                                        else if (int.Parse(lastDayValue) == int.Parse(desiredStartDayMonthYear[0]))
                                        {
                                            if (!CheckTimeConflict(desiredStartTime, desiredEndTime, startHourMin,
                                                endHourMin)) return false;
                                        }
                                        else
                                        {
                                            return false;
                                        }
                                    }
                                    else if (lastMonthValue.Equals(desiredStartDayMonthYear[1]))
                                    {
                                        if (int.Parse(lastDayValue) < int.Parse(desiredStartDayMonthYear[0]))
                                        {
                                        }
                                        else if (int.Parse(lastDayValue) > int.Parse(desiredStartDayMonthYear[0]))
                                        {
                                            return false;
                                        }
                                        else if (int.Parse(lastDayValue) == int.Parse(desiredStartDayMonthYear[0]))
                                        {
                                            if (!CheckTimeConflict(desiredStartTime, desiredEndTime, startHourMin,
                                                endHourMin)) return false;
                                        }
                                    }
                                    else if (startMonthValue.Equals(desiredEndDayMonthYear[1]))
                                    {
                                        if (int.Parse(desiredEndDayMonthYear[1]) < int.Parse(startMonthValue))
                                        {
                                        }
                                        else if (int.Parse(desiredEndDayMonthYear[1]) > int.Parse(startMonthValue))
                                        {
                                            return false;
                                        }
                                        else if (int.Parse(lastDayValue) == int.Parse(desiredStartDayMonthYear[1]))
                                        {
                                            if (!CheckTimeConflict(desiredStartTime, desiredEndTime, startHourMin,
                                                endHourMin)) return false;
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
            var date = new DateTime();
            var day = date.Day;
            var month = date.Month;
            var year = date.Year;

            // Schedules
            var schedules = Schedule.GetAllSchedules();
            var schedulesList = new List<Schedule>();
            foreach (var schedule in schedules)
            {
                var scheduleAdapter = new DictionaryAdapter(schedule);
                var startDateValue = scheduleAdapter.GetValue("firstDay");
                var lastDateValue = scheduleAdapter.GetValue("lastDay");

                var startDayMonthYear = startDateValue.Split('-');
                var endDayMonthYear = lastDateValue.Split('-');

                if (month.ToString().Equals(startDayMonthYear[1]) && year.ToString().Equals(endDayMonthYear[1]))
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

            if (schedulesList.Count == 0)
                return null;
            return schedulesList;
        }

        public IList<Events> GetPermanentList()
        {
            var events = new List<Events>();

            var permanentDictionary = Permanent.GetAllPermanents();
            foreach (var permanent in permanentDictionary)
            {
                Events newEvents = (Permanent)FactoryCreator.Instance.CreateFactory(FactoryCreator.ExhibitionFactory)
                    .ImportData(ExhibitionFactory.Permanent, permanent);
                events.Add(newEvents);
            }

            return events;
        }

        public bool CheckTimeConflict(string[] desiredStart, string[] desiredEnd, string[] start, string[] end)
        {
            if (int.Parse(desiredStart[0]) > int.Parse(start[0]))
                if (int.Parse(end[0]) < int.Parse(desiredStart[0]))
                    return true;
                else if (int.Parse(end[0]) == int.Parse(desiredStart[0]))
                    if (int.Parse(end[1]) <= int.Parse(desiredStart[1]))
                        return true;
                    else
                        return false;
                else
                    return false;
            if (int.Parse(desiredStart[0]) < int.Parse(start[0]))
                if (int.Parse(desiredEnd[0]) < int.Parse(start[0]))
                    return true;
                else if (int.Parse(desiredEnd[0]) == int.Parse(start[0]))
                    if (int.Parse(desiredEnd[1]) <= int.Parse(start[1]))
                        return true;
                    else
                        return false;
                else
                    return false;
            return false;
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            if (CheckFields())
                if (CheckRoomAvailbility(_roomsIdList))
                {
                    if (ParentForm != null)
                    {
                        var appForms = (AppForms)ParentForm;
                        var dashboardControl = appForms.DashboardControl;

                        var exhibitorResult = Exhibitor.GetExhibitorByPersonId(dashboardControl.Person.Id.ToString());
                        var exhibitor = (Exhibitor)FactoryCreator.Instance.CreateFactory(FactoryCreator.PersonFactory)
                            .ImportData(PersonFactory.Exhibitor, exhibitorResult[0]);

                        var rooms = new List<Room>();

                        var roomsResult = Room.GetAllRoomsByIds(_roomsIdList);

                        foreach (var room in roomsResult)
                        {
                            var newRoom = new Room(room);
                            rooms.Add(newRoom);
                        }

                        var date = FromPicker.Value;
                        var dayStart = date.Day;
                        var monthStart = date.Month;
                        var yearStart = date.Year;

                        date = UntilPicker.Value;
                        var dayEnd = date.Day;
                        var monthEnd = date.Month;
                        var yearEnd = date.Year;

                        var schedule = new Schedule(dayStart.ToString(), monthStart.ToString(), yearStart.ToString(),
                            dayEnd.ToString(), monthEnd.ToString(), yearEnd.ToString(), startBox.Text, endBox.Text);
                        schedule.Save();

                        var employeesResult = Employee.GetAllEmployees();

                        var number = 0;
                        var chosenId = 0;

                        for (var i = 0; i < employeesResult.Count; i++)
                        {
                            var adapterEmployee = new DictionaryAdapter(employeesResult[i]);

                            var processesResult = Process.GetProcessesByEmployeeIdandActive(adapterEmployee.GetValue("id"));
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

                        var employeeResult = Employee.GetAllEmployeesByRoleId(chosenId.ToString());

                        var employee = (Employee)FactoryCreator.Instance.CreateFactory(FactoryCreator.PersonFactory)
                            .ImportData(PersonFactory.Employee, employeeResult[0]);

                        var process = new Process(exhibitor, employee, schedule, rooms, textBoxName.Text,
                            textBoxDescription.Text, textBoxTitle.Text, "img");
                        process.Save();
                    }
                    _roomsIdList.Clear();

                    if (ParentForm != null)
                    {
                        var appForms = (AppForms)ParentForm;
                        var processesExhibitorControl = appForms.ProcessesExhibitorControl;
                        processesExhibitorControl.GetProcesses();
                        processesExhibitorControl.ResetProcesses();
                        processesExhibitorControl.ListProcesses(processesExhibitorControl.ActualPage);
                        processesExhibitorControl.BringToFront();
                    }
                }
                else
                {
                    var myTimer = new Timer { Interval = 1000 };
                    InvalidValue.Text = @"These schedule is not available in this rooms!";
                    InvalidValue.Visible = true;
                    myTimer.Tick += HideFail;
                    myTimer.Start();
                }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (ParentForm != null)
            {
                var appForms = (AppForms)ParentForm;
                appForms.ProcessesExhibitorControl.BringToFront();
            }
        }
    }
}