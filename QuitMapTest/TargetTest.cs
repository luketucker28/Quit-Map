using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuitMap.Model;
using QuitMap;
using QuitMap.Repository;
namespace QuitMapTest
{
    [TestClass]
    public class TargetTest : TestHelper
    {

        [ClassInitialize]
        public static void SetupTests(TestContext _context)
        {
            TestHelper.SetupClass(_context);
        }

        [TestInitialize]
        public void SetupTests()
        {
            TestHelper.TestPrep();
        }

        [TestCleanup]
        public void CleanUp()
        {
            TestHelper.CleanThisUp();
        }

        [TestMethod]
        public void ScenarioCigaretteEntryCreation()
        {
            IClickToViewNewForm();
            AndIShouldSeeTheNewForm();
            ButtonsInvisible(); 
            IChooseTheDayToAddData(new DateTime(2015, 05, 28));
            IChooseTheTime("4:30");
            IChooseThePlace("Home");
            IChooseTheAntecedent("Sex");
            IClickTheSubmitButton();
            IShouldSeeTheDataEntered();
           

        }
            [TestMethod]
        public void CreateQuitDate()
        {
            IClickViewQuitPlanForm();
            IShouldSeeTheQuitPlanForm();
            IChooseSetTheAmountToReducePerWeek(2);
            IChooseTheQuitDate(new DateTime(2015, 05, 28));
            IChooseMyCurrentIntake(10);
            IClickButtonToSubmitPlan();
            IShouldSeeListBox();
            IShouldAlsoSeeQuitDateCount(35);
        }
         [TestMethod]
            public void CheckingNullFields()
            {
            IClickViewQuitPlanForm();
            IShouldSeeTheQuitPlanForm();
            IChooseSetTheAmountToReducePerWeek(null);
            IChooseTheQuitDate(new DateTime(2015, 05, 28));
            IChooseMyCurrentIntake(10);
            IClickButtonToSubmitPlan();
            IShouldSeeNullLabel();           
            }
         [TestMethod]
         public void CheckingIfPlanExists()
         {
             IClickViewQuitPlanForm();
             IShouldSeeTheQuitPlanForm();
             IChooseSetTheAmountToReducePerWeek(2);
             IChooseTheQuitDate(new DateTime(2015, 05, 28));
             IChooseMyCurrentIntake(10);
             IClickButtonToSubmitPlan();
             ICannotEnterDuplicateLabelAppears();   
         }
         [TestMethod]
         public void IWantToExitPlanToMainMenuWithoutSubmitting()
         {
             IClickViewQuitPlanForm();
             IShouldSeeTheQuitPlanForm();
             IShouldReturnToMainViewWithoutSubmitting();
             
         }
        [TestMethod]
         public void IWantToReturnToMainWindowAfterQuitPlanSubmit()
         {
             IClickViewQuitPlanForm();
             IShouldSeeTheQuitPlanForm();
             IChooseSetTheAmountToReducePerWeek(2);
             IChooseTheQuitDate(new DateTime(2015, 05, 28));
             IChooseMyCurrentIntake(10);
             IClickButtonToSubmitPlan();
             IShouldSeeListBox();
             IShouldAlsoSeeQuitDateCount(35);
             IShouldReturnToMainViewAfterSubmitting();   
         }
        [TestMethod]
        public void IWantToEditMyPlanAfterSubmit()
        {
            IClickViewQuitPlanForm();
             IShouldSeeTheQuitPlanForm();
             IChooseSetTheAmountToReducePerWeek(2);
             IChooseTheQuitDate(new DateTime(2015, 05, 28));
             IChooseMyCurrentIntake(10);
             IClickButtonToSubmitPlan();
             IShouldSeeListBox();
             IShouldAlsoSeeQuitDateCount(35);
             IWantToEditMyPlanAfterSubmitting();
        }
        //[TestMethod]
        //public void ScenarioDataValidationForEventCreation()
        //{
        //    GivenThereAreNoEvents();
        //    WhenIClick("+");
        //    AndIClick("Add");
        //    ThenIShouldSeeTheEventForm();
      
        //    WhenIFillInEventTitleWith("Valentine's");
        //    AndIChooseTheEventDate(new DateTime(2015, 02, 14));
        //    AndIClick("Add");
        //    ThenIShouldNotSeeTheEventForm();
        //    AndIShouldSeeXEvents(1);
        //    AndIShouldSeeACountdownFor("Valentine's", "02/14/15");
        //}

        //[TestMethod]
        //public void ScenarioCancelingOutOfEventCreation()
        //{
        //    GivenThereAreNoEvents();
        //    WhenIClick("+");
        //    WhenIFillInEventTitleWith("Valentine's");
        //    AndIChooseTheEventDate(new DateTime(2015, 02, 14));
        //    AndIClick("Cancel");
        //    ThenIShouldNotSeeTheEventForm();
        //    AndIShouldSeeXEvents(0);
           
        //    AndTheButtonShouldBeEnabled("+");
        //    WhenIClick("+");
        //    ThenIShouldSeeTheEventForm();
        //    AndTheEventDateShouldBe30DaysFromNow();
        //    AndTheButtonShouldBeDisabled("+");
        //} 
   
    }
}

      
