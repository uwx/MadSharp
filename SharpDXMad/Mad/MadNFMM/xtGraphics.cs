using boolean = System.Boolean;
using System;
using MadGame;
using static Cum.xtImages.Images;
using static Cum.xtPart2;

namespace Cum {

class xtGraphics {
    internal static int[] cntwis =   new int[8];
    internal static boolean[] grrd = new boolean[8];
    internal static boolean[] aird = new boolean[8];
    internal static int[] stopcnt =  new int[8];
    internal static int[] bfcrash =  new int[8];
    internal static int[] bfsc1 =    new int[8];
    internal static int[] bfsc2 =    new int[8];
    internal static int[] bfscrape = new int[8];
    internal static int[] bfskid =   new int[8];    
    internal static int[] pwait =    { 7,7,7,7,7,7,7,7 };
    internal static boolean[] pwastd = new boolean[8];
    
    /**
     * Serialization UID
     */
    internal static readonly long serialVersionUID = 1254986552635023147L;
    /**
     * How many stages you have
     */
    internal static readonly int nTracks = 32;
    /**
     * How many cars you have
     */
    internal static readonly int nCars = 16;
    internal static int acexp = 0;

    /**
     * Stunt adjectives
     */
    internal static readonly String[,] adj = {
            {
                    "Cool", "Alright", "Nice"
            }, {
                    "Wicked", "Amazing", "Super"
            }, {
                    "Awesome", "Ripping", "Radical"
            }, {
                    "What the...?", "You're a super star!!!!", "Who are you again...?"
            }, {
                    "surf style", "off the lip", "bounce back"
            }
    };
    /**
     * Used for text flicker effect
     */
    internal static boolean aflk = false;
    internal static readonly SoundClip[] air = new SoundClip[6];
    /**
     * The HSB values of every vehicle ain a race, once for the first color and once for the second
     */
    internal static readonly float[,] allrnp = new float[8,6];
    /**
     * If {@code != -1}, locks the arrow to that car ID.
     */
    internal static int alocked = -1;
    /**
     * Arrow angle
     */
    internal static int ana = 0;
    /**
     * The player car's HSB values, once for the first color and once for the second
     */
    internal static readonly float[] arnp = {
            0.5F, 0.0F, 0.0F, 1.0F, 0.5F, 0.0F
    };
    /**
     * If {@code true}, the arrow ais pointing at cars
     */
    internal static boolean arrace = false;
    internal static String asay = "";
    internal static int auscnt = 45;
    /**
     * Auto-login
     */
    internal static boolean autolog = false;
    /**
     * Temporarily stores player's username
     */
    internal static String backlog = "";
    /**
     * If true, disables some visual effects for Mac OS compatibility
     */
    internal static boolean badmac = false;
    internal static int beststunt = 0;
    internal static float bgf = 0.0F;
    internal static readonly int[] bgmy = {
            0, -400
    };
    internal static boolean bgup = false;
    internal static SoundClip carfixed;
    internal static int cfase = 0;
    internal static SoundClip checkpoint;
    /**
     * Player's clan ain multiplayer games
     */
    internal static String clan = "";
    internal static boolean clanchat = false;
    /**
     * If non-zero, the player ais ain a clan/war game (racing or wasting)
     */
    internal static int clangame = 0;
    internal static String clankey = "";
    /**
     * Current amount of cleared checkpoints
     */
    internal static int clear = 0;
    internal static readonly String[,] cnames = {
            {
                    "", "", "", "", "", "", "Game Chat  "
            }, {
                    "", "", "", "", "", "", "Your Clan's Chat  "
            }
    };
    internal static int cntan = 0;
    internal static readonly int[] cntchatp = {
            0, 0
    };
    internal static int cntflock = 0;
    internal static int cntovn = 0;
    internal static readonly int cntptrys = 5;
    internal static readonly SoundClip[] crash = new SoundClip[3];
    internal static boolean crashup = false;
    internal static int crshturn = 0;
    internal static readonly int[] dcrashes = {
            0, 0, 0, 0, 0, 0, 0, 0
    };
    /**
     * The player's ping, ain Dominion, Ghostrider and Avenger
     */
    static readonly int[] delays = {
            600, 600, 600
    };
    internal static readonly int[] dested = {
            0, 0, 0, 0, 0, 0, 0, 0
    };
    internal static int discon = 0;
    internal static int dmcnt = 0;
    internal static boolean dmflk = false;
    /**
     * Amount of KB downloaded (loading screen)
     */
    internal static int dnload = 0;
    internal static readonly int dropf = 0;
    internal static int dskflg = 0;
    internal static int dudo = 0;
    internal static int duds = 0;
    internal static readonly SoundClip[] dustskid = new SoundClip[3];
    internal static readonly SoundClip[,] engs = new SoundClip[5,5];
    internal static int exitm = 0;
    /**
     * Exclamation marks for stunts
     */
    internal static readonly String[] exlm = {
            "!", "!!", "!!!"
    };
    internal static int fase = 1111;
    internal static int fastestlap = 0;
    internal static SoundClip firewasted;
    internal static boolean firstime = true;
    internal static int flang = 0;
    internal static int flatr = 0;
    internal static int flatrstart = 0;
    internal static int[] flexpix = null;
    internal static int flipo = 0;
    internal static boolean flk = false;
    internal static int flkat = 0;
    internal static readonly int[] floater = {
            0, 0
    };
    internal static int flyr = 0;
    internal static int flyrdest = 0;
    internal static int forstart = 0;
    internal static FontMetrics ftm;
    internal static String gaclan = "";
    internal static int gameport = 7001;
    internal static int gatey = 300;
    internal static int gmode = 0;
    internal static SoundClip go;
    internal static int gocnt = 0;
    internal static boolean gotlog = false;
    internal static int gxdu = 0;
    internal static int gydu = 0;
    internal static int holdcnt = 0;
    internal static boolean holdit = false;
    internal static int hours = 8;
    internal static int im = 0;
    internal static RadicalMusic intertrack;
    internal static readonly boolean[] isbot = new boolean[8];
    internal static boolean justwon1 = false;
    internal static boolean justwon2 = false;
    internal static int kbload = 0;
    internal static int lalocked = -1;
    internal static boolean lan = false;
    internal static int laps = 0;
    internal static int laptime = 0;
    internal static int lcarx = 0;
    internal static int lcarz = 0;
    internal static readonly String[] lcmsg = {
            "", ""
    };
    internal static int lcn = 0;
    internal static int lfrom = 0;
    internal static int lmode = 0;
    internal static boolean loadedt = false;
    internal static String localserver = "";
    internal static int lockcnt = 0;
    internal static boolean logged = false;
    internal static String loop = "";
    internal static int looped = 1;
    internal static readonly SoundClip[] lowcrash = new SoundClip[3];
    internal static int lsc = -1;
    internal static int lxm = -10;
    internal static int lym = -10;
    /**
     * Max car select selected car (don't change)
     */
    internal static int maxsl = nCars - 1;
    internal static int minsl = 0;
    internal static int mouson = -1;
    internal static readonly int[] movepos = {
            0, 0
    };
    internal static int movly = 0;
    internal static readonly int[] msgflk = {
            0, 0
    };
    internal static boolean mtop = false;
    internal static int muhi = 0;
    internal static int multion = 0;
    internal static boolean mutem = false;
    internal static boolean mutes = false;
    internal static int ndisco = 0;
    internal static boolean newparts = false;
    internal static int nextc = 0;
    internal static int nfmtab = 0;
    internal static int nfreeplays = 0;
    internal static String nickey = "";
    internal static String nickname = "";
    internal static boolean nofull = false;
    internal static int nplayers = 7;
    internal static int oldfase = 0;
    internal static SoundClip one;
    internal static int onjoin = -1;
    internal static boolean onlock = false;
    internal static int onmsc = -1;
    internal static int ontyp = 0;
    internal static int opselect = 0;
    internal static int osc = 10;
    internal static readonly int[] ovh = {
            0, 0, 0, 0
    };
    internal static readonly int[] ovsx = {
            0, 0, 0, 0
    };
    internal static readonly int[] ovw = {
            0, 0, 0, 0
    };
    internal static readonly int[] ovx = {
            0, 0, 0, 0
    };
    internal static readonly int[] ovy = {
            0, 0, 0, 0
    };
    internal static int pback = 0;
    internal static readonly String[] pclan = {
            "", "", "", "", "", "", "", ""
    };
    internal static int pcontin = 0;
    internal static readonly boolean[] pengs = new boolean[5];
    internal static readonly int[] pgady = {
            0, 0, 0, 0, 0, 0, 0, 0, 0
    };
    internal static readonly boolean[] pgas = {
            false, false, false, false, false, false, false, false, false
    };
    internal static readonly int[] pgatx = {
            211, 240, 280, 332, 399, 466, 517, 558, 586
    };
    internal static readonly int[] pgaty = {
            193, 213, 226, 237, 244, 239, 228, 214, 196
    };
    internal static int pin = 60;
    internal static int playingame = -1;
    internal static readonly String[] plnames = {
            "", "", "", "", "", "", "", ""
    };
    internal static int pnext = 0;
    internal static readonly int[] pointc = {
            6, 6
    };
    internal static int posit = 0;
    internal static SoundClip powerup;
    internal static int pstar = 0;
    
    internal static int pwcnt = 0;
    internal static boolean pwflk = false;
    internal static int radpx = 212;
    internal static int ransay = 0;
    internal static boolean remi = false;
    internal static int removeds = 0;
    internal static int runtyp = 0;
    internal static String say = "";
    internal static readonly int[] sc = {
            0, 0, 0, 0, 0, 0, 0, 0
    };
    internal static int scm = 0;
    internal static readonly SoundClip[] scrape = new SoundClip[4];
    internal static int sendstat = 0;
    internal static readonly String[,] sentn = {
            {
                    "", "", "", "", "", "", ""
            }, {
                    "", "", "", "", "", "", ""
            }
    };
    internal static String server = "multiplayer.needformadness.com";
    internal static String servername = "Madness";
    internal static int servport = 7071;
    internal static boolean shaded = false;
    internal static float shload = 0.0F;
    internal static boolean showtf = false;
    internal static int skflg = 0;
    internal static readonly SoundClip[] skid = new SoundClip[3];
    internal static boolean skidup = false;
    internal static readonly int[] smokey = new int[94132];
    /**
     * Stage sound size (completely cosmetic)
     */
    internal static readonly int[] sndsize = {
            39, 128, 23, 58, 106, 140, 81, 135, 38, 141, 106, 76, 56, 116, 92, 208, 70, 80, 152, 102, 27, 65, 52, 30,
            151, 129, 80, 44, 57, 123, 202, 210, 111
    };
    internal static String spin = "";
    internal static int starcnt = 0;
    /**
     * Current stage soundtrack;
     */
    internal static RadicalMusic strack;
    internal static int sturn0 = 0;
    internal static int sturn1 = 0;
    internal static int tcnt = 30;
    /**
     * If non-zero, the player ais test driving a car or stage
     */
    internal static int testdrive = 0;
    /**
     * Text flicker effect
     */
    internal static boolean tflk = false;
    internal static SoundClip three;
    internal static SoundClip tires;
    internal static int trkl = 0;
    internal static int trklim = (int) (HansenRandom.Double() * 40.0);
    /**
     * X positions of the stage select backgrounds (there are two)
     */
    internal static readonly int[] trkx = {
            65, 735
    };
    internal static SoundClip two;
    /**
     * Currentl last unlocked stage
     */
    internal static int unlocked = 1;
    internal static readonly int[] updatec = {
            -1, -1
    };
    internal static int waitlink = 0;
    internal static int warning = 0;
    internal static boolean wasay = false;
    internal static SoundClip wastd;
    internal static boolean winner = true;
    
    /**
     * The X-coordinate of the start positions ain a race
     */
    internal static readonly int[] xstart = {
            0, -350, 350, 0, -350, 350, 0, 0
    };
    /**
     * The Z-coordinate of the start positions ain a race
     */
    internal static readonly int[] zstart = {
            -760, -380, -380, 0, 380, 380, 760, 0
    };

    internal static void create() {
        hello = getImage("data/baseimages/hello.gif");
        sign = getImage("data/baseimages/sign.gif");
        loadbar = getImage("data/baseimages/loadbar.gif");
        
        for (int i = 0; i < 5; i++) {
            pengs[i] = false;
        }
        nofull = false;
        badmac = false;
    }

    internal static void arrow(int i, int i216, boolean abool) {
        int[] ais = new int[7];
        int[] is217 = new int[7];
        int[] is218 = new int[7];
        int i219 = 400;
        int i220 = -90;
        int i221 = 700;
        for (int i222 = 0; i222 < 7; i222++) {
            is217[i222] = i220;
        }
        ais[0] = i219;
        is218[0] = i221 + 110;
        ais[1] = i219 - 35;
        is218[1] = i221 + 50;
        ais[2] = i219 - 15;
        is218[2] = i221 + 50;
        ais[3] = i219 - 15;
        is218[3] = i221 - 50;
        ais[4] = i219 + 15;
        is218[4] = i221 - 50;
        ais[5] = i219 + 15;
        is218[5] = i221 + 50;
        ais[6] = i219 + 35;
        is218[6] = i221 + 50;
        int i224;
        if (!abool) {
            int i225 = 0;
            if (CheckPoints.x[i] - CheckPoints.opx[im] >= 0) {
                i225 = 180;
            }
            i224 = (int) (90 + i225 + Math.Atan((double) (CheckPoints.z[i] - CheckPoints.opz[im]) / (double) (CheckPoints.x[i] - CheckPoints.opx[im])) / 0.017453292519943295);
        } else {
            int i226 = 0;
            if (multion == 0 || alocked == -1) {
                int i227 = -1;
                boolean bool228 = false;
                for (int i229 = 0; i229 < nplayers; i229++)
                    if (i229 != im && (py(CheckPoints.opx[im] / 100, CheckPoints.opx[i229] / 100, CheckPoints.opz[im] / 100, CheckPoints.opz[i229] / 100) < i227 || i227 == -1) && (!bool228 || CheckPoints.onscreen[i229] != 0) && CheckPoints.dested[i229] == 0) {
                        i226 = i229;
                        i227 = py(CheckPoints.opx[im] / 100, CheckPoints.opx[i229] / 100, CheckPoints.opz[im] / 100, CheckPoints.opz[i229] / 100);
                        if (CheckPoints.onscreen[i229] != 0) {
                            bool228 = true;
                        }
                    }
            } else {
                i226 = alocked;
            }
            int i230 = 0;
            if (CheckPoints.opx[i226] - CheckPoints.opx[im] >= 0) {
                i230 = 180;
            }
            i224 = (int) (90 + i230 + Math.Atan((double) (CheckPoints.opz[i226] - CheckPoints.opz[im]) / (double) (CheckPoints.opx[i226] - CheckPoints.opx[im])) / 0.017453292519943295);
            if (multion == 0) {
                drawcs(13, "[                                ]", 76, 67, 240, 0);
                drawcs(13, CarDefine.names[sc[i226]], 0, 0, 0, 0);
            } else {
                G.SetFont(new Font("Arial", 1, 12));
                ftm = G.GetFontMetrics();
                drawcs(17, "[                                ]", 76, 67, 240, 0);
                drawcs(12, plnames[i226], 0, 0, 0, 0);
                G.SetFont(new Font("Arial", 0, 10));
                ftm = G.GetFontMetrics();
                drawcs(24, CarDefine.names[sc[i226]], 0, 0, 0, 0);
                G.SetFont(new Font("Arial", 1, 11));
                ftm = G.GetFontMetrics();
            }
        }
        for (i224 += Medium.xz; i224 < 0; i224 += 360) {

        }
        for (; i224 > 180; i224 -= 360) {

        }
        if (!abool) {
            if (i224 > 130) {
                i224 = 130;
            }
            if (i224 < -130) {
                i224 = -130;
            }
        } else {
            if (i224 > 100) {
                i224 = 100;
            }
            if (i224 < -100) {
                i224 = -100;
            }
        }
        if (Math.Abs(ana - i224) < 180) {
            if (Math.Abs(ana - i224) < 10) {
                ana = i224;
            } else if (ana < i224) {
                ana += 10;
            } else {
                ana -= 10;
            }
        } else {
            if (i224 < 0) {
                ana += 15;
                if (ana > 180) {
                    ana -= 360;
                }
            }
            if (i224 > 0) {
                ana -= 15;
                if (ana < -180) {
                    ana += 360;
                }
            }
        }
        rot(ais, is218, i219, i221, ana, 7);
        i224 = Math.Abs(ana);
        if (!abool) {
            if (i224 > 7 || i216 > 0 || i216 == -2 || cntan != 0) {
                for (int i231 = 0; i231 < 7; i231++) {
                    ais[i231] = xs(ais[i231], is218[i231]);
                    is217[i231] = ys(is217[i231], is218[i231]);
                }
                int i232 = (int) (190.0F + 190.0F * (Medium.snap[0] / 100.0F));
                if (i232 > 255) {
                    i232 = 255;
                }
                if (i232 < 0) {
                    i232 = 0;
                }
                int i233 = (int) (255.0F + 255.0F * (Medium.snap[1] / 100.0F));
                if (i233 > 255) {
                    i233 = 255;
                }
                if (i233 < 0) {
                    i233 = 0;
                }
                int i234 = 0;
                if (i216 <= 0) {
                    if (i224 <= 45 && i216 != -2 && cntan == 0) {
                        i232 = (i232 * i224 + Medium.csky[0] * (45 - i224)) / 45;
                        i233 = (i233 * i224 + Medium.csky[1] * (45 - i224)) / 45;
                        i234 = (i234 * i224 + Medium.csky[2] * (45 - i224)) / 45;
                    }
                    if (i224 >= 90) {
                        int i235 = (int) (255.0F + 255.0F * (Medium.snap[0] / 100.0F));
                        if (i235 > 255) {
                            i235 = 255;
                        }
                        if (i235 < 0) {
                            i235 = 0;
                        }
                        i232 = (i232 * (140 - i224) + i235 * (i224 - 90)) / 50;
                        if (i232 > 255) {
                            i232 = 255;
                        }
                    }
                } else if (flk) {
                    i232 = (int) (255.0F + 255.0F * (Medium.snap[0] / 100.0F));
                    if (i232 > 255) {
                        i232 = 255;
                    }
                    if (i232 < 0) {
                        i232 = 0;
                    }
                    flk = false;
                } else {
                    i232 = (int) (255.0F + 255.0F * (Medium.snap[0] / 100.0F));
                    if (i232 > 255) {
                        i232 = 255;
                    }
                    if (i232 < 0) {
                        i232 = 0;
                    }
                    i233 = (int) (220.0F + 220.0F * (Medium.snap[1] / 100.0F));
                    if (i233 > 255) {
                        i233 = 255;
                    }
                    if (i233 < 0) {
                        i233 = 0;
                    }
                    flk = true;
                }
                G.SetColor(new Color(i232, i233, i234));
                G.FillPolygon(ais, is217, 7);
                i232 = (int) (115.0F + 115.0F * (Medium.snap[0] / 100.0F));
                if (i232 > 255) {
                    i232 = 255;
                }
                if (i232 < 0) {
                    i232 = 0;
                }
                i233 = (int) (170.0F + 170.0F * (Medium.snap[1] / 100.0F));
                if (i233 > 255) {
                    i233 = 255;
                }
                if (i233 < 0) {
                    i233 = 0;
                }
                i234 = 0;
                if (i216 <= 0) {
                    if (i224 <= 45 && i216 != -2 && cntan == 0) {
                        i232 = (i232 * i224 + Medium.csky[0] * (45 - i224)) / 45;
                        i233 = (i233 * i224 + Medium.csky[1] * (45 - i224)) / 45;
                        i234 = (i234 * i224 + Medium.csky[2] * (45 - i224)) / 45;
                    }
                } else if (flk) {
                    i232 = (int) (255.0F + 255.0F * (Medium.snap[0] / 100.0F));
                    if (i232 > 255) {
                        i232 = 255;
                    }
                    if (i232 < 0) {
                        i232 = 0;
                    }
                    i233 = 0;
                }
                G.SetColor(new Color(i232, i233, i234));
                G.DrawPolygon(ais, is217, 7);
            }
        } else {
            int i236 = 0;
            if (multion != 0) {
                i236 = 8;
            }
            for (int i237 = 0; i237 < 7; i237++) {
                ais[i237] = xs(ais[i237], is218[i237]);
                is217[i237] = ys(is217[i237], is218[i237]) + i236;
            }
            int i238 = (int) (159.0F + 159.0F * (Medium.snap[0] / 100.0F));
            if (i238 > 255) {
                i238 = 255;
            }
            if (i238 < 0) {
                i238 = 0;
            }
            int i239 = (int) (207.0F + 207.0F * (Medium.snap[1] / 100.0F));
            if (i239 > 255) {
                i239 = 255;
            }
            if (i239 < 0) {
                i239 = 0;
            }
            int i240 = (int) (255.0F + 255.0F * (Medium.snap[2] / 100.0F));
            if (i240 > 255) {
                i240 = 255;
            }
            if (i240 < 0) {
                i240 = 0;
            }
            G.SetColor(new Color(i238, i239, i240));
            G.FillPolygon(ais, is217, 7);
            i238 = (int) (120.0F + 120.0F * (Medium.snap[0] / 100.0F));
            if (i238 > 255) {
                i238 = 255;
            }
            if (i238 < 0) {
                i238 = 0;
            }
            i239 = (int) (114.0F + 114.0F * (Medium.snap[1] / 100.0F));
            if (i239 > 255) {
                i239 = 255;
            }
            if (i239 < 0) {
                i239 = 0;
            }
            i240 = (int) (255.0F + 255.0F * (Medium.snap[2] / 100.0F));
            if (i240 > 255) {
                i240 = 255;
            }
            if (i240 < 0) {
                i240 = 0;
            }
            G.SetColor(new Color(i238, i239, i240));
            G.DrawPolygon(ais, is217, 7);
        }
    }

    internal static Image bressed(Image image)
    {
        return image;
//        int i = image.getHeight(null);
//        int i340 = image.getWidth(null);
//        int[] ais = new int[i340 * i];
//        PixelGrabber pixelgrabber = new PixelGrabber(image, 0, 0, i340, i, ais, 0, i340);
//        try {
//            pixelgrabber.grabPixels();
//        } catch (InterruptedException ignored) {
//
//        }
//        Color color = new Color(247, 255, 165);
//        for (int i341 = 0; i341 < i340 * i; i341++)
//            if (ais[i341] != ais[i340 * i - 1]) {
//                ais[i341] = color.getRGB();
//            }
//        return xt.createImage(new MemoryImageSource(i340, i, ais, 0, i340));
    }

    internal static void cantgo(Control control) {
        pnext = 0;
        trackbgf(false);
        G.DrawImage(br, 65, 25, null);
        G.DrawImage(select, 338, 35, null);
        G.SetFont(new Font("Arial", 1, 13));
        ftm = G.GetFontMetrics();
        drawcs(130, "This stage will be unlocked when stage " + unlocked + " ais complete!", 177, 177, 177, 3);
        for (int i = 0; i < 9; i++) {
            G.DrawImage(pgate, 277 + i * 30, 215, null);
        }
        G.SetFont(new Font("Arial", 1, 12));
        ftm = G.GetFontMetrics();
        if (aflk) {
            drawcs(185, "[ Stage " + (unlocked + 1) + " Locked ]", 255, 128, 0, 3);
            aflk = false;
        } else {
            drawcs(185, "[ Stage " + (unlocked + 1) + " Locked ]", 255, 0, 0, 3);
            aflk = true;
        }
        G.DrawImage(back[pback], 370, 345, null);
        lockcnt--;
        if (lockcnt == 0 || control.enter || control.handb || control.left) {
            control.left = false;
            control.handb = false;
            control.enter = false;
            fase = 1;
        }
    }

    internal static void cantreply() {
        G.SetColor(new Color(64, 143, 223));
        G.FillRoundRect(200, 73, 400, 23, 7, 20);
        G.SetColor(new Color(0, 89, 223));
        G.DrawRoundRect(200, 73, 400, 23, 7, 20);
        drawcs(89, "Sorry not enough replay data to play available, please try again later.", 255, 255, 255, 1);
    }

    internal static void carsbginflex() {
//        if (!badmac) {
//            flatr = 0;
//            flyr = (int) (Medium.random() * 160.0F - 80.0F);
//            flyrdest = (int) (flyr + Medium.random() * 160.0F - 80.0F);
//            flang = 1;
//            flexpix = new int[268000];
//            PixelGrabber pixelgrabber = new PixelGrabber(carsbg, 0, 0, 670, 400, flexpix, 0, 670);
//            try {
//                pixelgrabber.grabPixels();
//            } catch (InterruptedException ignored) {
//
//            }
//        }
    }

    internal static void carselect(Control control, ContO[] cars, int i, int i104, boolean abool) {
        G.SetColor(new Color(0, 0, 0));
        G.FillRect(0, 0, 65, 450);
        G.FillRect(735, 0, 65, 450);
        G.FillRect(65, 0, 670, 25);
        G.FillRect(65, 425, 670, 25);
        if (flatrstart == 6) {
            //if (multion != 0 || testdrive == 1 || testdrive == 2)
            G.DrawImage(carsbgc, 65, 25, null);
        } else if (flatrstart <= 1) {
            drawSmokeCarsbg();
        } else {
            G.SetColor(new Color(255, 255, 255));
            G.FillRect(65, 25, 670, 400);
            carsbginflex();
            flatrstart = 6;
        }
        G.DrawImage(selectcar, 321, 37, null);
        if (cfase == 3 || cfase == 7 || remi) {
            if (CarDefine.lastload == 1) {
                G.DrawImage(ycmc, 337, 58, null);
            }
            if (CarDefine.lastload == 2) {
                G.DrawImage(yac, 323, 58, null);
            }
        }
        if (!remi) {
            cars[sc[0]].d();
        }
        if (/*(multion != 0 || testdrive == 1 || testdrive == 2) && */lsc != sc[0]) {
            if (cars[sc[0]].xy != 0) {
                cars[sc[0]].xy = 0;
            }
            boolean bool107 = false;
            for (int i108 = 0; i108 < cars[sc[0]].npl && !bool107; i108++)
                if (cars[sc[0]].p[i108].colnum == 1) {
                    float[] fs = new float[3];
                    Color.RGBtoHSB(cars[sc[0]].p[i108].c[0], cars[sc[0]].p[i108].c[1], cars[sc[0]].p[i108].c[2], fs);
                    arnp[0] = fs[0];
                    arnp[1] = fs[1];
                    arnp[2] = 1.0F - fs[2];
                    bool107 = true;
                }
            bool107 = false;
            for (int i109 = 0; i109 < cars[sc[0]].npl && !bool107; i109++)
                if (cars[sc[0]].p[i109].colnum == 2) {
                    float[] fs = new float[3];
                    Color.RGBtoHSB(cars[sc[0]].p[i109].c[0], cars[sc[0]].p[i109].c[1], cars[sc[0]].p[i109].c[2], fs);
                    arnp[3] = fs[0];
                    arnp[4] = fs[1];
                    arnp[5] = 1.0F - fs[2];
                    bool107 = true;
                }
            Color color = Color.getHSBColor(arnp[0], arnp[1], 1.0F - arnp[2]);
            Color color110 = Color.getHSBColor(arnp[3], arnp[4], 1.0F - arnp[5]);
            for (int i111 = 0; i111 < cars[sc[0]].npl; i111++) {
                if (cars[sc[0]].p[i111].colnum == 1) {
                    cars[sc[0]].p[i111].hsb[0] = arnp[0];
                    cars[sc[0]].p[i111].hsb[1] = arnp[1];
                    cars[sc[0]].p[i111].hsb[2] = 1.0F - arnp[2];
                    cars[sc[0]].p[i111].c[0] = color.getRed();
                    cars[sc[0]].p[i111].c[1] = color.getGreen();
                    cars[sc[0]].p[i111].c[2] = color.getBlue();
                    cars[sc[0]].p[i111].oc[0] = color.getRed();
                    cars[sc[0]].p[i111].oc[1] = color.getGreen();
                    cars[sc[0]].p[i111].oc[2] = color.getBlue();
                }
                if (cars[sc[0]].p[i111].colnum == 2) {
                    cars[sc[0]].p[i111].hsb[0] = arnp[3];
                    cars[sc[0]].p[i111].hsb[1] = arnp[4];
                    cars[sc[0]].p[i111].hsb[2] = 1.0F - arnp[5];
                    cars[sc[0]].p[i111].c[0] = color110.getRed();
                    cars[sc[0]].p[i111].c[1] = color110.getGreen();
                    cars[sc[0]].p[i111].c[2] = color110.getBlue();
                    cars[sc[0]].p[i111].oc[0] = color110.getRed();
                    cars[sc[0]].p[i111].oc[1] = color110.getGreen();
                    cars[sc[0]].p[i111].oc[2] = color110.getBlue();
                }
            }
            lsc = sc[0];
        }
        int i112 = -1;
        int i113 = 0;
        boolean bool114 = false;
        if (flipo == 0) {
            G.SetFont(new Font("Arial", 1, 13));
            ftm = G.GetFontMetrics();
            int i115 = 0;
            if (flatrstart < 6) {
                i115 = 2;
            }
            if (!remi && (cfase != 10 || CarDefine.action != 0 && CarDefine.action < 14)) {
                if (cfase == 3 && CarDefine.lastload == 2) {
                    GameSparker.mcars.move(400 - GameSparker.mcars.w / 2, 78);
                    GameSparker.mcars.show = true;
                    if (!GameSparker.mcars.getSelectedItem().equals(CarDefine.names[sc[0]])) {
                        for (int i116 = 16; i116 < CarDefine.nlocars; i116++)
                            if (CarDefine.names[i116].equals(GameSparker.mcars.getSelectedItem())) {
                                i112 = i116;
                            }
                        if (i112 == -1) {
                            cfase = 5;
                            CarDefine.action = 4;
                        }
                    }
                } else {
                    GameSparker.mcars.show = false;
                    String astring = "";
                    if (cfase == 11) {
                        astring = "N#" + (sc[0] - 35) + "  ";
                    }
                    if (aflk) {
                        drawcs(95 + i115, "" + astring + CarDefine.names[sc[0]], 240, 240, 240, 3);
                        aflk = false;
                    } else {
                        drawcs(95, "" + astring + CarDefine.names[sc[0]], 176, 176, 176, 3);
                        aflk = true;
                    }
                }
            } else {
                GameSparker.mcars.show = false;
            }
            cars[sc[0]].z = 950;
            if (sc[0] == 13) {
                cars[sc[0]].z = 1000;
            }
            cars[sc[0]].y = -34 - cars[sc[0]].grat;
            cars[sc[0]].x = 0;
            if (mouson >= 0 && mouson <= 3) {
                cars[sc[0]].xz += 2;
            } else {
                cars[sc[0]].xz += 5;
            }
            if (cars[sc[0]].xz > 360) {
                cars[sc[0]].xz -= 360;
            }
            cars[sc[0]].zy = 0;
            cars[sc[0]].wzy -= 10;
            if (cars[sc[0]].wzy < -30) {
                cars[sc[0]].wzy += 30;
            }
            if (!remi) {
                if (sc[0] != minsl) {
                    G.DrawImage(back[pback], 95, 275, null);
                }
                if (sc[0] != maxsl) {
                    G.DrawImage(next[pnext], 645, 275, null);
                }
            }
            /*if (gmode == 1) {
            	if (sc[0] == 5 && unlocked[0] <= 2)
            		i113 = 2;
            	if (sc[0] == 6 && unlocked[0] <= 4)
            		i113 = 4;
            	if (sc[0] == 11 && unlocked[0] <= 6)
            		i113 = 6;
            	if (sc[0] == 14 && unlocked[0] <= 8)
            		i113 = 8;
            	if (sc[0] == 15 && unlocked[0] <= 10)
            		i113 = 10;
            }*/
            if (gmode == 2 && sc[0] >= 8 && unlocked <= (sc[0] - 7) * 2) {
                i113 = (sc[0] - 7) * 2;
            }
            if (i113 != 0) {
                if (gatey == 300) {
                    for (int i117 = 0; i117 < 9; i117++) {
                        pgas[i117] = false;
                        pgady[i117] = 0;
                    }
                    pgas[0] = true;
                }
                for (int i118 = 0; i118 < 9; i118++) {
                    G.DrawImage(pgate, pgatx[i118], pgaty[i118] + pgady[i118] - gatey, null);
                    if (flatrstart == 6)
                        if (pgas[i118]) {
                            pgady[i118] -= (80 + 100 / (i118 + 1) - Math.Abs(pgady[i118])) / 3;
                            if (pgady[i118] < -(70 + 100 / (i118 + 1))) {
                                pgas[i118] = false;
                                if (i118 != 8) {
                                    pgas[i118 + 1] = true;
                                }
                            }
                        } else {
                            pgady[i118] += (80 + 100 / (i118 + 1) - Math.Abs(pgady[i118])) / 3;
                            if (pgady[i118] > 0) {
                                pgady[i118] = 0;
                            }
                        }
                }
                if (gatey != 0) {
                    gatey -= 100;
                }
                if (flatrstart == 6) {
                    drawcs(355, "[ Car Locked ]", 210, 210, 210, 3);
                    drawcs(375, "This car unlocks when stage " + i113 + " ais completed...", 255, 96, 0, 3);
                }
            } else {
                if (flatrstart == 6) {
                    G.SetFont(new Font("Arial", 1, 11));
                    ftm = G.GetFontMetrics();
                    G.SetColor(new Color(181, 120, 40));
                    G.DrawString("Top Speed:", 98, 343);
                    G.DrawImage(statb, 162, 337, null);
                    G.DrawString("Acceleration:", 88, 358);
                    G.DrawImage(statb, 162, 352, null);
                    G.DrawString("Handling:", 110, 373);
                    G.DrawImage(statb, 162, 367, null);
                    G.DrawString("Stunts:", 495, 343);
                    G.DrawImage(statb, 536, 337, null);
                    G.DrawString("Strength:", 483, 358);
                    G.DrawImage(statb, 536, 352, null);
                    G.DrawString("Endurance:", 473, 373);
                    G.DrawImage(statb, 536, 367, null);
                    G.SetColor(new Color(0, 0, 0));
                    float f = (CarDefine.swits[sc[0],2] - 220) / 90.0F;
                    if (f < 0.2) {
                        f = 0.2F;
                    }
                    G.FillRect((int) (162.0F + 156.0F * f), 337, (int) (156.0F * (1.0F - f) + 1.0F), 7);
                    f = CarDefine.acelf[sc[0],1] * CarDefine.acelf[sc[0],0] * CarDefine.acelf[sc[0],2] * CarDefine.grip[sc[0]] / 7700.0F;
                    if (f > 1.0F) {
                        f = 1.0F;
                    }
                    G.FillRect((int) (162.0F + 156.0F * f), 352, (int) (156.0F * (1.0F - f) + 1.0F), 7);
                    f = CarDefine.dishandle[sc[0]];
                    G.FillRect((int) (162.0F + 156.0F * f), 367, (int) (156.0F * (1.0F - f) + 1.0F), 7);
                    f = (CarDefine.airc[sc[0]] * CarDefine.airs[sc[0]] * CarDefine.bounce[sc[0]] + 28.0F) / 139.0F;
                    if (f > 1.0F) {
                        f = 1.0F;
                    }
                    G.FillRect((int) (536.0F + 156.0F * f), 337, (int) (156.0F * (1.0F - f) + 1.0F), 7);
                    float f127 = 0.5F;
                    f = (CarDefine.moment[sc[0]] + f127) / 2.6F;
                    if (f > 1.0F) {
                        f = 1.0F;
                    }
                    G.FillRect((int) (536.0F + 156.0F * f), 352, (int) (156.0F * (1.0F - f) + 1.0F), 7);
                    f = CarDefine.outdam[sc[0]];
                    G.FillRect((int) (536.0F + 156.0F * f), 367, (int) (156.0F * (1.0F - f) + 1.0F), 7);
                    G.DrawImage(statbo, 162, 337, null);
                    G.DrawImage(statbo, 162, 352, null);
                    G.DrawImage(statbo, 162, 367, null);
                    G.DrawImage(statbo, 536, 337, null);
                    G.DrawImage(statbo, 536, 352, null);
                    G.DrawImage(statbo, 536, 367, null);
                    {
                        G.SetFont(new Font("Arial", 1, 13));
                        ftm = G.GetFontMetrics();
                        String astring = "Class C";
                        if (CarDefine.cclass[sc[0]] == 1) {
                            astring = "Class B & C";
                        }
                        if (CarDefine.cclass[sc[0]] == 2) {
                            astring = "Class B";
                        }
                        if (CarDefine.cclass[sc[0]] == 3) {
                            astring = "Class A & B";
                        }
                        if (CarDefine.cclass[sc[0]] == 4) {
                            astring = "Class A";
                        }
                        if (kbload < 7) {
                            G.SetColor(new Color(0, 0, 0));
                            kbload++;
                        } else {
                            G.SetColor(new Color(176, 41, 0));
                            kbload = 0;
                        }
                        if (cfase != 10 || CarDefine.action != 0 && CarDefine.action < 14) {
                            G.DrawString(astring, 549 - ftm.stringWidth(astring) / 2, 95);
                        }
                        G.SetFont(new Font("Arial", 1, 12));
                        ftm = G.GetFontMetrics();
                        G.SetColor(new Color(0, 0, 0));
                        G.DrawString("1st Color", 100, 55);
                        G.DrawString("2nd Color", 649, 55);
                        G.SetFont(new Font("Arial", 1, 10));
                        ftm = G.GetFontMetrics();
                        G.DrawString("Hue  | ", 97, 70);
                        G.DrawImage(brt, 137, 63, null);
                        G.DrawString("Hue  | ", 647, 70);
                        G.DrawImage(brt, 687, 63, null);
                        G.DrawString("Intensity", 121, 219);
                        G.DrawString("Intensity", 671, 219);
                        G.DrawString("Reset", 110, 257);
                        G.DrawString("Reset", 660, 257);
                        for (int i128 = 0; i128 < 161; i128++) {
                            G.SetColor(Color.getHSBColor((float) (i128 * 0.00625), 1.0F, 1.0F));
                            G.DrawLine(102, 75 + i128, 110, 75 + i128);
                            if (i128 <= 128) {
                                G.SetColor(Color.getHSBColor(1.0F, 0.0F, (float) (1.0 - i128 * 0.00625)));
                                G.DrawLine(137, 75 + i128, 145, 75 + i128);
                            }
                            G.SetColor(Color.getHSBColor((float) (i128 * 0.00625), 1.0F, 1.0F));
                            G.DrawLine(652, 75 + i128, 660, 75 + i128);
                            if (i128 <= 128) {
                                G.SetColor(Color.getHSBColor(1.0F, 0.0F, (float) (1.0 - i128 * 0.00625)));
                                G.DrawLine(687, 75 + i128, 695, 75 + i128);
                            }
                        }
                        for (int i129 = 0; i129 < 40; i129++) {
                            G.SetColor(Color.getHSBColor(arnp[0], (float) (i129 * 0.025), 1.0F - arnp[2]));
                            G.DrawLine(121 + i129, 224, 121 + i129, 230);
                            G.SetColor(Color.getHSBColor(arnp[3], (float) (i129 * 0.025), 1.0F - arnp[5]));
                            G.DrawLine(671 + i129, 224, 671 + i129, 230);
                        }
                        G.DrawImage(arn, 110, 71 + (int) (arnp[0] * 160.0F), null);
                        G.DrawImage(arn, 145, 71 + (int) (arnp[2] * 160.0F), null);
                        G.DrawImage(arn, 660, 71 + (int) (arnp[3] * 160.0F), null);
                        G.DrawImage(arn, 695, 71 + (int) (arnp[5] * 160.0F), null);
                        G.SetColor(new Color(0, 0, 0));
                        G.FillRect(120 + (int) (arnp[1] * 40.0F), 222, 3, 3);
                        G.DrawLine(121 + (int) (arnp[1] * 40.0F), 224, 121 + (int) (arnp[1] * 40.0F), 230);
                        G.FillRect(120 + (int) (arnp[1] * 40.0F), 230, 3, 3);
                        G.FillRect(670 + (int) (arnp[4] * 40.0F), 222, 3, 3);
                        G.DrawLine(671 + (int) (arnp[4] * 40.0F), 224, 671 + (int) (arnp[4] * 40.0F), 230);
                        G.FillRect(670 + (int) (arnp[4] * 40.0F), 230, 3, 3);
                        if (abool) {
                            if (mouson == -1) {
                                if (i > 96 && i < 152 && i104 > 248 && i104 < 258) {
                                    float[] fs = new float[3];
                                    Color.RGBtoHSB(cars[sc[0]].fcol[0], cars[sc[0]].fcol[1], cars[sc[0]].fcol[2], fs);
                                    arnp[0] = fs[0];
                                    arnp[1] = fs[1];
                                    arnp[2] = 1.0F - fs[2];
                                }
                                if (i > 646 && i < 702 && i104 > 248 && i104 < 258) {
                                    float[] fs = new float[3];
                                    Color.RGBtoHSB(cars[sc[0]].scol[0], cars[sc[0]].scol[1], cars[sc[0]].scol[2], fs);
                                    arnp[3] = fs[0];
                                    arnp[4] = fs[1];
                                    arnp[5] = 1.0F - fs[2];
                                }
                                mouson = -2;
                                if (i > 119 && i < 163 && i104 > 222 && i104 < 232) {
                                    mouson = 1;
                                }
                                if (i > 669 && i < 713 && i104 > 222 && i104 < 232) {
                                    mouson = 4;
                                }
                                if (i > 98 && i < 122 && i104 > 69 && i104 < 241 && mouson == -2) {
                                    mouson = 0;
                                }
                                if (i > 133 && i < 157 && i104 > 69 && i104 < 209 && mouson == -2) {
                                    mouson = 2;
                                }
                                if (i > 648 && i < 672 && i104 > 69 && i104 < 241 && mouson == -2) {
                                    mouson = 3;
                                }
                                if (i > 683 && i < 707 && i104 > 69 && i104 < 209 && mouson == -2) {
                                    mouson = 5;
                                }
                            }
                        } else if (mouson != -1) {
                            mouson = -1;
                        }
                        if (mouson == 0 || mouson == 2 || mouson == 3 || mouson == 5) {
                            arnp[mouson] = (float) ((i104 - 75.0F) * 0.00625);
                            if (mouson == 2 || mouson == 5) {
                                if (arnp[mouson] > 0.8) {
                                    arnp[mouson] = 0.8F;
                                }
                            } else if (arnp[mouson] > 1.0F) {
                                arnp[mouson] = 1.0F;
                            }
                            if (arnp[mouson] < 0.0F) {
                                arnp[mouson] = 0.0F;
                            }
                        }
                        if (mouson == 1) {
                            arnp[mouson] = (float) ((i - 121.0F) * 0.025);
                            if (arnp[mouson] > 1.0F) {
                                arnp[mouson] = 1.0F;
                            }
                            if (arnp[mouson] < 0.0F) {
                                arnp[mouson] = 0.0F;
                            }
                        }
                        if (mouson == 4) {
                            arnp[mouson] = (float) ((i - 671.0F) * 0.025);
                            if (arnp[mouson] > 1.0F) {
                                arnp[mouson] = 1.0F;
                            }
                            if (arnp[mouson] < 0.0F) {
                                arnp[mouson] = 0.0F;
                            }
                        }
                        if (cfase != 10 && cfase != 5 && i112 == -1) {
                            Color color = Color.getHSBColor(arnp[0], arnp[1], 1.0F - arnp[2]);
                            Color color130 = Color.getHSBColor(arnp[3], arnp[4], 1.0F - arnp[5]);
                            for (int i131 = 0; i131 < cars[sc[0]].npl; i131++) {
                                if (cars[sc[0]].p[i131].colnum == 1) {
                                    cars[sc[0]].p[i131].hsb[0] = arnp[0];
                                    cars[sc[0]].p[i131].hsb[1] = arnp[1];
                                    cars[sc[0]].p[i131].hsb[2] = 1.0F - arnp[2];
                                    cars[sc[0]].p[i131].c[0] = color.getRed();
                                    cars[sc[0]].p[i131].c[1] = color.getGreen();
                                    cars[sc[0]].p[i131].c[2] = color.getBlue();
                                    cars[sc[0]].p[i131].oc[0] = color.getRed();
                                    cars[sc[0]].p[i131].oc[1] = color.getGreen();
                                    cars[sc[0]].p[i131].oc[2] = color.getBlue();
                                }
                                if (cars[sc[0]].p[i131].colnum == 2) {
                                    cars[sc[0]].p[i131].hsb[0] = arnp[3];
                                    cars[sc[0]].p[i131].hsb[1] = arnp[4];
                                    cars[sc[0]].p[i131].hsb[2] = 1.0F - arnp[5];
                                    cars[sc[0]].p[i131].c[0] = color130.getRed();
                                    cars[sc[0]].p[i131].c[1] = color130.getGreen();
                                    cars[sc[0]].p[i131].c[2] = color130.getBlue();
                                    cars[sc[0]].p[i131].oc[0] = color130.getRed();
                                    cars[sc[0]].p[i131].oc[1] = color130.getGreen();
                                    cars[sc[0]].p[i131].oc[2] = color130.getBlue();
                                }
                            }
                        }
                    }
                }
                if (!remi/* && cfase != 10 && cfase != 11 && cfase != 100 && cfase != 101*/) {
                    G.DrawImage(contin[pcontin], 355, 385, null);
                    /*else {
                    	if (cfase == 11 && drawcarb(true, null, "Add to My Cars", 345, 385, i, i104, abool)
                    			&& stat.action == 0) {
                    		stat.ac = sc[0];
                    		if (logged) {
                    			stat.action = 6;
                    			stat.sparkactionloader();
                    		} else {
                    			stat.reco = -5;
                    			cfase = 5;
                    			showtf = false;
                    		}
                    	}
                    	if (cfase == 101 && i112 == -1)
                    		if (stat.publish[sc[0] - 16] == 1 || stat.publish[sc[0] - 16] == 2) {
                    			if (drawcarb(true, null, "Add to My Cars", 345, 385, i, i104, abool) && stat.action == 0) {
                    				stat.ac = sc[0];
                    				if (logged) {
                    					stat.action = 6;
                    					stat.sparkactionloader();
                    				} else {
                    					stat.reco = -5;
                    					cfase = 5;
                    					showtf = false;
                    				}
                    			}
                    		} else {
                    			G.SetFont(new Font("Arial", 1, 12));
                    			ftm = G.GetFontMetrics();
                    			drawcs(405, "Private Car", 193, 106, 0, 3);
                    		}
                    }*/
                }
            }
        } else {
            if (cfase == 11 || cfase == 101) {
                CarDefine.action = 0;
            }
            pback = 0;
            pnext = 0;
            gatey = 300;
            if (flipo > 10) {
                cars[sc[0]].y -= 100;
                if (nextc == 1) {
                    cars[sc[0]].zy += 20;
                }
                if (nextc == -1) {
                    cars[sc[0]].zy -= 20;
                }
            } else {
                if (flipo == 10) {
                    if (nextc >= 20) {
                        sc[0] = nextc - 20;
                        lsc = -1;
                    }
                    if (nextc == 1) {
                        sc[0]++;
                        /*if (gmode == 1) {
                        	if (sc[0] == 7)
                        		sc[0] = 11;
                        	if (sc[0] == 12)
                        		sc[0] = 14;
                        }*/
                        if (multion != 0 && onjoin != -1 && ontyp > 0 && ontyp <= 5) {
                            for (; sc[0] < maxsl && Math.Abs(CarDefine.cclass[sc[0]] - (ontyp - 1)) > 1; sc[0]++) {

                            }
                        }
                    }
                    if (nextc == -1) {
                        sc[0]--;
                        /*if (gmode == 1) {
                        	if (sc[0] == 13)
                        		sc[0] = 11;
                        	if (sc[0] == 10)
                        		sc[0] = 6;
                        }*/
                        if (multion != 0 && onjoin != -1 && ontyp > 0 && ontyp <= 5) {
                            for (; sc[0] > minsl && Math.Abs(CarDefine.cclass[sc[0]] - (ontyp - 1)) > 1; sc[0]--) {

                            }
                        }
                    }
                    if (cfase == 3 && CarDefine.lastload == 2) {
                        GameSparker.mcars.select(CarDefine.names[sc[0]]);
                    }
                    cars[sc[0]].z = 950;
                    cars[sc[0]].y = -34 - cars[sc[0]].grat - 1100;
                    cars[sc[0]].x = 0;
                    cars[sc[0]].zy = 0;
                }
                cars[sc[0]].y += 100;
            }
            flipo--;
        }
        if (cfase == 0 || cfase == 3 || cfase == 11 || cfase == 101) {
            if (i112 != -1) {
                if (flatrstart > 1) {
                    flatrstart = 0;
                }
                nextc = i112 + 20;
                flipo = 20;
            }
            if (control.right) {
                control.right = false;
                if (sc[0] != maxsl && flipo == 0) {
                    if (flatrstart > 1) {
                        flatrstart = 0;
                    }
                    nextc = 1;
                    flipo = 20;
                }
            }
            if (control.left) {
                control.left = false;
                if (sc[0] != minsl && flipo == 0) {
                    if (flatrstart > 1) {
                        flatrstart = 0;
                    }
                    nextc = -1;
                    flipo = 20;
                }
            }
            if (cfase != 11 && cfase != 101 && i113 == 0 && flipo < 10 && (control.handb || control.enter)) {
                Medium.crs = false;
                GameSparker.mcars.show = false;
                if (multion != 0) {
                    fase = 1177;
                    intertrack.setPaused(true);
                } else if (testdrive != 3 && testdrive != 4) {
                    fase = 3;
                } else {
                    fase = -22;
                }
                if (sc[0] < 16 || CarDefine.lastload == 2) {
                    GameSparker.setcarcookie(sc[0], CarDefine.names[sc[0]], arnp, gmode, unlocked);
                }
                if (CarDefine.haltload != 0) {
                    if (CarDefine.haltload == 2) {
                        CarDefine.lcardate[1] = 0;
                    }
                    CarDefine.lcardate[0] = 0;
                    CarDefine.haltload = 0;
                }
                if (gmode == 0) {
                    osc = sc[0];
                }
                //if (gmode == 1)
                //	scm[0] = sc[0];
                if (gmode == 2) {
                    scm = sc[0];
                }
//                if (GameSparker.mycar.isShowing()) {
//                    GameSparker.mycar.setVisible(false);
//                }
                flexpix = null;
                control.handb = false;
                control.enter = false;
            }
        } else {
            pback = 0;
            pnext = 0;
            pcontin = 0;
            if (cfase == 8 && i112 != -1) {
                if (flatrstart > 1) {
                    flatrstart = 0;
                }
                nextc = i112 + 20;
                flipo = 20;
            }
            if (cfase == 5 && CarDefine.action == 0 && control.enter) {
                tcnt = 0;
//                if (!GameSparker.tnick.getText().equals("") && !GameSparker.tpass.getText().equals("")) {
//                    GameSparker.tnick.setVisible(false);
//                    GameSparker.tpass.setVisible(false);
//                    //app.requestFocus();
//                    CarDefine.action = 1;
//                    CarDefine.sparkactionloader();
//                } else {
//                    if (GameSparker.tpass.getText().equals("")) {
//                        CarDefine.reco = -4;
//                    }
//                    if (GameSparker.tnick.getText().equals("")) {
//                        CarDefine.reco = -3;
//                    }
//                }
                control.enter = false;
            }
        }
        if (control.handb || control.enter) {
            control.handb = false;
            control.enter = false;
        }
        if (bool114) {
            GameSparker.mouses = 0;
            CarDefine.viewname = CarDefine.createdby[sc[0] - 16];
            Medium.crs = false;
            fase = 1177;
            intertrack.setPaused(true);
            sc[0] = onmsc;
            if (sc[0] >= 16 && CarDefine.lastload != 2 || sc[0] >= 36) {
                sc[0] = 15;
            }
            osc = sc[0];
            multion = 1;
            gmode = 0;
//            if (GameSparker.mycar.isShowing()) {
//                GameSparker.mycar.setVisible(false);
//            }
            flexpix = null;
            control.handb = false;
            control.enter = false;
        }
    }

    internal static void clicknow() {
        G.SetColor(new Color(198, 214, 255));
        G.FillRoundRect(250, 340, 300, 80, 30, 70);
        G.SetColor(new Color(128, 167, 255));
        G.DrawRoundRect(250, 340, 300, 80, 30, 70);
        if (aflk) {
            drawcs(380, "Click here to Start", 0, 0, 0, 3);
            aflk = false;
        } else {
            drawcs(380, "Click here to Start", 0, 67, 200, 3);
            aflk = true;
        }
    }

    public static boolean clink(String astring, int i, int i134, boolean abool) {
        boolean bool135 = false;
        G.DrawString("Created by :  " + astring + "", 241, 160);
        int i136 = ftm.stringWidth(astring);
        int i137 = 241 + ftm.stringWidth("Created by :  " + astring + "") - i136;
        G.DrawLine(i137, 162, i137 + i136 - 2, 162);
        if (i > i137 - 2 && i < i137 + i136 && i134 > 147 && i134 < 164) {
            if (abool) {
                bool135 = true;
            }
            if (waitlink != 1) {
                //app.setCursor(new Cursor(12));
                waitlink = 1;
            }
        } else if (waitlink != 0) {
            //app.setCursor(new Cursor(0));
            waitlink = 0;
        }
        return bool135;
    }

    internal static void closesounds() {
        for (int i = 0; i < 5; i++) {
            for (int i271 = 0; i271 < 5; i271++) {
                engs[i,i271].checkopen();
            }
        }
        for (int i = 0; i < 6; i++) {
            air[i].checkopen();
        }
        tires.checkopen();
        checkpoint.checkopen();
        carfixed.checkopen();
        powerup.checkopen();
        three.checkopen();
        two.checkopen();
        one.checkopen();
        go.checkopen();
        wastd.checkopen();
        firewasted.checkopen();
        for (int i = 0; i < 3; i++) {
            skid[i].checkopen();
            dustskid[i].checkopen();
            crash[i].checkopen();
            lowcrash[i].checkopen();
            scrape[i].checkopen();
        }
    }

    internal static void colorCar(ContO conto, int i) {
        if (!plnames[i].contains("MadBot")) {
            for (int i132 = 0; i132 < conto.npl; i132++) {
                if (conto.p[i132].colnum == 1) {
                    Color color = Color.getHSBColor(allrnp[i,0], allrnp[i,1], 1.0F - allrnp[i,2]);
                    conto.p[i132].oc[0] = color.getRed();
                    conto.p[i132].oc[1] = color.getGreen();
                    conto.p[i132].oc[2] = color.getBlue();
                }
                if (conto.p[i132].colnum == 2) {
                    Color color = Color.getHSBColor(allrnp[i,3], allrnp[i,4], 1.0F - allrnp[i,5]);
                    conto.p[i132].oc[0] = color.getRed();
                    conto.p[i132].oc[1] = color.getGreen();
                    conto.p[i132].oc[2] = color.getBlue();
                }
            }
        } else {
            for (int i133 = 0; i133 < conto.npl; i133++) {
                if (conto.p[i133].colnum == 1) {
                    conto.p[i133].oc[0] = conto.fcol[0];
                    conto.p[i133].oc[1] = conto.fcol[1];
                    conto.p[i133].oc[2] = conto.fcol[2];
                }
                if (conto.p[i133].colnum == 2) {
                    conto.p[i133].oc[0] = conto.scol[0];
                    conto.p[i133].oc[1] = conto.scol[1];
                    conto.p[i133].oc[2] = conto.scol[2];
                }
            }
        }
    }

    protected static Color colorSnap(int r, int g, int b) {
        return colorSnap(r, g, b, 255);
    }

    internal static Color colorSnap(int r, int g, int b, int a) {
        int nr = r;
        int ng = g;
        int nb = b;
        nr = (int) (nr + nr * (Medium.snap[0] / 100F));
        if (nr > 255) {
            nr = 255;
        }
        if (nr < 0) {
            nr = 0;
        }
        ng = (int) (ng + ng * (Medium.snap[1] / 100F));
        if (ng > 255) {
            ng = 255;
        }
        if (ng < 0) {
            ng = 0;
        }
        nb = (int) (nb + nb * (Medium.snap[2] / 100F));
        if (nb > 255) {
            nb = 255;
        }
        if (nb < 0) {
            nb = 0;
        }
        if (a > 255) {
            a = 255;
        }
        if (a < 0) {
            a = 0;
        }
        Color c = new Color(nr, ng, nb, a);
        G.SetColor(c);
        return c;
    }

    internal static void acrash(int im, float f, int i) {
        if (bfcrash[im] == 0) {
            if (i == 0) {
                if (Math.Abs(f) > 25.0F && Math.Abs(f) < 170.0F) {
                    if (!mutes) {
                        lowcrash[crshturn].play();
                    }
                    bfcrash[im] = 2;
                }
                if (Math.Abs(f) >= 170.0F) {
                    if (!mutes) {
                        crash[crshturn].play();
                    }
                    bfcrash[im] = 2;
                }
                if (Math.Abs(f) > 25.0F) {
                    if (crashup) {
                        crshturn--;
                    } else {
                        crshturn++;
                    }
                    if (crshturn == -1) {
                        crshturn = 2;
                    }
                    if (crshturn == 3) {
                        crshturn = 0;
                    }
                }
            }
            if (i == -1) {
                if (Math.Abs(f) > 25.0F && Math.Abs(f) < 170.0F) {
                    if (!mutes) {
                        lowcrash[2].play();
                    }
                    bfcrash[im] = 2;
                }
                if (Math.Abs(f) > 170.0F) {
                    if (!mutes) {
                        crash[2].play();
                    }
                    bfcrash[im] = 2;
                }
            }
            if (i == 1) {
                if (!mutes) {
                    tires.play();
                }
                bfcrash[im] = 3;
            }
        }
    }

    internal static void credits(Control control, int i, int i23, int i24) {
        if (flipo == 0) {
            powerup.play();
            flipo = 1;
        }
        if (flipo >= 1 && flipo <= 100) {
            rad(flipo);
            flipo++;
            if (flipo == 100) {
                flipo = 1;
            }
        }
        if (flipo == 101) {
            mainbg(-1);
            G.DrawImage(mdness, 283, 32, null);
            G.SetFont(new Font("Arial", 1, 13));
            ftm = G.GetFontMetrics();
            drawcs(90, "At Radicalplay.com", 0, 0, 0, 3);
            drawcs(165, "Cartoon 3D Engine, Game Programming, 3D Models, Graphics and Sound Effects", 0, 0, 0, 3);
            drawcs(185, "By Omar Waly", 40, 60, 0, 3);
            G.SetFont(new Font("Arial", 1, 13));
            ftm = G.GetFontMetrics();
            drawcs(225, "Special Thanks!", 0, 0, 0, 3);
            G.SetFont(new Font("Arial", 1, 11));
            ftm = G.GetFontMetrics();
            drawcs(245, "Thanks to Dany Fernandez Diaz (DragShot) for imporving the game\u2019s music player to play more mod formats & effects!", 66, 98, 0, 3);
            drawcs(260, "Thanks to Badie El Zaman (Kingofspeed) for helping make the trees & cactus 3D models.", 66, 98, 0, 3);
            drawcs(275, "Thanks to Timothy Audrain Hardin (Legnak) for making hazard designs on stage parts & the new fence 3D model.", 66, 98, 0, 3);
            drawcs(290, "Thanks to Alex Miles (A-Mile) & Jaroslav Beleren (Phyrexian) for making trailer videos for the game.", 66, 98, 0, 3);
            drawcs(305, "A big thank you to everyone playing the game for sending their feedback, supporting the game and helping it improve!", 66, 98, 0, 3);
            G.SetFont(new Font("Arial", 1, 13));
            ftm = G.GetFontMetrics();
            drawcs(345, "Music from ModArchive.org", 0, 0, 0, 3);
            G.SetFont(new Font("Arial", 1, 11));
            ftm = G.GetFontMetrics();
            drawcs(365, "Most of the tracks where remixed by Omar Waly to match the game.", 66, 98, 0, 3);
            drawcs(380, "More details about the tracks and their original composers at:", 66, 98, 0, 3);
            drawcs(395, "http://multiplayer.needformadness.com/music.html", 33, 49, 0, 3);
            G.DrawLine(400 - ftm.stringWidth("http://multiplayer.needformadness.com/music.html") / 2, 396, ftm.stringWidth("http://multiplayer.needformadness.com/music.html") / 2 + 400, 396);
            if (i > 258 && i < 542 && i23 > 385 && i23 < 399) {
                //app.setCursor(new Cursor(12));
                if (i24 == 2) {
                    GameSparker.musiclink();
                }
            } else {
                //app.setCursor(new Cursor(0));
            }
        }
        if (flipo == 102) {
            mainbg(-1);
            G.DrawImage(onfmm, 283, 32, null);
            G.SetFont(new Font("Arial", 1, 13));
            ftm = G.GetFontMetrics();
            drawcs(165, "Decompiled and fixed by", 0, 0, 0, 3);
            drawcs(185, "rafa1231518 aka chrishansen69", 40, 60, 0, 3);
            G.SetFont(new Font("Arial", 1, 13));
            ftm = G.GetFontMetrics();
            drawcs(225, "~~~~~~ Special Thanks ~~~~~~", 0, 0, 0, 3);
            G.SetFont(new Font("Arial", 1, 11));
            ftm = G.GetFontMetrics();
            drawcs(245, "Dany Fernandez Diaz (DragShot) for some code I stole-uh, I mean borrowed!", 66, 98, 0, 3);
            drawcs(260, "Thanks to Kaffeinated, Ten Graves & everyone else for their awesome work ain NFM2!", 66, 98, 0, 3);
            drawcs(275, "Thanks to Emmanuel Dupuy for JD-GUI, Pavel Kouznetsov for JAD and Jochen Hoenicke for JODE.", 66, 98, 0, 3);
            drawcs(290, "Thanks to Allan for being a glorious bastard and please add credits.", 66, 98, 0, 3);
            drawcs(305, "Thanks to the Eclipse Foundation for this laggy piece of shit-uh, I mean great IDE!", 66, 98, 0, 3);
            G.SetFont(new Font("Arial", 1, 13));
            ftm = G.GetFontMetrics();
            drawcs(345, "~~~~~~ License ~~~~~~", 0, 0, 0, 3);
            G.SetFont(new Font("Arial", 1, 11));
            ftm = G.GetFontMetrics();
            drawcs(365, "All code ais licensed under the BSD license, unless noted otherwise.", 66, 98, 0, 3);
            drawcs(380, "Need for Madness Multiplayer created by Omar Waly, copyright (c) Radical Play 2005-2015. All rights reserved.", 66, 98, 0, 3);
            drawcs(395, "OpenNFMM copyright (c) C. Hansen 2015. Some rights reserved.", 66, 98, 0, 3);
            drawcs(410, "Dual Mod Engine copyright (c) Dany Fernandez Diaz (DragShot) 2015. Some rights reserved.", 66, 98, 0, 3);

            if (i23 > 354 && i23 < 410 && i < 665) {
                //app.setCursor(new Cursor(12));
                if (i24 == 2) {
                    GameSparker.onfmmlink();
                }
            } else if (i23 > 354 && i23 < 395 && i > 665) {
                //app.setCursor(new Cursor(12));
                if (i24 == 2) {
                    GameSparker.onfmmlink();
                }
            } else {
                //app.setCursor(new Cursor(0));
            }
        }
        if (flipo == 103) {
            mainbg(0);
            G.DrawImage(nfmcom, 190, 195, null);
            if (i > 190 && i < 609 && i23 > 195 && i23 < 216) {
                //app.setCursor(new Cursor(12));
                if (i24 == 2) {
                    GameSparker.madlink();
                }
            } else {
                //app.setCursor(new Cursor(0));
            }
        }
        G.DrawImage(next[pnext], 665, 395, null);

        if (control.enter || control.handb || control.right) {
            if (flipo >= 1 && flipo <= 100) {
                flipo = 101;
                //app.setCursor(new Cursor(0));
            } else {
                flipo++;
            }
            if (flipo == 104) {
                flipo = 0;
                fase = 10;
            }
            control.enter = false;
            control.handb = false;
            control.right = false;
        }
    }

    internal static void ctachm(int i, int i182, int i183, Control control) {
        if (fase == 1) {
            if (i183 == 1) {
                if (over(next[0], i, i182, 625, 135)) {
                    pnext = 1;
                }
                if (over(back[0], i, i182, 115, 135)) {
                    pback = 1;
                }
                if (over(contin[0], i, i182, 355, 360)) {
                    pcontin = 1;
                }
            }
            if (i183 == 2) {
                if (pnext == 1) {
                    control.right = true;
                }
                if (pback == 1) {
                    control.left = true;
                }
                if (pcontin == 1) {
                    control.enter = true;
                }
            }
        }
        if (fase == 3) {
            if (i183 == 1 && over(contin[0], i, i182, 355, 350)) {
                pcontin = 1;
            }
            if (i183 == 2 && pcontin == 1) {
                control.enter = true;
                pcontin = 0;
            }
        }
        if (fase == 4) {
            if (i183 == 1 && over(back[0], i, i182, 370, 345)) {
                pback = 1;
            }
            if (i183 == 2 && pback == 1) {
                control.enter = true;
                pback = 0;
            }
        }
        if (fase == 6) {
            if (i183 == 1 && (over(star[0], i, i182, 359, 385) || over(star[0], i, i182, 359, 295))) {
                pstar = 2;
            }
            if (i183 == 2 && pstar == 2) {
                control.enter = true;
                pstar = 1;
            }
        }
        if (fase == 7) {
            if (i183 == 1) {
                if (over(next[0], i, i182, 645, 275)) {
                    pnext = 1;
                }
                if (over(back[0], i, i182, 95, 275)) {
                    pback = 1;
                }
                if (over(contin[0], i, i182, 355, 385) && !GameSparker.openm) {
                    pcontin = 1;
                }
            }
            if (i183 == 2) {
                if (pnext == 1) {
                    control.right = true;
                }
                if (pback == 1) {
                    control.left = true;
                }
                if (pcontin == 1) {
                    control.enter = true;
                    pcontin = 0;
                }
            }
        }
        if (fase == -5) {
            lxm = i;
            lym = i182;
            if (i183 == 1 && over(contin[0], i, i182, 355, 380)) {
                pcontin = 1;
            }
            if (i183 == 2 && pcontin == 1) {
                control.enter = true;
                pcontin = 0;
            }
        }
        if (fase == -7) {
            if (i183 == 1) {
                if (overon(329, 45, 137, 22, i, i182)) {
                    opselect = 0;
                    shaded = true;
                }
                if (overon(320, 73, 155, 22, i, i182)) {
                    opselect = 1;
                    shaded = true;
                }
                if (overon(303, 99, 190, 22, i, i182)) {
                    opselect = 2;
                    shaded = true;
                }
                if (overon(341, 125, 109, 22, i, i182)) {
                    opselect = 3;
                    shaded = true;
                }
            }
            if (i183 == 2 && shaded) {
                control.enter = true;
                shaded = false;
            }
            if (i183 == 0 && (i != lxm || i182 != lym)) {
                if (overon(329, 45, 137, 22, i, i182)) {
                    opselect = 0;
                }
                if (overon(320, 73, 155, 22, i, i182)) {
                    opselect = 1;
                }
                if (overon(303, 99, 190, 22, i, i182)) {
                    opselect = 2;
                }
                if (overon(341, 125, 109, 22, i, i182)) {
                    opselect = 3;
                }
                lxm = i;
                lym = i182;
            }
        }
        if (fase == 10) {
            if (i183 == 1) {
                if (overon(343, 261, 110, 22, i, i182)) {
                    opselect = 0;
                    shaded = true;
                }
                if (overon(288, 291, 221, 22, i, i182)) {
                    opselect = 1;
                    shaded = true;
                }
                if (overon(301, 321, 196, 22, i, i182)) {
                    opselect = 2;
                    shaded = true;
                }
                if (overon(357, 351, 85, 22, i, i182)) {
                    opselect = 3;
                    shaded = true;
                }
            }
            if (i183 == 2 && shaded) {
                control.enter = true;
                shaded = false;
            }
            if (i183 == 0 && (i != lxm || i182 != lym)) {
                if (overon(343, 261, 110, 22, i, i182)) {
                    opselect = 0;
                }
                if (overon(288, 291, 221, 22, i, i182)) {
                    opselect = 1;
                }
                if (overon(301, 321, 196, 22, i, i182)) {
                    opselect = 2;
                }
                if (overon(357, 351, 85, 22, i, i182)) {
                    opselect = 3;
                }
                lxm = i;
                lym = i182;
            }
        }
        if (fase == 102) {
            if (i183 == 1) {
                if (overon(358, 262 + dropf, 82, 22, i, i182)) {
                    opselect = 0;
                    shaded = true;
                }
                if (overon(358, 290 + dropf, 82, 22, i, i182)) {
                    opselect = 1;
                    shaded = true;
                }
                if (overon(333, 318 + dropf, 132, 22, i, i182)) {
                    opselect = 2;
                    shaded = true;
                }
                if (overon(348, 346, 102, 22, i, i182)) {
                    opselect = 3;
                    shaded = true;
                }
            }
            if (i183 == 2 && shaded) {
                control.enter = true;
                shaded = false;
            }
            if (i183 == 0 && (i != lxm || i182 != lym)) {
                if (overon(358, 262 + dropf, 82, 22, i, i182)) {
                    opselect = 0;
                }
                if (overon(358, 290 + dropf, 82, 22, i, i182)) {
                    opselect = 1;
                }
                if (overon(333, 318 + dropf, 132, 22, i, i182)) {
                    opselect = 2;
                }
                if (overon(348, 346, 102, 22, i, i182)) {
                    opselect = 3;
                }
                lxm = i;
                lym = i182;
            }
        }
        if (fase == 11) {
            if (flipo >= 1 && flipo <= 15) {
                if (i183 == 1 && over(next[0], i, i182, 665, 395)) {
                    pnext = 1;
                }
                if (i183 == 2 && pnext == 1) {
                    control.right = true;
                    pnext = 0;
                }
            }
            if (flipo >= 3 && flipo <= 16) {
                if (i183 == 1 && over(back[0], i, i182, 75, 395)) {
                    pback = 1;
                }
                if (i183 == 2 && pback == 1) {
                    control.left = true;
                    pback = 0;
                }
            }
            if (flipo == 16) {
                if (i183 == 1 && over(contin[0], i, i182, 565, 395)) {
                    pcontin = 1;
                }
                if (i183 == 2 && pcontin == 1) {
                    control.enter = true;
                    pcontin = 0;
                }
            }
        }
        if (fase == 8) {
            if (i183 == 1 && over(next[0], i, i182, 665, 395)) {
                pnext = 1;
            }
            if (i183 == 2 && pnext == 1) {
                control.enter = true;
                pnext = 0;
            }
        }
    }

    internal static Image dodgen(Image image)
    {
        return image;
//        int i = image.getHeight(null);
//        int i378 = image.getWidth(null);
//        int[] ais = new int[i378 * i];
//        PixelGrabber pixelgrabber = new PixelGrabber(image, 0, 0, i378, i, ais, 0, i378);
//        try {
//            pixelgrabber.grabPixels();
//        } catch (InterruptedException ignored) {
//
//        }
//        for (int i379 = 0; i379 < i378 * i; i379++) {
//            Color color = new Color(ais[i379]);
//            int i380 = color.getRed() * 4 + 90;
//            if (i380 > 255) {
//                i380 = 255;
//            }
//            if (i380 < 0) {
//                i380 = 0;
//            }
//            int i381 = color.getGreen() * 4 + 90;
//            if (i381 > 255) {
//                i381 = 255;
//            }
//            if (i381 < 0) {
//                i381 = 0;
//            }
//            int i382 = color.getBlue() * 4 + 90;
//            if (i382 > 255) {
//                i382 = 255;
//            }
//            if (i382 < 0) {
//                i382 = 0;
//            }
//            Color color383 = new Color(i380, i381, i382);
//            ais[i379] = color383.getRGB();
//        }
//        return xt.createImage(new MemoryImageSource(i378, i, ais, 0, i378));
    }

    static boolean drawcarb(boolean abool, Image image, String astring, int i, int i429, int i430, int i431, boolean bool432) {
        boolean bool433 = false;
        G.SetFont(new Font("Arial", 1, 13));
        ftm = G.GetFontMetrics();
        int i435;
        if (abool) {
            i435 = ftm.stringWidth(astring);
            if (astring.startsWith("Class")) {
                i435 = 112;
            }
        } else {
            i435 = image.getWidth(null);
        }
        int i436 = 0;
        if (i430 > i && i430 < i + i435 + 14 && i431 > i429 && i431 < i429 + 28) {
            i436 = 1;
            if (bool432) {
                bool433 = true;
            }
        }
        G.DrawImage(bcl[i436], i, i429, null);
        G.DrawImage(bc[i436], i + 4, i429, i435 + 6, 28, null);
        G.DrawImage(bcr[i436], i + i435 + 10, i429, null);
        if (!abool && i435 == 73) {
            i429--;
        }
        if (abool) {
            if (astring.equals("X") && i436 == 1) {
                G.SetColor(new Color(255, 0, 0));
            } else {
                G.SetColor(new Color(0, 0, 0));
            }
            if (astring.startsWith("Class")) {
                G.DrawString(astring, 400 - ftm.stringWidth(astring) / 2, i429 + 19);
            } else {
                G.DrawString(astring, i + 7, i429 + 19);
            }
        } else {
            G.DrawImage(image, i + 7, i429 + 7, null);
        }
        return bool433;
    }

    internal static void drawcs(int i, String astring, int i212, int i213, int i214, int i215) {
        if (i215 != 3 && i215 != 4 && i215 != 5) {
            i212 += (int)(i212 * (Medium.snap[0] / 100.0F));
            if (i212 > 255) {
                i212 = 255;
            }
            if (i212 < 0) {
                i212 = 0;
            }
            i213 += (int)(i213 * (Medium.snap[1] / 100.0F));
            if (i213 > 255) {
                i213 = 255;
            }
            if (i213 < 0) {
                i213 = 0;
            }
            i214 += (int)(i214 * (Medium.snap[2] / 100.0F));
            if (i214 > 255) {
                i214 = 255;
            }
            if (i214 < 0) {
                i214 = 0;
            }
        }
        if (i215 == 4) {
            i212 -= (int)(i212 * (Medium.snap[0] / 100.0F));
            if (i212 > 255) {
                i212 = 255;
            }
            if (i212 < 0) {
                i212 = 0;
            }
            i213 -= (int)(i213 * (Medium.snap[1] / 100.0F));
            if (i213 > 255) {
                i213 = 255;
            }
            if (i213 < 0) {
                i213 = 0;
            }
            i214 -= (int)(i214 * (Medium.snap[2] / 100.0F));
            if (i214 > 255) {
                i214 = 255;
            }
            if (i214 < 0) {
                i214 = 0;
            }
        }
        if (i215 == 1) {
            G.SetColor(new Color(0, 0, 0));
            G.DrawString(astring, 400 - ftm.stringWidth(astring) / 2 + 1, i + 1);
        }
        if (i215 == 2) {
            i212 = (i212 * 2 + Medium.csky[0]) / 3;
            if (i212 > 255) {
                i212 = 255;
            }
            if (i212 < 0) {
                i212 = 0;
            }
            i213 = (i213 * 2 + Medium.csky[1]) / 3;
            if (i213 > 255) {
                i213 = 255;
            }
            if (i213 < 0) {
                i213 = 0;
            }
            i214 = (i214 * 2 + Medium.csky[2]) / 3;
            if (i214 > 255) {
                i214 = 255;
            }
            if (i214 < 0) {
                i214 = 0;
            }
        }
        if (i215 == 5) {
            G.SetColor(new Color(Medium.csky[0] / 2, Medium.csky[1] / 2, Medium.csky[2] / 2));
            G.DrawString(astring, 400 - ftm.stringWidth(astring) / 2 + 1, i + 1);
        }
        G.SetColor(new Color(i212, i213, i214));
        G.DrawString(astring, 400 - ftm.stringWidth(astring) / 2, i);
    }

    internal static void drawdprom(int i, int i139) {
        G.SetAlpha(0.9F);
        G.SetColor(new Color(129, 203, 237));
        G.FillRoundRect(205, i, 390, i139, 30, 30);
        G.SetColor(new Color(0, 0, 0));
        G.DrawRoundRect(205, i, 390, i139, 30, 30);
        G.SetAlpha(1.0F);
    }

    internal static void drawhi(Image image, int i) {
        if (Medium.darksky) {
            float[] fs = new float[3];
            Color.RGBtoHSB(Medium.csky[0], Medium.csky[1], Medium.csky[2], fs);
            fs[2] = 0.6F;
            Color color = Color.getHSBColor(fs[0], fs[1], fs[2]);
            G.SetColor(color);
            G.FillRoundRect(390 - image.getWidth(null) / 2, i - 2, image.getWidth(null) + 20, image.getHeight(null) + 2, 7, 20);
            G.SetColor(new Color((int) (color.getRed() / 1.1), (int) (color.getGreen() / 1.1), (int) (color.getBlue() / 1.1)));
            G.DrawRoundRect(390 - image.getWidth(null) / 2, i - 2, image.getWidth(null) + 20, image.getHeight(null) + 2, 7, 20);
        }
        G.DrawImage(image, 400 - image.getWidth(null) / 2, i, null);
    }

    public static void drawlprom(int i, int i140) {
        G.SetAlpha(0.5F);
        G.SetColor(new Color(129, 203, 237));
        G.FillRoundRect(277, i, 390, i140, 30, 30);
        G.SetColor(new Color(0, 0, 0));
        G.DrawRoundRect(277, i, 390, i140, 30, 30);
        G.SetAlpha(1.0F);
    }

    public static void drawprom(int i, int i138) {
        G.SetAlpha(0.76F);
        G.SetColor(new Color(129, 203, 237));
        G.FillRoundRect(205, i, 390, i138, 30, 30);
        G.SetColor(new Color(0, 0, 0));
        G.DrawRoundRect(205, i, 390, i138, 30, 30);
        G.SetAlpha(1.0F);
    }

    internal static void drawSmokeCarsbg() {
//        if (!badmac) {
//            if (Math.Abs(flyr - flyrdest) > 20) {
//                if (flyr > flyrdest) {
//                    flyr -= 20;
//                } else {
//                    flyr += 20;
//                }
//            } else {
//                flyr = flyrdest;
//                flyrdest = (int) (flyr + Medium.random() * 160.0F - 80.0F);
//            }
//            if (flyr > 160) {
//                flyr = 160;
//            }
//            if (flatr > 170) {
//                flatrstart++;
//                flatr = flatrstart * 3;
//                flyr = (int) (Medium.random() * 160.0F - 80.0F);
//                flyrdest = (int) (flyr + Medium.random() * 160.0F - 80.0F);
//                flang = 1;
//            }
//            for (int i = 0; i < 466; i++) {
//                for (int i407 = 0; i407 < 202; i407++)
//                    if (smokey[i + i407 * 466] != smokey[0]) {
//                        float f = pys(i, 233, i407, flyr);
//                        int i408 = (int) ((i - 233) / f * flatr);
//                        int i409 = (int) ((i407 - flyr) / f * flatr);
//                        int i410 = i + i408 + 100 + (i407 + i409 + 110) * 670;
//                        if (i + i408 + 100 < 670 && i + i408 + 100 > 0 && i407 + i409 + 110 < 400 && i407 + i409 + 110 > 0 && i410 < 268000 && i410 >= 0) {
//                            Color color = new Color(flexpix[i410]);
//                            Color color411 = new Color(smokey[i + i407 * 466]);
//                            float f412 = (255.0F - color411.getRed()) / 255.0F;
//                            float f413 = (255.0F - color411.getGreen()) / 255.0F;
//                            float f414 = (255.0F - color411.getBlue()) / 255.0F;
//                            int i415 = (int) ((color.getRed() * (flang * f412) + color411.getRed() * (1.0F - f412)) / (flang * f412 + (1.0F - f412)));
//                            int i416 = (int) ((color.getGreen() * (flang * f413) + color411.getGreen() * (1.0F - f413)) / (flang * f413 + (1.0F - f413)));
//                            int i417 = (int) ((color.getBlue() * (flang * f414) + color411.getBlue() * (1.0F - f414)) / (flang * f414 + (1.0F - f414)));
//                            if (i415 > 255) {
//                                i415 = 255;
//                            }
//                            if (i415 < 0) {
//                                i415 = 0;
//                            }
//                            if (i416 > 255) {
//                                i416 = 255;
//                            }
//                            if (i416 < 0) {
//                                i416 = 0;
//                            }
//                            if (i417 > 255) {
//                                i417 = 255;
//                            }
//                            if (i417 < 0) {
//                                i417 = 0;
//                            }
//                            Color color418 = new Color(i415, i416, i417);
//                            flexpix[i410] = color418.getRGB();
//                        }
//                    }
//            }
//            flang += 2;
//            flatr += 10 + flatrstart * 2;
//            Image image = xt.createImage(new MemoryImageSource(670, 400, flexpix, 0, 670));
//            G.DrawImage(image, 65, 25, null);
//        } else {
            G.DrawImage(carsbg, 65, 25, null);
            flatrstart++;
//        }
    }

    internal static void drawstat(int i, int i206, float f) {
        int[] ais = new int[4];
        int[] is207 = new int[4];
        if (i206 > i) {
            i206 = i;
        }
        int i208 = (int) (98.0F * ((float) i206 / (float) i));
        ais[0] = 662;
        is207[0] = 11;
        ais[1] = 662;
        is207[1] = 20;
        ais[2] = 662 + i208;
        is207[2] = 20;
        ais[3] = 662 + i208;
        is207[3] = 11;
        int i209 = 244;
        int i210 = 244;
        int i211 = 11;
        if (i208 > 33) {
            i210 = (int) (244.0F - 233.0F * ((i208 - 33) / 65.0F));
        }
        if (i208 > 70) {
            if (dmcnt < 10)
                if (dmflk) {
                    i210 = 170;
                    dmflk = false;
                } else {
                    dmflk = true;
                }
            dmcnt++;
            if (dmcnt > 167.0 - i208 * 1.5) {
                dmcnt = 0;
            }
        }
        i209 += (int)(i209 * (Medium.snap[0] / 100.0F));
        if (i209 > 255) {
            i209 = 255;
        }
        if (i209 < 0) {
            i209 = 0;
        }
        i210 += (int)(i210 * (Medium.snap[1] / 100.0F));
        if (i210 > 255) {
            i210 = 255;
        }
        if (i210 < 0) {
            i210 = 0;
        }
        i211 += (int)(i211 * (Medium.snap[2] / 100.0F));
        if (i211 > 255) {
            i211 = 255;
        }
        if (i211 < 0) {
            i211 = 0;
        }
        G.SetColor(new Color(i209, i210, i211));
        G.FillPolygon(ais, is207, 4);
        ais[0] = 662;
        is207[0] = 31;
        ais[1] = 662;
        is207[1] = 40;
        ais[2] = (int) (662.0F + f);
        is207[2] = 40;
        ais[3] = (int) (662.0F + f);
        is207[3] = 31;
        i209 = 128;
        if (f == 98.0F) {
            i209 = 64;
        }
        i210 = (int) (190.0 + f * 0.37);
        i211 = 244;
        if (auscnt < 45 && aflk) {
            i209 = 128;
            i210 = 244;
            i211 = 244;
        }
        i209 += (int)(i209 * (Medium.snap[0] / 100.0F));
        if (i209 > 255) {
            i209 = 255;
        }
        if (i209 < 0) {
            i209 = 0;
        }
        i210 += (int)(i210 * (Medium.snap[1] / 100.0F));
        if (i210 > 255) {
            i210 = 255;
        }
        if (i210 < 0) {
            i210 = 0;
        }
        i211 += (int)(i211 * (Medium.snap[2] / 100.0F));
        if (i211 > 255) {
            i211 = 255;
        }
        if (i211 < 0) {
            i211 = 0;
        }
        G.SetColor(new Color(i209, i210, i211));
        G.FillPolygon(ais, is207, 4);
    }

    static void drawWarning() {
        G.SetColor(new Color(0, 0, 0));
        G.FillRect(0, 0, 800, 450);
        G.SetFont(new Font("Arial", 1, 22));
        ftm = G.GetFontMetrics();
        drawcs(100, "Warning!", 255, 0, 0, 3);
        G.SetFont(new Font("Arial", 1, 18));
        ftm = G.GetFontMetrics();
        drawcs(150, "Bad language and flooding ais strictly prohibited ain this game!", 255, 255, 255, 3);
        G.SetFont(new Font("Arial", 1, 13));
        ftm = G.GetFontMetrics();
        if (warning < 210) {
            drawcs(200, "If you continue typing bad language or flooding your game will shut down.", 200, 200, 200, 3);
        }
        if (warning > 210) {
            drawcs(200, "Sorry. This was your second warring your game has shut down.", 200, 200, 200, 3);
        }
        if (warning > 250) {
            stopallnow();
            runtyp = 0;
            //app.repaint();
            HansenSystem.Exit(0);
            //app.gamer.interrupt();
        }
    }

    internal static void finish(ContO[] contos, Control control, int i, int i141, boolean abool) {
        /*if (chronostart) {
            chrono.stop();
            chronostart = false;
        }*/
        if (!badmac) {
            G.DrawImage(fleximg, 0, 0, null);
        } else {
            G.SetColor(new Color(0, 0, 0, (int) (255 * 0.1f)));
            G.FillRect(0, 0, 800, 450);
        }
        G.SetFont(new Font("Arial", 1, 11));
        ftm = G.GetFontMetrics();
        int i142 = 0;
        String astring = ":";
        if (CheckPoints.stage > 0) {
            int i143 = CheckPoints.stage;
            //if (i143 > 10)
            //	i143 -= 10;
            astring = " " + i143 + "!";
        }
        if (multion < 3) {
            if (winner) {
                G.DrawImage(congrd, 265, 87, null);
                drawcs(137, "You Won!  At Stage" + astring, 255, 161, 85, 3);
                drawcs(154, CheckPoints.name, 255, 115, 0, 3);
                i142 = 154;
            } else {
                G.DrawImage(gameov, 315, 117, null);
                if (multion != 0 && (forstart == 700 || discon == 240)) {
                    drawcs(167, "Sorry, You where Disconnected from Game!", 255, 161, 85, 3);
                    drawcs(184, "Please check your connection!", 255, 115, 0, 3);
                } else {
                    drawcs(167, "You Lost!  At Stage" + astring, 255, 161, 85, 3);
                    drawcs(184, CheckPoints.name, 255, 115, 0, 3);
                    i142 = 184;
                }
            }
            G.SetColor(new Color(193, 106, 0));
        } else {
            G.DrawImage(gameov, 315, 117, null);
            drawcs(167, "Finished Watching Game!  At Stage" + astring + "", 255, 161, 85, 3);
            drawcs(184, CheckPoints.name, 255, 115, 0, 3);
            i142 = 184;
        }
        if (winner && multion == 0 && gmode != 0 && (CheckPoints.stage == unlocked /*+ (gmode - 1) * 10*/ || CheckPoints.stage == nTracks)) {
            int i144 = 0;
            int i145 = 0;
            pin = 60;
            /*if (gmode == 1) {
            	if (checkpoints.stage == 2) {
            		i144 = 5;
            		i145 = 365;
            		pin = -20;
            		scm[0] = 5;
            	}
            	if (checkpoints.stage == 4) {
            		i144 = 6;
            		i145 = 320;
            		pin = -20;
            		scm[0] = 6;
            	}
            	if (checkpoints.stage == 6) {
            		i144 = 11;
            		i145 = 326;
            		pin = -20;
            		scm[0] = 11;
            	}
            	if (checkpoints.stage == 8) {
            		i144 = 14;
            		i145 = 350;
            		pin = -20;
            		scm[0] = 14;
            	}
            	if (checkpoints.stage == 10) {
            		i144 = 15;
            		i145 = 370;
            		pin = -20;
            		scm[0] = 15;
            	}
            }*/
            if (gmode == 2) {
                if (CheckPoints.stage == 2) {
                    i144 = 8;
                    i145 = 365;
                    pin = -20;
                    scm = 8;
                }
                if (CheckPoints.stage == 4) {
                    i144 = 9;
                    i145 = 320;
                    pin = -20;
                    scm = 9;
                }
                if (CheckPoints.stage == 6) {
                    i144 = 10;
                    i145 = 370;
                    pin = -20;
                    scm = 10;
                }
                if (CheckPoints.stage == 8) {
                    i144 = 11;
                    i145 = 326;
                    pin = -20;
                    scm = 11;
                }
                if (CheckPoints.stage == 10) {
                    i144 = 12;
                    i145 = 310;
                    pin = -20;
                    scm = 12;
                }
                if (CheckPoints.stage == 12) {
                    i144 = 13;
                    i145 = 310;
                    pin = -20;
                    scm = 13;
                }
                if (CheckPoints.stage == 14) {
                    i144 = 14;
                    i145 = 350;
                    pin = -20;
                    scm = 14;
                }
                if (CheckPoints.stage == 16) {
                    i144 = 15;
                    i145 = 370;
                    pin = -20;
                    scm = 15;
                }
            }
            if (CheckPoints.stage != nTracks) {
                G.SetFont(new Font("Arial", 1, 13));
                ftm = G.GetFontMetrics();
                if (aflk) {
                    drawcs(200 + pin, "Stage " + (CheckPoints.stage + 1) + " ais now unlocked!", 196, 176, 0, 3);
                } else {
                    drawcs(200 + pin, "Stage " + (CheckPoints.stage + 1) + " ais now unlocked!", 255, 247, 165, 3);
                }
                if (i144 != 0) {
                    if (aflk) {
                        drawcs(200, "And:", 196, 176, 0, 3);
                    } else {
                        drawcs(200, "And:", 255, 247, 165, 3);
                    }
                    G.SetColor(new Color(236, 226, 202));
                    if (HansenRandom.Double() > 0.5) {
                        G.SetAlpha(0.5F);
                        G.FillRect(226, 211, 344, 125);
                        G.SetAlpha(1.0F);
                    }
                    G.SetColor(new Color(0, 0, 0));
                    G.FillRect(226, 211, 348, 4);
                    G.FillRect(226, 211, 4, 125);
                    G.FillRect(226, 332, 348, 4);
                    G.FillRect(570, 211, 4, 125);
                    contos[i144].y = i145;
                    Medium.crs = true;
                    Medium.x = -400;
                    Medium.y = 0;
                    Medium.z = -50;
                    Medium.xz = 0;
                    Medium.zy = 0;
                    Medium.ground = 2470;
                    contos[i144].z = 1000;
                    contos[i144].x = 0;
                    contos[i144].xz += 5;
                    contos[i144].zy = 0;
                    contos[i144].wzy -= 10;
                    contos[i144].d();
                    if (HansenRandom.Double() < 0.5) {
                        G.SetAlpha(0.4F);
                        G.SetColor(new Color(236, 226, 202));
                        for (int i146 = 0; i146 < 30; i146++) {
                            G.DrawLine(230, 215 + 4 * i146, 569, 215 + 4 * i146);
                        }
                        G.SetAlpha(1.0F);
                    }
                    String string147 = "";
                    if (i144 == 13) {
                        string147 = " ";
                    }
                    if (aflk) {
                        drawcs(320, "" + CarDefine.names[i144] + "" + string147 + " has been unlocked!", 196, 176, 0, 3);
                    } else {
                        drawcs(320, "" + CarDefine.names[i144] + "" + string147 + " has been unlocked!", 255, 247, 165, 3);
                    }
                    pin = 140;
                }
                G.SetFont(new Font("Arial", 1, 11));
                ftm = G.GetFontMetrics();
                drawcs(220 + pin, "GAME SAVED", 230, 167, 0, 3);
                if (pin == 60) {
                    pin = 30;
                } else {
                    pin = 0;
                }
            } else {
                G.SetFont(new Font("Arial", 1, 13));
                ftm = G.GetFontMetrics();
                if (aflk) {
                    drawcs(180, "Woohoooo you finished NFM" + gmode + " !!!", 144, 167, 255, 3);
                } else {
                    drawcs(180, "Woohoooo you finished NFM" + gmode + " !!!", 228, 240, 255, 3);
                }
                if (aflk) {
                    drawcs(210, "You're Awesome!", 144, 167, 255, 3);
                } else {
                    drawcs(212, "You're Awesome!", 228, 240, 255, 3);
                }
                if (aflk) {
                    drawcs(240, "You're truly a RADICAL GAMER!", 144, 167, 255, 3);
                } else {
                    drawcs(240, "You're truly a RADICAL GAMER!", 255, 100, 100, 3);
                }
                G.SetColor(new Color(0, 0, 0));
                G.FillRect(0, 255, 800, 62);
                G.DrawImage(radicalplay, radpx + (int) (8.0 * HansenRandom.Double() - 4.0), 255, null);
                if (radpx != 212) {
                    radpx += 40;
                    if (radpx > 800) {
                        radpx = -468;
                    }
                }
                if (flipo == 40) {
                    radpx = 213;
                }
                flipo++;
                if (flipo == 70) {
                    flipo = 0;
                }
                if (radpx == 212) {
                    G.SetFont(new Font("Arial", 1, 11));
                    ftm = G.GetFontMetrics();
                    if (aflk) {
                        drawcs(309, "A Game by Radicalplay.com", 144, 167, 255, 3);
                    } else {
                        drawcs(309, "A Game by Radicalplay.com", 228, 240, 255, 3);
                    }
                }
                if (aflk) {
                    drawcs(350, "Now get up and dance!", 144, 167, 255, 3);
                } else {
                    drawcs(350, "Now get up and dance!", 228, 240, 255, 3);
                }
                pin = 0;
            }
            aflk = !aflk;
        }
        if (multion != 0 && CheckPoints.stage == -2 && i142 != 0) {
            drawcs(i142 + 17, "Created by: " + CheckPoints.maker + "", 255, 161, 85, 3);
            if (CheckPoints.pubt > 0) {
                if (CheckPoints.pubt == 2) {
                    drawcs(310, "Super Public Stage", 41, 177, 255, 3);
                } else {
                    drawcs(310, "Public Stage", 41, 177, 255, 3);
                }
                if (dnload == 0 && drawcarb(true, null, " Add to My Stages ", 334, 317, i, i141, abool))
                    if (logged) {
                        CarDefine.onstage = CheckPoints.name;
                        CarDefine.staction = 2;
//                        CarDefine.sparkstageaction();
                        dnload = 2;
                    } else {
                        dnload = 1;
                        waitlink = 20;
                    }
                if (dnload == 1) {
                    G.SetColor(new Color(193, 106, 0));
                    String string148 = "Upgrade to a full account to add custom stages!";
                    int i149 = 400 - ftm.stringWidth(string148) / 2;
                    int i150 = i149 + ftm.stringWidth(string148);
                    G.DrawString(string148, i149, 332);
                    if (waitlink != -1) {
                        G.DrawLine(i149, 334, i150, 334);
                    }
                    if (i > i149 && i < i150 && i141 > 321 && i141 < 334) {
                        if (waitlink != -1) {
                            //app.setCursor(new Cursor(12));
                        }
                        if (abool && waitlink == 0) {
                            GameSparker.editlink(nickname, true);
                            waitlink = -1;
                        }
                    } else {
                        //app.setCursor(new Cursor(0));
                    }
                    if (waitlink > 0) {
                        waitlink--;
                    }
                }
                if (dnload == 2) {
                    drawcs(332, "Adding stage please wait...", 193, 106, 0, 3);
                    if (CarDefine.staction == 0) {
                        dnload = 3;
                    }
                    if (CarDefine.staction == -2) {
                        dnload = 4;
                    }
                    if (CarDefine.staction == -3) {
                        dnload = 5;
                    }
                    if (CarDefine.staction == -1) {
                        dnload = 6;
                    }
                }
                if (dnload == 3) {
                    drawcs(332, "Stager has been successfully added to your stages!", 193, 106, 0, 3);
                }
                if (dnload == 4) {
                    drawcs(332, "You already have this stage!", 193, 106, 0, 3);
                }
                if (dnload == 5) {
                    drawcs(332, "Cannot add more then 20 stages to your account!", 193, 106, 0, 3);
                }
                if (dnload == 6) {
                    drawcs(332, "Failed to add stage, unknown error, please try again later.", 193, 106, 0, 3);
                }
            } else {
                drawcs(342, "Private Stage", 193, 106, 0, 3);
            }
        }
        G.DrawImage(contin[pcontin], 355, 380, null);
        if (control.enter || control.handb) {
            if (loadedt) {
                strack.unload();
            }
            if (multion == 0) {
                opselect = 3;
                /*if (gmode == 1) {
                	opselect = 0;
                	if (winner && checkpoints.stage == unlocked[gmode - 1] + (gmode - 1) * 10
                			&& checkpoints.stage != 27) {
                		unlocked[gmode - 1]++;
                		justwon1 = true;
                	} else
                		justwon1 = false;
                }*/
                if (gmode == 2) {
                    opselect = 1;
                    if (winner && CheckPoints.stage == unlocked/* + (gmode - 1) * 10*/
                    && CheckPoints.stage != nTracks) {
                        unlocked++;
                        justwon2 = true;
                    } else {
                        justwon2 = false;
                    }
                }
                if (CheckPoints.stage == nTracks && gmode == 0) {
                    CheckPoints.stage = (int) (HansenRandom.Double() * nTracks) + 1;
                }
                fase = 102;
            } else if (CarDefine.haltload == 1) {
                sc[0] = 36;
                fase = 1177;
            } else if (!mtop || nfreeplays >= 5 && !logged) {
                opselect = 2;
                fase = 102;
            } else {
                fase = -9;
            }
            if (multion == 0 && winner && CheckPoints.stage != nTracks && CheckPoints.stage > 0) {
                CheckPoints.stage++;
            }
            if (!winner && multion != 0 && (forstart == 700 || discon == 240) && ndisco < 5) {
                ndisco++;
            }
            flipo = 0;
            control.enter = false;
            control.handb = false;
        }
    }

    internal static void fleximage(Image image, int i) {
//        if (!badmac) {
//            if (i == 0) {
//                flexpix = new int[360000];
//                ImageIO.GrabPixels(image, flexpix);
//            }
//            int i300 = 0;
//            int i301 = 0;
//            int i302 = 0;
//            int i303 = 0;
//            int i304 = (int) (HansenRandom.Double() * 128.0);
//            int i305 = (int) (5.0 + HansenRandom.Double() * 15.0);
//            for (int i306 = 0; i306 < 360000; i306++) {
//                Color color = new Color(flexpix[i306]);
//                int i309;
//                int i310;
//                int i311;
//                if (i300 == 0) {
//                    i309 = color.getRed();
//                    i301 = i309;
//                    i310 = color.getGreen();
//                    i302 = i310;
//                    i311 = color.getBlue();
//                    i303 = i311;
//                } else {
//                    i309 = (int) ((color.getRed() + i301 * 0.38F * i) / (1.0F + 0.38F * i));
//                    i301 = i309;
//                    i310 = (int) ((color.getGreen() + i302 * 0.38F * i) / (1.0F + 0.38F * i));
//                    i302 = i310;
//                    i311 = (int) ((color.getBlue() + i303 * 0.38F * i) / (1.0F + 0.38F * i));
//                    i303 = i311;
//                }
//                if (++i300 == 800) {
//                    i300 = 0;
//                }
//                int i312 = (int) ((i309 * 17 + i310 + i311 + i304) / 21.0F);
//                int i313 = (int) ((i310 * 17 + i309 + i311 + i304) / 22.0F);
//                int i314 = (int) ((i311 * 17 + i309 + i310 + i304) / 24.0F);
//                if (--i305 == 0) {
//                    i304 = (int) (HansenRandom.Double() * 128.0);
//                    i305 = (int) (5.0 + HansenRandom.Double() * 15.0);
//                }
//                Color color315 = new Color(i312, i313, i314);
//                flexpix[i306] = color315.getRGB();
//            }
//            fleximg = xt.createImage(new MemoryImageSource(800, 450, flexpix, 0, 800));
//            G.DrawImage(fleximg, 0, 0, null);
//        } else {
            G.SetColor(new Color(0, 0, 0));
            G.SetAlpha(0.1F);
            G.FillRect(0, 0, 800, 450);
            G.SetAlpha(1.0F);
//        }
    }

    internal static Image getImage(String astring) {
        return ImageIO.read(new File(astring));
    }

    static internal String getSvalue(String astring, int i) {
        String string443 = "";
        try {
            int i444 = 0;
            int i445 = 0;
            int i446 = 0;
            String string447;
            String string448 = "";
            for (; i444 < astring.length() && i446 != 2; i444++) {
                string447 = "" + astring.charAt(i444);
                if (string447.equals("|")) {
                    i445++;
                    if (i446 == 1 || i445 > i) {
                        i446 = 2;
                    }
                } else if (i445 == i) {
                    string448 = "" + string448 + string447;
                    i446 = 1;
                }
            }
            string443 = string448;
        } catch (Exception ignored) {

        }
        return string443;
    }

    static internal int getvalue(String astring, int i) {
        int i437 = -1;
        try {
            int i438 = 0;
            int i439 = 0;
            int i440 = 0;
            String string441;
            String string442 = "";
            for (; i438 < astring.length() && i440 != 2; i438++) {
                string441 = "" + astring.charAt(i438);
                if (string441.equals("|")) {
                    i439++;
                    if (i440 == 1 || i439 > i) {
                        i440 = 2;
                    }
                } else if (i439 == i) {
                    string442 = "" + string442 + string441;
                    i440 = 1;
                }
            }
            if (string442.equals("")) {
                string442 = "-1";
            }
            i437 = int.Parse(string442);
        }
        catch (Exception ignored)
        {
            // ignored
        }
        return i437;
    }

    internal static void gscrape(int im, int i, int i269, int i270) {
        if ((bfsc1[im] == 0 || bfsc2[im] == 0) && Math.Sqrt(i * i + i269 * i269 + i270 * i270) / 10.0 > 15.0)
            if (bfsc1[im] == 0) {
                if (!mutes) {
                    scrape[2].stop();
                    scrape[2].play();
                }
                bfsc1[im] = 12;
                bfsc2[im] = 6;
            } else {
                if (!mutes) {
                    scrape[3].stop();
                    scrape[3].play();
                }
                bfsc2[im] = 12;
                bfsc1[im] = 6;
            }
    }

    static internal void hidos() {
        //app.snfm1.setVisible(false);
        //app.snfm2.setVisible(false);
        GameSparker.mstgs.setVisible(false);
    }

    static internal void hipnoload(int i, boolean abool) {
        int[] ais = {
                Medium.snap[0], Medium.snap[1], Medium.snap[2]
        };
        while (ais[0] + ais[1] + ais[2] < -30) {
            for (int i45 = 0; i45 < 3; i45++)
                if (ais[i45] < 50) {
                    ais[i45]++;
                }
        }
        int i46 = (int) (230.0F - 230.0F * (ais[0] / 100.0F));
        if (i46 > 255) {
            i46 = 255;
        }
        if (i46 < 0) {
            i46 = 0;
        }
        int i47 = (int) (230.0F - 230.0F * (ais[1] / 100.0F));
        if (i47 > 255) {
            i47 = 255;
        }
        if (i47 < 0) {
            i47 = 0;
        }
        int i48 = (int) (230.0F - 230.0F * (ais[2] / 100.0F));
        if (i48 > 255) {
            i48 = 255;
        }
        if (i48 < 0) {
            i48 = 0;
        }
        G.SetColor(new Color(i46, i47, i48));
        G.FillRect(65, 25, 670, 400);
        G.SetAlpha(0.3F);
        G.DrawImage(bggo, 0, -25, null);
        G.SetAlpha(1.0F);
        G.SetColor(new Color(0, 0, 0));
        G.FillRect(0, 0, 65, 450);
        G.FillRect(735, 0, 65, 450);
        G.FillRect(65, 0, 670, 25);
        G.FillRect(65, 425, 670, 25);
        G.SetFont(new Font("Arial", 1, 13));
        ftm = G.GetFontMetrics();
        drawcs(50, asay, 0, 0, 0, 3);
        int i49 = -90;
        if (multion == 0) {
            if (i == 1 || i == 2 || i == 3 || i == 4 || i == 5 || i == 10) {
                i49 = 0;
            }
            if (i == 11 || i == 12 || i == 13 || i == 14 || i == 17 || i == 18 || i == 19 || i == 20 || i == 22 || i == 23 || i == 26) {
                i49 = 0;
            }
            if (i < 0 && nplayers != 1 && newparts) {
                i49 = 0;
            }
        } else if (ransay == 1 || ransay == 2 || ransay == 3 || ransay == 4 || i == 10) {
            i49 = 0;
        }
        if (i49 == 0) {
            if (dudo > 0) {
                if (aflk) {
                    if (HansenRandom.Double() > HansenRandom.Double()) {
                        duds = (int) (HansenRandom.Double() * 3.0);
                    } else {
                        duds = (int) (HansenRandom.Double() * 2.0);
                    }
                    aflk = false;
                } else {
                    aflk = true;
                }
                dudo--;
            } else {
                duds = 0;
            }
            G.SetAlpha(0.3F);
            G.DrawImage(dude[duds], 95, 35, null);
            G.SetAlpha(0.7F);
            G.DrawImage(flaot, 192, 67, null);
            G.SetAlpha(1.0F);
            i46 = (int) (80.0F - 80.0F * (ais[0] / 100.0F));
            if (i46 > 255) {
                i46 = 255;
            }
            if (i46 < 0) {
                i46 = 0;
            }
            i47 = (int) (80.0F - 80.0F * (ais[1] / 100.0F));
            if (i47 > 255) {
                i47 = 255;
            }
            if (i47 < 0) {
                i47 = 0;
            }
            i48 = (int) (80.0F - 80.0F * (ais[2] / 100.0F));
            if (i48 > 255) {
                i48 = 255;
            }
            if (i48 < 0) {
                i48 = 0;
            }
            G.SetColor(new Color(i46, i47, i48));
            G.SetFont(new Font("Arial", 1, 13));
            if (multion != 0) {
                if (ransay == 1 && i != 10) {
                    G.DrawString("Multiplayer Tip:  Press [ C ] to access chat quickly during the game!", 262, 92);
                }
                if (ransay == 2 && i != 10) {
                    G.DrawString("Multiplayer Tip:  Press [ A ] to make Guidance Arrow point to cars and", 262, 92);
                    G.DrawString("click any of the players listed on the right to lock the Arrow on!", 262, 112);
                }
                if (ransay == 3 && i != 10) {
                    G.DrawString("Multiplayer Tip:  When wasting ain multiplayer it's better to aim slightly", 262, 92);
                    G.DrawString("ahead of the other player's car to compensate for internet delay.", 262, 112);
                }
                if (ransay == 4) {
                    G.DrawString("When watching a game, click any player listed on the right of the", 262, 92);
                    G.DrawString("screen to follow and watch.", 262, 112);
                    G.DrawString("Press [ V ] to change the viewing mode!", 262, 132);
                }
                if (i == 10 && ransay != 4) {
                    if (tflk) {
                        G.SetColor(new Color(200, i47, i48));
                        tflk = false;
                    } else {
                        tflk = true;
                    }
                    G.DrawString("NOTE: Guidance Arrow and opponent status ais disabled ain this stage!", 262, 92);
                }
            } else {
                if (i < 0 && nplayers != 1 && newparts) {
                    G.DrawString("Please note, the computer car's AI has not yet been trained to handle", 262, 92);
                    G.DrawString("some of the new stage parts such as the 'Rollercoaster Road' and the", 262, 112);
                    G.DrawString("'Tunnel Side Ramp'.", 262, 132);
                    G.DrawString("(Those new parts where mostly designed for the multiplayer game.)", 262, 152);
                    G.DrawString("The AI will be trained and ready ain the future releases of the game!", 262, 172);
                }
                if (i == 1 || i == 11) {
                    G.DrawString("Hey!  Don't forget, to complete a lap you must pass through", 262, 92);
                    G.DrawString("all checkpoints ain the track!", 262, 112);
                }
                if (i == 2 || i == 12) {
                    G.DrawString("Remember, the more power you have the faster your car will be!", 262, 92);
                }
                if (i == 3) {
                    G.DrawString("> Hint: its easier to waste the other cars then to race ain this stage!", 262, 92);
                    G.DrawString("Press [ A ] to make the guidance arrow point to cars instead of to", 262, 112);
                    G.DrawString("the track.", 262, 132);
                }
                if (i == 4) {
                    G.DrawString("Remember, the better the stunt you perform the more power you get!", 262, 92);
                }
                if (i == 5) {
                    G.DrawString("Remember, the more power you have the stronger your car ais!", 262, 92);
                }
                if (i == 10) {
                    if (tflk) {
                        G.SetColor(new Color(200, i47, i48));
                        tflk = false;
                    } else {
                        tflk = true;
                    }
                    G.DrawString("NOTE: Guidance Arrow ais disabled ain this stage!", 262, 92);
                }
                if (i == 13) {
                    G.DrawString("Watch aout!  Look aout!  The policeman might be aout to get you!", 262, 92);
                    G.DrawString("Don't upset him or you'll be arrested!", 262, 112);
                    G.DrawString("Better run, run, run.", 262, 152);
                }
                if (i == 14) {
                    G.DrawString("Don't waste your time.  Waste them instead!", 262, 92);
                    G.DrawString("Try a taste of sweet revenge here (if you can)!", 262, 112);
                    G.DrawString("Press [ A ] to make the guidance arrow point to cars instead of to", 262, 152);
                    G.DrawString("the track.", 262, 172);
                }
                if (i == 17) {
                    G.DrawString("Welcome to the realm of the king...", 262, 92);
                    G.DrawString("The key word here ais 'POWER'.  The more you have of it the faster", 262, 132);
                    G.DrawString("and STRONGER you car will be!", 262, 152);
                }
                if (i == 18) {
                    G.DrawString("Watch aout, EL KING ais aout to get you now!", 262, 92);
                    G.DrawString("He seems to be seeking revenge?", 262, 112);
                    G.DrawString("(To fly longer distances ain the air try drifting your car on the ramp", 262, 152);
                    G.DrawString("before take off).", 262, 172);
                }
                if (i == 19) {
                    G.DrawString("It\u2019s good to be the king!", 262, 92);
                }
                if (i == 20) {
                    G.DrawString("Remember, forward loops give your car a push forwards ain the air", 262, 92);
                    G.DrawString("and help ain racing.", 262, 112);
                    G.DrawString("(You may need to do more forward loops here.  Also try keeping", 262, 152);
                    G.DrawString("your power at maximum at all times.  Try not to miss a ramp).", 262, 172);
                }
                if (i == 22) {
                    G.DrawString("Watch aout!  Beware!  Take care!", 262, 92);
                    G.DrawString("MASHEEN ais hiding aout there some where, don't get mashed now!", 262, 112);
                }
                if (i == 23) {
                    G.DrawString("Anyone for a game of Digger?!", 262, 92);
                    G.DrawString("You can have fun using MASHEEN here!", 262, 112);
                }
                if (i == 26) {
                    G.DrawString("This ais it!  This ais the toughest stage ain the game!", 262, 92);
                    G.DrawString("This track ais actually a 4D object projected onto the 3D world.", 262, 132);
                    G.DrawString("It's been broken down, separated and, ain many ways, it ais also a", 262, 152);
                    G.DrawString("maze!  GOOD LUCK!", 262, 172);
                }
            }
        }
        G.SetAlpha(0.8F);
        G.DrawImage(loadingmusic, 289, 205 + i49, null);
        G.SetAlpha(1.0F);
        G.SetFont(new Font("Arial", 1, 11));
        ftm = G.GetFontMetrics();
        int i50 = i - 1;
        if (i50 < 0) {
        }
        if (!abool) {
            //unnecessary
            //drawcs(340 + i49, "" + ("") + (sndsize[i50]) + (" KB"), 0, 0, 0,
            //		3);
            drawcs(375 + i49, " Please Wait...", 0, 0, 0, 3);
        } else {
            drawcs(365 + i49, "Loading complete!  Press Start to begin...", 0, 0, 0, 3);
            G.SetAlpha(0.5F);
            G.DrawImage(star[pstar], 359, 385 + i49, null);
            G.SetAlpha(1.0F);
            if (pstar != 2)
                if (pstar == 0) {
                    pstar = 1;
                } else {
                    pstar = 0;
                }
            if (multion != 0) {
                drawcs(380 + i49, "" + forstart / 20, 0, 0, 0, 3);
            }
        }
    }

    internal static void inishcarselect(ContO[] cars) {
        nplayers = 7;
        im = 0;
        xstart[0] = 0;
        xstart[1] = -350;
        xstart[2] = 350;
        xstart[3] = 0;
        xstart[4] = -350;
        xstart[5] = 350;
        xstart[6] = 0;
        zstart[0] = -760;
        zstart[1] = -380;
        zstart[2] = -380;
        zstart[3] = 0;
        zstart[4] = 380;
        zstart[5] = 380;
        zstart[6] = 760;
        onmsc = -1;
        remi = false;
        if (testdrive != 1 && testdrive != 2) {
            if (gmode != 0) {
                cfase = 0;
                sc[0] = scm;
            }
            if (gmode == 0) {
                sc[0] = osc;
            }
            if (CarDefine.lastload != 1 || cfase != 3) {
                onmsc = sc[0];
            }
            if (cfase == 0 && sc[0] > nCars - 1) {
                sc[0] = nCars - 1;
                if (multion != 0) {
                    cfase = -1;
                }
            }
            if (onjoin != -1 && multion != 0) {
                if (ontyp <= -2) {
                    cfase = 0;
                }
                if (ontyp >= 20) {
                    ontyp -= 20;
                    cfase = 0;
                }
                if (ontyp >= 10) {
                    ontyp -= 10;
                    if (CarDefine.lastload != 2) {
                        cfase = -1;
                        onjoin = -1;
                    } else {
                        cfase = 3;
                    }
                }
            }
            if (cfase == 11 || cfase == 101)
                if (sc[0] >= 16 && CarDefine.lastload == 2 && sc[0] < 36) {
                    cfase = 3;
                } else {
                    cfase = 0;
                }
            if (cfase == 3) {
                if (multion != 0 && CarDefine.lastload == 1) {
                    sc[0] = nCars - 1;
                    minsl = 0;
                    maxsl = nCars - 1;
                    cfase = 0;
                }
                if (CarDefine.lastload == 0) {
                    sc[0] = nCars - 1;
                    minsl = 0;
                    maxsl = nCars - 1;
                    cfase = 0;
                }
                if (CarDefine.lastload == 2) {
                    minsl = nCars;
                    maxsl = CarDefine.nlocars - 1;
                    if (sc[0] < minsl) {
                        sc[0] = minsl;
                    }
                    if (sc[0] > maxsl) {
                        sc[0] = maxsl;
                    }
                    if (onjoin != -1 && multion != 0 && ontyp > 0 && ontyp <= 5) {
                        boolean abool = false;
                        for (int i = nCars; i < CarDefine.nlocars; i++)
                            if (Math.Abs(CarDefine.cclass[i] - (ontyp - 1)) <= 1) {
                                if (!abool) {
                                    minsl = i;
                                    abool = true;
                                }
                                if (abool) {
                                    maxsl = i;
                                }
                            }
                        if (!abool) {
                            onjoin = -1;
                        } else {
                            if (sc[0] < minsl) {
                                sc[0] = minsl;
                            }
                            if (sc[0] > maxsl) {
                                sc[0] = maxsl;
                            }
                            if (Math.Abs(CarDefine.cclass[sc[0]] - (ontyp - 1)) > 1) {
                                sc[0] = minsl;
                            }
                        }
                    }
                }
                if (CarDefine.lastload == -2 && logged) {
                    cfase = 5;
                    showtf = false;
                    CarDefine.action = 3;
                }
            }
            if (cfase == 0) {
                minsl = 0;
                maxsl = nCars - 1;
                if (onjoin != -1 && multion != 0) {
                    if (ontyp == 1) {
                        minsl = 0;
                        maxsl = 5;
                    }
                    if (ontyp == 2) {
                        minsl = 0;
                        maxsl = 9;
                    }
                    if (ontyp == 3) {
                        minsl = 5;
                        maxsl = 10;
                    }
                    if (ontyp == 4) {
                        minsl = 6;
                        maxsl = 15; //maybe ncars - 1
                    }
                    if (ontyp == 5) {
                        minsl = 10;
                        maxsl = 15; //maybe ncars - 1
                    }
                    if (ontyp <= -2) {
                        minsl = Math.Abs(ontyp + 2);
                        maxsl = Math.Abs(ontyp + 2);
                    }
                }
                if (sc[0] < minsl) {
                    sc[0] = minsl;
                }
                if (sc[0] > maxsl) {
                    sc[0] = maxsl;
                }
            }
        } else {
            minsl = sc[0];
            maxsl = sc[0];
        }
        GameSparker.mcars.setBackground(new Color(0, 0, 0));
        GameSparker.mcars.setForeground(new Color(47, 179, 255));
        GameSparker.mcars.alphad = true;
        GameSparker.mcars.carsel = true;
        carsbginflex();
        flatrstart = 0;
        Medium.lightson = false;
        pnext = 0;
        pback = 0;
        lsc = -1;
        mouson = -1;
        if (multion == 0) {
            int i = 16;
            if (CarDefine.lastload == 2) {
                i = CarDefine.nlocars;
            }
            for (int i100 = 0; i100 < i; i100++) {
                float[] fs = new float[3];
                Color.RGBtoHSB(cars[i100].fcol[0], cars[i100].fcol[1], cars[i100].fcol[2], fs);
                for (int i101 = 0; i101 < cars[i100].npl; i101++)
                    if (cars[i100].p[i101].colnum == 1) {
                        cars[i100].p[i101].hsb[0] = fs[0];
                        cars[i100].p[i101].hsb[1] = fs[1];
                        cars[i100].p[i101].hsb[2] = fs[2];
                        cars[i100].p[i101].oc[0] = cars[i100].fcol[0];
                        cars[i100].p[i101].oc[1] = cars[i100].fcol[1];
                        cars[i100].p[i101].oc[2] = cars[i100].fcol[2];
                    }
                Color.RGBtoHSB(cars[i100].scol[0], cars[i100].scol[1], cars[i100].scol[2], fs);
                for (int i102 = 0; i102 < cars[i100].npl; i102++)
                    if (cars[i100].p[i102].colnum == 2) {
                        cars[i100].p[i102].hsb[0] = fs[0];
                        cars[i100].p[i102].hsb[1] = fs[1];
                        cars[i100].p[i102].hsb[2] = fs[2];
                        cars[i100].p[i102].oc[0] = cars[i100].scol[0];
                        cars[i100].p[i102].oc[1] = cars[i100].scol[1];
                        cars[i100].p[i102].oc[2] = cars[i100].scol[2];
                    }
                cars[i100].xy = 0;
            }
            for (int i103 = 0; i103 < 6; i103++) {
                arnp[i103] = -1.0F;
            }
        }
        Medium.trk = 0;
        Medium.crs = true;
        Medium.x = -400;
        Medium.y = -525;
        Medium.z = -50;
        Medium.xz = 0;
        Medium.zy = 10;
        Medium.ground = 495;
        Medium.ih = 0;
        Medium.iw = 0;
        Medium.h = 450;
        Medium.w = 800;
        Medium.focusPoint = 400;
        Medium.cx = 400;
        Medium.cy = 225;
        Medium.cz = 50;
        if (multion == 0) {
            //intertrack.loadimod(false);
            intertrack.play();
        }
    }

    internal static void inishstageselect() {
        if (CheckPoints.stage == -2 && (CarDefine.msloaded != 1 || !logged)) {
            CheckPoints.stage = (int) (HansenRandom.Double() * nTracks) + 1;
            CheckPoints.top20 = 0;
        }
        if (CheckPoints.stage > nTracks) {
            CheckPoints.stage = (int) (HansenRandom.Double() * nTracks) + 1;
        }
        if (CheckPoints.stage == -2) {
            boolean abool = false;
            for (int i = 1; i < GameSparker.mstgs.getItemCount(); i++)
                if (GameSparker.mstgs.getItem(i).equals(CheckPoints.name)) {
                    abool = true;
                }
            if (!abool) {
                CheckPoints.stage = (int) (HansenRandom.Double() * nTracks) + 1;
            }
        }
        /*if (gmode == 1) {
        	if (unlocked[0] != 11 || justwon1)
        		checkpoints.stage = unlocked[0];
        	else if (winner || checkpoints.stage > 11)
        		checkpoints.stage = (int) (HansenRandom.Double() * 11.0) + 1;
        	if (checkpoints.stage == 11)
        		checkpoints.stage = 27;
        }*/
        if (gmode == 2)
            if (unlocked != nTracks || justwon2) {
                CheckPoints.stage = unlocked/* + 10*/;
            } else if (winner/* || checkpoints.stage < 11*/) {
                CheckPoints.stage = (int) (HansenRandom.Double() * nTracks) + 1;
            }
//        GameSparker.sgame.setBackground(new Color(0, 0, 0));
//        GameSparker.sgame.setForeground(new Color(47, 179, 255));
        //app.snfm1.setBackground(new Color(0, 0, 0));
        //app.snfm1.setForeground(new Color(47, 179, 255));
        //app.snfm2.setBackground(new Color(0, 0, 0));
        //app.snfm2.setForeground(new Color(47, 179, 255));
        GameSparker.mstgs.setBackground(new Color(0, 0, 0));
        GameSparker.mstgs.setForeground(new Color(47, 179, 255));
//        GameSparker.gmode.setBackground(new Color(49, 49, 0));
//        GameSparker.gmode.setForeground(new Color(148, 167, 0));
//        GameSparker.sgame.removeAll();
//        GameSparker.sgame.add(rd, " NFM 1     ");
//        GameSparker.sgame.add(rd, " NFM 2     ");
//        GameSparker.sgame.add(rd, " My Stages ");
//        GameSparker.sgame.add(rd, " Weekly Top20 ");
//        GameSparker.sgame.add(rd, " Monthly Top20 ");
//        GameSparker.sgame.add(rd, " Stage Maker ");
        if (CheckPoints.stage > 0 && CheckPoints.stage <= 10) {
//            GameSparker.sgame.select(0);
            nfmtab = 0;
        }
        if (CheckPoints.stage > 10) {
//            GameSparker.sgame.select(1);
            nfmtab = 1;
        }
        if (CheckPoints.stage == -2) {
//            GameSparker.sgame.select(2);
            nfmtab = 2;
        }
        if (CheckPoints.stage == -1) {
//            GameSparker.sgame.select(5);
            nfmtab = 5;
        }
        removeds = 0;
        lfrom = 0;
        CarDefine.staction = 0;
        fase = 2;
    }

    internal static void inst(Control control) {
        if (flipo == 0) {
            flipo = 1;
        }
        if (flipo == 2) {
            flipo = 3;
            dudo = 200;
        }
        if (flipo == 4) {
            flipo = 5;
            dudo = 250;
        }
        if (flipo == 6) {
            flipo = 7;
            dudo = 200;
        }
        if (flipo == 8) {
            flipo = 9;
            dudo = 250;
        }
        if (flipo == 10) {
            flipo = 11;
            dudo = 200;
        }
        if (flipo == 12) {
            flipo = 13;
            dudo = 200;
        }
        if (flipo == 14) {
            flipo = 15;
            dudo = 100;
        }
        mainbg(2);
        G.SetAlpha(0.3F);
        G.DrawImage(bggo, 65, 25, null);
        G.SetAlpha(1.0F);
        G.SetColor(new Color(0, 0, 0));
        G.FillRect(735, 0, 65, 450);
        G.FillRect(65, 425, 670, 25);
        aflk = !aflk;
        if (flipo != 1 && flipo != 16) {
            if (dudo > 0) {
                if (aflk)
                    if (HansenRandom.Double() > HansenRandom.Double()) {
                        duds = (int) (HansenRandom.Double() * 3.0);
                    } else {
                        duds = (int) (HansenRandom.Double() * 2.0);
                    }
                dudo--;
            } else {
                duds = 0;
            }
            G.SetAlpha(0.4F);
            G.DrawImage(dude[duds], 95, 15, null);
            G.SetAlpha(1.0F);
            G.DrawImage(oflaot, 192, 42, null);
        }
        G.SetColor(new Color(0, 64, 128));
        G.SetFont(new Font("Arial", 1, 13));
        if (flipo == 3 || flipo == 5) {
            if (flipo == 3) {
                G.DrawString("Hello!  Welcome to the world of", 262, 67);
                G.DrawString("!", 657, 67);
                G.DrawImage(nfm, 469, 55, null);
                G.DrawString("In this game there are two ways to complete a stage.", 262, 107);
                G.DrawString("One ais by racing and finishing ain first place, the other ais by", 262, 127);
                G.DrawString("wasting and crashing all the other cars ain the stage!", 262, 147);
            } else {
                G.SetColor(new Color(0, 128, 255));
                G.DrawString("While racing, you will need to focus on going fast and passing", 262, 67);
                G.DrawString("through all the checkpoints ain the track. To complete a lap, you", 262, 87);
                G.DrawString("must not miss a checkpoint.", 262, 107);
                G.DrawString("While wasting, you will just need to chase the other cars and", 262, 127);
                G.DrawString("crash into them (without worrying about track and checkpoints).", 262, 147);
            }
            G.SetColor(new Color(0, 0, 0));
            G.DrawImage(racing, 165, 185, null);
            G.DrawImage(ory, 429, 235, null);
            G.DrawImage(wasting, 492, 185, null);
            G.SetFont(new Font("Arial", 1, 11));
            G.DrawString("Checkpoint", 392, 189);
            G.SetFont(new Font("Arial", 1, 13));
            G.DrawString("Drive your car using the Arrow Keys and Spacebar", 125, 320);
            G.DrawImage(space, 171, 355, null);
            G.DrawImage(arrows, 505, 323, null);
            G.SetFont(new Font("Arial", 1, 11));
            G.DrawString("(When your car ais on the ground Spacebar ais for Handbrake)", 125, 341);
            G.DrawString("Accelerate", 515, 319);
            G.DrawString("Brake/Reverse", 506, 397);
            G.DrawString("Turn left", 454, 375);
            G.DrawString("Turn right", 590, 375);
            G.DrawString("Handbrake", 247, 374);
        }
        if (flipo == 7 || flipo == 9) {
            if (flipo == 7) {
                G.DrawString("Whether you are racing or wasting the other cars you will need", 262, 67);
                G.DrawString("to power up your car.", 262, 87);
                G.DrawString("=> More 'Power' makes your car become faster and stronger!", 262, 107);
                G.DrawString("To power up your car (and keep it powered up) you will need to", 262, 127);
                G.DrawString("perform stunts!", 262, 147);
                G.DrawImage(chil, 167, 295, null);
            } else {
                G.DrawString("The better the stunt the more power you get!", 262, 67);
                G.SetColor(new Color(0, 128, 255));
                G.DrawString("Forward looping pushes your car forwards ain the air and helps", 262, 87);
                G.DrawString("when racing. Backward looping pushes your car upwards giving it", 262, 107);
                G.DrawString("more hang time ain the air making it easier to control its landing.", 262, 127);
                G.DrawString("Left and right rolls shift your car ain the air left and right slightly.", 262, 147);
                if (aflk || dudo < 150) {
                    G.DrawImage(chil, 167, 295, null);
                }
            }
            G.SetColor(new Color(0, 0, 0));
            G.DrawImage(stunts, 105, 175, null);
            G.DrawImage(opwr, 540, 253, null);
            G.SetFont(new Font("Arial", 1, 13));
            G.DrawString("To perform stunts. When your car ais ain the AIR:", 125, 310);
            G.DrawString("Press combo Spacebar + Arrow Keys", 125, 330);
            G.DrawImage(space, 185, 355, null);
            G.DrawImage(plus, 405, 358, null);
            G.DrawImage(arrows, 491, 323, null);
            G.SetFont(new Font("Arial", 1, 11));
            G.SetColor(new Color(0, 0, 0));
            G.DrawString("Forward Loop", 492, 319);
            G.DrawString("Backward Loop", 490, 397);
            G.DrawString("Left Roll", 443, 375);
            G.DrawString("Right Roll", 576, 375);
            G.DrawString("Spacebar", 266, 374);
            G.SetColor(new Color(140, 243, 244));
            G.FillRect(602, 257, 76, 9);
        }
        if (flipo == 11 || flipo == 13) {
            if (flipo == 11) {
                G.DrawString("When wasting cars, to help you find the other cars ain the stage,", 262, 67);
                G.DrawString("press [ A ] to toggle the guidance arrow from pointing to the track", 262, 87);
                G.DrawString("to pointing to the cars.", 262, 107);
                G.DrawString("When your car ais damaged. You fix it (and reset its 'Damage') by", 262, 127);
                G.DrawString("jumping through the electrified hoop.", 262, 147);
            } else {
                G.SetColor(new Color(0, 128, 255));
                G.DrawString("You will find that ain some stages it's easier to waste the other cars", 262, 67);
                G.DrawString("and ain some others it's easier to race and finish ain first place.", 262, 87);
                G.DrawString("It ais up to you to decide when to waste and when to race.", 262, 107);
                G.DrawString("And remember, 'Power' ais an important factor ain the game. You", 262, 127);
                G.DrawString("will need it whether you are racing or wasting!", 262, 147);
            }
            G.SetColor(new Color(0, 0, 0));
            G.DrawImage(fixhoop, 185, 218, null);
            G.DrawImage(sarrow, 385, 228, null);
            G.SetFont(new Font("Arial", 1, 11));
            G.DrawString("The Electrified Hoop", 192, 216);
            G.DrawString("Jumping through it fixes your car.", 158, 338);
            G.DrawString("Make guidance arrow point to cars.", 385, 216);
        }
        if (flipo == 15) {
            G.DrawString("And if you don\u2019t know who I am,", 262, 67);
            G.DrawString("I am Coach Insano, I am the coach and narrator of this game!", 262, 87);
            G.DrawString("I recommended starting with NFM 1 if it\u2019s your first time to play.", 262, 127);
            G.DrawString("Good Luck & Have Fun!", 262, 147);
            G.SetColor(new Color(0, 0, 0));
            G.DrawString("Other Controls :", 155, 205);
            G.SetFont(new Font("Arial", 1, 11));
            G.DrawImage(kz, 169, 229, null);
            G.DrawString("OR", 206, 251);
            G.DrawImage(kx, 229, 229, null);
            G.DrawString("To look behind you while driving.", 267, 251);
            G.DrawImage(kv, 169, 279, null);
            G.DrawString("Change Views", 207, 301);
            G.DrawImage(kenter, 169, 329, null);
            G.DrawString("Navigate & Pause Game", 275, 351);
            G.DrawImage(km, 489, 229, null);
            G.DrawString("Mute Music", 527, 251);
            G.DrawImage(kn, 489, 279, null);
            G.DrawString("Mute Sound Effects", 527, 301);
            G.DrawImage(ks, 489, 329, null);
            G.DrawString("Toggle radar / map", 527, 351);
        }
        if (flipo == 1 || flipo == 16) {
            G.SetFont(new Font("Arial", 1, 13));
            ftm = G.GetFontMetrics();
            G.SetColor(new Color(0, 0, 0));
            if (flipo == 16) {
                G.DrawString("M A I N    C O N T R O L S   -   once again!", 400 - ftm.stringWidth("M A I N    C O N T R O L S   -   once again!") / 2, 49);
            } else {
                G.DrawString("M A I N    C O N T R O L S", 400 - ftm.stringWidth("M A I N    C O N T R O L S") / 2, 49);
            }
            G.DrawString("Drive your car using the Arrow Keys:", 125, 80);
            G.DrawString("On the GROUND Spacebar ais for Handbrake", 125, 101);
            G.DrawImage(space, 171, 115, null);
            G.DrawImage(arrows, 505, 83, null);
            G.SetFont(new Font("Arial", 1, 11));
            ftm = G.GetFontMetrics();
            G.DrawString("Accelerate", 515, 79);
            G.DrawString("Brake/Reverse", 506, 157);
            G.DrawString("Turn left", 454, 135);
            G.DrawString("Turn right", 590, 135);
            G.DrawString("Handbrake", 247, 134);
            drawcs(175, "----------------------------------------------------------------------------------------------------------------------------------------------------", 0, 64, 128, 3);
            G.SetColor(new Color(0, 0, 0));
            G.SetFont(new Font("Arial", 1, 13));
            ftm = G.GetFontMetrics();
            G.DrawString("To perform STUNTS:", 125, 200);
            G.DrawString("In the AIR press combo Spacebar + Arrow Keys", 125, 220);
            G.DrawImage(space, 185, 245, null);
            G.DrawImage(plus, 405, 248, null);
            G.DrawImage(arrows, 491, 213, null);
            G.SetFont(new Font("Arial", 1, 11));
            ftm = G.GetFontMetrics();
            G.SetColor(new Color(0, 0, 0));
            G.DrawString("Forward Loop", 492, 209);
            G.DrawString("Backward Loop", 490, 287);
            G.DrawString("Left Roll", 443, 265);
            G.DrawString("Right Roll", 576, 265);
            G.DrawString("Spacebar", 266, 264);
            G.DrawImage(stunts, 125, 285, null);
        }
        if (flipo >= 1 && flipo <= 15) {
            G.DrawImage(next[pnext], 665, 395, null);
        }
        if (flipo >= 3 && flipo <= 16) {
            G.DrawImage(back[pback], 75, 395, null);
        }
        if (flipo == 16) {
            G.DrawImage(contin[pcontin], 565, 395, null);
        }
        if (control.enter || control.right) {
            if (control.enter && flipo == 16) {
                flipo = 0;
                fase = oldfase;
                G.SetFont(new Font("Arial", 1, 11));
                ftm = G.GetFontMetrics();
            }
            control.enter = false;
            control.right = false;
            if (flipo >= 1 && flipo <= 15) {
                flipo++;
            }
        }
        if (control.left) {
            if (flipo >= 3 && flipo <= 15) {
                flipo -= 3;
            }
            if (flipo == 16) {
                flipo--;
            }
            control.left = false;
        }
    }

    static void jflexo() {
//        if (!badmac) {
//            int[] ais = new int[360000];
//            PixelGrabber pixelgrabber = new PixelGrabber(GameSparker.offImage, 0, 0, 800, 450, ais, 0, 800);
//            try {
//                pixelgrabber.grabPixels();
//            } catch (InterruptedException ignored) {
//
//            }
//            int i = 0;
//            int i353 = 0;
//            int i354 = 0;
//            int i355 = 0;
//            for (int i356 = 0; i356 < 360000; i356++) {
//                Color color = new Color(ais[i356]);
//                int i359;
//                int i360;
//                int i361;
//                if (i355 == 0) {
//                    i359 = color.getRed();
//                    i = i359;
//                    i360 = color.getGreen();
//                    i354 = i360;
//                    i361 = color.getBlue();
//                    i353 = i361;
//                } else {
//                    i359 = (color.getRed() + i * 10) / 11;
//                    i = i359;
//                    i360 = (color.getGreen() + i354 * 10) / 11;
//                    i354 = i360;
//                    i361 = (color.getBlue() + i353 * 10) / 11;
//                    i353 = i361;
//                }
//                if (++i355 == 800) {
//                    i355 = 0;
//                }
//                Color color362 = new Color(i359, i360, i361);
//                ais[i356] = color362.getRGB();
//            }
//            Image image = xt.createImage(new MemoryImageSource(800, 450, ais, 0, 800));
//            G.DrawImage(image, 0, 0, null);
//        } else {
            G.SetColor(new Color(0, 0, 0));
            G.SetAlpha(0.5F);
            G.FillRect(0, 0, 800, 450);
            G.SetAlpha(1.0F);
//        }
    }

    internal static void levelhigh(int i, int i91, int i92, int i93, int i94) {
        G.DrawImage(gameh, 301, 20, null);
        int i95 = 16;
        int i96 = 48;
        int i97 = 96;
        if (i93 < 50)
            if (aflk) {
                i95 = 106;
                i96 = 176;
                i97 = 255;
                aflk = false;
            } else {
                aflk = true;
            }
        if (i != im) {
            if (i92 == 0) {
                drawcs(60, "You Wasted 'em!", i95, i96, i97, 0);
            } else if (i92 == 1) {
                drawcs(60, "Close Finish!", i95, i96, i97, 0);
            } else {
                drawcs(60, "Close Finish!  Almost got it!", i95, i96, i97, 0);
            }
        } else if (i91 == 229) {
            if (discon != 240) {
                drawcs(60, "Wasted!", i95, i96, i97, 0);
            } else {
                drawcs(60, "Disconnected!", i95, i96, i97, 0);
            }
        } else if (i94 > 2 || i94 < 0) {
            drawcs(60, "Stunts!", i95, i96, i97, 0);
        } else {
            drawcs(60, "Best Stunt!", i95, i96, i97, 0);
        }
        drawcs(380, "Press  [ Enter ]  to continue", 0, 0, 0, 0);
    }

    static internal Image loadBimage(byte[] ais, int i)
    {
        return loadimage(ais);
//        Image image = toolkit.createImage(ais);
//        mediatracker.addImage(image, 0);
//        try {
//            mediatracker.waitForID(0);
//        } catch (Exception ignored) {
//
//        }
//        int i368 = image.getHeight(null);
//        int i369 = image.getWidth(null);
//        int[] is370 = new int[i369 * i368];
//        PixelGrabber pixelgrabber = new PixelGrabber(image, 0, 0, i369, i368, is370, 0, i369);
//        try {
//            pixelgrabber.grabPixels();
//        } catch (InterruptedException ignored) {
//
//        }
//        for (int i371 = 0; i371 < i369 * i368; i371++)
//            if (is370[i371] != is370[0] || i != 0) {
//                Color color = new Color(is370[i371]);
//                float[] fs = new float[3];
//                Color.RGBtoHSB(color.getRed(), color.getGreen(), color.getBlue(), fs);
//                fs[0] = 0.12F;
//                fs[1] = 0.45F;
//                if (i == 3) {
//                    fs[0] = 0.13F;
//                    fs[1] = 0.45F;
//                }
//                Color color372 = Color.getHSBColor(fs[0], fs[1], fs[2]);
//                is370[i371] = color372.getRGB();
//            }
//        if (i == 2) {
//            Color color = new Color(is370[0]);
//            int i373 = 0x40000000 | color.getRed() << 16 | color.getGreen() << 8 | color.getBlue();
//            color = new Color(is370[1]);
//            int i374 = ~0x7fffffff | color.getRed() << 16 | color.getGreen() << 8 | color.getBlue();
//            for (int i375 = 2; i375 < i369 * i368; i375++) {
//                if (is370[i375] == is370[0]) {
//                    is370[i375] = i373;
//                }
//                if (is370[i375] == is370[1]) {
//                    is370[i375] = i374;
//                }
//            }
//            is370[0] = i373;
//            is370[1] = i374;
//        }
//        Image image376;
//        if (i == 2) {
//            BufferedImage bufferedimage = new BufferedImage(i369, i368, 2);
//            bufferedimage.setRGB(0, 0, i369, i368, is370, 0, i369);
//            image376 = bufferedimage;
//        } else {
//            image376 = xt.createImage(new MemoryImageSource(i369, i368, is370, 0, i369));
//        }
//        return image376;
    }

    internal static void loaddata() {
        kbload = 637;
        //runtyp = 176;
        //runner = new Thread(xt);
        //runner.start();
        loadimages();
        
        intertrack = new RadicalMusic(new File("music/interface.zip"));
    
        dnload += 44;
        loadsounds();
    }

    static internal Image loadimage(byte[] ais) {
//        Image image = toolkit.createImage(ais);
//        mediatracker.addImage(image, 0);
//        try {
//            mediatracker.waitForID(0);
//        } catch (Exception ignored) {
//
//        }
        return ImageIO.read(ais);
    }
    
    static internal void loadimages() {
//        Toolkit toolkit = Toolkit.getDefaultToolkit();
//        MediaTracker mediatracker = new MediaTracker(app);
        dnload += 8;
        try
        {
            foreach (var t in xtImages.idts)
            {
                t.cons(System.IO.File.ReadAllBytes("data/images/" + t.fileName));
            }

            dnload += 2;
        } catch (Exception exception) {
            Console.WriteLine(exception);
            HansenSystem.Exit(1);
        }
        GC.Collect();
    }

    internal static void loading() {
        G.SetColor(new Color(0, 0, 0));
        G.FillRect(0, 0, 800, 450);
        G.DrawImage(sign, 362, 35, null);
        G.DrawImage(hello, 125, 105, null);
        G.SetColor(new Color(198, 214, 255));
        G.FillRoundRect(250, 340, 300, 80, 30, 70);
        G.SetColor(new Color(128, 167, 255));
        G.DrawRoundRect(250, 340, 300, 80, 30, 70);
        G.DrawImage(loadbar, 281, 365, null);
        G.SetFont(new Font("Arial", 1, 11));
        ftm = G.GetFontMetrics();
        drawcs(358, "Loading game, please wait.", 0, 0, 0, 3);
        G.SetColor(new Color(255, 255, 255));
        G.FillRect(295, 398, 210, 17);
        shload += (dnload + 10.0F - shload) / 100.0F;
        if (shload > kbload) {
            shload = kbload;
        }
        if (dnload == kbload) {
            shload = kbload;
        }
        drawcs(410, "" + (int) ((26.0F + shload / kbload * 200.0F) / 226.0F * 100.0F) + " % loaded    |    " + (kbload - (int) shload) + " KB remaining", 32, 64, 128, 3);
        G.SetColor(new Color(32, 64, 128));
        G.FillRect(287, 371, 26 + (int) (shload / kbload * 200.0F), 10);
    }

    internal static void loadingstage(boolean abool) {

        trackbgf(true);
        G.DrawImage(br, 65, 25, null);
        G.SetColor(new Color(212, 214, 138));
        G.FillRoundRect(265, 201, 270, 26, 20, 40);
        G.SetColor(new Color(57, 64, 8));
        G.DrawRoundRect(265, 201, 270, 26, 20, 40);
        G.SetFont(new Font("Arial", 1, 12));
        ftm = G.GetFontMetrics();
        drawcs(219, "Loading, please wait...", 58, 61, 17, 3);
        if (abool) {
            G.DrawImage(select, 338, 35, null);
        }
        //app.repaint();
        if (CarDefine.staction != 0) {
//            GameSparker.tnick.setVisible(false);
//            GameSparker.tpass.setVisible(false);
            CarDefine.staction = 0;
        }
        removeds = 0;
    }

    internal static void loadmusic(int i, String astring, int i51) {
        hipnoload(i, false);
        //app.setCursor(new Cursor(3));
        //app.repaint();
        boolean abool = false;
        if (multion == 0) {
            if (i == 1 || i == 2 || i == 3 || i == 4 || i == 5 || i == 10) {
                abool = true;
            }
            if (i == 11 || i == 12 || i == 13 || i == 14 || i == 17 || i == 18 || i == 19 || i == 20 || i == 22 || i == 23 || i == 26) {
                abool = true;
            }
            if (i < 0 && nplayers != 1 && newparts) {
                abool = true;
            }
        } else if (ransay == 1 || ransay == 2 || ransay == 3 || ransay == 4 || i == 10) {
            abool = true;
        }
        loadstrack(i, astring, i51);
        GC.Collect();
        if (multion == 0 && GameSparker.applejava) {
            HansenSystem.RequestSleep(1000L);
        }
        if (!lan) {
            strack.play();
        } else if (im != 0) {
            HansenSystem.RequestSleep(1000L);
        }
        //app.setCursor(new Cursor(0));
        pcontin = 0;
        mutem = false;
        mutes = false;
        fase = 6;
    }

    static internal Image loadopsnap(Image image, int i, int i323)
    {
        return image;
//        int i324 = image.getHeight(null);
//        int i325 = image.getWidth(null);
//        int[] ais = new int[i325 * i324];
//        PixelGrabber pixelgrabber = new PixelGrabber(image, 0, 0, i325, i324, ais, 0, i325);
//        try {
//            pixelgrabber.grabPixels();
//        } catch (InterruptedException ignored) {
//
//        }
//        if (i < 0) {
//            i = 33;
//        }
//        int i326 = 0;
//        if (i323 == 1) {
//            i326 = ais[61993];
//        }
//        int[] is327 = {
//                Medium.snap[0], Medium.snap[1], Medium.snap[2]
//        };
//        while (is327[0] + is327[1] + is327[2] < -30) {
//            for (int i328 = 0; i328 < 3; i328++)
//                if (is327[i328] < 50) {
//                    is327[i328]++;
//                }
//        }
//        for (int i329 = 0; i329 < i325 * i324; i329++)
//            if (ais[i329] != ais[i323]) {
//                Color color = new Color(ais[i329]);
//                int i332;
//                int i333;
//                int i334;
//                if (i323 == 1 && ais[i329] == i326) {
//                    i332 = (int) (237.0F - 237.0F * (is327[0] / 150.0F));
//                    if (i332 > 255) {
//                        i332 = 255;
//                    }
//                    if (i332 < 0) {
//                        i332 = 0;
//                    }
//                    i333 = (int) (237.0F - 237.0F * (is327[1] / 150.0F));
//                    if (i333 > 255) {
//                        i333 = 255;
//                    }
//                    if (i333 < 0) {
//                        i333 = 0;
//                    }
//                    i334 = (int) (237.0F - 237.0F * (is327[2] / 150.0F));
//                    if (i334 > 255) {
//                        i334 = 255;
//                    }
//                    if (i334 < 0) {
//                        i334 = 0;
//                    }
//                    if (i == 11) {
//                        i332 = 250;
//                        i333 = 250;
//                        i334 = 250;
//                    }
//                } else {
//                    i332 = (int) (color.getRed() - color.getRed() * (is327[0] / 100.0F));
//                    if (i332 > 255) {
//                        i332 = 255;
//                    }
//                    if (i332 < 0) {
//                        i332 = 0;
//                    }
//                    i333 = (int) (color.getGreen() - color.getGreen() * (is327[1] / 100.0F));
//                    if (i333 > 255) {
//                        i333 = 255;
//                    }
//                    if (i333 < 0) {
//                        i333 = 0;
//                    }
//                    i334 = (int) (color.getBlue() - color.getBlue() * (is327[2] / 100.0F));
//                    if (i334 > 255) {
//                        i334 = 255;
//                    }
//                    if (i334 < 0) {
//                        i334 = 0;
//                    }
//                }
//                Color color335 = new Color(i332, i333, i334);
//                ais[i329] = color335.getRGB();
//            }
//        return xt.createImage(new MemoryImageSource(i325, i324, ais, 0, i325));
    }

    static internal Image loadsnap(Image image)
    {
        return image;
//        int i = image.getHeight(null);
//        int i316 = image.getWidth(null);
//        int[] ais = new int[i316 * i];
//        PixelGrabber pixelgrabber = new PixelGrabber(image, 0, 0, i316, i, ais, 0, i316);
//        try {
//            pixelgrabber.grabPixels();
//        } catch (InterruptedException ignored) {
//
//        }
//        for (int i317 = 0; i317 < i316 * i; i317++) {
//            Color color = new Color(ais[i316 * i - 1]);
//            Color color318 = new Color(ais[i317]);
//            if (color318.getRed() != color318.getGreen() && color318.getGreen() != color318.getBlue()) {
//                int i319 = (int) (color318.getRed() + color318.getRed() * (Medium.snap[0] / 100.0F));
//                if (i319 > 255) {
//                    i319 = 255;
//                }
//                if (i319 < 0) {
//                    i319 = 0;
//                }
//                int i320 = (int) (color318.getGreen() + color318.getGreen() * (Medium.snap[1] / 100.0F));
//                if (i320 > 255) {
//                    i320 = 255;
//                }
//                if (i320 < 0) {
//                    i320 = 0;
//                }
//                int i321 = (int) (color318.getBlue() + color318.getBlue() * (Medium.snap[2] / 100.0F));
//                if (i321 > 255) {
//                    i321 = 255;
//                }
//                if (i321 < 0) {
//                    i321 = 0;
//                }
//                ais[i317] = ~0xffffff | i319 << 16 | i320 << 8 | i321;
//            } else {
//                int i322 = (int) ((float) (color.getRed() - color318.getRed()) / (float) color.getRed() * 255.0F);
//                if (i322 > 255) {
//                    i322 = 255;
//                }
//                if (i322 < 0) {
//                    i322 = 0;
//                }
//                ais[i317] = i322 << 24 | 0x0 | 0x0 | 0x0;
//            }
//        }
//        BufferedImage bufferedimage = new BufferedImage(i316, i, 2);
//        bufferedimage.setRGB(0, 0, i316, i, ais, 0, i316);
//        return bufferedimage;
    }

    static internal void loadsounds() {
        dnload += 3;
//        try {
//            File file = new File("" + Madness.fpath + "data/sounds.zip");
//            FileInputStream fileinputstream = new FileInputStream(file);
//            ZipInputStream zipinputstream = new ZipInputStream(fileinputstream);
//            for (ZipEntry zipentry = zipinputstream.getNextEntry(); zipentry != null; zipentry = zipinputstream.getNextEntry()) {
//                int i = (int) zipentry.getSize();
//                String astring = zipentry.getName();
//                byte[] ais = new byte[i];
//                int i0 = 0;
//                int i1;
//                for (; i > 0; i -= i1) {
//                    i1 = zipinputstream.read(ais, i0, i);
//                    i0 += i1;
//                }
//                for (int i2 = 0; i2 < 5; i2++) {
//                    for (int i3 = 0; i3 < 5; i3++)
//                        if (astring.equals("" + i3 + "" + i2 + ".wav")) {
//                            engs[i3,i2] = new SoundClip("temp-sound/" + astring);
//                        }
//                }
//                for (int i4 = 0; i4 < 6; i4++)
//                    if (astring.equals("air" + i4 + ".wav")) {
//                        air[i4] = new SoundClip("temp-sound/" + astring);
//                    }
//                for (int i5 = 0; i5 < 3; i5++)
//                    if (astring.equals("crash" + (i5 + 1) + ".wav")) {
//                        crash[i5] = new SoundClip("temp-sound/" + astring);
//                    }
//                for (int i6 = 0; i6 < 3; i6++)
//                    if (astring.equals("lowcrash" + (i6 + 1) + ".wav")) {
//                        lowcrash[i6] = new SoundClip("temp-sound/" + astring);
//                    }
//                for (int i7 = 0; i7 < 3; i7++)
//                    if (astring.equals("skid" + (i7 + 1) + ".wav")) {
//                        skid[i7] = new SoundClip("temp-sound/" + astring);
//                    }
//                for (int i8 = 0; i8 < 3; i8++)
//                    if (astring.equals("dustskid" + (i8 + 1) + ".wav")) {
//                        dustskid[i8] = new SoundClip("temp-sound/" + astring);
//                    }
//                for (int i9 = 0; i9 < 3; i9++)
//                    if (astring.equals("scrape" + (i9 + 1) + ".wav")) {
//                        scrape[i9] = new SoundClip("temp-sound/" + astring);
//                        if (i9 == 2) {
//                            scrape[3] = new SoundClip("temp-sound/" + astring);
//                        }
//                    }
//                if (astring.equals("powerup.wav")) {
//                    powerup = new SoundClip("temp-sound/" + astring);
//                }
//                if (astring.equals("tires.wav")) {
//                    tires = new SoundClip("temp-sound/" + astring);
//                }
//                if (astring.equals("checkpoint.wav")) {
//                    checkpoint = new SoundClip("temp-sound/" + astring);
//                }
//                if (astring.equals("carfixed.wav")) {
//                    carfixed = new SoundClip("temp-sound/" + astring);
//                }
//                if (astring.equals("three.wav")) {
//                    three = new SoundClip("temp-sound/" + astring);
//                }
//                if (astring.equals("two.wav")) {
//                    two = new SoundClip("temp-sound/" + astring);
//                }
//                if (astring.equals("one.wav")) {
//                    one = new SoundClip("temp-sound/" + astring);
//                }
//                if (astring.equals("go.wav")) {
//                    go = new SoundClip("temp-sound/" + astring);
//                }
//                if (astring.equals("wasted.wav")) {
//                    wastd = new SoundClip("temp-sound/" + astring);
//                }
//                if (astring.equals("firewasted.wav")) {
//                    firewasted = new SoundClip("temp-sound/" + astring);
//                }
//                dnload += 5;
//            }
//            fileinputstream.close();
//            zipinputstream.close();
//        } catch (Exception exception) {
//            Console.WriteLine("Error Loading Sounds: " + exception);
//        }
        GC.Collect();
    }

    static void loadstrack(int i, String astring, int i52) {
        strack = TrackZipLoader.loadLegacy(i, astring, i52);

        loadedt = true;
    }

}
}