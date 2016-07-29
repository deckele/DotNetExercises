namespace PrimesCalculator
{
    partial class PrimesCalculator
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
            this.FromTexBox = new System.Windows.Forms.TextBox();
            this.ResultListBox = new System.Windows.Forms.ListBox();
            this.ToLabel = new System.Windows.Forms.Label();
            this.FromLabel = new System.Windows.Forms.Label();
            this.ToTextBox = new System.Windows.Forms.TextBox();
            this.CalculateButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FromTexBox
            // 
            this.FromTexBox.Location = new System.Drawing.Point(60, 10);
            this.FromTexBox.Name = "FromTexBox";
            this.FromTexBox.Size = new System.Drawing.Size(124, 22);
            this.FromTexBox.TabIndex = 1;
            // 
            // ResultListBox
            // 
            this.ResultListBox.FormattingEnabled = true;
            this.ResultListBox.ItemHeight = 16;
            this.ResultListBox.Location = new System.Drawing.Point(12, 95);
            this.ResultListBox.Name = "ResultListBox";
            this.ResultListBox.Size = new System.Drawing.Size(345, 340);
            this.ResultListBox.TabIndex = 3;
            this.ResultListBox.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // ToLabel
            // 
            this.ToLabel.AutoSize = true;
            this.ToLabel.Location = new System.Drawing.Point(10, 53);
            this.ToLabel.Name = "ToLabel";
            this.ToLabel.Size = new System.Drawing.Size(29, 17);
            this.ToLabel.TabIndex = 6;
            this.ToLabel.Text = "To:";
            // 
            // FromLabel
            // 
            this.FromLabel.AutoSize = true;
            this.FromLabel.Location = new System.Drawing.Point(10, 13);
            this.FromLabel.Name = "FromLabel";
            this.FromLabel.Size = new System.Drawing.Size(44, 17);
            this.FromLabel.TabIndex = 7;
            this.FromLabel.Text = "From:";
            // 
            // ToTextBox
            // 
            this.ToTextBox.Location = new System.Drawing.Point(60, 47);
            this.ToTextBox.Name = "ToTextBox";
            this.ToTextBox.Size = new System.Drawing.Size(124, 22);
            this.ToTextBox.TabIndex = 8;
            // 
            // CalculateButton
            // 
            this.CalculateButton.Location = new System.Drawing.Point(238, 6);
            this.CalculateButton.Name = "CalculateButton";
            this.CalculateButton.Size = new System.Drawing.Size(81, 31);
            this.CalculateButton.TabIndex = 9;
            this.CalculateButton.Text = "Calculate";
            this.CalculateButton.UseVisualStyleBackColor = true;
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(238, 42);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(81, 30);
            this.CancelButton.TabIndex = 10;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            // 
            // PrimesCalculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 444);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.CalculateButton);
            this.Controls.Add(this.ToTextBox);
            this.Controls.Add(this.FromLabel);
            this.Controls.Add(this.ToLabel);
            this.Controls.Add(this.ResultListBox);
            this.Controls.Add(this.FromTexBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PrimesCalculator";
            this.ShowIcon = false;
            this.Text = "PrimesCalculator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox FromTexBox;
        private System.Windows.Forms.ListBox ResultListBox;
        private System.Windows.Forms.Label ToLabel;
        private System.Windows.Forms.Label FromLabel;
        private System.Windows.Forms.TextBox ToTextBox;
        private System.Windows.Forms.Button CalculateButton;
        private new System.Windows.Forms.Button CancelButton;
    }
}

