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
        private IEnumerator<Employee> EmpEnumerator;
        private readonly IList<Label> empTextList = new List<Label>();
        private IList<Employee> employees = new List<Employee>();


        public int CurrentPage { get; set; } = 1;

        public int TotalPages { get; set; }

        public IList<Employee> Employees
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

            var list = Employee.GetAllEmployeesOrderedByLastUpdate();
            Debug.WriteLine(list.Count);
            IFactory personFactory = FactoryCreator.Instance.CreateFactory("PersonFactory");
            bool valueExists = false;

            foreach (var demployee in list)
            {
                var daEmployee = new DictionaryAdapter(demployee);
                var person_id = daEmployee.GetValue("persons_id");
                if (person_id != null)
                {
                    valueExists = false;
                    foreach (var emp in Employees)
                    {
                        if (emp.Id == int.Parse(person_id))
                        {
                            valueExists = true;// ja existe, nao adiciona
                            if (emp.LastUpdateSalary == daEmployee.GetValue("empLastUpdate"))
                            {
                                //não altera pois já está o mais atualizado
                            }
                            else
                            {
                                emp.LastUpdateSalary = daEmployee.GetValue("empLastUpdate"); //atualiza o lastupdate na instância classe
                            }
                                            
                        }
                    }
                    if (!valueExists) //não existe logo adiciona à lista Employees
                    {
                        var employee = personFactory.ImportData("Employee", demployee);
                        Employees.Insert(0,(Employee)employee);
                    }
                }
            }
            Debug.WriteLine("emp count: " +Employees.Count);
        }
        public void ResetView() // função que volta a mostrar as mensagens inicialmente (da mais recente para a menos)
        {
            BringToFront();
            getEmployees(); 
            TotalPages = GetTotalPages();
            EmpEnumerator = Employees.GetEnumerator();
            CurrentPage = 1;
            UpdateText("initial");
        }
 

        public void showEmployees(string operation)
        {
            int c = 0;
            var nr_emp = Employees.Count;

            if (operation == "next" || operation == "initial")
            {
                if (EmpEnumerator.Current == null) // caso inicial
                {
                    EmpEnumerator.MoveNext();
                }
                if (nr_emp > 0)
                {
                    if (CurrentPage == TotalPages)
                    {
                        nr_emp = nr_emp - 5 * (TotalPages - 1);
                    }
                    else
                    {
                        nr_emp = 5;
                    }
                    EmptyTextFields();
                    while (c < nr_emp)
                    {
                        addEmployee(c);
                        c++;
                        EmpEnumerator.MoveNext();
                    }
                }
                else
                {
                    EmptyTextFields();
                    addEmployee(0);
                }


            } else
            {
                var PrevPage = CurrentPage + 1;
                var indexLastEmpShown = 0;
                indexLastEmpShown = PrevPage * 5 - 1;
                var empList = Employees;
                Debug.WriteLine("index of: " + indexLastEmpShown);
                EmpEnumerator.Reset();
                while (EmpEnumerator.Current != empList[indexLastEmpShown - 9])
                    EmpEnumerator.MoveNext();

                Debug.WriteLine("totalpages:" + TotalPages + " nr_emps: " + nr_emp);
                Debug.WriteLine("currentpg: " + CurrentPage);
                if (nr_emp > 0)
                {
                    nr_emp = 5;
                    EmptyTextFields();
                    while (c < nr_emp)
                    {
                        addEmployee(c);
                        Debug.WriteLine("emp displayed:" + c);
                        EmpEnumerator.MoveNext();
                        c++;
                    }
                }
            }
        }

        public void addEmployee(int c)
        {
            if (Employees.Count > 0)
            {
                var employee =(Employee)EmpEnumerator.Current;
                if (employee != null)
                {
                    var empLabel = addEmployeeField(80 * c);

                    empLabel.AutoSize = false;
                    empLabel.BorderStyle = BorderStyle.FixedSingle;
                    empLabel.BackColor = Color.BurlyWood;
                    empLabel.Text = "Employee: " + employee.Name + " - " + employee.Mail + Environment.NewLine + " lastUpdated: " +employee.LastUpdateSalary;


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
            var index = ParentForm.Controls.IndexOfKey(AppForms.singleEmployee_Control);
            var singleEmployeeControl = (SingleEmployeeControl)ParentForm.Controls[index];
            singleEmployeeControl.Employee = (Employee)emp;
            singleEmployeeControl.ResetView();
        }

        public int GetTotalPages()
        {
            var totalEmp = Employees.Count;
            var quantity = 1;
            if (totalEmp == 0)
            {
                quantity = 1;
            }
            else
            {
                quantity = (int) Math.Ceiling((double) totalEmp / 5);
            }
            return quantity;
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

        public void UpdateText(string operation)
        {
            pageLabel.Text = CurrentPage.ToString();
            if (operation == "initial")
                showEmployees(operation);
            else if (operation == "next")
               showEmployees(operation);
            else
               showEmployees(operation);

            if (CurrentPage == TotalPages || TotalPages == 0)
                nextButton.Visible = false;
            else
                nextButton.Visible = true;

            if (CurrentPage == 1)
                backButton.Visible = false;
            else
                backButton.Visible = true;
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            if (CurrentPage <= TotalPages)
            {
                CurrentPage++;
                UpdateText("next");
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            if (CurrentPage == 1)
            {
                //nao pode fazer back
            }
            else
            {
                CurrentPage--;
                UpdateText("back");
            }
        }

        private void addEmpButton_Click(object sender, EventArgs e)
        {
            var index = ParentForm.Controls.IndexOfKey(AppForms.newEmployee_Control);
            var newEmployeeControl = (NewEmployeeControl)ParentForm.Controls[index];
            newEmployeeControl.ResetView();
        }
    }
}
