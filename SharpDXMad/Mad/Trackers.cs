namespace MadGame
{
    public class Trackers
    {
        public Trackers()
        {
            x = new int[100];
            y = new int[100];
            z = new int[100];
            xy = new int[100];
            zy = new int[100];
            c = new int[100][];
            for (var i = 0; i < 100; i++) c[i] = new int[3];
            radx = new int[100];
            radz = new int[100];
            _in = new bool[100];
            nt = 0;
        }

        public void prepare()
        {
            for (var i = 0; i < nt; i++)
                _in[i] = false;
        }

        internal int[] x;
        internal int[] y;
        internal int[] z;
        internal int[] xy;
        internal int[] zy;
        internal int[][] c;
        internal int[] radx;
        internal int[] radz;
        internal bool[] _in;
        internal int nt;
    }
}