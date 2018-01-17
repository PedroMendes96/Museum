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
    public partial class ProcessesExhibitorControl : UserControl
    {
        IList<Process> processes = new List<Process>();
        public ProcessesExhibitorControl()
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
            var processesList = GetProcesses();
            if (processesList.Count > 0)
            {
                var containerSize = processContainer.Size;
                var PanelSize = containerSize.Height / processesList.Count;
                int index = 0;
                foreach (var process in processesList)
                {
                    Panel panel = new Panel();
                    panel.Dock = DockStyle.Top;
                    panel.Location = new Point(0, 0);
                    panel.Name = "process"+ process.Id;
                    panel.Size = new Size(containerSize.Width, PanelSize);
                    panel.TabIndex = index;

                    Panel processPanel = new Panel();
                    processPanel.Dock = DockStyle.Top;
                    processPanel.Location = new Point(0, index*PanelSize);
                    processPanel.Name = "Process"+ process.Id;
                    processPanel.Size = new Size(containerSize.Width, PanelSize/2);
                    panel.AutoSize = false;
                    processPanel.TabIndex = 0;

                    Panel employeePanel = new Panel();
                    employeePanel.Dock = DockStyle.Top;
                    employeePanel.Location = new Point(0, index * PanelSize + PanelSize/2);
                    employeePanel.Name = "Employee" + process.Employee.Id;
                    employeePanel.Size = new Size(containerSize.Width, PanelSize / 2);
                    panel.AutoSize = false;
                    employeePanel.TabIndex = 1;

                    Label processLabel = new Label();
                    processLabel.Dock = DockStyle.Fill;
                    processLabel.Font = new Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    processLabel.Location = new Point(0, index * PanelSize);
                    processLabel.Name = "ProcessNumber"+index;
                    processLabel.Size = new Size(containerSize.Width, PanelSize / 2);
                    processLabel.TabIndex = 0;
                    processLabel.Text = "ProcessNumber" + process.Id;
                    processLabel.TextAlign = ContentAlignment.MiddleCenter;

                    Label employeeLabel = new Label();
                    employeeLabel.Dock = DockStyle.Fill;
                    employeeLabel.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
                    employeeLabel.Location = new Point(0, index * PanelSize);
                    employeeLabel.Name = "EmployeeNumber:" + process.Employee.Id;
                    employeeLabel.Size = new Size(containerSize.Width, PanelSize / 2);
                    employeeLabel.TabIndex = 0;
                    employeeLabel.Text = "Employee: " + process.Employee.Name;
                    employeeLabel.TextAlign = ContentAlignment.MiddleCenter;

                    processPanel.Controls.Add(processLabel);
                    employeePanel.Controls.Add(employeeLabel);

                    panel.Controls.Add(processPanel);
                    panel.Controls.Add(employeePanel);
                    index++;
                    processContainer.Controls.Add(panel);
                }
                //ToolStripButton bindingNavigatorMovePreviousItem = new ToolStripButton();
                //ToolStripButton bindingNavigatorMoveNextItem = new ToolStripButton();

                //BindingNavigator bindingNavigator = new BindingNavigator();
                //bindingNavigator.AddNewItem = null;
                //bindingNavigator.CountItem = null;
                //bindingNavigator.DeleteItem = null;
                //bindingNavigator.Dock = DockStyle.None;
                //bindingNavigator.Items.AddRange(new ToolStripItem[] {
                //bindingNavigatorMovePreviousItem,
                //bindingNavigatorMoveNextItem});
                //bindingNavigator.Location = new Point(containerSize.Width + 20, containerSize.Height + 20);
                //bindingNavigator.MoveFirstItem = null;
                //bindingNavigator.MoveLastItem = null;
                //bindingNavigator.MoveNextItem = bindingNavigatorMoveNextItem;
                //bindingNavigator.MovePreviousItem = bindingNavigatorMovePreviousItem;
                //bindingNavigator.Name = "bindingNavigator";
                //bindingNavigator.PositionItem = null;
                //bindingNavigator.Size = new Size(90, 25);
                //bindingNavigator.TabIndex = 2;
                //bindingNavigator.Text = "bindingNavigator";

                //ComponentResourceManager resources = new ComponentResourceManager(typeof(ProcessesExhibitorControl));

                //bindingNavigatorMovePreviousItem.DisplayStyle = ToolStripItemDisplayStyle.Image;
                //bindingNavigatorMovePreviousItem.Image = ((Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
                //bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
                //bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
                //bindingNavigatorMovePreviousItem.Size = new Size(25, 25);
                //bindingNavigatorMovePreviousItem.Text = "Move previous";

                //bindingNavigatorMoveNextItem.DisplayStyle = ToolStripItemDisplayStyle.Image;
                //bindingNavigatorMoveNextItem.Image = ((Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
                //bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
                //bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
                //bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(25, 25);
                //bindingNavigatorMoveNextItem.Text = "Move next";
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

            var exhibitorSQL = "SELECT * FROM exhibitors WHERE person_id=" + dashboardControl.Person.Id;
            var exhibitorResult = DBConnection.Instance.Query(exhibitorSQL);
            var exhibitorAdapter = new DictonaryAdapter(exhibitorResult[0]);

            var processesSQL = "SELECT * FROM processes WHERE exhibitors_id=" + exhibitorAdapter.GetValue("id") + "ORDER BY lastUpdate DESC";
            var processesResult = DBConnection.Instance.Query(processesSQL);

            foreach (var process in processesResult)
            {
                var processesAdapter = new DictonaryAdapter(process);

                var RoomsSQL = "SELECT * FROM processes_has_rooms WHERE processes_id=" + processesAdapter.GetValue("id");
                var RoomsResult = DBConnection.Instance.Query(RoomsSQL);

                var PersonRole =
                    "SELECT persons.id as persons_id, exhibitors_id, name, password, phone, mail, type FROM persons, exhibitors" +
                    " WHERE persons_id=persons.id exhibitors.id=" + processesAdapter.GetValue("exhibitors_id");
                var PersonResult = DBConnection.Instance.Query(PersonRole);
                var Employee = (Employee)FactoryCreator.Instance.CreateFactory(FactoryCreator.PersonFactory).ImportData(PersonFactory.employee, PersonResult[0]);

                var ScheduleSQL = "SELECT * FROM schedules WHERE id=" + processesAdapter.GetValue("schedule_id");
                var ScheduleResult = DBConnection.Instance.Query(ScheduleSQL);
                var Schedule = new Schedule(ScheduleResult[0]);

                List<Room> Rooms = new List<Room>();

                foreach (var room in RoomsResult)
                {
                    var newRoom = new Room(room);
                    Rooms.Add(newRoom);
                }
                var newProcesses = new Process((Exhibitor)dashboardControl.Person, Employee, Schedule, Rooms);
                processes.Add(newProcesses);
            }
            return processes;
        }
    }
}
