using System.Collections.Generic;

namespace Museum
{
    public interface ICreateAccount
    {
        bool CreateAccountMethod(Dictionary<string, string> values);
        void GetData(Dictionary<string, string> values);
        bool SubmitData();
    }
}