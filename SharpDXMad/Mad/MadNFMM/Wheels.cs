package nfm.open;/* Wheels - Decompiled by JODE
 * Visit http://jode.sourceforge.net/
 */

class Wheels {
    private float depth = 3.0F;
    int ground = 0;
    int mast = 0;
    private final int[] rc = {
            120, 120, 120
    };
    private float size = 2.0F;
    int sparkat = 0;

    public Wheels() {
        sparkat = 0;
        ground = 0;
    }

    void make(final Plane[] planes, int i, final int i4, final int i5, final int i6, final int i7, final int i8, final int i9, final int i10) {
        final int[] is = new int[20];
        final int[] is11 = new int[20];
        final int[] is12 = new int[20];
        final int[] is13 = {
                45, 45, 45
        };
        int i14 = 0;
        final float f = i8 / 10.0F;
        final float f15 = i9 / 10.0F;
        if (i7 == 11) {
            i14 = (int) (i4 + 4.0F * f);
        }
        sparkat = (int) (f15 * 24.0F);
        ground = (int) (i5 + 13.0F * f15);
        int i16 = -1;
        if (i4 < 0) {
            i16 = 1;
        }
        for (int i17 = 0; i17 < 20; i17++) {
            is[i17] = (int) (i4 - 4.0F * f);
        }
        is11[0] = (int) (i5 - 9.1923F * f15);
        is12[0] = (int) (i6 + 9.1923F * f15);
        is11[1] = (int) (i5 - 12.557F * f15);
        is12[1] = (int) (i6 + 3.3646F * f15);
        is11[2] = (int) (i5 - 12.557F * f15);
        is12[2] = (int) (i6 - 3.3646F * f15);
        is11[3] = (int) (i5 - 9.1923F * f15);
        is12[3] = (int) (i6 - 9.1923F * f15);
        is11[4] = (int) (i5 - 3.3646F * f15);
        is12[4] = (int) (i6 - 12.557F * f15);
        is11[5] = (int) (i5 + 3.3646F * f15);
        is12[5] = (int) (i6 - 12.557F * f15);
        is11[6] = (int) (i5 + 9.1923F * f15);
        is12[6] = (int) (i6 - 9.1923F * f15);
        is11[7] = (int) (i5 + 12.557F * f15);
        is12[7] = (int) (i6 - 3.3646F * f15);
        is11[8] = (int) (i5 + 12.557F * f15);
        is12[8] = (int) (i6 + 3.3646F * f15);
        is11[9] = (int) (i5 + 9.1923F * f15);
        is12[9] = (int) (i6 + 9.1923F * f15);
        is11[10] = (int) (i5 + 3.3646F * f15);
        is12[10] = (int) (i6 + 12.557F * f15);
        is11[11] = (int) (i5 - 3.3646F * f15);
        is12[11] = (int) (i6 + 12.557F * f15);
        is11[12] = i5;
        is12[12] = (int) (i6 + 10.0F * size);
        is11[13] = (int) (i5 + 8.66 * size);
        is12[13] = (int) (i6 + 5.0F * size);
        is11[14] = (int) (i5 + 8.66 * size);
        is12[14] = (int) (i6 - 5.0F * size);
        is11[15] = i5;
        is12[15] = (int) (i6 - 10.0F * size);
        is11[16] = (int) (i5 - 8.66 * size);
        is12[16] = (int) (i6 - 5.0F * size);
        is11[17] = (int) (i5 - 8.66 * size);
        is12[17] = (int) (i6 + 5.0F * size);
        is11[18] = i5;
        is12[18] = (int) (i6 + 10.0F * size);
        is11[19] = (int) (i5 - 3.3646F * f15);
        is12[19] = (int) (i6 + 12.557F * f15);
        planes[i] = new Plane(is, is12, is11, 20, is13, 0, i10, 0, i14, i5, i6, 7, 0, false, 0, false, false, false, false, 1, 0, 0, 10);
        planes[i].master = 1;
        i++;
        is[2] = (int) (i4 - depth * f);
        is11[2] = i5;
        is12[2] = i6;
        int i18 = (int) (i10 - depth / size * 4.0F);
        if (i18 < -16) {
            i18 = -16;
        }
        is11[0] = i5;
        is12[0] = (int) (i6 + 10.0F * size);
        is11[1] = (int) (i5 + 8.66 * size);
        is12[1] = (int) (i6 + 5.0F * size);
        planes[i] = new Plane(is, is12, is11, 3, rc, 0, i18, 0, i14, i5, i6, 7, 0, false, 0, false, false, false, false, 1, 0, 0, 10);
        if (depth / size < 7.0F) {
            planes[i].master = 2;
        }
        i++;
        is11[0] = (int) (i5 + 8.66 * size);
        is12[0] = (int) (i6 + 5.0F * size);
        is11[1] = (int) (i5 + 8.66 * size);
        is12[1] = (int) (i6 - 5.0F * size);
        planes[i] = new Plane(is, is12, is11, 3, rc, 0, i18, 0, i14, i5, i6, 7, 0, false, 0, false, false, false, false, 1, 0, 0, 10);
        if (depth / size < 7.0F) {
            planes[i].master = 2;
        }
        i++;
        is11[0] = (int) (i5 + 8.66 * size);
        is12[0] = (int) (i6 - 5.0F * size);
        is11[1] = i5;
        is12[1] = (int) (i6 - 10.0F * size);
        planes[i] = new Plane(is, is12, is11, 3, rc, 0, i18, 0, i14, i5, i6, 7, 0, false, 0, false, false, false, false, 1, 0, 0, 10);
        if (depth / size < 7.0F) {
            planes[i].master = 2;
        }
        i++;
        is11[0] = i5;
        is12[0] = (int) (i6 - 10.0F * size);
        is11[1] = (int) (i5 - 8.66 * size);
        is12[1] = (int) (i6 - 5.0F * size);
        planes[i] = new Plane(is, is12, is11, 3, rc, 0, i18, 0, i14, i5, i6, 7, 0, false, 0, false, false, false, false, 1, 0, 0, 10);
        if (depth / size < 7.0F) {
            planes[i].master = 2;
        }
        i++;
        is11[0] = (int) (i5 - 8.66 * size);
        is12[0] = (int) (i6 - 5.0F * size);
        is11[1] = (int) (i5 - 8.66 * size);
        is12[1] = (int) (i6 + 5.0F * size);
        planes[i] = new Plane(is, is12, is11, 3, rc, 0, i18, 0, i14, i5, i6, 7, 0, false, 0, false, false, false, false, 1, 0, 0, 10);
        if (depth / size < 7.0F) {
            planes[i].master = 2;
        }
        i++;
        is11[0] = (int) (i5 - 8.66 * size);
        is12[0] = (int) (i6 + 5.0F * size);
        is11[1] = i5;
        is12[1] = (int) (i6 + 10.0F * size);
        planes[i] = new Plane(is, is12, is11, 3, rc, 0, i18, 0, i14, i5, i6, 7, 0, false, 0, false, false, false, false, 1, 0, 0, 10);
        if (depth / size < 7.0F) {
            planes[i].master = 2;
        }
        i++;
        is[0] = (int) (i4 - 4.0F * f);
        is11[0] = (int) (i5 - 12.557F * f15);
        is12[0] = (int) (i6 + 3.3646F * f15);
        is[1] = (int) (i4 - 4.0F * f);
        is11[1] = (int) (i5 - 12.557F * f15);
        is12[1] = (int) (i6 - 3.3646F * f15);
        is[2] = (int) (i4 + 4.0F * f);
        is11[2] = (int) (i5 - 12.557F * f15);
        is12[2] = (int) (i6 - 3.3646F * f15);
        is[3] = (int) (i4 + 4.0F * f);
        is11[3] = (int) (i5 - 12.557F * f15);
        is12[3] = (int) (i6 + 3.3646F * f15);
        planes[i] = new Plane(is, is12, is11, 4, is13, 0, i10, -1 * i16, i14, i5, i6, 7, 0, false, 0, true, false, false, false, 1, 0, 0, 10);
        i++;
        is[0] = (int) (i4 - 4.0F * f);
        is11[0] = (int) (i5 - 9.1923F * f15);
        is12[0] = (int) (i6 - 9.1923F * f15);
        is[1] = (int) (i4 - 4.0F * f);
        is11[1] = (int) (i5 - 12.557F * f15);
        is12[1] = (int) (i6 - 3.3646F * f15);
        is[2] = (int) (i4 + 4.0F * f);
        is11[2] = (int) (i5 - 12.557F * f15);
        is12[2] = (int) (i6 - 3.3646F * f15);
        is[3] = (int) (i4 + 4.0F * f);
        is11[3] = (int) (i5 - 9.1923F * f15);
        is12[3] = (int) (i6 - 9.1923F * f15);
        planes[i] = new Plane(is, is12, is11, 4, is13, 0, i10, i16, i14, i5, i6, 7, 0, false, 0, true, false, false, false, 1, 0, 0, 10);
        i++;
        is[0] = (int) (i4 - 4.0F * f);
        is11[0] = (int) (i5 - 9.1923F * f15);
        is12[0] = (int) (i6 - 9.1923F * f15);
        is[1] = (int) (i4 - 4.0F * f);
        is11[1] = (int) (i5 - 3.3646F * f15);
        is12[1] = (int) (i6 - 12.557F * f15);
        is[2] = (int) (i4 + 4.0F * f);
        is11[2] = (int) (i5 - 3.3646F * f15);
        is12[2] = (int) (i6 - 12.557F * f15);
        is[3] = (int) (i4 + 4.0F * f);
        is11[3] = (int) (i5 - 9.1923F * f15);
        is12[3] = (int) (i6 - 9.1923F * f15);
        planes[i] = new Plane(is, is12, is11, 4, is13, 0, i10, i16, i14, i5, i6, 7, 0, false, 0, true, false, false, false, 1, 0, 0, 10);
        i++;
        is[0] = (int) (i4 - 4.0F * f);
        is11[0] = (int) (i5 - 3.3646F * f15);
        is12[0] = (int) (i6 - 12.557F * f15);
        is[1] = (int) (i4 - 4.0F * f);
        is11[1] = (int) (i5 + 3.3646F * f15);
        is12[1] = (int) (i6 - 12.557F * f15);
        is[2] = (int) (i4 + 4.0F * f);
        is11[2] = (int) (i5 + 3.3646F * f15);
        is12[2] = (int) (i6 - 12.557F * f15);
        is[3] = (int) (i4 + 4.0F * f);
        is11[3] = (int) (i5 - 3.3646F * f15);
        is12[3] = (int) (i6 - 12.557F * f15);
        planes[i] = new Plane(is, is12, is11, 4, is13, 0, i10, -1 * i16, i14, i5, i6, 7, 0, false, 0, true, false, false, false, 1, 0, 0, 10);
        i++;
        is[0] = (int) (i4 - 4.0F * f);
        is11[0] = (int) (i5 + 9.1923F * f15);
        is12[0] = (int) (i6 - 9.1923F * f15);
        is[1] = (int) (i4 - 4.0F * f);
        is11[1] = (int) (i5 + 3.3646F * f15);
        is12[1] = (int) (i6 - 12.557F * f15);
        is[2] = (int) (i4 + 4.0F * f);
        is11[2] = (int) (i5 + 3.3646F * f15);
        is12[2] = (int) (i6 - 12.557F * f15);
        is[3] = (int) (i4 + 4.0F * f);
        is11[3] = (int) (i5 + 9.1923F * f15);
        is12[3] = (int) (i6 - 9.1923F * f15);
        planes[i] = new Plane(is, is12, is11, 4, is13, 0, i10, i16, i14, i5, i6, 7, 0, false, 0, true, false, false, false, 1, 0, 0, 10);
        i++;
        is[0] = (int) (i4 - 4.0F * f);
        is11[0] = (int) (i5 + 9.1923F * f15);
        is12[0] = (int) (i6 - 9.1923F * f15);
        is[1] = (int) (i4 - 4.0F * f);
        is11[1] = (int) (i5 + 12.557F * f15);
        is12[1] = (int) (i6 - 3.3646F * f15);
        is[2] = (int) (i4 + 4.0F * f);
        is11[2] = (int) (i5 + 12.557F * f15);
        is12[2] = (int) (i6 - 3.3646F * f15);
        is[3] = (int) (i4 + 4.0F * f);
        is11[3] = (int) (i5 + 9.1923F * f15);
        is12[3] = (int) (i6 - 9.1923F * f15);
        planes[i] = new Plane(is, is12, is11, 4, is13, 0, i10, i16, i14, i5, i6, 7, 0, false, 0, true, false, false, false, 1, 0, 0, 10);
        i++;
        is[0] = (int) (i4 - 4.0F * f);
        is11[0] = (int) (i5 + 12.557F * f15);
        is12[0] = (int) (i6 - 3.3646F * f15);
        is[1] = (int) (i4 - 4.0F * f);
        is11[1] = (int) (i5 + 12.557F * f15);
        is12[1] = (int) (i6 + 3.3646F * f15);
        is[2] = (int) (i4 + 4.0F * f);
        is11[2] = (int) (i5 + 12.557F * f15);
        is12[2] = (int) (i6 + 3.3646F * f15);
        is[3] = (int) (i4 + 4.0F * f);
        is11[3] = (int) (i5 + 12.557F * f15);
        is12[3] = (int) (i6 - 3.3646F * f15);
        planes[i] = new Plane(is, is12, is11, 4, is13, 0, i10, -1 * i16, i14, i5, i6, 7, 0, false, 0, true, false, false, false, 1, 0, 0, 10);
        i++;
        is[0] = (int) (i4 - 4.0F * f);
        is11[0] = (int) (i5 + 9.1923F * f15);
        is12[0] = (int) (i6 + 9.1923F * f15);
        is[1] = (int) (i4 - 4.0F * f);
        is11[1] = (int) (i5 + 12.557F * f15);
        is12[1] = (int) (i6 + 3.3646F * f15);
        is[2] = (int) (i4 + 4.0F * f);
        is11[2] = (int) (i5 + 12.557F * f15);
        is12[2] = (int) (i6 + 3.3646F * f15);
        is[3] = (int) (i4 + 4.0F * f);
        is11[3] = (int) (i5 + 9.1923F * f15);
        is12[3] = (int) (i6 + 9.1923F * f15);
        planes[i] = new Plane(is, is12, is11, 4, is13, 0, i10, i16, i14, i5, i6, 7, 0, false, 0, true, false, false, false, 1, 0, 0, 10);
        i++;
        is[0] = (int) (i4 - 4.0F * f);
        is11[0] = (int) (i5 + 9.1923F * f15);
        is12[0] = (int) (i6 + 9.1923F * f15);
        is[1] = (int) (i4 - 4.0F * f);
        is11[1] = (int) (i5 + 3.3646F * f15);
        is12[1] = (int) (i6 + 12.557F * f15);
        is[2] = (int) (i4 + 4.0F * f);
        is11[2] = (int) (i5 + 3.3646F * f15);
        is12[2] = (int) (i6 + 12.557F * f15);
        is[3] = (int) (i4 + 4.0F * f);
        is11[3] = (int) (i5 + 9.1923F * f15);
        is12[3] = (int) (i6 + 9.1923F * f15);
        planes[i] = new Plane(is, is12, is11, 4, is13, 0, i10, i16, i14, i5, i6, 7, 0, false, 0, true, false, false, false, 1, 0, 0, 10);
        i++;
        is[0] = (int) (i4 - 4.0F * f);
        is11[0] = (int) (i5 + 3.3646F * f15);
        is12[0] = (int) (i6 + 12.557F * f15);
        is[1] = (int) (i4 - 4.0F * f);
        is11[1] = (int) (i5 - 3.3646F * f15);
        is12[1] = (int) (i6 + 12.557F * f15);
        is[2] = (int) (i4 + 4.0F * f);
        is11[2] = (int) (i5 - 3.3646F * f15);
        is12[2] = (int) (i6 + 12.557F * f15);
        is[3] = (int) (i4 + 4.0F * f);
        is11[3] = (int) (i5 + 3.3646F * f15);
        is12[3] = (int) (i6 + 12.557F * f15);
        planes[i] = new Plane(is, is12, is11, 4, is13, 0, i10, -1 * i16, i14, i5, i6, 7, 0, false, 0, true, false, false, false, 1, 0, 0, 10);
        i++;
        is[0] = (int) (i4 - 4.0F * f);
        is11[0] = (int) (i5 - 9.1923F * f15);
        is12[0] = (int) (i6 + 9.1923F * f15);
        is[1] = (int) (i4 - 4.0F * f);
        is11[1] = (int) (i5 - 3.3646F * f15);
        is12[1] = (int) (i6 + 12.557F * f15);
        is[2] = (int) (i4 + 4.0F * f);
        is11[2] = (int) (i5 - 3.3646F * f15);
        is12[2] = (int) (i6 + 12.557F * f15);
        is[3] = (int) (i4 + 4.0F * f);
        is11[3] = (int) (i5 - 9.1923F * f15);
        is12[3] = (int) (i6 + 9.1923F * f15);
        planes[i] = new Plane(is, is12, is11, 4, is13, 0, i10, i16, i14, i5, i6, 7, 0, false, 0, true, false, false, false, 1, 0, 0, 10);
        i++;
        is[0] = (int) (i4 - 4.0F * f);
        is11[0] = (int) (i5 - 9.1923F * f15);
        is12[0] = (int) (i6 + 9.1923F * f15);
        is[1] = (int) (i4 - 4.0F * f);
        is11[1] = (int) (i5 - 12.557F * f15);
        is12[1] = (int) (i6 + 3.3646F * f15);
        is[2] = (int) (i4 + 4.0F * f);
        is11[2] = (int) (i5 - 12.557F * f15);
        is12[2] = (int) (i6 + 3.3646F * f15);
        is[3] = (int) (i4 + 4.0F * f);
        is11[3] = (int) (i5 - 9.1923F * f15);
        is12[3] = (int) (i6 + 9.1923F * f15);
        planes[i] = new Plane(is, is12, is11, 4, is13, 0, i10, i16, i14, i5, i6, 7, 0, false, 0, true, false, false, false, 1, 0, 0, 10);
        i++;
    }

    void setrims(final int i, final int i0, final int i1, final int i2, final int i3) {
        rc[0] = i;
        rc[1] = i0;
        rc[2] = i1;
        size = i2 / 10.0F;
        if (size < 0.0F) {
            size = 0.0F;
        }
        depth = i3 / 10.0F;
        if (depth / size > 41.0F) {
            depth = size * 41.0F;
        }
        if (depth / size < -25.0F) {
            depth = -(size * 25.0F);
        }
    }
}
