using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRM_262_DIV_2
{
    public class DivToZero
    {
        /*
         * You are given an integer num from which you should replace the last two digits such that the resulting number
         * is divisible by factor and is also the smallest possible number. Return the two replacement digits as a string. 
         * 
         * For instance:  
         * 
         * if num = 275, and factor = 5, you would return "00" because 200 is divisible by 5.
         * if num = 1021, and factor = 11, you would return "01" because 1001 is divisible by 11.
         * if num = 70000, and factor = 17, you would return "06" because 70006 is divisible by 17.
        */

        string lastTwo(int num, int factor)
        { 
            // Convert number so it finishes in 00
            num = num - (num % 100);

            // returning value has to be devisible by "factor"... and it has to be the smallest possible number
            while (num % factor != 0)
            {
                num++;
            }

            // return last two digits as string
            string lastTwoStr = num.ToString();
            lastTwoStr = lastTwoStr.Substring(lastTwoStr.Length - 2);
            
            return lastTwoStr;
        }

        static void Main()
        {
            var divToZero = new DivToZero();

            Console.WriteLine(divToZero.lastTwo(275, 5));
            Console.WriteLine(divToZero.lastTwo(1021, 11));
            Console.WriteLine(divToZero.lastTwo(70000, 17));

            Console.Read();
        }
    }
}
