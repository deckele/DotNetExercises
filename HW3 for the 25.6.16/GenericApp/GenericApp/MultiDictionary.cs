using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GenericApp
{
    public class MultiDictionary<K, V> : IMultiDictionary<K, V>, IEnumerable<KeyValuePair<K, V>>
    {
        private Dictionary<K, LinkedList<V>> _multiDictionary = new Dictionary<K, LinkedList<V>>(); 

        public void Add(K key, V value)
        {
            if (!_multiDictionary.ContainsKey(key))
            {
                _multiDictionary[key] = new LinkedList<V>();
            }
            _multiDictionary[key].AddLast(value);
        }

        public bool Remove(K key)
        {
            if (_multiDictionary.ContainsKey(key))
            {
                _multiDictionary.Remove(key);
                return true;
            }
            return false;
        }

        public bool Remove(K key, V value)
        {
            if (_multiDictionary.ContainsKey(key))
            {
                if (_multiDictionary[key].Contains(value))
                {
                    _multiDictionary[key].Remove(value);
                    return true;
                }
            }
            return false;
        }

        public ICollection<K> Keys
        {
            get
            {
                return _multiDictionary.Keys;
            }
        }

        public ICollection<V> Values
        {
            get
            {
                var valuesList = new List<V>();
                foreach (var list in _multiDictionary.Values)
                {
                    valuesList.AddRange(list);
                }
                return valuesList;
            }
        }

        public int Count
        {
            get
            {
                int counter = 0;
                foreach (var list in _multiDictionary.Values)
                {
                    counter += list.Count;
                }
                return counter;
            }
        }

        public void Clear()
        {
            _multiDictionary.Clear();
        }
        public bool ContainsKey(K key)
        {
            return _multiDictionary.ContainsKey(key);
        }

        public bool Contains(K key, V value)
        {
            return _multiDictionary.ContainsKey(key) && _multiDictionary[key].Contains(value);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _multiDictionary.GetEnumerator();
        }

        public IEnumerator<KeyValuePair<K, V>> GetEnumerator()
        {
            List <KeyValuePair<K,V>> listOfKeyValuePairs= new List<KeyValuePair<K, V>>();

            foreach (var key in _multiDictionary.Keys)
            {
                foreach (var value in _multiDictionary[key])
                {
                    listOfKeyValuePairs.Add(new KeyValuePair<K, V>(key,value));
                }
            }
            return listOfKeyValuePairs.GetEnumerator();
        }

        //For testing- Method that prints the current _multiDictionary instance.
        public void PrintDictionary()
        {
            int counter = 1;
            foreach (var key in _multiDictionary.Keys)
            {
                Console.Write("{0}) Key: {1}", counter, key);
                foreach (var value in _multiDictionary[key])
                {
                    Console.Write("{0,8}", value);
                }
                Console.WriteLine();
                counter++;               
            }
        }
    }
}