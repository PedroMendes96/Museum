using System;
using System.Drawing;
using System.Windows.Forms;
using Museum;

namespace MuseumForm
{
    public partial class DashboardControl : UserControl
    {
        public DashboardControl()
        {
            InitializeComponent();
        }

        private Person person { get; set; }
        private string role { get; set; }

        public Person Person
        {
            get => person;
            set => person = value;
        }

        public string Role
        {
            get => role;
            set => role = value;
        }

        public void ChangeUser()
        {
            if (Role == "Admin")
                UserName.Text = "Admnistrator";
            else
                UserName.Text = Person.Name;
        }

        private void LogOut_Click(object sender, EventArgs e)
        {
            Role = "";
            Person = null;
            var ind = ParentForm.Controls.IndexOfKey(AppForms.newMessage_Control);
            var newMessagesControl = (newMessageControl) ParentForm.Controls[ind];
            newMessagesControl
                .ResetCBoxItems(); //esvazia a lista com os destinatarios (pois esta altera com os diferentes tipos de utilizador)
            var index = ParentForm.Controls.IndexOfKey(AppForms.Initial_Control);
            ParentForm.Controls[index].BringToFront();
        }

        public void UpdatePerUser()
        {
            var height = OptionsPanel.Size.Height;
            var width = OptionsPanel.Size.Width;
            if (Role.Equals("Admin"))
            {
                var pie = height / 2;

                var employees = new Button();
                employees.BackColor = Color.BurlyWood;
                employees.Dock = DockStyle.Top;
                employees.Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
                employees.Location = new Point(0, 0);
                employees.Name = "employees";
                employees.Size = new Size(width, pie);
                employees.TabIndex = 0;
                employees.Text = "employees";
                employees.UseVisualStyleBackColor = false;
                employees.Click += employees_Click;
                employees.MouseEnter += HoverOption;
                employees.MouseLeave += LeaveOption;
                employees.MouseHover += HoverOption;

                var rooms = new Button();
                rooms.BackColor = Color.BurlyWood;
                rooms.Dock = DockStyle.Top;
                rooms.Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
                rooms.Location = new Point(0, 0);
                rooms.Name = "rooms";
                rooms.Size = new Size(width, pie);
                rooms.TabIndex = 0;
                rooms.Text = "rooms";
                rooms.UseVisualStyleBackColor = false;
                rooms.Click += rooms_Click;
                rooms.MouseEnter += HoverOption;
                rooms.MouseLeave += LeaveOption;
                rooms.MouseHover += HoverOption;

                OptionsPanel.Controls.Add(rooms);
                OptionsPanel.Controls.Add(employees);
            }
            else
            {
                var pie = height / 4;
                var message = new Button();
                message.BackColor = Color.BurlyWood;
                message.Dock = DockStyle.Top;
                message.Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
                message.Location = new Point(0, 0);
                message.Name = "message";
                message.Size = new Size(width, pie);
                message.TabIndex = 0;
                message.Text = "Messages";
                message.UseVisualStyleBackColor = false;
                message.Click += Messages_Click;
                message.MouseEnter += HoverOption;
                message.MouseLeave += LeaveOption;
                message.MouseHover += HoverOption;

                var processes = new Button();
                processes.BackColor = Color.BurlyWood;
                processes.Dock = DockStyle.Top;
                processes.Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
                processes.Location = new Point(0, 1 * pie);
                processes.Name = "processes";
                processes.Size = new Size(width, pie);
                processes.TabIndex = 1;
                processes.Text = "Processes";
                processes.UseVisualStyleBackColor = false;
                processes.Click += Processes_Click;
                processes.MouseEnter += HoverOption;
                processes.MouseLeave += LeaveOption;
                processes.MouseHover += HoverOption;

                var schedule = new Button();
                schedule.BackColor = Color.BurlyWood;
                schedule.Dock = DockStyle.Top;
                schedule.Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
                schedule.Location = new Point(0, 2 * pie);
                schedule.Name = "schedule";
                schedule.Size = new Size(width, pie);
                schedule.TabIndex = 2;
                schedule.Text = "Schedule";
                schedule.UseVisualStyleBackColor = false;
                schedule.Click += Schedule_Click;
                schedule.MouseEnter += HoverOption;
                schedule.MouseLeave += LeaveOption;
                schedule.MouseHover += HoverOption;

                var settings = new Button();
                settings.BackColor = Color.BurlyWood;
                settings.Dock = DockStyle.Top;
                settings.Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
                settings.Location = new Point(0, 3 * pie);
                settings.Name = "settings";
                settings.Size = new Size(width, pie);
                settings.TabIndex = 3;
                settings.Text = "Settings";
                settings.UseVisualStyleBackColor = false;
                settings.Click += Settings_Click;
                settings.MouseEnter += HoverOption;
                settings.MouseLeave += LeaveOption;
                settings.MouseHover += HoverOption;

                OptionsPanel.Controls.Add(settings);
                OptionsPanel.Controls.Add(schedule);
                OptionsPanel.Controls.Add(processes);
                OptionsPanel.Controls.Add(message);
            }
        }

        private void rooms_Click(object sender, EventArgs e)
        {
            var index = ParentForm.Controls.IndexOfKey(AppForms.AddRoomControl);
            var addRoom = (AddRoom)ParentForm.Controls[index];
            addRoom.BringToFront();
        }

        private void employees_Click(object sender, EventArgs e)
        {
            var index = ParentForm.Controls.IndexOfKey(AppForms.Employees_Control);
            var employeesControl = (EmployeesControl) ParentForm.Controls[index];
            employeesControl.BringToFront();
            employeesControl.getEmployees();
        }

        private void Messages_Click(object sender, EventArgs e)
        {
            var index = ParentForm.Controls.IndexOfKey(AppForms.Messages_Control);
            var messagesControl = (MessagesControl) ParentForm.Controls[index];
            messagesControl.Person = Person;
            messagesControl.Role = Role;
            messagesControl.ResetView();
        }

        private void Processes_Click(object sender, EventArgs e)
        {
            if (Role.Equals(nameof(Employee)))
            {
                var index = ParentForm.Controls.IndexOfKey(AppForms.ProcessesEmployee_Control);
                var control = (ProcessesEmployeeControl) ParentForm.Controls[index];
                control.ResetProcesses();
                control.ActualPage = 1;
                control.ListProcesses(control.ActualPage);
                control.BringToFront();
            }
            else
            {
                var index = ParentForm.Controls.IndexOfKey(AppForms.ProcessesExhibitorControl);
                var control = (ProcessesExhibitorControl) ParentForm.Controls[index];
                control.ResetProcesses();
                control.ActualPage = 1;
                control.ListProcesses(control.ActualPage);
                control.BringToFront();
            }
        }

        private void Schedule_Click(object sender, EventArgs e)
        {
            var index = ParentForm.Controls.IndexOfKey(AppForms.Schedule_Control);
            var scheduleControl = (ScheduleControl) ParentForm.Controls[index];
            scheduleControl.addRooms();
            scheduleControl.BringToFront();
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            var index = ParentForm.Controls.IndexOfKey(AppForms.Settings_Control);
            ParentForm.Controls[index].BringToFront();
        }

        private void HoverOption(object sender, EventArgs e)
        {
            var button = (Button) sender;
            button.BackColor = Color.Coral;
            Cursor.Current = Cursors.Hand;
        }

        private void LeaveOption(object sender, EventArgs e)
        {
            var button = (Button) sender;
            button.BackColor = Color.BurlyWood;
            Cursor.Current = Cursors.Default;
        }
    }
}