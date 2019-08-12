using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorizor.BLL
{
    public class FactorFinder
    {
        public static int[] FindFactors(int number)
        {
            List<int> factors = new List<int>();
            for (int i = 1; i <= number; i++)
            {
                if (number % i == 0)
                {
                    factors.Add(i);
                }
            }

            return factors.ToArray();
        }
    }
}
