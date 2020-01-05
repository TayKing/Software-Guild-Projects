using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorizor.BLL
{
    public class PerfectChecker
    {
        public static bool CheckForPerfect(int number, int[] factorArr)
        {
            int sum = 0;

            foreach (int n in factorArr)
                sum += n;

            sum -= number;

            if (sum == number)
                return true;
            else
                return false;
        }
    }
}
