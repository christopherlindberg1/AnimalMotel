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
        ///   Fills the application with sample data.
        /// </summary>
        public void FillManagerWithSampleData()
        {
            Cat c1 = new Cat("Zimba", 10, Gender.Male, 23, 40, 4);
            Cat c2 = new Cat("Lilleman", 3, Gender.Male, 24, 45, 6);
            Cat c3 = new Cat("Molly", 7, Gender.Female, 24, 38, 5);

            Dog d1 = new Dog("Bosse", 12, Gender.Male, 28, 12, "Huskey");
            Dog d2 = new Dog("Alice", 5, Gender.Female, 28, 35, "White something");

            Pigeon p1 = new Pigeon("Hans", 6, Gender.Unknown, 40, 2.6f);

            Eagle e1 = new Eagle("Tonald Drump", 73, Gender.Male, 200000, 40023);

            AddAnimal(c1);
            AddAnimal(c2);
            AddAnimal(c3);
            AddAnimal(d1);
            AddAnimal(d2);
            AddAnimal(p1);
            AddAnimal(e1);
        }

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
        ///   Returns a reference to an Animal object with a given id.
        /// </summary>
        /// <param name="id">Id of the animal.</param>
        /// <returns>Animal object.</returns>
        public Animal GetAnimalById(int id)
        {
            foreach (Animal animal in List)
            {
                if (animal.Id.Equals(id))
                {
                    return animal;
                }
            }

            return null;
        }

        /// <summary>
        ///   Updates the data for an existing animal.
        /// </summary>
        /// <param name="animal">Animal object.</param>
        /// <param name="animalData">User input data.</param>
        /// <returns>True if animal got updated, false otherwise.</returns>
        public bool UpdateAnimal(Animal animal, Dictionary<string, string> animalData)
        {


            return false;
        }

        /// <summary>
        ///   Removes an animal with a given id.
        /// </summary>
        /// <param name="id">id for the animal.</param>
        /// <returns>true if removed, false otherwise.</returns>
        public bool RemoveById(int id)
        {
            for (int i = 0; i < Count; i++)
            {
                if (GetAnimalAt(i).Id.Equals(id))
                {
                    List.RemoveAt(i);
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        ///   Deletes an collection of animals with given ids.
        /// </summary>
        /// <param name="ids">List with ids.</param>
        /// <returns>true if all got deleted, false otherwise.</returns>
        public bool DeleteAnimals(List<int> ids)
        {
            bool allOk = true;

            foreach (int id in ids)
            {
                allOk = allOk && RemoveById(id);
            }

            return allOk;
        }

        /// <summary>
        ///   Returns an array with string representation of all animals.
        /// </summary>
        /// <returns>array with string representation of alla nimals.</returns>
        public string[] GetAnimalsStringRepr()
        {
            return base.ToStringArray();
        }
    }
}
