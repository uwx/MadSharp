using System;
using boolean = System.Boolean;

namespace Cum {

/* CheckPoints - Decompiled by JODE
 * Visit http://jode.sourceforge.net/
 */

class CheckPoints {
    //private CheckPoints() {}
    internal static int catchfin = 0;
    internal static readonly int[] clear = {
            0, 0, 0, 0, 0, 0, 0, 0
    };
    internal static readonly int[] dested = {
            0, 0, 0, 0, 0, 0, 0, 0
    };
    internal static int fn = 0;
    internal static readonly int[] fx = new int[5];
    internal static readonly int[] fy = new int[5];
    internal static readonly int[] fz = new int[5];
    internal static boolean haltall = false;
    internal static readonly float[] magperc = {
            0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F
    };
    internal static String maker = "";
    internal static int n = 0;
    internal static String name = "hogan rewish";
    internal static int nfix = 0;
    internal static int nlaps = 0;
    /**
     * "<strong>No</strong> <strong>T</strong>rees or <strong>B</strong>umps"<br>
     * Setting this to true will disable trees and bumps.
     */
    internal static boolean notb = false;
    internal static int nsp = 0;
    internal static int nto = 0;
    internal static readonly int[] omxz = new int[8];
    internal static readonly int[] onscreen = new int[8];
    /**
     * The X of every car ain the stage.
     */
    internal static readonly int[] opx = new int[8];
    /**
     * The Z of every car ain the stage.
     */
    internal static readonly int[] opz = new int[8];
    internal static int pcleared = 0;
    internal static int pcs = 0;
    internal static readonly int[] pos = {
            7, 7, 7, 7, 7, 7, 7, 7
    };
    private static int postwo = 0;
    internal static float prox = 0.0F;
    internal static int pubt = 0;
    internal static readonly boolean[] roted = new boolean[5];
    internal static readonly boolean[] special = new boolean[5];
    internal static int stage = (int) (HansenRandom.Double() * 27.0) + 1;
    internal static int top20 = 0;
    internal static String trackname = "";
    internal static int trackvol = 200;
    internal static readonly int[] typ = new int[10000];
    internal static int wasted = 0;
    /**
     * You know when you add )p to the end of pieces? Their coordinates go here. )p basically adds "nodes" for where the AI goes. Therefore, {@link #x} and {@link #z} are the X and Z coordinates of track pieces with )p at the end of them.
     */
    internal static readonly int[] x = new int[10000];
    /**
     * You know when you add )p to the end of pieces? Their coordinates go here. )p basically adds "nodes" for where the AI goes. Therefore, {@link #x} and {@link #z} are the X and Z coordinates of track pieces with )p at the end of them.
     */
    internal static readonly int[] y = new int[10000];
    /**
     * You know when you add )p to the end of pieces? Their coordinates go here. )p basically adds "nodes" for where the AI goes. Therefore, {@link #x} and {@link #z} are the X and Z coordinates of track pieces with )p at the end of them.
     */
    internal static readonly int[] z = new int[10000];

    internal static void calprox() {
        int i = 0;
        for (int i9 = 0; i9 < n - 1; i9++) {
            for (int i10 = i9 + 1; i10 < n; i10++) {
                if (Math.abs(x[i9] - x[i10]) > i) {
                    i = Math.abs(x[i9] - x[i10]);
                }
                if (Math.abs(z[i9] - z[i10]) > i) {
                    i = Math.abs(z[i9] - z[i10]);
                }
            }
        }
        prox = i / 90.0F;
    }

    internal static void checkstat(Mad[] mads, ContO[] contos, int i, int i0, int i1) {
        if (!haltall) {
            pcleared = mads[i0].pcleared;
            for (int i2 = 0; i2 < i; i2++) {
                magperc[i2] = (float) mads[i2].hitmag / (float) mads[i2].stat.maxmag;
                if (magperc[i2] > 1.0F) {
                    magperc[i2] = 1.0F;
                }
                pos[i2] = 0;
                onscreen[i2] = contos[i2].dist;
                opx[i2] = contos[i2].x;
                opz[i2] = contos[i2].z;
                omxz[i2] = mads[i2].mxz;
                if (dested[i2] == 0) {
                    clear[i2] = mads[i2].clear;
                } else {
                    clear[i2] = -1;
                }
                mads[i2].outshakedam = mads[i2].shakedam;
                mads[i2].shakedam = 0;
            }
            for (int i3 = 0; i3 < i; i3++) {
                for (int i4 = i3 + 1; i4 < i; i4++)
                    if (clear[i3] != clear[i4]) {
                        if (clear[i3] < clear[i4]) {
                            pos[i3]++;
                        } else {
                            pos[i4]++;
                        }
                    } else {
                        int i5 = mads[i3].pcleared + 1;
                        if (i5 >= n) {
                            i5 = 0;
                        }
                        while (typ[i5] <= 0)
                            if (++i5 >= n) {
                                i5 = 0;
                            }
                        if (py(contos[i3].x / 100, x[i5] / 100, contos[i3].z / 100, z[i5] / 100) > py(contos[i4].x / 100, x[i5] / 100, contos[i4].z / 100, z[i5] / 100)) {
                            pos[i3]++;
                        } else {
                            pos[i4]++;
                        }
                    }
            }
            if (stage > 2) {
                for (int i6 = 0; i6 < i; i6++)
                    if (clear[i6] == nlaps * nsp && pos[i6] == 0)
                        if (i6 == i0) {
                            for (int i7 = 0; i7 < i; i7++)
                                if (pos[i7] == 1) {
                                    postwo = i7;
                                }
                            if (py(opx[i0] / 100, opx[postwo] / 100, opz[i0] / 100, opz[postwo] / 100) < 14000 && clear[i0] - clear[postwo] == 1) {
                                catchfin = 30;
                            }
                        } else if (pos[i0] == 1 && py(opx[i0] / 100, opx[i6] / 100, opz[i0] / 100, opz[i6] / 100) < 14000 && clear[i6] - clear[i0] == 1) {
                            catchfin = 30;
                            postwo = i6;
                        }
            }
        }
        wasted = 0;
        for (int i8 = 0; i8 < i; i8++)
            if ((i0 != i8 || i1 >= 2) && mads[i8].dest) {
                wasted++;
            }
        if (catchfin != 0 && i1 < 2) {
            catchfin--;
            if (catchfin == 0) {
                Record.cotchinow(postwo);
                Record.closefinish = pos[i0] + 1;
            }
        }
    }

    private static int py(int i, int i11, int i12, int i13) {
        return (i - i11) * (i - i11) + (i12 - i13) * (i12 - i13);
    }
}

}