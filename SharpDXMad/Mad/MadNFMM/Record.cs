package nfm.open;
/* Record - Decompiled by JODE
 * Visit http://jode.sourceforge.net/
 */
import java.awt.Color;

class Record {
    static final ContO[][] car = new ContO[6][8];
    static int caught = 0;
    static private final int[] checkpoint = new int[300];
    static int closefinish = 0;
    static final int[] cntdest = new int[8];
    static private int cntf = 50;
    static final int[] dest = new int[8];
    static final int[] fix = new int[8];
    static boolean hcaught = false;
    static private final int[] hcheckpoint = new int[300];
    static private final int[] hdest = {
            -1, -1, -1, -1, -1, -1, -1, -1
    };
    static final int[] hfix = {
            -1, -1, -1, -1, -1, -1, -1, -1
    };
    static private final boolean[] hlastcheck = new boolean[300];
    static private final int[][][] hmagx = new int[8][4][7];
    static private final int[][][] hmagy = new int[8][4][7];
    static private final int[][][] hmagz = new int[8][4][7];
    static private final boolean[][] hmtouch = new boolean[8][7];
    static private final float[][] hrcx = new float[8][200];
    static private final float[][] hrcy = new float[8][200];
    static private final float[][] hrcz = new float[8][200];
    static private final int[][] hrspark = new int[8][200];
    static private final int[][][] hrx = new int[8][4][7];
    static private final int[][][] hry = new int[8][4][7];
    static private final int[][][] hrz = new int[8][4][7];
    static private final int[][][] hscx = new int[8][20][30];
    static private final int[][][] hscz = new int[8][20][30];
    static private final float[][][] hsmag = new float[8][20][30];
    static private final int[][] hsprk = new int[8][200];
    static private final int[] hsquash = {
            0, 0, 0, 0, 0, 0, 0, 0
    };
    static private final int[][] hsrx = new int[8][200];
    static private final int[][] hsry = new int[8][200];
    static private final int[][] hsrz = new int[8][200];
    static private final int[][][] hsspark = new int[8][20][30];
    static private final int[][][] hsx = new int[8][20][30];
    static private final int[][][] hsy = new int[8][20][30];
    static private final int[][][] hsz = new int[8][20][30];
    static private final int[][] hwxz = new int[300][8];
    static private final int[][] hwzy = new int[300][8];
    static private final int[][] hx = new int[300][8];
    static private final int[][] hxy = new int[300][8];
    static private final int[][] hxz = new int[300][8];
    static private final int[][] hy = new int[300][8];
    static private final int[][] hz = new int[300][8];
    static private final int[][] hzy = new int[300][8];
    static private final boolean[] lastcheck = new boolean[300];
    static private int lastfr = 0;
    static private final int[][][] magx = new int[8][4][7];
    static private final int[][][] magy = new int[8][4][7];
    static private final int[][][] magz = new int[8][4][7];
    static private final boolean[][] mtouch = new boolean[8][7];
    static private final int[] nr = new int[8];
    static private final int[][] nrx = new int[8][4];
    static private final int[][] nry = new int[8][4];
    static private final int[][] nrz = new int[8][4];
    static private final int[][] ns = new int[8][20];
    static final ContO[] ocar = new ContO[8];
    static int powered = 0;
    static private boolean prepit = true;
    static private final float[][] rcx = new float[8][200];
    static private final float[][] rcy = new float[8][200];
    static private final float[][] rcz = new float[8][200];
    static private final int[][] rspark = new int[8][200];
    static private final int[][][] rx = new int[8][4][7];
    static private final int[][][] ry = new int[8][4][7];
    static private final int[][][] rz = new int[8][4][7];
    static private final int[][][] scx = new int[8][20][30];
    static private final int[][][] scz = new int[8][20][30];
    static private final float[][][] smag = new float[8][20][30];
    static private final int[][] sprk = new int[8][200];
    static private final int[][] squash = new int[6][8];
    static private final int[][] srx = new int[8][200];
    static private final int[][] sry = new int[8][200];
    static private final int[][] srz = new int[8][200];
    static private final int[][][] sspark = new int[8][20][30];
    static final ContO[] starcar = new ContO[8];
    static private final int[][][] sx = new int[8][20][30];
    static private final int[][][] sy = new int[8][20][30];
    static private final int[][][] sz = new int[8][20][30];
    static int wasted = 0;
    static int whenwasted = 0;
    static private final int[][] wxz = new int[300][8];
    static private final int[][] wzy = new int[300][8];
    static private final int[][] x = new int[300][8];
    static private final int[][] xy = new int[300][8];
    static private final int[][] xz = new int[300][8];
    static private final int[][] y = new int[300][8];
    static private final int[][] z = new int[300][8];
    static private final int[][] zy = new int[300][8];

    Record() {
        caught = 0;
        cotchinow(0);
    }

    static private void chipx(final int i, float f, final ContO conto, final Mad mad) {
        if (Math.abs(f) > 100.0F) {
            if (f > 100.0F) {
                f -= 100.0F;
            }
            if (f < -100.0F) {
                f += 100.0F;
            }
            for (int i68 = 0; i68 < conto.npl; i68++) {
                float f69 = 0.0F;
                for (int i70 = 0; i70 < conto.p[i68].n; i70++)
                    if (conto.p[i68].wz == 0 && py(conto.keyx[i], conto.p[i68].ox[i70], conto.keyz[i], conto.p[i68].oz[i70]) < mad.stat.clrad) {
                        f69 = f / 20.0F * Medium.random();
                    }
                if (f69 != 0.0F && Math.abs(f69) >= 1.0F) {
                    conto.p[i68].chip = 1;
                    conto.p[i68].ctmag = f69;
                }
            }
        }
    }

    static private void chipz(final int i, float f, final ContO conto, final Mad mad) {
        if (Math.abs(f) > 100.0F) {
            if (f > 100.0F) {
                f -= 100.0F;
            }
            if (f < -100.0F) {
                f += 100.0F;
            }
            for (int i71 = 0; i71 < conto.npl; i71++) {
                float f72 = 0.0F;
                for (int i73 = 0; i73 < conto.p[i71].n; i73++)
                    if (conto.p[i71].wz == 0 && py(conto.keyx[i], conto.p[i71].ox[i73], conto.keyz[i], conto.p[i71].oz[i73]) < mad.stat.clrad) {
                        f72 = f / 20.0F * Medium.random();
                    }
                if (f72 != 0.0F && Math.abs(f72) >= 1.0F) {
                    conto.p[i71].chip = 1;
                    conto.p[i71].ctmag = f72;
                }
            }
        }
    }

    static void cotchinow(final int i) {
        if (caught >= 300) {
            wasted = i;
            for (int i6 = 0; i6 < 8; i6++) {
                starcar[i6] = new ContO(car[0][i6], 0, 0, 0, 0);
                hsquash[i6] = squash[0][i6];
                hfix[i6] = fix[i6];
                hdest[i6] = dest[i6];
            }
            for (int i7 = 0; i7 < 300; i7++) {
                for (int i8 = 0; i8 < 8; i8++) {
                    hx[i7][i8] = x[i7][i8];
                    hy[i7][i8] = y[i7][i8];
                    hz[i7][i8] = z[i7][i8];
                    hxy[i7][i8] = xy[i7][i8];
                    hzy[i7][i8] = zy[i7][i8];
                    hxz[i7][i8] = xz[i7][i8];
                    hwxz[i7][i8] = wxz[i7][i8];
                    hwzy[i7][i8] = wzy[i7][i8];
                }
                hcheckpoint[i7] = checkpoint[i7];
                hlastcheck[i7] = lastcheck[i7];
            }
            for (int i9 = 0; i9 < 8; i9++) {
                for (int i10 = 0; i10 < 20; i10++) {
                    for (int i11 = 0; i11 < 30; i11++) {
                        hsspark[i9][i10][i11] = sspark[i9][i10][i11];
                        hsx[i9][i10][i11] = sx[i9][i10][i11];
                        hsy[i9][i10][i11] = sy[i9][i10][i11];
                        hsz[i9][i10][i11] = sz[i9][i10][i11];
                        hsmag[i9][i10][i11] = smag[i9][i10][i11];
                        hscx[i9][i10][i11] = scx[i9][i10][i11];
                        hscz[i9][i10][i11] = scz[i9][i10][i11];
                    }
                }
                for (int i12 = 0; i12 < 200; i12++) {
                    hrspark[i9][i12] = rspark[i9][i12];
                    hsprk[i9][i12] = sprk[i9][i12];
                    hsrx[i9][i12] = srx[i9][i12];
                    hsry[i9][i12] = sry[i9][i12];
                    hsrz[i9][i12] = srz[i9][i12];
                    hrcx[i9][i12] = rcx[i9][i12];
                    hrcy[i9][i12] = rcy[i9][i12];
                    hrcz[i9][i12] = rcz[i9][i12];
                }
            }
            for (int i13 = 0; i13 < 8; i13++) {
                for (int i14 = 0; i14 < 4; i14++) {
                    for (int i15 = 0; i15 < 7; i15++) {
                        hry[i13][i14][i15] = ry[i13][i14][i15];
                        hmagy[i13][i14][i15] = magy[i13][i14][i15];
                        hrx[i13][i14][i15] = rx[i13][i14][i15];
                        hmagx[i13][i14][i15] = magx[i13][i14][i15];
                        hrz[i13][i14][i15] = rz[i13][i14][i15];
                        hmagz[i13][i14][i15] = magz[i13][i14][i15];
                    }
                }
            }
            for (int i16 = 0; i16 < 8; i16++) {
                System.arraycopy(mtouch[i16], 0, hmtouch[i16], 0, 7);
            }
            hcaught = true;
        }
    }

    static void play(final ContO conto, final Mad mad, final int i, final int i30) {
        conto.x = x[i30][i];
        conto.y = y[i30][i];
        conto.z = z[i30][i];
        conto.zy = zy[i30][i];
        conto.xy = xy[i30][i];
        conto.xz = xz[i30][i];
        conto.wxz = wxz[i30][i];
        conto.wzy = wzy[i30][i];
        if (i == 0) {
            Medium.checkpoint = checkpoint[i30];
            Medium.lastcheck = lastcheck[i30];
        }
        if (i30 == 0) {
            cntdest[i] = 0;
        }
        if (dest[i] == i30) {
            cntdest[i] = 7;
        }
        if (i30 == 0 && dest[i] < -1) {
            for (int i31 = 0; i31 < conto.npl; i31++)
                if (conto.p[i31].wz == 0 || conto.p[i31].gr == -17 || conto.p[i31].gr == -16) {
                    conto.p[i31].embos = 13;
                }
        }
        if (cntdest[i] != 0) {
            for (int i32 = 0; i32 < conto.npl; i32++)
                if (conto.p[i32].wz == 0 || conto.p[i32].gr == -17 || conto.p[i32].gr == -16) {
                    conto.p[i32].embos = 1;
                }
            cntdest[i]--;
        }
        for (int i33 = 0; i33 < 20; i33++) {
            for (int i34 = 0; i34 < 30; i34++)
                if (sspark[i][i33][i34] == i30) {
                    conto.stg[i33] = 1;
                    conto.sx[i33] = sx[i][i33][i34];
                    conto.sy[i33] = sy[i][i33][i34];
                    conto.sz[i33] = sz[i][i33][i34];
                    conto.osmag[i33] = smag[i][i33][i34];
                    conto.scx[i33] = scx[i][i33][i34];
                    conto.scz[i33] = scz[i][i33][i34];
                }
        }
        for (int i35 = 0; i35 < 200; i35++)
            if (rspark[i][i35] == i30) {
                conto.sprk = sprk[i][i35];
                conto.srx = srx[i][i35];
                conto.sry = sry[i][i35];
                conto.srz = srz[i][i35];
                conto.rcx = rcx[i][i35];
                conto.rcy = rcy[i][i35];
                conto.rcz = rcz[i][i35];
            }
        for (int i36 = 0; i36 < 4; i36++) {
            for (int i37 = 0; i37 < 7; i37++) {
                if (ry[i][i36][i37] == i30) {
                    regy(i36, magy[i][i36][i37], mtouch[i][i37], conto, mad);
                }
                if (rx[i][i36][i37] == i30) {
                    regx(i36, magx[i][i36][i37], conto, mad);
                }
                if (rz[i][i36][i37] == i30) {
                    regz(i36, magz[i][i36][i37], conto, mad);
                }
            }
        }
    }

    static void playh(final ContO conto, final Mad mad, final int i, final int i38, final int i39) {
        conto.x = hx[i38][i];
        conto.y = hy[i38][i];
        conto.z = hz[i38][i];
        conto.zy = hzy[i38][i];
        conto.xy = hxy[i38][i];
        conto.xz = hxz[i38][i];
        conto.wxz = hwxz[i38][i];
        conto.wzy = hwzy[i38][i];
        if (i == i39) {
            Medium.checkpoint = hcheckpoint[i38];
            Medium.lastcheck = hlastcheck[i38];
        }
        if (i38 == 0) {
            cntdest[i] = 0;
        }
        if (hdest[i] == i38) {
            cntdest[i] = 7;
        }
        if (i38 == 0 && hdest[i] < -1) {
            for (int i40 = 0; i40 < conto.npl; i40++)
                if (conto.p[i40].wz == 0 || conto.p[i40].gr == -17 || conto.p[i40].gr == -16) {
                    conto.p[i40].embos = 13;
                }
        }
        if (cntdest[i] != 0) {
            for (int i41 = 0; i41 < conto.npl; i41++)
                if (conto.p[i41].wz == 0 || conto.p[i41].gr == -17 || conto.p[i41].gr == -16) {
                    conto.p[i41].embos = 1;
                }
            cntdest[i]--;
        }
        for (int i42 = 0; i42 < 20; i42++) {
            for (int i43 = 0; i43 < 30; i43++)
                if (hsspark[i][i42][i43] == i38) {
                    conto.stg[i42] = 1;
                    conto.sx[i42] = hsx[i][i42][i43];
                    conto.sy[i42] = hsy[i][i42][i43];
                    conto.sz[i42] = hsz[i][i42][i43];
                    conto.osmag[i42] = hsmag[i][i42][i43];
                    conto.scx[i42] = hscx[i][i42][i43];
                    conto.scz[i42] = hscz[i][i42][i43];
                }
        }
        for (int i44 = 0; i44 < 200; i44++)
            if (hrspark[i][i44] == i38) {
                conto.sprk = hsprk[i][i44];
                conto.srx = hsrx[i][i44];
                conto.sry = hsry[i][i44];
                conto.srz = hsrz[i][i44];
                conto.rcx = hrcx[i][i44];
                conto.rcy = hrcy[i][i44];
                conto.rcz = hrcz[i][i44];
            }
        for (int i45 = 0; i45 < 4; i45++) {
            for (int i46 = 0; i46 < 7; i46++) {
                if (hry[i][i45][i46] == i38 && lastfr != i38) {
                    regy(i45, hmagy[i][i45][i46], hmtouch[i][i46], conto, mad);
                }
                if (hrx[i][i45][i46] == i38)
                    if (lastfr != i38) {
                        regx(i45, hmagx[i][i45][i46], conto, mad);
                    } else {
                        chipx(i45, hmagx[i][i45][i46], conto, mad);
                    }
                if (hrz[i][i45][i46] == i38)
                    if (lastfr != i38) {
                        regz(i45, hmagz[i][i45][i46], conto, mad);
                    } else {
                        chipz(i45, hmagz[i][i45][i46], conto, mad);
                    }
            }
        }
        lastfr = i38;
    }

    static private int py(final int i, final int i74, final int i75, final int i76) {
        return (i - i74) * (i - i74) + (i75 - i76) * (i75 - i76);
    }

    static void rec(final ContO conto, final int i, final int i18, final int i19, final int i20, final int i21) {
        if (i == i21) {
            caught++;
        }
        if (cntf == 50) {
            for (int i22 = 0; i22 < 5; i22++) {
                car[i22][i] = new ContO(car[i22 + 1][i], 0, 0, 0, 0);
                squash[i22][i] = squash[i22 + 1][i];
            }
            car[5][i] = new ContO(conto, 0, 0, 0, 0);
            squash[5][i] = i18;
            cntf = 0;
        } else {
            cntf++;
        }
        fix[i]--;
        if (i20 != 0) {
            dest[i]--;
        }
        if (dest[i] == 230)
            if (i == i21) {
                cotchinow(i21);
                whenwasted = 229;
            } else if (i19 != 0) {
                cotchinow(i);
                whenwasted = 165 + i19;
            }
        for (int i23 = 0; i23 < 299; i23++) {
            x[i23][i] = x[i23 + 1][i];
            y[i23][i] = y[i23 + 1][i];
            z[i23][i] = z[i23 + 1][i];
            zy[i23][i] = zy[i23 + 1][i];
            xy[i23][i] = xy[i23 + 1][i];
            xz[i23][i] = xz[i23 + 1][i];
            wxz[i23][i] = wxz[i23 + 1][i];
            wzy[i23][i] = wzy[i23 + 1][i];
        }
        x[299][i] = conto.x;
        y[299][i] = conto.y;
        z[299][i] = conto.z;
        xy[299][i] = conto.xy;
        zy[299][i] = conto.zy;
        xz[299][i] = conto.xz;
        wxz[299][i] = conto.wxz;
        wzy[299][i] = conto.wzy;
        if (i == i21) {
            for (int i24 = 0; i24 < 299; i24++) {
                checkpoint[i24] = checkpoint[i24 + 1];
                lastcheck[i24] = lastcheck[i24 + 1];
            }
            checkpoint[299] = Medium.checkpoint;
            lastcheck[299] = Medium.lastcheck;
        }
        for (int i25 = 0; i25 < 20; i25++) {
            if (conto.stg != null && conto.stg[i25] == 1) {
                sspark[i][i25][ns[i][i25]] = 300;
                sx[i][i25][ns[i][i25]] = conto.sx[i25];
                sy[i][i25][ns[i][i25]] = conto.sy[i25];
                sz[i][i25][ns[i][i25]] = conto.sz[i25];
                smag[i][i25][ns[i][i25]] = conto.osmag[i25];
                scx[i][i25][ns[i][i25]] = conto.scx[i25];
                scz[i][i25][ns[i][i25]] = conto.scz[i25];
                ns[i][i25]++;
                if (ns[i][i25] == 30) {
                    ns[i][i25] = 0;
                }
            }
            for (int i26 = 0; i26 < 30; i26++) {
                sspark[i][i25][i26]--;
            }
        }
        if (conto.sprk != 0) {
            rspark[i][nr[i]] = 300;
            sprk[i][nr[i]] = conto.sprk;
            srx[i][nr[i]] = conto.srx;
            sry[i][nr[i]] = conto.sry;
            srz[i][nr[i]] = conto.srz;
            rcx[i][nr[i]] = conto.rcx;
            rcy[i][nr[i]] = conto.rcy;
            rcz[i][nr[i]] = conto.rcz;
            nr[i]++;
            if (nr[i] == 200) {
                nr[i] = 0;
            }
        }
        for (int i27 = 0; i27 < 200; i27++) {
            rspark[i][i27]--;
        }
        for (int i28 = 0; i28 < 4; i28++) {
            for (int i29 = 0; i29 < 7; i29++) {
                ry[i][i28][i29]--;
                rx[i][i28][i29]--;
                rz[i][i28][i29]--;
            }
        }
    }

    static void recx(final int i, final float f, final int i48) {
        rx[i48][i][nry[i48][i]] = 300;
        magx[i48][i][nry[i48][i]] = (int) f;
        nrx[i48][i]++;
        if (nrx[i48][i] == 7) {
            nrx[i48][i] = 0;
        }
    }

    static void recy(final int i, final float f, final boolean bool, final int i47) {
        ry[i47][i][nry[i47][i]] = 300;
        magy[i47][i][nry[i47][i]] = (int) f;
        mtouch[i47][nry[i47][i]] = bool;
        nry[i47][i]++;
        if (nry[i47][i] == 7) {
            nry[i47][i] = 0;
        }
    }

    static void recz(final int i, final float f, final int i49) {
        rz[i49][i][nry[i49][i]] = 300;
        magz[i49][i][nry[i49][i]] = (int) f;
        nrz[i49][i]++;
        if (nrz[i49][i] == 7) {
            nrz[i49][i] = 0;
        }
    }

    static private void regx(final int i, float f, final ContO conto, final Mad mad) {
        if (Math.abs(f) > 100.0F) {
            if (f > 100.0F) {
                f -= 100.0F;
            }
            if (f < -100.0F) {
                f += 100.0F;
            }
            for (int i62 = 0; i62 < conto.npl; i62++) {
                float f63 = 0.0F;
                for (int i64 = 0; i64 < conto.p[i62].n; i64++)
                    if (conto.p[i62].wz == 0 && py(conto.keyx[i], conto.p[i62].ox[i64], conto.keyz[i], conto.p[i62].oz[i64]) < mad.stat.clrad) {
                        f63 = f / 20.0F * Medium.random();
                        conto.p[i62].oz[i64] -= f63 * Medium.sin(conto.xz) * Medium.cos(conto.zy);
                        conto.p[i62].ox[i64] += f63 * Medium.cos(conto.xz) * Medium.cos(conto.xy);
                    }
                if (f63 != 0.0F) {
                    if (Math.abs(f63) >= 1.0F) {
                        conto.p[i62].chip = 1;
                        conto.p[i62].ctmag = f63;
                    }
                    if (!conto.p[i62].nocol && conto.p[i62].glass != 1) {
                        if (conto.p[i62].bfase > 20 && conto.p[i62].hsb[1] > 0.2) {
                            conto.p[i62].hsb[1] = 0.2F;
                        }
                        if (conto.p[i62].bfase > 30) {
                            if (conto.p[i62].hsb[2] < 0.5) {
                                conto.p[i62].hsb[2] = 0.5F;
                            }
                            if (conto.p[i62].hsb[1] > 0.1) {
                                conto.p[i62].hsb[1] = 0.1F;
                            }
                        }
                        if (conto.p[i62].bfase > 40) {
                            conto.p[i62].hsb[1] = 0.05F;
                        }
                        if (conto.p[i62].bfase > 50) {
                            if (conto.p[i62].hsb[2] > 0.8) {
                                conto.p[i62].hsb[2] = 0.8F;
                            }
                            conto.p[i62].hsb[0] = 0.075F;
                            conto.p[i62].hsb[1] = 0.05F;
                        }
                        if (conto.p[i62].bfase > 60) {
                            conto.p[i62].hsb[0] = 0.05F;
                        }
                        conto.p[i62].bfase += Math.abs(f63);
                        new Color(conto.p[i62].c[0], conto.p[i62].c[1], conto.p[i62].c[2]);
                        final Color color = Color.getHSBColor(conto.p[i62].hsb[0], conto.p[i62].hsb[1], conto.p[i62].hsb[2]);
                        conto.p[i62].c[0] = color.getRed();
                        conto.p[i62].c[1] = color.getGreen();
                        conto.p[i62].c[2] = color.getBlue();
                    }
                    if (conto.p[i62].glass == 1) {
                        conto.p[i62].gr += Math.abs(f63 * 1.5);
                    }
                }
            }
        }
    }

    static private void regy(final int i, float f, final boolean bool, final ContO conto, final Mad mad) {
        if (f > 100.0F) {
            f -= 100.0F;
            int i50 = 0;
            int i51 = 0;
            int i52 = conto.zy;
            int i53 = conto.xy;
            for (/**/; i52 < 360; i52 += 360) {

            }
            for (/**/; i52 > 360; i52 -= 360) {

            }
            if (i52 < 210 && i52 > 150) {
                i50 = -1;
            }
            if (i52 > 330 || i52 < 30) {
                i50 = 1;
            }
            for (/**/; i53 < 360; i53 += 360) {

            }
            for (/**/; i53 > 360; i53 -= 360) {

            }
            if (i53 < 210 && i53 > 150) {
                i51 = -1;
            }
            if (i53 > 330 || i53 < 30) {
                i51 = 1;
            }
            if (i51 * i50 == 0 || bool) {
                for (int i54 = 0; i54 < conto.npl; i54++) {
                    float f55 = 0.0F;
                    for (int i56 = 0; i56 < conto.p[i54].n; i56++)
                        if (conto.p[i54].wz == 0 && py(conto.keyx[i], conto.p[i54].ox[i56], conto.keyz[i], conto.p[i54].oz[i56]) < mad.stat.clrad) {
                            f55 = f / 20.0F * Medium.random();
                            conto.p[i54].oz[i56] += f55 * Medium.sin(i52);
                            conto.p[i54].ox[i56] -= f55 * Medium.sin(i53);
                        }
                    if (f55 != 0.0F) {
                        if (Math.abs(f55) >= 1.0F) {
                            conto.p[i54].chip = 1;
                            conto.p[i54].ctmag = f55;
                        }
                        if (!conto.p[i54].nocol && conto.p[i54].glass != 1) {
                            if (conto.p[i54].bfase > 20 && conto.p[i54].hsb[1] > 0.2) {
                                conto.p[i54].hsb[1] = 0.2F;
                            }
                            if (conto.p[i54].bfase > 30) {
                                if (conto.p[i54].hsb[2] < 0.5) {
                                    conto.p[i54].hsb[2] = 0.5F;
                                }
                                if (conto.p[i54].hsb[1] > 0.1) {
                                    conto.p[i54].hsb[1] = 0.1F;
                                }
                            }
                            if (conto.p[i54].bfase > 40) {
                                conto.p[i54].hsb[1] = 0.05F;
                            }
                            if (conto.p[i54].bfase > 50) {
                                if (conto.p[i54].hsb[2] > 0.8) {
                                    conto.p[i54].hsb[2] = 0.8F;
                                }
                                conto.p[i54].hsb[0] = 0.075F;
                                conto.p[i54].hsb[1] = 0.05F;
                            }
                            if (conto.p[i54].bfase > 60) {
                                conto.p[i54].hsb[0] = 0.05F;
                            }
                            conto.p[i54].bfase += f55;
                            new Color(conto.p[i54].c[0], conto.p[i54].c[1], conto.p[i54].c[2]);
                            final Color color = Color.getHSBColor(conto.p[i54].hsb[0], conto.p[i54].hsb[1], conto.p[i54].hsb[2]);
                            conto.p[i54].c[0] = color.getRed();
                            conto.p[i54].c[1] = color.getGreen();
                            conto.p[i54].c[2] = color.getBlue();
                        }
                        if (conto.p[i54].glass == 1) {
                            conto.p[i54].gr += Math.abs(f55 * 1.5);
                        }
                    }
                }
            }
            if (i51 * i50 == -1) {
                int i57 = 0;
                int i58 = 1;
                for (int i59 = 0; i59 < conto.npl; i59++) {
                    float f60 = 0.0F;
                    for (int i61 = 0; i61 < conto.p[i59].n; i61++)
                        if (conto.p[i59].wz == 0) {
                            f60 = f / 15.0F * Medium.random();
                            if ((Math.abs(conto.p[i59].oy[i61] - mad.stat.flipy - squash[0][mad.im]) < mad.stat.msquash * 3 || conto.p[i59].oy[i61] < mad.stat.flipy + squash[0][mad.im]) && squash[0][mad.im] < mad.stat.msquash) {
                                conto.p[i59].oy[i61] += f60;
                                i57 += f60;
                                i58++;
                            }
                        }
                    if (conto.p[i59].glass == 1) {
                        conto.p[i59].gr += 5;
                    } else if (f60 != 0.0F) {
                        conto.p[i59].bfase += f60;
                    }
                    if (Math.abs(f60) >= 1.0F) {
                        conto.p[i59].chip = 1;
                        conto.p[i59].ctmag = f60;
                    }
                }
                squash[0][mad.im] += i57 / i58;
            }
        }
    }

    static private void regz(final int i, float f, final ContO conto, final Mad mad) {
        if (Math.abs(f) > 100.0F) {
            if (f > 100.0F) {
                f -= 100.0F;
            }
            if (f < -100.0F) {
                f += 100.0F;
            }
            for (int i65 = 0; i65 < conto.npl; i65++) {
                float f66 = 0.0F;
                for (int i67 = 0; i67 < conto.p[i65].n; i67++)
                    if (conto.p[i65].wz == 0 && py(conto.keyx[i], conto.p[i65].ox[i67], conto.keyz[i], conto.p[i65].oz[i67]) < mad.stat.clrad) {
                        f66 = f / 20.0F * Medium.random();
                        conto.p[i65].oz[i67] += f66 * Medium.cos(conto.xz) * Medium.cos(conto.zy);
                        conto.p[i65].ox[i67] += f66 * Medium.sin(conto.xz) * Medium.cos(conto.xy);
                    }
                if (f66 != 0.0F) {
                    if (Math.abs(f66) >= 1.0F) {
                        conto.p[i65].chip = 1;
                        conto.p[i65].ctmag = f66;
                    }
                    if (!conto.p[i65].nocol && conto.p[i65].glass != 1) {
                        if (conto.p[i65].bfase > 20 && conto.p[i65].hsb[1] > 0.2) {
                            conto.p[i65].hsb[1] = 0.2F;
                        }
                        if (conto.p[i65].bfase > 30) {
                            if (conto.p[i65].hsb[2] < 0.5) {
                                conto.p[i65].hsb[2] = 0.5F;
                            }
                            if (conto.p[i65].hsb[1] > 0.1) {
                                conto.p[i65].hsb[1] = 0.1F;
                            }
                        }
                        if (conto.p[i65].bfase > 40) {
                            conto.p[i65].hsb[1] = 0.05F;
                        }
                        if (conto.p[i65].bfase > 50) {
                            if (conto.p[i65].hsb[2] > 0.8) {
                                conto.p[i65].hsb[2] = 0.8F;
                            }
                            conto.p[i65].hsb[0] = 0.075F;
                            conto.p[i65].hsb[1] = 0.05F;
                        }
                        if (conto.p[i65].bfase > 60) {
                            conto.p[i65].hsb[0] = 0.05F;
                        }
                        conto.p[i65].bfase += Math.abs(f66);
                        new Color(conto.p[i65].c[0], conto.p[i65].c[1], conto.p[i65].c[2]);
                        final Color color = Color.getHSBColor(conto.p[i65].hsb[0], conto.p[i65].hsb[1], conto.p[i65].hsb[2]);
                        conto.p[i65].c[0] = color.getRed();
                        conto.p[i65].c[1] = color.getGreen();
                        conto.p[i65].c[2] = color.getBlue();
                    }
                    if (conto.p[i65].glass == 1) {
                        conto.p[i65].gr += Math.abs(f66 * 1.5);
                    }
                }
            }
        }
    }

    static void reset(final ContO[] contos) {
        caught = 0;
        hcaught = false;
        wasted = 0;
        whenwasted = 0;
        closefinish = 0;
        powered = 0;
        for (int i = 0; i < 8; i++) {
            if (prepit) {
                starcar[i] = new ContO(contos[i], 0, 0, 0, 0);
            }
            fix[i] = -1;
            dest[i] = -1;
            cntdest[i] = 0;
        }
        for (int i = 0; i < 6; i++) {
            for (int i0 = 0; i0 < 8; i0++) {
                car[i][i0] = new ContO(contos[i0], 0, 0, 0, 0);
                squash[i][i0] = 0;
            }
        }
        for (int i = 0; i < 8; i++) {
            nr[i] = 0;
            for (int i1 = 0; i1 < 200; i1++) {
                rspark[i][i1] = -1;
            }
            for (int i2 = 0; i2 < 20; i2++) {
                ns[i][i2] = 0;
                for (int i3 = 0; i3 < 30; i3++) {
                    sspark[i][i2][i3] = -1;
                }
            }
            for (int i4 = 0; i4 < 4; i4++) {
                nry[i][i4] = 0;
                nrx[i][i4] = 0;
                nrz[i][i4] = 0;
                for (int i5 = 0; i5 < 7; i5++) {
                    ry[i][i4][i5] = -1;
                    rx[i][i4][i5] = -1;
                    rz[i][i4][i5] = -1;
                }
            }
        }
        prepit = false;
    }
}
