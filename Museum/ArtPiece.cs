using System.Collections.Generic;

namespace Museum
{
    public abstract class ArtPiece : IDecorator
    {
        public static readonly string NameProperty = "name";
        public static readonly string DescriptionProperty = "description";
        public static readonly string TitleProperty = "title";
        public static readonly string RoomProperty = "room";

        public static readonly string Items = "items";
        public static readonly string Paitings = "paitings";
        public static readonly string Photographies = "photographies";
        public static readonly string Sculptures = "sculptures";

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Exhibitor Exhibitor { get; set; }
        public IDecorator Element { get; set; }

        public abstract string GetInformation();
        public abstract void SetDimension(string size);
        public abstract void Save();
        public abstract void Update(string properties, string values, string table);

        public void SetElement(IDecorator newElement)
        {
            Element = newElement;
        }

        public IDecorator GetElement()
        {
            return Element;
        }

        public void SetParameters(string name, string description, string size, Exhibitor exhibitor)
        {
            Name = name;
            Description = description;
            SetDimension(size);
            Exhibitor = exhibitor;
        }

        public static IList<Dictionary<string, string>> GetAllItemsByProcess(string idProcess)
        {
            var selected = new[] {"*"};
            var table = new[]{"items_has_processes"};
            var properties = new[] {"processes_id"};
            var values = new[] {idProcess};
            var query = SqlOperations.Instance.Select(selected, table, properties, values);
            //            var query = "SELECT * FROM items_has_processes  WHERE processes_id=" + idProcess;
            return DbConnection.Instance.Query(query);
        }

        public void AssociateWithProcess(int processId)
        {
            var table = "items_has_processes";
            var properties = new[] {"items_id", "processes_id"};
            var values = new[] {Id.ToString(), processId.ToString()};
            var artPieceProcess = SqlOperations.Instance.Insert(table, properties, values);
//            var artPieceProcess = "INSERT INTO items_has_processes (items_id,processes_id) VALUES (" + Id + "," +
//                                  processId + ")";
            DbConnection.Instance.Execute(artPieceProcess);
        }

        public void UpdateSequence(string table, string[] properties, string[] values)
        {
            var update = SqlOperations.Instance.Update(Id, table, properties, values);
            DbConnection.Instance.Execute(update);
        }
    }
}