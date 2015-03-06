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
    public class TargetRepositoryTest
    {
        private static TargetRepository repo;

        [ClassInitialize]
        public static void SetUp(TestContext _context)
        {
            repo = new TargetRepository();
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
        public void TestDeleteFromDatabase()
        {
           var tester = new Target("seven", "two", "three", "four");
           repo.Add(tester);
           repo.Delete(tester);
           Assert.AreEqual(0, repo.GetCount());
        }
        [TestMethod]
        public void TestAddToDatabase() //Valid
        {
            Assert.AreEqual(0, repo.GetCount());
            repo.Add(new Target("seven", "two", "three", "four"));
            Assert.AreEqual(1, repo.GetCount());
        }

        [TestMethod]
        public void TestAllMethod()
        {
            repo.Add(new Target("seven", "two", "three", "four"));
            repo.Add(new Target("Valentine's Day", "02/14/2015", "four", "five"));
            Assert.AreEqual(2, repo.GetCount());
        }

        [TestMethod]
        public void TestGetCount()
        {
            Assert.AreEqual(0, repo.GetCount());
            repo.Add(new Target("seven", "two", "three", "four"));
            Assert.AreEqual(1, repo.GetCount());
        }

        [TestMethod]
        public void FindByDate()
        {
            Assert.AreEqual(0, repo.GetCount());
            repo.Add(new Target("12-12-2015", "ten", "three", "four"));
            repo.Add(new Target("12-12-2015", "one", "three", "four"));
            repo.Add(new Target("12-12-2015", "three", "three", "four"));
            repo.Add(new Target("12-12-14", "three", "three", "four"));
           
            Assert.AreEqual(repo.GetCount(), repo.GetByDate("12-12-2015").Count);
        }
        [TestMethod]
        public void TestClear()
        {
            repo.Add(new Target("seven", "two", "three", "four"));
            repo.Clear();
            Assert.AreEqual(0, repo.GetCount());
        }

        // Execption Tag: We want the Repository to throw an exception instead of adding duplicate
        // Targets
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TargetsAreUnique()
        {
            Target e = new Target("seven", "two", "three", "four");
            Target f = new Target("seven", "two", "two", "one");
            repo.Clear();
            repo.Add(e);
            repo.Add(f);
        }
    }
}