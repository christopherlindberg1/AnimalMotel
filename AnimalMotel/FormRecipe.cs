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

        private Recipe _recipe;





        // ========================== Properties ========================== //
        public Recipe Recipe
        {
            get { return _recipe; }
            set { _recipe = value; }
        }




        // ========================== Mehtods ========================== //
        public FormRecipe()
        {
            InitializeComponent();
        }

        private void ClearIngredientInputField()
        {
            textBoxIngredient.Text = "";
        }

        private void AddIngredientToGUIList()
        {
            listBoxIngredients.Items.Add(textBoxIngredient.Text);
            textBoxIngredient.Text = "";
        }

        private Recipe CreateRecipeObject()
        {
            Recipe recipe = new Recipe();

            recipe.Name = textBoxName.Text;

            foreach(string item in listBoxIngredients.Items)
            {
                recipe.Ingredients.Add(item);
            }

            return recipe;
        }

        
















        // ========================== Events ========================== //

        /// <summary>
        ///   Validates that an ingredient is not empty befor adding it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidateIngredient())
            {
                AddIngredientToGUIList();
            }
            else
            {
                MessageBox.Show(MessageHandler.GetMessages());
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                // Creates recipe object that can be accessed and stored in FormMain.
                Recipe = CreateRecipeObject();
                // Sets dialogresult so FormMain knows if to fetch recipe or not.
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(MessageHandler.GetMessages());
            }
        }
    }
}
