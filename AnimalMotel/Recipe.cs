using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalMotel
{
    public class Recipe
    {
        private readonly ListManager<string> _ingredients = new ListManager<string>();
        private string _name;



        // ======================== Properties ======================== //
        public ListManager<string> Ingredients
        {
            get { return _ingredients; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }




        // ======================== Methods ======================== //

        /// <summary>
        ///   Returns a string representation of a recipe object.
        /// </summary>
        /// <returns>String representation of recipe object.</returns>
        public override string ToString()
        {
            StringBuilder recipeString = new StringBuilder();

            for (int i = 0; i < Ingredients.Count; i++)
            {
                recipeString.Append($"{ Ingredients[i] }. ");
            }

            return recipeString.ToString();
        }
    }
}
