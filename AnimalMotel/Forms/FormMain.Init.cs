﻿using System;
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

namespace AnimalMotel
{
    public partial class FormMain : Form
    {
        /// <summary>
        /// Initializes the entire app to the
        /// starting state
        /// </summary>
        private void InitializeApp()
        {
            InitializeData();
            InitializeGUI();
        }

        private void InitializeData()
        {
            AppSettings = AppSettings.GetSettingsFromStorage();
            AnimalManager.LastGeneratedId = AppSettings.LastGeneratedId;
        }

        /// <summary>
        /// Initializes the GUI of the app
        /// </summary>
        private void InitializeGUI()
        {
            StartPosition = FormStartPosition.CenterScreen;
            listBoxGender.Items.AddRange(Enum.GetNames(typeof(Gender)));
            listBoxCategory.Items.AddRange(Enum.GetNames(typeof(Category)));
            groupBoxAnimalCategorySpecs.Text = "";
            groupBoxSpecieSpecificData.Text = "";

            InitializeMenuStrip();
            InitializeGeneralElements();
            InitializeCategorySpecificFields();
            InitializeSpecieSpecificFields();
            InitializeFoodScheduleSection();
            InitializeFoodSection();
            InitializeStaffSection();
            InitializeListViewAnimals();

            SetFormToDefaultState();
        }

        private void InitializeMenuStrip()
        {
            menu.BackColor = Color.FromArgb(220, 220, 220);
            menuFileNew.ShortcutKeys = Keys.Control | Keys.N;
            menuFileExit.ShortcutKeys = Keys.Alt | Keys.X;
        }

        /// <summary>
        /// Initializes general elements like buttons on the main form.
        /// </summary>
        private void InitializeGeneralElements()
        {
            btnUpdateAnimal.Location = new Point(200, 270);
            btnDeleteAnimal.Location = new Point(430, 270);
            btnSave.Location = new Point(200, 270);
            btnCancel.Location = new Point(430, 270);
            btnSave.Visible = false;
            btnCancel.Visible = false;
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
            lblClawLength.Location = new Point(8, 25);
            textBoxClawLength.Location = new Point(80, 24);
            textBoxClawLength.Size = new Size(50, 24);

            // Fields for Pigeon
            lblBeakLength.Location = new Point(8, 25);
            textBoxBeakLength.Location = new Point(80, 24);
            textBoxBeakLength.Size = new Size(50, 24);

            // Fields for Cat
            lblNrOfLives.Location = new Point(8, 25);
            textBoxNrOfLives.Location = new Point(80, 24);
            textBoxNrOfLives.Size = new Size(50, 24);

            // Fields for Dog
            lblBreed.Location = new Point(8, 25);
            textBoxBreed.Location = new Point(55, 24);
            textBoxBreed.Size = new Size(100, 24);

            HideAllSpecieFields();
        }

        private void InitializeFoodScheduleSection()
        {
            lblShowEaterType.Text = "";
            listBoxFoodSchedule.Enabled = false;
        }

        private void InitializeFoodSection()
        {
            listBoxRecipes.Location = new Point(122, 45);
            listBoxRecipes.Size = new Size(300, 270);
        }

        private void InitializeStaffSection()
        {
            listBoxStaff.Location = new Point(122, 45);
            listBoxStaff.Size = new Size(300, 270);
            ToggleStaffList(false);
        }

        private void InitializeListViewAnimals()
        {
            // Setting width for columns
            listViewAnimals.Columns[0].Width = 50;      // id
            listViewAnimals.Columns[1].Width = 100;     // specie
            listViewAnimals.Columns[2].Width = 120;     // name
            listViewAnimals.Columns[3].Width = 50;      // age
            listViewAnimals.Columns[4].Width = 80;      // gender
            listViewAnimals.Columns[5].Width = 370;     // special characteristics

            // Set the view to show details.
            listViewAnimals.View = View.Details;
            // Allow the user to rearrange columns.
            listViewAnimals.AllowColumnReorder = true;
            // Select the item and subitems when selection is made.
            listViewAnimals.FullRowSelect = true;
            // Display grid lines.
            listViewAnimals.GridLines = true;

            AddAnimalsToGUIList();
        }
    }
}
