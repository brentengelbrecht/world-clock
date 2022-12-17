using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ZonedTimeClockControl
{
    public partial class ZonedTimeClockControl: UserControl
    {
        public ContentsResizedEventHandler ContentsResized;

        private SvgImageList.SvgImageList svgImageList;
        public SvgImageList.SvgImageList SvgImageList
        {
            get
            {
                return svgImageList;
            }
            set
            {
                svgImageList = value;
            }
        }

        private String place;
        public String Place {
            get
            {
                return place;
            }
            set
            {
                place = value;
                PlaceLabel.Text = place;
            }
        }

        private DateTime time;
        public DateTime Time
        {
            get
            {
               return time;
            }
            set
            {
                time = value;
                String format = InternationalTime ? (ShowSeconds ? "HHmmss" : "HHmm") : (ShowSeconds ? "hhmmsst" : "hhmmt");
                UpdateTime(time.ToString(format));
            }
        }

        private bool showSeconds;
        public bool ShowSeconds
        {
            get
            {
                return showSeconds;
            }
            set
            {
                showSeconds = value;
                Configure();
            }
        }

        public bool InternationalTime { get; set; }

        public ZonedTimeClockControl()
        {
            InitializeComponent();

            DigitsPanel.AutoSize = true;
            Configure();
        }

        private void Configure()
        {
            DigitsPanel.Controls.Clear();

            for (int i = 0; i < 4; i++)
            {
                DigitsPanel.Controls.Add(BuildPictureBox(70, 95));
            }

            if (ShowSeconds)
            {
                DigitsPanel.Controls.Add(BuildPictureBox(70, 95));
                DigitsPanel.Controls.Add(BuildPictureBox(70, 95));
            }

            if (!InternationalTime)
            {
                DigitsPanel.Controls.Add(BuildPictureBox(70, 95));
            }
        }

        private PictureBox BuildPictureBox(int Width, int Height)
        {
            PictureBox p = new PictureBox();
            p.Width = Width;
            p.Height = Height;
            return p;
        }

        private void UpdateTime(String time)
        {
            SvgImage.SvgImage s;

            for (int i = 0; i < time.Length; i++)
            {
                char c = time[i];
                int j = 0;

                if (c == 'a')
                {
                    j = 10;
                } else if (c == 'p')
                {
                    j = 11;
                }
                else
                {
                    j = c - 48;
                }

                s = svgImageList[j];
                Image d = s.Draw();
                ((PictureBox)DigitsPanel.Controls[i]).Image = d;
            }
        }
    }
}
