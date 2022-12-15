using System;
using System.Drawing;
using System.Windows.Forms;

namespace ZonedTimeClockControl
{
    public partial class ZonedTimeClockControl: UserControl
    {
        public ContentsResizedEventHandler ContentsResized;

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
                String formatString = InternationalTime ? (ShowSeconds ? "HH:mm:ss" : "HH:mm") : (ShowSeconds ? "hh:mm:ss tt" : "hh:mm tt");
                LabelTime.Text = time.ToString(formatString);
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
