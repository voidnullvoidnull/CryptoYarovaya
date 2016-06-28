using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoUI
{
    public static class ImageConverter
    {

        public static BitmapFrame BinaryToImage(byte[] data)
        {
            double squaredLenght = Math.Sqrt(data.Length);

            int width = (int)Math.Round(Math.Sqrt(data.Length));
            int height = data.Length - (width*width) > 0    ?    width + 1 : width;
            byte[] pixels = new byte[width * height];

            for (int i = 0; i < pixels.Length; i++)
            {
                if(i < data.Length)
                    pixels[i] = data[i];
                else
                    pixels[i] = 255;
            }

            BitmapSource source = BitmapSource.Create(width, height, 1, 1, PixelFormats.Gray8, null, pixels, width);
            BitmapFrame frame = BitmapFrame.Create(source);
            return frame;
        }


        public static byte[] ImageToBinary(BitmapFrame frame)
        {
            byte[] data = new byte[frame.PixelWidth * frame.PixelHeight];
            frame.CopyPixels(data, frame.PixelWidth, 0);
            return data;
        }
    }
}
