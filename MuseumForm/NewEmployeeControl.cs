using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using Museum;

namespace MuseumForm
{
    public partial class NewEmployeeControl : UserControl
    {
        private IFactory employeeFactory;
        private string UserName => userName.Text;

        private string UserMail => userMail.Text;

        private string UserPhone => userPhone.Text;

        private string UserPassword => userPassword.Text;

        private string Salary => userSalary.Text;

        public NewEmployeeControl()
        {
            InitializeComponent();
            employeeFactory = FactoryCreator.Instance.CreateFactory(FactoryCreator.PersonFactory);
        }

        public void ResetView()
        {
            BringToFront();
            userName.Text = "";
            userMail.Text = "";
            userPhone.Text = "";
            userPassword.Text = "";
            userSalary.Text = "";
            nameRequired.Visible = false;
            emailRequired.Visible = false;
            phoneRequired.Visible = false;
            passwordRequired.Visible = false;
            SalaryRequired.Visible = false;
            MailExists.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (UserName == "" || UserMail == "" || UserPhone == "" || UserPassword == "")
            {
                nameRequired.Visible = UserName == "";
                emailRequired.Visible = UserMail == "";
                phoneRequired.Visible = UserPhone == "";
                passwordRequired.Visible = UserPassword == "";
              
            }
            else
            {
                if (Salary == "")
                {
                    userSalary.Text = @"0";
                }
                Person employee = (Employee)employeeFactory.Create(PersonFactory.Employee);
                var dictionary = new Dictionary<string, string>
                {
                    {Person.MailProperty, UserMail},
                    {Person.NameProperty, UserName},
                    {Person.PhoneProperty, UserPhone},
                    {Person.PasswordProperty, UserPassword},
                    {Employee.SalaryProperty, Salary}
                };

                if (employee.CreateAccountMethod(dictionary))
                {
                    Debug.WriteLine("employee created");
                    ResetView();
                    if (ParentForm != null)
                    {
                        var index = ParentForm.Controls.IndexOfKey(AppForms.EmployeesControl);
                        var employeesControl = (EmployeesControl) ParentForm.Controls[index];
                        employeesControl.ResetView();
                        employeesControl.NotificationLabel.Text = @"Employee sucessfully added!";
                        employeesControl.ShowNotification();
                    }
                }
                else
                {
                    MailExists.Visible = true;
                    var myTimer = new Timer {Interval = 1000};
                    myTimer.Tick += HideWarning;
                    myTimer.Start();
                }
            }
        }

        private void HideWarning(object sender, EventArgs e)
        {
            MailExists.Visible = false;
            var timer = (Timer)sender;
            timer.Enabled = false;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            if (ParentForm != null)
            {
                var index = ParentForm.Controls.IndexOfKey(AppForms.EmployeesControl);
                var employeesControl = (EmployeesControl)ParentForm.Controls[index];
                employeesControl.ResetView();
            }
        }

        private void NewEmployeeControl_Load(object sender, EventArgs e)
        {

        }
    }
}
