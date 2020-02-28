using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Own namespaces
using AnimalMotel.Animals.Categories;
using AnimalMotel.Animals.Species;
using AnimalMotel.Enums;


namespace AnimalMotel.Factories
{
    /// <summary>
    ///   Class used to create Objects that defive from the Mammal class.
    /// </summary>
    public class MammalFactory
    {
        /// <summary>
        ///   Creates an object for a specific Mammal specie and assigns its values
        ///   to the ones passed in.
        /// </summary>
        /// <param name="mammalSpecie">>Specie to create.</param>
        /// <param name="animalData">Data to assign to the object.</param>
        /// <returns>Object that derives from the Mammal class.</returns>
        public static Mammal CreateMammal(MammalSpecies mammalSpecie,
            Dictionary<string, string> animalData)
        {
            switch (mammalSpecie)
            {
                case MammalSpecies.Cat:
                    return MammalFactory.CreateCat(animalData);

                case MammalSpecies.Dog:
                    return MammalFactory.CreateDog(animalData);

                default:
                    throw new InvalidOperationException("Specie did not match any case.");
            }
        }

        /// <summary>
        ///   Creates an cat object with the data passed in.
        /// </summary>
        /// <param name="animalData">Input data about the animal.</param>
        /// <returns>Eagle object.</returns>
        private static Cat CreateCat(Dictionary<string, string> animalData)
        {
            Cat cat = new Cat();

            cat.Name = animalData["name"];
            cat.Age = int.Parse(animalData["age"]);
            cat.Gender = (Gender)Enum.Parse(typeof(Gender), animalData["gender"]);
            cat.NrOfTeeth = int.Parse(animalData["nrOfTeeth"]);
            cat.TailLegth = int.Parse(animalData["tailLength"]);
            cat.Lives = int.Parse(animalData["lives"]);

            return cat;
        }

        /// <summary>
        ///   Creates an Dog object with the data passed in.
        /// </summary>
        /// <param name="animalData">Input data about the animal.</param>
        /// <returns>Eagle object.</returns>
        private static Dog CreateDog(Dictionary<string, string> animalData)
        {
            Dog dog = new Dog();

            dog.Name = animalData["name"];
            dog.Age = int.Parse(animalData["age"]);
            dog.Gender = (Gender)Enum.Parse(typeof(Gender), animalData["gender"]);
            dog.NrOfTeeth = int.Parse(animalData["nrOfTeeth"]);
            dog.TailLegth = int.Parse(animalData["tailLength"]);
            dog.Breed = animalData["breed"];

            return dog;
        }
    }
}
