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
using AnimalMotel.Animals.Species;
using AnimalMotel.Animals.Categories;


namespace AnimalMotel
{
    /// <summary>
    ///   Partial class responsible for functionality related to
    ///   updateing and deleting animals.
    /// </summary>
    public partial class FormMain : Form
    {
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
        private void UpdateAnimal()
        {
            if (listViewAnimals.SelectedIndices.Count == 0
                || listViewAnimals.SelectedIndices.Count > 1)
            {
                return;
            }

            int index = GetSelectedAnimalIndex();
            //int id = GetSelectedAnimalId();

            Animal animal = AnimalManager.GetAt(index);
            Category category = GetAnimalCategory(animal);

            AnimalManager.UpdateAnimal(animal, category, GetUserInput());
            AddAnimalsToGUIList();
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

        /// <summary>
        ///   Fills the GUI with general animal data from an animal object.
        /// </summary>
        /// <param name="animal"></param>
        private void FillGUIWithGeneralAnimalData(Animal animal)
        {
            textBoxName.Text = animal.Name;
            textBoxAge.Text = animal.Age.ToString();
            SetListBoxGender(animal);
        }

        /// <summary>
        ///   Fills the GUI with data that is specific to the animal's category.
        /// </summary>
        /// <param name="category">The animal's category.</param>
        /// <param name="animal">Animal object.</param>
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

        /// <summary>
        ///   Fills the GUI with data that is specific the the animal's specie.
        /// </summary>
        /// <param name="animal">Animal object.</param>
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
        ///   Returns the animal category for a given animal specie.
        /// </summary>
        /// <param name="specie">Name of the specie.</param>
        /// <returns>Category value.</returns>
        private Category GetAnimalCategory(string specie)
        {
            if (Enum.IsDefined(typeof(BirdSpecies), specie))
            {
                return Category.Bird;
            }
            else if (Enum.IsDefined(typeof(MammalSpecies), specie))
            {
                return Category.Mammal;
            }
            else
            {
                throw new InvalidOperationException("" +
                    "The specified specie did not match any category. Missing if-statement?");
            }
        }

        /// <summary>
        ///   Returns the animal category for a given animal object.
        /// </summary>
        /// <param name="animal">Animal object.</param>
        /// <returns>Category value.</returns>
        private Category GetAnimalCategory(Animal animal)
        {
            return GetAnimalCategory(animal.GetSpecie());
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
                List<int> animalIndexes = GetSelectedAnimalsIndexes();

                int leftShift = 0;

                foreach (int i in animalIndexes)
                {
                    AnimalManager.DeleteAt(i - leftShift);
                    leftShift++;
                }

                AddAnimalsToGUIList();
            }
            else
            {
                listViewAnimals.SelectedItems.Clear();
            }
        }
    }
}
