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
using CryptoYarovaya;

namespace YarovayaUI
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

        private void button_Click(object sender, RoutedEventArgs e)
        {
            ImageLoader loader = new ImageLoader();
            string text = @"Кто ты, что посягнул на этот час
                   И этот бранный и прекрасный облик,
                   В котором мертвый повелитель датчан
                   Ступал когда-то? Заклинаю, молви!

                                  Марцелл

                   Он оскорблен.

                                  Бернардо

                                 Смотри, шагает прочь!

                                  Горацио

                   Стой! Молви, молви! Заклинаю, молви!

                              Призрак уходит.

                                  Марцелл";
            loader.CreateBitmap("image.png", text);
        }

        private void button_load_Click(object sender, RoutedEventArgs e)
        {
            ImageLoader loader = new ImageLoader();
            string text = loader.LoadBitmap("image.png");
            textBlock.Text = text;
        }
    }
}
