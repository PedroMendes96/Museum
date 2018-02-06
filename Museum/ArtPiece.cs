namespace Museum
{
    public abstract class ArtPiece : IDecorator
    {
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
    }
}