using System;
using System.Drawing;
using System.Windows.Forms;

namespace ZonedTimeClockControl
{
    public partial class ZonedTimeClockControl: UserControl
    {
        const int DEFAULT_DIGIT_WIDTH = 70;
        const int DEFAULT_DIGIT_HEIGHT = 95;
        const int DEFAULT_COLON_WIDTH = 18;
        const int DEFAULT_COLON_HEIGHT = DEFAULT_DIGIT_HEIGHT;

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
                UpdateTime(time);
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

            Configure();
        }

        private void Configure()
        {
            Size digitSize = new Size(DEFAULT_DIGIT_WIDTH, DEFAULT_DIGIT_HEIGHT);
            Size colonSize = new Size(DEFAULT_COLON_WIDTH, DEFAULT_COLON_HEIGHT);
            const int FIXED_SIZE = 8;
            int size = 0;

            DigitsPanel.Controls.Clear();

            for (int i = 0; i < 5; i++)
            {
                if (i == 2)
                {
                    DigitsPanel.Controls.Add(BuildPictureBox(colonSize));
                    size += colonSize.Width + FIXED_SIZE;
                }
                else
                {
                    DigitsPanel.Controls.Add(BuildPictureBox(digitSize));
                    size += digitSize.Width + FIXED_SIZE;
                }
            }

            if (showSeconds)
            {
                DigitsPanel.Controls.Add(BuildPictureBox(colonSize));
                size += colonSize.Width + FIXED_SIZE;
                DigitsPanel.Controls.Add(BuildPictureBox(digitSize));
                size += digitSize.Width + FIXED_SIZE;
                DigitsPanel.Controls.Add(BuildPictureBox(digitSize));
                size += digitSize.Width + FIXED_SIZE;
            }

            if (!InternationalTime)
            {
                DigitsPanel.Controls.Add(BuildPictureBox(digitSize));
                size += digitSize.Width + FIXED_SIZE;
            }

            if (size + 20 > Width)
            {
                Width = size + 20;
            }
        }

        private PictureBox BuildPictureBox(Size dimensions)
        {
            PictureBox p = new PictureBox();
            p.Width = dimensions.Width;
            p.Height = dimensions.Height;
            return p;
        }

        private void UpdateTime(DateTime inputTime)
        {
            SvgImage.SvgImage s;

            String format = InternationalTime ? (ShowSeconds ? "HH:mm:ss" : "HH:mm") : (ShowSeconds ? "hh:mm:sst" : "hh:mmt");
            String time = inputTime.ToString(format);

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
                (DigitsPanel.Controls[i] as PictureBox).Image = d;
            }
        }
    }
}
