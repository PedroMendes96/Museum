using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Museum;

namespace MuseumForm
{
    public partial class ProcessControl : UserControl
    {
        public Process Process;
        public ProcessControl()
        {
            InitializeComponent();
        }

        public void UpdateViewPerUser()
        {
            var index = this.ParentForm.Controls.IndexOfKey(AppForms.Dashboard_Control);
            DashboardControl dashboardControl = (DashboardControl)this.ParentForm.Controls[index];

            Label RoomsLabel = this.RoomsLabel;
            Label EndTimeLabel = this.EndTimeLabel;
            Label EntityLabel = this.Entity;
            Label EntetyNameLabel = this.EntityName;
            Label FirstDayLabel = this.FirstDayLabel;
            Label LastDayLabel = this.LastDayLabel;
            Label PriceLabel = this.PriceLabel;
            Label ResultLabel = this.ResultLabel;
            Label StartTimeLabel = this.StartTimeLabel;
            Label StateLabel = this.StateLabel;

            if (dashboardControl.Role.Equals(nameof(Employee)))
            {
                EntityLabel.Text = "Exhibitor";
                EntetyNameLabel.Text = Process.Exhibitor.Name;
            }
            else
            {
                EntityLabel.Text = "Employee";
                EntetyNameLabel.Text = Process.Employee.Name;
            }
            EndTimeLabel.Text = Process.Schedule.EndTime;
            FirstDayLabel.Text = Process.Schedule.FirstDay+"/"+ Process.Schedule.FirstMonth + "/" + Process.Schedule.FirstYear;
            LastDayLabel.Text = Process.Schedule.LastDay + "/" + Process.Schedule.LastMonth + "/" + Process.Schedule.LastYear;
            PriceLabel.Text = Process.Price.ToString();
            if (Process.Result == null)
            {
                ResultLabel.Text = "Pendent";
            }
            else if (Process.Result == true)
            {
                if (Process.Active == true)
                {
                    ResultLabel.Text = "Approved";
                }
                else
                {
                    ResultLabel.Text = "Confirmed";
                }
            }
            else
            {
                ResultLabel.Text = "Denied";
            }
            StartTimeLabel.Text = Process.Schedule.StartTime;
            StateLabel.Text = nameof(Process.Actual);
            RoomsLabel.Text = "Rooms ";
            foreach (var room in Process.Room)
            {
                RoomsLabel.Text += room.ToString();
            }


            Button accept = AcceptButton;
            Button refuse = RefuseButton;
            Button addArtPiece = AddArtPieceButton;
            Button confirmEvent = ConfirmEvent;
            Button refuseEvent = RefuseEventButton;
            Button editPrice = EditPriceButton;
            Button editProcess = EditProcessButton;

            if (dashboardControl.Role.Equals(nameof(Employee)))
            {
                if (Process.Active == false)
                {
                    if (Process.Result == true)
                    {
                        accept.Visible = false;
                        refuse.Visible = false;
                        addArtPiece.Visible = false;
                        confirmEvent.Visible = false;
                        refuseEvent.Visible = true;
                        editPrice.Visible = false;
                        editProcess.Visible = false;
                    }
                    else if(Process.Result == false)
                    { 
                        accept.Visible = false;
                        refuse.Visible = false;
                        addArtPiece.Visible = false;
                        confirmEvent.Visible = false;
                        refuseEvent.Visible = false;
                        editPrice.Visible = false;
                        editProcess.Visible = false;
                    }
                }
                else if (Process.Active == true)
                {
                    if (Process.Result == null)
                    {
                        accept.Visible = true;
                        refuse.Visible = true;
                        addArtPiece.Visible = false;
                        confirmEvent.Visible = false;
                        refuseEvent.Visible = false;
                        editPrice.Visible = true;
                        editProcess.Visible = false;
                    }
                    else
                    {
                        accept.Visible = false;
                        refuse.Visible = false;
                        addArtPiece.Visible = false;
                        confirmEvent.Visible = false;
                        refuseEvent.Visible = false;
                        editPrice.Visible = false;
                        editProcess.Visible = false;
                    }
                }
            }
            else if (dashboardControl.Role.Equals(nameof(Exhibitor)))
            {
                if (Process.Active == false && Process.Result != null)
                {
                    accept.Visible = false;
                    refuse.Visible = false;
                    addArtPiece.Visible = false;
                    confirmEvent.Visible = false;
                    refuseEvent.Visible = false;
                    editPrice.Visible = false;
                    editProcess.Visible = false;
                }
                else if (Process.Active == true)
                {
                    if (Process.Result == null)
                    {
                        accept.Visible = false;
                        refuse.Visible = false;
                        addArtPiece.Visible = true;
                        confirmEvent.Visible = false;
                        refuseEvent.Visible = false;
                        editPrice.Visible = false;
                        editProcess.Visible = true;
                    }
                    else if(Process.Result == true)
                    {
                        accept.Visible = false;
                        refuse.Visible = false;
                        addArtPiece.Visible = false;
                        confirmEvent.Visible = true;
                        refuseEvent.Visible = true;
                        editPrice.Visible = false;
                        editProcess.Visible = false;
                    }
                    else if (Process.Result == false)
                    {
                        accept.Visible = false;
                        refuse.Visible = false;
                        addArtPiece.Visible = false;
                        confirmEvent.Visible = false;
                        refuseEvent.Visible = false;
                        editPrice.Visible = false;
                        editProcess.Visible = false;
                    }
                }
            }
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            Process.Actual.Accept();
            UpdateViewPerUser();
        }

        private void EditPriceButton_Click(object sender, EventArgs e)
        {
            var index = this.ParentForm.Controls.IndexOfKey(AppForms.EditPriceControl);
            EditPriceControl editPriceControl = (EditPriceControl)this.ParentForm.Controls[index];
            editPriceControl.BringToFront();
            editPriceControl.process = Process;
            UpdateViewPerUser();
        }

        private void EditProcessButton_Click(object sender, EventArgs e)
        {
            var index = this.ParentForm.Controls.IndexOfKey(AppForms.EditProcess_Control);
            EditProcessControl editProcessControl = (EditProcessControl)this.ParentForm.Controls[index];
            editProcessControl.BringToFront();
            editProcessControl.process = Process;
            UpdateViewPerUser();
        }

        private void AddArtPieceButton_Click(object sender, EventArgs e)
        {
            var index = this.ParentForm.Controls.IndexOfKey(AppForms.AddArtPiece_Control);
            AddArtPieceControl addArtPieceControl = (AddArtPieceControl)this.ParentForm.Controls[index];
            addArtPieceControl.BringToFront();
            addArtPieceControl.process = Process;
        }

        private void RefuseButton_Click(object sender, EventArgs e)
        {
            Process.Actual.Refuse();
            UpdateViewPerUser();
        }

        private void ConfirmEvent_Click(object sender, EventArgs e)
        {
            Process.Actual.Confirm();
            UpdateViewPerUser();
        }

        private void RefuseEventButton_Click(object sender, EventArgs e)
        {
            Process.Actual.Cancel();
            UpdateViewPerUser();
        }
    }
}
