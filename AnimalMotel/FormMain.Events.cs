using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Own namespaces
using AnimalMotel.Enums;
using AnimalMotel.Animals.Sorting;


namespace AnimalMotel
{
    /// <summary>
    ///   Partial class containing all events for the main form.
    /// </summary>
    public partial class FormMain : Form
    {
        /// <summary>
        ///   Event triggered when the selected index on listBoxCategory is changed.
        ///   Updates the GUI accordingly.
        /// </summary>
        private void listBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = listBoxCategory.SelectedIndex;

            if (selectedIndex != -1)
            {
                Category selectedCategory = (Category)Enum.Parse(
                    typeof(Category), listBoxCategory.SelectedItem.ToString());

                UpdateAnimalCategoryInputFields(selectedCategory);

                FillAnimalObjectList(selectedCategory);

                HideSpecieFieldsAndLabel();
            }
        }

        /// <summary>
        ///   Event triggered when the user clicks the checkbox for showing all animals.
        ///   Updates the GUI accordingliy.
        /// </summary>
        private void checkBoxListAllAnimals_CheckedChanged(object sender, EventArgs e)
        {
            listBoxCategory.SelectedIndex = -1;

            HideAnimalCategoryFieldsAndLabel();
            HideSpecieFieldsAndLabel();
            ShowFoodScheduleFields(false);

            if (checkBoxListAllAnimals.Checked)
            {
                ShowAllAminalsInObjectList();
                listBoxCategory.Enabled = false;
            }
            else
            {
                listBoxSpecies.Items.Clear();
                listBoxCategory.Enabled = true;
            }
        }

        /// <summary>
        ///   Event triggered when the selected index for listBoxSpecies is changes.
        ///   Updates the state of the GUI to match the selected item.
        /// </summary>
        private void listBoxSpecies_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxSpecies.SelectedIndex != -1)
            {
                Category category = GetAnimalCategoryByAnimal();
                UpdateAnimalCategoryInputFields(category);
                UpdateSpecieInputFields(listBoxSpecies.SelectedItem.ToString());
                UpdateFoodScheduleFields(listBoxSpecies.SelectedItem.ToString());
            }
        }

        /// <summary>
        ///   Click event for adding an animal.
        /// </summary>
        private void btnAddAnimal_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                AddAnimal();
                SetFormToDefaultState();
            }
            else
            {
                MessageBox.Show(
                    MessageHandler.GetMessages(),
                    "Info",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        /// <summary>
        ///   Event for sorting the animals by their attricutes when the 
        ///   user clicks in a column heading.
        /// </summary>
        private void listViewAnimals_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            int columnIndex = e.Column;

            switch (columnIndex)
            {
                case 0:
                    AnimalManager.Sort(new SortAnimalById());
                    break;

                case 1:
                    AnimalManager.Sort(new SortAnimalBySpecie());
                    break;

                case 2:
                    AnimalManager.Sort(new SortAnimalByName());
                    break;

                case 3:
                    AnimalManager.Sort(new SortAnimalByAge());
                    break;

                case 4:
                    AnimalManager.Sort(new SortAnimalByGender());
                    break;

                case 5:
                    AnimalManager.Sort(new SortAnimalBySpecialCharacteristics());
                    break;

                default:
                    throw new InvalidOperationException(
                        "Column index was not in within the range");
            }

            AddAnimalsToGUIList();
        }

        private void listViewAnimals_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewAnimals.SelectedIndices.Count == 0)
            {
                return;
            }
        }

        private void btnUpdateAnimal_Click(object sender, EventArgs e)
        {
            // Check that an animal is selected.
            if (listViewAnimals.SelectedIndices.Count == 0)
            {
                MessageBox.Show(
                    "You have to select an animal to change.",
                    "Info",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            // Check that no more than one animal is selected.
            if (listViewAnimals.SelectedIndices.Count > 1)
            {
                MessageBox.Show(
                    "Make sure you only mark one animal to change at the time!",
                    "Info",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            SetFormToEditState();

            int animalIndex = GetSelectedAnimalIndex();
            Animal animal = AnimalManager.GetAt(animalIndex);

            FillGUIWithAnimalData(animal);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (listViewAnimals.SelectedItems.Count == 0
                || listViewAnimals.SelectedItems.Count > 1)
            {
                MessageHandler.AddMessage("You must select only one animal.");
                return;
            }

            if (ValidateUpdatedInput())
            {
                UpdateAnimal();
                SetFormToDefaultState();
            }
            else
            {
                MessageBox.Show(
                    MessageHandler.GetMessages(),
                    "Info",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void btnDeleteAnimal_Click(object sender, EventArgs e)
        {
            // Check that an animal is selected.
            if (listViewAnimals.SelectedIndices.Count == 0)
            {
                MessageBox.Show(
                    "You have to select an animal to delete.",
                    "Info",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            DeleteMarkedAnimals();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SetFormToDefaultState();
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            DialogResult result = FormRecipe.ShowDialog();

            if (result == DialogResult.OK)
            {
                ShowRecipeList();
                AddRecipe(FormRecipe.Recipe);
            }
        }

        private void btnAddStaff_Click(object sender, EventArgs e)
        {
            DialogResult result = FormStaffPlanning.ShowDialog();

            if (result == DialogResult.OK)
            {
                ShowStaffList();
                AddStaff(FormStaffPlanning.Staff);
            }
        }

        private void lblShowFoods_Click(object sender, EventArgs e)
        {
            ShowRecipeList();
        }

        private void lblShowStaff_Click(object sender, EventArgs e)
        {
            ShowStaffList();
        }

        private void menuFileExit_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show(
                "Confirm that you want to exit.",
                "Confirm",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Information);

            if (confirm == DialogResult.OK)
            {
                Close();
            }
        }
    }
}
