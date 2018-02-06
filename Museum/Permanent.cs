using System;
using System.Collections.Generic;

namespace Museum
{
    public class Permanent : Events
    {
        public int PermanentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public IList<int> IdRooms { get; set; }

        public Permanent()
        {
        }

        public Permanent(Dictionary<string, string> dictionary)
        {
        }

        private bool CheckRoomAvailability()
        {
            foreach (var specificId in IdRooms)
            {
                var isRoomOcuppiedResult = DbQuery.GetAllRoomsByRoom(specificId.ToString());
                if (isRoomOcuppiedResult.Count > 0) return false;
            }

            return true;
        }

        public override void Save()
        {
            if (CheckRoomAvailability())
            {
                Id = DbQuery.InsertEvent(Description, Name, Title);
                PermanentId = DbQuery.InsertPermanent(Id.ToString());

                foreach (var idRoom in IdRooms)
                {
                    DbQuery.AssociateRoomEvent(Id.ToString(), idRoom.ToString());
                }
            }
        }

        public override void Update(string changeProperties, string changeValues, string table)
        {
            var properties = changeProperties.Split('-');
            var values = changeValues.Split('-');
            var error = false;
            foreach (var property in properties)
                if (table == Event)
                {
                    if (property != DescriptionProperty) error = true;
                }
                else if (table == Permanent)
                {
                    error = true;
                }
                else
                {
                    error = true;
                }

            if (error)
                Console.WriteLine(@"Falta preencher coisas!!!!");
            else
                DbQuery.UpdateSequence(Id,table, properties, values);
        }
    }
}