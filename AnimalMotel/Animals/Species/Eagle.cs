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
    public class Eagle : Bird
    {
        private float _clawLength;
        private FoodSchedule _foodSchedule;


        // ======================= Properties ======================= //

        public float ClawLength
        {
            get { return _clawLength; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(
                        "ClawLength", "Claw length cannot be less than 0");

                _clawLength = value;
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
        public Eagle()
            : this("No name", 0, Gender.Unknown)
        {
        }

        /// <summary>
        ///   Constructor taking arguments for Animal objects.
        ///   Calls constructor that takes arguments for Bird objects
        ///   with default argument for flying speed.
        /// </summary>
        public Eagle(string name, int age, Gender gender)
            : this(name, age, gender, 0f)
        {
        }

        /// <summary>
        ///   Constructor taking arguments for Bird objects.
        ///   Calls constructor that takes all arguments for Eagle objects
        ///   with default argument for claw length.
        /// </summary>
        public Eagle(string name, int age,
            Gender gender, float flyingSpeed)
            : this(name, age, gender, flyingSpeed, 0f)
        {
        }

        /// <summary>
        ///   Constructor taking all arguments for Eagle objects.
        ///   Calls base constructor that handle all arguments for Bird objects.
        /// </summary>
        public Eagle(string name, int age,
            Gender gender, float flyingSpeed, float clawLength)
            : base(name, age, gender, flyingSpeed)
        {
            ClawLength = clawLength;

            _foodSchedule = new FoodSchedule(
                new List<string>
                {
                    "(1) Morning: raw meat and water.",
                    "(2) Lunch: chicken and water.",
                    "(3) Evening: rabbit and water."
                }
            );
        }

        public override EaterType GetEaterType()
        {
            return EaterType.Carnivore;
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
        ///   Overrides the default ToString method.
        ///   Formats a string by building ontop of the ToString method
        ///   defined in the base class.
        /// </summary>
        /// <returns>String representation of an Eagle object</returns>
        public override string ToString()
        {
            StringBuilder strRepr = new StringBuilder(
                base.ToString() + String.Format("Claw length: {0}. ", ClawLength));

            strRepr.Insert(15, GetSpecie());

            return strRepr.ToString();
        }
    }
}
