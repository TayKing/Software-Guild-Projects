using System; 

namespace Warmups.BLL
{
    public class Conditionals
    {
        public bool AreWeInTrouble(bool aSmile, bool bSmile)
        {
            if (aSmile == bSmile)
                return true;
            else
                return false;
        }

        public bool CanSleepIn(bool isWeekday, bool isVacation)
        {
            if (isWeekday != true || isVacation == true)
                return true;
            else
                return false;
        }

        public int SumDouble(int a, int b)
        {
            int sum;
            if (a == b)
                sum = (a + b) * 2;
            else
                sum = a + b;

            return sum;
        }
        
        public int Diff21(int n)
        {
            int value;
            if (n > 21)
                value = (n - 21) * 2;
            else
                value = 21 - n;

            return value;
        }
        
        public bool ParrotTrouble(bool isTalking, int hour)
        {
            if (isTalking == true && (hour < 7 || hour > 20))
                return true;
            else
                return false;
        }
        
        public bool Makes10(int a, int b)
        {
            if (a + b == 10 || a == 10 || b == 10)
                return true;
            else
                return false;
        }
        
        public bool NearHundred(int n)
        {
            int num = 11;

            if (n >200)
            {
                num = n - 200;
            }
            else if ( n > 110 && n < 200)
            {
                num = 200 - n;
            }
            else if (n > 100 && n <= 110)
            {
                num = n - 100;
            }
            else if (n >=90)
            {
                num = 100 - n;
            }

            if (num <= 10)
                return true;
            else
                return false;
        }
        
        public bool PosNeg(int a, int b, bool negative)
        {
            if ((a < 0 && b < 0 && negative == true) || (a < 0 && b >= 0) || (a >= 0 && b < 0))
                return true;
            else
                return false;

        }
        
        public string NotString(string s)
        {
            if (s.Contains("not"))
                return s;
            else
                return "not " + s;
        }
        
        public string MissingChar(string str, int n)
        {
            int index = str.IndexOf(str[n]);
            if (index != -1)
                str = str.Remove(index, 1);

            return str;
        }
        
        public string FrontBack(string str)
        {
            if (str.Length < 2)
                return str;
            else
                return str[str.Length - 1] + str.Substring(1, str.Length - 2) + str[0];            
        }
        
        public string Front3(string str)
        {
            if (str.Length < 3)
                return str + str + str;
            else
                return str.Substring(0, 3) + str.Substring(0, 3) + str.Substring(0, 3);
        }
        
        public string BackAround(string str)
        {
            return str[str.Length - 1] + str + str[str.Length - 1];
        }
        
        public bool Multiple3or5(int number)
        {
            if (number % 3 == 0 || number % 5 == 0)
                return true;
            else
                return false;
        }
        
        public bool StartHi(string str)
        {
            bool hi = false;
            char[] delimiters = { ',', '!', '.', ' ' };
            string[] words = str.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            if (words[0] == "hi")
                hi = true;
            else
                hi = false;

            return hi;
        }
        
        public bool IcyHot(int temp1, int temp2)
        {
            if ((temp1 < 0 && temp2 > 100) || (temp2 < 0 && temp1 > 100))
                return true;
            else
                return false;
        }
        
        public bool Between10and20(int a, int b)
        {
            if ((a >= 10 && a <= 20) || (b >= 10 && b <= 20))
                return true;
            else
                return false;
        }
        
        public bool HasTeen(int a, int b, int c)
        {
            if ((a  >= 13 && a <= 19) || (b >= 13 && b <= 19) || (c >= 13 && c <= 19))
                return true;
            else
                return false;
        }
        
        public bool SoAlone(int a, int b)
        {
            if ((a >= 13 && a <= 19) && !(b >= 13 && b <= 19) || !(a >= 13 && a <= 19) && (b >= 13 && b <= 19))
                return true;
            else
                return false;
        }
        
        public string RemoveDel(string str)
        {
            int index = str.IndexOf("del");
            if (index != -1)
                return str.Remove(index, 3);
            else
                return str;
                
        }
        
        public bool IxStart(string str)
        {
            if (str.Substring(0, 3).Contains("ix"))
                return true;
            else
                return false;
        }
        
        public string StartOz(string str)
        {
            string found = string.Empty;

            if (str.Length >= 2)
            {

                string start = str.Substring(0, 2);
                string oz = "oz";

                for (int i = 0; i < start.Length; i++)
                {
                    if (start[i] == oz[i])
                        found += start[i];
                }
            }
            return found;
        }
        
        public int Max(int a, int b, int c)
        {
            return Math.Max(a, Math.Max(b, c));
        }
        
        public int Closer(int a, int b)
        {
            int aValue = Math.Abs(a - 10);
            int bValue = Math.Abs(b - 10);
            int close = 0;

            if (aValue == bValue)
                close = 0;
            else if (aValue > bValue)
                close = b;
            else
                close = a;

            return close;
        }
        
        public bool GotE(string str)
        {
            int count = 0;

            foreach (char s in str)
                if (s == 'e')
                    count++;

            if (count > 0 && count < 4)
                return true;
            else
                return false;
        }

        public string EndUp(string str)
        {
            string end;
            int upEnd = str.Length - 3;
            if (str.Length < 3)
                end = str.ToUpper();
            else
                end = str.Substring(0, upEnd) + str.Substring(upEnd).ToUpper();

            return end;
        }
        
        public string EveryNth(string str, int n)
        {
            string nth = string.Empty;

            for (int i = 0; i < str.Length; i += n)
            {
                nth += str[i];
            }

            return nth;
        }
    }
}
