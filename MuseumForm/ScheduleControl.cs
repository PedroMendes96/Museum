using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Museum;

namespace MuseumForm
{
    public partial class ScheduleControl : UserControl
    {
        public ScheduleControl()
        {
            InitializeComponent();
        }

        private void SpecSchedule_Click(object sender, EventArgs e)
        {
            Exhibitions.Controls.Clear();
            var value = (ComboboxItem) RoomsCombo.SelectedItem;
            long idRoom = 0;
            try
            {
                idRoom = value.Value;
            }
            catch (NullReferenceException)
            {
                return;
            }

            var date = dateTimePicker.Value;
            var day = date.Day;
            var month = date.Month;
            var year = date.Year;

            var eventsID = Museum.Events.GetEventsByRoom(idRoom.ToString());
            if (eventsID.Count > 0)
            {
                var idSchedules = new List<int>();
                DictionaryAdapter eventsAdapter = null;

                // Para cada evento ver se é temporario, se nao for é permanente
                foreach (var events in eventsID)
                {
                    var adapter = new DictionaryAdapter(events);

                    var temporariesList = Temporary.GetTemporariesInEvents(adapter.GetValue("events_id"));

                    if (temporariesList.Count > 0)
                    {
                        eventsAdapter = new DictionaryAdapter(temporariesList[0]);
                        idSchedules.Add(int.Parse(eventsAdapter.GetValue("schedule_id")));
                    }
                }

                if (idSchedules.Count > 0)
                {
                    var AllSchedules = Schedule.GetSchedulesByIds(idSchedules, day, month, year);

                    var scheduleList = new List<Schedule>();
                    foreach (var schedule in AllSchedules)
                    {
                        var AddSchedule = new Schedule(schedule);
                        scheduleList.Add(AddSchedule);
                    }

                    var totalDivisions = 20;
                    var spacesList = new List<int>();
                    var pickList = new List<string>();
                    var textsLabel = new List<string>();

                    var baseTime = "9:00";

                    foreach (var schedule in scheduleList)
                    {
                        var startTime = schedule.StartTime;
                        var startTimeComponentes = startTime.Split(':');
                        var endTime = schedule.EndTime;
                        var endTimeComponentes = endTime.Split(':');

                        if (!baseTime.Equals(startTime))
                        {
                            var baseSplit = baseTime.Split(':');
                            var baseInicial = int.Parse(baseSplit[0]) * 2;
                            baseInicial = startTimeComponentes[1].Equals("30") ? baseInicial + 1 : baseInicial;

                            var startTimeNext = int.Parse(startTimeComponentes[0]) * 2;
                            startTimeNext = startTimeComponentes[1].Equals("30")
                                ? startTimeNext + 1
                                : startTimeNext;

                            var spaceWithout = startTimeNext - baseInicial;
//                            totalDivisions += spaceWithout;
                            textsLabel.Add("Free Schedule");
                            spacesList.Add(spaceWithout);
                            pickList.Add("Without");
                        }

                        var horaInicial = int.Parse(startTimeComponentes[0]) * 2;
                        horaInicial = startTimeComponentes[1].Equals("30") ? horaInicial + 1 : horaInicial;

                        var horaFinal = int.Parse(endTimeComponentes[0]) * 2;
                        horaFinal = endTimeComponentes[1].Equals("30") ? horaFinal + 1 : horaFinal;

                        var space = horaFinal - horaInicial;
//                        totalDivisions += space;
                        spacesList.Add(space);
                        pickList.Add("Schedule");
                        baseTime = endTime;

                        var processEventResult = Process.GetProcessByScheduleId(schedule.Id.ToString());
                        var adapter = new DictionaryAdapter(processEventResult[0]);
                        textsLabel.Add(adapter.GetValue("title") + "-" + adapter.GetValue("name"));
                    }

                    if (!baseTime.Equals("19:00"))
                    {
                        var final = 38;
                        var componentTime = baseTime.Split(':');
                        var lastDivision = componentTime[1].Equals("30")
                            ? int.Parse(componentTime[0]) * 2 + 1
                            : int.Parse(componentTime[0]) * 2;
                        lastDivision = final - lastDivision + 1;
                        spacesList.Add(lastDivision);
                        pickList.Add("Without");
                        textsLabel.Add("Free Schedule");
                    }

                    var listOfPanels = new List<Panel>();

                    var distanceTop = 0;
                    var heigtht = Exhibitions.Size.Height;
                    var width = Exhibitions.Size.Width;
                    var pie = (float) (heigtht / totalDivisions);
                    for (var i = 0; i < spacesList.Count; i++)
                    {
                        var panel = new Panel();
                        panel.Dock = DockStyle.Top;
                        panel.Location = new Point(0, (int) (i * (distanceTop * pie)));
                        panel.Name = "Time" + i;
                        if (pickList[i].Equals("Without"))
                            panel.BackColor = Color.White;
                        else
                            panel.BackColor = Color.Yellow;
                        panel.Size = new Size(width, (int) (spacesList[i] * pie));
                        panel.AutoSize = false;
                        panel.TabIndex = i;
                        panel.BorderStyle = BorderStyle.FixedSingle;

                        var label = new Label();
                        label.Dock = DockStyle.Fill;
                        label.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
                        label.Location = new Point(0, (int) (i * (distanceTop * pie)));
                        label.Name = "Event-" + i;
                        label.Size = new Size(width, (int) (spacesList[i] * pie));
                        label.TabIndex = 1;
                        label.Text = textsLabel[i];
                        label.TextAlign = ContentAlignment.MiddleCenter;

                        distanceTop += spacesList[i];

                        panel.Controls.Add(label);
                        listOfPanels.Add(panel);
                    }

                    listOfPanels.Reverse();
                    foreach (var panel in listOfPanels) Exhibitions.Controls.Add(panel);
                }
            }
        }

        public void addRooms()
        {
            RoomsCombo.Items.Clear();
            var roomsList = Room.GetAllRooms();
            if (roomsList != null)
                foreach (var room in roomsList)
                {
                    var dictionaryAdapter = new DictionaryAdapter(room);
                    var comboItem = new ComboboxItem();
                    comboItem.Text = "Room " + dictionaryAdapter.GetValue("id");
                    comboItem.Value = int.Parse(dictionaryAdapter.GetValue("id"));
                    RoomsCombo.Items.Add(comboItem);
                }
        }
    }
}