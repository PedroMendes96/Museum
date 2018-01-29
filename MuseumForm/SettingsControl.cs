using System;
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
            var canChanged = true;
            if (!RadioMail.Checked && !RadioName.Checked && !RadioPassword.Checked && !PhoneRadio.Checked)
                canChanged = false;

            var property = "";
            if (canChanged)
            {
                if (!ValueTextBox.Text.Equals(""))
                    if (RadioMail.Checked)
                        try
                        {
                            var mailAddress = new MailAddress(ValueTextBox.Text);
                            property = Person.MailProperty;
                        }
                        catch (FormatException)
                        {
                            return;
                        }
                    else if (RadioName.Checked)
                        property = Person.NameProperty;
                    else if (RadioPassword.Checked)
                        property = Person.PasswordProperty;
                    else if (PhoneRadio.Checked)
                        property = Person.PhoneProperty;

                var index = ParentForm.Controls.IndexOfKey(AppForms.Dashboard_Control);
                var dashboard = (DashboardControl) ParentForm.Controls[index];
                var person = dashboard.Person;
                person.Update(property, ValueTextBox.Text, Person.Itself);
                if (property == Person.NameProperty)
                {
                    person.Name = ValueTextBox.Text;
                    dashboard.ChangeUser();
                }

                ValueTextBox.Text = "";
            }
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