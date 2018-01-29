using System;
using System.Windows.Forms;
using Museum;

namespace MuseumForm
{
    public partial class LoginControl : UserControl
    {
        public LoginControl()
        {
            InitializeComponent();
            form = ParentForm;
        }

        private string Email => emailTextBox.Text;

        private Form form { get; }

        private string Password => passwordTextBox.Text;

        private void Login_Click(object sender, EventArgs e)
        {
            if (Email.Equals("admin@admin") && Password.Equals("admin"))
            {
                var index = ParentForm.Controls.IndexOfKey(AppForms.Dashboard_Control);
                var dashboardControl = (DashboardControl) ParentForm.Controls[index];
                dashboardControl.Role = "Admin";
                dashboardControl.ChangeUser();
                dashboardControl.UpdatePerUser();
                dashboardControl.BringToFront();
            }

            if (Email == "")
                emailRequired.Visible = true;
            else
                emailRequired.Visible = false;
            if (Password == "")
                passwordRequired.Visible = true;
            else
                passwordRequired.Visible = false;
            if (Email != "" && Password != "")
            {
                var person = Person.Login(Email, Password);
                if (person != null)
                {
                    Console.WriteLine(person.GetType());
                    var role = "";
                    if (person.GetType().ToString().Equals("Museum.Employee"))
                        role = nameof(Employee);
                    else
                        role = nameof(Exhibitor);

                    var index = ParentForm.Controls.IndexOfKey(AppForms.Dashboard_Control);
                    var dashboardControl = (DashboardControl) ParentForm.Controls[index];
                    dashboardControl.Person = person;
                    dashboardControl.Role = role;
                    dashboardControl.ChangeUser();
                    dashboardControl.UpdatePerUser();
                    index = ParentForm.Controls.IndexOfKey(AppForms.Exhibitions_Control);
                    var exhibitionsControl = (ExhibitionsControl) ParentForm.Controls[index];
                    exhibitionsControl.UpdateExhibitions();
                    dashboardControl.BringToFront();
                    exhibitionsControl.BringToFront();
                }
                else
                {
                    CredentialsLabel.Visible = true;
                }
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            var index = ParentForm.Controls.IndexOfKey(AppForms.Initial_Control);
            ParentForm.Controls[index].BringToFront();
        }


        public void ResetView() // reset da view e trás para a frente (põe os campos em branco)
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
            var index = ParentForm.Controls.IndexOfKey(AppForms.ForgotPassword_Control);
            ParentForm.Controls[index].BringToFront();
        }
    }
}