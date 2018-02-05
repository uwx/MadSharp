using SharpDX.DirectWrite;

namespace Cum
{
    public struct CachedFont
    {
        public readonly TextFormat Format;
        public FontMetrics Metrics;

        public CachedFont((TextFormat, FontMetrics) res)
        {
            Format = res.Item1;
            Metrics = res.Item2;
        }
    }
}