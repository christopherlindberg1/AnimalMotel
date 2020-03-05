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


        private bool ValidateInput()
        {
            bool nameOk = ValidateName();
            bool qualificationOk = ValidateQualification();

            return nameOk && qualificationOk;
        }

        private bool ValidateName()
        {
            if (String.IsNullOrWhiteSpace(textBoxName.Text))
            {
                _messageHandler.AddMessage("Name cannot be empty.");
                return false;
            }

            return true;
        }

        private bool ValidateQualification()
        {
            if (String.IsNullOrWhiteSpace(textBoxQualification.Text))
            {
                _messageHandler.AddMessage("Qualification cannot be empty.");
                return false;
            }

            return true;
        }
    }
}
