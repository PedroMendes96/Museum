using System.Collections.Generic;

namespace Museum
{
    public class ExhibitionFactory : IFactory
    {
        public static readonly string Temporary = "Temporary";
        public static readonly string Permanent = "Permanent";

        public object Create(string type)
        {
            Events exhibition;
            if (type == Temporary)
                exhibition = new Temporary();
            else if (type == Permanent)
                exhibition = new Permanent();
            else
                return null;
            return exhibition;
        }

        public object ImportData(string type, Dictionary<string, string> dictionary)
        {
            Events exhibition;
            if (type == Temporary)
                exhibition = new Temporary(dictionary);
            else if (type == Permanent)
                exhibition = new Permanent(dictionary);
            else
                return null;
            return exhibition;
        }
    }
}