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
            var exhibitions = "SELECT * FROM events ORDER BY lastUpdate DESC";
            var exhibitionsResult = DBConnection.Instance.Query(exhibitions);
            if (exhibitionsResult != null)
                if (exhibitionsResult.Count >= 2)
                    for (var i = 0; i < 2; i++)
                    {
                        var adapter = new DictionaryAdapter(exhibitionsResult[i]);

                        var isTemporary = "SELECT * FROM temporaries WHERE events_id=" + adapter.GetValue("id");
                        var temporaryResult = DBConnection.Instance.Query(isTemporary);

                        if (temporaryResult.Count == 0)
                        {
                            var isPermanent = "SELECT title,name,description FROM permanents,events WHERE events.id=" +
                                              adapter.GetValue("id") + " AND events.id=permanents.events_id";
                            var PermanentResult = DBConnection.Instance.Query(isPermanent);
                            if (PermanentResult.Count > 0)
                            {
                                adapter = new DictionaryAdapter(PermanentResult[0]);

                                if (i == 0)
                                {
                                    TitleFirstExhibition.Text = adapter.GetValue("title");
                                    NameExhibitionOne.Text = adapter.GetValue("name");
                                    DescriptionExhibitionOne.Text = adapter.GetValue("description");
                                    FromExhibitionOne.Text = "---";
                                    ToExhibitionOne.Text = "---";
                                    ScheduleExhibitionOne.Text = "9:00 - 19:00";
                                    ArtistExhibitionOne.Text = "Museum Property";
                                }
                                else
                                {
                                    TitleSecondExhibition.Text = adapter.GetValue("title");
                                    NameExhibitionTwo.Text = adapter.GetValue("name");
                                    DescriptionExhibitionTwo.Text = adapter.GetValue("description");
                                    FromExhibitionTwo.Text = "---";
                                    ToExhibitionTwo.Text = "---";
                                    schedule.Text = "9:00 - 19:00";
                                    ArtistExhibitionTwo.Text = "Museum Property";
                                }
                            }
                        }
                        else
                        {
                            for (var j = 0; j < temporaryResult.Count; j++)
                            {
                                var temporaryAdapter = new DictionaryAdapter(temporaryResult[j]);

                                var scheduleSQL = "SELECT * FROM schedules WHERE id=" +
                                                  temporaryAdapter.GetValue("schedule_id");
                                var schedulesResult = DBConnection.Instance.Query(scheduleSQL);

                                var schedulesAdapter = new DictionaryAdapter(schedulesResult[0]);

                                var processesSQL = "SELECT * FROM processes WHERE id=" +
                                                   temporaryAdapter.GetValue("processes_id");
                                var processesResult = DBConnection.Instance.Query(processesSQL);

                                var processesAdapter = new DictionaryAdapter(processesResult[0]);

                                var exhibitorSQL = "SELECT * FROM exhibitors WHERE id=" +
                                                   processesAdapter.GetValue("exhibitors_id");
                                var exhibitorResult = DBConnection.Instance.Query(exhibitorSQL);

                                var exhibitorAdapter = new DictionaryAdapter(exhibitorResult[0]);

                                var personSQL = "SELECT * FROM persons WHERE id=" +
                                                exhibitorAdapter.GetValue("persons_id");
                                var personResult = DBConnection.Instance.Query(personSQL);

                                var personAdapter = new DictionaryAdapter(personResult[0]);

                                if (i == 0)
                                {
                                    TitleFirstExhibition.Text = adapter.GetValue("title");
                                    NameExhibitionOne.Text = adapter.GetValue("name");
                                    DescriptionExhibitionOne.Text = adapter.GetValue("description");
                                    FromExhibitionOne.Text =
                                        schedulesAdapter.GetValue("startDay") + "/" +
                                        schedulesAdapter.GetValue("startMonth") + "/" +
                                        schedulesAdapter.GetValue("startYear");
                                    ToExhibitionOne.Text =
                                        schedulesAdapter.GetValue("endDay") + "/" +
                                        schedulesAdapter.GetValue("endMonth") + "/" +
                                        schedulesAdapter.GetValue("endYear");
                                    ;
                                    ScheduleExhibitionOne.Text =
                                        schedulesAdapter.GetValue("startTime") + "-" +
                                        schedulesAdapter.GetValue("endTime");
                                    ArtistExhibitionOne.Text = personAdapter.GetValue("name");
                                }
                                else
                                {
                                    TitleSecondExhibition.Text = adapter.GetValue("title");
                                    NameExhibitionTwo.Text = adapter.GetValue("name");
                                    DescriptionExhibitionTwo.Text = adapter.GetValue("description");
                                    FromExhibitionTwo.Text =
                                        schedulesAdapter.GetValue("startDay") + "/" +
                                        schedulesAdapter.GetValue("startMonth") + "/" +
                                        schedulesAdapter.GetValue("startYear");
                                    ToExhibitionTwo.Text =
                                        schedulesAdapter.GetValue("endDay") + "/" +
                                        schedulesAdapter.GetValue("endMonth") + "/" +
                                        schedulesAdapter.GetValue("endYear");
                                    ScheduleExhibitionTwo.Text =
                                        schedulesAdapter.GetValue("startTime") + "-" +
                                        schedulesAdapter.GetValue("endTime");
                                    ArtistExhibitionTwo.Text = personAdapter.GetValue("name");
                                }
                            }
                        }
                    }
        }
    }
}