using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuitMap.Model;
using TestStack.White.UIItems.WindowItems;
using TestStack.White;
using System.IO;
using System.Reflection;
using TestStack.White.Factory;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WPFUIItems;
using QuitMap.Repository;
using QuitMap;
using System.Windows.Automation;
using TestStack.White.UIItems;

namespace QuitMapTest
{
    public class TestHelper
    {
        private static TestContext test_context;
        protected static Window window;
        private static Application application;
        private static TargetRepository repo1 = new TargetRepository();
        private static DataEntryRepository repo = new DataEntryRepository();
        private static QuitMapContext context;
        private static String applicationPath;

        public static void SetupClass(TestContext _context)
        {
            var applicationDir = _context.DeploymentDirectory;
            applicationPath = Path.Combine(applicationDir, "..\\..\\..\\QuitMap\\bin\\Debug\\QuitMap");
        }

        public static void TestPrep()
        {
            application = Application.Launch(applicationPath);
            window = application.GetWindow("MainWindow", InitializeOption.NoCache);
            context = repo.Context();
        }

        //Tests for Target e.g Data Entry setup
        public void IClickToViewNewForm()
        {
            Button button = window.Get<Button>(SearchCriteria.ByAutomationId("SmokingData"));
            button.Click();
        }

        public void AndIShouldSeeTheNewForm()
        {
         
            DateTimePicker start = window.Get<DateTimePicker>(SearchCriteria.ByAutomationId("DayToEnter"));
            ComboBox ante =  window.Get<ComboBox>(SearchCriteria.ByAutomationId("Antecedent"));
            ComboBox plac =  window.Get<ComboBox>(SearchCriteria.ByAutomationId("Place"));
            Assert.IsTrue(start.Visible);
            Assert.IsTrue(ante.Visible);
            Assert.IsTrue(plac.Visible);
        }
        public void ButtonsInvisible()
        {
            Button button = window.Get<Button>(SearchCriteria.ByAutomationId("SmokingData"));
            Button button1 = window.Get<Button>(SearchCriteria.ByAutomationId("QuitPath"));
            Button button2 = window.Get<Button>(SearchCriteria.ByAutomationId("Progress"));
            Assert.IsFalse(button.Visible);
            Assert.IsFalse(button1.Visible);
            Assert.IsFalse(button2.Visible);
        }
        public void IChooseTheDayToAddData(DateTime newDate)
        {
            DateTimePicker picker = window.Get<DateTimePicker>(SearchCriteria.ByAutomationId("DayToEnter"));
            picker.Date = newDate;
            Assert.AreEqual(newDate, picker.Date);
        }
        public void IChooseTheTime(string time)
        {
            var smokeTime = window.Get<TextBox>("TimeOfSmoke");
            smokeTime.Text = time;
            Assert.AreEqual(smokeTime.Text, time);
        }
        public void IChooseThePlace(string value)
        {
            var plac = window.Get<ComboBox>("Place");
            plac.SetValue(value);
        }
        public void IChooseTheAntecedent(string value)
        {
            var ante = window.Get<ComboBox>("Antecedent");
            ante.SetValue(value);
        }
        public void IClickTheSubmitButton()
        {
            Button button = window.Get<Button>(SearchCriteria.ByAutomationId("SubmitSmokes"));
            button.Click();
        }
        public void IShouldSeeTheDataEntered()
        {
            ListBox list_box = window.Get<ListBox>(SearchCriteria.ByAutomationId("SmokingDataBox"));
            Assert.IsTrue(list_box.Visible);
        }   


        // tests for data entry setup e.g target
        public void IClickViewQuitPlanForm()
        {
            Button button = window.Get<Button>(SearchCriteria.ByAutomationId("QuitPath"));
            button.Click();
        }
       
        public void IShouldSeeTheQuitPlanForm()
        {

            DateTimePicker quitDate = (DateTimePicker)window.Get(SearchCriteria.ByAutomationId("StartDate"));
            ComboBox startingIntake = window.Get<ComboBox>(SearchCriteria.ByAutomationId("DailySmoked"));
            ComboBox reduce = window.Get<ComboBox>(SearchCriteria.ByAutomationId("ReductionPerWeek"));
            Button submits = window.Get<Button>(SearchCriteria.ByAutomationId("SubmitPlan"));
            Button exiter = window.Get<Button>(SearchCriteria.ByAutomationId("Exiting"));
            Assert.IsTrue(quitDate.Visible);
            Assert.IsTrue(reduce.Visible);
            Assert.IsTrue(startingIntake.Visible);
            Assert.IsTrue(submits.Visible);
            Assert.IsTrue(exiter.Visible);
        }
        
        public void IChooseTheQuitDate(DateTime? newDate)
        {
            var timer = window.Get<DateTimePicker>("StartDate");
            timer.Date = newDate;
            Assert.AreEqual(newDate, timer.Date);
        }

        public void IChooseMyCurrentIntake(int? smokes)
        {
            var smokesDaily = window.Get<ComboBox>("DailySmoked");
            smokesDaily.SetValue(smokes);
        }
        public void IChooseSetTheAmountToReducePerWeek(int? value)
        {
            var reduce = window.Get<ComboBox>("ReductionPerWeek");
            reduce.SetValue(value);
        }
        public void IClickButtonToSubmitPlan()
        {
            Button planSubmitter = window.Get<Button>(SearchCriteria.ByAutomationId("SubmitPlan"));
            planSubmitter.Click();
        
        }
        
        public void IShouldSeeListBox()
        {
            DateTimePicker quitDate = window.Get<DateTimePicker>(SearchCriteria.ByAutomationId("StartDate"));
            ComboBox startingIntake = window.Get<ComboBox>(SearchCriteria.ByAutomationId("DailySmoked"));
            ComboBox reduce = window.Get<ComboBox>(SearchCriteria.ByAutomationId("ReductionPerWeek"));
            Button submits = window.Get<Button>(SearchCriteria.ByAutomationId("SubmitPlan"));
            //Assert.IsFalse(quitDate.Visible);
            Assert.IsFalse(reduce.Visible);
            Assert.IsFalse(startingIntake.Visible);
            Assert.IsFalse(submits.Visible);
        }
        public void ICannotEnterDuplicateLabelAppears()
        {
            repo.Add(new DataEntry("5/18/15", 3, 5));
            Assert.AreEqual(1, repo.GetCount());
            Label aba = window.Get<Label>("PlanInPlace");
            Assert.IsTrue(aba.Visible);

        }
        public void IShouldSeeNullLabel() {
            Label aba = window.Get<Label>("NullValues");
            Assert.IsTrue(aba.Visible);
            int? a = null;
            int? b = null;
            DateTime? c = null;
                if (a == null)
                {
                    IChooseSetTheAmountToReducePerWeek(a);
                    Assert.IsTrue(aba.Visible);
                }
                if(b == null) {
                    IChooseMyCurrentIntake(b);
                    Assert.IsTrue(aba.Visible);
                }
                if (c == null) {
                    IChooseTheQuitDate(c);
                    Assert.IsTrue(aba.Visible);
                
            }
        }
        public void IShouldSeeQuitDatePopulated(int expected)
        {
            Assert.IsNotNull(window);
            //SearchCriteria searchCriteria = SearchCriteria.ByAutomationId("QuitDayAdded");
            ListBox list_box = window.Get<ListBox>(SearchCriteria.ByAutomationId("QuitDayAdded"));
            Assert.IsTrue(list_box.Visible);
            Assert.AreEqual(expected, list_box.Items.Count);
        }
        public void IShouldAlsoSeeQuitDateCount(int x)
        {
            IShouldSeeQuitDatePopulated(x);
        }
        public void IShouldReturnToMainViewWithoutSubmitting()
        {
            Button exiter = window.Get<Button>(SearchCriteria.ByAutomationId("Exiting"));
            exiter.Click();
            MainPageButtonsAreVisible();

        }

        private static void MainPageButtonsAreVisible()
        {
            Button button = window.Get<Button>(SearchCriteria.ByAutomationId("SmokingData"));
            Button button1 = window.Get<Button>(SearchCriteria.ByAutomationId("QuitPath"));
            Button button2 = window.Get<Button>(SearchCriteria.ByAutomationId("Progress"));
            Assert.IsTrue(button.Visible);
            Assert.IsTrue(button1.Visible);
            Assert.IsTrue(button2.Visible);
        }
        public void IShouldReturnToMainViewAfterSubmitting()
        {
            Button exiter = window.Get<Button>(SearchCriteria.ByAutomationId("Exiting"));
            exiter.Click();           
            ListBox list_box = window.Get<ListBox>(SearchCriteria.ByAutomationId("QuitDayAdded"));
            Assert.IsFalse(list_box.Visible);
           

        }
        public void IWantToEditMyPlanAfterSubmitting()
        {
            Button editsBack = window.Get<Button>(SearchCriteria.ByAutomationId("EditButton"));
            editsBack.Click();
             ListBox list_box = window.Get<ListBox>(SearchCriteria.ByAutomationId("QuitDayAdded"));
            Assert.AreEqual(0, repo.GetCount());
            Assert.IsFalse(list_box.Visible);
        }
        
        
       
        //stop
        public void ThenIShouldSeeXEvents(int expected)
        {
            Assert.IsNotNull(window);
            SearchCriteria searchCriteria = SearchCriteria.ByAutomationId("CountdownList").AndIndex(0);
            ListBox list_box = (ListBox)window.Get(searchCriteria);
            Assert.AreEqual(expected, list_box.Items.Count);
        }

        public void AndIShouldSeeXEvents(int x)
        {
            ThenIShouldSeeXEvents(x);
        }

        public void AndTheButtonShouldBeEnabled(string buttonContent)
        {
            Button button = window.Get<Button>(SearchCriteria.ByText(buttonContent));
            Assert.IsTrue(button.Enabled);
        }

        public void AndTheButtonShouldBeDisabled(string buttonContent)
        {
            Button button = window.Get<Button>(SearchCriteria.ByText(buttonContent));
            Assert.IsFalse(button.Enabled);
        }

        //public void AndIShouldSeeACountdownFor(string p1, string p2)
        //{
        //    var e = repo.GetByDate(p2);
        //    Assert.IsNotNull(window);
        //    SearchCriteria searchCriteria = SearchCriteria.ByAutomationId("CountdownList").AndIndex(0);
        //    ListBox list_box = (ListBox)window.Get(searchCriteria);
        //    var item = list_box.Items.Find(i => i.Text == p1);
        //    Assert.AreEqual(p1, item.Text);
           
        //}

        public void ThenIShouldNotSeeTheEventForm()
        {
            Button button = window.Get<Button>(SearchCriteria.ByAutomationId("AddEvent"));
            Assert.IsFalse(button.Visible);
        }

        public void AndIClick(string buttonContent)
        {
            WhenIClick(buttonContent);
        }

        public void AndIChooseTheEventDate(DateTime newDate)
        {
            DateTimePicker picker = window.Get<DateTimePicker>(SearchCriteria.ByAutomationId("EventDate"));
            picker.SetValue(newDate);
        }

        public void WhenIFillInEventTitleWith(string value)
        {
            var textBox = window.Get<TextBox>("EventTitle");
            textBox.SetValue(value);
        }

        public void AndTheEventDateShouldBe30DaysFromNow()
        {
            DateTimePicker picker = window.Get<DateTimePicker>(SearchCriteria.ByAutomationId("EventDate"));
            DateTime? actual = picker.Date;
            DateTime expected = DateTime.Today.AddDays(30);
            Assert.AreEqual(expected, actual);
        }

        public void AndIShouldNotSeeTheHelperText()
        {
            var text = window.Get(SearchCriteria.ByAutomationId("GettingStartedText"));
            Assert.IsFalse(text.Visible);
        }

        public void ThenIShouldSeeTheEventForm()
        {
            Button button = window.Get<Button>(SearchCriteria.ByAutomationId("AddEvent"));
            Assert.IsTrue(button.Visible);
        }

        public void WhenIClick(string buttonContent)
        {
            Button button = window.Get<Button>(SearchCriteria.ByText(buttonContent));
            button.Click();
        }

        public void ThenIShouldSeeACountdownFor(string p1, string p2)
        {
            throw new NotImplementedException();
        }

        public void GivenThereAreNoEvents()
        {
            Assert.AreEqual(0,repo.GetCount());
        }

        public static void GivenTheseEvents(params Target[] targets)
        {
            foreach (Target evnt in targets)
            {
                // Add event to Events here.
                repo1.Add(evnt);
            }
            
            //context.SaveChanges();
            Assert.AreEqual(targets.Length, repo.GetCount());
        }

        public static void CleanThisUp()
        {
            window.Close();
            application.Close();
            repo.Clear();
        }
    }
}

  



