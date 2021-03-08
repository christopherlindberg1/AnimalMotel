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
using AnimalMotel.Enums;
using AnimalMotel.Animals.Sorting;
using AnimalMotel.Storage;
using System.Runtime.Serialization;

namespace AnimalMotel
{
    /// <summary>
    /// Partial class containing all events for the main form.
    /// </summary>
    public partial class FormMain : Form
    {
        #region EventHandlers
        private void SaveAppSettingsToStorage()
        {
            try
            {
                AppSettings.SaveSettingsToStorage();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void EventHandler_ListBoxCategoryIndexChange()
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

        private void EventHandler_CheckBoxListAllAnimals()
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

        private void EventHandler_ListBoxSpecieIndexChange()
        {
            if (listBoxSpecies.SelectedIndex != -1)
            {
                Category category = GetAnimalCategoryByAnimal();
                UpdateAnimalCategoryInputFields(category);
                UpdateSpecieInputFields(listBoxSpecies.SelectedItem.ToString());
                UpdateFoodScheduleFields(listBoxSpecies.SelectedItem.ToString());
            }
        }

        private void EventHandler_AddAnimal()
        {
            if (ValidateInput())
            {
                AddAnimal();
                SetFormToDefaultState();
                HasSavedData = false;
            }
            else
            {
                MessageBox.Show(
                    MessageHandler.GetMessages(),
                    "Info",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                
                return;
            }

            AppSettings.LastGeneratedId = AnimalManager.LastGeneratedId;
        }

        private void EventHandler_SortAnimals(ColumnClickEventArgs e)
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

        private void EventHandler_UpdateAnimal()
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

        private void EventHandler_SaveAnimalUpdates()
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
                HasSavedData = false;
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

        private void EventHandler_DeleteAnimal()
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
            HasSavedData = false;
        }

        private void EventHandler_AddFood()
        {
            DialogResult result = FormRecipe.ShowDialog();

            if (result == DialogResult.OK)
            {
                ShowRecipeList();
                AddRecipe(FormRecipe.Recipe);
            }
        }

        private void EventHandler_AddStaff()
        {
            DialogResult result = FormStaffPlanning.ShowDialog();

            if (result == DialogResult.OK)
            {
                ShowStaffList();
                AddStaff(FormStaffPlanning.Staff);
            }
        }

        private void EventHandler_RestartApp()
        {
            if (HasSavedData == false)
            {
                DialogResult result = MessageBox.Show(
                    "Sure you want to start over? Unsaved changes will be lost.",
                    "Warning",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Information);

                if (result == DialogResult.Cancel)
                {
                    return;
                }

                ResetForm();
                HasSavedData = true;
                return;
            }
         
            ResetForm();
            HasSavedData = true;
            LastUsedPathToAnimalsFile = null;

            SetFormToDefaultState();
        }

        private void EventHandler_OpenAnimalFile()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.InitialDirectory = FilePaths.AnimalDataFolderPath;
            fileDialog.Title = "Choose file to open";
            fileDialog.Filter = "Binary Files | *.bin";

            DialogResult result = fileDialog.ShowDialog();

            if (result == DialogResult.Cancel)
            {
                return;
            }

            try
            {
                AnimalManager.BinaryDeserialize(fileDialog.FileName);
                LastUsedPathToAnimalsFile = fileDialog.FileName;

                AddAnimalsToGUIList();
            }
            catch (SerializationException ex)
            {
                MessageBox.Show("The file you chose does not have data in the correct format.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetType().Name);
                MessageBox.Show("Something went wrong when reading the file.");
            }
        }

        private void EventHandler_SaveAnimalsToFile_SaveAs()
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.InitialDirectory = FilePaths.AnimalDataFolderPath;
            fileDialog.Title = "Name the file for storing animal data";
            fileDialog.Filter = "Binary Files | *.bin";

            DialogResult result = fileDialog.ShowDialog();

            if (result == DialogResult.Cancel)
            {
                return;
            }

            try
            {
                // Save animals
                AnimalManager.BinarySerialize(fileDialog.FileName);
                LastUsedPathToAnimalsFile = fileDialog.FileName;
                
                HasSavedData = true;
                
                // Save app settings
                SaveAppSettingsToStorage();
            }
            catch (SerializationException ex)
            {
                MessageBox.Show("The file you chose does not have data in the correct format.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetType().Name);
                MessageBox.Show("Something went wrong when reading the file.");
            }
        }

        private void EventHandler_SaveAnimalsToFile_Save()
        {
            if (String.IsNullOrWhiteSpace(LastUsedPathToAnimalsFile))
            {
                EventHandler_SaveAnimalsToFile_SaveAs();
                SaveAppSettingsToStorage();
                return;
            }

            try
            {
                AnimalManager.BinarySerialize(LastUsedPathToAnimalsFile);
                SaveAppSettingsToStorage();

                HasSavedData = true;

                MessageBox.Show(
                    "The animals have been saved.",
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (SerializationException ex)
            {
                MessageBox.Show("The file you chose does not have data in the correct format.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetType().Name);
                MessageBox.Show("Something went wrong when reading the file.");
            }
        }

        private void EventHandler_SaveRecipesToFile()
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.InitialDirectory = FilePaths.RecipesDataFolderPath;
            fileDialog.Title = "Name the file for storing recipe data";
            fileDialog.Filter = "XML Files | *.xml";

            DialogResult result = fileDialog.ShowDialog();

            if (result == DialogResult.Cancel)
            {
                return;
            }

            try
            {
                // Save recipes
                RecipeManager.XMLSerialize(fileDialog.FileName);
                //LastUsedPathToAnimalsFile = fileDialog.FileName;
            }
            catch (SerializationException)
            {
                MessageBox.Show("The file you chose does not have data in the correct format.");
            }
            catch (Exception ex)
            {
                throw;
                MessageBox.Show(ex.GetType().Name);
                MessageBox.Show("Something went wrong when reading the file.");
            }
        }

        private void EventHandler_OpenRecipesFile()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.InitialDirectory = FilePaths.RecipesDataFolderPath;
            fileDialog.Title = "Choose file to open";
            fileDialog.Filter = "XML Files | *.xml";

            DialogResult result = fileDialog.ShowDialog();

            if (result == DialogResult.Cancel)
            {
                return;
            }

            try
            {
                // Load recipes
                RecipeManager.XmlDeserialize(fileDialog.FileName);
                AddRecipesToGUI();
                MessageBox.Show(RecipeManager.List.Count.ToString());
                //LastUsedPathToAnimalsFile = fileDialog.FileName;
            }
            catch (SerializationException)
            {
                throw;
                MessageBox.Show("The file you chose does not have data in the correct format.");
            }
            catch (Exception ex)
            {
                throw;
                MessageBox.Show(ex.GetType().Name);
                MessageBox.Show("Something went wrong when reading the file.");
            }
        }

        private void EventHandler_ExitApp()
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
        #endregion

        #region Events
        /// <summary>
        /// Event triggered when the selected index on listBoxCategory is changed.
        /// Updates the GUI accordingly.
        /// </summary>
        private void listBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            EventHandler_ListBoxCategoryIndexChange();
        }

        /// <summary>
        /// Event triggered when the user clicks the checkbox for showing all animals.
        /// Updates the GUI accordingliy.
        /// </summary>
        private void checkBoxListAllAnimals_CheckedChanged(object sender, EventArgs e)
        {
            EventHandler_CheckBoxListAllAnimals();
        }

        /// <summary>
        /// Event triggered when the selected index for listBoxSpecies is changes.
        /// Updates the state of the GUI to match the selected item.
        /// </summary>
        private void listBoxSpecies_SelectedIndexChanged(object sender, EventArgs e)
        {
            EventHandler_ListBoxSpecieIndexChange();
        }

        /// <summary>
        /// Click event for adding an animal.
        /// </summary>
        private void btnAddAnimal_Click(object sender, EventArgs e)
        {
            EventHandler_AddAnimal();
        }

        /// <summary>
        /// Event for sorting the animals by their attricutes when the 
        /// user clicks in a column heading.
        /// </summary>
        private void listViewAnimals_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            EventHandler_SortAnimals(e);
        }

        private void btnUpdateAnimal_Click(object sender, EventArgs e)
        {
            EventHandler_UpdateAnimal();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            EventHandler_SaveAnimalUpdates();
        }

        private void btnDeleteAnimal_Click(object sender, EventArgs e)
        {
            EventHandler_DeleteAnimal();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SetFormToDefaultState();
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            EventHandler_AddFood();
        }

        private void btnAddStaff_Click(object sender, EventArgs e)
        {
            EventHandler_AddStaff();
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
        /// Clears everything in the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuFileNew_Click(object sender, EventArgs e)
        {
            EventHandler_RestartApp();
        }

        /// <summary>
        /// Reads animal data from binary file.
        /// Clears existing animal data in GUI and replaces it with data from file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuFileOpenBinaryFile_Click(object sender, EventArgs e)
        {
            EventHandler_OpenAnimalFile();
        }

        /// <summary>
        /// Saves the current list if animals in a new binary file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuFileSaveAsBinaryFile_Click(object sender, EventArgs e)
        {
            EventHandler_SaveAnimalsToFile_SaveAs();
        }

        /// <summary>
        /// Reads recipe data from an XML file.
        /// Clears existing recipe data in GUI and replaces it with data from file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuFileXMLImport_Click(object sender, EventArgs e)
        {
            EventHandler_OpenRecipesFile();
        }

        /// <summary>
        /// Saves current list of recipes in a new XML file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuFileXMLExport_Click(object sender, EventArgs e)
        {
            EventHandler_SaveRecipesToFile();
        }

        /// <summary>
        /// Event for saving animals and recipes when clicking the save option.
        /// Asks user to name files for animals and recipes if nothing has been saved before.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuFileSave_Click(object sender, EventArgs e)
        {
            // Get file paths for animals and recipes.
            if (String.IsNullOrEmpty(LastUsedPathToAnimalsFile))
            {
                EventHandler_SaveAnimalsToFile_SaveAs();
                return;
            }

            EventHandler_SaveAnimalsToFile_Save();
        }

        private void menuFileExit_Click(object sender, EventArgs e)
        {
            EventHandler_ExitApp();
        }
        #endregion
    }
}
