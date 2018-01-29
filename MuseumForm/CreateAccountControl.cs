using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Windows.Forms;
using Museum;

namespace MuseumForm
{
    public partial class CreateAccountControl : UserControl
    {
        public CreateAccountControl()
        {
            InitializeComponent();
        }

        private string UserName => userName.Text;

        private string UserMail => userMail.Text;

        private string UserPhone => userPhone.Text;

        private string UserPassword => userPassword.Text;

        private void BackButton_Click(object sender, EventArgs e)
        {
            var index = ParentForm.Controls.IndexOfKey(AppForms.Initial_Control);
            ParentForm.Controls[index].BringToFront();
        }

        private void ForgotPasswordClick(object sender, EventArgs e)
        {
            var index = ParentForm.Controls.IndexOfKey(AppForms.ForgotPassword_Control);
            ParentForm.Controls[index].BringToFront();
        }


        private void CreateAccount_Click(object sender, EventArgs e)
        {
            var fillParameters = true;


            if (UserName.Equals(""))
            {
                nameRequired.Visible = true;
                fillParameters = false;
            }
            else
            {
                nameRequired.Visible = false;
            }

            if (UserPassword.Equals(""))
            {
                passwordRequired.Visible = true;
                fillParameters = false;
            }
            else
            {
                passwordRequired.Visible = false;
            }

            if (UserMail.Equals(""))
            {
                emailRequired.Visible = true;
                fillParameters = false;
            }
            else
            {
                emailRequired.Visible = false;
            }

            if (UserPhone.Equals(""))
            {
                phoneRequired.Visible = true;
                fillParameters = false;
            }
            else
            {
                phoneRequired.Visible = false;
            }

            if (!radioEmployee.Checked && !radioExhibitor.Checked)
            {
                fillParameters = false;
                roleRequired.Visible = true;
            }
            else
            {
                roleRequired.Visible = false;
            }

            if (!UserMail.Equals(""))
            {
                try
                {
                    var mail = new MailAddress(UserMail);
                }
                catch (FormatException)
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
                        user = (Exhibitor) FactoryUsers.Create(PersonFactory.exhibitor);
                        role = nameof(Exhibitor);
                    }
                    else
                    {
                        user = (Employee) FactoryUsers.Create(PersonFactory.employee);
                        role = nameof(Employee);
                    }

                    var dictionary = new Dictionary<string, string>();

                    dictionary.Add(Person.MailProperty, UserMail);
                    dictionary.Add(Person.NameProperty, UserName);
                    dictionary.Add(Person.PhoneProperty, UserPhone);
                    dictionary.Add(Person.PasswordProperty, UserPassword);

                    if (user.CreateAccountMethod(dictionary))
                    {
                        Console.WriteLine("Correu tudo bem");
                        var index = ParentForm.Controls.IndexOfKey(AppForms.Dashboard_Control);
                        var dashboardControl = (DashboardControl) ParentForm.Controls[index];
                        dashboardControl.Person = user;
                        dashboardControl.Role = role;
                        index = ParentForm.Controls.IndexOfKey(AppForms.Exhibitions_Control);
                        var exhibitionsControl = (ExhibitionsControl) ParentForm.Controls[index];
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

        private void label3_Click(object sender, EventArgs e)
        {
        }
    }
}