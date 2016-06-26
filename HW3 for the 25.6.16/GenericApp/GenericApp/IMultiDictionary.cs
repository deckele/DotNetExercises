using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericApp
{
    public interface IMultiDictionary<K, V>
    {
        void Add(K key, V value);
        bool Remove(K key);
        bool Remove(K key, V value);
        void Clear();
        bool ContainsKey(K key);
        bool Contains(K key, V value);
        ICollection<K> Keys { get; }
        ICollection<V> Values { get; }
        int Count { get; }
    }
}
