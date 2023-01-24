using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcpServerToClientSendSS.AddditionalClasses
{
    public class ImageHelper
    {

        public string GetImagePath(byte[] buffer, int counter)
        {
            ImageConverter ic = new ImageConverter();
            var data = ic.ConvertFrom(buffer);

            Image img = data as Image;
            if (img != null)
            {
                Bitmap bitmap1 = new Bitmap(img);

                var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Images");
                Directory.CreateDirectory(path);
                bitmap1.Save($@"{path}\image{counter}.png");
                var imagepath = $@"{path}\image{counter}.png";
                return imagepath;
            }
            else
            {
                return String.Empty;
            }

        }
        public string GetImagePathJpeg(byte[] buffer, int counter)
        {
            ImageConverter ic = new ImageConverter();
            var data = ic.ConvertFrom(buffer);

            Image img = data as Image;
            if (img != null)
            {
                Bitmap bitmap1 = new Bitmap(img);

                var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Images");
                Directory.CreateDirectory(path);
                // Assumes myImage is the PNG you are converting
                using (var b = new Bitmap(bitmap1.Width, bitmap1.Height))
                {
                    b.SetResolution(bitmap1.HorizontalResolution, bitmap1.VerticalResolution);

                    using (var g = Graphics.FromImage(b))
                    {
                        g.Clear(Color.White);
                        g.DrawImageUnscaled(bitmap1, 0, 0);
                    }

                    // Now save b as a JPEG like you normally would
                    b.Save($@"{path}\image{counter}.jpeg");
                }
                var imagepath = $@"{path}\image{counter}.jpeg";
                return imagepath;
            }
            else
            {
                return String.Empty;
            }

        }

        public byte[] GetBytesOfImageJpeg(string path)
        {
            var image = new Bitmap(path);
            // Assumes myImage is the PNG you are converting
            ImageConverter imageconverter = new ImageConverter();
            using (var b = new Bitmap(image.Width, image.Height))
            {
                b.SetResolution(image.HorizontalResolution, image.VerticalResolution);

                using (var g = Graphics.FromImage(b))
                {
                    g.Clear(Color.White);
                    g.DrawImageUnscaled(image, 0, 0);
                }
                // Now save b as a JPEG like you normally would
                var imagebytes = ((byte[])imageconverter.ConvertTo(b, typeof(byte[])));
                return imagebytes;
            }
        }


        public byte[] GetBytesOfImage(string path)
        {
            var image = new Bitmap(path);
            ImageConverter imageconverter = new ImageConverter();
            var imagebytes = ((byte[])imageconverter.ConvertTo(image, typeof(byte[])));
            return imagebytes;
        }
    }
}
