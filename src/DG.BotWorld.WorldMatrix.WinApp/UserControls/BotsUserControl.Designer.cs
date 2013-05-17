namespace DG.BotWorld.WorldMatrix.WinApp.UserControls
{
    partial class BotsUserControl
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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("With needed abilities for environment", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Without neeed abilities", System.Windows.Forms.HorizontalAlignment.Left);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BotsUserControl));
            this.gpbAllBots = new System.Windows.Forms.GroupBox();
            this.spcBots = new System.Windows.Forms.SplitContainer();
            this.lsvAllBots = new System.Windows.Forms.ListView();
            this.imlBots = new System.Windows.Forms.ImageList(this.components);
            this.pgdSelectedBot = new System.Windows.Forms.PropertyGrid();
            this.grbBotAbilities = new System.Windows.Forms.GroupBox();
            this.lsvBotAbilities = new System.Windows.Forms.ListView();
            this.clhDefault = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clhInterface = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clhInstance = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imlBotAbilities = new System.Windows.Forms.ImageList(this.components);
            this.spcMain = new System.Windows.Forms.SplitContainer();
            this.gpbAllBots.SuspendLayout();
            this.spcBots.Panel1.SuspendLayout();
            this.spcBots.Panel2.SuspendLayout();
            this.spcBots.SuspendLayout();
            this.grbBotAbilities.SuspendLayout();
            this.spcMain.Panel1.SuspendLayout();
            this.spcMain.Panel2.SuspendLayout();
            this.spcMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbAllBots
            // 
            this.gpbAllBots.Controls.Add(this.spcBots);
            this.gpbAllBots.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpbAllBots.ForeColor = System.Drawing.Color.ForestGreen;
            this.gpbAllBots.Location = new System.Drawing.Point(0, 0);
            this.gpbAllBots.Name = "gpbAllBots";
            this.gpbAllBots.Size = new System.Drawing.Size(881, 369);
            this.gpbAllBots.TabIndex = 0;
            this.gpbAllBots.TabStop = false;
            this.gpbAllBots.Text = "Available bots";
            // 
            // spcBots
            // 
            this.spcBots.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.spcBots.Location = new System.Drawing.Point(6, 19);
            this.spcBots.Name = "spcBots";
            // 
            // spcBots.Panel1
            // 
            this.spcBots.Panel1.Controls.Add(this.lsvAllBots);
            // 
            // spcBots.Panel2
            // 
            this.spcBots.Panel2.Controls.Add(this.pgdSelectedBot);
            this.spcBots.Size = new System.Drawing.Size(869, 344);
            this.spcBots.SplitterDistance = 585;
            this.spcBots.TabIndex = 5;
            // 
            // lsvAllBots
            // 
            this.lsvAllBots.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lsvAllBots.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lsvAllBots.CheckBoxes = true;
            listViewGroup1.Header = "With needed abilities for environment";
            listViewGroup1.Name = "lvgWithAbilities";
            listViewGroup2.Header = "Without neeed abilities";
            listViewGroup2.Name = "lvgWithoutAbilities";
            this.lsvAllBots.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2});
            this.lsvAllBots.HideSelection = false;
            this.lsvAllBots.LargeImageList = this.imlBots;
            this.lsvAllBots.Location = new System.Drawing.Point(0, 0);
            this.lsvAllBots.MultiSelect = false;
            this.lsvAllBots.Name = "lsvAllBots";
            this.lsvAllBots.Size = new System.Drawing.Size(582, 341);
            this.lsvAllBots.TabIndex = 4;
            this.lsvAllBots.UseCompatibleStateImageBehavior = false;
            this.lsvAllBots.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lsvAllBots_ItemChecked);
            this.lsvAllBots.SelectedIndexChanged += new System.EventHandler(this.lsvAvailableBots_SelectedIndexChanged);
            // 
            // imlBots
            // 
            this.imlBots.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imlBots.ImageSize = new System.Drawing.Size(32, 32);
            this.imlBots.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // pgdSelectedBot
            // 
            this.pgdSelectedBot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgdSelectedBot.Location = new System.Drawing.Point(0, 0);
            this.pgdSelectedBot.Name = "pgdSelectedBot";
            this.pgdSelectedBot.Size = new System.Drawing.Size(280, 344);
            this.pgdSelectedBot.TabIndex = 4;
            this.pgdSelectedBot.Visible = false;
            // 
            // grbBotAbilities
            // 
            this.grbBotAbilities.Controls.Add(this.lsvBotAbilities);
            this.grbBotAbilities.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbBotAbilities.ForeColor = System.Drawing.Color.ForestGreen;
            this.grbBotAbilities.Location = new System.Drawing.Point(0, 0);
            this.grbBotAbilities.Name = "grbBotAbilities";
            this.grbBotAbilities.Size = new System.Drawing.Size(881, 200);
            this.grbBotAbilities.TabIndex = 1;
            this.grbBotAbilities.TabStop = false;
            this.grbBotAbilities.Text = "Selected bot abilities";
            // 
            // lsvBotAbilities
            // 
            this.lsvBotAbilities.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clhDefault,
            this.clhInterface,
            this.clhInstance});
            this.lsvBotAbilities.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvBotAbilities.LargeImageList = this.imlBotAbilities;
            this.lsvBotAbilities.Location = new System.Drawing.Point(3, 16);
            this.lsvBotAbilities.MultiSelect = false;
            this.lsvBotAbilities.Name = "lsvBotAbilities";
            this.lsvBotAbilities.ShowGroups = false;
            this.lsvBotAbilities.Size = new System.Drawing.Size(875, 181);
            this.lsvBotAbilities.SmallImageList = this.imlBotAbilities;
            this.lsvBotAbilities.TabIndex = 5;
            this.lsvBotAbilities.TileSize = new System.Drawing.Size(500, 65);
            this.lsvBotAbilities.UseCompatibleStateImageBehavior = false;
            this.lsvBotAbilities.View = System.Windows.Forms.View.Details;
            // 
            // clhDefault
            // 
            this.clhDefault.Text = "";
            this.clhDefault.Width = 48;
            // 
            // clhInterface
            // 
            this.clhInterface.Text = "Interface";
            this.clhInterface.Width = 600;
            // 
            // clhInstance
            // 
            this.clhInstance.Text = "Instance";
            this.clhInstance.Width = 600;
            // 
            // imlBotAbilities
            // 
            this.imlBotAbilities.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlBotAbilities.ImageStream")));
            this.imlBotAbilities.TransparentColor = System.Drawing.Color.Transparent;
            this.imlBotAbilities.Images.SetKeyName(0, "BotAbility");
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
            this.spcMain.Panel1.Controls.Add(this.gpbAllBots);
            // 
            // spcMain.Panel2
            // 
            this.spcMain.Panel2.Controls.Add(this.grbBotAbilities);
            this.spcMain.Size = new System.Drawing.Size(881, 573);
            this.spcMain.SplitterDistance = 369;
            this.spcMain.TabIndex = 2;
            // 
            // BotsUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.spcMain);
            this.Name = "BotsUserControl";
            this.Size = new System.Drawing.Size(881, 573);
            this.Load += new System.EventHandler(this.BotsUserControl_Load);
            this.gpbAllBots.ResumeLayout(false);
            this.spcBots.Panel1.ResumeLayout(false);
            this.spcBots.Panel2.ResumeLayout(false);
            this.spcBots.ResumeLayout(false);
            this.grbBotAbilities.ResumeLayout(false);
            this.spcMain.Panel1.ResumeLayout(false);
            this.spcMain.Panel2.ResumeLayout(false);
            this.spcMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbAllBots;
        private System.Windows.Forms.ImageList imlBots;
        private System.Windows.Forms.ListView lsvAllBots;
        private System.Windows.Forms.SplitContainer spcBots;
        private System.Windows.Forms.PropertyGrid pgdSelectedBot;
        private System.Windows.Forms.GroupBox grbBotAbilities;
        private System.Windows.Forms.ImageList imlBotAbilities;
        private System.Windows.Forms.ListView lsvBotAbilities;
        private System.Windows.Forms.ColumnHeader clhInstance;
        private System.Windows.Forms.ColumnHeader clhInterface;
        private System.Windows.Forms.SplitContainer spcMain;
        private System.Windows.Forms.ColumnHeader clhDefault;
    }
}
