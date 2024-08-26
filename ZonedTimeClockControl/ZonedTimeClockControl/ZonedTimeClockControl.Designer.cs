namespace ZonedTimeClockControl
{
    partial class ZonedTimeClockControl
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
            this.MainLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.PlaceLabel = new System.Windows.Forms.Label();
            this.DigitsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.MainLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainLayout
            // 
            this.MainLayout.AutoSize = true;
            this.MainLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.MainLayout.Controls.Add(this.PlaceLabel);
            this.MainLayout.Controls.Add(this.DigitsPanel);
            this.MainLayout.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.MainLayout.Location = new System.Drawing.Point(0, 0);
            this.MainLayout.Name = "MainLayout";
            this.MainLayout.Size = new System.Drawing.Size(41, 17);
            this.MainLayout.TabIndex = 0;
            // 
            // PlaceLabel
            // 
            this.PlaceLabel.AutoSize = true;
            this.PlaceLabel.Location = new System.Drawing.Point(3, 0);
            this.PlaceLabel.Name = "PlaceLabel";
            this.PlaceLabel.Size = new System.Drawing.Size(35, 13);
            this.PlaceLabel.TabIndex = 0;
            this.PlaceLabel.Text = "label1";
            // 
            // DigitsPanel
            // 
            this.DigitsPanel.AutoSize = true;
            this.DigitsPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.DigitsPanel.Location = new System.Drawing.Point(2, 15);
            this.DigitsPanel.Margin = new System.Windows.Forms.Padding(2);
            this.DigitsPanel.Name = "DigitsPanel";
            this.DigitsPanel.Size = new System.Drawing.Size(0, 0);
            this.DigitsPanel.TabIndex = 1;
            // 
            // ZonedTimeClockControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.MainLayout);
            this.Name = "ZonedTimeClockControl";
            this.Size = new System.Drawing.Size(44, 20);
            this.MainLayout.ResumeLayout(false);
            this.MainLayout.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel MainLayout;
        private System.Windows.Forms.Label PlaceLabel;
        private System.Windows.Forms.FlowLayoutPanel DigitsPanel;
    }
}
