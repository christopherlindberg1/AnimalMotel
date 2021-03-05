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
    public class Cat : Mammal
    {
        private int _lives;
        private FoodSchedule _foodSchedule;
        int MyProperty { get; set; }


        // ======================= Properties ======================= //

        public int Lives
        {
            get { return this._lives; }
            set
            {
                if (value < 1)
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
            : this(name, age, gender, 0, 0, 7)
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

        /// <summary>
        /// Method used for deserializing Cat objects.
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Id", this.Id);
            info.AddValue("Name", this.Name);
            info.AddValue("Age", this.Age);
            info.AddValue("Gender", this.Gender);
            info.AddValue("NrOfTeeth", this.NrOfTeeth);
            info.AddValue("TailLength", this.TailLegth);
            info.AddValue("Lives", this.Lives);
        }

        /// <summary>
        /// Constructor used for deserializing Cat objects.
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public Cat(SerializationInfo info, StreamingContext context)
        {
            this.Id = (int)info.GetValue("Id", typeof(int));
            this.Name = (string)info.GetValue("Name", typeof(string));
            this.Age = (int)info.GetValue("Age", typeof(int));
            this.Gender = (Gender)info.GetValue("Gender", typeof(Gender));
            this.NrOfTeeth = (int)info.GetValue("NrOfTeeth", typeof(int));
            this.TailLegth = (float)info.GetValue("TailLength", typeof(float));
            this.Lives = (int)info.GetValue("Lives", typeof(int));
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
        /// <returns>"cat".</returns>
        public override string GetSpecie()
        {
            return this.GetType().Name;
        }

        /// <summary>
        ///   Returns a string with the characteristics that are unique to cats.
        /// </summary>
        /// <returns>String with special characteristics.</returns>
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
