using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalMotel
{
    public class FoodSchedule
    {
        private readonly List<string> _foodDescriptionList = new List<string>();



        // ======================= Properties ======================= //


        public int NrOfFoodDescriptions
        {
            get { return _foodDescriptionList.Count; }
        }




        // ======================= Methods ======================= //


        public FoodSchedule()
        {

        }

        public FoodSchedule(List<string> foodList)
        {
            
        }

        /// <summary>
        ///   Adds a food schedule item to the collection.
        ///   Validates that it is not empty and that it does not already exist.
        /// </summary>
        /// <param name="item">Food schedule item to be added.</param>
        /// <returns>bool showing if item was added of not</returns>
        public bool AddFoodScheduleItem(string item)
        {
            if (String.IsNullOrWhiteSpace(item))
            {
                return false;
            }

            foreach (string description in _foodDescriptionList)
            {
                if (description.Equals(item))
                {
                    return false;
                }
            }

            _foodDescriptionList.Add(item);

            return true;
        }

        /// <summary>
        ///   Changes a food schedule item at a given index.
        ///   Validates index and item.
        /// </summary>
        /// <param name="item">Food schedule item.</param>
        /// <param name="index">Index for the food schedule item.</param>
        /// <returns>bool showing if food schedule item got changed or not.</returns>
        public bool ChangeFoodScheduleItem(string item, int index)
        {
            if (!ValidateIndex(index))
            {
                return false;
            }

            if (String.IsNullOrWhiteSpace(item))
            {
                return false;
            }

            _foodDescriptionList[index] = item;

            return true;
        }

        /// <summary>
        ///   Removed a food schedule item at a given index.
        ///   Validates index.
        /// </summary>
        /// <param name="index">Index for the food item.</param>
        /// <returns>bool showing if food schedule item got deleted or not.</returns>
        public bool DeleteFoodScheduleItem(int index)
        {
            if (!ValidateIndex(index))
            {
                return false;
            }

            _foodDescriptionList.RemoveAt(index);

            return true;
        }

        /// <summary>
        ///   Returns a string with information that the animal requires
        ///   no manual feeding.
        /// </summary>
        /// <returns>string with no feeding-information.</returns>
        public string DescribeNoFeedingRequired()
        {
            return "Animals of this specie are self feeding";
        }

        /// <summary>
        ///   Returns a specific food schedule item.
        /// </summary>
        /// <param name="index">Index for the food schedule item.</param>
        /// <returns>Food schedule item.</returns>
        public string GetFoodSchedule(int index)
        {
            return _foodDescriptionList[index];
        }

        /// <summary>
        ///   Returns all food schedule descriptions as a single string.
        /// </summary>
        /// <returns>string with all food schedule descriptions.</returns>
        public override string ToString()
        {
            if (NrOfFoodDescriptions == 0)
            {
                return "No food schedule descriptions added.";
            }

            StringBuilder descriptionString = new StringBuilder();

            descriptionString.Append($"To be fed {NrOfFoodDescriptions} times as follows:\n");

            foreach (string description in _foodDescriptionList)
            {
                descriptionString.Append(description + "\n");
            }

            return descriptionString.ToString();
        }

        /// <summary>
        ///   Validates that an index is within the range of the collection.
        /// </summary>
        /// <param name="index">index for the collection.</param>
        /// <returns>bool showing if index is withing the range of the collection or not.</returns>
        public bool ValidateIndex(int index)
        {
            if (index < NrOfFoodDescriptions && index > -1)
            {
                return true;
            }

            return false;
        }
    }
}
