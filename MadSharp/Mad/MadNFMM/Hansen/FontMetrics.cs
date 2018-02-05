using MadGame;
using SharpDX.DirectWrite;

namespace Cum
{
    public struct FontMetrics
    {
        private readonly TextFormat _textFormat;

        public FontMetrics(TextFormat font)
        {
            _textFormat = font;
        }

        public int StringWidth(string astring)
        {
            var layout = new TextLayout(G.FactoryDW, astring, _textFormat, 1024, _textFormat.FontSize);
            return (int)layout.Metrics.Width;
        }

        public int Height(string astring)
        {
            return (int)_textFormat.FontSize;
        }
    }
}