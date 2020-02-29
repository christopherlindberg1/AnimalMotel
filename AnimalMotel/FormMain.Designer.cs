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
            this.lblSpecie = new System.Windows.Forms.Label();
            this.lblRegSpecialCharacteristics = new System.Windows.Forms.Label();
            this.lblRegGender = new System.Windows.Forms.Label();
            this.lblRegAge = new System.Windows.Forms.Label();
            this.lblRegName = new System.Windows.Forms.Label();
            this.lblRegId = new System.Windows.Forms.Label();
            this.listBoxRegisteredAnimals = new System.Windows.Forms.ListBox();
            this.lblAge = new System.Windows.Forms.Label();
            this.textBoxNrOfTeeth = new System.Windows.Forms.TextBox();
            this.lblTailLength = new System.Windows.Forms.Label();
            this.groupBoxAnimalSpecs = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblShowEaterType = new System.Windows.Forms.Label();
            this.lblEaterType = new System.Windows.Forms.Label();
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
            this.listBoxFoodSchedule = new System.Windows.Forms.ListBox();
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
            this.groupBoxAnimalList.Controls.Add(this.lblSpecie);
            this.groupBoxAnimalList.Controls.Add(this.lblRegSpecialCharacteristics);
            this.groupBoxAnimalList.Controls.Add(this.lblRegGender);
            this.groupBoxAnimalList.Controls.Add(this.lblRegAge);
            this.groupBoxAnimalList.Controls.Add(this.lblRegName);
            this.groupBoxAnimalList.Controls.Add(this.lblRegId);
            this.groupBoxAnimalList.Controls.Add(this.listBoxRegisteredAnimals);
            this.groupBoxAnimalList.Location = new System.Drawing.Point(14, 420);
            this.groupBoxAnimalList.Name = "groupBoxAnimalList";
            this.groupBoxAnimalList.Size = new System.Drawing.Size(1156, 334);
            this.groupBoxAnimalList.TabIndex = 1;
            this.groupBoxAnimalList.TabStop = false;
            this.groupBoxAnimalList.Text = "List of registered animals";
            // 
            // lblSpecie
            // 
            this.lblSpecie.AutoSize = true;
            this.lblSpecie.Location = new System.Drawing.Point(82, 42);
            this.lblSpecie.Name = "lblSpecie";
            this.lblSpecie.Size = new System.Drawing.Size(53, 18);
            this.lblSpecie.TabIndex = 1;
            this.lblSpecie.Text = "Specie";
            // 
            // lblRegSpecialCharacteristics
            // 
            this.lblRegSpecialCharacteristics.AutoSize = true;
            this.lblRegSpecialCharacteristics.Location = new System.Drawing.Point(496, 42);
            this.lblRegSpecialCharacteristics.Name = "lblRegSpecialCharacteristics";
            this.lblRegSpecialCharacteristics.Size = new System.Drawing.Size(156, 18);
            this.lblRegSpecialCharacteristics.TabIndex = 0;
            this.lblRegSpecialCharacteristics.Text = "Special characteristics";
            // 
            // lblRegGender
            // 
            this.lblRegGender.AutoSize = true;
            this.lblRegGender.Location = new System.Drawing.Point(344, 44);
            this.lblRegGender.Name = "lblRegGender";
            this.lblRegGender.Size = new System.Drawing.Size(57, 18);
            this.lblRegGender.TabIndex = 0;
            this.lblRegGender.Text = "Gender";
            // 
            // lblRegAge
            // 
            this.lblRegAge.AutoSize = true;
            this.lblRegAge.Location = new System.Drawing.Point(272, 42);
            this.lblRegAge.Name = "lblRegAge";
            this.lblRegAge.Size = new System.Drawing.Size(33, 18);
            this.lblRegAge.TabIndex = 0;
            this.lblRegAge.Text = "Age";
            // 
            // lblRegName
            // 
            this.lblRegName.AutoSize = true;
            this.lblRegName.Location = new System.Drawing.Point(178, 42);
            this.lblRegName.Name = "lblRegName";
            this.lblRegName.Size = new System.Drawing.Size(48, 18);
            this.lblRegName.TabIndex = 0;
            this.lblRegName.Text = "Name";
            // 
            // lblRegId
            // 
            this.lblRegId.AutoSize = true;
            this.lblRegId.Location = new System.Drawing.Point(42, 42);
            this.lblRegId.Name = "lblRegId";
            this.lblRegId.Size = new System.Drawing.Size(22, 18);
            this.lblRegId.TabIndex = 0;
            this.lblRegId.Text = "ID";
            // 
            // listBoxRegisteredAnimals
            // 
            this.listBoxRegisteredAnimals.FormattingEnabled = true;
            this.listBoxRegisteredAnimals.ItemHeight = 18;
            this.listBoxRegisteredAnimals.Location = new System.Drawing.Point(24, 68);
            this.listBoxRegisteredAnimals.Name = "listBoxRegisteredAnimals";
            this.listBoxRegisteredAnimals.Size = new System.Drawing.Size(1105, 238);
            this.listBoxRegisteredAnimals.TabIndex = 0;
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
            this.groupBoxAnimalSpecs.Size = new System.Drawing.Size(1156, 399);
            this.groupBoxAnimalSpecs.TabIndex = 2;
            this.groupBoxAnimalSpecs.TabStop = false;
            this.groupBoxAnimalSpecs.Text = "Animal Specifications";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listBoxFoodSchedule);
            this.groupBox1.Controls.Add(this.lblShowEaterType);
            this.groupBox1.Controls.Add(this.lblEaterType);
            this.groupBox1.Location = new System.Drawing.Point(772, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(378, 299);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Feeding schedule";
            // 
            // lblShowEaterType
            // 
            this.lblShowEaterType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblShowEaterType.Location = new System.Drawing.Point(198, 22);
            this.lblShowEaterType.Name = "lblShowEaterType";
            this.lblShowEaterType.Size = new System.Drawing.Size(174, 20);
            this.lblShowEaterType.TabIndex = 1;
            this.lblShowEaterType.Text = "Carnivore";
            this.lblShowEaterType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblEaterType
            // 
            this.lblEaterType.Location = new System.Drawing.Point(6, 22);
            this.lblEaterType.Name = "lblEaterType";
            this.lblEaterType.Size = new System.Drawing.Size(79, 18);
            this.lblEaterType.TabIndex = 0;
            this.lblEaterType.Text = "Eater type";
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
            this.groupBoxSpecieSpecificData.Size = new System.Drawing.Size(197, 231);
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
            this.btnAddAnimal.Location = new System.Drawing.Point(510, 324);
            this.btnAddAnimal.Name = "btnAddAnimal";
            this.btnAddAnimal.Size = new System.Drawing.Size(166, 47);
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
            // listBoxFoodSchedule
            // 
            this.listBoxFoodSchedule.BackColor = System.Drawing.SystemColors.Control;
            this.listBoxFoodSchedule.Enabled = false;
            this.listBoxFoodSchedule.FormattingEnabled = true;
            this.listBoxFoodSchedule.ItemHeight = 18;
            this.listBoxFoodSchedule.Location = new System.Drawing.Point(144, 83);
            this.listBoxFoodSchedule.Name = "listBoxFoodSchedule";
            this.listBoxFoodSchedule.Size = new System.Drawing.Size(120, 94);
            this.listBoxFoodSchedule.TabIndex = 2;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 766);
            this.Controls.Add(this.groupBoxAnimalList);
            this.Controls.Add(this.groupBoxAnimalSpecs);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FormMain";
            this.Text = "Animal Motel";
            this.groupBoxGender.ResumeLayout(false);
            this.groupBoxAnimalList.ResumeLayout(false);
            this.groupBoxAnimalList.PerformLayout();
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
        private System.Windows.Forms.Label lblSpecie;
        private System.Windows.Forms.Label lblRegSpecialCharacteristics;
        private System.Windows.Forms.Label lblRegGender;
        private System.Windows.Forms.Label lblRegAge;
        private System.Windows.Forms.Label lblRegName;
        private System.Windows.Forms.Label lblRegId;
        private System.Windows.Forms.ListBox listBoxRegisteredAnimals;
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
    }
}

