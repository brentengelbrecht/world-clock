using System;
using System.Windows.Forms;

namespace ZonedTimeClockControl
{
    public partial class ZonedTimeClockControl: UserControl
    {
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
                LabelTime.Text = time.ToString("HH:mm:ss");
            }
        }

        public ZonedTimeClockControl()
        {
            InitializeComponent();
        }
    }
}
