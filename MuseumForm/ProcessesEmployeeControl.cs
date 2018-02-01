using System.Collections.Generic;
using System.Windows.Forms;
using Museum;

namespace MuseumForm
{
    public partial class ProcessesEmployeeControl : ProcessTemplate
    {

        public ProcessesEmployeeControl()
        {
            InitializeComponent();
            InitialSize = processContainer.Size.Height;
        }

        public int ActualPage { get; set; } = 1;

        public override int GetPage()
        {
            return ActualPage;
        }

        public override void SetPage(int page)
        {
            ActualPage = page;
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
//            var employeeSQL =
//                "SELECT name,phone,password,persons.id AS persons_id, employees.id AS employees_id FROM persons, employees WHERE persons.id=" +
//                idPerson + " AND employees.persons_id=persons.id";
//
//
//            var employeeResult = DbConnection.Instance.Query(employeeSQL);
            var employeeResult = Employee.GetEmployeeByPersonId(idPerson.ToString());

            var employee = (Employee)FactoryCreator.Instance.CreateFactory(FactoryCreator.PersonFactory)
                .ImportData(PersonFactory.Employee, employeeResult[0]);

            return employee;
        }

        public override string GetProcessByPerson(int idPerson)
        {
            var processesSql = "SELECT * FROM processes WHERE employees_id=" + idPerson +
                               " ORDER BY lastUpdate DESC";
            return processesSql;
        }

        public override Person GetOtherPerson(DictionaryAdapter dictionaryAdapter)
        {
//            var PersonRole =
//                "SELECT persons.id as persons_id, exhibitors.id AS exhibitors_id, name, password, phone, mail, type FROM persons, exhibitors" +
//                " WHERE persons_id=persons.id AND exhibitors.id=" + dictionaryAdapter.GetValue("exhibitors_id");
            var personResult = Exhibitor.GetExhibitorByRoleId(dictionaryAdapter.GetValue("exhibitors_id"));// DbConnection.Instance.Query(PersonRole);
            var exhibitor = (Exhibitor)FactoryCreator.Instance.CreateFactory(FactoryCreator.PersonFactory)
                .ImportData(PersonFactory.Exhibitor, personResult[0]);
            return exhibitor;
        }

        public override Process CreateProcess(Dictionary<string, string> process, Person role, Person otherEntety, Schedule schedule, List<Room> rooms)
        {
            return new Process(process, (Exhibitor)otherEntety, (Employee)role, schedule, rooms);
        }

    }
}