using System.Collections.Generic;

namespace Museum
{
    public interface IFactory
    {
        object Create(string type);
        object ImportData(string type,Dictionary<string, string> dictionary);
    }
}