using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace MuseumForm
{
    public partial class AppForms : Form
    {
//        public static readonly string CreateAccountControl = nameof(MuseumForm.CreateAccountControl);
//        public static readonly string DashboardControl = nameof(MuseumForm.DashboardControl);
//        public static readonly string InitialControl = nameof(MuseumForm.InitialControl);
//        public static readonly string LoginControl = nameof(MuseumForm.LoginControl);
//        public static readonly string ScheduleControl = nameof(MuseumForm.ScheduleControl);
//        public static readonly string SettingsControl = nameof(MuseumForm.SettingsControl);
//        public static readonly string ExhibitionsControl = nameof(MuseumForm.ExhibitionsControl);
//        public static readonly string ForgotPasswordControl = nameof(MuseumForm.ForgotPasswordControl);
//        public static readonly string ProcessesExhibitorControl = nameof(MuseumForm.ProcessesExhibitorControl);
//        public static readonly string EditPriceControl = nameof(MuseumForm.EditPriceControl);
//        public static readonly string ProcessControl = nameof(MuseumForm.ProcessControl);
//        public static readonly string AddArtPieceControl = nameof(MuseumForm.AddArtPieceControl);
//        public static readonly string EditProcessControl = nameof(MuseumForm.EditProcessControl);
//        public static readonly string ProcessesEmployeeControl = nameof(MuseumForm.ProcessesEmployeeControl);
//        public static readonly string NewProcessControl = "NewProcess";
//        public static readonly string MessagesControl = nameof(MuseumForm.MessagesControl);
//        public static readonly string NewMessageControl = nameof(MuseumForm.NewMessageControl);
//        public static readonly string SingleMessageControl = nameof(MuseumForm.SingleMessageControl);
//        public static readonly string AddRoomControl = "AddRoom";
//        public static readonly string EmployeesControl = nameof(MuseumForm.EmployeesControl);
//        public static readonly string NewEmployeeControl = nameof(MuseumForm.NewEmployeeControl);
//        public static readonly string SingleEmployeeControl = nameof(MuseumForm.SingleEmployeeControl);

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

//        public const int WmNclbuttondown = 0xA1;
//        public const int HtCaption = 0x2;

//        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
//        public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);
//        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
//        public static extern bool ReleaseCapture();
//
//        public new void MouseDown(object sender, MouseEventArgs e)
//        {
//            if (e.Button != MouseButtons.Left) return;
//            ReleaseCapture();
//            SendMessage(Handle, WmNclbuttondown, HtCaption, 0);
//        }

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
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            Trace.WriteLine("Paint");
        }


    }
}