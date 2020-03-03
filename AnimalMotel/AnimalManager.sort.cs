﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Own namespaces
using AnimalMotel.Enums.Sorting;
using AnimalMotel.Animals.Sorting;

namespace AnimalMotel
{
    /// <summary>
    ///   Partial AnimalManager class. This file contains methods
    ///   sort the animal objects.
    /// </summary>
    public partial class AnimalManager
    {
        private IOrderedEnumerable<Animal> _sortedAnimals;
        private SortingParameters _lastUsedSortingParameter = SortingParameters.Id;
        private SortingDirections _lastUsedSortingDirection = SortingDirections.Asc;
        private SortAnimalByAge _sortAnimalByAge = new SortAnimalByAge();
        private SortAnimalByGender _sortAnimalByGender = new SortAnimalByGender();
        private SortAnimalById _sortAnimalById = new SortAnimalById();
        private SortAnimalByName _sortAnimalByName = new SortAnimalByName();
        private SortAnimalBySpecialCharacteristics _sortAnimalBySpecialCharacteristics = new SortAnimalBySpecialCharacteristics();
        private SortAnimalBySpecie _sortAnimalBySpecie = new SortAnimalBySpecie();



        /// <summary>
        ///   Sorts animals by their ID.
        ///   Checks the current state to determine if to sort
        ///   ascending ordescending, and then updates state.
        /// </summary>
        public void SortById()
        {
            /*
             If previous sort wasn't by id or if previous sort was by id
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

        /// <summary>
        ///   Sorts animals by their specie.
        ///   Checks the current state to determine if to sort
        ///   ascending ordescending, and then updates state.
        /// </summary>
        public void SortBySpecie()
        {
            /*
             If previous sort wasn't by specie or if previous sort was by specie
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

        /// <summary>
        ///   Sorts animals by their Name.
        ///   Checks the current state to determine if to sort
        ///   ascending ordescending, and then updates state.
        /// </summary>
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

        /// <summary>
        ///   Sorts animals by their age.
        ///   Checks the current state to determine if to sort
        ///   ascending ordescending, and then updates state.
        /// </summary>
        public void SortByAge()
        {
            /*
             If previous sort wasn't by age or if previous sort was by age
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

        /// <summary>
        ///   Sorts animals by their gender.
        ///   Checks the current state to determine if to sort
        ///   ascending ordescending, and then updates state.
        /// </summary>
        public void SortByGender()
        {
            /*
             If previous sort wasn't by gender or if previous sort was by gender
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

        /// <summary>
        ///   Sorts animals by their special characteristics (just compares
        ///   the strings that represent all special characteristics).
        ///   Checks the current state to determine if to sort
        ///   ascending ordescending, and then updates state.
        /// </summary>
        public void SortBySpecialCharacteristics()
        {
            /*
             If previous sort wasn't by special characteristics or if
             previous sort was by special characteristics in descending order.
             */
            if ((_lastUsedSortingParameter != SortingParameters.SpecialCharacteristics)
                || (_lastUsedSortingParameter == SortingParameters.SpecialCharacteristics
                && _lastUsedSortingDirection == SortingDirections.Desc))
            {
                _sortedAnimals = from animal in _animals
                                 orderby animal.GetSpecialCharacteristics() ascending
                                 select animal;

                _lastUsedSortingParameter = SortingParameters.SpecialCharacteristics;
                _lastUsedSortingDirection = SortingDirections.Asc;
            }
            else
            {
                _sortedAnimals = from animal in _animals
                                 orderby animal.GetSpecialCharacteristics() descending
                                 select animal;

                _lastUsedSortingParameter = SortingParameters.SpecialCharacteristics;
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
