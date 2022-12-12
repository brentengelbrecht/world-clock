using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SvgImageList
{
    public class SvgImageList
    {
        private List<SvgImage.SvgImage> images;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SvgImage.SvgImage this[int index]
        {
            get
            {
                return images[index];
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
