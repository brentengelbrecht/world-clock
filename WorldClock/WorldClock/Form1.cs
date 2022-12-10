using System;
using System.Windows.Forms;
using System.Drawing;
using DirectionalScrollerControl;

namespace WorldClock
{
    public partial class MainForm : Form
    {
        private FlowLayoutPanel mainLayout;
        private DirectionalScrollerControl.DirectionalScrollerControl scrollbar;
        private ZonedTimeClockControl.ZonedTimeClockControl local, tokyo;
        private Timer timer;
        private double timeOffset; 

        public MainForm()
        {
            InitializeComponent();

            scrollbar = new DirectionalScrollerControl.DirectionalScrollerControl();
            //scrollbar.Minimum = 0;
            //scrollbar.Maximum = 100;
            //scrollbar.Value = 50;
            scrollbar.Width = ClientSize.Width;
            scrollbar.OnValueChanged += Scrollbar_ValueChanged;

            local = new ZonedTimeClockControl.ZonedTimeClockControl();
            local.Location = new Point(0, 0);
            local.AutoSize = true;
            local.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            tokyo = new ZonedTimeClockControl.ZonedTimeClockControl();
            tokyo.Location = new Point(0, 0);
            tokyo.AutoSize = true;
            tokyo.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            mainLayout = new FlowLayoutPanel();
            mainLayout.Location = new Point(0, 30);
            mainLayout.AutoSize = true;
            mainLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            mainLayout.FlowDirection = FlowDirection.TopDown;

            mainLayout.Controls.Add(scrollbar);
            mainLayout.Controls.Add(local);
            mainLayout.Controls.Add(tokyo);

            Controls.Add(mainLayout);

            UpdateTimes();

            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Enabled = true;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Scrollbar_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            timeOffset = e.Value;
            UpdateTimes();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            UpdateTimes();
        }

        private void UpdateTimes()
        {
            DateTime dt = DateTime.Now;
            if (timeOffset != 0)
            {
                int hours = (int)Math.Truncate(timeOffset);
                int minutes = (int)((timeOffset - hours) * 60);
                dt = dt.AddHours(hours).AddMinutes(minutes);
            }

            TimeZoneInfo tzLocal = TimeZoneInfo.Local;
            local.Place = "Local";
            local.Time = dt;

            TimeZoneInfo tzTokyo = TimeZoneInfo.FindSystemTimeZoneById("Tokyo Standard Time");
            TimeSpan ts = tzTokyo.BaseUtcOffset;
            DateTime tokyoTime = dt.AddHours(ts.Hours).AddMinutes(ts.Minutes);
            tokyo.Place = "Tokyo, Japan";
            tokyo.Time = tokyoTime;
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (scrollbar != null)
            {
                scrollbar.Width = ((Form)sender).ClientSize.Width - 9;
            }
        }
    }
}
