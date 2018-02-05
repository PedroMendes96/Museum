using System.Collections.Generic;

namespace Museum
{
    public class DictionaryAdapter
    {
        private readonly Dictionary<string, string> _dictionary;

        public DictionaryAdapter(Dictionary<string, string> dictionary)
        {
            _dictionary = dictionary;
        }

        public string GetValue(string key)
        {
            return _dictionary.TryGetValue(key, out var value) ? value : null;
        }
    }
}