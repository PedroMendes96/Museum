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

        }

        private void Processes_Click(object sender, EventArgs e)
        {

        }

        private void Schedule_Click(object sender, EventArgs e)
        {
            var index = this.ParentForm.Controls.IndexOfKey(AppForms.Schedule_Control);
            this.ParentForm.Controls[index].BringToFront();
        }

        private void Settings_Click(object sender, EventArgs e)
        {

        }
    }
}
