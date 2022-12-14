using Svg;
using System;
using System.Drawing;
using System.IO;

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

        public SvgImage(Stream Data) : this()
        {
            LoadFromStream(Data);
        }

        public SvgImage(int Width, int Height, String PathName) : this()
        {
            this.Width = Width;
            this.Height = Height;
            LoadFromFile(PathName);
        }

        public SvgImage(int Width, int Height, Stream Data) : this()
        {
            this.Width = Width;
            this.Height = Height;
            LoadFromStream(Data);
        }

        private void LoadFromFile(String PathName)
        {
            documentLocation = PathName;
            svgDoc = SvgDocument.Open<SvgDocument>(PathName, null);
        }

        private void LoadFromStream(Stream Name)
        {
            documentLocation = "Stream:" + Name.ToString();
            svgDoc = SvgDocument.Open<SvgDocument>(Name, null);
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
