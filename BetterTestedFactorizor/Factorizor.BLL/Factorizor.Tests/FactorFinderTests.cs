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
    class FactorFinderTests
    {
        [TestCase(6,new[] { 1, 2, 3, 6 })]
        [TestCase(1, new[] { 1 })]
        [TestCase(17,new[] { 1, 17 })]
        public void FactorFinderTest(int num, int[] expected)
        {
            var actual = FactorFinder.FindFactors(num);
            Assert.AreEqual(expected, actual);
        }
    }
}
