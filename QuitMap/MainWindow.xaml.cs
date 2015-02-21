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
using QuitMap.Model;
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
            ChoosePlan.Visibility = Visibility.Visible;
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

        private void Plan_Submit(object sender, RoutedEventArgs e)
        {



            if (DailySmoked.SelectedValue == null || ReductionPerWeek.SelectedValue == null || StartDate.SelectedDate == null)
                NullValues.Visibility = Visibility.Visible;
            if (repo1.GetCount() != 0)
                PlanInPlace.Visibility = Visibility.Visible;
            else
            {
                int smokeDaily = (int)DailySmoked.SelectedValue;
                int reduceRate = (int)ReductionPerWeek.SelectedValue;
                string starting = StartDate.Text;
                repo1.Add(new DataEntry(starting, smokeDaily, reduceRate));

            }
        }
    }
}
