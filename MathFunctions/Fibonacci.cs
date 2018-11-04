using System;
using System.Numerics;
using MathFunctions.DataStructures;

namespace MathFunctions
{
    public static class Fibonacci
    {
        private static BigInteger FibonacciSimple(long x)
        {  
            BigInteger f0 = 0;
            BigInteger f1 = 1;
            if(x == 0)
                return f0;
            if(x==1)
                return f1;                
            BigInteger fnp= f1 + f0; 
            if(x==2)
                return fnp;
            for(long i = 2;i<x;i++)
            {
                f0 = f1;
                f1 = fnp;
                fnp = f1 + f0;
            }
            return fnp;
        }
        //This will return the pair F_x and F_{x+1}
        private static Pair<BigInteger> FibGet(long x)
        {
            if(x == 0)
            {
                return new Pair<BigInteger>(0,1);
            }
            var S = FibGet(x / 2);
            var fn = S.First;
            var fnp = S.Second;
            var f2n = fn * (2* fnp - fn);
            var f2np= (fnp*fnp)+(fn*fn);
            if(x%2==0)
                return new Pair<BigInteger>(f2n,f2np);
            else
                return new Pair<BigInteger>(f2np,f2n+f2np);
        }
        private static BigInteger FibonacciDoubling(long x)
        {
            if(x < 100)
                return FibonacciSimple(x);
            
            return FibGet(x).First;
        }

        public static BigInteger FibonacciVal(long x)
        {
            return FibonacciDoubling(x);
        }
        public static string FString(long x)
        {
            return FibonacciVal(x).ToString();
        }        
    }
}