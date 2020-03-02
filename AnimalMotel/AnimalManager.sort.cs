using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Own namespaces
using AnimalMotel.Enums.Sorting;

namespace AnimalMotel
{
    public partial class AnimalManager
    {
        private IOrderedEnumerable<Animal> _sortedAnimals;
        private SortingParameters _lastUsedSortingParameter = SortingParameters.Id;
        private SortingDirections _lastUsedSortingDirection = SortingDirections.Asc;


        public void SortById()
        {
            /*
             If previous sort wasn't by name or if previous sort was by name
             in descending order.
             */
            if ((_lastUsedSortingParameter != SortingParameters.Id)
                || (_lastUsedSortingParameter == SortingParameters.Id
                && _lastUsedSortingDirection == SortingDirections.Desc))
            {
                _sortedAnimals = from animal in _animals
                                 orderby animal.Id ascending
                                 select animal;

                _lastUsedSortingParameter = SortingParameters.Id;
                _lastUsedSortingDirection = SortingDirections.Asc;
            }
            else
            {
                _sortedAnimals = from animal in _animals
                                 orderby animal.Id descending
                                 select animal;

                _lastUsedSortingParameter = SortingParameters.Id;
                _lastUsedSortingDirection = SortingDirections.Desc;
            }

            List<Animal> sortedAnimals = _sortedAnimals.ToList<Animal>();

            for (int i = 0; i < ListCount; i++)
            {
                _animals[i] = sortedAnimals[i];
            }
        }

        public void SortBySpecie()
        {
            /*
             If previous sort wasn't by name or if previous sort was by name
             in descending order.
             */
            if ((_lastUsedSortingParameter != SortingParameters.Specie)
                || (_lastUsedSortingParameter == SortingParameters.Specie
                && _lastUsedSortingDirection == SortingDirections.Desc))
            {
                _sortedAnimals = from animal in _animals
                                 orderby animal.GetSpecie() ascending
                                 select animal;

                _lastUsedSortingParameter = SortingParameters.Specie;
                _lastUsedSortingDirection = SortingDirections.Asc;
            }
            else
            {
                _sortedAnimals = from animal in _animals
                                 orderby animal.GetSpecie() descending
                                 select animal;

                _lastUsedSortingParameter = SortingParameters.Specie;
                _lastUsedSortingDirection = SortingDirections.Desc;
            }

            List<Animal> sortedAnimals = _sortedAnimals.ToList<Animal>();

            for (int i = 0; i < ListCount; i++)
            {
                _animals[i] = sortedAnimals[i];
            }
        }

        public void SortByName()
        {
            /*
             If previous sort wasn't by name or if previous sort was by name
             in descending order.
             */
            if ((_lastUsedSortingParameter != SortingParameters.Name)
                || (_lastUsedSortingParameter == SortingParameters.Name
                && _lastUsedSortingDirection == SortingDirections.Desc))
            {
                _sortedAnimals = from animal in _animals
                                 orderby animal.Name ascending
                                 select animal;

                _lastUsedSortingParameter = SortingParameters.Name;
                _lastUsedSortingDirection = SortingDirections.Asc;
            }
            else
            {
                _sortedAnimals = from animal in _animals
                                 orderby animal.Name descending
                                 select animal;

                _lastUsedSortingParameter = SortingParameters.Name;
                _lastUsedSortingDirection = SortingDirections.Desc;
            }

            List<Animal> sortedAnimals = _sortedAnimals.ToList<Animal>();

            for (int i = 0; i < ListCount; i++)
            {
                _animals[i] = sortedAnimals[i];
            }
        }

        public void SortByAge()
        {
            /*
             If previous sort wasn't by name or if previous sort was by name
             in descending order.
             */
            if ((_lastUsedSortingParameter != SortingParameters.Age)
                || (_lastUsedSortingParameter == SortingParameters.Age
                && _lastUsedSortingDirection == SortingDirections.Desc))
            {
                _sortedAnimals = from animal in _animals
                                 orderby animal.Age ascending
                                 select animal;

                _lastUsedSortingParameter = SortingParameters.Age;
                _lastUsedSortingDirection = SortingDirections.Asc;
            }
            else
            {
                _sortedAnimals = from animal in _animals
                                 orderby animal.Age descending
                                 select animal;

                _lastUsedSortingParameter = SortingParameters.Age;
                _lastUsedSortingDirection = SortingDirections.Desc;
            }

            List<Animal> sortedAnimals = _sortedAnimals.ToList<Animal>();

            for (int i = 0; i < ListCount; i++)
            {
                _animals[i] = sortedAnimals[i];
            }
        }

        public void SortByGender()
        {
            /*
             If previous sort wasn't by name or if previous sort was by name
             in descending order.
             */
            if ((_lastUsedSortingParameter != SortingParameters.Gender)
                || (_lastUsedSortingParameter == SortingParameters.Gender
                && _lastUsedSortingDirection == SortingDirections.Desc))
            {
                _sortedAnimals = from animal in _animals
                                 orderby animal.Gender ascending
                                 select animal;

                _lastUsedSortingParameter = SortingParameters.Gender;
                _lastUsedSortingDirection = SortingDirections.Asc;
            }
            else
            {
                _sortedAnimals = from animal in _animals
                                 orderby animal.Gender descending
                                 select animal;

                _lastUsedSortingParameter = SortingParameters.Gender;
                _lastUsedSortingDirection = SortingDirections.Desc;
            }

            List<Animal> sortedAnimals = _sortedAnimals.ToList<Animal>();

            for (int i = 0; i < ListCount; i++)
            {
                _animals[i] = sortedAnimals[i];
            }
        }

        public void SortBySpecialCharacteristics()
        {
            /*
             If previous sort wasn't by name or if previous sort was by name
             in descending order.
             */
            if ((_lastUsedSortingParameter != SortingParameters.Specialcharacteristics)
                || (_lastUsedSortingParameter == SortingParameters.Specialcharacteristics
                && _lastUsedSortingDirection == SortingDirections.Desc))
            {
                _sortedAnimals = from animal in _animals
                                 orderby animal.GetSpecialCharacteristics() ascending
                                 select animal;

                _lastUsedSortingParameter = SortingParameters.Specialcharacteristics;
                _lastUsedSortingDirection = SortingDirections.Asc;
            }
            else
            {
                _sortedAnimals = from animal in _animals
                                 orderby animal.GetSpecialCharacteristics() descending
                                 select animal;

                _lastUsedSortingParameter = SortingParameters.Specialcharacteristics;
                _lastUsedSortingDirection = SortingDirections.Desc;
            }

            List<Animal> sortedAnimals = _sortedAnimals.ToList<Animal>();

            for (int i = 0; i < ListCount; i++)
            {
                _animals[i] = sortedAnimals[i];
            }
        }
    }
}
