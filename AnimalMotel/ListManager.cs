using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalMotel
{
    public class ListManager<T> : IListManager<T>
    {
        private readonly List<T> _list = new List<T>();




        // ========================= Properties ========================= //
        
        public int Count
        {
            get { return _list.Count; }
        }

        protected List<T> List
        {
            get { return _list; }
        }





        // ========================= Methods ========================= //

        /// <summary>
        ///   Indexer for getting the object at a given index.
        ///   Throws error if index is out of range.
        /// </summary>
        /// <param name="index">Index of the object.</param>
        /// <returns>Object of the specified type.</returns>
        public T this[int index]
        {
            get
            { 
                if (index < 0 || index >= Count)
                {
                    throw new IndexOutOfRangeException("Index is out of range.");
                }

                return List[index]; 
            }
        }

        /// <summary>
        ///   Method for adding an object to the list.
        /// </summary>
        /// <param name="obj">Object to add.</param>
        /// <returns>True if obj != null, False otherwise.</returns>
        public bool Add(T obj)
        {
            if (obj == null)
            {
                return false;
            }

            _list.Add(obj);
            return true;
        }

        public bool ChangeAt(T obj, int index)
        {
            if (!CheckIndex(index))
            {
                return false;
            }

            _list[index] = obj;
            return true;
        }

        public bool CheckIndex(int index)
        {
            if (index < 0 || index > Count)
            {
                return false;
            }

            return true;
        }

        public void DeleteAll()
        {
            _list.RemoveRange(0, Count);
        }

        public bool DeleteAt(int index)
        {
            if (!CheckIndex(index))
            {
                return false;
            }

            _list.RemoveAt(index);
            return true;
        }

        

        public T GetAt(int index)
        {
            if (!CheckIndex(index))
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }

            return _list[index];
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///   Returns an array with string representations of all objects
        ///   stored int the list.
        /// </summary>
        /// <returns>Array with string representations.</returns>
        public string[] ToStringArray()
        {
            string[] arr = new string[Count];

            for (int i = 0; i < Count; i++)
            {
                arr[i] = _list[i].ToString();
            }

            return arr;
        }

        /// <summary>
        ///   Returns a list with string representations of all objects
        ///   stored int the list.
        /// </summary>
        /// <returns>List with string representations.</returns>
        public List<string> ToStringList()
        {
            List<string> list = new List<string>();

            for (int i = 0; i < Count; i++)
            {
                list[i] = _list[i].ToString();
            }

            return list;
        }
    }
}
