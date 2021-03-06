﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using AnimalMotel.Enums;
using AnimalMotel.Animals;

namespace AnimalMotel
{
    [Serializable]
    public abstract class Animal
    {
        private int _id;
        private string _name;
        private int _age;
        private Gender _gender;




        // ======================= Properties ======================= //

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("name", "Name cannot be null or empty");
                }

                _name = value;
            }
        }

        public int Age
        {
            get { return _age; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Age cannot be negative", "age");
                }

                _age = value;
            }
        }

        public Gender Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }




        // ======================= Methods ======================= //

        /// <summary>
        /// Constructor taking arguments for name, age and gender.
        /// </summary>
        public Animal(string name, int age, Gender gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

        /// <summary>
        /// Abstract method for returning the EaterType for the animal.
        /// Is implemented by the final subclasses.
        /// </summary>
        /// <returns>EaterType value.</returns>
        public abstract EaterType GetEaterType();

        /// <summary>
        /// Abstract method for returning a FoodSchedule object from an animal.
        /// Is implemented by the final subclasses.
        /// </summary>
        /// <returns>FoodSchedule object.</returns>
        public abstract FoodSchedule GetFoodSchedule();

        /// <summary>
        /// Abstract method for returning the name of the specie for an animal.
        /// Is implemented by the final subclasses.
        /// </summary>
        /// <returns>Name of the specie.</returns>
        public abstract string GetSpecie();

        /// <summary>
        /// Abstract method for returning the special characteristics of a specie.
        /// Is implemented by the final subclasses.
        /// </summary>
        /// <returns>String with special characteristics.</returns>
        public abstract string GetSpecialCharacteristics();

        /// <summary>
        /// String representation of an Animal object.
        /// </summary>
        /// <returns>String representation of an Animal object.</returns>
        public override string ToString()
        {
            return String.Format("   {0, -29} {1, -24} {2, -20} {3, -32} ",
                Id, Name, Age, Gender);
        }
    }
}