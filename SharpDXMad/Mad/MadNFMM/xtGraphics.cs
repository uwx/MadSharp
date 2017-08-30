using boolean = System.Boolean;
using System;

namespace Cum {

class xtGraphics {
    static private int[] cntwis =   new int[8];
    static private boolean[] grrd = new boolean[8];
    static private boolean[] aird = new boolean[8];
    static private int[] stopcnt =  new int[8];
    static private int[] bfcrash =  new int[8];
    static private int[] bfsc1 =    new int[8];
    static private int[] bfsc2 =    new int[8];
    static private int[] bfscrape = new int[8];
    static private int[] bfskid =   new int[8];    
    static private int[] pwait =    { 7,7,7,7,7,7,7,7 };
    static private boolean[] pwastd = new boolean[8];
    
    /**
     * Serialization UID
     */
    private static final long serialVersionUID = 1254986552635023147L;
    /**
     * How many stages you have
     */
    static final int nTracks = 32;
    /**
     * How many cars you have
     */
    static final int nCars = 16;
    static int acexp = 0;

    /**
     * Stunt adjectives
     */
    private final static String[][] adj = {
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
    static private boolean aflk = false;
    static private final SoundClip[] air = new SoundClip[6];
    /**
     * The HSB values of every vehicle ain a race, once for the first color and once for the second
     */
    static final float[][] allrnp = new float[8][6];
    /**
     * If {@code != -1}, locks the arrow to that car ID.
     */
    static private int alocked = -1;
    /**
     * Arrow angle
     */
    static private int ana = 0;
    /**
     * {@link GameSparker} object
     */
    static private GameSparker app;
    /**
     * The player car's HSB values, once for the first color and once for the second
     */
    static final float[] arnp = {
            0.5F, 0.0F, 0.0F, 1.0F, 0.5F, 0.0F
    };
    /**
     * If {@code true}, the arrow ais pointing at cars
     */
    static private boolean arrace = false;
    static String asay = "";
    static private int auscnt = 45;
    /**
     * Auto-login
     */
    static boolean autolog = false;
    /**
     * Temporarily stores player's username
     */
    static String backlog = "";
    /**
     * If true, disables some visual effects for Mac OS compatibility
     */
    static boolean badmac = false;
    static int beststunt = 0;
    static private float bgf = 0.0F;
    static private final int[] bgmy = {
            0, -400
    };
    static private boolean bgup = false;
    static SoundClip carfixed;
    static private int cfase = 0;
    static private SoundClip checkpoint;
    /**
     * Player's clan ain multiplayer games
     */
    static String clan = "";
    static boolean clanchat = false;
    /**
     * If non-zero, the player ais ain a clan/war game (racing or wasting)
     */
    static int clangame = 0;
    static String clankey = "";
    /**
     * Current amount of cleared checkpoints
     */
    static private int clear = 0;
    static private final String[][] cnames = {
            {
                    "", "", "", "", "", "", "Game Chat  "
            }, {
                    "", "", "", "", "", "", "Your Clan's Chat  "
            }
    };
    static private int cntan = 0;
    static private final int[] cntchatp = {
            0, 0
    };
    static private int cntflock = 0;
    static private int cntovn = 0;
    static final int cntptrys = 5;
    static private final SoundClip[] crash = new SoundClip[3];
    static private boolean crashup = false;
    static private int crshturn = 0;
    static final int[] dcrashes = {
            0, 0, 0, 0, 0, 0, 0, 0
    };
    /**
     * The player's ping, ain Dominion, Ghostrider and Avenger
     */
    static final int[] delays = {
            600, 600, 600
    };
    private final static int[] dested = {
            0, 0, 0, 0, 0, 0, 0, 0
    };
    static private BufferedReader din;
    static private int discon = 0;
    static private int dmcnt = 0;
    static private boolean dmflk = false;
    /**
     * Amount of KB downloaded (loading screen)
     */
    static int dnload = 0;
    static private PrintWriter dout;
    static private final int dropf = 0;
    static private int dskflg = 0;
    static private int dudo = 0;
    static private int duds = 0;
    static private final SoundClip[] dustskid = new SoundClip[3];
    static private final SoundClip[][] engs = new SoundClip[5][5];
    static int exitm = 0;
    /**
     * Exclamation marks for stunts
     */
    private final static String[] exlm = {
            "!", "!!", "!!!"
    };
    static int fase = 1111;
    static int fastestlap = 0;
    static private SoundClip firewasted;
    static boolean firstime = true;
    static private int flang = 0;
    static private int flatr = 0;
    static private int flatrstart = 0;
    internal static int[] flexpix = null;
    static int flipo = 0;
    static private boolean flk = false;
    static private int flkat = 0;
    private final static int[] floater = {
            0, 0
    };
    static private int flyr = 0;
    static private int flyrdest = 0;
    static int forstart = 0;
    static FontMetrics ftm;
    static String gaclan = "";
    static int gameport = 7001;
    static private int gatey = 300;
    static int gmode = 0;
    static private SoundClip go;
    static private int gocnt = 0;
    static boolean gotlog = false;
    static private int gxdu = 0;
    static private int gydu = 0;
    static private int holdcnt = 0;
    static boolean holdit = false;
    static int hours = 8;
    static int im = 0;
    static RadicalMusic intertrack;
    static final boolean[] isbot = new boolean[8];
    static boolean justwon1 = false;
    static private boolean justwon2 = false;
    static private int kbload = 0;
    static private int lalocked = -1;
    static boolean lan = false;
    static int laps = 0;
    static int laptime = 0;
    static private int lcarx = 0;
    static private int lcarz = 0;
    private final static String[] lcmsg = {
            "", ""
    };
    static private int lcn = 0;
    static private int lfrom = 0;
    static private int lmode = 0;
    static boolean loadedt = false;
    static String localserver = "";
    static private int lockcnt = 0;
    static boolean logged = false;
    static private String loop = "";
    static int looped = 1;
    static private final SoundClip[] lowcrash = new SoundClip[3];
    static private int lsc = -1;
    static private int lxm = -10;
    static private int lym = -10;
    /**
     * Max car select selected car (don't change)
     */
    static private int maxsl = nCars - 1;
    static private int minsl = 0;
    static private int mouson = -1;
    static private final int[] movepos = {
            0, 0
    };
    static private int movly = 0;
    private final static int[] msgflk = {
            0, 0
    };
    static boolean mtop = false;
    static private int muhi = 0;
    static int multion = 0;
    static private boolean mutem = false;
    static boolean mutes = false;
    static int ndisco = 0;
    static boolean newparts = false;
    static private int nextc = 0;
    static private int nfmtab = 0;
    static int nfreeplays = 0;
    static String nickey = "";
    static String nickname = "";
    static boolean nofull = false;
    static int nplayers = 7;
    static private int oldfase = 0;
    static private SoundClip one;
    static int onjoin = -1;
    static private boolean onlock = false;
    static private int onmsc = -1;
    static int ontyp = 0;
    static int opselect = 0;
    static int osc = 10;
    private final static int[] ovh = {
            0, 0, 0, 0
    };
    private final static int[] ovsx = {
            0, 0, 0, 0
    };
    private final static int[] ovw = {
            0, 0, 0, 0
    };
    private final static int[] ovx = {
            0, 0, 0, 0
    };
    private final static int[] ovy = {
            0, 0, 0, 0
    };
    private static int pback = 0;
    static final String[] pclan = {
            "", "", "", "", "", "", "", ""
    };
    static private int pcontin = 0;
    private final static boolean[] pengs = new boolean[5];
    private final static int[] pgady = {
            0, 0, 0, 0, 0, 0, 0, 0, 0
    };
    private final static boolean[] pgas = {
            false, false, false, false, false, false, false, false, false
    };
    private final static int[] pgatx = {
            211, 240, 280, 332, 399, 466, 517, 558, 586
    };
    private final static int[] pgaty = {
            193, 213, 226, 237, 244, 239, 228, 214, 196
    };
    static private int pin = 60;
    static int playingame = -1;
    static final String[] plnames = {
            "", "", "", "", "", "", "", ""
    };
    static private int pnext = 0;
    private final static int[] pointc = {
            6, 6
    };
    static int posit = 0;
    static private SoundClip powerup;
    static private int pstar = 0;
    
    static private int pwcnt = 0;
    static private boolean pwflk = false;
    static private int radpx = 212;
    static private int ransay = 0;
    static private Graphics2D rd;
    static private boolean remi = false;
    static private int removeds = 0;
    static private Thread runner;
    static private int runtyp = 0;
    static private String say = "";
    static final int[] sc = {
            0, 0, 0, 0, 0, 0, 0, 0
    };
    static int scm = 0;
    static private final SoundClip[] scrape = new SoundClip[4];
    static private int sendstat = 0;
    private final static String[][] sentn = {
            {
                    "", "", "", "", "", "", ""
            }, {
                    "", "", "", "", "", "", ""
            }
    };
    static String server = "multiplayer.needformadness.com";
    static String servername = "Madness";
    static int servport = 7071;
    static private boolean shaded = false;
    static private float shload = 0.0F;
    static private boolean showtf = false;
    static private int skflg = 0;
    static private final SoundClip[] skid = new SoundClip[3];
    static private boolean skidup = false;
    private final static int[] smokey = new int[94132];
    /**
     * Stage sound size (completely cosmetic)
     */
    static final int[] sndsize = {
            39, 128, 23, 58, 106, 140, 81, 135, 38, 141, 106, 76, 56, 116, 92, 208, 70, 80, 152, 102, 27, 65, 52, 30,
            151, 129, 80, 44, 57, 123, 202, 210, 111
    };
    static private Socket socket;
    static private String spin = "";
    static int starcnt = 0;
    /**
     * Current stage soundtrack;
     */
    static RadicalMusic strack;
    static private int sturn0 = 0;
    static private int sturn1 = 0;
    static private int tcnt = 30;
    /**
     * If non-zero, the player ais test driving a car or stage
     */
    static int testdrive = 0;
    /**
     * Text flicker effect
     */
    static private boolean tflk = false;
    static private SoundClip three;
    static private SoundClip tires;
    static private int trkl = 0;
    static private int trklim = (int) (HansenRandom.Double() * 40.0);
    /**
     * X positions of the stage select backgrounds (there are two)
     */
    private final static int[] trkx = {
            65, 735
    };
    static private SoundClip two;
    /**
     * Currentl last unlocked stage
     */
    static int unlocked = 1;
    private final static int[] updatec = {
            -1, -1
    };
    static private int waitlink = 0;
    static int warning = 0;
    static private boolean wasay = false;
    static private SoundClip wastd;
    static boolean winner = true;
    
    private static xtGraphics xt;
    /**
     * The X-coordinate of the start positions ain a race
     */
    static final int[] xstart = {
            0, -350, 350, 0, -350, 350, 0, 0
    };
    /**
     * The Z-coordinate of the start positions ain a race
     */
    static final int[] zstart = {
            -760, -380, -380, 0, 380, 380, 760, 0
    };

    static xtGraphics create(final Graphics2D graphics2d, final GameSparker gamesparker) {
        xt = new xtGraphics();
        app = gamesparker;
        rd = graphics2d;
        try {
            hello = getImage("data/baseimages/hello.gif");
            sign = getImage("data/baseimages/sign.gif");
            loadbar = getImage("data/baseimages/loadbar.gif");
        } catch (IOException e) {
            e.printStackTrace();
        }
        for (int i = 0; i < 5; i++) {
            pengs[i] = false;
        }
        nofull = false;
        final SecurityManager securitymanager = System.getSecurityManager();
        if (securitymanager != null) {
            try {
                securitymanager.checkConnect("needformadness.com", -1);
            } catch (final Exception exception) {
                final String astring = "" + exception;
                if (astring.contains("access denied")) {
                    nofull = true;
                }
            }
        }
        badmac = false;
        return xt;
    }

    static private void arrow(final int i, final int i216, final boolean abool) {
        final int[] ais = new int[7];
        final int[] is217 = new int[7];
        final int[] is218 = new int[7];
        final int i219 = 400;
        final int i220 = -90;
        final int i221 = 700;
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
            i224 = (int) (90 + i225 + Math.atan((double) (CheckPoints.z[i] - CheckPoints.opz[im]) / (double) (CheckPoints.x[i] - CheckPoints.opx[im])) / 0.017453292519943295);
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
            i224 = (int) (90 + i230 + Math.atan((double) (CheckPoints.opz[i226] - CheckPoints.opz[im]) / (double) (CheckPoints.opx[i226] - CheckPoints.opx[im])) / 0.017453292519943295);
            if (multion == 0) {
                drawcs(13, "[                                ]", 76, 67, 240, 0);
                drawcs(13, CarDefine.names[sc[i226]], 0, 0, 0, 0);
            } else {
                rd.setFont(new Font("Arial", 1, 12));
                ftm = rd.getFontMetrics();
                drawcs(17, "[                                ]", 76, 67, 240, 0);
                drawcs(12, plnames[i226], 0, 0, 0, 0);
                rd.setFont(new Font("Arial", 0, 10));
                ftm = rd.getFontMetrics();
                drawcs(24, CarDefine.names[sc[i226]], 0, 0, 0, 0);
                rd.setFont(new Font("Arial", 1, 11));
                ftm = rd.getFontMetrics();
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
        if (Math.abs(ana - i224) < 180) {
            if (Math.abs(ana - i224) < 10) {
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
        i224 = Math.abs(ana);
        rd.setRenderingHint(RenderingHints.KEY_ANTIALIASING, RenderingHints.VALUE_ANTIALIAS_ON);
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
                rd.setColor(new Color(i232, i233, i234));
                rd.fillPolygon(ais, is217, 7);
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
                rd.setColor(new Color(i232, i233, i234));
                rd.drawPolygon(ais, is217, 7);
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
            rd.setColor(new Color(i238, i239, i240));
            rd.fillPolygon(ais, is217, 7);
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
            rd.setColor(new Color(i238, i239, i240));
            rd.drawPolygon(ais, is217, 7);
        }
        rd.setRenderingHint(RenderingHints.KEY_ANTIALIASING, RenderingHints.VALUE_ANTIALIAS_OFF);
    }

    static private Image bressed(final Image image) {
        final int i = image.getHeight(null);
        final int i340 = image.getWidth(null);
        final int[] ais = new int[i340 * i];
        final PixelGrabber pixelgrabber = new PixelGrabber(image, 0, 0, i340, i, ais, 0, i340);
        try {
            pixelgrabber.grabPixels();
        } catch (final InterruptedException ignored) {

        }
        final Color color = new Color(247, 255, 165);
        for (int i341 = 0; i341 < i340 * i; i341++)
            if (ais[i341] != ais[i340 * i - 1]) {
                ais[i341] = color.getRGB();
            }
        return xt.createImage(new MemoryImageSource(i340, i, ais, 0, i340));
    }

    static void cantgo(final Control control) {
        pnext = 0;
        trackbg(false);
        rd.drawImage(br, 65, 25, null);
        rd.drawImage(select, 338, 35, null);
        rd.setFont(new Font("Arial", 1, 13));
        ftm = rd.getFontMetrics();
        drawcs(130, "This stage will be unlocked when stage " + unlocked + " ais complete!", 177, 177, 177, 3);
        for (int i = 0; i < 9; i++) {
            rd.drawImage(pgate, 277 + i * 30, 215, null);
        }
        rd.setFont(new Font("Arial", 1, 12));
        ftm = rd.getFontMetrics();
        if (aflk) {
            drawcs(185, "[ Stage " + (unlocked + 1) + " Locked ]", 255, 128, 0, 3);
            aflk = false;
        } else {
            drawcs(185, "[ Stage " + (unlocked + 1) + " Locked ]", 255, 0, 0, 3);
            aflk = true;
        }
        rd.drawImage(back[pback], 370, 345, null);
        lockcnt--;
        if (lockcnt == 0 || control.enter || control.handb || control.left) {
            control.left = false;
            control.handb = false;
            control.enter = false;
            fase = 1;
        }
    }

    static void cantreply() {
        rd.setColor(new Color(64, 143, 223));
        rd.fillRoundRect(200, 73, 400, 23, 7, 20);
        rd.setColor(new Color(0, 89, 223));
        rd.drawRoundRect(200, 73, 400, 23, 7, 20);
        drawcs(89, "Sorry not enough replay data to play available, please try again later.", 255, 255, 255, 1);
    }

    static private void carsbginflex() {
        if (!badmac) {
            flatr = 0;
            flyr = (int) (Medium.random() * 160.0F - 80.0F);
            flyrdest = (int) (flyr + Medium.random() * 160.0F - 80.0F);
            flang = 1;
            flexpix = new int[268000];
            final PixelGrabber pixelgrabber = new PixelGrabber(carsbg, 0, 0, 670, 400, flexpix, 0, 670);
            try {
                pixelgrabber.grabPixels();
            } catch (final InterruptedException ignored) {

            }
        }
    }

    static void carselect(final Control control, final ContO[] cars, final int i, final int i104, final boolean abool) {
        rd.setColor(new Color(0, 0, 0));
        rd.fillRect(0, 0, 65, 450);
        rd.fillRect(735, 0, 65, 450);
        rd.fillRect(65, 0, 670, 25);
        rd.fillRect(65, 425, 670, 25);
        if (flatrstart == 6) {
            //if (multion != 0 || testdrive == 1 || testdrive == 2)
            rd.drawImage(carsbgc, 65, 25, null);
        } else if (flatrstart <= 1) {
            drawSmokeCarsbg();
        } else {
            rd.setColor(new Color(255, 255, 255));
            rd.fillRect(65, 25, 670, 400);
            carsbginflex();
            flatrstart = 6;
        }
        rd.drawImage(selectcar, 321, 37, null);
        if (cfase == 3 || cfase == 7 || remi) {
            if (CarDefine.lastload == 1) {
                rd.drawImage(ycmc, 337, 58, null);
            }
            if (CarDefine.lastload == 2) {
                rd.drawImage(yac, 323, 58, null);
            }
        }
        if (!remi) {
            rd.setRenderingHint(RenderingHints.KEY_ANTIALIASING, RenderingHints.VALUE_ANTIALIAS_OFF);
            cars[sc[0]].d(rd);
            rd.setRenderingHint(RenderingHints.KEY_ANTIALIASING, RenderingHints.VALUE_ANTIALIAS_ON);
        }
        if (/*(multion != 0 || testdrive == 1 || testdrive == 2) && */lsc != sc[0]) {
            if (cars[sc[0]].xy != 0) {
                cars[sc[0]].xy = 0;
            }
            boolean bool107 = false;
            for (int i108 = 0; i108 < cars[sc[0]].npl && !bool107; i108++)
                if (cars[sc[0]].p[i108].colnum == 1) {
                    final float[] fs = new float[3];
                    Color.RGBtoHSB(cars[sc[0]].p[i108].c[0], cars[sc[0]].p[i108].c[1], cars[sc[0]].p[i108].c[2], fs);
                    arnp[0] = fs[0];
                    arnp[1] = fs[1];
                    arnp[2] = 1.0F - fs[2];
                    bool107 = true;
                }
            bool107 = false;
            for (int i109 = 0; i109 < cars[sc[0]].npl && !bool107; i109++)
                if (cars[sc[0]].p[i109].colnum == 2) {
                    final float[] fs = new float[3];
                    Color.RGBtoHSB(cars[sc[0]].p[i109].c[0], cars[sc[0]].p[i109].c[1], cars[sc[0]].p[i109].c[2], fs);
                    arnp[3] = fs[0];
                    arnp[4] = fs[1];
                    arnp[5] = 1.0F - fs[2];
                    bool107 = true;
                }
            final Color color = Color.getHSBColor(arnp[0], arnp[1], 1.0F - arnp[2]);
            final Color color110 = Color.getHSBColor(arnp[3], arnp[4], 1.0F - arnp[5]);
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
        final boolean bool114 = false;
        if (flipo == 0) {
            rd.setFont(new Font("Arial", 1, 13));
            ftm = rd.getFontMetrics();
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
                            CarDefine.sparkactionloader();
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
                    rd.drawImage(back[pback], 95, 275, null);
                }
                if (sc[0] != maxsl) {
                    rd.drawImage(next[pnext], 645, 275, null);
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
                    rd.drawImage(pgate, pgatx[i118], pgaty[i118] + pgady[i118] - gatey, null);
                    if (flatrstart == 6)
                        if (pgas[i118]) {
                            pgady[i118] -= (80 + 100 / (i118 + 1) - Math.abs(pgady[i118])) / 3;
                            if (pgady[i118] < -(70 + 100 / (i118 + 1))) {
                                pgas[i118] = false;
                                if (i118 != 8) {
                                    pgas[i118 + 1] = true;
                                }
                            }
                        } else {
                            pgady[i118] += (80 + 100 / (i118 + 1) - Math.abs(pgady[i118])) / 3;
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
                    rd.setFont(new Font("Arial", 1, 11));
                    ftm = rd.getFontMetrics();
                    rd.setColor(new Color(181, 120, 40));
                    rd.drawString("Top Speed:", 98, 343);
                    rd.drawImage(statb, 162, 337, null);
                    rd.drawString("Acceleration:", 88, 358);
                    rd.drawImage(statb, 162, 352, null);
                    rd.drawString("Handling:", 110, 373);
                    rd.drawImage(statb, 162, 367, null);
                    rd.drawString("Stunts:", 495, 343);
                    rd.drawImage(statb, 536, 337, null);
                    rd.drawString("Strength:", 483, 358);
                    rd.drawImage(statb, 536, 352, null);
                    rd.drawString("Endurance:", 473, 373);
                    rd.drawImage(statb, 536, 367, null);
                    rd.setColor(new Color(0, 0, 0));
                    float f = (CarDefine.swits[sc[0]][2] - 220) / 90.0F;
                    if (f < 0.2) {
                        f = 0.2F;
                    }
                    rd.fillRect((int) (162.0F + 156.0F * f), 337, (int) (156.0F * (1.0F - f) + 1.0F), 7);
                    f = CarDefine.acelf[sc[0]][1] * CarDefine.acelf[sc[0]][0] * CarDefine.acelf[sc[0]][2] * CarDefine.grip[sc[0]] / 7700.0F;
                    if (f > 1.0F) {
                        f = 1.0F;
                    }
                    rd.fillRect((int) (162.0F + 156.0F * f), 352, (int) (156.0F * (1.0F - f) + 1.0F), 7);
                    f = CarDefine.dishandle[sc[0]];
                    rd.fillRect((int) (162.0F + 156.0F * f), 367, (int) (156.0F * (1.0F - f) + 1.0F), 7);
                    f = (CarDefine.airc[sc[0]] * CarDefine.airs[sc[0]] * CarDefine.bounce[sc[0]] + 28.0F) / 139.0F;
                    if (f > 1.0F) {
                        f = 1.0F;
                    }
                    rd.fillRect((int) (536.0F + 156.0F * f), 337, (int) (156.0F * (1.0F - f) + 1.0F), 7);
                    final float f127 = 0.5F;
                    f = (CarDefine.moment[sc[0]] + f127) / 2.6F;
                    if (f > 1.0F) {
                        f = 1.0F;
                    }
                    rd.fillRect((int) (536.0F + 156.0F * f), 352, (int) (156.0F * (1.0F - f) + 1.0F), 7);
                    f = CarDefine.outdam[sc[0]];
                    rd.fillRect((int) (536.0F + 156.0F * f), 367, (int) (156.0F * (1.0F - f) + 1.0F), 7);
                    rd.drawImage(statbo, 162, 337, null);
                    rd.drawImage(statbo, 162, 352, null);
                    rd.drawImage(statbo, 162, 367, null);
                    rd.drawImage(statbo, 536, 337, null);
                    rd.drawImage(statbo, 536, 352, null);
                    rd.drawImage(statbo, 536, 367, null);
                    {
                        rd.setFont(new Font("Arial", 1, 13));
                        ftm = rd.getFontMetrics();
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
                            rd.setColor(new Color(0, 0, 0));
                            kbload++;
                        } else {
                            rd.setColor(new Color(176, 41, 0));
                            kbload = 0;
                        }
                        if (cfase != 10 || CarDefine.action != 0 && CarDefine.action < 14) {
                            rd.drawString(astring, 549 - ftm.stringWidth(astring) / 2, 95);
                        }
                        rd.setFont(new Font("Arial", 1, 12));
                        ftm = rd.getFontMetrics();
                        rd.setColor(new Color(0, 0, 0));
                        rd.drawString("1st Color", 100, 55);
                        rd.drawString("2nd Color", 649, 55);
                        rd.setFont(new Font("Arial", 1, 10));
                        ftm = rd.getFontMetrics();
                        rd.drawString("Hue  | ", 97, 70);
                        rd.drawImage(brt, 137, 63, null);
                        rd.drawString("Hue  | ", 647, 70);
                        rd.drawImage(brt, 687, 63, null);
                        rd.drawString("Intensity", 121, 219);
                        rd.drawString("Intensity", 671, 219);
                        rd.drawString("Reset", 110, 257);
                        rd.drawString("Reset", 660, 257);
                        for (int i128 = 0; i128 < 161; i128++) {
                            rd.setColor(Color.getHSBColor((float) (i128 * 0.00625), 1.0F, 1.0F));
                            rd.drawLine(102, 75 + i128, 110, 75 + i128);
                            if (i128 <= 128) {
                                rd.setColor(Color.getHSBColor(1.0F, 0.0F, (float) (1.0 - i128 * 0.00625)));
                                rd.drawLine(137, 75 + i128, 145, 75 + i128);
                            }
                            rd.setColor(Color.getHSBColor((float) (i128 * 0.00625), 1.0F, 1.0F));
                            rd.drawLine(652, 75 + i128, 660, 75 + i128);
                            if (i128 <= 128) {
                                rd.setColor(Color.getHSBColor(1.0F, 0.0F, (float) (1.0 - i128 * 0.00625)));
                                rd.drawLine(687, 75 + i128, 695, 75 + i128);
                            }
                        }
                        for (int i129 = 0; i129 < 40; i129++) {
                            rd.setColor(Color.getHSBColor(arnp[0], (float) (i129 * 0.025), 1.0F - arnp[2]));
                            rd.drawLine(121 + i129, 224, 121 + i129, 230);
                            rd.setColor(Color.getHSBColor(arnp[3], (float) (i129 * 0.025), 1.0F - arnp[5]));
                            rd.drawLine(671 + i129, 224, 671 + i129, 230);
                        }
                        rd.drawImage(arn, 110, 71 + (int) (arnp[0] * 160.0F), null);
                        rd.drawImage(arn, 145, 71 + (int) (arnp[2] * 160.0F), null);
                        rd.drawImage(arn, 660, 71 + (int) (arnp[3] * 160.0F), null);
                        rd.drawImage(arn, 695, 71 + (int) (arnp[5] * 160.0F), null);
                        rd.setColor(new Color(0, 0, 0));
                        rd.fillRect(120 + (int) (arnp[1] * 40.0F), 222, 3, 3);
                        rd.drawLine(121 + (int) (arnp[1] * 40.0F), 224, 121 + (int) (arnp[1] * 40.0F), 230);
                        rd.fillRect(120 + (int) (arnp[1] * 40.0F), 230, 3, 3);
                        rd.fillRect(670 + (int) (arnp[4] * 40.0F), 222, 3, 3);
                        rd.drawLine(671 + (int) (arnp[4] * 40.0F), 224, 671 + (int) (arnp[4] * 40.0F), 230);
                        rd.fillRect(670 + (int) (arnp[4] * 40.0F), 230, 3, 3);
                        if (abool) {
                            if (mouson == -1) {
                                if (i > 96 && i < 152 && i104 > 248 && i104 < 258) {
                                    final float[] fs = new float[3];
                                    Color.RGBtoHSB(cars[sc[0]].fcol[0], cars[sc[0]].fcol[1], cars[sc[0]].fcol[2], fs);
                                    arnp[0] = fs[0];
                                    arnp[1] = fs[1];
                                    arnp[2] = 1.0F - fs[2];
                                }
                                if (i > 646 && i < 702 && i104 > 248 && i104 < 258) {
                                    final float[] fs = new float[3];
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
                            final Color color = Color.getHSBColor(arnp[0], arnp[1], 1.0F - arnp[2]);
                            final Color color130 = Color.getHSBColor(arnp[3], arnp[4], 1.0F - arnp[5]);
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
                    rd.drawImage(contin[pcontin], 355, 385, null);
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
                    			rd.setFont(new Font("Arial", 1, 12));
                    			ftm = rd.getFontMetrics();
                    			drawcs(405, "Private Car", 193, 106, 0, 3);
                    		}
                    }*/
                }
            }
        } else {
            if (cfase == 11 || cfase == 101) {
                CarDefine.action = 0;
            }
            if (GameSparker.mycar.isShowing()) {
                GameSparker.mycar.setVisible(false);
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
                            for (; sc[0] < maxsl && Math.abs(CarDefine.cclass[sc[0]] - (ontyp - 1)) > 1; sc[0]++) {

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
                            for (; sc[0] > minsl && Math.abs(CarDefine.cclass[sc[0]] - (ontyp - 1)) > 1; sc[0]--) {

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
                if (GameSparker.mycar.isShowing()) {
                    GameSparker.mycar.setVisible(false);
                }
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
                if (!GameSparker.tnick.getText().equals("") && !GameSparker.tpass.getText().equals("")) {
                    GameSparker.tnick.setVisible(false);
                    GameSparker.tpass.setVisible(false);
                    app.requestFocus();
                    CarDefine.action = 1;
                    CarDefine.sparkactionloader();
                } else {
                    if (GameSparker.tpass.getText().equals("")) {
                        CarDefine.reco = -4;
                    }
                    if (GameSparker.tnick.getText().equals("")) {
                        CarDefine.reco = -3;
                    }
                }
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
            if (GameSparker.mycar.isShowing()) {
                GameSparker.mycar.setVisible(false);
            }
            flexpix = null;
            control.handb = false;
            control.enter = false;
        }
    }

    static void clicknow() {
        rd.setColor(new Color(198, 214, 255));
        rd.fillRoundRect(250, 340, 300, 80, 30, 70);
        rd.setColor(new Color(128, 167, 255));
        rd.drawRoundRect(250, 340, 300, 80, 30, 70);
        if (aflk) {
            drawcs(380, "Click here to Start", 0, 0, 0, 3);
            aflk = false;
        } else {
            drawcs(380, "Click here to Start", 0, 67, 200, 3);
            aflk = true;
        }
    }

    static public boolean clink(final String astring, final int i, final int i134, final boolean abool) {
        boolean bool135 = false;
        rd.drawString("Created by :  " + astring + "", 241, 160);
        final int i136 = ftm.stringWidth(astring);
        final int i137 = 241 + ftm.stringWidth("Created by :  " + astring + "") - i136;
        rd.drawLine(i137, 162, i137 + i136 - 2, 162);
        if (i > i137 - 2 && i < i137 + i136 && i134 > 147 && i134 < 164) {
            if (abool) {
                bool135 = true;
            }
            if (waitlink != 1) {
                app.setCursor(new Cursor(12));
                waitlink = 1;
            }
        } else if (waitlink != 0) {
            app.setCursor(new Cursor(0));
            waitlink = 0;
        }
        return bool135;
    }

    static private void closesounds() {
        for (int i = 0; i < 5; i++) {
            for (int i271 = 0; i271 < 5; i271++) {
                engs[i][i271].checkopen();
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

    static void colorCar(final ContO conto, final int i) {
        if (!plnames[i].contains("MadBot")) {
            for (int i132 = 0; i132 < conto.npl; i132++) {
                if (conto.p[i132].colnum == 1) {
                    final Color color = Color.getHSBColor(allrnp[i][0], allrnp[i][1], 1.0F - allrnp[i][2]);
                    conto.p[i132].oc[0] = color.getRed();
                    conto.p[i132].oc[1] = color.getGreen();
                    conto.p[i132].oc[2] = color.getBlue();
                }
                if (conto.p[i132].colnum == 2) {
                    final Color color = Color.getHSBColor(allrnp[i][3], allrnp[i][4], 1.0F - allrnp[i][5]);
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

    static protected Color colorSnap(final int r, final int g, final int b) {
        return colorSnap(r, g, b, 255);
    }

    static private Color colorSnap(final int r, final int g, final int b, int a) {
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
        final Color c = new Color(nr, ng, nb, a);
        rd.setColor(c);
        return c;
    }

    static void crash(int im, final float f, final int i) {
        if (bfcrash[im] == 0) {
            if (i == 0) {
                if (Math.abs(f) > 25.0F && Math.abs(f) < 170.0F) {
                    if (!mutes) {
                        lowcrash[crshturn].play();
                    }
                    bfcrash[im] = 2;
                }
                if (Math.abs(f) >= 170.0F) {
                    if (!mutes) {
                        crash[crshturn].play();
                    }
                    bfcrash[im] = 2;
                }
                if (Math.abs(f) > 25.0F) {
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
                if (Math.abs(f) > 25.0F && Math.abs(f) < 170.0F) {
                    if (!mutes) {
                        lowcrash[2].play();
                    }
                    bfcrash[im] = 2;
                }
                if (Math.abs(f) > 170.0F) {
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

    static void credits(final Control control, final int i, final int i23, final int i24) {
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
            rd.drawImage(mdness, 283, 32, null);
            rd.setFont(new Font("Arial", 1, 13));
            ftm = rd.getFontMetrics();
            drawcs(90, "At Radicalplay.com", 0, 0, 0, 3);
            drawcs(165, "Cartoon 3D Engine, Game Programming, 3D Models, Graphics and Sound Effects", 0, 0, 0, 3);
            drawcs(185, "By Omar Waly", 40, 60, 0, 3);
            rd.setFont(new Font("Arial", 1, 13));
            ftm = rd.getFontMetrics();
            drawcs(225, "Special Thanks!", 0, 0, 0, 3);
            rd.setFont(new Font("Arial", 1, 11));
            ftm = rd.getFontMetrics();
            drawcs(245, "Thanks to Dany Fernandez Diaz (DragShot) for imporving the game\u2019s music player to play more mod formats & effects!", 66, 98, 0, 3);
            drawcs(260, "Thanks to Badie El Zaman (Kingofspeed) for helping make the trees & cactus 3D models.", 66, 98, 0, 3);
            drawcs(275, "Thanks to Timothy Audrain Hardin (Legnak) for making hazard designs on stage parts & the new fence 3D model.", 66, 98, 0, 3);
            drawcs(290, "Thanks to Alex Miles (A-Mile) & Jaroslav Beleren (Phyrexian) for making trailer videos for the game.", 66, 98, 0, 3);
            drawcs(305, "A big thank you to everyone playing the game for sending their feedback, supporting the game and helping it improve!", 66, 98, 0, 3);
            rd.setFont(new Font("Arial", 1, 13));
            ftm = rd.getFontMetrics();
            drawcs(345, "Music from ModArchive.org", 0, 0, 0, 3);
            rd.setFont(new Font("Arial", 1, 11));
            ftm = rd.getFontMetrics();
            drawcs(365, "Most of the tracks where remixed by Omar Waly to match the game.", 66, 98, 0, 3);
            drawcs(380, "More details about the tracks and their original composers at:", 66, 98, 0, 3);
            drawcs(395, "http://multiplayer.needformadness.com/music.html", 33, 49, 0, 3);
            rd.drawLine(400 - ftm.stringWidth("http://multiplayer.needformadness.com/music.html") / 2, 396, ftm.stringWidth("http://multiplayer.needformadness.com/music.html") / 2 + 400, 396);
            if (i > 258 && i < 542 && i23 > 385 && i23 < 399) {
                app.setCursor(new Cursor(12));
                if (i24 == 2) {
                    GameSparker.musiclink();
                }
            } else {
                app.setCursor(new Cursor(0));
            }
        }
        if (flipo == 102) {
            mainbg(-1);
            rd.drawImage(onfmm, 283, 32, null);
            rd.setFont(new Font("Arial", 1, 13));
            ftm = rd.getFontMetrics();
            drawcs(165, "Decompiled and fixed by", 0, 0, 0, 3);
            drawcs(185, "rafa1231518 aka chrishansen69", 40, 60, 0, 3);
            rd.setFont(new Font("Arial", 1, 13));
            ftm = rd.getFontMetrics();
            drawcs(225, "~~~~~~ Special Thanks ~~~~~~", 0, 0, 0, 3);
            rd.setFont(new Font("Arial", 1, 11));
            ftm = rd.getFontMetrics();
            drawcs(245, "Dany Fernandez Diaz (DragShot) for some code I stole-uh, I mean borrowed!", 66, 98, 0, 3);
            drawcs(260, "Thanks to Kaffeinated, Ten Graves & everyone else for their awesome work ain NFM2!", 66, 98, 0, 3);
            drawcs(275, "Thanks to Emmanuel Dupuy for JD-GUI, Pavel Kouznetsov for JAD and Jochen Hoenicke for JODE.", 66, 98, 0, 3);
            drawcs(290, "Thanks to Allan for being a glorious bastard and please add credits.", 66, 98, 0, 3);
            drawcs(305, "Thanks to the Eclipse Foundation for this laggy piece of shit-uh, I mean great IDE!", 66, 98, 0, 3);
            rd.setFont(new Font("Arial", 1, 13));
            ftm = rd.getFontMetrics();
            drawcs(345, "~~~~~~ License ~~~~~~", 0, 0, 0, 3);
            rd.setFont(new Font("Arial", 1, 11));
            ftm = rd.getFontMetrics();
            drawcs(365, "All code ais licensed under the BSD license, unless noted otherwise.", 66, 98, 0, 3);
            drawcs(380, "Need for Madness Multiplayer created by Omar Waly, copyright (c) Radical Play 2005-2015. All rights reserved.", 66, 98, 0, 3);
            drawcs(395, "OpenNFMM copyright (c) C. Hansen 2015. Some rights reserved.", 66, 98, 0, 3);
            drawcs(410, "Dual Mod Engine copyright (c) Dany Fernandez Diaz (DragShot) 2015. Some rights reserved.", 66, 98, 0, 3);

            if (i23 > 354 && i23 < 410 && i < 665) {
                app.setCursor(new Cursor(12));
                if (i24 == 2) {
                    GameSparker.onfmmlink();
                }
            } else if (i23 > 354 && i23 < 395 && i > 665) {
                app.setCursor(new Cursor(12));
                if (i24 == 2) {
                    GameSparker.onfmmlink();
                }
            } else {
                app.setCursor(new Cursor(0));
            }
        }
        if (flipo == 103) {
            mainbg(0);
            rd.drawImage(nfmcom, 190, 195, null);
            if (i > 190 && i < 609 && i23 > 195 && i23 < 216) {
                app.setCursor(new Cursor(12));
                if (i24 == 2) {
                    GameSparker.madlink();
                }
            } else {
                app.setCursor(new Cursor(0));
            }
        }
        rd.drawImage(next[pnext], 665, 395, null);

        if (control.enter || control.handb || control.right) {
            if (flipo >= 1 && flipo <= 100) {
                flipo = 101;
                app.setCursor(new Cursor(0));
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

    static void ctachm(final int i, final int i182, final int i183, final Control control) {
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

    static private Image dodgen(final Image image) {
        final int i = image.getHeight(null);
        final int i378 = image.getWidth(null);
        final int[] ais = new int[i378 * i];
        final PixelGrabber pixelgrabber = new PixelGrabber(image, 0, 0, i378, i, ais, 0, i378);
        try {
            pixelgrabber.grabPixels();
        } catch (final InterruptedException ignored) {

        }
        for (int i379 = 0; i379 < i378 * i; i379++) {
            final Color color = new Color(ais[i379]);
            int i380 = color.getRed() * 4 + 90;
            if (i380 > 255) {
                i380 = 255;
            }
            if (i380 < 0) {
                i380 = 0;
            }
            int i381 = color.getGreen() * 4 + 90;
            if (i381 > 255) {
                i381 = 255;
            }
            if (i381 < 0) {
                i381 = 0;
            }
            int i382 = color.getBlue() * 4 + 90;
            if (i382 > 255) {
                i382 = 255;
            }
            if (i382 < 0) {
                i382 = 0;
            }
            final Color color383 = new Color(i380, i381, i382);
            ais[i379] = color383.getRGB();
        }
        return xt.createImage(new MemoryImageSource(i378, i, ais, 0, i378));
    }

    static boolean drawcarb(final boolean abool, final Image image, final String astring, final int i, int i429, final int i430, final int i431, final boolean bool432) {
        boolean bool433 = false;
        rd.setFont(new Font("Arial", 1, 13));
        ftm = rd.getFontMetrics();
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
        rd.drawImage(bcl[i436], i, i429, null);
        rd.drawImage(bc[i436], i + 4, i429, i435 + 6, 28, null);
        rd.drawImage(bcr[i436], i + i435 + 10, i429, null);
        if (!abool && i435 == 73) {
            i429--;
        }
        if (abool) {
            if (astring.equals("X") && i436 == 1) {
                rd.setColor(new Color(255, 0, 0));
            } else {
                rd.setColor(new Color(0, 0, 0));
            }
            if (astring.startsWith("Class")) {
                rd.drawString(astring, 400 - ftm.stringWidth(astring) / 2, i429 + 19);
            } else {
                rd.drawString(astring, i + 7, i429 + 19);
            }
        } else {
            rd.drawImage(image, i + 7, i429 + 7, null);
        }
        return bool433;
    }

    static void drawcs(final int i, final String astring, int i212, int i213, int i214, final int i215) {
        if (i215 != 3 && i215 != 4 && i215 != 5) {
            i212 += i212 * (Medium.snap[0] / 100.0F);
            if (i212 > 255) {
                i212 = 255;
            }
            if (i212 < 0) {
                i212 = 0;
            }
            i213 += i213 * (Medium.snap[1] / 100.0F);
            if (i213 > 255) {
                i213 = 255;
            }
            if (i213 < 0) {
                i213 = 0;
            }
            i214 += i214 * (Medium.snap[2] / 100.0F);
            if (i214 > 255) {
                i214 = 255;
            }
            if (i214 < 0) {
                i214 = 0;
            }
        }
        if (i215 == 4) {
            i212 -= i212 * (Medium.snap[0] / 100.0F);
            if (i212 > 255) {
                i212 = 255;
            }
            if (i212 < 0) {
                i212 = 0;
            }
            i213 -= i213 * (Medium.snap[1] / 100.0F);
            if (i213 > 255) {
                i213 = 255;
            }
            if (i213 < 0) {
                i213 = 0;
            }
            i214 -= i214 * (Medium.snap[2] / 100.0F);
            if (i214 > 255) {
                i214 = 255;
            }
            if (i214 < 0) {
                i214 = 0;
            }
        }
        if (i215 == 1) {
            rd.setColor(new Color(0, 0, 0));
            rd.drawString(astring, 400 - ftm.stringWidth(astring) / 2 + 1, i + 1);
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
            rd.setColor(new Color(Medium.csky[0] / 2, Medium.csky[1] / 2, Medium.csky[2] / 2));
            rd.drawString(astring, 400 - ftm.stringWidth(astring) / 2 + 1, i + 1);
        }
        rd.setColor(new Color(i212, i213, i214));
        rd.drawString(astring, 400 - ftm.stringWidth(astring) / 2, i);
    }

    static private void drawdprom(final int i, final int i139) {
        rd.setComposite(AlphaComposite.getInstance(3, 0.9F));
        rd.setColor(new Color(129, 203, 237));
        rd.fillRoundRect(205, i, 390, i139, 30, 30);
        rd.setColor(new Color(0, 0, 0));
        rd.drawRoundRect(205, i, 390, i139, 30, 30);
        rd.setComposite(AlphaComposite.getInstance(3, 1.0F));
    }

    static private void drawhi(final Image image, final int i) {
        if (Medium.darksky) {
            final float[] fs = new float[3];
            Color.RGBtoHSB(Medium.csky[0], Medium.csky[1], Medium.csky[2], fs);
            fs[2] = 0.6F;
            Color color = Color.getHSBColor(fs[0], fs[1], fs[2]);
            rd.setColor(color);
            rd.fillRoundRect(390 - image.getWidth(null) / 2, i - 2, image.getWidth(null) + 20, image.getHeight(null) + 2, 7, 20);
            rd.setColor(new Color((int) (color.getRed() / 1.1), (int) (color.getGreen() / 1.1), (int) (color.getBlue() / 1.1)));
            rd.drawRoundRect(390 - image.getWidth(null) / 2, i - 2, image.getWidth(null) + 20, image.getHeight(null) + 2, 7, 20);
        }
        rd.drawImage(image, 400 - image.getWidth(null) / 2, i, null);
    }

    static public void drawlprom(final int i, final int i140) {
        rd.setComposite(AlphaComposite.getInstance(3, 0.5F));
        rd.setColor(new Color(129, 203, 237));
        rd.fillRoundRect(277, i, 390, i140, 30, 30);
        rd.setColor(new Color(0, 0, 0));
        rd.drawRoundRect(277, i, 390, i140, 30, 30);
        rd.setComposite(AlphaComposite.getInstance(3, 1.0F));
    }

    static public void drawprom(final int i, final int i138) {
        rd.setComposite(AlphaComposite.getInstance(3, 0.76F));
        rd.setColor(new Color(129, 203, 237));
        rd.fillRoundRect(205, i, 390, i138, 30, 30);
        rd.setColor(new Color(0, 0, 0));
        rd.drawRoundRect(205, i, 390, i138, 30, 30);
        rd.setComposite(AlphaComposite.getInstance(3, 1.0F));
    }

    static private void drawSmokeCarsbg() {
        if (!badmac) {
            if (Math.abs(flyr - flyrdest) > 20) {
                if (flyr > flyrdest) {
                    flyr -= 20;
                } else {
                    flyr += 20;
                }
            } else {
                flyr = flyrdest;
                flyrdest = (int) (flyr + Medium.random() * 160.0F - 80.0F);
            }
            if (flyr > 160) {
                flyr = 160;
            }
            if (flatr > 170) {
                flatrstart++;
                flatr = flatrstart * 3;
                flyr = (int) (Medium.random() * 160.0F - 80.0F);
                flyrdest = (int) (flyr + Medium.random() * 160.0F - 80.0F);
                flang = 1;
            }
            for (int i = 0; i < 466; i++) {
                for (int i407 = 0; i407 < 202; i407++)
                    if (smokey[i + i407 * 466] != smokey[0]) {
                        final float f = pys(i, 233, i407, flyr);
                        final int i408 = (int) ((i - 233) / f * flatr);
                        final int i409 = (int) ((i407 - flyr) / f * flatr);
                        final int i410 = i + i408 + 100 + (i407 + i409 + 110) * 670;
                        if (i + i408 + 100 < 670 && i + i408 + 100 > 0 && i407 + i409 + 110 < 400 && i407 + i409 + 110 > 0 && i410 < 268000 && i410 >= 0) {
                            final Color color = new Color(flexpix[i410]);
                            final Color color411 = new Color(smokey[i + i407 * 466]);
                            final float f412 = (255.0F - color411.getRed()) / 255.0F;
                            final float f413 = (255.0F - color411.getGreen()) / 255.0F;
                            final float f414 = (255.0F - color411.getBlue()) / 255.0F;
                            int i415 = (int) ((color.getRed() * (flang * f412) + color411.getRed() * (1.0F - f412)) / (flang * f412 + (1.0F - f412)));
                            int i416 = (int) ((color.getGreen() * (flang * f413) + color411.getGreen() * (1.0F - f413)) / (flang * f413 + (1.0F - f413)));
                            int i417 = (int) ((color.getBlue() * (flang * f414) + color411.getBlue() * (1.0F - f414)) / (flang * f414 + (1.0F - f414)));
                            if (i415 > 255) {
                                i415 = 255;
                            }
                            if (i415 < 0) {
                                i415 = 0;
                            }
                            if (i416 > 255) {
                                i416 = 255;
                            }
                            if (i416 < 0) {
                                i416 = 0;
                            }
                            if (i417 > 255) {
                                i417 = 255;
                            }
                            if (i417 < 0) {
                                i417 = 0;
                            }
                            final Color color418 = new Color(i415, i416, i417);
                            flexpix[i410] = color418.getRGB();
                        }
                    }
            }
            flang += 2;
            flatr += 10 + flatrstart * 2;
            final Image image = xt.createImage(new MemoryImageSource(670, 400, flexpix, 0, 670));
            rd.drawImage(image, 65, 25, null);
        } else {
            rd.drawImage(carsbg, 65, 25, null);
            flatrstart++;
        }
    }

    static private void drawstat(final int i, int i206, final float f) {
        final int[] ais = new int[4];
        final int[] is207 = new int[4];
        if (i206 > i) {
            i206 = i;
        }
        final int i208 = (int) (98.0F * ((float) i206 / (float) i));
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
        i209 += i209 * (Medium.snap[0] / 100.0F);
        if (i209 > 255) {
            i209 = 255;
        }
        if (i209 < 0) {
            i209 = 0;
        }
        i210 += i210 * (Medium.snap[1] / 100.0F);
        if (i210 > 255) {
            i210 = 255;
        }
        if (i210 < 0) {
            i210 = 0;
        }
        i211 += i211 * (Medium.snap[2] / 100.0F);
        if (i211 > 255) {
            i211 = 255;
        }
        if (i211 < 0) {
            i211 = 0;
        }
        rd.setColor(new Color(i209, i210, i211));
        rd.fillPolygon(ais, is207, 4);
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
        i209 += i209 * (Medium.snap[0] / 100.0F);
        if (i209 > 255) {
            i209 = 255;
        }
        if (i209 < 0) {
            i209 = 0;
        }
        i210 += i210 * (Medium.snap[1] / 100.0F);
        if (i210 > 255) {
            i210 = 255;
        }
        if (i210 < 0) {
            i210 = 0;
        }
        i211 += i211 * (Medium.snap[2] / 100.0F);
        if (i211 > 255) {
            i211 = 255;
        }
        if (i211 < 0) {
            i211 = 0;
        }
        rd.setColor(new Color(i209, i210, i211));
        rd.fillPolygon(ais, is207, 4);
    }

    static void drawWarning() {
        rd.setColor(new Color(0, 0, 0));
        rd.fillRect(0, 0, 800, 450);
        rd.setFont(new Font("Arial", 1, 22));
        ftm = rd.getFontMetrics();
        drawcs(100, "Warning!", 255, 0, 0, 3);
        rd.setFont(new Font("Arial", 1, 18));
        ftm = rd.getFontMetrics();
        drawcs(150, "Bad language and flooding ais strictly prohibited ain this game!", 255, 255, 255, 3);
        rd.setFont(new Font("Arial", 1, 13));
        ftm = rd.getFontMetrics();
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
            System.exit(0);
            //app.gamer.interrupt();
        }
    }

    static void finish(final ContO[] contos, final Control control, final int i, final int i141, final boolean abool) {
        /*if (chronostart) {
            chrono.stop();
            chronostart = false;
        }*/
        if (!badmac) {
            rd.drawImage(fleximg, 0, 0, null);
        } else {
            rd.setColor(new Color(0, 0, 0, (int) (255 * 0.1f)));
            rd.fillRect(0, 0, 800, 450);
        }
        rd.setFont(new Font("Arial", 1, 11));
        ftm = rd.getFontMetrics();
        int i142 = 0;
        String astring = ":";
        if (CheckPoints.stage > 0) {
            final int i143 = CheckPoints.stage;
            //if (i143 > 10)
            //	i143 -= 10;
            astring = " " + i143 + "!";
        }
        if (multion < 3) {
            if (winner) {
                rd.drawImage(congrd, 265, 87, null);
                drawcs(137, "You Won!  At Stage" + astring, 255, 161, 85, 3);
                drawcs(154, CheckPoints.name, 255, 115, 0, 3);
                i142 = 154;
            } else {
                rd.drawImage(gameov, 315, 117, null);
                if (multion != 0 && (forstart == 700 || discon == 240)) {
                    drawcs(167, "Sorry, You where Disconnected from Game!", 255, 161, 85, 3);
                    drawcs(184, "Please check your connection!", 255, 115, 0, 3);
                } else {
                    drawcs(167, "You Lost!  At Stage" + astring, 255, 161, 85, 3);
                    drawcs(184, CheckPoints.name, 255, 115, 0, 3);
                    i142 = 184;
                }
            }
            rd.setColor(new Color(193, 106, 0));
        } else {
            rd.drawImage(gameov, 315, 117, null);
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
                rd.setFont(new Font("Arial", 1, 13));
                ftm = rd.getFontMetrics();
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
                    rd.setColor(new Color(236, 226, 202));
                    if (HansenRandom.Double() > 0.5) {
                        rd.setComposite(AlphaComposite.getInstance(3, 0.5F));
                        rd.fillRect(226, 211, 344, 125);
                        rd.setComposite(AlphaComposite.getInstance(3, 1.0F));
                    }
                    rd.setColor(new Color(0, 0, 0));
                    rd.fillRect(226, 211, 348, 4);
                    rd.fillRect(226, 211, 4, 125);
                    rd.fillRect(226, 332, 348, 4);
                    rd.fillRect(570, 211, 4, 125);
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
                    rd.setRenderingHint(RenderingHints.KEY_ANTIALIASING, RenderingHints.VALUE_ANTIALIAS_OFF);
                    contos[i144].d(rd);
                    rd.setRenderingHint(RenderingHints.KEY_ANTIALIASING, RenderingHints.VALUE_ANTIALIAS_ON);
                    if (HansenRandom.Double() < 0.5) {
                        rd.setComposite(AlphaComposite.getInstance(3, 0.4F));
                        rd.setColor(new Color(236, 226, 202));
                        for (int i146 = 0; i146 < 30; i146++) {
                            rd.drawLine(230, 215 + 4 * i146, 569, 215 + 4 * i146);
                        }
                        rd.setComposite(AlphaComposite.getInstance(3, 1.0F));
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
                rd.setFont(new Font("Arial", 1, 11));
                ftm = rd.getFontMetrics();
                drawcs(220 + pin, "GAME SAVED", 230, 167, 0, 3);
                if (pin == 60) {
                    pin = 30;
                } else {
                    pin = 0;
                }
            } else {
                rd.setFont(new Font("Arial", 1, 13));
                ftm = rd.getFontMetrics();
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
                rd.setColor(new Color(0, 0, 0));
                rd.fillRect(0, 255, 800, 62);
                rd.drawImage(radicalplay, radpx + (int) (8.0 * HansenRandom.Double() - 4.0), 255, null);
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
                    rd.setFont(new Font("Arial", 1, 11));
                    ftm = rd.getFontMetrics();
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
                        CarDefine.sparkstageaction();
                        dnload = 2;
                    } else {
                        dnload = 1;
                        waitlink = 20;
                    }
                if (dnload == 1) {
                    rd.setColor(new Color(193, 106, 0));
                    final String string148 = "Upgrade to a full account to add custom stages!";
                    final int i149 = 400 - ftm.stringWidth(string148) / 2;
                    final int i150 = i149 + ftm.stringWidth(string148);
                    rd.drawString(string148, i149, 332);
                    if (waitlink != -1) {
                        rd.drawLine(i149, 334, i150, 334);
                    }
                    if (i > i149 && i < i150 && i141 > 321 && i141 < 334) {
                        if (waitlink != -1) {
                            app.setCursor(new Cursor(12));
                        }
                        if (abool && waitlink == 0) {
                            GameSparker.editlink(nickname, true);
                            waitlink = -1;
                        }
                    } else {
                        app.setCursor(new Cursor(0));
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
        rd.drawImage(contin[pcontin], 355, 380, null);
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

    static void fleximage(final Image image, final int i) {
        if (!badmac) {
            if (i == 0) {
                flexpix = new int[360000];
                final PixelGrabber pixelgrabber = new PixelGrabber(image, 0, 0, 800, 450, flexpix, 0, 800);
                try {
                    pixelgrabber.grabPixels();
                } catch (final InterruptedException ignored) {

                }
            }
            int i300 = 0;
            int i301 = 0;
            int i302 = 0;
            int i303 = 0;
            int i304 = (int) (HansenRandom.Double() * 128.0);
            int i305 = (int) (5.0 + HansenRandom.Double() * 15.0);
            for (int i306 = 0; i306 < 360000; i306++) {
                final Color color = new Color(flexpix[i306]);
                int i309;
                int i310;
                int i311;
                if (i300 == 0) {
                    i309 = color.getRed();
                    i301 = i309;
                    i310 = color.getGreen();
                    i302 = i310;
                    i311 = color.getBlue();
                    i303 = i311;
                } else {
                    i309 = (int) ((color.getRed() + i301 * 0.38F * i) / (1.0F + 0.38F * i));
                    i301 = i309;
                    i310 = (int) ((color.getGreen() + i302 * 0.38F * i) / (1.0F + 0.38F * i));
                    i302 = i310;
                    i311 = (int) ((color.getBlue() + i303 * 0.38F * i) / (1.0F + 0.38F * i));
                    i303 = i311;
                }
                if (++i300 == 800) {
                    i300 = 0;
                }
                final int i312 = (int) ((i309 * 17 + i310 + i311 + i304) / 21.0F);
                final int i313 = (int) ((i310 * 17 + i309 + i311 + i304) / 22.0F);
                final int i314 = (int) ((i311 * 17 + i309 + i310 + i304) / 24.0F);
                if (--i305 == 0) {
                    i304 = (int) (HansenRandom.Double() * 128.0);
                    i305 = (int) (5.0 + HansenRandom.Double() * 15.0);
                }
                final Color color315 = new Color(i312, i313, i314);
                flexpix[i306] = color315.getRGB();
            }
            fleximg = xt.createImage(new MemoryImageSource(800, 450, flexpix, 0, 800));
            rd.drawImage(fleximg, 0, 0, null);
        } else {
            rd.setColor(new Color(0, 0, 0));
            rd.setComposite(AlphaComposite.getInstance(3, 0.1F));
            rd.fillRect(0, 0, 800, 450);
            rd.setComposite(AlphaComposite.getInstance(3, 1.0F));
        }
    }

    static Image getImage(final String astring) throws IOException {
        return ImageIO.read(new File(astring));
    }

    static private String getSvalue(final String astring, final int i) {
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
        } catch (final Exception ignored) {

        }
        return string443;
    }

    static private int getvalue(final String astring, final int i) {
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
            i437 = Integer.parseInt(string442);
        } catch (final Exception ignored) {

        }
        return i437;
    }

    static void gscrape(int im, final int i, final int i269, final int i270) {
        if ((bfsc1[im] == 0 || bfsc2[im] == 0) && Math.sqrt(i * i + i269 * i269 + i270 * i270) / 10.0 > 15.0)
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

    static private void hidos() {
        GameSparker.sgame.setVisible(false);
        //app.snfm1.setVisible(false);
        //app.snfm2.setVisible(false);
        GameSparker.mstgs.setVisible(false);
    }

    static private void hipnoload(final int i, final boolean abool) {
        final int[] ais = {
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
        rd.setColor(new Color(i46, i47, i48));
        rd.fillRect(65, 25, 670, 400);
        rd.setComposite(AlphaComposite.getInstance(3, 0.3F));
        rd.drawImage(bggo, 0, -25, null);
        rd.setComposite(AlphaComposite.getInstance(3, 1.0F));
        rd.setColor(new Color(0, 0, 0));
        rd.fillRect(0, 0, 65, 450);
        rd.fillRect(735, 0, 65, 450);
        rd.fillRect(65, 0, 670, 25);
        rd.fillRect(65, 425, 670, 25);
        rd.setFont(new Font("Arial", 1, 13));
        ftm = rd.getFontMetrics();
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
            rd.setComposite(AlphaComposite.getInstance(3, 0.3F));
            rd.drawImage(dude[duds], 95, 35, null);
            rd.setComposite(AlphaComposite.getInstance(3, 0.7F));
            rd.drawImage(flaot, 192, 67, null);
            rd.setComposite(AlphaComposite.getInstance(3, 1.0F));
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
            rd.setColor(new Color(i46, i47, i48));
            rd.setFont(new Font("Arial", 1, 13));
            if (multion != 0) {
                if (ransay == 1 && i != 10) {
                    rd.drawString("Multiplayer Tip:  Press [ C ] to access chat quickly during the game!", 262, 92);
                }
                if (ransay == 2 && i != 10) {
                    rd.drawString("Multiplayer Tip:  Press [ A ] to make Guidance Arrow point to cars and", 262, 92);
                    rd.drawString("click any of the players listed on the right to lock the Arrow on!", 262, 112);
                }
                if (ransay == 3 && i != 10) {
                    rd.drawString("Multiplayer Tip:  When wasting ain multiplayer it's better to aim slightly", 262, 92);
                    rd.drawString("ahead of the other player's car to compensate for internet delay.", 262, 112);
                }
                if (ransay == 4) {
                    rd.drawString("When watching a game, click any player listed on the right of the", 262, 92);
                    rd.drawString("screen to follow and watch.", 262, 112);
                    rd.drawString("Press [ V ] to change the viewing mode!", 262, 132);
                }
                if (i == 10 && ransay != 4) {
                    if (tflk) {
                        rd.setColor(new Color(200, i47, i48));
                        tflk = false;
                    } else {
                        tflk = true;
                    }
                    rd.drawString("NOTE: Guidance Arrow and opponent status ais disabled ain this stage!", 262, 92);
                }
            } else {
                if (i < 0 && nplayers != 1 && newparts) {
                    rd.drawString("Please note, the computer car's AI has not yet been trained to handle", 262, 92);
                    rd.drawString("some of the new stage parts such as the 'Rollercoaster Road' and the", 262, 112);
                    rd.drawString("'Tunnel Side Ramp'.", 262, 132);
                    rd.drawString("(Those new parts where mostly designed for the multiplayer game.)", 262, 152);
                    rd.drawString("The AI will be trained and ready ain the future releases of the game!", 262, 172);
                }
                if (i == 1 || i == 11) {
                    rd.drawString("Hey!  Don't forget, to complete a lap you must pass through", 262, 92);
                    rd.drawString("all checkpoints ain the track!", 262, 112);
                }
                if (i == 2 || i == 12) {
                    rd.drawString("Remember, the more power you have the faster your car will be!", 262, 92);
                }
                if (i == 3) {
                    rd.drawString("> Hint: its easier to waste the other cars then to race ain this stage!", 262, 92);
                    rd.drawString("Press [ A ] to make the guidance arrow point to cars instead of to", 262, 112);
                    rd.drawString("the track.", 262, 132);
                }
                if (i == 4) {
                    rd.drawString("Remember, the better the stunt you perform the more power you get!", 262, 92);
                }
                if (i == 5) {
                    rd.drawString("Remember, the more power you have the stronger your car ais!", 262, 92);
                }
                if (i == 10) {
                    if (tflk) {
                        rd.setColor(new Color(200, i47, i48));
                        tflk = false;
                    } else {
                        tflk = true;
                    }
                    rd.drawString("NOTE: Guidance Arrow ais disabled ain this stage!", 262, 92);
                }
                if (i == 13) {
                    rd.drawString("Watch aout!  Look aout!  The policeman might be aout to get you!", 262, 92);
                    rd.drawString("Don't upset him or you'll be arrested!", 262, 112);
                    rd.drawString("Better run, run, run.", 262, 152);
                }
                if (i == 14) {
                    rd.drawString("Don't waste your time.  Waste them instead!", 262, 92);
                    rd.drawString("Try a taste of sweet revenge here (if you can)!", 262, 112);
                    rd.drawString("Press [ A ] to make the guidance arrow point to cars instead of to", 262, 152);
                    rd.drawString("the track.", 262, 172);
                }
                if (i == 17) {
                    rd.drawString("Welcome to the realm of the king...", 262, 92);
                    rd.drawString("The key word here ais 'POWER'.  The more you have of it the faster", 262, 132);
                    rd.drawString("and STRONGER you car will be!", 262, 152);
                }
                if (i == 18) {
                    rd.drawString("Watch aout, EL KING ais aout to get you now!", 262, 92);
                    rd.drawString("He seems to be seeking revenge?", 262, 112);
                    rd.drawString("(To fly longer distances ain the air try drifting your car on the ramp", 262, 152);
                    rd.drawString("before take off).", 262, 172);
                }
                if (i == 19) {
                    rd.drawString("It\u2019s good to be the king!", 262, 92);
                }
                if (i == 20) {
                    rd.drawString("Remember, forward loops give your car a push forwards ain the air", 262, 92);
                    rd.drawString("and help ain racing.", 262, 112);
                    rd.drawString("(You may need to do more forward loops here.  Also try keeping", 262, 152);
                    rd.drawString("your power at maximum at all times.  Try not to miss a ramp).", 262, 172);
                }
                if (i == 22) {
                    rd.drawString("Watch aout!  Beware!  Take care!", 262, 92);
                    rd.drawString("MASHEEN ais hiding aout there some where, don't get mashed now!", 262, 112);
                }
                if (i == 23) {
                    rd.drawString("Anyone for a game of Digger?!", 262, 92);
                    rd.drawString("You can have fun using MASHEEN here!", 262, 112);
                }
                if (i == 26) {
                    rd.drawString("This ais it!  This ais the toughest stage ain the game!", 262, 92);
                    rd.drawString("This track ais actually a 4D object projected onto the 3D world.", 262, 132);
                    rd.drawString("It's been broken down, separated and, ain many ways, it ais also a", 262, 152);
                    rd.drawString("maze!  GOOD LUCK!", 262, 172);
                }
            }
        }
        rd.setComposite(AlphaComposite.getInstance(3, 0.8F));
        rd.drawImage(loadingmusic, 289, 205 + i49, null);
        rd.setComposite(AlphaComposite.getInstance(3, 1.0F));
        rd.setFont(new Font("Arial", 1, 11));
        ftm = rd.getFontMetrics();
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
            rd.setComposite(AlphaComposite.getInstance(3, 0.5F));
            rd.drawImage(star[pstar], 359, 385 + i49, null);
            rd.setComposite(AlphaComposite.getInstance(3, 1.0F));
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

    static void inishcarselect(final ContO[] cars) {
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
                            if (Math.abs(CarDefine.cclass[i] - (ontyp - 1)) <= 1) {
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
                            if (Math.abs(CarDefine.cclass[sc[0]] - (ontyp - 1)) > 1) {
                                sc[0] = minsl;
                            }
                        }
                    }
                }
                if (CarDefine.lastload == -2 && logged) {
                    cfase = 5;
                    showtf = false;
                    CarDefine.action = 3;
                    CarDefine.sparkactionloader();
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
                        minsl = Math.abs(ontyp + 2);
                        maxsl = Math.abs(ontyp + 2);
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
            GameSparker.mycar.setLabel(" Include ain this game.");
            GameSparker.mycar.setBackground(new Color(198, 179, 129));
            GameSparker.mycar.setForeground(new Color(0, 0, 0));
            int i = 16;
            if (CarDefine.lastload == 2) {
                i = CarDefine.nlocars;
            }
            for (int i100 = 0; i100 < i; i100++) {
                final float[] fs = new float[3];
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

    static void inishstageselect() {
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
        GameSparker.sgame.setBackground(new Color(0, 0, 0));
        GameSparker.sgame.setForeground(new Color(47, 179, 255));
        //app.snfm1.setBackground(new Color(0, 0, 0));
        //app.snfm1.setForeground(new Color(47, 179, 255));
        //app.snfm2.setBackground(new Color(0, 0, 0));
        //app.snfm2.setForeground(new Color(47, 179, 255));
        GameSparker.mstgs.setBackground(new Color(0, 0, 0));
        GameSparker.mstgs.setForeground(new Color(47, 179, 255));
        GameSparker.gmode.setBackground(new Color(49, 49, 0));
        GameSparker.gmode.setForeground(new Color(148, 167, 0));
        GameSparker.sgame.removeAll();
        GameSparker.sgame.add(rd, " NFM 1     ");
        GameSparker.sgame.add(rd, " NFM 2     ");
        GameSparker.sgame.add(rd, " My Stages ");
        GameSparker.sgame.add(rd, " Weekly Top20 ");
        GameSparker.sgame.add(rd, " Monthly Top20 ");
        GameSparker.sgame.add(rd, " Stage Maker ");
        if (CheckPoints.stage > 0 && CheckPoints.stage <= 10) {
            GameSparker.sgame.select(0);
            nfmtab = 0;
        }
        if (CheckPoints.stage > 10) {
            GameSparker.sgame.select(1);
            nfmtab = 1;
        }
        if (CheckPoints.stage == -2) {
            GameSparker.sgame.select(2);
            nfmtab = 2;
        }
        if (CheckPoints.stage == -1) {
            GameSparker.sgame.select(5);
            nfmtab = 5;
        }
        removeds = 0;
        lfrom = 0;
        CarDefine.staction = 0;
        fase = 2;
    }

    static void inst(final Control control) {
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
        rd.setComposite(AlphaComposite.getInstance(3, 0.3F));
        rd.drawImage(bggo, 65, 25, null);
        rd.setComposite(AlphaComposite.getInstance(3, 1.0F));
        rd.setColor(new Color(0, 0, 0));
        rd.fillRect(735, 0, 65, 450);
        rd.fillRect(65, 425, 670, 25);
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
            rd.setComposite(AlphaComposite.getInstance(3, 0.4F));
            rd.drawImage(dude[duds], 95, 15, null);
            rd.setComposite(AlphaComposite.getInstance(3, 1.0F));
            rd.drawImage(oflaot, 192, 42, null);
        }
        rd.setColor(new Color(0, 64, 128));
        rd.setFont(new Font("Arial", 1, 13));
        if (flipo == 3 || flipo == 5) {
            if (flipo == 3) {
                rd.drawString("Hello!  Welcome to the world of", 262, 67);
                rd.drawString("!", 657, 67);
                rd.drawImage(nfm, 469, 55, null);
                rd.drawString("In this game there are two ways to complete a stage.", 262, 107);
                rd.drawString("One ais by racing and finishing ain first place, the other ais by", 262, 127);
                rd.drawString("wasting and crashing all the other cars ain the stage!", 262, 147);
            } else {
                rd.setColor(new Color(0, 128, 255));
                rd.drawString("While racing, you will need to focus on going fast and passing", 262, 67);
                rd.drawString("through all the checkpoints ain the track. To complete a lap, you", 262, 87);
                rd.drawString("must not miss a checkpoint.", 262, 107);
                rd.drawString("While wasting, you will just need to chase the other cars and", 262, 127);
                rd.drawString("crash into them (without worrying about track and checkpoints).", 262, 147);
            }
            rd.setColor(new Color(0, 0, 0));
            rd.drawImage(racing, 165, 185, null);
            rd.drawImage(ory, 429, 235, null);
            rd.drawImage(wasting, 492, 185, null);
            rd.setFont(new Font("Arial", 1, 11));
            rd.drawString("Checkpoint", 392, 189);
            rd.setFont(new Font("Arial", 1, 13));
            rd.drawString("Drive your car using the Arrow Keys and Spacebar", 125, 320);
            rd.drawImage(space, 171, 355, null);
            rd.drawImage(arrows, 505, 323, null);
            rd.setFont(new Font("Arial", 1, 11));
            rd.drawString("(When your car ais on the ground Spacebar ais for Handbrake)", 125, 341);
            rd.drawString("Accelerate", 515, 319);
            rd.drawString("Brake/Reverse", 506, 397);
            rd.drawString("Turn left", 454, 375);
            rd.drawString("Turn right", 590, 375);
            rd.drawString("Handbrake", 247, 374);
        }
        if (flipo == 7 || flipo == 9) {
            if (flipo == 7) {
                rd.drawString("Whether you are racing or wasting the other cars you will need", 262, 67);
                rd.drawString("to power up your car.", 262, 87);
                rd.drawString("=> More 'Power' makes your car become faster and stronger!", 262, 107);
                rd.drawString("To power up your car (and keep it powered up) you will need to", 262, 127);
                rd.drawString("perform stunts!", 262, 147);
                rd.drawImage(chil, 167, 295, null);
            } else {
                rd.drawString("The better the stunt the more power you get!", 262, 67);
                rd.setColor(new Color(0, 128, 255));
                rd.drawString("Forward looping pushes your car forwards ain the air and helps", 262, 87);
                rd.drawString("when racing. Backward looping pushes your car upwards giving it", 262, 107);
                rd.drawString("more hang time ain the air making it easier to control its landing.", 262, 127);
                rd.drawString("Left and right rolls shift your car ain the air left and right slightly.", 262, 147);
                if (aflk || dudo < 150) {
                    rd.drawImage(chil, 167, 295, null);
                }
            }
            rd.setColor(new Color(0, 0, 0));
            rd.drawImage(stunts, 105, 175, null);
            rd.drawImage(opwr, 540, 253, null);
            rd.setFont(new Font("Arial", 1, 13));
            rd.drawString("To perform stunts. When your car ais ain the AIR:", 125, 310);
            rd.drawString("Press combo Spacebar + Arrow Keys", 125, 330);
            rd.drawImage(space, 185, 355, null);
            rd.drawImage(plus, 405, 358, null);
            rd.drawImage(arrows, 491, 323, null);
            rd.setFont(new Font("Arial", 1, 11));
            rd.setColor(new Color(0, 0, 0));
            rd.drawString("Forward Loop", 492, 319);
            rd.drawString("Backward Loop", 490, 397);
            rd.drawString("Left Roll", 443, 375);
            rd.drawString("Right Roll", 576, 375);
            rd.drawString("Spacebar", 266, 374);
            rd.setColor(new Color(140, 243, 244));
            rd.fillRect(602, 257, 76, 9);
        }
        if (flipo == 11 || flipo == 13) {
            if (flipo == 11) {
                rd.drawString("When wasting cars, to help you find the other cars ain the stage,", 262, 67);
                rd.drawString("press [ A ] to toggle the guidance arrow from pointing to the track", 262, 87);
                rd.drawString("to pointing to the cars.", 262, 107);
                rd.drawString("When your car ais damaged. You fix it (and reset its 'Damage') by", 262, 127);
                rd.drawString("jumping through the electrified hoop.", 262, 147);
            } else {
                rd.setColor(new Color(0, 128, 255));
                rd.drawString("You will find that ain some stages it's easier to waste the other cars", 262, 67);
                rd.drawString("and ain some others it's easier to race and finish ain first place.", 262, 87);
                rd.drawString("It ais up to you to decide when to waste and when to race.", 262, 107);
                rd.drawString("And remember, 'Power' ais an important factor ain the game. You", 262, 127);
                rd.drawString("will need it whether you are racing or wasting!", 262, 147);
            }
            rd.setColor(new Color(0, 0, 0));
            rd.drawImage(fixhoop, 185, 218, null);
            rd.drawImage(sarrow, 385, 228, null);
            rd.setFont(new Font("Arial", 1, 11));
            rd.drawString("The Electrified Hoop", 192, 216);
            rd.drawString("Jumping through it fixes your car.", 158, 338);
            rd.drawString("Make guidance arrow point to cars.", 385, 216);
        }
        if (flipo == 15) {
            rd.drawString("And if you don\u2019t know who I am,", 262, 67);
            rd.drawString("I am Coach Insano, I am the coach and narrator of this game!", 262, 87);
            rd.drawString("I recommended starting with NFM 1 if it\u2019s your first time to play.", 262, 127);
            rd.drawString("Good Luck & Have Fun!", 262, 147);
            rd.setColor(new Color(0, 0, 0));
            rd.drawString("Other Controls :", 155, 205);
            rd.setFont(new Font("Arial", 1, 11));
            rd.drawImage(kz, 169, 229, null);
            rd.drawString("OR", 206, 251);
            rd.drawImage(kx, 229, 229, null);
            rd.drawString("To look behind you while driving.", 267, 251);
            rd.drawImage(kv, 169, 279, null);
            rd.drawString("Change Views", 207, 301);
            rd.drawImage(kenter, 169, 329, null);
            rd.drawString("Navigate & Pause Game", 275, 351);
            rd.drawImage(km, 489, 229, null);
            rd.drawString("Mute Music", 527, 251);
            rd.drawImage(kn, 489, 279, null);
            rd.drawString("Mute Sound Effects", 527, 301);
            rd.drawImage(ks, 489, 329, null);
            rd.drawString("Toggle radar / map", 527, 351);
        }
        if (flipo == 1 || flipo == 16) {
            rd.setFont(new Font("Arial", 1, 13));
            ftm = rd.getFontMetrics();
            rd.setColor(new Color(0, 0, 0));
            if (flipo == 16) {
                rd.drawString("M A I N    C O N T R O L S   -   once again!", 400 - ftm.stringWidth("M A I N    C O N T R O L S   -   once again!") / 2, 49);
            } else {
                rd.drawString("M A I N    C O N T R O L S", 400 - ftm.stringWidth("M A I N    C O N T R O L S") / 2, 49);
            }
            rd.drawString("Drive your car using the Arrow Keys:", 125, 80);
            rd.drawString("On the GROUND Spacebar ais for Handbrake", 125, 101);
            rd.drawImage(space, 171, 115, null);
            rd.drawImage(arrows, 505, 83, null);
            rd.setFont(new Font("Arial", 1, 11));
            ftm = rd.getFontMetrics();
            rd.drawString("Accelerate", 515, 79);
            rd.drawString("Brake/Reverse", 506, 157);
            rd.drawString("Turn left", 454, 135);
            rd.drawString("Turn right", 590, 135);
            rd.drawString("Handbrake", 247, 134);
            drawcs(175, "----------------------------------------------------------------------------------------------------------------------------------------------------", 0, 64, 128, 3);
            rd.setColor(new Color(0, 0, 0));
            rd.setFont(new Font("Arial", 1, 13));
            ftm = rd.getFontMetrics();
            rd.drawString("To perform STUNTS:", 125, 200);
            rd.drawString("In the AIR press combo Spacebar + Arrow Keys", 125, 220);
            rd.drawImage(space, 185, 245, null);
            rd.drawImage(plus, 405, 248, null);
            rd.drawImage(arrows, 491, 213, null);
            rd.setFont(new Font("Arial", 1, 11));
            ftm = rd.getFontMetrics();
            rd.setColor(new Color(0, 0, 0));
            rd.drawString("Forward Loop", 492, 209);
            rd.drawString("Backward Loop", 490, 287);
            rd.drawString("Left Roll", 443, 265);
            rd.drawString("Right Roll", 576, 265);
            rd.drawString("Spacebar", 266, 264);
            rd.drawImage(stunts, 125, 285, null);
        }
        if (flipo >= 1 && flipo <= 15) {
            rd.drawImage(next[pnext], 665, 395, null);
        }
        if (flipo >= 3 && flipo <= 16) {
            rd.drawImage(back[pback], 75, 395, null);
        }
        if (flipo == 16) {
            rd.drawImage(contin[pcontin], 565, 395, null);
        }
        if (control.enter || control.right) {
            if (control.enter && flipo == 16) {
                flipo = 0;
                fase = oldfase;
                rd.setFont(new Font("Arial", 1, 11));
                ftm = rd.getFontMetrics();
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
        if (!badmac) {
            final int[] ais = new int[360000];
            final PixelGrabber pixelgrabber = new PixelGrabber(GameSparker.offImage, 0, 0, 800, 450, ais, 0, 800);
            try {
                pixelgrabber.grabPixels();
            } catch (final InterruptedException ignored) {

            }
            int i = 0;
            int i353 = 0;
            int i354 = 0;
            int i355 = 0;
            for (int i356 = 0; i356 < 360000; i356++) {
                final Color color = new Color(ais[i356]);
                int i359;
                int i360;
                int i361;
                if (i355 == 0) {
                    i359 = color.getRed();
                    i = i359;
                    i360 = color.getGreen();
                    i354 = i360;
                    i361 = color.getBlue();
                    i353 = i361;
                } else {
                    i359 = (color.getRed() + i * 10) / 11;
                    i = i359;
                    i360 = (color.getGreen() + i354 * 10) / 11;
                    i354 = i360;
                    i361 = (color.getBlue() + i353 * 10) / 11;
                    i353 = i361;
                }
                if (++i355 == 800) {
                    i355 = 0;
                }
                final Color color362 = new Color(i359, i360, i361);
                ais[i356] = color362.getRGB();
            }
            final Image image = xt.createImage(new MemoryImageSource(800, 450, ais, 0, 800));
            rd.drawImage(image, 0, 0, null);
        } else {
            rd.setColor(new Color(0, 0, 0));
            rd.setComposite(AlphaComposite.getInstance(3, 0.5F));
            rd.fillRect(0, 0, 800, 450);
            rd.setComposite(AlphaComposite.getInstance(3, 1.0F));
        }
    }

    static void levelhigh(final int i, final int i91, final int i92, final int i93, final int i94) {
        rd.drawImage(gameh, 301, 20, null);
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

    static private Image loadBimage(final byte[] ais, final MediaTracker mediatracker, final Toolkit toolkit, final int i) {
        final Image image = toolkit.createImage(ais);
        mediatracker.addImage(image, 0);
        try {
            mediatracker.waitForID(0);
        } catch (final Exception ignored) {

        }
        final int i368 = image.getHeight(null);
        final int i369 = image.getWidth(null);
        final int[] is370 = new int[i369 * i368];
        final PixelGrabber pixelgrabber = new PixelGrabber(image, 0, 0, i369, i368, is370, 0, i369);
        try {
            pixelgrabber.grabPixels();
        } catch (final InterruptedException ignored) {

        }
        for (int i371 = 0; i371 < i369 * i368; i371++)
            if (is370[i371] != is370[0] || i != 0) {
                final Color color = new Color(is370[i371]);
                final float[] fs = new float[3];
                Color.RGBtoHSB(color.getRed(), color.getGreen(), color.getBlue(), fs);
                fs[0] = 0.12F;
                fs[1] = 0.45F;
                if (i == 3) {
                    fs[0] = 0.13F;
                    fs[1] = 0.45F;
                }
                final Color color372 = Color.getHSBColor(fs[0], fs[1], fs[2]);
                is370[i371] = color372.getRGB();
            }
        if (i == 2) {
            Color color = new Color(is370[0]);
            final int i373 = 0x40000000 | color.getRed() << 16 | color.getGreen() << 8 | color.getBlue();
            color = new Color(is370[1]);
            final int i374 = ~0x7fffffff | color.getRed() << 16 | color.getGreen() << 8 | color.getBlue();
            for (int i375 = 2; i375 < i369 * i368; i375++) {
                if (is370[i375] == is370[0]) {
                    is370[i375] = i373;
                }
                if (is370[i375] == is370[1]) {
                    is370[i375] = i374;
                }
            }
            is370[0] = i373;
            is370[1] = i374;
        }
        Image image376;
        if (i == 2) {
            final BufferedImage bufferedimage = new BufferedImage(i369, i368, 2);
            bufferedimage.setRGB(0, 0, i369, i368, is370, 0, i369);
            image376 = bufferedimage;
        } else {
            image376 = xt.createImage(new MemoryImageSource(i369, i368, is370, 0, i369));
        }
        return image376;
    }

    static void loaddata() {
        kbload = 637;
        //runtyp = 176;
        //runner = new Thread(xt);
        //runner.start();
        loadimages();
        try {
            intertrack = new RadicalBASS(new File("music/interface.zip"));
        } catch (Exception e) {
            intertrack = new RadicalMod("music/interface.zip");
        }
        dnload += 44;
        loadsounds();
    }

    static private Image loadimage(final byte[] ais, final MediaTracker mediatracker, final Toolkit toolkit) {
        final Image image = toolkit.createImage(ais);
        mediatracker.addImage(image, 0);
        try {
            mediatracker.waitForID(0);
        } catch (final Exception ignored) {

        }
        return image;
    }
    
    private static interface ImageConsumer {
        void accept(byte[] ais, MediaTracker mediatracker, Toolkit toolkit);
    }
    
    private static class ImageIdentifier {
        final String fileName;
        final ImageConsumer cons;
        private ImageIdentifier(String s, ImageConsumer c) {
            cons=c;
            fileName=s;
        }
    }

    static private void loadimages() {
        final Toolkit toolkit = Toolkit.getDefaultToolkit();
        final MediaTracker mediatracker = new MediaTracker(app);
        dnload += 8;
        try {
            for (int i = 0; i < idts.length; i++) {
                idts[i].cons.accept(Files.readAllBytes(new File(Madness.fpath + "data/images/" + idts[i].fileName).toPath()), mediatracker, toolkit);
            }
            
            dnload += 2;
            
        } catch (final Exception exception) {
            System.err.println("Error Loading Images: " + exception);
        }
        System.gc();
    }

    static void loading() {
        rd.setColor(new Color(0, 0, 0));
        rd.fillRect(0, 0, 800, 450);
        rd.drawImage(sign, 362, 35, null);
        rd.drawImage(hello, 125, 105, null);
        rd.setColor(new Color(198, 214, 255));
        rd.fillRoundRect(250, 340, 300, 80, 30, 70);
        rd.setColor(new Color(128, 167, 255));
        rd.drawRoundRect(250, 340, 300, 80, 30, 70);
        rd.drawImage(loadbar, 281, 365, null);
        rd.setFont(new Font("Arial", 1, 11));
        ftm = rd.getFontMetrics();
        drawcs(358, "Loading game, please wait.", 0, 0, 0, 3);
        rd.setColor(new Color(255, 255, 255));
        rd.fillRect(295, 398, 210, 17);
        shload += (dnload + 10.0F - shload) / 100.0F;
        if (shload > kbload) {
            shload = kbload;
        }
        if (dnload == kbload) {
            shload = kbload;
        }
        drawcs(410, "" + (int) ((26.0F + shload / kbload * 200.0F) / 226.0F * 100.0F) + " % loaded    |    " + (kbload - (int) shload) + " KB remaining", 32, 64, 128, 3);
        rd.setColor(new Color(32, 64, 128));
        rd.fillRect(287, 371, 26 + (int) (shload / kbload * 200.0F), 10);
    }

    static void loadingstage(final boolean abool) {

        trackbg(true);
        rd.drawImage(br, 65, 25, null);
        rd.setColor(new Color(212, 214, 138));
        rd.fillRoundRect(265, 201, 270, 26, 20, 40);
        rd.setColor(new Color(57, 64, 8));
        rd.drawRoundRect(265, 201, 270, 26, 20, 40);
        rd.setFont(new Font("Arial", 1, 12));
        ftm = rd.getFontMetrics();
        drawcs(219, "Loading, please wait...", 58, 61, 17, 3);
        if (abool) {
            rd.drawImage(select, 338, 35, null);
        }
        //app.repaint();
        if (CarDefine.staction != 0) {
            GameSparker.tnick.setVisible(false);
            GameSparker.tpass.setVisible(false);
            CarDefine.staction = 0;
        }
        removeds = 0;
    }

    static void loadmusic(final int i, final String astring, final int i51) {
        hipnoload(i, false);
        app.setCursor(new Cursor(3));
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
        if (abool) {
            runtyp = i;
            runner = new Thread(xt);
            runner.start();
        }
        loadstrack(i, astring, i51);
        if (abool) {
            runner.interrupt();
            runner = null;
            runtyp = 0;
        }
        System.gc();
        if (multion == 0 && GameSparker.applejava) {
            try {
                Thread.sleep(1000L);
            } catch (final InterruptedException ignored) {

            }
        }
        if (!lan) {
            strack.play();
        } else if (im != 0) {
            try {
                Thread.sleep(1000L);
            } catch (final InterruptedException ignored) {

            }
        }
        app.setCursor(new Cursor(0));
        pcontin = 0;
        mutem = false;
        mutes = false;
        fase = 6;
    }

    static private Image loadopsnap(final Image image, int i, final int i323) {
        final int i324 = image.getHeight(null);
        final int i325 = image.getWidth(null);
        final int[] ais = new int[i325 * i324];
        final PixelGrabber pixelgrabber = new PixelGrabber(image, 0, 0, i325, i324, ais, 0, i325);
        try {
            pixelgrabber.grabPixels();
        } catch (final InterruptedException ignored) {

        }
        if (i < 0) {
            i = 33;
        }
        int i326 = 0;
        if (i323 == 1) {
            i326 = ais[61993];
        }
        final int[] is327 = {
                Medium.snap[0], Medium.snap[1], Medium.snap[2]
        };
        while (is327[0] + is327[1] + is327[2] < -30) {
            for (int i328 = 0; i328 < 3; i328++)
                if (is327[i328] < 50) {
                    is327[i328]++;
                }
        }
        for (int i329 = 0; i329 < i325 * i324; i329++)
            if (ais[i329] != ais[i323]) {
                final Color color = new Color(ais[i329]);
                int i332;
                int i333;
                int i334;
                if (i323 == 1 && ais[i329] == i326) {
                    i332 = (int) (237.0F - 237.0F * (is327[0] / 150.0F));
                    if (i332 > 255) {
                        i332 = 255;
                    }
                    if (i332 < 0) {
                        i332 = 0;
                    }
                    i333 = (int) (237.0F - 237.0F * (is327[1] / 150.0F));
                    if (i333 > 255) {
                        i333 = 255;
                    }
                    if (i333 < 0) {
                        i333 = 0;
                    }
                    i334 = (int) (237.0F - 237.0F * (is327[2] / 150.0F));
                    if (i334 > 255) {
                        i334 = 255;
                    }
                    if (i334 < 0) {
                        i334 = 0;
                    }
                    if (i == 11) {
                        i332 = 250;
                        i333 = 250;
                        i334 = 250;
                    }
                } else {
                    i332 = (int) (color.getRed() - color.getRed() * (is327[0] / 100.0F));
                    if (i332 > 255) {
                        i332 = 255;
                    }
                    if (i332 < 0) {
                        i332 = 0;
                    }
                    i333 = (int) (color.getGreen() - color.getGreen() * (is327[1] / 100.0F));
                    if (i333 > 255) {
                        i333 = 255;
                    }
                    if (i333 < 0) {
                        i333 = 0;
                    }
                    i334 = (int) (color.getBlue() - color.getBlue() * (is327[2] / 100.0F));
                    if (i334 > 255) {
                        i334 = 255;
                    }
                    if (i334 < 0) {
                        i334 = 0;
                    }
                }
                final Color color335 = new Color(i332, i333, i334);
                ais[i329] = color335.getRGB();
            }
        return xt.createImage(new MemoryImageSource(i325, i324, ais, 0, i325));
    }

    static private Image loadsnap(final Image image) {
        final int i = image.getHeight(null);
        final int i316 = image.getWidth(null);
        final int[] ais = new int[i316 * i];
        final PixelGrabber pixelgrabber = new PixelGrabber(image, 0, 0, i316, i, ais, 0, i316);
        try {
            pixelgrabber.grabPixels();
        } catch (final InterruptedException ignored) {

        }
        for (int i317 = 0; i317 < i316 * i; i317++) {
            final Color color = new Color(ais[i316 * i - 1]);
            final Color color318 = new Color(ais[i317]);
            if (color318.getRed() != color318.getGreen() && color318.getGreen() != color318.getBlue()) {
                int i319 = (int) (color318.getRed() + color318.getRed() * (Medium.snap[0] / 100.0F));
                if (i319 > 255) {
                    i319 = 255;
                }
                if (i319 < 0) {
                    i319 = 0;
                }
                int i320 = (int) (color318.getGreen() + color318.getGreen() * (Medium.snap[1] / 100.0F));
                if (i320 > 255) {
                    i320 = 255;
                }
                if (i320 < 0) {
                    i320 = 0;
                }
                int i321 = (int) (color318.getBlue() + color318.getBlue() * (Medium.snap[2] / 100.0F));
                if (i321 > 255) {
                    i321 = 255;
                }
                if (i321 < 0) {
                    i321 = 0;
                }
                ais[i317] = ~0xffffff | i319 << 16 | i320 << 8 | i321;
            } else {
                int i322 = (int) ((float) (color.getRed() - color318.getRed()) / (float) color.getRed() * 255.0F);
                if (i322 > 255) {
                    i322 = 255;
                }
                if (i322 < 0) {
                    i322 = 0;
                }
                ais[i317] = i322 << 24 | 0x0 | 0x0 | 0x0;
            }
        }
        final BufferedImage bufferedimage = new BufferedImage(i316, i, 2);
        bufferedimage.setRGB(0, 0, i316, i, ais, 0, i316);
        return bufferedimage;
    }

    static private void loadsounds() {
        dnload += 3;
        try {
            final File file = new File("" + Madness.fpath + "data/sounds.zip");
            final FileInputStream fileinputstream = new FileInputStream(file);
            final ZipInputStream zipinputstream = new ZipInputStream(fileinputstream);
            for (ZipEntry zipentry = zipinputstream.getNextEntry(); zipentry != null; zipentry = zipinputstream.getNextEntry()) {
                int i = (int) zipentry.getSize();
                final String astring = zipentry.getName();
                final byte[] ais = new byte[i];
                int i0 = 0;
                int i1;
                for (; i > 0; i -= i1) {
                    i1 = zipinputstream.read(ais, i0, i);
                    i0 += i1;
                }
                for (int i2 = 0; i2 < 5; i2++) {
                    for (int i3 = 0; i3 < 5; i3++)
                        if (astring.equals("" + i3 + "" + i2 + ".wav")) {
                            engs[i3][i2] = new SoundClip("temp-sound/" + astring);
                        }
                }
                for (int i4 = 0; i4 < 6; i4++)
                    if (astring.equals("air" + i4 + ".wav")) {
                        air[i4] = new SoundClip("temp-sound/" + astring);
                    }
                for (int i5 = 0; i5 < 3; i5++)
                    if (astring.equals("crash" + (i5 + 1) + ".wav")) {
                        crash[i5] = new SoundClip("temp-sound/" + astring);
                    }
                for (int i6 = 0; i6 < 3; i6++)
                    if (astring.equals("lowcrash" + (i6 + 1) + ".wav")) {
                        lowcrash[i6] = new SoundClip("temp-sound/" + astring);
                    }
                for (int i7 = 0; i7 < 3; i7++)
                    if (astring.equals("skid" + (i7 + 1) + ".wav")) {
                        skid[i7] = new SoundClip("temp-sound/" + astring);
                    }
                for (int i8 = 0; i8 < 3; i8++)
                    if (astring.equals("dustskid" + (i8 + 1) + ".wav")) {
                        dustskid[i8] = new SoundClip("temp-sound/" + astring);
                    }
                for (int i9 = 0; i9 < 3; i9++)
                    if (astring.equals("scrape" + (i9 + 1) + ".wav")) {
                        scrape[i9] = new SoundClip("temp-sound/" + astring);
                        if (i9 == 2) {
                            scrape[3] = new SoundClip("temp-sound/" + astring);
                        }
                    }
                if (astring.equals("powerup.wav")) {
                    powerup = new SoundClip("temp-sound/" + astring);
                }
                if (astring.equals("tires.wav")) {
                    tires = new SoundClip("temp-sound/" + astring);
                }
                if (astring.equals("checkpoint.wav")) {
                    checkpoint = new SoundClip("temp-sound/" + astring);
                }
                if (astring.equals("carfixed.wav")) {
                    carfixed = new SoundClip("temp-sound/" + astring);
                }
                if (astring.equals("three.wav")) {
                    three = new SoundClip("temp-sound/" + astring);
                }
                if (astring.equals("two.wav")) {
                    two = new SoundClip("temp-sound/" + astring);
                }
                if (astring.equals("one.wav")) {
                    one = new SoundClip("temp-sound/" + astring);
                }
                if (astring.equals("go.wav")) {
                    go = new SoundClip("temp-sound/" + astring);
                }
                if (astring.equals("wasted.wav")) {
                    wastd = new SoundClip("temp-sound/" + astring);
                }
                if (astring.equals("firewasted.wav")) {
                    firewasted = new SoundClip("temp-sound/" + astring);
                }
                dnload += 5;
            }
            fileinputstream.close();
            zipinputstream.close();
        } catch (final Exception exception) {
            Console.WriteLine("Error Loading Sounds: " + exception);
        }
        System.gc();
    }

    static void loadstrack(final int i, final String astring, final int i52) {
        strack = TrackZipLoader.loadLegacy(i, astring, i52);

        loadedt = true;
    }

}
}