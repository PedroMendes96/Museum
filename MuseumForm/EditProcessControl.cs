using System;
using System.Diagnostics;
using System.Windows.Forms;
using Museum;
using Process = Museum.Process;

namespace MuseumForm
{
    public partial class EditProcessControl : UserControl
    {
        private new const string Name = "Name";
        private const string Description = "Description";
        private const string Title = "Title";
        private const string From = "From";
        private const string Until = "Until";
        private const string Schedule = "Schedule";
        public Process process;

        public EditProcessControl()
        {
            InitializeComponent();
        }

        private void OnChange(object sender, EventArgs e)
        {
            if (properties.Text.Equals(Name) || properties.Text.Equals(Description) ||
                properties.Text.Equals(Title))
            {
                newValue.Visible = true;

                startBox.Visible = false;
                endBox.Visible = false;

                datePicker.Visible = false;
            }
            else if (properties.Text.Equals(From) || properties.Text.Equals(Until))
            {
                newValue.Visible = false;

                startBox.Visible = false;
                endBox.Visible = false;

                datePicker.Visible = true;
            }
            else if (properties.Text == Schedule)
            {
                newValue.Visible = false;

                startBox.Visible = true;
                endBox.Visible = true;

                datePicker.Visible = false;
            }
        }

        private void UpdateProcess_Click(object sender, EventArgs e)
        {
            var myTimer = new Timer { Interval = 1000 };
            try
            {
                if (properties.Text.Equals(Name) || properties.Text.Equals(Description) ||
                properties.Text.Equals(Title))
                {
                    if (!newValue.Text.Trim().Equals(""))
                    {
                        var property = "";
                        if (properties.Text.Equals(Name))
                            property = ArtPiece.NameProperty;
                        else if (properties.Text.Equals(Description))
                            property += ArtPiece.DescriptionProperty;
                        else if (properties.Text.Equals(Title))
                            property = ArtPiece.TitleProperty;
                        process.Update(property, newValue.Text);
                    }
                }
                else if (properties.Text.Equals(From) || properties.Text.Equals(Until))
                {
                    var date = datePicker.Value;
                    var day = date.Day;
                    var month = date.Month;
                    var year = date.Year;
                    if (endBox.Text != null || startBox != null)
                    {
                        var property = "";
                        var values = "";
                        if (properties.Text.Equals(From))
                            property += Museum.Schedule.StartDayProperty + "-" + Museum.Schedule.StartMonthProperty + "-" +
                                        Museum.Schedule.StartYearProperty;
                        else if (properties.Text.Equals(Until))
                            property += Museum.Schedule.EndDayProperty + "-" + Museum.Schedule.EndMonthProperty + "-" +
                                        Museum.Schedule.EndYearProperty;
                        values += day + "-" + month + "-" + year;
                        process.Schedule.Update(property, values);
                    }
                }
                else if (properties.Text == Schedule)
                {
                    var property = Museum.Schedule.StartTimeProperty + "-" + Museum.Schedule.EndTimeProperty;
                    var values = startBox.Text + "-" + endBox.Text;
                    process.Schedule.Update(property, values);
                }
                Sucess.Visible = true;
                myTimer.Tick += ShowAndHideSucess;
                myTimer.Start();
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
                MissingFields.Visible = true;
                myTimer.Tick += ShowAndHideFail;
                myTimer.Start();
            }
            newValue.Text = "";
        }

        private void ShowAndHideSucess(object sender, EventArgs e)
        {
            Sucess.Visible = false;
            var timer = (Timer)sender;
            timer.Enabled = false;
        }

        private void ShowAndHideFail(object sender, EventArgs e)
        {
            MissingFields.Visible = false;
            var timer = (Timer)sender;
            timer.Enabled = false;
        }
    }
}