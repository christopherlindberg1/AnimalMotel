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


namespace AnimalMotel
{
    partial class FormMain : Form
    {
        private readonly MessageHandler _messageHandler = new MessageHandler();



        // ======================= Properties ======================= //

        private MessageHandler MessageHandler
        {
            get { return _messageHandler; }
        }




        // ======================= Methods ======================= //

        /// <summary>
        ///   Validates user input when adding a new animal.
        ///   Validates different data points depending on what category
        ///   the user has chosen.
        /// </summary>
        /// <returns>true if data validated, false otherwise.</returns>
        private bool ValidateInput()
        {
            bool inputOk = ValidateGeneralAnimalData();

            if (listBoxSpecies.SelectedIndex == -1)
            {
                return false;
            }

            Category category = GetAnimalCategory();

            inputOk = inputOk && ValidateCategoryAnimalData(category);

            string specie = GetSelectedSpecie();

            inputOk = inputOk && ValidateSpecieAnimalData(specie);

            return inputOk;
        }

        /// <summary>
        ///   Validates general animal input data.
        /// </summary>
        /// <returns>true if data validated, false otherwise.</returns>
        private bool ValidateGeneralAnimalData()
        {
            // Validating general animal data
            bool nameOk = this.ValidateName();
            bool ageOk = this.ValidateAge();
            bool genderOk = this.ValidateGender();
            bool specieOk = this.ValidateSpecie();

            return nameOk && ageOk && genderOk && specieOk;
        }

        /// <summary>
        ///   Validates input data that is related to a specific category.
        /// </summary>
        /// <param name="category">Category of the animal.</param>
        /// <returns></returns>
        private bool ValidateCategoryAnimalData(Category category)
        {
            switch (category)
            {
                // Validating bird specific data
                case Category.Bird:
                    return ValidateFlyingSpeed();

                // Validating mammal specific data
                case Category.Mammal:
                    bool nrOfTeethOk = ValidateNrOfTeeth();
                    bool tailLengthOk = ValidateTailLength();

                    return nrOfTeethOk && tailLengthOk;

                default:
                    throw new ArgumentException(
                        "Category did not match any case.", "category");
            }
        }

        /// <summary>
        ///   Validates data that is specific to a specie.
        /// </summary>
        /// <param name="specie">Name of specie.</param>
        /// <returns>true if validated, false otherwise.</returns>
        private bool ValidateSpecieAnimalData(string specie)
        {
            switch (specie)
            {
                // Validating eagle specific data
                case "Eagle":
                    return ValidateClawLength();

                // Validating pigeon specific data
                case "Pigeon":
                    return ValidateBeakLength();

                // Validating cat specific data
                case "Cat":
                    return ValidateNrOFLives();

                // Validating dog specific data
                case "Dog":
                    return ValidateBreed();

                default:
                    throw new ArgumentException("Specie did not match any case", "specie");
            }
        }

        /// <summary>
        ///   General method for vaildating the string values
        ///   in text box elements.
        /// </summary>
        /// <param name="element">Element that data is read from.</param>
        /// <param name="errNullOrEmpty">Error message for when element is empty.</param>
        /// <returns>true if data validated correctly, false otherwise.</returns>
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
        ///   General method for vaildating the integer values
        ///   in text box elements.
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
        ///   General method for vaildating the float values
        ///   in text box elements.
        /// </summary>
        /// <param name="element">TextBox element.</param>
        /// <param name="errNullOrEmpty">Error message for when the value is empty.</param>
        /// <param name="errWrongFormat">Error message for when the data is formatted incorrectly.</param>
        /// <param name="errLessThanZero">Error message for when the value is less than 0.</param>
        /// <returns>true if the data validated correctly, false otherwise.</returns>
        private bool ValidateTextBoxFloat(
            TextBox element,
            string errNullOrEmpty,
            string errWrongFormat,
            string errLessThanZero)
        {
            if (String.IsNullOrWhiteSpace(element.Text))
            {
                MessageHandler.AddMessage(errNullOrEmpty);
                return false;
            }

            float number;
            bool numberOk = float.TryParse(element.Text, out number);

            if (!numberOk)
            {
                MessageHandler.AddMessage(errWrongFormat);
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
        ///   Validates the provided name
        /// </summary>
        /// <returns>bool showing if name validated correctly</returns>
        private bool ValidateName()
        {
            return ValidateTextBoxString(textBoxName, "Name cannot be empty.");
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
            return ValidateTextBoxFloat(
                textBoxTailLength,
                "Tail length cannot be empty",
                "Decimal numbers for tail length must be specified with a comma",
                "Tail length cannot be less than 0");
        }

        /// <summary>
        ///   Validates the provided flying speed.
        /// </summary>
        /// <returns>true if the data validated correctly, false otherwise.</returns>
        private bool ValidateFlyingSpeed()
        {
            return ValidateTextBoxFloat(
                textBoxFlyingSpeed,
                "Flying speed cannot be empty",
                "Decimal numbers for flying speed must be specified with a comma",
                "Flying speed cannot be less than 0");
        }

        /// <summary>
        ///   Validates the provided claw length.
        /// </summary>
        /// <returns>true if the data validated correctly, false otherwise.</returns>
        private bool ValidateClawLength()
        {
            return ValidateTextBoxFloat(
                textBoxClawLength,
                "Claw length cannot be empty",
                "Decimal numbers for claw length must be specified with a comma",
                "Claw length cannot be less than 0");
        }

        /// <summary>
        ///   Validates the provided beak length.
        /// </summary>
        /// <returns>true if the data validated correctly, false otherwise.</returns>
        private bool ValidateBeakLength()
        {
            return ValidateTextBoxFloat(
                textBoxBeakLength,
                "Beak length cannot be empty",
                "Decimal numbers for beak length must be specified with a comma",
                "Beak length cannot be less than 0");
        }

        /// <summary>
        ///   Validates the provided nr of lives value.
        /// </summary>
        /// <returns>true if the data validated correctly, false otherwise.</returns>
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
        ///   Validates user input when changing the data for an existing animal.
        ///   Validates different data points depending on specie the animal is.
        /// </summary>
        /// <returns>true if data validates, false otherwise.</returns>
        private bool ValidateUpdatedInput()
        {
            // Checks that only one animal is selected.
            if (listViewAnimals.SelectedItems.Count == 0
                || listViewAnimals.SelectedItems.Count > 1)
            {
                throw new InvalidProgramException(
                    "This method should only be called when exactly one animal is marked.");
            }

            bool inputOk;

            // Validating general animal data
            bool nameOk = this.ValidateName();
            bool ageOk = this.ValidateAge();
            bool genderOk = this.ValidateGender();

            inputOk = nameOk && ageOk && genderOk;

            string specie = listViewAnimals.SelectedItems[0].SubItems[1].Text;

            Category category = GetAnimalCategory(specie);

            inputOk = inputOk && ValidateCategoryAnimalData(category);

            inputOk = inputOk && ValidateSpecieAnimalData(specie);

            return inputOk;
        }
    }
}
