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
    /// <summary>
    ///   Partial AnimalManager class. This file contains methods
    ///   used to manipulate the storage, but not sorting.
    /// </summary>
    public partial class AnimalManager : ListManager<Animal>
    {
        private static int _lastGeneratedId = 1;



        // ======================= Properties ======================= //

        private static int LastGeneratedId
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
            base.Add(animal);
            RepeatLatestSort();
        }

        /// <summary>
        ///   Returns a reference to an Animal object at a given index.
        /// </summary>
        /// <param name="index">index for the Animal object.</param>
        /// <returns>Animal object.</returns>
        public Animal GetAnimalAt(int index)
        {
            return base.GetAt(index);
        }

        /// <summary>
        ///   Returns an array with string representation of all animals.
        /// </summary>
        /// <returns>array with string representation of alla nimals.</returns>
        public string[] GetAnimalsStringRepr()
        {
            return base.ToStringArray();
        }

        /// <summary>
        ///   METHOD ONLY USED FOR MORE EFFICIENT TESTING.
        ///   STORES SOME DEFAULT ANIMAL OBJECTS WITH DIFFERENT ATTRIBUTES / SPECIES
        ///   SO THAT CHANGING, SORTING AND DELETING CAN BE TESTED WITHOUT
        ///   HAVING TO MANUALLY ADD OBJECTS EACH TIME THE APP IS RESTARTED.
        /// </summary>
        public void FillManagerWithSampleData()
        {
            Cat c1 = new Cat("Zimba", 10, Gender.Male, 23, 40, 4);
            Cat c2 = new Cat("Lilleman", 3, Gender.Male, 24, 45, 6);
            Cat c3 = new Cat("Molly", 7, Gender.Female, 24, 38, 5);
            
            Dog d1 = new Dog("Bosse", 12, Gender.Male, 28, 12, "Huskey");
            Dog d2 = new Dog("Alice", 5, Gender.Female, 28, 35, "White something");
            
            Pigeon p1 = new Pigeon("Hans", 6, Gender.Unknown, 40, 2.6f);
            
            Eagle e1 = new Eagle("Donald Trump", 72, Gender.Male, 200000, 40023);

            AddAnimal(c1);
            AddAnimal(c2);
            AddAnimal(c3);
            AddAnimal(d1);
            AddAnimal(d2);
            AddAnimal(p1);
            AddAnimal(e1);
        }
    }
}
