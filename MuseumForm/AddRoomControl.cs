using System;
using System.Windows.Forms;
using Museum;

namespace MuseumForm
{
    public partial class AddRoomControl : UserControl
    {
        public AddRoomControl()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            if (ParentForm != null)
            {
                var appForms = (AppForms)ParentForm;
                var dashboardControl = appForms.DashboardControl;
                dashboardControl.BringToFront();
            }

            CleanFields();
        }

        private void CleanFields()
        {
            SizeBox.Text = "";
            DescriptionBox.Text = "";
        }

        private void HideMessage(object sender, EventArgs e)
        {
            MissingFields.Visible = false;
            var timer = (Timer) sender;
            timer.Enabled = false;
        }

        private void ShowMessage(object sender, EventArgs e)
        {
            Sucess.Visible = false;
            var timer = (Timer)sender;
            timer.Enabled = false;
        }

        private void AddRoom_Click(object sender, EventArgs e)
        {
            var myTimer = new Timer { Interval = 1000 };
            var size = SizeBox.Text ?? throw new ArgumentNullException(nameof(sender));
            var description = DescriptionBox.Text;
            if (description.Trim().Equals("") || size.Trim().Equals(""))
            {
                if (description.Trim().Equals(""))
                    MissingFields.Text = @"You must fill description correcly";
                else if (size.Trim().Equals(""))
                    MissingFields.Text = @"You must fill Size correcly";
                else
                    MissingFields.Text = @"You must fill all the fields";
                MissingFields.Visible = true;

                myTimer.Tick += HideMessage;
                myTimer.Start();
            }
            else
            {
                var room = new Room(size, description);
                room.Save();
                BackButton_Click(null, null);
                CleanFields();
                myTimer.Tick += ShowMessage;
                myTimer.Start();
            }
        }
    }
}