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
    public partial class ProcessesEmployeeControl : UserControl
    {
        IList<Process> processes = new List<Process>();
        public ProcessesEmployeeControl()
        {
            InitializeComponent();
        }

        public void ResetProcesses()
        {
            processContainer.Controls.Clear();
            processes.Clear();
        }

        public void ListProcesses()
        {
            processes = GetProcesses();
            if (processes.Count > 0)
            {
                var containerSize = processContainer.Size;
                var PanelSize = containerSize.Height / processes.Count;
                int index = 0;
                foreach (var process in processes)
                {
                    Panel panel = new Panel();
                    panel.Dock = DockStyle.Top;
                    panel.Location = new Point(0, 0);
                    panel.Name = "process" + process.Id;
                    panel.Size = new Size(containerSize.Width, PanelSize);
                    panel.TabIndex = index;

                    Panel processPanel = new Panel();
                    processPanel.Dock = DockStyle.Top;
                    processPanel.Location = new Point(0, index * PanelSize);
                    processPanel.Name = "Process" + process.Id;
                    processPanel.Size = new Size(containerSize.Width, PanelSize / 2);
                    processPanel.AutoSize = false;
                    processPanel.TabIndex = 0;

                    Panel employeePanel = new Panel();
                    employeePanel.Dock = DockStyle.Top;
                    employeePanel.Location = new Point(0, index * PanelSize + PanelSize / 2);
                    employeePanel.Name = "Employee" + process.Employee.Id;
                    employeePanel.Size = new Size(containerSize.Width, PanelSize / 2);
                    employeePanel.AutoSize = false;
                    employeePanel.TabIndex = 1;

                    Label processLabel = new Label();
                    processLabel.Dock = DockStyle.Fill;
                    processLabel.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
                    processLabel.Location = new Point(0, index * PanelSize);
                    processLabel.Name = "ProcessNumber" + index;
                    processLabel.Size = new Size(containerSize.Width, PanelSize / 2);
                    processLabel.TabIndex = 0;
                    processLabel.Text = "ProcessNumber" + process.Id;
                    processLabel.Click += delegate { ClickPanel(index); };
                    processLabel.TextAlign = ContentAlignment.MiddleCenter;

                    Label employeeLabel = new Label();
                    employeeLabel.Dock = DockStyle.Fill;
                    employeeLabel.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
                    employeeLabel.Location = new Point(0, index * PanelSize);
                    employeeLabel.Name = "EmployeeNumber:" + process.Employee.Id;
                    employeeLabel.Size = new Size(containerSize.Width, PanelSize / 2);
                    employeeLabel.TabIndex = 0;
                    employeeLabel.Click += delegate { ClickPanel(index); };
                    employeeLabel.Text = "Employee: " + process.Employee.Name;
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
                Console.WriteLine("No processes");
            }
        }

        public List<Process> GetProcesses()
        {
            List<Process> processes = new List<Process>();

            var index = this.ParentForm.Controls.IndexOfKey(AppForms.Dashboard_Control);
            var dashboardControl = (DashboardControl)this.ParentForm.Controls[index];

            var employeeSQL = "SELECT name,phone,password,persons.id AS persons_id, employees.id AS employees_id FROM persons, employees WHERE persons.id=" + dashboardControl.Person.Id+" AND employees.persons_id=persons.id";


            var employeeResult = DBConnection.Instance.Query(employeeSQL);
            //var employeeAdapter = new DictonaryAdapter(employeeResult[0]);

            var Employee = (Employee)FactoryCreator.Instance.CreateFactory(FactoryCreator.PersonFactory)
                .ImportData(PersonFactory.employee, employeeResult[0]);

            var processesSQL = "SELECT * FROM processes WHERE employees_id=" + Employee.IdEmployee + " ORDER BY active DESC";
            var processesResult = DBConnection.Instance.Query(processesSQL);

            foreach (var process in processesResult)
            {
                var processesAdapter = new DictonaryAdapter(process);

                var RoomsSQL = "SELECT * FROM processes_has_rooms WHERE processes_id=" + processesAdapter.GetValue("id");
                var RoomsResult = DBConnection.Instance.Query(RoomsSQL);

                var PersonRole =
                    "SELECT persons.id as persons_id, exhibitors.id AS exhibitors_id, name, password, phone, mail, type FROM persons, exhibitors" +
                    " WHERE persons_id=persons.id AND exhibitors.id=" + processesAdapter.GetValue("exhibitors_id");
                var PersonResult = DBConnection.Instance.Query(PersonRole);
                var Exhibitor = (Exhibitor)FactoryCreator.Instance.CreateFactory(FactoryCreator.PersonFactory).ImportData(PersonFactory.exhibitor, PersonResult[0]);

                var ScheduleSQL = "SELECT * FROM schedules WHERE id=" + processesAdapter.GetValue("schedule_id");
                var ScheduleResult = DBConnection.Instance.Query(ScheduleSQL);
                var Schedule = new Schedule(ScheduleResult[0]);

                List<Room> Rooms = new List<Room>();

                foreach (var room in RoomsResult)
                {
                    var adapterRoom = new DictonaryAdapter(room);
                    var specRoom = "SELECT * FROM rooms WHERE id=" + adapterRoom.GetValue("rooms_id");
                    var specRoomResult = DBConnection.Instance.Query(specRoom);
                    var newRoom = new Room(specRoomResult[0]);
                    Rooms.Add(newRoom);
                }
                var newProcesses = new Process(Exhibitor, Employee, Schedule, Rooms);
                processes.Add(newProcesses);
            }
            return processes;
        }

        private void ClickPanel(int index)
        {
            var indexOf = this.ParentForm.Controls.IndexOfKey(AppForms.ProcessControl);
            var ProcessControl = (ProcessControl)this.ParentForm.Controls[indexOf];
            ProcessControl.Process = processes[index - 1];
            ProcessControl.UpdateViewPerUser();
            ProcessControl.BringToFront();
        }
    }
}
