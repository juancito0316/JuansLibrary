using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace JuansLibrary
{
    public static class ImageHelper
    {

        public static byte[] ConvertToByteArray(this Image image, ImageFormat format)
        {
            using (var ms = new MemoryStream())
            {
                image.Save(ms, format);
                return ms.ToArray();
            }
        }

        public static Image ConvertToImage(this IEnumerable<byte> bytes)
        {
            using (var ms = new MemoryStream(bytes.ToArray()))
            {
                return Image.FromStream(ms);
            }
        }

        public static Image ResizeImage(this Image img, Size size)
        {
           var bitmap = new Bitmap(img, size);
           return (Image)bitmap;
        }
    }
}
