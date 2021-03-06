using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalMotel.Animals.Sorting
{
    /// <summary>
    /// Class used for sorting animal objects by Id.
    /// </summary>
    public class SortAnimalById : IComparer<Animal>
    {
        public int Compare(Animal a1, Animal a2)
        {
            return a1.Id.CompareTo(a2.Id);
        }
    }
}