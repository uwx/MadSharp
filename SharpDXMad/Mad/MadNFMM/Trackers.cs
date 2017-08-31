using boolean = System.Boolean;

namespace Cum
{
    internal class Trackers
    {
        //private Trackers() {}
        internal static readonly int[][] c = new int[75000][3];
        internal static readonly int[] dam = new int[75000];
        internal static readonly boolean[] decor = new boolean[75000];
        internal static int ncx = 0;
        internal static int ncz = 0;
        internal static readonly boolean[] notwall = new boolean[75000];
        internal static int nt = 0;
        internal static readonly int[] radx = new int[75000];
        internal static readonly int[] rady = new int[75000];
        internal static readonly int[] radz = new int[75000];
        internal static int[,][] sect = null;
        internal static readonly int[] skd = new int[75000];
        internal static int sx = 0;
        internal static int sz = 0;
        internal static readonly int[] x = new int[75000];
        internal static readonly int[] xy = new int[75000];
        internal static readonly int[] y = new int[75000];
        internal static readonly int[] z = new int[75000];
        internal static readonly int[] zy = new int[75000];

        internal static void devidetrackers(int i, int i0, int i1, int i2) {
            sect = null;
            sx = i;
            sz = i1;
            ncx = i0 / 3000;
            if (ncx <= 0)
            {
                ncx = 1;
            }
            ncz = i2 / 3000;
            if (ncz <= 0)
            {
                ncz = 1;
            }
            sect = new int[ncx,ncz][];
            for (int i3 = 0; i3 < ncx; i3++)
            {
                for (int i4 = 0; i4 < ncz; i4++)
                {
                    int i5 = sx + i3 * 3000 + 1500;
                    int i6 = sz + i4 * 3000 + 1500;
                    int[] ais  = new int[6700];
                    int i7 = 0;
                    for (int i8 = 0; i8 < nt; i8++)
                    {
                        int i9 = py(i5, x[i8], i6, z[i8]);
                        if (i9 < 20250000 && i9 > 0 && dam[i8] != 167)
                        {
                            ais[i7] = i8;
                            i7++;
                        }
                    }
                    if (i3 == 0 || i4 == 0 || i3 == ncx - 1 || i4 == ncz - 1)
                    {
                        for (int i10 = 0; i10 < nt; i10++)
                            if (dam[i10] == 167)
                            {
                                ais[i7] = i10;
                                i7++;
                            }
                    }
                    if (i7 == 0)
                    {
                        ais[i7] = 0;
                        i7++;
                    }
                    sect[i3,i4] = new int[i7];
                    HansenSystem.ArrayCopy( ais, 0, sect[i3,i4], 0, i7);
                }
            }
            for (int i12 = 0; i12 < nt; i12++)
                if (dam[i12] == 167)
                {
                    dam[i12] = 1;
                }
            ncx--;
            ncz--;
        }

        private static int py(int i, int i13, int i14, int i15) {
            return (i - i13) * (i - i13) + (i14 - i15) * (i14 - i15);
        }
    }
}