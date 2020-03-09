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
        private readonly MessageHandler _messageHandler = new MessageHandler();




        // ========================= Properties ========================= //

        private MessageHandler MessageHandler
        {
            get { return _messageHandler; }
        }




        // ========================= Methods ========================= //

        private bool ValidateInput()
        {
            bool nameOk = ValidateName();
            bool qualificationOk = ValidateAllQualifications();

            return nameOk && qualificationOk;
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

        private bool ValidateName()
        {
            return ValidateTextBoxString(textBoxName, "Name cannot be empty");
        }

        private bool ValidateQualification()
        {
            if (String.IsNullOrWhiteSpace(textBoxQualification.Text))
            {
                MessageHandler.AddMessage("Qualification cannot be empty.");
                return false;
            }

            return true;
        }

        private bool ValidateAllQualifications()
        {
            if (listBoxQualifications.Items.Count == 0)
            {
                MessageHandler.AddMessage("You must add at least one qualification.");
                return false;
            }

            return true;
        }
    }
}
