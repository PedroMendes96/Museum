using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Forms;
using Museum;

namespace MuseumForm
{
    public partial class SingleEmployeeControl : UserControl
    {
        public Employee Employee { get; set; }

        public SingleEmployeeControl()
        {
            InitializeComponent();
        }

        private void headTitle_Click(object sender, EventArgs e)
        {

        }

        public void ResetView()
        {
            salaryIncorrect.Visible = false;
            headTitle.Text = @"Employee: " + Employee.Name;
            NameText.Text = Employee.Name;
            MailText.Text = Employee.Mail;
            LastUpdateLabel.Text = @"Last Updated: "+Employee.LastUpdateSalary;
            PhoneText.Text = Employee.Phone.ToString();
            salaryBox.Text = Employee.Salary.ToString(CultureInfo.CurrentCulture);
            BringToFront();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            if (ParentForm != null)
            {
                var appForms = (MadeiraMuseum)ParentForm;
                var employeesControl = appForms.EmployeesControl;
                employeesControl.ResetView();
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
           

            {
                try
                {
                    var salaryUpdated = false;
                    if (Employee.Salary == double.Parse(salaryBox.Text))
                    {
                        // não atualiza pois os dados guardados são os mesmos

                    }
                    else
                    {                     
                        Employee.Salary = double.Parse(salaryBox.Text);
                        Employee.Update(Employee.SalaryProperty,
                        Employee.Salary.ToString(CultureInfo.CurrentCulture), "employees");
                        salaryUpdated = true;           
                    }

                    if (ParentForm != null)
                    {
                        var appForms = (MadeiraMuseum)ParentForm;
                        var employeesControl = appForms.EmployeesControl;
                        employeesControl.ResetView();
                        if (!salaryUpdated) return;
                        employeesControl.NotificationLabel.Text = @"Employee salary edited with success!";
                        employeesControl.ShowNotification();
                    }
                }
                catch (Exception)
                {
                    salaryIncorrect.Visible = true;
                    var myTimer = new Timer { Interval = 3000 };
                    myTimer.Tick += HideFail;
                    myTimer.Start();
                    Debug.WriteLine("O SALARIO NAO E UM DOUBLE");
                }
            }
        }

        private void HideFail(object sender, EventArgs e)
        {
            salaryIncorrect.Visible = false;
            var timer = (Timer)sender;
            timer.Enabled = false;
        }
    }
}
