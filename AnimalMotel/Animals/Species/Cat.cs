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
    public class Cat : Mammal
    {
        private int _lives;


        // ======================= Properties ======================= //

        public int Lives
        {
            get { return this._lives; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(
                        "Lives", "Cats must have at least one life");

                this._lives = value;
            }
        }

        /// <summary>
        ///   Parameterless constructor chain calling another constructor
        ///   and passing in default values.
        /// </summary>
        public Cat()
            : this("No name", 0, Gender.Unknown)
        {
        }

        /// <summary>
        ///   Constructor taking arguments for Animal objects.
        ///   Chain calls constructor that takes arguments for Mammal objects
        ///   with default argument for nrOfTeeth and tailLength.
        /// </summary>
        public Cat(string name, int age, Gender gender)
            : this(name, age, gender, 0, 0, 0)
        {
        }

        /// <summary>
        ///   Constructor taking arguments for Animal objects.
        ///   Calls base class's constructor that handles all arguments except the
        ///   one that is specific for cat objects.
        /// </summary>
        public Cat(string name, int age, Gender gender,
            int nrOfTeeth, float tailLength, int lives)
            : base(name, age, gender, nrOfTeeth, tailLength)
        {
            Lives = lives;
        }

        /// <summary>
        ///   Constructor taking a Mammal object as argument and filling those fields.
        /// </summary>
        /// <param name="mammal">Mammal object</param>
        public Cat(Mammal mammal)
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
            return this.GetType().Name;
        }

        /// <summary>
        ///   Formats a string by building ontop of the ToString method
        ///   defined in the base class.
        /// </summary>
        /// <returns>String representation of a Cat object</returns>
        public override string ToString()
        {
            StringBuilder strRepr = new StringBuilder(
                base.ToString() + String.Format("Nr of lives: {0}. ", Lives));

            strRepr.Insert(15, this.GetType().Name);

            return strRepr.ToString();
        }
    }
}
