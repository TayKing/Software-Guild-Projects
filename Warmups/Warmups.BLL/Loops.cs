using System;

namespace Warmups.BLL
{
    public class Loops
    {

        public string StringTimes(string str, int n)
        {
            string times = str;

            for (int i = 0; i < n - 1; i++)
            {
                times += str;
            }

            return times;
        }

        public string FrontTimes(string str, int n)
        {
            string first = string.Empty;
            string times = string.Empty;

            if (str.Length < 3)
                times = str;
            else
                times = str.Substring(0, 3);

            for (int i = 0; i < n; i++)
            {
                first += times;
            }

            return first;
        }

        public int CountXX(string str)
        {
            int xcounter = 0;

            for (int i = 0; i < str.Length - 1; i++)
                if (str[i] == str[i + 1])
                    xcounter++;

            return xcounter;
        }

        public bool DoubleX(string str)
        {
            if (!str.Contains("xx"))
                return false;
            else
            {
                int index = str.IndexOf("x");

                if (str[index] == str[index + 1])
                    return true;
                else
                    return false;
            }
        }

        public string EveryOther(string str)
        {
            string alternating = string.Empty;

            for (int i = 0; i < str.Length; i += 2)
                alternating += str[i];

            return alternating;
        }

        public string StringSplosion(string str)
        {
            string splosion = string.Empty;

            for (int i = 0; i < str.Length + 1; i++)
                splosion += str.Substring(0, i);
                
            return splosion;
        }

        public int CountLast2(string str)
        {
            string lasttwo = str.Substring(str.Length - 2, 2);
            int count = 0;

            for (int i = 0; i < str.Length - 2; i++)
            {
                if (str[i] == lasttwo[0] && str[i + 1] == lasttwo[1])
                    count++;
            }

            return count;
        }

        public int Count9(int[] numbers)
        {
            int nines = 0;

            foreach (int a in numbers)
            {
                if (a == 9)
                    nines++;
            }

            return nines;
        }

        public bool ArrayFront9(int[] numbers)
        {
            bool found = false;

            if (numbers.Length >= 4)
                for (int i = 0; i < 4; i++)
                {
                    if (numbers[i] == 9)
                    {
                        found = true;
                        break;
                    }
                }

            return found;
        }

        public bool Array123(int[] numbers)
        {
            bool onetwothree = false;

            for (int i = 0; i < numbers.Length - 2; i++)
            {
                if (numbers[i] == 1 && numbers[i + 1] == 2 && numbers[i + 2] == 3)
                {
                    onetwothree = true;
                    break;
                }
            }

            return onetwothree;
        }

        public int SubStringMatch(string a, string b)
        {
            int subCount = 0;

            for (int i = 0; i < b.Length - 1; i++)
            {
                if (a.Substring(i, 2) == b.Substring(i, 2))
                    subCount++;
            }

            return subCount;
        }

        public string StringX(string str)
        {
            string noX = string.Empty;

            for (int i = 1; i < str.Length - 1; i++)
            {
                if (str[i] != 'x')
                {
                    noX += str[i];
                }
            }

            return str[0] + noX + str[str.Length - 1];
        }

        public string AltPairs(string str)
        {
            string pairs = string.Empty;

            for (int i = 0; i < str.Length - 1; i += 4)
            {
                pairs += str.Substring(i, 2);
            }

            if (str.Length % 2 != 0)
                pairs += str[str.Length - 1];

            return pairs;
        }

        public string DoNotYak(string str)
        {
            if (str.Contains("yak"))
            {
                str = str.Remove(str.IndexOf("yak"), 3);
            }

            return str;
        }

        public int Array667(int[] numbers)
        {
            int count = 0;

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                if (numbers[i] == 6 && (numbers[i + 1] == 6 || numbers[i + 1] == 7))
                    count++;
            }

            return count;
        }

        public bool NoTriples(int[] numbers)
        {
            bool noTrips = true;

            for (int i = 0; i < numbers.Length - 2; i++)
            {
                if ((numbers[i] == numbers[i + 1]) && (numbers[i + 1] == numbers[i + 2]))
                {
                    noTrips = false;
                    break;
                }
                else
                    noTrips = true;                    
            }

            return noTrips;
        }

        public bool Pattern51(int[] numbers)
        {
            bool pattern = false;

            for (int i = 0; i < numbers.Length - 2; i++)
            {
                if (numbers[i + 1] == (numbers[i] + 5) && numbers[i + 2] == (numbers[i] - 1))
                {
                    pattern = true;
                }
            }

            return pattern;
        }

    }
}
