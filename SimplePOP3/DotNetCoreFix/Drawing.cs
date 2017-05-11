using System;
using System.Collections.Generic;
using System.Text;

namespace System.Drawing
{

    namespace Imaging
    {

        public sealed class ImageFormat
        {
            public ImageFormat(Guid guid)
            { }

            public static ImageFormat MemoryBmp { get; }
            public static ImageFormat Bmp { get; }
            public static ImageFormat Emf { get; }
            public static ImageFormat Wmf { get; }
            public static ImageFormat Gif { get; }
            public static ImageFormat Jpeg { get; }
            public static ImageFormat Png { get; }
            public static ImageFormat Tiff { get; }
            public static ImageFormat Exif { get; }
            public static ImageFormat Icon { get; }
            public Guid Guid { get; }

            public override bool Equals(object o)
            {
                return false;
            }
            public override int GetHashCode()
            {
                return 0;
            }
            public override string ToString()
            {
                return "";
            }
        }

    }

    public class Image
    {

        public static Image FromStream(System.IO.Stream strm)
        {
            return FromStream(strm, false);
        }

        public static Image FromStream(System.IO.Stream strm, bool useEmbeddedColorManagement)
        {
            return FromStream(strm, useEmbeddedColorManagement, false);
        }

        public static Image FromStream(System.IO.Stream strm, bool useEmbeddedColorManagement, bool validateImageData)
        {
            return null;
        }

        public void Save(string filename)
        { }

        public void Save(string filename, System.Drawing.Imaging.ImageFormat format)
        {

        }

        public void Save(System.IO.Stream stream, System.Drawing.Imaging.ImageFormat format)
        {

        }


    }
}
