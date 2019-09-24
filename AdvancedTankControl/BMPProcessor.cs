using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace AdvancedTankControl
{
    class BMPProcessor
    {
        public static Bitmap GetBmp(byte[] data, Size size, bool VGA)
        {
            // Get width and height of bitmap
            int Width = 160;
            int Height = 120;
            if (!VGA)
            {
                Width = 80;
                Height = 60;
            }
            //Create bitmap
            Bitmap bmp = new Bitmap(Width, Height, PixelFormat.Format16bppRgb565);
            // get total locked pixels count
            int PixelCount = Width * Height;

            // Create rectangle to lock
            Rectangle rect = new Rectangle(0, 0, Width, Height);
            
            // Lock bitmap and return bitmap data
            BitmapData bitmapData = bmp.LockBits(rect, ImageLockMode.ReadWrite,
                                         bmp.PixelFormat);

            // create byte array to copy pixel values            
            IntPtr Iptr = bitmapData.Scan0;
            
            // Copy data from byte array to pointer
            Marshal.Copy(data, 0, Iptr, data.Length);

            // Unlock bitmap data
            bmp.UnlockBits(bitmapData);

            return new Bitmap(bmp, size);
        }
    }
}
