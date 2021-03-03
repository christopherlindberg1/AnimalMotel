using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

// Own namespaces
using AnimalMotel.Animals.Categories;
using AnimalMotel.Enums;


namespace AnimalMotel.Animals.Species
{
    [Serializable]
    public class Dog : Mammal, ISerializable
    {
        private string _breed;
        private FoodSchedule _foodSchedule;

        // ======================= Properties ======================= //

        public string Breed
        {
            get { return this._breed; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(
                        "Breed", "Breed cannot be null or empty");
                }

                this._breed = value;
            }
        }

        public FoodSchedule FoodSchedule
        {
            get { return _foodSchedule; }
        }




        // ======================= Methods ======================= //

        /// <summary>
        ///   Parameterless constructor chain calling another constructor
        ///   and passing in default values.
        /// </summary>
        public Dog()
            : this("No name", 0, Gender.Unknown)
        {
        }

        /// <summary>
        ///   Constructor taking arguments for Animal objects.
        ///   Chain calls constructor that takes arguments for Mammal objects
        ///   with default argument for nrOfTeeth and tailLength.
        /// </summary>
        public Dog(string name, int age, Gender gender)
            : this(name, age, gender, 0, 0f)
        {
        }

        /// <summary>
        ///   Constructor taking arguments for Mammal objects.
        ///   Calls base class's constructor that handles all arguments except the
        ///   one that is specific for Dog objects.
        /// </summary>
        public Dog(string name, int age,
            Gender gender, int nrOfTeeth, float tailLength)
            : this(name, age, gender, nrOfTeeth, tailLength, "Default breed")
        {
        }

        /// <summary>
        ///   Constructor taking all arguments for Dog objects.
        ///   Calls base constructor that handle all arguments for Mammal objects.
        ///   Hard codes a food schedule.
        /// </summary>
        public Dog(string name, int age,
            Gender gender, int nrOfTeeth, float tailLength, string breed)
            : base(name, age, gender, nrOfTeeth, tailLength)
        {
            Breed = breed;

            // Hard coding food schedule.
            _foodSchedule = new FoodSchedule(
                new List<string>
                {
                    "(1) Morning: bones and one glas of milk.",
                    "(2) Lunch: dog food and water.",
                    "(3) 3 PM: Sweets and water.",
                    "(4) Evening: Rests from a chicken and water."
                }
            );
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Id", this.Id);
            info.AddValue("Name", this.Name);
            info.AddValue("Age", this.Age);
            info.AddValue("Gender", this.Gender);
            info.AddValue("NrOfTeeth", this.NrOfTeeth);
            info.AddValue("TailLength", this.TailLegth);
            info.AddValue("Breed", this.Breed);
        }

        /// <summary>
        ///   Returns the eater type of cats.
        /// </summary>
        /// <returns>EaterType.Carnivore.</returns>
        public override EaterType GetEaterType()
        {
            return EaterType.Carnivore;
        }

        /// <summary>
        ///   Returns the FoodSchedule object.
        /// </summary>
        /// <returns>FoodSchedule object.</returns>
        public override FoodSchedule GetFoodSchedule()
        {
            return _foodSchedule;
        }

        /// <summary>
        ///   Returns the name of the specie by referring to the name of the class.
        /// </summary>
        /// <returns>"dog".</returns>
        public override string GetSpecie()
        {
            return this.GetType().Name;
        }

        /// <summary>
        ///   Returns a string with the characteristics that are unique to dogs.
        /// </summary>
        /// <returns>String with special characteristics.</returns>
        public override string GetSpecialCharacteristics()
        {
            return String.Format("Nr of teeth: {0, -7} Tail length: {1, -7}" +
                "Breed: {2}",
                NrOfTeeth, TailLegth, Breed);
        }

        /// <summary>
        ///   Formats a string by building ontop of the ToString method
        ///   defined in the base class.
        /// </summary>
        /// <returns>String representation of a Dog object</returns>
        public override string ToString()
        {
            StringBuilder strRepr = new StringBuilder(
                base.ToString() + String.Format("Breed: {0}. ", Breed));

            strRepr.Insert(15, GetSpecie());

            return strRepr.ToString();
        }
    }
}
