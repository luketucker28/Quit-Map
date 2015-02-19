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
using QuitMap.Repository;
using Xceed.Wpf.Toolkit;
using Xceed.Wpf.DataGrid;
namespace QuitMap
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static TargetRepository repo = new TargetRepository();
        public static DataEntryRepository repo1 = new DataEntryRepository();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Quit(object sender, RoutedEventArgs e)
        {
        QuitPath.Visibility = Visibility.Collapsed;
        SmokingData.Visibility = Visibility.Collapsed;
        Progress.Visibility = Visibility.Collapsed;
       
           
        }

        private void Data(object sender, RoutedEventArgs e)
        {
            QuitPath.Visibility = Visibility.Collapsed;
            SmokingData.Visibility = Visibility.Collapsed;
            Progress.Visibility = Visibility.Collapsed;
            NewEventForm.Visibility = Visibility.Visible;
            SubmitSmokes.Visibility = Visibility.Visible;
        }

        private void Track(object sender, RoutedEventArgs e)
        {
            QuitPath.Visibility = Visibility.Collapsed;
            SmokingData.Visibility = Visibility.Collapsed;
            Progress.Visibility = Visibility.Collapsed;
           
        }

        private void AddSmokes_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddNewRow(object sender, RoutedEventArgs e)
        {

        }

        private void SmokeDaySubmit(object sender, RoutedEventArgs e)
        {

        }
    }
}
