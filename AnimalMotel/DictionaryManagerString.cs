using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalMotel
{
    public class DictionaryManagerString : IDictionaryManagerString
    {
        private readonly Dictionary<string, string> _dictionary = new Dictionary<string, string>();





        // ========================= Properties ========================= //

        public int Count
        {
            get { return Dictionary.Count; }
        }

        public  Dictionary<string, string> Dictionary
        {
            get { return _dictionary; }
        }





        // ========================= Methods ========================= //

        public string this[string key]
        {
            get
            {
                if (!Dictionary.ContainsKey(key))
                {
                    throw new ArgumentException("The provided key does not exist", "key");
                }

                return Dictionary[key];
            }
            set
            {
                if (String.IsNullOrEmpty(key))
                {
                    throw new ArgumentException("Key cannot be null or empty", "key");
                }
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Value cannot be null or empty", "value");
                }

                Dictionary[key] = value;
            }
        }

        public string GetItem(string key)
        {
            if (!Dictionary.ContainsKey(key))
            {
                return null;
            }

            return Dictionary[key];
        }

        public bool Add(string key, string value)
        {
            if (Dictionary.ContainsKey(key))
            {
                return false;
            }

            Dictionary[key] = value;
            return true;
        }

        public bool Change(string key, string value)
        {
            if (!Dictionary.ContainsKey(key))
            {
                return false;
            }

            Dictionary[key] = value;
            return true;
        }

        public bool Remove(string key)
        {
            if (!Dictionary.ContainsKey(key))
            {
                return false;
            }

            Dictionary.Remove(key);
            return true;
        }
    }
}
