using System;
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
            ActualPage = 1;
        }

        public int ActualPage { get; set; } = 1;

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

        public void Previous_Click(object sender, EventArgs e)
        {
            if (ActualPage != 0)
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

        public override void ResetContainer()
        {
            var size = processContainer.Size;
            size.Height = 0;
            processContainer.Size = size;
        }

        public override Person GetOtherPerson(DictionaryAdapter dictionaryAdapter)
        {
            var personResult = Exhibitor.GetExhibitorByRoleId(dictionaryAdapter.GetValue("exhibitors_id"));
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