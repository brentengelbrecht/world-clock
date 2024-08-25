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
        private SvgImageList.SvgImageList leand;

        private FlowLayoutPanel mainLayout;
        private DirectionalScrollerControl.DirectionalScrollerControl scrollbar;
        private FlowLayoutPanel clocksLayout;

        private ZonedTimeClockControl.ZonedTimeClockControl local;
        private Timer timer;
        private double timeOffset;

        private bool doExit = false;
        private bool oldSwagger;


        public MainForm()
        {
            InitializeComponent();

            configuration = new Configuration(registryHome);
            oldSwagger = configuration.IncludeSwagger;

            mainLayout = new FlowLayoutPanel();
            mainLayout.Location = new Point(0, 0);
            mainLayout.AutoSize = true;
            mainLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            mainLayout.FlowDirection = FlowDirection.TopDown;
            Controls.Add(mainLayout);

            scrollbar = new DirectionalScrollerControl.DirectionalScrollerControl();
            scrollbar.Height = 40;
            scrollbar.Width = mainLayout.ClientRectangle.Width;
            scrollbar.Minimum = -12;
            scrollbar.Maximum = 12;
            scrollbar.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            scrollbar.OnValueChanged += Scrollbar_ValueChanged;
            mainLayout.Controls.Add(scrollbar);

            clocksLayout = new FlowLayoutPanel();
            clocksLayout.Location = new Point(0, 30);
            clocksLayout.AutoSize = true;
            clocksLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            clocksLayout.FlowDirection = FlowDirection.TopDown;
            clocksLayout.SizeChanged += ClocksLayout_SizeChanged;
            mainLayout.Controls.Add(clocksLayout);

            digits = new SvgImageList.SvgImageList();
            digits.DigitWidth = 80;
            digits.DigitHeight = 100;
            digits.Add(new SvgImage.SvgImage(GetResource("digit_0.svg")));
            digits.Add(new SvgImage.SvgImage(GetResource("digit_1.svg")));
            digits.Add(new SvgImage.SvgImage(GetResource("digit_2.svg")));
            digits.Add(new SvgImage.SvgImage(GetResource("digit_3.svg")));
            digits.Add(new SvgImage.SvgImage(GetResource("digit_4.svg")));
            digits.Add(new SvgImage.SvgImage(GetResource("digit_5.svg")));
            digits.Add(new SvgImage.SvgImage(GetResource("digit_6.svg")));
            digits.Add(new SvgImage.SvgImage(GetResource("digit_7.svg")));
            digits.Add(new SvgImage.SvgImage(GetResource("digit_8.svg")));
            digits.Add(new SvgImage.SvgImage(GetResource("digit_9.svg")));
            digits.Add(new SvgImage.SvgImage(GetResource("digit_a.svg")));
            digits.Add(new SvgImage.SvgImage(GetResource("digit_p.svg")));
            digits.Add(new SvgImage.SvgImage(GetResource("digit_c.svg")));
            digits.Add(new SvgImage.SvgImage(GetResource("digit_spc.svg")));

            leand = new SvgImageList.SvgImageList();
            leand.DigitWidth = 80;
            leand.DigitHeight = 100;
            leand.Add(new SvgImage.SvgImage(GetResource("lean_0.svg")));
            leand.Add(new SvgImage.SvgImage(GetResource("lean_1.svg")));
            leand.Add(new SvgImage.SvgImage(GetResource("lean_2.svg")));
            leand.Add(new SvgImage.SvgImage(GetResource("lean_3.svg")));
            leand.Add(new SvgImage.SvgImage(GetResource("lean_4.svg")));
            leand.Add(new SvgImage.SvgImage(GetResource("lean_5.svg")));
            leand.Add(new SvgImage.SvgImage(GetResource("lean_6.svg")));
            leand.Add(new SvgImage.SvgImage(GetResource("lean_7.svg")));
            leand.Add(new SvgImage.SvgImage(GetResource("lean_8.svg")));
            leand.Add(new SvgImage.SvgImage(GetResource("lean_9.svg")));
            leand.Add(new SvgImage.SvgImage(GetResource("lean_a.svg")));
            leand.Add(new SvgImage.SvgImage(GetResource("lean_p.svg")));
            leand.Add(new SvgImage.SvgImage(GetResource("lean_c.svg")));
            leand.Add(new SvgImage.SvgImage(GetResource("lean_spc.svg")));

            local = new ZonedTimeClockControl.ZonedTimeClockControl();
            local.SvgImageList = configuration.IncludeSwagger ? leand : digits;
            local.Location = new Point(0, 0);
            local.AutoSize = true;
            local.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            local.Place = localName;
            local.InternationalTime = configuration.InternationalTime;
            local.ShowSeconds = configuration.IncludeSeconds;

            SetupClocksLayout();

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

        private void ClocksLayout_SizeChanged(object sender, EventArgs e)
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
                if (oldSwagger != configuration.IncludeSwagger)
                {
                    local.SvgImageList = configuration.IncludeSwagger ? leand : digits;
                    oldSwagger = configuration.IncludeSwagger;
                }
                SetupClocksLayout();
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

        private void SetupClocksLayout()
        {
            clocksLayout.SuspendLayout();
            scrollbar.Width = 20;
            local.InternationalTime = configuration.InternationalTime;
            local.ShowSeconds = configuration.IncludeSeconds;
            clocksLayout.Controls.Clear();
            clocksLayout.Controls.Add(scrollbar);
            clocksLayout.Controls.Add(local);

            ArrayList ids = (ArrayList)configuration.GetTimezoneIds();
            foreach (String s in ids)
            {
                ZonedTimeClockControl.ZonedTimeClockControl place = new ZonedTimeClockControl.ZonedTimeClockControl();
                place.SvgImageList = configuration.IncludeSwagger ? leand : digits;
                place.Location = new Point(0, 0);
                place.AutoSize = true;
                place.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                place.Place = s;
                place.InternationalTime = configuration.InternationalTime;
                place.ShowSeconds = configuration.IncludeSeconds;
                clocksLayout.Controls.Add(place);
            }
            clocksLayout.Invalidate();
            clocksLayout.ResumeLayout();
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

            for (int i = 0; i < clocksLayout.Controls.Count; i++)
            {
                Control ctrl = clocksLayout.Controls[i];
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
            if (clocksLayout != null)
            {
                clocksLayout.Size = new Size(((Form)sender).ClientSize.Width, ((Form)sender).ClientSize.Height);
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
