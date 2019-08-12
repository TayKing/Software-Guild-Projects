using System;
using NUnit.Framework;
using Factorizor.BLL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorizor.Tests
{
    class PrimeCheckerTests
    {
        [TestCase(new[] { 1, 2, 3, 6 }, false)]
        [TestCase(new[] { 1 }, false)]
        [TestCase(new[] { 1, 17 }, true)]
        public void CheckForPrimeTest(int[] nums, bool expected)
        {
            var actual = PrimeChecker.CheckForPrime(nums);
            Assert.AreEqual(expected, actual);
        }
    }
}
