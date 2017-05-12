
// Copyright 2017-+infinity Stefan Steiger
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.


// Simulates System.Drawing.Image + System.Drawing.Imaging.ImageFormat for .NET Core 
// Required by vCard 
// TODO: Use ImageSharp/SkiaSharp to implement 


#define DOTNETCORE_LEGACY_COMPATIBILITY
#if DOTNETCORE_LEGACY_COMPATIBILITY


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
        } // End Class ImageFormat 

    } // End Namespace Imaging


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


    } // End Class Image 


} // End Namespace System.Drawing

#endif
