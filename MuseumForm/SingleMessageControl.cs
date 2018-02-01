using System;
using System.Windows.Forms;
using Museum;
using Message = Museum.Message;

namespace MuseumForm
{
    public partial class SingleMessageControl : UserControl
    {
        public SingleMessageControl()
        {
            InitializeComponent();
        }


        public Message Message { get; set; }

        public void UpdateText()
        {
            var result = Employee.GetEmployeeByPersonId(Message.Sender.Id.ToString());
            if (result.Count > 0)
                headTitle.Text = @"Message from: " + Message.Sender.Name + @" - Employee";
            else
                headTitle.Text = @"Message from: " + Message.Sender.Name + @" - Exhibitor";
            title.Text = @"Title: " + Message.Title;
            content.Text = Message.Content;
            receivedTimeLabel.Text = @"at " + Message.LastUpdate;
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click_1(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ParentForm != null)
            {
                var index = ParentForm.Controls.IndexOfKey(AppForms.MessagesControl);
                var messagesControl = (MessagesControl) ParentForm.Controls[index];
                messagesControl.ResetView();
            }
        }
    }
}