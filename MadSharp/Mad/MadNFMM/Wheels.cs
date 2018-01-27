namespace Cum
{
    internal class Wheels
    {
        private float _depth = 3.0F;
        internal int Ground;
        internal int Mast = 0;

        private readonly int[] _rc =
        {
            120, 120, 120
        };

        private float _size = 2.0F;
        internal int Sparkat;

        public Wheels()
        {
            Sparkat = 0;
            Ground = 0;
        }

        internal void Make(Plane[] planes, int i, int i4, int i5, int i6, int i7, int i8, int i9, int i10)
        {
            var ais = new int[20];
            var is11 = new int[20];
            var is12 = new int[20];
            int[] is13 =
            {
                45, 45, 45
            };
            var i14 = 0;
            var f = i8 / 10.0F;
            var f15 = i9 / 10.0F;
            if (i7 == 11)
            {
                i14 = (int) (i4 + 4.0F * f);
            }
            Sparkat = (int) (f15 * 24.0F);
            Ground = (int) (i5 + 13.0F * f15);
            var i16 = -1;
            if (i4 < 0)
            {
                i16 = 1;
            }
            for (var i17 = 0; i17 < 20; i17++)
            {
                ais[i17] = (int) (i4 - 4.0F * f);
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
            is12[12] = (int) (i6 + 10.0F * _size);
            is11[13] = (int) (i5 + 8.66 * _size);
            is12[13] = (int) (i6 + 5.0F * _size);
            is11[14] = (int) (i5 + 8.66 * _size);
            is12[14] = (int) (i6 - 5.0F * _size);
            is11[15] = i5;
            is12[15] = (int) (i6 - 10.0F * _size);
            is11[16] = (int) (i5 - 8.66 * _size);
            is12[16] = (int) (i6 - 5.0F * _size);
            is11[17] = (int) (i5 - 8.66 * _size);
            is12[17] = (int) (i6 + 5.0F * _size);
            is11[18] = i5;
            is12[18] = (int) (i6 + 10.0F * _size);
            is11[19] = (int) (i5 - 3.3646F * f15);
            is12[19] = (int) (i6 + 12.557F * f15);
            planes[i] = new Plane(ais, is12, is11, 20, is13, 0, i10, 0, i14, i5, i6, 7, 0, false, 0, false);
            planes[i].Master = 1;
            i++;
            ais[2] = (int) (i4 - _depth * f);
            is11[2] = i5;
            is12[2] = i6;
            var i18 = (int) (i10 - _depth / _size * 4.0F);
            if (i18 < -16)
            {
                i18 = -16;
            }
            is11[0] = i5;
            is12[0] = (int) (i6 + 10.0F * _size);
            is11[1] = (int) (i5 + 8.66 * _size);
            is12[1] = (int) (i6 + 5.0F * _size);
            planes[i] = new Plane(ais, is12, is11, 3, _rc, 0, i18, 0, i14, i5, i6, 7, 0, false, 0, false);
            if (_depth / _size < 7.0F)
            {
                planes[i].Master = 2;
            }
            i++;
            is11[0] = (int) (i5 + 8.66 * _size);
            is12[0] = (int) (i6 + 5.0F * _size);
            is11[1] = (int) (i5 + 8.66 * _size);
            is12[1] = (int) (i6 - 5.0F * _size);
            planes[i] = new Plane(ais, is12, is11, 3, _rc, 0, i18, 0, i14, i5, i6, 7, 0, false, 0, false);
            if (_depth / _size < 7.0F)
            {
                planes[i].Master = 2;
            }
            i++;
            is11[0] = (int) (i5 + 8.66 * _size);
            is12[0] = (int) (i6 - 5.0F * _size);
            is11[1] = i5;
            is12[1] = (int) (i6 - 10.0F * _size);
            planes[i] = new Plane(ais, is12, is11, 3, _rc, 0, i18, 0, i14, i5, i6, 7, 0, false, 0, false);
            if (_depth / _size < 7.0F)
            {
                planes[i].Master = 2;
            }
            i++;
            is11[0] = i5;
            is12[0] = (int) (i6 - 10.0F * _size);
            is11[1] = (int) (i5 - 8.66 * _size);
            is12[1] = (int) (i6 - 5.0F * _size);
            planes[i] = new Plane(ais, is12, is11, 3, _rc, 0, i18, 0, i14, i5, i6, 7, 0, false, 0, false);
            if (_depth / _size < 7.0F)
            {
                planes[i].Master = 2;
            }
            i++;
            is11[0] = (int) (i5 - 8.66 * _size);
            is12[0] = (int) (i6 - 5.0F * _size);
            is11[1] = (int) (i5 - 8.66 * _size);
            is12[1] = (int) (i6 + 5.0F * _size);
            planes[i] = new Plane(ais, is12, is11, 3, _rc, 0, i18, 0, i14, i5, i6, 7, 0, false, 0, false);
            if (_depth / _size < 7.0F)
            {
                planes[i].Master = 2;
            }
            i++;
            is11[0] = (int) (i5 - 8.66 * _size);
            is12[0] = (int) (i6 + 5.0F * _size);
            is11[1] = i5;
            is12[1] = (int) (i6 + 10.0F * _size);
            planes[i] = new Plane(ais, is12, is11, 3, _rc, 0, i18, 0, i14, i5, i6, 7, 0, false, 0, false);
            if (_depth / _size < 7.0F)
            {
                planes[i].Master = 2;
            }
            i++;
            ais[0] = (int) (i4 - 4.0F * f);
            is11[0] = (int) (i5 - 12.557F * f15);
            is12[0] = (int) (i6 + 3.3646F * f15);
            ais[1] = (int) (i4 - 4.0F * f);
            is11[1] = (int) (i5 - 12.557F * f15);
            is12[1] = (int) (i6 - 3.3646F * f15);
            ais[2] = (int) (i4 + 4.0F * f);
            is11[2] = (int) (i5 - 12.557F * f15);
            is12[2] = (int) (i6 - 3.3646F * f15);
            ais[3] = (int) (i4 + 4.0F * f);
            is11[3] = (int) (i5 - 12.557F * f15);
            is12[3] = (int) (i6 + 3.3646F * f15);
            planes[i] = new Plane(ais, is12, is11, 4, is13, 0, i10, -1 * i16, i14, i5, i6, 7, 0, false, 0, true);
            i++;
            ais[0] = (int) (i4 - 4.0F * f);
            is11[0] = (int) (i5 - 9.1923F * f15);
            is12[0] = (int) (i6 - 9.1923F * f15);
            ais[1] = (int) (i4 - 4.0F * f);
            is11[1] = (int) (i5 - 12.557F * f15);
            is12[1] = (int) (i6 - 3.3646F * f15);
            ais[2] = (int) (i4 + 4.0F * f);
            is11[2] = (int) (i5 - 12.557F * f15);
            is12[2] = (int) (i6 - 3.3646F * f15);
            ais[3] = (int) (i4 + 4.0F * f);
            is11[3] = (int) (i5 - 9.1923F * f15);
            is12[3] = (int) (i6 - 9.1923F * f15);
            planes[i] = new Plane(ais, is12, is11, 4, is13, 0, i10, i16, i14, i5, i6, 7, 0, false, 0, true);
            i++;
            ais[0] = (int) (i4 - 4.0F * f);
            is11[0] = (int) (i5 - 9.1923F * f15);
            is12[0] = (int) (i6 - 9.1923F * f15);
            ais[1] = (int) (i4 - 4.0F * f);
            is11[1] = (int) (i5 - 3.3646F * f15);
            is12[1] = (int) (i6 - 12.557F * f15);
            ais[2] = (int) (i4 + 4.0F * f);
            is11[2] = (int) (i5 - 3.3646F * f15);
            is12[2] = (int) (i6 - 12.557F * f15);
            ais[3] = (int) (i4 + 4.0F * f);
            is11[3] = (int) (i5 - 9.1923F * f15);
            is12[3] = (int) (i6 - 9.1923F * f15);
            planes[i] = new Plane(ais, is12, is11, 4, is13, 0, i10, i16, i14, i5, i6, 7, 0, false, 0, true);
            i++;
            ais[0] = (int) (i4 - 4.0F * f);
            is11[0] = (int) (i5 - 3.3646F * f15);
            is12[0] = (int) (i6 - 12.557F * f15);
            ais[1] = (int) (i4 - 4.0F * f);
            is11[1] = (int) (i5 + 3.3646F * f15);
            is12[1] = (int) (i6 - 12.557F * f15);
            ais[2] = (int) (i4 + 4.0F * f);
            is11[2] = (int) (i5 + 3.3646F * f15);
            is12[2] = (int) (i6 - 12.557F * f15);
            ais[3] = (int) (i4 + 4.0F * f);
            is11[3] = (int) (i5 - 3.3646F * f15);
            is12[3] = (int) (i6 - 12.557F * f15);
            planes[i] = new Plane(ais, is12, is11, 4, is13, 0, i10, -1 * i16, i14, i5, i6, 7, 0, false, 0, true);
            i++;
            ais[0] = (int) (i4 - 4.0F * f);
            is11[0] = (int) (i5 + 9.1923F * f15);
            is12[0] = (int) (i6 - 9.1923F * f15);
            ais[1] = (int) (i4 - 4.0F * f);
            is11[1] = (int) (i5 + 3.3646F * f15);
            is12[1] = (int) (i6 - 12.557F * f15);
            ais[2] = (int) (i4 + 4.0F * f);
            is11[2] = (int) (i5 + 3.3646F * f15);
            is12[2] = (int) (i6 - 12.557F * f15);
            ais[3] = (int) (i4 + 4.0F * f);
            is11[3] = (int) (i5 + 9.1923F * f15);
            is12[3] = (int) (i6 - 9.1923F * f15);
            planes[i] = new Plane(ais, is12, is11, 4, is13, 0, i10, i16, i14, i5, i6, 7, 0, false, 0, true);
            i++;
            ais[0] = (int) (i4 - 4.0F * f);
            is11[0] = (int) (i5 + 9.1923F * f15);
            is12[0] = (int) (i6 - 9.1923F * f15);
            ais[1] = (int) (i4 - 4.0F * f);
            is11[1] = (int) (i5 + 12.557F * f15);
            is12[1] = (int) (i6 - 3.3646F * f15);
            ais[2] = (int) (i4 + 4.0F * f);
            is11[2] = (int) (i5 + 12.557F * f15);
            is12[2] = (int) (i6 - 3.3646F * f15);
            ais[3] = (int) (i4 + 4.0F * f);
            is11[3] = (int) (i5 + 9.1923F * f15);
            is12[3] = (int) (i6 - 9.1923F * f15);
            planes[i] = new Plane(ais, is12, is11, 4, is13, 0, i10, i16, i14, i5, i6, 7, 0, false, 0, true);
            i++;
            ais[0] = (int) (i4 - 4.0F * f);
            is11[0] = (int) (i5 + 12.557F * f15);
            is12[0] = (int) (i6 - 3.3646F * f15);
            ais[1] = (int) (i4 - 4.0F * f);
            is11[1] = (int) (i5 + 12.557F * f15);
            is12[1] = (int) (i6 + 3.3646F * f15);
            ais[2] = (int) (i4 + 4.0F * f);
            is11[2] = (int) (i5 + 12.557F * f15);
            is12[2] = (int) (i6 + 3.3646F * f15);
            ais[3] = (int) (i4 + 4.0F * f);
            is11[3] = (int) (i5 + 12.557F * f15);
            is12[3] = (int) (i6 - 3.3646F * f15);
            planes[i] = new Plane(ais, is12, is11, 4, is13, 0, i10, -1 * i16, i14, i5, i6, 7, 0, false, 0, true);
            i++;
            ais[0] = (int) (i4 - 4.0F * f);
            is11[0] = (int) (i5 + 9.1923F * f15);
            is12[0] = (int) (i6 + 9.1923F * f15);
            ais[1] = (int) (i4 - 4.0F * f);
            is11[1] = (int) (i5 + 12.557F * f15);
            is12[1] = (int) (i6 + 3.3646F * f15);
            ais[2] = (int) (i4 + 4.0F * f);
            is11[2] = (int) (i5 + 12.557F * f15);
            is12[2] = (int) (i6 + 3.3646F * f15);
            ais[3] = (int) (i4 + 4.0F * f);
            is11[3] = (int) (i5 + 9.1923F * f15);
            is12[3] = (int) (i6 + 9.1923F * f15);
            planes[i] = new Plane(ais, is12, is11, 4, is13, 0, i10, i16, i14, i5, i6, 7, 0, false, 0, true);
            i++;
            ais[0] = (int) (i4 - 4.0F * f);
            is11[0] = (int) (i5 + 9.1923F * f15);
            is12[0] = (int) (i6 + 9.1923F * f15);
            ais[1] = (int) (i4 - 4.0F * f);
            is11[1] = (int) (i5 + 3.3646F * f15);
            is12[1] = (int) (i6 + 12.557F * f15);
            ais[2] = (int) (i4 + 4.0F * f);
            is11[2] = (int) (i5 + 3.3646F * f15);
            is12[2] = (int) (i6 + 12.557F * f15);
            ais[3] = (int) (i4 + 4.0F * f);
            is11[3] = (int) (i5 + 9.1923F * f15);
            is12[3] = (int) (i6 + 9.1923F * f15);
            planes[i] = new Plane(ais, is12, is11, 4, is13, 0, i10, i16, i14, i5, i6, 7, 0, false, 0, true);
            i++;
            ais[0] = (int) (i4 - 4.0F * f);
            is11[0] = (int) (i5 + 3.3646F * f15);
            is12[0] = (int) (i6 + 12.557F * f15);
            ais[1] = (int) (i4 - 4.0F * f);
            is11[1] = (int) (i5 - 3.3646F * f15);
            is12[1] = (int) (i6 + 12.557F * f15);
            ais[2] = (int) (i4 + 4.0F * f);
            is11[2] = (int) (i5 - 3.3646F * f15);
            is12[2] = (int) (i6 + 12.557F * f15);
            ais[3] = (int) (i4 + 4.0F * f);
            is11[3] = (int) (i5 + 3.3646F * f15);
            is12[3] = (int) (i6 + 12.557F * f15);
            planes[i] = new Plane(ais, is12, is11, 4, is13, 0, i10, -1 * i16, i14, i5, i6, 7, 0, false, 0, true);
            i++;
            ais[0] = (int) (i4 - 4.0F * f);
            is11[0] = (int) (i5 - 9.1923F * f15);
            is12[0] = (int) (i6 + 9.1923F * f15);
            ais[1] = (int) (i4 - 4.0F * f);
            is11[1] = (int) (i5 - 3.3646F * f15);
            is12[1] = (int) (i6 + 12.557F * f15);
            ais[2] = (int) (i4 + 4.0F * f);
            is11[2] = (int) (i5 - 3.3646F * f15);
            is12[2] = (int) (i6 + 12.557F * f15);
            ais[3] = (int) (i4 + 4.0F * f);
            is11[3] = (int) (i5 - 9.1923F * f15);
            is12[3] = (int) (i6 + 9.1923F * f15);
            planes[i] = new Plane(ais, is12, is11, 4, is13, 0, i10, i16, i14, i5, i6, 7, 0, false, 0, true);
            i++;
            ais[0] = (int) (i4 - 4.0F * f);
            is11[0] = (int) (i5 - 9.1923F * f15);
            is12[0] = (int) (i6 + 9.1923F * f15);
            ais[1] = (int) (i4 - 4.0F * f);
            is11[1] = (int) (i5 - 12.557F * f15);
            is12[1] = (int) (i6 + 3.3646F * f15);
            ais[2] = (int) (i4 + 4.0F * f);
            is11[2] = (int) (i5 - 12.557F * f15);
            is12[2] = (int) (i6 + 3.3646F * f15);
            ais[3] = (int) (i4 + 4.0F * f);
            is11[3] = (int) (i5 - 9.1923F * f15);
            is12[3] = (int) (i6 + 9.1923F * f15);
            planes[i] = new Plane(ais, is12, is11, 4, is13, 0, i10, i16, i14, i5, i6, 7, 0, false, 0, true);
            i++;
        }

        internal void Setrims(int i, int i0, int i1, int i2, int i3)
        {
            _rc[0] = i;
            _rc[1] = i0;
            _rc[2] = i1;
            _size = i2 / 10.0F;
            if (_size < 0.0F)
            {
                _size = 0.0F;
            }
            _depth = i3 / 10.0F;
            if (_depth / _size > 41.0F)
            {
                _depth = _size * 41.0F;
            }
            if (_depth / _size < -25.0F)
            {
                _depth = -(_size * 25.0F);
            }
        }
    }
}