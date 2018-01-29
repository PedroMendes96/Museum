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
        private readonly Random random = new Random();

        public ForgotPasswordControl()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
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

            var properties = new[] {"*"};
            var tables = new[] {"persons"};
            var keys = new[] {"mail"};
            var values = new[] {MailBox.Text};

            var personSQL = SqlOperations.Instance.Select(properties, tables, keys, values);
            var personResult = DBConnection.Instance.Query(personSQL);
            if (personResult.Count > 0)
            {
                var adapter = new DictionaryAdapter(personResult[0]);
                try
                {
                    var newPassword = RandomString(20);
                    var table = "persons";
                    keys = new[] {Person.PasswordProperty};
                    values = new[] {newPassword};
                    var updatePersonSql =
                        SqlOperations.Instance.Update(int.Parse(adapter.GetValue("id")), table, keys, values);
                    DBConnection.Instance.Execute(updatePersonSql);
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
            var index = ParentForm.Controls.IndexOfKey(AppForms.Initial_Control);
            ParentForm.Controls[index].BringToFront();
        }

        private void SendEmail(string newPassword, string email)
        {
            try
            {
                var clientDetails = new SmtpClient();
                clientDetails.Port = 587;
                clientDetails.Host = "smtp.gmail.com";
                clientDetails.EnableSsl = true;
                clientDetails.DeliveryMethod = SmtpDeliveryMethod.Network;
                clientDetails.UseDefaultCredentials = false;
                clientDetails.Credentials = new NetworkCredential("museumprojectdis@gmail.com", "DIS20172018");

                var mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("museumprojectdis@gmail.com");
                mailMessage.To.Add(email);
                mailMessage.Subject = "Reset Password";
                mailMessage.IsBodyHtml = false;
                mailMessage.Body = "Hi" + Environment.NewLine + "Your new password is:" + Environment.NewLine +
                                   newPassword;

                clientDetails.Send(mailMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            var index = ParentForm.Controls.IndexOfKey(AppForms.Initial_Control);
            ParentForm.Controls[index].BringToFront();
        }

        private string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}