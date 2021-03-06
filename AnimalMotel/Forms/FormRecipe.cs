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
            SetFormToDefaultState();
            Recipe = new Recipe();
        }

        private void ClearIngredientInputField()
        {
            textBoxIngredient.Text = "";
        }

        private void ClearAllInputFields()
        {
            textBoxName.Text = "";
            listBoxIngredients.Items.Clear();
            ClearIngredientInputField();
        }

        private void SetFormToDefaultState()
        {
            listBoxIngredients.SelectedIndex = -1;
            lblIngredient.Text = "Add ingredient";
            btnChange.Enabled = false;
            btnDelete.Enabled = false;
            ClearIngredientInputField();
        }

        private void SetFormToEditState()
        {
            lblIngredient.Text = "Change ingredient";
            btnChange.Enabled = true;
            btnDelete.Enabled = true;
            textBoxIngredient.Text = listBoxIngredients.SelectedItem.ToString();
        }

        private void AddIngredientToGUIList()
        {
            listBoxIngredients.Items.Add(textBoxIngredient.Text);
            textBoxIngredient.Text = "";
            listBoxIngredients.SelectedIndex = -1;
        }

        private void ChangeIngredient()
        {
            if (listBoxIngredients.SelectedIndex == -1)
            {
                return;
            }

            if (ValidateIngredient())
            {
                listBoxIngredients.Items[listBoxIngredients.SelectedIndex]
                    = textBoxIngredient.Text;
                listBoxIngredients.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show(MessageHandler.GetMessages());
            }
        }

        private void DeleteIngredient()
        {
            if (listBoxIngredients.SelectedIndex == -1)
            {
                return;
            }

            listBoxIngredients.Items.RemoveAt(listBoxIngredients.SelectedIndex);
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

        private void FormRecipe_Load(object sender, EventArgs e)
        {
            ClearAllInputFields();
        }

        /// <summary>
        /// Validates that an ingredient is not empty befor adding it.
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

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (listBoxIngredients.SelectedIndex == -1)
            {
                return;
            }

            ChangeIngredient();
            SetFormToDefaultState();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listBoxIngredients.SelectedIndex == -1)
            {
                MessageBox.Show("You must select an ingredient to delete.");
                return;
            }

            DeleteIngredient();
            SetFormToDefaultState();
        }

        private void listBoxIngredients_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxIngredients.SelectedIndex == -1)
            {
                return;
            }

            SetFormToEditState();
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
