using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Museum;

namespace MuseumForm
{
    public partial class EmployeesControl : UserControl
    {
        private readonly IList<Label> _empTextList = new List<Label>();
        private IEnumerator<Employee> _empEnumerator;

        public EmployeesControl()
        {
            InitializeComponent();
        }

        public Label NotificationLabel { get; set; }

        public int CurrentPage { get; set; } = 1;

        public int TotalPages { get; set; }

        public IList<Employee> Employees { get; set; } = new List<Employee>();

        public void ShowNotification()
        {
            NotificationLabel.Visible = true;
            var timer = new Timer {Interval = 3000};
            timer.Tick += timer_Tick;
            timer.Enabled = true;
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            NotificationLabel.Visible = false;
        }

        public void GetEmployees()
        {
            var list = DbQuery.GetAllEmployeesOrderedByLastUpdate();
            Debug.WriteLine(list.Count);
            var personFactory = FactoryCreator.Instance.CreateFactory("PersonFactory");

            foreach (var demployee in list)
            {
                var daEmployee = new DictionaryAdapter(demployee);
                var personId = daEmployee.GetValue("persons_id");
                if (personId != null)
                {
                    var valueExists = false;
                    foreach (var emp in Employees)
                        if (emp.Id == int.Parse(personId))
                        {
                            valueExists = true; // ja existe, nao adiciona
                            if (emp.LastUpdateSalary == daEmployee.GetValue("empLastUpdate"))
                            {
                                //não altera pois já está o mais atualizado
                            }
                            else
                            {
                                emp.LastUpdateSalary =
                                    daEmployee.GetValue("empLastUpdate"); //atualiza o lastupdate na instância classe
                            }
                        }

                    if (!valueExists) //não existe logo adiciona à lista Employees
                    {
                        var employee = personFactory.ImportData("Employee", demployee);
                        Employees.Insert(0, (Employee) employee);
                    }
                }
            }

            Debug.WriteLine("emp count: " + Employees.Count);
        }

        public void ResetView() // função que volta a mostrar as mensagens inicialmente (da mais recente para a menos)
        {
            BringToFront();
            GetEmployees();
            TotalPages = GetTotalPages();
            _empEnumerator = Employees.GetEnumerator();
            CurrentPage = 1;
            UpdateText("initial");
        }


        public void ShowEmployees(string operation)
        {
            var c = 0;
            var nrEmp = Employees.Count;

            if (operation == "next" || operation == "initial")
            {
                if (_empEnumerator.Current == null) // caso inicial
                    _empEnumerator.MoveNext();
                if (nrEmp > 0)
                {
                    if (CurrentPage == TotalPages)
                        nrEmp = nrEmp - 5 * (TotalPages - 1);
                    else
                        nrEmp = 5;
                    EmptyTextFields();
                    while (c < nrEmp)
                    {
                        AddEmployee(c);
                        c++;
                        _empEnumerator.MoveNext();
                    }
                }
                else
                {
                    EmptyTextFields();
                    AddEmployee(0);
                }
            }
            else
            {
                var prevPage = CurrentPage + 1;
                var indexLastEmpShown = prevPage * 5 - 1;
                var empList = Employees;
                Debug.WriteLine("index of: " + indexLastEmpShown);
                _empEnumerator.Reset();
                while (_empEnumerator.Current != empList[indexLastEmpShown - 9])
                    _empEnumerator.MoveNext();

                Debug.WriteLine("totalpages:" + TotalPages + " nr_emps: " + nrEmp);
                Debug.WriteLine("currentpg: " + CurrentPage);
                if (nrEmp > 0)
                {
                    nrEmp = 5;
                    EmptyTextFields();
                    while (c < nrEmp)
                    {
                        AddEmployee(c);
                        Debug.WriteLine("emp displayed:" + c);
                        _empEnumerator.MoveNext();
                        c++;
                    }
                }
            }
        }

        public void AddEmployee(int c)
        {
            if (Employees.Count > 0)
            {
                var employee = _empEnumerator.Current;
                if (employee != null)
                {
                    var empLabel = AddEmployeeField(80 * c);

                    empLabel.AutoSize = false;
                    empLabel.BorderStyle = BorderStyle.FixedSingle;
                    empLabel.BackColor = Color.BurlyWood;
                    empLabel.Text = @"Employee: " + employee.Name + @" - " + employee.Mail + Environment.NewLine +
                                    @" lastUpdated: " + employee.LastUpdateSalary;


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

                    if (_empEnumerator.Current != null) Debug.WriteLine(_empEnumerator.Current.Id);
                }
            }
            else
            {
                var empLabel = AddEmployeeField(20 * 1); //Cria o campo no windows forms
                empLabel.AutoSize = false;
                empLabel.Font = new Font("Microsoft Sans Serif", 18F);
                empLabel.BackColor = Color.BurlyWood;
                empLabel.Text = @"No employees";
                empLabel.TextAlign = ContentAlignment.MiddleCenter;
                empLabel.Width = 625;
                empLabel.Height = 80;
            }
        }

        public Label AddEmployeeField(int y)
        {
            var empTextLabel = new Label
            {
                AutoSize = true,
                BackColor = Color.BurlyWood,
                Font = new Font("Microsoft Sans Serif", 14F),
                Location = new Point(133, 140 + y),
                Size = new Size(64, 20)
            };
            Controls.Add(empTextLabel);
            _empTextList.Add(empTextLabel);
            empTextLabel.BringToFront();
            return empTextLabel;
        }

        public void empLabel_Click(Person emp)
        {
            if (ParentForm != null)
            {
                var appForms = (MadeiraMuseum) ParentForm;
                var singleEmployeeControl = appForms.SingleEmployeeControl;
                singleEmployeeControl.Employee = (Employee) emp;
                singleEmployeeControl.ResetView();
            }
        }

        public int GetTotalPages()
        {
            var totalEmp = Employees.Count;
            int quantity;
            if (totalEmp == 0)
                quantity = 1;
            else
                quantity = (int) Math.Ceiling((double) totalEmp / 5);
            return quantity;
        }


        public void EmptyTextFields()
        {
            if (_empTextList != null)
            {
                var label = _empTextList.GetEnumerator();
                label.Reset();
                while (label.MoveNext()) label.Current?.Dispose(); //destroy os msgs texts
            }
        }

        public void UpdateText(string operation)
        {
            pageLabel.Text = CurrentPage.ToString();
            if (operation == "initial")
                ShowEmployees(operation);
            else if (operation == "next")
                ShowEmployees(operation);
            else
                ShowEmployees(operation);

            if (CurrentPage == TotalPages || TotalPages == 0)
                nextButton.Visible = false;
            else
                nextButton.Visible = true;

            backButton.Visible = CurrentPage != 1;
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
            if (ParentForm != null)
            {
                var appForms = (MadeiraMuseum) ParentForm;
                var newEmployeeControl = appForms.NewEmployeeControl;
                newEmployeeControl.ResetView();
            }
        }
    }
}