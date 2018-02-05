using System;

namespace Cum
{
    public static class HMath
    {
        public static int SafeAbs(int value)
        {
            return value == int.MinValue ? int.MaxValue : Math.Abs(value);
        }
    }
}