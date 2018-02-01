using System;
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
            if (ParentForm != null)
            {
                var index = ParentForm.Controls.IndexOfKey(AppForms.DashboardControl);
                var dashboardControl = (DashboardControl) ParentForm.Controls[index];

                var roomsLabel = RoomsLabel;
                var endTimeLabel = EndTimeLabel;
                var entityLabel = Entity;
                var entetyNameLabel = EntityName;
                var firstDayLabel = FirstDayLabel;
                var lastDayLabel = LastDayLabel;
                var priceLabel = PriceLabel;
                var resultLabel = ResultLabel;
                var startTimeLabel = StartTimeLabel;
                var stateLabel = StateLabel;

                if (dashboardControl.Role.Equals(nameof(Employee)))
                {
                    entityLabel.Text = nameof(Exhibitor);
                    entetyNameLabel.Text = Process.Exhibitor.Name;
                }
                else
                {
                    entityLabel.Text = nameof(Employee);
                    entetyNameLabel.Text = Process.Employee.Name;
                }

                endTimeLabel.Text = Process.Schedule.EndTime;
                firstDayLabel.Text = Process.Schedule.FirstDay + @"/" + Process.Schedule.FirstMonth + @"/" +
                                     Process.Schedule.FirstYear;
                lastDayLabel.Text = Process.Schedule.LastDay + @"/" + Process.Schedule.LastMonth + @"/" +
                                    Process.Schedule.LastYear;
                priceLabel.Text = Process.Price.ToString();
                if (Process.Result == null)
                    resultLabel.Text = nameof(Pendent);
                else if (Process.Result == 1)
                    resultLabel.Text = Process.Active == 1 ? nameof(Approved) : nameof(Confirmed);
                else
                    resultLabel.Text = nameof(Denied);
                startTimeLabel.Text = Process.Schedule.StartTime;
                stateLabel.Text = nameof(Process.Actual);
                roomsLabel.Text = nameof(Room)+@"s ";
                foreach (var room in Process.Room) roomsLabel.Text += room.ToString();


                var accept = AcceptButton;
                var refuse = RefuseButton;
                var addArtPiece = AddArtPieceButton;
                var confirmEvent = ConfirmEvent;
                var refuseEvent = RefuseEventButton;
                var editPrice = EditPriceButton;
                var editProcess = EditProcessButton;

                if (dashboardControl.Role.Equals(nameof(Employee)))
                {
                    if (Process.Active == 0)
                    {
                        if (Process.Result == 1)
                        {
                            accept.Visible = false;
                            refuse.Visible = false;
                            addArtPiece.Visible = false;
                            confirmEvent.Visible = false;
                            refuseEvent.Visible = true;
                            editPrice.Visible = false;
                            editProcess.Visible = false;
                        }
                        else if (Process.Result == 0)
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
                    else if (Process.Active == 1)
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
                    if (Process.Active == 0)
                        if (Process.Result == 1)
                        {
                            accept.Visible = false;
                            refuse.Visible = false;
                            addArtPiece.Visible = false;
                            confirmEvent.Visible = false;
                            refuseEvent.Visible = true;
                            editPrice.Visible = false;
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
                    else if (Process.Active == 1)
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
                        else if (Process.Result == 1)
                        {
                            accept.Visible = false;
                            refuse.Visible = false;
                            addArtPiece.Visible = false;
                            confirmEvent.Visible = true;
                            refuseEvent.Visible = false;
                            editPrice.Visible = false;
                            editProcess.Visible = false;
                        }
                        else if (Process.Result == 0)
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
            if (ParentForm != null)
            {
                var index = ParentForm.Controls.IndexOfKey(AppForms.EditPriceControl);
                var editPriceControl = (EditPriceControl) ParentForm.Controls[index];
                editPriceControl.BringToFront();
                editPriceControl.process = Process;
            }

            UpdateViewPerUser();
        }

        private void EditProcessButton_Click(object sender, EventArgs e)
        {
            if (ParentForm != null)
            {
                var index = ParentForm.Controls.IndexOfKey(AppForms.EditProcessControl);
                var editProcessControl = (EditProcessControl) ParentForm.Controls[index];
                editProcessControl.BringToFront();
                editProcessControl.process = Process;
            }

            UpdateViewPerUser();
        }

        private void AddArtPieceButton_Click(object sender, EventArgs e)
        {
            if (ParentForm == null) return;
            var index = ParentForm.Controls.IndexOfKey(AppForms.AddArtPieceControl);
            var addArtPieceControl = (AddArtPieceControl) ParentForm.Controls[index];
            addArtPieceControl.BringToFront();
            addArtPieceControl.Process = Process;
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