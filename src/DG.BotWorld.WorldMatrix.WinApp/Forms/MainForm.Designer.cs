namespace DG.BotWorld.WorldMatrix.WinApp.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.stpMain = new System.Windows.Forms.StatusStrip();
            this.tslStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.imlTabsIcons = new System.Windows.Forms.ImageList(this.components);
            this.tscMain = new System.Windows.Forms.ToolStripContainer();
            this.tbcMain = new System.Windows.Forms.TabControl();
            this.tbpEnvironments = new System.Windows.Forms.TabPage();
            this.environmentsUserControl = new DG.BotWorld.WorldMatrix.WinApp.UserControls.EnvironmentsUserControl();
            this.tbpBots = new System.Windows.Forms.TabPage();
            this.botsUserControl = new DG.BotWorld.WorldMatrix.WinApp.UserControls.BotsUserControl();
            this.tbpRunner = new System.Windows.Forms.TabPage();
            this.runnerUserControl = new DG.BotWorld.WorldMatrix.WinApp.UserControls.RunnerUserControl();
            this.tspMain = new System.Windows.Forms.ToolStrip();
            this.tsbInitializeEnvironment = new System.Windows.Forms.ToolStripButton();
            this.tsbRunEnvironment = new System.Windows.Forms.ToolStripButton();
            this.tsbStopEnvironment = new System.Windows.Forms.ToolStripButton();
            this.stpMain.SuspendLayout();
            this.tscMain.ContentPanel.SuspendLayout();
            this.tscMain.TopToolStripPanel.SuspendLayout();
            this.tscMain.SuspendLayout();
            this.tbcMain.SuspendLayout();
            this.tbpEnvironments.SuspendLayout();
            this.tbpBots.SuspendLayout();
            this.tbpRunner.SuspendLayout();
            this.tspMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // stpMain
            // 
            this.stpMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslStatus});
            this.stpMain.Location = new System.Drawing.Point(0, 543);
            this.stpMain.Name = "stpMain";
            this.stpMain.Size = new System.Drawing.Size(882, 22);
            this.stpMain.TabIndex = 3;
            // 
            // tslStatus
            // 
            this.tslStatus.Name = "tslStatus";
            this.tslStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // imlTabsIcons
            // 
            this.imlTabsIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlTabsIcons.ImageStream")));
            this.imlTabsIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.imlTabsIcons.Images.SetKeyName(0, "Environments");
            this.imlTabsIcons.Images.SetKeyName(1, "Bots");
            this.imlTabsIcons.Images.SetKeyName(2, "Runner");
            // 
            // tscMain
            // 
            // 
            // tscMain.ContentPanel
            // 
            this.tscMain.ContentPanel.Controls.Add(this.tbcMain);
            this.tscMain.ContentPanel.Size = new System.Drawing.Size(882, 512);
            this.tscMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tscMain.Location = new System.Drawing.Point(0, 0);
            this.tscMain.Name = "tscMain";
            this.tscMain.Size = new System.Drawing.Size(882, 543);
            this.tscMain.TabIndex = 5;
            this.tscMain.Text = "toolStripContainer1";
            // 
            // tscMain.TopToolStripPanel
            // 
            this.tscMain.TopToolStripPanel.Controls.Add(this.tspMain);
            // 
            // tbcMain
            // 
            this.tbcMain.Controls.Add(this.tbpEnvironments);
            this.tbcMain.Controls.Add(this.tbpBots);
            this.tbcMain.Controls.Add(this.tbpRunner);
            this.tbcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcMain.Location = new System.Drawing.Point(0, 0);
            this.tbcMain.Name = "tbcMain";
            this.tbcMain.SelectedIndex = 0;
            this.tbcMain.Size = new System.Drawing.Size(882, 512);
            this.tbcMain.TabIndex = 0;
            // 
            // tbpEnvironments
            // 
            this.tbpEnvironments.Controls.Add(this.environmentsUserControl);
            this.tbpEnvironments.ImageKey = "Environments";
            this.tbpEnvironments.Location = new System.Drawing.Point(4, 31);
            this.tbpEnvironments.Name = "tbpEnvironments";
            this.tbpEnvironments.Padding = new System.Windows.Forms.Padding(3);
            this.tbpEnvironments.Size = new System.Drawing.Size(874, 477);
            this.tbpEnvironments.TabIndex = 0;
            this.tbpEnvironments.Text = "Environments";
            this.tbpEnvironments.UseVisualStyleBackColor = true;
            // 
            // environmentsUserControl
            // 
            this.environmentsUserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.environmentsUserControl.Location = new System.Drawing.Point(3, 3);
            this.environmentsUserControl.Name = "environmentsUserControl";
            this.environmentsUserControl.Size = new System.Drawing.Size(868, 471);
            this.environmentsUserControl.TabIndex = 0;
            // 
            // tbpBots
            // 
            this.tbpBots.Controls.Add(this.botsUserControl);
            this.tbpBots.ImageKey = "Bots";
            this.tbpBots.Location = new System.Drawing.Point(4, 31);
            this.tbpBots.Name = "tbpBots";
            this.tbpBots.Size = new System.Drawing.Size(874, 477);
            this.tbpBots.TabIndex = 2;
            this.tbpBots.Text = "Bots";
            this.tbpBots.UseVisualStyleBackColor = true;
            // 
            // botsUserControl
            // 
            this.botsUserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.botsUserControl.Location = new System.Drawing.Point(0, 0);
            this.botsUserControl.Name = "botsUserControl";
            this.botsUserControl.Size = new System.Drawing.Size(192, 74);
            this.botsUserControl.TabIndex = 0;
            // 
            // tbpRunner
            // 
            this.tbpRunner.Controls.Add(this.runnerUserControl);
            this.tbpRunner.ImageKey = "Runner";
            this.tbpRunner.Location = new System.Drawing.Point(4, 31);
            this.tbpRunner.Name = "tbpRunner";
            this.tbpRunner.Size = new System.Drawing.Size(874, 477);
            this.tbpRunner.TabIndex = 1;
            this.tbpRunner.Text = "Runner";
            this.tbpRunner.UseVisualStyleBackColor = true;
            // 
            // runnerUserControl
            // 
            this.runnerUserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.runnerUserControl.Location = new System.Drawing.Point(0, 0);
            this.runnerUserControl.Name = "runnerUserControl";
            this.runnerUserControl.Size = new System.Drawing.Size(192, 74);
            this.runnerUserControl.TabIndex = 0;
            // 
            // tspMain
            // 
            this.tspMain.Dock = System.Windows.Forms.DockStyle.None;
            this.tspMain.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.tspMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbInitializeEnvironment,
            this.tsbRunEnvironment,
            this.tsbStopEnvironment});
            this.tspMain.Location = new System.Drawing.Point(0, 0);
            this.tspMain.Name = "tspMain";
            this.tspMain.Size = new System.Drawing.Size(882, 31);
            this.tspMain.Stretch = true;
            this.tspMain.TabIndex = 0;
            // 
            // tsbInitializeEnvironment
            // 
            this.tsbInitializeEnvironment.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbInitializeEnvironment.Enabled = false;
            this.tsbInitializeEnvironment.Image = ((System.Drawing.Image)(resources.GetObject("tsbInitializeEnvironment.Image")));
            this.tsbInitializeEnvironment.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbInitializeEnvironment.Name = "tsbInitializeEnvironment";
            this.tsbInitializeEnvironment.Size = new System.Drawing.Size(28, 28);
            this.tsbInitializeEnvironment.Click += new System.EventHandler(this.tsbInitializeEnvironment_Click);
            // 
            // tsbRunEnvironment
            // 
            this.tsbRunEnvironment.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRunEnvironment.Enabled = false;
            this.tsbRunEnvironment.Image = ((System.Drawing.Image)(resources.GetObject("tsbRunEnvironment.Image")));
            this.tsbRunEnvironment.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRunEnvironment.Name = "tsbRunEnvironment";
            this.tsbRunEnvironment.Size = new System.Drawing.Size(28, 28);
            this.tsbRunEnvironment.Click += new System.EventHandler(this.tsbRunEnvironment_Click);
            // 
            // tsbStopEnvironment
            // 
            this.tsbStopEnvironment.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbStopEnvironment.Enabled = false;
            this.tsbStopEnvironment.Image = ((System.Drawing.Image)(resources.GetObject("tsbStopEnvironment.Image")));
            this.tsbStopEnvironment.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbStopEnvironment.Name = "tsbStopEnvironment";
            this.tsbStopEnvironment.Size = new System.Drawing.Size(28, 28);
            this.tsbStopEnvironment.Click += new System.EventHandler(this.tsbStopEnvironment_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 565);
            this.Controls.Add(this.tscMain);
            this.Controls.Add(this.stpMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.Text = "Bot World - Matrix";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.stpMain.ResumeLayout(false);
            this.stpMain.PerformLayout();
            this.tscMain.ContentPanel.ResumeLayout(false);
            this.tscMain.TopToolStripPanel.ResumeLayout(false);
            this.tscMain.TopToolStripPanel.PerformLayout();
            this.tscMain.ResumeLayout(false);
            this.tscMain.PerformLayout();
            this.tbcMain.ResumeLayout(false);
            this.tbpEnvironments.ResumeLayout(false);
            this.tbpBots.ResumeLayout(false);
            this.tbpRunner.ResumeLayout(false);
            this.tspMain.ResumeLayout(false);
            this.tspMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip stpMain;
        private System.Windows.Forms.ToolStripStatusLabel tslStatus;
        private System.Windows.Forms.ToolStripContainer tscMain;
        private System.Windows.Forms.TabControl tbcMain;
        private System.Windows.Forms.TabPage tbpEnvironments;
        private System.Windows.Forms.TabPage tbpRunner;
        private System.Windows.Forms.TabPage tbpBots;
        private DG.BotWorld.WorldMatrix.WinApp.UserControls.EnvironmentsUserControl environmentsUserControl;
        private DG.BotWorld.WorldMatrix.WinApp.UserControls.BotsUserControl botsUserControl;
        private DG.BotWorld.WorldMatrix.WinApp.UserControls.RunnerUserControl runnerUserControl;
        private System.Windows.Forms.ToolStrip tspMain;
        private System.Windows.Forms.ToolStripButton tsbInitializeEnvironment;
        private System.Windows.Forms.ToolStripButton tsbRunEnvironment;
        private System.Windows.Forms.ToolStripButton tsbStopEnvironment;
        private System.Windows.Forms.ImageList imlTabsIcons;
    }
}