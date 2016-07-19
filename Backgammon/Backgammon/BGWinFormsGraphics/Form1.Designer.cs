namespace BGWinFormsGraphics
{
    partial class FormGraphic
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redPlayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.humanPlayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.randomComputerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.advancedComputerPlayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blackPlayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.humanPlayerToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.randomComputerPlayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.advancedComputerPlayerToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(724, 28);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            this.menuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.redPlayerToolStripMenuItem,
            this.blackPlayerToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem1});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.aboutToolStripMenuItem.Text = "Help";
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.newGameToolStripMenuItem.Text = "New Game";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.loadToolStripMenuItem.Text = "Load";
            // 
            // redPlayerToolStripMenuItem
            // 
            this.redPlayerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.humanPlayerToolStripMenuItem,
            this.randomComputerToolStripMenuItem,
            this.advancedComputerPlayerToolStripMenuItem});
            this.redPlayerToolStripMenuItem.Name = "redPlayerToolStripMenuItem";
            this.redPlayerToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.redPlayerToolStripMenuItem.Text = "Red Player";
            // 
            // humanPlayerToolStripMenuItem
            // 
            this.humanPlayerToolStripMenuItem.Name = "humanPlayerToolStripMenuItem";
            this.humanPlayerToolStripMenuItem.Size = new System.Drawing.Size(264, 26);
            this.humanPlayerToolStripMenuItem.Text = "Human Player";
            // 
            // randomComputerToolStripMenuItem
            // 
            this.randomComputerToolStripMenuItem.Name = "randomComputerToolStripMenuItem";
            this.randomComputerToolStripMenuItem.Size = new System.Drawing.Size(264, 26);
            this.randomComputerToolStripMenuItem.Text = "Random Computer Player";
            this.randomComputerToolStripMenuItem.Click += new System.EventHandler(this.randomComputerToolStripMenuItem_Click);
            // 
            // advancedComputerPlayerToolStripMenuItem
            // 
            this.advancedComputerPlayerToolStripMenuItem.Name = "advancedComputerPlayerToolStripMenuItem";
            this.advancedComputerPlayerToolStripMenuItem.Size = new System.Drawing.Size(264, 26);
            this.advancedComputerPlayerToolStripMenuItem.Text = "Advanced Computer Player";
            // 
            // blackPlayerToolStripMenuItem
            // 
            this.blackPlayerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.humanPlayerToolStripMenuItem1,
            this.randomComputerPlayerToolStripMenuItem,
            this.advancedComputerPlayerToolStripMenuItem1});
            this.blackPlayerToolStripMenuItem.Name = "blackPlayerToolStripMenuItem";
            this.blackPlayerToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.blackPlayerToolStripMenuItem.Text = "Black Player";
            // 
            // humanPlayerToolStripMenuItem1
            // 
            this.humanPlayerToolStripMenuItem1.Name = "humanPlayerToolStripMenuItem1";
            this.humanPlayerToolStripMenuItem1.Size = new System.Drawing.Size(264, 26);
            this.humanPlayerToolStripMenuItem1.Text = "Human Player";
            // 
            // randomComputerPlayerToolStripMenuItem
            // 
            this.randomComputerPlayerToolStripMenuItem.Name = "randomComputerPlayerToolStripMenuItem";
            this.randomComputerPlayerToolStripMenuItem.Size = new System.Drawing.Size(264, 26);
            this.randomComputerPlayerToolStripMenuItem.Text = "Random Computer Player";
            // 
            // advancedComputerPlayerToolStripMenuItem1
            // 
            this.advancedComputerPlayerToolStripMenuItem1.Name = "advancedComputerPlayerToolStripMenuItem1";
            this.advancedComputerPlayerToolStripMenuItem1.Size = new System.Drawing.Size(264, 26);
            this.advancedComputerPlayerToolStripMenuItem1.Text = "Advanced Computer Player";
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(181, 26);
            this.aboutToolStripMenuItem1.Text = "About";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BGWinFormsGraphics.Properties.Resources.BGBoard;
            this.pictureBox1.Location = new System.Drawing.Point(2, 31);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(722, 643);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // FormGraphic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 673);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FormGraphic";
            this.ShowIcon = false;
            this.Text = "Backgammon";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redPlayerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem humanPlayerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem randomComputerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem advancedComputerPlayerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blackPlayerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem humanPlayerToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem randomComputerPlayerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem advancedComputerPlayerToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

