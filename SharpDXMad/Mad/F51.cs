using SharpDX;
using boolean = System.Boolean;
using g = MadGame.G;
using rd = MadGame.G;

namespace MadGame
{
    public class F51
    {
        internal ContO o;
        internal bool right;
        internal bool left;
        internal bool up;
        internal bool down;
        internal bool forward;
        internal bool back;
        internal bool rotl;
        internal bool rotr;
        internal bool plus;
        internal bool minus;
        internal bool _in;
        internal bool _out;
        internal bool show3;
        internal static bool trans;
        internal Medium medium;


        public F51()
        {
            show3 = false;
            right = false;
            left = false;
            up = false;
            down = false;
            forward = false;
            back = false;
            rotl = false;
            rotr = false;
            plus = false;
            minus = false;
        }

        /*public boolean keyDown(Event event, int i)
        {
            if(i == 56)
                forward = true;
            if(i == 50)
                back = true;
            if(i == 119)
                if(o.wire)
                    o.wire = false;
                else
                    o.wire = true;
            if(i == 54)
                rotr = true;
            if(i == 52)
                rotl = true;
            if(i == 43)
                plus = true;
            if(i == 45)
                minus = true;
            if(i == 42)
                in = true;
            if(i == 47)
                out = true;
            if(i == 1006)
                left = true;
            if(i == 1007)
                right = true;
            if(i == 1005)
                down = true;
            if(i == 1004)
                up = true;
            if(i == 86 || i == 111)
                trans = !trans;
            return false;
        }
    
        public boolean keyUp(Event event, int i)
        {
            if(i == 56)
                forward = false;
            if(i == 50)
                back = false;
            if(i == 54)
                rotr = false;
            if(i == 52)
                rotl = false;
            if(i == 43)
                plus = false;
            if(i == 45)
                minus = false;
            if(i == 42)
                in = false;
            if(i == 47)
                out = false;
            if(i == 1006)
                left = false;
            if(i == 1007)
                right = false;
            if(i == 1005)
                down = false;
            if(i == 1004)
                up = false;
            return false;
        }
    */

//    public void paint()
//    {
//        g.drawImage(offImage, 0, 0, this);
//    }

        public void remake()
        {
            medium = new Medium();
            o = new ContO("o", medium, 350, 150, 600, this);
            o.y = 120;
            o.z += 200;
            medium.y -= 300;
            medium.zy += 10;
        }

        public void run()
        {
            medium = new Medium();
            o = new ContO("o", medium, 350, 150, 600, this);
            o.y = 120;
            o.z += 200;
            medium.y -= 300;
            medium.zy += 10;
        }

        public void wtrue()
        {
            medium.d();
            o.d();
            if (show3)
                medium.d3p();
            if (forward)
                o.wxz += 5;
            if (back)
                o.wxz -= 5;
            if (rotr)
                o.xz -= 5;
            if (rotl)
                o.xz += 5;
            if (left)
                o.xy -= 5;
            if (right)
                o.xy += 5;
            if (up)
                o.zy -= 5;
            if (down)
                o.zy += 5;
            if (plus)
                o.y += 5;
            if (minus)
                o.y -= 5;
            if (_in)
                o.z += 10;
            if (_out)
                o.z -= 10;
            rd.SetColor(new Color(0, 0, 0));
        }

        public void switchmode()
        {
            medium.mode = medium.mode == 0 ? 1 : 0;
        }

        public void showthree()
        {
            show3 = !show3;
        }

//
//    public void start()
//    {
//        if(gamer == null)
//            gamer = new Thread(this);
//        gamer.start();
//    }
//
//    public void stop()
//    {
//        if(gamer != null)
//            gamer.stop();
//        gamer = null;
//    }
//
//    public void update(Graphics g)
//    {
//        paint(g);
//    }
    }
}