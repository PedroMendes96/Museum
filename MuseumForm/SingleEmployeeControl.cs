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
    public partial class SingleEmployeeControl : UserControl
    {
        private Employee employee;

        public Employee Employee
        {
            get => employee;
            set => employee = value;
        }

        public SingleEmployeeControl()
        {
            InitializeComponent();
        }

        private void headTitle_Click(object sender, EventArgs e)
        {

        }

        public void ResetView()
        {
            headTitle.Text = "Employee: " + Employee.Name;
            NameText.Text = Employee.Name;
            MailText.Text = Employee.Mail;
            LastUpdateLabel.Text = "Last Updated: "+Employee.LastUpdateSalary;
            PhoneText.Text = Employee.Phone.ToString();
            salaryBox.Text = Employee.Salary.ToString();
            BringToFront();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            var index = ParentForm.Controls.IndexOfKey(AppForms.Employees_Control);
            var employeesControl = (EmployeesControl)ParentForm.Controls[index];
            employeesControl.ResetView();
        }

        private void editButton_Click(object sender, EventArgs e)
        {

            //VERIFICAR TIPO DO SALARIO!!!!
            if (Employee.Salary == double.Parse(salaryBox.Text))
            {
                // não atualiza pois os dados guardados são os mesmos
            }
            else
            {
                Employee.Salary = double.Parse(salaryBox.Text);
                string query = "UPDATE employees SET salary =" + Employee.Salary + " WHERE employees.id = " +
                               Employee.IdEmployee;
                Debug.WriteLine(query);
                var db = DBConnection.Instance;
                db.Execute(query);
            }

            var index = ParentForm.Controls.IndexOfKey(AppForms.Employees_Control);
            var employeesControl = (EmployeesControl)ParentForm.Controls[index];
            employeesControl.ResetView();

        }
    }
}
