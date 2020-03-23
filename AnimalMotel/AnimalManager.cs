﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// Own namespaces
using AnimalMotel.Enums;
using AnimalMotel.Animals.Categories;
using AnimalMotel.Animals.Species;
using AnimalMotel.Animals.Sorting;


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
        ///   Default constructor that sets the default sorting class.
        /// </summary>
        public AnimalManager()
        {
            LastUsedSortingClass = new SortAnimalById();
        }

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
            Add(animal);
            RepeatLatestSort();
        }

        /// <summary>
        ///   Updates the data for an existing animal.
        /// </summary>
        /// <param name="animal">Animal object.</param>
        /// <param name="category">category of the animal.</param>
        /// <param name="animalData">User input data.</param>
        public void UpdateAnimal(
            Animal animal,
            Category category,
            Dictionary<string, string> animalData)
        {
            UpdateGeneralData(animal, category, animalData);
            UpdateCategoryData(animal, category, animalData);
            UpdateSpecieData(animal, animalData);

            RepeatLatestSort();
        }

        /// <summary>
        ///   Updates general animal data for an animal object.
        /// </summary>
        /// <param name="animal">Animal object.</param>
        /// <param name="category">category of the animal.</param>
        /// <param name="animalData">User input data.</param>
        private void UpdateGeneralData(
            Animal animal,
            Category category,
            Dictionary<string, string> animalData)
        {
            animal.Name = animalData["name"];
            animal.Age = int.Parse(animalData["age"]);
            animal.Gender = (Gender) Enum.Parse(typeof(Gender), animalData["gender"]);
        }

        /// <summary>
        ///   Updates category specific data for an animal object.
        /// </summary>
        /// <param name="animal">Animal object.</param>
        /// <param name="animalData">User input data.</param>
        private void UpdateCategoryData(
            Animal animal,
            Category category,
            Dictionary<string, string> animalData)
        {
            switch (category)
            {
                case Category.Bird:
                    Bird bird = animal as Bird;
                    bird.FlyingSpeed = float.Parse(animalData["flyingSpeed"]);
                    break;

                case Category.Mammal:
                    Mammal mammal = animal as Mammal;
                    mammal.NrOfTeeth = int.Parse(animalData["nrOfTeeth"]);
                    mammal.TailLegth = float.Parse(animalData["tailLength"]);
                    break;

                default:
                    throw new ArgumentException(
                        "Category did not match any case.", "category");
            }
        }

        /// <summary>
        ///   Updates specie specific data for an animal object.
        /// </summary>
        /// <param name="animal">Animal object.</param>
        /// <param name="animalData">User input data.</param>
        private void UpdateSpecieData(
            Animal animal,
            Dictionary<string, string> animalData)
        {
            string specie = animal.GetSpecie();

            switch (specie)
            {
                case "Eagle":
                    Eagle eagle = animal as Eagle;
                    eagle.ClawLength = float.Parse(animalData["clawLength"]);
                    break;

                case "Pigeon":
                    Pigeon pigeon = animal as Pigeon;
                    pigeon.BeakLength = float.Parse(animalData["beakLength"]);
                    break;

                case "Cat":
                    Cat cat = animal as Cat;
                    cat.Lives = int.Parse(animalData["lives"]);
                    break;
                
                case "Dog":
                    Dog dog = animal as Dog;
                    dog.Breed = animalData["breed"];
                    break;

                default:
                    throw new ArgumentException("Specie did not match any case.", "specie");
            }
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
