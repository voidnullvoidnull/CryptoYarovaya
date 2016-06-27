using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace CryptoUI
{
    public static class FileManager
    {

        public static BitmapFrame LoadImage( MainWindow window)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == true)
            {

                using (Stream fs = dialog.OpenFile())
                {
                    BitmapDecoder dec = PngBitmapDecoder.Create(fs, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.OnLoad);
                    return dec.Frames[0];
                }
            }
            else
            {
                return null;
            }
        }


        public static void SaveImage( BitmapFrame frame )
        {
            SaveFileDialog dialog = new SaveFileDialog();

            if (dialog.ShowDialog() == true & dialog.FileName != "")
            {
                using (FileStream fs = File.Create(dialog.FileName))
                {
                    BitmapEncoder encoder = new PngBitmapEncoder();
                    encoder.Frames.Add(frame);
                    encoder.Save(fs);
                    fs.Close();
                }
            }

        }

    }
}
