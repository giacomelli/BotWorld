using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DG.BotWorld.WorldMatrix.WinApp.Forms;
using DG.BotWorld.WorldMatrix.WinApp.Helpers;

namespace DG.BotWorld.WorldMatrix.WinApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form.CheckForIllegalCrossThreadCalls = false;
            FormHelper.MainForm = new MainForm();
            Application.Run(FormHelper.MainForm);
        }
    }
}
