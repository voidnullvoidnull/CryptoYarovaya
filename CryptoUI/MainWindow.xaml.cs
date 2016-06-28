using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Crypter.Init();

            inputTextBox.Text = Crypter.privString;
            loadedTextBox.Text = Crypter.pubString;
        }

        private void generateButton_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == true)
            {
                JpegMetadataAdapter jpeg = new JpegMetadataAdapter(dialog.FileName);
                jpeg.Metadata.Comment = inputTextBox.Text;
                jpeg.Save();          
            }            
        }

        private void loadButton_Click(object sender, RoutedEventArgs e)
        {
            BitmapFrame frame = FileManager.LoadImage();
            BitmapMetadata meta = (BitmapMetadata)frame.Metadata;
            loadedTextBox.Text = meta.Comment;
            loadedImage.Source = frame;
        }
    }
}
