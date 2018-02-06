using System.Collections.Generic;

namespace Museum
{
    public class DbQuery
    {
        public static readonly string NameProperty = "name";
        public static readonly string PasswordProperty = "password";
        public static readonly string PhoneProperty = "phone";
        public static readonly string MailProperty = "mail";
        public static readonly string Itself = "persons";
        public static readonly string Exhibitor = "exhibitors";
        public static readonly string Employee = "employees";
        public static readonly string SalaryProperty = "salary";
        public static readonly string TypeProperty = "type";
        public static readonly string ContentProperty = "content";
        public static readonly string TitleProperty = "title";
        public static readonly string DescriptionProperty = "description";
        public static readonly string RoomProperty = "room";
        public static readonly string Items = "items";
        public static readonly string Paitings = "paitings";
        public static readonly string Photographies = "photographies";
        public static readonly string Sculptures = "sculptures";
        public static readonly string PriceProperty = "price";
        public static readonly string ResultProperty = "result";
        public static readonly string ActiveProperty = "active";
        public static readonly string ScheduleProperty = "schedule_id";
        public static readonly string SizeProperty = "size";
        public static readonly string EventProperty = "events_id";
        public static readonly string StartDayProperty = "startDay";
        public static readonly string StartMonthProperty = "startMonth";
        public static readonly string StartYearProperty = "startYear";
        public static readonly string EndDayProperty = "endDay";
        public static readonly string EndMonthProperty = "endMonth";
        public static readonly string EndYearProperty = "endYear";
        public static readonly string StartTimeProperty = "startTime";
        public static readonly string EndTimeProperty = "endTime";
        public static readonly string VolumeProperty = "volume";

        private const string AllAttributes = "*";
        private const string Id = "id";
        private const string ImageProperty = "img";
        private const string ItemsHasProcess = "items_has_processes";
        private const string RoomsHasEvents = "rooms_has_events";
        private const string PersonsHasMessages = "persons_has_messages";
        private const string ProcessesHasRooms = "processes_has_rooms";
        private const string ProcessesId = "processes_id";
        private const string ItemsId = "items_id";
        private const string RoomsId = "rooms_id";
        private const string MessagesId = "messages_id";
        private const string True = "true";
        private const string EventsId = "events_id";
        private const string PersonsId = "persons_id";
        private const string ScheduleId = "schedule_id";
        private const string EmployeesId = "employees_id";
        private const string SenderId = "sender_id";
        private const string ExhibitorsId = "exhibitors_id";
        private const string Temporaries = "temporaries";
        private const string Persons = "persons";
        private const string Rooms = "rooms";
        private const string Schedules = "schedules";
        private const string Events = "events";
        private const string Permanents = "permanents";
        private const string Processes = "processes";
        private const string Messages = "messages";
        private const string LastUpdate = "lastUpdate";


        public static IList<Dictionary<string, string>> GetAllItemsByProcess(string idProcess)
        {
            var selected = new[] { AllAttributes };
            var table = new[] { ItemsHasProcess };
            var properties = new[] { ProcessesId };
            var values = new[] { idProcess };
            return SelectSequence(selected, table, properties, values);
//            var query = SqlOperations.Instance.Select(selected, table, properties, values);
//            return DbConnection.Instance.Query(query);
        }

        public static void AssociateItemProcess(int processId, int itemId)
        {
            var table = ItemsHasProcess;
            var properties = new [] { ItemsId , ProcessesId };
            var values = new[] { itemId.ToString(), processId.ToString() };
            ExecuteSequence(table, properties, values);
//            var artPieceProcess = SqlOperations.Instance.Insert(table, properties, values);
//            DbConnection.Instance.Execute(artPieceProcess);
        }

        public static void AssociateRoomEvent(string eventId, string itemId)
        {
            var table = RoomsHasEvents;
            var properties = new[] { RoomsId, EventsId };
            var values = new[] { itemId, eventId };
            ExecuteSequence(table, properties, values);
//            var sql = SqlOperations.Instance.Insert(table, properties, values);
//            DbConnection.Instance.Execute(sql);
        }

        public static IList<Dictionary<string, string>> GetEmployeeByRoleId(string id)
        {
            var personRole =
                "SELECT persons.id as persons_id, employees.id As employees_id, name, password, phone, mail FROM persons, employees" +
                " WHERE persons_id=persons.id AND employees.id=" + id;
            return DbConnection.Instance.Query(personRole);
        }

        public static IList<Dictionary<string, string>> GetEmployeeByPersonId(string id)
        {
            var query =
                "SELECT persons.id as persons_id, employees.id As employees_id, name, password, phone, mail FROM persons, employees" +
                " WHERE persons_id=persons.id AND persons.id=" + id;
            return DbConnection.Instance.Query(query);
        }

        public static IList<Dictionary<string, string>> GetAllEmployees()
        {
            var properties = new[] { AllAttributes };
            var tables = new[] { Employee };
            return SelectSequence(properties, tables);
//            var allEmployee = "SELECT * FROM employees";
//            return DbConnection.Instance.Query(allEmployee);
        }

        public static IList<Dictionary<string, string>> GetAllEmployeesOrderedByLastUpdate()
        {
            var select =
                "SELECT persons.name AS name,persons.password AS password,persons.mail AS mail,persons.phone AS phone, persons.id AS persons_id,employees.id AS employees_id,employees.salary AS salary,employees.lastUpdate AS empLastUpdate FROM employees,persons WHERE persons.id = employees.persons_id ORDER BY empLastUpdate ASC";
            return DbConnection.Instance.Query(select);
        }

        public static IList<Dictionary<string, string>> GetAllEmployeesByRoleId(string id)
        {
            var employeeSql = "SELECT persons.id as persons_id, employees.id as employees_id," +
                              "name,password,phone,mail FROM persons,employees WHERE " +
                              "employees.persons_id=persons.id and employees.id=" + id;

            return DbConnection.Instance.Query(employeeSql);
        }

        public static int InsertPerson(string password,string name,string phone, string mail)
        {
            var table = Persons;
            var keys = new[] { PasswordProperty, NameProperty, PhoneProperty, MailProperty };
            var values = new[] { password, name, phone, mail };
            return ExecuteSequence(table, keys, values);
            //            var insertPersons = SqlOperations.Instance.Insert(table, keys, values);
            //            Console.WriteLine(insertPersons);
            //            return DbConnection.Instance.Execute(insertPersons);
        }

        public static int InsertEmployee(string salary, string id)
        {
            var table = Employee;
            var keys = new[] { SalaryProperty, PersonsId };
            var values = new[] { salary, id };
            return ExecuteSequence(table, keys, values);
            //            var insertEmployees = SqlOperations.Instance.Insert(table, keys, values);
            //            Console.WriteLine(insertEmployees);
            //            return DbConnection.Instance.Execute(insertEmployees);
        }

        public static int InsertExhibitor(string type, string id)
        {
            var table = Exhibitor;
            var keys = new[] { TypeProperty, Persons };
            var values = new[] { type, id };
            return ExecuteSequence(table, keys, values);
            //            var insertExhibitors = SqlOperations.Instance.Insert(table, keys, values);
            //            Console.WriteLine(insertExhibitors);
            //            return DbConnection.Instance.Execute(insertExhibitors);
        }

        public static IList<Dictionary<string, string>> GetAllEventsOrderedByLast()
        {
            var exhibitions = "SELECT * FROM events ORDER BY lastUpdate DESC";
            return DbConnection.Instance.Query(exhibitions);
        }

        public static IList<Dictionary<string, string>> GetEventsByRoom(string id)
        {
            var properties = new[] { AllAttributes };
            var tables = new[] { RoomsHasEvents };
            var keys = new[] { RoomsId };
            var values = new[] { id };
            return SelectSequence(properties, tables, keys, values);
//            var eventsSql = SqlOperations.Instance.Select(properties, tables, keys, values);
//            return DbConnection.Instance.Query(eventsSql);
        }

        public static IList<Dictionary<string, string>> GetExhibitorByPersonId(string id)
        {
            var sel = "SELECT persons.id as persons_id, exhibitors.id as exhibitors_id," +
                      "name,password,phone,mail,type FROM persons,exhibitors WHERE " +
                      "exhibitors.persons_id=persons.id and persons.id=" + id;
            return DbConnection.Instance.Query(sel);
        }

        public static IList<Dictionary<string, string>> GetExhibitorByRoleId(string id)
        {
            var personRole =
                "SELECT persons.id as persons_id, exhibitors.id AS exhibitors_id, name, password, phone, mail, type FROM persons, exhibitors" +
                " WHERE persons_id=persons.id AND exhibitors.id=" + id;
            return DbConnection.Instance.Query(personRole);
        }

        public static IList<Dictionary<string, string>> GetExhibitorsById(string id)
        {
            var properties = new[] { AllAttributes };
            var tables = new[] { Exhibitor };
            var keys = new[] { Id };
            var values = new[] { id };
            return SelectSequence(properties, tables, keys, values);
//            var exhibitorSql = "SELECT * FROM exhibitors WHERE id=" + id;
//            return DbConnection.Instance.Query(exhibitorSql);
        }

        public static IList<Dictionary<string, string>> GetMessageLastUpdate(string id)
        {
            var selvals = new[] { LastUpdate };
            var tables = new[] { Messages };
            var keys = new[] { Id };
            var values = new[] { id };
            return SelectSequence(selvals, tables, keys, values);
//            var select = SqlOperations.Instance.Select(selvals, tables, keys, values);
//            return DbConnection.Instance.Query(select);
        }

        public static IList<Dictionary<string, string>> GetPermanentsInEvents(string id)
        {
            var isPermanent = "SELECT title,name,description FROM permanents,events WHERE events.id=" +
                              id + " AND events.id=permanents.events_id";
            return DbConnection.Instance.Query(isPermanent);
        }

        public static IList<Dictionary<string, string>> GetAllPermanents()
        {
            var properties = new[] { AllAttributes };
            var table = new[] { Permanents };
            return SelectSequence(properties, table);
//            var permanentEvents = SqlOperations.Instance.Select(properties, table);
//            return DbConnection.Instance.Query(permanentEvents);
        }

        public static IList<Dictionary<string, string>> GetAllPeople()
        {
            var properties = new[] { AllAttributes };
            var tables = new[] { Persons };
            return SelectSequence(properties, tables);
//            var selQuery = "SELECT * FROM persons";
//            return DbConnection.Instance.Query(selQuery);
        }

        public static IList<Dictionary<string, string>> GetPeopleById(string id)
        {
            var properties = new[] { AllAttributes };
            var tables = new[] { Persons };
            var keys = new[] { Id };
            var values = new[] { id };
            return SelectSequence(properties, tables, keys, values);
//            var personSql = "SELECT * FROM persons WHERE id=" + id;
//            return DbConnection.Instance.Query(personSql);
        }

        public static IList<Dictionary<string, string>> GetPeopleByMail(string mail)
        {
            var properties = new[] { AllAttributes };
            var tables = new[] { Persons };
            var keys = new[] { MailProperty };
            var values = new[] { mail };
            return SelectSequence(properties, tables, keys, values);
//            var personSql = SqlOperations.Instance.Select(properties, tables, keys, values);
//            return DbConnection.Instance.Query(personSql);
        }

        public static int UpdatePersonPassword(string id, string newPassword)
        {
            var table = Persons;
            var keys = new[] { PasswordProperty };
            var values = new[] { newPassword };
            return UpdateSequence(int.Parse(id), table, keys, values);
//            var updatePersonSql = SqlOperations.Instance.Update(int.Parse(id), table, keys, values);
//            return DbConnection.Instance.Execute(updatePersonSql);
        }

        public static IList<Dictionary<string, string>> GetProcessesById(string id)
        {
            var properties = new[] { AllAttributes };
            var tables = new[] { Processes };
            var keys = new[] { Id };
            var values = new[] { id };
            return SelectSequence(properties, tables, keys, values);
//            var processesSql = "SELECT * FROM processes WHERE id=" + id;
//            return DbConnection.Instance.Query(processesSql);
        }

        public static IList<Dictionary<string, string>> GetProcessesByEmployeeIdandActive(string id)
        {
            var properties = new[] { AllAttributes };
            var tables = new[] { Processes };
            var keys = new[] { ActiveProperty,EmployeesId };
            var values = new[] { True,id };
            return SelectSequence(properties, tables, keys, values);
//            var processes = "SELECT * FROM processes WHERE active=true and employees_id=" + id;
//            return DbConnection.Instance.Query(processes);
        }

        public static IList<Dictionary<string, string>> GetProcessByScheduleId(string id)
        {
            var properties = new[] { AllAttributes };
            var tables = new[] { Processes };
            var keys = new[] { ScheduleId };
            var values = new[] { id };
            return SelectSequence(properties, tables, keys, values);
//            var processEvent = "SELECT title,name FROM processes WHERE schedule_id=" + id;
//            return DbConnection.Instance.Query(processEvent);
        }

        public static IList<Dictionary<string, string>> GetAllRooms()
        {
            var attr = new[] { Id };
            var tables = new[] { Rooms };
            return SelectSequence(attr, tables);
//            var roomsSql = SqlOperations.Instance.Select(attr, tables);
//            Console.WriteLine(roomsSql);
//            return DbConnection.Instance.Query(roomsSql);
        }

        public static IList<Dictionary<string, string>> GetAllRoomsByProcess(string id)
        {
            var properties = new[] { AllAttributes };
            var tables = new[] { ProcessesHasRooms };
            var keys = new[] { ProcessesId };
            var values = new[] { id };
            return SelectSequence(properties, tables, keys, values);
//            var roomsSql = "SELECT * FROM processes_has_rooms WHERE processes_id=" + id;
//            return DbConnection.Instance.Query(roomsSql);
        }

        public static IList<Dictionary<string, string>> GetAllRoomsByRoom(string id)
        {
            var properties = new[] { AllAttributes };
            var tables = new[] { ProcessesHasRooms };
            var keys = new[] { RoomsId };
            var values = new[] { id };
            return SelectSequence(properties, tables, keys, values);
//            var roomsSql = "SELECT * FROM processes_has_rooms WHERE rooms_id=" + id;
//            return DbConnection.Instance.Query(roomsSql);
        }

        public static IList<Dictionary<string, string>> GetAllRoomsById(string id)
        {
            var properties = new[] { AllAttributes };
            var tables = new[] { Rooms };
            var keys = new[] { Id };
            var values = new[] { id };
            return SelectSequence(properties, tables, keys, values);
//            var specRoom = "SELECT * FROM rooms WHERE id=" + id;
//            return DbConnection.Instance.Query(specRoom);
        }

        public static IList<Dictionary<string, string>> GetAllRoomsByIds(List<int> ids)
        {
            var roomsSQl = "SELECT * FROM rooms WHERE ";

            for (var i = 0; i < ids.Count; i++)
                if (i == ids.Count - 1)
                    roomsSQl += "id=" + ids[i];
                else
                    roomsSQl += "id=" + ids[i] + " OR ";

            return DbConnection.Instance.Query(roomsSQl);
        }

        public static IList<Dictionary<string, string>> GetScheduleByIdOrderByLastUpdateDesc(string id)
        {
            var scheduleEvent = "SELECT * FROM schedules WHERE id="
                                + id + " ORDER BY lastUpdate DESC";
            return DbConnection.Instance.Query(scheduleEvent);
        }

        public static IList<Dictionary<string, string>> GetAllSchedules()
        {
            var properties = new[] { AllAttributes };
            var table = new[] { Schedules };
            return SelectSequence(properties, table);
//            var schedulesSql = SqlOperations.Instance.Select(properties, table);
//            return DbConnection.Instance.Query(schedulesSql);
        }

        public static IList<Dictionary<string, string>> GetSchedulesById(string id)
        {
            var properties = new[] { AllAttributes };
            var tables = new[] { Schedules };
            var keys = new[] { Id };
            var values = new[] { id };
            return SelectSequence(properties, tables, keys, values);
//            var scheduleSql = "SELECT * FROM schedules WHERE id=" + id;
//            return DbConnection.Instance.Query(scheduleSql);
        }

        public static IList<Dictionary<string, string>> GetSchedulesByIds(IList<int> ids, int day, int month, int year)
        {
            var sqlSchedules = "SELECT * FROM schedules WHERE ";

            for (var i = 0; i < ids.Count; i++)
                if (ids.Count - 1 == i)
                    sqlSchedules += "id=" + ids[i] + " AND startDay <=" + day + " AND endDay >=" + day +
                                    " AND " +
                                    "startMonth <= " + month + " AND endMonth >= " + month + " AND " +
                                    "startYear<=" + year + " AND endYear>=" + year +
                                    " ORDER BY endTime ASC";
                else
                    sqlSchedules += "id=" + ids[i] + " OR ";

            return DbConnection.Instance.Query(sqlSchedules);
        }

        public static IList<Dictionary<string, string>> GetTemporariesInEvents(string id)
        {
            var properties = new[] { AllAttributes };
            var tables = new[] { Temporaries };
            var keys = new[] { EventsId };
            var values = new[] { id };
            return SelectSequence(properties, tables, keys, values);
//            var isTemporary = "SELECT * FROM temporaries WHERE events_id=" + id;
//            return DbConnection.Instance.Query(isTemporary);
        }

        public static int InsertMessage(string content, string senderId, string title)
        {
//            var so = SqlOperations.Instance;
//            var db = DbConnection.Instance;
            var table = Messages;
            var keys = new[] { ContentProperty, SenderId, TitleProperty };
            var values = new[] { content, senderId, title };
            return ExecuteSequence(table, keys, values);
//            var insertMessages = so.Insert(table, keys, values);
//            return db.Execute(insertMessages);
        }

        public static void AssociatePersonMessage(string receiverId, string messageId)
        {
//            var so = SqlOperations.Instance;
//            var db = DbConnection.Instance;
            var table = PersonsHasMessages;
            var keys = new[] { PersonsId, MessagesId };
            var values = new[] { receiverId, messageId };
            ExecuteSequence(table, keys, values);
//            var insert = so.Insert(table, keys, values);
//            Debug.WriteLine(insert);
//            db.Execute(insert);
        }

        public static int InsertArtPiece(string name,string description,string exhibitiorId)
        {
            var table = Items;
            var keys = new[] { NameProperty, DescriptionProperty, ExhibitorsId };
            var values = new[] { name, description, exhibitiorId };
            return ExecuteSequence(table, keys, values);
//            var insertItems = SqlOperations.Instance.Insert(table, keys, values);
//            return DbConnection.Instance.Execute(insertItems);
        }

        public static int InsertSpecificArtPiece(string queryTable,string size, string id, string sizeProperty)
        {
            var table = queryTable;
            var keys = new[] { sizeProperty, ItemsId };
            var values = new[] { size, id };
            return ExecuteSequence(table, keys, values);
//            var insertPainting = SqlOperations.Instance.Insert(table, keys, values);
//            return DbConnection.Instance.Execute(insertPainting);
        }

        public static int InsertEvent(string description,string name,string title)
        {
            var table = Events;
            var keys = new[] { DescriptionProperty, NameProperty, TitleProperty };
            var values = new[] { description,name,title };
            return ExecuteSequence(table, keys, values);
//            var insertEvent = SqlOperations.Instance.Insert(table, keys, values);
//            return DbConnection.Instance.Execute(insertEvent);
        }

        public static int InsertPermanent(string id)
        {
            var table = Permanents;
            var keys = new[] { EventsId };
            var values = new[] { id };
            return ExecuteSequence(table, keys, values);
//            var insertPermanent = SqlOperations.Instance.Insert(table, keys, values);
//            return DbConnection.Instance.Execute(insertPermanent);
        }

        public static IList<Dictionary<string, string>> GetPeopleMessage(string id)
        {
//            var so = SqlOperations.Instance;
//            var db = DbConnection.Instance;
            string[] selvals = { AllAttributes };
            string[] tables = { Messages, PersonsHasMessages };
            string[] keys = { "persons_has_messages.persons_id", "persons_has_messages.messages_id" };
            string[] values = { "" + id + "", "messages.id ORDER BY lastUpdate ASC" };
            return SelectSequence(selvals, tables, keys, values);
//            string sql = so.Select(selvals, tables, keys, values);
//            return db.Query(sql);
        }

        public static int InsertProcess(string active,string description,string img,string title,string name,string employeeId,string exhibitorId,string scheduleId)
        {
            var table = Processes;
            var keys = new[]
                {ActiveProperty, DescriptionProperty, ImageProperty, TitleProperty, NameProperty, EmployeesId, ExhibitorsId, ScheduleId};
            var values = new[]
            {
                active,description,img,title,name,employeeId,exhibitorId,scheduleId
            };
            return ExecuteSequence(table, keys, values);
//            var insertProcess = SqlOperations.Instance.Insert(table, keys, values);
//            Console.WriteLine(insertProcess);
//            return DbConnection.Instance.Execute(insertProcess);
        }

        public static int AssociateProcessRoom(string processId,string roomId)
        {
            var table = ProcessesHasRooms;
            var keys = new[] { ProcessesId, RoomProperty };
            var values = new[] { processId, roomId };
            return ExecuteSequence(table, keys, values);
            //            var associateProcessRoom = "INSERT INTO processes_has_rooms (processes_id,rooms_id) VALUES (" + processId +
            //                                       "," + roomId + ")";
            //            return DbConnection.Instance.Execute(associateProcessRoom);
        }

        public static int InsertRoom(string size, string description)
        {
            var table = Rooms;
            var keys = new[] { SizeProperty, DescriptionProperty };
            var values = new[] { size, description };
            return ExecuteSequence(table, keys, values);
//            var insertRoom = SqlOperations.Instance.Insert(table, keys, values);
//            return DbConnection.Instance.Execute(insertRoom);
        }

        public static int InsertSchedule(string firstDay, string firstMonth, string firstYear, string lastDay, string lastMonth, string lastYear, string startTime, string endTime )
        {
            var table = Schedules;
            var keys = new[]
            {
                StartDayProperty, StartMonthProperty, StartYearProperty, EndDayProperty, EndMonthProperty,
                EndYearProperty, StartTimeProperty, EndTimeProperty
            };
            var values = new[] { firstDay, firstMonth, firstYear, lastDay, lastMonth, lastYear, startTime, endTime };
            return ExecuteSequence(table, keys, values);
//            var insertSchedule = SqlOperations.Instance.Insert(table, keys, values);
//            return DbConnection.Instance.Execute(insertSchedule);
        }

        public static int InsertTemporary(string eventId,string processId,string scheduleId)
        {
            var table = Temporaries;
            var keys = new[] { EventsId, ProcessesId, ScheduleId };
            var values = new[] { eventId, processId, scheduleId };
            return ExecuteSequence(table, keys, values);
//            var insertTemporaries = SqlOperations.Instance.Insert(table, keys, values);
//            return DbConnection.Instance.Execute(insertTemporaries);
        }

        public static IList<Dictionary<string, string>> GetSculptureByArtPieceId(string itemId)
        {
            var sculptureSql =
                "SELECT items.id as itemId, volume, sculptures.id as specificId, name, description FROM sculptures,items WHERE items.id=sculptures.items_id AND items.id=" +
                itemId;
            return DbConnection.Instance.Query(sculptureSql);
        }

        public static IList<Dictionary<string, string>> GetPaintingByArtPieceId(string itemId)
        {
            var paintingSql =
                "SELECT items.id as itemId, size, paintings.id as specificId, name, description FROM paintings,items WHERE items.id=paintings.items_id AND items.id=" +
                itemId;
            return DbConnection.Instance.Query(paintingSql);
        }

        public static IList<Dictionary<string, string>> GetPhotographyByArtPieceId(string itemId)
        {
            var photographiesSql =
                "SELECT items.id as itemId, size, photographies.id as specificId, name, description FROM photographies,items WHERE items.id=photographies.items_id AND items.id=" +
                itemId;
            return DbConnection.Instance.Query(photographiesSql);
        }

        public static IList<Dictionary<string, string>> GetProcessByPerson(string query)
        {
            return DbConnection.Instance.Query(query);
        }

        public static int UpdateSequence(int id,string table, string[] properties, string[] values)
        {
            var update = SqlOperations.Instance.Update(id, table, properties, values);
            return DbConnection.Instance.Execute(update);
        }

        private static IList<Dictionary<string, string>> SelectSequence(string[] properties, string[] tables)
        {
            var sql = SqlOperations.Instance.Select(properties, tables);
            return DbConnection.Instance.Query(sql);
        }

        private static IList<Dictionary<string, string>> SelectSequence(string[] properties, string[] tables, string[] keys, string[] values)
        {
            var sql = SqlOperations.Instance.Select(properties, tables, keys, values);
            return DbConnection.Instance.Query(sql);
        }

        private static int ExecuteSequence(string table,string[] keys,string[] values)
        {
            var sql = SqlOperations.Instance.Insert(table, keys, values);
            return DbConnection.Instance.Execute(sql);
        }
    }
}
