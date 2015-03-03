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

using QuitMap.Model;

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
            SmokingDataBox.DataContext = repo1.Context().Targets.Local;
            A.DataContext = repo1.Context().Targets.Local;
            B.DataContext = repo.Context().DataEntries.Local;
            
          
           
        }

        private void Data(object sender, RoutedEventArgs e)
        {
            HideStartPage();
            LabelForEntry.Visibility = Visibility.Visible;
            NewEventForm.Visibility = Visibility.Visible;
            SmokeDataStack.Visibility = Visibility.Visible;
            repo1.OrderByDate();
            SubmitSmokes.Visibility = Visibility.Visible;
            
        } 
        private void SmokeDaySubmit(object sender, RoutedEventArgs e)
        {
            DateTime smokeDate = (DateTime)DayToEnter.SelectedDate;
            string smokeTime = TimeOfSmoke.Text;
            string placeOfSmoke = Place.SelectionBoxItem.ToString();
            string AntecedantOFSmoke = Antecedent.SelectionBoxItem.ToString();
            if (smokeDate == null || smokeTime == null || placeOfSmoke == null || AntecedantOFSmoke == null)
            {
                NullValuesExist.Visibility = Visibility.Visible;
            }
            else
            {
                repo1.Add(new Target(smokeDate.ToShortDateString(), smokeTime, placeOfSmoke, AntecedantOFSmoke));
                repo1.OrderByDate();
                Place.SelectedValue = null;
                Antecedent.SelectedValue = null;
                TimeOfSmoke.Text = "";

            }

        }
       
        private void ExitSmokePage(object sender, RoutedEventArgs e)
        {
            ReturnToStartPage();
            NewEventForm.Visibility = Visibility.Collapsed;
            SmokeDataStack.Visibility = Visibility.Collapsed;
            LabelForEntry.Visibility = Visibility.Collapsed;
        }

        private void ReturnToStartPage()
        {
            QuitPath.Visibility = Visibility.Visible;
            SmokingData.Visibility = Visibility.Visible;
            Progress.Visibility = Visibility.Visible;
            SeePlan.Visibility = Visibility.Visible;
            SmokeDataStack.Visibility = Visibility.Collapsed;
            MainLabel.Visibility = Visibility.Visible;
        } 
        //Adding DataEntry e.g Target Info

        private void Quit(object sender, RoutedEventArgs e)
        {
            HideStartPage();
            ChoosePlan.Visibility = Visibility.Visible;
            ExitEditButtons.Visibility = Visibility.Visible;
        }
        
        private void Plan_Submit(object sender, RoutedEventArgs e)
        {
            if (DailySmoked.SelectedValue == null || ReductionPerWeek.SelectedValue == null || StartDate.SelectedDate == null)
            {
                NullValues.Visibility = Visibility.Visible;
            }               
            else if (repo.GetCount() != 0) {
                DeleteCurrentPlan.Visibility = Visibility.Visible;
                ChoosePlan.Visibility = Visibility.Collapsed;
            }                     
            else
            {
                QuitBox.Visibility = Visibility.Visible;
                ChoosePlan.Visibility = Visibility.Collapsed;
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
            ReturnToStartPage();
            ChoosePlan.Visibility = Visibility.Collapsed;
            SubmitSmokes.Visibility = Visibility.Collapsed;
            ExitEditButtons.Visibility = Visibility.Collapsed;
            QuitBox.Visibility = Visibility.Collapsed;

        }

        
// tracking page
        private void Track(object sender, RoutedEventArgs e)
        {
            HideStartPage();
          
            DatePickerFinder.Visibility = Visibility.Visible;
           
          

        }

        private void HideStartPage()
        {
            QuitPath.Visibility = Visibility.Collapsed;
            SmokingData.Visibility = Visibility.Collapsed;
            Progress.Visibility = Visibility.Collapsed;
            SeePlan.Visibility = Visibility.Collapsed;
            MainLabel.Visibility = Visibility.Collapsed;
        }
        
        
        private void FindDates(object sender, RoutedEventArgs e)
        {
            ViewTarget.Visibility = Visibility.Visible;
            Viewer.Visibility = Visibility.Visible;
            CountStacker.Visibility = Visibility.Visible;
            DateTime targetDater = (DateTime)DateFinder.SelectedDate;
            string asp = targetDater.ToShortDateString();
            var a = repo1.GetByDate(asp);
            int counter = a.Count();
            C.DataContext = counter;
            A.DataContext = repo1.GetByDate(asp);
            B.DataContext = repo.GetByDate(asp);
            //B.DataContext = repo.GetByDate(asp);
            //C.DataContext = repo.GetByDate(asp);
            //D.DataContext = repo1.GetByDate(asp);
            //E.DataContext = repo1.GetByDate(asp);
            //F.DataContext = repo1.GetByDate(asp);
           
      
        }

       
        private void Rubout(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                object item = btn.DataContext;


                if (item != null)
                {
                    int index = this.SmokingDataBox.Items.IndexOf(item);
                  var a = repo1.FindEntry(index);
                  repo1.Delete(a);
                }
            }
        }

        private void Redo(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                object item = btn.DataContext;


                if (item != null)
                {
                    int index = this.SmokingDataBox.Items.IndexOf(item);
                    var a = repo1.FindEntry(index);
                    repo1.Delete(a);
                }
            }
        }

        private void DeletePlan(object sender, RoutedEventArgs e)
        {
            DeleteCurrentPlan.Visibility = Visibility.Collapsed;
            repo1.Clear();
            repo.Clear();
            ChoosePlan.Visibility = Visibility.Visible;
            ExitEditButtons.Visibility = Visibility.Visible;
        }

        private void DoNotDelete(object sender, RoutedEventArgs e)
        {
            DeleteCurrentPlan.Visibility = Visibility.Collapsed;
            ReturnToStartPage();
        }

  

        private void TakeToQuitBox(object sender, RoutedEventArgs e)
        {
            QuitBox.Visibility = Visibility.Visible;
            ExitEditButtons.Visibility = Visibility.Visible;
            HideStartPage();
        }

        private void HomeFromTracker(object sender, RoutedEventArgs e)
        {
            ReturnToStartPage();
            DatePickerFinder.Visibility = Visibility.Collapsed;
            ViewTarget.Visibility = Visibility.Collapsed;
            Viewer.Visibility = Visibility.Collapsed;
            CountStacker.Visibility = Visibility.Collapsed;
        }

        
        

      
    }
}