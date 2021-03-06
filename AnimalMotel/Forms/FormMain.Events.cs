using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

// Own namespaces
using AnimalMotel.Enums;
using AnimalMotel.Animals.Sorting;
using AnimalMotel.Serialization;
using AnimalMotel.Storage;
using AnimalMotel.Animals.Species;

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

        /// <summary>
        ///   Clears everything in the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuFileNew_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Sure you want to start over? Unsaved changes will be lost.",
                "Warning",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Information);

            if (result == DialogResult.OK)
            {
                ResetForm();
            }
        }

        /// <summary>
        ///   Reads animal data from binary file.
        ///   Clears existing animal data in GUI and replaces it with data from file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuFileOpenBinaryFile_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Event for deserialization");

            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.InitialDirectory = Path.GetFullPath(Path.Combine(Application.StartupPath, "..\\..\\AppData\\Data"));
            fileDialog.Title = "Choose file to open";
            fileDialog.Filter = "Binary Files | *.bin";
            
            DialogResult result = fileDialog.ShowDialog();

            if (result == DialogResult.Cancel)
            {
                return;
            }

            try
            {
                //List<Animal> animals = LoadAnimalsFromFile(fileDialog.FileName);

                //AnimalManager.BinaryDeserialize(fileDialog.FileName);

                AnimalManager.List = BinarySerializerUtility.Deserialize<List<Animal>>(fileDialog.FileName);

                MessageBox.Show(AnimalManager.ListCount.ToString());

                //this.AnimalManager.AddAll(animals);

                AddAnimalsToGUIList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        ///   Saves the current list if animals in a new binary file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuFileSaveAsBinaryFile_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Event for serialization");

            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.InitialDirectory = FilePaths.AnimalDataFolderPath;
            fileDialog.Title = "Name the file for storing animal data";
            fileDialog.Filter = "Binary Files | *.bin";
            
            DialogResult result = fileDialog.ShowDialog();

            if (result == DialogResult.Cancel)
            {
                return;
            }

            MessageBox.Show(fileDialog.FileName);

            try
            {
                //AnimalManager.BinarySerialize(fileDialog.FileName);
                //Cat cat = new Cat("Zimba", 10, Gender.Male, 20, 20, 30);

                BinarySerializerUtility.Serialize<List<Animal>>(fileDialog.FileName, AnimalManager.List);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            //SaveAnimalsToFile(fileDialog.FileName);
        }

        /// <summary>
        ///   Reads recipe data from an XML file.
        ///   Clears existing recipe data in GUI and replaces it with data from file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuFileXMLImport_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        ///   Saves current list of recipes in a new XML file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuFileXMLExport_Click(object sender, EventArgs e)
        {

        }


        /// <summary>
        ///   Event for saving animals and recipes when clicking the save option.
        ///   Asks user to name files for animals and recipes if nothing has been saved before.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuFileSave_Click(object sender, EventArgs e)
        {
            // Get file paths for animals and recipes.
            

            
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
