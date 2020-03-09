using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalMotel
{
    public class Recipe
    {
        private string _name;
        private readonly ListManager<string> _ingredients = new ListManager<string>();




        // ======================== Properties ======================== //

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public ListManager<string> Ingredients
        {
            get { return _ingredients; }
        }




        // ======================== Methods ======================== //

        /// <summary>
        ///   Returns a string representation of a recipe object.
        /// </summary>
        /// <returns>String representation of recipe object.</returns>
        public override string ToString()
        {
            StringBuilder recipeString = new StringBuilder();

            recipeString.Append($"{ Name }. ");
            recipeString.Replace(recipeString[0],
                char.Parse(recipeString[0].ToString().ToUpper()));

            for (int i = 0; i < Ingredients.Count; i++)
            {
                recipeString.Append($"{ Ingredients[i] }, ");
            }

            return recipeString.ToString();
        }
    }
}
