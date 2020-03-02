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
        private FoodSchedule _foodSchedule;


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

        public FoodSchedule FoodSchedule
        {
            get { return _foodSchedule; }
        }




        // ======================= Methods ======================= //

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

            _foodSchedule = new FoodSchedule(
                new List<string> 
                {
                    "(1) Morning: tuna and water.",
                    "(2) Lunch: Cat food and water.",
                    "(3) 3 PM: Wiskers and milk.",
                    "(4) Evening: tuna and water."
                }
            );
        }

        public override EaterType GetEaterType()
        {
            return EaterType.Carnivore;
        }

        public override FoodSchedule GetFoodSchedule()
        {
            return _foodSchedule;
        }

        public override string GetSpecie()
        {
            return this.GetType().Name;
        }

        public override string GetSpecialCharacteristics()
        {
            return String.Format("Nr of teeth: {0, -7} Tail length: {1, -7}" +
                "Nr of lives: {2}",
                NrOfTeeth, TailLegth, Lives);
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

            strRepr.Insert(15, GetSpecie());

            return strRepr.ToString();
        }
    }
}
