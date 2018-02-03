namespace Museum
{
    public interface IDecorator
    {
        string GetInformation();
        void SetElement(IDecorator newElement);
        IDecorator GetElement();
    }
}