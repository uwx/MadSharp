
using System;
using System.IO;
using System.Text;
using boolean = System.Boolean;
using g = MadGame.G;
using rd = MadGame.G;

namespace MadGame
{
    public class ContO
    {
        

        internal Medium m;
        internal Plane[] p;
        internal int npl;
        internal int x;
        internal int y;
        internal int z;
        internal int xz;
        internal int xy;
        internal int zy;
        internal int wxz;
        internal int dist;
        internal int maxR;
        internal int disp;
        internal boolean shadow;
        internal boolean loom;
        internal int grounded;
        internal boolean colides;
        internal int rcol;
        internal int pcol;
        internal int track;
        internal boolean _out;
        internal int nhits;
        internal int maxhits;
        internal int grat;
        internal boolean wire;
        
    public ContO(String s, Medium medium, int i, int j, int k, F51 applet)
    {
        npl = 0;
        x = 0;
        y = 0;
        z = 0;
        xz = 0;
        xy = 0;
        zy = 0;
        wxz = 0;
        dist = 0;
        maxR = 0;
        disp = 0;
        shadow = false;
        loom = false;
        grounded = 1;
        colides = false;
        rcol = 0;
        pcol = 0;
        track = -2;
        _out = false;
        nhits = 0;
        maxhits = -1;
        grat = 0;
        wire = false;
        m = medium;
        p = new Plane[0x186a0];
        x = i;
        y = j;
        z = k;
        boolean flag = false;
        int l = 0;
        float f = 1.0F;
        int[] ai = new int[350];
        int[] ai1 = new int[350];
        int[] ai2 = new int[350];
        int[] ai3 = new int[3];
        boolean flag1 = false;
        Wheels wheels = new Wheels();
        int i1 = 1;
        int j1 = 0;
    
        var reader = File.ReadAllLines("o.rad");
        foreach (var s1 in reader)
        {
            String s2 = s1.Trim();
            if(s2.StartsWith("<p>"))
            {
                flag = true;
                l = 0;
                i1 = 0;
                j1 = 0;
            }
            if(flag)
            {
                if(s2.StartsWith("gr"))
                    i1 = getvalue("gr", s2, 0);
                if(s2.StartsWith("fs"))
                    j1 = getvalue("fs", s2, 0);
                if(s2.StartsWith("glass"))
                    flag1 = true;
                if(s2.StartsWith("c"))
                {
                    if(flag1)
                        flag1 = false;
                    ai3[0] = getvalue("c", s2, 0);
                    ai3[1] = getvalue("c", s2, 1);
                    ai3[2] = getvalue("c", s2, 2);
                }
                if(s2.StartsWith("p"))
                {
                    ai[l] = (int)((float)getvalue("p", s2, 0) * f);
                    ai1[l] = (int)((float)getvalue("p", s2, 1) * f);
                    ai2[l] = (int)((float)getvalue("p", s2, 2) * f);
                    l++;
                }
            }
            if(s2.StartsWith("</p>"))
            {
                p[npl] = new Plane(m, ai, ai2, ai1, l, ai3, flag1, i1, j1, 0, 0);
                npl++;
                flag = false;
            }
            if(s2.StartsWith("w"))
                npl += wheels.make(applet, m, p, npl, (int)((float)getvalue("w", s2, 0) * f), (int)((float)getvalue("w", s2, 1) * f), (int)((float)getvalue("w", s2, 2) * f), getvalue("w", s2, 3), (int)((float)getvalue("w", s2, 4) * f), (int)((float)getvalue("w", s2, 5) * f), (int)((float)getvalue("w", s2, 6) * f));
            if(s2.StartsWith("<track>"))
                track = -1;
            if(track == -1)
            {
                if(s2.StartsWith("c"))
                {
                    m.tr.c[m.tr.nt][0] = getvalue("c", s2, 0);
                    m.tr.c[m.tr.nt][1] = getvalue("c", s2, 1);
                    m.tr.c[m.tr.nt][2] = getvalue("c", s2, 2);
                }
                if(s2.StartsWith("xy"))
                    m.tr.xy[m.tr.nt] = getvalue("xy", s2, 0);
                if(s2.StartsWith("zy"))
                    m.tr.zy[m.tr.nt] = getvalue("zy", s2, 0);
                if(s2.StartsWith("radx"))
                    m.tr.radx[m.tr.nt] = (int)((float)getvalue("radx", s2, 0) * f);
                if(s2.StartsWith("radz"))
                    m.tr.radz[m.tr.nt] = (int)((float)getvalue("radz", s2, 0) * f);
            }
            if(s2.StartsWith("</track>"))
            {
                track = m.tr.nt;
                m.tr.nt++;
            }
            if(s2.StartsWith("MaxRadius"))
                maxR = (int)((float)getvalue("MaxRadius", s2, 0) * f);
            if(s2.StartsWith("disp"))
                disp = getvalue("disp", s2, 0);
            if(s2.StartsWith("shadow"))
                shadow = true;
            if(s2.StartsWith("loom"))
                loom = true;
            if(s2.StartsWith("out"))
                _out = true;
            if(s2.StartsWith("hits"))
                maxhits = getvalue("hits", s2, 0);
            if(s2.StartsWith("colid"))
            {
                colides = true;
                rcol = getvalue("colid", s2, 0);
                pcol = getvalue("colid", s2, 1);
            }
            if(s2.StartsWith("grounded"))
                grounded = getvalue("grounded", s2, 0);
            if(s2.StartsWith("div"))
                f = (float)getvalue("div", s2, 0) / 10F;
        }
        
        Console.WriteLine("polygantos: " + npl);
        grat = wheels.ground;

        if (npl <= 0)
        {
            throw new Exception("NO LOAD!");
        }
        p[npl - 1].imlast = true;
    }

    public ContO(Medium medium, ContO conto, int i, int j, int k)
    {
        npl = 0;
        x = 0;
        y = 0;
        z = 0;
        xz = 0;
        xy = 0;
        zy = 0;
        wxz = 0;
        dist = 0;
        maxR = 0;
        disp = 0;
        shadow = false;
        loom = false;
        grounded = 1;
        colides = false;
        rcol = 0;
        pcol = 0;
        track = -2;
        _out = false;
        nhits = 0;
        maxhits = -1;
        grat = 0;
        wire = false;
        m = medium;
        npl = conto.npl;
        maxR = conto.maxR;
        disp = conto.disp;
        loom = conto.loom;
        colides = conto.colides;
        maxhits = conto.maxhits;
        _out = conto._out;
        rcol = conto.rcol;
        pcol = conto.pcol;
        shadow = conto.shadow;
        grounded = conto.grounded;
        p = new Plane[conto.npl];
        x = i;
        y = j;
        z = k;
        for(int l = 0; l < npl; l++)
            p[l] = new Plane(m, conto.p[l].ox, conto.p[l].oz, conto.p[l].oy, conto.p[l].n, conto.p[l].c, conto.p[l].glass, conto.p[l].gr, conto.p[l].fs, conto.p[l].wx, conto.p[l].wz);

    }

    public void d()
    {
        if(dist != 0)
        {
            dist = 0;
            if(track != -2)
                m.tr._in[track] = false;
        }
        if(!_out)
        {
            int i = m.cx + (int)((double)(x - m.x - m.cx) * Math.Cos((double)m.xz * 0.017453292519943295D) - (double)(z - m.z - m.cz) * Math.Sin((double)m.xz * 0.017453292519943295D));
            int j = m.cz + (int)((double)(x - m.x - m.cx) * Math.Sin((double)m.xz * 0.017453292519943295D) + (double)(z - m.z - m.cz) * Math.Cos((double)m.xz * 0.017453292519943295D));
            int k = m.cz + (int)((double)(y - m.y - m.cy) * Math.Sin((double)m.zy * 0.017453292519943295D) + (double)(j - m.cz) * Math.Cos((double)m.zy * 0.017453292519943295D));
            if(xs(i + maxR, k) > 0 && xs(i - maxR, k) < m.w && k > -maxR && k < m.fade[7] && xs(i + maxR, k) - xs(i - maxR, k) > disp)
            {
                if(shadow)
                {
                    int l = m.cy + (int)((double)(m.ground - m.cy) * Math.Cos((double)m.zy * 0.017453292519943295D) - (double)(j - m.cz) * Math.Sin((double)m.zy * 0.017453292519943295D));
                    int j1 = m.cz + (int)((double)(m.ground - m.cy) * Math.Sin((double)m.zy * 0.017453292519943295D) + (double)(j - m.cz) * Math.Cos((double)m.zy * 0.017453292519943295D));
                    if(ys(l + maxR, j1) > 0 && ys(l - maxR, j1) < m.h)
                    {
                        for(int k1 = 0; k1 < npl; k1++)
                            p[k1].s(x - m.x, y - m.y, z - m.z, xz, xy, zy, loom);

                    }
                }
                int i1 = m.cy + (int)((double)(y - m.y - m.cy) * Math.Cos((double)m.zy * 0.017453292519943295D) - (double)(j - m.cz) * Math.Sin((double)m.zy * 0.017453292519943295D));
                if(ys(i1 + maxR, k) > 0 && ys(i1 - maxR, k) < m.h)
                {
                    int[] ai = new int[npl];
                    for(int l1 = 0; l1 < npl; l1++)
                    {
                        ai[l1] = 0;
                        for(int j2 = 0; j2 < npl; j2++)
                            if(p[l1].av != p[j2].av)
                            {
                                if(p[l1].av < p[j2].av)
                                    ai[l1]++;
                            } else
                            if(l1 > j2)
                                ai[l1]++;

                    }

                    for(int i2 = 0; i2 < npl; i2++)
                    {
                        for(int k2 = 0; k2 < npl; k2++)
                            if(ai[k2] == i2)
                            {
                                p[k2].d(x - m.x, y - m.y, z - m.z, xz, xy, zy, wxz, wire, loom);
                            }

                    }

                    dist = (int)Math.Sqrt((int)Math.Sqrt(((m.x + m.cx) - x) * ((m.x + m.cx) - x) + (m.z - z) * (m.z - z) + ((m.y + m.cy) - y) * ((m.y + m.cy) - y))) * grounded;
                }
            }
        }
        if(dist != 0 && track != -2)
        {
            m.tr._in[track] = true;
            m.tr.x[track] = x - m.x;
            m.tr.y[track] = y - m.y;
            m.tr.z[track] = z - m.z;
        }
    }

    public void reset()
    {
        nhits = 0;
        xz = 0;
        xy = 0;
        zy = 0;
    }

    public void loadrots(boolean flag)
    {
        if(!flag)
            reset();
        for(int i = 0; i < npl; i++)
        {
            p[i].rot(p[i].ox, p[i].oy, 0, 0, xy, p[i].n);
            p[i].rot(p[i].oy, p[i].oz, 0, 0, zy, p[i].n);
            p[i].rot(p[i].ox, p[i].oz, 0, 0, xz, p[i].n);
            p[i].loadprojf();
        }

        if(flag)
            reset();
    }

    public void tryexp(ContO conto)
    {
        if(!_out)
        {
            int i = getpy(conto.x, conto.y, conto.z);
            if(i < (maxR / 10) * (maxR / 10) + (conto.maxR / 10) * (conto.maxR / 10) && i > 0)
            {
                if(pcol != 0)
                {
                    for(int j = 0; j < npl; j++)
                    {
                        for(int k = 0; k < p[j].n && (conto.x - (x + p[j].ox[k])) * (conto.x - (x + p[j].ox[k])) + (conto.y - (y + p[j].oy[k])) * (conto.y - (y + p[j].oy[k])) + (conto.z - (z + p[j].oz[k])) * (conto.z - (z + p[j].oz[k])) >= ((conto.maxR * 10) / pcol) * ((conto.maxR * 10) / pcol); k++);
                    }

                }
                if(rcol != 0)
                    if(i < (maxR / (10 * rcol)) * (maxR / (10 * rcol)) + (conto.maxR / 10) * (conto.maxR / 10));
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

    public int getvalue(String s, String s1, int i)
    {
        int k = 0;
        String s3 = "";
        for(int j = s.Length + 1; j < s1.Length; j++)
        {
            var s2 = s1[j];
            if(s2 == ',' || s2 == ')')
            {
                k++;
                j++;
            }
            if (k == i)
                s3 += s1[j];
        }

        return int.Parse(s3);
    }

    public int getpy(int i, int j, int k)
    {
        return ((i - x) / 10) * ((i - x) / 10) + ((j - y) / 10) * ((j - y) / 10) + ((k - z) / 10) * ((k - z) / 10);
    }
    }
}