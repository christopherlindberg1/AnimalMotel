using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalMotel.Enums;


namespace AnimalMotel.Animals
{
    public interface IAnimal
    {
        int Id { get; set; }

        string Name { get; set; }

        int Age { get; set; }

        Gender Gender { get; set; }

        EaterType GetEaterType();

        FoodSchedule GetFoodSchedule();

        string GetSpecie();

        string GetSpecialCharacteristics();
    }
}