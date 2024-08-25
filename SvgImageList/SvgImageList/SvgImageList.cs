using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SvgImageList
{
    public class SvgImageList
    {
        private List<SvgImage.SvgImage> images;

        private int digitWidth;
        public int DigitWidth
        {
            get
            {
                return digitWidth;
            }
            set
            {
                digitWidth = value;
            }
        }

        private int digitHeight;
        public int DigitHeight
        {
            get
            {
                return digitHeight;
            }
            set
            {
                digitHeight = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SvgImage.SvgImage this[int index]
        {
            get
            {
                SvgImage.SvgImage s = images[index];
                if (digitWidth > 0)
                {
                    s.Width = digitWidth;
                }
                if (digitHeight > 0)
                {
                    s.Height = digitHeight;
                }
                return s;
            }
        }

        public SvgImageList()
        {
            images = new List<SvgImage.SvgImage>();
        }

        public void Clear()
        {
            images.Clear();
        }

        public int Add(SvgImage.SvgImage image)
        {
            images.Add(image);
            return images.Count - 1;
        }

        public void RemoveAt(int index)
        {
            images.RemoveAt(index);
        }
    }
}
