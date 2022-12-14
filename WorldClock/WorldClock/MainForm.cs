using System;
using System.Windows.Forms;
using System.Drawing;
using DirectionalScrollerControl;
using System.Collections;
using System.IO;
using System.Reflection;

namespace WorldClock
{
    public partial class MainForm : Form
    {
        private const String registryHome = @"Software\Zooloo\WorldClock";
        private const String localName = "Local";

        private Configuration configuration;
        private SvgImageList.SvgImageList digits;
        private FlowLayoutPanel mainLayout;
        private DirectionalScrollerControl.DirectionalScrollerControl scrollbar;
        private ZonedTimeClockControl.ZonedTimeClockControl local;
        private Timer timer;
        private double timeOffset;

        private bool doExit = false;


        public MainForm()
        {
            InitializeComponent();

            configuration = new Configuration(registryHome);

            digits = new SvgImageList.SvgImageList();
            digits.Add(new SvgImage.SvgImage(80, 100, GetResource("digit_0.svg")));
            digits.Add(new SvgImage.SvgImage(80, 100, GetResource("digit_1.svg")));
            digits.Add(new SvgImage.SvgImage(80, 100, GetResource("digit_2.svg")));
            digits.Add(new SvgImage.SvgImage(80, 100, GetResource("digit_3.svg")));
            digits.Add(new SvgImage.SvgImage(80, 100, GetResource("digit_4.svg")));
            digits.Add(new SvgImage.SvgImage(80, 100, GetResource("digit_5.svg")));
            digits.Add(new SvgImage.SvgImage(80, 100, GetResource("digit_6.svg")));
            digits.Add(new SvgImage.SvgImage(80, 100, GetResource("digit_7.svg")));
            digits.Add(new SvgImage.SvgImage(80, 100, GetResource("digit_8.svg")));
            digits.Add(new SvgImage.SvgImage(80, 100, GetResource("digit_9.svg")));

            scrollbar = new DirectionalScrollerControl.DirectionalScrollerControl();
            scrollbar.Minimum = -12;
            scrollbar.Maximum = 12;
            scrollbar.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            scrollbar.OnValueChanged += Scrollbar_ValueChanged;

            local = new ZonedTimeClockControl.ZonedTimeClockControl();
            local.SvgImageList = digits;
            local.Location = new Point(0, 0);
            local.AutoSize = true;
            local.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            local.Place = localName;
            local.InternationalTime = configuration.InternationalTime;
            local.ShowSeconds = configuration.IncludeSeconds;

            this.Controls.Add(mainLayout);

            SetupMainLayout();

            UpdateTimes();

            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Enabled = true;
        }

        private Stream GetResource(String Name)
        {
            Assembly myAssembly = Assembly.GetExecutingAssembly();
            return myAssembly.GetManifestResourceStream("WorldClock." + Name);
        }

        private void MainLayout_SizeChanged(object sender, EventArgs e)
        {
            scrollbar.Invalidate();
            scrollbar.Update();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            doExit = true;
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
            mainLayout.SuspendLayout();
            local.InternationalTime = configuration.InternationalTime;
            local.ShowSeconds = configuration.IncludeSeconds;
            mainLayout.Controls.Clear();
            mainLayout.Controls.Add(scrollbar);
            mainLayout.Controls.Add(local);

            ArrayList ids = (ArrayList)configuration.GetTimezoneIds();
            foreach (String s in ids)
            {
                ZonedTimeClockControl.ZonedTimeClockControl place = new ZonedTimeClockControl.ZonedTimeClockControl();
                place.SvgImageList = digits;
                place.Location = new Point(0, 0);
                place.AutoSize = true;
                place.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                place.Place = s;
                place.InternationalTime = configuration.InternationalTime;
                place.ShowSeconds = configuration.IncludeSeconds;
                mainLayout.Controls.Add(place);
            }
            mainLayout.Invalidate();
            mainLayout.ResumeLayout();
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

            for (int i = 0; i < mainLayout.Controls.Count; i++)
            {
                Control ctrl = mainLayout.Controls[i];
                if (ctrl is ZonedTimeClockControl.ZonedTimeClockControl)
                {
                    ZonedTimeClockControl.ZonedTimeClockControl next = (ZonedTimeClockControl.ZonedTimeClockControl)ctrl;
                    if (next.Place == localName)
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
            }
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (mainLayout != null)
            {
                mainLayout.Size = new Size(((Form)sender).ClientSize.Width, ((Form)sender).ClientSize.Height);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!doExit)
            {
                if (configuration.MinimizeToStatusArea && e.CloseReason == CloseReason.UserClosing)
                {
                    timer.Enabled = false;
                    NotifyIcon.Visible = true;
                    this.Hide();
                    e.Cancel = true;
                }

                if (configuration.MinimizeOnClose && e.CloseReason == CloseReason.UserClosing)
                {
                    WindowState = FormWindowState.Minimized;
                    e.Cancel = true;
                }
            }
        }

        private void NotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Timer.Enabled = true;
            WindowState = FormWindowState.Normal;
            this.Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm about = new AboutForm();
            about.Show();
        }
    }
}
