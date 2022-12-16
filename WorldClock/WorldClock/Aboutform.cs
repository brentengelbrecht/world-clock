using System;
using System.Reflection;
using System.Windows.Forms;

namespace WorldClock
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();

            TextBoxInfo.SelectionStart = 0;
            TextBoxInfo.SelectionLength = 0;

            LabelVersion.Text = "Version" + Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(((LinkLabel)sender).Text);
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {

        }
    }
}
