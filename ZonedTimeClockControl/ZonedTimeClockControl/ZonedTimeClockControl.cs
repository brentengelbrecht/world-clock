using System;
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
                //LabelTime.Text = time.ToString("HH:mm:ss");
                String t = time.ToString("HH:mm:ss");
                SvgImage.SvgImage s = svgImageList[Int16.Parse(t.Substring(0, 1))];
                H1.Image = s.Draw(H1.Width, H1.Height);
                s = svgImageList[Int16.Parse(t.Substring(1, 1))];
                H2.Image = s.Draw(H1.Width, H1.Height);
                s = svgImageList[Int16.Parse(t.Substring(3, 1))];
                M1.Image = s.Draw(H1.Width, H1.Height);
                s = svgImageList[Int16.Parse(t.Substring(4, 1))];
                M2.Image = s.Draw(H1.Width, H1.Height);
                s = svgImageList[Int16.Parse(t.Substring(6, 1))];
                S1.Image = s.Draw(H1.Width, H1.Height);
                s = svgImageList[Int16.Parse(t.Substring(7, 1))];
                S2.Image = s.Draw(H1.Width, H1.Height);
            }
        }

        public bool InternationalTime { get; set; }
        public bool ShowSeconds { get; set; }

        public ZonedTimeClockControl()
        {
            InitializeComponent();
        }

        private void LabelTime_SizeChanged(object sender, EventArgs e)
        {
            ContentsResized?.Invoke(this, new ContentsResizedEventArgs(new Rectangle(Location.X, Location.Y, Size.Width, Size.Height)));
        }
    }
}
