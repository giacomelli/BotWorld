using System;
using System.Globalization;
using System.Windows.Forms;
using DG.BotWorld.WorldMatrix.WinApp.Forms.Resources;
using DG.BotWorld.WorldMatrix.WinApp.Helpers;
using DG.BotWorld.Hosting;

namespace DG.BotWorld.WorldMatrix.WinApp.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
			try
			{
            	InitializeComponent();
			}
			catch(WorldException ex) {
				MessageBox.Show (ex.Message, "World Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
				Application.Exit ();
			}
        }

        public ToolStripStatusLabel StatusLabel
        {
            get
            {
                return tslStatus;
            }
        }

        public ToolStripButton InitializeEnvironmentButton
        {
            get
            {
                return tsbInitializeEnvironment;
            }
        }

        public ToolStripButton RunEnvironmentButton
        {
            get
            {
                return tsbRunEnvironment;
            }
        }

        public ToolStripButton StopEnvironmentButton
        {
            get
            {
                return tsbStopEnvironment;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                MatrixHelper.SelectedEnvironmentChanged += new EventHandler(MatrixHelper_SelectedEnvironmentChanged);
                Text = MainFormResource.Text;
            }
        }

        void MatrixHelper_SelectedEnvironmentChanged(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                Text = String.Format(CultureInfo.CurrentUICulture, MainFormResource.TextWithSelectedEnvironment, MatrixHelper.SelectedEnvironment.Name);
            }
        }

        private void tsbInitializeEnvironment_Click(object sender, EventArgs e)
        {
            runnerUserControl.InitializeEnvironment();
        }

        private void tsbRunEnvironment_Click(object sender, EventArgs e)
        {            
            runnerUserControl.RunEnvironment();            
        }

        private void tsbStopEnvironment_Click(object sender, EventArgs e)
        {
            runnerUserControl.StopEnvironment(true);
        }                     
    }
}
