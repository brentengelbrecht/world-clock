using System;
using System.Windows.Forms;
using System.Drawing;
using DirectionalScrollerControl;
using System.Collections;

namespace WorldClock
{
    public partial class MainForm : Form
    {
        private const String registryHome = @"Software\Zooloo\WorldClock";

        private Configuration configuration;
        private FlowLayoutPanel mainLayout;
        private DirectionalScrollerControl.DirectionalScrollerControl scrollbar;
        private ZonedTimeClockControl.ZonedTimeClockControl local;
        private Timer timer;
        private double timeOffset; 

        public MainForm()
        {
            InitializeComponent();

            configuration = new Configuration(registryHome);

            scrollbar = new DirectionalScrollerControl.DirectionalScrollerControl();
            scrollbar.Minimum = -12;
            scrollbar.Maximum = 12;
            scrollbar.Width = ClientSize.Width;
            scrollbar.OnValueChanged += Scrollbar_ValueChanged;

            local = new ZonedTimeClockControl.ZonedTimeClockControl();
            local.Location = new Point(0, 0);
            local.AutoSize = true;
            local.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            local.Place = "Local";

            mainLayout = new FlowLayoutPanel();
            mainLayout.Location = new Point(0, 30);
            mainLayout.AutoSize = true;
            mainLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            mainLayout.FlowDirection = FlowDirection.TopDown;

            this.Controls.Add(mainLayout);

            SetupMainLayout();

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

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm settings = new SettingsForm(configuration);
            if (settings.ShowDialog() == DialogResult.OK)
            {
                Timer.Enabled = false;
                SetupMainLayout();
                Timer.Enabled = true;
            }
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

        private void SetupMainLayout()
        {
            mainLayout.Controls.Clear();
            mainLayout.Controls.Add(scrollbar);
            mainLayout.Controls.Add(local);

            ArrayList ids = (ArrayList)configuration.GetTimezoneIds();
            foreach (String s in ids)
            {
                ZonedTimeClockControl.ZonedTimeClockControl place = new ZonedTimeClockControl.ZonedTimeClockControl();
                place.Location = new Point(0, 0);
                place.AutoSize = true;
                place.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                place.Place = s;
                mainLayout.Controls.Add(place);
            }
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

            int i = 0;
            foreach (Control ctrl in mainLayout.Controls)
            {
                if (ctrl is ZonedTimeClockControl.ZonedTimeClockControl)
                {
                    ZonedTimeClockControl.ZonedTimeClockControl next = (ZonedTimeClockControl.ZonedTimeClockControl)ctrl;
                    if (i < 2)
                    {
                        TimeZoneInfo tzLocal = TimeZoneInfo.Local;
                        local.Time = dt;
                    }
                    else
                    {
                        TimeZoneInfo tzNext = TimeZoneInfo.FindSystemTimeZoneById(next.Place);
                        TimeSpan ts = tzNext.BaseUtcOffset;
                        DateTime nextTime = dt.AddHours(ts.Hours).AddMinutes(ts.Minutes);
                        next.Time = nextTime;
                    }
                }
                i++;
            }
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
