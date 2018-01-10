namespace Museum
{
    public abstract class ArtPiece : IDecorator
    {
        public static readonly string NameProperty = "name";
        public static readonly string DescriptionProperty = "description";
        public static readonly string RoomProperty = "room";
        public static readonly string SizeProperty = "size";

        public static readonly string Items = "items";
        public static readonly string Paitings = "paitings";
        public static readonly string Photographies = "photographies";
        public static readonly string Sculptures = "sculptures";

        private int id { get; set; }

        public int Id
        {
            get => id;
            set => id = value;
        }

        private string name { get; set; }

        public string Name
        {
            get => name;
            set => name = value;
        }

        private double size { get; set; }

        public double Size
        {
            get => size;
            set => size = value;
        }

        private string description { get; set; }

        public string Description
        {
            get => description;
            set => description = value;
        }

        private Exhibitor exhibitor { get; set; }

        public Exhibitor Exhibitor
        {
            get => exhibitor;
            set => exhibitor = value;
        }
        
        private IDecorator element { get; set; }

        public IDecorator Element
        {
            get => element;
            set => element = value;
        }

        public abstract string GetInformation();

        public abstract void Save();

        public abstract void Update(string properties, string values, string table);

        public void UpdateSequence(string table, string[] properties, string[] values)
        {
            var update = SqlOperations.Instance.Update(Id,table ,properties, values);
            DBConnection.Instance.Execute(update);
        }
    }
}