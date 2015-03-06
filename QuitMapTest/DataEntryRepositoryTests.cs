using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using System.Collections.Generic;
using QuitMap.Repository;
using QuitMap;
using QuitMap.Model;
namespace QuitMapTest
{
    [TestClass]
    public class DataEntryRepositoryTests
   {

        private static DataEntryRepository repo;

        [ClassInitialize]
        public static void SetUp(TestContext _context)
        {
            repo = new DataEntryRepository();
            repo.Clear();
        }

        [ClassCleanup]
        public static void CleanUp()
        {
            repo.Clear();
            repo.Dispose();
        }
 
        [TestCleanup]
        public void ClearDatabase()
        {
            repo.Clear();
        }

        [TestMethod]
        public void TestAddToDatabase() //Valid
        {
            Assert.AreEqual(0, repo.GetCount());
            repo.Add(new DataEntry("New Years Eve", 1, 2));
            Assert.AreEqual(1, repo.GetCount());
        }

        [TestMethod]
        public void TestDeleteFromDatabase()
        {
            var tester = new DataEntry("New Years Eve", 1, 2);
            repo.Add(tester);
            repo.Delete(tester);
            Assert.AreEqual(0, repo.GetCount());
        }
        [TestMethod]
        public void TestAllMethod()
        {
            repo.Add(new DataEntry("New Years Eve", 1, 2));
            repo.Add(new DataEntry("New Years Eve", 1, 2));
            Assert.AreEqual(2, repo.GetCount());
        }

        [TestMethod]
        public void TestGetCount()
        {
            Assert.AreEqual(0, repo.GetCount());
            repo.Add(new DataEntry("New Years Eve", 1, 2));

            Assert.AreEqual(1, repo.GetCount());
        }

        [TestMethod]
        public void TestClear()
        {
            repo.Add(new DataEntry("New Years Eve", 1, 2));
            repo.Clear();
            Assert.AreEqual(0, repo.GetCount());
        }
        [TestMethod]
        public void GetFirstItem()
        {
            repo.Clear();
            var a = new DataEntry("New Years Eve", 1, 2);
            var b = new DataEntry("saturday", 3, 1);
            repo.Add(a);
            repo.Add(b);
            Assert.AreEqual(a.Date, repo.FirstEntry().Date);
        }

       // [TestMethod]
       // public void
        // Execption Tag: We want the Repository to throw an exception instead of adding duplicate
        // DataEntrys
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DataEntriesAreUnique()
        {
            DataEntry e = new DataEntry("New Years Eve", 1, 2);
            repo.Clear();
            repo.Add(e);
            repo.Add(e);

        }
    }
}
   
