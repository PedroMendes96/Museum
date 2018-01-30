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
    public partial class NewEmployeeControl : UserControl
    {
        private string UserName => userName.Text;

        private string UserMail => userMail.Text;

        private string UserPhone => userPhone.Text;

        private string UserPassword => userPassword.Text;

        private string Salary => userSalary.Text;

        public NewEmployeeControl()
        {
            InitializeComponent();
        }

        private void headTitle_Click(object sender, EventArgs e)
        {

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
                if (UserName == "")
                {
                    nameRequired.Visible = true;
                }
                else
                {
                    nameRequired.Visible = false;
                }
                if (UserMail == "")
                {
                    emailRequired.Visible = true;
                }
                else
                {
                    emailRequired.Visible = false;
                }
                if (UserPhone == "")
                {
                    phoneRequired.Visible = true;
                }
                else
                {
                    phoneRequired.Visible = false;
                }
                if (UserPassword == "")
                {
                    passwordRequired.Visible = true;
                }
                else
                {
                    passwordRequired.Visible = false;
                }
                if (Salary == "")
                {
                    userSalary.Text = "0";
                }
            }
            else
            {
                Person employee = null;
                IFactory employeeFactory = FactoryCreator.Instance.CreateFactory(FactoryCreator.PersonFactory);
                employee = (Employee)employeeFactory.Create(PersonFactory.employee);
                var dictionary = new Dictionary<string, string>();

                dictionary.Add(Person.MailProperty, UserMail);
                dictionary.Add(Person.NameProperty, UserName);
                dictionary.Add(Person.PhoneProperty, UserPhone);
                dictionary.Add(Person.PasswordProperty, UserPassword);
                dictionary.Add(Employee.SalaryProperty, Salary);
                if (employee.CreateAccountMethod(dictionary))
                {
                    Debug.WriteLine("employee created");
                    ResetView();
                    var index = ParentForm.Controls.IndexOfKey(AppForms.Employees_Control);
                    var employeesControl = (EmployeesControl) ParentForm.Controls[index];
                    employeesControl.ResetView();
                }
                else
                {
                    MailExists.Visible = true;
                }
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            var index = ParentForm.Controls.IndexOfKey(AppForms.Employees_Control);
            var employeesControl = (EmployeesControl)ParentForm.Controls[index];
            employeesControl.ResetView();
        }

        private void NewEmployeeControl_Load(object sender, EventArgs e)
        {

        }
    }
}
