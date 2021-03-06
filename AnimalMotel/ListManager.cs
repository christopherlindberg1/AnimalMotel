using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


// Own namespaces
using AnimalMotel.Enums.Sorting;
using AnimalMotel.Animals.Sorting;
using AnimalMotel.Serialization;
using System.Xml.Serialization;
using AnimalMotel.Animals.Species;
using AnimalMotel.Storage;
using System.Runtime.Serialization;

namespace AnimalMotel
{
    public class ListManager<T> : IListManager<T>
    {
        private List<T> _list = new List<T>();
        [NonSerialized]
        private SortingDirections _lastUsedSortingDirection = SortingDirections.Asc;
        [NonSerialized]
        private IComparer<T> _lastUsedSortingClass;




        // ========================= Properties ========================= //

        public List<T> List
        {
            get => _list;

            set => _list = value ??
                throw new ArgumentNullException("List cannot be null.");
        }

        public int Count
        {
            get { return _list.Count; }
        }

        public SortingDirections LastUsedSortingDirection
        {
            get => _lastUsedSortingDirection;

            set => _lastUsedSortingDirection = value;
        }

        public IComparer<T> LastUsedSortingClass
        {
            get
            {
                return _lastUsedSortingClass;
            }
            set
            {
                _lastUsedSortingClass = value;
            }
        }





        // ========================= Methods ========================= //

        /// <summary>
        ///   Indexer for getting the object at a given index.
        ///   Throws error if index is out of range.
        /// </summary>
        /// <param name="index">Index of the item.</param>
        /// <returns>Item of the specified type.</returns>
        public T this[int index]
        {
            get
            { 
                if (index < 0 || index >= Count)
                {
                    throw new IndexOutOfRangeException("Index is out of range.");
                }

                return _list[index]; 
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
            RepeatLatestSort();
            return true;
        }

        /// <summary>
        ///   Changes the value for a given key.
        ///   Validates that the key exists.
        /// </summary>
        /// <param name="obj">item to update.</param>
        /// <param name="index">Index of the item.</param>
        /// <returns>true if item got updated, false otherwise.</returns>
        public bool ChangeAt(T obj, int index)
        {
            if (!CheckIndex(index))
            {
                return false;
            }

            _list[index] = obj;
            RepeatLatestSort();
            return true;
        }

        /// <summary>
        ///   Checks whether a given index is within the range for the list.
        /// </summary>
        /// <param name="index">Index.</param>
        /// <returns>true if index is within range, false otherwise.</returns>
        public bool CheckIndex(int index)
        {
            if (index < 0 || index > Count)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        ///   Removes all items in the list.
        /// </summary>
        public void DeleteAll()
        {
            _list.RemoveRange(0, Count);
        }

        /// <summary>
        ///   Deletes an item at a given index.
        /// </summary>
        /// <param name="index">Index of the object.</param>
        /// <returns>true if item got deleted, false otherwise.</returns>
        public bool DeleteAt(int index)
        {
            if (!CheckIndex(index))
            {
                return false;
            }

            _list.RemoveAt(index);
            return true;
        }

        public void AddAll(List<T> items)
        {
            DeleteAll();
           
            foreach (T item in items)
            {
                this.Add(item);
            }

            RepeatLatestSort();
        }

        /// <summary>
        ///   Gets the item at a given index.
        /// </summary>
        /// <param name="index">Index of the item.</param>
        /// <returns>item.</returns>
        public T GetAt(int index)
        {
            if (!CheckIndex(index))
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }

            return _list[index];
        }

        /// <summary>
        ///   Sorts animals by any parameter. Takes a sorting class that implements
        ///   the IComparer interface as an argument, which performs the sort.
        ///   This method keeps track of the state in order to determine if to sort
        ///   in ascending or descending order.
        ///   Does not perform any sorting if the concrete class has not been initiated
        ///   with a sorting class.
        /// </summary>
        /// <param name="sorter">Sorting class that implements the IComparer interface.</param>
        public void Sort(IComparer<T> sorter)
        {
            // Null of the concrete list class has not been initiated with a sorting class.
            // This happens when the list does not need to be sorted.
            if (LastUsedSortingClass == null)
            {
                return;
            }

            string lastUsedSortingClassName = LastUsedSortingClass.GetType().Name;
            string newSortingClassName = sorter.GetType().Name;
            
            // Performs sort
            if ((lastUsedSortingClassName != newSortingClassName)
                || (lastUsedSortingClassName == newSortingClassName
                && _lastUsedSortingDirection == SortingDirections.Desc))
            {
                _list.Sort(sorter);
                _lastUsedSortingDirection = SortingDirections.Asc;
            }
            else
            {
                _list.Sort(sorter);
                _list.Reverse();
                _lastUsedSortingDirection = SortingDirections.Desc;
            }

            LastUsedSortingClass = sorter;
        }

        /// <summary>
        ///   Reverses the order of the items in the list.
        /// </summary>
        public void Reverse()
        {
            _list.Reverse();
        }

        /// <summary>
        ///   Performs the last sort that was made. This method is used
        ///   whenever animal objects are added, changed or deleted to preserve
        ///   the correct order.
        /// </summary>
        public void RepeatLatestSort()
        {
            if (LastUsedSortingClass == null)
            {
                return;
            }

            Sort(LastUsedSortingClass);

            if (_lastUsedSortingDirection == SortingDirections.Desc)
            {
                Reverse();
            }
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

            foreach (T obj in _list)
            {
                list.Append(obj.ToString());
            }

            return list;
        }

        /// <summary>
        /// Method for binary serializing of the objects in the list (used to serialize animals)
        /// </summary>
        /// <param name="filePath">Path to a binary file where animals should be stored</param>
        public void BinarySerialize(string filePath)
        {
            try
            {
                BinarySerializerUtility.Serialize<List<T>>(filePath, List);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Method used to deserialize objects from a binary file and store them in the list
        /// (used when deserializing animals)
        /// </summary>
        /// <param name="filePath">Path to the binary file with serialized animals</param>
        public void BinaryDeserialize(string filePath)
        {
            List = BinarySerializerUtility.Deserialize<List<T>>(filePath);
        }

        /// <summary>
        /// Method for XML serialization of the objects in the list (used to serialize reciped)
        /// </summary>
        /// <param name="fileName">Path for where the file should be stored</param>
        public void XMLSerialize(string fileName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method used to deserialize objects from a binary file and store them in the list
        /// (used when deserializing animals)
        /// </summary>
        /// <param name="filename"></param>
        public void XmlDeserialize(string filename)
        {
            throw new NotImplementedException();
        }
    }
}
