using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalMotel.Animals.Sorting
{
    /// <summary>
    /// Class used for sorting animal objects by name.
    /// </summary>
    public class SortAnimalByName : IComparer<Animal>
    {
        public int Compare(Animal a1, Animal a2)
        {
            return a1.Name.CompareTo(a2.Name);
        }
    }
}