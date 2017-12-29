using System;
using boolean = System.Boolean;

namespace Cum
{
    internal class Record
    {
        internal static readonly ContO[,] Car = new ContO[6, 8];
        internal static int Caught;
        private static readonly int[] Checkpoint = new int[300];
        internal static int Closefinish;
        internal static readonly int[] Cntdest = new int[8];
        private static int _cntf = 50;
        internal static readonly int[] Dest = new int[8];
        internal static readonly int[] Fix = new int[8];
        internal static bool Hcaught;
        private static readonly int[] Hcheckpoint = new int[300];

        private static readonly int[] Hdest =
        {
            -1, -1, -1, -1, -1, -1, -1, -1
        };

        internal static readonly int[] Hfix =
        {
            -1, -1, -1, -1, -1, -1, -1, -1
        };

        private static readonly bool[] Hlastcheck = new bool[300];
        private static readonly int[,,] Hmagx = new int[8, 4, 7];
        private static readonly int[,,] Hmagy = new int[8, 4, 7];
        private static readonly int[,,] Hmagz = new int[8, 4, 7];
        private static readonly bool[,] Hmtouch = new bool[8, 7];
        private static readonly float[,] Hrcx = new float[8, 200];
        private static readonly float[,] Hrcy = new float[8, 200];
        private static readonly float[,] Hrcz = new float[8, 200];
        private static readonly int[,] Hrspark = new int[8, 200];
        private static readonly int[,,] Hrx = new int[8, 4, 7];
        private static readonly int[,,] Hry = new int[8, 4, 7];
        private static readonly int[,,] Hrz = new int[8, 4, 7];
        private static readonly int[,,] Hscx = new int[8, 20, 30];
        private static readonly int[,,] Hscz = new int[8, 20, 30];
        private static readonly float[,,] Hsmag = new float[8, 20, 30];
        private static readonly int[,] Hsprk = new int[8, 200];

        private static readonly int[] Hsquash =
        {
            0, 0, 0, 0, 0, 0, 0, 0
        };

        private static readonly int[,] Hsrx = new int[8, 200];
        private static readonly int[,] Hsry = new int[8, 200];
        private static readonly int[,] Hsrz = new int[8, 200];
        private static readonly int[,,] Hsspark = new int[8, 20, 30];
        private static readonly int[,,] Hsx = new int[8, 20, 30];
        private static readonly int[,,] Hsy = new int[8, 20, 30];
        private static readonly int[,,] Hsz = new int[8, 20, 30];
        private static readonly int[,] Hwxz = new int[300, 8];
        private static readonly int[,] Hwzy = new int[300, 8];
        private static readonly int[,] Hx = new int[300, 8];
        private static readonly int[,] Hxy = new int[300, 8];
        private static readonly int[,] Hxz = new int[300, 8];
        private static readonly int[,] Hy = new int[300, 8];
        private static readonly int[,] Hz = new int[300, 8];
        private static readonly int[,] Hzy = new int[300, 8];
        private static readonly bool[] Lastcheck = new bool[300];
        private static int _lastfr;
        private static readonly int[,,] Magx = new int[8, 4, 7];
        private static readonly int[,,] Magy = new int[8, 4, 7];
        private static readonly int[,,] Magz = new int[8, 4, 7];
        private static readonly bool[,] Mtouch = new bool[8, 7];
        private static readonly int[] Nr = new int[8];
        private static readonly int[,] Nrx = new int[8, 4];
        private static readonly int[,] Nry = new int[8, 4];
        private static readonly int[,] Nrz = new int[8, 4];
        private static readonly int[,] Ns = new int[8, 20];
        internal static readonly ContO[] Ocar = new ContO[8];
        internal static int Powered;
        private static bool _prepit = true;
        private static readonly float[,] Rcx = new float[8, 200];
        private static readonly float[,] Rcy = new float[8, 200];
        private static readonly float[,] Rcz = new float[8, 200];
        private static readonly int[,] Rspark = new int[8, 200];
        private static readonly int[,,] Rx = new int[8, 4, 7];
        private static readonly int[,,] Ry = new int[8, 4, 7];
        private static readonly int[,,] Rz = new int[8, 4, 7];
        private static readonly int[,,] Scx = new int[8, 20, 30];
        private static readonly int[,,] Scz = new int[8, 20, 30];
        private static readonly float[,,] Smag = new float[8, 20, 30];
        private static readonly int[,] Sprk = new int[8, 200];
        private static readonly int[,] Squash = new int[6, 8];
        private static readonly int[,] Srx = new int[8, 200];
        private static readonly int[,] Sry = new int[8, 200];
        private static readonly int[,] Srz = new int[8, 200];
        private static readonly int[,,] Sspark = new int[8, 20, 30];
        internal static readonly ContO[] Starcar = new ContO[8];
        private static readonly int[,,] Sx = new int[8, 20, 30];
        private static readonly int[,,] Sy = new int[8, 20, 30];
        private static readonly int[,,] Sz = new int[8, 20, 30];
        internal static int Wasted;
        internal static int Whenwasted;
        private static readonly int[,] Wxz = new int[300, 8];
        private static readonly int[,] Wzy = new int[300, 8];
        private static readonly int[,] X = new int[300, 8];
        private static readonly int[,] Xy = new int[300, 8];
        private static readonly int[,] Xz = new int[300, 8];
        private static readonly int[,] Y = new int[300, 8];
        private static readonly int[,] Z = new int[300, 8];
        private static readonly int[,] Zy = new int[300, 8];

        internal Record()
        {
            Caught = 0;
            Cotchinow(0);
        }

        private static void Chipx(int i, float f, ContO conto, Mad mad)
        {
            if (Math.Abs(f) > 100.0F)
            {
                if (f > 100.0F)
                {
                    f -= 100.0F;
                }
                if (f < -100.0F)
                {
                    f += 100.0F;
                }
                for (var i68 = 0; i68 < conto.Npl; i68++)
                {
                    var f69 = 0.0F;
                    for (var i70 = 0; i70 < conto.P[i68].N; i70++)
                    {
                        if (conto.P[i68].Wz == 0 &&
                            Py(conto.Keyx[i], conto.P[i68].Ox[i70], conto.Keyz[i], conto.P[i68].Oz[i70]) <
                            mad.Stat.Clrad)
                        {
                            f69 = f / 20.0F * Medium.Random();
                        }
                    }

                    if (f69 == 0.0F || !(Math.Abs(f69) >= 1.0F))
                    {
                        continue;
                    }

                    conto.P[i68].Chip = 1;
                    conto.P[i68].Ctmag = f69;
                }
            }
        }

        private static void Chipz(int i, float f, ContO conto, Mad mad)
        {
            if (Math.Abs(f) > 100.0F)
            {
                if (f > 100.0F)
                {
                    f -= 100.0F;
                }
                if (f < -100.0F)
                {
                    f += 100.0F;
                }
                for (var i71 = 0; i71 < conto.Npl; i71++)
                {
                    var f72 = 0.0F;
                    for (var i73 = 0; i73 < conto.P[i71].N; i73++)
                    {
                        if (conto.P[i71].Wz == 0 &&
                            Py(conto.Keyx[i], conto.P[i71].Ox[i73], conto.Keyz[i], conto.P[i71].Oz[i73]) <
                            mad.Stat.Clrad)
                        {
                            f72 = f / 20.0F * Medium.Random();
                        }
                    }

                    if (f72 != 0.0F && Math.Abs(f72) >= 1.0F)
                    {
                        conto.P[i71].Chip = 1;
                        conto.P[i71].Ctmag = f72;
                    }
                }
            }
        }

        internal static void Cotchinow(int i)
        {
            if (Caught >= 300)
            {
                Wasted = i;
                for (var i6 = 0; i6 < 8; i6++)
                {
                    Starcar[i6] = new ContO(Car[0, i6], 0, 0, 0, 0);
                    Hsquash[i6] = Squash[0, i6];
                    Hfix[i6] = Fix[i6];
                    Hdest[i6] = Dest[i6];
                }
                for (var i7 = 0; i7 < 300; i7++)
                {
                    for (var i8 = 0; i8 < 8; i8++)
                    {
                        Hx[i7, i8] = X[i7, i8];
                        Hy[i7, i8] = Y[i7, i8];
                        Hz[i7, i8] = Z[i7, i8];
                        Hxy[i7, i8] = Xy[i7, i8];
                        Hzy[i7, i8] = Zy[i7, i8];
                        Hxz[i7, i8] = Xz[i7, i8];
                        Hwxz[i7, i8] = Wxz[i7, i8];
                        Hwzy[i7, i8] = Wzy[i7, i8];
                    }
                    Hcheckpoint[i7] = Checkpoint[i7];
                    Hlastcheck[i7] = Lastcheck[i7];
                }
                for (var i9 = 0; i9 < 8; i9++)
                {
                    for (var i10 = 0; i10 < 20; i10++)
                    {
                        for (var i11 = 0; i11 < 30; i11++)
                        {
                            Hsspark[i9, i10, i11] = Sspark[i9, i10, i11];
                            Hsx[i9, i10, i11] = Sx[i9, i10, i11];
                            Hsy[i9, i10, i11] = Sy[i9, i10, i11];
                            Hsz[i9, i10, i11] = Sz[i9, i10, i11];
                            Hsmag[i9, i10, i11] = Smag[i9, i10, i11];
                            Hscx[i9, i10, i11] = Scx[i9, i10, i11];
                            Hscz[i9, i10, i11] = Scz[i9, i10, i11];
                        }
                    }
                    for (var i12 = 0; i12 < 200; i12++)
                    {
                        Hrspark[i9, i12] = Rspark[i9, i12];
                        Hsprk[i9, i12] = Sprk[i9, i12];
                        Hsrx[i9, i12] = Srx[i9, i12];
                        Hsry[i9, i12] = Sry[i9, i12];
                        Hsrz[i9, i12] = Srz[i9, i12];
                        Hrcx[i9, i12] = Rcx[i9, i12];
                        Hrcy[i9, i12] = Rcy[i9, i12];
                        Hrcz[i9, i12] = Rcz[i9, i12];
                    }
                }
                for (var i13 = 0; i13 < 8; i13++)
                {
                    for (var i14 = 0; i14 < 4; i14++)
                    {
                        for (var i15 = 0; i15 < 7; i15++)
                        {
                            Hry[i13, i14, i15] = Ry[i13, i14, i15];
                            Hmagy[i13, i14, i15] = Magy[i13, i14, i15];
                            Hrx[i13, i14, i15] = Rx[i13, i14, i15];
                            Hmagx[i13, i14, i15] = Magx[i13, i14, i15];
                            Hrz[i13, i14, i15] = Rz[i13, i14, i15];
                            Hmagz[i13, i14, i15] = Magz[i13, i14, i15];
                        }
                    }
                }
                for (var i16 = 0; i16 < 8; i16++)
                {
                    HansenSystem.ArrayCopy(Mtouch.Slice(i16), 0, Hmtouch.Slice(i16), 0, 7);
                }
                Hcaught = true;
            }
        }

        internal static void Play(ContO conto, Mad mad, int i, int i30)
        {
            conto.X = X[i30, i];
            conto.Y = Y[i30, i];
            conto.Z = Z[i30, i];
            conto.Zy = Zy[i30, i];
            conto.Xy = Xy[i30, i];
            conto.Xz = Xz[i30, i];
            conto.Wxz = Wxz[i30, i];
            conto.Wzy = Wzy[i30, i];
            if (i == 0)
            {
                Medium.Checkpoint = Checkpoint[i30];
                Medium.Lastcheck = Lastcheck[i30];
            }
            if (i30 == 0)
            {
                Cntdest[i] = 0;
            }
            if (Dest[i] == i30)
            {
                Cntdest[i] = 7;
            }
            if (i30 == 0 && Dest[i] < -1)
            {
                for (var i31 = 0; i31 < conto.Npl; i31++)
                {
                    if (conto.P[i31].Wz == 0 || conto.P[i31].Gr == -17 || conto.P[i31].Gr == -16)
                    {
                        conto.P[i31].Embos = 13;
                    }
                }
            }
            if (Cntdest[i] != 0)
            {
                for (var i32 = 0; i32 < conto.Npl; i32++)
                {
                    if (conto.P[i32].Wz == 0 || conto.P[i32].Gr == -17 || conto.P[i32].Gr == -16)
                    {
                        conto.P[i32].Embos = 1;
                    }
                }

                Cntdest[i]--;
            }
            for (var i33 = 0; i33 < 20; i33++)
            {
                for (var i34 = 0; i34 < 30; i34++)
                {
                    if (Sspark[i, i33, i34] == i30)
                    {
                        conto.Stg[i33] = 1;
                        conto.Sx[i33] = Sx[i, i33, i34];
                        conto.Sy[i33] = Sy[i, i33, i34];
                        conto.Sz[i33] = Sz[i, i33, i34];
                        conto.Osmag[i33] = Smag[i, i33, i34];
                        conto.Scx[i33] = Scx[i, i33, i34];
                        conto.Scz[i33] = Scz[i, i33, i34];
                    }
                }
            }
            for (var i35 = 0; i35 < 200; i35++)
            {
                if (Rspark[i, i35] == i30)
                {
                    conto.Sprk = Sprk[i, i35];
                    conto.Srx = Srx[i, i35];
                    conto.Sry = Sry[i, i35];
                    conto.Srz = Srz[i, i35];
                    conto.Rcx = Rcx[i, i35];
                    conto.Rcy = Rcy[i, i35];
                    conto.Rcz = Rcz[i, i35];
                }
            }

            for (var i36 = 0; i36 < 4; i36++)
            {
                for (var i37 = 0; i37 < 7; i37++)
                {
                    if (Ry[i, i36, i37] == i30)
                    {
                        Regy(i36, Magy[i, i36, i37], Mtouch[i, i37], conto, mad);
                    }
                    if (Rx[i, i36, i37] == i30)
                    {
                        Regx(i36, Magx[i, i36, i37], conto, mad);
                    }
                    if (Rz[i, i36, i37] == i30)
                    {
                        Regz(i36, Magz[i, i36, i37], conto, mad);
                    }
                }
            }
        }

        internal static void Playh(ContO conto, Mad mad, int i, int i38, int i39)
        {
            conto.X = Hx[i38, i];
            conto.Y = Hy[i38, i];
            conto.Z = Hz[i38, i];
            conto.Zy = Hzy[i38, i];
            conto.Xy = Hxy[i38, i];
            conto.Xz = Hxz[i38, i];
            conto.Wxz = Hwxz[i38, i];
            conto.Wzy = Hwzy[i38, i];
            if (i == i39)
            {
                Medium.Checkpoint = Hcheckpoint[i38];
                Medium.Lastcheck = Hlastcheck[i38];
            }
            if (i38 == 0)
            {
                Cntdest[i] = 0;
            }
            if (Hdest[i] == i38)
            {
                Cntdest[i] = 7;
            }
            if (i38 == 0 && Hdest[i] < -1)
            {
                for (var i40 = 0; i40 < conto.Npl; i40++)
                {
                    if (conto.P[i40].Wz == 0 || conto.P[i40].Gr == -17 || conto.P[i40].Gr == -16)
                    {
                        conto.P[i40].Embos = 13;
                    }
                }
            }
            if (Cntdest[i] != 0)
            {
                for (var i41 = 0; i41 < conto.Npl; i41++)
                {
                    if (conto.P[i41].Wz == 0 || conto.P[i41].Gr == -17 || conto.P[i41].Gr == -16)
                    {
                        conto.P[i41].Embos = 1;
                    }
                }

                Cntdest[i]--;
            }
            for (var i42 = 0; i42 < 20; i42++)
            {
                for (var i43 = 0; i43 < 30; i43++)
                {
                    if (Hsspark[i, i42, i43] == i38)
                    {
                        conto.Stg[i42] = 1;
                        conto.Sx[i42] = Hsx[i, i42, i43];
                        conto.Sy[i42] = Hsy[i, i42, i43];
                        conto.Sz[i42] = Hsz[i, i42, i43];
                        conto.Osmag[i42] = Hsmag[i, i42, i43];
                        conto.Scx[i42] = Hscx[i, i42, i43];
                        conto.Scz[i42] = Hscz[i, i42, i43];
                    }
                }
            }
            for (var i44 = 0; i44 < 200; i44++)
            {
                if (Hrspark[i, i44] == i38)
                {
                    conto.Sprk = Hsprk[i, i44];
                    conto.Srx = Hsrx[i, i44];
                    conto.Sry = Hsry[i, i44];
                    conto.Srz = Hsrz[i, i44];
                    conto.Rcx = Hrcx[i, i44];
                    conto.Rcy = Hrcy[i, i44];
                    conto.Rcz = Hrcz[i, i44];
                }
            }

            for (var i45 = 0; i45 < 4; i45++)
            {
                for (var i46 = 0; i46 < 7; i46++)
                {
                    if (Hry[i, i45, i46] == i38 && _lastfr != i38)
                    {
                        Regy(i45, Hmagy[i, i45, i46], Hmtouch[i, i46], conto, mad);
                    }
                    if (Hrx[i, i45, i46] == i38)
                    {
                        if (_lastfr != i38)
                        {
                            Regx(i45, Hmagx[i, i45, i46], conto, mad);
                        }
                        else
                        {
                            Chipx(i45, Hmagx[i, i45, i46], conto, mad);
                        }
                    }

                    if (Hrz[i, i45, i46] == i38)
                    {
                        if (_lastfr != i38)
                        {
                            Regz(i45, Hmagz[i, i45, i46], conto, mad);
                        }
                        else
                        {
                            Chipz(i45, Hmagz[i, i45, i46], conto, mad);
                        }
                    }
                }
            }
            _lastfr = i38;
        }

        private static int Py(int i, int i74, int i75, int i76)
        {
            return (i - i74) * (i - i74) + (i75 - i76) * (i75 - i76);
        }

        internal static void Rec(ContO conto, int i, int i18, int i19, int i20, int i21)
        {
            if (i == i21)
            {
                Caught++;
            }
            if (_cntf == 50)
            {
                for (var i22 = 0; i22 < 5; i22++)
                {
                    Car[i22, i] = new ContO(Car[i22 + 1, i], 0, 0, 0, 0);
                    Squash[i22, i] = Squash[i22 + 1, i];
                }
                Car[5, i] = new ContO(conto, 0, 0, 0, 0);
                Squash[5, i] = i18;
                _cntf = 0;
            }
            else
            {
                _cntf++;
            }
            Fix[i]--;
            if (i20 != 0)
            {
                Dest[i]--;
            }
            if (Dest[i] == 230)
            {
                if (i == i21)
                {
                    Cotchinow(i21);
                    Whenwasted = 229;
                }
                else if (i19 != 0)
                {
                    Cotchinow(i);
                    Whenwasted = 165 + i19;
                }
            }

            for (var i23 = 0; i23 < 299; i23++)
            {
                X[i23, i] = X[i23 + 1, i];
                Y[i23, i] = Y[i23 + 1, i];
                Z[i23, i] = Z[i23 + 1, i];
                Zy[i23, i] = Zy[i23 + 1, i];
                Xy[i23, i] = Xy[i23 + 1, i];
                Xz[i23, i] = Xz[i23 + 1, i];
                Wxz[i23, i] = Wxz[i23 + 1, i];
                Wzy[i23, i] = Wzy[i23 + 1, i];
            }
            X[299, i] = conto.X;
            Y[299, i] = conto.Y;
            Z[299, i] = conto.Z;
            Xy[299, i] = conto.Xy;
            Zy[299, i] = conto.Zy;
            Xz[299, i] = conto.Xz;
            Wxz[299, i] = conto.Wxz;
            Wzy[299, i] = conto.Wzy;
            if (i == i21)
            {
                for (var i24 = 0; i24 < 299; i24++)
                {
                    Checkpoint[i24] = Checkpoint[i24 + 1];
                    Lastcheck[i24] = Lastcheck[i24 + 1];
                }
                Checkpoint[299] = Medium.Checkpoint;
                Lastcheck[299] = Medium.Lastcheck;
            }
            for (var i25 = 0; i25 < 20; i25++)
            {
                if (conto.Stg != null && conto.Stg[i25] == 1)
                {
                    Sspark[i, i25, Ns[i, i25]] = 300;
                    Sx[i, i25, Ns[i, i25]] = conto.Sx[i25];
                    Sy[i, i25, Ns[i, i25]] = conto.Sy[i25];
                    Sz[i, i25, Ns[i, i25]] = conto.Sz[i25];
                    Smag[i, i25, Ns[i, i25]] = conto.Osmag[i25];
                    Scx[i, i25, Ns[i, i25]] = conto.Scx[i25];
                    Scz[i, i25, Ns[i, i25]] = conto.Scz[i25];
                    Ns[i, i25]++;
                    if (Ns[i, i25] == 30)
                    {
                        Ns[i, i25] = 0;
                    }
                }
                for (var i26 = 0; i26 < 30; i26++)
                {
                    Sspark[i, i25, i26]--;
                }
            }
            if (conto.Sprk != 0)
            {
                Rspark[i, Nr[i]] = 300;
                Sprk[i, Nr[i]] = conto.Sprk;
                Srx[i, Nr[i]] = conto.Srx;
                Sry[i, Nr[i]] = conto.Sry;
                Srz[i, Nr[i]] = conto.Srz;
                Rcx[i, Nr[i]] = conto.Rcx;
                Rcy[i, Nr[i]] = conto.Rcy;
                Rcz[i, Nr[i]] = conto.Rcz;
                Nr[i]++;
                if (Nr[i] == 200)
                {
                    Nr[i] = 0;
                }
            }
            for (var i27 = 0; i27 < 200; i27++)
            {
                Rspark[i, i27]--;
            }
            for (var i28 = 0; i28 < 4; i28++)
            {
                for (var i29 = 0; i29 < 7; i29++)
                {
                    Ry[i, i28, i29]--;
                    Rx[i, i28, i29]--;
                    Rz[i, i28, i29]--;
                }
            }
        }

        internal static void Recx(int i, float f, int i48)
        {
            Rx[i48, i, Nry[i48, i]] = 300;
            Magx[i48, i, Nry[i48, i]] = (int) f;
            Nrx[i48, i]++;
            if (Nrx[i48, i] == 7)
            {
                Nrx[i48, i] = 0;
            }
        }

        internal static void Recy(int i, float f, bool abool, int i47)
        {
            Ry[i47, i, Nry[i47, i]] = 300;
            Magy[i47, i, Nry[i47, i]] = (int) f;
            Mtouch[i47, Nry[i47, i]] = abool;
            Nry[i47, i]++;
            if (Nry[i47, i] == 7)
            {
                Nry[i47, i] = 0;
            }
        }

        internal static void Recz(int i, float f, int i49)
        {
            Rz[i49, i, Nry[i49, i]] = 300;
            Magz[i49, i, Nry[i49, i]] = (int) f;
            Nrz[i49, i]++;
            if (Nrz[i49, i] == 7)
            {
                Nrz[i49, i] = 0;
            }
        }

        private static void Regx(int i, float f, ContO conto, Mad mad)
        {
            if (Math.Abs(f) > 100.0F)
            {
                if (f > 100.0F)
                {
                    f -= 100.0F;
                }
                if (f < -100.0F)
                {
                    f += 100.0F;
                }
                for (var i62 = 0; i62 < conto.Npl; i62++)
                {
                    var f63 = 0.0F;
                    for (var i64 = 0; i64 < conto.P[i62].N; i64++)
                    {
                        if (conto.P[i62].Wz == 0 &&
                            Py(conto.Keyx[i], conto.P[i62].Ox[i64], conto.Keyz[i], conto.P[i62].Oz[i64]) <
                            mad.Stat.Clrad)
                        {
                            f63 = f / 20.0F * Medium.Random();
                            conto.P[i62].Oz[i64] -= (int) (f63 * Medium.Sin(conto.Xz) * Medium.Cos(conto.Zy));
                            conto.P[i62].Ox[i64] += (int) (f63 * Medium.Cos(conto.Xz) * Medium.Cos(conto.Xy));
                        }
                    }

                    if (f63 != 0.0F)
                    {
                        if (Math.Abs(f63) >= 1.0F)
                        {
                            conto.P[i62].Chip = 1;
                            conto.P[i62].Ctmag = f63;
                        }
                        if (!conto.P[i62].Nocol && conto.P[i62].Glass != 1)
                        {
                            if (conto.P[i62].Bfase > 20 && conto.P[i62].HSB[1] > 0.2)
                            {
                                conto.P[i62].HSB[1] = 0.2F;
                            }
                            if (conto.P[i62].Bfase > 30)
                            {
                                if (conto.P[i62].HSB[2] < 0.5)
                                {
                                    conto.P[i62].HSB[2] = 0.5F;
                                }
                                if (conto.P[i62].HSB[1] > 0.1)
                                {
                                    conto.P[i62].HSB[1] = 0.1F;
                                }
                            }
                            if (conto.P[i62].Bfase > 40)
                            {
                                conto.P[i62].HSB[1] = 0.05F;
                            }
                            if (conto.P[i62].Bfase > 50)
                            {
                                if (conto.P[i62].HSB[2] > 0.8)
                                {
                                    conto.P[i62].HSB[2] = 0.8F;
                                }
                                conto.P[i62].HSB[0] = 0.075F;
                                conto.P[i62].HSB[1] = 0.05F;
                            }
                            if (conto.P[i62].Bfase > 60)
                            {
                                conto.P[i62].HSB[0] = 0.05F;
                            }
                            conto.P[i62].Bfase += (int) Math.Abs(f63);
                            new Color(conto.P[i62].C[0], conto.P[i62].C[1], conto.P[i62].C[2]);
                            var color = Color.GetHSBColor(conto.P[i62].HSB[0], conto.P[i62].HSB[1],
                                conto.P[i62].HSB[2]);
                            conto.P[i62].C[0] = color.GetRed();
                            conto.P[i62].C[1] = color.GetGreen();
                            conto.P[i62].C[2] = color.GetBlue();
                        }
                        if (conto.P[i62].Glass == 1)
                        {
                            conto.P[i62].Gr += (int) Math.Abs(f63 * 1.5);
                        }
                    }
                }
            }
        }

        private static void Regy(int i, float f, bool abool, ContO conto, Mad mad)
        {
            if (f > 100.0F)
            {
                f -= 100.0F;
                var i50 = 0;
                var i51 = 0;
                var i52 = conto.Zy;
                var i53 = conto.Xy;
                for ( /**/; i52 < 360; i52 += 360)
                {
                }
                for ( /**/; i52 > 360; i52 -= 360)
                {
                }
                if (i52 < 210 && i52 > 150)
                {
                    i50 = -1;
                }
                if (i52 > 330 || i52 < 30)
                {
                    i50 = 1;
                }
                for ( /**/; i53 < 360; i53 += 360)
                {
                }
                for ( /**/; i53 > 360; i53 -= 360)
                {
                }
                if (i53 < 210 && i53 > 150)
                {
                    i51 = -1;
                }
                if (i53 > 330 || i53 < 30)
                {
                    i51 = 1;
                }
                if (i51 * i50 == 0 || abool)
                {
                    for (var i54 = 0; i54 < conto.Npl; i54++)
                    {
                        var f55 = 0.0F;
                        for (var i56 = 0; i56 < conto.P[i54].N; i56++)
                        {
                            if (conto.P[i54].Wz == 0 &&
                                Py(conto.Keyx[i], conto.P[i54].Ox[i56], conto.Keyz[i], conto.P[i54].Oz[i56]) <
                                mad.Stat.Clrad)
                            {
                                f55 = f / 20.0F * Medium.Random();
                                conto.P[i54].Oz[i56] += (int) (f55 * Medium.Sin(i52));
                                conto.P[i54].Ox[i56] -= (int) (f55 * Medium.Sin(i53));
                            }
                        }

                        if (f55 != 0.0F)
                        {
                            if (Math.Abs(f55) >= 1.0F)
                            {
                                conto.P[i54].Chip = 1;
                                conto.P[i54].Ctmag = f55;
                            }
                            if (!conto.P[i54].Nocol && conto.P[i54].Glass != 1)
                            {
                                if (conto.P[i54].Bfase > 20 && conto.P[i54].HSB[1] > 0.2)
                                {
                                    conto.P[i54].HSB[1] = 0.2F;
                                }
                                if (conto.P[i54].Bfase > 30)
                                {
                                    if (conto.P[i54].HSB[2] < 0.5)
                                    {
                                        conto.P[i54].HSB[2] = 0.5F;
                                    }
                                    if (conto.P[i54].HSB[1] > 0.1)
                                    {
                                        conto.P[i54].HSB[1] = 0.1F;
                                    }
                                }
                                if (conto.P[i54].Bfase > 40)
                                {
                                    conto.P[i54].HSB[1] = 0.05F;
                                }
                                if (conto.P[i54].Bfase > 50)
                                {
                                    if (conto.P[i54].HSB[2] > 0.8)
                                    {
                                        conto.P[i54].HSB[2] = 0.8F;
                                    }
                                    conto.P[i54].HSB[0] = 0.075F;
                                    conto.P[i54].HSB[1] = 0.05F;
                                }
                                if (conto.P[i54].Bfase > 60)
                                {
                                    conto.P[i54].HSB[0] = 0.05F;
                                }
                                conto.P[i54].Bfase += (int) f55;
                                new Color(conto.P[i54].C[0], conto.P[i54].C[1], conto.P[i54].C[2]);
                                var color = Color.GetHSBColor(conto.P[i54].HSB[0], conto.P[i54].HSB[1],
                                    conto.P[i54].HSB[2]);
                                conto.P[i54].C[0] = color.GetRed();
                                conto.P[i54].C[1] = color.GetGreen();
                                conto.P[i54].C[2] = color.GetBlue();
                            }
                            if (conto.P[i54].Glass == 1)
                            {
                                conto.P[i54].Gr += (int) Math.Abs(f55 * 1.5);
                            }
                        }
                    }
                }
                if (i51 * i50 == -1)
                {
                    var i57 = 0;
                    var i58 = 1;
                    for (var i59 = 0; i59 < conto.Npl; i59++)
                    {
                        var f60 = 0.0F;
                        for (var i61 = 0; i61 < conto.P[i59].N; i61++)
                        {
                            if (conto.P[i59].Wz == 0)
                            {
                                f60 = f / 15.0F * Medium.Random();
                                if ((Math.Abs(conto.P[i59].Oy[i61] - mad.Stat.Flipy - Squash[0, mad.Im]) <
                                     mad.Stat.Msquash * 3 ||
                                     conto.P[i59].Oy[i61] < mad.Stat.Flipy + Squash[0, mad.Im]) &&
                                    Squash[0, mad.Im] < mad.Stat.Msquash)
                                {
                                    conto.P[i59].Oy[i61] += (int) f60;
                                    i57 += (int) f60;
                                    i58++;
                                }
                            }
                        }

                        if (conto.P[i59].Glass == 1)
                        {
                            conto.P[i59].Gr += 5;
                        }
                        else if (f60 != 0.0F)
                        {
                            conto.P[i59].Bfase += (int) f60;
                        }
                        if (Math.Abs(f60) >= 1.0F)
                        {
                            conto.P[i59].Chip = 1;
                            conto.P[i59].Ctmag = f60;
                        }
                    }
                    Squash[0, mad.Im] += i57 / i58;
                }
            }
        }

        private static void Regz(int i, float f, ContO conto, Mad mad)
        {
            if (Math.Abs(f) > 100.0F)
            {
                if (f > 100.0F)
                {
                    f -= 100.0F;
                }
                if (f < -100.0F)
                {
                    f += 100.0F;
                }
                for (var i65 = 0; i65 < conto.Npl; i65++)
                {
                    var f66 = 0.0F;
                    for (var i67 = 0; i67 < conto.P[i65].N; i67++)
                    {
                        if (conto.P[i65].Wz == 0 &&
                            Py(conto.Keyx[i], conto.P[i65].Ox[i67], conto.Keyz[i], conto.P[i65].Oz[i67]) <
                            mad.Stat.Clrad)
                        {
                            f66 = f / 20.0F * Medium.Random();
                            conto.P[i65].Oz[i67] += (int) (f66 * Medium.Cos(conto.Xz) * Medium.Cos(conto.Zy));
                            conto.P[i65].Ox[i67] += (int) (f66 * Medium.Sin(conto.Xz) * Medium.Cos(conto.Xy));
                        }
                    }

                    if (f66 != 0.0F)
                    {
                        if (Math.Abs(f66) >= 1.0F)
                        {
                            conto.P[i65].Chip = 1;
                            conto.P[i65].Ctmag = f66;
                        }
                        if (!conto.P[i65].Nocol && conto.P[i65].Glass != 1)
                        {
                            if (conto.P[i65].Bfase > 20 && conto.P[i65].HSB[1] > 0.2)
                            {
                                conto.P[i65].HSB[1] = 0.2F;
                            }
                            if (conto.P[i65].Bfase > 30)
                            {
                                if (conto.P[i65].HSB[2] < 0.5)
                                {
                                    conto.P[i65].HSB[2] = 0.5F;
                                }
                                if (conto.P[i65].HSB[1] > 0.1)
                                {
                                    conto.P[i65].HSB[1] = 0.1F;
                                }
                            }
                            if (conto.P[i65].Bfase > 40)
                            {
                                conto.P[i65].HSB[1] = 0.05F;
                            }
                            if (conto.P[i65].Bfase > 50)
                            {
                                if (conto.P[i65].HSB[2] > 0.8)
                                {
                                    conto.P[i65].HSB[2] = 0.8F;
                                }
                                conto.P[i65].HSB[0] = 0.075F;
                                conto.P[i65].HSB[1] = 0.05F;
                            }
                            if (conto.P[i65].Bfase > 60)
                            {
                                conto.P[i65].HSB[0] = 0.05F;
                            }
                            conto.P[i65].Bfase += (int) Math.Abs(f66);
                            //new Color(conto.p[i65].c[0], conto.p[i65].c[1], conto.p[i65].c[2]);
                            var color = Color.GetHSBColor(conto.P[i65].HSB[0], conto.P[i65].HSB[1],
                                conto.P[i65].HSB[2]);
                            conto.P[i65].C[0] = color.GetRed();
                            conto.P[i65].C[1] = color.GetGreen();
                            conto.P[i65].C[2] = color.GetBlue();
                        }
                        if (conto.P[i65].Glass == 1)
                        {
                            conto.P[i65].Gr += (int) Math.Abs(f66 * 1.5);
                        }
                    }
                }
            }
        }

        internal static void Reset(ContO[] contos)
        {
            Caught = 0;
            Hcaught = false;
            Wasted = 0;
            Whenwasted = 0;
            Closefinish = 0;
            Powered = 0;
            for (var i = 0; i < 8; i++)
            {
                if (_prepit)
                {
                    Starcar[i] = new ContO(contos[i], 0, 0, 0, 0);
                }
                Fix[i] = -1;
                Dest[i] = -1;
                Cntdest[i] = 0;
            }
            for (var i = 0; i < 6; i++)
            {
                for (var i0 = 0; i0 < 8; i0++)
                {
                    Car[i, i0] = new ContO(contos[i0], 0, 0, 0, 0);
                    Squash[i, i0] = 0;
                }
            }
            for (var i = 0; i < 8; i++)
            {
                Nr[i] = 0;
                for (var i1 = 0; i1 < 200; i1++)
                {
                    Rspark[i, i1] = -1;
                }
                for (var i2 = 0; i2 < 20; i2++)
                {
                    Ns[i, i2] = 0;
                    for (var i3 = 0; i3 < 30; i3++)
                    {
                        Sspark[i, i2, i3] = -1;
                    }
                }
                for (var i4 = 0; i4 < 4; i4++)
                {
                    Nry[i, i4] = 0;
                    Nrx[i, i4] = 0;
                    Nrz[i, i4] = 0;
                    for (var i5 = 0; i5 < 7; i5++)
                    {
                        Ry[i, i4, i5] = -1;
                        Rx[i, i4, i5] = -1;
                        Rz[i, i4, i5] = -1;
                    }
                }
            }
            _prepit = false;
        }
    }
}