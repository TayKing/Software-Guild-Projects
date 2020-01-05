using System;
using NUnit.Framework;
using Factorizor.BLL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorizor.Tests
{
    [TestFixture]
    class PerfectCheckerTests
    {
        [TestCase(6,new[] { 1, 2, 3, 6 }, true)]
        [TestCase(1,new[] { 1 }, false)]
        [TestCase(17,new[] { 1, 17 }, false)]
        public void CheckForPerfectTest(int num, int[] nums, bool expected)
        {
            var actual = PerfectChecker.CheckForPerfect(num, nums);
            Assert.AreEqual(expected, actual);
        }
    }
}
