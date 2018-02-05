namespace Museum
{
    public sealed class FactoryCreator
    {
        public static FactoryCreator Instance = new FactoryCreator();
        public static readonly string PersonFactory = "PersonFactory";
        public static readonly string ExhibitionFactory = "ExhibitionFactory";
        public static readonly string ArtPieceFactory = "ArtPieceFactory";

        private FactoryCreator()
        {
        }

        public IFactory CreateFactory(string type)
        {
            IFactory factory;
            if (type == PersonFactory)
                factory = new PersonFactory();
            else if (type == ExhibitionFactory)
                factory = new ExhibitionFactory();
            else if (type == ArtPieceFactory)
                factory = new ArtpieceFactory();
            else
                factory = null;
            return factory;
        }
    }
}