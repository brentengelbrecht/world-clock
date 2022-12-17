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
                String format = InternationalTime ? (ShowSeconds ? "HH:mm:ss" : "HH:mm") : (ShowSeconds ? "hh:mm:sst" : "hh:mmt");
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
            const int digitWidth = 70;
            const int digitHeight = 95;
            const int colonWidth = 18;
            const int colonHeight = 95;

            DigitsPanel.Controls.Clear();

            for (int i = 0; i < 5; i++)
            {
                int w = digitWidth;
                int h = digitHeight;

                if (i == 2)
                {
                    w = colonWidth;
                    h = colonHeight;
                }

                DigitsPanel.Controls.Add(BuildPictureBox(w, h));
            }

            if (ShowSeconds)
            {
                DigitsPanel.Controls.Add(BuildPictureBox(colonWidth, digitHeight));
                DigitsPanel.Controls.Add(BuildPictureBox(digitWidth, digitHeight));
                DigitsPanel.Controls.Add(BuildPictureBox(digitWidth, digitHeight));
            }

            if (!InternationalTime)
            {
                DigitsPanel.Controls.Add(BuildPictureBox(digitWidth, digitHeight));
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
                } 
                else if (c == 'p')
                {
                    j = 11;
                } 
                else if (c == ':')
                {
                    j = 12;
                }
                else
                {
                    j = c - 48;
                }

                if (i == 0 && c == '0' && !InternationalTime)
                {
                    j = 13;
                }

                s = svgImageList[j];
                Image d = s.Draw();
                ((PictureBox)DigitsPanel.Controls[i]).Image = d;
            }
        }
    }
}
