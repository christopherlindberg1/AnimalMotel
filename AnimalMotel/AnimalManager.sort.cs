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

        /// <summary>
        ///   Sorts animals by their ID.
        /// </summary>
        public void SortById()
        {
            Sort(new SortAnimalById());
        }

        /// <summary>
        ///   Sorts animals by their specie.
        /// </summary>
        public void SortBySpecie()
        {
            Sort(new SortAnimalBySpecie());
        }

        /// <summary>
        ///   Sorts animals by their Name.
        /// </summary>
        public void SortByName()
        {
            Sort(new SortAnimalByName());
        }

        /// <summary>
        ///   Sorts animals by their age.
        /// </summary>
        public void SortByAge()
        {
            Sort(new SortAnimalByAge());
        }

        /// <summary>
        ///   Sorts animals by their gender.
        /// </summary>
        public void SortByGender()
        {
            Sort(new SortAnimalByGender());
        }

        /// <summary>
        ///   Sorts animals by their special characteristics (just compares
        ///   the strings that represent all special characteristics).
        /// </summary>
        public void SortBySpecialCharacteristics()
        {
            Sort(new SortAnimalBySpecialCharacteristics());
        }
    }
}
