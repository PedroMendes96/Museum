using System;
using System.Windows.Forms;
using Museum;

namespace MuseumForm
{
    public partial class EditProcessControl : UserControl
    {
        private const string name = "Name";
        private const string description = "Description";
        private const string title = "Title";
        private const string from = "From";
        private const string until = "Until";
        private const string schedule = "Schedule";
        public Process process;

        public EditProcessControl()
        {
            InitializeComponent();
        }

        private void onChange(object sender, EventArgs e)
        {
            if (properties.Text.Equals(name) || properties.Text.Equals(description) ||
                properties.Text.Equals(title))
            {
                newValue.Visible = true;

                startBox.Visible = false;
                endBox.Visible = false;

                datePicker.Visible = false;
            }
            else if (properties.Text.Equals(from) || properties.Text.Equals(until))
            {
                newValue.Visible = false;

                startBox.Visible = false;
                endBox.Visible = false;

                datePicker.Visible = true;
            }
            else if (properties.Text == schedule)
            {
                newValue.Visible = false;

                startBox.Visible = true;
                endBox.Visible = true;

                datePicker.Visible = false;
            }
        }

        private void UpdateProcess_Click(object sender, EventArgs e)
        {
            if (properties.Text.Equals(name) || properties.Text.Equals(description) ||
                properties.Text.Equals(title))
            {
                if (!newValue.Text.Trim().Equals(""))
                {
                    var property = "";
                    if (properties.Text.Equals(name))
                        property = ArtPiece.NameProperty;
                    else if (properties.Text.Equals(description))
                        property += ArtPiece.DescriptionProperty;
                    else if (properties.Text.Equals(title))
                        property = ArtPiece.TitleProperty;
                    process.Update(property, newValue.Text);
                }
            }
            else if (properties.Text.Equals(from) || properties.Text.Equals(until))
            {
                var date = datePicker.Value;
                var day = date.Day;
                var month = date.Month;
                var year = date.Year;
                if (endBox.Text != null || startBox != null)
                {
                    var property = "";
                    var values = "";
                    if (properties.Text.Equals(from))
                        property += Schedule.StartDayProperty + "-" + Schedule.StartMonthProperty + "-" +
                                    Schedule.StartYearProperty;
                    else if (properties.Text.Equals(until))
                        property += Schedule.EndDayProperty + "-" + Schedule.EndMonthProperty + "-" +
                                    Schedule.EndYearProperty;
                    values += day + "-" + month + "-" + year;
                    process.Schedule.Update(property, values);
                }
            }
            else if (properties.Text == schedule)
            {
                var property = Schedule.StartTimeProperty + "-" + Schedule.EndTimeProperty;
                var values = startBox.Text + "-" + endBox.Text;
                process.Schedule.Update(property, values);
            }
        }
    }
}