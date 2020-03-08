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
    }
}
