namespace DG.BotWorld.WorldMatrix.WinApp.UserControls
{
    partial class EnvironmentsUserControl
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
            this.imlEnvironments = new System.Windows.Forms.ImageList(this.components);
            this.gpbAvailableEnvironments = new System.Windows.Forms.GroupBox();
            this.spcEnvironments = new System.Windows.Forms.SplitContainer();
            this.lsvEnvironments = new System.Windows.Forms.ListView();
            this.pgdSelectedEnvironment = new System.Windows.Forms.PropertyGrid();
            this.gpbAvailableEnvironments.SuspendLayout();
            this.spcEnvironments.Panel1.SuspendLayout();
            this.spcEnvironments.Panel2.SuspendLayout();
            this.spcEnvironments.SuspendLayout();
            this.SuspendLayout();
            // 
            // imlEnvironments
            // 
            this.imlEnvironments.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imlEnvironments.ImageSize = new System.Drawing.Size(128, 128);
            this.imlEnvironments.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // gpbAvailableEnvironments
            // 
            this.gpbAvailableEnvironments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gpbAvailableEnvironments.Controls.Add(this.spcEnvironments);
            this.gpbAvailableEnvironments.ForeColor = System.Drawing.Color.ForestGreen;
            this.gpbAvailableEnvironments.Location = new System.Drawing.Point(3, 3);
            this.gpbAvailableEnvironments.Name = "gpbAvailableEnvironments";
            this.gpbAvailableEnvironments.Size = new System.Drawing.Size(810, 498);
            this.gpbAvailableEnvironments.TabIndex = 2;
            this.gpbAvailableEnvironments.TabStop = false;
            this.gpbAvailableEnvironments.Text = "Available environments";
            // 
            // spcEnvironments
            // 
            this.spcEnvironments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.spcEnvironments.Location = new System.Drawing.Point(6, 19);
            this.spcEnvironments.Name = "spcEnvironments";
            // 
            // spcEnvironments.Panel1
            // 
            this.spcEnvironments.Panel1.Controls.Add(this.lsvEnvironments);
            // 
            // spcEnvironments.Panel2
            // 
            this.spcEnvironments.Panel2.Controls.Add(this.pgdSelectedEnvironment);
            this.spcEnvironments.Size = new System.Drawing.Size(798, 473);
            this.spcEnvironments.SplitterDistance = 491;
            this.spcEnvironments.TabIndex = 4;
            // 
            // lsvEnvironments
            // 
            this.lsvEnvironments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvEnvironments.LargeImageList = this.imlEnvironments;
            this.lsvEnvironments.Location = new System.Drawing.Point(0, 0);
            this.lsvEnvironments.MultiSelect = false;
            this.lsvEnvironments.Name = "lsvEnvironments";
            this.lsvEnvironments.Size = new System.Drawing.Size(491, 473);
            this.lsvEnvironments.TabIndex = 2;
            this.lsvEnvironments.UseCompatibleStateImageBehavior = false;
            this.lsvEnvironments.SelectedIndexChanged += new System.EventHandler(this.lsvEnvironments_SelectedIndexChanged);
            // 
            // pgdSelectedEnvironment
            // 
            this.pgdSelectedEnvironment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgdSelectedEnvironment.Location = new System.Drawing.Point(0, 0);
            this.pgdSelectedEnvironment.Name = "pgdSelectedEnvironment";
            this.pgdSelectedEnvironment.Size = new System.Drawing.Size(303, 473);
            this.pgdSelectedEnvironment.TabIndex = 3;
            // 
            // EnvironmentsUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gpbAvailableEnvironments);
            this.Name = "EnvironmentsUserControl";
            this.Size = new System.Drawing.Size(816, 504);
            this.Load += new System.EventHandler(this.EnvironmentsUserControl_Load);
            this.gpbAvailableEnvironments.ResumeLayout(false);
            this.spcEnvironments.Panel1.ResumeLayout(false);
            this.spcEnvironments.Panel2.ResumeLayout(false);
            this.spcEnvironments.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imlEnvironments;
        private System.Windows.Forms.GroupBox gpbAvailableEnvironments;
        private System.Windows.Forms.ListView lsvEnvironments;
        private System.Windows.Forms.PropertyGrid pgdSelectedEnvironment;
        private System.Windows.Forms.SplitContainer spcEnvironments;
    }
}
