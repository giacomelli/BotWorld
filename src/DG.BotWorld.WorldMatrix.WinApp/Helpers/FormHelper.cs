using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DG.BotWorld.WorldMatrix.WinApp.Forms;
using DG.BotWorld.EnvironmentSdk;

namespace DG.BotWorld.WorldMatrix.WinApp.Helpers
{
    public static class FormHelper
    {
        public static MainForm MainForm
        {
            get;
            set;
        }

        public static string StatusMessage
        {
            get
            {
                return MainForm.StatusLabel.Text;
            }

            set
            {
                MainForm.StatusLabel.Text = value;
            }
        }     
    }
}
