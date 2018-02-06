using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Museum;

namespace MuseumForm
{
    public partial class MadeiraMuseum : Form
    {
        public MadeiraMuseum()
        {
            InitializeComponent();
        }

        public CreateAccountControl CreateAccountControl { get; } =
            new CreateAccountControl {Location = new Point(0, 0)};

        public DashboardControl DashboardControl { get; } = new DashboardControl {Location = new Point(0, 0)};

        public InitialControl InitialControl { get; } = new InitialControl {Location = new Point(0, 0)};

        public LoginControl LoginControl { get; } = new LoginControl {Location = new Point(0, 0)};

        public ScheduleControl ScheduleControl { get; } = new ScheduleControl {Location = new Point(185, 0)};

        public SettingsControl SettingsControl { get; } = new SettingsControl {Location = new Point(185, 0)};

        public ExhibitionsControl ExhibitionsControl { get; } = new ExhibitionsControl {Location = new Point(185, 0)};

        public ForgotPasswordControl ForgotPasswordControl { get; } =
            new ForgotPasswordControl {Location = new Point(0, 0)};

        public ProcessesExhibitorControl ProcessesExhibitorControl { get; } =
            new ProcessesExhibitorControl {Location = new Point(185, 0)};

        public EditPriceControl EditPriceControl { get; } = new EditPriceControl {Location = new Point(185, 0)};

        public AddArtPieceControl AddArtPieceControl { get; } = new AddArtPieceControl {Location = new Point(185, 0)};

        public EditProcessControl EditProcessControl { get; } = new EditProcessControl {Location = new Point(185, 0)};

        public ProcessesEmployeeControl ProcessesEmployeeControl { get; } =
            new ProcessesEmployeeControl {Location = new Point(185, 0)};

        public NewProcessControl NewProcessControl { get; } = new NewProcessControl {Location = new Point(185, 0)};

        public ProcessControl ProcessControl { get; } = new ProcessControl {Location = new Point(185, 0)};

        public MessagesControl MessagesControl { get; } = new MessagesControl {Location = new Point(185, 0)};

        public NewMessageControl NewMessageControl { get; } = new NewMessageControl {Location = new Point(185, 0)};

        public SingleMessageControl SingleMessageControl { get; } =
            new SingleMessageControl {Location = new Point(185, 0)};

        public AddRoomControl AddRoomControl { get; } = new AddRoomControl {Location = new Point(185, 0)};

        public EmployeesControl EmployeesControl { get; } = new EmployeesControl {Location = new Point(185, 0)};

        public NewEmployeeControl NewEmployeeControl { get; } = new NewEmployeeControl {Location = new Point(185, 0)};

        public SingleEmployeeControl SingleEmployeeControl { get; } =
            new SingleEmployeeControl {Location = new Point(185, 0)};

        public ListOfArtPieces ListOfArtPieces { get; } = new ListOfArtPieces {Location = new Point(185, 0)};

        public AddPermanentControl AddPermanentControl { get; } =
            new AddPermanentControl {Location = new Point(185, 0)};

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
            var controls = new List<Control>();

            foreach (Control child in parent.Controls) controls.AddRange(GetSelfAndChildrenRecursive(child));

            controls.Add(parent);

            return controls;
        }

        private void initialControl1_Load_1(object sender, EventArgs e)
        {
            Controls.Add(ProcessControl);
            Controls.Add(ProcessesEmployeeControl);
            Controls.Add(EditProcessControl);
            Controls.Add(EditPriceControl);
            Controls.Add(CreateAccountControl);
            Controls.Add(ForgotPasswordControl);
            Controls.Add(DashboardControl);
            Controls.Add(InitialControl);
            Controls.Add(LoginControl);
            Controls.Add(ScheduleControl);
            Controls.Add(NewProcessControl);
            Controls.Add(SettingsControl);
            Controls.Add(ExhibitionsControl);
            Controls.Add(ProcessesExhibitorControl);
            Controls.Add(MessagesControl);
            Controls.Add(NewMessageControl);
            Controls.Add(SingleMessageControl);
            Controls.Add(AddArtPieceControl);
            Controls.Add(AddRoomControl);
            Controls.Add(EmployeesControl);
            Controls.Add(NewEmployeeControl);
            Controls.Add(SingleEmployeeControl);
            Controls.Add(ListOfArtPieces);
            Controls.Add(AddPermanentControl);

            var controlsList = GetSelfAndChildrenRecursive(this).ToList();

            foreach (var control in controlsList)
                if (control.GetType() == typeof(Button))
                    control.Cursor = Cursors.Hand;
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
//            Trace.WriteLine("Paint");
        }
    }
}