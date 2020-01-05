using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warmups.BLL
{
    public class Logic
    {

        public bool GreatParty(int cigars, bool isWeekend)
        {
            bool partyTime = false;

            if (cigars >= 40)
            {
                if ((!isWeekend && cigars <= 60) || isWeekend)
                    partyTime = true;
            }

            return partyTime;
        }
        
        public int CanHazTable(int yourStyle, int dateStyle)
        {
            int getTable = 1;

            if (yourStyle <= 2 || dateStyle <= 2)
                getTable = 0;
            else if (yourStyle >= 8 || dateStyle >= 8)
                getTable = 2;

            return getTable;
        }

        public bool PlayOutside(int temp, bool isSummer)
        {
            bool outside = false;

            if (temp >= 60)
            {
                if ((!isSummer && temp <= 90) || (isSummer && temp <=100))
                    outside = true;
            }

            return outside;
        }
        
        public int CaughtSpeeding(int speed, bool isBirthday)
        {
            int getTicket = 2;

            if (isBirthday)
                speed -= 5;

            if (speed <= 60)
                getTicket = 0;
            else if (speed <= 80)
                getTicket = 1;            

            return getTicket;
        }
        
        public int SkipSum(int a, int b)
        {
            int sum = a + b;

            if (sum >= 10 && sum <= 19)
                sum = 20;

            return sum;
        }
        
        public string AlarmClock(int day, bool vacation)
        {
            string alarm = "10:00";

            if (!vacation)
            {
                if (day >= 1 && day <= 5)
                    alarm = "7:00";
            }
            else
                alarm = "off";

            return alarm;
        }
        
        public bool LoveSix(int a, int b)
        {
            int sum = a + b;

            if (a == 6 || b == 6 || sum == 6)
                return true;
            else
                return false;
        }
        
        public bool InRange(int n, bool outsideMode)
        {
            if (outsideMode && (n <= 1 || n >= 10) || (n >= 1 && n <= 10))
                return true;
            else
                return false;
        }
        
        public bool SpecialEleven(int n)
        {
            if (n % 11 == 0 || n % 11 == 1)
                return true;
            else
                return false;
        }
        
        public bool Mod20(int n)
        {
            if (n % 20 == 1 || n % 20 == 2)
                return true;
            else
                return false;
        }
        
        public bool Mod35(int n)
        {
            bool notBoth = false;

            if (n % 15 != 0 && (n % 3 == 0 || n % 5 == 0))
                notBoth = true;

            return notBoth;
        }
        
        public bool AnswerCell(bool isMorning, bool isMom, bool isAsleep)
        {
            if (isAsleep || (isMorning && !isMom))
                return false;
            else
                return true;
        }
        
        public bool TwoIsOne(int a, int b, int c)
        {
            int ab = a + b;
            int ac = a + c;
            int bc = b + c;
            if (ab == c || ac == b || bc == a)
                return true;
            else
                return false;

        }
        
        public bool AreInOrder(int a, int b, int c, bool bOk)
        {
            if (((a < b) || bOk) && (b < c))
                return true;
            else
                return false;
        }
        
        public bool InOrderEqual(int a, int b, int c, bool equalOk)
        {
            if (equalOk)
            {
                if (a <= b && b <= c)
                    return true;
                else
                    return false;
            }

            if (a < b && b < c)
                return true;
            else
                return false;
        }
        
        public bool LastDigit(int a, int b, int c)
        {
            int amod = a % 10;
            int bmod = b % 10;
            int cmod = c % 10;

            if (amod == bmod || amod == cmod || bmod == cmod)
                return true;
            else
                return false;
        }
        
        public int RollDice(int die1, int die2, bool noDoubles)
        {
            int sum = 0;

            if (noDoubles && die1 == die2)
            {
                die1 += 1;
            }

            sum = die1 + die2;
            return sum;
        }

    }
}
