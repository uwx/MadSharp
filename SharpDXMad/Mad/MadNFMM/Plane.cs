package nfm.open;
/* Plane - Decompiled by JODE
 * Visit http://jode.sourceforge.net/
 */
import java.awt.BasicStroke;
import java.awt.Color;
import java.awt.Graphics2D;
import java.awt.RenderingHints;
import java.util.concurrent.ThreadLocalRandom;

final class Plane implements Comparable<Plane> {
    private int av = 0;
    int bfase = 0;
    final int[] c = new int[3];
    int chip = 0;
    int colnum = 0;
    private final int[] cox = new int[3];
    private final int[] coy = new int[3];
    private final int[] coz = new int[3];
    float ctmag = 0.0F;
    private int cxy = 0;
    private int cxz = 0;
    private int czy = 0;
    private float deltaf = 1.0F;
    private int disline = 7;
    private int dx = 0;
    private int dy = 0;
    private int dz = 0;
    int embos = 0;
    int flx = 0;
    int fs = 0;
    int glass = 0;
    int gr = 0;
    final float[] hsb = new float[3];
    int light = 0;
    int master = 0;
    int n;
    boolean nocol = false;
    final int[] oc = new int[3];
    final int[] ox;
    final int[] oy;
    final int[] oz;
    private int pa = 0;
    private int pb = 0;
    private float projf = 1.0F;
    boolean road = false;
    boolean solo = false;
    private int typ = 0;
    private int vx = 0;
    private int vy = 0;
    private int vz = 0;
    int wx = 0;
    int wy = 0;
    int wz = 0;

    final boolean customstroke;
    final int strokewidth;
    final int strokecap;
    final int strokejoin;
    final int strokemtlimit;
    final boolean randomcolor;
    final boolean randoutline;
    
    byte project;//booleans are bytes anyway so hey why not

    Plane(final int[] is, final int[] is0, final int[] is1, final int i, final int[] is2, final int i3, final int i4, final int i5, final int i6, final int i7, final int i8, final int i9, final int i10, final boolean bool, final int i11, final boolean bool12, final boolean randomcolor, final boolean randoutline, final boolean customstroke, final int strokewidth, final int strokecap, final int strokejoin, final int strokemtlimit) {
        this.randoutline = randoutline;
        this.randomcolor = randomcolor;
        //stroke
        this.customstroke = customstroke;
        this.strokewidth = strokewidth;
        this.strokecap = strokecap;
        this.strokejoin = strokejoin;
        this.strokemtlimit = strokemtlimit;
        n = i;
        ox = new int[n];
        oz = new int[n];
        oy = new int[n];
        for (int i13 = 0; i13 < n; i13++) {
            ox[i13] = is[i13];
            oy[i13] = is1[i13];
            oz[i13] = is0[i13];
        }
        System.arraycopy(is2, 0, oc, 0, 3);
        if (i4 == -15) {
            if (is2[0] == 211) {
                final int i15 = (int) (ThreadLocalRandom.current().nextDouble() * 40.0 - 20.0);
                final int i16 = (int) (ThreadLocalRandom.current().nextDouble() * 40.0 - 20.0);
                for (int i17 = 0; i17 < n; i17++) {
                    ox[i17] += i15;
                    oz[i17] += i16;
                }
            }
            final int i18 = (int) (185.0 + ThreadLocalRandom.current().nextDouble() * 20.0);
            is2[0] = (217 + i18) / 2;
            if (is2[0] == 211) {
                is2[0] = 210;
            }
            is2[1] = (189 + i18) / 2;
            is2[2] = (132 + i18) / 2;
            for (int i19 = 0; i19 < n; i19++) {
                if (ThreadLocalRandom.current().nextDouble() > ThreadLocalRandom.current().nextDouble()) {
                    ox[i19] += (int) (8.0 * ThreadLocalRandom.current().nextDouble() - 4.0);
                }
                if (ThreadLocalRandom.current().nextDouble() > ThreadLocalRandom.current().nextDouble()) {
                    oy[i19] += (int) (8.0 * ThreadLocalRandom.current().nextDouble() - 4.0);
                }
                if (ThreadLocalRandom.current().nextDouble() > ThreadLocalRandom.current().nextDouble()) {
                    oz[i19] += (int) (8.0 * ThreadLocalRandom.current().nextDouble() - 4.0);
                }
            }
        }
        if (is2[0] == is2[1] && is2[1] == is2[2]) {
            nocol = true;
        }
        if (i3 == 0) {
            for (int i20 = 0; i20 < 3; i20++) {
                c[i20] = (int) (is2[i20] + is2[i20] * (Medium.snap[i20] / 100.0F));
                if (c[i20] > 255) {
                    c[i20] = 255;
                }
                if (c[i20] < 0) {
                    c[i20] = 0;
                }
            }
        }
        if (i3 == 1) {
            for (int i21 = 0; i21 < 3; i21++) {
                c[i21] = (Medium.csky[i21] * Medium.fade[0] * 2 + Medium.cfade[i21] * 3000) / (Medium.fade[0] * 2 + 3000);
            }
        }
        if (i3 == 2) {
            for (int i22 = 0; i22 < 3; i22++) {
                c[i22] = (int) (Medium.crgrnd[i22] * 0.925F);
            }
        }
        if (i3 == 3) {
            System.arraycopy(is2, 0, c, 0, 3);
        }
        disline = i9;
        bfase = i10;
        glass = i3;
        Color.RGBtoHSB(c[0], c[1], c[2], hsb);
        if (i3 == 3 && Medium.trk != 2) {
            hsb[1] += 0.05F;
            if (hsb[1] > 1.0F) {
                hsb[1] = 1.0F;
            }
        }
        if (!nocol && glass != 1) {
            if (bfase > 20 && hsb[1] > 0.25) {
                hsb[1] = 0.25F;
            }
            if (bfase > 25 && hsb[2] > 0.7) {
                hsb[2] = 0.7F;
            }
            if (bfase > 30 && hsb[1] > 0.15) {
                hsb[1] = 0.15F;
            }
            if (bfase > 35 && hsb[2] > 0.6) {
                hsb[2] = 0.6F;
            }
            if (bfase > 40) {
                hsb[0] = 0.075F;
            }
            if (bfase > 50 && hsb[2] > 0.5) {
                hsb[2] = 0.5F;
            }
            if (bfase > 60) {
                hsb[0] = 0.05F;
            }
        }
        road = bool;
        light = i11;
        solo = bool12;
        gr = i4;
        if (gr == -1337) {
            project = -1;
            gr = 0;
        } else if (gr == 1337) {
            project = 1;
            gr = 0;
        }
        fs = i5;
        wx = i6;
        wy = i7;
        wz = i8;
        deltafntyp();
    }

    void d(final Plane _last, final Plane _next, final Graphics2D graphics2d, final int _mx, final int _my, final int _mz, final int _xz, final int _xy, final int _yz, final int i34, final int i35, boolean bool, final int i36) {
        if (master == 1)
            if (av > 1500 && !Medium.crs) {
                n = 12;
            } else {
                n = 20;
            }
        final int[] _x = new int[n];
        final int[] _z = new int[n];
        final int[] _y = new int[n];
        if (embos == 0) {
            for (int i39 = 0; i39 < n; i39++) {
                _x[i39] = ox[i39] + _mx;
                _y[i39] = oy[i39] + _my;
                _z[i39] = oz[i39] + _mz;
            }
            if ((gr == -11 || gr == -12 || gr == -13) && Medium.lastmaf == 1) {
                for (int i40 = 0; i40 < n; i40++) {
                    _x[i40] = -ox[i40] + _mx;
                    _y[i40] = oy[i40] + _my;
                    _z[i40] = -oz[i40] + _mz;
                }
            }
        } else {
            if (embos <= 11 && Medium.random() > 0.5 && glass != 1) {
                for (int i41 = 0; i41 < n; i41++) {
                    _x[i41] = (int) (ox[i41] + _mx + (15.0F - Medium.random() * 30.0F));
                    _y[i41] = (int) (oy[i41] + _my + (15.0F - Medium.random() * 30.0F));
                    _z[i41] = (int) (oz[i41] + _mz + (15.0F - Medium.random() * 30.0F));
                }
                rot(_x, _y, _mx, _my, _xy, n);
                rot(_y, _z, _my, _mz, _yz, n);
                rot(_x, _z, _mx, _mz, _xz, n);
                rot(_x, _z, Medium.cx, Medium.cz, Medium.xz, n);
                rot(_y, _z, Medium.cy, Medium.cz, Medium.zy, n);
                final int[] is42 = new int[n];
                final int[] is43 = new int[n];
                for (int i44 = 0; i44 < n; i44++) {
                    is42[i44] = xs(_x[i44], _z[i44]);
                    is43[i44] = ys(_y[i44], _z[i44]);
                }
                graphics2d.setColor(new Color(230, 230, 230));
                graphics2d.fillPolygon(is42, is43, n);
            }
            float f = 1.0F;
            if (embos <= 4) {
                f = 1.0F + Medium.random() / 5.0F;
            }
            if (embos > 4 && embos <= 7) {
                f = 1.0F + Medium.random() / 4.0F;
            }
            if (embos > 7 && embos <= 9) {
                f = 1.0F + Medium.random() / 3.0F;
                if (hsb[2] > 0.7) {
                    hsb[2] = 0.7F;
                }
            }
            if (embos > 9 && embos <= 10) {
                f = 1.0F + Medium.random() / 2.0F;
                if (hsb[2] > 0.6) {
                    hsb[2] = 0.6F;
                }
            }
            if (embos > 10 && embos <= 12) {
                f = 1.0F + Medium.random() / 1.0F;
                if (hsb[2] > 0.5) {
                    hsb[2] = 0.5F;
                }
            }
            if (embos == 12) {
                chip = 1;
                ctmag = 2.0F;
                bfase = -7;
            }
            if (embos == 13) {
                hsb[1] = 0.2F;
                hsb[2] = 0.4F;
            }
            if (embos == 16) {
                pa = (int) (Medium.random() * n);
                for (pb = (int) (Medium.random() * n); pa == pb; pb = (int) (Medium.random() * n)) {

                }
            }
            if (embos >= 16) {
                int i45 = 1;
                int i46 = 1;
                int i47;
                for (i47 = Math.abs(_yz); i47 > 270; i47 -= 360) {

                }
                i47 = Math.abs(i47);
                if (i47 > 90) {
                    i45 = -1;
                }
                int i48;
                for (i48 = Math.abs(_xy); i48 > 270; i48 -= 360) {

                }
                i48 = Math.abs(i48);
                if (i48 > 90) {
                    i46 = -1;
                }
                final int[] is49 = new int[3];
                final int[] is50 = new int[3];
                _x[0] = ox[pa] + _mx;
                _y[0] = oy[pa] + _my;
                _z[0] = oz[pa] + _mz;
                _x[1] = ox[pb] + _mx;
                _y[1] = oy[pb] + _my;
                _z[1] = oz[pb] + _mz;
                while (Math.abs(_x[0] - _x[1]) > 100)
                    if (_x[1] > _x[0]) {
                        _x[1] -= 30;
                    } else {
                        _x[1] += 30;
                    }
                while (Math.abs(_z[0] - _z[1]) > 100)
                    if (_z[1] > _z[0]) {
                        _z[1] -= 30;
                    } else {
                        _z[1] += 30;
                    }
                final int i51 = (int) (Math.abs(_x[0] - _x[1]) / 3 * (0.5 - Medium.random()));
                final int i52 = (int) (Math.abs(_z[0] - _z[1]) / 3 * (0.5 - Medium.random()));
                _x[2] = (_x[0] + _x[1]) / 2 + i51;
                _z[2] = (_z[0] + _z[1]) / 2 + i52;
                int i53 = (int) ((Math.abs(_x[0] - _x[1]) + Math.abs(_z[0] - _z[1])) / 1.5 * (Medium.random() / 2.0F + 0.5));
                _y[2] = (_y[0] + _y[1]) / 2 - i45 * i46 * i53;
                rot(_x, _y, _mx, _my, _xy, 3);
                rot(_y, _z, _my, _mz, _yz, 3);
                rot(_x, _z, _mx, _mz, _xz, 3);
                rot(_x, _z, Medium.cx, Medium.cz, Medium.xz, 3);
                rot(_y, _z, Medium.cy, Medium.cz, Medium.zy, 3);
                for (int i54 = 0; i54 < 3; i54++) {
                    is49[i54] = xs(_x[i54], _z[i54]);
                    is50[i54] = ys(_y[i54], _z[i54]);
                }
                int i55 = (int) (255.0F + 255.0F * (Medium.snap[0] / 400.0F));
                if (i55 > 255) {
                    i55 = 255;
                }
                if (i55 < 0) {
                    i55 = 0;
                }
                int i56 = (int) (169.0F + 169.0F * (Medium.snap[1] / 300.0F));
                if (i56 > 255) {
                    i56 = 255;
                }
                if (i56 < 0) {
                    i56 = 0;
                }
                int i57 = (int) (89.0F + 89.0F * (Medium.snap[2] / 200.0F));
                if (i57 > 255) {
                    i57 = 255;
                }
                if (i57 < 0) {
                    i57 = 0;
                }
                graphics2d.setColor(new Color(i55, i56, i57));
                graphics2d.fillPolygon(is49, is50, 3);
                _x[0] = ox[pa] + _mx;
                _y[0] = oy[pa] + _my;
                _z[0] = oz[pa] + _mz;
                _x[1] = ox[pb] + _mx;
                _y[1] = oy[pb] + _my;
                _z[1] = oz[pb] + _mz;
                while (Math.abs(_x[0] - _x[1]) > 100)
                    if (_x[1] > _x[0]) {
                        _x[1] -= 30;
                    } else {
                        _x[1] += 30;
                    }
                while (Math.abs(_z[0] - _z[1]) > 100)
                    if (_z[1] > _z[0]) {
                        _z[1] -= 30;
                    } else {
                        _z[1] += 30;
                    }
                _x[2] = (_x[0] + _x[1]) / 2 + i51;
                _z[2] = (_z[0] + _z[1]) / 2 + i52;
                i53 *= 0.8;
                _y[2] = (_y[0] + _y[1]) / 2 - i45 * i46 * i53;
                rot(_x, _y, _mx, _my, _xy, 3);
                rot(_y, _z, _my, _mz, _yz, 3);
                rot(_x, _z, _mx, _mz, _xz, 3);
                rot(_x, _z, Medium.cx, Medium.cz, Medium.xz, 3);
                rot(_y, _z, Medium.cy, Medium.cz, Medium.zy, 3);
                for (int i58 = 0; i58 < 3; i58++) {
                    is49[i58] = xs(_x[i58], _z[i58]);
                    is50[i58] = ys(_y[i58], _z[i58]);
                }
                i55 = (int) (255.0F + 255.0F * (Medium.snap[0] / 400.0F));
                if (i55 > 255) {
                    i55 = 255;
                }
                if (i55 < 0) {
                    i55 = 0;
                }
                i56 = (int) (207.0F + 207.0F * (Medium.snap[1] / 300.0F));
                if (i56 > 255) {
                    i56 = 255;
                }
                if (i56 < 0) {
                    i56 = 0;
                }
                i57 = (int) (136.0F + 136.0F * (Medium.snap[2] / 200.0F));
                if (i57 > 255) {
                    i57 = 255;
                }
                if (i57 < 0) {
                    i57 = 0;
                }
                graphics2d.setColor(new Color(i55, i56, i57));
                graphics2d.fillPolygon(is49, is50, 3);
            }
            for (int i59 = 0; i59 < n; i59++) {
                if (typ == 1) {
                    _x[i59] = (int) (ox[i59] * f + _mx);
                } else {
                    _x[i59] = ox[i59] + _mx;
                }
                if (typ == 2) {
                    _y[i59] = (int) (oy[i59] * f + _my);
                } else {
                    _y[i59] = oy[i59] + _my;
                }
                if (typ == 3) {
                    _z[i59] = (int) (oz[i59] * f + _mz);
                } else {
                    _z[i59] = oz[i59] + _mz;
                }
            }
            if (embos != 70) {
                embos++;
            } else {
                embos = 16;
            }
        }
        if (wz != 0) {
            rot(_y, _z, wy + _my, wz + _mz, i35, n);
        }
        if (wx != 0) {
            rot(_x, _z, wx + _mx, wz + _mz, i34, n);
        }
        if (chip == 1 && (Medium.random() > 0.6 || bfase == 0)) {
            chip = 0;
            if (bfase == 0 && nocol) {
                bfase = 1;
            }
        }
        if (chip != 0) {
            if (chip == 1) {
                cxz = _xz;
                cxy = _xy;
                czy = _yz;
                final int i60 = (int) (Medium.random() * n);
                cox[0] = ox[i60];
                coz[0] = oz[i60];
                coy[0] = oy[i60];
                if (ctmag > 3.0F) {
                    ctmag = 3.0F;
                }
                if (ctmag < -3.0F) {
                    ctmag = -3.0F;
                }
                cox[1] = (int) (cox[0] + ctmag * (10.0F - Medium.random() * 20.0F));
                cox[2] = (int) (cox[0] + ctmag * (10.0F - Medium.random() * 20.0F));
                coy[1] = (int) (coy[0] + ctmag * (10.0F - Medium.random() * 20.0F));
                coy[2] = (int) (coy[0] + ctmag * (10.0F - Medium.random() * 20.0F));
                coz[1] = (int) (coz[0] + ctmag * (10.0F - Medium.random() * 20.0F));
                coz[2] = (int) (coz[0] + ctmag * (10.0F - Medium.random() * 20.0F));
                dx = 0;
                dy = 0;
                dz = 0;
                if (bfase != -7) {
                    vx = (int) (ctmag * (30.0F - Medium.random() * 60.0F));
                    vz = (int) (ctmag * (30.0F - Medium.random() * 60.0F));
                    vy = (int) (ctmag * (30.0F - Medium.random() * 60.0F));
                } else {
                    vx = (int) (ctmag * (10.0F - Medium.random() * 20.0F));
                    vz = (int) (ctmag * (10.0F - Medium.random() * 20.0F));
                    vy = (int) (ctmag * (10.0F - Medium.random() * 20.0F));
                }
                chip = 2;
            }
            final int[] is61 = new int[3];
            final int[] is62 = new int[3];
            final int[] is63 = new int[3];
            for (int i64 = 0; i64 < 3; i64++) {
                is61[i64] = cox[i64] + _mx;
                is63[i64] = coy[i64] + _my;
                is62[i64] = coz[i64] + _mz;
            }
            rot(is61, is63, _mx, _my, cxy, 3);
            rot(is63, is62, _my, _mz, czy, 3);
            rot(is61, is62, _mx, _mz, cxz, 3);
            for (int i65 = 0; i65 < 3; i65++) {
                is61[i65] += dx;
                is63[i65] += dy;
                is62[i65] += dz;
            }
            dx += vx;
            dz += vz;
            dy += vy;
            vy += 7;
            if (is63[0] > Medium.ground) {
                chip = 19;
            }
            rot(is61, is62, Medium.cx, Medium.cz, Medium.xz, 3);
            rot(is63, is62, Medium.cy, Medium.cz, Medium.zy, 3);
            final int[] is66 = new int[3];
            final int[] is67 = new int[3];
            for (int i68 = 0; i68 < 3; i68++) {
                is66[i68] = xs(is61[i68], is62[i68]);
                is67[i68] = ys(is63[i68], is62[i68]);
            }
            final int i69 = (int) (Medium.random() * 3.0F);
            if (bfase != -7) {
                if (i69 == 0) {
                    graphics2d.setColor(new Color(c[0], c[1], c[2]).darker());
                }
                if (i69 == 1) {
                    graphics2d.setColor(new Color(c[0], c[1], c[2]));
                }
                if (i69 == 2) {
                    graphics2d.setColor(new Color(c[0], c[1], c[2]).brighter());
                }
            } else {
                graphics2d.setColor(Color.getHSBColor(hsb[0], hsb[1], hsb[2]));
            }
            graphics2d.fillPolygon(is66, is67, 3);
            chip++;
            if (chip == 20) {
                chip = 0;
            }
        }
        rot(_x, _y, _mx, _my, _xy, n);
        rot(_y, _z, _my, _mz, _yz, n);
        rot(_x, _z, _mx, _mz, _xz, n);
        if ((_xy != 0 || _yz != 0 || _xz != 0) && Medium.trk != 2) {
            projf = 1.0F;
            for (int i70 = 0; i70 < 3; i70++) {
                for (int i71 = 0; i71 < 3; i71++)
                    if (i71 != i70) {
                        projf *= (float) (Math.sqrt((_x[i70] - _x[i71]) * (_x[i70] - _x[i71]) + (_z[i70] - _z[i71]) * (_z[i70] - _z[i71])) / 100.0);
                    }
            }
            projf = projf / 3.0F;
        }
        rot(_x, _z, Medium.cx, Medium.cz, Medium.xz, n);
        boolean bool72 = false;
        final int[] is73 = new int[n];
        final int[] is74 = new int[n];
        int i75 = 500;
        for (int i76 = 0; i76 < n; i76++) {
            is73[i76] = xs(_x[i76], _z[i76]);
            is74[i76] = ys(_y[i76], _z[i76]);
        }
        int i77 = 0;
        int i78 = 1;
        for (int i79 = 0; i79 < n; i79++) {
            for (int i80 = i79; i80 < n; i80++)
                if (i79 != i80 && Math.abs(is73[i79] - is73[i80]) - Math.abs(is74[i79] - is74[i80]) < i75) {
                    i78 = i79;
                    i77 = i80;
                    i75 = Math.abs(is73[i79] - is73[i80]) - Math.abs(is74[i79] - is74[i80]);
                }
        }
        if (is74[i77] < is74[i78]) {
            final int i81 = i77;
            i77 = i78;
            i78 = i81;
        }
        if (spy(_x[i77], _z[i77]) > spy(_x[i78], _z[i78])) {
            bool72 = true;
            int i82 = 0;
            for (int i83 = 0; i83 < n; i83++)
                if (_z[i83] < 50 && _y[i83] > Medium.cy) {
                    bool72 = false;
                } else if (_y[i83] == _y[0]) {
                    i82++;
                }
            if (i82 == n && _y[0] > Medium.cy) {
                bool72 = false;
            }
        }
        rot(_y, _z, Medium.cy, Medium.cz, Medium.zy, n);
        boolean bool84 = true;
        final int[] is85 = new int[n];
        final int[] is86 = new int[n];
        int i87 = 0;
        int i88 = 0;
        int i89 = 0;
        int i90 = 0;
        int i91 = 0;
        for (int i92 = 0; i92 < n; i92++) {
            is85[i92] = xs(_x[i92], _z[i92]);
            is86[i92] = ys(_y[i92], _z[i92]);
            if (is86[i92] < Medium.ih || _z[i92] < 10) {
                i87++;
            }
            if (is86[i92] > Medium.h || _z[i92] < 10) {
                i88++;
            }
            if (is85[i92] < Medium.iw || _z[i92] < 10) {
                i89++;
            }
            if (is85[i92] > Medium.w || _z[i92] < 10) {
                i90++;
            }
            if (_z[i92] < 10) {
                i91++;
            }
        }
        if (i89 == n || i87 == n || i88 == n || i90 == n) {
            bool84 = false;
        }
        if ((Medium.trk == 1 || Medium.trk == 4) && (i89 != 0 || i87 != 0 || i88 != 0 || i90 != 0)) {
            bool84 = false;
        }
        if (Medium.trk == 3 && i91 != 0) {
            bool84 = false;
        }
        if (i91 != 0) {
            bool = true;
        }
        if (bool84 && i36 != -1) {
            int i93 = 0;
            int i94 = 0;
            for (int i95 = 0; i95 < n; i95++) {
                for (int i96 = i95; i96 < n; i96++)
                    if (i95 != i96) {
                        if (Math.abs(is85[i95] - is85[i96]) > i93) {
                            i93 = Math.abs(is85[i95] - is85[i96]);
                        }
                        if (Math.abs(is86[i95] - is86[i96]) > i94) {
                            i94 = Math.abs(is86[i95] - is86[i96]);
                        }
                    }
            }
            if (i93 == 0 || i94 == 0) {
                bool84 = false;
            } else if (i93 < 3 && i94 < 3 && (i36 / i93 > 15 && i36 / i94 > 15 || bool) && (!Medium.lightson || light == 0)) {
                bool84 = false;
            }
        }
        if (bool84) {
            int i97 = 1;
            int i98 = gr;
            if (i98 < 0 && i98 >= -15) {
                i98 = 0;
            }
            if (gr == -11) {
                i98 = -90;
            }
            if (gr == -12) {
                i98 = -75;
            }
            if (gr == -14 || gr == -15) {
                i98 = -50;
            }
            if (glass == 2) {
                i98 = 200;
            }
            if (fs != 0) {
                int i101;
                int i102;
                if (Math.abs(is86[0] - is86[1]) > Math.abs(is86[2] - is86[1])) {
                    i101 = 0;
                    i102 = 2;
                } else {
                    i101 = 2;
                    i102 = 0;
                    i97 *= -1;
                }
                if (is86[1] > is86[i101]) {
                    i97 *= -1;
                }
                if (is85[1] > is85[i102]) {
                    i97 *= -1;
                }
                if (fs != 22) {
                    i97 *= fs;
                    if (i97 == -1) {
                        i98 += 40;
                        i97 = -111;
                    }
                }
            }
            if (Medium.lightson && light == 2) {
                i98 -= 40;
            }
            int i103 = _y[0];
            int i104 = _y[0];
            int i105 = _x[0];
            int i106 = _x[0];
            int i107 = _z[0];
            int i108 = _z[0];
            for (int i109 = 0; i109 < n; i109++) {
                if (_y[i109] > i103) {
                    i103 = _y[i109];
                }
                if (_y[i109] < i104) {
                    i104 = _y[i109];
                }
                if (_x[i109] > i105) {
                    i105 = _x[i109];
                }
                if (_x[i109] < i106) {
                    i106 = _x[i109];
                }
                if (_z[i109] > i107) {
                    i107 = _z[i109];
                }
                if (_z[i109] < i108) {
                    i108 = _z[i109];
                }
            }
            final int i110 = (i103 + i104) / 2;
            final int i111 = (i105 + i106) / 2;
            final int i112 = (i107 + i108) / 2;
            av = (int) Math.sqrt((Medium.cy - i110) * (Medium.cy - i110) + (Medium.cx - i111) * (Medium.cx - i111) + i112 * i112 + i98 * i98 * i98);
            if (Medium.trk == 0 && (av > Medium.fade[disline] || av == 0)) {
                bool84 = false;
            }
            if (i97 == -111 && av > 4500 && !road) {
                bool84 = false;
            }
            if (i97 == -111 && av > 1500) {
                bool = true;
            }
            if (av > 3000 && Medium.adv <= 900) {
                bool = true;
            }
            if (fs == 22 && av < 11200) {
                Medium.lastmaf = i97;
            }
            if (gr == -13 && (!Medium.lastcheck || i36 != -1)) {
                bool84 = false;
            }
            if (master == 2 && av > 1500 && !Medium.crs) {
                bool84 = false;
            }
            if ((gr == -14 || gr == -15 || gr == -12) && (av > 11000 || bool72 || i97 == -111 || Medium.resdown == 2) && Medium.trk != 2 && Medium.trk != 3) {
                bool84 = false;
            }
            if (gr == -11 && av > 11000 && Medium.trk != 2 && Medium.trk != 3) {
                bool84 = false;
            }
            if (glass == 2 && (Medium.trk != 0 || av > 6700)) {
                bool84 = false;
            }
            if (flx != 0 && Medium.random() > 0.3 && flx != 77) {
                bool84 = false;
            }
        }
        if (bool84) {
            float f = (float) (projf / deltaf + 0.3);
            if (bool && !solo) {
                boolean bool113 = false;
                if (f > 1.0F) {
                    if (f >= 1.27) {
                        bool113 = true;
                    }
                    f = 1.0F;
                }
                if (bool113) {
                    f *= 0.89;
                } else {
                    f *= 0.86;
                }
                if (f < 0.37) {
                    f = 0.37F;
                }
                if (gr == -9) {
                    f = 0.7F;
                }
                if (gr == -4) {
                    f = 0.74F;
                }
                if (gr != -7 && Medium.trk == 0 && bool72) {
                    f = 0.32F;
                }
                if (gr == -8 || gr == -14 || gr == -15) {
                    f = 1.0F;
                }
                if (gr == -11 || gr == -12) {
                    f = 0.6F;
                    if (i36 == -1)
                        if (Medium.cpflik || Medium.nochekflk && !Medium.lastcheck) {
                            f = 1.0F;
                        } else {
                            f = 0.76F;
                        }
                }
                if (gr == -13 && i36 == -1)
                    if (Medium.cpflik) {
                        f = 0.0F;
                    } else {
                        f = 0.76F;
                    }
                if (gr == -6) {
                    f = 0.62F;
                }
                if (gr == -5) {
                    f = 0.55F;
                }
            } else {
                if (f > 1.0F) {
                    f = 1.0F;
                }
                if (f < 0.6 || bool72) {
                    f = 0.6F;
                }
            }
            if (project==-1) {
                f = (float) (_last.projf / _last.deltaf + 0.3);

                if (f > 1.0F) {
                    f = 1.0F;
                }
                if (f < 0.6 || bool72) {//yeah its referencing OUR bool72, i dunno man...
                    f = 0.6F;
                }
            } else if (project==1 && _next!=null) {
                f = (float) (_next.projf / _next.deltaf + 0.3);

                if (f > 1.0F) {
                    f = 1.0F;
                }
                if (f < 0.6 || bool72) {//yeah its referencing OUR bool72, i dunno man...
                    f = 0.6F;
                }
            }
            Color color = Color.getHSBColor(hsb[0], hsb[1], hsb[2] * f);
            if (Medium.trk == 1) {
                final float[] fs = new float[3];
                Color.RGBtoHSB(oc[0], oc[1], oc[2], fs);
                fs[0] = 0.15F;
                fs[1] = 0.3F;
                color = Color.getHSBColor(fs[0], fs[1], fs[2] * f + 0.0F);
            }
            if (Medium.trk == 3) {
                final float[] fs = new float[3];
                Color.RGBtoHSB(oc[0], oc[1], oc[2], fs);
                fs[0] = 0.6F;
                fs[1] = 0.14F;
                color = Color.getHSBColor(fs[0], fs[1], fs[2] * f + 0.0F);
            }
            int i114 = color.getRed();
            int i115 = color.getGreen();
            int i116 = color.getBlue();
            if (randomcolor) { //before the dim
                i114 = (int) (ThreadLocalRandom.current().nextDouble() * 255);
                i115 = (int) (ThreadLocalRandom.current().nextDouble() * 255);
                i116 = (int) (ThreadLocalRandom.current().nextDouble() * 255);
            }
            if (Medium.lightson && (light != 0 || (gr == -11 || gr == -12) && i36 == -1)) {
                i114 = oc[0];
                if (i114 > 255) {
                    i114 = 255;
                }
                if (i114 < 0) {
                    i114 = 0;
                }
                i115 = oc[1];
                if (i115 > 255) {
                    i115 = 255;
                }
                if (i115 < 0) {
                    i115 = 0;
                }
                i116 = oc[2];
                if (i116 > 255) {
                    i116 = 255;
                }
                if (i116 < 0) {
                    i116 = 0;
                }
            }
            if (Medium.trk == 0) {
                for (int i117 = 0; i117 < 16; i117++)
                    if (av > Medium.fade[i117]) {
                        i114 = (i114 * Medium.fogd + Medium.cfade[0]) / (Medium.fogd + 1);
                        i115 = (i115 * Medium.fogd + Medium.cfade[1]) / (Medium.fogd + 1);
                        i116 = (i116 * Medium.fogd + Medium.cfade[2]) / (Medium.fogd + 1);
                    }
            }
            graphics2d.setColor(new Color(i114, i115, i116));
            graphics2d.fillPolygon(is85, is86, n);
            if (Medium.trk != 0 && gr == -10) {
                bool = false;
            }
            if (!bool) {
                if (flx == 0) {
                    if (!solo) {
                        i114 = 0;
                        i115 = 0;
                        i116 = 0;
                        if (randoutline) {
                            i114 = (int) (ThreadLocalRandom.current().nextDouble() * 255);
                            i115 = (int) (ThreadLocalRandom.current().nextDouble() * 255);
                            i116 = (int) (ThreadLocalRandom.current().nextDouble() * 255);
                        }
                        if (Medium.lightson && light != 0) {
                            i114 = oc[0] / 2;
                            if (i114 > 255) {
                                i114 = 255;
                            }
                            if (i114 < 0) {
                                i114 = 0;
                            }
                            i115 = oc[1] / 2;
                            if (i115 > 255) {
                                i115 = 255;
                            }
                            if (i115 < 0) {
                                i115 = 0;
                            }
                            i116 = oc[2] / 2;
                            if (i116 > 255) {
                                i116 = 255;
                            }
                            if (i116 < 0) {
                                i116 = 0;
                            }
                        }
                        if (Madness.anti == 1) {
                            graphics2d.setRenderingHint(RenderingHints.KEY_ANTIALIASING, RenderingHints.VALUE_ANTIALIAS_ON);
                        }
                        graphics2d.setColor(new Color(i114, i115, i116));
                        if (customstroke) {
                            graphics2d.setStroke(new BasicStroke(strokewidth, strokecap, strokejoin, strokemtlimit));
                        }
                        graphics2d.drawPolygon(is85, is86, n);
                        if (customstroke) {
                            graphics2d.setStroke(new BasicStroke());
                        }
                        if (Madness.anti == 1) {
                            graphics2d.setRenderingHint(RenderingHints.KEY_ANTIALIASING, RenderingHints.VALUE_ANTIALIAS_OFF);
                        }
                    }
                } else {
                    if (flx == 2) {
                        graphics2d.setColor(new Color(0, 0, 0));
                        graphics2d.drawPolygon(is85, is86, n);
                    }
                    if (flx == 1) {
                        i114 = 0;
                        i115 = (int) (223.0F + 223.0F * (Medium.snap[1] / 100.0F));
                        if (i115 > 255) {
                            i115 = 255;
                        }
                        if (i115 < 0) {
                            i115 = 0;
                        }
                        i116 = (int) (255.0F + 255.0F * (Medium.snap[2] / 100.0F));
                        if (i116 > 255) {
                            i116 = 255;
                        }
                        if (i116 < 0) {
                            i116 = 0;
                        }
                        graphics2d.setColor(new Color(i114, i115, i116));
                        graphics2d.drawPolygon(is85, is86, n);
                        flx = 2;
                    }
                    if (flx == 3) {
                        i114 = 0;
                        i115 = (int) (255.0F + 255.0F * (Medium.snap[1] / 100.0F));
                        if (i115 > 255) {
                            i115 = 255;
                        }
                        if (i115 < 0) {
                            i115 = 0;
                        }
                        i116 = (int) (223.0F + 223.0F * (Medium.snap[2] / 100.0F));
                        if (i116 > 255) {
                            i116 = 255;
                        }
                        if (i116 < 0) {
                            i116 = 0;
                        }
                        graphics2d.setColor(new Color(i114, i115, i116));
                        graphics2d.drawPolygon(is85, is86, n);
                        flx = 2;
                    }
                    if (flx == 77) {
                        graphics2d.setColor(new Color(16, 198, 255));
                        graphics2d.drawPolygon(is85, is86, n);
                        flx = 0;
                    }
                }
            } else if (road && av <= 3000 && Medium.trk == 0 && Medium.fade[0] > 4000) {
                i114 -= 10;
                if (i114 < 0) {
                    i114 = 0;
                }
                i115 -= 10;
                if (i115 < 0) {
                    i115 = 0;
                }
                i116 -= 10;
                if (i116 < 0) {
                    i116 = 0;
                }
                graphics2d.setColor(new Color(i114, i115, i116));
                graphics2d.drawPolygon(is85, is86, n);
            }
            if (gr == -10)
                if (Medium.trk == 0) {
                    i114 = c[0];
                    i115 = c[1];
                    i116 = c[2];
                    if (i36 == -1 && Medium.cpflik) {
                        i114 *= 1.6;
                        if (i114 > 255) {
                            i114 = 255;
                        }
                        i115 *= 1.6;
                        if (i115 > 255) {
                            i115 = 255;
                        }
                        i116 *= 1.6;
                        if (i116 > 255) {
                            i116 = 255;
                        }
                    }
                    for (int i118 = 0; i118 < 16; i118++)
                        if (av > Medium.fade[i118]) {
                            i114 = (i114 * Medium.fogd + Medium.cfade[0]) / (Medium.fogd + 1);
                            i115 = (i115 * Medium.fogd + Medium.cfade[1]) / (Medium.fogd + 1);
                            i116 = (i116 * Medium.fogd + Medium.cfade[2]) / (Medium.fogd + 1);
                        }
                    graphics2d.setColor(new Color(i114, i115, i116));
                    graphics2d.drawPolygon(is85, is86, n);
                } else if (Medium.cpflik && Medium.hit == 5000) {
                    i115 = (int) (ThreadLocalRandom.current().nextDouble() * 115.0);
                    i114 = i115 * 2 - 54;
                    if (i114 < 0) {
                        i114 = 0;
                    }
                    if (i114 > 255) {
                        i114 = 255;
                    }
                    i116 = 202 + i115 * 2;
                    if (i116 < 0) {
                        i116 = 0;
                    }
                    if (i116 > 255) {
                        i116 = 255;
                    }
                    i115 += 101;
                    if (i115 < 0) {
                        i115 = 0;
                    }
                    if (i115 > 255) {
                        i115 = 255;
                    }
                    graphics2d.setColor(new Color(i114, i115, i116));
                    graphics2d.drawPolygon(is85, is86, n);
                }
            if (gr == -18 && Medium.trk == 0) {
                i114 = c[0];
                i115 = c[1];
                i116 = c[2];
                if (Medium.cpflik && Medium.elecr >= 0.0F) {
                    i114 = (int) (25.5F * Medium.elecr);
                    if (i114 > 255) {
                        i114 = 255;
                    }
                    i115 = (int) (128.0F + 12.8F * Medium.elecr);
                    if (i115 > 255) {
                        i115 = 255;
                    }
                    i116 = 255;
                }
                for (int i119 = 0; i119 < 16; i119++)
                    if (av > Medium.fade[i119]) {
                        i114 = (i114 * Medium.fogd + Medium.cfade[0]) / (Medium.fogd + 1);
                        i115 = (i115 * Medium.fogd + Medium.cfade[1]) / (Medium.fogd + 1);
                        i116 = (i116 * Medium.fogd + Medium.cfade[2]) / (Medium.fogd + 1);
                    }
                graphics2d.setColor(new Color(i114, i115, i116));
                graphics2d.drawPolygon(is85, is86, n);
            }
        }
    }

    void deltafntyp() {
        final int i = Math.abs(ox[2] - ox[1]);
        final int i24 = Math.abs(oy[2] - oy[1]);
        final int i25 = Math.abs(oz[2] - oz[1]);
        if (i24 <= i && i24 <= i25) {
            typ = 2;
        }
        if (i <= i24 && i <= i25) {
            typ = 1;
        }
        if (i25 <= i && i25 <= i24) {
            typ = 3;
        }
        deltaf = 1.0F;
        for (int i26 = 0; i26 < 3; i26++) {
            for (int i27 = 0; i27 < 3; i27++)
                if (i27 != i26) {
                    deltaf *= (float) (Math.sqrt((ox[i27] - ox[i26]) * (ox[i27] - ox[i26]) + (oy[i27] - oy[i26]) * (oy[i27] - oy[i26]) + (oz[i27] - oz[i26]) * (oz[i27] - oz[i26])) / 100.0);
                }
        }
        deltaf = deltaf / 3.0F;
    }

    void loadprojf() {
        projf = 1.0F;
        for (int i = 0; i < 3; i++) {
            for (int i28 = 0; i28 < 3; i28++)
                if (i28 != i) {
                    projf *= (float) (Math.sqrt((ox[i] - ox[i28]) * (ox[i] - ox[i28]) + (oz[i] - oz[i28]) * (oz[i] - oz[i28])) / 100.0);
                }
        }
        projf = projf / 3.0F;
    }

    void rot(final int[] is, final int[] is163, final int i, final int i164, final int i165, final int i166) {
        if (i165 != 0) {
            for (int i167 = 0; i167 < i166; i167++) {
                final int i168 = is[i167];
                final int i169 = is163[i167];
                is[i167] = i + (int) ((i168 - i) * Medium.cos(i165) - (i169 - i164) * Medium.sin(i165));
                is163[i167] = i164 + (int) ((i168 - i) * Medium.sin(i165) + (i169 - i164) * Medium.cos(i165));
            }
        }
    }

    void s(final Graphics2D graphics2d, final int i, final int i120, final int i121, final int i122, final int i123, final int i124, final int i125) {
        final int[] is = new int[n];
        final int[] is126 = new int[n];
        final int[] is127 = new int[n];
        for (int i128 = 0; i128 < n; i128++) {
            is[i128] = ox[i128] + i;
            is127[i128] = oy[i128] + i120;
            is126[i128] = oz[i128] + i121;
        }
        rot(is, is127, i, i120, i123, n);
        rot(is127, is126, i120, i121, i124, n);
        rot(is, is126, i, i121, i122, n);
        int i129 = (int) (Medium.crgrnd[0] / 1.5);
        int i130 = (int) (Medium.crgrnd[1] / 1.5);
        int i131 = (int) (Medium.crgrnd[2] / 1.5);
        for (int i132 = 0; i132 < n; i132++) {
            is127[i132] = Medium.ground;
        }
        if (i125 == 0) {
            int i133 = 0;
            int i134 = 0;
            int i135 = 0;
            int i136 = 0;
            for (int i137 = 0; i137 < n; i137++) {
                int i138 = 0;
                int i139 = 0;
                int i140 = 0;
                int i141 = 0;
                for (int i142 = 0; i142 < n; i142++) {
                    if (is[i137] >= is[i142]) {
                        i138++;
                    }
                    if (is[i137] <= is[i142]) {
                        i139++;
                    }
                    if (is126[i137] >= is126[i142]) {
                        i140++;
                    }
                    if (is126[i137] <= is126[i142]) {
                        i141++;
                    }
                }
                if (i138 == n) {
                    i133 = is[i137];
                }
                if (i139 == n) {
                    i134 = is[i137];
                }
                if (i140 == n) {
                    i135 = is126[i137];
                }
                if (i141 == n) {
                    i136 = is126[i137];
                }
            }
            final int i143 = (i133 + i134) / 2;
            final int i144 = (i135 + i136) / 2;
            int i145 = (i143 - Trackers.sx + Medium.x) / 3000;
            if (i145 > Trackers.ncx) {
                i145 = Trackers.ncx;
            }
            if (i145 < 0) {
                i145 = 0;
            }
            int i146 = (i144 - Trackers.sz + Medium.z) / 3000;
            if (i146 > Trackers.ncz) {
                i146 = Trackers.ncz;
            }
            if (i146 < 0) {
                i146 = 0;
            }
            for (int i147 = Trackers.sect[i145][i146].length - 1; i147 >= 0; i147--) {
                final int i148 = Trackers.sect[i145][i146][i147];
                int i149 = 0;
                if (Math.abs(Trackers.zy[i148]) != 90 && Math.abs(Trackers.xy[i148]) != 90 && Trackers.rady[i148] != 801 && Math.abs(i143 - (Trackers.x[i148] - Medium.x)) < Trackers.radx[i148] && Math.abs(i144 - (Trackers.z[i148] - Medium.z)) < Trackers.radz[i148] && (!Trackers.decor[i148] || Medium.resdown != 2)) {
                    i149++;
                }
                if (i149 != 0) {
                    for (int i150 = 0; i150 < n; i150++) {
                        is127[i150] = Trackers.y[i148] - Medium.y;
                        if (Trackers.zy[i148] != 0) {
                            is127[i150] += (is126[i150] - (Trackers.z[i148] - Medium.z - Trackers.radz[i148])) * Medium.sin(Trackers.zy[i148]) / Medium.sin(90 - Trackers.zy[i148]) - Trackers.radz[i148] * Medium.sin(Trackers.zy[i148]) / Medium.sin(90 - Trackers.zy[i148]);
                        }
                        if (Trackers.xy[i148] != 0) {
                            is127[i150] += (is[i150] - (Trackers.x[i148] - Medium.x - Trackers.radx[i148])) * Medium.sin(Trackers.xy[i148]) / Medium.sin(90 - Trackers.xy[i148]) - Trackers.radx[i148] * Medium.sin(Trackers.xy[i148]) / Medium.sin(90 - Trackers.xy[i148]);
                        }
                    }
                    i129 = (int) (Trackers.c[i148][0] / 1.5);
                    i130 = (int) (Trackers.c[i148][1] / 1.5);
                    i131 = (int) (Trackers.c[i148][2] / 1.5);
                    break;
                }
            }
        }
        boolean bool = true;
        final int[] is151 = new int[n];
        final int[] is152 = new int[n];
        if (i125 == 2) {
            i129 = 87;
            i130 = 85;
            i131 = 57;
        } else {
            for (int i153 = 0; i153 < Medium.nsp; i153++) {
                for (int i154 = 0; i154 < n; i154++)
                    if (Math.abs(is[i154] - Medium.spx[i153]) < Medium.sprad[i153] && Math.abs(is126[i154] - Medium.spz[i153]) < Medium.sprad[i153]) {
                        bool = false;
                    }
            }
        }
        if (bool) {
            rot(is, is126, Medium.cx, Medium.cz, Medium.xz, n);
            rot(is127, is126, Medium.cy, Medium.cz, Medium.zy, n);
            int i155 = 0;
            int i156 = 0;
            int i157 = 0;
            int i158 = 0;
            for (int i159 = 0; i159 < n; i159++) {
                is151[i159] = xs(is[i159], is126[i159]);
                is152[i159] = ys(is127[i159], is126[i159]);
                if (is152[i159] < Medium.ih || is126[i159] < 10) {
                    i155++;
                }
                if (is152[i159] > Medium.h || is126[i159] < 10) {
                    i156++;
                }
                if (is151[i159] < Medium.iw || is126[i159] < 10) {
                    i157++;
                }
                if (is151[i159] > Medium.w || is126[i159] < 10) {
                    i158++;
                }
            }
            if (i157 == n || i155 == n || i156 == n || i158 == n) {
                bool = false;
            }
        }
        if (bool) {
            for (int i160 = 0; i160 < 16; i160++)
                if (av > Medium.fade[i160]) {
                    i129 = (i129 * Medium.fogd + Medium.cfade[0]) / (Medium.fogd + 1);
                    i130 = (i130 * Medium.fogd + Medium.cfade[1]) / (Medium.fogd + 1);
                    i131 = (i131 * Medium.fogd + Medium.cfade[2]) / (Medium.fogd + 1);
                }
            graphics2d.setColor(new Color(i129, i130, i131));
            graphics2d.fillPolygon(is151, is152, n);
        }
    }

    private int spy(final int i, final int i170) {
        return (int) Math.sqrt((i - Medium.cx) * (i - Medium.cx) + i170 * i170);
    }

    private int xs(final int i, int i161) {
        if (i161 < Medium.cz) {
            i161 = Medium.cz;
        }
        return (i161 - Medium.focusPoint) * (Medium.cx - i) / i161 + i;
    }

    private int ys(final int i, int i162) {
        if (i162 < Medium.cz) {
            i162 = Medium.cz;
        }
        return (i162 - Medium.focusPoint) * (Medium.cy - i) / i162 + i;
    }

    @Override
    public int compareTo(final Plane o) {
        if (av != o.av) {
            if (av < o.av)
                return 1;
            else
                return -1;
        }
        return 0;
    }
}
