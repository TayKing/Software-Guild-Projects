using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorizor.BLL
{
    public class PrimeChecker
    {
        public static bool CheckForPrime(int[] factorArr)
        {
            int sum = 0;

            foreach (int n in factorArr)
                sum ++;

            if (sum == 2)
                return true;
            else
                return false;
        }
    }
}
