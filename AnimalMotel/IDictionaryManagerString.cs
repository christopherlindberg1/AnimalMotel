using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalMotel
{
    public interface IDictionaryManagerString
    {
        int Count { get; }

        Dictionary<string, string> Dictionary { get; }

        string this[string key] { get; set; }

        string GetItem(string key);

        bool Add(string key, string value);

        bool Change(string key, string value);

        bool Remove(string key);

        /// <summary>
        ///   Method for getting an array with string representations
        ///   of all objects stored in the dictionary.
        /// </summary>
        /// <returns>Nested array with key-value pairs.</returns>
        //string[] ToValueAndKeyStringArray();

        /// <summary>
        ///   Method for getting a list with string representations
        ///   of all objects stored in the dictionary.
        /// </summary>
        /// <returns>Nested list with key-value pairs.</returns>
        //List<string> ToValueAndKeyStringList();
    }
}
