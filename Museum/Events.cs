using System.Collections.Generic;

namespace Museum
{
    public abstract class Events
    {
        public static readonly string DescriptionProperty = "description";
        public static readonly string Permanent = "permanents";
        public static readonly string Temporary = "temporaries";
        public static readonly string Event = "events";
        public static readonly string TitleProperty = "title";
        public static readonly string NameProperty = "name";

        public int Id { get; set; }

        public abstract void Save();

        public abstract void Update(string properties, string values, string table);
    }
}