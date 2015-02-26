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
        public static TargetRepository repo1 = new TargetRepository();
        public static DataEntryRepository repo = new DataEntryRepository();
        public MainWindow()
        {
            InitializeComponent();
            QuitDayAdded.DataContext = repo.Context().DataEntries.Local;
        }

        private void Quit(object sender, RoutedEventArgs e)
        {
            QuitPath.Visibility = Visibility.Collapsed;
            SmokingData.Visibility = Visibility.Collapsed;
            Progress.Visibility = Visibility.Collapsed;
            ChoosePlan.Visibility = Visibility.Visible;
            ExitEditButtons.Visibility = Visibility.Visible;
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
            NewEventForm.Visibility = Visibility.Collapsed;
            SmokingDataGrid.Visibility = Visibility.Visible;

        }

        private void Plan_Submit(object sender, RoutedEventArgs e)
        {
            if (DailySmoked.SelectedValue == null || ReductionPerWeek.SelectedValue == null || StartDate.SelectedDate == null)
            {
                NullValues.Visibility = Visibility.Visible;
            }               
            else if (repo.GetCount() != 0) {
                PlanInPlace.Visibility = Visibility.Visible; 
            }                     
            else
            {
                QuitBox.Visibility = Visibility.Visible;
                ChoosePlan.Visibility = Visibility.Collapsed;
                EditButton.Visibility = Visibility.Visible;
                int smokeDaily = (int)DailySmoked.SelectedValue;
             
                int reduceRate = (int)ReductionPerWeek.SelectedValue;
                DateTime tryer = (DateTime)StartDate.SelectedDate;
      
                repo.Add(new DataEntry(tryer.ToShortDateString(), smokeDaily, reduceRate));
                int totalDays = ((smokeDaily / reduceRate) * 7);           
                int counter = 1;           
                while (counter < totalDays)
                {
                    if (counter % 7 == 0)
                    {
                      int smokeReducer = smokeDaily - reduceRate;
                        smokeDaily = smokeReducer;
                        repo.Add(new DataEntry(tryer.AddDays(counter).ToShortDateString(), smokeReducer, reduceRate));                     
                        counter++;
                    }
                    else
                    {                        
                        repo.Add(new DataEntry(tryer.AddDays(counter).ToShortDateString(), smokeDaily, reduceRate));
                        counter++;
                    }
                }               
            }
        }

        private void ReturnToInitial(object sender, RoutedEventArgs e)
        {
            QuitPath.Visibility = Visibility.Visible;
            SmokingData.Visibility = Visibility.Visible;
            Progress.Visibility = Visibility.Visible;
            ChoosePlan.Visibility = Visibility.Collapsed;
            SubmitSmokes.Visibility = Visibility.Collapsed;
            QuitDayAdded.Visibility = Visibility.Collapsed;
            ExitEditButtons.Visibility = Visibility.Collapsed;
        }

        private void Editing(object sender, RoutedEventArgs e)
        {
            repo.Clear();
            ChoosePlan.Visibility = Visibility.Visible;
            EditButton.Visibility = Visibility.Collapsed;
            QuitDayAdded.Visibility = Visibility.Collapsed;
        }
    }
}