using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Hashing
{
    internal sealed class OneToManyDictionary<TKey, TValue> : IEnumerable<KeyValuePair<TKey, HashSet<TValue>>>
    {
        private readonly Dictionary<TKey, HashSet<TValue>> _keyValuePairs = new Dictionary<TKey, HashSet<TValue>>();

        public HashSet<TValue> this[TKey key] => _keyValuePairs[key];

        public bool ContainsKey(TKey key)
        {
            return _keyValuePairs.ContainsKey(key);
        }

        public void Add(TKey key, TValue value)
        {
            if (_keyValuePairs.TryGetValue(key, out var values))
            {
                values.Add(value);
            }
            else
            {
                values = new HashSet<TValue>();
                if (value != null)
                {
                    values.Add(value);
                }
                _keyValuePairs[key] = values;
            }
        }

        public IEnumerator<KeyValuePair<TKey, HashSet<TValue>>> GetEnumerator()
        {
            return _keyValuePairs.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
