namespace AnimalMotel
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBoxCategory = new System.Windows.Forms.ListBox();
            this.textBoxFlyingSpeed = new System.Windows.Forms.TextBox();
            this.lblFlyingSpeed = new System.Windows.Forms.Label();
            this.textBoxTailLength = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.groupBoxGender = new System.Windows.Forms.GroupBox();
            this.listBoxGender = new System.Windows.Forms.ListBox();
            this.textBoxAge = new System.Windows.Forms.TextBox();
            this.lblAnimalObject = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.groupBoxAnimalList = new System.Windows.Forms.GroupBox();
            this.btnDeleteAnimal = new System.Windows.Forms.Button();
            this.lblShowEaterType = new System.Windows.Forms.Label();
            this.listBoxFoodSchedule = new System.Windows.Forms.ListBox();
            this.lblEaterType = new System.Windows.Forms.Label();
            this.btnChangeAnimal = new System.Windows.Forms.Button();
            this.listViewAnimals = new System.Windows.Forms.ListView();
            this.id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.specie = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.age = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gender = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.specialCharacteristics = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblAge = new System.Windows.Forms.Label();
            this.textBoxNrOfTeeth = new System.Windows.Forms.TextBox();
            this.lblTailLength = new System.Windows.Forms.Label();
            this.groupBoxAnimalSpecs = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listBoxStaff = new System.Windows.Forms.ListBox();
            this.lblShowStaff = new System.Windows.Forms.Label();
            this.lblShowFoods = new System.Windows.Forms.Label();
            this.listBoxRecipes = new System.Windows.Forms.ListBox();
            this.btnAddStaff = new System.Windows.Forms.Button();
            this.btnAddFood = new System.Windows.Forms.Button();
            this.groupBoxSpecieSpecificData = new System.Windows.Forms.GroupBox();
            this.textBoxNrOfLives = new System.Windows.Forms.TextBox();
            this.textBoxBreed = new System.Windows.Forms.TextBox();
            this.textBoxBeakLength = new System.Windows.Forms.TextBox();
            this.textBoxClawLength = new System.Windows.Forms.TextBox();
            this.lblNrOfLives = new System.Windows.Forms.Label();
            this.lblBreed = new System.Windows.Forms.Label();
            this.lblBeakLength = new System.Windows.Forms.Label();
            this.lblClawLength = new System.Windows.Forms.Label();
            this.checkBoxListAllAnimals = new System.Windows.Forms.CheckBox();
            this.btnAddAnimal = new System.Windows.Forms.Button();
            this.groupBoxAnimalCategorySpecs = new System.Windows.Forms.GroupBox();
            this.lblNrOfTeeth = new System.Windows.Forms.Label();
            this.listBoxSpecies = new System.Windows.Forms.ListBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBoxGender.SuspendLayout();
            this.groupBoxAnimalList.SuspendLayout();
            this.groupBoxAnimalSpecs.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBoxSpecieSpecificData.SuspendLayout();
            this.groupBoxAnimalCategorySpecs.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxCategory
            // 
            this.listBoxCategory.FormattingEnabled = true;
            this.listBoxCategory.ItemHeight = 18;
            this.listBoxCategory.Location = new System.Drawing.Point(214, 37);
            this.listBoxCategory.Name = "listBoxCategory";
            this.listBoxCategory.Size = new System.Drawing.Size(152, 202);
            this.listBoxCategory.TabIndex = 4;
            this.listBoxCategory.SelectedIndexChanged += new System.EventHandler(this.listBoxCategory_SelectedIndexChanged);
            // 
            // textBoxFlyingSpeed
            // 
            this.textBoxFlyingSpeed.Location = new System.Drawing.Point(224, 22);
            this.textBoxFlyingSpeed.Name = "textBoxFlyingSpeed";
            this.textBoxFlyingSpeed.Size = new System.Drawing.Size(29, 24);
            this.textBoxFlyingSpeed.TabIndex = 9;
            // 
            // lblFlyingSpeed
            // 
            this.lblFlyingSpeed.AutoSize = true;
            this.lblFlyingSpeed.Location = new System.Drawing.Point(87, 40);
            this.lblFlyingSpeed.Name = "lblFlyingSpeed";
            this.lblFlyingSpeed.Size = new System.Drawing.Size(90, 18);
            this.lblFlyingSpeed.TabIndex = 8;
            this.lblFlyingSpeed.Text = "Flying speed";
            // 
            // textBoxTailLength
            // 
            this.textBoxTailLength.Location = new System.Drawing.Point(170, 74);
            this.textBoxTailLength.Name = "textBoxTailLength";
            this.textBoxTailLength.Size = new System.Drawing.Size(43, 24);
            this.textBoxTailLength.TabIndex = 7;
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(77, 39);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(119, 24);
            this.textBoxName.TabIndex = 1;
            // 
            // groupBoxGender
            // 
            this.groupBoxGender.Controls.Add(this.listBoxGender);
            this.groupBoxGender.Location = new System.Drawing.Point(15, 104);
            this.groupBoxGender.Name = "groupBoxGender";
            this.groupBoxGender.Size = new System.Drawing.Size(181, 109);
            this.groupBoxGender.TabIndex = 6;
            this.groupBoxGender.TabStop = false;
            this.groupBoxGender.Text = "Gender";
            // 
            // listBoxGender
            // 
            this.listBoxGender.FormattingEnabled = true;
            this.listBoxGender.ItemHeight = 18;
            this.listBoxGender.Location = new System.Drawing.Point(7, 26);
            this.listBoxGender.Name = "listBoxGender";
            this.listBoxGender.Size = new System.Drawing.Size(166, 76);
            this.listBoxGender.TabIndex = 3;
            // 
            // textBoxAge
            // 
            this.textBoxAge.Location = new System.Drawing.Point(77, 69);
            this.textBoxAge.Name = "textBoxAge";
            this.textBoxAge.Size = new System.Drawing.Size(119, 24);
            this.textBoxAge.TabIndex = 2;
            // 
            // lblAnimalObject
            // 
            this.lblAnimalObject.AutoSize = true;
            this.lblAnimalObject.Location = new System.Drawing.Point(441, 13);
            this.lblAnimalObject.Name = "lblAnimalObject";
            this.lblAnimalObject.Size = new System.Drawing.Size(53, 18);
            this.lblAnimalObject.TabIndex = 0;
            this.lblAnimalObject.Text = "Specie";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(259, 16);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(68, 18);
            this.lblCategory.TabIndex = 0;
            this.lblCategory.Text = "Category";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(11, 39);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(48, 18);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name";
            // 
            // groupBoxAnimalList
            // 
            this.groupBoxAnimalList.Controls.Add(this.btnCancel);
            this.groupBoxAnimalList.Controls.Add(this.btnSave);
            this.groupBoxAnimalList.Controls.Add(this.btnDeleteAnimal);
            this.groupBoxAnimalList.Controls.Add(this.lblShowEaterType);
            this.groupBoxAnimalList.Controls.Add(this.listBoxFoodSchedule);
            this.groupBoxAnimalList.Controls.Add(this.lblEaterType);
            this.groupBoxAnimalList.Controls.Add(this.btnChangeAnimal);
            this.groupBoxAnimalList.Controls.Add(this.listViewAnimals);
            this.groupBoxAnimalList.Location = new System.Drawing.Point(14, 397);
            this.groupBoxAnimalList.Name = "groupBoxAnimalList";
            this.groupBoxAnimalList.Size = new System.Drawing.Size(1206, 321);
            this.groupBoxAnimalList.TabIndex = 1;
            this.groupBoxAnimalList.TabStop = false;
            this.groupBoxAnimalList.Text = "List of registered animals";
            // 
            // btnDeleteAnimal
            // 
            this.btnDeleteAnimal.Location = new System.Drawing.Point(434, 269);
            this.btnDeleteAnimal.Name = "btnDeleteAnimal";
            this.btnDeleteAnimal.Size = new System.Drawing.Size(150, 40);
            this.btnDeleteAnimal.TabIndex = 4;
            this.btnDeleteAnimal.Text = "Delete";
            this.btnDeleteAnimal.UseVisualStyleBackColor = true;
            this.btnDeleteAnimal.Click += new System.EventHandler(this.btnDeleteAnimal_Click);
            // 
            // lblShowEaterType
            // 
            this.lblShowEaterType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblShowEaterType.Location = new System.Drawing.Point(999, 33);
            this.lblShowEaterType.Name = "lblShowEaterType";
            this.lblShowEaterType.Size = new System.Drawing.Size(174, 20);
            this.lblShowEaterType.TabIndex = 1;
            this.lblShowEaterType.Text = "Carnivore";
            this.lblShowEaterType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // listBoxFoodSchedule
            // 
            this.listBoxFoodSchedule.BackColor = System.Drawing.SystemColors.Control;
            this.listBoxFoodSchedule.Enabled = false;
            this.listBoxFoodSchedule.FormattingEnabled = true;
            this.listBoxFoodSchedule.ItemHeight = 18;
            this.listBoxFoodSchedule.Location = new System.Drawing.Point(810, 70);
            this.listBoxFoodSchedule.Name = "listBoxFoodSchedule";
            this.listBoxFoodSchedule.Size = new System.Drawing.Size(363, 184);
            this.listBoxFoodSchedule.TabIndex = 2;
            // 
            // lblEaterType
            // 
            this.lblEaterType.Location = new System.Drawing.Point(807, 33);
            this.lblEaterType.Name = "lblEaterType";
            this.lblEaterType.Size = new System.Drawing.Size(79, 18);
            this.lblEaterType.TabIndex = 0;
            this.lblEaterType.Text = "Eater type";
            // 
            // btnChangeAnimal
            // 
            this.btnChangeAnimal.Location = new System.Drawing.Point(200, 270);
            this.btnChangeAnimal.Name = "btnChangeAnimal";
            this.btnChangeAnimal.Size = new System.Drawing.Size(150, 40);
            this.btnChangeAnimal.TabIndex = 3;
            this.btnChangeAnimal.Text = "Change";
            this.btnChangeAnimal.UseVisualStyleBackColor = true;
            this.btnChangeAnimal.Click += new System.EventHandler(this.btnChangeAnimal_Click);
            // 
            // listViewAnimals
            // 
            this.listViewAnimals.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.id,
            this.specie,
            this.name,
            this.age,
            this.gender,
            this.specialCharacteristics});
            this.listViewAnimals.HideSelection = false;
            this.listViewAnimals.Location = new System.Drawing.Point(14, 33);
            this.listViewAnimals.Name = "listViewAnimals";
            this.listViewAnimals.Size = new System.Drawing.Size(774, 226);
            this.listViewAnimals.TabIndex = 2;
            this.listViewAnimals.UseCompatibleStateImageBehavior = false;
            this.listViewAnimals.View = System.Windows.Forms.View.Details;
            this.listViewAnimals.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewAnimals_ColumnClick);
            this.listViewAnimals.SelectedIndexChanged += new System.EventHandler(this.listViewAnimals_SelectedIndexChanged);
            // 
            // id
            // 
            this.id.Text = "ID";
            // 
            // specie
            // 
            this.specie.Text = "Specie";
            // 
            // name
            // 
            this.name.Text = "Name";
            // 
            // age
            // 
            this.age.Text = "Age";
            // 
            // gender
            // 
            this.gender.Text = "Gender";
            // 
            // specialCharacteristics
            // 
            this.specialCharacteristics.Text = "Special characteristics";
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.Location = new System.Drawing.Point(11, 69);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(33, 18);
            this.lblAge.TabIndex = 1;
            this.lblAge.Text = "Age";
            // 
            // textBoxNrOfTeeth
            // 
            this.textBoxNrOfTeeth.Location = new System.Drawing.Point(170, 34);
            this.textBoxNrOfTeeth.Name = "textBoxNrOfTeeth";
            this.textBoxNrOfTeeth.Size = new System.Drawing.Size(43, 24);
            this.textBoxNrOfTeeth.TabIndex = 6;
            // 
            // lblTailLength
            // 
            this.lblTailLength.AutoSize = true;
            this.lblTailLength.Location = new System.Drawing.Point(19, 79);
            this.lblTailLength.Name = "lblTailLength";
            this.lblTailLength.Size = new System.Drawing.Size(74, 18);
            this.lblTailLength.TabIndex = 0;
            this.lblTailLength.Text = "Tail length";
            // 
            // groupBoxAnimalSpecs
            // 
            this.groupBoxAnimalSpecs.Controls.Add(this.groupBox1);
            this.groupBoxAnimalSpecs.Controls.Add(this.groupBoxSpecieSpecificData);
            this.groupBoxAnimalSpecs.Controls.Add(this.checkBoxListAllAnimals);
            this.groupBoxAnimalSpecs.Controls.Add(this.btnAddAnimal);
            this.groupBoxAnimalSpecs.Controls.Add(this.groupBoxAnimalCategorySpecs);
            this.groupBoxAnimalSpecs.Controls.Add(this.listBoxSpecies);
            this.groupBoxAnimalSpecs.Controls.Add(this.listBoxCategory);
            this.groupBoxAnimalSpecs.Controls.Add(this.textBoxAge);
            this.groupBoxAnimalSpecs.Controls.Add(this.textBoxName);
            this.groupBoxAnimalSpecs.Controls.Add(this.groupBoxGender);
            this.groupBoxAnimalSpecs.Controls.Add(this.lblAnimalObject);
            this.groupBoxAnimalSpecs.Controls.Add(this.lblCategory);
            this.groupBoxAnimalSpecs.Controls.Add(this.lblAge);
            this.groupBoxAnimalSpecs.Controls.Add(this.lblName);
            this.groupBoxAnimalSpecs.Location = new System.Drawing.Point(14, 14);
            this.groupBoxAnimalSpecs.Name = "groupBoxAnimalSpecs";
            this.groupBoxAnimalSpecs.Size = new System.Drawing.Size(1206, 362);
            this.groupBoxAnimalSpecs.TabIndex = 2;
            this.groupBoxAnimalSpecs.TabStop = false;
            this.groupBoxAnimalSpecs.Text = "Animal Specifications";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listBoxStaff);
            this.groupBox1.Controls.Add(this.lblShowStaff);
            this.groupBox1.Controls.Add(this.lblShowFoods);
            this.groupBox1.Controls.Add(this.listBoxRecipes);
            this.groupBox1.Controls.Add(this.btnAddStaff);
            this.groupBox1.Controls.Add(this.btnAddFood);
            this.groupBox1.Location = new System.Drawing.Point(772, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(428, 324);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Food details";
            // 
            // listBoxStaff
            // 
            this.listBoxStaff.FormattingEnabled = true;
            this.listBoxStaff.ItemHeight = 18;
            this.listBoxStaff.Location = new System.Drawing.Point(126, 191);
            this.listBoxStaff.Name = "listBoxStaff";
            this.listBoxStaff.Size = new System.Drawing.Size(296, 94);
            this.listBoxStaff.TabIndex = 10;
            // 
            // lblShowStaff
            // 
            this.lblShowStaff.BackColor = System.Drawing.Color.Green;
            this.lblShowStaff.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblShowStaff.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShowStaff.ForeColor = System.Drawing.Color.White;
            this.lblShowStaff.Location = new System.Drawing.Point(274, 18);
            this.lblShowStaff.Name = "lblShowStaff";
            this.lblShowStaff.Size = new System.Drawing.Size(148, 25);
            this.lblShowStaff.TabIndex = 9;
            this.lblShowStaff.Text = "Show staff";
            this.lblShowStaff.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblShowStaff.Click += new System.EventHandler(this.lblShowStaff_Click);
            // 
            // lblShowFoods
            // 
            this.lblShowFoods.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblShowFoods.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblShowFoods.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShowFoods.ForeColor = System.Drawing.Color.White;
            this.lblShowFoods.Location = new System.Drawing.Point(122, 18);
            this.lblShowFoods.Name = "lblShowFoods";
            this.lblShowFoods.Size = new System.Drawing.Size(148, 25);
            this.lblShowFoods.TabIndex = 8;
            this.lblShowFoods.Text = "Show foods";
            this.lblShowFoods.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblShowFoods.Click += new System.EventHandler(this.lblShowFoods_Click);
            // 
            // listBoxRecipes
            // 
            this.listBoxRecipes.FormattingEnabled = true;
            this.listBoxRecipes.ItemHeight = 18;
            this.listBoxRecipes.Location = new System.Drawing.Point(122, 46);
            this.listBoxRecipes.Name = "listBoxRecipes";
            this.listBoxRecipes.Size = new System.Drawing.Size(255, 184);
            this.listBoxRecipes.TabIndex = 5;
            // 
            // btnAddStaff
            // 
            this.btnAddStaff.Location = new System.Drawing.Point(6, 104);
            this.btnAddStaff.Name = "btnAddStaff";
            this.btnAddStaff.Size = new System.Drawing.Size(110, 40);
            this.btnAddStaff.TabIndex = 4;
            this.btnAddStaff.Text = "Add staff";
            this.btnAddStaff.UseVisualStyleBackColor = true;
            this.btnAddStaff.Click += new System.EventHandler(this.btnAddStaff_Click);
            // 
            // btnAddFood
            // 
            this.btnAddFood.Location = new System.Drawing.Point(6, 45);
            this.btnAddFood.Name = "btnAddFood";
            this.btnAddFood.Size = new System.Drawing.Size(110, 40);
            this.btnAddFood.TabIndex = 3;
            this.btnAddFood.Text = "Add food";
            this.btnAddFood.UseVisualStyleBackColor = true;
            this.btnAddFood.Click += new System.EventHandler(this.btnAddFood_Click);
            // 
            // groupBoxSpecieSpecificData
            // 
            this.groupBoxSpecieSpecificData.Controls.Add(this.textBoxNrOfLives);
            this.groupBoxSpecieSpecificData.Controls.Add(this.textBoxBreed);
            this.groupBoxSpecieSpecificData.Controls.Add(this.textBoxBeakLength);
            this.groupBoxSpecieSpecificData.Controls.Add(this.textBoxClawLength);
            this.groupBoxSpecieSpecificData.Controls.Add(this.lblNrOfLives);
            this.groupBoxSpecieSpecificData.Controls.Add(this.lblBreed);
            this.groupBoxSpecieSpecificData.Controls.Add(this.lblBeakLength);
            this.groupBoxSpecieSpecificData.Controls.Add(this.lblClawLength);
            this.groupBoxSpecieSpecificData.Location = new System.Drawing.Point(569, 26);
            this.groupBoxSpecieSpecificData.Name = "groupBoxSpecieSpecificData";
            this.groupBoxSpecieSpecificData.Size = new System.Drawing.Size(181, 231);
            this.groupBoxSpecieSpecificData.TabIndex = 10;
            this.groupBoxSpecieSpecificData.TabStop = false;
            this.groupBoxSpecieSpecificData.Text = "Default";
            // 
            // textBoxNrOfLives
            // 
            this.textBoxNrOfLives.Location = new System.Drawing.Point(71, 90);
            this.textBoxNrOfLives.Name = "textBoxNrOfLives";
            this.textBoxNrOfLives.Size = new System.Drawing.Size(112, 24);
            this.textBoxNrOfLives.TabIndex = 7;
            // 
            // textBoxBreed
            // 
            this.textBoxBreed.Location = new System.Drawing.Point(64, 56);
            this.textBoxBreed.Name = "textBoxBreed";
            this.textBoxBreed.Size = new System.Drawing.Size(112, 24);
            this.textBoxBreed.TabIndex = 6;
            // 
            // textBoxBeakLength
            // 
            this.textBoxBeakLength.Location = new System.Drawing.Point(45, 43);
            this.textBoxBeakLength.Name = "textBoxBeakLength";
            this.textBoxBeakLength.Size = new System.Drawing.Size(112, 24);
            this.textBoxBeakLength.TabIndex = 5;
            // 
            // textBoxClawLength
            // 
            this.textBoxClawLength.Location = new System.Drawing.Point(71, 12);
            this.textBoxClawLength.Name = "textBoxClawLength";
            this.textBoxClawLength.Size = new System.Drawing.Size(112, 24);
            this.textBoxClawLength.TabIndex = 4;
            // 
            // lblNrOfLives
            // 
            this.lblNrOfLives.AutoSize = true;
            this.lblNrOfLives.Location = new System.Drawing.Point(7, 97);
            this.lblNrOfLives.Name = "lblNrOfLives";
            this.lblNrOfLives.Size = new System.Drawing.Size(74, 18);
            this.lblNrOfLives.TabIndex = 3;
            this.lblNrOfLives.Text = "Nr of lives";
            // 
            // lblBreed
            // 
            this.lblBreed.AutoSize = true;
            this.lblBreed.Location = new System.Drawing.Point(19, 76);
            this.lblBreed.Name = "lblBreed";
            this.lblBreed.Size = new System.Drawing.Size(47, 18);
            this.lblBreed.TabIndex = 2;
            this.lblBreed.Text = "Breed";
            // 
            // lblBeakLength
            // 
            this.lblBeakLength.AutoSize = true;
            this.lblBeakLength.Location = new System.Drawing.Point(7, 56);
            this.lblBeakLength.Name = "lblBeakLength";
            this.lblBeakLength.Size = new System.Drawing.Size(85, 18);
            this.lblBeakLength.TabIndex = 1;
            this.lblBeakLength.Text = "Beak length";
            // 
            // lblClawLength
            // 
            this.lblClawLength.AutoSize = true;
            this.lblClawLength.Location = new System.Drawing.Point(7, 22);
            this.lblClawLength.Name = "lblClawLength";
            this.lblClawLength.Size = new System.Drawing.Size(84, 18);
            this.lblClawLength.TabIndex = 0;
            this.lblClawLength.Text = "Claw length";
            // 
            // checkBoxListAllAnimals
            // 
            this.checkBoxListAllAnimals.AutoSize = true;
            this.checkBoxListAllAnimals.Location = new System.Drawing.Point(399, 290);
            this.checkBoxListAllAnimals.Name = "checkBoxListAllAnimals";
            this.checkBoxListAllAnimals.Size = new System.Drawing.Size(126, 22);
            this.checkBoxListAllAnimals.TabIndex = 8;
            this.checkBoxListAllAnimals.Text = "List all animals";
            this.checkBoxListAllAnimals.UseVisualStyleBackColor = true;
            this.checkBoxListAllAnimals.CheckedChanged += new System.EventHandler(this.checkBoxListAllAnimals_CheckedChanged);
            // 
            // btnAddAnimal
            // 
            this.btnAddAnimal.Location = new System.Drawing.Point(569, 300);
            this.btnAddAnimal.Name = "btnAddAnimal";
            this.btnAddAnimal.Size = new System.Drawing.Size(183, 47);
            this.btnAddAnimal.TabIndex = 9;
            this.btnAddAnimal.Text = "Add animal";
            this.btnAddAnimal.UseVisualStyleBackColor = true;
            this.btnAddAnimal.Click += new System.EventHandler(this.btnAddAnimal_Click);
            // 
            // groupBoxAnimalCategorySpecs
            // 
            this.groupBoxAnimalCategorySpecs.Controls.Add(this.textBoxFlyingSpeed);
            this.groupBoxAnimalCategorySpecs.Controls.Add(this.lblFlyingSpeed);
            this.groupBoxAnimalCategorySpecs.Controls.Add(this.textBoxTailLength);
            this.groupBoxAnimalCategorySpecs.Controls.Add(this.textBoxNrOfTeeth);
            this.groupBoxAnimalCategorySpecs.Controls.Add(this.lblNrOfTeeth);
            this.groupBoxAnimalCategorySpecs.Controls.Add(this.lblTailLength);
            this.groupBoxAnimalCategorySpecs.Location = new System.Drawing.Point(15, 250);
            this.groupBoxAnimalCategorySpecs.Name = "groupBoxAnimalCategorySpecs";
            this.groupBoxAnimalCategorySpecs.Size = new System.Drawing.Size(352, 98);
            this.groupBoxAnimalCategorySpecs.TabIndex = 0;
            this.groupBoxAnimalCategorySpecs.TabStop = false;
            this.groupBoxAnimalCategorySpecs.Text = "Mammal specifications";
            // 
            // lblNrOfTeeth
            // 
            this.lblNrOfTeeth.AutoSize = true;
            this.lblNrOfTeeth.Location = new System.Drawing.Point(18, 40);
            this.lblNrOfTeeth.Name = "lblNrOfTeeth";
            this.lblNrOfTeeth.Size = new System.Drawing.Size(77, 18);
            this.lblNrOfTeeth.TabIndex = 0;
            this.lblNrOfTeeth.Text = "Nr of teeth";
            // 
            // listBoxSpecies
            // 
            this.listBoxSpecies.FormattingEnabled = true;
            this.listBoxSpecies.ItemHeight = 18;
            this.listBoxSpecies.Location = new System.Drawing.Point(384, 37);
            this.listBoxSpecies.Name = "listBoxSpecies";
            this.listBoxSpecies.Size = new System.Drawing.Size(166, 256);
            this.listBoxSpecies.TabIndex = 5;
            this.listBoxSpecies.SelectedIndexChanged += new System.EventHandler(this.listBoxSpecies_SelectedIndexChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(45, 266);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(150, 40);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(595, 270);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(150, 40);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1232, 719);
            this.Controls.Add(this.groupBoxAnimalList);
            this.Controls.Add(this.groupBoxAnimalSpecs);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FormMain";
            this.Text = "Animal Motel";
            this.groupBoxGender.ResumeLayout(false);
            this.groupBoxAnimalList.ResumeLayout(false);
            this.groupBoxAnimalSpecs.ResumeLayout(false);
            this.groupBoxAnimalSpecs.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBoxSpecieSpecificData.ResumeLayout(false);
            this.groupBoxSpecieSpecificData.PerformLayout();
            this.groupBoxAnimalCategorySpecs.ResumeLayout(false);
            this.groupBoxAnimalCategorySpecs.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxCategory;
        private System.Windows.Forms.TextBox textBoxFlyingSpeed;
        private System.Windows.Forms.Label lblFlyingSpeed;
        private System.Windows.Forms.TextBox textBoxTailLength;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.GroupBox groupBoxGender;
        private System.Windows.Forms.ListBox listBoxGender;
        private System.Windows.Forms.TextBox textBoxAge;
        private System.Windows.Forms.Label lblAnimalObject;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.GroupBox groupBoxAnimalList;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.TextBox textBoxNrOfTeeth;
        private System.Windows.Forms.Label lblTailLength;
        private System.Windows.Forms.GroupBox groupBoxAnimalSpecs;
        private System.Windows.Forms.GroupBox groupBoxSpecieSpecificData;
        private System.Windows.Forms.TextBox textBoxNrOfLives;
        private System.Windows.Forms.TextBox textBoxBreed;
        private System.Windows.Forms.TextBox textBoxBeakLength;
        private System.Windows.Forms.TextBox textBoxClawLength;
        private System.Windows.Forms.Label lblNrOfLives;
        private System.Windows.Forms.Label lblBreed;
        private System.Windows.Forms.Label lblBeakLength;
        private System.Windows.Forms.Label lblClawLength;
        private System.Windows.Forms.CheckBox checkBoxListAllAnimals;
        private System.Windows.Forms.Button btnAddAnimal;
        private System.Windows.Forms.GroupBox groupBoxAnimalCategorySpecs;
        private System.Windows.Forms.Label lblNrOfTeeth;
        private System.Windows.Forms.ListBox listBoxSpecies;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblEaterType;
        private System.Windows.Forms.Label lblShowEaterType;
        private System.Windows.Forms.ListBox listBoxFoodSchedule;
        private System.Windows.Forms.ListView listViewAnimals;
        private System.Windows.Forms.ColumnHeader id;
        private System.Windows.Forms.ColumnHeader specie;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader age;
        private System.Windows.Forms.ColumnHeader gender;
        private System.Windows.Forms.ColumnHeader specialCharacteristics;
        private System.Windows.Forms.Button btnDeleteAnimal;
        private System.Windows.Forms.Button btnChangeAnimal;
        private System.Windows.Forms.Button btnAddStaff;
        private System.Windows.Forms.Button btnAddFood;
        private System.Windows.Forms.ListBox listBoxRecipes;
        private System.Windows.Forms.Label lblShowFoods;
        private System.Windows.Forms.Label lblShowStaff;
        private System.Windows.Forms.ListBox listBoxStaff;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
    }
}

