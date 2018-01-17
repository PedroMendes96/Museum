using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SpecSchedule_Click(object sender, EventArgs e)
        {
            var value = (ComboboxItem)RoomsCombo.SelectedItem;
            long idRoom = 0;
            try
            {
                idRoom = value.Value;
            }
            catch (NullReferenceException)
            {
                return;
            }

            DateTime date = dateTimePicker.Value;
            var day = date.Day;
            var month = date.Month;
            var year = date.Year;

            var properties = new[] {"events_id"};
            var tables = new[] {"rooms_has_events"};
            var keys = new[] {"rooms_id"};
            var values = new[] {idRoom.ToString()};

            var eventsSQL = SqlOperations.Instance.Select(properties, tables, keys, values);
            var eventsID = DBConnection.Instance.Query(eventsSQL);
            var eventAdapter = new DictonaryAdapter(eventsID[0]);
            Events.Controls.Clear();

            if (eventsID.Count == 1)
            {
                properties = new[] { "*" };
                tables = new[] { "events" };
                keys = new[] { "id" };
                values = new[] { eventAdapter.GetValue("events_id") };

                var eventSQL = SqlOperations.Instance.Select(properties, tables, keys, values);
                var eventResult = DBConnection.Instance.Query(eventSQL);
                var resultAdapter = new DictonaryAdapter(eventResult[0]);

                Events.Controls.Clear();

                Label label = new Label();
                label.Dock = DockStyle.Fill;
                label.Location = new Point(3, 0);
                label.Name = "Description";
                label.Size = new Size(243, 457);
                label.TabIndex = 0;
                label.Text = resultAdapter.GetValue("description");
                label.TextAlign = ContentAlignment.MiddleCenter;

                Events.BackColor = Color.Chocolate;
                Events.ColumnCount = 1;
                Events.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
                Events.Controls.Add(label, 0, 0);
                Events.Dock = DockStyle.Fill;
                Events.Location = new Point(111, 43);
                Events.Name = "Events";
                Events.RowCount = 1;
                Events.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
                Events.Size = new Size(249, 457);
                Events.TabIndex = 41;
            }
            else
            {
                if (eventsID != null)
                {
                    // Se houver eventos com essa sala


                    List<int> idSchedules = new List<int>();
                    DictonaryAdapter eventsAdapter = null;

                    // Para cada evento ver se é temporario, se nao for é permanente
                    foreach (var events in eventsID)
                    {
                        var adapter = new DictonaryAdapter(events);

                        properties = new[] { "*" };
                        tables = new[] { "temporaries" };
                        keys = new[] { "events_id" };
                        values = new[] { adapter.GetValue("events_id") };

                        var temporariesSQL = SqlOperations.Instance.Select(properties, tables, keys, values);
                        var temporariesList = DBConnection.Instance.Query(temporariesSQL);

                        if (temporariesList.Count > 0)
                        {
                            eventsAdapter = new DictonaryAdapter(temporariesList[0]);
                            idSchedules.Add(int.Parse(eventsAdapter.GetValue("schedule_id")));
                        }
                    }

                    TableLayoutPanel table = Events;
                    if (idSchedules.Count > 0)
                    {
                        var sqlSchedules = "SELECT * FROM schedules WHERE ";

                        for (int i = 0; i < idSchedules.Count; i++)
                        {
                            if (idSchedules.Count - 1 == i)
                            {
                                sqlSchedules += "id=" + idSchedules + "AND startDay <="+day+" AND endDay>="+day+" AND " +
                                                "startMonth = "+month+" OR endMonth = "+month+" and" +
                                                "startYear="+year+" OR endYear="+year+"  ORDER BY startTime ASC";
                            }
                            else
                            {
                                sqlSchedules += "id=" + idSchedules + " OR ";
                            }
                        }

                        var AllSchedules = DBConnection.Instance.Query(sqlSchedules);
                        Events.RowCount = AllSchedules.Count;
                        int totalDivisions = 0;
                        List<int> spacesList = new List<int>();
                        List<string> pickList = new List<string>();
                        int index = 0;
                        var baseTime = "9:00";
                        foreach (var schedule in AllSchedules)
                        {
                            var adapterSchedule = new DictonaryAdapter(schedule);

                            var startTime = adapterSchedule.GetValue("startTime");
                            var startTimeComponentes = startTime.Split(':');
                            var endTime = adapterSchedule.GetValue("endTime");
                            var endTimeComponentes = endTime.Split(':');


                            if (!baseTime.Equals(startTime))
                            {
                                var baseSplit = baseTime.Split(':');
                                var baseInicial = int.Parse(baseSplit[0]);
                                baseInicial = startTimeComponentes[1].Equals("30") ? baseInicial + 1 : baseInicial;

                                var startTimeNext = int.Parse(startTimeComponentes[0]);
                                startTimeNext = startTimeComponentes[1].Equals("30") ? startTimeNext + 1 : startTimeNext;

                                var spaceWithout = startTimeNext - baseInicial;
                                totalDivisions += spaceWithout;
                                spacesList.Add(spaceWithout);
                                pickList.Add("Without");
                            }

                            var horaInicial = int.Parse(startTimeComponentes[0]);
                            horaInicial = startTimeComponentes[1].Equals("30") ? horaInicial+1 : horaInicial;

                            var horaFinal = int.Parse(endTimeComponentes[0]);
                            horaFinal = endTimeComponentes[1].Equals("30") ? horaFinal + 1 : horaFinal;

                            var space = horaFinal - horaInicial;
                            totalDivisions += space;
                            spacesList.Add(space);
                            pickList.Add("Schedule");

                            index++;

                        }

                        for (int i = 0; i < spacesList.Capacity; i++)
                        {
                            var total = 100.00;
                            var parte = (float)(total / totalDivisions) * spacesList[i];
                            Events.RowStyles.Add(new RowStyle(SizeType.Percent, parte));


                            Label panel = new Label();
                            panel.Dock = DockStyle.Fill;
                            //panel.Location = new Point(3, (int)parte/100 * Events.Size.Height);
                            panel.Name = "Schedule"+i;
                            panel.TabIndex = 1;
                            panel.Text = "Schedule"+i;
                            panel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                            Events.Controls.Add(panel, 0, i);
                        }


                    }
                }
            }
        }

        private void TableSchedule_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ScheduleControl_Load(object sender, EventArgs e)
        {

        }

        public void addRooms()
        {
            RoomsCombo.Items.Clear();
            var attr = new[] {"id"};
            var tables = new[] {"rooms"};
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
                    RoomsCombo.Items.Add(comboItem);
                }
            }
        }
    }
}
