using System;
using SharpDX;

namespace MadGame
{
    public class Medium
    {

        public Medium()
        {
            tr = new Trackers();
            isun = false;
            focus_point = 400;
            ground = 250;
            skyline = -300;
            cx = 350;
            cy = 287;
            cz = 50;
            xz = 0;
            zy = 0;
            x = 0;
            y = 0;
            z = 0;
            w = 700;
            h = 475;
            tart = 0;
            yart = -100;
            zart = 0;
            ztgo = 0;
            mode = 0;
            lxp = new int[3];
            lyp = new int[3];
            td = false;
            vxz = 0;
            adv = -500;
            vert = false;
        }

        public void behinde(ContO conto)
        {
            var i = conto.zy;
            var j = conto.xz;
            for(; i > 360; i -= 360);
            for(; i < 0; i += 360);
            if(i > 90 && i < 270)
            {
                tart += (180 - tart) / 3;
                yart += (100 - yart) / 4;
            } else
            {
                tart -= tart / 3;
                yart += (-100 - yart) / 4;
            }
            j += tart;
            if(i > 90)
                i = 180 - i;
            if(i < -90)
                i = -180 - i;
            var k = conto.y + (int)(((conto.y + yart) - conto.y) * Math.Cos(conto.zy * 0.017453292519943295D) - (conto.z - 600 - conto.z) * Math.Sin(conto.zy * 0.017453292519943295D));
            var l = conto.z + (int)(((conto.y + yart) - conto.y) * Math.Sin(conto.zy * 0.017453292519943295D) + (conto.z - 600 - conto.z) * Math.Cos(conto.zy * 0.017453292519943295D));
            var i1 = conto.x + (int)(-(l - conto.z) * Math.Sin(conto.xz * 0.017453292519943295D));
            var j1 = conto.z + (int)((l - conto.z) * Math.Cos(conto.xz * 0.017453292519943295D));
            zy = -i;
            xz = -j;
            x += (i1 - cx - x) / 3;
            z += (int)((j1 - cz - z) / 1.5D);
            y += (int)((k - cy - y) / 1.5D);
        }

        public void infront(ContO conto)
        {
            var i = conto.zy;
            var j = conto.xz;
            for(; i > 360; i -= 360);
            for(; i < 0; i += 360);
            if(i > 90 && i < 270)
            {
                tart += (180 - tart) / 3;
                yart += (100 - yart) / 3;
            } else
            {
                tart -= tart / 3;
                yart += (-100 - yart) / 3;
            }
            j += tart;
            if(i > 90)
                i = 180 - i;
            if(i < -90)
                i = -180 - i;
            var k = conto.y + (int)(((conto.y + yart) - conto.y) * Math.Cos(conto.zy * 0.017453292519943295D) - ((conto.z + 800) - conto.z) * Math.Sin(conto.zy * 0.017453292519943295D));
            var l = conto.z + (int)(((conto.y + yart) - conto.y) * Math.Sin(conto.zy * 0.017453292519943295D) + ((conto.z + 800) - conto.z) * Math.Cos(conto.zy * 0.017453292519943295D));
            var i1 = conto.x + (int)(-(l - conto.z) * Math.Sin(conto.xz * 0.017453292519943295D));
            var j1 = conto.z + (int)((l - conto.z) * Math.Cos(conto.xz * 0.017453292519943295D));
            zy = i;
            xz = -(j + 180);
            x += (i1 - cx - x) / 3;
            z += (int)((j1 - cz - z) / 1.5D);
            y += (int)((k - cy - y) / 1.5D);
        }

        public void left(ContO conto)
        {
            var i = conto.y;
            var j = conto.x + (int)(((conto.x + 600) - conto.x) * Math.Cos(conto.xz * 0.017453292519943295D));
            var k = conto.z + (int)(((conto.x + 600) - conto.x) * Math.Sin(conto.xz * 0.017453292519943295D));
            zy = 0;
            xz = -(conto.xz + 90);
            x += (int)((j - cx - x) / 1.5D);
            z += (int)((k - cz - z) / 1.5D);
            y += (int)((i - cy - y) / 1.5D);
        }

        public void right(ContO conto)
        {
            var i = conto.y;
            var j = conto.x + (int)((conto.x - 600 - conto.x) * Math.Cos(conto.xz * 0.017453292519943295D));
            var k = conto.z + (int)((conto.x - 600 - conto.x) * Math.Sin(conto.xz * 0.017453292519943295D));
            zy = 0;
            xz = -(conto.xz - 90);
            x += (j - cx - x) / 3;
            z += (int)((k - cz - z) / 1.5D);
            y += (int)((i - cy - y) / 1.5D);
        }

        public void watch(ContO conto)
        {
            if(!td)
            {
                y = conto.y + (int)((conto.y - 300 - conto.y) * Math.Cos(conto.zy * 0.017453292519943295D) - ((conto.z + 3000) - conto.z) * Math.Sin(conto.zy * 0.017453292519943295D));
                var i = conto.z + (int)((conto.y - 300 - conto.y) * Math.Sin(conto.zy * 0.017453292519943295D) + ((conto.z + 3000) - conto.z) * Math.Cos(conto.zy * 0.017453292519943295D));
                x = conto.x + (int)(((conto.x + 400) - conto.x) * Math.Cos(conto.xz * 0.017453292519943295D) - (i - conto.z) * Math.Sin(conto.xz * 0.017453292519943295D));
                z = conto.z + (int)(((conto.x + 400) - conto.x) * Math.Sin(conto.xz * 0.017453292519943295D) + (i - conto.z) * Math.Cos(conto.xz * 0.017453292519943295D));
                td = true;
            }
            var c = '\0';
            if(conto.x - x - cx > 0)
                c = (char) 180;
            var j = -(int)(90 + c + Math.Atan((conto.z - z) / (double)(conto.x - x - cx)) / 0.017453292519943295D);
            c = '\0';
            if(conto.y - y - cy < 0)
                c = '\uFF4C';
            var k = (int)Math.Sqrt((conto.z - z) * (conto.z - z) + (conto.x - x - cx) * (conto.x - x - cx));
            var l = (int)(90 + c - Math.Atan(k / (double)(conto.y - y - cy)) / 0.017453292519943295D);
            xz = j;
            zy += (l - zy) / 5;
            if((int)Math.Sqrt((conto.z - z) * (conto.z - z) + (conto.x - x - cx) * (conto.x - x - cx) + (conto.y - y - cy) * (conto.y - y - cy)) > 3500)
                td = false;
        }

        public void around(ContO conto, int i)
        {
            byte byte0 = 1;
            if(i == 6000)
                byte0 = 2;
            y = conto.y + adv;
            x = conto.x + (int)((((conto.x - i) + adv * byte0) - conto.x) * Math.Cos(vxz * 0.017453292519943295D));
            z = conto.z + (int)((((conto.x - i) + adv * byte0) - conto.x) * Math.Sin(vxz * 0.017453292519943295D));
            if(i == 6000)
            {
                if(!vert)
                    adv -= 10;
                else
                    adv += 10;
                if(adv < -900)
                    vert = true;
                if(adv > 1200)
                    vert = false;
            } else
            {
                if(!vert)
                    adv -= 2;
                else
                    adv += 2;
                if(adv < -500)
                    vert = true;
                if(adv > 150)
                    vert = false;
                if(adv > 300)
                    adv = 300;
            }
            vxz += 2;
            if(vxz > 360)
                vxz -= 360;
            var c = '\0';
            var j = y;
            if(j > 0)
                j = 0;
            if(conto.y - j - cy < 0)
                c = '\uFF4C';
            var k = (int)Math.Sqrt((conto.z - z) * (conto.z - z) + (conto.x - x - cx) * (conto.x - x - cx));
            var l = (int)(90 + c - Math.Atan(k / (double)(conto.y - j - cy)) / 0.017453292519943295D);
            xz = -vxz + 90;
            zy += (l - zy) / 10;
        }

        public void d3p()
        {

        }

        public void d()
        {
            if(zy > 90)
                zy = 90;
            if(zy < -90)
                zy = -90;
            if(y > 0)
                y = 0;
            ground = 250 - y;
            var ai = new int[4];
            var ai1 = new int[4];
            var i = cgrnd[0];
            var j = cgrnd[1];
            var k = cgrnd[2];
            var l = h;
            for(var i1 = 0; i1 < 8; i1++)
            {
                var k1 = fade[i1];
                var i2 = ground;
                if(zy != 0)
                {
                    i2 = cy + (int)((ground - cy) * Math.Cos(zy * 0.017453292519943295D) - (fade[i1] - cz) * Math.Sin(zy * 0.017453292519943295D));
                    k1 = cz + (int)((ground - cy) * Math.Sin(zy * 0.017453292519943295D) + (fade[i1] - cz) * Math.Cos(zy * 0.017453292519943295D));
                }
                ai[0] = 0;
                ai1[0] = ys(i2, k1);
                if(ai1[0] < 0)
                    ai1[0] = 0;
                ai[1] = 0;
                ai1[1] = l;
                ai[2] = w;
                ai1[2] = l;
                ai[3] = w;
                ai1[3] = ai1[0];
                l = ai1[0];
                if(i1 > 0)
                {
                    i = (i * 3 + cfade[0]) / 4;
                    j = (j * 3 + cfade[1]) / 4;
                    k = (k * 3 + cfade[2]) / 4;
                }
                if(ai1[0] < h && ai1[1] > 0)
                {
                    G.SetColor(new Color(i, j, k));
                    G.FillPolygon(ai, ai1, 4);
                }
            }

            i = csky[0];
            j = csky[1];
            k = csky[2];
            var j1 = 0;
            for(var l1 = 0; l1 < 8; l1++)
            {
                var j2 = fade[l1];
                var k2 = skyline;
                if(zy != 0)
                {
                    k2 = cy + (int)((skyline - cy) * Math.Cos(zy * 0.017453292519943295D) - (fade[l1] - cz) * Math.Sin(zy * 0.017453292519943295D));
                    j2 = cz + (int)((skyline - cy) * Math.Sin(zy * 0.017453292519943295D) + (fade[l1] - cz) * Math.Cos(zy * 0.017453292519943295D));
                }
                ai[0] = 0;
                ai1[0] = ys(k2, j2);
                if(ai1[0] > h)
                    ai1[0] = h;
                ai[1] = 0;
                ai1[1] = j1;
                ai[2] = w;
                ai1[2] = j1;
                ai[3] = w;
                ai1[3] = ai1[0];
                j1 = ai1[0];
                if(l1 > 0)
                {
                    i = (i * 3 + cfade[0]) / 4;
                    j = (j * 3 + cfade[1]) / 4;
                    k = (k * 3 + cfade[2]) / 4;
                }
                if(ai1[0] > 0 && ai1[1] < h)
                {
                    G.SetColor(new Color(i, j, k));
                    G.FillPolygon(ai, ai1, 4);
                }
            }

            ai[0] = 0;
            ai1[0] = j1;
            ai[1] = 0;
            ai1[1] = l;
            ai[2] = w;
            ai1[2] = l;
            ai[3] = w;
            ai1[3] = j1;
            if(ai1[0] < h && ai1[1] > 0)
            {
                G.SetColor(new Color(cfade[0], cfade[1], cfade[2]));
                G.FillPolygon(ai, ai1, 4);
            }
        }

        public int ys(int i, int j)
        {
            if(j < 10)
                j = 10;
            return ((j - focus_point) * (cy - i)) / j + i;
        }

        internal Trackers tr;
        internal bool isun;
        internal int focus_point;
        internal int ground;
        internal int skyline;
        internal int[] csky = {
            145, 200, 255
        };
        internal int[] cgrnd = {
            180, 180, 180
        };
        internal int[] cfade = {
            255, 255, 255
        };
        internal int[] fade = {
            3000, 5000, 7000, 9000, 11000, 13000, 15000, 17000
        };
        internal int[] mom;
        internal int cx;
        internal int cy;
        internal int cz;
        internal int xz;
        internal int zy;
        internal int x;
        internal int y;
        internal int z;
        internal int w;
        internal int h;
        internal int tart;
        internal int yart;
        internal int zart;
        internal int ztgo;
        internal int mode;
        internal int[] lxp;
        internal int[] lyp;
        internal bool td;
        internal int vxz;
        internal int adv;
        internal bool vert;
    }
}