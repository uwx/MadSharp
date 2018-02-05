using System;
using System.Collections.Generic;
using SharpDX.DirectWrite;

namespace Cum
{
    public static class Fonts
    {
        private static readonly Dictionary<Font, CachedFont> Dict = new Dictionary<Font, CachedFont>();

        public static CachedFont GetOrCompute(Font fontCached, Func<(TextFormat, FontMetrics)> func)
        {
            if (Dict.ContainsKey(fontCached))
            {
                return Dict[fontCached];
            }
            return Dict[fontCached] = new CachedFont(func());
        }
    }
}