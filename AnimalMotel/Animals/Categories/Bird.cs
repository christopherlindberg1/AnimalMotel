using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Own namespaces
using AnimalMotel.Enums;

namespace AnimalMotel.Animals.Categories
{
    public abstract class Bird : Animal
    {
        private float _flyingSpeed;


        // ======================= Properties ======================= //

        public float FlyingSpeed
        {
            get { return _flyingSpeed; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(
                        "FlyingSpeed", "Flying speed cannot be less than 0");

                _flyingSpeed = value;
            }
        }

        /// <summary>
        ///   Parameterless constructur chain calling other constructor
        ///   and passing in default arguments.
        /// </summary>
        public Bird()
            : this("No name", 0, Gender.Unknown)
        {
        }

        /// <summary>
        ///   Constructor taking all arguments for Animal objects.
        ///   Calls constructor that handle all arguments for Bird objects.
        /// </summary>
        public Bird(string name, int age, Gender gender)
            : this(name, age, gender, 0f)
        {
        }

        /// <summary>
        ///   Constructor taking all arguments for Bird objects.
        ///   Calls base constructor that handle all arguments for Animal objects.
        /// </summary>
        public Bird(string name, int age,
            Gender gender, float flyingSpeed)
            : base(name, age, gender)
        {
            FlyingSpeed = flyingSpeed;
        }

        


        /// <summary>
        ///   String representation of a Bird object. Makes use of its base class.
        /// </summary>
        /// <returns>String representation of a Bird object.</returns>
        public override string ToString()
        {
            return base.ToString()
                + String.Format("Flying speed: {0}. ", FlyingSpeed);
        }
    }
}
