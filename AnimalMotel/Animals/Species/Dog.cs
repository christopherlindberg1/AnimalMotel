using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Own namespaces
using AnimalMotel.Animals.Categories;
using AnimalMotel.Enums;


namespace AnimalMotel.Animals.Species
{
    public class Dog : Mammal
    {
        private string _breed;


        // ======================= Properties ======================= //

        public string Breed
        {
            get { return this._breed; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(
                        "Breed", "Breed cannot be null or empty");

                this._breed = value;
            }
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
        /// </summary>
        public Dog(string name, int age,
            Gender gender, int nrOfTeeth, float tailLength, string breed)
            : base(name, age, gender, nrOfTeeth, tailLength)
        {
            Breed = breed;
        }

        /// <summary>
        ///   Constructor taking a Mammal object as argument and filling those values.
        /// </summary>
        /// <param name="mammal">Mammal object</param>
        public Dog(Mammal mammal)
        {
            Name = mammal.Name;
            Age = mammal.Age;
            Gender = mammal.Gender;
            NrOfTeeth = mammal.NrOfTeeth;
            TailLegth = mammal.TailLegth;
        }

        public override EaterType GetEaterType()
        {
            throw new NotImplementedException();
        }

        public override FoodSchedule GetFoodSchedule()
        {
            throw new NotImplementedException();
        }

        public override string GetSpecie()
        {
            throw new NotImplementedException();
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

            strRepr.Insert(15, this.GetType().Name);

            return strRepr.ToString();
        }
    }
}
