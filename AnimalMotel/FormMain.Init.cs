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
    public partial class FormMain : Form
    {
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
            InitializeFoodScheduleSection();
            SetFormToDefaultState();
        }

        /// <summary>
        ///   Initializes the entire app to the
        ///   starting state
        /// </summary>
        private void InitializeApp()
        {
            InitializeGUI();
        }

        private void InitializeCategorySpecificFields()
        {
            // Fields for mammal
            lblNrOfTeeth.Location = new Point(12, 30);
            lblTailLength.Location = new Point(12, 60);
            textBoxNrOfTeeth.Location = new Point(90, 28);
            textBoxNrOfTeeth.Size = new Size(50, 24);
            textBoxTailLength.Location = new Point(90, 59);
            textBoxTailLength.Size = new Size(50, 24);

            // Fields for birds
            lblFlyingSpeed.Location = new Point(16, 30);
            textBoxFlyingSpeed.Location = new Point(100, 28);
            textBoxFlyingSpeed.Size = new Size(50, 24);

            HideAllAnimalCategoryFields();
        }

        private void InitializeSpecieSpecificFields()
        {
            // Fields for Eagle
            lblClawLength.Location = new Point(5, 25);
            textBoxClawLength.Location = new Point(80, 24);
            textBoxClawLength.Size = new Size(50, 24);

            // Fields for Pigeon
            lblBeakLength.Location = new Point(5, 25);
            textBoxBeakLength.Location = new Point(80, 24);
            textBoxBeakLength.Size = new Size(50, 24);

            // Fields for Cat
            lblNrOfLives.Location = new Point(5, 25);
            textBoxNrOfLives.Location = new Point(80, 24);
            textBoxNrOfLives.Size = new Size(50, 24);

            // Fields for Dog
            lblBreed.Location = new Point(5, 25);
            textBoxBreed.Location = new Point(55, 24);
            textBoxBreed.Size = new Size(100, 24);

            HideAllSpecieFields();
        }

        private void InitializeFoodScheduleSection()
        {
            lblEaterType.Location = new Point(5, 25);
            lblShowEaterType.Text = "";
            lblShowEaterType.Location = new Point(90, 24);
            lblShowEaterType.Size = new Size(270, 22);
        }
    }
}
