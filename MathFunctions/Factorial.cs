using System;
using System.Numerics;

namespace MathFunctions
{
    public static class Factorial
    {
        public static long FInt(long x)
        {
            if(x > 20 || x < 0)
            {
                return -1;
            }
            if(x == 0)
                return 1;
            if(x <= 2)
                return x;
            else
                return FInt(x-1) * x;
        }

        public static string FString(long x)
        {
            if(x < 0)
                return "Integer must be greater than or equal to zero";
            return FBigInt(x).ToString();
        }

        public static BigInteger FBigInt(long x)
        {
            BigInteger posInteger = x;
            if(x < 20)
                return FInt(x);
            if(x < 2000)
            { 
                for(long i = x-1;i > 1;i--)
                {
                    posInteger *= i;
                }
                return posInteger;
            }
            else
            {
                return FRec(1,x);
            }
        }
        // This will return (beg) * (beg+1) ... (end)
        public static BigInteger FRec(long beg,long end)
        {
            long l = (beg + end)/2;
            if(beg==end)
                return beg;
            if(end<beg)
                return 1;
            else
                return FRec(beg,l)*FRec(l+1,end);
        }
    }
}