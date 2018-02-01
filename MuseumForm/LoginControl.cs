using System;
using System.Windows.Forms;
using Museum;

namespace MuseumForm
{
    public partial class LoginControl : UserControl
    {
        private const string UserAdmin = "admin@admin";
        private const string PasswordAdmin = "admin";

        public LoginControl()
        {
            InitializeComponent();
        }

        private string Email => emailTextBox.Text;

        private string Password => passwordTextBox.Text;

        private void Login_Click(object sender, EventArgs e)
        {
            if (Email.Equals(UserAdmin) && Password.Equals(PasswordAdmin))
            {
                if (ParentForm != null)
                {
                    var index = ParentForm.Controls.IndexOfKey(AppForms.DashboardControl);
                    var dashboardControl = (DashboardControl) ParentForm.Controls[index];
                    dashboardControl.Role = "Admin";
                    dashboardControl.ChangeUser();
                    dashboardControl.UpdatePerUser();
                    dashboardControl.BringToFront();
                }
            }

            emailRequired.Visible = Email == "";
            passwordRequired.Visible = Password == "";
            if (Email == "" || Password == "") return;
            {
                var person = Person.Login(Email, Password);
                if (person != null)
                {
                    Console.WriteLine(person.GetType());
                    var role = person.GetType().ToString().Equals("Museum.Employee") ? nameof(Employee) : nameof(Exhibitor);

                    if (ParentForm != null)
                    {
                        var index = ParentForm.Controls.IndexOfKey(AppForms.DashboardControl);
                        var dashboardControl = (DashboardControl) ParentForm.Controls[index];
                        dashboardControl.Person = person;
                        dashboardControl.Role = role;
                        dashboardControl.ChangeUser();
                        dashboardControl.UpdatePerUser();
                        index = ParentForm.Controls.IndexOfKey(AppForms.ExhibitionsControl);
                        var exhibitionsControl = (ExhibitionsControl) ParentForm.Controls[index];
                        exhibitionsControl.UpdateExhibitions();
                        dashboardControl.BringToFront();
                        exhibitionsControl.BringToFront();
                    }
                }
                else
                {
                    CredentialsLabel.Visible = true;
                }
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            if (ParentForm != null)
            {
                var index = ParentForm.Controls.IndexOfKey(AppForms.InitialControl);
                ParentForm.Controls[index].BringToFront();
            }
        }


        public void ResetView()
        {
            CredentialsLabel.Visible = false;
            emailTextBox.Text = "";
            passwordTextBox.Text = "";
            BringToFront();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void label7_Click(object sender, EventArgs e)
        {
            if (ParentForm != null)
            {
                var index = ParentForm.Controls.IndexOfKey(AppForms.ForgotPasswordControl);
                ParentForm.Controls[index].BringToFront();
            }
        }
    }
}