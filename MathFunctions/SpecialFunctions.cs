using SF = MathNet.Numerics.SpecialFunctions;

namespace MathFunctions
{
    //TODO: write my own special functions and stop using MathNet
    public static class SpecialFunctions
    {
        public static double Gamma(double x)
        {
            return SF.Gamma(x);
        }
        public static double GammaLn(double x)
        {
            return SF.GammaLn(x);
        }
        public static double ExponentialIntegral(double x, int n)
        {
            return SF.ExponentialIntegral(x,n);
        }
    }
}