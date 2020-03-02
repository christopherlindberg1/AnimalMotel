using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalMotel
{
    public partial class AnimalManager
    {

        public void SortById()
        {
            IOrderedEnumerable<Animal> animals = from animal in _animals
                                                 orderby animal.Id
                                                 select animal;

            _animals = animals.ToList<Animal>();
        }

        public void SortBySpecie()
        {
            IOrderedEnumerable<Animal> animals = from animal in _animals
                                                 orderby animal.GetSpecie()
                                                 select animal;

            _animals = animals.ToList<Animal>();
        }

        public void SortByName()
        {
            IOrderedEnumerable<Animal> animals = from animal in _animals
                                                 orderby animal.Name
                                                 select animal;

            _animals = animals.ToList<Animal>();
        }

        public void SortByAge()
        {
            IOrderedEnumerable<Animal> animals = from animal in _animals
                                                 orderby animal.Age
                                                 select animal;

            _animals = animals.ToList<Animal>();
        }

        public void SortByGender()
        {
            IOrderedEnumerable<Animal> animals = from animal in _animals
                                                 orderby animal.Gender
                                                 select animal;

            _animals = animals.ToList<Animal>();
        }

        public void SortBySpecialCharacteristics()
        {
            IOrderedEnumerable<Animal> animals = from animal in _animals
                                                 orderby animal.GetSpecialCharacteristics()
                                                 select animal;

            _animals = animals.ToList<Animal>();
        }


    }
}
