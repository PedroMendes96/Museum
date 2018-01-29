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
    public partial class DashboardControl : UserControl
    {
        private Person person { get; set; }
        private String role { get; set; }

        public Person Person
        {
            get => person;
            set => person = value;
        }

        public String Role
        {
            get => role;
            set => role = value;
        }
        public DashboardControl()
        {
            InitializeComponent();
        }

        public void ChangeUser()
        {
            if (Role == "Admin")
            {
                UserName.Text = "Admnistrador";
            }

            UserName.Text = Person.Name;
        }

        //private void button1_Click(object sender, EventArgs e)
        //{

        //}

        private void LogOut_Click(object sender, EventArgs e)
        {
            Role = "";
            Person = null;
            var ind = this.ParentForm.Controls.IndexOfKey(AppForms.newMessage_Control);
            newMessageControl newMessagesControl = (newMessageControl)this.ParentForm.Controls[ind];
            newMessagesControl.ResetCBoxItems(); //esvazia a lista com os destinatarios (pois esta altera com os diferentes tipos de utilizador)
            var index = this.ParentForm.Controls.IndexOfKey(AppForms.Initial_Control);
            this.ParentForm.Controls[index].BringToFront();
        }

        public void UpdatePerUser()
        {
            var height = OptionsPanel.Size.Height;
            var width = OptionsPanel.Size.Width;
            if (Role.Equals("Admin"))
            {
                var pie = height / 2;

                Button employees = new Button();
                employees.BackColor = Color.BurlyWood;
                employees.Dock = DockStyle.Top;
                employees.Font = new Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                employees.Location = new Point(0, 0);
                employees.Name = "employees";
                employees.Size = new Size(width, pie);
                employees.TabIndex = 0;
                employees.Text = "employeess";
                employees.UseVisualStyleBackColor = false;
//                employees.Click += (employeess_Click);
                employees.MouseEnter += (HoverOption);
                employees.MouseLeave += (LeaveOption);
                employees.MouseHover += (HoverOption);

                Button rooms = new Button();
                rooms.BackColor = Color.BurlyWood;
                rooms.Dock = DockStyle.Top;
                rooms.Font = new Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                rooms.Location = new Point(0, 0);
                rooms.Name = "rooms";
                rooms.Size = new Size(width, pie);
                rooms.TabIndex = 0;
                rooms.Text = "roomss";
                rooms.UseVisualStyleBackColor = false;
//                rooms.Click += (rooms_Click);
                rooms.MouseEnter += (HoverOption);
                rooms.MouseLeave += (LeaveOption);
                rooms.MouseHover += (HoverOption);

                OptionsPanel.Controls.Add(rooms);
                OptionsPanel.Controls.Add(employees);
            }
            else
            {
                var pie = height / 4;
                Button message = new Button();
                message.BackColor = Color.BurlyWood;
                message.Dock = DockStyle.Top;
                message.Font = new Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                message.Location = new Point(0, 0);
                message.Name = "message";
                message.Size = new Size(width, pie);
                message.TabIndex = 0;
                message.Text = "Messages";
                message.UseVisualStyleBackColor = false;
                message.Click += (Messages_Click);
                message.MouseEnter += (HoverOption);
                message.MouseLeave += (LeaveOption);
                message.MouseHover += (HoverOption);

                Button processes = new Button();
                processes.BackColor = Color.BurlyWood;
                processes.Dock = DockStyle.Top;
                processes.Font = new Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                processes.Location = new Point(0, 1 * pie);
                processes.Name = "processes";
                processes.Size = new Size(width, pie);
                processes.TabIndex = 1;
                processes.Text = "Processes";
                processes.UseVisualStyleBackColor = false;
                processes.Click += (Processes_Click);
                processes.MouseEnter += (HoverOption);
                processes.MouseLeave += (LeaveOption);
                processes.MouseHover += (HoverOption);

                Button schedule = new Button();
                schedule.BackColor = System.Drawing.Color.BurlyWood;
                schedule.Dock = System.Windows.Forms.DockStyle.Top;
                schedule.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                schedule.Location = new System.Drawing.Point(0, 2 * pie);
                schedule.Name = "schedule";
                schedule.Size = new System.Drawing.Size(width, pie);
                schedule.TabIndex = 2;
                schedule.Text = "Schedule";
                schedule.UseVisualStyleBackColor = false;
                schedule.Click += new System.EventHandler(this.Schedule_Click);
                schedule.MouseEnter += new System.EventHandler(this.HoverOption);
                schedule.MouseLeave += new System.EventHandler(this.LeaveOption);
                schedule.MouseHover += new System.EventHandler(this.HoverOption);

                Button settings = new Button();
                settings.BackColor = System.Drawing.Color.BurlyWood;
                settings.Dock = System.Windows.Forms.DockStyle.Top;
                settings.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                settings.Location = new System.Drawing.Point(0, 3 * pie);
                settings.Name = "settings";
                settings.Size = new System.Drawing.Size(width, pie);
                settings.TabIndex = 3;
                settings.Text = "Settings";
                settings.UseVisualStyleBackColor = false;
                settings.Click += new System.EventHandler(this.Settings_Click);
                settings.MouseEnter += new System.EventHandler(this.HoverOption);
                settings.MouseLeave += new System.EventHandler(this.LeaveOption);
                settings.MouseHover += new System.EventHandler(this.HoverOption);

                OptionsPanel.Controls.Add(settings);
                OptionsPanel.Controls.Add(schedule);
                OptionsPanel.Controls.Add(processes);
                OptionsPanel.Controls.Add(message);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void UserName_Click(object sender, EventArgs e)
        {

        }

        private void Messages_Click(object sender, EventArgs e)
        {
            var index = this.ParentForm.Controls.IndexOfKey(AppForms.Messages_Control);
            MessagesControl messagesControl = (MessagesControl)this.ParentForm.Controls[index];
            messagesControl.Person = Person;
            messagesControl.Role = Role;
            messagesControl.ResetView();
            
        }

        private void Processes_Click(object sender, EventArgs e)
        {
            if (Role.Equals(nameof(Employee)))
            {
                var index = this.ParentForm.Controls.IndexOfKey(AppForms.ProcessesEmployee_Control);
                var control = (ProcessesEmployeeControl)this.ParentForm.Controls[index];
                control.ResetProcesses();
                control.ActualPage = 1;
                control.ListProcesses(control.ActualPage);
                control.BringToFront();
            }
            else
            {
                var index = this.ParentForm.Controls.IndexOfKey(AppForms.ProcessesExhibitorControl);
                var control = (ProcessesExhibitorControl)this.ParentForm.Controls[index];
                control.ResetProcesses();
                control.ActualPage = 1;
                control.ListProcesses(control.ActualPage);
                control.BringToFront();
            }
        }

        private void Schedule_Click(object sender, EventArgs e)
        {
            var index = this.ParentForm.Controls.IndexOfKey(AppForms.Schedule_Control);
            var scheduleControl = (ScheduleControl) this.ParentForm.Controls[index];
            scheduleControl.addRooms();
            scheduleControl.BringToFront();
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            var index = this.ParentForm.Controls.IndexOfKey(AppForms.Settings_Control);
            this.ParentForm.Controls[index].BringToFront();
        }

        private void HoverOption(object sender, EventArgs e)
        {
            Button button = (Button) sender;
            button.BackColor = Color.Coral;
            Cursor.Current = Cursors.Hand;
        }

        private void LeaveOption(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.BackColor = Color.BurlyWood;
            Cursor.Current = Cursors.Default;
        }
    }
}
