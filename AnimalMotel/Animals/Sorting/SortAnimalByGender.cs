using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalMotel.Animals.Sorting
{
    /// <summary>
    /// Class used for sorting animal objects by gender.
    /// </summary>
    public class SortAnimalByGender : IComparer<Animal>
    {
        public int Compare(Animal a1, Animal a2)
        {
            return a1.Gender.CompareTo(a2.Gender);
        }
    }
}