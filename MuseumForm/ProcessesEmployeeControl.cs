using System.Collections.Generic;
using System.Windows.Forms;
using Museum;

namespace MuseumForm
{
    public partial class ProcessesEmployeeControl : ProcessTemplate
    {
        public int ActualPage { get; set; }

        public ProcessesEmployeeControl()
        {
            InitializeComponent();
            InitialSize = processContainer.Size.Height;
            ActualPage = 1;
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
            var employeeResult = DbQuery.GetEmployeeByPersonId(idPerson.ToString());

            var employee = (Employee) FactoryCreator.Instance.CreateFactory(FactoryCreator.PersonFactory)
                .ImportData(PersonFactory.Employee, employeeResult[0]);

            return employee;
        }

        public override string GetProcessByPerson(int idPerson)
        {
            var processesSql = "SELECT * FROM processes WHERE employees_id=" + idPerson +
                               " ORDER BY lastUpdate DESC";
            return processesSql;
        }

        public override int GetPage()
        {
            return ActualPage;
        }

        public override void SetPage(int number)
        {
            ActualPage = number;
        }

        public override void ResetContainer()
        {
            var size = processContainer.Size;
            size.Height = 0;
            processContainer.Size = size;
        }

        public override Person GetOtherPerson(DictionaryAdapter dictionaryAdapter)
        {
            var personResult = DbQuery.GetExhibitorByRoleId(dictionaryAdapter.GetValue("exhibitors_id"));
            var exhibitor = (Exhibitor) FactoryCreator.Instance.CreateFactory(FactoryCreator.PersonFactory)
                .ImportData(PersonFactory.Exhibitor, personResult[0]);
            return exhibitor;
        }

        public override Process CreateProcess(Dictionary<string, string> process, Person role, Person otherEntety,
            Schedule schedule, List<Room> rooms)
        {
            return new Process(process, (Exhibitor) otherEntety, (Employee) role, schedule, rooms);
        }
    }
}