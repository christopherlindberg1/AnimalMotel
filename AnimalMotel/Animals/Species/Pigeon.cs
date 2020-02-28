﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Own namespaces
using AnimalMotel.Animals.Categories;
using AnimalMotel.Enums;

namespace AnimalMotel.Animals.Species
{
    public class Pigeon: Bird
    {
        private float _beakLength;


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

        /// <summary>
        ///   Parameterless constructor chain calling another constructor
        ///   and passing in default values.
        /// </summary>
        public Pigeon()
            : this("No name", 0, Gender.Unknown)
        {
        }

        /// <summary>
        ///   Constructor taking arguments for Animal objects.
        ///   Calls constructor that takes arguments for Bird objects
        ///   with default argument for flying speed.
        /// </summary>
        public Pigeon(string name, int age, Gender gender)
            : this(name, age, gender, 0f)
        {
        }

        /// <summary>
        ///   Constructor taking arguments for Bird objects.
        ///   Calls constructor that takes all arguments for Pigeon objects
        ///   with default argument for beak length.
        /// </summary>
        public Pigeon(string name, int age,
            Gender gender, float flyingSpeed)
            : this(name, age, gender, flyingSpeed, 0f)
        {
        }

        /// <summary>
        ///   Constructor taking all arguments for Pigeon objects.
        ///   Calls base constructor that handle all arguments for Bird objects.
        /// </summary>
        public Pigeon(string name, int age,
            Gender gender, float flyingSpeed, float beakLength)
            : base(name, age, gender, flyingSpeed)
        {
            BeakLength = beakLength;
        }

        /// <summary>
        ///   Constructor taking a Bird object as argument and filling those values.
        /// </summary>
        /// <param name="mammal">Bird object</param>
        public Pigeon(Bird bird)
        {
            Name = bird.Name;
            Age = bird.Age;
            Gender = bird.Gender;
            FlyingSpeed = bird.FlyingSpeed;
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
        ///   Overrides the default ToString method.
        ///   Formats a string by adding beak length to the string
        ///   generated by the base class's ToString method.
        /// </summary>
        /// <returns>String representation of a Pigeon object</returns>
        public override string ToString()
        {
            StringBuilder strRepr = new StringBuilder(
                base.ToString() + String.Format("Beak length: {0}. ", BeakLength));

            strRepr.Insert(15, this.GetType().Name);

            return strRepr.ToString();
        }

    }
}
