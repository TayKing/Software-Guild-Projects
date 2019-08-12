using System;
using Factorizor.BLL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorizor.UI
{
    public class WorkFlow
    {
        public void Factorize()
        {
            ConsoleOutput.DisplayTitle();
            int number = ConsoleInput.GetFactorFromUser();
            int[] factorArr = FactorFinder.FindFactors(number);
            ConsoleOutput.DisplayFactors(number, factorArr);
            bool _IsPerfect = PerfectChecker.CheckForPerfect(number, factorArr);
            ConsoleOutput.DisplayPerfect(number, _IsPerfect);
            bool _IsPrime = PrimeChecker.CheckForPrime(factorArr);
            ConsoleOutput.DisplayPrime(number, _IsPrime);
            Console.ReadKey();
        }
    }
}
