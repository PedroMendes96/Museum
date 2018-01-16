using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Museum;

namespace MuseumForm
{
    public partial class LoginControl : UserControl
    {
        private string Email => emailTextBox.Text;

        private Form form
        {
            get;
        }

        private string Password => passwordTextBox.Text;

        public LoginControl()
        {
            InitializeComponent();
            form = ParentForm;
        }

        private void Login_Click(object sender, EventArgs e)
        {
            var person = Person.Login(Email,Password);
            if (person != null)
            {
                Console.WriteLine(person.GetType());
                string role = "";
                if (person.GetType().ToString().Equals("Museum.Employees"))
                {
                    role = nameof(Employee);
                }
                else
                {
                    role = nameof(Exhibitor);
                }

                var index = this.ParentForm.Controls.IndexOfKey(AppForms.Dashboard_Control);
                DashboardControl dashboardControl = (DashboardControl)this.ParentForm.Controls[index];
                dashboardControl.Person = person;
                dashboardControl.Role = role;
                dashboardControl.ChangeUser();
                dashboardControl.BringToFront();
            }
            else
            {
                Console.WriteLine("Nao existe esse utilizador");
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            var index = this.ParentForm.Controls.IndexOfKey(AppForms.Initial_Control);
            this.ParentForm.Controls[index].BringToFront();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
