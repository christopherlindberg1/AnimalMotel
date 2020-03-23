using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// Own namespaces
using AnimalMotel.Enums.Sorting;
using AnimalMotel.Animals.Sorting;

namespace AnimalMotel
{
    public class ListManager<T> : IListManager<T>
    {
        private readonly List<T> _list = new List<T>();

        private SortingDirections _lastUsedSortingDirection = SortingDirections.Asc;
        private SortingParameters _lastUsedSortingParameter = SortingParameters.Id;
        private IComparer<T> _lastUsedSortingClass;




        // ========================= Properties ========================= //

        public int Count
        {
            get { return _list.Count; }
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
        /// </summary>
        /// <param name="sorter">Sorting class that implements the IComparer interface.</param>
        public void Sort(IComparer<T> sorter)
        {
            if (LastUsedSortingClass == null)
            {
                LastUsedSortingClass = sorter;
            }
            
            SortingParameters wantToSortBy;

            // Stores sorting option to be able to keep track of state.
            if (sorter is SortAnimalByAge)
            {
                wantToSortBy = SortingParameters.Age;
            }
            else if (sorter is SortAnimalByGender)
            {
                wantToSortBy = SortingParameters.Gender;
            }
            else if (sorter is SortAnimalById)
            {
                wantToSortBy = SortingParameters.Id;
            }
            else if (sorter is SortAnimalByName)
            {
                wantToSortBy = SortingParameters.Name;
            }
            else if (sorter is SortAnimalBySpecialCharacteristics)
            {
                wantToSortBy = SortingParameters.SpecialCharacteristics;
            }
            else if (sorter is SortAnimalBySpecie)
            {
                wantToSortBy = SortingParameters.Specie;
            }
            else
            {
                throw new InvalidOperationException(
                    "Sorter class did not match any sorting option.");
            }

            // Performs sort
            if ((_lastUsedSortingParameter != wantToSortBy)
                || (_lastUsedSortingParameter == wantToSortBy
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

            // Updates state
            _lastUsedSortingParameter = wantToSortBy;
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

            for (int i = 0; i < Count; i++)
            {
                list[i] = _list[i].ToString();
            }

            return list;
        }
    }
}
