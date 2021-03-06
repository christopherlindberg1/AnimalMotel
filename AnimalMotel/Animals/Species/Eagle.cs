using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using AnimalMotel.Animals.Categories;
using AnimalMotel.Enums;


namespace AnimalMotel.Animals.Species
{
    [Serializable]
    public class Eagle : Bird, ISerializable
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
        /// Parameterless constructor chain calling another constructor
        /// and passing in default values.
        /// </summary>
        public Eagle()
            : this("No name", 0, Gender.Unknown)
        {
        }

        /// <summary>
        /// Constructor taking arguments for Animal objects.
        /// Calls constructor that takes arguments for Bird objects
        /// with default argument for flying speed.
        /// </summary>
        public Eagle(string name, int age, Gender gender)
            : this(name, age, gender, 0f)
        {
        }

        /// <summary>
        /// Constructor taking arguments for Bird objects.
        /// Calls constructor that takes all arguments for Eagle objects
        /// with default argument for claw length.
        /// </summary>
        public Eagle(string name, int age,
            Gender gender, float flyingSpeed)
            : this(name, age, gender, flyingSpeed, 0f)
        {
        }

        /// <summary>
        /// Constructor taking all arguments for Eagle objects.
        /// Calls base constructor that handle all arguments for Bird objects.
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

        /// <summary>
        /// Method used for serializing Eagle objects.
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Id", this.Id);
            info.AddValue("Name", this.Name);
            info.AddValue("Age", this.Age);
            info.AddValue("Gender", this.Gender);
            info.AddValue("FlyingSpeed", this.FlyingSpeed);
            info.AddValue("ClawLength", this.ClawLength);
        }

        /// <summary>
        /// Constructor used fpr deserializing Eagle objects.
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public Eagle(SerializationInfo info, StreamingContext context)
        {
            this.Id = (int)info.GetValue("Id", typeof(int));
            this.Name = (string)info.GetValue("Name", typeof(string));
            this.Age = (int)info.GetValue("Age", typeof(int));
            this.Gender = (Gender)info.GetValue("Gender", typeof(Gender));
            this.FlyingSpeed = (float)info.GetValue("FlyingSpeed", typeof(float));
            this.ClawLength = (float)info.GetValue("ClawLength", typeof(float));
        }

        /// <summary>
        /// Returns the eater type of cats.
        /// </summary>
        /// <returns>EaterType.Carnivore.</returns>
        public override EaterType GetEaterType()
        {
            return EaterType.Carnivore;
        }

        /// <summary>
        /// Returns the FoodSchedule object.
        /// </summary>
        /// <returns>FoodSchedule object.</returns>
        public override FoodSchedule GetFoodSchedule()
        {
            
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the name of the specie by referring to the name of the class.
        /// </summary>
        /// <returns>"eagle".</returns>
        public override string GetSpecie()
        {
            return this.GetType().Name;
        }

        /// <summary>
        /// Returns a string with the characteristics that are unique to eagles.
        /// </summary>
        /// <returns>string with special characteristics.</returns>
        public override string GetSpecialCharacteristics()
        {
            return String.Format("Flying speed: {0, -7} Claw legth: {1, -7}",
                FlyingSpeed, ClawLength);
        }

        /// <summary>
        /// Overrides the default ToString method.
        /// Formats a string by building ontop of the ToString method
        /// defined in the base class.
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