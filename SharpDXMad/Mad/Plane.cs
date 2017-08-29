using System;
using SharpDX;
using boolean = System.Boolean;
using g = MadGame.G;
using rd = MadGame.G;

namespace MadGame
{
    public class Plane
    {

        internal Medium m;
        internal int[] ox;
        internal int[] oy;
        internal int[] oz;
        internal int n;
        internal int[] c;
        internal float[] hsb;
        internal bool glass;
        internal int gr;
        internal int fs;
        internal int wx;
        internal int wz;
        internal float deltaf;
        internal float projf;
        internal int av;
        internal int lav;
        internal bool imlast;
        
    public Plane(Medium medium, int[] ai, int[] ai1, int[] ai2, int i, int[] ai3, bool flag, 
            int j, int k, int l, int i1)
    {
        c = new int[3];
        hsb = new float[3];
        glass = false;
        gr = 0;
        fs = 0;
        wx = 0;
        wz = 0;
        deltaf = 1.0F;
        projf = 1.0F;
        av = 0;
        lav = 0;
        imlast = false;
        m = medium;
        n = i;
        ox = new int[n];
        oz = new int[n];
        oy = new int[n];
        for(var j1 = 0; j1 < n; j1++)
        {
            ox[j1] = ai[j1];
            oy[j1] = ai2[j1];
            oz[j1] = ai1[j1];
        }

        glass = flag;
        if(!glass)
        {
            for(var k1 = 0; k1 < 3; k1++)
                c[k1] = ai3[k1];

        } else
        {
            for(var l1 = 0; l1 < 3; l1++)
                c[l1] = m.csky[l1];

        }
        
        Colors.RGBtoHSB(c[0], c[1], c[2], hsb);
        gr = j;
        fs = k;
        wx = l;
        wz = i1;
        for(var i2 = 0; i2 < 3; i2++)
        {
            for(var j2 = 0; j2 < 3; j2++)
                if(j2 != i2)
                    deltaf *= (float)(Math.Sqrt((ox[j2] - ox[i2]) * (ox[j2] - ox[i2]) + (oy[j2] - oy[i2]) * (oy[j2] - oy[i2]) + (oz[j2] - oz[i2]) * (oz[j2] - oz[i2])) / 100D);

        }

        deltaf /= 3F;
    }

    public void loadprojf()
    {
        projf = 1.0F;
        for(var i = 0; i < 3; i++)
        {
            for(var j = 0; j < 3; j++)
                if(j != i)
                    projf *= (float)(Math.Sqrt((ox[i] - ox[j]) * (ox[i] - ox[j]) + (oz[i] - oz[j]) * (oz[i] - oz[j])) / 100D);

        }

        projf /= 3F;
    }

    public void d(int i, int j, int k, int l, int i1, int j1, 
            int k1, bool flag, bool flag1)
    {
        var ai = new int[n];
        var ai1 = new int[n];
        var ai2 = new int[n];
        for(var l1 = 0; l1 < n; l1++)
        {
            ai[l1] = ox[l1] + i;
            ai2[l1] = oy[l1] + j;
            ai1[l1] = oz[l1] + k;
        }

        if(wx != 0)
            rot(ai, ai1, wx + i, wz + k, k1, n);
        rot(ai, ai2, i, j, i1, n);
        rot(ai2, ai1, j, k, j1, n);
        rot(ai, ai1, i, k, l, n);
        if(i1 != 0 || j1 != 0 || l != 0)
        {
            projf = 1.0F;
            for(var i2 = 0; i2 < 3; i2++)
            {
                for(var j2 = 0; j2 < 3; j2++)
                    if(j2 != i2)
                        projf *= (float)(Math.Sqrt((ai[i2] - ai[j2]) * (ai[i2] - ai[j2]) + (ai1[i2] - ai1[j2]) * (ai1[i2] - ai1[j2])) / 100D);

            }

            projf /= 3F;
        }
        rot(ai, ai1, m.cx, m.cz, m.xz, n);
        var flag2 = false;
        var ai3 = new int[n];
        var ai4 = new int[n];
        var k2 = 500;
        for(var l2 = 0; l2 < n; l2++)
        {
            ai3[l2] = xs(ai[l2], ai1[l2]);
            ai4[l2] = ys(ai2[l2], ai1[l2]);
        }

        var i3 = 0;
        var j3 = 1;
        for(var k3 = 0; k3 < n; k3++)
        {
            for(var j4 = 0; j4 < n; j4++)
                if(k3 != j4 && Math.Abs(ai3[k3] - ai3[j4]) - Math.Abs(ai4[k3] - ai4[j4]) < k2)
                {
                    j3 = k3;
                    i3 = j4;
                    k2 = Math.Abs(ai3[k3] - ai3[j4]) - Math.Abs(ai4[k3] - ai4[j4]);
                }

        }

        if(ai4[i3] < ai4[j3])
        {
            var l3 = i3;
            i3 = j3;
            j3 = l3;
        }
        if(spy(ai[i3], ai1[i3]) > spy(ai[j3], ai1[j3]))
        {
            flag2 = true;
            var i4 = 0;
            for(var k4 = 0; k4 < n; k4++)
                if(ai1[k4] < 50 && ai2[k4] > m.cy)
                    flag2 = false;
                else
                if(ai2[k4] == ai2[0])
                    i4++;

            if(i4 == n && ai2[0] > m.cy)
                flag2 = false;
        }
        rot(ai2, ai1, m.cy, m.cz, m.zy, n);
        var flag3 = true;
        var flag4 = false;
        var ai5 = new int[n];
        var ai6 = new int[n];
        var l4 = 0;
        var i5 = 0;
        var j5 = 0;
        var k5 = 0;
        var flag5 = false;
        for(var l5 = 0; l5 < n; l5++)
        {
            ai5[l5] = xs(ai[l5], ai1[l5]);
            ai6[l5] = ys(ai2[l5], ai1[l5]);
            if(ai6[l5] < 0 || ai1[l5] < 10)
                l4++;
            if(ai6[l5] > m.h || ai1[l5] < 10)
                i5++;
            if(ai5[l5] < 0 || ai1[l5] < 10)
                j5++;
            if(ai5[l5] > m.w || ai1[l5] < 10)
                k5++;
        }

        if(j5 == n || l4 == n || i5 == n || k5 == n)
        {
            flag3 = false;
            flag4 = true;
        }
        if(flag3)
        {
            if(imlast)
            {
                for(var i6 = 0; i6 < 3; i6++)
                {
                    m.lxp[i6] = ai5[i6];
                    m.lyp[i6] = ai6[i6];
                }

            }
            var j6 = 1;
            byte byte0 = 1;
            byte byte1 = 1;
            if(Math.Abs(ai6[0] - ai6[1]) > Math.Abs(ai6[2] - ai6[1]))
            {
                byte0 = 0;
                byte1 = 2;
            } else
            {
                byte0 = 2;
                byte1 = 0;
                j6 *= -1;
            }
            if(ai6[1] > ai6[byte0])
                j6 *= -1;
            if(ai5[1] > ai5[byte1])
                j6 *= -1;
            var l6 = gr;
            if(fs != 0)
            {
                j6 *= fs;
                if(j6 == -1)
                {
                    l6 += 40;
                    if(m.mode == 0)
                        flag3 = false;
                }
            }
            var j7 = 0;
            var l7 = 0;
            var j8 = 0;
            var k8 = 0;
            var l8 = 0;
            var i9 = 0;
            for(var j9 = 0; j9 < n; j9++)
            {
                var l9 = 0;
                var j10 = 0;
                var l10 = 0;
                var i11 = 0;
                var j11 = 0;
                var k11 = 0;
                for(var l11 = 0; l11 < n; l11++)
                {
                    if(ai2[j9] >= ai2[l11])
                        l9++;
                    if(ai2[j9] <= ai2[l11])
                        j10++;
                    if(ai[j9] >= ai[l11])
                        l10++;
                    if(ai[j9] <= ai[l11])
                        i11++;
                    if(ai1[j9] >= ai1[l11])
                        j11++;
                    if(ai1[j9] <= ai1[l11])
                        k11++;
                }

                if(l9 == n)
                    j7 = ai2[j9];
                if(j10 == n)
                    l7 = ai2[j9];
                if(l10 == n)
                    j8 = ai[j9];
                if(i11 == n)
                    k8 = ai[j9];
                if(j11 == n)
                    l8 = ai1[j9];
                if(k11 == n)
                    i9 = ai1[j9];
            }

            var k9 = (j7 + l7) / 2;
            var i10 = (j8 + k8) / 2;
            var k10 = (l8 + i9) / 2;
            av = (int)Math.Sqrt((m.cy - k9) * (m.cy - k9) + (m.cx - i10) * (m.cx - i10) + k10 * k10 + l6 * l6 * l6);
            if(av > m.fade[7] || av == 0)
            {
                flag3 = false;
                flag4 = true;
            }
            if(l6 > 0 && av > 2500)
                flag3 = false;
            if(l6 > 0 && av > 1000)
                flag4 = true;
            if(av > 2000)
                flag4 = true;
        }
        if(flag3)
        {
            var f = (float)(projf / deltaf + 0.5D);
            if(f > 1.0F)
                f = 1.0F;
            if(f < 0.5D || flag2)
                f = 0.5F;
            if(flag4)
                f = (float)(f * 0.90000000000000002D);
            //new Color(c[0], c[1], c[2]);
            
            
            
            
            var color = Colors.GetHSBColor(hsb[0], hsb[1], hsb[2] * f);
            int red = color.R;
            int grn = color.G;
            int blu = color.B;
            for(var i8 = 0; i8 < 8; i8++)
                if(av > m.fade[i8])
                {
                    red = (red * 3 + m.cfade[0]) / 4;
                    grn = (grn * 3 + m.cfade[1]) / 4;
                    blu = (blu * 3 + m.cfade[2]) / 4;
                }

            g.SetColor(new Color(red, grn, blu));
            g.FillPolygon(ai5, ai6, n);
        }
        if(!flag4)
        {
            g.SetColor(new Color(0, 0, 0));
            g.DrawPolygon(ai5, ai6, n);
        }
    }

    public void s(int i, int j, int k, int l, int i1, int j1, 
            bool flag)
    {
        if(gr <= 0 && av < m.fade[7] && av != 0)
        {
            var ai = new int[n];
            var ai1 = new int[n];
            var ai2 = new int[n];
            for(var k1 = 0; k1 < n; k1++)
            {
                ai[k1] = ox[k1] + i;
                ai2[k1] = oy[k1] + j;
                ai1[k1] = oz[k1] + k;
            }

            rot(ai, ai2, i, j, i1, n);
            rot(ai2, ai1, j, k, j1, n);
            rot(ai, ai1, i, k, l, n);
            var l1 = (int)(m.cgrnd[0] / 1.5D);
            var i2 = (int)(m.cgrnd[1] / 1.5D);
            var j2 = (int)(m.cgrnd[2] / 1.5D);
            for(var k2 = 0; k2 < n; k2++)
                ai2[k2] = m.ground;

            for(var l2 = 0; l2 < m.tr.nt; l2++)
                if(m.tr._in[l2])
                {
                    var i3 = 0;
                    for(var j3 = 0; j3 < n; j3++)
                        if(Math.Abs(ai[j3] - m.tr.x[l2]) < m.tr.radx[l2] && Math.Abs(ai1[j3] - m.tr.z[l2]) < m.tr.radz[l2])
                            i3++;

                    if(i3 == n)
                    {
                        for(var k3 = 0; k3 < n; k3++)
                            ai2[k3] = m.tr.y[l2];

                        if(m.tr.xy[l2] != 0)
                        {
                            for(var l3 = 0; l3 < n; l3++)
                            {
                                ai[l3] -= i;
                                ai[l3] = (int)(ai[l3] * (1.0D / Math.Cos(m.tr.xy[l2] * 0.017453292519943295D)));
                                ai[l3] += i;
                            }

                            rot(ai, ai2, m.tr.x[l2], m.tr.y[l2], m.tr.xy[l2], n);
                        }
                        if(m.tr.zy[l2] != 0)
                        {
                            for(var i4 = 0; i4 < n; i4++)
                            {
                                ai1[i4] -= k;
                                ai1[i4] = (int)(ai1[i4] * (1.0D / Math.Cos(m.tr.zy[l2] * 0.017453292519943295D)));
                                ai1[i4] += k;
                            }

                            rot(ai1, ai2, m.tr.z[l2], m.tr.y[l2], m.tr.zy[l2], n);
                        }
                        l1 = (int)(m.tr.c[l2][0] / 1.5D);
                        i2 = (int)(m.tr.c[l2][1] / 1.5D);
                        j2 = (int)(m.tr.c[l2][2] / 1.5D);
                    }
                }

            rot(ai, ai1, m.cx, m.cz, m.xz, n);
            rot(ai2, ai1, m.cy, m.cz, m.zy, n);
            var flag1 = false;
            var ai3 = new int[n];
            var ai4 = new int[n];
            for(var j4 = 0; j4 < n; j4++)
            {
                ai3[j4] = xs(ai[j4], ai1[j4]);
                ai4[j4] = ys(ai2[j4], ai1[j4]);
                if(ai4[j4] > 0 && ai4[j4] < m.h && ai3[j4] > 0 && ai3[j4] < m.w && ai1[j4] > 10)
                    flag1 = true;
            }

            if(flag1)
            {
                for(var k4 = 0; k4 < 8; k4++)
                    if(av > m.fade[k4])
                    {
                        l1 = (l1 * 3 + m.cfade[0]) / 4;
                        i2 = (i2 * 3 + m.cfade[1]) / 4;
                        j2 = (j2 * 3 + m.cfade[2]) / 4;
                    }

                g.SetColor(new Color(l1, i2, j2));
                g.FillPolygon(ai3, ai4, n);
            }
        }
    }

    public int xs(int i, int j)
    {
        if(j < 10)
            j = 10;
        return ((j - m.focus_point) * (m.cx - i)) / j + i;
    }

    public int ys(int i, int j)
    {
        if(j < 10)
            j = 10;
        return ((j - m.focus_point) * (m.cy - i)) / j + i;
    }

    public void rot(int[] ai, int[] ai1, int i, int j, int k, int l)
    {
        if(k != 0)
        {
            for(var i1 = 0; i1 < l; i1++)
            {
                var j1 = ai[i1];
                var k1 = ai1[i1];
                ai[i1] = i + (int)((j1 - i) * Math.Cos(k * 0.017453292519943295D) - (k1 - j) * Math.Sin(k * 0.017453292519943295D));
                ai1[i1] = j + (int)((j1 - i) * Math.Sin(k * 0.017453292519943295D) + (k1 - j) * Math.Cos(k * 0.017453292519943295D));
            }

        }
    }

    public int spy(int i, int j)
    {
        return (int)Math.Sqrt((i - m.cx) * (i - m.cx) + j * j);
    }

        public Plane this[int npl]
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
    }
}