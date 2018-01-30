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
//            var exhibitorSQL =
//                "SELECT persons.id as persons_id, exhibitors.id as exhibitors_id, name, phone, password, mail FROM exhibitors,persons WHERE persons.id=" +
//                idPerson + " AND persons.id=exhibitors.persons_id";
            var exhibitorResult = Museum.Exhibitor.GetExhibitorByPersonId(idPerson.ToString());// DBConnection.Instance.Query(exhibitorSQL);

            var Exhibitor = (Exhibitor)FactoryCreator.Instance.CreateFactory(FactoryCreator.PersonFactory)
                .ImportData(PersonFactory.exhibitor, exhibitorResult[0]);

            return Exhibitor;
        }

        public override string GetProcessByPerson(int idPerson)
        {
            var processesSQL = "SELECT * FROM processes WHERE exhibitors_id=" + idPerson +
                               " ORDER BY lastUpdate DESC";
            return processesSQL;
        }

        public override Person GetOtherPerson(DictionaryAdapter dictionaryAdapter)
        {
//            var PersonRole =
//                "SELECT persons.id as persons_id, employees.id As employees_id, name, password, phone, mail FROM persons, employees" +
//                " WHERE persons_id=persons.id AND employees.id=" + dictionaryAdapter.GetValue("employees_id");
            var PersonResult = Museum.Employee.GetEmployeeByRoleId(dictionaryAdapter.GetValue("employees_id"));// DBConnection.Instance.Query(PersonRole);
            var Employee = (Employee)FactoryCreator.Instance.CreateFactory(FactoryCreator.PersonFactory)
                .ImportData(PersonFactory.employee, PersonResult[0]);
            return Employee;
        }

        public override Process CreateProcess(Dictionary<string, string> process, Person Role, Person OtherEntety, Schedule schedule, List<Room> rooms)
        {
            return new Process(process, (Exhibitor)Role, (Employee)OtherEntety, schedule, rooms);
        }

        private void newProcess_Click(object sender, EventArgs e)
        {
            var index = ParentForm.Controls.IndexOfKey(AppForms.newProcess_Control);
            ParentForm.Controls[index].BringToFront();
        }
    }
}