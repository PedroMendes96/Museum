using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Museum;

namespace MuseumForm
{
    public partial class CreateAccountControl : UserControl
    {
        private string UserName
        {
            get { return userName.Text; }
        }

        private string UserMail
        {
            get { return userMail.Text; }
        }

        private string UserPhone
        {
            get { return userPhone.Text; }
        }

        private string UserPassword
        {
            get { return userPassword.Text; }
        }

        public CreateAccountControl()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            var index = this.ParentForm.Controls.IndexOfKey(AppForms.Initial_Control);
            this.ParentForm.Controls[index].BringToFront();
        }

        private void ForgotPasswordClick(object sender, EventArgs e)
        {
            var index = this.ParentForm.Controls.IndexOfKey(AppForms.ForgotPasswprd_Control);
            this.ParentForm.Controls[index].BringToFront();
        }

        private void CreateAccount_Click(object sender, EventArgs e)
        {
            bool fillParameters = true;

            if (UserName.Equals("") || UserPassword.Equals("") || UserMail.Equals("") || UserPhone.Equals(""))
            {
                fillParameters = false;
            }

            try
            {
                MailAddress mail = new MailAddress(UserMail);
            }
            catch (FormatException )
            {
                fillParameters = false;
            }

            if (!radioEmployee.Checked && !radioExhibitor.Checked)
            {
                fillParameters = false;
            }

            if (fillParameters)
            {
                var FactoryUsers = FactoryCreator.Instance.CreateFactory(FactoryCreator.PersonFactory);
                Person user = null;
                string role;
                if (radioExhibitor.Checked)
                {
                    user = (Exhibitor)FactoryUsers.Create(PersonFactory.exhibitor);
                    role = nameof(Exhibitor);
                }
                else
                {
                    user = (Employee)FactoryUsers.Create(PersonFactory.employee);
                    role = nameof(Employee);
                }
                Dictionary<string,string> dictionary = new Dictionary<string, string>();

                dictionary.Add(Person.MailProperty,UserMail);
                dictionary.Add(Person.NameProperty,UserName);
                dictionary.Add(Person.PhoneProperty,UserPhone);
                dictionary.Add(Person.PasswordProperty,UserPassword);

                if (user.CreateAccountMethod(dictionary))
                {
                    Console.WriteLine("Correu tudo bem");
                    var index = this.ParentForm.Controls.IndexOfKey(AppForms.Dashboard_Control);
                    DashboardControl dashboardControl = (DashboardControl)this.ParentForm.Controls[index];
                    dashboardControl.Person = user;
                    dashboardControl.Role = role;
                    index = this.ParentForm.Controls.IndexOfKey(AppForms.Exhibitions_Control);
                    ExhibitionsControl exhibitionsControl = (ExhibitionsControl)this.ParentForm.Controls[index];
                    exhibitionsControl.UpdateExhibitions();
                    dashboardControl.ChangeUser();
                    dashboardControl.BringToFront();
                }
                else
                {
                    Console.WriteLine("Algo falhou");
                }
            }
            else
            {
                Console.WriteLine("Falta preencher coisas!!!!");
            }
        }
    }
}
