using System;
using System.Numerics;

namespace MathFunctions
{
    public static class BinomialCoefficient
    {
        public static BigInteger Binomial(long n, long k)
        {
            if(k >= n)
                throw new ArgumentException("n must be greater than k");
            if(n > 2*k)
                return (Factorial.FRec(n-k+1,n))/(Factorial.FBigInt(k));
            else
                return (Factorial.FRec(k+1,n))/(Factorial.FBigInt(n-k));
        }

        public static string BinomialString(long n,long k)
        {
            return Binomial(n,k).ToString();
        }
    }
}