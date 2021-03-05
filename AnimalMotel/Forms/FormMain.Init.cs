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
using AnimalMotel.Storage;
using AnimalMotel.Serialization;
using AnimalMotel.Animals.Species;

namespace AnimalMotel
{
    public partial class FormMain : Form
    {
        /// <summary>
        ///   Initializes the entire app to the
        ///   starting state
        /// </summary>
        private void InitializeApp()
        {
            InitializeGUI();
            // InitializeData();

            //TestMethod();
        }

        private void TestMethod()
        {
            string eagleFilePathXml = Path.GetFullPath(
                    Path.Combine(FilePaths.AnimalDataFolderPath, @"eagle.xml"));

            string eagleFilePathBin = Path.GetFullPath(
                    Path.Combine(FilePaths.AnimalDataFolderPath, @"eagle.bin"));

            // Serialize
            try
            {
                Eagle eagle = new Eagle
                {
                    Name = "Chris",
                    Age = 2,
                    Gender = Enums.Gender.Male,
                    FlyingSpeed = 10,
                    ClawLength = 10,
                };

                BinarySerializerUtility.Serialize<Eagle>(eagleFilePathBin, eagle);
                XMLSerializerUtility.Serialize<Eagle>(eagleFilePathXml, eagle);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                //throw;
            }

            // Deserialize
            try
            {
                //Eagle eagleRevivedXml = XMLSerializerUtility.XmlDeserialize<Eagle>(eagleFilePathXml);
                Eagle eagleRevivedBin = BinarySerializerUtility.Deserialize<Eagle>(eagleFilePathBin);

                //MessageBox.Show(eagleRevivedXml.ToString());
                MessageBox.Show(eagleRevivedBin.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                //throw;
            }

            Close();
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

            InitializeMenuStrip();
            InitializeGeneralElements();
            InitializeCategorySpecificFields();
            InitializeSpecieSpecificFields();
            InitializeFoodScheduleSection();
            InitializeFoodSection();
            InitializeStaffSection();
            InitializeListViewAnimals();

            SetFormToDefaultState();

            //SetSampleData();
        }

        private void InitializeData()
        {
            InitializeStoragePaths();
        }

        private void InitializeMenuStrip()
        {
            menu.BackColor = Color.FromArgb(220, 220, 220);
            menuFileNew.ShortcutKeys = Keys.Control | Keys.N;
            menuFileExit.ShortcutKeys = Keys.Alt | Keys.X;
        }

        /// <summary>
        ///   Initializes general elements like buttons on the main form.
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

            // Filling the app with sample data
            AnimalManager.FillManagerWithSampleData();
            AddAnimalsToGUIList();
        }

        //private void SetSampleData()
        //{
        //    textBoxName.Text = "Bosse";
        //    textBoxAge.Text = "5";
        //    listBoxGender.SelectedIndex = 1;
        //    listBoxCategory.SelectedIndex = 0;
        //    listBoxSpecies.SelectedIndex = 0;
        //    textBoxNrOfTeeth.Text = "20";
        //    textBoxClawLength.Text = "4";
        //    textBoxFlyingSpeed.Text = "200";
        //}

        private void InitializeStoragePaths()
        {
            // Streamreader for animal path file.
            /*StreamReader sr = new StreamReader($"{ this._pathToPathsFolder }\\PathsToAnimalsFile.txt");
            sr.Close();*/
        }
    }
}
