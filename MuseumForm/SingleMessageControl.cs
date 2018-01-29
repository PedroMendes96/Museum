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
            var db = DBConnection.Instance;
            var query = "SELECT * FROM employees WHERE employees.persons_id = " + Message.Sender.Id;
            var result = db.Query(query);
            if (result.Count > 0)
                headTitle.Text = "Message from: " + Message.Sender.Name + " - Employee";
            else
                headTitle.Text = "Message from: " + Message.Sender.Name + " - Exhibitor";
            title.Text = "Title: " + Message.Title;
            content.Text = Message.Content;
            receivedTimeLabel.Text = "at " + Message.LastUpdate;
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click_1(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var index = ParentForm.Controls.IndexOfKey(AppForms.Messages_Control);
            var messagesControl = (MessagesControl) ParentForm.Controls[index];
            messagesControl.ResetView();
        }
    }
}