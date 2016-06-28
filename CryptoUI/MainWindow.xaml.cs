using System;
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

namespace CryptoUI
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        string privText = "";
        string pubText = "";

        private void generateButton_Click(object sender, RoutedEventArgs e)
        {
            byte[] data = TextCrypter.StringToBytes(inputTextBox.Text, pubText);
            createdImage.Source = ImageConverter.BinaryToImage(data); 
        }

        private void loadButton_Click(object sender, RoutedEventArgs e)
        {
            BitmapFrame frame = FileManager.LoadImage(this);
            byte[] data = ImageConverter.ImageToBinary(frame);
            loadedTextBox.Text = TextCrypter.BytesToString(data, privText);
            loadedImage.Source = frame;
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            FileManager.SaveImage((BitmapFrame)createdImage.Source);
        }

        private void generateKeyButton_Click(object sender, RoutedEventArgs e)
        {
            KeyValuePair<string, string> keys = TextCrypter.GetKeys();
            privateBox.Text = keys.Key;
            publicBox.Text = keys.Value;

            privateKeyText.Text = keys.Key;
            publicKeyText.Text = keys.Value;
        }

        private void privateBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            privText = privateBox.Text;
        }

        private void publicBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            pubText = publicBox.Text;
        }
    }
}
