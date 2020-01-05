using System;

namespace Warmups.BLL
{
    public class Strings
    {

        public string SayHi(string name)
        {
            return "Hello " + name + "!";
        }

        public string Abba(string a, string b)
        {
            return a+b+b+a;
        }

        public string MakeTags(string tag, string content)
        {
            return ($"<{tag}>{content}</{tag}>");
        }

        public string InsertWord(string container, string word)
        {
            string c1,c2,wordInserted;

            c1 = container.Substring(0, 2);
            c2 = container.Substring(2, 2);
            wordInserted = c1 + word + c2;

            return wordInserted;
        }

        public string MultipleEndings(string str)
        {
            string ending;
            int lastTwo;
            lastTwo = str.Length - 2;
            ending = str.Remove(0, lastTwo) + str.Remove(0, lastTwo) + str.Remove(0, lastTwo);

            return ending;
        }

        public string FirstHalf(string str)
        {
            string half;
            int num;
            num = str.Length / 2;
            half = str.Remove(num);

            return half;
        }

        public string TrimOne(string str)
        {
            string trimmed = null;

            for (int i = 1; i < str.Length - 1; i++)
            {
               trimmed += str[i];
            }

            return trimmed;
        }

        public string LongInMiddle(string a, string b)
        {
            string longer;
            string shorter;

            if (a.Length < b.Length)
            {
                shorter = a;
                longer = b;
            }
            else
            {
                shorter = b;
                longer = a;
            }

            string sls = shorter + longer + shorter;

            return sls;
        }

        public string RotateLeft2(string str)
        {
            return str.Substring(2, str.Length - 2) + str.Substring(0,2);
        }

        public string RotateRight2(string str)
        {
            return str.Substring(str.Length - 2, 2) + str.Substring(0, str.Length - 2);
        }

        public string TakeOne(string str, bool fromFront)
        {
            char printchar;

            if (fromFront == true)
                printchar = str[0];
            else
                printchar = str[str.Length - 1];
            string one = printchar.ToString();

            return one;
        }

        public string MiddleTwo(string str)
        {
            int mid = (str.Length - 2) / 2;

            return str.Substring(mid, 2);
        }

        public bool EndsWithLy(string str)
        {
            bool truefalse;

            if (str.Contains("ly"))
                truefalse = true;
            else
                truefalse = false;

            return truefalse;
        }

        public string FrontAndBack(string str, int n)
        {
            return str.Substring(0, n) + str.Substring(str.Length - n, n);
        }

        public string TakeTwoFromPosition(string str, int n)
        {
            if (n > (str.Length - 2))
                n = 0;

            return str.Substring(n, 2);

        }

        public bool HasBad(string str)
        {
            bool truefalse;

            if (str.Length > 2 && str.Substring(0, 4).Contains("bad"))
                truefalse = true;
            else
                truefalse = false;

            return truefalse;
        }

        public string AtFirst(string str)
        {
            while (str.Length < 2)
            {
                str += "@";
            }
            str = str.Substring(0, 2);

            return str;

        }

        public string LastChars(string a, string b)
        {
            if (string.IsNullOrEmpty(a))
                a = "@";

            if (string.IsNullOrEmpty(b))
                b = "@";

            string last = a.Substring(0, 1) + b.Substring(b.Length - 1, 1);

            return last;
        }

        public string ConCat(string a, string b)
        {
            string cat = null;

            if (string.IsNullOrEmpty(a))
            {
                cat = b;
            }

            else if (string.IsNullOrEmpty(b))
            {
                cat = a;
            }

            else if (a[a.Length - 1] == b[0])
            {
                cat = a.Remove(a.Length - 1) + b;
            }
            else
            {
                cat = a + b;
            }

            return cat;
        }

        public string SwapLast(string str)
        {
            if (str.Length < 2)
            {
                return str;
            }
            else
            {
                char ftl = str[str.Length - 2];
                char ltf = str[str.Length - 1];
                string swap = ltf.ToString() + ftl.ToString();
                return (str.Substring(0, str.Length - 2)) + swap;
            }
        }

        public bool FrontAgain(string str)
        {
            string a = str.Substring(0, 2);
            string b = str.Substring(str.Length - 2, 2);

            if (a == b)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string MinCat(string a, string b)
        {
            string shorter;

            if (a.Length > b.Length)
            {
                shorter = a.Substring(a.Length - b.Length);
                return shorter + b;
            }
            else
            {
                shorter = b.Substring(b.Length - a.Length);
                return a + shorter;
            }
        }

        public string TweakFront(string str)
        {
            string front = string.Empty;

            if (str.IndexOf("a") == 0 && str.IndexOf("b") == 1)
            {
                front = "ab";
            }
            else if (str.IndexOf("a") == 0)
            {
                front = "a";
            }
            else if (str.IndexOf("b") == 1)
            {
                front = "b";
            }

            if (string.IsNullOrEmpty(str))
                return front;
            else
                return front + str.Substring(2);
        }

        public string StripX(string str)
        {
            return str.Trim(new char[] { 'x' });
        }
    }
}
