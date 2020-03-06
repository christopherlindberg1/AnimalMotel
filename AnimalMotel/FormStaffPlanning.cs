using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnimalMotel
{
    public partial class FormStaffPlanning : Form
    {




        // ========================= Methods ========================= //
        public FormStaffPlanning()
        {
            InitializeComponent();
            InitializeGUI();
        }

        private void InitializeGUI()
        {
            SetFormToDefaultState();
        }

        private void ClearInputFields()
        {
            textBoxQualification.Text = "";
            textBoxName.Text = "";
        }

        private void SetFormToDefaultState()
        {
            ClearInputFields();

            btnAdd.Enabled = true;
            btnChange.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void SetFormToEditState()
        {
            btnAdd.Enabled = false;
            btnChange.Enabled = true;
            btnDelete.Enabled = true;
        }

        /// <summary>
        ///   Adds a qualification to the storage and GUI.
        /// </summary>
        private void AddQualification()
        {
            AddQualificationToGUIList();
        }

        /// <summary>
        ///   Adds a qualification to the GUI.
        /// </summary>
        private void AddQualificationToGUIList()
        {
            listBoxQualifications.Items.Add(textBoxQualification.Text);
        }

        private void ChangeQualification()
        {

        }

        private void DeleteQualification()
        {

        }





        // ========================= Events ========================= //

        private void listBoxQualifications_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxQualifications.SelectedIndex == -1)
            {
                return;
            }

            SetFormToEditState();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                AddQualification();
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

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (listBoxQualifications.SelectedIndex == -1)
            {
                return;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listBoxQualifications.SelectedIndex == -1)
            {
                return;
            }
        }
    }
}
