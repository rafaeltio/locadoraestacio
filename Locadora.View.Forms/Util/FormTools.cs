using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Locadora.View.Forms.Util
{
    public static class FormTools
    {
        public static void LimparControles(Control.ControlCollection c)
        {
            foreach (Control item in c)
            {
                if (item.HasChildren)
                    FormTools.LimparControles(item.Controls);

                if (item is TextBox)
                    ((TextBox)item).Clear();
                if (item is MaskedTextBox)
                    ((MaskedTextBox)item).Clear();
                if (item is CheckBox)
                    ((CheckBox)item).Checked = false;
            }

        }
    }
}
