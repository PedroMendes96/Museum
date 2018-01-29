using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Museum;

namespace MuseumForm
{
    public partial class EmployeesControl : UserControl
    {
        public IEnumerator<Person> EmpEnumerator;
        private readonly IList<Label> empTextList = new List<Label>();
        private IList<Person> employees = new List<Person>();

        public IList<Person> Employees
        {
            get => employees;
            set => employees = value;
        }

        public EmployeesControl()
        {
            InitializeComponent();
        }

        public void getEmployees()
        {
            var db = DBConnection.Instance;
            string select =
                "SELECT persons.name AS name,persons.password AS password,persons.mail AS mail,persons.phone AS phone, persons.id AS persons_id,employees.id AS employees_id,employees.salary,employees.lastUpdate,employees.id FROM employees,persons WHERE persons.id = employees.persons_id";
            Debug.WriteLine(select);
            var list = db.Query(select);
            Debug.WriteLine(list.Count);
            IFactory personFactory = FactoryCreator.Instance.CreateFactory("PersonFactory");
            bool valueExists = false;

            foreach (var demployee in list)
            {
                var daEmployee = new DictionaryAdapter(demployee);
                if (Employees.Count > 0)
                {
                    foreach (var emp in Employees)
                    {
                        Debug.WriteLine("emp.Id: " + emp.Id + " , daemp id:" + daEmployee.GetValue("id"));
                        if (emp.Id == int.Parse(daEmployee.GetValue("id")))
                        {
                            valueExists = true;
                            // ja existe, nao adiciona
                        }
                    }
                    if (!valueExists)
                    {
                        var employee = personFactory.ImportData("Employee", demployee);
                        Employees.Add((Employee)employee);
                        valueExists = false;
                    }
                }
                else
                {
                    var employee = personFactory.ImportData("Employee", demployee);
                    Employees.Add((Employee)employee);
                }

            }
            Debug.WriteLine("emp count: " +Employees.Count);
        }
        public void ResetView() // função que volta a mostrar as mensagens inicialmente (da mais recente para a menos)
        {
            BringToFront();
            getEmployees();
            EmpEnumerator = Employees.GetEnumerator();
            showEmployees();
        }

        public void showEmployees()
        {
            var c = 0;
            if (EmpEnumerator.Current == null)// caso inicial
            {
                EmpEnumerator.MoveNext(); 
            }
            while (c < 5)
            {
                addEmployee(c);
                c++;
                EmpEnumerator.MoveNext();
            }

        }

        public void addEmployee(int c)
        {
            if (Employees.Count > 0)
            {
                var employee = EmpEnumerator.Current;
                if (employee != null)
                {
                    var empLabel = addEmployeeField(80 * c);

                    empLabel.AutoSize = false;
                    empLabel.BorderStyle = BorderStyle.FixedSingle;
                    empLabel.BackColor = Color.BurlyWood;
                    empLabel.Text = "Employee: " + employee.Name + " - " + employee.Mail;


                    empLabel.TextAlign = ContentAlignment.MiddleCenter;
                    empLabel.Width = 625;
                    empLabel.Height = 80;
                    empLabel.Click += delegate { empLabel_Click(employee); };
                    empLabel.MouseHover += delegate
                    {
                        empLabel.BackColor = Color.AntiqueWhite;
                        Cursor.Current = Cursors.Hand;
                    };
                    empLabel.MouseEnter += delegate
                    {
                        empLabel.BackColor = Color.AntiqueWhite;
                        Cursor.Current = Cursors.Hand;
                    };
                    empLabel.MouseLeave += delegate
                    {
                        empLabel.BackColor = Color.BurlyWood;
                        Cursor.Current = Cursors.Default;
                    };

                    Debug.WriteLine(EmpEnumerator.Current.Id);
                }
            }
            else
            {
                var empLabel = addEmployeeField(20 * 1); //Cria o campo no windows forms
                empLabel.AutoSize = false;
                empLabel.Font = new Font("Microsoft Sans Serif", 18F);
                empLabel.BackColor = Color.BurlyWood;
                empLabel.Text = "No employees";
                empLabel.TextAlign = ContentAlignment.MiddleCenter;
                empLabel.Width = 625;
                empLabel.Height = 80;
            }
        }
    
        public Label addEmployeeField(int y)
        {

            var empTextLabel = new Label();
            empTextLabel.AutoSize = true;
            empTextLabel.BackColor = Color.BurlyWood;
            empTextLabel.Font = new Font("Microsoft Sans Serif", 14F);
            empTextLabel.Location = new Point(133, 140 + y);
            empTextLabel.Size = new Size(64, 20);
            Controls.Add(empTextLabel);
            empTextList.Add(empTextLabel);
            empTextLabel.BringToFront();
            return empTextLabel;
        }

        public void empLabel_Click(Person emp)
        {
            
        }

        public void EmptyTextFields()
        {
            var label = empTextList.GetEnumerator();
            label.Reset();
            while (label.MoveNext())
            {
                Debug.WriteLine(label.Current.Text);

                label.Current.Dispose(); //destroy os msgs texts
            }
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            EmptyTextFields();
            showEmployees();
        }
    }
}
