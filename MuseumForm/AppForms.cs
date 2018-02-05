using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MuseumForm
{
    public partial class AppForms : Form
    {
        private readonly CreateAccountControl _createAccountControl = new CreateAccountControl { Location = new Point(0, 0) };

        private readonly DashboardControl _dashboardControl = new DashboardControl { Location = new Point(0, 0) };

        private readonly InitialControl _initialControl = new InitialControl { Location = new Point(0, 0) };

        private readonly LoginControl _loginControl = new LoginControl { Location = new Point(0, 0) };

        private readonly ScheduleControl _scheduleControl = new ScheduleControl { Location = new Point(185, 0) };

        private readonly SettingsControl _settingsControl = new SettingsControl { Location = new Point(185, 0) };

        private readonly ExhibitionsControl _exhibitionsControl = new ExhibitionsControl { Location = new Point(185, 0) };

        private readonly ForgotPasswordControl _forgotPasswordControl = new ForgotPasswordControl { Location = new Point(0, 0) };

        private readonly ProcessesExhibitorControl _processesExhibitorControl = new ProcessesExhibitorControl { Location = new Point(185, 0) };

        private readonly EditPriceControl _editPriceControl = new EditPriceControl { Location = new Point(185, 0) };

        private readonly AddArtPieceControl _addArtPieceControl = new AddArtPieceControl { Location = new Point(185, 0) };

        private readonly EditProcessControl _editProcessControl = new EditProcessControl { Location = new Point(185, 0) };

        private readonly ProcessesEmployeeControl _processesEmployeeControl = new ProcessesEmployeeControl { Location = new Point(185, 0) };

        private readonly NewProcessControl _newProcessControl = new NewProcessControl { Location = new Point(185, 0) };

        private readonly ProcessControl _processControl = new ProcessControl { Location = new Point(185, 0) };

        private readonly MessagesControl _messagesControl = new MessagesControl { Location = new Point(185, 0) };

        private readonly NewMessageControl _newMessageControl = new NewMessageControl { Location = new Point(185, 0) };

        private readonly SingleMessageControl _singleMessageControl = new SingleMessageControl { Location = new Point(185, 0) };

        private readonly AddRoomControl _addRoomControl = new AddRoomControl { Location = new Point(185, 0) };

        private readonly EmployeesControl _employeesControl = new EmployeesControl { Location = new Point(185, 0) };

        private readonly NewEmployeeControl _newEmployeeControl = new NewEmployeeControl { Location = new Point(185, 0) };

        private readonly SingleEmployeeControl _singleEmployeeControl = new SingleEmployeeControl { Location = new Point(185, 0) };

        private readonly ListOfArtPieces _listOfArtPieces = new ListOfArtPieces() { Location = new Point(185, 0) };

        private readonly AddPermanentControl _addPermanentControl = new AddPermanentControl() { Location = new Point(185, 0) };

        public CreateAccountControl CreateAccountControl => _createAccountControl;
        public DashboardControl DashboardControl => _dashboardControl;
        public InitialControl InitialControl => _initialControl;
        public LoginControl LoginControl => _loginControl;
        public ScheduleControl ScheduleControl => _scheduleControl;
        public SettingsControl SettingsControl => _settingsControl;
        public ExhibitionsControl ExhibitionsControl => _exhibitionsControl;
        public ForgotPasswordControl ForgotPasswordControl => _forgotPasswordControl;
        public ProcessesExhibitorControl ProcessesExhibitorControl => _processesExhibitorControl;
        public EditPriceControl EditPriceControl => _editPriceControl;
        public AddArtPieceControl AddArtPieceControl => _addArtPieceControl;
        public EditProcessControl EditProcessControl => _editProcessControl;
        public ProcessesEmployeeControl ProcessesEmployeeControl => _processesEmployeeControl;
        public NewProcessControl NewProcessControl => _newProcessControl;
        public ProcessControl ProcessControl => _processControl;
        public MessagesControl MessagesControl => _messagesControl;
        public NewMessageControl NewMessageControl => _newMessageControl;
        public SingleMessageControl SingleMessageControl => _singleMessageControl;
        public AddRoomControl AddRoomControl => _addRoomControl;
        public EmployeesControl EmployeesControl => _employeesControl;
        public NewEmployeeControl NewEmployeeControl => _newEmployeeControl;
        public SingleEmployeeControl SingleEmployeeControl => _singleEmployeeControl;
        public ListOfArtPieces ListOfArtPieces => _listOfArtPieces;
        public AddPermanentControl AddPermanentControl => _addPermanentControl;

        public AppForms()
        {
            InitializeComponent();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        public IEnumerable<Control> GetSelfAndChildrenRecursive(Control parent)
        {
            List<Control> controls = new List<Control>();

            foreach (Control child in parent.Controls)
            {
                controls.AddRange(GetSelfAndChildrenRecursive(child));
            }

            controls.Add(parent);

            return controls;
        }

        private void initialControl1_Load_1(object sender, EventArgs e)
        { 
            Controls.Add(_processControl);
            Controls.Add(_processesEmployeeControl);
            Controls.Add(_editProcessControl);
            Controls.Add(_editPriceControl);
            Controls.Add(_createAccountControl);
            Controls.Add(_forgotPasswordControl);
            Controls.Add(_dashboardControl);
            Controls.Add(_initialControl);
            Controls.Add(_loginControl);
            Controls.Add(_scheduleControl);
            Controls.Add(_newProcessControl);
            Controls.Add(_settingsControl);
            Controls.Add(_exhibitionsControl);
            Controls.Add(_processesExhibitorControl);
            Controls.Add(_messagesControl);
            Controls.Add(_newMessageControl);
            Controls.Add(_singleMessageControl);
            Controls.Add(_addArtPieceControl);
            Controls.Add(_addRoomControl);
            Controls.Add(_employeesControl);
            Controls.Add(_newEmployeeControl);
            Controls.Add(_singleEmployeeControl);
            Controls.Add(_listOfArtPieces);
            Controls.Add(_addPermanentControl);

             var controlsList = GetSelfAndChildrenRecursive(this).ToList();

            foreach (var control in controlsList)
            {
                if (control.GetType() == typeof(Button))
                {
                    control.Cursor = Cursors.Hand;
                }
            }
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            Trace.WriteLine("Paint");
        }


    }
}