﻿using System;
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
    public class Pigeon: Bird, ISerializable
    {
        private float _beakLength;
        private FoodSchedule _foodSchedule;




        // ======================= Properties ======================= //

        public float BeakLength
        {
            get { return _beakLength; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(
                        "BeakLength", "Beak length cannot be less than 0");

                _beakLength = value;
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
        public Pigeon()
            : this("No name", 0, Gender.Unknown)
        {
        }

        /// <summary>
        /// Constructor taking arguments for Animal objects.
        /// Calls constructor that takes arguments for Bird objects
        /// with default argument for flying speed.
        /// </summary>
        public Pigeon(string name, int age, Gender gender)
            : this(name, age, gender, 0f)
        {
        }

        /// <summary>
        /// Constructor taking arguments for Bird objects.
        /// Calls constructor that takes all arguments for Pigeon objects
        /// with default argument for beak length.
        /// </summary>
        public Pigeon(string name, int age,
            Gender gender, float flyingSpeed)
            : this(name, age, gender, flyingSpeed, 0f)
        {
        }

        /// <summary>
        /// Constructor taking all arguments for Pigeon objects.
        /// Calls base constructor that handle all arguments for Bird objects.
        /// </summary>
        public Pigeon(string name, int age,
            Gender gender, float flyingSpeed, float beakLength)
            : base(name, age, gender, flyingSpeed)
        {
            BeakLength = beakLength;

            _foodSchedule = new FoodSchedule(
                new List<string>
                {
                    "(1) Morning: nuts and water.",
                    "(2) Lunch: insects and water.",
                    "(3) Evening: nuts and water."
                }
            );
        }

        /// <summary>
        /// Method used for serializing Pigeon objects.
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
            info.AddValue("BeakLength", this.BeakLength);
        }

        /// <summary>
        /// Constructor used for deserializing Pigeon objects.
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public Pigeon(SerializationInfo info, StreamingContext context)
        {
            this.Id = (int)info.GetValue("Id", typeof(int));
            this.Name = (string)info.GetValue("Name", typeof(string));
            this.Age = (int)info.GetValue("Age", typeof(int));
            this.Gender = (Gender)info.GetValue("Gender", typeof(Gender));
            this.FlyingSpeed = (float)info.GetValue("FlyingSpeed", typeof(float));
            this.BeakLength = (float)info.GetValue("BeakLength", typeof(float));
        }

        /// <summary>
        /// Returns the eater type of cats.
        /// </summary>
        /// <returns>EaterType.Omnivorous.</returns>
        public override EaterType GetEaterType()
        {
            return EaterType.Omnivorous;
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
        /// <returns>"pigeon".</returns>
        public override string GetSpecie()
        {
            return this.GetType().Name;
        }

        /// <summary>
        /// Returns a string with the characteristics that are unique to cats.
        /// </summary>
        /// <returns>String with special characteristics.</returns>
        public override string GetSpecialCharacteristics()
        {
            return String.Format("Flying speed: {0, -7} Beak legth: {1, -7}.",
                FlyingSpeed, BeakLength);
        }

        /// <summary>
        /// Overrides the default ToString method.
        /// Formats a string by adding beak length to the string
        /// generated by the base class's ToString method.
        /// </summary>
        /// <returns>String representation of a Pigeon object</returns>
        public override string ToString()
        {
            StringBuilder strRepr = new StringBuilder(
                base.ToString() + String.Format("Beak length: {0} ", BeakLength));

            strRepr.Insert(15, GetSpecie());

            return strRepr.ToString();
        }
    }
}