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

        public Label MailExists { get; set; }

        private string UserName => userName.Text;

        private string UserMail => userMail.Text;

        private string UserPhone => userPhone.Text;

        private string UserPassword => userPassword.Text;

        private string TypeExhibitor => typeBox.Text;

        private void BackButton_Click(object sender, EventArgs e)
        {
            if (ParentForm != null)
            {
                var index = ParentForm.Controls.IndexOfKey(AppForms.InitialControl);
                ParentForm.Controls[index].BringToFront();
            }
        }

        private void ForgotPasswordClick(object sender, EventArgs e)
        {
            if (ParentForm != null)
            {
                var index = ParentForm.Controls.IndexOfKey(AppForms.ForgotPasswordControl);
                ParentForm.Controls[index].BringToFront();
            }
        }


        private void CreateAccount_Click(object sender, EventArgs e)
        {
            var fillParameters = true;


            if (UserName.Trim().Equals(""))
            {
                nameRequired.Visible = true;
                fillParameters = false;
            }
            else
            {
                nameRequired.Visible = false;
            }

            if (UserPassword.Trim().Equals(""))
            {
                passwordRequired.Visible = true;
                fillParameters = false;
            }
            else
            {
                passwordRequired.Visible = false;
            }

            if (UserMail.Trim().Equals(""))
            {
                emailRequired.Visible = true;
                fillParameters = false;
            }
            else
            {
                emailRequired.Visible = false;
            }

            if (UserPhone.Trim().Equals(""))
            {
                phoneRequired.Visible = true;
                fillParameters = false;
            }
            else
            {
                phoneRequired.Visible = false;
            }

            if (TypeExhibitor.Trim().Equals(""))
            {
                typeRequired.Visible = true;
                fillParameters = false;
            }
            else
            {
                typeRequired.Visible = false;
            }

            if (!UserMail.Equals(""))
            {
                try
                {
                    var mailAddress = new MailAddress(UserMail);
                }
                catch (FormatException)
                {
                    fillParameters = false;
                }


                if (fillParameters)
                {
                    var factoryUsers = FactoryCreator.Instance.CreateFactory(FactoryCreator.PersonFactory);
                    var user = (Exhibitor) factoryUsers.Create(PersonFactory.Exhibitor);
                    var role = nameof(Exhibitor);
                    var dictionary = new Dictionary<string, string>
                    {
                        {Person.MailProperty, UserMail},
                        {Person.NameProperty, UserName},
                        {Person.PhoneProperty, UserPhone},
                        {Person.PasswordProperty, UserPassword},
                        {Exhibitor.TypeProperty, TypeExhibitor}
                    };


                    if (user.CreateAccountMethod(dictionary))
                    {
                        Console.WriteLine(@"Falta preencher coisas!!!!");
                        if (ParentForm != null)
                        {
                            var index = ParentForm.Controls.IndexOfKey(AppForms.DashboardControl);
                            var dashboardControl = (DashboardControl) ParentForm.Controls[index];
                            dashboardControl.Person = user;
                            dashboardControl.Role = role;

                            index = ParentForm.Controls.IndexOfKey(AppForms.ExhibitionsControl);
                            var exhibitionsControl = (ExhibitionsControl) ParentForm.Controls[index];
                            exhibitionsControl.UpdateExhibitions();
                            dashboardControl.UpdatePerUser();
                            dashboardControl.ChangeUser();
                            dashboardControl.BringToFront();
                        }
                    }
                    else
                    {
                        Console.WriteLine(@"Falta preencher coisas!!!!");
                        var myTimer = new Timer { Interval = 1000 };
                        myTimer.Tick += ShowAndHideUsedEmail;
                        myTimer.Start();
                        UsedEmail.Visible = true;
                    }
                }
                else
                {
                    Console.WriteLine(@"Falta preencher coisas!!!!");
                }
            }
        }

        private void ShowAndHideUsedEmail(object sender, EventArgs e)
        {
            UsedEmail.Visible = false;
            var timer = (Timer)sender;
            timer.Enabled = false;
        }
    }
}