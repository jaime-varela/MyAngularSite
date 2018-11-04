
using System;

namespace ParseUtilities
{
    public static class TryParser
    {
        public static Tuple<bool,long> TryLongParse(string Try,long max)
        {
            bool res = true;
            long result = 0;
            try
            {
                result = Convert.ToInt64(Try);
                if(result > max)
                    res = false;
            }
            catch(Exception e)
            {
                res = false;
                //throw new ArgumentException("bad integer");
            }
            var RESULT = new Tuple<bool,long>(res,result);
            return RESULT;
        }
        public static Tuple<bool,double> TryDoubleParse(string Try)
        {
            bool res = true;
            double result = 0;
            try
            {
                result = Convert.ToDouble(Try);
            }
            catch(Exception e)
            {
                res = false;
            }
            var RESULT = new Tuple<bool,double>(res,result);
            return RESULT;
        }

        ///<description> attepts to parse number into a decimal and checks if number is within the range [min,max]
        ///<result> a tuple whose bool is true/false if the parse and check passed/failed. The decimal element is the parse result.
        public static Tuple<bool,decimal> TryDecimalParse(string number,decimal min,decimal max = Decimal.MaxValue)
        {
            bool res = true;
            decimal result = 0m;
            try
            {
                result = Convert.ToDecimal(number);
                if(result >= max || result <= min)
                    res = false;
            }
            catch(Exception e)
            {
                res = false;
            }
            var RESULT = new Tuple<bool,decimal>(res,result);
            return RESULT;
        }

    }

}