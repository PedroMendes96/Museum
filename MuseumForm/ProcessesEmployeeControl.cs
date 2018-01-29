using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Museum;

namespace MuseumForm
{
    public partial class ProcessesEmployeeControl : UserControl
    {
        private readonly int initialSize;
        private IList<Process> processes = new List<Process>();

        public ProcessesEmployeeControl()
        {
            InitializeComponent();
            initialSize = processContainer.Size.Height;
        }

        public int ActualPage { get; set; } = 1;

        public void ResetProcesses()
        {
            processContainer.Controls.Clear();
            processes.Clear();
        }

        public void ListProcesses(int i)
        {
            var processesList = GetProcesses();
            processes = processesList;

            processes = processes.OrderBy(o => o.LastUpdate).ToList();

            var maxPag = (int) Math.Ceiling((double) processes.Count / 5);

            if (maxPag > 1)
            {
                Next.Visible = true;
                Previous.Visible = true;
            }
            else
            {
                Next.Visible = false;
                Previous.Visible = false;
            }

            if (processesList.Count > 0)
            {
                var divisor = processesList.Count - (i - 1) * 5 > 5 ? 5 : processesList.Count - (i - 1) * 5;
                var containerSize = processContainer.Size;
                var pie = initialSize / 5;

                if (divisor < 5)
                {
                    containerSize.Height = initialSize - (5 - divisor) * pie;
                    processContainer.Size = containerSize;
                }
                else
                {
                    containerSize.Height = initialSize;
                    processContainer.Size = containerSize;
                }

                var PanelSize = containerSize.Height / divisor;
                var index = 0;

                for (var j = (i - 1) * 5; j < (i - 1) * 5 + divisor; j++)
                {
                    var selectedProcess = processes[j];

                    var panel = new Panel();
                    panel.Dock = DockStyle.Top;
                    panel.Location = new Point(0, 0);
                    panel.Name = "process" + processes[j];
                    panel.BorderStyle = BorderStyle.FixedSingle;
                    panel.Size = new Size(containerSize.Width, PanelSize);
                    panel.TabIndex = index;

                    var processPanel = new Panel();
                    processPanel.Dock = DockStyle.Top;
                    processPanel.Location = new Point(0, index * PanelSize);
                    processPanel.Name = "Process" + processes[j];
                    processPanel.Size = new Size(containerSize.Width, PanelSize / 2);
                    processPanel.AutoSize = false;
                    processPanel.TabIndex = 0;

                    var employeePanel = new Panel();
                    employeePanel.Dock = DockStyle.Top;
                    employeePanel.Location = new Point(0, index * PanelSize + PanelSize / 2);
                    employeePanel.Name = "Exhibitor" + processes[j].Exhibitor.Id;
                    employeePanel.Size = new Size(containerSize.Width, PanelSize / 2);
                    employeePanel.AutoSize = false;
                    employeePanel.TabIndex = 1;

                    var processLabel = new Label();
                    var employeeLabel = new Label();
                    processLabel.Dock = DockStyle.Fill;
                    processLabel.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
                    processLabel.Location = new Point(0, index * PanelSize);
                    processLabel.Name = "ProcessNumber" + index;
                    processLabel.Size = new Size(containerSize.Width, PanelSize / 2);
                    processLabel.TabIndex = 0;
                    processLabel.Text = "ProcessNumber" + processes[j].Id;
                    processLabel.Click += delegate { ClickPanel(selectedProcess); };
                    processLabel.MouseHover += delegate { HoverMouse(employeeLabel, processLabel); };
                    processLabel.MouseLeave += delegate { LeaveMouse(employeeLabel, processLabel); };
                    processLabel.TextAlign = ContentAlignment.MiddleCenter;


                    employeeLabel.Dock = DockStyle.Fill;
                    employeeLabel.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
                    employeeLabel.Location = new Point(0, index * PanelSize);
                    employeeLabel.Name = "ExhibitorNumber:" + processes[j].Exhibitor.Id;
                    employeeLabel.Size = new Size(containerSize.Width, PanelSize / 2);
                    employeeLabel.TabIndex = 0;
                    employeeLabel.Click += delegate { ClickPanel(selectedProcess); };
                    employeeLabel.MouseHover += delegate { HoverMouse(employeeLabel, processLabel); };
                    employeeLabel.MouseLeave += delegate { LeaveMouse(employeeLabel, processLabel); };
                    employeeLabel.Text = "Exhibitor: " + processes[j].Exhibitor.Name;
                    employeeLabel.TextAlign = ContentAlignment.MiddleCenter;

                    processPanel.Controls.Add(processLabel);
                    employeePanel.Controls.Add(employeeLabel);

                    panel.Controls.Add(processPanel);
                    panel.Controls.Add(employeePanel);
                    index++;
                    processContainer.Controls.Add(panel);
                }
            }
            else
            {
                ResetProcesses();
                Console.WriteLine("No processes");
            }
        }

//        public void ListProcesses(int i)
//        {
//            var processesList = GetProcesses();
//            processes = processesList;
//            if (processesList.Count > 0)
//            {
//                var containerSize = processContainer.Size;
//                var PanelSize = containerSize.Height / processesList.Count;
//                int index = 0;
//                foreach (var process in processesList)
//                {
//                    Process selectedProcess = processes[index];
//
//                    Panel panel = new Panel();
//                    panel.Dock = DockStyle.Top;
//                    panel.Location = new Point(0, 0);
//                    panel.Name = "process" + process.Id;
//                    panel.BorderStyle = BorderStyle.FixedSingle;
//                    panel.Size = new Size(containerSize.Width, PanelSize);
//                    panel.TabIndex = index;
//
//                    Panel processPanel = new Panel();
//                    processPanel.Dock = DockStyle.Top;
//                    processPanel.Location = new Point(0, index * PanelSize);
//                    processPanel.Name = "Process" + process.Id;
//                    processPanel.Size = new Size(containerSize.Width, PanelSize / 2);
//                    processPanel.AutoSize = false;
//                    processPanel.TabIndex = 0;
//
//                    Panel employeePanel = new Panel();
//                    employeePanel.Dock = DockStyle.Top;
//                    employeePanel.Location = new Point(0, index * PanelSize + PanelSize / 2);
//                    employeePanel.Name = "Exhibitor" + process.Exhibitor.Id;
//                    employeePanel.Size = new Size(containerSize.Width, PanelSize / 2);
//                    employeePanel.AutoSize = false;
//                    employeePanel.TabIndex = 1;
//
//                    Label processLabel = new Label();
//                    Label employeeLabel = new Label();
//                    processLabel.Dock = DockStyle.Fill;
//                    processLabel.Font = new Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//                    processLabel.Location = new Point(0, index * PanelSize);
//                    processLabel.Name = "ProcessNumber" + index;
//                    processLabel.Size = new Size(containerSize.Width, PanelSize / 2);
//                    processLabel.TabIndex = 0;
//                    processLabel.Text = "ProcessNumber" + process.Id;
//                    processLabel.Click += delegate { ClickPanel(selectedProcess); };
//                    processLabel.MouseHover += delegate { HoverMouse(employeeLabel, processLabel); };
//                    processLabel.MouseLeave += delegate { LeaveMouse(employeeLabel, processLabel); };
//                    processLabel.TextAlign = ContentAlignment.MiddleCenter;
//
//                    employeeLabel.Dock = DockStyle.Fill;
//                    employeeLabel.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
//                    employeeLabel.Location = new Point(0, index * PanelSize);
//                    employeeLabel.Name = "ExhibitorNumber:" + process.Exhibitor.Id;
//                    employeeLabel.Size = new Size(containerSize.Width, PanelSize / 2);
//                    employeeLabel.TabIndex = 0;
//                    employeeLabel.Click += delegate { ClickPanel(selectedProcess); };
//                    employeeLabel.MouseHover += delegate { HoverMouse(employeeLabel, processLabel); };
//                    employeeLabel.MouseLeave += delegate { LeaveMouse(employeeLabel, processLabel); };
//                    employeeLabel.Text = "Exhibitor: " + process.Exhibitor.Name;
//                    employeeLabel.TextAlign = ContentAlignment.MiddleCenter;
//
//                    processPanel.Controls.Add(processLabel);
//                    employeePanel.Controls.Add(employeeLabel);
//
//                    panel.Controls.Add(processPanel);
//                    panel.Controls.Add(employeePanel);
//                    index++;
//                    processContainer.Controls.Add(panel);
//                }
//            }
//            else
//            {
//                Console.WriteLine("No processes");
//            }
//        }


        public void HoverMouse(Label first, Label second)
        {
            first.BackColor = Color.AntiqueWhite;
            second.BackColor = Color.AntiqueWhite;
            Cursor.Current = Cursors.Hand;
        }

        public void LeaveMouse(Label first, Label second)
        {
            first.BackColor = Color.BurlyWood;
            second.BackColor = Color.BurlyWood;
            Cursor.Current = Cursors.Default;
        }

        public List<Process> GetProcesses()
        {
            var processes = new List<Process>();

            var index = ParentForm.Controls.IndexOfKey(AppForms.Dashboard_Control);
            var dashboardControl = (DashboardControl) ParentForm.Controls[index];

            var employeeSQL =
                "SELECT name,phone,password,persons.id AS persons_id, employees.id AS employees_id FROM persons, employees WHERE persons.id=" +
                dashboardControl.Person.Id + " AND employees.persons_id=persons.id";


            var employeeResult = DBConnection.Instance.Query(employeeSQL);
            //var employeeAdapter = new DictonaryAdapter(employeeResult[0]);

            var Employee = (Employee) FactoryCreator.Instance.CreateFactory(FactoryCreator.PersonFactory)
                .ImportData(PersonFactory.employee, employeeResult[0]);

            var processesSQL = "SELECT * FROM processes WHERE employees_id=" + Employee.IdEmployee +
                               " ORDER BY lastUpdate DESC";
            var processesResult = DBConnection.Instance.Query(processesSQL);

            if (processesResult != null)
                foreach (var process in processesResult)
                {
                    var processesAdapter = new DictionaryAdapter(process);

                    var RoomsSQL = "SELECT * FROM processes_has_rooms WHERE processes_id=" +
                                   processesAdapter.GetValue("id");
                    var RoomsResult = DBConnection.Instance.Query(RoomsSQL);

                    var PersonRole =
                        "SELECT persons.id as persons_id, exhibitors.id AS exhibitors_id, name, password, phone, mail, type FROM persons, exhibitors" +
                        " WHERE persons_id=persons.id AND exhibitors.id=" + processesAdapter.GetValue("exhibitors_id");
                    var PersonResult = DBConnection.Instance.Query(PersonRole);
                    var Exhibitor = (Exhibitor) FactoryCreator.Instance.CreateFactory(FactoryCreator.PersonFactory)
                        .ImportData(PersonFactory.exhibitor, PersonResult[0]);

                    var ScheduleSQL = "SELECT * FROM schedules WHERE id=" + processesAdapter.GetValue("schedule_id");
                    var ScheduleResult = DBConnection.Instance.Query(ScheduleSQL);
                    var Schedule = new Schedule(ScheduleResult[0]);

                    var Rooms = new List<Room>();

                    foreach (var room in RoomsResult)
                    {
                        var adapterRoom = new DictionaryAdapter(room);
                        var specRoom = "SELECT * FROM rooms WHERE id=" + adapterRoom.GetValue("rooms_id");
                        var specRoomResult = DBConnection.Instance.Query(specRoom);
                        var newRoom = new Room(specRoomResult[0]);
                        Rooms.Add(newRoom);
                    }

                    var newProcesses = new Process(process, Exhibitor, Employee, Schedule, Rooms);
                    processes.Add(newProcesses);
                }

            return processes;
        }

        private void ClickPanel(Process process)
        {
            var indexOf = ParentForm.Controls.IndexOfKey(AppForms.ProcessControl);
            var ProcessControl = (ProcessControl) ParentForm.Controls[indexOf];
            ProcessControl.Process = process;
            ProcessControl.UpdateViewPerUser();
            ProcessControl.BringToFront();
        }

        private void Previous_Click(object sender, EventArgs e)
        {
            if (ActualPage != 1)
            {
                ActualPage--;
                ResetProcesses();
                ListProcesses(ActualPage);
            }
        }

        private void Next_Click(object sender, EventArgs e)
        {
            var maxPag = (int) Math.Ceiling((double) processes.Count / 5);
            if (ActualPage != maxPag)
            {
                ActualPage++;
                ResetProcesses();
                ListProcesses(ActualPage);
            }
        }
    }
}