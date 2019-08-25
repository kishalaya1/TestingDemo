using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingDemo

{
    public class Demonstration
    {

        private List<int> lstwholeNo = new List<int>();

        /// <summary>
        /// add two nos - public func
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int Add(int x, int y)
        {
            return x + y;
        }

        /// <summary>
        /// multiply two nos - private func
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private int Multiply(int x, int y)
        {
            return x * y;
        }

        /// <summary>
        /// check if no is even - public static func
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static bool IsEven(int x)
        {
            return (x % 2 == 0);
        }

        /// <summary>
        /// calculate percentage x of y - private static func
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private static decimal CalculatePercentage(int x, int y)
        {
            decimal percentage = (x * 100) / y;
            return percentage;
        }

        /// <summary>
        /// check and save list of whole nos
        /// private static void func setting 
        /// value of class level private variable         
        /// </summary>
        /// <param name="lstNos"></param>
        private void SetWholeNo(List<int> lstNos)
        {
            foreach (var no in lstNos)
            {
                if (no >= 0)
                {
                    lstwholeNo.Add(no);
                }
            }
        }
    }
}

