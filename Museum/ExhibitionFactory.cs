namespace Museum
{
    public class ExhibitionFactory : IFactory
    {
        public static readonly string temporary = "Temporary";
        public static readonly string permanent = "Permanent";

        public object Create(string type)
        {
            Events exhibition;
            if (type == temporary)
                exhibition = new Temporary();
            else if (type == permanent)
                exhibition = new Permanent();
            else
                return null;
            return exhibition;
        }
    }
}