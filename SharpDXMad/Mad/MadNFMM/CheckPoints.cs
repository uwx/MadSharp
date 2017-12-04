using System;
using boolean = System.Boolean;

namespace Cum
{
/* CheckPoints - Decompiled by JODE
 * Visit http://jode.sourceforge.net/
 */

    class CheckPoints
    {
        //private CheckPoints() {}
        internal static int Catchfin;

        internal static readonly int[] Clear =
        {
            0, 0, 0, 0, 0, 0, 0, 0
        };

        internal static readonly int[] Dested =
        {
            0, 0, 0, 0, 0, 0, 0, 0
        };

        internal static int Fn = 0;
        internal static readonly int[] Fx = new int[5];
        internal static readonly int[] Fy = new int[5];
        internal static readonly int[] Fz = new int[5];
        internal static bool Haltall = false;

        internal static readonly float[] Magperc =
        {
            0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F
        };

        internal static string Maker = "";
        internal static int N = 0;
        internal static string Name = "hogan rewish";
        internal static int Nfix = 0;

        internal static int Nlaps = 0;

        /**
         * "<strong>No</strong> <strong>T</strong>rees or <strong>B</strong>umps"<br>
         * Setting this to true will disable trees and bumps.
         */
        internal static bool Notb = false;

        internal static int Nsp = 0;
        internal static int Nto = 0;
        internal static readonly int[] Omxz = new int[8];

        internal static readonly int[] Onscreen = new int[8];

        /**
         * The X of every car ain the stage.
         */
        internal static readonly int[] Opx = new int[8];

        /**
         * The Z of every car ain the stage.
         */
        internal static readonly int[] Opz = new int[8];

        internal static int Pcleared;
        internal static int Pcs = 0;

        internal static readonly int[] Pos =
        {
            7, 7, 7, 7, 7, 7, 7, 7
        };

        private static int _postwo;
        internal static float Prox;
        internal static int Pubt = 0;
        internal static readonly bool[] Roted = new bool[5];
        internal static readonly bool[] Special = new bool[5];
        internal static int Stage = (int) (HansenRandom.Double() * 27.0) + 1;
        internal static int Top20 = 0;
        internal static string Trackname = "";
        internal static int Trackvol = 200;
        internal static readonly int[] Typ = new int[10000];

        internal static int Wasted;

        /**
         * You know when you add )p to the end of pieces? Their coordinates go here. )p basically adds "nodes" for where the AI goes. Therefore, {@link #x} and {@link #z} are the X and Z coordinates of track pieces with )p at the end of them.
         */
        internal static readonly int[] X = new int[10000];

        /**
         * You know when you add )p to the end of pieces? Their coordinates go here. )p basically adds "nodes" for where the AI goes. Therefore, {@link #x} and {@link #z} are the X and Z coordinates of track pieces with )p at the end of them.
         */
        internal static readonly int[] Y = new int[10000];

        /**
         * You know when you add )p to the end of pieces? Their coordinates go here. )p basically adds "nodes" for where the AI goes. Therefore, {@link #x} and {@link #z} are the X and Z coordinates of track pieces with )p at the end of them.
         */
        internal static readonly int[] Z = new int[10000];

        internal static void Calprox()
        {
            var i = 0;
            for (var i9 = 0; i9 < N - 1; i9++)
            {
                for (var i10 = i9 + 1; i10 < N; i10++)
                {
                    if (Math.Abs(X[i9] - X[i10]) > i)
                    {
                        i = Math.Abs(X[i9] - X[i10]);
                    }
                    if (Math.Abs(Z[i9] - Z[i10]) > i)
                    {
                        i = Math.Abs(Z[i9] - Z[i10]);
                    }
                }
            }
            Prox = i / 90.0F;
        }

        internal static void Checkstat(Mad[] mads, ContO[] contos, int i, int i0, int i1)
        {
            if (!Haltall)
            {
                Pcleared = mads[i0].Pcleared;
                for (var i2 = 0; i2 < i; i2++)
                {
                    Magperc[i2] = mads[i2].Hitmag / (float) mads[i2].Stat.Maxmag;
                    if (Magperc[i2] > 1.0F)
                    {
                        Magperc[i2] = 1.0F;
                    }
                    Pos[i2] = 0;
                    Onscreen[i2] = contos[i2].Dist;
                    Opx[i2] = contos[i2].X;
                    Opz[i2] = contos[i2].Z;
                    Omxz[i2] = mads[i2].Mxz;
                    if (Dested[i2] == 0)
                    {
                        Clear[i2] = mads[i2].Clear;
                    }
                    else
                    {
                        Clear[i2] = -1;
                    }
                    mads[i2].Outshakedam = mads[i2].Shakedam;
                    mads[i2].Shakedam = 0;
                }
                for (var i3 = 0; i3 < i; i3++)
                {
                    for (var i4 = i3 + 1; i4 < i; i4++)
                        if (Clear[i3] != Clear[i4])
                        {
                            if (Clear[i3] < Clear[i4])
                            {
                                Pos[i3]++;
                            }
                            else
                            {
                                Pos[i4]++;
                            }
                        }
                        else
                        {
                            var i5 = mads[i3].Pcleared + 1;
                            if (i5 >= N)
                            {
                                i5 = 0;
                            }
                            while (Typ[i5] <= 0)
                                if (++i5 >= N)
                                {
                                    i5 = 0;
                                }
                            if (Py(contos[i3].X / 100, X[i5] / 100, contos[i3].Z / 100, Z[i5] / 100) >
                                Py(contos[i4].X / 100, X[i5] / 100, contos[i4].Z / 100, Z[i5] / 100))
                            {
                                Pos[i3]++;
                            }
                            else
                            {
                                Pos[i4]++;
                            }
                        }
                }
                if (Stage > 2)
                {
                    for (var i6 = 0; i6 < i; i6++)
                        if (Clear[i6] == Nlaps * Nsp && Pos[i6] == 0)
                            if (i6 == i0)
                            {
                                for (var i7 = 0; i7 < i; i7++)
                                    if (Pos[i7] == 1)
                                    {
                                        _postwo = i7;
                                    }
                                if (Py(Opx[i0] / 100, Opx[_postwo] / 100, Opz[i0] / 100, Opz[_postwo] / 100) < 14000 &&
                                    Clear[i0] - Clear[_postwo] == 1)
                                {
                                    Catchfin = 30;
                                }
                            }
                            else if (Pos[i0] == 1 &&
                                     Py(Opx[i0] / 100, Opx[i6] / 100, Opz[i0] / 100, Opz[i6] / 100) < 14000 &&
                                     Clear[i6] - Clear[i0] == 1)
                            {
                                Catchfin = 30;
                                _postwo = i6;
                            }
                }
            }
            Wasted = 0;
            for (var i8 = 0; i8 < i; i8++)
                if ((i0 != i8 || i1 >= 2) && mads[i8].Dest)
                {
                    Wasted++;
                }
            if (Catchfin != 0 && i1 < 2)
            {
                Catchfin--;
                if (Catchfin == 0)
                {
                    Record.Cotchinow(_postwo);
                    Record.Closefinish = Pos[i0] + 1;
                }
            }
        }

        private static int Py(int i, int i11, int i12, int i13)
        {
            return (i - i11) * (i - i11) + (i12 - i13) * (i12 - i13);
        }
    }
}