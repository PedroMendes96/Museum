using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
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
            var index = ParentForm.Controls.IndexOfKey(AppForms.Dashboard_Control);
            var dashboardControl = (DashboardControl)ParentForm.Controls[index];
            dashboardControl.BringToFront();
            CleanFields();
        }

        private void CleanFields()
        {
            SizeBox.Text = "";
            DescriptionBox.Text = "";
        }

        private void UpdatePrice_Click(object sender, EventArgs e)
        {
            var size = SizeBox.Text;
            var description = DescriptionBox.Text;
            if (description.Trim().Equals("") || size.Trim().Equals(""))
            {
                if (description.Trim().Equals(""))
                {
                    MissingFields.Text = "You must fill description correcly";
                }
                else if(size.Trim().Equals(""))
                {
                    MissingFields.Text = "You must fill Size correcly";
                }
                else
                {
                    MissingFields.Text = "You must fill all the fields";
                }
                MissingFields.Visible = true;

                System.Windows.Forms.Timer MyTimer = new System.Windows.Forms.Timer();
                MyTimer.Interval = (1000); // 45 mins
                MyTimer.Tick += new EventHandler(HideMessage);
                MyTimer.Start();
            }
            else
            {
                var insertRoomSql = "INSERT INTO rooms (size,description) VALUES ("+size+",'"+description+"')";
                DBConnection.Instance.Execute(insertRoomSql);
                BackButton_Click(null,null);
                CleanFields();
            }
        }

        private void HideMessage(object sender, EventArgs e)
        {
            MissingFields.Visible = false;
            var timer = (System.Windows.Forms.Timer) sender;
            timer.Enabled = false;
        }
    }
}
