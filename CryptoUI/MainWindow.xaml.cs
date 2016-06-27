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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void generateButton_Click(object sender, RoutedEventArgs e)
        {
            byte[] data = TextConverter.StringToBytes(inputTextBox.Text);
            createdImage.Source = ImageToText.CreateImageFrame(data); 
        }

        private void loadButton_Click(object sender, RoutedEventArgs e)
        {
            BitmapFrame frame = FileManager.LoadImage(this);
            loadedTextBox.Text = ImageToText.CreateStringFromImage(frame);
            loadedImage.Source = frame;
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            FileManager.SaveImage((BitmapFrame)createdImage.Source);
        }
    }
}
