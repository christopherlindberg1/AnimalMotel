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

        public bool AddFoodScheduleItem(string item)
        {
            return false;
        }

        public bool ChangeFoodScheduleItem(string item, int index)
        {
            return false;
        }

        public bool DeleteFoodScheduleItem(string item, int index)
        {
            return false;
        }

        public string DescribeNoFeedingRequired()
        {
            return "";
        }

        public string GetFoodSchedule(int index)
        {
            return "";
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }

        public bool ValidateIndex(int index)
        {
            return false;
        }
    }
}
