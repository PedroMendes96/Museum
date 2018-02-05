using System.Windows.Forms;
using Museum;

namespace MuseumForm
{
    public partial class ExhibitionsControl : UserControl
    {
        public ExhibitionsControl()
        {
            InitializeComponent();
        }

        public void UpdateExhibitions()
        {
            var exhibitionsResult = Museum.Events.GetAllEventsOrderedByLast();
            if (exhibitionsResult?.Count >= 2)
            {
                for (var i = 0; i < 2; i++)
                {
                    var adapter = new DictionaryAdapter(exhibitionsResult[i]);

                    var temporaryResult = Temporary.GetTemporariesInEvents(adapter.GetValue("id"));

                    if (temporaryResult.Count == 0)
                    {
                        var permanentResult = Permanent.GetPermanentsInEvents(adapter.GetValue("id"));
                        if (permanentResult.Count > 0)
                        {
                            adapter = new DictionaryAdapter(permanentResult[0]);

                            if (i == 0)
                            {
                                TitleFirstExhibition.Text = adapter.GetValue("title");
                                NameExhibitionOne.Text = adapter.GetValue("name");
                                DescriptionExhibitionOne.Text = adapter.GetValue("description");
                                FromExhibitionOne.Text = @"---";
                                ToExhibitionOne.Text = @"---";
                                ScheduleExhibitionOne.Text = @"9:00 - 19:00";
                                ArtistExhibitionOne.Text = @"Museum Property";
                            }
                            else
                            {
                                TitleSecondExhibition.Text = adapter.GetValue("title");
                                NameExhibitionTwo.Text = adapter.GetValue("name");
                                DescriptionExhibitionTwo.Text = adapter.GetValue("description");
                                ToExhibitionTwo.Text = @"---";
                                FromExhibitionTwo.Text = @"---";
                                ScheduleExhibitionTwo.Text = @"9:00 - 19:00";
                                ArtistExhibitionTwo.Text = @"Museum Property";
                            }
                        }
                    }
                    else
                    {
                        foreach (var property in temporaryResult)
                        {
                            var temporaryAdapter = new DictionaryAdapter(property);

                            var schedulesResult = Schedule.GetSchedulesById(temporaryAdapter.GetValue("schedule_id"));

                            var schedulesAdapter = new DictionaryAdapter(schedulesResult[0]);

                            var processesResult = Process.GetProcessesById(temporaryAdapter.GetValue("processes_id"));

                            var processesAdapter = new DictionaryAdapter(processesResult[0]);

                            var exhibitorResult = Exhibitor.GetExhibitorsById(processesAdapter.GetValue("exhibitors_id"));

                            var exhibitorAdapter = new DictionaryAdapter(exhibitorResult[0]);

                            var personResult = Person.GetPeopleById(exhibitorAdapter.GetValue("persons_id"));

                            var personAdapter = new DictionaryAdapter(personResult[0]);

                            if (i == 0)
                            {
                                TitleFirstExhibition.Text = adapter.GetValue("title");
                                NameExhibitionOne.Text = adapter.GetValue("name");
                                DescriptionExhibitionOne.Text = adapter.GetValue("description");
                                FromExhibitionOne.Text =
                                    schedulesAdapter.GetValue("startDay") + @"/" +
                                    schedulesAdapter.GetValue("startMonth") + @"/" +
                                    schedulesAdapter.GetValue("startYear");
                                ToExhibitionOne.Text =
                                    schedulesAdapter.GetValue("endDay") + @"/" +
                                    schedulesAdapter.GetValue("endMonth") + @"/" +
                                    schedulesAdapter.GetValue("endYear");
                                ScheduleExhibitionOne.Text =
                                    schedulesAdapter.GetValue("startTime") + @"-" +
                                    schedulesAdapter.GetValue("endTime");
                                ArtistExhibitionOne.Text = personAdapter.GetValue("name");
                            }
                            else
                            {
                                TitleSecondExhibition.Text = adapter.GetValue("title");
                                NameExhibitionTwo.Text = adapter.GetValue("name");
                                DescriptionExhibitionTwo.Text = adapter.GetValue("description");
                                FromExhibitionTwo.Text =
                                    schedulesAdapter.GetValue("startDay") + @"/" +
                                    schedulesAdapter.GetValue("startMonth") + @"/" +
                                    schedulesAdapter.GetValue("startYear");
                                ToExhibitionTwo.Text =
                                    schedulesAdapter.GetValue("endDay") + @"/" +
                                    schedulesAdapter.GetValue("endMonth") + @"/" +
                                    schedulesAdapter.GetValue("endYear");
                                ScheduleExhibitionTwo.Text =
                                    schedulesAdapter.GetValue("startTime") + @"-" +
                                    schedulesAdapter.GetValue("endTime");
                                ArtistExhibitionTwo.Text = personAdapter.GetValue("name");
                            }
                        }
                    }
                }
                ExhibitionOne.Visible = true;
                ExhibitionTwo.Visible = true;
            }
            else
            {
                ExhibitionOne.Visible = false;
                ExhibitionTwo.Visible = false;
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}