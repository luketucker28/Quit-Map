using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuitMap.Model;


namespace QuitMapTest
{
    [TestClass]
    public class DataEntryTest : TestHelper
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
        public void ScenarioDataEntryCreation()
        {
            AndIShouldSeeTheNewForm();
            AndIShouldSeeTheNewForm();
            ButtonsInvisible();
            IChooseTheDayToAddData(new DateTime(2015, 05, 28));
            IChooseThePlace("Home");
            IChooseTheAntecedent("Sex");
            IChooseTheTime("4:30 PM");
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
