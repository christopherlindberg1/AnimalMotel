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
        private Staff _staff;




        // ========================= Properties ========================= //
        public Staff Staff
        {
            get { return _staff; }
            set { _staff = value; }
        }




        // ========================= Methods ========================= //
        public FormStaffPlanning()
        {
            InitializeComponent();
            InitializeForm();
        }

        private void ClearQualificationInputFields()
        {
            textBoxQualification.Text = "";
        }

        private void ClearAllInputFields()
        {
            textBoxName.Text = "";
            listBoxQualifications.Items.Clear();
            ClearQualificationInputFields();
        }

        private void SetFormToDefaultState()
        {
            lblQualification.Text = "Add qualification";
            listBoxQualifications.SelectedIndex = -1;
            btnChange.Enabled = false;
            btnDelete.Enabled = false;

            ClearQualificationInputFields();
        }

        private void SetFormToEditState()
        {
            lblQualification.Text = "Change qualification";
            btnChange.Enabled = true;
            btnDelete.Enabled = true;
            textBoxQualification.Text = listBoxQualifications.SelectedItem.ToString();
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
            ClearQualificationInputFields();
        }

        private void ChangeQualification()
        {
            if (listBoxQualifications.SelectedIndex == -1)
            {
                return;
            }

            if (ValidateQualification())
            {
                listBoxQualifications.Items[listBoxQualifications.SelectedIndex]
                    = textBoxQualification.Text;
            }
            else
            {
                MessageBox.Show(MessageHandler.GetMessages());
            }
        }

        private void DeleteQualification()
        {
            if (listBoxQualifications.SelectedIndex == -1)
            {
                return;
            }

            listBoxQualifications.Items.RemoveAt(listBoxQualifications.SelectedIndex);
            textBoxQualification.Text = "";
        }

        private Staff CreateStaffObject()
        {
            Staff staff = new Staff();

            staff.Name = textBoxName.Text;

            foreach (string item in listBoxQualifications.Items)
            {
                staff.Qualifications.Add(item);
            }

            return staff;
        }





        // ========================= Events ========================= //

        private void FormStaffPlanning_Load(object sender, EventArgs e)
        {
            ClearAllInputFields();
        }

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
            if (ValidateQualification())
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
                MessageBox.Show(MessageHandler.GetMessages());
                return;
            }

            ChangeQualification();
            SetFormToDefaultState();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listBoxQualifications.SelectedIndex == -1)
            {
                return;
            }

            DeleteQualification();
            SetFormToDefaultState();

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                // Creates staff object that can be accessed and stored in FormMain.
                Staff = CreateStaffObject();
                // Sets dialogresult so FormMain knows if to fetch staff or not.
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(MessageHandler.GetMessages());
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        
    }
}
