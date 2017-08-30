package nfm.open;
/* Medium - Decompiled by JODE
 * Visit http://jode.sourceforge.net/
 */
import java.awt.Color;
import java.awt.Graphics2D;
import java.util.Random;
import java.util.concurrent.ThreadLocalRandom;

public class Medium {
    //private Medium() {}
    static int adv = 500;
    static private long atrx = 0L;
    static private long atrz = 0L;
    static private int bcxz = 0;
    static private boolean[] bst = null;
    static boolean bt = false;
    static final int[] cfade = {
            255, 220, 220
    };
    static private int[] cgpx = null;
    static private int[] cgpz = null;
    static final int[] cgrnd = {
            205, 200, 200
    };
    static int checkpoint = -1;
    static private int[][][] clax = null;
    static private int[][][] clay = null;
    static private int[][][] claz = null;
    static private int[][][][] clc = null;
    static private final int[] cldd = {
            210, 210, 210, 1, -1000
    };
    static private final int[] clds = {
            210, 210, 210
    };
    static private int[] clx = null;
    static private int[] clz = null;
    static private int[] cmx = null;
    static private int cntrn = 0;
    static boolean cpflik = false;
    static final int[] cpol = {
            215, 210, 210
    };
    static final int[] crgrnd = {
            205, 200, 200
    };
    static boolean crs = false;
    static final int[] csky = {
            170, 220, 255
    };
    public static int cx = 400;
    static int cy = 225;
    static int cz = 50;
    static boolean darksky = false;
    static private final boolean[] diup = {
            false, false, false
    };
    static float elecr = 0.0F;
    static final int[] fade = {
            3000, 4500, 6000, 7500, 9000, 10500, 12000, 13500, 15000, 16500, 18000, 19500, 21000, 22500, 24000, 25500
    };
    static int fallen = 0;
    static private float fo = 1.0F;
    static int focusPoint = 400;
    static int fogd = 7;
    static private int fvect = 200;
    static private float gofo = (float) (0.33000001311302185 + ThreadLocalRandom.current().nextDouble() * 1.34);
    static int ground = 250;
    static int h = 450;
    static int hit = 45000;
    static int ih = 0;
    static int iw = 0;
    static boolean lastcheck = false;
    static int lastmaf = 0;
    static int lightn = -1;
    static boolean lightson = false;
    static private int lilo = 217;
    static boolean loadnew = false;
    static boolean lton = false;
    static int mgen = (int) (ThreadLocalRandom.current().nextDouble() * 100000.0);
    static private int[] mrd = null;
    static private int[][][] mtc = null;
    static private int[][] mtx = null;
    static private int[][] mty = null;
    static private int[][] mtz = null;
    static int ncl = 0;
    static private int nmt = 0;
    static private int[] nmv = null;
    static private int noc = 0;
    static boolean nochekflk = false;
    static int noelec = 0;
    static int nrnd = 0;
    static int nrw = 0;
    static int nsp = 0;
    static private int nst = 0;
    static private int[][] ogpx = null;
    static private int[][] ogpz = null;
    static private final int[] ogrnd = {
            205, 200, 200
    };
    static private final int[] osky = {
            170, 220, 255
    };
    static private float[] pcv = null;
    static private int[] pmx = null;
    static int ptcnt = -10;
    static int ptr = 0;
    static private float[][] pvr = null;
    static private final int[] rand = {
            0, 0, 0
    };
    static int rescnt = 5;
    static int resdown = 0;
    static private int sgpx = 0;
    static private int sgpz = 0;
    static private final int skyline = -300;
    static final int[] snap = {
            0, 0, 0
    };
    static final int[] sprad = new int[7];
    static final int[] spx = new int[7];
    static final int[] spz = new int[7];
    static private int[][][] stc = null;
    static private int[] stx = null;
    static private int[] stz = null;
    static private final float[] tcos = new float[360];
    static private boolean td = false;
    static private final int[] texture = {
            0, 0, 0, 50
    };
    static int trk = 0;
    static private int trn = 0;
    static long trx = 0L;
    static long trz = 0L;
    static private final float[] tsin = new float[360];
    static private int[] twn = null;
    static boolean vert = false;
    static int vxz = 180;
    static int w = 800;
    static int x = 0;
    static int xz = 0;
    static int y = 0;
    static int z = 0;
    static int zy = 0;

    static {
        for (int i = 0; i < 360; i++) {
            tcos[i] = (float) Math.cos(i * 0.017453292519943295);
        }
        for (int i = 0; i < 360; i++) {
            tsin[i] = (float) Math.sin(i * 0.017453292519943295);
        }
    }

    static void addsp(final int i, final int i245, final int i246) {
        if (nsp != 7) {
            spx[nsp] = i;
            spz[nsp] = i245;
            sprad[nsp] = i246;
            nsp++;
        }
    }

    static void adjstfade(final float f, final float f271, final int i, final GameSparker gamesparker) {
        if (resdown != 2)
            if (f == 5.0F) {
                if (resdown == 0 && rescnt == 0) {
                    GameSparker.moto = 0;
                    Madness.anti = 0;
                    fade[0] = 3000;
                    fadfrom(fade[0]);
                    resdown = 1;
                    rescnt = 10;
                }
                if (resdown == 1 && rescnt == 0) {
                    resdown = 2;
                }
                if ((i == 0 || resdown == 0) && f271 <= -20.0F) {
                    rescnt--;
                }
            } else if (resdown == 0) {
                rescnt = 5;
            } else {
                rescnt = 10;
            }
    }

    static void around(final ContO conto, final boolean bool) {
        if (!bool) {
            if (!vert) {
                adv += 2;
            } else {
                adv -= 2;
            }
            if (adv > 900) {
                vert = true;
            }
            if (adv < -500) {
                vert = false;
            }
        } else {
            adv -= 14;
            if (adv < 617) {
                adv = 617;
            }
        }
        int i = 500 + adv;
        if (bool && i < 1300) {
            i = 1300;
        }
        if (i < 1000) {
            i = 1000;
        }
        y = conto.y - adv;
        if (y > 10) {
            vert = false;
        }
        x = conto.x + (int) ((conto.x - i - conto.x) * cos(vxz));
        z = conto.z + (int) ((conto.x - i - conto.x) * sin(vxz));
        if (!bool) {
            vxz += 2;
        } else {
            vxz += 4;
        }
        int i4 = 0;
        int i5 = y;
        if (i5 > 0) {
            i5 = 0;
        }
        if (conto.y - i5 - cy < 0) {
            i4 = -180;
        }
        final int i6 = (int) Math.sqrt((conto.z - z + cz) * (conto.z - z + cz) + (conto.x - x - cx) * (conto.x - x - cx));
        int i7 = (int) (90 + i4 - Math.atan((double) i6 / (double) (conto.y - i5 - cy)) / 0.017453292519943295);
        xz = -vxz + 90;
        if (bool) {
            i7 -= 15;
        }
        zy += (i7 - zy) / 10;
    }

    static void aroundtrack() {
        y = -hit;
        x = cx + (int) trx + (int) (17000.0F * cos(vxz));
        z = (int) trz + (int) (17000.0F * sin(vxz));
        if (hit > 5000) {
            if (hit == 45000) {
                fo = 1.0F;
                zy = 67;
                atrx = (CheckPoints.x[0] - trx) / 116L;
                atrz = (CheckPoints.z[0] - trz) / 116L;
                focusPoint = 400;
            }
            if (hit == 20000) {
                fallen = 500;
                fo = 1.0F;
                zy = 67;
                atrx = (CheckPoints.x[0] - trx) / 116L;
                atrz = (CheckPoints.z[0] - trz) / 116L;
                focusPoint = 400;
            }
            hit -= fallen;
            fallen += 7;
            trx += atrx;
            trz += atrz;
            if (hit < 17600) {
                zy -= 2;
            }
            if (fallen > 500) {
                fallen = 500;
            }
            if (hit <= 5000) {
                hit = 5000;
                fallen = 0;
            }
            vxz += 3;
        } else {
            focusPoint = (int) (400.0F * fo);
            if (Math.abs(fo - gofo) > 0.005) {
                if (fo < gofo) {
                    fo += 0.005F;
                } else {
                    fo -= 0.005F;
                }
            } else {
                gofo = (float) (0.3499999940395355 + ThreadLocalRandom.current().nextDouble() * 1.3);
            }
            vxz++;
            trx -= (trx - CheckPoints.x[ptr]) / 10L;
            trz -= (trz - CheckPoints.z[ptr]) / 10L;
            if (ptcnt == 7) {
                ptr++;
                if (ptr == CheckPoints.n) {
                    ptr = 0;
                    nrnd++;
                }
                ptcnt = 0;
            } else {
                ptcnt++;
            }
        }
        if (vxz > 360) {
            vxz -= 360;
        }
        xz = -vxz - 90;
        if (-y - cy < 0) {
        }
        Math.sqrt((trz - z + cz) * (trz - z + cz) + (trx - x - cx) * (trx - x - cx));
        cpflik = !cpflik;
    }

    static float cos(int i) {
        for (/**/; i >= 360; i -= 360) {

        }
        for (/**/; i < 0; i += 360) {

        }
        return tcos[i];
    }

    static void d(final Graphics2D graphics2d) {
        nsp = 0;
        if (zy > 90) {
            zy = 90;
        }
        if (zy < -90) {
            zy = -90;
        }
        if (xz > 360) {
            xz -= 360;
        }
        if (xz < 0) {
            xz += 360;
        }
        if (y > 0) {
            y = 0;
        }
        ground = 250 - y;
        final int[] is = new int[4];
        final int[] is223 = new int[4];
        int i = cgrnd[0];
        int i224 = cgrnd[1];
        int i225 = cgrnd[2];
        int i226 = crgrnd[0];
        int i227 = crgrnd[1];
        int i228 = crgrnd[2];
        int i229 = h;
        for (int i230 = 0; i230 < 16; i230++) {
            int i231 = fade[i230];
            int i232 = ground;
            if (zy != 0) {
                i232 = cy + (int) ((ground - cy) * cos(zy) - (fade[i230] - cz) * sin(zy));
                i231 = cz + (int) ((ground - cy) * sin(zy) + (fade[i230] - cz) * cos(zy));
            }
            is[0] = iw;
            is223[0] = ys(i232, i231);
            if (is223[0] < ih) {
                is223[0] = ih;
            }
            if (is223[0] > h) {
                is223[0] = h;
            }
            is[1] = iw;
            is223[1] = i229;
            is[2] = w;
            is223[2] = i229;
            is[3] = w;
            is223[3] = is223[0];
            i229 = is223[0];
            if (i230 > 0) {
                i226 = (i226 * 7 + cfade[0]) / 8;
                i227 = (i227 * 7 + cfade[1]) / 8;
                i228 = (i228 * 7 + cfade[2]) / 8;
                if (i230 < 3) {
                    i = (i * 7 + cfade[0]) / 8;
                    i224 = (i224 * 7 + cfade[1]) / 8;
                    i225 = (i225 * 7 + cfade[2]) / 8;
                } else {
                    i = i226;
                    i224 = i227;
                    i225 = i228;
                }
            }
            if (is223[0] < h && is223[1] > ih) {
                graphics2d.setColor(new Color(i, i224, i225));
                graphics2d.fillPolygon(is, is223, 4);
            }
        }
        if (lightn != -1 && lton) {
            if (lightn < 16) {
                if (lilo > lightn + 217) {
                    lilo -= 3;
                } else {
                    lightn = (int) (16.0F + 16.0F * random());
                }
            } else if (lilo < lightn + 217) {
                lilo += 7;
            } else {
                lightn = (int) (16.0F * random());
            }
            csky[0] = (int) (lilo + lilo * (snap[0] / 100.0F));
            if (csky[0] > 255) {
                csky[0] = 255;
            }
            if (csky[0] < 0) {
                csky[0] = 0;
            }
            csky[1] = (int) (lilo + lilo * (snap[1] / 100.0F));
            if (csky[1] > 255) {
                csky[1] = 255;
            }
            if (csky[1] < 0) {
                csky[1] = 0;
            }
            csky[2] = (int) (lilo + lilo * (snap[2] / 100.0F));
            if (csky[2] > 255) {
                csky[2] = 255;
            }
            if (csky[2] < 0) {
                csky[2] = 0;
            }
        }
        i = csky[0];
        i224 = csky[1];
        i225 = csky[2];
        int i233 = i;
        int i234 = i224;
        int i235 = i225;
        int i236 = cy + (int) ((skyline - 700 - cy) * cos(zy) - (7000 - cz) * sin(zy));
        final int i237 = cz + (int) ((skyline - 700 - cy) * sin(zy) + (7000 - cz) * cos(zy));
        i236 = ys(i236, i237);
        int i238 = ih;
        for (int i239 = 0; i239 < 16; i239++) {
            int i240 = fade[i239];
            int i241 = skyline;
            if (zy != 0) {
                i241 = cy + (int) ((skyline - cy) * cos(zy) - (fade[i239] - cz) * sin(zy));
                i240 = cz + (int) ((skyline - cy) * sin(zy) + (fade[i239] - cz) * cos(zy));
            }
            is[0] = iw;
            is223[0] = ys(i241, i240);
            if (is223[0] > h) {
                is223[0] = h;
            }
            if (is223[0] < ih) {
                is223[0] = ih;
            }
            is[1] = iw;
            is223[1] = i238;
            is[2] = w;
            is223[2] = i238;
            is[3] = w;
            is223[3] = is223[0];
            i238 = is223[0];
            if (i239 > 0) {
                i = (i * 7 + cfade[0]) / 8;
                i224 = (i224 * 7 + cfade[1]) / 8;
                i225 = (i225 * 7 + cfade[2]) / 8;
            }
            if (is223[1] < i236) {
                i233 = i;
                i234 = i224;
                i235 = i225;
            }
            if (is223[0] > ih && is223[1] < h) {
                graphics2d.setColor(new Color(i, i224, i225));
                graphics2d.fillPolygon(is, is223, 4);
            }
        }
        is[0] = iw;
        is223[0] = i238;
        is[1] = iw;
        is223[1] = i229;
        is[2] = w;
        is223[2] = i229;
        is[3] = w;
        is223[3] = i238;
        if (is223[0] < h && is223[1] > ih) {
            float f = (Math.abs(y) - 250.0F) / (fade[0] * 2);
            if (f < 0.0F) {
                f = 0.0F;
            }
            if (f > 1.0F) {
                f = 1.0F;
            }
            i = (int) ((i * (1.0F - f) + i226 * (1.0F + f)) / 2.0F);
            i224 = (int) ((i224 * (1.0F - f) + i227 * (1.0F + f)) / 2.0F);
            i225 = (int) ((i225 * (1.0F - f) + i228 * (1.0F + f)) / 2.0F);
            graphics2d.setColor(new Color(i, i224, i225));
            graphics2d.fillPolygon(is, is223, 4);
        }
        if (resdown != 2) {
            for (int i242 = 1; i242 < 20; i242++) {
                int i243 = 7000;
                int i244 = skyline - 700 - i242 * 70;
                if (zy != 0 && i242 != 19) {
                    i244 = cy + (int) ((skyline - 700 - i242 * 70 - cy) * cos(zy) - (7000 - cz) * sin(zy));
                    i243 = cz + (int) ((skyline - 700 - i242 * 70 - cy) * sin(zy) + (7000 - cz) * cos(zy));
                }
                is[0] = iw;
                if (i242 != 19) {
                    is223[0] = ys(i244, i243);
                    if (is223[0] > h) {
                        is223[0] = h;
                    }
                    if (is223[0] < ih) {
                        is223[0] = ih;
                    }
                } else {
                    is223[0] = ih;
                }
                is[1] = iw;
                is223[1] = i236;
                is[2] = w;
                is223[2] = i236;
                is[3] = w;
                is223[3] = is223[0];
                i236 = is223[0];
                i233 *= 0.991;
                i234 *= 0.991;
                i235 *= 0.998;
                if (is223[1] > ih && is223[0] < h) {
                    graphics2d.setColor(new Color(i233, i234, i235));
                    graphics2d.fillPolygon(is, is223, 4);
                }
            }
            if (lightson) {
                drawstars(graphics2d);
            }
            drawmountains(graphics2d);
            drawclouds(graphics2d);
        }
        groundpolys(graphics2d);
        if (noelec != 0) {
            noelec--;
        }
        if (cpflik) {
            cpflik = false;
        } else {
            cpflik = true;
            elecr = random() * 15.0F - 6.0F;
        }
    }

    static private void drawclouds(final Graphics2D graphics2d) {
        for (int i = 0; i < noc; i++) {
            final int i104 = cx + (int) ((clx[i] - x / 20 - cx) * cos(xz) - (clz[i] - z / 20 - cz) * sin(xz));
            final int i105 = cz + (int) ((clx[i] - x / 20 - cx) * sin(xz) + (clz[i] - z / 20 - cz) * cos(xz));
            final int i106 = cz + (int) ((cldd[4] - y / 20 - cy) * sin(zy) + (i105 - cz) * cos(zy));
            final int i107 = xs(i104 + cmx[i], i106);
            final int i108 = xs(i104 - cmx[i], i106);
            if (i107 > 0 && i108 < w && i106 > -cmx[i] && i107 - i108 > 20) {
                final int[][] is = new int[3][12];
                final int[][] is109 = new int[3][12];
                final int[][] is110 = new int[3][12];
                final int[] is111 = new int[12];
                final int[] is112 = new int[12];
                boolean bool116;
                for (int i120 = 0; i120 < 3; i120++) {
                    for (int i121 = 0; i121 < 12; i121++) {
                        is[i120][i121] = clax[i][i120][i121] + clx[i] - x / 20;
                        is110[i120][i121] = claz[i][i120][i121] + clz[i] - z / 20;
                        is109[i120][i121] = clay[i][i120][i121] + cldd[4] - y / 20;
                    }
                    rot(is[i120], is110[i120], cx, cz, xz, 12);
                    rot(is109[i120], is110[i120], cy, cz, zy, 12);
                }
                for (int i122 = 0; i122 < 12; i122 += 2) {
                    int i123 = 0;
                    int i124 = 0;
                    int i125 = 0;
                    int i126 = 0;
                    bool116 = true;
                    int i127 = 0;
                    int i128 = 0;
                    int i129 = 0;
                    for (int i130 = 0; i130 < 6; i130++) {
                        int i131 = 0;
                        int i132 = 1;
                        if (i130 == 0) {
                            i131 = i122;
                        }
                        if (i130 == 1) {
                            i131 = i122 + 1;
                            if (i131 >= 12) {
                                i131 -= 12;
                            }
                        }
                        if (i130 == 2) {
                            i131 = i122 + 2;
                            if (i131 >= 12) {
                                i131 -= 12;
                            }
                        }
                        if (i130 == 3) {
                            i131 = i122 + 2;
                            if (i131 >= 12) {
                                i131 -= 12;
                            }
                            i132 = 2;
                        }
                        if (i130 == 4) {
                            i131 = i122 + 1;
                            if (i131 >= 12) {
                                i131 -= 12;
                            }
                            i132 = 2;
                        }
                        if (i130 == 5) {
                            i131 = i122;
                            i132 = 2;
                        }
                        is111[i130] = xs(is[i132][i131], is110[i132][i131]);
                        is112[i130] = ys(is109[i132][i131], is110[i132][i131]);
                        i128 += is[i132][i131];
                        i127 += is109[i132][i131];
                        i129 += is110[i132][i131];
                        if (is112[i130] < 0 || is110[0][i130] < 10) {
                            i123++;
                        }
                        if (is112[i130] > h || is110[0][i130] < 10) {
                            i124++;
                        }
                        if (is111[i130] < 0 || is110[0][i130] < 10) {
                            i125++;
                        }
                        if (is111[i130] > w || is110[0][i130] < 10) {
                            i126++;
                        }
                    }
                    if (i125 == 6 || i123 == 6 || i124 == 6 || i126 == 6) {
                        bool116 = false;
                    }
                    if (bool116) {
                        i128 /= 6;
                        i127 /= 6;
                        i129 /= 6;
                        final int i133 = (int) Math.sqrt((cy - i127) * (cy - i127) + (cx - i128) * (cx - i128) + i129 * i129);
                        if (i133 < fade[7]) {
                            int i134 = clc[i][1][i122 / 2][0];
                            int i135 = clc[i][1][i122 / 2][1];
                            int i136 = clc[i][1][i122 / 2][2];
                            for (int i137 = 0; i137 < 16; i137++)
                                if (i133 > fade[i137]) {
                                    i134 = (i134 * fogd + cfade[0]) / (fogd + 1);
                                    i135 = (i135 * fogd + cfade[1]) / (fogd + 1);
                                    i136 = (i136 * fogd + cfade[2]) / (fogd + 1);
                                }
                            graphics2d.setColor(new Color(i134, i135, i136));
                            graphics2d.fillPolygon(is111, is112, 6);
                        }
                    }
                }
                for (int i138 = 0; i138 < 12; i138 += 2) {
                    int i139 = 0;
                    int i140 = 0;
                    int i141 = 0;
                    int i142 = 0;
                    bool116 = true;
                    int i143 = 0;
                    int i144 = 0;
                    int i145 = 0;
                    for (int i146 = 0; i146 < 6; i146++) {
                        int i147 = 0;
                        int i148 = 0;
                        if (i146 == 0) {
                            i147 = i138;
                        }
                        if (i146 == 1) {
                            i147 = i138 + 1;
                            if (i147 >= 12) {
                                i147 -= 12;
                            }
                        }
                        if (i146 == 2) {
                            i147 = i138 + 2;
                            if (i147 >= 12) {
                                i147 -= 12;
                            }
                        }
                        if (i146 == 3) {
                            i147 = i138 + 2;
                            if (i147 >= 12) {
                                i147 -= 12;
                            }
                            i148 = 1;
                        }
                        if (i146 == 4) {
                            i147 = i138 + 1;
                            if (i147 >= 12) {
                                i147 -= 12;
                            }
                            i148 = 1;
                        }
                        if (i146 == 5) {
                            i147 = i138;
                            i148 = 1;
                        }
                        is111[i146] = xs(is[i148][i147], is110[i148][i147]);
                        is112[i146] = ys(is109[i148][i147], is110[i148][i147]);
                        i144 += is[i148][i147];
                        i143 += is109[i148][i147];
                        i145 += is110[i148][i147];
                        if (is112[i146] < 0 || is110[0][i146] < 10) {
                            i139++;
                        }
                        if (is112[i146] > h || is110[0][i146] < 10) {
                            i140++;
                        }
                        if (is111[i146] < 0 || is110[0][i146] < 10) {
                            i141++;
                        }
                        if (is111[i146] > w || is110[0][i146] < 10) {
                            i142++;
                        }
                    }
                    if (i141 == 6 || i139 == 6 || i140 == 6 || i142 == 6) {
                        bool116 = false;
                    }
                    if (bool116) {
                        i144 /= 6;
                        i143 /= 6;
                        i145 /= 6;
                        final int i149 = (int) Math.sqrt((cy - i143) * (cy - i143) + (cx - i144) * (cx - i144) + i145 * i145);
                        if (i149 < fade[7]) {
                            int i150 = clc[i][0][i138 / 2][0];
                            int i151 = clc[i][0][i138 / 2][1];
                            int i152 = clc[i][0][i138 / 2][2];
                            for (int i153 = 0; i153 < 16; i153++)
                                if (i149 > fade[i153]) {
                                    i150 = (i150 * fogd + cfade[0]) / (fogd + 1);
                                    i151 = (i151 * fogd + cfade[1]) / (fogd + 1);
                                    i152 = (i152 * fogd + cfade[2]) / (fogd + 1);
                                }
                            graphics2d.setColor(new Color(i150, i151, i152));
                            graphics2d.fillPolygon(is111, is112, 6);
                        }
                    }
                }
                int i154 = 0;
                int i155 = 0;
                int i156 = 0;
                int i157 = 0;
                bool116 = true;
                int i158 = 0;
                int i159 = 0;
                int i160 = 0;
                for (int i161 = 0; i161 < 12; i161++) {
                    is111[i161] = xs(is[0][i161], is110[0][i161]);
                    is112[i161] = ys(is109[0][i161], is110[0][i161]);
                    i159 += is[0][i161];
                    i158 += is109[0][i161];
                    i160 += is110[0][i161];
                    if (is112[i161] < 0 || is110[0][i161] < 10) {
                        i154++;
                    }
                    if (is112[i161] > h || is110[0][i161] < 10) {
                        i155++;
                    }
                    if (is111[i161] < 0 || is110[0][i161] < 10) {
                        i156++;
                    }
                    if (is111[i161] > w || is110[0][i161] < 10) {
                        i157++;
                    }
                }
                if (i156 == 12 || i154 == 12 || i155 == 12 || i157 == 12) {
                    bool116 = false;
                }
                if (bool116) {
                    i159 /= 12;
                    i158 /= 12;
                    i160 /= 12;
                    final int i162 = (int) Math.sqrt((cy - i158) * (cy - i158) + (cx - i159) * (cx - i159) + i160 * i160);
                    if (i162 < fade[7]) {
                        int i163 = clds[0];
                        int i164 = clds[1];
                        int i165 = clds[2];
                        for (int i166 = 0; i166 < 16; i166++)
                            if (i162 > fade[i166]) {
                                i163 = (i163 * fogd + cfade[0]) / (fogd + 1);
                                i164 = (i164 * fogd + cfade[1]) / (fogd + 1);
                                i165 = (i165 * fogd + cfade[2]) / (fogd + 1);
                            }
                        graphics2d.setColor(new Color(i163, i164, i165));
                        graphics2d.fillPolygon(is111, is112, 12);
                    }
                }
            }
        }
    }

    static private void drawmountains(final Graphics2D graphics2d) {
        for (int i = 0; i < nmt; i++) {
            final int i185 = mrd[i];
            final int i186 = cx + (int) ((mtx[i185][0] - x / 30 - cx) * cos(xz) - (mtz[i185][0] - z / 30 - cz) * sin(xz));
            final int i187 = cz + (int) ((mtx[i185][0] - x / 30 - cx) * sin(xz) + (mtz[i185][0] - z / 30 - cz) * cos(xz));
            final int i188 = cz + (int) ((mty[i185][0] - y / 30 - cy) * sin(zy) + (i187 - cz) * cos(zy));
            final int i189 = cx + (int) ((mtx[i185][nmv[i185] - 1] - x / 30 - cx) * cos(xz) - (mtz[i185][nmv[i185] - 1] - z / 30 - cz) * sin(xz));
            final int i190 = cz + (int) ((mtx[i185][nmv[i185] - 1] - x / 30 - cx) * sin(xz) + (mtz[i185][nmv[i185] - 1] - z / 30 - cz) * cos(xz));
            final int i191 = cz + (int) ((mty[i185][nmv[i185] - 1] - y / 30 - cy) * sin(zy) + (i190 - cz) * cos(zy));
            if (xs(i189, i191) > 0 && xs(i186, i188) < w) {
                final int[] is = new int[nmv[i185] * 2];
                final int[] is192 = new int[nmv[i185] * 2];
                final int[] is193 = new int[nmv[i185] * 2];
                for (int i194 = 0; i194 < nmv[i185] * 2; i194++) {
                    is[i194] = mtx[i185][i194] - x / 30;
                    is192[i194] = mty[i185][i194] - y / 30;
                    is193[i194] = mtz[i185][i194] - z / 30;
                }
                final int i195 = (int) Math.sqrt(is[nmv[i185] / 4] * is[nmv[i185] / 4] + is193[nmv[i185] / 4] * is193[nmv[i185] / 4]);
                rot(is, is193, cx, cz, xz, nmv[i185] * 2);
                rot(is192, is193, cy, cz, zy, nmv[i185] * 2);
                final int[] is196 = new int[4];
                final int[] is197 = new int[4];
                boolean bool201;
                for (int i202 = 0; i202 < nmv[i185] - 1; i202++) {
                    int i203 = 0;
                    int i204 = 0;
                    int i205 = 0;
                    int i206 = 0;
                    bool201 = true;
                    for (int i207 = 0; i207 < 4; i207++) {
                        int i208 = i207 + i202;
                        if (i207 == 2) {
                            i208 = i202 + nmv[i185] + 1;
                        }
                        if (i207 == 3) {
                            i208 = i202 + nmv[i185];
                        }
                        is196[i207] = xs(is[i208], is193[i208]);
                        is197[i207] = ys(is192[i208], is193[i208]);
                        if (is197[i207] < 0 || is193[i208] < 10) {
                            i203++;
                        }
                        if (is197[i207] > h || is193[i208] < 10) {
                            i204++;
                        }
                        if (is196[i207] < 0 || is193[i208] < 10) {
                            i205++;
                        }
                        if (is196[i207] > w || is193[i208] < 10) {
                            i206++;
                        }
                    }
                    if (i205 == 4 || i203 == 4 || i204 == 4 || i206 == 4) {
                        bool201 = false;
                    }
                    if (bool201) {
                        float f = i195 / 2500.0F + (8000.0F - fade[0]) / 1000.0F - 2.0F - (Math.abs(y) - 250.0F) / 5000.0F;
                        if (f > 0.0F && f < 10.0F) {
                            if (f < 3.5) {
                                f = 3.5F;
                            }
                            final int i209 = (int) ((mtc[i185][i202][0] + cgrnd[0] + csky[0] * f + cfade[0] * f) / (2.0F + f * 2.0F));
                            final int i210 = (int) ((mtc[i185][i202][1] + cgrnd[1] + csky[1] * f + cfade[1] * f) / (2.0F + f * 2.0F));
                            final int i211 = (int) ((mtc[i185][i202][2] + cgrnd[2] + csky[2] * f + cfade[2] * f) / (2.0F + f * 2.0F));
                            graphics2d.setColor(new Color(i209, i210, i211));
                            graphics2d.fillPolygon(is196, is197, 4);
                        }
                    }
                }
            }
        }
    }

    static private void drawstars(final Graphics2D graphics2d) {
        for (int i = 0; i < nst; i++) {
            int i215 = cx + (int) (stx[i] * cos(xz) - stz[i] * sin(xz));
            final int i216 = cz + (int) (stx[i] * sin(xz) + stz[i] * cos(xz));
            int i217 = cy + (int) (-200.0F * cos(zy) - i216 * sin(zy));
            final int i218 = cz + (int) (-200.0F * sin(zy) + i216 * cos(zy));
            i215 = xs(i215, i218);
            i217 = ys(i217, i218);
            if (i215 - 1 > iw && i215 + 3 < w && i217 - 1 > ih && i217 + 3 < h) {
                if (twn[i] == 0) {
                    int i219 = (int) (3.0 * ThreadLocalRandom.current().nextDouble());
                    if (i219 >= 3) {
                        i219 = 0;
                    }
                    if (i219 <= -1) {
                        i219 = 2;
                    }
                    int i220 = i219 + 1;
                    if (ThreadLocalRandom.current().nextDouble() > ThreadLocalRandom.current().nextDouble()) {
                        i220 = i219 - 1;
                    }
                    if (i220 == 3) {
                        i220 = 0;
                    }
                    if (i220 == -1) {
                        i220 = 2;
                    }
                    for (int i221 = 0; i221 < 3; i221++) {
                        stc[i][0][i221] = 200;
                        if (i219 == i221) {
                            stc[i][0][i221] += (int) (55.0 * ThreadLocalRandom.current().nextDouble());
                        }
                        if (i220 == i221) {
                            stc[i][0][i221] += 55;
                        }
                        stc[i][0][i221] = (stc[i][0][i221] * 2 + csky[i221]) / 3;
                        stc[i][1][i221] = (stc[i][0][i221] + csky[i221]) / 2;
                    }
                    twn[i] = 3;
                } else {
                    twn[i]--;
                }
                int i222 = 0;
                if (bst[i]) {
                    i222 = 1;
                }
                graphics2d.setColor(new Color(stc[i][1][0], stc[i][1][1], stc[i][1][2]));
                graphics2d.fillRect(i215 - 1, i217, 3 + i222, 1 + i222);
                graphics2d.fillRect(i215, i217 - 1, 1 + i222, 3 + i222);
                graphics2d.setColor(new Color(stc[i][0][0], stc[i][0][1], stc[i][0][2]));
                graphics2d.fillRect(i215, i217, 1 + i222, 1 + i222);
            }
        }
    }

    static void fadfrom(int i) {
        if (i > 8000) {
            i = 8000;
        }
        for (int i270 = 1; i270 < 17; i270++) {
            fade[i270 - 1] = i / 2 * (i270 + 1);
        }
    }

    static void follow(final ContO conto, int i, final int i27) {
        zy = 10;
        int i28 = 2 + Math.abs(bcxz) / 4;
        if (i28 > 20) {
            i28 = 20;
        }
        if (i27 != 0) {
            if (i27 == 1) {
                if (bcxz < 180) {
                    bcxz += i28;
                }
                if (bcxz > 180) {
                    bcxz = 180;
                }
            }
            if (i27 == -1) {
                if (bcxz > -180) {
                    bcxz -= i28;
                }
                if (bcxz < -180) {
                    bcxz = -180;
                }
            }
        } else if (Math.abs(bcxz) > i28) {
            if (bcxz > 0) {
                bcxz -= i28;
            } else {
                bcxz += i28;
            }
        } else if (bcxz != 0) {
            bcxz = 0;
        }
        i += bcxz;
        xz = -i;
        x = conto.x - cx + (int) (-(conto.z - 800 - conto.z) * sin(i));
        z = conto.z - cz + (int) ((conto.z - 800 - conto.z) * cos(i));
        y = conto.y - 250 - cy;
    }

    static void getaround(final ContO conto) {
        if (!vert) {
            adv += 2;
        } else {
            adv -= 2;
        }
        if (adv > 1700) {
            vert = true;
        }
        if (adv < -500) {
            vert = false;
        }
        if (conto.y - adv > 10) {
            vert = false;
        }
        int i = 500 + adv;
        if (i < 1000) {
            i = 1000;
        }
        final int i8 = conto.y - adv;
        final int i9 = conto.x + (int) ((conto.x - i - conto.x) * cos(vxz));
        final int i10 = conto.z + (int) ((conto.x - i - conto.x) * sin(vxz));
        int i11 = 0;
        if (Math.abs(i8 - y) > fvect) {
            if (y < i8) {
                y += fvect;
            } else {
                y -= fvect;
            }
        } else {
            y = i8;
            i11++;
        }
        if (Math.abs(i9 - x) > fvect) {
            if (x < i9) {
                x += fvect;
            } else {
                x -= fvect;
            }
        } else {
            x = i9;
            i11++;
        }
        if (Math.abs(i10 - z) > fvect) {
            if (z < i10) {
                z += fvect;
            } else {
                z -= fvect;
            }
        } else {
            z = i10;
            i11++;
        }
        if (i11 == 3) {
            fvect = 200;
        } else {
            fvect += 2;
        }
        for (vxz += 2; vxz > 360; vxz -= 360) {

        }
        int i12 = -vxz + 90;
        int i13 = 0;
        if (conto.x - x - cx > 0) {
            i13 = 180;
        }
        int i14 = -(int) (90 + i13 + Math.atan((double) (conto.z - z) / (double) (conto.x - x - cx)) / 0.017453292519943295);
        int i15 = y;
        i13 = 0;
        if (i15 > 0) {
            i15 = 0;
        }
        if (conto.y - i15 - cy < 0) {
            i13 = -180;
        }
        final int i16 = (int) Math.sqrt((conto.z - z + cz) * (conto.z - z + cz) + (conto.x - x - cx) * (conto.x - x - cx));
        int i17 = 25;
        if (i16 != 0) {
            i17 = (int) (90 + i13 - Math.atan((double) i16 / (double) (conto.y - i15 - cy)) / 0.017453292519943295);
        }
        for (/**/; i12 < 0; i12 += 360) {

        }
        for (/**/; i12 > 360; i12 -= 360) {

        }
        for (/**/; i14 < 0; i14 += 360) {

        }
        for (/**/; i14 > 360; i14 -= 360) {

        }
        if ((Math.abs(i12 - i14) < 30 || Math.abs(i12 - i14) > 330) && i11 == 3) {
            if (Math.abs(i12 - xz) > 7 && Math.abs(i12 - xz) < 353) {
                if (Math.abs(i12 - xz) > 180) {
                    if (xz > i12) {
                        xz += 7;
                    } else {
                        xz -= 7;
                    }
                } else if (xz < i12) {
                    xz += 7;
                } else {
                    xz -= 7;
                }
            } else {
                xz = i12;
            }
        } else if (Math.abs(i14 - xz) > 6 && Math.abs(i14 - xz) < 354) {
            if (Math.abs(i14 - xz) > 180) {
                if (xz > i14) {
                    xz += 3;
                } else {
                    xz -= 3;
                }
            } else if (xz < i14) {
                xz += 3;
            } else {
                xz -= 3;
            }
        } else {
            xz = i14;
        }
        zy += (i17 - zy) / 10;
    }

    static void getfollow(final ContO conto, int i, final int i29) {
        zy = 10;
        int i30 = 2 + Math.abs(bcxz) / 4;
        if (i30 > 20) {
            i30 = 20;
        }
        if (i29 != 0) {
            if (i29 == 1) {
                if (bcxz < 180) {
                    bcxz += i30;
                }
                if (bcxz > 180) {
                    bcxz = 180;
                }
            }
            if (i29 == -1) {
                if (bcxz > -180) {
                    bcxz -= i30;
                }
                if (bcxz < -180) {
                    bcxz = -180;
                }
            }
        } else if (Math.abs(bcxz) > i30) {
            if (bcxz > 0) {
                bcxz -= i30;
            } else {
                bcxz += i30;
            }
        } else if (bcxz != 0) {
            bcxz = 0;
        }
        i += bcxz;
        xz = -i;
        final int i31 = conto.x - cx + (int) (-(conto.z - 800 - conto.z) * sin(i));
        final int i32 = conto.z - cz + (int) ((conto.z - 800 - conto.z) * cos(i));
        final int i33 = conto.y - 250 - cy;
        int i34 = 0;
        if (Math.abs(i33 - y) > fvect) {
            if (y < i33) {
                y += fvect;
            } else {
                y -= fvect;
            }
        } else {
            y = i33;
            i34++;
        }
        if (Math.abs(i31 - x) > fvect) {
            if (x < i31) {
                x += fvect;
            } else {
                x -= fvect;
            }
        } else {
            x = i31;
            i34++;
        }
        if (Math.abs(i32 - z) > fvect) {
            if (z < i32) {
                z += fvect;
            } else {
                z -= fvect;
            }
        } else {
            z = i32;
            i34++;
        }
        if (i34 == 3) {
            fvect = 200;
        } else {
            fvect += 2;
        }
    }

    static private void groundpolys(final Graphics2D graphics2d) {
        int i = (x - sgpx) / 1200 - 12;
        if (i < 0) {
            i = 0;
        }
        int i48 = i + 25;
        if (i48 > nrw) {
            i48 = nrw;
        }
        if (i48 < i) {
            i48 = i;
        }
        int i49 = (z - sgpz) / 1200 - 12;
        if (i49 < 0) {
            i49 = 0;
        }
        int i50 = i49 + 25;
        if (i50 > ncl) {
            i50 = ncl;
        }
        if (i50 < i49) {
            i50 = i49;
        }
        final int[][] is = new int[i48 - i][i50 - i49];
        for (int i51 = i; i51 < i48; i51++) {
            for (int i52 = i49; i52 < i50; i52++) {
                is[i51 - i][i52 - i49] = 0;
                final int i53 = i51 + i52 * nrw;
                if (resdown < 2 || i53 % 2 == 0) {
                    final int i54 = cx + (int) ((cgpx[i53] - x - cx) * cos(xz) - (cgpz[i53] - z - cz) * sin(xz));
                    final int i55 = cz + (int) ((cgpx[i53] - x - cx) * sin(xz) + (cgpz[i53] - z - cz) * cos(xz));
                    final int i56 = cz + (int) ((250 - y - cy) * sin(zy) + (i55 - cz) * cos(zy));
                    if (xs(i54 + pmx[i53], i56) > 0 && xs(i54 - pmx[i53], i56) < w && i56 > -pmx[i53] && i56 < fade[2]) {
                        is[i51 - i][i52 - i49] = i56;
                        final int[] is57 = new int[8];
                        final int[] is58 = new int[8];
                        final int[] is59 = new int[8];
                        for (int i60 = 0; i60 < 8; i60++) {
                            is57[i60] = (int) (ogpx[i53][i60] * pvr[i53][i60] + cgpx[i53] - x);
                            is58[i60] = (int) (ogpz[i53][i60] * pvr[i53][i60] + cgpz[i53] - z);
                            is59[i60] = ground;
                        }
                        rot(is57, is58, cx, cz, xz, 8);
                        rot(is59, is58, cy, cz, zy, 8);
                        final int[] is61 = new int[8];
                        final int[] is62 = new int[8];
                        int i63 = 0;
                        int i64 = 0;
                        int i65 = 0;
                        int i66 = 0;
                        boolean bool = true;
                        for (int i67 = 0; i67 < 8; i67++) {
                            is61[i67] = xs(is57[i67], is58[i67]);
                            is62[i67] = ys(is59[i67], is58[i67]);
                            if (is62[i67] < 0 || is58[i67] < 10) {
                                i63++;
                            }
                            if (is62[i67] > h || is58[i67] < 10) {
                                i64++;
                            }
                            if (is61[i67] < 0 || is58[i67] < 10) {
                                i65++;
                            }
                            if (is61[i67] > w || is58[i67] < 10) {
                                i66++;
                            }
                        }
                        if (i65 == 8 || i63 == 8 || i64 == 8 || i66 == 8) {
                            bool = false;
                        }
                        if (bool) {
                            int i68 = (int) ((cpol[0] * pcv[i53] + cgrnd[0]) / 2.0F);
                            int i69 = (int) ((cpol[1] * pcv[i53] + cgrnd[1]) / 2.0F);
                            int i70 = (int) ((cpol[2] * pcv[i53] + cgrnd[2]) / 2.0F);
                            if (i56 - pmx[i53] > fade[0]) {
                                i68 = (i68 * 7 + cfade[0]) / 8;
                                i69 = (i69 * 7 + cfade[1]) / 8;
                                i70 = (i70 * 7 + cfade[2]) / 8;
                            }
                            if (i56 - pmx[i53] > fade[1]) {
                                i68 = (i68 * 7 + cfade[0]) / 8;
                                i69 = (i69 * 7 + cfade[1]) / 8;
                                i70 = (i70 * 7 + cfade[2]) / 8;
                            }
                            graphics2d.setColor(new Color(i68, i69, i70));
                            graphics2d.fillPolygon(is61, is62, 8);
                        }
                    }
                }
            }
        }
        for (int i71 = i; i71 < i48; i71++) {
            for (int i72 = i49; i72 < i50; i72++)
                if (is[i71 - i][i72 - i49] != 0) {
                    final int i73 = i71 + i72 * nrw;
                    final int[] is74 = new int[8];
                    final int[] is75 = new int[8];
                    final int[] is76 = new int[8];
                    for (int i77 = 0; i77 < 8; i77++) {
                        is74[i77] = ogpx[i73][i77] + cgpx[i73] - x;
                        is75[i77] = ogpz[i73][i77] + cgpz[i73] - z;
                        is76[i77] = ground;
                    }
                    rot(is74, is75, cx, cz, xz, 8);
                    rot(is76, is75, cy, cz, zy, 8);
                    final int[] is78 = new int[8];
                    final int[] is79 = new int[8];
                    int i80 = 0;
                    int i81 = 0;
                    int i82 = 0;
                    int i83 = 0;
                    boolean bool = true;
                    for (int i84 = 0; i84 < 8; i84++) {
                        is78[i84] = xs(is74[i84], is75[i84]);
                        is79[i84] = ys(is76[i84], is75[i84]);
                        if (is79[i84] < 0 || is75[i84] < 10) {
                            i80++;
                        }
                        if (is79[i84] > h || is75[i84] < 10) {
                            i81++;
                        }
                        if (is78[i84] < 0 || is75[i84] < 10) {
                            i82++;
                        }
                        if (is78[i84] > w || is75[i84] < 10) {
                            i83++;
                        }
                    }
                    if (i82 == 8 || i80 == 8 || i81 == 8 || i83 == 8) {
                        bool = false;
                    }
                    if (bool) {
                        int i85 = (int) (cpol[0] * pcv[i73]);
                        int i86 = (int) (cpol[1] * pcv[i73]);
                        int i87 = (int) (cpol[2] * pcv[i73]);
                        if (is[i71 - i][i72 - i49] - pmx[i73] > fade[0]) {
                            i85 = (i85 * 7 + cfade[0]) / 8;
                            i86 = (i86 * 7 + cfade[1]) / 8;
                            i87 = (i87 * 7 + cfade[2]) / 8;
                        }
                        if (is[i71 - i][i72 - i49] - pmx[i73] > fade[1]) {
                            i85 = (i85 * 7 + cfade[0]) / 8;
                            i86 = (i86 * 7 + cfade[1]) / 8;
                            i87 = (i87 * 7 + cfade[2]) / 8;
                        }
                        graphics2d.setColor(new Color(i85, i86, i87));
                        graphics2d.fillPolygon(is78, is79, 8);
                    }
                }
        }
    }

    static void newclouds(int i, int i88, int i89, int i90) {
        clx = null;
        clz = null;
        cmx = null;
        clax = null;
        clay = null;
        claz = null;
        clc = null;
        i = i / 20 - 10000;
        i88 = i88 / 20 + 10000;
        i89 = i89 / 20 - 10000;
        i90 = i90 / 20 + 10000;
        noc = (i88 - i) * (i90 - i89) / 16666667;
        clx = new int[noc];
        clz = new int[noc];
        cmx = new int[noc];
        clax = new int[noc][3][12];
        clay = new int[noc][3][12];
        claz = new int[noc][3][12];
        clc = new int[noc][2][6][3];
        for (int i91 = 0; i91 < noc; i91++) {
            clx[i91] = (int) (i + (i88 - i) * ThreadLocalRandom.current().nextDouble());
            clz[i91] = (int) (i89 + (i90 - i89) * ThreadLocalRandom.current().nextDouble());
            final float f = (float) (0.25 + ThreadLocalRandom.current().nextDouble() * 1.25);
            float f92 = (float) ((200.0 + ThreadLocalRandom.current().nextDouble() * 700.0) * f);
            clax[i91][0][0] = (int) (f92 * 0.3826);
            claz[i91][0][0] = (int) (f92 * 0.9238);
            clay[i91][0][0] = (int) ((25.0 - ThreadLocalRandom.current().nextDouble() * 50.0) * f);
            f92 = (float) ((200.0 + ThreadLocalRandom.current().nextDouble() * 700.0) * f);
            clax[i91][0][1] = (int) (f92 * 0.7071);
            claz[i91][0][1] = (int) (f92 * 0.7071);
            clay[i91][0][1] = (int) ((25.0 - ThreadLocalRandom.current().nextDouble() * 50.0) * f);
            f92 = (float) ((200.0 + ThreadLocalRandom.current().nextDouble() * 700.0) * f);
            clax[i91][0][2] = (int) (f92 * 0.9238);
            claz[i91][0][2] = (int) (f92 * 0.3826);
            clay[i91][0][2] = (int) ((25.0 - ThreadLocalRandom.current().nextDouble() * 50.0) * f);
            f92 = (float) ((200.0 + ThreadLocalRandom.current().nextDouble() * 700.0) * f);
            clax[i91][0][3] = (int) (f92 * 0.9238);
            claz[i91][0][3] = -(int) (f92 * 0.3826);
            clay[i91][0][3] = (int) ((25.0 - ThreadLocalRandom.current().nextDouble() * 50.0) * f);
            f92 = (float) ((200.0 + ThreadLocalRandom.current().nextDouble() * 700.0) * f);
            clax[i91][0][4] = (int) (f92 * 0.7071);
            claz[i91][0][4] = -(int) (f92 * 0.7071);
            clay[i91][0][4] = (int) ((25.0 - ThreadLocalRandom.current().nextDouble() * 50.0) * f);
            f92 = (float) ((200.0 + ThreadLocalRandom.current().nextDouble() * 700.0) * f);
            clax[i91][0][5] = (int) (f92 * 0.3826);
            claz[i91][0][5] = -(int) (f92 * 0.9238);
            clay[i91][0][5] = (int) ((25.0 - ThreadLocalRandom.current().nextDouble() * 50.0) * f);
            f92 = (float) ((200.0 + ThreadLocalRandom.current().nextDouble() * 700.0) * f);
            clax[i91][0][6] = -(int) (f92 * 0.3826);
            claz[i91][0][6] = -(int) (f92 * 0.9238);
            clay[i91][0][6] = (int) ((25.0 - ThreadLocalRandom.current().nextDouble() * 50.0) * f);
            f92 = (float) ((200.0 + ThreadLocalRandom.current().nextDouble() * 700.0) * f);
            clax[i91][0][7] = -(int) (f92 * 0.7071);
            claz[i91][0][7] = -(int) (f92 * 0.7071);
            clay[i91][0][7] = (int) ((25.0 - ThreadLocalRandom.current().nextDouble() * 50.0) * f);
            f92 = (float) ((200.0 + ThreadLocalRandom.current().nextDouble() * 700.0) * f);
            clax[i91][0][8] = -(int) (f92 * 0.9238);
            claz[i91][0][8] = -(int) (f92 * 0.3826);
            clay[i91][0][8] = (int) ((25.0 - ThreadLocalRandom.current().nextDouble() * 50.0) * f);
            f92 = (float) ((200.0 + ThreadLocalRandom.current().nextDouble() * 700.0) * f);
            clax[i91][0][9] = -(int) (f92 * 0.9238);
            claz[i91][0][9] = (int) (f92 * 0.3826);
            clay[i91][0][9] = (int) ((25.0 - ThreadLocalRandom.current().nextDouble() * 50.0) * f);
            f92 = (float) ((200.0 + ThreadLocalRandom.current().nextDouble() * 700.0) * f);
            clax[i91][0][10] = -(int) (f92 * 0.7071);
            claz[i91][0][10] = (int) (f92 * 0.7071);
            clay[i91][0][10] = (int) ((25.0 - ThreadLocalRandom.current().nextDouble() * 50.0) * f);
            f92 = (float) ((200.0 + ThreadLocalRandom.current().nextDouble() * 700.0) * f);
            clax[i91][0][11] = -(int) (f92 * 0.3826);
            claz[i91][0][11] = (int) (f92 * 0.9238);
            clay[i91][0][11] = (int) ((25.0 - ThreadLocalRandom.current().nextDouble() * 50.0) * f);
            for (int i93 = 0; i93 < 12; i93++) {
                int i94 = i93 - 1;
                if (i94 == -1) {
                    i94 = 11;
                }
                int i95 = i93 + 1;
                if (i95 == 12) {
                    i95 = 0;
                }
                clax[i91][0][i93] = ((clax[i91][0][i94] + clax[i91][0][i95]) / 2 + clax[i91][0][i93]) / 2;
                clay[i91][0][i93] = ((clay[i91][0][i94] + clay[i91][0][i95]) / 2 + clay[i91][0][i93]) / 2;
                claz[i91][0][i93] = ((claz[i91][0][i94] + claz[i91][0][i95]) / 2 + claz[i91][0][i93]) / 2;
            }
            for (int i96 = 0; i96 < 12; i96++) {
                f92 = (float) (1.2 + 0.6 * ThreadLocalRandom.current().nextDouble());
                clax[i91][1][i96] = (int) (clax[i91][0][i96] * f92);
                claz[i91][1][i96] = (int) (claz[i91][0][i96] * f92);
                clay[i91][1][i96] = (int) (clay[i91][0][i96] - 100.0 * ThreadLocalRandom.current().nextDouble());
                f92 = (float) (1.1 + 0.3 * ThreadLocalRandom.current().nextDouble());
                clax[i91][2][i96] = (int) (clax[i91][1][i96] * f92);
                claz[i91][2][i96] = (int) (claz[i91][1][i96] * f92);
                clay[i91][2][i96] = (int) (clay[i91][1][i96] - 240.0 * ThreadLocalRandom.current().nextDouble());
            }
            cmx[i91] = 0;
            for (int i97 = 0; i97 < 12; i97++) {
                int i98 = i97 - 1;
                if (i98 == -1) {
                    i98 = 11;
                }
                int i99 = i97 + 1;
                if (i99 == 12) {
                    i99 = 0;
                }
                clay[i91][1][i97] = ((clay[i91][1][i98] + clay[i91][1][i99]) / 2 + clay[i91][1][i97]) / 2;
                clay[i91][2][i97] = ((clay[i91][2][i98] + clay[i91][2][i99]) / 2 + clay[i91][2][i97]) / 2;
                final int i100 = (int) Math.sqrt(clax[i91][2][i97] * clax[i91][2][i97] + claz[i91][2][i97] * claz[i91][2][i97]);
                if (i100 > cmx[i91]) {
                    cmx[i91] = i100;
                }
            }
            for (int i101 = 0; i101 < 6; i101++) {
                final double d = ThreadLocalRandom.current().nextDouble();
                final double d102 = ThreadLocalRandom.current().nextDouble();
                for (int i103 = 0; i103 < 3; i103++) {
                    f92 = clds[i103] * 1.05F - clds[i103];
                    clc[i91][0][i101][i103] = (int) (clds[i103] + f92 * d);
                    if (clc[i91][0][i101][i103] > 255) {
                        clc[i91][0][i101][i103] = 255;
                    }
                    if (clc[i91][0][i101][i103] < 0) {
                        clc[i91][0][i101][i103] = 0;
                    }
                    clc[i91][1][i101][i103] = (int) (clds[i103] * 1.05F + f92 * d102);
                    if (clc[i91][1][i101][i103] > 255) {
                        clc[i91][1][i101][i103] = 255;
                    }
                    if (clc[i91][1][i101][i103] < 0) {
                        clc[i91][1][i101][i103] = 0;
                    }
                }
            }
        }
    }

    static void newmountains(final int i, final int i167, final int i168, final int i169) {
        final Random random = new Random(mgen);
        nmt = (int) (20.0 + 10.0 * random.nextDouble());
        final int i170 = (i + i167) / 60;
        final int i171 = (i168 + i169) / 60;
        final int i172 = Math.max(i167 - i, i169 - i168) / 60;
        mrd = null;
        nmv = null;
        mtx = null;
        mty = null;
        mtz = null;
        mtc = null;
        mrd = new int[nmt];
        nmv = new int[nmt];
        mtx = new int[nmt][];
        mty = new int[nmt][];
        mtz = new int[nmt][];
        mtc = new int[nmt][][];
        final int[] is = new int[nmt];
        final int[] is173 = new int[nmt];
        for (int i174 = 0; i174 < nmt; i174++) {
            int i175;
            float f;
            float f176;
            is[i174] = (int) (10000.0 + random.nextDouble() * 10000.0);
            final int i177 = (int) (random.nextDouble() * 360.0);
            if (random.nextDouble() > random.nextDouble()) {
                f = (float) (0.2 + random.nextDouble() * 0.35);
                f176 = (float) (0.2 + random.nextDouble() * 0.35);
                nmv[i174] = (int) (f * (24.0 + 16.0 * random.nextDouble()));
                i175 = (int) (85.0 + 10.0 * random.nextDouble());
            } else {
                f = (float) (0.3 + random.nextDouble() * 1.1);
                f176 = (float) (0.2 + random.nextDouble() * 0.35);
                nmv[i174] = (int) (f * (12.0 + 8.0 * random.nextDouble()));
                i175 = (int) (104.0 - 10.0 * random.nextDouble());
            }
            mtx[i174] = new int[nmv[i174] * 2];
            mty[i174] = new int[nmv[i174] * 2];
            mtz[i174] = new int[nmv[i174] * 2];
            mtc[i174] = new int[nmv[i174]][3];
            for (int i178 = 0; i178 < nmv[i174]; i178++) {
                mtx[i174][i178] = (int) ((i178 * 500 + (random.nextDouble() * 800.0 - 400.0) - 250 * (nmv[i174] - 1)) * f);
                mtx[i174][i178 + nmv[i174]] = (int) ((i178 * 500 + (random.nextDouble() * 800.0 - 400.0) - 250 * (nmv[i174] - 1)) * f);
                mtx[i174][nmv[i174]] = (int) (mtx[i174][0] - (100.0 + random.nextDouble() * 600.0) * f);
                mtx[i174][nmv[i174] * 2 - 1] = (int) (mtx[i174][nmv[i174] - 1] + (100.0 + random.nextDouble() * 600.0) * f);
                if (i178 == 0 || i178 == nmv[i174] - 1) {
                    mty[i174][i178] = (int) ((-400.0 - 1200.0 * random.nextDouble()) * f176 + ground);
                }
                if (i178 == 1 || i178 == nmv[i174] - 2) {
                    mty[i174][i178] = (int) ((-1000.0 - 1450.0 * random.nextDouble()) * f176 + ground);
                }
                if (i178 > 1 && i178 < nmv[i174] - 2) {
                    mty[i174][i178] = (int) ((-1600.0 - 1700.0 * random.nextDouble()) * f176 + ground);
                }
                mty[i174][i178 + nmv[i174]] = ground - 70;
                mtz[i174][i178] = i171 + i172 + is[i174];
                mtz[i174][i178 + nmv[i174]] = i171 + i172 + is[i174];
                final float f179 = (float) (0.5 + random.nextDouble() * 0.5);
                mtc[i174][i178][0] = (int) (170.0F * f179 + 170.0F * f179 * (snap[0] / 100.0F));
                if (mtc[i174][i178][0] > 255) {
                    mtc[i174][i178][0] = 255;
                }
                if (mtc[i174][i178][0] < 0) {
                    mtc[i174][i178][0] = 0;
                }
                mtc[i174][i178][1] = (int) (i175 * f179 + 85.0F * f179 * (snap[1] / 100.0F));
                if (mtc[i174][i178][1] > 255) {
                    mtc[i174][i178][1] = 255;
                }
                if (mtc[i174][i178][1] < 1) {
                    mtc[i174][i178][1] = 0;
                }
                mtc[i174][i178][2] = 0;
            }
            for (int i180 = 1; i180 < nmv[i174] - 1; i180++) {
                final int i181 = i180 - 1;
                final int i182 = i180 + 1;
                mty[i174][i180] = ((mty[i174][i181] + mty[i174][i182]) / 2 + mty[i174][i180]) / 2;
            }
            rot(mtx[i174], mtz[i174], i170, i171, i177, nmv[i174] * 2);
            is173[i174] = 0;
        }
        for (int i183 = 0; i183 < nmt; i183++) {
            for (int i184 = i183 + 1; i184 < nmt; i184++)
                if (is[i183] < is[i184]) {
                    is173[i183]++;
                } else {
                    is173[i184]++;
                }
            mrd[is173[i183]] = i183;
        }
    }

    static void newpolys(final int i, final int i35, final int i36, final int i37, final int i38) {
        final Random random = new Random((i38 + cgrnd[0] + cgrnd[1] + cgrnd[2]) * 1671);
        nrw = i35 / 1200 + 9;
        ncl = i37 / 1200 + 9;
        sgpx = i - 4800;
        sgpz = i36 - 4800;
        ogpx = null;
        ogpz = null;
        pvr = null;
        cgpx = null;
        cgpz = null;
        pmx = null;
        pcv = null;
        ogpx = new int[nrw * ncl][8];
        ogpz = new int[nrw * ncl][8];
        pvr = new float[nrw * ncl][8];
        cgpx = new int[nrw * ncl];
        cgpz = new int[nrw * ncl];
        pmx = new int[nrw * ncl];
        pcv = new float[nrw * ncl];
        int i39 = 0;
        int i40 = 0;
        for (int i41 = 0; i41 < nrw * ncl; i41++) {
            cgpx[i41] = sgpx + i39 * 1200 + (int) (random.nextDouble() * 1000.0 - 500.0);
            cgpz[i41] = sgpz + i40 * 1200 + (int) (random.nextDouble() * 1000.0 - 500.0);
            for (int i42 = 0; i42 < Trackers.nt; i42++)
                if (Trackers.zy[i42] == 0 && Trackers.xy[i42] == 0) {
                    if (Trackers.radx[i42] < Trackers.radz[i42] && Math.abs(cgpz[i41] - Trackers.z[i42]) < Trackers.radz[i42]) {
                        for (/**/; Math.abs(cgpx[i41] - Trackers.x[i42]) < Trackers.radx[i42]; cgpx[i41] += random.nextDouble() * Trackers.radx[i42] * 2.0 - Trackers.radx[i42]) {

                        }
                    }
                    if (Trackers.radz[i42] < Trackers.radx[i42] && Math.abs(cgpx[i41] - Trackers.x[i42]) < Trackers.radx[i42]) {
                        for (/**/; Math.abs(cgpz[i41] - Trackers.z[i42]) < Trackers.radz[i42]; cgpz[i41] += random.nextDouble() * Trackers.radz[i42] * 2.0 - Trackers.radz[i42]) {

                        }
                    }
                }
            if (++i39 == nrw) {
                i39 = 0;
                i40++;
            }
        }
        for (int i43 = 0; i43 < nrw * ncl; i43++) {
            final float f = (float) (0.3 + 1.6 * random.nextDouble());
            ogpx[i43][0] = 0;
            ogpz[i43][0] = (int) ((100.0 + random.nextDouble() * 760.0) * f);
            ogpx[i43][1] = (int) ((100.0 + random.nextDouble() * 760.0) * 0.7071 * f);
            ogpz[i43][1] = ogpx[i43][1];
            ogpx[i43][2] = (int) ((100.0 + random.nextDouble() * 760.0) * f);
            ogpz[i43][2] = 0;
            ogpx[i43][3] = (int) ((100.0 + random.nextDouble() * 760.0) * 0.7071 * f);
            ogpz[i43][3] = -ogpx[i43][3];
            ogpx[i43][4] = 0;
            ogpz[i43][4] = -(int) ((100.0 + random.nextDouble() * 760.0) * f);
            ogpx[i43][5] = -(int) ((100.0 + random.nextDouble() * 760.0) * 0.7071 * f);
            ogpz[i43][5] = ogpx[i43][5];
            ogpx[i43][6] = -(int) ((100.0 + random.nextDouble() * 760.0) * f);
            ogpz[i43][6] = 0;
            ogpx[i43][7] = -(int) ((100.0 + random.nextDouble() * 760.0) * 0.7071 * f);
            ogpz[i43][7] = -ogpx[i43][7];
            for (int i44 = 0; i44 < 8; i44++) {
                int i45 = i44 - 1;
                if (i45 == -1) {
                    i45 = 7;
                }
                int i46 = i44 + 1;
                if (i46 == 8) {
                    i46 = 0;
                }
                ogpx[i43][i44] = ((ogpx[i43][i45] + ogpx[i43][i46]) / 2 + ogpx[i43][i44]) / 2;
                ogpz[i43][i44] = ((ogpz[i43][i45] + ogpz[i43][i46]) / 2 + ogpz[i43][i44]) / 2;
                pvr[i43][i44] = (float) (1.1 + random.nextDouble() * 0.8);
                final int i47 = (int) Math.sqrt((int) (ogpx[i43][i44] * ogpx[i43][i44] * pvr[i43][i44] * pvr[i43][i44] + ogpz[i43][i44] * ogpz[i43][i44] * pvr[i43][i44] * pvr[i43][i44]));
                if (i47 > pmx[i43]) {
                    pmx[i43] = i47;
                }
            }
            pcv[i43] = (float) (0.97 + random.nextDouble() * 0.03);
            if (pcv[i43] > 1.0F) {
                pcv[i43] = 1.0F;
            }
            if (random.nextDouble() > random.nextDouble()) {
                pcv[i43] = 1.0F;
            }
        }
    }

    static void newstars() {
        stx = null;
        stz = null;
        stc = null;
        bst = null;
        twn = null;
        nst = 0;
        if (lightson) {
            final Random random = new Random((long) (ThreadLocalRandom.current().nextDouble() * 100000.0));
            nst = 40;
            stx = new int[nst];
            stz = new int[nst];
            stc = new int[nst][2][3];
            bst = new boolean[nst];
            twn = new int[nst];
            for (int i = 0; i < nst; i++) {
                stx[i] = (int) (2000.0 * random.nextDouble() - 1000.0);
                stz[i] = (int) (2000.0 * random.nextDouble() - 1000.0);
                int i212 = (int) (3.0 * random.nextDouble());
                if (i212 >= 3) {
                    i212 = 0;
                }
                if (i212 <= -1) {
                    i212 = 2;
                }
                int i213 = i212 + 1;
                if (random.nextDouble() > random.nextDouble()) {
                    i213 = i212 - 1;
                }
                if (i213 == 3) {
                    i213 = 0;
                }
                if (i213 == -1) {
                    i213 = 2;
                }
                for (int i214 = 0; i214 < 3; i214++) {
                    stc[i][0][i214] = 200;
                    if (i212 == i214) {
                        stc[i][0][i214] += (int) (55.0 * random.nextDouble());
                    }
                    if (i213 == i214) {
                        stc[i][0][i214] += 55;
                    }
                    stc[i][0][i214] = (stc[i][0][i214] * 2 + csky[i214]) / 3;
                    stc[i][1][i214] = (stc[i][0][i214] + csky[i214]) / 2;
                }
                twn[i] = (int) (4.0 * random.nextDouble());
                bst[i] = random.nextDouble() > 0.8;
            }
        }
    }

    static float random() {
        if (cntrn == 0) {
            for (int i = 0; i < 3; i++) {
                rand[i] = (int) (10.0 * ThreadLocalRandom.current().nextDouble());
                diup[i] = ThreadLocalRandom.current().nextDouble() <= ThreadLocalRandom.current().nextDouble();
            }
            cntrn = 20;
        } else {
            cntrn--;
        }
        for (int i = 0; i < 3; i++)
            if (diup[i]) {
                rand[i]++;
                if (rand[i] == 10) {
                    rand[i] = 0;
                }
            } else {
                rand[i]--;
                if (rand[i] == -1) {
                    rand[i] = 9;
                }
            }
        trn++;
        if (trn == 3) {
            trn = 0;
        }
        return rand[trn] / 10.0F;
    }

    static private void rot(final int[] is, final int[] is274, final int i, final int i275, final int i276, final int i277) {
        if (i276 != 0) {
            for (int i278 = 0; i278 < i277; i278++) {
                final int i279 = is[i278];
                final int i280 = is274[i278];
                is[i278] = i + (int) ((i279 - i) * cos(i276) - (i280 - i275) * sin(i276));
                is274[i278] = i275 + (int) ((i279 - i) * sin(i276) + (i280 - i275) * cos(i276));
            }
        }
    }

    static void setcloads(final int i, final int i252, final int i253, int i254, int i255) {
        if (i254 < 0) {
            i254 = 0;
        }
        if (i254 > 10) {
            i254 = 10;
        }
        if (i255 < -1500) {
            i255 = -1500;
        }
        if (i255 > -500) {
            i255 = -500;
        }
        cldd[0] = i;
        cldd[1] = i252;
        cldd[2] = i253;
        cldd[3] = i254;
        cldd[4] = i255;
        for (int i256 = 0; i256 < 3; i256++) {
            clds[i256] = (osky[i256] * cldd[3] + cldd[i256]) / (cldd[3] + 1);
            clds[i256] = (int) (clds[i256] + clds[i256] * (snap[i256] / 100.0F));
            if (clds[i256] > 255) {
                clds[i256] = 255;
            }
            if (clds[i256] < 0) {
                clds[i256] = 0;
            }
        }
    }

    static void setexture(int i, int i261, int i262, int i263) {
        if (i263 < 20) {
            i263 = 20;
        }
        if (i263 > 60) {
            i263 = 60;
        }
        texture[0] = i;
        texture[1] = i261;
        texture[2] = i262;
        texture[3] = i263;
        i = (ogrnd[0] * i263 + i) / (1 + i263);
        i261 = (ogrnd[1] * i263 + i261) / (1 + i263);
        i262 = (ogrnd[2] * i263 + i262) / (1 + i263);
        cpol[0] = (int) (i + i * (snap[0] / 100.0F));
        if (cpol[0] > 255) {
            cpol[0] = 255;
        }
        if (cpol[0] < 0) {
            cpol[0] = 0;
        }
        cpol[1] = (int) (i261 + i261 * (snap[1] / 100.0F));
        if (cpol[1] > 255) {
            cpol[1] = 255;
        }
        if (cpol[1] < 0) {
            cpol[1] = 0;
        }
        cpol[2] = (int) (i262 + i262 * (snap[2] / 100.0F));
        if (cpol[2] > 255) {
            cpol[2] = 255;
        }
        if (cpol[2] < 0) {
            cpol[2] = 0;
        }
        for (int i264 = 0; i264 < 3; i264++) {
            crgrnd[i264] = (int) ((cpol[i264] * 0.99 + cgrnd[i264]) / 2.0);
        }
    }

    static void setfade(final int i, final int i268, final int i269) {
        cfade[0] = (int) (i + i * (snap[0] / 100.0F));
        if (cfade[0] > 255) {
            cfade[0] = 255;
        }
        if (cfade[0] < 0) {
            cfade[0] = 0;
        }
        cfade[1] = (int) (i268 + i268 * (snap[1] / 100.0F));
        if (cfade[1] > 255) {
            cfade[1] = 255;
        }
        if (cfade[1] < 0) {
            cfade[1] = 0;
        }
        cfade[2] = (int) (i269 + i269 * (snap[2] / 100.0F));
        if (cfade[2] > 255) {
            cfade[2] = 255;
        }
        if (cfade[2] < 0) {
            cfade[2] = 0;
        }
    }

    static void setgrnd(final int i, final int i257, final int i258) {
        ogrnd[0] = i;
        ogrnd[1] = i257;
        ogrnd[2] = i258;
        for (int i259 = 0; i259 < 3; i259++) {
            cpol[i259] = (ogrnd[i259] * texture[3] + texture[i259]) / (1 + texture[3]);
            cpol[i259] = (int) (cpol[i259] + cpol[i259] * (snap[i259] / 100.0F));
            if (cpol[i259] > 255) {
                cpol[i259] = 255;
            }
            if (cpol[i259] < 0) {
                cpol[i259] = 0;
            }
        }
        cgrnd[0] = (int) (i + i * (snap[0] / 100.0F));
        if (cgrnd[0] > 255) {
            cgrnd[0] = 255;
        }
        if (cgrnd[0] < 0) {
            cgrnd[0] = 0;
        }
        cgrnd[1] = (int) (i257 + i257 * (snap[1] / 100.0F));
        if (cgrnd[1] > 255) {
            cgrnd[1] = 255;
        }
        if (cgrnd[1] < 0) {
            cgrnd[1] = 0;
        }
        cgrnd[2] = (int) (i258 + i258 * (snap[2] / 100.0F));
        if (cgrnd[2] > 255) {
            cgrnd[2] = 255;
        }
        if (cgrnd[2] < 0) {
            cgrnd[2] = 0;
        }
        for (int i260 = 0; i260 < 3; i260++) {
            crgrnd[i260] = (int) ((cpol[i260] * 0.99 + cgrnd[i260]) / 2.0);
        }
    }

    static void setpolys(final int i, final int i265, final int i266) {
        cpol[0] = (int) (i + i * (snap[0] / 100.0F));
        if (cpol[0] > 255) {
            cpol[0] = 255;
        }
        if (cpol[0] < 0) {
            cpol[0] = 0;
        }
        cpol[1] = (int) (i265 + i265 * (snap[1] / 100.0F));
        if (cpol[1] > 255) {
            cpol[1] = 255;
        }
        if (cpol[1] < 0) {
            cpol[1] = 0;
        }
        cpol[2] = (int) (i266 + i266 * (snap[2] / 100.0F));
        if (cpol[2] > 255) {
            cpol[2] = 255;
        }
        if (cpol[2] < 0) {
            cpol[2] = 0;
        }
        for (int i267 = 0; i267 < 3; i267++) {
            crgrnd[i267] = (int) ((cpol[i267] * 0.99 + cgrnd[i267]) / 2.0);
        }
    }

    static void setsky(final int i, final int i249, final int i250) {
        osky[0] = i;
        osky[1] = i249;
        osky[2] = i250;
        for (int i251 = 0; i251 < 3; i251++) {
            clds[i251] = (osky[i251] * cldd[3] + cldd[i251]) / (cldd[3] + 1);
            clds[i251] = (int) (clds[i251] + clds[i251] * (snap[i251] / 100.0F));
            if (clds[i251] > 255) {
                clds[i251] = 255;
            }
            if (clds[i251] < 0) {
                clds[i251] = 0;
            }
        }
        csky[0] = (int) (i + i * (snap[0] / 100.0F));
        if (csky[0] > 255) {
            csky[0] = 255;
        }
        if (csky[0] < 0) {
            csky[0] = 0;
        }
        csky[1] = (int) (i249 + i249 * (snap[1] / 100.0F));
        if (csky[1] > 255) {
            csky[1] = 255;
        }
        if (csky[1] < 0) {
            csky[1] = 0;
        }
        csky[2] = (int) (i250 + i250 * (snap[2] / 100.0F));
        if (csky[2] > 255) {
            csky[2] = 255;
        }
        if (csky[2] < 0) {
            csky[2] = 0;
        }
        final float[] fs = new float[3];
        Color.RGBtoHSB(csky[0], csky[1], csky[2], fs);
        darksky = fs[2] < 0.6;
    }

    static void setsnap(final int i, final int i247, final int i248) {
        snap[0] = i;
        snap[1] = i247;
        snap[2] = i248;
    }

    static float sin(int i) {
        for (/**/; i >= 360; i -= 360) {

        }
        for (/**/; i < 0; i += 360) {

        }
        return tsin[i];
    }

    static void transaround(final ContO conto, final ContO conto18, final int i) {
        final int i19 = (conto.x * (20 - i) + conto18.x * i) / 20;
        final int i20 = (conto.y * (20 - i) + conto18.y * i) / 20;
        final int i21 = (conto.z * (20 - i) + conto18.z * i) / 20;
        if (!vert) {
            adv += 2;
        } else {
            adv -= 2;
        }
        if (adv > 900) {
            vert = true;
        }
        if (adv < -500) {
            vert = false;
        }
        int i22 = 500 + adv;
        if (i22 < 1000) {
            i22 = 1000;
        }
        y = i20 - adv;
        if (y > 10) {
            vert = false;
        }
        x = i19 + (int) ((i19 - i22 - i19) * cos(vxz));
        z = i21 + (int) ((i19 - i22 - i19) * sin(vxz));
        vxz += 2;
        int i23 = 0;
        int i24 = y;
        if (i24 > 0) {
            i24 = 0;
        }
        if (i20 - i24 - cy < 0) {
            i23 = -180;
        }
        final int i25 = (int) Math.sqrt((i21 - z + cz) * (i21 - z + cz) + (i19 - x - cx) * (i19 - x - cx));
        final int i26 = (int) (90 + i23 - Math.atan((double) i25 / (double) (i20 - i24 - cy)) / 0.017453292519943295);
        xz = -vxz + 90;
        zy += (i26 - zy) / 10;
    }

    static void watch(final ContO conto, final int i) {
        if (td) {
            y = (int) (conto.y - 300 - 1100.0F * random());
            x = conto.x + (int) ((conto.x + 400 - conto.x) * cos(i) - (conto.z + 5000 - conto.z) * sin(i));
            z = conto.z + (int) ((conto.x + 400 - conto.x) * sin(i) + (conto.z + 5000 - conto.z) * cos(i));
            td = false;
        }
        int i0 = 0;
        if (conto.x - x - cx > 0) {
            i0 = 180;
        }
        int i1 = -(int) (90 + i0 + Math.atan((double) (conto.z - z) / (double) (conto.x - x - cx)) / 0.017453292519943295);
        i0 = 0;
        if (conto.y - y - cy < 0) {
            i0 = -180;
        }
        final int i2 = (int) Math.sqrt((conto.z - z) * (conto.z - z) + (conto.x - x - cx) * (conto.x - x - cx));
        final int i3 = (int) (90 + i0 - Math.atan((double) i2 / (double) (conto.y - y - cy)) / 0.017453292519943295);
        for (/**/; i1 < 0; i1 += 360) {

        }
        for (/**/; i1 > 360; i1 -= 360) {

        }
        xz = i1;
        zy += (i3 - zy) / 5;
        if ((int) Math.sqrt((conto.z - z) * (conto.z - z) + (conto.x - x - cx) * (conto.x - x - cx) + (conto.y - y - cy) * (conto.y - y - cy)) > 6000) {
            td = true;
        }
    }

    static private int xs(final int i, int i272) {
        if (i272 < cz) {
            i272 = cz;
        }
        return (i272 - focusPoint) * (cx - i) / i272 + i;
    }

    static private int ys(final int i, int i273) {
        if (i273 < 10) {
            i273 = 10;
        }
        return (i273 - focusPoint) * (cy - i) / i273 + i;
    }
}
