using System;
using System.Diagnostics;
using System.Net.Mail;
using System.Windows.Forms;
using Museum;

namespace MuseumForm
{
    public partial class SettingsControl : UserControl
    {
        public SettingsControl()
        {
            InitializeComponent();
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            var canChanged =
                !(!RadioMail.Checked && !RadioName.Checked && !RadioPassword.Checked && !PhoneRadio.Checked);

            var property = "";
            if (!canChanged) return;
            if (!ValueTextBox.Text.Equals(""))
                if (RadioMail.Checked)
                    try
                    {
                        var mailAddress = new MailAddress(ValueTextBox.Text);
                        property = DbQuery.MailProperty;
                    }
                    catch (FormatException)
                    {
                        MissingFields.Visible = true;
                        var myTimer = new Timer {Interval = 3000};
                        myTimer.Tick += HideFail;
                        myTimer.Start();
                        return;
                    }
                else if (RadioName.Checked)
                    property = DbQuery.NameProperty;
                else if (RadioPassword.Checked)
                    property = DbQuery.PasswordProperty;
                else if (PhoneRadio.Checked)
                    property = DbQuery.PhoneProperty;

            if (ParentForm != null)
            {
                var appForms = (MadeiraMuseum) ParentForm;
                var dashboard = appForms.DashboardControl;
                var person = dashboard.Person;
                if (property == DbQuery.MailProperty)
                {
                    var availability = person.CheckAvailability(ValueTextBox.Text);
                    if (availability)
                    {
                        person.Update(property, ValueTextBox.Text, DbQuery.Itself);
                        Sucess.Visible = true;
                        var myTimer = new Timer {Interval = 3000};
                        myTimer.Tick += HideSucess;
                        myTimer.Start();
                    }
                    else
                    {
                        MissingFields.Visible = true;
                        var myTimer = new Timer {Interval = 3000};
                        myTimer.Tick += HideFail;
                        myTimer.Start();
                        Debug.WriteLine("Esse email ja existe!");
                    }
                }
                else
                {
                    person.Update(property, ValueTextBox.Text, DbQuery.Itself);
                    Sucess.Visible = true;
                    var myTimer = new Timer {Interval = 3000};
                    myTimer.Tick += HideSucess;
                    myTimer.Start();
                }

                if (property == DbQuery.NameProperty)
                {
                    person.Name = ValueTextBox.Text;
                    dashboard.ChangeUser();
                }
            }

            ValueTextBox.Text = "";
        }

        private void HideSucess(object sender, EventArgs e)
        {
            Sucess.Visible = false;
            var timer = (Timer) sender;
            timer.Enabled = false;
        }

        private void HideFail(object sender, EventArgs e)
        {
            MissingFields.Visible = false;
            var timer = (Timer) sender;
            timer.Enabled = false;
        }

        private void PasswordClick(object sender, EventArgs e)
        {
            ValueTextBox.PasswordChar = '*';
        }

        private void MailClick(object sender, EventArgs e)
        {
            ValueTextBox.PasswordChar = '\0';
        }

        private void PhoneClick(object sender, EventArgs e)
        {
            ValueTextBox.PasswordChar = '\0';
        }

        private void NameClick(object sender, EventArgs e)
        {
            ValueTextBox.PasswordChar = '\0';
        }
    }
}