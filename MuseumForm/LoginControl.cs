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
                    var appForms = (AppForms)ParentForm;
                    var dashboardControl = appForms.DashboardControl;
                    dashboardControl.Role = "Admin";
                    dashboardControl.ChangeUser();
                    dashboardControl.UpdatePerUser();
                    dashboardControl.BringToFront();

                    var exhibitionsControl = appForms.ExhibitionsControl;
                    exhibitionsControl.UpdateExhibitions();
                    exhibitionsControl.BringToFront();
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
                        var appForms = (AppForms)ParentForm;
                        var dashboardControl = appForms.DashboardControl;
                        dashboardControl.Person = person;
                        dashboardControl.Role = role;
                        dashboardControl.ChangeUser();
                        dashboardControl.UpdatePerUser();
                        var exhibitionsControl = appForms.ExhibitionsControl;
                        exhibitionsControl.UpdateExhibitions();
                        dashboardControl.BringToFront();
                        exhibitionsControl.BringToFront();
                    }
                }
                else
                {
                    CredentialsLabel.Visible = true;
                    var myTimer = new Timer { Interval = 3000 };
                    myTimer.Tick += HideFail;
                    myTimer.Start();
                }
            }
        }

        private void HideFail(object sender, EventArgs e)
        {
            CredentialsLabel.Visible = false;
            var timer = (Timer)sender;
            timer.Enabled = false;
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            if (ParentForm != null)
            {
                var appForms = (AppForms)ParentForm;
                appForms.InitialControl.BringToFront();
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
                var appForms = (AppForms)ParentForm;
                appForms.ForgotPasswordControl.BringToFront();
            }
        }
    }
}