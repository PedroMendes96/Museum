using System.Collections.Generic;

namespace Museum
{
    public class DictonaryAdapter
    {
        private readonly Dictionary<string, string> dictionary;

        public DictonaryAdapter(Dictionary<string, string> dictionary)
        {
            this.dictionary = dictionary;
        }

        public string GetValue(string key)
        {
            if (dictionary.TryGetValue(key, out var value)) return value;
            return null;
        }
    }
}