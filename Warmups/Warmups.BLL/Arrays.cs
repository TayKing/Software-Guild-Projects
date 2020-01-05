using System;

namespace Warmups.BLL
{
    public class Arrays
    {

        public bool FirstLast6(int[] numbers)
        {
            if (numbers[0] == 6 || numbers[numbers.Length - 1] == 6)
                return true;
            else
                return false;
        }

        public bool SameFirstLast(int[] numbers)
        {
            if (numbers.Length >= 1 && (numbers[0] == numbers[numbers.Length - 1]))
                return true;
            else
                return false;
        }
        public int[] MakePi(int n)
        {
            var pi = Math.PI;
            var pistring = pi.ToString().Remove(1, 1);
            var newpi = new int[n];

            for (var i = 0; i < n; i++)
            {
                newpi[i] = int.Parse(pistring[i].ToString());
            }

            return newpi;
        }
        
        public bool CommonEnd(int[] a, int[] b)
        {
            if (a[0] == b[0] || a[a.Length - 1] == b[b.Length - 1])
                return true;
            else
                return false;
        }
        
        public int Sum(int[] numbers)
        {
            int sum = 0;

            foreach (int i in numbers)
            {
                sum += i;
            }

            return sum;
        }
        
        public int[] RotateLeft(int[] numbers)
        {
            int[] left = new int[numbers.Length];
            int first = numbers[0];
            Array.Copy(numbers, 1, left, 0, numbers.Length - 1);
            left[left.Length - 1] = first;

            return left;
        }

        public int[] Reverse(int[] numbers)
        {
            Array.Reverse(numbers);
            return numbers;
        }
        
        public int[] HigherWins(int[] numbers)
        {
            int biggest;

            if (numbers[0] > numbers[numbers.Length - 1])
                biggest = numbers[0];
            else
                biggest = numbers[numbers.Length - 1];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = biggest;
            }

            return numbers;
        }
        
        public int[] GetMiddle(int[] a, int[] b)
        {
            int[] mid = new int[2] {a[1],b[1]};
            return mid;
        }
        
        public bool HasEven(int[] numbers)
        {
            bool even = false;

            foreach (var i in numbers)
            {
                if (i % 2 == 0)
                    even = true;
            }

            return even;
        }
        
        public int[] KeepLast(int[] numbers)
        {
            int[] last = new int[numbers.Length * 2];
            last[last.Length - 1] = numbers[numbers.Length - 1];

            return last;
        }
        
        public bool Double23(int[] numbers)
        {
            int twos = 0;
            int threes = 0;
            bool doub = false;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == 2)
                    twos++;
                else if (numbers[i] == 3)
                    threes++;

                if (twos == 2 || threes == 2)
                    doub = true;
                else
                    doub = false;
            }

            return doub;
        }
        
        public int[] Fix23(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == 2 && numbers[i + 1] == 3)
                    numbers[i + 1] = 0;
            }

            return numbers;
        }

        public bool Unlucky1(int[] numbers)
        {
            bool noluck = false;

            if ((numbers[0] == 1 && numbers[1] == 3) || (numbers[1] == 1 && numbers[2] == 3) || (numbers[numbers.Length - 2] == 1 && numbers[numbers.Length - 1] == 3))
            {
                noluck = true;
            }

            return noluck;
        }
        
        public int[] Make2(int[] a, int[] b)
        {
            int[] join = new int[a.Length + b.Length];
            Array.Copy(a, join, a.Length);
            Array.Copy(b, 0, join, a.Length, b.Length);
            int[] two = new int[2];
            Array.Copy(join, two, 2);

            return two;
            
        }

    }
}
