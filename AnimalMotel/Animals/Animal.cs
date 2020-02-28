using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Own namespaces
using AnimalMotel.Enums;
using AnimalMotel.Animals;

namespace AnimalMotel
{
    public abstract class Animal : IAnimal
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
                    throw new ArgumentNullException("name", "Name cannot be null or empty");
                
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
        ///   Constructor taking arguments for name, age and gender.
        /// </summary>
        public Animal(string name, int age, Gender gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

        public abstract EaterType GetEaterType();

        public abstract FoodSchedule GetFoodSchedule();

        public abstract string GetSpecie();

        /// <summary>
        ///   String representation of an Animal object.
        /// </summary>
        /// <returns>String representation of an Animal object.</returns>
        public override string ToString()
        {
            return String.Format("   {0, -29} {1, -24} {2, -20} {3, -32} ",
                Id, Name, Age, Gender);
        }
    }
}
