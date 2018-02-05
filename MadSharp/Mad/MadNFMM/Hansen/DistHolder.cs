using TextRenderer = System.Windows.Forms.TextRenderer;

namespace Cum
{
    internal struct DistHolder
    {
        public int Id;
        public int Dist;

        public DistHolder(int id, int dist)
        {
            Dist = dist;
            Id = id;
        }
    }

    // http://mark-dot-net.blogspot.com/2009/10/looped-playback-in-net-with-naudio.html
}