using System;
using System.Drawing;
using System.Windows.Forms;
using Museum;

namespace MuseumForm
{
    public partial class DashboardControl : UserControl
    {
        private const string AdminRole = "Admin";
        private const string AdminName = "Admnistrator";

        public DashboardControl()
        {
            InitializeComponent();
            HomeButton.Cursor = Cursors.Hand;
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
            UserName.Text = Role == AdminRole ? AdminName : Person.Name;
        }

        private void LogOut_Click(object sender, EventArgs e)
        {
            Role = "";
            Person = null;
            if (ParentForm != null)
            {
                var appForms = (MadeiraMuseum)ParentForm;
                var newMessagesControl = appForms.NewMessageControl;
                newMessagesControl
                    .ResetCBoxItems(); //esvazia a lista com os destinatarios (pois esta altera com os diferentes tipos de utilizador)
                appForms.InitialControl.BringToFront();
            }
        }

        public void UpdatePerUser()
        {
            var height = OptionsPanel.Size.Height;
            var width = OptionsPanel.Size.Width;
            if (Role.Equals("Admin"))
            {
                var pie = height / 3;

                var employees = new Button
                {
                    BackColor = Color.BurlyWood,
                    Dock = DockStyle.Top,
                    Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Bold, GraphicsUnit.Point, 0),
                    Location = new Point(0, 0),
                    Name = "employees",
                    Size = new Size(width, pie),
                    TabIndex = 0,
                    Text = @"Employees",
                    UseVisualStyleBackColor = false,
                };
                employees.Cursor = Cursors.Hand;
                employees.Click += employees_Click;
                employees.MouseEnter += HoverOption;
                employees.MouseLeave += LeaveOption;
                employees.MouseHover += HoverOption;

                var rooms = new Button
                {
                    BackColor = Color.BurlyWood,
                    Dock = DockStyle.Top,
                    Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Bold, GraphicsUnit.Point, 0),
                    Location = new Point(0, 0),
                    Name = "rooms",
                    Size = new Size(width, pie),
                    TabIndex = 0,
                    Text = @"Rooms",
                    UseVisualStyleBackColor = false
                };
                rooms.Click += rooms_Click;
                rooms.MouseEnter += HoverOption;
                rooms.MouseLeave += LeaveOption;
                rooms.MouseHover += HoverOption;
                rooms.Cursor = Cursors.Hand;

                var exhibitions = new Button
                {
                    BackColor = Color.BurlyWood,
                    Dock = DockStyle.Top,
                    Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Bold, GraphicsUnit.Point, 0),
                    Location = new Point(0, 0),
                    Name = "exhibitions",
                    Size = new Size(width, pie),
                    TabIndex = 0,
                    Text = @"Exhibitions",
                    UseVisualStyleBackColor = false
                };
                exhibitions.Click += Exhibitions_Click;
                exhibitions.MouseEnter += HoverOption;
                exhibitions.MouseLeave += LeaveOption;
                exhibitions.MouseHover += HoverOption;
                exhibitions.Cursor = Cursors.Hand;

                OptionsPanel.Controls.Add(rooms);
                OptionsPanel.Controls.Add(employees);
                OptionsPanel.Controls.Add(exhibitions);
            }
            else
            {
                var pie = height / 4;
                var message = new Button
                {
                    BackColor = Color.BurlyWood,
                    Dock = DockStyle.Top,
                    Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Bold, GraphicsUnit.Point, 0),
                    Location = new Point(0, 0),
                    Name = "message",
                    Size = new Size(width, pie),
                    TabIndex = 0,
                    Text = @"Messages",
                    UseVisualStyleBackColor = false
                };
                message.Click += Messages_Click;
                message.MouseEnter += HoverOption;
                message.MouseLeave += LeaveOption;
                message.MouseHover += HoverOption;
                message.Cursor = Cursors.Hand;

                var processes = new Button
                {
                    BackColor = Color.BurlyWood,
                    Dock = DockStyle.Top,
                    Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Bold, GraphicsUnit.Point, 0),
                    Location = new Point(0, 1 * pie),
                    Name = "processes",
                    Size = new Size(width, pie),
                    TabIndex = 1,
                    Text = @"Processes",
                    UseVisualStyleBackColor = false
                };
                processes.Click += Processes_Click;
                processes.MouseEnter += HoverOption;
                processes.MouseLeave += LeaveOption;
                processes.MouseHover += HoverOption;
                processes.Cursor = Cursors.Hand;

                var schedule = new Button
                {
                    BackColor = Color.BurlyWood,
                    Dock = DockStyle.Top,
                    Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Bold, GraphicsUnit.Point, 0),
                    Location = new Point(0, 2 * pie),
                    Name = "schedule",
                    Size = new Size(width, pie),
                    TabIndex = 2,
                    Text = @"Schedule",
                    UseVisualStyleBackColor = false
                };
                schedule.Click += Schedule_Click;
                schedule.MouseEnter += HoverOption;
                schedule.MouseLeave += LeaveOption;
                schedule.MouseHover += HoverOption;
                schedule.Cursor = Cursors.Hand;

                var settings = new Button
                {
                    BackColor = Color.BurlyWood,
                    Dock = DockStyle.Top,
                    Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Bold, GraphicsUnit.Point, 0),
                    Location = new Point(0, 3 * pie),
                    Name = "settings",
                    Size = new Size(width, pie),
                    TabIndex = 3,
                    Text = @"Settings",
                    UseVisualStyleBackColor = false
                };
                settings.Click += Settings_Click;
                settings.MouseEnter += HoverOption;
                settings.MouseLeave += LeaveOption;
                settings.MouseHover += HoverOption;
                settings.Cursor = Cursors.Hand;

                OptionsPanel.Controls.Add(settings);
                OptionsPanel.Controls.Add(schedule);
                OptionsPanel.Controls.Add(processes);
                OptionsPanel.Controls.Add(message);
            }
        }

        private void rooms_Click(object sender, EventArgs e)
        {
            if (ParentForm != null)
            {
                var appForms = (MadeiraMuseum)ParentForm;
                var addRoom = appForms.AddRoomControl;
                addRoom.BringToFront();
            }
        }

        private void employees_Click(object sender, EventArgs e)
        {
            if (ParentForm != null)
            {
                var appForms = (MadeiraMuseum)ParentForm;
                var employeesControl = appForms.EmployeesControl;
                employeesControl.ResetView();
            }
        }

        private void Exhibitions_Click(object sender, EventArgs e)
        {
            if (ParentForm != null)
            {
                var appForms = (MadeiraMuseum)ParentForm;
                var addPermanentControl = appForms.AddPermanentControl;
                addPermanentControl.ListRooms();
                addPermanentControl.BringToFront();
            }
        }

        private void Messages_Click(object sender, EventArgs e)
        {
            if (ParentForm != null)
            {
                var appForms = (MadeiraMuseum)ParentForm;
                var messagesControl = appForms.MessagesControl;
                messagesControl.Person = Person;
                messagesControl.Role = Role;
                messagesControl.ResetView();
            }
        }

        private void Processes_Click(object sender, EventArgs e)
        {
            var appForms = (MadeiraMuseum)ParentForm;
            if (Role.Equals(nameof(Employee)))
            {
                if (ParentForm != null)
                {
                    var control = appForms.ProcessesEmployeeControl;
                    control.ResetProcesses();
                    control.ActualPage = 1;
                    control.ListProcesses(control.ActualPage);
                    control.BringToFront();
                }
            }
            else
            {
                if (ParentForm != null)
                { 
                    var control = appForms.ProcessesExhibitorControl;
                    control.ResetProcesses();
                    control.ActualPage = 1;
                    control.ListProcesses(control.ActualPage);
                    control.BringToFront();
                }
            }
        }

        private void Schedule_Click(object sender, EventArgs e)
        {
            if (ParentForm != null)
            {
                var appForms = (MadeiraMuseum)ParentForm;
                var scheduleControl = appForms.ScheduleControl;
                scheduleControl.AddRooms();
                scheduleControl.ResetExhibitions();
                scheduleControl.BringToFront();
            }
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            if (ParentForm != null)
            {
                var appForms = (MadeiraMuseum)ParentForm;
                var settingsControl = appForms.SettingsControl;
                settingsControl.BringToFront();
            }
        }

        private void HoverOption(object sender, EventArgs e)
        {
            var button = (Button) sender;
            button.BackColor = Color.Coral;
        }

        private void LeaveOption(object sender, EventArgs e)
        {
            var button = (Button) sender;
            button.BackColor = Color.BurlyWood;
        }

        private void HomeButton_Click(object sender, EventArgs e)
        {
            var appForms = (MadeiraMuseum) ParentForm;
            var control = appForms.ExhibitionsControl;
            control.BringToFront();
            control.UpdateExhibitions();
        }
    }
}