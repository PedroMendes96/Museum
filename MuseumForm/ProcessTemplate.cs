using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Museum;

namespace MuseumForm
{
    public abstract partial class ProcessTemplate : UserControl
    {
        private int initialSize;

        public int InitialSize
        {
            get => initialSize;
            set => initialSize = value;
        }

        public ProcessTemplate()
        {
            InitializeComponent();
        }

        private IList<Process> processes = new List<Process>();

        public IList<Process> Processes
        {
            get => processes;
            set => processes = value;
        }

        public abstract int GetPage();

        public abstract void SetPage(int page);

        public void ResetProcesses()
        {
            GetContainer().Controls.Clear();
            Processes.Clear();
        }

        public abstract Panel GetContainer();

        public void Previous_Click(object sender, EventArgs e)
        {
            var ActualPage = GetPage();
            if (ActualPage != 1)
            {
                SetPage(ActualPage--);
                ResetProcesses();
                ListProcesses(ActualPage);
            }
        }

        public abstract void HideNextPreviousButtons();

        public abstract void ShowNextPreviousButtons();

        public void ListProcesses(int i)
        {
            var processesList = GetProcesses();
            processes = processesList;

            processes = processes.OrderBy(o => o.LastUpdate).ToList();

            var maxPag = (int)Math.Ceiling((double)processes.Count / 5);

            if (maxPag > 1)
            {
                ShowNextPreviousButtons();
            }
            else
            {
                HideNextPreviousButtons();
            }

            if (processesList.Count > 0)
            {
                var processContainer = GetContainer();
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
                    var indexOf = ParentForm.Controls.IndexOfKey(AppForms.Dashboard_Control);
                    var dashboardControl = (DashboardControl)ParentForm.Controls[indexOf];
                    var role = dashboardControl.Role;

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
                    employeePanel.Name = "Employee" + processes[j].Employee.Id;
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
                    processLabel.MouseEnter += delegate { HoverMouse(employeeLabel, processLabel); };
                    processLabel.MouseLeave += delegate { LeaveMouse(employeeLabel, processLabel); };
                    processLabel.TextAlign = ContentAlignment.MiddleCenter;


                    employeeLabel.Dock = DockStyle.Fill;
                    employeeLabel.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
                    employeeLabel.Location = new Point(0, index * PanelSize);
                    employeeLabel.Name = "EmployeeNumber:" + processes[j].Employee.Id;
                    employeeLabel.Size = new Size(containerSize.Width, PanelSize / 2);
                    employeeLabel.TabIndex = 0;
                    employeeLabel.Click += delegate { ClickPanel(selectedProcess); };
                    employeeLabel.MouseHover += delegate { HoverMouse(employeeLabel, processLabel); };
                    employeeLabel.MouseEnter += delegate { HoverMouse(employeeLabel, processLabel); };
                    employeeLabel.MouseLeave += delegate { LeaveMouse(employeeLabel, processLabel); };
                    if (role.Equals(nameof(Employee)))
                    {
                        employeeLabel.Text = "Exhibitor: " + processes[j].Employee.Name;
                    }
                    else
                    {
                        employeeLabel.Text = "Employee: " + processes[j].Employee.Name;
                    }
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

        public void Next_Click(object sender, EventArgs e)
        {
            var ActualPage = GetPage();
            var maxPag = (int)Math.Ceiling((double)processes.Count / 5);
            if (ActualPage != maxPag)
            {
                SetPage(ActualPage++);
                ResetProcesses();
                ListProcesses(ActualPage);
            }
        }

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

        private void ClickPanel(Process process)
        {
            var indexOf = ParentForm.Controls.IndexOfKey(AppForms.ProcessControl);
            var ProcessControl = (ProcessControl)ParentForm.Controls[indexOf];
            ProcessControl.Process = process;
            ProcessControl.UpdateViewPerUser();
            ProcessControl.BringToFront();
        }

        public abstract Person GetPersonRole(int idPerson);

        public abstract string GetProcessByPerson(int idPerson);

        public abstract Person GetOtherPerson(DictionaryAdapter dictionaryAdapter);

        public abstract Process CreateProcess(Dictionary<string, string> process, Person Role, Person OtherEntety,
            Schedule schedule, List<Room> rooms);

        public List<Process> GetProcesses()
        {
            var processes = new List<Process>();

            var index = ParentForm.Controls.IndexOfKey(AppForms.Dashboard_Control);
            var dashboardControl = (DashboardControl)ParentForm.Controls[index];

            var Role = GetPersonRole(dashboardControl.Person.Id);

            var processesResult = DBConnection.Instance.Query(GetProcessByPerson(Role.RoleId()));

            if (processesResult != null)
                foreach (var process in processesResult)
                {
                    var processesAdapter = new DictionaryAdapter(process);

                    var RoomsSQL = "SELECT * FROM processes_has_rooms WHERE processes_id=" +
                                   processesAdapter.GetValue("id");
                    var RoomsResult = DBConnection.Instance.Query(RoomsSQL);

                    var OtherEntety = GetOtherPerson(processesAdapter);

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

                    var newProcesses = CreateProcess(process,Role,OtherEntety,Schedule,Rooms);
                    processes.Add(newProcesses);
                }

            return processes;
        }


    }
}
