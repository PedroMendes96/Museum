using System;
using System.Windows.Forms;
using Museum;
using Message = Museum.Message;

namespace MuseumForm
{
    public partial class SingleMessageControl : UserControl
    {
        public Message Message { get; set; }

        public SingleMessageControl()
        {
            InitializeComponent();
        }

        public void UpdateText()
        {
            var result = DbQuery.GetEmployeeByPersonId(Message.Sender.Id.ToString());
            if (result.Count > 0)
                headTitle.Text = @"Message from: " + Message.Sender.Name + @" - Employee";
            else
                headTitle.Text = @"Message from: " + Message.Sender.Name + @" - Exhibitor";
            title.Text = @"Title: " + Message.Title;
            content.Text = Message.Content;
            receivedTimeLabel.Text = @"at " + Message.LastUpdate;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ParentForm != null)
            {
                var appForms = (MadeiraMuseum) ParentForm;
                var messagesControl = appForms.MessagesControl;
                messagesControl.ResetView();
            }
        }
    }
}