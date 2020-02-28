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
    ///   Class responsible for creating objects that derive from the Bird class.
    /// </summary>
    public class BirdFactory
    {
        /// <summary>
        ///   Creates an object for a specific Bird specie and assigns its values
        ///   to the ones passed in.
        /// </summary>
        /// <param name="birdSpecie">Specie to create.</param>
        /// <param name="animalData">Data to assign to the object.</param>
        /// <returns>Object that derives from the Bird class.</returns>
        public static Bird CreateBird(BirdSpecies birdSpecie,
            Dictionary<string, string> animalData)
        {
            switch (birdSpecie)
            {
                case BirdSpecies.Eagle:
                    return BirdFactory.CreateEagle(animalData);

                case BirdSpecies.Pigeon:
                    return BirdFactory.CreatePigeon(animalData);

                default:
                    throw new InvalidOperationException("Specie did not match any case.");
            }
        }

        /// <summary>
        ///   Creates an Eagle object with the data passed in.
        /// </summary>
        /// <param name="animalData">Input data about the animal.</param>
        /// <returns>Eagle object.</returns>
        private static Eagle CreateEagle(Dictionary<string, string> animalData)
        {
            Eagle eagle = new Eagle();

            eagle.Name = animalData["name"];
            eagle.Age = int.Parse(animalData["age"]);
            eagle.Gender = (Gender)Enum.Parse(typeof(Gender), animalData["gender"]);
            eagle.FlyingSpeed = int.Parse(animalData["flyingSpeed"]);
            eagle.ClawLength = int.Parse(animalData["clawLength"]);

            return eagle;
        }

        /// <summary>
        ///   Creates an Pigeon object with the data passed in.
        /// </summary>
        /// <param name="animalData">Input data about the animal.</param>
        /// <returns>Pigeon object.</returns>
        private static Pigeon CreatePigeon(Dictionary<string, string> animalData)
        {
            Pigeon pigeon = new Pigeon();

            pigeon.Name = animalData["name"];
            pigeon.Age = int.Parse(animalData["age"]);
            pigeon.Gender = (Gender)Enum.Parse(typeof(Gender), animalData["gender"]);
            pigeon.FlyingSpeed = int.Parse(animalData["flyingSpeed"]);
            pigeon.BeakLength = int.Parse(animalData["beakLength"]);

            return pigeon;
        }
    }
}
