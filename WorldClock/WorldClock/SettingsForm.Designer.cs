
namespace WorldClock
{
    partial class SettingsForm
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
            this.TabControl = new System.Windows.Forms.TabControl();
            this.TabPageTimezones = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.ButtonDown = new System.Windows.Forms.Button();
            this.ButtonUp = new System.Windows.Forms.Button();
            this.ButtonOut = new System.Windows.Forms.Button();
            this.ButtonIn = new System.Windows.Forms.Button();
            this.TextBoxFilter = new System.Windows.Forms.TextBox();
            this.ListBoxPlaces = new System.Windows.Forms.ListBox();
            this.ListBoxSelected = new System.Windows.Forms.ListBox();
            this.TabPageOther = new System.Windows.Forms.TabPage();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.CheckBox24Hour = new System.Windows.Forms.CheckBox();
            this.ButtonOk = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.TabControl.SuspendLayout();
            this.TabPageTimezones.SuspendLayout();
            this.TabPageOther.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.TabPageTimezones);
            this.TabControl.Controls.Add(this.TabPageOther);
            this.TabControl.Location = new System.Drawing.Point(6, 6);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(643, 293);
            this.TabControl.TabIndex = 0;
            // 
            // TabPageTimezones
            // 
            this.TabPageTimezones.Controls.Add(this.label1);
            this.TabPageTimezones.Controls.Add(this.ButtonDown);
            this.TabPageTimezones.Controls.Add(this.ButtonUp);
            this.TabPageTimezones.Controls.Add(this.ButtonOut);
            this.TabPageTimezones.Controls.Add(this.ButtonIn);
            this.TabPageTimezones.Controls.Add(this.TextBoxFilter);
            this.TabPageTimezones.Controls.Add(this.ListBoxPlaces);
            this.TabPageTimezones.Controls.Add(this.ListBoxSelected);
            this.TabPageTimezones.Location = new System.Drawing.Point(4, 22);
            this.TabPageTimezones.Name = "TabPageTimezones";
            this.TabPageTimezones.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.TabPageTimezones.Size = new System.Drawing.Size(635, 267);
            this.TabPageTimezones.TabIndex = 0;
            this.TabPageTimezones.Text = "Timezones";
            this.TabPageTimezones.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Filter";
            // 
            // ButtonDown
            // 
            this.ButtonDown.Location = new System.Drawing.Point(543, 128);
            this.ButtonDown.Name = "ButtonDown";
            this.ButtonDown.Size = new System.Drawing.Size(30, 23);
            this.ButtonDown.TabIndex = 6;
            this.ButtonDown.Text = "down";
            this.ButtonDown.UseVisualStyleBackColor = true;
            this.ButtonDown.Click += new System.EventHandler(this.ButtonDown_Click);
            // 
            // ButtonUp
            // 
            this.ButtonUp.Location = new System.Drawing.Point(543, 99);
            this.ButtonUp.Name = "ButtonUp";
            this.ButtonUp.Size = new System.Drawing.Size(30, 23);
            this.ButtonUp.TabIndex = 5;
            this.ButtonUp.Text = "up";
            this.ButtonUp.UseVisualStyleBackColor = true;
            this.ButtonUp.Click += new System.EventHandler(this.ButtonUp_Click);
            // 
            // ButtonOut
            // 
            this.ButtonOut.Location = new System.Drawing.Point(288, 128);
            this.ButtonOut.Name = "ButtonOut";
            this.ButtonOut.Size = new System.Drawing.Size(30, 23);
            this.ButtonOut.TabIndex = 3;
            this.ButtonOut.Text = "out";
            this.ButtonOut.UseVisualStyleBackColor = true;
            this.ButtonOut.Click += new System.EventHandler(this.ButtonOut_Click);
            // 
            // ButtonIn
            // 
            this.ButtonIn.Location = new System.Drawing.Point(288, 99);
            this.ButtonIn.Name = "ButtonIn";
            this.ButtonIn.Size = new System.Drawing.Size(30, 23);
            this.ButtonIn.TabIndex = 2;
            this.ButtonIn.Text = "in";
            this.ButtonIn.UseVisualStyleBackColor = true;
            this.ButtonIn.Click += new System.EventHandler(this.ButtonIn_Click);
            // 
            // TextBoxFilter
            // 
            this.TextBoxFilter.Location = new System.Drawing.Point(84, 29);
            this.TextBoxFilter.Name = "TextBoxFilter";
            this.TextBoxFilter.Size = new System.Drawing.Size(182, 20);
            this.TextBoxFilter.TabIndex = 0;
            this.TextBoxFilter.TextChanged += new System.EventHandler(this.TextBoxFilter_TextChanged);
            // 
            // ListBoxPlaces
            // 
            this.ListBoxPlaces.Location = new System.Drawing.Point(82, 55);
            this.ListBoxPlaces.Name = "ListBoxPlaces";
            this.ListBoxPlaces.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.ListBoxPlaces.Size = new System.Drawing.Size(184, 160);
            this.ListBoxPlaces.Sorted = true;
            this.ListBoxPlaces.TabIndex = 1;
            // 
            // ListBoxSelected
            // 
            this.ListBoxSelected.FormattingEnabled = true;
            this.ListBoxSelected.Location = new System.Drawing.Point(340, 55);
            this.ListBoxSelected.Name = "ListBoxSelected";
            this.ListBoxSelected.Size = new System.Drawing.Size(184, 160);
            this.ListBoxSelected.TabIndex = 4;
            // 
            // TabPageOther
            // 
            this.TabPageOther.Controls.Add(this.GroupBox1);
            this.TabPageOther.Location = new System.Drawing.Point(4, 22);
            this.TabPageOther.Name = "TabPageOther";
            this.TabPageOther.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.TabPageOther.Size = new System.Drawing.Size(635, 267);
            this.TabPageOther.TabIndex = 1;
            this.TabPageOther.Text = "Other";
            this.TabPageOther.UseVisualStyleBackColor = true;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.CheckBox24Hour);
            this.GroupBox1.Location = new System.Drawing.Point(23, 20);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(294, 225);
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Display";
            // 
            // CheckBox24Hour
            // 
            this.CheckBox24Hour.AutoSize = true;
            this.CheckBox24Hour.Checked = true;
            this.CheckBox24Hour.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBox24Hour.Location = new System.Drawing.Point(25, 29);
            this.CheckBox24Hour.Name = "CheckBox24Hour";
            this.CheckBox24Hour.Size = new System.Drawing.Size(91, 17);
            this.CheckBox24Hour.TabIndex = 0;
            this.CheckBox24Hour.Text = "24-hour clock";
            this.CheckBox24Hour.UseVisualStyleBackColor = true;
            // 
            // ButtonOk
            // 
            this.ButtonOk.Location = new System.Drawing.Point(508, 322);
            this.ButtonOk.Name = "ButtonOk";
            this.ButtonOk.Size = new System.Drawing.Size(75, 23);
            this.ButtonOk.TabIndex = 2;
            this.ButtonOk.Text = "O&k";
            this.ButtonOk.UseVisualStyleBackColor = true;
            this.ButtonOk.Click += new System.EventHandler(this.ButtonOk_Click);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonCancel.Location = new System.Drawing.Point(404, 322);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.ButtonCancel.TabIndex = 1;
            this.ButtonCancel.Text = "Cancel";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.ButtonCancel;
            this.ClientSize = new System.Drawing.Size(656, 367);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonOk);
            this.Controls.Add(this.TabControl);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Location = new System.Drawing.Point(0, 10);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.ShowInTaskbar = false;
            this.Text = "Settings";
            this.TabControl.ResumeLayout(false);
            this.TabPageTimezones.ResumeLayout(false);
            this.TabPageTimezones.PerformLayout();
            this.TabPageOther.ResumeLayout(false);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage TabPageTimezones;
        private System.Windows.Forms.Button ButtonOk;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.Button ButtonDown;
        private System.Windows.Forms.Button ButtonUp;
        private System.Windows.Forms.Button ButtonOut;
        private System.Windows.Forms.Button ButtonIn;
        private System.Windows.Forms.TextBox TextBoxFilter;
        private System.Windows.Forms.ListBox ListBoxPlaces;
        private System.Windows.Forms.ListBox ListBoxSelected;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage TabPageOther;
        private System.Windows.Forms.GroupBox GroupBox1;
        private System.Windows.Forms.CheckBox CheckBox24Hour;
    }
}