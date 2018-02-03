using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Museum;
using Process = Museum.Process;

namespace MuseumForm
{
    public partial class ProcessesExhibitorControl : ProcessTemplate
    {

        public ProcessesExhibitorControl()
        {
            InitializeComponent();
            InitialSize = processContainer.Size.Height;
            ActualPage = 1;
        }

        public int ActualPage { get; set; } = 1;

        public void Previous_Click(object sender, EventArgs e)
        {
            if (ActualPage != 1)
            {
                ActualPage -= 1;
                ResetProcesses();
                ListProcesses(ActualPage);
            }
        }

        public void Next_Click(object sender, EventArgs e)
        {
            var maxPag = (int)Math.Ceiling((double)Processes.Count / 5);
            if (ActualPage != maxPag)
            {
                ActualPage += 1;
                ResetProcesses();
                ListProcesses(ActualPage);
            }
        }

        public override Panel GetContainer()
        {
            return processContainer;
        }

        public override void HideNextPreviousButtons()
        {
            Next.Visible = false;
            Previous.Visible = false;
        }

        public override void ShowNextPreviousButtons()
        {
            Next.Visible = true;
            Previous.Visible = true;
        }

        public override Person GetPersonRole(int idPerson)
        {
            var exhibitorResult = Exhibitor.GetExhibitorByPersonId(idPerson.ToString());

            var exhibitor = (Exhibitor)FactoryCreator.Instance.CreateFactory(FactoryCreator.PersonFactory)
                .ImportData(PersonFactory.Exhibitor, exhibitorResult[0]);

            return exhibitor;
        }

        public override string GetProcessByPerson(int idPerson)
        {
            var processesSql = "SELECT * FROM processes WHERE exhibitors_id=" + idPerson +
                               " ORDER BY lastUpdate DESC";
            return processesSql;
        }

        public override Person GetOtherPerson(DictionaryAdapter dictionaryAdapter)
        {
            var personResult = Employee.GetEmployeeByRoleId(dictionaryAdapter.GetValue("employees_id"));
            var employee = (Employee)FactoryCreator.Instance.CreateFactory(FactoryCreator.PersonFactory)
                .ImportData(PersonFactory.Employee, personResult[0]);
            return employee;
        }

        public override Process CreateProcess(Dictionary<string, string> process, Person role, Person otherEntety, Schedule schedule, List<Room> rooms)
        {
            return new Process(process, (Exhibitor)role, (Employee)otherEntety, schedule, rooms);
        }

        private void newProcess_Click(object sender, EventArgs e)
        {
            if (ParentForm != null)
            {
                var appForms = (AppForms)ParentForm;
                var selectedControl = appForms.NewProcessControl;
                selectedControl.ListRooms();
                selectedControl.BringToFront();
            }
        }

        public override void ResetContainer()
        {
            var size = processContainer.Size;
            size.Height = 0;
            processContainer.Size = size;
        }
    }
}