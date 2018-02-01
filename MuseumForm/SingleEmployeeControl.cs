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
                var index = ParentForm.Controls.IndexOfKey(AppForms.EmployeesControl);
                var employeesControl = (EmployeesControl)ParentForm.Controls[index];
                employeesControl.ResetView();
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
           

            {
                try
                {
                    if (Math.Abs(Employee.Salary - double.Parse(salaryBox.Text)) < 0.0)
                    {
                        // não atualiza pois os dados guardados são os mesmos
                    }
                    else
                    {
                        Employee.Salary = double.Parse(salaryBox.Text);
                        Employee.Update(Employee.SalaryProperty,Employee.Salary.ToString(CultureInfo.CurrentCulture),"employees");
                    }

                    if (ParentForm != null)
                    {
                        var index = ParentForm.Controls.IndexOfKey(AppForms.EmployeesControl);
                        var employeesControl = (EmployeesControl)ParentForm.Controls[index];
                        employeesControl.ResetView();
                    }
                }
                catch (Exception)
                {
                    salaryIncorrect.Visible = true;
                    Debug.WriteLine("O SALARIO NAO E UM DOUBLE");
                }
            }
        }
    }
}
