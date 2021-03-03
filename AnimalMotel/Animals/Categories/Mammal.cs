using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

// Own namespaces
using AnimalMotel.Enums;

namespace AnimalMotel.Animals.Categories
{
    [Serializable]
    public abstract class Mammal : Animal
    {
        private int _nrOfTeeth;
        private float _tailLength;


        // ======================= Properties ======================= //

        public int NrOfTeeth
        {
            get { return _nrOfTeeth; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(
                        "NrOfTeeth", "Cannot have fewer than 0 teeth");
                }
                    
                _nrOfTeeth = value;
            }
        }

        public float TailLegth
        {
            get { return _tailLength; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(
                        "TailLength", "Tail length cannot be less than 0");
                }

                _tailLength = value;
            }
        }

        /// <summary>
        ///   Parameterless constructur chain calling other constructor
        ///   and passing in default arguments.
        /// </summary>
        public Mammal()
            : this("No name", 0, Gender.Unknown)
        {
        }

        /// <summary>
        ///   Constructor taking all arguments for Animal objects.
        ///   Calls constructor that handle all arguments for Mammal objects.
        /// </summary>
        public Mammal(string name, int age, Gender gender)
            : this(name, age, gender, 0, 0f)
        {
        }

        /// <summary>
        ///   Constructor taking all arguments for Mammal objects.
        ///   Calls base constructor that handle all arguments for Animal objects.
        /// </summary>
        public Mammal(string name, int age,
            Gender gender, int nrOfTeeth, float tailLength)
            : base(name, age, gender)
        {
            NrOfTeeth = nrOfTeeth;
            TailLegth = tailLength;
        }

        /// <summary>
        ///   String representation of a Mammal object. Makes use of its base class.
        /// </summary>
        /// <returns>String representation of a Mammal object.</returns>
        public override string ToString()
        {
            return base.ToString()
                + String.Format("Nr of teeth: {0, -6} Tail length: {1}.     ",
                    NrOfTeeth, TailLegth);
        }
    }
}
