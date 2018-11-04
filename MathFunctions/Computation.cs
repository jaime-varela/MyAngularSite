using System;
using System.Numerics;

namespace MathFunctions
{
    public static class Computation
    {
        public static decimal SquareRoot(decimal v)
        {
            decimal x0 = v / 2.0m;
            decimal xn = (0.5m)*(x0 + (v / x0));
            while(Math.Abs(xn - x0) > 1e-28m )
            {
                x0 = xn;
                xn = (0.5m)*(x0 + (v / x0));
            }
            return xn;
        }

        
        

    }
}
