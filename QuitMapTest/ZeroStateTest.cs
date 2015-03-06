using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.WindowItems;
namespace QuitMapTest
{
    [TestClass]
    public class ZeroStateTest : TestHelper
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
        public void TestZeroStateButtons()
        {

            Button button = window.Get<Button>("QuitPath");
            Button button2 = window.Get<Button>("Progress");
            Button button3 = window.Get<Button>("SmokingData");
            Assert.IsTrue(button.Enabled);
            Assert.IsTrue(button2.Enabled);
            Assert.IsTrue(button3.Enabled);
        }
        
    }
}