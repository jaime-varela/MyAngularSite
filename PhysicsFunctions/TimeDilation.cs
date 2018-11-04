using System;
using MathFunctions;

namespace PhysicsFunctions
{
    public static class TimeDilation
    {
        /// <summary>
        /// This function will return dialated time given a ship time or a planet (stationary) time
        /// </summary>
        /// <input> velocity in percentage of the speed of light ( 0 < v < 1), time (arbitrary units), isShip is a bool which is true if your input is the ship time and false otherwise.</input>
        /// <returns>the desired time</returns>
        public static decimal TwinParadox(decimal velocity, decimal time,bool isShip)
        {
            if(isShip)
            {                
                return time / (Computation.SquareRoot(1-velocity) * Computation.SquareRoot(1+velocity));
            }
            else
            {
                return time * (Computation.SquareRoot(1-velocity) * Computation.SquareRoot(1+velocity));
            }
        }

        public static decimal BlackHole(decimal distanceRatio, decimal time, bool isNear)
        {
            var rsoverr = 1.0m / distanceRatio;
            if(isNear)
            {
                return time / Computation.SquareRoot(1-rsoverr);
            }
            else
            {
                return time * Computation.SquareRoot(1-rsoverr);
            }
        }

    }
}
