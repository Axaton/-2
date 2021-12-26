using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibMatrix;
namespace Library_10
{
    public static class SqrtValue
    {
        public static string GetSqrtMatrix(this MyMatrix myarray)
        {
            string[] result = new string[myarray.Length];

            for (int i = 0; i < myarray.Length; i++)
            {
                if (myarray[i] > 0)
                    result[i] += Math.Sqrt(myarray[i]) + " ";
            }
            return string.Join(" ", result); 
        }
    }
}
