using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Own namespaces
using AnimalMotel.Enums;
using AnimalMotel.Animals.Categories;
using AnimalMotel.Animals.Species;


namespace AnimalMotel
{
    public partial class AnimalManager
    {
        private static int _lastGeneratedId = 1;
        private readonly List<Animal> _animals = new List<Animal>();



        // ======================= Properties ======================= //

        private static int LastGeneratedId
        {
            get { return AnimalManager._lastGeneratedId; }
            set { AnimalManager._lastGeneratedId = value; }
        }

        public int ListCount
        {
            get { return _animals.Count; }
        }

        

        // ======================= Methods ======================= //
        
        /// <summary>
        ///   Generates an unique ID.
        ///   Increments it by one after sending it.
        /// </summary>
        /// <returns>int representing a unique ID.</returns>
        private static int GenerateUniqueId()
        {
            return AnimalManager.LastGeneratedId++;
        }

        /// <summary>
        ///   Adds an animal to Animals.
        ///   Assigns a unique ID to the animal passed in.
        /// </summary>
        /// <param name="animal">Animal object.</param>
        public void AddAnimal(Animal animal)
        {
            animal.Id = AnimalManager.GenerateUniqueId();
            _animals.Add(animal);
        }

        

        /// <summary>
        ///   Returns a reference to an Animal object at a given index.
        /// </summary>
        /// <param name="index">index for the Animal object.</param>
        /// <returns>Animal object.</returns>
        public Animal GetAnimalAt(int index)
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException("Index cannot be less than 0", "index");
            }

            if (index > ListCount - 1)
            {
                throw new IndexOutOfRangeException("Index is out of range");
            }

            return _animals[index];
        }

        /// <summary>
        ///   Returns an array with string representation of all animals.
        /// </summary>
        /// <returns>array with string representation of alla nimals.</returns>
        public string[] GetAnimalsStringRepr()
        {
            string[] animals =  new string[ListCount];

            for (int i = 0; i < ListCount; i++)
            {
                animals[i] = _animals[i].ToString();
            }

            return animals;
        }
    }
}
