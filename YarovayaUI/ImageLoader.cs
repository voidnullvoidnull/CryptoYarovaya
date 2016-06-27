using System;
using System.IO;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Text;
using System.Security;
using System.Runtime.Serialization;
using System.Collections;
using System.Collections.Generic;

namespace CryptoYarovaya
{
    public class ImageLoader
    {
        public void CreateBitmap(string path, string text)
        {

            byte[] data = Encoding.Unicode.GetBytes(text);

            int rawWidth = (int)Math.Round(Math.Sqrt(data.Length));
            byte[] array = new byte[rawWidth * rawWidth];
            for (int i = 0; i < array.Length; i++)
            {
                if (i < data.Length)
                {
                    array[i] = data[i];
                }
                else
                {
                    array[i] = 255;
                }
            }

            int dpi = 10;
            int width = rawWidth;
            int height = width;

            
            

            BitmapSource source = BitmapSource.Create(width, height, dpi, dpi, PixelFormats.Gray8, null, array, width);

            using (FileStream fs = File.Create(path))
            {

                PngBitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(source));
                encoder.Save(fs);
            }

        }

        public string LoadBitmap(string path)
        {
            string text;

            using (FileStream fs = File.Open(path, FileMode.Open))
            {
                BitmapDecoder decoder = PngBitmapDecoder.Create(fs, BitmapCreateOptions.DelayCreation, BitmapCacheOption.Default);
                BitmapFrame frame = decoder.Frames[0];

                byte[] bytes = new byte[frame.PixelWidth * frame.PixelHeight];
                frame.CopyPixels(bytes, frame.PixelWidth, 0);

                text = Encoding.Unicode.GetString(bytes);             
            }

            return text;
        }
    }
}
