using System;
using System.IO;
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
using AnimalMotel.Enums.Sorting;
using AnimalMotel.Factories;
using AnimalMotel.Animals.Species;
using AnimalMotel.Animals.Categories;


namespace AnimalMotel
{
    /// <summary>
    ///   Main class for the main Form. This class is split into multiple files.
    ///   This file handles the main tasks like controlling the flow of execution
    ///   and events.
    /// </summary>
    partial class FormMain : Form
    {
        // Managers
        private readonly AnimalManager _animalManager = new AnimalManager();
        private readonly RecipeManager _recipeManager = new RecipeManager();
        private readonly StaffManager _staffManager = new StaffManager();

        // Forms
        private FormRecipe _formRecipe = new FormRecipe();
        private FormStaffPlanning _formStaffPlanning = new FormStaffPlanning();




        // ======================= Properties ======================= //

        private AnimalManager AnimalManager
        {
            get { return _animalManager; }
        }

        private RecipeManager RecipeManager
        {
            get { return _recipeManager; }
        }

        private StaffManager StaffManager
        {
            get { return _staffManager; }
        }

        private FormRecipe FormRecipe
        {
            get { return _formRecipe; }
            set { _formRecipe = value; }
        }

        private FormStaffPlanning FormStaffPlanning
        {
            get { return _formStaffPlanning; }
            set { _formStaffPlanning = value; }
        }




        // ======================= Methods ======================= //

        public FormMain()
        {
            InitializeComponent();
            InitializeApp();
        }

        private void HideAllAnimalCategoryFields()
        {
            ShowMammalInputFields(false);
            ShowBirdInputFields(false);
        }

        private void HideAnimalCategoryFieldsAndLabel()
        {
            HideAllAnimalCategoryFields();
            groupBoxAnimalCategorySpecs.Text = "";
        }

        private void ShowMammalInputFields(bool show)
        {
            lblNrOfTeeth.Visible = show;
            lblTailLength.Visible = show;
            textBoxNrOfTeeth.Visible = show;
            textBoxTailLength.Visible = show;
        }

        private void ShowBirdInputFields(bool show)
        {
            lblFlyingSpeed.Visible = show;
            textBoxFlyingSpeed.Visible = show;
        }

        private void HideAllSpecieFields()
        {
            ShowEagleInputFields(false);
            ShowPigeonInputFields(false);
            ShowCatInputFields(false);
            ShowDogInputFields(false);
        }

        private void HideSpecieFieldsAndLabel()
        {
            HideAllSpecieFields();
            groupBoxSpecieSpecificData.Text = "";
        }

        private void ShowEagleInputFields(bool show)
        {
            lblClawLength.Visible = show;
            textBoxClawLength.Visible = show;
        }

        private void ShowPigeonInputFields(bool show)
        {
            lblBeakLength.Visible = show;
            textBoxBeakLength.Visible = show;
        }

        private void ShowCatInputFields(bool show)
        {
            lblNrOfLives.Visible = show;
            textBoxNrOfLives.Visible = show;
        }

        private void ShowDogInputFields(bool show)
        {
            lblBreed.Visible = show;
            textBoxBreed.Visible = show;
        }

        private void ShowFoodScheduleFields(bool show)
        {
            lblEaterType.Visible = show;
            lblShowEaterType.Visible = show;
            listBoxFoodSchedule.Visible = show;
        }

        /// <summary>
        ///   Sets the form controls to the default state.
        /// </summary>
        private void SetFormToDefaultState()
        {
            checkBoxListAllAnimals.Checked = false;

            btnAddAnimal.Enabled = true;
            btnChangeAnimal.Enabled = true;
            btnDeleteAnimal.Enabled = true;

            listBoxCategory.Enabled = true;
            listBoxSpecies.Enabled = true;
            listBoxSpecies.Items.Clear();

            ClearInput();
            HideSpecieFieldsAndLabel();
            HideAnimalCategoryFieldsAndLabel();
            ShowFoodScheduleFields(false);
        }

        /// <summary>
        ///   Updates the GUI elements so that animal objects can be changed.
        /// </summary>
        private void SetFormToEditState()
        {
            btnAddAnimal.Enabled = false;
            btnChangeAnimal.Enabled = true;
            btnDeleteAnimal.Enabled = true;
            listBoxCategory.Enabled = false;
            listBoxSpecies.Enabled = false;
        }

        /// <summary>
        ///   Fills the animal object list with all animals
        ///   that belong to the specified category.
        ///   Gives error is argument doesn't match an enum for animal category
        /// </summary>
        /// <param name="animalCategory">String with the item clicked in in Category</param>
        private void FillAnimalObjectList(Category animalCategory)
        {
            listBoxSpecies.Items.Clear();

            switch (animalCategory)
            {
                case (Category.Bird):
                    listBoxSpecies.Items.AddRange(
                        Enum.GetNames(typeof(BirdSpecies)));
                    break;

                case (Category.Mammal):
                    listBoxSpecies.Items.AddRange(
                        Enum.GetNames(typeof(MammalSpecies)));
                    break;
            }
        }

        /// <summary>
        ///   Shows all species in the specie listbox.
        /// </summary>
        private void ShowAllAminalsInObjectList()
        {
            listBoxSpecies.Items.Clear();
            listBoxSpecies.Items.AddRange(GetAllSpecies());
        }

        /// <summary>
        ///   Finds all file names in the folder named "Species" and stored them in an array.
        ///   (each file name corresponds to the class name for a specie)
        /// </summary>
        /// <returns>Array containing names for all species.</returns>
        private string[] GetAllSpecies()
        {
            string pathToSpeciesFolder = Path.GetFullPath(
                Path.Combine(Application.StartupPath, "..\\..\\", "Animals/Species/"));

            string[] species = Directory.GetFiles(pathToSpeciesFolder);

            for (int i = 0; i < species.Length; i++)
            {
                species[i] = Path.GetFileNameWithoutExtension(species[i]);
            }

            return species;
        }

        /// <summary>
        ///   Updates the label of the section covering animal category
        ///   specific input fields. Hides irrelevant fields.
        /// </summary>
        /// <param name="animalCategory">Animal category.</param>
        private void UpdateAnimalCategoryInputFields(Category animalCategory)
        {
            StringBuilder category = new StringBuilder(animalCategory.ToString());
            category.Replace(category[0].ToString(), category[0].ToString().ToUpper());

            groupBoxAnimalCategorySpecs.Text =
                $"{category.ToString()} specifications";

            HideAllAnimalCategoryFields();

            switch (animalCategory)
            {
                case Category.Bird:
                    ShowBirdInputFields(true);
                    break;

                case Category.Mammal:
                    ShowMammalInputFields(true);
                    break;

                default:
                    throw new InvalidOperationException(
                        "Animal category did not match an existing category");
            }
        }

        /// <summary>
        ///   Updates the label of the section covering specie specific input
        ///   fields. Hides irrelevant fields.
        /// </summary>
        /// <param name="specie">Name of the specie.</param>
        private void UpdateSpecieInputFields(string specie)
        {
            StringBuilder specieBuilder = new StringBuilder(specie);
            specieBuilder.Replace(specieBuilder[0].ToString(), specieBuilder[0].ToString().ToUpper());

            groupBoxSpecieSpecificData.Text =
                $"{specieBuilder.ToString()} specifications";

            HideAllSpecieFields();

            switch (specie)
            {
                case "Eagle":
                    ShowEagleInputFields(true);
                    break;

                case "Pigeon":
                    ShowPigeonInputFields(true);
                    break;

                case "Cat":
                    ShowCatInputFields(true);
                    break;

                case "Dog":
                    ShowDogInputFields(true);
                    break;

                default:
                    throw new ArgumentException("specie did not match any case", "specie");
            }
        }

        /// <summary>
        ///   Updates the section for the food schedule depending on what
        ///   specie is selcted.
        /// </summary>
        /// <param name="specie">Name of the specie.</param>
        private void UpdateFoodScheduleFields(string specie)
        {
            listBoxFoodSchedule.Items.Clear();

            switch (specie)
            {
                case "Eagle":
                    ShowFoodScheduleEagle();
                    break;

                case "Pigeon":
                    ShowFoodSchedulePigeon();
                    break;

                case "Cat":
                    ShowFoodScheduleCat();
                    break;

                case "Dog":
                    ShowFoodScheduleDog();
                    break;

                default:
                    throw new ArgumentException("specie did not match any case", "specie");
            }

            ShowFoodScheduleFields(true);
        }

        /// <summary>
        ///   Shows the food schedule for eagles.
        /// </summary>
        private void ShowFoodScheduleEagle()
        {
            lblShowEaterType.Text = EaterType.Carnivore.ToString();
            
            Eagle eagle = new Eagle();

            listBoxFoodSchedule.Items.Add("Feeding instructions for eagles:");
            
            for (int i = 0; i < eagle.FoodSchedule.NrOfFoodDescriptions; i++)
            {
                listBoxFoodSchedule.Items.Add(eagle.FoodSchedule.GetFoodSchedule(i));
            }
        }

        /// <summary>
        ///   Shows the food schedule for pigeons.
        /// </summary>
        private void ShowFoodSchedulePigeon()
        {
            lblShowEaterType.Text = EaterType.Omnivorous.ToString();

            Pigeon pigeon = new Pigeon();

            listBoxFoodSchedule.Items.Add("Feeding instructions for Pigeons:");

            for (int i = 0; i < pigeon.FoodSchedule.NrOfFoodDescriptions; i++)
            {
                listBoxFoodSchedule.Items.Add(pigeon.FoodSchedule.GetFoodSchedule(i));
            }
        }

        /// <summary>
        ///   Shows the food schedule for cats.
        /// </summary>
        private void ShowFoodScheduleCat()
        {
            lblShowEaterType.Text = EaterType.Carnivore.ToString();

            Cat cat = new Cat();

            listBoxFoodSchedule.Items.Add("Feeding instructions for cats:");

            for (int i = 0; i < cat.FoodSchedule.NrOfFoodDescriptions; i++)
            {
                listBoxFoodSchedule.Items.Add(cat.FoodSchedule.GetFoodSchedule(i));
            }
        }

        /// <summary>
        ///   Shows the food schedule for cats.
        /// </summary>
        private void ShowFoodScheduleDog()
        {
            lblShowEaterType.Text = EaterType.Carnivore.ToString();

            Dog dog = new Dog();

            listBoxFoodSchedule.Items.Add("Feeding instructions for dogs:");

            for (int i = 0; i < dog.FoodSchedule.NrOfFoodDescriptions; i++)
            {
                listBoxFoodSchedule.Items.Add(dog.FoodSchedule.GetFoodSchedule(i));
            }
        }

        /// <summary>
        ///   Clears and resets all input fields.
        /// </summary>
        private void ClearInput()
        {
            textBoxName.Text = "";
            textBoxAge.Text = "";
            textBoxNrOfTeeth.Text = "";
            textBoxTailLength.Text = "";
            textBoxFlyingSpeed.Text = "";
            textBoxClawLength.Text = "";
            textBoxBeakLength.Text = "";
            textBoxNrOfLives.Text = "";
            textBoxBreed.Text = "";

            listBoxGender.SelectedIndex = -1;
            listBoxCategory.SelectedIndex = -1;
            listBoxSpecies.SelectedIndex = -1;
        }

        /// <summary>
        ///   Returns the Category enum value that match the selected category.
        /// </summary>
        /// <returns>Category enum value.</returns>
        private Category GetAnimalCategory()
        {
            Category selectedCategory;

            // If user has explicitly selected an animal category
            if (listBoxCategory.SelectedIndex != -1)
            {
                selectedCategory = (Category)Enum.Parse(
                    typeof(Category), listBoxCategory.SelectedItem.ToString());
            }
            // If user has only selected an animal, and not category
            else
            {
                selectedCategory = GetAnimalCategoryByAnimal();
            }

            return selectedCategory;
        }

        /// <summary>
        ///   Returns the category of the selected animal by checking if
        ///   the selected animal matches any value in any of the specified enums
        ///   for animal categories.
        /// </summary>
        /// <returns>Category value for the selected specie</returns>
        private Category GetAnimalCategoryByAnimal()
        {
            if (listBoxSpecies.SelectedIndex == -1)
            {
                throw new InvalidOperationException("Shouldn't call this method" +
                    "when index of listboxSpecies could be -1");
            }

            string selectedSpecie = listBoxSpecies.SelectedItem.ToString();

            if (Enum.IsDefined(typeof(BirdSpecies), selectedSpecie))
                return Category.Bird;

            else if (Enum.IsDefined(typeof(MammalSpecies), selectedSpecie))
                return Category.Mammal;

            else
                throw new InvalidOperationException(
                    "Selected specie did not match any enum." +
                    "Check all AnimalCategory-enums");
        }

        /// <summary>
        ///   Returns the name of the selected specie in the listbox with species.
        /// </summary>
        /// <returns>String with the name of the selected specie.</returns>
        private string GetSelectedSpecie()
        {
            if (listBoxSpecies.SelectedIndex == -1)
                return null;

            return listBoxSpecies.SelectedItem.ToString();
        }

        /// <summary>
        ///   Returns a dictionary containing the string data for ALL fields in 
        ///   the form.
        /// </summary>
        /// <returns>Dictionary with user input data.</returns>
        private Dictionary<string, string> GetUserInput()
        {
            Dictionary<string, string> data = new Dictionary<string, string>
            {
                // General animal data
                { "name", textBoxName.Text },
                { "age", textBoxAge.Text },
                { "gender", listBoxGender.SelectedItem.ToString() },

                // Data for mammals
                { "nrOfTeeth", textBoxNrOfTeeth.Text },
                { "tailLength", textBoxTailLength.Text },

                // Data for birds
                { "flyingSpeed", textBoxFlyingSpeed.Text },

                /*
                 Data specific for species
                 */
                { "clawLength", textBoxClawLength.Text },   // For eagles
                { "beakLength", textBoxBeakLength.Text },   // For pigeons
                { "breed", textBoxBreed.Text },             // For dogs
                { "lives", textBoxNrOfLives.Text }         // For cats
            };

            return data;
        }

        /// <summary>
        ///   Adds animal to the storage and to the GUI.
        /// </summary>
        private void AddAnimal()
        {
            Animal animal;

            Category category = GetAnimalCategory();
            String specie = GetSelectedSpecie();

            // Storing user input in a dictionary so it can be passed to a factory class.
            Dictionary<string, string> animalData = GetUserInput();

            switch (category)
            {
                case Category.Bird:
                    BirdSpecies birdSpecie = (BirdSpecies)Enum.Parse(
                        typeof(BirdSpecies), specie);
                    animal = BirdFactory.CreateBird(birdSpecie, animalData);
                    break;

                case Category.Mammal:
                    MammalSpecies mammalSpecie = (MammalSpecies)Enum.Parse(
                        typeof(MammalSpecies), specie);
                    animal = MammalFactory.CreateMammal(mammalSpecie, animalData);
                    break;

                default:
                    throw new InvalidOperationException(
                        "The category did not match any case");
            }

            AnimalManager.AddAnimal(animal);
            AddAnimalsToGUIList();
        }

        /// <summary>
        ///   Clears the list with animals in the GUI and then
        ///   adds all animals that are stored in the AnimalManager.
        /// </summary>
        private void AddAnimalsToGUIList()
        {
            listViewAnimals.Items.Clear();

            Animal animal;

            for (int i = 0; i < AnimalManager.ListCount; i++)
            {
                animal = AnimalManager.GetAnimalAt(i);

                ListViewItem item = new ListViewItem(
                    animal.Id.ToString());

                item.SubItems.Add(animal.GetSpecie());
                item.SubItems.Add(animal.Name);
                item.SubItems.Add(animal.Age.ToString());
                item.SubItems.Add(animal.Gender.ToString());
                item.SubItems.Add(animal.GetSpecialCharacteristics());

                listViewAnimals.Items.Add(item);
            }
        }

        /// <summary>
        ///   Updates the GUI to match a specific specie.
        /// </summary>
        /// <param name="animalCategory">Category of the animal.</param>
        /// <param name="specie">Specie of the animal.</param>
        private void UpdateGUIToSpecie(Category animalCategory, string specie)
        {
            UpdateAnimalCategoryInputFields(animalCategory);
            UpdateSpecieInputFields(specie);
            UpdateFoodScheduleFields(specie);
        }

        /// <summary>
        ///   Updates an animal to the new data submitted in the form.
        /// </summary>
        private void ChangeAnimal()
        {
            if (listViewAnimals.SelectedIndices.Count == 0)
            {
                return;
            }

            int animalId = GetSelectedAnimalId();
            int index = listViewAnimals.SelectedIndices[0];

            Animal animal = AnimalManager.GetAnimalAt(index);
        }

        /// <summary>
        ///   Fills the input fields with data from an animal.
        /// </summary>
        /// <param name="animal">Animal object.</param>
        private void FillGUIWithAnimalData(Animal animal)
        {
            ClearInput();

            Category category = GetAnimalCategory(animal);
            UpdateGUIToSpecie(category, animal.GetSpecie());

            FillGUIWithGeneralAnimalData(animal);
            FillGUIWithAnimalCategoryData(category, animal);
            FillGUIWithSpecieSpecificData(animal);
            
        }

        private void FillGUIWithGeneralAnimalData(Animal animal)
        {
            textBoxName.Text = animal.Name;
            textBoxAge.Text = animal.Age.ToString();
            SetListBoxGender(animal);
        }

        private void FillGUIWithAnimalCategoryData(Category category, Animal animal)
        {
            // Type casting to the animals category so category specific data can be read.
            switch (category)
            {
                case Category.Bird:
                    Bird bird = animal as Bird;
                    textBoxFlyingSpeed.Text = bird.FlyingSpeed.ToString();
                    break;
                case Category.Mammal:
                    Mammal mammal = animal as Mammal;
                    textBoxNrOfTeeth.Text = mammal.NrOfTeeth.ToString();
                    textBoxTailLength.Text = mammal.TailLegth.ToString();
                    break;
            }
        }

        private void FillGUIWithSpecieSpecificData(Animal animal)
        {
            // Check what specie the animal is and to a type cast
            // to access specie specific data.
            if (animal is Eagle)
            {
                Eagle eagle = animal as Eagle;
                textBoxClawLength.Text = eagle.ClawLength.ToString();
            }
            else if (animal is Pigeon)
            {
                Pigeon pigeon = animal as Pigeon;
                textBoxBeakLength.Text = pigeon.BeakLength.ToString();
            }
            else if (animal is Cat)
            {
                Cat cat = animal as Cat;
                textBoxNrOfLives.Text = cat.Lives.ToString();
            }
            else if (animal is Dog)
            {
                Dog dog = animal as Dog;
                textBoxBreed.Text = dog.Breed;
            }
            else
            {
                throw new InvalidOperationException(
                    "Animal did not match any specie. Missing if-statement?");
            }
        }

        /// <summary>
        ///   Returns the animal category for a given animal.
        /// </summary>
        /// <param name="animal">Animal object.</param>
        /// <returns>Category value.</returns>
        private Category GetAnimalCategory(Animal animal)
        {
            if (Enum.IsDefined(typeof(BirdSpecies), animal.GetSpecie()))
            {
                return Category.Bird;
            }
            else if (Enum.IsDefined(typeof(MammalSpecies), animal.GetSpecie()))
            {
                return Category.Mammal;
            }
            else
            {
                throw new InvalidOperationException("" +
                    "Animal did not match any specie. Missing if-statement?");
            }
        }

        /// <summary>
        ///   Sets the gender in listBoxGender to match an animal.
        /// </summary>
        /// <param name="animal">Animal object.</param>
        private void SetListBoxGender(Animal animal)
        {
            switch (animal.Gender)
            {
                case Gender.Female:
                    listBoxGender.SelectedIndex = 0;
                    break;
                case Gender.Male:
                    listBoxGender.SelectedIndex = 1;
                    break;
                case Gender.Unknown:
                    listBoxGender.SelectedIndex = 2;
                    break;
            }
        }

        /// <summary>
        ///   Returns the id of the selected animal.
        /// </summary>
        /// <returns>Id.</returns>
        private int GetSelectedAnimalId()
        {
            // Return -1 if no animal or multiple animals are selected.
            if (listViewAnimals.SelectedItems.Count == 0
                || listViewAnimals.SelectedItems.Count > 1)
            {
                return -1;
            }

            int id = -1;

            int.TryParse(listViewAnimals.SelectedItems[0].SubItems[0].Text, out id);

            return id;
        }

        /// <summary>
        ///   Deletes marked animals.
        /// </summary>
        private void DeleteMarkedAnimals()
        {
            int nrOfAnimalsToDelete = listViewAnimals.SelectedIndices.Count;

            if (nrOfAnimalsToDelete == 0)
            {
                return;
            }

            // Builds string with appropriate confirm message.
            StringBuilder deleteConfirmMessage = new StringBuilder();
            deleteConfirmMessage.Append(
                $"Are you sure you want to delete the marked {nrOfAnimalsToDelete} animal");

            if (nrOfAnimalsToDelete > 1)
                deleteConfirmMessage.Append("s?");
            else
                deleteConfirmMessage.Append("?");

            // Presents confirm message.
            DialogResult result = MessageBox.Show(
                deleteConfirmMessage.ToString(),
                "Warning",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning);

            if (result == DialogResult.OK)
            {
                List<int> selectedAnimalIds = GetMarkedAnimalsId();

                AnimalManager.DeleteAnimals(selectedAnimalIds);
                AddAnimalsToGUIList();
            }
        }

        /// <summary>
        ///   Gets the ids for all the selected animals.
        /// </summary>
        /// <returns>List with ids.</returns>
        private List<int> GetMarkedAnimalsId()
        {
            List<int> ids = new List<int>();

            foreach (ListViewItem item in listViewAnimals.SelectedItems)
            {
                ids.Add( int.Parse(item.Text) );
            }

            return ids;
        }

        private void AddRecipe(Recipe recipe)
        {
            RecipeManager.Add(recipe);
            AddRecipeToGUI(recipe);
        }

        private void AddRecipeToGUI(Recipe recipe)
        {
            listBoxRecipes.Items.Add(recipe.ToString());
        }

        private void AddStaff(Staff staff)
        {
            StaffManager.Add(staff);
            AddStaffToGUI(staff);
        }

        private void AddStaffToGUI(Staff staff)
        {
            listBoxStaff.Items.Add(staff.ToString());
        }

        private void ToggleRecipeList(bool show)
        {
            listBoxRecipes.Visible = show;
        }

        private void ToggleStaffList(bool show)
        {
            listBoxStaff.Visible = show;
        }

        private void ShowRecipeList()
        {
            ToggleRecipeList(true);
            ToggleStaffList(false);
            listBoxRecipes.SelectedIndex = -1;
            listBoxStaff.SelectedIndex = -1;
            lblShowStaff.BackColor = Color.Green;
            lblShowFoods.BackColor = Color.FromArgb(0, 192, 0);
        }

        private void ShowStaffList()
        {
            ToggleRecipeList(false);
            ToggleStaffList(true);
            listBoxRecipes.SelectedIndex = -1;
            listBoxStaff.SelectedIndex = -1;
            lblShowStaff.BackColor = Color.FromArgb(0, 192, 0);
            lblShowFoods.BackColor = Color.Green;
        }







        // ========================== Events ========================== //

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
                    AnimalManager.SortById();
                    break;

                case 1:
                    AnimalManager.SortBySpecie();
                    break;

                case 2:
                    AnimalManager.SortByName();
                    break;

                case 3:
                    AnimalManager.SortByAge();
                    break;

                case 4:
                    AnimalManager.SortByGender();
                    break;

                case 5:
                    AnimalManager.SortBySpecialCharacteristics();
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

        private void btnChangeAnimal_Click(object sender, EventArgs e)
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

            int id = int.Parse(listViewAnimals.SelectedItems[0].Text);
            Animal animal = AnimalManager.GetAnimalById(id);

            FillGUIWithAnimalData(animal);
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
    }
}
