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
            UserName.Text = Person.Name;
        }

        //private void button1_Click(object sender, EventArgs e)
        //{

        //}

        private void LogOut_Click(object sender, EventArgs e)
        {
            Role = "";
            Person = null;

            var index = this.ParentForm.Controls.IndexOfKey(AppForms.Initial_Control);
            this.ParentForm.Controls[index].BringToFront();
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
            messagesControl.ResetView();
        }

        private void Processes_Click(object sender, EventArgs e)
        {
            if (Role.Equals(nameof(Employee)))
            {
                var index = this.ParentForm.Controls.IndexOfKey(AppForms.ProcessesEmployee_Control);
                var control = (ProcessesEmployeeControl)this.ParentForm.Controls[index];
                control.ResetProcesses();
                control.ListProcesses(control.ActualPage);
                control.BringToFront();
            }
            else
            {
                var index = this.ParentForm.Controls.IndexOfKey(AppForms.ProcessesExhibitorControl);
                var control = (ProcessesExhibitorControl)this.ParentForm.Controls[index];
                control.ResetProcesses();
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
