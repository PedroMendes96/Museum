using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Museum;

namespace MuseumForm
{
    public partial class ProcessTemplate : UserControl
    {
        public int InitialSize { get; set; }

        public ProcessTemplate()
        {
            InitializeComponent();
        }

        public IList<Process> Processes { get; set; } = new List<Process>();

        public void ResetProcesses()
        {
            GetContainer().Controls.Clear();
            Processes.Clear();
            ResetContainer();
        }

        public virtual void ResetContainer()
        {
        }

        public virtual Panel GetContainer()
        {
            return null;
        }

        public virtual void HideNextPreviousButtons()
        {
        }

        public virtual void ShowNextPreviousButtons()
        {
        }

        public void ListProcesses(int i)
        {
            var processesList = GetProcesses();
            Processes = processesList;

            Processes = Processes.OrderBy(o => o.LastUpdate).ToList();

            var maxPag = (int) Math.Ceiling((double) Processes.Count / 5);

            if (maxPag > 1)
                ShowNextPreviousButtons();
            else
                HideNextPreviousButtons();

            if (processesList.Count > 0)
            {
                var processContainer = GetContainer();
                var divisor = processesList.Count - (i - 1) * 5 > 5 ? 5 : processesList.Count - (i - 1) * 5;
                var containerSize = processContainer.Size;
                var pie = InitialSize / 5;

                if (divisor < 5)
                {
                    containerSize.Height = InitialSize - (5 - divisor) * pie;
                    processContainer.Size = containerSize;
                }
                else
                {
                    containerSize.Height = InitialSize;
                    processContainer.Size = containerSize;
                }

                var panelSize = containerSize.Height / divisor;
                var index = 0;

                if (ParentForm != null)
                {
                    var appForms = (MadeiraMuseum) ParentForm;
                    var dashboardControl = appForms.DashboardControl;
                    var role = dashboardControl.Role;

                    for (var j = (i - 1) * 5; j < (i - 1) * 5 + divisor; j++)
                    {
                        var selectedProcess = Processes[j];

                        var panel = new Panel
                        {
                            Dock = DockStyle.Top,
                            Location = new Point(0, 0),
                            Name = "process" + Processes[j],
                            BorderStyle = BorderStyle.FixedSingle,
                            Size = new Size(containerSize.Width, panelSize),
                            TabIndex = index
                        };

                        var processPanel = new Panel
                        {
                            Dock = DockStyle.Top,
                            Location = new Point(0, index * panelSize),
                            Name = "Process" + Processes[j],
                            Size = new Size(containerSize.Width, panelSize / 2),
                            AutoSize = false,
                            TabIndex = 0
                        };

                        var employeePanel = new Panel
                        {
                            Dock = DockStyle.Top,
                            Location = new Point(0, index * panelSize + panelSize / 2),
                            Name = "Employee" + Processes[j].Employee.Id,
                            Size = new Size(containerSize.Width, panelSize / 2),
                            AutoSize = false,
                            TabIndex = 1
                        };

                        var processLabel = new Label();
                        var employeeLabel = new Label();
                        processLabel.Dock = DockStyle.Fill;
                        processLabel.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold, GraphicsUnit.Point,
                            0);
                        processLabel.Location = new Point(0, index * panelSize);
                        processLabel.Name = @"ProcessNumber" + index;
                        processLabel.Size = new Size(containerSize.Width, panelSize / 2);
                        processLabel.TabIndex = 0;
                        processLabel.Text = @"ProcessNumber" + Processes[j].Id;
                        processLabel.Click += delegate { ClickPanel(selectedProcess); };
                        processLabel.MouseHover += delegate { HoverMouse(employeeLabel, processLabel); };
                        processLabel.MouseEnter += delegate { HoverMouse(employeeLabel, processLabel); };
                        processLabel.MouseLeave += delegate { LeaveMouse(employeeLabel, processLabel); };
                        processLabel.TextAlign = ContentAlignment.MiddleCenter;


                        employeeLabel.Dock = DockStyle.Fill;
                        employeeLabel.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold, GraphicsUnit.Point,
                            0);
                        employeeLabel.Location = new Point(0, index * panelSize);
                        employeeLabel.Name = "EmployeeNumber:" + Processes[j].Employee.Id;
                        employeeLabel.Size = new Size(containerSize.Width, panelSize / 2);
                        employeeLabel.TabIndex = 0;
                        employeeLabel.Click += delegate { ClickPanel(selectedProcess); };
                        employeeLabel.MouseHover += delegate { HoverMouse(employeeLabel, processLabel); };
                        employeeLabel.MouseEnter += delegate { HoverMouse(employeeLabel, processLabel); };
                        employeeLabel.MouseLeave += delegate { LeaveMouse(employeeLabel, processLabel); };
                        if (role.Equals(nameof(Employee)))
                            employeeLabel.Text = @"Exhibitor: " + Processes[j].Exhibitor.Name;
                        else
                            employeeLabel.Text = @"Employee: " + Processes[j].Employee.Name;
                        employeeLabel.TextAlign = ContentAlignment.MiddleCenter;

                        processPanel.Controls.Add(processLabel);
                        employeePanel.Controls.Add(employeeLabel);

                        panel.Controls.Add(processPanel);
                        panel.Controls.Add(employeePanel);
                        index++;
                        processContainer.Controls.Add(panel);
                    }
                }
            }
            else
            {
                ResetProcesses();
                Console.WriteLine(@"Falta preencher coisas!!!!");
            }
        }

        public void HoverMouse(Label first, Label second)
        {
            first.BackColor = Color.AntiqueWhite;
            second.BackColor = Color.AntiqueWhite;
            Cursor.Current = Cursors.Hand;
        }

        public void LeaveMouse(Label first, Label second)
        {
            first.BackColor = Color.BurlyWood;
            second.BackColor = Color.BurlyWood;
            Cursor.Current = Cursors.Default;
        }

        private void ClickPanel(Process process)
        {
            if (ParentForm != null)
            {
                var appForms = (MadeiraMuseum) ParentForm;
                var processControl = appForms.ProcessControl;
                processControl.Process = process;
                processControl.UpdateViewPerUser();
                processControl.BringToFront();
            }
        }

        public void Previous_Click(object sender, EventArgs e)
        {
            if (GetPage() != 1)
            {
                SetPage(GetPage() - 1);
                ResetProcesses();
                ListProcesses(GetPage());
            }
        }

        public void Next_Click(object sender, EventArgs e)
        {
            var maxPag = (int) Math.Ceiling((double) Processes.Count / 5);
            if (GetPage() != maxPag)
            {
                SetPage(GetPage() + 1);
                ResetProcesses();
                ListProcesses(GetPage());
            }
        }

        public virtual int GetPage()
        {
            return 0;
        }

        public virtual void SetPage(int number)
        {
        }

        public virtual Person GetPersonRole(int idPerson)
        {
            return null;
        }

        public virtual string GetProcessByPerson(int idPerson)
        {
            return null;
        }

        public virtual Person GetOtherPerson(DictionaryAdapter dictionaryAdapter)
        {
            return null;
        }

        public virtual Process CreateProcess(Dictionary<string, string> process, Person role, Person otherEntety,
            Schedule schedule, List<Room> rooms)
        {
            return null;
        }

        public List<Process> GetProcesses()
        {
            var processes = new List<Process>();

            if (ParentForm != null)
            {
                var appForms = (MadeiraMuseum) ParentForm;
                var dashboardControl = appForms.DashboardControl;

                var role = GetPersonRole(dashboardControl.Person.Id);

                var processesResult = DbQuery.GetProcessByPerson(GetProcessByPerson(role.RoleId()));

                if (processesResult != null)
                    foreach (var process in processesResult)
                    {
                        var processesAdapter = new DictionaryAdapter(process);

                        var roomsResult = DbQuery.GetAllRoomsByProcess(processesAdapter.GetValue("id"));

                        var itemsResult = DbQuery.GetAllItemsByProcess(processesAdapter.GetValue("id"));

                        var otherEntety = GetOtherPerson(processesAdapter);

                        var scheduleResult = DbQuery.GetSchedulesById(processesAdapter.GetValue("schedule_id"));

                        var schedule = new Schedule(scheduleResult[0]);

                        var rooms = new List<Room>();

                        foreach (var room in roomsResult)
                        {
                            var adapterRoom = new DictionaryAdapter(room);
                            var specRoomResult = DbQuery.GetAllRoomsById(adapterRoom.GetValue("rooms_id"));
                            var newRoom = new Room(specRoomResult[0]);
                            rooms.Add(newRoom);
                        }

                        var newProcesses = CreateProcess(process, role, otherEntety, schedule, rooms);
                        foreach (var item in itemsResult)
                        {
                            var adapter = new DictionaryAdapter(item);
                            var specificItem = GetSpecificItem(adapter.GetValue("items_id"));
                            newProcesses.DecorateWithArtPiece(specificItem);
                        }

                        processes.Add(newProcesses);
                    }
            }

            return processes;
        }

        public ArtPiece GetSpecificItem(string itemId)
        {
            var sculptureResult = DbQuery.GetSculptureByArtPieceId(itemId);
            var artPieceFactory = FactoryCreator.Instance.CreateFactory(FactoryCreator.ArtPieceFactory);

            if (sculptureResult.Count > 0)
                return (ArtPiece) artPieceFactory.ImportData(ArtpieceFactory.Sculpture, sculptureResult[0]);

            var paintingResult = DbQuery.GetPaintingByArtPieceId(itemId);

            if (paintingResult.Count > 0)
                return (ArtPiece) artPieceFactory.ImportData(ArtpieceFactory.Painting, paintingResult[0]);
            var photographiesResult = DbQuery.GetPhotographyByArtPieceId(itemId);
            if (photographiesResult.Count > 0)
                return (ArtPiece) artPieceFactory.ImportData(ArtpieceFactory.Photography, photographiesResult[0]);
            return null;
        }
    }
}