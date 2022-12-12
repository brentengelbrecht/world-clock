using Svg;
using System;
using System.Drawing;

namespace SvgImage
{
    public class SvgImage
    {
        private SvgDocument svgDoc;

        private int width = 30;
        public int Width
        {
            get
            {
                return width;
            }
            set
            {
                width = value;
            }
        }

        private int height = 30;
        public int Height
        {
            get
            {
                return height;
            }
            set
            {
                height = value;
            }
        }

        private String documentLocation;
        public String DocumentLocation
        {
            get
            {
                return documentLocation;
            }
            set
            {
                documentLocation = value;
                LoadFromFile(documentLocation);
            }
        }

        public SvgImage()
        {
        }

        public SvgImage(String PathName) : this()
        {
            LoadFromFile(PathName);
        }

        public SvgImage(int Width, int Height, String PathName) : this()
        {
            this.Width = Width;
            this.Height = Height;
            LoadFromFile(PathName);
        }

        private void LoadFromFile(String PathName)
        {
            documentLocation = PathName;
            svgDoc = SvgDocument.Open<SvgDocument>(PathName, null);
        }

        public Bitmap Draw()
        {
            return svgDoc.Draw(width, height);
        }

        public Bitmap Draw(int Width, int Height)
        {
            this.Width = Width;
            this.Height = Height;
            return svgDoc.Draw(Width, Height);
        }
    }
}
