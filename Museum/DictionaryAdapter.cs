using System.Collections.Generic;

namespace Museum
{
    public class DictionaryAdapter
    {
        private readonly Dictionary<string, string> dictionary;

        public DictionaryAdapter(Dictionary<string, string> dictionary)
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