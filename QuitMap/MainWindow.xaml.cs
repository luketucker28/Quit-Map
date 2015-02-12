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

namespace QuitMap
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

        private void Quit(object sender, RoutedEventArgs e)
        {
            QuitPath.IsEnabled = true;
           
        }

        private void Data(object sender, RoutedEventArgs e)
        {
            SmokingData.IsEnabled = true;
        }

        private void Track(object sender, RoutedEventArgs e)
        {
            Progress.IsEnabled = true;
        }
    }
}
