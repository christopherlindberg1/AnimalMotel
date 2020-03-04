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
    /// <summary>
    ///   Partial AnimalManager class. This file contains methods
    ///   for sorting the animal objects.
    /// </summary>
    public partial class AnimalManager
    {
        private SortingDirections _lastUsedSortingDirection = SortingDirections.Asc;
        private SortingParameters _lastUsedSortingParameter = SortingParameters.Id;
        private IComparer<Animal> _lastUsedSortingClass = new SortAnimalById();


        /// <summary>
        ///   Sorts animals by any parameter. Takes a sorting class that implements
        ///   the IComparer interface as an argument, which performs the sort.
        ///   This method keeps track of the state in order to determine if to sort
        ///   in ascending or descending order.
        /// </summary>
        /// <param name="sorter">Sorting class that implements the IComparer interface.</param>
        private void SortAnimals(IComparer<Animal> sorter)
        {
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
                _animals.Sort(sorter);
                
                _lastUsedSortingDirection = SortingDirections.Asc;
            }
            else
            {
                _animals.Sort(sorter);
                _animals.Reverse();

                _lastUsedSortingDirection = SortingDirections.Desc;
            }

            // Updates state
            _lastUsedSortingParameter = wantToSortBy;
            _lastUsedSortingClass = sorter;
        }

        /// <summary>
        ///   Sorts animals by their ID.
        /// </summary>
        public void SortById()
        {
            SortAnimals(new SortAnimalById());
        }

        /// <summary>
        ///   Sorts animals by their specie.
        /// </summary>
        public void SortBySpecie()
        {
            SortAnimals(new SortAnimalBySpecie());
        }

        /// <summary>
        ///   Sorts animals by their Name.
        /// </summary>
        public void SortByName()
        {
            SortAnimals(new SortAnimalByName());
        }

        /// <summary>
        ///   Sorts animals by their age.
        /// </summary>
        public void SortByAge()
        {
            SortAnimals(new SortAnimalByAge());
        }

        /// <summary>
        ///   Sorts animals by their gender.
        /// </summary>
        public void SortByGender()
        {
            SortAnimals(new SortAnimalByGender());
        }

        /// <summary>
        ///   Sorts animals by their special characteristics (just compares
        ///   the strings that represent all special characteristics).
        /// </summary>
        public void SortBySpecialCharacteristics()
        {
            SortAnimals(new SortAnimalBySpecialCharacteristics());
        }

        /// <summary>
        ///   Performs the last sort that was made. This method is used
        ///   whenever animal objects are added, changed or deleted to preserve
        ///   the correct order.
        /// </summary>
        private void RepeatLatestSort()
        {
            _animals.Sort(_lastUsedSortingClass);

            if (_lastUsedSortingDirection == SortingDirections.Desc)
            {
                _animals.Reverse();
            }
        }
    }
}
