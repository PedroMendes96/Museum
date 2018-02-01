using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using Museum;

namespace MuseumForm
{
    public partial class ForgotPasswordControl : UserControl
    {
        private readonly Random _random = new Random();
        private const string Mail = "museumprojectdis@gmail.com";

        public ForgotPasswordControl()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var mailAddress = new MailAddress(MailBox.Text);
            }
            catch (FormatException)
            {
                return;
            }

            var personResult = Person.GetPeopleByMail(MailBox.Text);
            if (personResult.Count > 0)
            {
                var adapter = new DictionaryAdapter(personResult[0]);
                try
                {
                    var newPassword = RandomString(20);
                    Person.UpdatePersonPassword(adapter.GetValue("id"), newPassword);
                    SendEmail(newPassword, MailBox.Text);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            if (ParentForm != null)
            {
                var index = ParentForm.Controls.IndexOfKey(AppForms.InitialControl);
                ParentForm.Controls[index].BringToFront();
            }
        }

        private void SendEmail(string newPassword, string email)
        { 
            try
            {
                var clientDetails = new SmtpClient
                {
                    Port = 587,
                    Host = "smtp.gmail.com",
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(Mail, "DIS20172018")
                };

                var mailMessage = new MailMessage {From = new MailAddress(Mail)};
                mailMessage.To.Add(email);
                mailMessage.Subject = "Reset Password";
                mailMessage.IsBodyHtml = false;
                mailMessage.Body = "Hi" + Environment.NewLine + "Your new password is:" + Environment.NewLine +
                                   newPassword;

                clientDetails.Send(mailMessage);
                if (ParentForm != null)
                {
                    var index = ParentForm.Controls.IndexOfKey(AppForms.InitialControl);
                    ParentForm.Controls[index].BringToFront();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[_random.Next(s.Length)]).ToArray());
        }
    }
}