namespace Museum
{
    public interface IFactory
    {
        object Create(string type);
    }
}