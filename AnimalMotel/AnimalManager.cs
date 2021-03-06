using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalMotel.Animals.Sorting;
using System.Runtime.Serialization;

namespace AnimalMotel
{
    /// <summary>
    /// Partial AnimalManager class. This file contains methods
    /// used to manipulate the storage, but not sorting.
    /// </summary>
    [Serializable]
    public class AnimalManager : ListManager<Animal>
    {
        private static int _lastGeneratedId = 0;




        // ======================= Properties ======================= //

        public static int LastGeneratedId
        {
            get { return AnimalManager._lastGeneratedId; }
            set { AnimalManager._lastGeneratedId = value; }
        }

        public int ListCount
        {
            get { return base.Count; }
        }




        // ======================= Methods ======================= //

        /// <summary>
        /// Default constructor that sets the default sorting class.
        /// </summary>
        public AnimalManager()
        {
            LastUsedSortingClass = new SortAnimalById();
        }

        /// <summary>
        /// Generates an unique ID.
        /// Increments it by one before sending it.
        /// </summary>
        /// <returns>int representing a unique ID.</returns>
        private static int GenerateUniqueId()
        {
            return ++AnimalManager.LastGeneratedId;
        }

        /// <summary>
        /// Adds an animal to Animals.
        /// Assigns a unique ID to the animal passed in.
        /// </summary>
        /// <param name="animal">Animal object.</param>
        public void AddAnimal(Animal animal)
        {
            animal.Id = AnimalManager.GenerateUniqueId();
            Add(animal);
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("List", this.List);
        }

        public AnimalManager(SerializationInfo info, StreamingContext context)
        {
            this.List = (List<Animal>)info.GetValue("List", typeof(List<Animal>));
        }
    }
}
