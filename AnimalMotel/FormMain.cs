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
using AnimalMotel.Factories;


namespace AnimalMotel
{
    public partial class FormMain : Form
    {
        private readonly AnimalManager _animalManager = new AnimalManager();
        private readonly MessageHandler _messageHandler = new MessageHandler();




        // ======================= Properties ======================= //

        private AnimalManager AnimalManager
        {
            get { return this._animalManager; }
        }

        private MessageHandler MessageHandler
        {
            get { return this._messageHandler; }
        }




        // ======================= Methods ======================= //


        public FormMain()
        {
            InitializeComponent();
            InitializeApp();
        }


        /// <summary>
        ///   Initializes the entire app to the
        ///   starting state
        /// </summary>
        private void InitializeApp()
        {
            InitializeGUI();
        }


        /// <summary>
        ///   Initializes the GUI of the app
        /// </summary>
        private void InitializeGUI()
        {
            StartPosition = FormStartPosition.CenterScreen;
            listBoxGender.Items.AddRange(Enum.GetNames(typeof(Gender)));
            listBoxCategory.Items.AddRange(Enum.GetNames(typeof(Category)));
            groupBoxAnimalCategorySpecs.Text = "";
            groupBoxSpecieSpecificData.Text = "";

            ClearInput();
            InitializeCategorySpecificFields();
            InitializeSpecieSpecificFields();
            SetFormToDefaultState();
        }

        private void InitializeCategorySpecificFields()
        {
            // Fields for mammal
            lblNrOfTeeth.Location = new Point(16, 30);
            lblTailLength.Location = new Point(16, 60);
            textBoxNrOfTeeth.Location = new Point(120, 28);
            textBoxTailLength.Location = new Point(120, 59);

            // Fields for birds
            lblFlyingSpeed.Location = new Point(16, 30);
            textBoxFlyingSpeed.Location = new Point(120, 28);

            HideAllAnimalCategoryFields();
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

        private void InitializeSpecieSpecificFields()
        {
            // Fields for Eagle
            lblClawLength.Location = new Point(5, 25);
            textBoxClawLength.Location = new Point(90, 24);

            // Fields for Pigeon
            lblBeakLength.Location = new Point(5, 25);
            textBoxBeakLength.Location = new Point(90, 24);

            // Fields for Cat
            lblNrOfLives.Location = new Point(5, 25);
            textBoxNrOfLives.Location = new Point(90, 24);

            // Fields for Dog
            lblBreed.Location = new Point(5, 25);
            textBoxBreed.Location = new Point(90, 24);

            HideAllSpecieFields();
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

        /// <summary>
        ///   Sets the form controls to the default state.
        /// </summary>
        private void SetFormToDefaultState()
        {
            listBoxSpecies.Items.Clear();
            checkBoxListAllAnimals.Checked = false;

            ClearInput();
            HideSpecieFieldsAndLabel();
            HideAnimalCategoryFieldsAndLabel();
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
        ///   Validates user input.
        ///   Validates different data points depending on what category
        ///   the user has chosen.
        /// </summary>
        /// <returns>bool showing if input validated correctly</returns>
        private bool ValidateInput()
        {
            bool inputOk;

            // Validating animal specific data
            bool nameOk = this.ValidateName();
            bool ageOk = this.ValidateAge();
            bool genderOk = this.ValidateGender();
            bool specieOk = this.ValidateSpecie();

            inputOk = nameOk && ageOk && genderOk && specieOk;

            if (listBoxSpecies.SelectedIndex == -1)
            {
                return false;
            }

            Category animalCategory = GetAnimalCategory();

            // Validating animal category specific data
            switch (animalCategory)
            {
                // Validating bird specific data
                case Category.Bird:
                    {
                        bool flyingSpeedOk = ValidateFlyingSpeed();

                        inputOk = inputOk && flyingSpeedOk;
                        break;
                    }

                // Validating mammal specific data
                case Category.Mammal:
                    {
                        bool nrOfTeethOk = ValidateNrOfTeeth();
                        bool tailLengthOk = ValidateTailLength();

                        inputOk = inputOk && nrOfTeethOk && tailLengthOk;
                        break;
                    }
            }

            string selectedSpecie = GetSelectedSpecie();

            // Validating specie specific data
            switch (selectedSpecie)
            {
                // Validating eagle specific data
                case "Eagle":
                    bool clawLengthOk = ValidateClawLength();

                    inputOk = inputOk && clawLengthOk;
                    break;

                // Validating pigeon specific data
                case "Pigeon":
                    bool beakLengthOk = ValidateBeakLength();

                    inputOk = inputOk && beakLengthOk;
                    break;

                // Validating cat specific data
                case "Cat":
                    bool nrOfLivesOk = ValidateNrOFLives();

                    inputOk = inputOk && nrOfLivesOk;
                    break;

                // Validating dog specific data
                case "Dog":
                    bool breedOk = ValidateBreed();

                    inputOk = inputOk && breedOk;
                    break;

                default:
                    throw new ArgumentException("Specie did not match any case", "specie");
            }

            return inputOk;
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

        /// <summary>
        ///   Validates the provided name
        /// </summary>
        /// <returns>bool showing if name validated correctly</returns>
        private bool ValidateName()
        {
            return ValidateTextBoxString(textBoxName, "Name cannot be empty.");
        }

        /// <summary>
        ///   General method for vaildating the integer values
        ///   in text box elements
        /// </summary>
        /// <param name="element">TextBox element.</param>
        /// <param name="errNullOrEmpty">Error message for when the value is empty.</param>
        /// <param name="errNotWholeNumer">Error message for when the value is not a whole number.</param>
        /// <param name="errLessThanZero">Error message for when the value is less than 0.</param>
        /// <returns>Bool showing if value validated of not.</returns>
        private bool ValidateTextBoxInt(
            TextBox element,
            string errNullOrEmpty,
            string errNotWholeNumer,
            string errLessThanZero)
        {
            if (String.IsNullOrWhiteSpace(element.Text))
            {
                MessageHandler.AddMessage(errNullOrEmpty);
                return false;
            }

            int number;
            bool numberOk = int.TryParse(element.Text, out number);

            if (!numberOk)
            {
                MessageHandler.AddMessage(errNotWholeNumer);
                return false;
            }

            if (number < 0)
            {
                MessageHandler.AddMessage(errLessThanZero);
                return false;
            }

            return true;
        }

        /// <summary>
        ///   Validates the provided age
        /// </summary>
        /// <returns>bool showing if age validated correctly</returns>
        private bool ValidateAge()
        {
            return ValidateTextBoxInt(
                textBoxAge,
                "Age cannot be empty.",
                "Age must be a whole number.",
                "Age cannot be less than 0.");
        }

        /// <summary>
        ///   Checks if the user has chosen a gender.
        /// </summary>
        /// <returns>bool showing if a gender has been chosen or not</returns>
        private bool ValidateGender()
        {
            if (listBoxGender.SelectedIndex == -1)
            {
                MessageHandler.AddMessage("You must select a gender.");
                return false;
            }

            return true;
        }

        /// <summary>
        ///   Checks if the user has chosen a category.
        /// </summary>
        /// <returns>bool showing if a specie has been chosen or not</returns>
        private bool ValidateSpecie()
        {
            if (listBoxSpecies.SelectedIndex == -1)
            {
                MessageHandler.AddMessage("You must select a specie.");
                return false;
            }

            return true;
        }

        /// <summary>
        ///   Validates the provided nr of teeth
        /// </summary>
        /// <returns>bool showing if nr of teeth validated correctly</returns>
        private bool ValidateNrOfTeeth()
        {
            return ValidateTextBoxInt(
                textBoxNrOfTeeth,
                "Number of teeth cannot be empty.",
                "Number of teeth must be a whole number.",
                "Number of teeth cannot be less than 0.");
        }

        /// <summary>
        ///   Validates the provided tail length.
        /// </summary>
        /// <returns>bool showing if tail length validated correctly.</returns>
        private bool ValidateTailLength()
        {
            return ValidateTextBoxInt(
                textBoxTailLength,
                "Tail length cannot be empty.",
                "Tail length must be a whole number.",
                "Tail length cannot be less than 0.");
        }

        /// <summary>
        ///   Validates the provided flying speed.
        /// </summary>
        /// <returns>bool showing if flying speed validated correctly.</returns>
        private bool ValidateFlyingSpeed()
        {
            return ValidateTextBoxInt(
                textBoxFlyingSpeed,
                "Flying speed cannot be empty.",
                "Flying speed must be a whole number.",
                "Flying speed cannot be less than 0.");
        }

        private bool ValidateClawLength()
        {
            return ValidateTextBoxInt(
                textBoxClawLength,
                "Claw length cannot be empty.",
                "Claw length must be a whole number.",
                "Claw length cannot be less than 0.");
        }

        private bool ValidateBeakLength()
        {
            return ValidateTextBoxInt(
                textBoxBeakLength,
                "Beak length cannot be empty.",
                "Beak length must be a whole number.",
                "Beak length cannot be less than 0.");
        }

        private bool ValidateNrOFLives()
        {
            return ValidateTextBoxInt(
                textBoxNrOfLives,
                "Number of lives cannot be empty.",
                "Number of lives must be a whole number.",
                "Number of lives cannot be less than 0.");
        }

        private bool ValidateBreed()
        {
            return ValidateTextBoxString(textBoxBreed, "Breed cannot be empty.");
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
        ///   Returns bool showing is the selected specie is a mammal.
        /// </summary>
        /// <returns>bool showing if specie is mammal.</returns>
        private bool SelectedSpecieIsMammal()
        {
            if (listBoxSpecies.SelectedIndex == -1)
                return false;

            return Enum.IsDefined(typeof(MammalSpecies),
                listBoxSpecies.SelectedItem.ToString());
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
        /// <param name="selectedCategory">Animal category</param>
        /// <returns>Dictionary with user input data.</returns>
        private Dictionary<string, string> GetUserInput(Category selectedCategory)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();

            // General animal data
            data.Add("name", textBoxName.Text);
            data.Add("age", textBoxAge.Text);
            data.Add("gender", listBoxGender.SelectedItem.ToString());

            // Data for mammals
            data.Add("nrOfTeeth", textBoxNrOfTeeth.Text);
            data.Add("tailLength", textBoxTailLength.Text);

            // Data for birds
            data.Add("flyingSpeed", textBoxFlyingSpeed.Text);

            /*
             Data specific for species
             */
            data.Add("clawLength", textBoxClawLength.Text);   // For eagles
            data.Add("beakLength", textBoxBeakLength.Text);   // For pigeons
            data.Add("breed", textBoxBreed.Text);             // For dogs
            data.Add("lives", textBoxNrOfLives.Text);         // For cats

            return data;
        }

        private void AddAnimal()
        {
            Animal animal;

            Category category = GetAnimalCategory();
            String specie = GetSelectedSpecie();

            // Storing user input in a dictionary so it can be passed to a factory class.
            Dictionary<string, string> animalData = GetUserInput(category);

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
        ///   Adds an animal to the list of animals.
        ///   Makes use of the animals ToString method.
        /// </summary>
        /// <param name="animal">Object created from the Animal
        /// class or its sub classes</param>
        private void AddAnimalToGUIList(Animal animal)
        {
            listBoxRegisteredAnimals.Items.Add(animal.ToString());
        }

        /// <summary>
        ///   Clears the list with animals in the GUI and then
        ///   adds all animals that are stored in the AnimalManager.
        /// </summary>
        private void AddAnimalsToGUIList()
        {
            listBoxRegisteredAnimals.Items.Clear();

            for (int i = 0; i < AnimalManager.ListCount; i++)
            {
                listBoxRegisteredAnimals.Items.Add(
                    AnimalManager.GetAnimalAt(i).ToString());
            }
        }






        // ========================== Events ========================== //

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

        private void checkBoxListAllAnimals_CheckedChanged(object sender, EventArgs e)
        {
            listBoxCategory.SelectedIndex = -1;

            HideAnimalCategoryFieldsAndLabel();
            HideSpecieFieldsAndLabel();

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

        private void listBoxSpecies_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxSpecies.SelectedIndex != -1)
            {
                Category category = GetAnimalCategoryByAnimal();
                UpdateAnimalCategoryInputFields(category);
                UpdateSpecieInputFields(listBoxSpecies.SelectedItem.ToString());
            }
        }

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
                    MessageHandler.getMessages(),
                    "Info",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }
    }
}
