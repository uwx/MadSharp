package nfm.open;

import java.util.concurrent.ThreadLocalRandom;

/* CheckPoints - Decompiled by JODE
 * Visit http://jode.sourceforge.net/
 */

class CheckPoints {
    //private CheckPoints() {}
    static int catchfin = 0;
    static final int[] clear = {
            0, 0, 0, 0, 0, 0, 0, 0
    };
    static final int[] dested = {
            0, 0, 0, 0, 0, 0, 0, 0
    };
    static int fn = 0;
    static final int[] fx = new int[5];
    static final int[] fy = new int[5];
    static final int[] fz = new int[5];
    static boolean haltall = false;
    static final float[] magperc = {
            0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F
    };
    static String maker = "";
    static int n = 0;
    static String name = "hogan rewish";
    static int nfix = 0;
    static int nlaps = 0;
    /**
     * "<strong>No</strong> <strong>T</strong>rees or <strong>B</strong>umps"<br>
     * Setting this to true will disable trees and bumps.
     */
    static boolean notb = false;
    static int nsp = 0;
    static int nto = 0;
    static final int[] omxz = new int[8];
    static final int[] onscreen = new int[8];
    /**
     * The X of every car in the stage.
     */
    static final int[] opx = new int[8];
    /**
     * The Z of every car in the stage.
     */
    static final int[] opz = new int[8];
    static int pcleared = 0;
    static int pcs = 0;
    static final int[] pos = {
            7, 7, 7, 7, 7, 7, 7, 7
    };
    static private int postwo = 0;
    static float prox = 0.0F;
    static int pubt = 0;
    static final boolean[] roted = new boolean[5];
    static final boolean[] special = new boolean[5];
    static int stage = (int) (ThreadLocalRandom.current().nextDouble() * 27.0) + 1;
    static int top20 = 0;
    static String trackname = "";
    static int trackvol = 200;
    static final int[] typ = new int[10000];
    static int wasted = 0;
    /**
     * You know when you add )p to the end of pieces? Their coordinates go here. )p basically adds "nodes" for where the AI goes. Therefore, {@link #x} and {@link #z} are the X and Z coordinates of track pieces with )p at the end of them.
     */
    static final int[] x = new int[10000];
    /**
     * You know when you add )p to the end of pieces? Their coordinates go here. )p basically adds "nodes" for where the AI goes. Therefore, {@link #x} and {@link #z} are the X and Z coordinates of track pieces with )p at the end of them.
     */
    static final int[] y = new int[10000];
    /**
     * You know when you add )p to the end of pieces? Their coordinates go here. )p basically adds "nodes" for where the AI goes. Therefore, {@link #x} and {@link #z} are the X and Z coordinates of track pieces with )p at the end of them.
     */
    static final int[] z = new int[10000];

    static void calprox() {
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

    static void checkstat(final Mad[] mads, final ContO[] contos, final int i, final int i0, final int i1) {
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

    static private int py(final int i, final int i11, final int i12, final int i13) {
        return (i - i11) * (i - i11) + (i12 - i13) * (i12 - i13);
    }
}
