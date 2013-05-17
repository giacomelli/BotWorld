namespace DG.BotWorld.WorldMatrix.WinApp.UserControls
{
    partial class RunnerUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gpbAvailableBots = new System.Windows.Forms.GroupBox();
            this.lsvBots = new System.Windows.Forms.ListView();
            this.imlBots = new System.Windows.Forms.ImageList(this.components);
            this.pcbEnvironment = new System.Windows.Forms.PictureBox();
            this.spcMain = new System.Windows.Forms.SplitContainer();
            this.tbcBottom = new System.Windows.Forms.TabControl();
            this.tbpOptions = new System.Windows.Forms.TabPage();
            this.gpbSteps = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.nudStepDelay = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.chbShowSteps = new System.Windows.Forms.CheckBox();
            this.tbpOutput = new System.Windows.Forms.TabPage();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.gpbAvailableBots.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbEnvironment)).BeginInit();
            this.spcMain.Panel1.SuspendLayout();
            this.spcMain.Panel2.SuspendLayout();
            this.spcMain.SuspendLayout();
            this.tbcBottom.SuspendLayout();
            this.tbpOptions.SuspendLayout();
            this.gpbSteps.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudStepDelay)).BeginInit();
            this.tbpOutput.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbAvailableBots
            // 
            this.gpbAvailableBots.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.gpbAvailableBots.Controls.Add(this.lsvBots);
            this.gpbAvailableBots.ForeColor = System.Drawing.Color.ForestGreen;
            this.gpbAvailableBots.Location = new System.Drawing.Point(7, 3);
            this.gpbAvailableBots.Name = "gpbAvailableBots";
            this.gpbAvailableBots.Size = new System.Drawing.Size(207, 490);
            this.gpbAvailableBots.TabIndex = 11;
            this.gpbAvailableBots.TabStop = false;
            this.gpbAvailableBots.Text = "Bots";
            // 
            // lsvBots
            // 
            this.lsvBots.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lsvBots.CheckBoxes = true;
            this.lsvBots.LargeImageList = this.imlBots;
            this.lsvBots.Location = new System.Drawing.Point(6, 19);
            this.lsvBots.MultiSelect = false;
            this.lsvBots.Name = "lsvBots";
            this.lsvBots.Size = new System.Drawing.Size(195, 465);
            this.lsvBots.TabIndex = 3;
            this.lsvBots.UseCompatibleStateImageBehavior = false;
            this.lsvBots.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lsvBots_ItemChecked);
            this.lsvBots.SelectedIndexChanged += new System.EventHandler(this.lsvBots_SelectedIndexChanged);
            // 
            // imlBots
            // 
            this.imlBots.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imlBots.ImageSize = new System.Drawing.Size(32, 32);
            this.imlBots.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // pcbEnvironment
            // 
            this.pcbEnvironment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pcbEnvironment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcbEnvironment.Location = new System.Drawing.Point(220, 3);
            this.pcbEnvironment.Name = "pcbEnvironment";
            this.pcbEnvironment.Size = new System.Drawing.Size(765, 490);
            this.pcbEnvironment.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcbEnvironment.TabIndex = 8;
            this.pcbEnvironment.TabStop = false;
            // 
            // spcMain
            // 
            this.spcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcMain.Location = new System.Drawing.Point(0, 0);
            this.spcMain.Name = "spcMain";
            this.spcMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcMain.Panel1
            // 
            this.spcMain.Panel1.Controls.Add(this.gpbAvailableBots);
            this.spcMain.Panel1.Controls.Add(this.pcbEnvironment);
            // 
            // spcMain.Panel2
            // 
            this.spcMain.Panel2.Controls.Add(this.tbcBottom);
            this.spcMain.Size = new System.Drawing.Size(989, 639);
            this.spcMain.SplitterDistance = 496;
            this.spcMain.SplitterWidth = 10;
            this.spcMain.TabIndex = 15;
            // 
            // tbcBottom
            // 
            this.tbcBottom.Controls.Add(this.tbpOptions);
            this.tbcBottom.Controls.Add(this.tbpOutput);
            this.tbcBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcBottom.Location = new System.Drawing.Point(0, 0);
            this.tbcBottom.Name = "tbcBottom";
            this.tbcBottom.SelectedIndex = 0;
            this.tbcBottom.Size = new System.Drawing.Size(989, 133);
            this.tbcBottom.TabIndex = 14;
            // 
            // tbpOptions
            // 
            this.tbpOptions.Controls.Add(this.gpbSteps);
            this.tbpOptions.Location = new System.Drawing.Point(4, 22);
            this.tbpOptions.Name = "tbpOptions";
            this.tbpOptions.Size = new System.Drawing.Size(981, 107);
            this.tbpOptions.TabIndex = 0;
            this.tbpOptions.Text = "Options";
            this.tbpOptions.UseVisualStyleBackColor = true;
            // 
            // gpbSteps
            // 
            this.gpbSteps.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gpbSteps.Controls.Add(this.tableLayoutPanel1);
            this.gpbSteps.ForeColor = System.Drawing.Color.ForestGreen;
            this.gpbSteps.Location = new System.Drawing.Point(4, 3);
            this.gpbSteps.Name = "gpbSteps";
            this.gpbSteps.Size = new System.Drawing.Size(206, 101);
            this.gpbSteps.TabIndex = 10;
            this.gpbSteps.TabStop = false;
            this.gpbSteps.Text = "Steps";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.nudStepDelay, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.chbShowSteps, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(200, 82);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Show steps";
            // 
            // nudStepDelay
            // 
            this.nudStepDelay.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudStepDelay.Location = new System.Drawing.Point(103, 44);
            this.nudStepDelay.Maximum = new decimal(new int[] {
            60000,
            0,
            0,
            0});
            this.nudStepDelay.Name = "nudStepDelay";
            this.nudStepDelay.Size = new System.Drawing.Size(94, 20);
            this.nudStepDelay.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Step delay";
            // 
            // chbShowSteps
            // 
            this.chbShowSteps.AutoSize = true;
            this.chbShowSteps.Checked = true;
            this.chbShowSteps.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbShowSteps.Location = new System.Drawing.Point(103, 3);
            this.chbShowSteps.Name = "chbShowSteps";
            this.chbShowSteps.Size = new System.Drawing.Size(15, 14);
            this.chbShowSteps.TabIndex = 6;
            this.chbShowSteps.UseVisualStyleBackColor = true;
            this.chbShowSteps.CheckedChanged += new System.EventHandler(this.chbShowSteps_CheckedChanged);
            // 
            // tbpOutput
            // 
            this.tbpOutput.Controls.Add(this.txtOutput);
            this.tbpOutput.Location = new System.Drawing.Point(4, 22);
            this.tbpOutput.Name = "tbpOutput";
            this.tbpOutput.Size = new System.Drawing.Size(981, 106);
            this.tbpOutput.TabIndex = 1;
            this.tbpOutput.Text = "Output";
            this.tbpOutput.UseVisualStyleBackColor = true;
            // 
            // txtOutput
            // 
            this.txtOutput.BackColor = System.Drawing.Color.White;
            this.txtOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtOutput.Location = new System.Drawing.Point(0, 0);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtOutput.Size = new System.Drawing.Size(981, 55);
            this.txtOutput.TabIndex = 0;
            // 
            // RunnerUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.spcMain);
            this.Name = "RunnerUserControl";
            this.Size = new System.Drawing.Size(989, 639);
            this.Load += new System.EventHandler(this.RunnerUserControl_Load);
            this.gpbAvailableBots.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcbEnvironment)).EndInit();
            this.spcMain.Panel1.ResumeLayout(false);
            this.spcMain.Panel2.ResumeLayout(false);
            this.spcMain.ResumeLayout(false);
            this.tbcBottom.ResumeLayout(false);
            this.tbpOptions.ResumeLayout(false);
            this.gpbSteps.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudStepDelay)).EndInit();
            this.tbpOutput.ResumeLayout(false);
            this.tbpOutput.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbAvailableBots;
        private System.Windows.Forms.ListView lsvBots;
        private System.Windows.Forms.PictureBox pcbEnvironment;
        private System.Windows.Forms.ImageList imlBots;
        private System.Windows.Forms.SplitContainer spcMain;
        private System.Windows.Forms.TabControl tbcBottom;
        private System.Windows.Forms.TabPage tbpOptions;
        private System.Windows.Forms.CheckBox chbShowSteps;
        private System.Windows.Forms.TabPage tbpOutput;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.GroupBox gpbSteps;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudStepDelay;
        private System.Windows.Forms.Label label1;

    }
}
