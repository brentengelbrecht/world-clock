
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
            this.TabPageAppearance = new System.Windows.Forms.TabPage();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.CheckBoxIncludeSeconds = new System.Windows.Forms.CheckBox();
            this.CheckBox24Hour = new System.Windows.Forms.CheckBox();
            this.ButtonOk = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.CheckBoxLaunch = new System.Windows.Forms.CheckBox();
            this.CheckBoxMinimize = new System.Windows.Forms.CheckBox();
            this.CheckBoxStatusArea = new System.Windows.Forms.CheckBox();
            this.TabControl.SuspendLayout();
            this.TabPageTimezones.SuspendLayout();
            this.TabPageAppearance.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.TabPageTimezones);
            this.TabControl.Controls.Add(this.TabPageAppearance);
            this.TabControl.Location = new System.Drawing.Point(8, 7);
            this.TabControl.Margin = new System.Windows.Forms.Padding(4);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(857, 361);
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
            this.TabPageTimezones.Location = new System.Drawing.Point(4, 25);
            this.TabPageTimezones.Margin = new System.Windows.Forms.Padding(4);
            this.TabPageTimezones.Name = "TabPageTimezones";
            this.TabPageTimezones.Padding = new System.Windows.Forms.Padding(4);
            this.TabPageTimezones.Size = new System.Drawing.Size(849, 332);
            this.TabPageTimezones.TabIndex = 0;
            this.TabPageTimezones.Text = "Timezones";
            this.TabPageTimezones.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 39);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Filter";
            // 
            // ButtonDown
            // 
            this.ButtonDown.Location = new System.Drawing.Point(724, 158);
            this.ButtonDown.Margin = new System.Windows.Forms.Padding(4);
            this.ButtonDown.Name = "ButtonDown";
            this.ButtonDown.Size = new System.Drawing.Size(40, 28);
            this.ButtonDown.TabIndex = 6;
            this.ButtonDown.Text = "down";
            this.ButtonDown.UseVisualStyleBackColor = true;
            this.ButtonDown.Click += new System.EventHandler(this.ButtonDown_Click);
            // 
            // ButtonUp
            // 
            this.ButtonUp.Location = new System.Drawing.Point(724, 122);
            this.ButtonUp.Margin = new System.Windows.Forms.Padding(4);
            this.ButtonUp.Name = "ButtonUp";
            this.ButtonUp.Size = new System.Drawing.Size(40, 28);
            this.ButtonUp.TabIndex = 5;
            this.ButtonUp.Text = "up";
            this.ButtonUp.UseVisualStyleBackColor = true;
            this.ButtonUp.Click += new System.EventHandler(this.ButtonUp_Click);
            // 
            // ButtonOut
            // 
            this.ButtonOut.Location = new System.Drawing.Point(384, 158);
            this.ButtonOut.Margin = new System.Windows.Forms.Padding(4);
            this.ButtonOut.Name = "ButtonOut";
            this.ButtonOut.Size = new System.Drawing.Size(40, 28);
            this.ButtonOut.TabIndex = 3;
            this.ButtonOut.Text = "out";
            this.ButtonOut.UseVisualStyleBackColor = true;
            this.ButtonOut.Click += new System.EventHandler(this.ButtonOut_Click);
            // 
            // ButtonIn
            // 
            this.ButtonIn.Location = new System.Drawing.Point(384, 122);
            this.ButtonIn.Margin = new System.Windows.Forms.Padding(4);
            this.ButtonIn.Name = "ButtonIn";
            this.ButtonIn.Size = new System.Drawing.Size(40, 28);
            this.ButtonIn.TabIndex = 2;
            this.ButtonIn.Text = "in";
            this.ButtonIn.UseVisualStyleBackColor = true;
            this.ButtonIn.Click += new System.EventHandler(this.ButtonIn_Click);
            // 
            // TextBoxFilter
            // 
            this.TextBoxFilter.Location = new System.Drawing.Point(112, 36);
            this.TextBoxFilter.Margin = new System.Windows.Forms.Padding(4);
            this.TextBoxFilter.Name = "TextBoxFilter";
            this.TextBoxFilter.Size = new System.Drawing.Size(241, 22);
            this.TextBoxFilter.TabIndex = 0;
            this.TextBoxFilter.TextChanged += new System.EventHandler(this.TextBoxFilter_TextChanged);
            // 
            // ListBoxPlaces
            // 
            this.ListBoxPlaces.ItemHeight = 16;
            this.ListBoxPlaces.Location = new System.Drawing.Point(109, 68);
            this.ListBoxPlaces.Margin = new System.Windows.Forms.Padding(4);
            this.ListBoxPlaces.Name = "ListBoxPlaces";
            this.ListBoxPlaces.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.ListBoxPlaces.Size = new System.Drawing.Size(244, 196);
            this.ListBoxPlaces.Sorted = true;
            this.ListBoxPlaces.TabIndex = 1;
            // 
            // ListBoxSelected
            // 
            this.ListBoxSelected.FormattingEnabled = true;
            this.ListBoxSelected.ItemHeight = 16;
            this.ListBoxSelected.Location = new System.Drawing.Point(453, 68);
            this.ListBoxSelected.Margin = new System.Windows.Forms.Padding(4);
            this.ListBoxSelected.Name = "ListBoxSelected";
            this.ListBoxSelected.Size = new System.Drawing.Size(244, 196);
            this.ListBoxSelected.TabIndex = 4;
            // 
            // TabPageAppearance
            // 
            this.TabPageAppearance.Controls.Add(this.groupBox2);
            this.TabPageAppearance.Controls.Add(this.GroupBox1);
            this.TabPageAppearance.Location = new System.Drawing.Point(4, 25);
            this.TabPageAppearance.Margin = new System.Windows.Forms.Padding(4);
            this.TabPageAppearance.Name = "TabPageAppearance";
            this.TabPageAppearance.Padding = new System.Windows.Forms.Padding(4);
            this.TabPageAppearance.Size = new System.Drawing.Size(849, 332);
            this.TabPageAppearance.TabIndex = 1;
            this.TabPageAppearance.Text = "Appearance";
            this.TabPageAppearance.UseVisualStyleBackColor = true;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.CheckBoxIncludeSeconds);
            this.GroupBox1.Controls.Add(this.CheckBox24Hour);
            this.GroupBox1.Location = new System.Drawing.Point(44, 25);
            this.GroupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.GroupBox1.Size = new System.Drawing.Size(347, 277);
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Display";
            // 
            // CheckBoxIncludeSeconds
            // 
            this.CheckBoxIncludeSeconds.AutoSize = true;
            this.CheckBoxIncludeSeconds.Checked = true;
            this.CheckBoxIncludeSeconds.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBoxIncludeSeconds.Location = new System.Drawing.Point(33, 65);
            this.CheckBoxIncludeSeconds.Margin = new System.Windows.Forms.Padding(4);
            this.CheckBoxIncludeSeconds.Name = "CheckBoxIncludeSeconds";
            this.CheckBoxIncludeSeconds.Size = new System.Drawing.Size(132, 21);
            this.CheckBoxIncludeSeconds.TabIndex = 1;
            this.CheckBoxIncludeSeconds.Text = "Include seconds";
            this.CheckBoxIncludeSeconds.UseVisualStyleBackColor = true;
            // 
            // CheckBox24Hour
            // 
            this.CheckBox24Hour.AutoSize = true;
            this.CheckBox24Hour.Checked = true;
            this.CheckBox24Hour.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBox24Hour.Location = new System.Drawing.Point(33, 36);
            this.CheckBox24Hour.Margin = new System.Windows.Forms.Padding(4);
            this.CheckBox24Hour.Name = "CheckBox24Hour";
            this.CheckBox24Hour.Size = new System.Drawing.Size(116, 21);
            this.CheckBox24Hour.TabIndex = 0;
            this.CheckBox24Hour.Text = "24-hour clock";
            this.CheckBox24Hour.UseVisualStyleBackColor = true;
            // 
            // ButtonOk
            // 
            this.ButtonOk.Location = new System.Drawing.Point(677, 396);
            this.ButtonOk.Margin = new System.Windows.Forms.Padding(4);
            this.ButtonOk.Name = "ButtonOk";
            this.ButtonOk.Size = new System.Drawing.Size(100, 28);
            this.ButtonOk.TabIndex = 2;
            this.ButtonOk.Text = "O&k";
            this.ButtonOk.UseVisualStyleBackColor = true;
            this.ButtonOk.Click += new System.EventHandler(this.ButtonOk_Click);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonCancel.Location = new System.Drawing.Point(539, 396);
            this.ButtonCancel.Margin = new System.Windows.Forms.Padding(4);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(100, 28);
            this.ButtonCancel.TabIndex = 1;
            this.ButtonCancel.Text = "Cancel";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.CheckBoxStatusArea);
            this.groupBox2.Controls.Add(this.CheckBoxMinimize);
            this.groupBox2.Controls.Add(this.CheckBoxLaunch);
            this.groupBox2.Location = new System.Drawing.Point(439, 25);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(365, 277);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Program";
            // 
            // CheckBoxLaunch
            // 
            this.CheckBoxLaunch.AutoSize = true;
            this.CheckBoxLaunch.Location = new System.Drawing.Point(33, 36);
            this.CheckBoxLaunch.Margin = new System.Windows.Forms.Padding(4);
            this.CheckBoxLaunch.Name = "CheckBoxLaunch";
            this.CheckBoxLaunch.Size = new System.Drawing.Size(185, 21);
            this.CheckBoxLaunch.TabIndex = 0;
            this.CheckBoxLaunch.Text = "Launch at Windows start";
            this.CheckBoxLaunch.UseVisualStyleBackColor = true;
            // 
            // CheckBoxMinimize
            // 
            this.CheckBoxMinimize.AutoSize = true;
            this.CheckBoxMinimize.Location = new System.Drawing.Point(33, 65);
            this.CheckBoxMinimize.Margin = new System.Windows.Forms.Padding(4);
            this.CheckBoxMinimize.Name = "CheckBoxMinimize";
            this.CheckBoxMinimize.Size = new System.Drawing.Size(143, 21);
            this.CheckBoxMinimize.TabIndex = 1;
            this.CheckBoxMinimize.Text = "Minimize on Close";
            this.CheckBoxMinimize.UseVisualStyleBackColor = true;
            // 
            // CheckBoxStatusArea
            // 
            this.CheckBoxStatusArea.AutoSize = true;
            this.CheckBoxStatusArea.Location = new System.Drawing.Point(33, 94);
            this.CheckBoxStatusArea.Margin = new System.Windows.Forms.Padding(4);
            this.CheckBoxStatusArea.Name = "CheckBoxStatusArea";
            this.CheckBoxStatusArea.Size = new System.Drawing.Size(223, 26);
            this.CheckBoxStatusArea.TabIndex = 2;
            this.CheckBoxStatusArea.Text = "Minimize to Status Area";
            this.CheckBoxStatusArea.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.ButtonCancel;
            this.ClientSize = new System.Drawing.Size(875, 452);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonOk);
            this.Controls.Add(this.TabControl);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Location = new System.Drawing.Point(0, 10);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.ShowInTaskbar = false;
            this.Text = "Settings";
            this.TabControl.ResumeLayout(false);
            this.TabPageTimezones.ResumeLayout(false);
            this.TabPageTimezones.PerformLayout();
            this.TabPageAppearance.ResumeLayout(false);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
        private System.Windows.Forms.TabPage TabPageAppearance;
        private System.Windows.Forms.GroupBox GroupBox1;
        private System.Windows.Forms.CheckBox CheckBox24Hour;
        private System.Windows.Forms.CheckBox CheckBoxIncludeSeconds;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox CheckBoxLaunch;
        private System.Windows.Forms.CheckBox CheckBoxStatusArea;
        private System.Windows.Forms.CheckBox CheckBoxMinimize;
    }
}