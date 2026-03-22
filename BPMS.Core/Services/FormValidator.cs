using System;
using System.Linq;
using System.Windows.Forms;

namespace BPMS.Core.Services
{
    public static class FormValidator
    {
        public static bool ValidateRequiredFields(Control parent)
        {
            var controls = parent.Controls.OfType<TextBox>();

            foreach (var control in controls)
            {
                if (string.IsNullOrWhiteSpace(control.Text))
                {
                    control.Focus();
                    return false;
                }
            }

            return true;
        }
    }
}
