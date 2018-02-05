namespace Cum
{
    public struct Font
    {
        internal string FontName;
        private int _flags;
        internal int Size;

        public Font(string fontName, int flags, int size)
        {
            FontName = fontName;
            _flags = flags;
            Size = size;
        }
    }
}