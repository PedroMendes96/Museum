namespace Museum
{
    public interface IState
    {
        void Accept();
        void Refuse();
        void Confirm();
        void Cancel();
    }
}