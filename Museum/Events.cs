namespace Museum
{
    public abstract class Events : IDecorator
    {
        public static readonly string DescriptionProperty = "description";
        public static readonly string Permanent = "permanents";
        public static readonly string Temporary = "temporaries";
        public static readonly string Event = "events";

        private int id { get; set; }

        public int Id
        {
            get => id;
            set => id = value;
        }

        public Process Process { get; set; }

        public abstract string GetInformation();

        public abstract void Save();

        public abstract void Update(string properties, string values, string table);

        public void UpdateSequence(string table, string[] properties, string[] values)
        {
            var update = SqlOperations.Instance.Update(Id, table, properties, values);
            DBConnection.Instance.Execute(update);
        }
    }
}