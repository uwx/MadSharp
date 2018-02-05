using System;

namespace Cum
{
    public static class StringShim
    {
        public static int Length(this string self)
        {
            return self.Length;
        }

        public static char CharAt(this string self, int at)
        {
            return self[at];
        }

        public static bool EqualsIgnoreCase(this string self, string other)
        {
            return self.Equals(other, StringComparison.OrdinalIgnoreCase);
        }

        public static string SubFromEnd(this string self, int amount)
        {
            return self.Substring(0, self.Length - amount);
        }
    }
}