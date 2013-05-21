#region Usings
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using DG.BotWorld.BotSdk;
using DG.BotWorld.Hosting;
using DG.BotWorld.WorldMatrix.WinApp.Helpers;
using DG.BotWorld.WorldMatrix.WinApp.UserControls.Resources;
using DG.Framework.Text;
#endregion

namespace DG.BotWorld.WorldMatrix.WinApp.UserControls
{
    /// <summary>
    /// User control to run environments.
    /// </summary>
    public partial class RunnerUserControl : UserControl
    {
        #region Fields   
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes the <see cref="RunnerUserControl"/> class.
        /// </summary>
        static RunnerUserControl()
        {
            MatrixHelper.SelectedEnvironmentChanged += new EventHandler(MatrixHelper_SelectedEnvironmentChanged);
            MatrixHelper.SelectedBotsChanged += new EventHandler(MatrixHelper_SelectedBotsChanged);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RunnerUserControl"/> class.
        /// </summary>
        public RunnerUserControl()
        {
            Instance = this;
            InitializeComponent();
        }
        #endregion
        
        #region Properties
        /// <summary>
        /// Gets or sets the current instance.
        /// </summary>
        private static RunnerUserControl Instance
        {
            get;
            set;
        }
        #endregion

        #region Operations
        /// <summary>
        /// Handles the SelectedBotsChanged event of the MatrixHelper.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        static void MatrixHelper_SelectedBotsChanged(object sender, EventArgs e)
        {
            Instance.LoadBotsList();
        }

        /// <summary>
        /// Handles the SelectedEnvironmentChanged event of the MatrixHelper.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        static void MatrixHelper_SelectedEnvironmentChanged(object sender, EventArgs e)
        {
            Instance.InitializeEnvironment();
        }

        /// <summary>
        /// Initialize the current environment.
        /// </summary>
        public void InitializeEnvironment()
        {
            if (!DesignMode)
            {                
                LoadBotsList();

                var environment = MatrixHelper.SelectedEnvironment;
                var f = FormHelper.MainForm;

                f.RunEnvironmentButton.Enabled = false;
                f.StopEnvironmentButton.Enabled = false;

                if (environment == null)
                {
                    f.InitializeEnvironmentButton.Enabled = false;
                }
                else
                {
                    var c = Host.Current;

                    c.InitializeEnvironment(environment);
                    UpdateEnvironmentImage();
                    Text = RunnerUserControlResource.Title;
                    AddOutputMessage(RunnerUserControlResource.EnvironmentInitializedMessage);

                    f.InitializeEnvironmentButton.Enabled = true;
                }
            }
        }

        /// <summary>
        /// Run the current environment.
        /// </summary>
        public void RunEnvironment()
        {
            tbcBottom.SelectedTab = tbpOutput;
            lsvBots.Enabled = false;

            var f = FormHelper.MainForm;
            Text = RunnerUserControlResource.Title;
            f.InitializeEnvironmentButton.Enabled = false;
            var c = Host.Current;

            c.EnvironmentUpdated -= new EventHandler<EnvironmentUpdatedEventArgs>(HandleEnvironmentUpdated);
            c.EnvironmentUpdated += new EventHandler<EnvironmentUpdatedEventArgs>(HandleEnvironmentUpdated);

            c.EnvironmentRan -= new EventHandler<EnvironmentRanEventArgs>(HandleEnvironmentRan);
            c.EnvironmentRan += new EventHandler<EnvironmentRanEventArgs>(HandleEnvironmentRan);

            c.EnvironmentAborted -= new EventHandler<EnvironmentAbortedEventArgs>(HandleEnvironmentAborted);
            c.EnvironmentAborted += new EventHandler<EnvironmentAbortedEventArgs>(HandleEnvironmentAborted);

            c.EnvironmentError -= new EventHandler<EnvironmentErrorEventArgs>(HandleEnvironmentError);
            c.EnvironmentError += new EventHandler<EnvironmentErrorEventArgs>(HandleEnvironmentError);

            var bots = new List<IBot>();

            foreach (ListViewItem item in lsvBots.CheckedItems)
            {
                bots.Add((IBot)item.Tag);
            }

            var botsText = StringHelper.Join(bots.Select(b => b.Name).ToList(), ", ", RunnerUserControlResource.AndText);
            AddOutputMessage(StringHelper.FormatSingularOrPlural(bots.Count, RunnerUserControlResource.BotIsThinkingMessage, RunnerUserControlResource.BotsAreThinkingMessage, botsText));            

            f.InitializeEnvironmentButton.Enabled = false;
            f.RunEnvironmentButton.Enabled = false;
            f.StopEnvironmentButton.Enabled = true;

            
            c.RunEnvironmentAsync(MatrixHelper.SelectedEnvironment, bots.ToArray());                     
        }

        private void HandleEnvironmentError(object sender, EnvironmentErrorEventArgs e)
        {
            AddOutputMessage(e.Exception.Message);            
        }

        private void HandleEnvironmentAborted(object sender, EnvironmentAbortedEventArgs e)
        {
            UpdateEnvironmentImage();
            UpdateButtonsToEnvironmentStopped();

            lsvBots.Enabled = true;
        }

        private void HandleEnvironmentUpdated(object sender, EnvironmentUpdatedEventArgs e)
        {
            try
            {
                if (chbShowSteps.Checked)
                {
                    UpdateEnvironmentImage();
                    UpdateMovesText(e.Cycle);

                    if (nudStepDelay.Value > 0)
                    {
                        Thread.Sleep(Convert.ToInt32(nudStepDelay.Value));
                    }
                }
            }
            catch (ThreadAbortException)
            {
                // No problem.
            }
        }

        private void HandleEnvironmentRan(object sender, EnvironmentRanEventArgs e)
        {
            UpdateEnvironmentImage();
            UpdateButtonsToEnvironmentStopped();
            UpdateMovesText(e.Cycles);            
            lsvBots.Enabled = true;
            UpdateMovesText(e.Cycles);

            var botsText = StringHelper.Join(e.Bots.Select(b => b.Name).ToList(), ", ", RunnerUserControlResource.AndText);
            AddOutputMessage(StringHelper.FormatSingularOrPlural(e.Bots.Count, RunnerUserControlResource.BotHasFinishedMessage, RunnerUserControlResource.BotsHaveFinishedMessage, botsText));
            AddOutputMessage(RunnerUserControlResource.EnvironmentFinishedInCyclesMessage, e.Cycles);
        }

        public void StopEnvironment(bool abort)
        {
            Host.Current.AbortEnvironment(MatrixHelper.SelectedEnvironment);            
            UpdateButtonsToEnvironmentStopped();
            AddOutputMessage(RunnerUserControlResource.EnvironmentStoppedMessage);
            lsvBots.Enabled = true;
        }

        private void UpdateButtonsToEnvironmentStopped()
        {
            var f = FormHelper.MainForm;
            f.InitializeEnvironmentButton.Enabled = true;
            f.RunEnvironmentButton.Enabled = true;
            f.StopEnvironmentButton.Enabled = false;             
        }

        private void UpdateEnvironmentImage()
        {
			var image = Host.Current.RenderEnvironmentToImage (MatrixHelper.SelectedEnvironment);

			if(image != null)
			{
            	pcbEnvironment.Image = image;
            	pcbEnvironment.Refresh();
			}
        }

        private void UpdateMovesText(int cycle)
        {
            FormHelper.MainForm.Text = String.Format(CultureInfo.CurrentUICulture, RunnerUserControlResource.TitleWithCycles, cycle);
        }

        /// <summary>
        /// Load the bots list with selected bots.
        /// </summary>
        private void LoadBotsList()
        {
            if (!DesignMode)
            {
                var bots = MatrixHelper.SelectedBots;
                FormHelper.MainForm.RunEnvironmentButton.Enabled = false;
                FormHelper.MainForm.StopEnvironmentButton.Enabled = false;

                lsvBots.Clear();

                foreach (var b in bots)
                {
                    imlBots.Images.Add(b.UIInformation.Avatar);
                    var item = new ListViewItem(b.Name, imlBots.Images.Count - 1);
                    item.Tag = b;
                    lsvBots.Items.Add(item);
                }
            }
        }

        private void AddOutputMessage(string msg, params object[] pars)
        {
            txtOutput.Text += String.Format(CultureInfo.CurrentUICulture, msg, pars) + Environment.NewLine;
            txtOutput.SelectionStart = txtOutput.Text.Length - 1;
            txtOutput.ScrollToCaret();
        }
        #endregion

        #region Events handlers
        private void btnRunEnvironment_Click(object sender, EventArgs e)
        {
            RunEnvironment();            
        }

        private void btnInitializeEnvironment_Click(object sender, EventArgs e)
        {
            InitializeEnvironment();
        }

        private void RunnerUserControl_Load(object sender, EventArgs e)
        {
            LoadBotsList();
            InitializeEnvironment();
        }                
        #endregion        

        private void btnStopEnvironment_Click(object sender, EventArgs e)
        {
            StopEnvironment(true);
        }

        private void lsvBots_SelectedIndexChanged(object sender, EventArgs e)
        {
  
        }

        private void lsvBots_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            var env = MatrixHelper.SelectedEnvironment;
            int selectedBotsCount = lsvBots.CheckedItems.Count;

            FormHelper.MainForm.RunEnvironmentButton.Enabled = (selectedBotsCount >= env.MinBotsNumber && selectedBotsCount <= env.MaxBotsNumber);
        }

        private void chbShowSteps_CheckedChanged(object sender, EventArgs e)
        {
            nudStepDelay.Enabled = chbShowSteps.Checked;
        }                
    }
}
