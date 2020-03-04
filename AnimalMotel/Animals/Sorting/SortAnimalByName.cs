﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Own namespaces
using AnimalMotel.Animals;

namespace AnimalMotel.Animals.Sorting
{
    public class SortAnimalByName : IComparer<Animal>
    {
        public int Compare(Animal a1, Animal a2)
        {
            return a1.Name.CompareTo(a2.Name);
        }
    }
}