using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnimalMotel
{
    public partial class FormRecipe : Form
    {
        private readonly MessageHandler _messageHandler = new MessageHandler();



        // ======================= Properties ======================= //

        private MessageHandler MessageHandler
        {
            get { return this._messageHandler; }
        }


        
        // ======================= Methods ======================= //

        private bool ValidateInput()
        {
            bool recipeNameOk = ValidateRecipeName();
            bool ingredientsOk = ValidateAllIngredients();

            return recipeNameOk && ingredientsOk;
        }

        private bool ValidateTextBoxString(TextBox element, string errNullOrEmpty)
        {
            if (String.IsNullOrWhiteSpace(element.Text))
            {
                MessageHandler.AddMessage(errNullOrEmpty);
                return false;
            }

            return true;
        }

        private bool ValidateRecipeName()
        {
            return ValidateTextBoxString(textBoxName, "Name cannot be empty.");
        }

        private bool ValidateAllIngredients()
        {
            if (listBoxIngredients.Items.Count == 0)
            {
                MessageHandler.AddMessage("You must add at least one ingredient.");
                return false;
            }

            return true;
        }

        private bool ValidateIngredient()
        {
            return ValidateTextBoxString(textBoxIngredient, "Ingredient cannot be empty.");
        }

    }
}
