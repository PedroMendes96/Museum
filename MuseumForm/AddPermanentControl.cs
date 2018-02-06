using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Museum;

namespace MuseumForm
{
    public partial class AddPermanentControl : UserControl
    {
        private readonly List<int> _roomsIdList = new List<int>();

        public AddPermanentControl()
        {
            InitializeComponent();
        }

        public void ListRooms()
        {
            comboBoxRooms.Items.Clear();
            var roomsList = DbQuery.GetAllRooms();
            if (roomsList != null)
                foreach (var room in roomsList)
                {
                    var dictionaryAdapter = new DictionaryAdapter(room);
                    var comboItem = new ComboboxItem
                    {
                        Text = "Room " + dictionaryAdapter.GetValue("id"),
                        Value = int.Parse(dictionaryAdapter.GetValue("id"))
                    };
                    comboBoxRooms.Items.Add(comboItem);
                }
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            if (CheckFields())
            {
                if (_roomsIdList.Count > 0)
                {
                    var eventsFactory = FactoryCreator.Instance.CreateFactory(FactoryCreator.ExhibitionFactory);
                    var permanent = (Permanent) eventsFactory.Create(ExhibitionFactory.Permanent);
                    permanent.Name = textBoxName.Text;
                    permanent.Description = textBoxDescription.Text;
                    permanent.Title = textBoxTitle.Text;
                    permanent.IdRooms = _roomsIdList;
                    permanent.Save();
                    ClearFields();


                    var myTimer = new Timer {Interval = 1000};
                    Information.Text = @"The permanent event was inserted sucessfully!";
                    Information.Visible = true;
                    myTimer.Tick += HideSucess;
                    myTimer.Start();
                    _roomsIdList.Clear();
                }
                else
                {
                    var myTimer = new Timer {Interval = 1000};
                    InvalidValue.Text = @"You add atleast one room!";
                    InvalidValue.Visible = true;
                    myTimer.Tick += HideFail;
                    myTimer.Start();
                }
            }
            else
            {
                var myTimer = new Timer {Interval = 1000};
                InvalidValue.Text = @"You must fill all the fields!";
                InvalidValue.Visible = true;
                myTimer.Tick += HideFail;
                myTimer.Start();
            }
        }

        private void ClearFields()
        {
            textBoxName.Text = "";
            textBoxDescription.Text = "";
            textBoxTitle.Text = "";
        }

        private bool CheckFields()
        {
            var result = !(textBoxName.Text.Trim().Equals("")
                           || textBoxDescription.Text.Trim().Equals("") || textBoxTitle.Text.Trim().Equals(""));

            return result;
        }

        private void HideSucess(object sender, EventArgs e)
        {
            Information.Visible = false;
            var timer = (Timer) sender;
            timer.Enabled = false;
        }

        private void HideFail(object sender, EventArgs e)
        {
            InvalidValue.Visible = false;
            var timer = (Timer) sender;
            timer.Enabled = false;
        }

        private void addButtonRoom_Click(object sender, EventArgs e)
        {
            var myTimer = new Timer {Interval = 1000};
            var value = comboBoxRooms.Text;
            if (!value.Trim().Equals(""))
            {
                var split = value.Split(' ');
                var id = int.Parse(split[1]);
                if (!CheckExistence(_roomsIdList, id))
                {
                    _roomsIdList.Add(id);
                    Information.Text = @"You insert the room " + id;
                    Information.Visible = true;
                    myTimer.Tick += HideSucess;
                }
                else
                {
                    InvalidValue.Text = @"You tried to insert again the room " + id;
                    InvalidValue.Visible = true;
                    myTimer.Tick += HideFail;
                }

                myTimer.Start();
            }
        }

        private bool CheckExistence(IEnumerable<int> list, int value)
        {
            return list.Any(item => item == value);
        }
    }
}