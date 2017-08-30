package nfm.open;
/* Mad - Decompiled by JODE
 * Visit http://jode.sourceforge.net/
 */
import java.awt.Color;

class Mad {
    boolean btab = false;
    int capcnt = 0;
    boolean capsized = false;
    private final boolean[] caught = new boolean[8];
    Stat stat;
    int clear = 0;
    int cn = 0;
    int cntdest = 0;
    private int cntouch = 0;
    private boolean colidim = false;
    private final int[][] crank = new int[4][4];
    int cxz = 0;
    private int dcnt = 0;
    float dcomp = 0.0F;
    boolean dest = false;
    private final boolean[] dominate = new boolean[8];
    private final float drag = 0.5F;
    private int fixes = -1;
    private int focus = -1;
    private float forca = 0.0F;
    boolean ftab = false;
    private int fxz = 0;
    boolean gtouch = false;
    int hitmag = 0;
    int im = 0;
    int lastcolido = 0;
    float lcomp = 0.0F;
    private final int[][] lcrank = new int[4][4];
    int loop = 0;
    private int lxz = 0;
    int missedcp = 0;
    boolean mtouch = false;
    int mxz = 0;
    private int nbsq = 0;
    boolean newcar = false;
    int newedcar = 0;
    int nlaps = 0;
    private int nmlt = 1;
    boolean nofocus = false;
    int outshakedam = 0;
    int pcleared = 0;
    boolean pd = false;
    boolean pl = false;
    private int pmlt = 1;
    int point = 0;
    float power = 75.0F;
    float powerup = 0.0F;
    boolean pr = false;
    boolean pu = false;
    boolean pushed = false;
    int pxy = 0;
    int pzy = 0;
    float rcomp = 0.0F;
    private int rpdcatch = 0;
    boolean rtab = false;
    final float[] scx = new float[4];
    final float[] scy = new float[4];
    final float[] scz = new float[4];
    int shakedam = 0;
    int skid = 0;
    float speed = 0.0F;
    int squash = 0;
    private int srfcnt = 0;
    boolean surfer = false;
    private float tilt = 0.0F;
    int travxy = 0;
    int travxz = 0;
    int travzy = 0;
    int trcnt = 0;
    int txz = 0;
    float ucomp = 0.0F;
    boolean wtouch = false;
    private int xtpower = 0;

    Mad(final Stat stat, final int i) {
        this.stat = stat;
        im = i;
    }

    public void setStat(final Stat stat) {
        this.stat = stat;
    }

    void colide(final ContO conto, final Mad mad118, final ContO conto119) {
        final float[] fs = new float[4];
        final float[] fs120 = new float[4];
        final float[] fs121 = new float[4];
        final float[] fs122 = new float[4];
        final float[] fs123 = new float[4];
        final float[] fs124 = new float[4];
        for (int i = 0; i < 4; i++) {
            fs[i] = conto.x + conto.keyx[i];
            if (capsized) {
                fs120[i] = conto.y + stat.flipy + squash;
            } else {
                fs120[i] = conto.y + conto.grat;
            }
            fs121[i] = conto.z + conto.keyz[i];
            fs122[i] = conto119.x + conto119.keyx[i];
            if (capsized) {
                fs123[i] = conto119.y + mad118.stat.flipy + mad118.squash;
            } else {
                fs123[i] = conto119.y + conto119.grat;
            }
            fs124[i] = conto119.z + conto119.keyz[i];
        }
        rot(fs, fs120, conto.x, conto.y, conto.xy, 4);
        rot(fs120, fs121, conto.y, conto.z, conto.zy, 4);
        rot(fs, fs121, conto.x, conto.z, conto.xz, 4);
        rot(fs122, fs123, conto119.x, conto119.y, conto119.xy, 4);
        rot(fs123, fs124, conto119.y, conto119.z, conto119.zy, 4);
        rot(fs122, fs124, conto119.x, conto119.z, conto119.xz, 4);
        if (rpy(conto.x, conto119.x, conto.y, conto119.y, conto.z, conto119.z) < (conto.maxR * conto.maxR + conto119.maxR * conto119.maxR) * 1.5) {
            if (!caught[mad118.im] && (speed != 0.0F || mad118.speed != 0.0F)) {
                if (Math.abs(power * speed * stat.moment) != Math.abs(mad118.power * mad118.speed * mad118.stat.moment)) {
                    dominate[mad118.im] = Math.abs(power * speed * stat.moment) > Math.abs(mad118.power * mad118.speed * mad118.stat.moment);
                } else dominate[mad118.im] = stat.moment > mad118.stat.moment;
                caught[mad118.im] = true;
            }
        } else if (caught[mad118.im]) {
            caught[mad118.im] = false;
        }
        int i = 0;
        int i125 = 0;
        if (dominate[mad118.im]) {
            final int i126 = (int) (((scz[0] - mad118.scz[0] + scz[1] - mad118.scz[1] + scz[2] - mad118.scz[2] + scz[3] - mad118.scz[3]) * (scz[0] - mad118.scz[0] + scz[1] - mad118.scz[1] + scz[2] - mad118.scz[2] + scz[3] - mad118.scz[3]) + (scx[0] - mad118.scx[0] + scx[1] - mad118.scx[1] + scx[2] - mad118.scx[2] + scx[3] - mad118.scx[3]) * (scx[0] - mad118.scx[0] + scx[1] - mad118.scx[1] + scx[2] - mad118.scx[2] + scx[3] - mad118.scx[3])) / 16.0F);
            int i127 = 7000;
            float f = 1.0F;
            if (xtGraphics.multion != 0) {
                i127 = 28000;
                f = 1.27F;
            }
            for (int i128 = 0; i128 < 4; i128++) {
                for (int i129 = 0; i129 < 4; i129++)
                    if (rpy(fs[i128], fs122[i129], fs120[i128], fs123[i129], fs121[i128], fs124[i129]) < (i126 + i127) * (mad118.stat.comprad + stat.comprad)) {
                        if (Math.abs(scx[i128] * stat.moment) > Math.abs(mad118.scx[i129] * mad118.stat.moment)) {
                            float f130 = mad118.scx[i129] * stat.revpush;
                            if (f130 > 300.0F) {
                                f130 = 300.0F;
                            }
                            if (f130 < -300.0F) {
                                f130 = -300.0F;
                            }
                            float f131 = scx[i128] * stat.push;
                            if (f131 > 300.0F) {
                                f131 = 300.0F;
                            }
                            if (f131 < -300.0F) {
                                f131 = -300.0F;
                            }
                            mad118.scx[i129] += f131;
                            if (im == xtGraphics.im) {
                                mad118.colidim = true;
                            }
                            i += mad118.regx(i129, f131 * stat.moment * f, conto119);
                            if (mad118.colidim) {
                                mad118.colidim = false;
                            }
                            scx[i128] -= f130;
                            i125 += regx(i128, -f130 * stat.moment * f, conto);
                            scy[i128] -= stat.revlift;
                            if (im == xtGraphics.im) {
                                mad118.colidim = true;
                            }
                            i += mad118.regy(i129, stat.revlift * 7, conto119);
                            if (mad118.colidim) {
                                mad118.colidim = false;
                            }
                            if (Medium.random() > Medium.random()) {
                                conto119.sprk((fs[i128] + fs122[i129]) / 2.0F, (fs120[i128] + fs123[i129]) / 2.0F, (fs121[i128] + fs124[i129]) / 2.0F, (mad118.scx[i129] + scx[i128]) / 4.0F, (mad118.scy[i129] + scy[i128]) / 4.0F, (mad118.scz[i129] + scz[i128]) / 4.0F, 2);
                            }
                        }
                        if (Math.abs(scz[i128] * stat.moment) > Math.abs(mad118.scz[i129] * mad118.stat.moment)) {
                            float f132 = mad118.scz[i129] * stat.revpush;
                            if (f132 > 300.0F) {
                                f132 = 300.0F;
                            }
                            if (f132 < -300.0F) {
                                f132 = -300.0F;
                            }
                            float f133 = scz[i128] * stat.push;
                            if (f133 > 300.0F) {
                                f133 = 300.0F;
                            }
                            if (f133 < -300.0F) {
                                f133 = -300.0F;
                            }
                            mad118.scz[i129] += f133;
                            if (im == xtGraphics.im) {
                                mad118.colidim = true;
                            }
                            i += mad118.regz(i129, f133 * stat.moment * f, conto119);
                            if (mad118.colidim) {
                                mad118.colidim = false;
                            }
                            scz[i128] -= f132;
                            i125 += regz(i128, -f132 * stat.moment * f, conto);
                            scy[i128] -= stat.revlift;
                            if (im == xtGraphics.im) {
                                mad118.colidim = true;
                            }
                            i += mad118.regy(i129, stat.revlift * 7, conto119);
                            if (mad118.colidim) {
                                mad118.colidim = false;
                            }
                            if (Medium.random() > Medium.random()) {
                                conto119.sprk((fs[i128] + fs122[i129]) / 2.0F, (fs120[i128] + fs123[i129]) / 2.0F, (fs121[i128] + fs124[i129]) / 2.0F, (mad118.scx[i129] + scx[i128]) / 4.0F, (mad118.scy[i129] + scy[i128]) / 4.0F, (mad118.scz[i129] + scz[i128]) / 4.0F, 2);
                            }
                        }
                        if (im == xtGraphics.im) {
                            mad118.lastcolido = 70;
                        }
                        if (mad118.im == xtGraphics.im) {
                            lastcolido = 70;
                        }
                        mad118.scy[i129] -= stat.lift;
                    }
            }
        }
        if (xtGraphics.multion == 1) {
            if (mad118.im == xtGraphics.im && i != 0) {
                xtGraphics.dcrashes[im] += i;
            }
            if (im == xtGraphics.im && i125 != 0) {
                xtGraphics.dcrashes[mad118.im] += i125;
            }
        }
    }

    private void distruct(final ContO conto) {
        for (int i = 0; i < conto.npl; i++)
            if (conto.p[i].wz == 0 || conto.p[i].gr == -17 || conto.p[i].gr == -16) {
                conto.p[i].embos = 1;
            }
    }

    void drive(final Control control, final ContO conto) {
        int i = 1;
        int i4 = 1;
        boolean bool = false;
        boolean bool5 = false;
        boolean bool6 = false;
        capsized = false;
        int i7;
        for (i7 = Math.abs(pzy); i7 > 270; i7 -= 360) {

        }
        i7 = Math.abs(i7);
        if (i7 > 90) {
            bool = true;
        }
        boolean bool8 = false;
        int i9;
        for (i9 = Math.abs(pxy); i9 > 270; i9 -= 360) {

        }
        i9 = Math.abs(i9);
        if (i9 > 90) {
            bool8 = true;
            i4 = -1;
        }
        int i10 = conto.grat;
        if (bool) {
            if (bool8) {
                bool8 = false;
                bool5 = true;
            } else {
                bool8 = true;
                capsized = true;
            }
            i = -1;
        } else if (bool8) {
            capsized = true;
        }
        if (capsized) {
            i10 = stat.flipy + squash;
        }
        control.zyinv = bool;
        float f = 0.0F;
        float f11 = 0.0F;
        float f12 = 0.0F;
        if (mtouch) {
            loop = 0;
        }
        if (wtouch) {
            if (loop == 2 || loop == -1) {
                loop = -1;
                if (control.left) {
                    pl = true;
                }
                if (control.right) {
                    pr = true;
                }
                if (control.up) {
                    pu = true;
                }
                if (control.down) {
                    pd = true;
                }
            }
            ucomp = 0.0F;
            dcomp = 0.0F;
            lcomp = 0.0F;
            rcomp = 0.0F;
        }
        if (control.handb) {
            if (!pushed)
                if (!wtouch) {
                    if (loop == 0) {
                        loop = 1;
                    }
                } else if (gtouch) {
                    pushed = true;
                }
        } else {
            pushed = false;
        }
        if (loop == 1) {
            final float f13 = (scy[0] + scy[1] + scy[2] + scy[3]) / 4.0F;
            for (int i14 = 0; i14 < 4; i14++) {
                scy[i14] = f13;
            }
            loop = 2;
        }
        if (!dest)
            if (loop == 2) {
                if (control.up) {
                    if (ucomp == 0.0F) {
                        ucomp = 10.0F + (scy[0] + 50.0F) / 20.0F;
                        if (ucomp < 5.0F) {
                            ucomp = 5.0F;
                        }
                        if (ucomp > 10.0F) {
                            ucomp = 10.0F;
                        }
                        ucomp *= stat.airs;
                    }
                    if (ucomp < 20.0F) {
                        ucomp += 0.5 * stat.airs;
                    }
                    f = -stat.airc * Medium.sin(conto.xz) * i4;
                    f11 = stat.airc * Medium.cos(conto.xz) * i4;
                } else if (ucomp != 0.0F && ucomp > -2.0F) {
                    ucomp -= 0.5 * stat.airs;
                }
                if (control.down) {
                    if (dcomp == 0.0F) {
                        dcomp = 10.0F + (scy[0] + 50.0F) / 20.0F;
                        if (dcomp < 5.0F) {
                            dcomp = 5.0F;
                        }
                        if (dcomp > 10.0F) {
                            dcomp = 10.0F;
                        }
                        dcomp *= stat.airs;
                    }
                    if (dcomp < 20.0F) {
                        dcomp += 0.5 * stat.airs;
                    }
                    f12 = -stat.airc;
                } else if (dcomp != 0.0F && ucomp > -2.0F) {
                    dcomp -= 0.5 * stat.airs;
                }
                if (control.left) {
                    if (lcomp == 0.0F) {
                        lcomp = 5.0F;
                    }
                    if (lcomp < 20.0F) {
                        lcomp += 2.0F * stat.airs;
                    }
                    f = -stat.airc * Medium.cos(conto.xz) * i;
                    f11 = -stat.airc * Medium.sin(conto.xz) * i;
                } else if (lcomp > 0.0F) {
                    lcomp -= 2.0F * stat.airs;
                }
                if (control.right) {
                    if (rcomp == 0.0F) {
                        rcomp = 5.0F;
                    }
                    if (rcomp < 20.0F) {
                        rcomp += 2.0F * stat.airs;
                    }
                    f = stat.airc * Medium.cos(conto.xz) * i;
                    f11 = stat.airc * Medium.sin(conto.xz) * i;
                } else if (rcomp > 0.0F) {
                    rcomp -= 2.0F * stat.airs;
                }
                pzy += (dcomp - ucomp) * Medium.cos(pxy);
                if (bool) {
                    conto.xz += (dcomp - ucomp) * Medium.sin(pxy);
                } else {
                    conto.xz -= (dcomp - ucomp) * Medium.sin(pxy);
                }
                pxy += rcomp - lcomp;
            } else {
                float f15 = power;
                if (f15 < 40.0F) {
                    f15 = 40.0F;
                }
                if (control.down)
                    if (speed > 0.0F) {
                        speed -= stat.handb / 2;
                    } else {
                        int i16 = 0;
                        for (int i17 = 0; i17 < 2; i17++)
                            if (speed <= -(stat.swits[i17] / 2 + f15 * stat.swits[i17] / 196.0F)) {
                                i16++;
                            }
                        if (i16 != 2) {
                            speed -= stat.acelf[i16] / 2.0F + f15 * stat.acelf[i16] / 196.0F;
                        } else {
                            speed = -(stat.swits[1] / 2 + f15 * stat.swits[1] / 196.0F);
                        }
                    }
                if (control.up)
                    if (speed < 0.0F) {
                        speed += stat.handb;
                    } else {
                        int i18 = 0;
                        for (int i19 = 0; i19 < 3; i19++)
                            if (speed >= stat.swits[i19] / 2 + f15 * stat.swits[i19] / 196.0F) {
                                i18++;
                            }
                        if (i18 != 3) {
                            speed += stat.acelf[i18] / 2.0F + f15 * stat.acelf[i18] / 196.0F;
                        } else {
                            speed = stat.swits[2] / 2 + f15 * stat.swits[2] / 196.0F;
                        }
                    }
                if (control.handb && Math.abs(speed) > stat.handb)
                    if (speed < 0.0F) {
                        speed += stat.handb;
                    } else {
                        speed -= stat.handb;
                    }
                if (loop == -1 && conto.y < 100) {
                    if (control.left) {
                        if (!pl) {
                            if (lcomp == 0.0F) {
                                lcomp = 5.0F * stat.airs;
                            }
                            if (lcomp < 20.0F) {
                                lcomp += 2.0F * stat.airs;
                            }
                        }
                    } else {
                        if (lcomp > 0.0F) {
                            lcomp -= 2.0F * stat.airs;
                        }
                        pl = false;
                    }
                    if (control.right) {
                        if (!pr) {
                            if (rcomp == 0.0F) {
                                rcomp = 5.0F * stat.airs;
                            }
                            if (rcomp < 20.0F) {
                                rcomp += 2.0F * stat.airs;
                            }
                        }
                    } else {
                        if (rcomp > 0.0F) {
                            rcomp -= 2.0F * stat.airs;
                        }
                        pr = false;
                    }
                    if (control.up) {
                        if (!pu) {
                            if (ucomp == 0.0F) {
                                ucomp = 5.0F * stat.airs;
                            }
                            if (ucomp < 20.0F) {
                                ucomp += 2.0F * stat.airs;
                            }
                        }
                    } else {
                        if (ucomp > 0.0F) {
                            ucomp -= 2.0F * stat.airs;
                        }
                        pu = false;
                    }
                    if (control.down) {
                        if (!pd) {
                            if (dcomp == 0.0F) {
                                dcomp = 5.0F * stat.airs;
                            }
                            if (dcomp < 20.0F) {
                                dcomp += 2.0F * stat.airs;
                            }
                        }
                    } else {
                        if (dcomp > 0.0F) {
                            dcomp -= 2.0F * stat.airs;
                        }
                        pd = false;
                    }
                    pzy += (dcomp - ucomp) * Medium.cos(pxy);
                    if (bool) {
                        conto.xz += (dcomp - ucomp) * Medium.sin(pxy);
                    } else {
                        conto.xz -= (dcomp - ucomp) * Medium.sin(pxy);
                    }
                    pxy += rcomp - lcomp;
                }
            }
        float f20 = 20.0F * speed / (154.0F * stat.simag);
        if (f20 > 20.0F) {
            f20 = 20.0F;
        }
        conto.wzy -= f20;
        if (conto.wzy < -30) {
            conto.wzy += 30;
        }
        if (conto.wzy > 30) {
            conto.wzy -= 30;
        }
        if (control.right) {
            conto.wxz -= stat.turn;
            if (conto.wxz < -36) {
                conto.wxz = -36;
            }
        }
        if (control.left) {
            conto.wxz += stat.turn;
            if (conto.wxz > 36) {
                conto.wxz = 36;
            }
        }
        if (conto.wxz != 0 && !control.left && !control.right)
            if (Math.abs(speed) < 10.0F) {
                if (Math.abs(conto.wxz) == 1) {
                    conto.wxz = 0;
                }
                if (conto.wxz > 0) {
                    conto.wxz--;
                }
                if (conto.wxz < 0) {
                    conto.wxz++;
                }
            } else {
                if (Math.abs(conto.wxz) < stat.turn * 2) {
                    conto.wxz = 0;
                }
                if (conto.wxz > 0) {
                    conto.wxz -= stat.turn * 2;
                }
                if (conto.wxz < 0) {
                    conto.wxz += stat.turn * 2;
                }
            }
        int i21 = (int) (3600.0F / (speed * speed));
        if (i21 < 5) {
            i21 = 5;
        }
        if (speed < 0.0F) {
            i21 = -i21;
        }
        if (wtouch) {
            if (!capsized) {
                if (!control.handb) {
                    fxz = conto.wxz / (i21 * 3);
                } else {
                    fxz = conto.wxz / i21;
                }
                conto.xz += conto.wxz / i21;
            }
            wtouch = false;
            gtouch = false;
        } else {
            conto.xz += fxz;
        }
        if (speed > 30.0F || speed < -100.0F) {
            while (Math.abs(mxz - cxz) > 180)
                if (cxz > mxz) {
                    cxz -= 360;
                } else if (cxz < mxz) {
                    cxz += 360;
                }
            if (Math.abs(mxz - cxz) < 30) {
                cxz += (mxz - cxz) / 4.0F;
            } else {
                if (cxz > mxz) {
                    cxz -= 10;
                }
                if (cxz < mxz) {
                    cxz += 10;
                }
            }
        }
        final float[] fs = new float[4];
        final float[] fs22 = new float[4];
        final float[] fs23 = new float[4];
        for (int i24 = 0; i24 < 4; i24++) {
            fs[i24] = conto.keyx[i24] + conto.x;
            fs23[i24] = i10 + conto.y;
            fs22[i24] = conto.z + conto.keyz[i24];
            scy[i24] += 7.0F;
        }
        rot(fs, fs23, conto.x, conto.y, pxy, 4);
        rot(fs23, fs22, conto.y, conto.z, pzy, 4);
        rot(fs, fs22, conto.x, conto.z, conto.xz, 4);
        boolean bool25 = false;
        double d;
        final int i26 = (int) ((scx[0] + scx[1] + scx[2] + scx[3]) / 4.0F);
        final int i27 = (int) ((scz[0] + scz[1] + scz[2] + scz[3]) / 4.0F);
        for (int i28 = 0; i28 < 4; i28++) {
            if (scx[i28] - i26 > 200.0F) {
                scx[i28] = 200 + i26;
            }
            if (scx[i28] - i26 < -200.0F) {
                scx[i28] = i26 - 200;
            }
            if (scz[i28] - i27 > 200.0F) {
                scz[i28] = 200 + i27;
            }
            if (scz[i28] - i27 < -200.0F) {
                scz[i28] = i27 - 200;
            }
        }
        for (int i29 = 0; i29 < 4; i29++) {
            fs23[i29] += scy[i29];
            fs[i29] += (scx[0] + scx[1] + scx[2] + scx[3]) / 4.0F;
            fs22[i29] += (scz[0] + scz[1] + scz[2] + scz[3]) / 4.0F;
        }
        int i30 = (conto.x - Trackers.sx) / 3000;
        if (i30 > Trackers.ncx) {
            i30 = Trackers.ncx;
        }
        if (i30 < 0) {
            i30 = 0;
        }
        int i31 = (conto.z - Trackers.sz) / 3000;
        if (i31 > Trackers.ncz) {
            i31 = Trackers.ncz;
        }
        if (i31 < 0) {
            i31 = 0;
        }
        int i32 = 1;
        for (int i33 = 0; i33 < Trackers.sect[i30][i31].length; i33++) {
            final int i34 = Trackers.sect[i30][i31][i33];
            if (Math.abs(Trackers.zy[i34]) != 90 && Math.abs(Trackers.xy[i34]) != 90 && Math.abs(conto.x - Trackers.x[i34]) < Trackers.radx[i34] && Math.abs(conto.z - Trackers.z[i34]) < Trackers.radz[i34] && (!Trackers.decor[i34] || Medium.resdown != 2 || xtGraphics.multion != 0)) {
                i32 = Trackers.skd[i34];
            }
        }
        if (mtouch) {
            float f35 = stat.grip;
            f35 -= Math.abs(txz - conto.xz) * speed / 250.0F;
            if (control.handb) {
                f35 -= Math.abs(txz - conto.xz) * 4;
            }
            if (f35 < stat.grip) {
                if (skid != 2) {
                    skid = 1;
                }
                speed -= speed / 100.0F;
            } else if (skid == 1) {
                skid = 2;
            }
            if (i32 == 1) {
                f35 *= 0.75;
            }
            if (i32 == 2) {
                f35 *= 0.55;
            }
            int i36 = -(int) (speed * Medium.sin(conto.xz) * Medium.cos(pzy));
            int i37 = (int) (speed * Medium.cos(conto.xz) * Medium.cos(pzy));
            int i38 = -(int) (speed * Medium.sin(pzy));
            if (capsized || dest || CheckPoints.haltall) {
                i36 = 0;
                i37 = 0;
                i38 = 0;
                f35 = stat.grip / 5.0F;
                if (speed > 0.0F) {
                    speed -= 2.0F;
                } else {
                    speed += 2.0F;
                }
            }
            if (Math.abs(speed) > drag) {
                if (speed > 0.0F) {
                    speed -= drag;
                } else {
                    speed += drag;
                }
            } else {
                speed = 0.0F;
            }
            if (cn == 8 && f35 < 5.0F) {
                f35 = 5.0F;
            }
            if (f35 < 1.0F) {
                f35 = 1.0F;
            }
            float f39 = 0.0F;
            float f40 = 0.0F;
            for (int i41 = 0; i41 < 4; i41++) {
                if (Math.abs(scx[i41] - i36) > f35) {
                    if (scx[i41] < i36) {
                        scx[i41] += f35;
                    } else {
                        scx[i41] -= f35;
                    }
                } else {
                    scx[i41] = i36;
                }
                if (Math.abs(scz[i41] - i37) > f35) {
                    if (scz[i41] < i37) {
                        scz[i41] += f35;
                    } else {
                        scz[i41] -= f35;
                    }
                } else {
                    scz[i41] = i37;
                }
                if (Math.abs(scy[i41] - i38) > f35) {
                    if (scy[i41] < i38) {
                        scy[i41] += f35;
                    } else {
                        scy[i41] -= f35;
                    }
                } else {
                    scy[i41] = i38;
                }
                if (f35 < stat.grip) {
                    if (txz != conto.xz) {
                        dcnt++;
                    } else if (dcnt != 0) {
                        dcnt = 0;
                    }
                    if (dcnt > 40.0F * f35 / stat.grip || capsized) {
                        float f42 = 1.0F;
                        if (i32 != 0) {
                            f42 = 1.2F;
                        }
                        if (Medium.random() > 0.65) {
                            conto.dust(i41, fs[i41], fs23[i41], fs22[i41], (int) scx[i41], (int) scz[i41], f42 * stat.simag, (int) tilt, capsized && mtouch);
                            if (im == xtGraphics.im && !capsized) {
                                xtGraphics.skid(im, i32, (float) Math.sqrt(scx[i41] * scx[i41] + scz[i41] * scz[i41]));
                            }
                        }
                    } else {
                        if (i32 == 1 && Medium.random() > 0.8) {
                            conto.dust(i41, fs[i41], fs23[i41], fs22[i41], (int) scx[i41], (int) scz[i41], 1.1F * stat.simag, (int) tilt, capsized && mtouch);
                        }
                        if ((i32 == 2 || i32 == 3) && Medium.random() > 0.6) {
                            conto.dust(i41, fs[i41], fs23[i41], fs22[i41], (int) scx[i41], (int) scz[i41], 1.15F * stat.simag, (int) tilt, capsized && mtouch);
                        }
                    }
                } else if (dcnt != 0) {
                    dcnt -= 2;
                    if (dcnt < 0) {
                        dcnt = 0;
                    }
                }
                if (i32 == 3) {
                    final int i43 = (int) (Medium.random() * 4.0F);
                    scy[i43] = (float) (-100.0F * Medium.random() * (speed / stat.swits[2]) * (stat.bounce - 0.3));
                }
                if (i32 == 4) {
                    final int i44 = (int) (Medium.random() * 4.0F);
                    scy[i44] = (float) (-150.0F * Medium.random() * (speed / stat.swits[2]) * (stat.bounce - 0.3));
                }
                f39 += scx[i41];
                f40 += scz[i41];
            }
            txz = conto.xz;
            if (f39 > 0.0F) {
                i = -1;
            } else {
                i = 1;
            }
            d = f40 / Math.sqrt(f39 * f39 + f40 * f40);
            mxz = (int) (Math.acos(d) / 0.017453292519943295 * i);
            if (skid == 2) {
                if (!capsized) {
                    f39 /= 4.0F;
                    f40 /= 4.0F;
                    if (bool5) {
                        speed = -((float) Math.sqrt(f39 * f39 + f40 * f40) * Medium.cos(mxz - conto.xz));
                    } else {
                        speed = (float) Math.sqrt(f39 * f39 + f40 * f40) * Medium.cos(mxz - conto.xz);
                    }
                }
                skid = 0;
            }
            if (capsized && f39 == 0.0F && f40 == 0.0F) {
                i32 = 0;
            }
            mtouch = false;
            bool25 = true;
        } else if (skid != 2) {
            skid = 2;
        }
        int i45 = 0;
        final boolean[] bools = new boolean[4];
        final boolean[] bools46 = new boolean[4];
        final boolean[] bools47 = new boolean[4];
        float f48 = 0.0F;
        for (int i49 = 0; i49 < 4; i49++) {
            bools46[i49] = false;
            bools47[i49] = false;
            if (fs23[i49] > 245.0F) {
                i45++;
                wtouch = true;
                gtouch = true;
                if (!bool25 && scy[i49] != 7.0F) {
                    float f50 = scy[i49] / 333.33F;
                    if (f50 > 0.3) {
                        f50 = 0.3F;
                    }
                    if (i32 == 0) {
                        f50 += 1.1;
                    } else {
                        f50 += 1.2;
                    }
                    conto.dust(i49, fs[i49], fs23[i49], fs22[i49], (int) scx[i49], (int) scz[i49], f50 * stat.simag, 0, capsized && mtouch);
                }
                fs23[i49] = 250.0F;
                bools47[i49] = true;
                f48 += fs23[i49] - 250.0F;
                float f51 = Math.abs(Medium.sin(pxy)) + Math.abs(Medium.sin(pzy));
                f51 /= 3.0F;
                if (f51 > 0.4) {
                    f51 = 0.4F;
                }
                f51 += stat.bounce;
                if (f51 < 1.1) {
                    f51 = 1.1F;
                }
                regy(i49, Math.abs(scy[i49] * f51), conto);
                if (scy[i49] > 0.0F) {
                    scy[i49] -= Math.abs(scy[i49] * f51);
                }
                if (capsized) {
                    bools46[i49] = true;
                }
            }
            bools[i49] = false;
        }
        if (i45 != 0) {
            f48 /= i45;
            for (int i52 = 0; i52 < 4; i52++)
                if (!bools47[i52]) {
                    fs23[i52] -= f48;
                }
        }
        int i53 = 0;
        for (int i54 = 0; i54 < Trackers.sect[i30][i31].length; i54++) {
            final int i55 = Trackers.sect[i30][i31][i54];
            int i56 = 0;
            int i57 = 0;
            for (int i58 = 0; i58 < 4; i58++) {
                if (bools46[i58] && (Trackers.skd[i55] == 0 || Trackers.skd[i55] == 1) && fs[i58] > Trackers.x[i55] - Trackers.radx[i55] && fs[i58] < Trackers.x[i55] + Trackers.radx[i55] && fs22[i58] > Trackers.z[i55] - Trackers.radz[i55] && fs22[i58] < Trackers.z[i55] + Trackers.radz[i55]) {
                    conto.sprk(fs[i58], fs23[i58], fs22[i58], scx[i58], scy[i58], scz[i58], 1);
                    if (im == xtGraphics.im) {
                        xtGraphics.gscrape(im, (int) scx[i58], (int) scy[i58], (int) scz[i58]);
                    }
                }
                if (!bools[i58] && fs[i58] > Trackers.x[i55] - Trackers.radx[i55] && fs[i58] < Trackers.x[i55] + Trackers.radx[i55] && fs22[i58] > Trackers.z[i55] - Trackers.radz[i55] && fs22[i58] < Trackers.z[i55] + Trackers.radz[i55] && fs23[i58] > Trackers.y[i55] - Trackers.rady[i55] && fs23[i58] < Trackers.y[i55] + Trackers.rady[i55] && (!Trackers.decor[i55] || Medium.resdown != 2 || xtGraphics.multion != 0)) {
                    if (Trackers.xy[i55] == 0 && Trackers.zy[i55] == 0 && Trackers.y[i55] != 250 && fs23[i58] > Trackers.y[i55] - 5) {
                        i57++;
                        wtouch = true;
                        gtouch = true;
                        if (!bool25 && scy[i58] != 7.0F) {
                            float f59 = scy[i58] / 333.33F;
                            if (f59 > 0.3) {
                                f59 = 0.3F;
                            }
                            if (i32 == 0) {
                                f59 += 1.1;
                            } else {
                                f59 += 1.2;
                            }
                            conto.dust(i58, fs[i58], fs23[i58], fs22[i58], (int) scx[i58], (int) scz[i58], f59 * stat.simag, 0, capsized && mtouch);
                        }
                        fs23[i58] = Trackers.y[i55];
                        if (capsized && (Trackers.skd[i55] == 0 || Trackers.skd[i55] == 1)) {
                            conto.sprk(fs[i58], fs23[i58], fs22[i58], scx[i58], scy[i58], scz[i58], 1);
                            if (im == xtGraphics.im) {
                                xtGraphics.gscrape(im, (int) scx[i58], (int) scy[i58], (int) scz[i58]);
                            }
                        }
                        float f60 = Math.abs(Medium.sin(pxy)) + Math.abs(Medium.sin(pzy));
                        f60 /= 3.0F;
                        if (f60 > 0.4) {
                            f60 = 0.4F;
                        }
                        f60 += stat.bounce;
                        if (f60 < 1.1) {
                            f60 = 1.1F;
                        }
                        regy(i58, Math.abs(scy[i58] * f60), conto);
                        if (scy[i58] > 0.0F) {
                            scy[i58] -= Math.abs(scy[i58] * f60);
                        }
                        bools[i58] = true;
                    }
                    if (Trackers.zy[i55] == -90 && fs22[i58] < Trackers.z[i55] + Trackers.radz[i55] && (scz[i58] < 0.0F || Trackers.radz[i55] == 287)) {
                        for (int i61 = 0; i61 < 4; i61++)
                            if (i58 != i61 && fs22[i61] >= Trackers.z[i55] + Trackers.radz[i55]) {
                                fs22[i61] -= fs22[i58] - (Trackers.z[i55] + Trackers.radz[i55]);
                            }
                        fs22[i58] = Trackers.z[i55] + Trackers.radz[i55];
                        if (Trackers.skd[i55] != 2) {
                            crank[0][i58]++;
                        }
                        if (Trackers.skd[i55] == 5 && Medium.random() > Medium.random()) {
                            crank[0][i58]++;
                        }
                        if (crank[0][i58] > 1) {
                            conto.sprk(fs[i58], fs23[i58], fs22[i58], scx[i58], scy[i58], scz[i58], 0);
                            if (im == xtGraphics.im) {
                                xtGraphics.scrape(im, (int) scx[i58], (int) scy[i58], (int) scz[i58]);
                            }
                        }
                        float f62 = Math.abs(Medium.cos(pxy)) + Math.abs(Medium.cos(pzy));
                        f62 /= 4.0F;
                        if (f62 > 0.3) {
                            f62 = 0.3F;
                        }
                        if (bool25) {
                            f62 = 0.0F;
                        }
                        f62 += stat.bounce - 0.2;
                        if (f62 < 1.1) {
                            f62 = 1.1F;
                        }
                        regz(i58, Math.abs(scz[i58] * f62 * Trackers.dam[i55]), conto);
                        scz[i58] += Math.abs(scz[i58] * f62);
                        skid = 2;
                        bool6 = true;
                        bools[i58] = true;
                        if (!Trackers.notwall[i55]) {
                            control.wall = i55;
                        }
                    }
                    if (Trackers.zy[i55] == 90 && fs22[i58] > Trackers.z[i55] - Trackers.radz[i55] && (scz[i58] > 0.0F || Trackers.radz[i55] == 287)) {
                        for (int i63 = 0; i63 < 4; i63++)
                            if (i58 != i63 && fs22[i63] <= Trackers.z[i55] - Trackers.radz[i55]) {
                                fs22[i63] -= fs22[i58] - (Trackers.z[i55] - Trackers.radz[i55]);
                            }
                        fs22[i58] = Trackers.z[i55] - Trackers.radz[i55];
                        if (Trackers.skd[i55] != 2) {
                            crank[1][i58]++;
                        }
                        if (Trackers.skd[i55] == 5 && Medium.random() > Medium.random()) {
                            crank[1][i58]++;
                        }
                        if (crank[1][i58] > 1) {
                            conto.sprk(fs[i58], fs23[i58], fs22[i58], scx[i58], scy[i58], scz[i58], 0);
                            if (im == xtGraphics.im) {
                                xtGraphics.scrape(im, (int) scx[i58], (int) scy[i58], (int) scz[i58]);
                            }
                        }
                        float f64 = Math.abs(Medium.cos(pxy)) + Math.abs(Medium.cos(pzy));
                        f64 /= 4.0F;
                        if (f64 > 0.3) {
                            f64 = 0.3F;
                        }
                        if (bool25) {
                            f64 = 0.0F;
                        }
                        f64 += stat.bounce - 0.2;
                        if (f64 < 1.1) {
                            f64 = 1.1F;
                        }
                        regz(i58, -Math.abs(scz[i58] * f64 * Trackers.dam[i55]), conto);
                        scz[i58] -= Math.abs(scz[i58] * f64);
                        skid = 2;
                        bool6 = true;
                        bools[i58] = true;
                        if (!Trackers.notwall[i55]) {
                            control.wall = i55;
                        }
                    }
                    if (Trackers.xy[i55] == -90 && fs[i58] < Trackers.x[i55] + Trackers.radx[i55] && (scx[i58] < 0.0F || Trackers.radx[i55] == 287)) {
                        for (int i65 = 0; i65 < 4; i65++)
                            if (i58 != i65 && fs[i65] >= Trackers.x[i55] + Trackers.radx[i55]) {
                                fs[i65] -= fs[i58] - (Trackers.x[i55] + Trackers.radx[i55]);
                            }
                        fs[i58] = Trackers.x[i55] + Trackers.radx[i55];
                        if (Trackers.skd[i55] != 2) {
                            crank[2][i58]++;
                        }
                        if (Trackers.skd[i55] == 5 && Medium.random() > Medium.random()) {
                            crank[2][i58]++;
                        }
                        if (crank[2][i58] > 1) {
                            conto.sprk(fs[i58], fs23[i58], fs22[i58], scx[i58], scy[i58], scz[i58], 0);
                            if (im == xtGraphics.im) {
                                xtGraphics.scrape(im, (int) scx[i58], (int) scy[i58], (int) scz[i58]);
                            }
                        }
                        float f66 = Math.abs(Medium.cos(pxy)) + Math.abs(Medium.cos(pzy));
                        f66 /= 4.0F;
                        if (f66 > 0.3) {
                            f66 = 0.3F;
                        }
                        if (bool25) {
                            f66 = 0.0F;
                        }
                        f66 += stat.bounce - 0.2;
                        if (f66 < 1.1) {
                            f66 = 1.1F;
                        }
                        regx(i58, Math.abs(scx[i58] * f66 * Trackers.dam[i55]), conto);
                        scx[i58] += Math.abs(scx[i58] * f66);
                        skid = 2;
                        bool6 = true;
                        bools[i58] = true;
                        if (!Trackers.notwall[i55]) {
                            control.wall = i55;
                        }
                    }
                    if (Trackers.xy[i55] == 90 && fs[i58] > Trackers.x[i55] - Trackers.radx[i55] && (scx[i58] > 0.0F || Trackers.radx[i55] == 287)) {
                        for (int i67 = 0; i67 < 4; i67++)
                            if (i58 != i67 && fs[i67] <= Trackers.x[i55] - Trackers.radx[i55]) {
                                fs[i67] -= fs[i58] - (Trackers.x[i55] - Trackers.radx[i55]);
                            }
                        fs[i58] = Trackers.x[i55] - Trackers.radx[i55];
                        if (Trackers.skd[i55] != 2) {
                            crank[3][i58]++;
                        }
                        if (Trackers.skd[i55] == 5 && Medium.random() > Medium.random()) {
                            crank[3][i58]++;
                        }
                        if (crank[3][i58] > 1) {
                            conto.sprk(fs[i58], fs23[i58], fs22[i58], scx[i58], scy[i58], scz[i58], 0);
                            if (im == xtGraphics.im) {
                                xtGraphics.scrape(im, (int) scx[i58], (int) scy[i58], (int) scz[i58]);
                            }
                        }
                        float f68 = Math.abs(Medium.cos(pxy)) + Math.abs(Medium.cos(pzy));
                        f68 /= 4.0F;
                        if (f68 > 0.3) {
                            f68 = 0.3F;
                        }
                        if (bool25) {
                            f68 = 0.0F;
                        }
                        f68 += stat.bounce - 0.2;
                        if (f68 < 1.1) {
                            f68 = 1.1F;
                        }
                        regx(i58, -Math.abs(scx[i58] * f68 * Trackers.dam[i55]), conto);
                        scx[i58] -= Math.abs(scx[i58] * f68);
                        skid = 2;
                        bool6 = true;
                        bools[i58] = true;
                        if (!Trackers.notwall[i55]) {
                            control.wall = i55;
                        }
                    }
                    if (Trackers.zy[i55] != 0 && Trackers.zy[i55] != 90 && Trackers.zy[i55] != -90) {
                        final int i69 = 90 + Trackers.zy[i55];
                        float f70 = 1.0F + (50 - Math.abs(Trackers.zy[i55])) / 30.0F;
                        if (f70 < 1.0F) {
                            f70 = 1.0F;
                        }
                        final float f71 = Trackers.y[i55] + ((fs23[i58] - Trackers.y[i55]) * Medium.cos(i69) - (fs22[i58] - Trackers.z[i55]) * Medium.sin(i69));
                        float f72 = Trackers.z[i55] + ((fs23[i58] - Trackers.y[i55]) * Medium.sin(i69) + (fs22[i58] - Trackers.z[i55]) * Medium.cos(i69));
                        if (f72 > Trackers.z[i55] && f72 < Trackers.z[i55] + 200) {
                            scy[i58] -= (f72 - Trackers.z[i55]) / f70;
                            f72 = Trackers.z[i55];
                        }
                        if (f72 > Trackers.z[i55] - 30) {
                            if (Trackers.skd[i55] == 2) {
                                i56++;
                            } else {
                                i53++;
                            }
                            wtouch = true;
                            gtouch = false;
                            if (capsized && (Trackers.skd[i55] == 0 || Trackers.skd[i55] == 1)) {
                                conto.sprk(fs[i58], fs23[i58], fs22[i58], scx[i58], scy[i58], scz[i58], 1);
                                if (im == xtGraphics.im) {
                                    xtGraphics.gscrape(im, (int) scx[i58], (int) scy[i58], (int) scz[i58]);
                                }
                            }
                            if (!bool25 && i32 != 0) {
                                final float f73 = 1.4F;
                                conto.dust(i58, fs[i58], fs23[i58], fs22[i58], (int) scx[i58], (int) scz[i58], f73 * stat.simag, 0, capsized && mtouch);
                            }
                        }
                        fs23[i58] = Trackers.y[i55] + ((f71 - Trackers.y[i55]) * Medium.cos(-i69) - (f72 - Trackers.z[i55]) * Medium.sin(-i69));
                        fs22[i58] = Trackers.z[i55] + ((f71 - Trackers.y[i55]) * Medium.sin(-i69) + (f72 - Trackers.z[i55]) * Medium.cos(-i69));
                        bools[i58] = true;
                    }
                    if (Trackers.xy[i55] != 0 && Trackers.xy[i55] != 90 && Trackers.xy[i55] != -90) {
                        final int i74 = 90 + Trackers.xy[i55];
                        float f75 = 1.0F + (50 - Math.abs(Trackers.xy[i55])) / 30.0F;
                        if (f75 < 1.0F) {
                            f75 = 1.0F;
                        }
                        final float f76 = Trackers.y[i55] + ((fs23[i58] - Trackers.y[i55]) * Medium.cos(i74) - (fs[i58] - Trackers.x[i55]) * Medium.sin(i74));
                        float f77 = Trackers.x[i55] + ((fs23[i58] - Trackers.y[i55]) * Medium.sin(i74) + (fs[i58] - Trackers.x[i55]) * Medium.cos(i74));
                        if (f77 > Trackers.x[i55] && f77 < Trackers.x[i55] + 200) {
                            scy[i58] -= (f77 - Trackers.x[i55]) / f75;
                            f77 = Trackers.x[i55];
                        }
                        if (f77 > Trackers.x[i55] - 30) {
                            if (Trackers.skd[i55] == 2) {
                                i56++;
                            } else {
                                i53++;
                            }
                            wtouch = true;
                            gtouch = false;
                            if (capsized && (Trackers.skd[i55] == 0 || Trackers.skd[i55] == 1)) {
                                conto.sprk(fs[i58], fs23[i58], fs22[i58], scx[i58], scy[i58], scz[i58], 1);
                                if (im == xtGraphics.im) {
                                    xtGraphics.gscrape(im, (int) scx[i58], (int) scy[i58], (int) scz[i58]);
                                }
                            }
                            if (!bool25 && i32 != 0) {
                                final float f78 = 1.4F;
                                conto.dust(i58, fs[i58], fs23[i58], fs22[i58], (int) scx[i58], (int) scz[i58], f78 * stat.simag, 0, capsized && mtouch);
                            }
                        }
                        fs23[i58] = Trackers.y[i55] + ((f76 - Trackers.y[i55]) * Medium.cos(-i74) - (f77 - Trackers.x[i55]) * Medium.sin(-i74));
                        fs[i58] = Trackers.x[i55] + ((f76 - Trackers.y[i55]) * Medium.sin(-i74) + (f77 - Trackers.x[i55]) * Medium.cos(-i74));
                        bools[i58] = true;
                    }
                }
            }
            if (i56 == 4) {
                mtouch = true;
            }
            if (i57 == 4) {
                i45 = 4;
            }
        }
        if (i53 == 4) {
            mtouch = true;
        }
        for (int i79 = 0; i79 < 4; i79++) {
            for (int i80 = 0; i80 < 4; i80++) {
                if (crank[i79][i80] == lcrank[i79][i80]) {
                    crank[i79][i80] = 0;
                }
                lcrank[i79][i80] = crank[i79][i80];
            }
        }
        int i81 = 0;
        int i82 = 0;
        int i83 = 0;
        int i84 = 0;
        if (scy[2] != scy[0]) {
            if (scy[2] < scy[0]) {
                i = -1;
            } else {
                i = 1;
            }
            d = Math.sqrt((fs22[0] - fs22[2]) * (fs22[0] - fs22[2]) + (fs23[0] - fs23[2]) * (fs23[0] - fs23[2]) + (fs[0] - fs[2]) * (fs[0] - fs[2])) / (Math.abs(conto.keyz[0]) + Math.abs(conto.keyz[2]));
            if (d >= 0.9998) {
                i81 = i;
            } else {
                i81 = (int) (Math.acos(d) / 0.017453292519943295 * i);
            }
        }
        if (scy[3] != scy[1]) {
            if (scy[3] < scy[1]) {
                i = -1;
            } else {
                i = 1;
            }
            d = Math.sqrt((fs22[1] - fs22[3]) * (fs22[1] - fs22[3]) + (fs23[1] - fs23[3]) * (fs23[1] - fs23[3]) + (fs[1] - fs[3]) * (fs[1] - fs[3])) / (Math.abs(conto.keyz[1]) + Math.abs(conto.keyz[3]));
            if (d >= 0.9998) {
                i82 = i;
            } else {
                i82 = (int) (Math.acos(d) / 0.017453292519943295 * i);
            }
        }
        if (scy[1] != scy[0]) {
            if (scy[1] < scy[0]) {
                i = -1;
            } else {
                i = 1;
            }
            d = Math.sqrt((fs22[0] - fs22[1]) * (fs22[0] - fs22[1]) + (fs23[0] - fs23[1]) * (fs23[0] - fs23[1]) + (fs[0] - fs[1]) * (fs[0] - fs[1])) / (Math.abs(conto.keyx[0]) + Math.abs(conto.keyx[1]));
            if (d >= 0.9998) {
                i83 = i;
            } else {
                i83 = (int) (Math.acos(d) / 0.017453292519943295 * i);
            }
        }
        if (scy[3] != scy[2]) {
            if (scy[3] < scy[2]) {
                i = -1;
            } else {
                i = 1;
            }
            d = Math.sqrt((fs22[2] - fs22[3]) * (fs22[2] - fs22[3]) + (fs23[2] - fs23[3]) * (fs23[2] - fs23[3]) + (fs[2] - fs[3]) * (fs[2] - fs[3])) / (Math.abs(conto.keyx[2]) + Math.abs(conto.keyx[3]));
            if (d >= 0.9998) {
                i84 = i;
            } else {
                i84 = (int) (Math.acos(d) / 0.017453292519943295 * i);
            }
        }
        if (bool6) {
            int i85;
            for (i85 = Math.abs(conto.xz + 45); i85 > 180; i85 -= 360) {

            }
            if (Math.abs(i85) > 90) {
                pmlt = 1;
            } else {
                pmlt = -1;
            }
            for (i85 = Math.abs(conto.xz - 45); i85 > 180; i85 -= 360) {

            }
            if (Math.abs(i85) > 90) {
                nmlt = 1;
            } else {
                nmlt = -1;
            }
        }
        conto.xz += forca * (scz[0] * nmlt - scz[1] * pmlt + scz[2] * pmlt - scz[3] * nmlt + scx[0] * pmlt + scx[1] * nmlt - scx[2] * nmlt - scx[3] * pmlt);
        if (Math.abs(i82) > Math.abs(i81)) {
            i81 = i82;
        }
        if (Math.abs(i84) > Math.abs(i83)) {
            i83 = i84;
        }
        if (!bool) {
            pzy += i81;
        } else {
            pzy -= i81;
        }
        if (!bool8) {
            pxy += i83;
        } else {
            pxy -= i83;
        }
        if (i45 == 4) {//# of touching wheels
            int i86 = 0;
            while (pzy < 360) {
                pzy += 360;
                conto.zy += 360;
            }
            while (pzy > 360) {
                pzy -= 360;
                conto.zy -= 360;
            }
            if (pzy < 190 && pzy > 170) {//player zy angle
                // rounds off the angle, capsizing the player
                pzy = 180;
                conto.zy = 180;
                i86++;
            }
            if (pzy > 350 || pzy < 10) {
                // this is the opposite, rounds off the angle but lands properly
                pzy = 0;
                conto.zy = 0;
                i86++;
            }
            while (pxy < 360) {
                pxy += 360;
                conto.xy += 360;
            }
            while (pxy > 360) {
                pxy -= 360;
                conto.xy -= 360;
            }
            if (pxy < 190 && pxy > 170) {//same as above but for xy
                pxy = 180;
                conto.xy = 180;
                i86++;
            }
            if (pxy > 350 || pxy < 10) {
                pxy = 0;
                conto.xy = 0;
                i86++;
            }
            if (i86 == 2) {
                mtouch = true;
            }
        }
        if (!mtouch && wtouch) {
            if (cntouch == 10) {
                mtouch = true;
            } else {
                cntouch++;
            }
        } else {
            cntouch = 0;
        }
        conto.y = (int) ((fs23[0] + fs23[1] + fs23[2] + fs23[3]) / 4.0F - i10 * Medium.cos(pzy) * Medium.cos(pxy) + f12);
        if (bool) {
            i = -1;
        } else {
            i = 1;
        }
        conto.x = (int) ((fs[0] - conto.keyx[0] * Medium.cos(conto.xz) + i * conto.keyz[0] * Medium.sin(conto.xz) + fs[1] - conto.keyx[1] * Medium.cos(conto.xz) + i * conto.keyz[1] * Medium.sin(conto.xz) + fs[2] - conto.keyx[2] * Medium.cos(conto.xz) + i * conto.keyz[2] * Medium.sin(conto.xz) + fs[3] - conto.keyx[3] * Medium.cos(conto.xz) + i * conto.keyz[3] * Medium.sin(conto.xz)) / 4.0F + i10 * Medium.sin(pxy) * Medium.cos(conto.xz) - i10 * Medium.sin(pzy) * Medium.sin(conto.xz) + f);
        conto.z = (int) ((fs22[0] - i * conto.keyz[0] * Medium.cos(conto.xz) - conto.keyx[0] * Medium.sin(conto.xz) + fs22[1] - i * conto.keyz[1] * Medium.cos(conto.xz) - conto.keyx[1] * Medium.sin(conto.xz) + fs22[2] - i * conto.keyz[2] * Medium.cos(conto.xz) - conto.keyx[2] * Medium.sin(conto.xz) + fs22[3] - i * conto.keyz[3] * Medium.cos(conto.xz) - conto.keyx[3] * Medium.sin(conto.xz)) / 4.0F + i10 * Medium.sin(pxy) * Medium.sin(conto.xz) - i10 * Medium.sin(pzy) * Medium.cos(conto.xz) + f11);
        if (Math.abs(speed) > 10.0F || !mtouch) {
            if (Math.abs(pxy - conto.xy) >= 4) {
                if (pxy > conto.xy) {
                    conto.xy += 2 + (pxy - conto.xy) / 2;
                } else {
                    conto.xy -= 2 + (conto.xy - pxy) / 2;
                }
            } else {
                conto.xy = pxy;
            }
            if (Math.abs(pzy - conto.zy) >= 4) {
                if (pzy > conto.zy) {
                    conto.zy += 2 + (pzy - conto.zy) / 2;
                } else {
                    conto.zy -= 2 + (conto.zy - pzy) / 2;
                }
            } else {
                conto.zy = pzy;
            }
        }
        if (wtouch && !capsized) {
            final float f87 = (float) (speed / stat.swits[2] * 14.0F * (stat.bounce - 0.4));
            if (control.left && tilt < f87 && tilt >= 0.0F) {
                tilt += 0.4;
            } else if (control.right && tilt > -f87 && tilt <= 0.0F) {
                tilt -= 0.4;
            } else if (Math.abs(tilt) > 3.0 * (stat.bounce - 0.4)) {
                if (tilt > 0.0F) {
                    tilt -= 3.0 * (stat.bounce - 0.3);
                } else {
                    tilt += 3.0 * (stat.bounce - 0.3);
                }
            } else {
                tilt = 0.0F;
            }
            conto.xy += tilt;
            if (gtouch) {
                conto.y -= tilt / 1.5;
            }
        } else if (tilt != 0.0F) {
            tilt = 0.0F;
        }
        if (wtouch && i32 == 2) {
            conto.zy += (int) ((Medium.random() * 6.0F * speed / stat.swits[2] - 3.0F * speed / stat.swits[2]) * (stat.bounce - 0.3));
            conto.xy += (int) ((Medium.random() * 6.0F * speed / stat.swits[2] - 3.0F * speed / stat.swits[2]) * (stat.bounce - 0.3));
        }
        if (wtouch && i32 == 1) {
            conto.zy += (int) ((Medium.random() * 4.0F * speed / stat.swits[2] - 2.0F * speed / stat.swits[2]) * (stat.bounce - 0.3));
            conto.xy += (int) ((Medium.random() * 4.0F * speed / stat.swits[2] - 2.0F * speed / stat.swits[2]) * (stat.bounce - 0.3));
        }
        if (hitmag >= stat.maxmag && !dest) {
            distruct(conto);
            if (cntdest == 7) {
                dest = true;
            } else {
                cntdest++;
            }
            if (cntdest == 1) {
                Record.dest[im] = 300;
            }
        }
        if (conto.dist == 0) {
            for (int i88 = 0; i88 < conto.npl; i88++) {
                if (conto.p[i88].chip != 0) {
                    conto.p[i88].chip = 0;
                }
                if (conto.p[i88].embos != 0) {
                    conto.p[i88].embos = 13;
                }
            }
        }
        int i89 = 0;
        int i90 = 0;
        int i91 = 0;
        if (nofocus) {
            i4 = 1;
        } else {
            i4 = 7;
        }
        for (int i92 = 0; i92 < CheckPoints.n; i92++) {
            if (CheckPoints.typ[i92] > 0) {
                i91++;
                if (CheckPoints.typ[i92] == 1) {
                    if (clear == i91 + nlaps * CheckPoints.nsp) {
                        i4 = 1;
                    }
                    if (Math.abs(conto.z - CheckPoints.z[i92]) < 60.0F + Math.abs(scz[0] + scz[1] + scz[2] + scz[3]) / 4.0F && Math.abs(conto.x - CheckPoints.x[i92]) < 700 && Math.abs(conto.y - CheckPoints.y[i92] + 350) < 450 && clear == i91 + nlaps * CheckPoints.nsp - 1) {
                        clear = i91 + nlaps * CheckPoints.nsp;
                        pcleared = i92;
                        focus = -1;
                    }
                }
                if (CheckPoints.typ[i92] == 2) {
                    if (clear == i91 + nlaps * CheckPoints.nsp) {
                        i4 = 1;
                    }
                    if (Math.abs(conto.x - CheckPoints.x[i92]) < 60.0F + Math.abs(scx[0] + scx[1] + scx[2] + scx[3]) / 4.0F && Math.abs(conto.z - CheckPoints.z[i92]) < 700 && Math.abs(conto.y - CheckPoints.y[i92] + 350) < 450 && clear == i91 + nlaps * CheckPoints.nsp - 1) {
                        clear = i91 + nlaps * CheckPoints.nsp;
                        pcleared = i92;
                        focus = -1;
                    }
                }
            }
            if (py(conto.x / 100, CheckPoints.x[i92] / 100, conto.z / 100, CheckPoints.z[i92] / 100) * i4 < i90 || i90 == 0) {
                i89 = i92;
                i90 = py(conto.x / 100, CheckPoints.x[i92] / 100, conto.z / 100, CheckPoints.z[i92] / 100) * i4;
            }
        }
        if (clear == i91 + nlaps * CheckPoints.nsp) {
            nlaps++;
            if (xtGraphics.multion == 1 && im == xtGraphics.im) {
                if (xtGraphics.laptime < xtGraphics.fastestlap || xtGraphics.fastestlap == 0) {
                    xtGraphics.fastestlap = xtGraphics.laptime;
                }
                xtGraphics.laptime = 0;
            }
        }
        if (im == xtGraphics.im) {
            if (xtGraphics.multion == 1 && xtGraphics.starcnt == 0) {
                xtGraphics.laptime++;
            }
            for (Medium.checkpoint = clear; Medium.checkpoint >= CheckPoints.nsp; Medium.checkpoint -= CheckPoints.nsp) {

            }
            if (clear == CheckPoints.nlaps * CheckPoints.nsp - 1) {
                Medium.lastcheck = true;
            }
            if (CheckPoints.haltall) {
                Medium.lastcheck = false;
            }
        }
        if (focus == -1) {
            if (im == xtGraphics.im) {
                i89 += 2;
            } else {
                i89++;
            }
            if (!nofocus) {
                i91 = pcleared + 1;
                if (i91 >= CheckPoints.n) {
                    i91 = 0;
                }
                while (CheckPoints.typ[i91] <= 0)
                    if (++i91 >= CheckPoints.n) {
                        i91 = 0;
                    }
                if (i89 > i91 && (clear != nlaps * CheckPoints.nsp || i89 < pcleared)) {
                    i89 = i91;
                    focus = i89;
                }
            }
            if (i89 >= CheckPoints.n) {
                i89 -= CheckPoints.n;
            }
            if (CheckPoints.typ[i89] == -3) {
                i89 = 0;
            }
            if (im == xtGraphics.im) {
                if (missedcp != -1) {
                    missedcp = -1;
                }
            } else if (missedcp != 0) {
                missedcp = 0;
            }
        } else {
            i89 = focus;
            if (im == xtGraphics.im) {
                if (missedcp == 0 && mtouch && Math.sqrt(py(conto.x / 10, CheckPoints.x[focus] / 10, conto.z / 10, CheckPoints.z[focus] / 10)) > 800.0) {
                    missedcp = 1;
                }
                if (missedcp == -2 && Math.sqrt(py(conto.x / 10, CheckPoints.x[focus] / 10, conto.z / 10, CheckPoints.z[focus] / 10)) < 400.0) {
                    missedcp = 0;
                }
                if (missedcp != 0 && mtouch && Math.sqrt(py(conto.x / 10, CheckPoints.x[focus] / 10, conto.z / 10, CheckPoints.z[focus] / 10)) < 250.0) {
                    missedcp = 68;
                }
            } else {
                missedcp = 1;
            }
            if (nofocus) {
                focus = -1;
                missedcp = 0;
            }
        }
        if (nofocus) {
            nofocus = false;
        }
        point = i89;
        if (fixes != 0) {
            if (Medium.noelec == 0) {
                for (int i93 = 0; i93 < CheckPoints.fn; i93++)
                    if (!CheckPoints.roted[i93]) {
                        if (Math.abs(conto.z - CheckPoints.fz[i93]) < 200 && py(conto.x / 100, CheckPoints.fx[i93] / 100, conto.y / 100, CheckPoints.fy[i93] / 100) < 30) {
                            if (conto.dist == 0) {
                                conto.fcnt = 8;
                            } else {
                                if (im == xtGraphics.im && !conto.fix && !xtGraphics.mutes) {
                                    xtGraphics.carfixed.play();
                                }
                                conto.fix = true;
                            }
                            Record.fix[im] = 300;
                        }
                    } else if (Math.abs(conto.x - CheckPoints.fx[i93]) < 200 && py(conto.z / 100, CheckPoints.fz[i93] / 100, conto.y / 100, CheckPoints.fy[i93] / 100) < 30) {
                        if (conto.dist == 0) {
                            conto.fcnt = 8;
                        } else {
                            if (im == xtGraphics.im && !conto.fix && !xtGraphics.mutes) {
                                xtGraphics.carfixed.play();
                            }
                            conto.fix = true;
                        }
                        Record.fix[im] = 300;
                    }
            }
        } else {
            for (int i94 = 0; i94 < CheckPoints.fn; i94++)
                if (rpy(conto.x / 100, CheckPoints.fx[i94] / 100, conto.y / 100, CheckPoints.fy[i94] / 100, conto.z / 100, CheckPoints.fz[i94] / 100) < 760) {
                    Medium.noelec = 2;
                }
        }
        if (conto.fcnt == 7 || conto.fcnt == 8) {
            squash = 0;
            nbsq = 0;
            hitmag = 0;
            cntdest = 0;
            dest = false;
            newcar = true;
            conto.fcnt = 9;
            if (fixes > 0) {
                fixes--;
            }
        }
        if (newedcar != 0) {
            newedcar--;
            if (newedcar == 10) {
                newcar = false;
            }
        }
        if (!mtouch) {
            if (trcnt != 1) {
                trcnt = 1;
                lxz = conto.xz;
            }
            if (loop == 2 || loop == -1) {
                travxy += rcomp - lcomp;
                if (Math.abs(travxy) > 135) {
                    rtab = true;
                }
                travzy += ucomp - dcomp;
                if (travzy > 135) {
                    ftab = true;
                }
                if (travzy < -135) {
                    btab = true;
                }
            }
            if (lxz != conto.xz) {
                travxz += lxz - conto.xz;
                lxz = conto.xz;
            }
            if (srfcnt < 10) {
                if (control.wall != -1) {
                    surfer = true;
                }
                srfcnt++;
            }
        } else if (!dest) {
            if (!capsized) {
                if (capcnt != 0) {
                    capcnt = 0;
                }
                if (gtouch && trcnt != 0) {
                    if (trcnt == 9) {
                        powerup = 0.0F;
                        if (Math.abs(travxy) > 90) {
                            powerup += Math.abs(travxy) / 24.0F;
                        } else if (rtab) {
                            powerup += 30.0F;
                        }
                        if (Math.abs(travzy) > 90) {
                            powerup += Math.abs(travzy) / 18.0F;
                        } else {
                            if (ftab) {
                                powerup += 40.0F;
                            }
                            if (btab) {
                                powerup += 40.0F;
                            }
                        }
                        if (Math.abs(travxz) > 90) {
                            powerup += Math.abs(travxz) / 18.0F;
                        }
                        if (surfer) {
                            powerup += 30.0F;
                        }
                        power += powerup;
                        if (im == xtGraphics.im && (int) powerup > Record.powered && Record.wasted == 0 && (powerup > 60.0F || CheckPoints.stage == 1 || CheckPoints.stage == 2)) {
                            rpdcatch = 30;
                            if (Record.hcaught) {
                                Record.powered = (int) powerup;
                            }
                            if (xtGraphics.multion == 1 && powerup > xtGraphics.beststunt) {
                                xtGraphics.beststunt = (int) powerup;
                            }
                        }
                        if (power > 98.0F) {
                            power = 98.0F;
                            if (powerup > 150.0F) {
                                xtpower = 200;
                            } else {
                                xtpower = 100;
                            }
                        }
                    }
                    if (trcnt == 10) {
                        travxy = 0;
                        travzy = 0;
                        travxz = 0;
                        ftab = false;
                        rtab = false;
                        btab = false;
                        trcnt = 0;
                        srfcnt = 0;
                        surfer = false;
                    } else {
                        trcnt++;
                    }
                }
            } else {
                if (trcnt != 0) {
                    travxy = 0;
                    travzy = 0;
                    travxz = 0;
                    ftab = false;
                    rtab = false;
                    btab = false;
                    trcnt = 0;
                    srfcnt = 0;
                    surfer = false;
                }
                if (capcnt == 0) {
                    int i95 = 0;
                    for (int i96 = 0; i96 < 4; i96++)
                        if (Math.abs(scz[i96]) < 70.0F && Math.abs(scx[i96]) < 70.0F) {
                            i95++;
                        }
                    if (i95 == 4) {
                        capcnt = 1;
                    }
                } else {
                    capcnt++;
                    if (capcnt == 30) {
                        speed = 0.0F;
                        conto.y += stat.flipy;
                        pxy += 180;
                        conto.xy += 180;
                        capcnt = 0;
                    }
                }
            }
            if (trcnt == 0 && speed != 0.0F)
                if (xtpower == 0) {
                    if (power > 0.0F) {
                        power -= power * power * power / stat.powerloss;
                    } else {
                        power = 0.0F;
                    }
                } else {
                    xtpower--;
                }
        }
        if (im == xtGraphics.im) {
            if (control.wall != -1) {
                control.wall = -1;
            }
        } else if (lastcolido != 0 && !dest) {
            lastcolido--;
        }
        if (dest) {
            if (CheckPoints.dested[im] == 0)
                if (lastcolido == 0) {
                    CheckPoints.dested[im] = 1;
                } else {
                    CheckPoints.dested[im] = 2;
                }
        } else if (CheckPoints.dested[im] != 0 && CheckPoints.dested[im] != 3) {
            CheckPoints.dested[im] = 0;
        }
        if (im == xtGraphics.im && Record.wasted == 0 && rpdcatch != 0) {
            rpdcatch--;
            if (rpdcatch == 0) {
                Record.cotchinow(im);
                if (Record.hcaught) {
                    Record.whenwasted = (int) (185.0F + Medium.random() * 20.0F);
                }
            }
        }
    }

    private int py(final int i, final int i145, final int i146, final int i147) {
        return (i - i145) * (i - i145) + (i146 - i147) * (i146 - i147);
    }

    private int regx(final int i, float f, final ContO conto) {
        int i110 = 0;
        boolean bool = true;
        if (xtGraphics.multion == 1 && xtGraphics.im != im) {
            bool = false;
        }
        if (xtGraphics.multion >= 2) {
            bool = false;
        }
        if (xtGraphics.lan && xtGraphics.multion >= 1 && xtGraphics.isbot[im]) {
            bool = true;
        }
        f *= stat.dammult;
        if (Math.abs(f) > 100.0F) {
            Record.recx(i, f, im);
            if (f > 100.0F) {
                f -= 100.0F;
            }
            if (f < -100.0F) {
                f += 100.0F;
            }
            shakedam = (int) ((Math.abs(f) + shakedam) / 2.0F);
            if (im == xtGraphics.im || colidim) {
                xtGraphics.crash(im, f, 0);
            }
            for (int i111 = 0; i111 < conto.npl; i111++) {
                float f112 = 0.0F;
                for (int i113 = 0; i113 < conto.p[i111].n; i113++)
                    if (conto.p[i111].wz == 0 && py(conto.keyx[i], conto.p[i111].ox[i113], conto.keyz[i], conto.p[i111].oz[i113]) < stat.clrad) {
                        f112 = f / 20.0F * Medium.random();
                        conto.p[i111].oz[i113] -= f112 * Medium.sin(conto.xz) * Medium.cos(conto.zy);
                        conto.p[i111].ox[i113] += f112 * Medium.cos(conto.xz) * Medium.cos(conto.xy);
                        if (bool) {
                            hitmag += Math.abs(f112);
                            i110 += Math.abs(f112);
                        }
                    }
                if (f112 != 0.0F) {
                    if (Math.abs(f112) >= 1.0F) {
                        conto.p[i111].chip = 1;
                        conto.p[i111].ctmag = f112;
                    }
                    if (!conto.p[i111].nocol && conto.p[i111].glass != 1) {
                        if (conto.p[i111].bfase > 20 && conto.p[i111].hsb[1] > 0.25) {
                            conto.p[i111].hsb[1] = 0.25F;
                        }
                        if (conto.p[i111].bfase > 25 && conto.p[i111].hsb[2] > 0.7) {
                            conto.p[i111].hsb[2] = 0.7F;
                        }
                        if (conto.p[i111].bfase > 30 && conto.p[i111].hsb[1] > 0.15) {
                            conto.p[i111].hsb[1] = 0.15F;
                        }
                        if (conto.p[i111].bfase > 35 && conto.p[i111].hsb[2] > 0.6) {
                            conto.p[i111].hsb[2] = 0.6F;
                        }
                        if (conto.p[i111].bfase > 40) {
                            conto.p[i111].hsb[0] = 0.075F;
                        }
                        if (conto.p[i111].bfase > 50 && conto.p[i111].hsb[2] > 0.5) {
                            conto.p[i111].hsb[2] = 0.5F;
                        }
                        if (conto.p[i111].bfase > 60) {
                            conto.p[i111].hsb[0] = 0.05F;
                        }
                        conto.p[i111].bfase += Math.abs(f112);
                        new Color(conto.p[i111].c[0], conto.p[i111].c[1], conto.p[i111].c[2]);
                        final Color color = Color.getHSBColor(conto.p[i111].hsb[0], conto.p[i111].hsb[1], conto.p[i111].hsb[2]);
                        conto.p[i111].c[0] = color.getRed();
                        conto.p[i111].c[1] = color.getGreen();
                        conto.p[i111].c[2] = color.getBlue();
                    }
                    if (conto.p[i111].glass == 1) {
                        conto.p[i111].gr += Math.abs(f112 * 1.5);
                    }
                }
            }
        }
        return i110;
    }

    private int regy(final int i, float f, final ContO conto) {
        int i97 = 0;
        boolean bool = true;
        if (xtGraphics.multion == 1 && xtGraphics.im != im) {
            bool = false;
        }
        if (xtGraphics.multion >= 2) {
            bool = false;
        }
        if (xtGraphics.lan && xtGraphics.multion >= 1 && xtGraphics.isbot[im]) {
            bool = true;
        }
        f *= stat.dammult;
        if (f > 100.0F) {
            Record.recy(i, f, mtouch, im);
            f -= 100.0F;
            int i98 = 0;
            int i99 = 0;
            int i100 = conto.zy;
            int i101 = conto.xy;
            for (/**/; i100 < 360; i100 += 360) {

            }
            for (/**/; i100 > 360; i100 -= 360) {

            }
            if (i100 < 210 && i100 > 150) {
                i98 = -1;
            }
            if (i100 > 330 || i100 < 30) {
                i98 = 1;
            }
            for (/**/; i101 < 360; i101 += 360) {

            }
            for (/**/; i101 > 360; i101 -= 360) {

            }
            if (i101 < 210 && i101 > 150) {
                i99 = -1;
            }
            if (i101 > 330 || i101 < 30) {
                i99 = 1;
            }
            if (i99 * i98 == 0) {
                shakedam = (int) ((Math.abs(f) + shakedam) / 2.0F);
            }
            if (im == xtGraphics.im || colidim) {
                xtGraphics.crash(im, f, i99 * i98);
            }
            if (i99 * i98 == 0 || mtouch) {
                for (int i102 = 0; i102 < conto.npl; i102++) {
                    float f103 = 0.0F;
                    for (int i104 = 0; i104 < conto.p[i102].n; i104++)
                        if (conto.p[i102].wz == 0 && py(conto.keyx[i], conto.p[i102].ox[i104], conto.keyz[i], conto.p[i102].oz[i104]) < stat.clrad) {
                            f103 = f / 20.0F * Medium.random();
                            conto.p[i102].oz[i104] += f103 * Medium.sin(i100);
                            conto.p[i102].ox[i104] -= f103 * Medium.sin(i101);
                            if (bool) {
                                hitmag += Math.abs(f103);
                                i97 += Math.abs(f103);
                            }
                        }
                    if (f103 != 0.0F) {
                        if (Math.abs(f103) >= 1.0F) {
                            conto.p[i102].chip = 1;
                            conto.p[i102].ctmag = f103;
                        }
                        if (!conto.p[i102].nocol && conto.p[i102].glass != 1) {
                            if (conto.p[i102].bfase > 20 && conto.p[i102].hsb[1] > 0.25) {
                                conto.p[i102].hsb[1] = 0.25F;
                            }
                            if (conto.p[i102].bfase > 25 && conto.p[i102].hsb[2] > 0.7) {
                                conto.p[i102].hsb[2] = 0.7F;
                            }
                            if (conto.p[i102].bfase > 30 && conto.p[i102].hsb[1] > 0.15) {
                                conto.p[i102].hsb[1] = 0.15F;
                            }
                            if (conto.p[i102].bfase > 35 && conto.p[i102].hsb[2] > 0.6) {
                                conto.p[i102].hsb[2] = 0.6F;
                            }
                            if (conto.p[i102].bfase > 40) {
                                conto.p[i102].hsb[0] = 0.075F;
                            }
                            if (conto.p[i102].bfase > 50 && conto.p[i102].hsb[2] > 0.5) {
                                conto.p[i102].hsb[2] = 0.5F;
                            }
                            if (conto.p[i102].bfase > 60) {
                                conto.p[i102].hsb[0] = 0.05F;
                            }
                            conto.p[i102].bfase += f103;
                            new Color(conto.p[i102].c[0], conto.p[i102].c[1], conto.p[i102].c[2]);
                            final Color color = Color.getHSBColor(conto.p[i102].hsb[0], conto.p[i102].hsb[1], conto.p[i102].hsb[2]);
                            conto.p[i102].c[0] = color.getRed();
                            conto.p[i102].c[1] = color.getGreen();
                            conto.p[i102].c[2] = color.getBlue();
                        }
                        if (conto.p[i102].glass == 1) {
                            conto.p[i102].gr += Math.abs(f103 * 1.5);
                        }
                    }
                }
            }
            if (i99 * i98 == -1)
                if (nbsq > 0) {
                    int i105 = 0;
                    int i106 = 1;
                    for (int i107 = 0; i107 < conto.npl; i107++) {
                        float f108 = 0.0F;
                        for (int i109 = 0; i109 < conto.p[i107].n; i109++)
                            if (conto.p[i107].wz == 0) {
                                f108 = f / 15.0F * Medium.random();
                                if ((Math.abs(conto.p[i107].oy[i109] - stat.flipy - squash) < stat.msquash * 3 || conto.p[i107].oy[i109] < stat.flipy + squash) && squash < stat.msquash) {
                                    conto.p[i107].oy[i109] += f108;
                                    i105 += f108;
                                    i106++;
                                    if (bool) {
                                        hitmag += Math.abs(f108);
                                        i97 += Math.abs(f108);
                                    }
                                }
                            }
                        if (conto.p[i107].glass == 1) {
                            conto.p[i107].gr += 5;
                        } else if (f108 != 0.0F) {
                            conto.p[i107].bfase += f108;
                        }
                        if (Math.abs(f108) >= 1.0F) {
                            conto.p[i107].chip = 1;
                            conto.p[i107].ctmag = f108;
                        }
                    }
                    squash += i105 / i106;
                    nbsq = 0;
                } else {
                    nbsq++;
                }
        }
        return i97;
    }

    private int regz(final int i, float f, final ContO conto) {
        int i114 = 0;
        boolean bool = true;
        if (xtGraphics.multion == 1 && xtGraphics.im != im) {
            bool = false;
        }
        if (xtGraphics.multion >= 2) {
            bool = false;
        }
        if (xtGraphics.lan && xtGraphics.multion >= 1 && xtGraphics.isbot[im]) {
            bool = true;
        }
        f *= stat.dammult;
        if (Math.abs(f) > 100.0F) {
            Record.recz(i, f, im);
            if (f > 100.0F) {
                f -= 100.0F;
            }
            if (f < -100.0F) {
                f += 100.0F;
            }
            shakedam = (int) ((Math.abs(f) + shakedam) / 2.0F);
            if (im == xtGraphics.im || colidim) {
                xtGraphics.crash(im, f, 0);
            }
            for (int i115 = 0; i115 < conto.npl; i115++) {
                float f116 = 0.0F;
                for (int i117 = 0; i117 < conto.p[i115].n; i117++)
                    if (conto.p[i115].wz == 0 && py(conto.keyx[i], conto.p[i115].ox[i117], conto.keyz[i], conto.p[i115].oz[i117]) < stat.clrad) {
                        f116 = f / 20.0F * Medium.random();
                        conto.p[i115].oz[i117] += f116 * Medium.cos(conto.xz) * Medium.cos(conto.zy);
                        conto.p[i115].ox[i117] += f116 * Medium.sin(conto.xz) * Medium.cos(conto.xy);
                        if (bool) {
                            hitmag += Math.abs(f116);
                            i114 += Math.abs(f116);
                        }
                    }
                if (f116 != 0.0F) {
                    if (Math.abs(f116) >= 1.0F) {
                        conto.p[i115].chip = 1;
                        conto.p[i115].ctmag = f116;
                    }
                    if (!conto.p[i115].nocol && conto.p[i115].glass != 1) {
                        if (conto.p[i115].bfase > 20 && conto.p[i115].hsb[1] > 0.25) {
                            conto.p[i115].hsb[1] = 0.25F;
                        }
                        if (conto.p[i115].bfase > 25 && conto.p[i115].hsb[2] > 0.7) {
                            conto.p[i115].hsb[2] = 0.7F;
                        }
                        if (conto.p[i115].bfase > 30 && conto.p[i115].hsb[1] > 0.15) {
                            conto.p[i115].hsb[1] = 0.15F;
                        }
                        if (conto.p[i115].bfase > 35 && conto.p[i115].hsb[2] > 0.6) {
                            conto.p[i115].hsb[2] = 0.6F;
                        }
                        if (conto.p[i115].bfase > 40) {
                            conto.p[i115].hsb[0] = 0.075F;
                        }
                        if (conto.p[i115].bfase > 50 && conto.p[i115].hsb[2] > 0.5) {
                            conto.p[i115].hsb[2] = 0.5F;
                        }
                        if (conto.p[i115].bfase > 60) {
                            conto.p[i115].hsb[0] = 0.05F;
                        }
                        conto.p[i115].bfase += Math.abs(f116);
                        new Color(conto.p[i115].c[0], conto.p[i115].c[1], conto.p[i115].c[2]);
                        final Color color = Color.getHSBColor(conto.p[i115].hsb[0], conto.p[i115].hsb[1], conto.p[i115].hsb[2]);
                        conto.p[i115].c[0] = color.getRed();
                        conto.p[i115].c[1] = color.getGreen();
                        conto.p[i115].c[2] = color.getBlue();
                    }
                    if (conto.p[i115].glass == 1) {
                        conto.p[i115].gr += Math.abs(f116 * 1.5);
                    }
                }
            }
        }
        return i114;
    }

    void reseto(final int i, final ContO conto) {
        cn = i;
        for (int i0 = 0; i0 < 8; i0++) {
            dominate[i0] = false;
            caught[i0] = false;
        }
        mxz = 0;
        cxz = 0;
        pzy = 0;
        pxy = 0;
        speed = 0.0F;
        for (int i1 = 0; i1 < 4; i1++) {
            scy[i1] = 0.0F;
            scx[i1] = 0.0F;
            scz[i1] = 0.0F;
        }
        forca = ((float) Math.sqrt(conto.keyz[0] * conto.keyz[0] + conto.keyx[0] * conto.keyx[0]) + (float) Math.sqrt(conto.keyz[1] * conto.keyz[1] + conto.keyx[1] * conto.keyx[1]) + (float) Math.sqrt(conto.keyz[2] * conto.keyz[2] + conto.keyx[2] * conto.keyx[2]) + (float) Math.sqrt(conto.keyz[3] * conto.keyz[3] + conto.keyx[3] * conto.keyx[3])) / 10000.0F * (float) (stat.bounce - 0.3);
        mtouch = false;
        wtouch = false;
        txz = 0;
        fxz = 0;
        pmlt = 1;
        nmlt = 1;
        dcnt = 0;
        skid = 0;
        pushed = false;
        gtouch = false;
        pl = false;
        pr = false;
        pd = false;
        pu = false;
        loop = 0;
        ucomp = 0.0F;
        dcomp = 0.0F;
        lcomp = 0.0F;
        rcomp = 0.0F;
        lxz = 0;
        travxy = 0;
        travzy = 0;
        travxz = 0;
        rtab = false;
        ftab = false;
        btab = false;
        powerup = 0.0F;
        xtpower = 0;
        trcnt = 0;
        capcnt = 0;
        tilt = 0.0F;
        for (int i2 = 0; i2 < 4; i2++) {
            for (int i3 = 0; i3 < 4; i3++) {
                crank[i2][i3] = 0;
                lcrank[i2][i3] = 0;
            }
        }
        pcleared = CheckPoints.pcs;
        clear = 0;
        nlaps = 0;
        focus = -1;
        missedcp = 0;
        nofocus = false;
        power = 98.0F;
        lastcolido = 0;
        CheckPoints.dested[im] = 0;
        squash = 0;
        nbsq = 0;
        hitmag = 0;
        cntdest = 0;
        dest = false;
        newcar = false;
        if (im == xtGraphics.im) {
            Medium.checkpoint = -1;
            Medium.lastcheck = false;
        }
        rpdcatch = 0;
        newedcar = 0;
        fixes = -1;
        if (CheckPoints.nfix == 1) {
            fixes = 4;
        }
        if (CheckPoints.nfix == 2) {
            fixes = 3;
        }
        if (CheckPoints.nfix == 3) {
            fixes = 2;
        }
        if (CheckPoints.nfix == 4) {
            fixes = 1;
        }
    }

    private void rot(final float[] fs, final float[] fs134, final int i, final int i135, final int i136, final int i137) {
        if (i136 != 0) {
            for (int i138 = 0; i138 < i137; i138++) {
                final float f = fs[i138];
                final float f139 = fs134[i138];
                fs[i138] = i + ((f - i) * Medium.cos(i136) - (f139 - i135) * Medium.sin(i136));
                fs134[i138] = i135 + ((f - i) * Medium.sin(i136) + (f139 - i135) * Medium.cos(i136));
            }
        }
    }

    private int rpy(final float f, final float f140, final float f141, final float f142, final float f143, final float f144) {
        return (int) ((f - f140) * (f - f140) + (f141 - f142) * (f141 - f142) + (f143 - f144) * (f143 - f144));
    }
}
