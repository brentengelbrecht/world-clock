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
            this.Layout = new System.Windows.Forms.FlowLayoutPanel();
            this.PlaceLabel = new System.Windows.Forms.Label();
            this.LabelTime = new System.Windows.Forms.Label();
            this.Layout.SuspendLayout();
            this.SuspendLayout();
            // 
            // Layout
            // 
            this.Layout.AutoSize = true;
            this.Layout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Layout.Controls.Add(this.PlaceLabel);
            this.Layout.Controls.Add(this.LabelTime);
            this.Layout.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.Layout.Location = new System.Drawing.Point(0, 0);
            this.Layout.Margin = new System.Windows.Forms.Padding(4);
            this.Layout.Name = "Layout";
            this.Layout.Size = new System.Drawing.Size(303, 93);
            this.Layout.TabIndex = 0;
            // 
            // PlaceLabel
            // 
            this.PlaceLabel.AutoSize = true;
            this.PlaceLabel.Location = new System.Drawing.Point(4, 0);
            this.PlaceLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PlaceLabel.Name = "PlaceLabel";
            this.PlaceLabel.Size = new System.Drawing.Size(46, 17);
            this.PlaceLabel.TabIndex = 0;
            this.PlaceLabel.Text = "label1";
            // 
            // LabelTime
            // 
            this.LabelTime.AutoSize = true;
            this.LabelTime.Font = new System.Drawing.Font("DS-Digital", 46F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelTime.Location = new System.Drawing.Point(4, 17);
            this.LabelTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelTime.Name = "LabelTime";
            this.LabelTime.Size = new System.Drawing.Size(295, 76);
            this.LabelTime.TabIndex = 1;
            this.LabelTime.Text = "00:00:00";
            this.LabelTime.SizeChanged += new System.EventHandler(this.LabelTime_SizeChanged);
            // 
            // ZonedTimeClockControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.Layout);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ZonedTimeClockControl";
            this.Size = new System.Drawing.Size(307, 97);
            this.Layout.ResumeLayout(false);
            this.Layout.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel Layout;
        private System.Windows.Forms.Label PlaceLabel;
        private System.Windows.Forms.Label LabelTime;
    }
}
