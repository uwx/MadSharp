package nfm.open;
/* xtGraphics - Decompiled by JODE
 * Visit http://jode.sourceforge.net/
 */
import nfm.open.music.*;

import static nfm.open.xtGraphics.Images.*;

import java.awt.AlphaComposite;
import java.awt.Color;
import java.awt.Cursor;
import java.awt.Font;
import java.awt.FontMetrics;
import java.awt.Graphics2D;
import java.awt.Image;
import java.awt.MediaTracker;
import java.awt.RenderingHints;
import java.awt.Toolkit;
import java.awt.image.BufferedImage;
import java.awt.image.MemoryImageSource;
import java.awt.image.PixelGrabber;
import java.io.BufferedReader;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.PrintWriter;
import java.net.Socket;
import java.net.URL;
import java.nio.file.Files;
import java.util.ArrayList;
import java.util.Collections;
import java.util.Objects;
import java.util.concurrent.ThreadLocalRandom;
import java.util.zip.ZipEntry;
import java.util.zip.ZipInputStream;

import javax.imageio.ImageIO;
import javax.swing.JPanel;

class xtGraphics extends JPanel implements Runnable {
    private xtGraphics() { super(); }
    
    static private int[] cntwis =   new int[8];
    static private boolean grrd[] = new boolean[8];
    static private boolean aird[] = new boolean[8];
    static private int[] stopcnt =  new int[8];
    static private int[] bfcrash =  new int[8];
    static private int[] bfsc1 =    new int[8];
    static private int[] bfsc2 =    new int[8];
    static private int[] bfscrape = new int[8];
    static private int[] bfskid =   new int[8];    
    static private int[] pwait =    { 7,7,7,7,7,7,7,7 };
    static private boolean[] pwastd = new boolean[8];
    
    static class Images {
        static Image arn;
        static Image arrows;
        static Image asd;
        static Image asu;
        static final Image[] back = new Image[2];
        static final Image[] bc = new Image[2];
        static final Image[] bcl = new Image[2];
        static final Image[] bcr = new Image[2];
        static Image bggo;
        static Image bgmain;
        static Image bob;
        static Image bol;
        static Image bolp;
        static Image bolps;
        static Image bols;
        static Image bor;
        static Image borp;
        static Image borps;
        static Image bors;
        static Image bot;
        static Image br;
        static Image brt;
        static Image byrd;
        static Image cancel;
        static Image carsbg;
        static Image carsbgc;
        static Image ccar;
        static Image cgame;
        static Image change;
        static Image chil;
        static final Image[] cntdn = new Image[4];
        static Image congrd;
        static final Image[] contin = new Image[2];
        static Image crd;
        static Image disco;
        static Image dmg;
        static final Image[] dude = new Image[3];
        static Image exit;
        static Image exitgame;
        static Image fixhoop;
        static Image flaot;
        static Image fleximg;
        static Image gamefinished;
        static Image gameh;
        static Image gameov;
        static Image games;
        static Image gmc;
        static Image hello;
        static Image kenter;
        static Image km;
        static Image kn;
        static Image ks;
        static Image kv;
        static Image kx;
        static Image kz;
        static Image lanm;
        static Image lap;
        static Image loadbar;
        static Image loadingmusic;
        static Image login;
        static Image logocars;
        static Image logomadbg;
        static Image logomadnes;
        static Image logout;
        static Image mdness;
        static Image mload;
        static final Image[] next = new Image[2];
        static Image nfm;
        static Image nfmcom;
        static Image nfmcoms;
        static Image ntrg;
        static final Image[] ocntdn = new Image[4];
        static Image odisco;
        static Image odmg;
        static Image oexitgame;
        static Image oflaot;
        static Image ogamefinished;
        static Image ogameh;
        static Image olap;
        static Image oloadingmusic;
        static Image onfmm;
        static Image opback;
        static Image opos;
        static Image opti;
        static Image opwr;
        static final Image[] orank = new Image[8];
        static Image ory;
        static Image osped;
        static final Image[] ostar = new Image[2];
        static Image owas;
        static Image owgame;
        static Image oyoulost;
        static Image oyourwasted;
        static Image oyouwastedem;
        static Image oyouwon;
        static Image paused;
        static Image pgate;
        static Image play;
        static Image pln;
        static Image pls;
        static Image plus;
        static Image pos;
        static Image pwr;
        static Image racing;
        static Image radicalplay;
        static final Image[] rank = new Image[8];
        static Image redy;
        static Image register;
        static Image roomp;
        static Image rpro;
        static Image sarrow;
        static Image sdets;
        static Image select;
        static Image selectcar;
        static Image sign;
        static Image space;
        static Image sped;
        static final Image[] star = new Image[3];
        static Image statb;
        static Image statbo;
        static Image stg;
        static Image sts;
        static Image stunts;
        static final Image[] trackbg = new Image[2];
        static Image upgrade;
        static Image was;
        static Image wasting;
        static Image wgame;
        static Image yac;
        static Image ycmc;
        static Image youlost;
        static Image yourwasted;
        static Image youwastedem;
        static Image youwon;

    }
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
     * The HSB values of every vehicle in a race, once for the first color and once for the second
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
     * If {@code true}, the arrow is pointing at cars
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
     * Player's clan in multiplayer games
     */
    static String clan = "";
    static boolean clanchat = false;
    /**
     * If non-zero, the player is in a clan/war game (racing or wasting)
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
     * The player's ping, in Dominion, Ghostrider and Avenger
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
    static int[] flexpix = null;
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
     * If non-zero, the player is test driving a car or stage
     */
    static int testdrive = 0;
    /**
     * Text flicker effect
     */
    static private boolean tflk = false;
    static private SoundClip three;
    static private SoundClip tires;
    static private int trkl = 0;
    static private int trklim = (int) (ThreadLocalRandom.current().nextDouble() * 40.0);
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
     * The X-coordinate of the start positions in a race
     */
    static final int[] xstart = {
            0, -350, 350, 0, -350, 350, 0, 0
    };
    /**
     * The Z-coordinate of the start positions in a race
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
                final String string = "" + exception;
                if (string.contains("access denied")) {
                    nofull = true;
                }
            }
        }
        badmac = false;
        return xt;
    }

    static private void arrow(final int i, final int i216, final boolean bool) {
        final int[] is = new int[7];
        final int[] is217 = new int[7];
        final int[] is218 = new int[7];
        final int i219 = 400;
        final int i220 = -90;
        final int i221 = 700;
        for (int i222 = 0; i222 < 7; i222++) {
            is217[i222] = i220;
        }
        is[0] = i219;
        is218[0] = i221 + 110;
        is[1] = i219 - 35;
        is218[1] = i221 + 50;
        is[2] = i219 - 15;
        is218[2] = i221 + 50;
        is[3] = i219 - 15;
        is218[3] = i221 - 50;
        is[4] = i219 + 15;
        is218[4] = i221 - 50;
        is[5] = i219 + 15;
        is218[5] = i221 + 50;
        is[6] = i219 + 35;
        is218[6] = i221 + 50;
        int i224;
        if (!bool) {
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
        if (!bool) {
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
        rot(is, is218, i219, i221, ana, 7);
        i224 = Math.abs(ana);
        rd.setRenderingHint(RenderingHints.KEY_ANTIALIASING, RenderingHints.VALUE_ANTIALIAS_ON);
        if (!bool) {
            if (i224 > 7 || i216 > 0 || i216 == -2 || cntan != 0) {
                for (int i231 = 0; i231 < 7; i231++) {
                    is[i231] = xs(is[i231], is218[i231]);
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
                rd.fillPolygon(is, is217, 7);
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
                rd.drawPolygon(is, is217, 7);
            }
        } else {
            int i236 = 0;
            if (multion != 0) {
                i236 = 8;
            }
            for (int i237 = 0; i237 < 7; i237++) {
                is[i237] = xs(is[i237], is218[i237]);
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
            rd.fillPolygon(is, is217, 7);
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
            rd.drawPolygon(is, is217, 7);
        }
        rd.setRenderingHint(RenderingHints.KEY_ANTIALIASING, RenderingHints.VALUE_ANTIALIAS_OFF);
    }

    static private Image bressed(final Image image) {
        final int i = image.getHeight(null);
        final int i340 = image.getWidth(null);
        final int[] is = new int[i340 * i];
        final PixelGrabber pixelgrabber = new PixelGrabber(image, 0, 0, i340, i, is, 0, i340);
        try {
            pixelgrabber.grabPixels();
        } catch (final InterruptedException ignored) {

        }
        final Color color = new Color(247, 255, 165);
        for (int i341 = 0; i341 < i340 * i; i341++)
            if (is[i341] != is[i340 * i - 1]) {
                is[i341] = color.getRGB();
            }
        return xt.createImage(new MemoryImageSource(i340, i, is, 0, i340));
    }

    static void cantgo(final Control control) {
        pnext = 0;
        trackbg(false);
        rd.drawImage(br, 65, 25, null);
        rd.drawImage(select, 338, 35, null);
        rd.setFont(new Font("Arial", 1, 13));
        ftm = rd.getFontMetrics();
        drawcs(130, "This stage will be unlocked when stage " + unlocked + " is complete!", 177, 177, 177, 3);
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

    static void carselect(final Control control, final ContO[] cars, final int i, final int i104, final boolean bool) {
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
        /*if (cfase == 11) {
        	rd.setFont(new Font("Arial", 1, 13));
        	ftm = rd.getFontMetrics();
        	String string = "Top 20 Cars";
        	int i105 = stat.loadlist;
        	String string106 = "Weekly";
        	while (i105 > 6) {
        		i105 -= 6;
        		if (string106.equals("Semi-Annual"))
        			string106 = "Annual";
        		if (string106.equals("Monthly"))
        			string106 = "Semi-Annual";
        		if (string106.equals("Weekly"))
        			string106 = "Monthly";
        	}
        	if (i105 == 1)
        		string = "" + ("") + (string106) + (" Top 20 Cars");
        	if (i105 == 2)
        		string = "" + ("") + (string106) + (" Top 20 Class A Cars");
        	if (i105 == 3)
        		string = "" + ("") + (string106) + (" Top 20 Class A & B Cars")
        				;
        	if (i105 == 4)
        		string = "" + ("") + (string106) + (" Top 20 Class B Cars");
        	if (i105 == 5)
        		string = "" + ("") + (string106) + (" Top 20 Class B & C Cars")
        				;
        	if (i105 == 6)
        		string = "" + ("") + (string106) + (" Top 20 Class C Cars");
        	drawcs(69, string, 120, 176, 255, 3);
        }*/
        /*if (cfase == 101) {
        	rd.setFont(new Font("Arial", 1, 13));
        	ftm = rd.getFontMetrics();
        	drawcs(69, "" + ("") + (stat.viewname) + ("'s account cars!"), 220,
        			112, 33, 3);
        }*/
        if (!remi) {
            rd.setRenderingHint(RenderingHints.KEY_ANTIALIASING, RenderingHints.VALUE_ANTIALIAS_OFF);
            cars[sc[0]].d(rd);
            rd.setRenderingHint(RenderingHints.KEY_ANTIALIASING, RenderingHints.VALUE_ANTIALIAS_ON);
        }
        /*if (cfase == 8) {
        	drawprom(150, 85);
        	rd.setFont(new Font("Arial", 1, 13));
        	ftm = rd.getFontMetrics();
        	drawcs(195, "Removing Car...", 0, 0, 0, 3);
        	if (stat.action != 10)
        		if (stat.action != -10) {
        			cfase = 5;
        			showtf = false;
        		} else
        			cfase = 9;
        }*/
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
                    String string = "";
                    if (cfase == 11) {
                        string = "N#" + (sc[0] - 35) + "  ";
                    }
                    if (aflk) {
                        drawcs(95 + i115, "" + string + CarDefine.names[sc[0]], 240, 240, 240, 3);
                        aflk = false;
                    } else {
                        drawcs(95, "" + string + CarDefine.names[sc[0]], 176, 176, 176, 3);
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
                    drawcs(375, "This car unlocks when stage " + i113 + " is completed...", 255, 96, 0, 3);
                }
            } else {
                if (flatrstart == 6) {
                    /*if (cfase == 10) {
                    	/*if (stat.action == 13) {
                    		minsl = nCars + 20;
                    		maxsl = stat.xnlocars - 1;
                    		i112 = nCars + 20;
                    		stat.action = 0;
                    		cfase = 11;
                    	}*/
                    /*if (stat.action == 12) {
                    	int i119 = stat.loadlist;
                    	String string = "Top 20 Cars";
                    	String string120 = "Weekly";
                    	while (i119 > 6) {
                    		i119 -= 6;
                    		if (string120.equals("Semi-Annual"))
                    			string120 = "Annual";
                    		if (string120.equals("Monthly"))
                    			string120 = "Semi-Annual";
                    		if (string120.equals("Weekly"))
                    			string120 = "Monthly";
                    	}
                    	if (i119 == 1)
                    		string = "" + ("") + (string120) + (" Top 20 Cars")
                    				;
                    	if (i119 == 2)
                    		string = "" + ("") + (string120)
                    				 + (" Top 20 Class A Cars");
                    	if (i119 == 3)
                    		string = "" + ("") + (string120)
                    				 + (" Top 20 Class A & B Cars");
                    	if (i119 == 4)
                    		string = "" + ("") + (string120)
                    				 + (" Top 20 Class B Cars");
                    	if (i119 == 5)
                    		string = "" + ("") + (string120)
                    				 + (" Top 20 Class B & C Cars");
                    	if (i119 == 6)
                    		string = "" + ("") + (string120)
                    				 + (" Top 20 Class C Cars");
                    	drawprom(145, 170);
                    	drawcs(195,
                    			"" + ("[  Loading ") + (string) + ("  ]"),
                    			0, 0, 0, 3);
                    	if (stat.nl > 0 && stat.nl <= 20)
                    		drawcs(235, "" + ("Loading :  ") + (stat.loadnames[stat.nl - 1])
                    				 + (""), 0, 0, 0, 3);
                    }*/
                    /*if (stat.action == 11) {
                    	drawprom(145, 170);
                    	drawcs(195, "Loading List, Please Wait...", 0, 0, 0, 3);
                    }*/
                    /*if (stat.action == -1) {
                    	drawprom(145, 170);
                    	drawcs(195, "Failed to Load List.", 0, 0, 0, 3);
                    	drawcs(225, "Unknown Error.  Please try again later.", 0, 0, 0, 3);
                    	if (drawcarb(true, null, "   OK   ", 371, 255, i, i104, bool)) {
                    		stat.action = 0;
                    		cfase = basefase;
                    	}
                    }*/
                    /*if (stat.action == 0 || stat.action == 14 || stat.action == 15 || stat.action == 16
                    		|| stat.action == 17) {
                    	drawprom(65, 250);
                    	if (drawcarb(true, null, " X ", 557, 70, i, i104, bool)) {
                    		stat.action = 0;
                    		cfase = basefase;
                    	}
                    	drawcs(305, "The lists get updated every 24 hours!", 0, 0, 0, 3);
                    	if (stat.action == 14 || stat.action == 15 || stat.action == 16 || stat.action == 17) {
                    		if (!bool && cntflock == 20)
                    			cntflock = 0;
                    		if (stat.action == 14)
                    			drawcs(91, "Weekly Top 20 Cars", 0, 0, 0, 3);
                    		if (stat.action == 15)
                    			drawcs(91, "Monthly Top 20 Cars", 0, 0, 0, 3);
                    		if (stat.action == 16)
                    			drawcs(91, "Semi-Annual Top 20 Cars", 0, 0, 0, 3);
                    		if (stat.action == 17)
                    			drawcs(91, "Annual Top 20 Cars", 0, 0, 0, 3);
                    		if (drawcarb(true, null, "   All Cars, All Classes   ", 318, 105, i, i104, bool)
                    				&& cntflock == 0) {
                    			stat.loadlist = 1 + (stat.action - 14) * 6;
                    			stat.action = 11;
                    			stat.sparkactionloader();
                    		}
                    		if (drawcarb(true, null, "Class A Cars", 337, 135, i, i104, bool) && cntflock == 0) {
                    			stat.loadlist = 2 + (stat.action - 14) * 6;
                    			stat.action = 11;
                    			stat.sparkactionloader();
                    		}
                    		if (drawcarb(true, null, "Class A & B Cars", 337, 165, i, i104, bool)
                    				&& cntflock == 0) {
                    			stat.loadlist = 3 + (stat.action - 14) * 6;
                    			stat.action = 11;
                    			stat.sparkactionloader();
                    		}
                    		if (drawcarb(true, null, "Class B Cars", 337, 195, i, i104, bool) && cntflock == 0) {
                    			stat.loadlist = 4 + (stat.action - 14) * 6;
                    			stat.action = 11;
                    			stat.sparkactionloader();
                    		}
                    		if (drawcarb(true, null, "Class B & C Cars", 337, 225, i, i104, bool)
                    				&& cntflock == 0) {
                    			stat.loadlist = 5 + (stat.action - 14) * 6;
                    			stat.action = 11;
                    			stat.sparkactionloader();
                    		}
                    		if (drawcarb(true, null, "Class C Cars", 337, 255, i, i104, bool) && cntflock == 0) {
                    			stat.loadlist = 6 + (stat.action - 14) * 6;
                    			stat.action = 11;
                    			stat.sparkactionloader();
                    		}
                    	}
                    	if (stat.action == 0) {
                    		drawcs(91, "Top 20 Most Added Public Custom Cars", 0, 0, 0, 3);
                    		if (drawcarb(true, null, "  Weekly Top 20  ", 338, 125, i, i104, bool))
                    			stat.action = 14;
                    		if (drawcarb(true, null, "  Monthly Top 20  ", 337, 165, i, i104, bool))
                    			stat.action = 15;
                    		if (drawcarb(true, null, "  Semi-Annual Top 20  ", 321, 205, i, i104, bool))
                    			stat.action = 16;
                    		if (drawcarb(true, null, "  Annual Top 20  ", 339, 245, i, i104, bool))
                    			stat.action = 17;
                    		if (cntflock != 20)
                    			cntflock = 20;
                    	}
                    }*/
                    //}
                    /*if (cfase == 100) {
                    	if (stat.action == -1) {
                    		drawprom(145, 170);
                    		drawcs(195, "Failed to Load List.", 0, 0, 0, 3);
                    		drawcs(225, "Unknown Error.  Please try again later.", 0, 0, 0, 3);
                    		if (drawcarb(true, null, "   OK   ", 371, 255, i, i104, bool))
                    			if (sc[0] >= 16 && stat.lastload == 2 && sc[0] < 36)
                    				cfase = 3;
                    			else
                    				cfase = 0;
                    	}
                    	if (stat.action == -2) {
                    		drawprom(145, 170);
                    		drawcs(195, "No account cars found.", 0, 0, 0, 3);
                    		drawcs(225,
                    				"" + ("") + (stat.viewname)
                    						 + (" does not have any published or added cars."),
                    				0, 0, 0, 3);
                    		if (drawcarb(true, null, "   OK   ", 371, 255, i, i104, bool))
                    			if (sc[0] >= 16 && stat.lastload == 2 && sc[0] < 36)
                    				cfase = 3;
                    			else
                    				cfase = 0;
                    	}
                    	if (stat.action == 100) {
                    		stat.action = 101;
                    		stat.sparkactionloader();
                    	}
                    	if (stat.action == 101) {
                    		drawprom(145, 170);
                    		drawcs(195, "" + ("Loading ") + (stat.viewname)
                    				 + ("'s account cars, please wait..."), 0, 0, 0, 3);
                    	}
                    	if (stat.action == 102) {
                    		drawprom(145, 170);
                    		drawcs(195, "" + ("Loading ") + (stat.viewname)
                    				 + ("'s account cars, please wait..."), 0, 0, 0, 3);
                    		if (stat.nl > 0 && stat.nl <= 20)
                    			drawcs(235, "" + ("Loading :  ") + (stat.loadnames[stat.nl - 1])
                    					 + (""), 0, 0, 0, 3);
                    	}
                    	if (stat.action == 103) {
                    		minsl = nCars + 20;
                    		maxsl = stat.xnlocars - 1;
                    		i112 = nCars + 20;
                    		stat.action = 0;
                    		cfase = 101;
                    	}
                    }*/
                    /*if (cfase == 0 && testdrive != 1 && testdrive != 2 && gmode == 0) {
                    	int i121 = 95;
                    	int i122 = 5;
                    	if (multion != 0) {
                    		i121 = 185;
                    		i122 = 0;
                    	}
                    	if (multion == 0 && drawcarb(false, cmc, "", 95, 70, i, i104, bool))
                    		if (stat.lastload != 1)
                    			cfase = 1;
                    		else {
                    			minsl = nCars;
                    			maxsl = stat.nlcars - 1;
                    			i112 = nCars;
                    			cfase = 3;
                    		}
                    	if (drawcarb(false, myc, "", i121, 105 + i122, i, i104, bool))
                    		if (stat.lastload != 2) {
                    			cfase = 5;
                    			showtf = false;
                    			if (!logged) {
                    				stat.action = 0;
                    				stat.reco = -2;
                    				tcnt = 5;
                    				cntflock = 0;
                    			} else {
                    				stat.action = 3;
                    				stat.sparkactionloader();
                    			}
                    		} else {
                    			minsl = nCars;
                    			maxsl = stat.nlocars - 1;
                    			if (onmsc >= minsl && onmsc <= maxsl)
                    				i112 = onmsc;
                    			else
                    				i112 = nCars;
                    			cfase = 3;
                    		}
                    	if ((multion == 0 || onjoin == -1) && drawcarb(false, top20s, "", i121,
                    			(i121 - 95) / 7 + 25 + i122, i, i104, bool)) {
                    		stat.action = 0;
                    		cfase = 10;
                    	}
                    	if (remi)
                    		remi = false;
                    }
                    if (cfase == -1)
                    	if (autolog) {
                    		autolog = false;
                    		cfase = 5;
                    		stat.action = 1;
                    		stat.sparkactionloader();
                    	} else if (stat.lastload != 2) {
                    		cfase = 5;
                    		showtf = false;
                    		if (!logged) {
                    			stat.action = 0;
                    			stat.reco = -2;
                    			tcnt = 5;
                    			cntflock = 0;
                    		} else {
                    			stat.action = 3;
                    			stat.sparkactionloader();
                    		}
                    	} else {
                    		minsl = nCars;
                    		maxsl = stat.nlocars - 1;
                    		if (onmsc >= minsl && onmsc <= maxsl)
                    			i112 = onmsc;
                    		else
                    			i112 = nCars;
                    		cfase = 3;
                    	}
                    if (cfase == 9) {
                    	drawprom(145, 95);
                    	drawcs(175, "Failed to remove car.  Unkown Error.  Try again laster.", 0, 0, 0, 3);
                    	if (drawcarb(true, null, "   OK   ", 371, 195, i, i104, bool)) {
                    		minsl = nCars;
                    		maxsl = stat.nlocars - 1;
                    		if (onmsc >= minsl && onmsc <= maxsl)
                    			i112 = onmsc;
                    		else
                    			i112 = nCars;
                    		cfase = 3;
                    	}
                    }
                    if (cfase == 7) {
                    	if (app.mycar.isShowing())
                    		app.mycar.setVisible(false);
                    	drawprom(145, 95);
                    	drawcs(175, "Remove this car from your account?", 0, 0, 0, 3);
                    	if (drawcarb(true, null, " Yes ", 354, 195, i, i104, bool)) {
                    		remi = true;
                    		minsl = 0;
                    		maxsl = nCars - 1;
                    		i112 = nCars - 1;
                    		cfase = 8;
                    		onmsc = sc[0];
                    		stat.ac = sc[0];
                    		stat.action = 10;
                    		stat.sparkactionloader();
                    	}
                    	if (drawcarb(true, null, " No ", 408, 195, i, i104, bool))
                    		cfase = 3;
                    }*/
                    /*if (cfase == 3 && i112 == -1) {
                    	int i123 = 95;
                    	int i124 = 5;
                    	if (multion != 0) {
                    		i123 = 185;
                    		i124 = 0;
                    	}
                    	if (drawcarb(false, gac, "", i123, 105 + i124, i, i104, bool)) {
                    		minsl = 0;
                    		maxsl = nCars - 1;
                    		if (onmsc >= minsl && onmsc <= maxsl)
                    			i112 = onmsc;
                    		else
                    			i112 = nCars - 1;
                    		cfase = 0;
                    	}
                    	if (multion == 0) {
                    		if (!app.openm) {
                    			if (!app.mycar.isShowing()) {
                    				app.mycar.setVisible(true);
                    				app.mycar.setState(stat.include[sc[0] - 16]);
                    			}
                    		} else
                    			app.mycar.setVisible(false);
                    		rd.setColor(new Color(198, 179, 129));
                    		rd.fillRoundRect(305, 302, 190, 24, 7, 20);
                    		rd.setColor(new Color(0, 0, 0));
                    		rd.drawRoundRect(305, 302, 190, 24, 7, 20);
                    		app.movefield(app.mycar, 334, 306, 150, 17);
                    		if (app.mycar.getState() != stat.include[sc[0] - 16]) {
                    			stat.include[sc[0] - 16] = app.mycar.getState();
                    			app.requestFocus();
                    		}
                    	}
                    	if ((multion == 0 || onjoin == -1) && drawcarb(false, top20s, "", i123,
                    			(i123 - 95) / 7 + 25 + i124, i, i104, bool)) {
                    		stat.action = 0;
                    		cfase = 10;
                    		if (app.mycar.isShowing())
                    			app.mycar.setVisible(false);
                    	}
                    	if (stat.lastload == 2) {
                    		if (drawcarb(true, null, "X", 567, 135, i, i104, bool))
                    			cfase = 7;
                    		rd.setFont(new Font("Arial", 1, 12));
                    		ftm = rd.getFontMetrics();
                    		rd.setColor(new Color(0, 0, 0));
                    		if (!stat.createdby[sc[0] - 16].equals(nickname))
                    			bool114 = clink(stat.createdby[sc[0] - 16], i, i104, bool);
                    		else
                    			rd.drawString("Created by You", 241, 160);
                    	}
                    	if (remi)
                    		remi = false;
                    	if (noclass) {
                    		drawprom(200, 95);
                    		rd.setFont(new Font("Arial", 1, 13));
                    		ftm = rd.getFontMetrics();
                    		String string = "Class C";
                    		if (ontyp == 2)
                    			string = "Class B or C";
                    		if (ontyp == 3)
                    			string = "Class B";
                    		if (ontyp == 4)
                    			string = "Class A or B";
                    		if (ontyp == 5)
                    			string = "Class A";
                    		drawcs(230, "" + ("You do not have a ") + (string)
                    				 + (" car in your account cars."), 0, 0, 0, 3);
                    		if (drawcarb(true, null, "   OK   ", 371, 250, i, i104, bool))
                    			noclass = false;
                    	}
                    }*/
                    /*if ((cfase == 11 || cfase == 101) && i112 == -1) {
                    	if (stat.action == -9) {
                    		drawprom(145, 95);
                    		drawcs(175, "Unknown error!  Failed to add car.  Try again later.", 0, 0, 0, 3);
                    		if (drawcarb(true, null, " OK ", 379, 195, i, i104, bool))
                    			stat.action = 0;
                    	}
                    	if (stat.action == -8) {
                    		drawprom(145, 95);
                    		drawcs(175, "Failed.  You already have 20 cars in your account!", 0, 0, 0, 3);
                    		if (drawcarb(true, null, " OK ", 379, 195, i, i104, bool))
                    			stat.action = 0;
                    	}
                    	if (stat.action == -7) {
                    		drawprom(145, 95);
                    		drawcs(175, "You already have this car!", 0, 0, 0, 3);
                    		if (drawcarb(true, null, " OK ", 379, 195, i, i104, bool))
                    			stat.action = 0;
                    	}
                    	if (stat.action == 7) {
                    		drawprom(145, 95);
                    		drawcs(175,
                    				"" + ("") + (stat.names[stat.ac])
                    						 + (" has been successfully added to your cars!"),
                    				0, 0, 0, 3);
                    		if (drawcarb(true, null, " OK ", 379, 195, i, i104, bool))
                    			stat.action = 0;
                    	}
                    	if (stat.action == 6) {
                    		drawprom(145, 95);
                    		drawcs(195, "" + ("Adding ") + (stat.names[stat.ac])
                    				 + (" to your cars..."), 0, 0, 0, 3);
                    	}
                    	int i125 = 95;
                    	int i126 = 5;
                    	if (multion != 0) {
                    		i125 = 185;
                    		i126 = 0;
                    	}
                    	if (onmsc >= 16 && (stat.lastload == 2 || stat.lastload == -2)) {
                    		if (drawcarb(false, myc, "", i125, 105 + i126, i, i104, bool)) {
                    			if (stat.lastload != 2) {
                    				cfase = 5;
                    				showtf = false;
                    				if (!logged) {
                    					stat.action = 0;
                    					stat.reco = -2;
                    					tcnt = 5;
                    					cntflock = 0;
                    				} else {
                    					stat.action = 3;
                    					stat.sparkactionloader();
                    				}
                    			} else {
                    				stat.action = 0;
                    				minsl = 16;
                    				maxsl = stat.nlocars - 1;
                    				if (onmsc >= minsl && onmsc <= maxsl)
                    					i112 = onmsc;
                    				else
                    					i112 = nCars;
                    				cfase = 3;
                    			}
                    			app.moused = false;
                    		}
                    	} else if (drawcarb(false, gac, "", i125, 105 + i126, i, i104, bool)) {
                    		stat.action = 0;
                    		minsl = 0;
                    		maxsl = nCars - 1;
                    		if (onmsc >= minsl && onmsc <= maxsl)
                    			i112 = onmsc;
                    		else
                    			i112 = nCars - 1;
                    		cfase = 0;
                    		app.moused = false;
                    	}
                    	if (drawcarb(false, top20s, "", i125, (i125 - 95) / 7 + 25 + i126, i, i104, bool)) {
                    		stat.action = 0;
                    		cfase = 10;
                    	}
                    	if (stat.action == 0) {
                    		rd.setFont(new Font("Arial", 1, 12));
                    		ftm = rd.getFontMetrics();
                    		rd.setColor(new Color(0, 0, 0));
                    		if (!stat.createdby[sc[0] - 16].equals(nickname))
                    			bool114 = clink(stat.createdby[sc[0] - 16], i, i104, bool);
                    		else
                    			rd.drawString("Created by You", 241, 160);
                    		if (cfase != 101) {
                    			rd.setFont(new Font("Arial", 1, 11));
                    			rd.drawString("" + ("Added by :  ") + (stat.adds[sc[0] - 36])
                    					 + (" Players"), 241, 180);
                    		}
                    	}
                    }*/
                    /*if (cfase == 5) {
                    	drawprom(145, 170);
                    	if (stat.action == 5) {
                    		minsl = 16;
                    		maxsl = stat.nlocars - 1;
                    		if (stat.inslot != -1) {
                    			onmsc = stat.inslot;
                    			stat.inslot = -1;
                    		}
                    		if (onmsc >= minsl && onmsc <= maxsl)
                    			i112 = onmsc;
                    		else
                    			i112 = nCars;
                    		cfase = 3;
                    	}
                    	if (stat.action == 4) {
                    		drawcs(195, "[  Loading Car  ]", 0, 0, 0, 3);
                    		drawcs(235, "" + ("Loading :  ") + (app.mcars.getSelectedItem())
                    				 + (""), 0, 0, 0, 3);
                    	}
                    	if (stat.action == -2) {
                    		drawcs(195, "Unknown Connection Error", 0, 0, 0, 3);
                    		drawcs(225, "Failed to connect to server, try again later!", 0, 0, 0, 3);
                    		if (drawcarb(true, null, "   OK   ", 371, 255, i, i104, bool))
                    			cfase = 0;
                    	}
                    	if (stat.action == -1) {
                    		drawcs(195, "No published cars found...", 0, 0, 0, 3);
                    		drawcs(225, "You have no added cars to your account yet!", 0, 0, 0, 3);
                    		if (drawcarb(true, null, "   OK   ", 371, 255, i, i104, bool))
                    			cfase = 0;
                    	}
                    	if (stat.action == 2 || stat.action == 3) {
                    		drawcs(195, "Loading your Account Cars list...", 0, 0, 0, 3);
                    		if (stat.action == 2) {
                    			nickname = app.tnick.getText();
                    			backlog = nickname;
                    			nickey = stat.tnickey;
                    			clan = stat.tclan;
                    			clankey = stat.tclankey;
                    			app.setloggedcookie();
                    			logged = true;
                    			gotlog = true;
                    			if (stat.reco == 0)
                    				acexp = 0;
                    			if (stat.reco > 10)
                    				acexp = stat.reco - 10;
                    			if (stat.reco == 3)
                    				acexp = -1;
                    			if (stat.reco == 111)
                    				if (!backlog.equalsIgnoreCase(nickname))
                    					acexp = -3;
                    				else
                    					acexp = 0;
                    			if (basefase == 0)
                    				stat.action = 3;
                    			if (basefase == 11) {
                    				stat.action = 6;
                    				cfase = 11;
                    			}
                    			if (basefase == 101) {
                    				stat.action = 6;
                    				cfase = 101;
                    			}
                    		}
                    	}
                    	if (stat.action == 1)
                    		drawcs(195, "Logging in to your account...", 0, 0, 0, 3);
                    	if (stat.action == 0) {
                    		if (stat.reco == -5)
                    			drawcs(171, "Login to Add this Car to your Account", 0, 0, 0, 3);
                    		if (stat.reco == -2)
                    			drawcs(171, "Login to Retrieve your Account Cars", 0, 0, 0, 3);
                    		if (stat.reco == -1)
                    			drawcs(171, "Unable to connect to server, try again later!", 0, 8, 0, 3);
                    		if (stat.reco == 1)
                    			drawcs(171, "Sorry.  The Nickname you have entered is incorrect.", 0, 0, 0, 3);
                    		if (stat.reco == 2)
                    			drawcs(171, "Sorry.  The Password you have entered is incorrect.", 0, 0, 0, 3);
                    		if (stat.reco == -167 || stat.reco == -177) {
                    			if (stat.reco == -167) {
                    				nickname = app.tnick.getText();
                    				backlog = nickname;
                    				stat.reco = -177;
                    			}
                    			drawcs(171, "You are currently using a trial account.", 0, 0, 0, 3);
                    		}
                    		if (stat.reco == -3 && (tcnt % 3 != 0 || tcnt > 20))
                    			drawcs(171, "Please enter your Nickname!", 0, 0, 0, 3);
                    		if (stat.reco == -4 && (tcnt % 3 != 0 || tcnt > 20))
                    			drawcs(171, "Please enter your Password!", 0, 0, 0, 3);
                    		if (!showtf) {
                    			app.tnick.setVisible(true);
                    			app.tnick.setBackground(new Color(206, 237, 255));
                    			if (stat.reco != 1) {
                    				if (stat.reco != 2)
                    					app.tnick.setText(nickname);
                    				app.tnick.setForeground(new Color(0, 0, 0));
                    			} else
                    				app.tnick.setForeground(new Color(255, 0, 0));
                    			app.tnick.requestFocus();
                    			app.tpass.setVisible(true);
                    			app.tpass.setBackground(new Color(206, 237, 255));
                    			if (stat.reco != 2) {
                    				if (!autolog)
                    					app.tpass.setText("");
                    				app.tpass.setForeground(new Color(0, 0, 0));
                    			} else
                    				app.tpass.setForeground(new Color(255, 0, 0));
                    			if (!app.tnick.getText().equals("") && stat.reco != 1)
                    				app.tpass.requestFocus();
                    			showtf = true;
                    		}
                    		rd.drawString("Nickname:", 376 - ftm.stringWidth("Nickname:") - 14, 201);
                    		rd.drawString("Password:", 376 - ftm.stringWidth("Password:") - 14, 231);
                    		app.movefieldd(app.tnick, 376, 185, 129, 23, true);
                    		app.movefieldd(app.tpass, 376, 215, 129, 23, true);
                    		if (tcnt < 30) {
                    			tcnt++;
                    			if (tcnt == 30) {
                    				if (stat.reco == 2)
                    					app.tpass.setText("");
                    				app.tnick.setForeground(new Color(0, 0, 0));
                    				app.tpass.setForeground(new Color(0, 0, 0));
                    			}
                    		}
                    		if (stat.reco != -177) {
                    			if (drawcarb(true, null, "       Login       ", 347, 247, i, i104, bool)
                    					&& tcnt > 5) {
                    				tcnt = 0;
                    				if (!app.tnick.getText().equals("") && !app.tpass.getText().equals("")) {
                    					autolog = false;
                    					app.tnick.setVisible(false);
                    					app.tpass.setVisible(false);
                    					app.requestFocus();
                    					stat.action = 1;
                    					stat.sparkactionloader();
                    				} else {
                    					if (app.tpass.getText().equals(""))
                    						stat.reco = -4;
                    					if (app.tnick.getText().equals(""))
                    						stat.reco = -3;
                    				}
                    			}
                    		} else if (drawcarb(true, null, "  Upgrade to have your own cars!  ", 284, 247, i, i104,
                    				bool) && cntflock == 0) {
                    			app.editlink(this.nickname, true);
                    			cntflock = 100;
                    		}
                    		if (drawcarb(true, null, "  Cancel  ", 409, 282, i, i104, bool)) {
                    			app.tnick.setVisible(false);
                    			app.tpass.setVisible(false);
                    			app.requestFocus();
                    			cfase = basefase;
                    		}
                    		if (drawcarb(true, null, "  Register!  ", 316, 282, i, i104, bool)) {
                    			if (cntflock == 0) {
                    				app.reglink();
                    				cntflock = 100;
                    			}
                    		} else if (cntflock != 0)
                    			cntflock--;
                    	}
                    }*/

                    //
                    // WE HAD TO REMOVE THIS
                    // SORRY LADS
                    //

                    /*if (cfase == 4) {
                    	drawprom(145, 150);
                    	rd.setColor(new Color(0, 0, 0));
                    	rd.drawString("Failed to find any ready car in your \u2018mycars\u2019 folder!", 215, 175);
                    	rd.drawString("Please \u2018Test Drive\u2019 your cars in the Car Maker to make", 215, 215);
                    	rd.drawString("sure they are ready.", 215, 235);
                    	if (drawcarb(true, null, "   OK   ", 371, 255, i, i104, bool))
                    		cfase = 0;
                    }
                    if (cfase == 2) {
                    	drawprom(165, 70);
                    	drawcs(205, "Loading Car Maker Cars...", 0, 0, 0, 3);
                    	//app.repaint();
                    	stat.loadcarmaker();
                    	if (stat.nlcars > nCars) {
                    		minsl = nCars;
                    		maxsl = stat.nlcars - 1;
                    		i112 = nCars;
                    		cfase = 3;
                    	} else
                    		cfase = 4;
                    }
                    if (cfase == 1) {
                    	drawprom(145, 170);
                    	rd.setColor(new Color(0, 0, 0));
                    	rd.drawString("The game will now load all the cars that can be loaded", 215, 170);
                    	rd.drawString("from your \u2018mycars\u2019 folder.", 215, 190);
                    	rd.drawString("If a car is not loaded, then it is not ready (not finished).", 215, 210);
                    	rd.drawString("Perform a \u2018Test Drive\u2019 on any car to see if it is ready or not.", 215,
                    			230);
                    	rd.drawString("The maximum number of cars that can be loaded is  40 !", 215, 260);
                    	if (drawcarb(true, null, "   OK   ", 371, 275, i, i104, bool))
                    		cfase = 2;
                    }*/
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
                        String string = "Class C";
                        if (CarDefine.cclass[sc[0]] == 1) {
                            string = "Class B & C";
                        }
                        if (CarDefine.cclass[sc[0]] == 2) {
                            string = "Class B";
                        }
                        if (CarDefine.cclass[sc[0]] == 3) {
                            string = "Class A & B";
                        }
                        if (CarDefine.cclass[sc[0]] == 4) {
                            string = "Class A";
                        }
                        if (kbload < 7) {
                            rd.setColor(new Color(0, 0, 0));
                            kbload++;
                        } else {
                            rd.setColor(new Color(176, 41, 0));
                            kbload = 0;
                        }
                        if (cfase != 10 || CarDefine.action != 0 && CarDefine.action < 14) {
                            rd.drawString(string, 549 - ftm.stringWidth(string) / 2, 95);
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
                        if (bool) {
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
                    	if (cfase == 11 && drawcarb(true, null, "Add to My Cars", 345, 385, i, i104, bool)
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
                    			if (drawcarb(true, null, "Add to My Cars", 345, 385, i, i104, bool) && stat.action == 0) {
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

    static public boolean clink(final String string, final int i, final int i134, final boolean bool) {
        boolean bool135 = false;
        rd.drawString("Created by :  " + string + "", 241, 160);
        final int i136 = ftm.stringWidth(string);
        final int i137 = 241 + ftm.stringWidth("Created by :  " + string + "") - i136;
        rd.drawLine(i137, 162, i137 + i136 - 2, 162);
        if (i > i137 - 2 && i < i137 + i136 && i134 > 147 && i134 < 164) {
            if (bool) {
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
            drawcs(260, "Thanks to Kaffeinated, Ten Graves & everyone else for their awesome work in NFM2!", 66, 98, 0, 3);
            drawcs(275, "Thanks to Emmanuel Dupuy for JD-GUI, Pavel Kouznetsov for JAD and Jochen Hoenicke for JODE.", 66, 98, 0, 3);
            drawcs(290, "Thanks to Allan for being a glorious bastard and please add credits.", 66, 98, 0, 3);
            drawcs(305, "Thanks to the Eclipse Foundation for this laggy piece of shit-uh, I mean great IDE!", 66, 98, 0, 3);
            rd.setFont(new Font("Arial", 1, 13));
            ftm = rd.getFontMetrics();
            drawcs(345, "~~~~~~ License ~~~~~~", 0, 0, 0, 3);
            rd.setFont(new Font("Arial", 1, 11));
            ftm = rd.getFontMetrics();
            drawcs(365, "All code is licensed under the BSD license, unless noted otherwise.", 66, 98, 0, 3);
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
        final int[] is = new int[i378 * i];
        final PixelGrabber pixelgrabber = new PixelGrabber(image, 0, 0, i378, i, is, 0, i378);
        try {
            pixelgrabber.grabPixels();
        } catch (final InterruptedException ignored) {

        }
        for (int i379 = 0; i379 < i378 * i; i379++) {
            final Color color = new Color(is[i379]);
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
            is[i379] = color383.getRGB();
        }
        return xt.createImage(new MemoryImageSource(i378, i, is, 0, i378));
    }

    static boolean drawcarb(final boolean bool, final Image image, final String string, final int i, int i429, final int i430, final int i431, final boolean bool432) {
        boolean bool433 = false;
        rd.setFont(new Font("Arial", 1, 13));
        ftm = rd.getFontMetrics();
        int i435;
        if (bool) {
            i435 = ftm.stringWidth(string);
            if (string.startsWith("Class")) {
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
        if (!bool && i435 == 73) {
            i429--;
        }
        if (bool) {
            if (string.equals("X") && i436 == 1) {
                rd.setColor(new Color(255, 0, 0));
            } else {
                rd.setColor(new Color(0, 0, 0));
            }
            if (string.startsWith("Class")) {
                rd.drawString(string, 400 - ftm.stringWidth(string) / 2, i429 + 19);
            } else {
                rd.drawString(string, i + 7, i429 + 19);
            }
        } else {
            rd.drawImage(image, i + 7, i429 + 7, null);
        }
        return bool433;
    }

    static void drawcs(final int i, final String string, int i212, int i213, int i214, final int i215) {
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
            rd.drawString(string, 400 - ftm.stringWidth(string) / 2 + 1, i + 1);
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
            rd.drawString(string, 400 - ftm.stringWidth(string) / 2 + 1, i + 1);
        }
        rd.setColor(new Color(i212, i213, i214));
        rd.drawString(string, 400 - ftm.stringWidth(string) / 2, i);
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
        final int[] is = new int[4];
        final int[] is207 = new int[4];
        if (i206 > i) {
            i206 = i;
        }
        final int i208 = (int) (98.0F * ((float) i206 / (float) i));
        is[0] = 662;
        is207[0] = 11;
        is[1] = 662;
        is207[1] = 20;
        is[2] = 662 + i208;
        is207[2] = 20;
        is[3] = 662 + i208;
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
        rd.fillPolygon(is, is207, 4);
        is[0] = 662;
        is207[0] = 31;
        is[1] = 662;
        is207[1] = 40;
        is[2] = (int) (662.0F + f);
        is207[2] = 40;
        is[3] = (int) (662.0F + f);
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
        rd.fillPolygon(is, is207, 4);
    }

    static void drawWarning() {
        rd.setColor(new Color(0, 0, 0));
        rd.fillRect(0, 0, 800, 450);
        rd.setFont(new Font("Arial", 1, 22));
        ftm = rd.getFontMetrics();
        drawcs(100, "Warning!", 255, 0, 0, 3);
        rd.setFont(new Font("Arial", 1, 18));
        ftm = rd.getFontMetrics();
        drawcs(150, "Bad language and flooding is strictly prohibited in this game!", 255, 255, 255, 3);
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

    static void finish(final ContO[] contos, final Control control, final int i, final int i141, final boolean bool) {
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
        String string = ":";
        if (CheckPoints.stage > 0) {
            final int i143 = CheckPoints.stage;
            //if (i143 > 10)
            //	i143 -= 10;
            string = " " + i143 + "!";
        }
        if (multion < 3) {
            if (winner) {
                rd.drawImage(congrd, 265, 87, null);
                drawcs(137, "You Won!  At Stage" + string, 255, 161, 85, 3);
                drawcs(154, CheckPoints.name, 255, 115, 0, 3);
                i142 = 154;
            } else {
                rd.drawImage(gameov, 315, 117, null);
                if (multion != 0 && (forstart == 700 || discon == 240)) {
                    drawcs(167, "Sorry, You where Disconnected from Game!", 255, 161, 85, 3);
                    drawcs(184, "Please check your connection!", 255, 115, 0, 3);
                } else {
                    drawcs(167, "You Lost!  At Stage" + string, 255, 161, 85, 3);
                    drawcs(184, CheckPoints.name, 255, 115, 0, 3);
                    i142 = 184;
                }
            }
            rd.setColor(new Color(193, 106, 0));
        } else {
            rd.drawImage(gameov, 315, 117, null);
            drawcs(167, "Finished Watching Game!  At Stage" + string + "", 255, 161, 85, 3);
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
                    drawcs(200 + pin, "Stage " + (CheckPoints.stage + 1) + " is now unlocked!", 196, 176, 0, 3);
                } else {
                    drawcs(200 + pin, "Stage " + (CheckPoints.stage + 1) + " is now unlocked!", 255, 247, 165, 3);
                }
                if (i144 != 0) {
                    if (aflk) {
                        drawcs(200, "And:", 196, 176, 0, 3);
                    } else {
                        drawcs(200, "And:", 255, 247, 165, 3);
                    }
                    rd.setColor(new Color(236, 226, 202));
                    if (ThreadLocalRandom.current().nextDouble() > 0.5) {
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
                    if (ThreadLocalRandom.current().nextDouble() < 0.5) {
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
                rd.drawImage(radicalplay, radpx + (int) (8.0 * ThreadLocalRandom.current().nextDouble() - 4.0), 255, null);
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
                if (dnload == 0 && drawcarb(true, null, " Add to My Stages ", 334, 317, i, i141, bool))
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
                        if (bool && waitlink == 0) {
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
                    CheckPoints.stage = (int) (ThreadLocalRandom.current().nextDouble() * nTracks) + 1;
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
            int i304 = (int) (ThreadLocalRandom.current().nextDouble() * 128.0);
            int i305 = (int) (5.0 + ThreadLocalRandom.current().nextDouble() * 15.0);
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
                    i304 = (int) (ThreadLocalRandom.current().nextDouble() * 128.0);
                    i305 = (int) (5.0 + ThreadLocalRandom.current().nextDouble() * 15.0);
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

    static Image getImage(final String string) throws IOException {
        return ImageIO.read(new File(string));
    }

    static private String getSvalue(final String string, final int i) {
        String string443 = "";
        try {
            int i444 = 0;
            int i445 = 0;
            int i446 = 0;
            String string447;
            String string448 = "";
            for (; i444 < string.length() && i446 != 2; i444++) {
                string447 = "" + string.charAt(i444);
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

    static private int getvalue(final String string, final int i) {
        int i437 = -1;
        try {
            int i438 = 0;
            int i439 = 0;
            int i440 = 0;
            String string441;
            String string442 = "";
            for (; i438 < string.length() && i440 != 2; i438++) {
                string441 = "" + string.charAt(i438);
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

    static private void hipnoload(final int i, final boolean bool) {
        final int[] is = {
                Medium.snap[0], Medium.snap[1], Medium.snap[2]
        };
        while (is[0] + is[1] + is[2] < -30) {
            for (int i45 = 0; i45 < 3; i45++)
                if (is[i45] < 50) {
                    is[i45]++;
                }
        }
        int i46 = (int) (230.0F - 230.0F * (is[0] / 100.0F));
        if (i46 > 255) {
            i46 = 255;
        }
        if (i46 < 0) {
            i46 = 0;
        }
        int i47 = (int) (230.0F - 230.0F * (is[1] / 100.0F));
        if (i47 > 255) {
            i47 = 255;
        }
        if (i47 < 0) {
            i47 = 0;
        }
        int i48 = (int) (230.0F - 230.0F * (is[2] / 100.0F));
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
                    if (ThreadLocalRandom.current().nextDouble() > ThreadLocalRandom.current().nextDouble()) {
                        duds = (int) (ThreadLocalRandom.current().nextDouble() * 3.0);
                    } else {
                        duds = (int) (ThreadLocalRandom.current().nextDouble() * 2.0);
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
            i46 = (int) (80.0F - 80.0F * (is[0] / 100.0F));
            if (i46 > 255) {
                i46 = 255;
            }
            if (i46 < 0) {
                i46 = 0;
            }
            i47 = (int) (80.0F - 80.0F * (is[1] / 100.0F));
            if (i47 > 255) {
                i47 = 255;
            }
            if (i47 < 0) {
                i47 = 0;
            }
            i48 = (int) (80.0F - 80.0F * (is[2] / 100.0F));
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
                    rd.drawString("Multiplayer Tip:  When wasting in multiplayer it's better to aim slightly", 262, 92);
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
                    rd.drawString("NOTE: Guidance Arrow and opponent status is disabled in this stage!", 262, 92);
                }
            } else {
                if (i < 0 && nplayers != 1 && newparts) {
                    rd.drawString("Please note, the computer car's AI has not yet been trained to handle", 262, 92);
                    rd.drawString("some of the new stage parts such as the 'Rollercoaster Road' and the", 262, 112);
                    rd.drawString("'Tunnel Side Ramp'.", 262, 132);
                    rd.drawString("(Those new parts where mostly designed for the multiplayer game.)", 262, 152);
                    rd.drawString("The AI will be trained and ready in the future releases of the game!", 262, 172);
                }
                if (i == 1 || i == 11) {
                    rd.drawString("Hey!  Don't forget, to complete a lap you must pass through", 262, 92);
                    rd.drawString("all checkpoints in the track!", 262, 112);
                }
                if (i == 2 || i == 12) {
                    rd.drawString("Remember, the more power you have the faster your car will be!", 262, 92);
                }
                if (i == 3) {
                    rd.drawString("> Hint: its easier to waste the other cars then to race in this stage!", 262, 92);
                    rd.drawString("Press [ A ] to make the guidance arrow point to cars instead of to", 262, 112);
                    rd.drawString("the track.", 262, 132);
                }
                if (i == 4) {
                    rd.drawString("Remember, the better the stunt you perform the more power you get!", 262, 92);
                }
                if (i == 5) {
                    rd.drawString("Remember, the more power you have the stronger your car is!", 262, 92);
                }
                if (i == 10) {
                    if (tflk) {
                        rd.setColor(new Color(200, i47, i48));
                        tflk = false;
                    } else {
                        tflk = true;
                    }
                    rd.drawString("NOTE: Guidance Arrow is disabled in this stage!", 262, 92);
                }
                if (i == 13) {
                    rd.drawString("Watch out!  Look out!  The policeman might be out to get you!", 262, 92);
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
                    rd.drawString("The key word here is 'POWER'.  The more you have of it the faster", 262, 132);
                    rd.drawString("and STRONGER you car will be!", 262, 152);
                }
                if (i == 18) {
                    rd.drawString("Watch out, EL KING is out to get you now!", 262, 92);
                    rd.drawString("He seems to be seeking revenge?", 262, 112);
                    rd.drawString("(To fly longer distances in the air try drifting your car on the ramp", 262, 152);
                    rd.drawString("before take off).", 262, 172);
                }
                if (i == 19) {
                    rd.drawString("It\u2019s good to be the king!", 262, 92);
                }
                if (i == 20) {
                    rd.drawString("Remember, forward loops give your car a push forwards in the air", 262, 92);
                    rd.drawString("and help in racing.", 262, 112);
                    rd.drawString("(You may need to do more forward loops here.  Also try keeping", 262, 152);
                    rd.drawString("your power at maximum at all times.  Try not to miss a ramp).", 262, 172);
                }
                if (i == 22) {
                    rd.drawString("Watch out!  Beware!  Take care!", 262, 92);
                    rd.drawString("MASHEEN is hiding out there some where, don't get mashed now!", 262, 112);
                }
                if (i == 23) {
                    rd.drawString("Anyone for a game of Digger?!", 262, 92);
                    rd.drawString("You can have fun using MASHEEN here!", 262, 112);
                }
                if (i == 26) {
                    rd.drawString("This is it!  This is the toughest stage in the game!", 262, 92);
                    rd.drawString("This track is actually a 4D object projected onto the 3D world.", 262, 132);
                    rd.drawString("It's been broken down, separated and, in many ways, it is also a", 262, 152);
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
        if (!bool) {
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
                        boolean bool = false;
                        for (int i = nCars; i < CarDefine.nlocars; i++)
                            if (Math.abs(CarDefine.cclass[i] - (ontyp - 1)) <= 1) {
                                if (!bool) {
                                    minsl = i;
                                    bool = true;
                                }
                                if (bool) {
                                    maxsl = i;
                                }
                            }
                        if (!bool) {
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
            GameSparker.mycar.setLabel(" Include in this game.");
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
            CheckPoints.stage = (int) (ThreadLocalRandom.current().nextDouble() * nTracks) + 1;
            CheckPoints.top20 = 0;
        }
        if (CheckPoints.stage > nTracks) {
            CheckPoints.stage = (int) (ThreadLocalRandom.current().nextDouble() * nTracks) + 1;
        }
        if (CheckPoints.stage == -2) {
            boolean bool = false;
            for (int i = 1; i < GameSparker.mstgs.getItemCount(); i++)
                if (GameSparker.mstgs.getItem(i).equals(CheckPoints.name)) {
                    bool = true;
                }
            if (!bool) {
                CheckPoints.stage = (int) (ThreadLocalRandom.current().nextDouble() * nTracks) + 1;
            }
        }
        /*if (gmode == 1) {
        	if (unlocked[0] != 11 || justwon1)
        		checkpoints.stage = unlocked[0];
        	else if (winner || checkpoints.stage > 11)
        		checkpoints.stage = (int) (ThreadLocalRandom.current().nextDouble() * 11.0) + 1;
        	if (checkpoints.stage == 11)
        		checkpoints.stage = 27;
        }*/
        if (gmode == 2)
            if (unlocked != nTracks || justwon2) {
                CheckPoints.stage = unlocked/* + 10*/;
            } else if (winner/* || checkpoints.stage < 11*/) {
                CheckPoints.stage = (int) (ThreadLocalRandom.current().nextDouble() * nTracks) + 1;
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
                    if (ThreadLocalRandom.current().nextDouble() > ThreadLocalRandom.current().nextDouble()) {
                        duds = (int) (ThreadLocalRandom.current().nextDouble() * 3.0);
                    } else {
                        duds = (int) (ThreadLocalRandom.current().nextDouble() * 2.0);
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
                rd.drawString("One is by racing and finishing in first place, the other is by", 262, 127);
                rd.drawString("wasting and crashing all the other cars in the stage!", 262, 147);
            } else {
                rd.setColor(new Color(0, 128, 255));
                rd.drawString("While racing, you will need to focus on going fast and passing", 262, 67);
                rd.drawString("through all the checkpoints in the track. To complete a lap, you", 262, 87);
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
            rd.drawString("(When your car is on the ground Spacebar is for Handbrake)", 125, 341);
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
                rd.drawString("Forward looping pushes your car forwards in the air and helps", 262, 87);
                rd.drawString("when racing. Backward looping pushes your car upwards giving it", 262, 107);
                rd.drawString("more hang time in the air making it easier to control its landing.", 262, 127);
                rd.drawString("Left and right rolls shift your car in the air left and right slightly.", 262, 147);
                if (aflk || dudo < 150) {
                    rd.drawImage(chil, 167, 295, null);
                }
            }
            rd.setColor(new Color(0, 0, 0));
            rd.drawImage(stunts, 105, 175, null);
            rd.drawImage(opwr, 540, 253, null);
            rd.setFont(new Font("Arial", 1, 13));
            rd.drawString("To perform stunts. When your car is in the AIR:", 125, 310);
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
                rd.drawString("When wasting cars, to help you find the other cars in the stage,", 262, 67);
                rd.drawString("press [ A ] to toggle the guidance arrow from pointing to the track", 262, 87);
                rd.drawString("to pointing to the cars.", 262, 107);
                rd.drawString("When your car is damaged. You fix it (and reset its 'Damage') by", 262, 127);
                rd.drawString("jumping through the electrified hoop.", 262, 147);
            } else {
                rd.setColor(new Color(0, 128, 255));
                rd.drawString("You will find that in some stages it's easier to waste the other cars", 262, 67);
                rd.drawString("and in some others it's easier to race and finish in first place.", 262, 87);
                rd.drawString("It is up to you to decide when to waste and when to race.", 262, 107);
                rd.drawString("And remember, 'Power' is an important factor in the game. You", 262, 127);
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
            rd.drawString("On the GROUND Spacebar is for Handbrake", 125, 101);
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
            final int[] is = new int[360000];
            final PixelGrabber pixelgrabber = new PixelGrabber(GameSparker.offImage, 0, 0, 800, 450, is, 0, 800);
            try {
                pixelgrabber.grabPixels();
            } catch (final InterruptedException ignored) {

            }
            int i = 0;
            int i353 = 0;
            int i354 = 0;
            int i355 = 0;
            for (int i356 = 0; i356 < 360000; i356++) {
                final Color color = new Color(is[i356]);
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
                is[i356] = color362.getRGB();
            }
            final Image image = xt.createImage(new MemoryImageSource(800, 450, is, 0, 800));
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

    static private Image loadBimage(final byte[] is, final MediaTracker mediatracker, final Toolkit toolkit, final int i) {
        final Image image = toolkit.createImage(is);
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

    static private Image loadimage(final byte[] is, final MediaTracker mediatracker, final Toolkit toolkit) {
        final Image image = toolkit.createImage(is);
        mediatracker.addImage(image, 0);
        try {
            mediatracker.waitForID(0);
        } catch (final Exception ignored) {

        }
        return image;
    }
    
    private static interface ImageConsumer {
        void accept(byte[] is, MediaTracker mediatracker, Toolkit toolkit);
    }
    
    private static final class ImageIdentifier {
        final String fileName;
        final ImageConsumer cons;
        private ImageIdentifier(String s, ImageConsumer c) {
            cons=c;
            fileName=s;
        }
    }
    
    private static Image cbg1, cbg2;
    
    private static final ImageIdentifier[] idts = {

        new ImageIdentifier("cars.gif", (is, mediatracker, toolkit) -> {
            carsbg = loadBimage(is, mediatracker, toolkit, 1);
        }),
        new ImageIdentifier("color.gif", (is, mediatracker, toolkit) -> {
            cbg1 = loadBimage(is, mediatracker, toolkit, 0);
            
            if (cbg1 != null && cbg2 != null)
                makecarsbgc(cbg1, cbg2);
        }),
        new ImageIdentifier("class.gif", (is, mediatracker, toolkit) -> {
            cbg2 = loadBimage(is, mediatracker, toolkit, 0);

            if (cbg1 != null && cbg2 != null)
                makecarsbgc(cbg1, cbg2);
        }),
        new ImageIdentifier("smokey.gif", (is, mediatracker, toolkit) -> {
            smokeypix(is, mediatracker, toolkit);
        }),
        new ImageIdentifier("1.gif", (is, mediatracker, toolkit) -> {
            orank[0] = loadimage(is, mediatracker, toolkit);
        }),
        new ImageIdentifier("gameh.gif", (is, mediatracker, toolkit) -> {
            ogameh = loadimage(is, mediatracker, toolkit);
        }),
        new ImageIdentifier("wgame.gif", (is, mediatracker, toolkit) -> {
            owgame = loadimage(is, mediatracker, toolkit);
        }),
        new ImageIdentifier("gameov.gif", (is, mediatracker, toolkit) -> {
            gameov = loadimage(is, mediatracker, toolkit);
        }),
        new ImageIdentifier("lap.gif", (is, mediatracker, toolkit) -> {
            olap = loadimage(is, mediatracker, toolkit);
        }),
        new ImageIdentifier("paused.gif", (is, mediatracker, toolkit) -> {
            paused = loadimage(is, mediatracker, toolkit);
        }),
        new ImageIdentifier("select.gif", (is, mediatracker, toolkit) -> {
            select = loadimage(is, mediatracker, toolkit);
        }),
        new ImageIdentifier("yourwasted.gif", (is, mediatracker, toolkit) -> {
            oyourwasted = loadimage(is, mediatracker, toolkit);
        }),
        new ImageIdentifier("disco.gif", (is, mediatracker, toolkit) -> {
            odisco = loadimage(is, mediatracker, toolkit);
        }),
        new ImageIdentifier("youwastedem.gif", (is, mediatracker, toolkit) -> {
            oyouwastedem = loadimage(is, mediatracker, toolkit);
        }),
        new ImageIdentifier("gamefinished.gif", (is, mediatracker, toolkit) -> {
            ogamefinished = loadimage(is, mediatracker, toolkit);
        }),
        new ImageIdentifier("exitgame.gif", (is, mediatracker, toolkit) -> {
            oexitgame = loadimage(is, mediatracker, toolkit);
        }),
        new ImageIdentifier("pgate.gif", (is, mediatracker, toolkit) -> {
            pgate = loadimage(is, mediatracker, toolkit);
        }),
        new ImageIdentifier("d1.png", (is, mediatracker, toolkit) -> {
            dude[0] = loadimage(is, mediatracker, toolkit);
        }),
        new ImageIdentifier("d2.png", (is, mediatracker, toolkit) -> {
            dude[1] = loadimage(is, mediatracker, toolkit);
        }),
        new ImageIdentifier("d3.png", (is, mediatracker, toolkit) -> {
            dude[2] = loadimage(is, mediatracker, toolkit);
        }),
        new ImageIdentifier("float.gif", (is, mediatracker, toolkit) -> {
            oflaot = loadimage(is, mediatracker, toolkit);
        }),
        new ImageIdentifier("1c.gif", (is, mediatracker, toolkit) -> {
            ocntdn[1] = loadimage(is, mediatracker, toolkit);
        }),
        new ImageIdentifier("2c.gif", (is, mediatracker, toolkit) -> {
            ocntdn[2] = loadimage(is, mediatracker, toolkit);
        }),
        new ImageIdentifier("3c.gif", (is, mediatracker, toolkit) -> {
            ocntdn[3] = loadimage(is, mediatracker, toolkit);
        }),
        new ImageIdentifier("2.gif", (is, mediatracker, toolkit) -> {
            orank[1] = loadimage(is, mediatracker, toolkit);
        }),
        new ImageIdentifier("3.gif", (is, mediatracker, toolkit) -> {
            orank[2] = loadimage(is, mediatracker, toolkit);
        }),
        new ImageIdentifier("4.gif", (is, mediatracker, toolkit) -> {
            orank[3] = loadimage(is, mediatracker, toolkit);
        }),
        new ImageIdentifier("5.gif", (is, mediatracker, toolkit) -> {
            orank[4] = loadimage(is, mediatracker, toolkit);
        }),
        new ImageIdentifier("6.gif", (is, mediatracker, toolkit) -> {
            orank[5] = loadimage(is, mediatracker, toolkit);
        }),
        new ImageIdentifier("7.gif", (is, mediatracker, toolkit) -> {
            orank[6] = loadimage(is, mediatracker, toolkit);
        }),
        new ImageIdentifier("8.gif", (is, mediatracker, toolkit) -> {
            orank[7] = loadimage(is, mediatracker, toolkit);
        }),
        new ImageIdentifier("bgmain.jpg", (is, mediatracker, toolkit) -> {
            bgmain = loadBimage(is, mediatracker, toolkit, 2);
        }),
        new ImageIdentifier("br.png", (is, mediatracker, toolkit) -> {
            br = loadimage(is, mediatracker, toolkit);
        }),
        new ImageIdentifier("loadingmusic.gif", (is, mediatracker, toolkit) -> {
            oloadingmusic = loadimage(is, mediatracker, toolkit);
        }),
        new ImageIdentifier("radicalplay.gif", (is, mediatracker, toolkit) -> {
            radicalplay = loadimage(is, mediatracker, toolkit);
        }),
        new ImageIdentifier("back.gif", (is, mediatracker, toolkit) -> {
            back[0] = loadimage(is, mediatracker, toolkit);
            back[1] = bressed(back[0]);
        }),
        new ImageIdentifier("continue.gif", (is, mediatracker, toolkit) -> {
            contin[0] = loadimage(is, mediatracker, toolkit);
            contin[1] = bressed(contin[0]);
        }),
        new ImageIdentifier("next.gif", (is, mediatracker, toolkit) -> {
            next[0] = loadimage(is, mediatracker, toolkit);
            next[1] = bressed(next[0]);
        }),
        new ImageIdentifier("rpro.gif", (is, mediatracker, toolkit) -> {
            rpro = loadimage(is, mediatracker, toolkit);
        }),
        new ImageIdentifier("selectcar.gif", (is, mediatracker, toolkit) -> {
            selectcar = loadimage(is, mediatracker, toolkit);
        }),
        new ImageIdentifier("track.jpg", (is, mediatracker, toolkit) -> {
            trackbg[0] = loadBimage(is, mediatracker, toolkit, 3);
            trackbg[1] = dodgen(trackbg[0]);
        }),
        new ImageIdentifier("youlost.gif", (is, mediatracker, toolkit) -> {
            oyoulost = loadimage(is, mediatracker, toolkit);
        }),
        new ImageIdentifier("youwon.gif", (is, mediatracker, toolkit) -> {
            oyouwon = loadimage(is, mediatracker, toolkit);
        }),
        new ImageIdentifier("0c.gif", (is, mediatracker, toolkit) -> {
            ocntdn[0] = loadimage(is, mediatracker, toolkit);
        }),
        new ImageIdentifier("damage.gif", (is, mediatracker, toolkit) -> {
            odmg = loadimage(is, mediatracker, toolkit);
        }),
        new ImageIdentifier("power.gif", (is, mediatracker, toolkit) -> {
            opwr = loadimage(is, mediatracker, toolkit);
        }),
        new ImageIdentifier("position.gif", (is, mediatracker, toolkit) -> {
            opos = loadimage(is, mediatracker, toolkit);
        }),
        new ImageIdentifier("speed.gif", (is, mediatracker, toolkit) -> {
            osped = loadimage(is, mediatracker, toolkit);
        }),
        new ImageIdentifier("wasted.gif", (is, mediatracker, toolkit) -> {
            owas = loadimage(is, mediatracker, toolkit);
        }),
        new ImageIdentifier("start1.gif", (is, mediatracker, toolkit) -> {
            ostar[0] = loadimage(is, mediatracker, toolkit);
        }),
        new ImageIdentifier("start2.gif", (is, mediatracker, toolkit) -> {
            ostar[1] = loadimage(is, mediatracker, toolkit);
            star[2] = pressed(ostar[1]);
        }),
        new ImageIdentifier("congrad.gif", (is, mediatracker, toolkit) -> {
            congrd = loadimage(is, mediatracker, toolkit);
        }),
        new ImageIdentifier("statb.gif", (is, mediatracker, toolkit) -> {
            statb = loadimage(is, mediatracker, toolkit);
        }),
        new ImageIdentifier("statbo.gif", (is, mediatracker, toolkit) -> {
            statbo = loadimage(is, mediatracker, toolkit);
        }),
        new ImageIdentifier("madness.gif", (is, mediatracker, toolkit) -> {
            mdness = loadude(is, mediatracker, toolkit);
        }),
//            new ImageIdentifier("onfmm.gif", (is, mediatracker, toolkit) -> {
//                onfmm = loadude(is, mediatracker, toolkit);
//            }),
        new ImageIdentifier("fixhoop.png", (is, mediatracker, toolkit) -> {
            fixhoop = loadimage(is, mediatracker, toolkit);
        }),
        new ImageIdentifier("arrow.gif", (is, mediatracker, toolkit) -> {
            sarrow = loadimage(is, mediatracker, toolkit);
        }),
        new ImageIdentifier("stunts.png", (is, mediatracker, toolkit) -> {
            stunts = loadimage(is, mediatracker, toolkit);
        }),
        new ImageIdentifier("racing.gif", (is, mediatracker, toolkit) -> {
            racing = loadimage(is, mediatracker, toolkit);
        }),
        new ImageIdentifier("wasting.gif", (is, mediatracker, toolkit) -> {
            wasting = loadimage(is, mediatracker, toolkit);
        }),
        new ImageIdentifier("plus.gif", (is, mediatracker, toolkit) -> {
            plus = loadimage(is, mediatracker, toolkit);
        }),
        new ImageIdentifier("space.gif", (is, mediatracker, toolkit) -> {
            space = loadimage(is, mediatracker, toolkit);
        }),
        new ImageIdentifier("arrows.gif", (is, mediatracker, toolkit) -> {
            arrows = loadimage(is, mediatracker, toolkit);
        }),
        new ImageIdentifier("chil.gif", (is, mediatracker, toolkit) -> {
            chil = loadimage(is, mediatracker, toolkit);
        }),
        new ImageIdentifier("ory.gif", (is, mediatracker, toolkit) -> {
            ory = loadimage(is, mediatracker, toolkit);
        }),
        new ImageIdentifier("kz.gif", (is, mediatracker, toolkit) -> {
            kz = loadimage(is, mediatracker, toolkit);
        }),
        new ImageIdentifier("kx.gif", (is, mediatracker, toolkit) -> {
            kx = loadimage(is, mediatracker, toolkit);
        }),
        new ImageIdentifier("kv.gif", (is, mediatracker, toolkit) -> {
            kv = loadimage(is, mediatracker, toolkit);
        }),
        new ImageIdentifier("km.gif", (is, mediatracker, toolkit) -> {
            km = loadimage(is, mediatracker, toolkit);
        }),
        new ImageIdentifier("kn.gif", (is, mediatracker, toolkit) -> {
            kn = loadimage(is, mediatracker, toolkit);
        }),
        new ImageIdentifier("ks.gif", (is, mediatracker, toolkit) -> {
            ks = loadimage(is, mediatracker, toolkit);
        }),
        new ImageIdentifier("kenter.gif", (is, mediatracker, toolkit) -> {
            kenter = loadimage(is, mediatracker, toolkit);
        }),
        new ImageIdentifier("nfm.gif", (is, mediatracker, toolkit) -> {
            nfm = loadimage(is, mediatracker, toolkit);
        }),
        new ImageIdentifier("options.png", (is, mediatracker, toolkit) -> {
            opti = loadimage(is, mediatracker, toolkit);
        }),
        new ImageIdentifier("opback.png", (is, mediatracker, toolkit) -> {
            opback = loadimage(is, mediatracker, toolkit);
        }),
        new ImageIdentifier("logocars.png", (is, mediatracker, toolkit) -> {
            logocars = loadimage(is, mediatracker, toolkit);
        }),
        new ImageIdentifier("logomad.png", (is, mediatracker, toolkit) -> {
            logomadnes = loadimage(is, mediatracker, toolkit);
        }),
        new ImageIdentifier("logomadbg.jpg", (is, mediatracker, toolkit) -> {
            logomadbg = loadimage(is, mediatracker, toolkit);
        }),
        new ImageIdentifier("byrd.png", (is, mediatracker, toolkit) -> {
            byrd = loadimage(is, mediatracker, toolkit);
        }),
        new ImageIdentifier("bggo.jpg", (is, mediatracker, toolkit) -> {
            bggo = loadimage(is, mediatracker, toolkit);
        }),
        new ImageIdentifier("nfmcoms.png", (is, mediatracker, toolkit) -> {
            nfmcoms = loadimage(is, mediatracker, toolkit);
        }),
        new ImageIdentifier("nfmcom.gif", (is, mediatracker, toolkit) -> {
            nfmcom = loadBimage(is, mediatracker, toolkit, 0);
        }),
        new ImageIdentifier("brit.gif", (is, mediatracker, toolkit) -> {
            brt = loadimage(is, mediatracker, toolkit);
        }),
        new ImageIdentifier("arn.gif", (is, mediatracker, toolkit) -> {
            arn = loadimage(is, mediatracker, toolkit);
        }),
        new ImageIdentifier("mload.gif", (is, mediatracker, toolkit) -> {
            mload = loadimage(is, mediatracker, toolkit);
        }),
        new ImageIdentifier("login.gif", (is, mediatracker, toolkit) -> {
            login = loadBimage(is, mediatracker, toolkit, 0);
        }),
        new ImageIdentifier("play.gif", (is, mediatracker, toolkit) -> {
            play = loadBimage(is, mediatracker, toolkit, 0);
        }),
        new ImageIdentifier("cancel.gif", (is, mediatracker, toolkit) -> {
            cancel = loadBimage(is, mediatracker, toolkit, 0);
        }),
        new ImageIdentifier("register.gif", (is, mediatracker, toolkit) -> {
            register = loadBimage(is, mediatracker, toolkit, 0);
        }),
        new ImageIdentifier("upgrade.gif", (is, mediatracker, toolkit) -> {
            upgrade = loadimage(is, mediatracker, toolkit);
        }),
        new ImageIdentifier("sdets.gif", (is, mediatracker, toolkit) -> {
            sdets = loadBimage(is, mediatracker, toolkit, 0);
        }),
        new ImageIdentifier("bob.gif", (is, mediatracker, toolkit) -> {
            bob = loadBimage(is, mediatracker, toolkit, 1);
        }),
        new ImageIdentifier("bot.gif", (is, mediatracker, toolkit) -> {
            bot = loadBimage(is, mediatracker, toolkit, 1);
        }),
        new ImageIdentifier("bol.gif", (is, mediatracker, toolkit) -> {
            bol = loadBimage(is, mediatracker, toolkit, 0);
        }),
        new ImageIdentifier("bolp.gif", (is, mediatracker, toolkit) -> {
            bolp = loadBimage(is, mediatracker, toolkit, 0);
        }),
        new ImageIdentifier("bor.gif", (is, mediatracker, toolkit) -> {
            bor = loadBimage(is, mediatracker, toolkit, 0);
        }),
        new ImageIdentifier("borp.gif", (is, mediatracker, toolkit) -> {
            borp = loadBimage(is, mediatracker, toolkit, 0);
        }),
        new ImageIdentifier("logout.gif", (is, mediatracker, toolkit) -> {
            logout = loadBimage(is, mediatracker, toolkit, 0);
        }),
        new ImageIdentifier("change.gif", (is, mediatracker, toolkit) -> {
            change = loadBimage(is, mediatracker, toolkit, 0);
        }),
        new ImageIdentifier("pln.gif", (is, mediatracker, toolkit) -> {
            pln = loadBimage(is, mediatracker, toolkit, 0);
        }),
        new ImageIdentifier("bols.gif", (is, mediatracker, toolkit) -> {
            bols = loadBimage(is, mediatracker, toolkit, 0);
        }),
        new ImageIdentifier("bolps.gif", (is, mediatracker, toolkit) -> {
            bolps = loadBimage(is, mediatracker, toolkit, 0);
        }),
        new ImageIdentifier("bors.gif", (is, mediatracker, toolkit) -> {
            bors = loadBimage(is, mediatracker, toolkit, 0);
        }),
        new ImageIdentifier("borps.gif", (is, mediatracker, toolkit) -> {
            borps = loadBimage(is, mediatracker, toolkit, 0);
        }),
        new ImageIdentifier("games.gif", (is, mediatracker, toolkit) -> {
            games = loadBimage(is, mediatracker, toolkit, 0);
        }),
        new ImageIdentifier("exit.gif", (is, mediatracker, toolkit) -> {
            exit = loadBimage(is, mediatracker, toolkit, 0);
        }),
        new ImageIdentifier("roomp.gif", (is, mediatracker, toolkit) -> {
            roomp = loadBimage(is, mediatracker, toolkit, 0);
        }),
        new ImageIdentifier("ready.gif", (is, mediatracker, toolkit) -> {
            redy = loadBimage(is, mediatracker, toolkit, 0);
        }),
        new ImageIdentifier("notreg.gif", (is, mediatracker, toolkit) -> {
            ntrg = loadBimage(is, mediatracker, toolkit, 0);
        }),
        new ImageIdentifier("cgame.gif", (is, mediatracker, toolkit) -> {
            cgame = loadBimage(is, mediatracker, toolkit, 0);
        }),
        new ImageIdentifier("ccar.gif", (is, mediatracker, toolkit) -> {
            ccar = loadBimage(is, mediatracker, toolkit, 0);
        }),
        new ImageIdentifier("lanm.gif", (is, mediatracker, toolkit) -> {
            lanm = loadBimage(is, mediatracker, toolkit, 0);
        }),
        new ImageIdentifier("asu.gif", (is, mediatracker, toolkit) -> {
            asu = loadimage(is, mediatracker, toolkit);
        }),
        new ImageIdentifier("asd.gif", (is, mediatracker, toolkit) -> {
            asd = loadimage(is, mediatracker, toolkit);
        }),
        new ImageIdentifier("pls.gif", (is, mediatracker, toolkit) -> {
            pls = loadBimage(is, mediatracker, toolkit, 0);
        }),
        new ImageIdentifier("sts.gif", (is, mediatracker, toolkit) -> {
            sts = loadBimage(is, mediatracker, toolkit, 0);
        }),
        new ImageIdentifier("gmc.gif", (is, mediatracker, toolkit) -> {
            gmc = loadBimage(is, mediatracker, toolkit, 0);
        }),
        new ImageIdentifier("stg.gif", (is, mediatracker, toolkit) -> {
            stg = loadBimage(is, mediatracker, toolkit, 0);
        }),
        new ImageIdentifier("crd.gif", (is, mediatracker, toolkit) -> {
            crd = loadBimage(is, mediatracker, toolkit, 0);
        }),
        new ImageIdentifier("bcl.gif", (is, mediatracker, toolkit) -> {
            bcl[0] = loadimage(is, mediatracker, toolkit);
        }),
        new ImageIdentifier("bcr.gif", (is, mediatracker, toolkit) -> {
            bcr[0] = loadimage(is, mediatracker, toolkit);
        }),
        new ImageIdentifier("bc.gif", (is, mediatracker, toolkit) -> {
            bc[0] = loadimage(is, mediatracker, toolkit);
        }),
        new ImageIdentifier("pbcl.gif", (is, mediatracker, toolkit) -> {
            bcl[1] = loadimage(is, mediatracker, toolkit);
        }),
        new ImageIdentifier("pbcr.gif", (is, mediatracker, toolkit) -> {
            bcr[1] = loadimage(is, mediatracker, toolkit);
        }),
        new ImageIdentifier("pbc.gif", (is, mediatracker, toolkit) -> {
            bc[1] = loadimage(is, mediatracker, toolkit);
        }),
        new ImageIdentifier("yac.gif", (is, mediatracker, toolkit) -> {
            yac = loadimage(is, mediatracker, toolkit);
        }),
        new ImageIdentifier("ycmc.gif", (is, mediatracker, toolkit) -> {
            ycmc = loadimage(is, mediatracker, toolkit);
        }),
    };
    

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

    static void loadingstage(final boolean bool) {

        trackbg(true);
        rd.drawImage(br, 65, 25, null);
        rd.setColor(new Color(212, 214, 138));
        rd.fillRoundRect(265, 201, 270, 26, 20, 40);
        rd.setColor(new Color(57, 64, 8));
        rd.drawRoundRect(265, 201, 270, 26, 20, 40);
        rd.setFont(new Font("Arial", 1, 12));
        ftm = rd.getFontMetrics();
        drawcs(219, "Loading, please wait...", 58, 61, 17, 3);
        if (bool) {
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

    static void loadmusic(final int i, final String string, final int i51) {
        hipnoload(i, false);
        app.setCursor(new Cursor(3));
        //app.repaint();
        boolean bool = false;
        if (multion == 0) {
            if (i == 1 || i == 2 || i == 3 || i == 4 || i == 5 || i == 10) {
                bool = true;
            }
            if (i == 11 || i == 12 || i == 13 || i == 14 || i == 17 || i == 18 || i == 19 || i == 20 || i == 22 || i == 23 || i == 26) {
                bool = true;
            }
            if (i < 0 && nplayers != 1 && newparts) {
                bool = true;
            }
        } else if (ransay == 1 || ransay == 2 || ransay == 3 || ransay == 4 || i == 10) {
            bool = true;
        }
        if (bool) {
            runtyp = i;
            runner = new Thread(xt);
            runner.start();
        }
        loadstrack(i, string, i51);
        if (bool) {
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
        final int[] is = new int[i325 * i324];
        final PixelGrabber pixelgrabber = new PixelGrabber(image, 0, 0, i325, i324, is, 0, i325);
        try {
            pixelgrabber.grabPixels();
        } catch (final InterruptedException ignored) {

        }
        if (i < 0) {
            i = 33;
        }
        int i326 = 0;
        if (i323 == 1) {
            i326 = is[61993];
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
            if (is[i329] != is[i323]) {
                final Color color = new Color(is[i329]);
                int i332;
                int i333;
                int i334;
                if (i323 == 1 && is[i329] == i326) {
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
                is[i329] = color335.getRGB();
            }
        return xt.createImage(new MemoryImageSource(i325, i324, is, 0, i325));
    }

    static private Image loadsnap(final Image image) {
        final int i = image.getHeight(null);
        final int i316 = image.getWidth(null);
        final int[] is = new int[i316 * i];
        final PixelGrabber pixelgrabber = new PixelGrabber(image, 0, 0, i316, i, is, 0, i316);
        try {
            pixelgrabber.grabPixels();
        } catch (final InterruptedException ignored) {

        }
        for (int i317 = 0; i317 < i316 * i; i317++) {
            final Color color = new Color(is[i316 * i - 1]);
            final Color color318 = new Color(is[i317]);
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
                is[i317] = ~0xffffff | i319 << 16 | i320 << 8 | i321;
            } else {
                int i322 = (int) ((float) (color.getRed() - color318.getRed()) / (float) color.getRed() * 255.0F);
                if (i322 > 255) {
                    i322 = 255;
                }
                if (i322 < 0) {
                    i322 = 0;
                }
                is[i317] = i322 << 24 | 0x0 | 0x0 | 0x0;
            }
        }
        final BufferedImage bufferedimage = new BufferedImage(i316, i, 2);
        bufferedimage.setRGB(0, 0, i316, i, is, 0, i316);
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
                final String string = zipentry.getName();
                final byte[] is = new byte[i];
                int i0 = 0;
                int i1;
                for (; i > 0; i -= i1) {
                    i1 = zipinputstream.read(is, i0, i);
                    i0 += i1;
                }
                for (int i2 = 0; i2 < 5; i2++) {
                    for (int i3 = 0; i3 < 5; i3++)
                        if (string.equals("" + i3 + "" + i2 + ".wav")) {
                            engs[i3][i2] = new SoundClip("temp-sound/" + string);
                        }
                }
                for (int i4 = 0; i4 < 6; i4++)
                    if (string.equals("air" + i4 + ".wav")) {
                        air[i4] = new SoundClip("temp-sound/" + string);
                    }
                for (int i5 = 0; i5 < 3; i5++)
                    if (string.equals("crash" + (i5 + 1) + ".wav")) {
                        crash[i5] = new SoundClip("temp-sound/" + string);
                    }
                for (int i6 = 0; i6 < 3; i6++)
                    if (string.equals("lowcrash" + (i6 + 1) + ".wav")) {
                        lowcrash[i6] = new SoundClip("temp-sound/" + string);
                    }
                for (int i7 = 0; i7 < 3; i7++)
                    if (string.equals("skid" + (i7 + 1) + ".wav")) {
                        skid[i7] = new SoundClip("temp-sound/" + string);
                    }
                for (int i8 = 0; i8 < 3; i8++)
                    if (string.equals("dustskid" + (i8 + 1) + ".wav")) {
                        dustskid[i8] = new SoundClip("temp-sound/" + string);
                    }
                for (int i9 = 0; i9 < 3; i9++)
                    if (string.equals("scrape" + (i9 + 1) + ".wav")) {
                        scrape[i9] = new SoundClip("temp-sound/" + string);
                        if (i9 == 2) {
                            scrape[3] = new SoundClip("temp-sound/" + string);
                        }
                    }
                if (string.equals("powerup.wav")) {
                    powerup = new SoundClip("temp-sound/" + string);
                }
                if (string.equals("tires.wav")) {
                    tires = new SoundClip("temp-sound/" + string);
                }
                if (string.equals("checkpoint.wav")) {
                    checkpoint = new SoundClip("temp-sound/" + string);
                }
                if (string.equals("carfixed.wav")) {
                    carfixed = new SoundClip("temp-sound/" + string);
                }
                if (string.equals("three.wav")) {
                    three = new SoundClip("temp-sound/" + string);
                }
                if (string.equals("two.wav")) {
                    two = new SoundClip("temp-sound/" + string);
                }
                if (string.equals("one.wav")) {
                    one = new SoundClip("temp-sound/" + string);
                }
                if (string.equals("go.wav")) {
                    go = new SoundClip("temp-sound/" + string);
                }
                if (string.equals("wasted.wav")) {
                    wastd = new SoundClip("temp-sound/" + string);
                }
                if (string.equals("firewasted.wav")) {
                    firewasted = new SoundClip("temp-sound/" + string);
                }
                dnload += 5;
            }
            fileinputstream.close();
            zipinputstream.close();
        } catch (final Exception exception) {
            System.out.println("Error Loading Sounds: " + exception);
        }
        System.gc();
    }

    static void loadstrack(final int i, final String string, final int i52) {
        strack = TrackZipLoader.loadLegacy(i, string, i52);

        loadedt = true;
    }

    static private Image loadude(final byte[] is, final MediaTracker mediatracker, final Toolkit toolkit) {
        final Image image = toolkit.createImage(is);
        mediatracker.addImage(image, 0);
        try {
            mediatracker.waitForID(0);
        } catch (final Exception ignored) {

        }
        final int i = image.getHeight(null);
        final int i364 = image.getWidth(null);
        final int[] is365 = new int[i364 * i];
        final PixelGrabber pixelgrabber = new PixelGrabber(image, 0, 0, i364, i, is365, 0, i364);
        try {
            pixelgrabber.grabPixels();
        } catch (final InterruptedException ignored) {

        }
        for (int i366 = 0; i366 < i364 * i; i366++) {
            final Color color = new Color(is365[i366]);
            if (color.getGreen() > color.getRed() + 5 && color.getGreen() > color.getBlue() + 5) {
                int i367 = (int) (255.0F - (color.getGreen() - (color.getRed() + color.getBlue()) / 2) * 1.5F);
                if (i367 > 255) {
                    i367 = 255;
                }
                if (i367 < 0) {
                    i367 = 0;
                }
                is365[i366] = i367 << 24 | 0x0 | 0x0 | 0x0;
            }
        }
        final BufferedImage bufferedimage = new BufferedImage(i364, i, 2);
        bufferedimage.setRGB(0, 0, i364, i, is365, 0, i364);
        return bufferedimage;
    }

    static void mainbg(final int i) {
        int i26 = 2;
        rd.setColor(new Color(191, 184, 124));
        if (i == -1) {
            if (i != lmode) {
                bgmy[0] = 0;
                bgmy[1] = -400;
                bgup = false;
                bgf = 0.0F;
                lmode = i;
            }
            rd.setColor(new Color(144, 222, 9));
            i26 = 8;
        }
        if (i == 0) {
            if (i != lmode) {
                bgmy[0] = 0;
                bgmy[1] = -400;
                bgup = false;
                bgf = 0.0F;
                lmode = i;
            }
            final int i27 = (int) (255.0F * bgf + 191.0F * (1.0F - bgf));
            final int i28 = (int) (176.0F * bgf + 184.0F * (1.0F - bgf));
            final int i29 = (int) (67.0F * bgf + 124.0F * (1.0F - bgf));
            if (!bgup) {
                bgf += 0.02F;
                if (bgf > 0.9F) {
                    bgf = 0.9F;
                    bgup = true;
                }
            } else {
                bgf -= 0.02F;
                if (bgf < 0.2F) {
                    bgf = 0.2F;
                    bgup = false;
                }
            }
            rd.setColor(new Color(i27, i28, i29));
            i26 = 4;
        }
        if (i == 1) {
            if (i != lmode) {
                bgmy[0] = 0;
                bgmy[1] = -400;
                lmode = i;
            }
            rd.setColor(new Color(255, 176, 67));
            i26 = 8;
        }
        if (i == 2) {
            if (i != lmode) {
                bgmy[0] = 0;
                bgmy[1] = -400;
                lmode = i;
                bgf = 0.2F;
            }
            rd.setColor(new Color(188, 170, 122));
            if (flipo == 16) {
                final int i30 = (int) (176.0F * bgf + 191.0F * (1.0F - bgf));
                final int i31 = (int) (202.0F * bgf + 184.0F * (1.0F - bgf));
                final int i32 = (int) (255.0F * bgf + 124.0F * (1.0F - bgf));
                rd.setColor(new Color(i30, i31, i32));
                bgf += 0.025F;
                if (bgf > 0.85F) {
                    bgf = 0.85F;
                }
            } else {
                bgf = 0.2F;
            }
            i26 = 2;
        }
        if (i == 3) {
            if (i != lmode) {
                bgmy[0] = 0;
                bgmy[1] = -400;
                bgup = false;
                bgf = 0.0F;
                lmode = i;
            }
            final int i33 = (int) (255.0F * bgf + 191.0F * (1.0F - bgf));
            final int i34 = (int) (176.0F * bgf + 184.0F * (1.0F - bgf));
            final int i35 = (int) (67.0F * bgf + 124.0F * (1.0F - bgf));
            if (!bgup) {
                bgf += 0.02F;
                if (bgf > 0.9F) {
                    bgf = 0.9F;
                    bgup = true;
                }
            } else {
                bgf -= 0.02F;
                if (bgf < 0.2F) {
                    bgf = 0.2F;
                    bgup = false;
                }
            }
            rd.setColor(new Color(i33, i34, i35));
            i26 = 2;
        }
        if (i != -101)
            if (i == 4) {
                rd.setColor(new Color(216, 177, 100));
                rd.fillRect(65, 0, 670, 425);
            } else {
                rd.fillRect(65, 25, 670, 400);
            }
        if (i == 4) {
            if (i != lmode) {
                bgmy[0] = 0;
                bgmy[1] = 400;
                for (int i36 = 0; i36 < 4; i36++) {
                    ovw[i36] = (int) (50.0 + 150.0 * ThreadLocalRandom.current().nextDouble());
                    ovh[i36] = (int) (50.0 + 150.0 * ThreadLocalRandom.current().nextDouble());
                    ovy[i36] = (int) (400.0 * ThreadLocalRandom.current().nextDouble());
                    ovx[i36] = (int) (ThreadLocalRandom.current().nextDouble() * 670.0);
                    ovsx[i36] = (int) (5.0 + ThreadLocalRandom.current().nextDouble() * 10.0);
                }
                lmode = i;
            }
            for (int i37 = 0; i37 < 4; i37++) {
                rd.setColor(new Color(235, 176, 84));
                rd.fillOval((int) (65 + ovx[i37] - ovw[i37] * 1.5 / 2.0), (int) (25 + ovy[i37] - ovh[i37] * 1.5 / 2.0), (int) (ovw[i37] * 1.5), (int) (ovh[i37] * 1.5));
                rd.setColor(new Color(255, 176, 67));
                rd.fillOval(65 + ovx[i37] - ovh[i37] / 2, 25 + ovy[i37] - ovh[i37] / 2, ovw[i37], ovh[i37]);
                ovx[i37] -= ovsx[i37];
                if (ovx[i37] + ovw[i37] * 1.5 / 2.0 < 0.0) {
                    ovw[i37] = (int) (50.0 + 150.0 * ThreadLocalRandom.current().nextDouble());
                    ovh[i37] = (int) (50.0 + 150.0 * ThreadLocalRandom.current().nextDouble());
                    ovy[i37] = (int) (400.0 * ThreadLocalRandom.current().nextDouble());
                    ovx[i37] = (int) (670.0 + ovw[i37] * 1.5 / 2.0);
                    ovsx[i37] = (int) (5.0 + ThreadLocalRandom.current().nextDouble() * 10.0);
                }
            }
        }
        if (i != -101 && i != 4) {
            for (int i38 = 0; i38 < 2; i38++) {
                if (i != 2 || flipo != 16) {
                    rd.drawImage(bgmain, 65, 25 + bgmy[i38], null);
                }
                bgmy[i38] += i26;
                if (bgmy[i38] >= 400) {
                    bgmy[i38] = -400;
                }
            }
        }
        rd.setColor(new Color(0, 0, 0));
        rd.fillRect(0, 0, 65, 450);
        rd.fillRect(735, 0, 65, 450);
        if (i != 4) {
            rd.fillRect(65, 0, 670, 25);
        }
        rd.fillRect(65, 425, 670, 25);
    }

    static void maini(final Control control) {
        if (flipo == 0) {
            app.setCursor(new Cursor(0));
            flipo++;
        }
        mainbg(1);
        rd.setComposite(AlphaComposite.getInstance(3, 0.6F));
        rd.drawImage(logomadbg, 65, 25, null);
        rd.setComposite(AlphaComposite.getInstance(3, 1.0F));
        rd.drawImage(logomadnes, 233, 186, null);
        float f = flkat / 800.0F;
        if (f > 0.2) {
            f = 0.2F;
        }
        if (flkat > 200) {
            f = (400 - flkat) / 1000.0F;
            if (f < 0.0F) {
                f = 0.0F;
            }
        }
        flkat++;
        if (flkat == 400) {
            flkat = 0;
        }
        rd.setComposite(AlphaComposite.getInstance(3, f));
        rd.drawImage(dude[0], 351 + gxdu, 28 + gydu, null);
        rd.setComposite(AlphaComposite.getInstance(3, 1.0F));
        if (movly == 0) {
            gxdu = (int) (5.0 - 11.0 * ThreadLocalRandom.current().nextDouble());
            gydu = (int) (5.0 - 11.0 * ThreadLocalRandom.current().nextDouble());
        }
        movly++;
        if (movly == 2) {
            movly = 0;
        }
        rd.drawImage(logocars, 66, 33, null);
        rd.drawImage(opback, 247, 237, null);
        if (muhi < 0) {
            rd.setColor(new Color(140, 70, 0));
            rd.fillRoundRect(335, 293, 114, 19, 7, 20);
        }
        muhi--;
        if (muhi < -5) {
            muhi = 50;
        }
        if (control.up) {
            opselect--;
            if (opselect == -1) {
                opselect = 3;
            }
            control.up = false;
        }
        if (control.down) {
            opselect++;
            if (opselect == 4) {
                opselect = 0;
            }
            control.down = false;
        }
        if (opselect == 0) {
            if (shaded) {
                rd.setColor(new Color(140, 70, 0));
                rd.fillRect(343, 261, 110, 22);
                aflk = false;
            }
            if (aflk) {
                rd.setColor(new Color(200, 200, 0));
                aflk = false;
            } else {
                rd.setColor(new Color(255, 128, 0));
                aflk = true;
            }
            rd.drawRoundRect(343, 261, 110, 22, 7, 20);
        } else {
            rd.setColor(new Color(0, 0, 0));
            rd.drawRoundRect(343, 261, 110, 22, 7, 20);
        }
        if (opselect == 1) {
            if (shaded) {
                rd.setColor(new Color(140, 70, 0));
                rd.fillRect(288, 291, 221, 22);
                aflk = false;
            }
            if (aflk) {
                rd.setColor(new Color(200, 191, 0));
                aflk = false;
            } else {
                rd.setColor(new Color(255, 95, 0));
                aflk = true;
            }
            rd.drawRoundRect(288, 291, 221, 22, 7, 20);
        } else {
            rd.setColor(new Color(0, 0, 0));
            rd.drawRoundRect(288, 291, 221, 22, 7, 20);
        }
        if (opselect == 2) {
            if (shaded) {
                rd.setColor(new Color(140, 70, 0));
                rd.fillRect(301, 321, 196, 22);
                aflk = false;
            }
            if (aflk) {
                rd.setColor(new Color(200, 128, 0));
                aflk = false;
            } else {
                rd.setColor(new Color(255, 128, 0));
                aflk = true;
            }
            rd.drawRoundRect(301, 321, 196, 22, 7, 20);
        } else {
            rd.setColor(new Color(0, 0, 0));
            rd.drawRoundRect(301, 321, 196, 22, 7, 20);
        }
        if (opselect == 3) {
            if (shaded) {
                rd.setColor(new Color(140, 70, 0));
                rd.fillRect(357, 351, 85, 22);
                aflk = false;
            }
            if (aflk) {
                rd.setColor(new Color(200, 0, 0));
                aflk = false;
            } else {
                rd.setColor(new Color(255, 128, 0));
                aflk = true;
            }
            rd.drawRoundRect(357, 351, 85, 22, 7, 20);
        } else {
            rd.setColor(new Color(0, 0, 0));
            rd.drawRoundRect(357, 351, 85, 22, 7, 20);
        }
        rd.drawImage(opti, 294, 265, null);
        if (control.enter || control.handb) {
            if (opselect == 1) {
                mtop = true;
                multion = 1;
                gmode = 0;
                if (firstime) {
                    oldfase = -9;
                    fase = 11;
                    firstime = false;
                } else {
                    fase = -9;
                }
            }
            if (opselect == 2) {
                oldfase = 10;
                fase = 11;
                firstime = false;
            }
            if (opselect == 3) {
                fase = 8;
            }
            if (opselect == 0)
                /*if (unlocked[0] == 11)
                	if (unlocked[1] != 17)
                		opselect = 1;
                	else
                		opselect = 2;*/
                if (firstime) {
                    oldfase = 102;
                    fase = 11;
                    firstime = false;
                } else {
                    fase = 102;
                }
            flipo = 0;
            control.enter = false;
            control.handb = false;
        }
        rd.drawImage(byrd, 72, 410, null);
        rd.drawImage(nfmcoms, 567, 410, null);
        if (shaded) {
            //app.repaint();
            try {
                Thread.sleep(200L);
            } catch (final InterruptedException ignored) {

            }
        }
    }

    static void maini2() {
        mainbg(1);
        multion = 0;
        clangame = 0;
        gmode = 2;
        fase = -9;
        opselect = 0;
    }

    static private void makecarsbgc(final Image image, final Image image386) {
        final int[] is = new int[268000];
        final PixelGrabber pixelgrabber = new PixelGrabber(carsbg, 0, 0, 670, 400, is, 0, 670);
        try {
            pixelgrabber.grabPixels();
        } catch (final InterruptedException ignored) {

        }
        final int[] is387 = new int[20700];
        final PixelGrabber pixelgrabber388 = new PixelGrabber(image, 0, 0, 92, 225, is387, 0, 92);
        try {
            pixelgrabber388.grabPixels();
        } catch (final InterruptedException ignored) {

        }
        final int[] is389 = new int[2112];
        final PixelGrabber pixelgrabber390 = new PixelGrabber(image386, 0, 0, 88, 24, is389, 0, 88);
        try {
            pixelgrabber390.grabPixels();
        } catch (final InterruptedException ignored) {

        }
        for (int i = 0; i < 670; i++) {
            for (int i391 = 0; i391 < 400; i391++) {
                if (i > 14 && i < 106 && i391 > 11 && i391 < 236 && is387[i - 14 + (i391 - 11) * 92] != is387[0]) {
                    final Color color = new Color(is[i + i391 * 670]);
                    final Color color392 = new Color(is387[i - 14 + (i391 - 11) * 92]);
                    int i393 = (int) (color.getRed() * 0.33 + color392.getRed() * 0.67);
                    if (i393 > 255) {
                        i393 = 255;
                    }
                    if (i393 < 0) {
                        i393 = 0;
                    }
                    int i394 = (int) (color.getGreen() * 0.33 + color392.getGreen() * 0.67);
                    if (i394 > 255) {
                        i394 = 255;
                    }
                    if (i394 < 0) {
                        i394 = 0;
                    }
                    int i395 = (int) (color.getBlue() * 0.33 + color392.getBlue() * 0.67);
                    if (i395 > 255) {
                        i395 = 255;
                    }
                    if (i395 < 0) {
                        i395 = 0;
                    }
                    final Color color396 = new Color(i393, i394, i395);
                    is[i + i391 * 670] = color396.getRGB();
                }
                if (i > 564 && i < 656 && i391 > 11 && i391 < 236 && is387[i - 564 + (i391 - 11) * 92] != is387[0]) {
                    final Color color = new Color(is[i + i391 * 670]);
                    final Color color397 = new Color(is387[i - 564 + (i391 - 11) * 92]);
                    int i398 = (int) (color.getRed() * 0.33 + color397.getRed() * 0.67);
                    if (i398 > 255) {
                        i398 = 255;
                    }
                    if (i398 < 0) {
                        i398 = 0;
                    }
                    int i399 = (int) (color.getGreen() * 0.33 + color397.getGreen() * 0.67);
                    if (i399 > 255) {
                        i399 = 255;
                    }
                    if (i399 < 0) {
                        i399 = 0;
                    }
                    int i400 = (int) (color.getBlue() * 0.33 + color397.getBlue() * 0.67);
                    if (i400 > 255) {
                        i400 = 255;
                    }
                    if (i400 < 0) {
                        i400 = 0;
                    }
                    final Color color401 = new Color(i398, i399, i400);
                    is[i + i391 * 670] = color401.getRGB();
                }
                if (i > 440 && i < 528 && i391 > 53 && i391 < 77 && is389[i - 440 + (i391 - 53) * 88] != is389[0]) {
                    final Color color = new Color(is[i + i391 * 670]);
                    final Color color402 = new Color(is389[i - 440 + (i391 - 53) * 88]);
                    int i403 = (int) (color.getRed() * 0.33 + color402.getRed() * 0.67);
                    if (i403 > 255) {
                        i403 = 255;
                    }
                    if (i403 < 0) {
                        i403 = 0;
                    }
                    int i404 = (int) (color.getGreen() * 0.33 + color402.getGreen() * 0.67);
                    if (i404 > 255) {
                        i404 = 255;
                    }
                    if (i404 < 0) {
                        i404 = 0;
                    }
                    int i405 = (int) (color.getBlue() * 0.33 + color402.getBlue() * 0.67);
                    if (i405 > 255) {
                        i405 = 255;
                    }
                    if (i405 < 0) {
                        i405 = 0;
                    }
                    final Color color406 = new Color(i403, i404, i405);
                    is[i + i391 * 670] = color406.getRGB();
                }
            }
        }
        carsbgc = xt.createImage(new MemoryImageSource(670, 400, is, 0, 670));
    }

    static boolean msgcheck(String string) {
        boolean bool = false;
        string = string.toLowerCase();
        final String[] strings = {
                "fu ", " rape", "slut ", "screw ", "redtube", "fuck", "fuk", "f*ck", "fu*k", "f**k", "ass hole",
                "asshole", "dick", "dik", "cock", "cok ", "shit", "damn", "sex", "anal", "whore", "bitch", "biatch",
                "bich", " ass", "bastard", "cunt", "dildo", "fag", "homo", "mothaf", "motherf", "negro", "nigga",
                "nigger", "pussy", "gay", "homo", "you punk", "i will kill you"
        };
        for (final String string2 : strings)
            if (string.contains(string2)) {
                bool = true;
            }
        if (string.startsWith("ass ")) {
            bool = true;
        }
        if (string.equals("ass")) {
            bool = true;
        }
        if (string.equals("rape")) {
            bool = true;
        }
        if (string.equals("fu")) {
            bool = true;
        }
        String string419 = "";
        String string420 = "";
        int i = 0;
        boolean bool421 = false;
        boolean bool422;
        for (bool422 = false; i < string.length() && !bool422; i++)
            if (!bool421) {
                string419 = "" + string419 + "" + string.charAt(i);
                bool421 = true;
            } else {
                bool421 = false;
                if (!string420.equals("") && !string420.equals("" + string.charAt(i))) {
                    bool422 = true;
                }
                string420 = "" + string.charAt(i);
            }
        if (!bool422) {
            for (final String string2 : strings)
                if (string419.contains(string2)) {
                    bool = true;
                }
        }
        string419 = "";
        string420 = "";
        i = 0;
        bool421 = true;
        for (bool422 = false; i < string.length() && !bool422; i++)
            if (!bool421) {
                string419 = "" + string419 + "" + string.charAt(i);
                bool421 = true;
            } else {
                bool421 = false;
                if (!string420.equals("") && !string420.equals("" + string.charAt(i))) {
                    bool422 = true;
                }
                string420 = "" + string.charAt(i);
            }
        if (!bool422) {
            for (final String string2 : strings)
                if (string419.contains(string2)) {
                    bool = true;
                }
        }
        string419 = "";
        string420 = "";
        i = 0;
        int i425 = 0;
        for (bool422 = false; i < string.length() && !bool422; i++)
            if (i425 == 0) {
                string419 = "" + string419 + "" + string.charAt(i);
                i425 = 2;
            } else {
                i425--;
                if (!string420.equals("") && !string420.equals("" + string.charAt(i))) {
                    bool422 = true;
                }
                string420 = "" + string.charAt(i);
            }
        if (!bool422) {
            for (final String string2 : strings)
                if (string419.contains(string2)) {
                    bool = true;
                }
        }
        string419 = "";
        string420 = "";
        i = 0;
        i425 = 1;
        for (bool422 = false; i < string.length() && !bool422; i++)
            if (i425 == 0) {
                string419 = "" + string419 + "" + string.charAt(i);
                i425 = 2;
            } else {
                i425--;
                if (!string420.equals("") && !string420.equals("" + string.charAt(i))) {
                    bool422 = true;
                }
                string420 = "" + string.charAt(i);
            }
        if (!bool422) {
            for (final String string2 : strings)
                if (string419.contains(string2)) {
                    bool = true;
                }
        }
        string419 = "";
        string420 = "";
        i = 0;
        i425 = 2;
        for (bool422 = false; i < string.length() && !bool422; i++)
            if (i425 == 0) {
                string419 = "" + string419 + "" + string.charAt(i);
                i425 = 2;
            } else {
                i425--;
                if (!string420.equals("") && !string420.equals("" + string.charAt(i))) {
                    bool422 = true;
                }
                string420 = "" + string.charAt(i);
            }
        if (!bool422) {
            for (final String string2 : strings)
                if (string419.contains(string2)) {
                    bool = true;
                }
        }
        return bool;
    }

    static void multistat(final Control control, final int i, final int i53, final boolean bool, final UDPMistro udpmistro) {
        int i54 = -1;
        if (fase != -2) {
            if (exitm != 0 && !holdit) {
                if (!lan || im != 0) {
                    if (bool)
                        if (i > 357 && i < 396 && i53 > 162 && i53 < 179) {
                            exitm = 2;
                            if (multion == 1 && !lan && sendstat == 0) {
                                sendstat = 1;
                                if (runtyp != -101) {
                                    if (runner != null) {
                                        runner.interrupt();
                                    }
                                    runner = null;
                                    runner = new Thread(xt);
                                    runner.start();
                                }
                            }
                        } else {
                            exitm = 0;
                        }
                    final float[] fs = new float[3];
                    Color.RGBtoHSB(Medium.cgrnd[0], Medium.cgrnd[1], Medium.cgrnd[2], fs);
                    fs[1] -= 0.15;
                    if (fs[1] < 0.0F) {
                        fs[1] = 0.0F;
                    }
                    fs[2] += 0.15;
                    if (fs[2] > 1.0F) {
                        fs[2] = 1.0F;
                    }
                    rd.setColor(Color.getHSBColor(fs[0], fs[1], fs[2]));
                    rd.fillRect(357, 169, 39, 10);
                    rd.fillRect(403, 169, 39, 10);
                    fs[1] -= 0.07;
                    if (fs[1] < 0.0F) {
                        fs[1] = 0.0F;
                    }
                    fs[2] += 0.07;
                    if (fs[2] > 1.0F) {
                        fs[2] = 1.0F;
                    }
                    rd.setColor(Color.getHSBColor(fs[0], fs[1], fs[2]));
                    rd.fillRect(357, 162, 39, 7);
                    rd.fillRect(403, 162, 39, 7);
                    drawhi(exitgame, 116);
                    if (i > 357 && i < 396 && i53 > 162 && i53 < 179) {
                        rd.setColor(new Color(Medium.csky[0], Medium.csky[1], Medium.csky[2]));
                        rd.fillRect(357, 162, 39, 17);
                    }
                    if (i > 403 && i < 442 && i53 > 162 && i53 < 179) {
                        rd.setColor(new Color(Medium.csky[0], Medium.csky[1], Medium.csky[2]));
                        rd.fillRect(403, 162, 39, 17);
                    }
                    rd.setColor(new Color(0, 0, 0));
                    rd.drawString("Yes", 366, 175);
                    rd.drawString("No", 416, 175);
                    rd.setColor(new Color(Medium.csky[0] / 2, Medium.csky[1] / 2, Medium.csky[2] / 2));
                    rd.drawRect(403, 162, 39, 17);
                    rd.drawRect(357, 162, 39, 17);
                } else {
                    rd.setFont(new Font("Arial", 1, 13));
                    ftm = rd.getFontMetrics();
                    drawcs(125, "You cannot exit game.  Your computer is the LAN server!", 0, 0, 0, 0);
                    msgflk[0]++;
                    if (msgflk[0] == 67 || bool) {
                        msgflk[0] = 0;
                        exitm = 0;
                    }
                    rd.setFont(new Font("Arial", 1, 11));
                    ftm = rd.getFontMetrics();
                }
            } else if (exitm == 4) {
                if (bool) {
                    if (i > 357 && i < 396 && i53 > 362 && i53 < 379) {
                        alocked = -1;
                        lalocked = -1;
                        multion = 2;
                        control.multion = multion;
                        holdit = false;
                        exitm = 0;
                        control.chatup = 0;
                    }
                    if ((!lan || im != 0) && i > 403 && i < 442 && i53 > 362 && i53 < 379) {
                        holdcnt = 600;
                        exitm = 0;
                        control.chatup = 0;
                    }
                }
                final float[] fs = new float[3];
                Color.RGBtoHSB(Medium.cgrnd[0], Medium.cgrnd[1], Medium.cgrnd[2], fs);
                fs[1] -= 0.15;
                if (fs[1] < 0.0F) {
                    fs[1] = 0.0F;
                }
                fs[2] += 0.15;
                if (fs[2] > 1.0F) {
                    fs[2] = 1.0F;
                }
                rd.setColor(Color.getHSBColor(fs[0], fs[1], fs[2]));
                rd.fillRect(357, 369, 39, 10);
                if (!lan || im != 0) {
                    rd.fillRect(403, 369, 39, 10);
                }
                fs[1] -= 0.07;
                if (fs[1] < 0.0F) {
                    fs[1] = 0.0F;
                }
                fs[2] += 0.07;
                if (fs[2] > 1.0F) {
                    fs[2] = 1.0F;
                }
                rd.setColor(Color.getHSBColor(fs[0], fs[1], fs[2]));
                rd.fillRect(357, 362, 39, 7);
                if (!lan || im != 0) {
                    rd.fillRect(403, 362, 39, 7);
                }
                rd.setColor(new Color(0, 0, 0));
                rd.setFont(new Font("Arial", 1, 13));
                ftm = rd.getFontMetrics();
                if (lan && im == 0) {
                    drawcs(140, "(You cannot exit game.  Your computer is the LAN server... )", 0, 0, 0, 0);
                }
                rd.drawString("Continue watching this game?", 155, 375);
                if (i > 357 && i < 396 && i53 > 362 && i53 < 379) {
                    rd.setColor(new Color(Medium.csky[0], Medium.csky[1], Medium.csky[2]));
                    rd.fillRect(357, 362, 39, 17);
                }
                if ((!lan || im != 0) && i > 403 && i < 442 && i53 > 362 && i53 < 379) {
                    rd.setColor(new Color(Medium.csky[0], Medium.csky[1], Medium.csky[2]));
                    rd.fillRect(403, 362, 39, 17);
                }
                rd.setFont(new Font("Arial", 1, 11));
                ftm = rd.getFontMetrics();
                rd.setColor(new Color(0, 0, 0));
                rd.drawString("Yes", 366, 375);
                if (!lan || im != 0) {
                    rd.drawString("No", 416, 375);
                }
                rd.setColor(new Color(Medium.csky[0] / 2, Medium.csky[1] / 2, Medium.csky[2] / 2));
                if (!lan || im != 0) {
                    rd.drawRoundRect(147, 357, 301, 27, 7, 20);
                } else {
                    rd.drawRoundRect(147, 357, 262, 27, 7, 20);
                }
                rd.drawRect(357, 362, 39, 17);
                if (!lan || im != 0) {
                    rd.drawRect(403, 362, 39, 17);
                }
            }
            if (runtyp == -101 && !lan) {
                if (warning == 0 || warning == 210) {
                    int i55 = 0;
                    int i56 = 0;
                    if (clanchat) {
                        i55 = 1;
                        i56 = -23;
                    } else if (control.chatup == 2) {
                        control.chatup = 1;
                    }
                    for (int i57 = i55; i57 >= 0; i57--) {
                        boolean bool58 = false;
                        if (i > 5 && i < 33 && i53 > 423 + i56 && i53 < 446 + i56) {
                            bool58 = true;
                            if (control.chatup != 0) {
                                control.chatup = 0;
                            }
                        } else if (pointc[i57] != 6) {
                            pointc[i57] = 6;
                            floater[i57] = 1;
                        }
                        if (i > 33 && i < 666 && i53 > 423 + i56 && i53 < 446 + i56 && lxm != i && i53 != lym && lxm != -100) {
                            control.chatup = i57 + 1;
                            cntchatp[i57] = 0;
                        }
                        if (i57 == 0) {
                            lxm = i;
                            lym = i53;
                        }
                        if (exitm != 0 && exitm != 4) {
                            control.chatup = 0;
                        }
                        boolean bool59 = false;
                        if (control.enter && control.chatup == i57 + 1) {
                            bool59 = true;
                            control.chatup = 0;
                            control.enter = false;
                            lxm = -100;
                        }
                        if (bool) {
                            if (mouson == 0) {
                                if (i > 676 && i < 785 && i53 > 426 + i56 && i53 < 443 + i56 && control.chatup == i57 + 1) {
                                    bool59 = true;
                                    control.chatup = 0;
                                }
                                if (bool58 && pointc[i57] > 0) {
                                    pointc[i57]--;
                                    floater[i57] = 1;
                                }
                                if (i57 == 0) {
                                    mouson = 1;
                                }
                            }
                            if (i57 == 0) {
                                control.chatup = 0;
                            }
                        } else if (i57 == 0 && mouson != 0) {
                            mouson = 0;
                        }
                        if (bool59) {
                            String string = "";
                            int i60 = 0;
                            int i61 = 1;
                            for (; i60 < lcmsg[i57].length(); i60++) {
                                final String string62 = "" + lcmsg[i57].charAt(i60);
                                if (string62.equals(" ")) {
                                    i61++;
                                } else {
                                    i61 = 0;
                                }
                                if (i61 < 2) {
                                    string = "" + string + string62;
                                }
                            }
                            if (!string.equals("")) {
                                string = string.replace('|', ':');
                                if (string.toLowerCase().contains(GameSparker.tpass.getText().toLowerCase())) {
                                    string = " ";
                                }
                                if (!msgcheck(string) && updatec[i57] > -12) {
                                    if (cnames[i57][6].equals("Game Chat  ") || cnames[i57][6].equals("" + clan + "'s Chat  ")) {
                                        cnames[i57][6] = "";
                                    }
                                    for (int i63 = 0; i63 < 6; i63++) {
                                        sentn[i57][i63] = sentn[i57][i63 + 1];
                                        cnames[i57][i63] = cnames[i57][i63 + 1];
                                    }
                                    sentn[i57][6] = string;
                                    cnames[i57][6] = nickname;
                                    if (pointc[i57] != 6) {
                                        pointc[i57] = 6;
                                        floater[i57] = 1;
                                    }
                                    msgflk[i57] = 110;
                                    if (updatec[i57] > -11) {
                                        updatec[i57] = -11;
                                    } else {
                                        updatec[i57]--;
                                    }
                                } else {
                                    warning++;
                                }
                            }
                        }
                        if (bool58 || floater[i57] != 0 || control.chatup == i57 + 1 || msgflk[i57] != 0) {
                            final float[] fs = new float[3];
                            Color.RGBtoHSB(Medium.cgrnd[0], Medium.cgrnd[1], Medium.cgrnd[2], fs);
                            fs[1] -= 0.15;
                            if (fs[1] < 0.0F) {
                                fs[1] = 0.0F;
                            }
                            fs[2] += 0.15;
                            if (fs[2] > 1.0F) {
                                fs[2] = 1.0F;
                            }
                            rd.setColor(Color.getHSBColor(fs[0], fs[1], fs[2]));
                            rd.fillRect(33, 423 + i56, 761, 23);
                        }
                        if (control.chatup == 0 && GameSparker.cmsg.isShowing()) {
                            GameSparker.cmsg.setVisible(false);
                            app.requestFocus();
                        }
                        if (control.chatup != i57 + 1) {
                            int i64 = 0;
                            int i65 = (int) (48.0F + 48.0F * (Medium.snap[1] / 100.0F));
                            if (i65 > 255) {
                                i65 = 255;
                            }
                            if (i65 < 0) {
                                i65 = 0;
                            }
                            int i66 = (int) (96.0F + 96.0F * (Medium.snap[2] / 100.0F));
                            if (i66 > 255) {
                                i66 = 255;
                            }
                            if (i66 < 0) {
                                i66 = 0;
                            }
                            if (floater[i57] != 0) {
                                for (int i67 = 6; i67 >= 0; i67--) {
                                    if (pointc[i57] == i67)
                                        if (Math.abs(i64 + movepos[i57]) > 10) {
                                            floater[i57] = (movepos[i57] + i64) / 4;
                                            if (floater[i57] > -5 && floater[i57] < 0) {
                                                floater[i57] = -5;
                                            }
                                            if (floater[i57] < 10 && floater[i57] > 0) {
                                                floater[i57] = 10;
                                            }
                                            movepos[i57] -= floater[i57];
                                        } else {
                                            movepos[i57] = -i64;
                                            floater[i57] = 0;
                                        }
                                    if (pointc[i57] >= i67) {
                                        rd.setColor(new Color(0, i65, i66));
                                        rd.setFont(new Font("Tahoma", 1, 11));
                                        ftm = rd.getFontMetrics();
                                        rd.drawString("" + cnames[i57][i67] + ": ", 39 + i64 + movepos[i57], 439 + i56);
                                        i64 += ftm.stringWidth("" + cnames[i57][i67] + ": ");
                                        rd.setColor(new Color(0, 0, 0));
                                        rd.setFont(new Font("Tahoma", 0, 11));
                                        ftm = rd.getFontMetrics();
                                        rd.drawString("" + sentn[i57][i67] + "   ", 39 + i64 + movepos[i57], 439 + i56);
                                        i64 += ftm.stringWidth("" + sentn[i57][i67] + "   ");
                                    } else {
                                        i64 += ftm.stringWidth("" + cnames[i57][i67] + ": ");
                                        i64 += ftm.stringWidth("" + sentn[i57][i67] + "   ");
                                    }
                                }
                                rd.setColor(new Color(0, 0, 0));
                                rd.fillRect(0, 423 + i56, 5, 24);
                                rd.fillRect(794, 423 + i56, 6, 24);
                            } else {
                                for (int i68 = pointc[i57]; i68 >= 0; i68--) {
                                    if (i68 == 6 && msgflk[i57] != 0) {
                                        msgflk[i57]--;
                                    }
                                    rd.setColor(new Color(0, i65, i66));
                                    rd.setFont(new Font("Tahoma", 1, 11));
                                    ftm = rd.getFontMetrics();
                                    if (ftm.stringWidth("" + cnames[i57][i68] + ": ") + 39 + i64 < 775) {
                                        if (i68 != 6 || msgflk[i57] < 67 || msgflk[i57] % 3 != 0) {
                                            rd.drawString("" + cnames[i57][i68] + ": ", 39 + i64, 439 + i56);
                                        }
                                        i64 += ftm.stringWidth("" + cnames[i57][i68] + ": ");
                                    } else {
                                        String string = "";
                                        for (int i69 = 0; ftm.stringWidth(string) + 39 + i64 < 775 && i69 < cnames[i57][i68].length(); i69++) {
                                            string = "" + string + cnames[i57][i68].charAt(i69);
                                        }
                                        string = "" + string + "...";
                                        if (i68 != 6 || msgflk[i57] < 67 || msgflk[i57] % 3 != 0) {
                                            rd.drawString(string, 39 + i64, 439 + i56);
                                        }
                                        break;
                                    }
                                    rd.setColor(new Color(0, 0, 0));
                                    rd.setFont(new Font("Tahoma", 0, 11));
                                    ftm = rd.getFontMetrics();
                                    if (ftm.stringWidth(sentn[i57][i68]) + 39 + i64 < 775) {
                                        if (i68 != 6 || msgflk[i57] < 67 || msgflk[i57] % 3 != 0) {
                                            rd.drawString("" + sentn[i57][i68] + "   ", 39 + i64, 439 + i56);
                                        }
                                        i64 += ftm.stringWidth("" + sentn[i57][i68] + "   ");
                                    } else {
                                        String string = "";
                                        for (int i70 = 0; ftm.stringWidth(string) + 39 + i64 < 775 && i70 < sentn[i57][i68].length(); i70++) {
                                            string = "" + string + sentn[i57][i68].charAt(i70);
                                        }
                                        string = "" + string + "...";
                                        if (i68 != 6 || msgflk[i57] < 67 || msgflk[i57] % 3 != 0) {
                                            rd.drawString(string, 39 + i64, 439 + i56);
                                        }
                                        break;
                                    }
                                }
                            }
                        } else {
                            msgflk[i57] = 0;
                            i54 = i57;
                        }
                        if (bool58 || floater[i57] != 0) {
                            final float[] fs = new float[3];
                            Color.RGBtoHSB(Medium.cgrnd[0], Medium.cgrnd[1], Medium.cgrnd[2], fs);
                            fs[1] -= 0.076;
                            if (fs[1] < 0.0F) {
                                fs[1] = 0.0F;
                            }
                            fs[2] += 0.076;
                            if (fs[2] > 1.0F) {
                                fs[2] = 1.0F;
                            }
                            rd.setColor(Color.getHSBColor(fs[0], fs[1], fs[2]));
                            rd.fillRect(5, 423 + i56, 28, 23);
                        }
                        if (bool58) {
                            rd.setColor(new Color(0, 0, 0));
                        } else {
                            rd.setColor(new Color((int) (Medium.cgrnd[0] / 2.0F), (int) (Medium.cgrnd[1] / 2.0F), (int) (Medium.cgrnd[2] / 2.0F)));
                        }
                        rd.setFont(new Font("Tahoma", 1, 11));
                        rd.drawString("<<", 10, 439 + i56);
                        rd.setColor(new Color(0, 0, 0));
                        rd.drawRect(5, 423 + i56, 789, 23);
                        rd.drawLine(33, 423 + i56, 33, 446 + i56);
                        i56 += 23;
                    }
                    if (i > 775 && i < 794 && i53 > 409 - i55 * 23 && i53 < 423 - i55 * 23) {
                        rd.drawRect(775, 409 - i55 * 23, 19, 14);
                        rd.setColor(new Color(200, 0, 0));
                        if (bool) {
                            control.chatup = 0;
                            if (GameSparker.cmsg.isShowing()) {
                                GameSparker.cmsg.setVisible(false);
                                app.requestFocus();
                            }
                            runtyp = 0;
                            try {
                                socket.close();
                                socket = null;
                                din.close();
                                din = null;
                                dout.close();
                                dout = null;
                            } catch (final Exception ignored) {

                            }
                        }
                    }
                    rd.setFont(new Font("Arial", 1, 12));
                    rd.drawString("x", 782, 420 - i55 * 23);
                } else {
                    drawWarning();
                    if (GameSparker.cmsg.isShowing()) {
                        GameSparker.cmsg.setVisible(false);
                        app.requestFocus();
                    }
                    warning++;
                }
                rd.setFont(new Font("Arial", 1, 11));
                ftm = rd.getFontMetrics();
            } else if (control.chatup != 0) {
                control.chatup = 0;
                if (!lan) {
                    runtyp = -101;
                    if (runner != null) {
                        runner.interrupt();
                    }
                    runner = null;
                    runner = new Thread(xt);
                    runner.start();
                }
            }
            if (holdit && multion == 1 && !lan && sendstat == 0) {
                sendstat = 1;
                if (runtyp != -101) {
                    if (runner != null) {
                        runner.interrupt();
                    }
                    runner = null;
                    runner = new Thread(xt);
                    runner.start();
                }
            }
            if (control.arrace && starcnt < 38 && !holdit && CheckPoints.stage != 10 || multion >= 2) {
                if (alocked != -1 && CheckPoints.dested[alocked] != 0) {
                    alocked = -1;
                    lalocked = -1;
                }
                if (multion >= 2) {
                    if (alocked == -1 || holdit) {
                        if (cntflock == 100) {
                            for (int i71 = 0; i71 < nplayers; i71++)
                                if (holdit) {
                                    if (CheckPoints.pos[i71] == 0) {
                                        alocked = i71;
                                        im = i71;
                                    }
                                } else if (CheckPoints.dested[i71] == 0) {
                                    alocked = i71;
                                    im = i71;
                                }
                        }
                        cntflock++;
                    } else {
                        cntflock = 0;
                    }
                    if (lan) {
                        boolean bool72 = true;
                        for (int i73 = 0; i73 < nplayers; i73++)
                            if (dested[i73] == 0 && !plnames[i73].contains("MadBot")) {
                                bool72 = false;
                            }
                        if (bool72) {
                            exitm = 2;
                        }
                    }
                }
                final int i74 = nplayers;
                for (int i75 = 0; i75 < i74; i75++) {
                    boolean bool76 = false;
                    for (int i77 = 0; i77 < nplayers; i77++)
                        if (CheckPoints.pos[i77] == i75 && CheckPoints.dested[i77] == 0 && !bool76) {
                            int i81 = (int) (100.0F + 100.0F * (Medium.snap[2] / 100.0F));
                            if (i81 > 255) {
                                i81 = 255;
                            }
                            if (i81 < 0) {
                                i81 = 0;
                            }
                            rd.setColor(new Color(0, 0, i81));
                            if (i75 == 0) {
                                rd.drawString("1st", 673, 76 + 30 * i75);
                            }
                            if (i75 == 1) {
                                rd.drawString("2nd", 671, 76 + 30 * i75);
                            }
                            if (i75 == 2) {
                                rd.drawString("3rd", 671, 76 + 30 * i75);
                            }
                            if (i75 >= 3) {
                                rd.drawString("" + (i75 + 1) + "th", 671, 76 + 30 * i75);
                            }
                            if (clangame != 0) {
                                int i82;
                                int i83;
                                if (pclan[i77].equalsIgnoreCase(gaclan)) {
                                    i82 = 255;
                                    i83 = 128;
                                    i81 = 0;
                                } else {
                                    i82 = 0;
                                    i83 = 128;
                                    i81 = 255;
                                }
                                i82 += i82 * (Medium.snap[0] / 100.0F);
                                if (i82 > 255) {
                                    i82 = 255;
                                }
                                if (i82 < 0) {
                                    i82 = 0;
                                }
                                i83 += i83 * (Medium.snap[1] / 100.0F);
                                if (i83 > 255) {
                                    i83 = 255;
                                }
                                if (i83 < 0) {
                                    i83 = 0;
                                }
                                i81 += i81 * (Medium.snap[2] / 100.0F);
                                if (i81 > 255) {
                                    i81 = 255;
                                }
                                if (i81 < 0) {
                                    i81 = 0;
                                }
                                rd.setColor(new Color(i82, i83, i81));
                                rd.drawString(plnames[i77], 731 - ftm.stringWidth(plnames[i77]) / 2, 70 + 30 * i75);
                            }
                            rd.setColor(new Color(0, 0, 0));
                            rd.drawString(plnames[i77], 730 - ftm.stringWidth(plnames[i77]) / 2, 70 + 30 * i75);
                            final int i84 = (int) (60.0F * CheckPoints.magperc[i77]);
                            int i85 = 244;
                            int i86 = 244;
                            i81 = 11;
                            if (i84 > 20) {
                                i86 = (int) (244.0F - 233.0F * ((i84 - 20) / 40.0F));
                            }
                            i85 += i85 * (Medium.snap[0] / 100.0F);
                            if (i85 > 255) {
                                i85 = 255;
                            }
                            if (i85 < 0) {
                                i85 = 0;
                            }
                            i86 += i86 * (Medium.snap[1] / 100.0F);
                            if (i86 > 255) {
                                i86 = 255;
                            }
                            if (i86 < 0) {
                                i86 = 0;
                            }
                            i81 += i81 * (Medium.snap[2] / 100.0F);
                            if (i81 > 255) {
                                i81 = 255;
                            }
                            if (i81 < 0) {
                                i81 = 0;
                            }
                            rd.setColor(new Color(i85, i86, i81));
                            rd.fillRect(700, 74 + 30 * i75, i84, 5);
                            rd.setColor(new Color(0, 0, 0));
                            rd.drawRect(700, 74 + 30 * i75, 60, 5);
                            boolean bool87 = false;
                            if ((im != i77 || multion >= 2) && i > 661 && i < 775 && i53 > 58 + 30 * i75 && i53 < 83 + 30 * i75) {
                                bool87 = true;
                                if (bool) {
                                    if (!onlock)
                                        if (alocked != i77 || multion >= 2) {
                                            alocked = i77;
                                            if (multion >= 2) {
                                                im = i77;
                                            }
                                        } else {
                                            alocked = -1;
                                        }
                                    onlock = true;
                                } else if (onlock) {
                                    onlock = false;
                                }
                            }
                            if (alocked == i77) {
                                i85 = (int) (159.0F + 159.0F * (Medium.snap[0] / 100.0F));
                                if (i85 > 255) {
                                    i85 = 255;
                                }
                                if (i85 < 0) {
                                    i85 = 0;
                                }
                                i86 = (int) (207.0F + 207.0F * (Medium.snap[1] / 100.0F));
                                if (i86 > 255) {
                                    i86 = 255;
                                }
                                if (i86 < 0) {
                                    i86 = 0;
                                }
                                i81 = (int) (255.0F + 255.0F * (Medium.snap[2] / 100.0F));
                                if (i81 > 255) {
                                    i81 = 255;
                                }
                                if (i81 < 0) {
                                    i81 = 0;
                                }
                                rd.setColor(new Color(i85, i86, i81));
                                rd.drawRect(661, 58 + 30 * i75, 114, 25);
                                rd.drawRect(662, 59 + 30 * i75, 112, 23);
                            }
                            if (bool87 && !onlock) {
                                if (alocked == i77) {
                                    i85 = (int) (120.0F + 120.0F * (Medium.snap[0] / 100.0F));
                                    if (i85 > 255) {
                                        i85 = 255;
                                    }
                                    if (i85 < 0) {
                                        i85 = 0;
                                    }
                                    i86 = (int) (114.0F + 114.0F * (Medium.snap[1] / 100.0F));
                                    if (i86 > 255) {
                                        i86 = 255;
                                    }
                                    if (i86 < 0) {
                                        i86 = 0;
                                    }
                                    i81 = (int) (255.0F + 255.0F * (Medium.snap[2] / 100.0F));
                                    if (i81 > 255) {
                                        i81 = 255;
                                    }
                                    if (i81 < 0) {
                                        i81 = 0;
                                    }
                                } else {
                                    i85 = (int) (140.0F + 140.0F * (Medium.snap[0] / 100.0F));
                                    if (i85 > 255) {
                                        i85 = 255;
                                    }
                                    if (i85 < 0) {
                                        i85 = 0;
                                    }
                                    i86 = (int) (160.0F + 160.0F * (Medium.snap[1] / 100.0F));
                                    if (i86 > 255) {
                                        i86 = 255;
                                    }
                                    if (i86 < 0) {
                                        i86 = 0;
                                    }
                                    i81 = (int) (255.0F + 255.0F * (Medium.snap[2] / 100.0F));
                                    if (i81 > 255) {
                                        i81 = 255;
                                    }
                                    if (i81 < 0) {
                                        i81 = 0;
                                    }
                                }
                                rd.setColor(new Color(i85, i86, i81));
                                rd.drawRect(660, 57 + 30 * i75, 116, 27);
                            }
                            bool76 = true;
                        }
                }
            }
            if (udpmistro.go && udpmistro.runon == 1 && !holdit) {
                int i88 = 0;
                int i89 = 0;
                for (int i90 = 0; i90 < nplayers; i90++)
                    if (i90 != udpmistro.im) {
                        i89++;
                        if (udpmistro.lframe[i90] == udpmistro.lcframe[i90] || udpmistro.force[i90] == 7) {
                            i88++;
                        } else {
                            udpmistro.lcframe[i90] = udpmistro.lframe[i90];
                        }
                    }
                if (i88 == i89) {
                    discon++;
                } else if (discon != 0) {
                    discon = 0;
                }
                if (discon == 240) {
                    udpmistro.runon = 2;
                }
            }
        }
        if (i54 != -1) {
            final float[] fs = new float[3];
            Color.RGBtoHSB(Medium.cgrnd[0], Medium.cgrnd[1], Medium.cgrnd[2], fs);
            fs[1] -= 0.22;
            if (fs[1] < 0.0F) {
                fs[1] = 0.0F;
            }
            fs[2] += 0.22;
            if (fs[2] > 1.0F) {
                fs[2] = 1.0F;
            }
            final Color color = Color.getHSBColor(fs[0], fs[1], fs[2]);
            rd.setColor(color);
            rd.fillRect(676, 426 - i54 * 23, 109, 7);
            rd.setColor(new Color(0, 0, 0));
            rd.setFont(new Font("Tahoma", 1, 11));
            rd.drawString("Send Message  >", 684, 439 - i54 * 23);
            rd.setColor(new Color((int) (Medium.cgrnd[0] / 1.2F), (int) (Medium.cgrnd[1] / 1.2F), (int) (Medium.cgrnd[2] / 1.2F)));
            rd.drawRect(676, 426 - i54 * 23, 109, 17);
            if (!GameSparker.cmsg.isShowing()) {
                GameSparker.cmsg.setVisible(true);
                GameSparker.cmsg.requestFocus();
                lcmsg[i54] = "";
                GameSparker.cmsg.setText("");
                GameSparker.cmsg.setBackground(color);
            }
            GameSparker.movefield(GameSparker.cmsg, 34, 424 - i54 * 23, 633, 22);
            if (GameSparker.cmsg.getText().equals(lcmsg[i54])) {
                cntchatp[i54]++;
            } else {
                cntchatp[i54] = -200;
            }
            lcmsg[i54] = "" + GameSparker.cmsg.getText();
            if (cntchatp[i54] == 67) {
                control.chatup = 0;
            }
            if (GameSparker.cmsg.getText().length() > 100) {
                GameSparker.cmsg.setText(GameSparker.cmsg.getText().substring(0, 100));
                GameSparker.cmsg.select(100, 100);
            }
            rd.setFont(new Font("Arial", 1, 11));
            ftm = rd.getFontMetrics();
        }
    }

    static void musicomp(final int i, final Control control) {
        hipnoload(i, true);
        if (multion != 0) {
            forstart--;
            if (lan && im == 0) {
                forstart = 0;
            }
        }
        if (control.handb || control.enter || forstart == 0) {
            System.gc();
            Medium.trk = 0;
            Medium.crs = false;
            Medium.ih = 0;
            Medium.iw = 0;
            Medium.h = 450;
            Medium.w = 800;
            Medium.focusPoint = 400;
            Medium.cx = 400;
            Medium.cy = 225;
            Medium.cz = 50;
            rd.setRenderingHint(RenderingHints.KEY_TEXT_ANTIALIASING, RenderingHints.VALUE_TEXT_ANTIALIAS_OFF);
            rd.setRenderingHint(RenderingHints.KEY_ANTIALIASING, RenderingHints.VALUE_ANTIALIAS_OFF);
            if (multion == 0) {
                fase = 0;
            } else {
                fase = 7001;
                forstart = 0;
                if (!lan) {
                    try {
                        socket = new Socket(server, servport);
                        din = new BufferedReader(new InputStreamReader(socket.getInputStream()));
                        dout = new PrintWriter(socket.getOutputStream(), true);
                        runtyp = -101;
                        runner = new Thread(xt);
                        runner.start();
                    } catch (final Exception ignored) {

                    }
                }
            }
            if (ThreadLocalRandom.current().nextDouble() > ThreadLocalRandom.current().nextDouble()) {
                dudo = 250;
            } else {
                dudo = 428;
            }
            control.handb = false;
            control.enter = false;
        }
    }

    static public void nofocus() {
        rd.setColor(new Color(255, 255, 255));
        rd.fillRect(0, 0, 800, 20);
        rd.fillRect(0, 0, 20, 450);
        rd.fillRect(0, 430, 800, 20);
        rd.fillRect(780, 0, 20, 450);
        rd.setColor(new Color(192, 192, 192));
        rd.drawRect(20, 20, 760, 410);
        rd.setColor(new Color(0, 0, 0));
        rd.drawRect(22, 22, 756, 406);
        rd.setFont(new Font("Arial", 1, 11));
        ftm = rd.getFontMetrics();
        drawcs(14, "Game lost its focus.   Click screen with mouse to continue.", 100, 100, 100, 3);
        drawcs(445, "Game lost its focus.   Click screen with mouse to continue.", 100, 100, 100, 3);
    }

    static private boolean over(final Image image, final int i, final int i294, final int i295, final int i296) {
        final int i297 = image.getHeight(null);
        final int i298 = image.getWidth(null);
        return i > i295 - 5 && i < i295 + i298 + 5 && i294 > i296 - 5 && i294 < i296 + i297 + 5;
    }

    static private boolean overon(final int i, final int i289, final int i290, final int i291, final int i292, final int i293) {
        return i292 > i && i292 < i + i290 && i293 > i289 && i293 < i289 + i291;
    }

    static void pausedgame(final Control control) {
        if (!badmac) {
            rd.drawImage(fleximg, 0, 0, null);
        } else {
            rd.setColor(new Color(30, 67, 110));
            rd.fillRect(281, 8, 237, 188);
        }
        if (control.up) {
            opselect--;
            if (opselect == -1) {
                opselect = 3;
            }
            control.up = false;
        }
        if (control.down) {
            opselect++;
            if (opselect == 4) {
                opselect = 0;
            }
            control.down = false;
        }
        if (opselect == 0) {
            rd.setColor(new Color(64, 143, 223));
            rd.fillRoundRect(329, 45, 137, 22, 7, 20);
            if (shaded) {
                rd.setColor(new Color(225, 200, 255));
            } else {
                rd.setColor(new Color(0, 89, 223));
            }
            rd.drawRoundRect(329, 45, 137, 22, 7, 20);
        }
        if (opselect == 1) {
            rd.setColor(new Color(64, 143, 223));
            rd.fillRoundRect(320, 73, 155, 22, 7, 20);
            if (shaded) {
                rd.setColor(new Color(225, 200, 255));
            } else {
                rd.setColor(new Color(0, 89, 223));
            }
            rd.drawRoundRect(320, 73, 155, 22, 7, 20);
        }
        if (opselect == 2) {
            rd.setColor(new Color(64, 143, 223));
            rd.fillRoundRect(303, 99, 190, 22, 7, 20);
            if (shaded) {
                rd.setColor(new Color(225, 200, 255));
            } else {
                rd.setColor(new Color(0, 89, 223));
            }
            rd.drawRoundRect(303, 99, 190, 22, 7, 20);
        }
        if (opselect == 3) {
            rd.setColor(new Color(64, 143, 223));
            rd.fillRoundRect(341, 125, 109, 22, 7, 20);
            if (shaded) {
                rd.setColor(new Color(225, 200, 255));
            } else {
                rd.setColor(new Color(0, 89, 223));
            }
            rd.drawRoundRect(341, 125, 109, 22, 7, 20);
        }
        rd.drawImage(paused, 281, 8, null);
        if (control.enter || control.handb) {
            if (opselect == 0) {
                if (loadedt && !mutem) {
                    strack.setPaused(false);
                }
                fase = 0;
            }
            if (opselect == 1)
                if (Record.caught >= 300) {
                    if (loadedt && !mutem) {
                        strack.setPaused(false);
                    }
                    fase = -1;
                } else {
                    fase = -8;
                }
            if (opselect == 2) {
                if (loadedt) {
                    strack.setPaused(true);
                }
                oldfase = -7;
                fase = 11;
            }
            if (opselect == 3) {
                if (loadedt) {
                    strack.unload();
                }
                fase = 102;
                if (gmode == 0) {
                    opselect = 3;
                }
                //if (gmode == 1)
                //	opselect = 0;
                if (gmode == 2) {
                    opselect = 1;
                }
                rd.setRenderingHint(RenderingHints.KEY_TEXT_ANTIALIASING, RenderingHints.VALUE_TEXT_ANTIALIAS_ON);
                rd.setRenderingHint(RenderingHints.KEY_ANTIALIASING, RenderingHints.VALUE_ANTIALIAS_ON);
            }
            control.enter = false;
            control.handb = false;
        }
    }

    static void pauseimage(final Image image) {
        if (!badmac) {
            final int[] is = new int[360000];
            final PixelGrabber pixelgrabber = new PixelGrabber(image, 0, 0, 800, 450, is, 0, 800);
            try {
                pixelgrabber.grabPixels();
            } catch (final InterruptedException ignored) {

            }
            int i = 0;
            int i343 = 0;
            int i344 = 0;
            int i345 = 0;
            for (int i346 = 0; i346 < 360000; i346++) {
                final Color color = new Color(is[i346]);
                int i347;
                if (i345 == 0) {
                    i347 = (color.getRed() + color.getGreen() + color.getBlue()) / 3;
                    i344 = i347;
                } else {
                    i347 = (color.getRed() + color.getGreen() + color.getBlue() + i344 * 30) / 33;
                    i344 = i347;
                }
                if (++i345 == 800) {
                    i345 = 0;
                }
                if (i346 > 800 * (8 + i343) + 281 && i343 < 188) {
                    final int i348 = (i347 + 60) / 3;
                    final int i349 = (i347 + 135) / 3;
                    final int i350 = (i347 + 220) / 3;
                    if (++i == 237) {
                        i343++;
                        i = 0;
                    }
                    final Color color351 = new Color(i348, i349, i350);
                    is[i346] = color351.getRGB();
                } else {
                    final Color color352 = new Color(i347, i347, i347);
                    is[i346] = color352.getRGB();
                }
            }
            fleximg = xt.createImage(new MemoryImageSource(800, 450, is, 0, 800));
            rd.drawImage(fleximg, 0, 0, null);
        } else {
            rd.setColor(new Color(0, 0, 0));
            rd.setComposite(AlphaComposite.getInstance(3, 0.5F));
            rd.fillRect(0, 0, 800, 450);
            rd.setComposite(AlphaComposite.getInstance(3, 1.0F));
        }
    }

    static private void pingstat() {
        final int i = (int) (100.0 * ThreadLocalRandom.current().nextDouble());
        try {
            final URL url = new URL("http://c.statcounter.com/9994681/0/14bb645e/1/?reco=" + i + "");
            url.openConnection().setConnectTimeout(5000);
            final Image image = Toolkit.getDefaultToolkit().createImage(url);
            final MediaTracker mediatracker = new MediaTracker(app);
            mediatracker.addImage(image, 0);
            mediatracker.waitForID(0);
            mediatracker.removeImage(image, 0);
        } catch (final Exception ignored) {

        }
    }

    static void playsounds(int im, final Mad mad, final Control control, final ContO player, final ContO conto) {
        SoundClip.source = conto;
        SoundClip.player = player;
        
        if ((fase == 0 || fase == 7001) && starcnt < 35 && cntwis[im] != 8 && !mutes) {
            boolean bool = control.up && mad.speed > 0.0F || control.down && mad.speed < 10.0F;
            boolean bool257 = mad.skid == 1 && control.handb || Math.abs(mad.scz[0] - (mad.scz[1] + mad.scz[0] + mad.scz[2] + mad.scz[3]) / 4.0F) > 1.0F || Math.abs(mad.scx[0] - (mad.scx[1] + mad.scx[0] + mad.scx[2] + mad.scx[3]) / 4.0F) > 1.0F;
            boolean bool258 = false;
            if (control.up && mad.speed < 10.0F) {
                bool257 = true;
                bool = true;
                bool258 = true;
            }
            if (bool && mad.mtouch) {
                if (!mad.capsized) {
                    if (!bool257) {
                        if (mad.power != 98.0F) {
                            if (Math.abs(mad.speed) > 0.0F && Math.abs(mad.speed) <= CarDefine.swits[mad.cn][0]) {
                                int i259 = (int) (3.0F * Math.abs(mad.speed) / CarDefine.swits[mad.cn][0]);
                                if (i259 == 2) {
                                    if (pwait[im] == 0) {
                                        i259 = 0;
                                    } else {
                                        pwait[im]--;
                                    }
                                } else {
                                    pwait[im] = 7;
                                }
                                sparkeng(i259, mad.cn);
                            }
                            if (Math.abs(mad.speed) > CarDefine.swits[mad.cn][0] && Math.abs(mad.speed) <= CarDefine.swits[mad.cn][1]) {
                                int i260 = (int) (3.0F * (Math.abs(mad.speed) - CarDefine.swits[mad.cn][0]) / (CarDefine.swits[mad.cn][1] - CarDefine.swits[mad.cn][0]));
                                if (i260 == 2) {
                                    if (pwait[im] == 0) {
                                        i260 = 0;
                                    } else {
                                        pwait[im]--;
                                    }
                                } else {
                                    pwait[im] = 7;
                                }
                                sparkeng(i260, mad.cn);
                            }
                            if (Math.abs(mad.speed) > CarDefine.swits[mad.cn][1] && Math.abs(mad.speed) <= CarDefine.swits[mad.cn][2]) {
                                final int i261 = (int) (3.0F * (Math.abs(mad.speed) - CarDefine.swits[mad.cn][1]) / (CarDefine.swits[mad.cn][2] - CarDefine.swits[mad.cn][1]));
                                sparkeng(i261, mad.cn);
                            }
                        } else {
                            int i262 = 2;
                            if (pwait[im] == 0) {
                                if (Math.abs(mad.speed) > CarDefine.swits[mad.cn][1]) {
                                    i262 = 3;
                                }
                            } else {
                                pwait[im]--;
                            }
                            sparkeng(i262, mad.cn);
                        }
                    } else {
                        sparkeng(-1, mad.cn);
                        if (bool258) {
                            if (stopcnt[im] <= 0) {
                                air[5].loop();
                                stopcnt[im] = 10;
                            }
                        } else if (stopcnt[im] <= -2) {
                            air[2 + (int) (Medium.random() * 3.0F)].loop();
                            stopcnt[im] = 7;
                        }
                    }
                } else {
                    sparkeng(3, mad.cn);
                }
                grrd[im] = false;
                aird [im]= false;
            } else {
                pwait[im] = 15;
                if (!mad.mtouch && !grrd[im] && Medium.random() > 0.4) {
                    air[(int) (Medium.random() * 4.0F)].loop();
                    stopcnt[im] = 5;
                    grrd [im]= true;
                }
                if (!mad.wtouch && !aird[im]) {
                    stopairs();
                    air[(int) (Medium.random() * 4.0F)].loop();
                    stopcnt[im] = 10;
                    aird [im]= true;
                }
                sparkeng(-1, mad.cn);
            }
            if (mad.cntdest != 0 && cntwis[im] < 7) {
                if (!pwastd[im]) {
                    wastd.loop();
                    pwastd[im] = true;
                }
            } else {
                if (pwastd[im]) {
                    wastd.stop();
                    pwastd[im] = false;
                }
                if (cntwis[im] == 7 && !mutes) {
                    firewasted.play();
                }
            }
        } else {
            sparkeng(-2, mad.cn);
            if (pwastd[im]) {
                wastd.stop();
                pwastd [im]= false;
            }
        }
        if (stopcnt[im] != -20) {
            if (stopcnt[im] == 1) {
                stopairs();
            }
            stopcnt[im]--;
        }
        if (bfcrash[im] != 0) {
            bfcrash[im]--;
        }
        if (bfscrape[im] != 0) {
            bfscrape[im]--;
        }
        if (bfsc1[im] != 0) {
            bfsc1[im]--;
        }
        if (bfsc2[im] != 0) {
            bfsc2[im]--;
        }
        if (bfskid[im] != 0) {
            bfskid[im]--;
        }
        if (mad.newcar) {
            cntwis[im] = 0;
        }
        if (fase == 0 || fase == 7001 || fase == 6 || fase == -1 || fase == -2 || fase == -3 || fase == -4 || fase == -5) {
            if (mutes != control.mutes) {
                mutes = control.mutes;
            }
            if (control.mutem != mutem) {
                mutem = control.mutem;
                if (mutem) {
                    if (loadedt) {
                        strack.setPaused(true);
                    }
                } else if (loadedt) {
                    strack.setPaused(false);
                }
            }
        }
        if (mad.cntdest != 0 && cntwis[im] < 7) {
            if (mad.dest) {
                cntwis[im]++;
            }
        } else {
            if (mad.cntdest == 0) {
                cntwis[im] = 0;
            }
            if (cntwis[im] == 7) {
                cntwis[im] = 8;
            }
        }
        if (GameSparker.applejava) {
            closesounds();
        }
    }

    static private Image pressed(final Image image) {
        final int i = image.getHeight(null);
        final int i337 = image.getWidth(null);
        final int[] is = new int[i337 * i];
        final PixelGrabber pixelgrabber = new PixelGrabber(image, 0, 0, i337, i, is, 0, i337);
        try {
            pixelgrabber.grabPixels();
        } catch (final InterruptedException ignored) {

        }
        for (int i338 = 0; i338 < i337 * i; i338++)
            if (is[i338] != is[i337 * i - 1]) {
                is[i338] = -16777216;
            }
        return xt.createImage(new MemoryImageSource(i337, i, is, 0, i337));
    }

    static private int py(final int i, final int i281, final int i282, final int i283) {
        return (i - i281) * (i - i281) + (i282 - i283) * (i282 - i283);
    }

    static private float pys(final int i, final int i284, final int i285, final int i286) {
        return (float) Math.sqrt((i - i284) * (i - i284) + (i285 - i286) * (i285 - i286));
    }

    static void rad(final int i) {
        if (i == 0) {
            powerup.play();
            radpx = 212;
            pin = 0;
        }
        trackbg(false);
        rd.setColor(new Color(0, 0, 0));
        rd.fillRect(65, 135, 670, 59);
        if (pin != 0) {
            rd.drawImage(radicalplay, radpx + (int) (8.0 * ThreadLocalRandom.current().nextDouble() - 4.0), 135, null);
        } else {
            rd.drawImage(radicalplay, 212, 135, null);
        }
        if (radpx != 212) {
            radpx += 40;
            if (radpx > 735) {
                radpx = -388;
            }
        } else if (pin != 0) {
            pin--;
        }
        if (i == 40) {
            radpx = 213;
            pin = 7;
        }
        if (radpx == 212) {
            rd.setFont(new Font("Arial", 1, 11));
            ftm = rd.getFontMetrics();
            drawcs(185 + (int) (5.0F * Medium.random()), "Radicalplay.com", 112, 120, 143, 3);
        }
        rd.setFont(new Font("Arial", 1, 11));
        ftm = rd.getFontMetrics();
        if (aflk) {
            drawcs(215, "And we are never going to find the new unless we get a little crazy...", 112, 120, 143, 3);
            aflk = false;
        } else {
            drawcs(217, "And we are never going to find the new unless we get a little crazy...", 150, 150, 150, 3);
            aflk = true;
        }
        rd.drawImage(rpro, 275, 265, null);
        rd.setColor(new Color(0, 0, 0));
        rd.fillRect(0, 0, 65, 450);
        rd.fillRect(735, 0, 65, 450);
        rd.fillRect(65, 0, 670, 25);
        rd.fillRect(65, 425, 670, 25);
    }

    static private void radarstat(final Mad mad, final ContO conto) {
        rd.setComposite(AlphaComposite.getInstance(3, 0.5F));
        rd.setColor(new Color(Medium.csky[0], Medium.csky[1], Medium.csky[2]));
        rd.fillRoundRect(10, 55, 172, 172, 30, 30);
        rd.setComposite(AlphaComposite.getInstance(3, 1.0F));
        rd.setRenderingHint(RenderingHints.KEY_ANTIALIASING, RenderingHints.VALUE_ANTIALIAS_ON);
        rd.setColor(new Color(Medium.csky[0] / 2, Medium.csky[1] / 2, Medium.csky[2] / 2));
        for (int i = 0; i < CheckPoints.n; i++) {
            int i241 = i + 1;
            if (i == CheckPoints.n - 1) {
                i241 = 0;
            }
            boolean bool = false;
            if (CheckPoints.typ[i241] == -3) {
                i241 = 0;
                bool = true;
            }
            final int[] is = {
                    (int) (96.0F - (CheckPoints.opx[im] - CheckPoints.x[i]) / CheckPoints.prox),
                    (int) (96.0F - (CheckPoints.opx[im] - CheckPoints.x[i241]) / CheckPoints.prox)
            };
            final int[] is242 = {
                    (int) (141.0F - (CheckPoints.z[i] - CheckPoints.opz[im]) / CheckPoints.prox),
                    (int) (141.0F - (CheckPoints.z[i241] - CheckPoints.opz[im]) / CheckPoints.prox)
            };
            rot(is, is242, 96, 141, mad.cxz, 2);
            rd.drawLine(is[0], is242[0], is[1], is242[1]);
            if (bool) {
                break;
            }
        }
        if (arrace || multion > 1) {
            final int[] is = new int[nplayers];
            final int[] is245 = new int[nplayers];
            for (int i = 0; i < nplayers; i++) {
                is[i] = (int) (96.0F - (CheckPoints.opx[im] - CheckPoints.opx[i]) / CheckPoints.prox);
                is245[i] = (int) (141.0F - (CheckPoints.opz[i] - CheckPoints.opz[im]) / CheckPoints.prox);
            }
            rot(is, is245, 96, 141, mad.cxz, nplayers);
            int i = 0;
            int i246 = (int) (80.0F + 80.0F * (Medium.snap[1] / 100.0F));
            if (i246 > 255) {
                i246 = 255;
            }
            if (i246 < 0) {
                i246 = 0;
            }
            int i247 = (int) (159.0F + 159.0F * (Medium.snap[2] / 100.0F));
            if (i247 > 255) {
                i247 = 255;
            }
            if (i247 < 0) {
                i247 = 0;
            }
            for (int i248 = 0; i248 < nplayers; i248++)
                if (i248 != im && CheckPoints.dested[i248] == 0) {
                    if (clangame != 0) {
                        if (pclan[i248].equalsIgnoreCase(gaclan)) {
                            i = 159;
                            i246 = 80;
                            i247 = 0;
                        } else {
                            i = 0;
                            i246 = 80;
                            i247 = 159;
                        }
                        i += i * (Medium.snap[0] / 100.0F);
                        if (i > 255) {
                            i = 255;
                        }
                        if (i < 0) {
                            i = 0;
                        }
                        i246 += i246 * (Medium.snap[1] / 100.0F);
                        if (i246 > 255) {
                            i246 = 255;
                        }
                        if (i246 < 0) {
                            i246 = 0;
                        }
                        i247 += i247 * (Medium.snap[2] / 100.0F);
                        if (i247 > 255) {
                            i247 = 255;
                        }
                        if (i247 < 0) {
                            i247 = 0;
                        }
                    }
                    int i249 = 2;
                    if (alocked == i248) {
                        i249 = 3;
                        rd.setColor(new Color(i, i246, i247));
                    } else {
                        rd.setColor(new Color((i + Medium.csky[0]) / 2, (Medium.csky[1] + i246) / 2, (i247 + Medium.csky[2]) / 2));
                    }
                    rd.drawLine(is[i248] - i249, is245[i248], is[i248] + i249, is245[i248]);
                    rd.drawLine(is[i248], is245[i248] + i249, is[i248], is245[i248] - i249);
                    rd.setColor(new Color(i, i246, i247));
                    rd.fillRect(is[i248] - 1, is245[i248] - 1, 3, 3);
                }
        }
        int i = (int) (159.0F + 159.0F * (Medium.snap[0] / 100.0F));
        if (i > 255) {
            i = 255;
        }
        if (i < 0) {
            i = 0;
        }
        int i250 = 0;
        int i251 = 0;
        if (clangame != 0) {
            if (pclan[im].equalsIgnoreCase(gaclan)) {
                i = 159;
                i250 = 80;
                i251 = 0;
            } else {
                i = 0;
                i250 = 80;
                i251 = 159;
            }
            i += i * (Medium.snap[0] / 100.0F);
            if (i > 255) {
                i = 255;
            }
            if (i < 0) {
                i = 0;
            }
            i250 += i250 * (Medium.snap[1] / 100.0F);
            if (i250 > 255) {
                i250 = 255;
            }
            if (i250 < 0) {
                i250 = 0;
            }
            i251 += i251 * (Medium.snap[2] / 100.0F);
            if (i251 > 255) {
                i251 = 255;
            }
            if (i251 < 0) {
                i251 = 0;
            }
        }
        rd.setColor(new Color((i + Medium.csky[0]) / 2, (Medium.csky[1] + i250) / 2, (i251 + Medium.csky[2]) / 2));
        rd.drawLine(96, 139, 96, 143);
        rd.drawLine(94, 141, 98, 141);
        rd.setColor(new Color(i, i250, i251));
        rd.fillRect(95, 140, 3, 3);
        rd.setRenderingHint(RenderingHints.KEY_ANTIALIASING, RenderingHints.VALUE_ANTIALIAS_OFF);
        if (Medium.darksky) {
            Color color = new Color(Medium.csky[0], Medium.csky[1], Medium.csky[2]);
            final float[] fs = new float[3];
            Color.RGBtoHSB(Medium.csky[0], Medium.csky[1], Medium.csky[2], fs);
            fs[2] = 0.6F;
            color = Color.getHSBColor(fs[0], fs[1], fs[2]);
            rd.setColor(color);
            rd.fillRect(5, 232, 181, 17);
            rd.drawLine(4, 233, 4, 247);
            rd.drawLine(3, 235, 3, 245);
            rd.drawLine(186, 233, 186, 247);
            rd.drawLine(187, 235, 187, 245);
        }
        rd.drawImage(sped, 7, 234, null);
        final int i252 = conto.x - lcarx;
        lcarx = conto.x;
        final int i254 = conto.z - lcarz;
        lcarz = conto.z;
        final float f = (float) Math.sqrt(i252 * i252 + i254 * i254);
        final float f255 = f * 1.4F * 21.0F * 60.0F * 60.0F / 100000.0F;
        final float f256 = f255 * 0.621371F;
        rd.setColor(new Color(0, 0, 100));
        rd.drawString("" + (int) f255, 62, 245);
        rd.drawString("" + (int) f256, 132, 245);
    }

    static void replyn() {
        if (aflk) {
            drawcs(30, "Replay  > ", 0, 0, 0, 0);
            aflk = false;
        } else {
            drawcs(30, "Replay  >>", 0, 128, 255, 0);
            aflk = true;
        }
    }

    static void resetstat(final int i) {
        arrace = false;
        alocked = -1;
        lalocked = -1;
        cntflock = 90;
        onlock = false;
        ana = 0;
        cntan = 0;
        cntovn = 0;
        tcnt = 30;
        wasay = false;
        clear = 0;
        dmcnt = 0;
        pwcnt = 0;
        auscnt = 45;
        pnext = 0;
        pback = 0;
        starcnt = 130;
        gocnt = 3;
        for (int im = 0; im < 8; im++) {
            grrd[im] = true;
            aird[im] = true;
            bfcrash[im] = 0;
            bfscrape[im] = 0;
            cntwis[im] = 0;
            bfskid[im] = 0;
            pwait[im] = 7;
        }
        forstart = 200;
        exitm = 0;
        holdcnt = 0;
        holdit = false;
        winner = false;
        for (int i20 = 0; i20 < 8; i20++) {
            dested[i20] = 0;
            isbot[i20] = false;
            dcrashes[i20] = 0;
        }
        runtyp = 0;
        discon = 0;
        dnload = 0;
        beststunt = 0;
        laptime = 0;
        fastestlap = 0;
        sendstat = 0;
        if (fase == 2 || fase == -22) {
            sortcars(i);
        }
        if (fase == 22) {
            for (int i21 = 0; i21 < 2; i21++) {
                for (int i22 = 0; i22 < 7; i22++) {
                    cnames[i21][i22] = "";
                    sentn[i21][i22] = "";
                }
                if (i21 == 0) {
                    cnames[i21][6] = "Game Chat  ";
                } else {
                    cnames[i21][6] = "" + clan + "'s Chat  ";
                }
                updatec[i21] = -1;
                movepos[i21] = 0;
                pointc[i21] = 6;
                floater[i21] = 0;
                cntchatp[i21] = 0;
                msgflk[i21] = 0;
                lcmsg[i21] = "";
            }
            if (multion == 3) {
                ransay = 4;
            } else if (ransay == 0) {
                ransay = 1 + (int) (ThreadLocalRandom.current().nextDouble() * 3.0);
            } else {
                ransay++;
                if (ransay > 3) {
                    ransay = 1;
                }
            }
        }
    }

    static private void rot(final int[] is, final int[] is272, final int i, final int i273, final int i274, final int i275) {
        if (i274 != 0) {
            for (int i276 = 0; i276 < i275; i276++) {
                final int i277 = is[i276];
                final int i278 = is272[i276];
                is[i276] = i + (int) ((i277 - i) * Medium.cos(i274) - (i278 - i273) * Medium.sin(i274));
                is272[i276] = i273 + (int) ((i277 - i) * Medium.sin(i274) + (i278 - i273) * Medium.cos(i274));
            }
        }
    }

    @Override
    public void run() {
        if (!Thread.currentThread().isInterrupted()) {
            boolean bool = false;
            while (runtyp > 0) {
                if (runtyp >= 1 && runtyp <= 140) {
                    hipnoload(runtyp, false);
                }
                //if (runtyp == 176) {
                //    loading();
                //    bool = true;
                //}
                //app.repaint();
                try {
                    if (runner != null) {

                    }
                    Thread.sleep(20L);
                } catch (final InterruptedException ignored) {

                }
            }
            if (bool) {
                pingstat();
            }
            final boolean[] bools = {
                    true, true
            };
            while ((runtyp == -101 || sendstat == 1) && !lan) {
                String string = "3|" + playingame + "|" + updatec[0] + "|";
                if (clanchat) {
                    string = "" + string + "" + updatec[1] + "|" + clan + "|" + clankey + "|";
                } else {
                    string = "" + string + "0|||";
                }
                if (updatec[0] <= -11) {
                    for (int i = 0; i < -updatec[0] - 10; i++) {
                        string = "" + string + "" + cnames[0][6 - i] + "|" + sentn[0][6 - i] + "|";
                    }
                    updatec[0] = -2;
                }
                if (clanchat && updatec[1] <= -11) {
                    for (int i = 0; i < -updatec[1] - 10; i++) {
                        string = "" + string + "" + cnames[1][6 - i] + "|" + sentn[1][6 - i] + "|";
                    }
                    updatec[1] = -2;
                }
                if (sendstat == 1) {
                    string = "5|" + playingame + "|" + im + "|" + beststunt + "|" + fastestlap + "|";
                    for (int i = 0; i < nplayers; i++) {
                        string = "" + string + "" + dcrashes[i] + "|";
                    }
                    sendstat = 2;
                }
                boolean bool13 = false;
                String string14 = "";
                try {
                    dout.println(string);
                    string14 = din.readLine();
                    if (string14 == null) {
                        bool13 = true;
                    }
                } catch (final Exception exception) {
                    bool13 = true;
                }
                if (bool13) {
                    try {
                        socket.close();
                        socket = null;
                        din.close();
                        din = null;
                        dout.close();
                        dout = null;
                    } catch (final Exception ignored) {

                    }
                    try {
                        socket = new Socket(server, servport);
                        din = new BufferedReader(new InputStreamReader(socket.getInputStream()));
                        dout = new PrintWriter(socket.getOutputStream(), true);
                        dout.println(string);
                        string14 = din.readLine();
                        if (string14 != null) {
                            bool13 = false;
                        }
                    } catch (final Exception ignored) {

                    }
                }
                if (bool13) {
                    try {
                        socket.close();
                        socket = null;
                    } catch (final Exception ignored) {

                    }
                    runtyp = 0;
                    if (GameSparker.cmsg.isShowing()) {
                        GameSparker.cmsg.setVisible(false);
                        app.requestFocus();
                    }
                    runner.interrupt();
                    runner = null;
                }
                if (sendstat != 2) {
                    int i = 2;
                    int i15 = 1;
                    if (clanchat) {
                        i15 = 2;
                    }
                    for (int i16 = 0; i16 < i15; i16++) {
                        final int i17 = getvalue(string14, i16);
                        if (updatec[i16] != i17 && updatec[i16] >= -2 && pointc[i16] == 6) {
                            for (int i18 = 0; i18 < 7; i18++) {
                                cnames[i16][i18] = getSvalue(string14, i);
                                i++;
                                sentn[i16][i18] = getSvalue(string14, i);
                                i++;
                            }
                            if (cnames[i16][6].equals(""))
                                if (i16 == 0) {
                                    cnames[i16][6] = "Game Chat  ";
                                } else {
                                    cnames[i16][6] = "" + clan + "'s Chat  ";
                                }
                            if (updatec[i16] != -2) {
                                floater[i16] = 1;
                                if (bools[i16]) {
                                    msgflk[i16] = 67;
                                    bools[i16] = false;
                                } else {
                                    msgflk[i16] = 110;
                                }
                            }
                            updatec[i16] = i17;
                        }
                    }
                } else {
                    sendstat = 3;
                }
                try {
                    if (runner != null) {

                    }
                    Thread.sleep(1000L);
                } catch (final InterruptedException ignored) {

                }
            }
            if (runtyp == -167 || runtyp == -168) {
                try {
                    socket = new Socket("multiplayer.needformadness.com", 7061);
                    din = new BufferedReader(new InputStreamReader(socket.getInputStream()));
                    dout = new PrintWriter(socket.getOutputStream(), true);
                    dout.println("101|" + (runtyp + 174) + "|" + GameSparker.tnick.getText() + "|" + GameSparker.tpass.getText() + "|");
                    din.readLine();
                    socket.close();
                    socket = null;
                    din.close();
                    din = null;
                    dout.close();
                    dout = null;
                } catch (final Exception ignored) {

                }
                runtyp = 0;
            }
            if (runtyp == -166 || runtyp == -167 || runtyp == -168) {
                pingstat();
            }
        }
    }

    static void scrape(int im, final int i, final int i266, final int i267) {
        if (bfscrape[im] == 0 && Math.sqrt(i * i + i266 * i266 + i267 * i267) / 10.0 > 10.0) {
            int i268 = 0;
            if (Medium.random() > Medium.random()) {
                i268 = 1;
            }
            if (i268 == 0) {
                sturn1 = 0;
                sturn0++;
                if (sturn0 == 3) {
                    i268 = 1;
                    sturn1 = 1;
                    sturn0 = 0;
                }
            } else {
                sturn0 = 0;
                sturn1++;
                if (sturn1 == 3) {
                    i268 = 0;
                    sturn0 = 1;
                    sturn1 = 0;
                }
            }
            if (!mutes) {
                scrape[i268].play();
            }
            bfscrape[im] = 5;
        }
    }

    static void sendwin() {
        if (logged && multion == 1 && winner) {
            if (CheckPoints.wasted == nplayers - 1) {
                runtyp = -167;
            } else {
                runtyp = -168;
            }
        } else {
            runtyp = -166;
        }
        runner = new Thread(xt);
        runner.start();
    }

    static void setbots(final boolean[] bools) {
        for (int i = 0; i < nplayers; i++)
            if (plnames[i].contains("MadBot")) {
                bools[i] = true;
                isbot[i] = true;
            }
    }

    static void skid(int im, final int i, final float f) {
        if (bfcrash[im] == 0 && bfskid[im] == 0 && f > 150.0F) {
            if (i == 0) {
                if (!mutes) {
                    skid[skflg].play();
                }
                if (skidup) {
                    skflg++;
                } else {
                    skflg--;
                }
                if (skflg == 3) {
                    skflg = 0;
                }
                if (skflg == -1) {
                    skflg = 2;
                }
            } else {
                if (!mutes) {
                    dustskid[dskflg].play();
                }
                if (skidup) {
                    dskflg++;
                } else {
                    dskflg--;
                }
                if (dskflg == 3) {
                    dskflg = 0;
                }
                if (dskflg == -1) {
                    dskflg = 2;
                }
            }
            bfskid[im] = 35;
        }
    }

    static private void smokeypix(final byte[] is, final MediaTracker mediatracker, final Toolkit toolkit) {
        final Image image = toolkit.createImage(is);
        mediatracker.addImage(image, 0);
        try {
            mediatracker.waitForID(0);
        } catch (final Exception ignored) {

        }
        final PixelGrabber pixelgrabber = new PixelGrabber(image, 0, 0, 466, 202, smokey, 0, 466);
        try {
            pixelgrabber.grabPixels();
        } catch (final InterruptedException ignored) {

        }
        for (int i = 0; i < 94132; i++)
            if (smokey[i] != smokey[0]) {
                final Color color = new Color(smokey[i]);
                final float[] fs = new float[3];
                Color.RGBtoHSB(color.getRed(), color.getGreen(), color.getBlue(), fs);
                fs[0] = 0.11F;
                fs[1] = 0.45F;
                final Color color385 = Color.getHSBColor(fs[0], fs[1], fs[2]);
                smokey[i] = color385.getRGB();
            }
    }

    static void snap(final int i) {
        dmg = loadsnap(odmg);
        pwr = loadsnap(opwr);
        was = loadsnap(owas);
        lap = loadsnap(olap);
        pos = loadsnap(opos);
        sped = loadsnap(osped);
        for (int i287 = 0; i287 < 8; i287++) {
            rank[i287] = loadsnap(orank[i287]);
        }
        for (int i288 = 0; i288 < 4; i288++) {
            cntdn[i288] = loadsnap(ocntdn[i288]);
        }
        if (multion != 0) {
            wgame = loadsnap(owgame);
            exitgame = loadsnap(oexitgame);
            gamefinished = loadsnap(ogamefinished);
            disco = loadsnap(odisco);
        }
        yourwasted = loadsnap(oyourwasted);
        youlost = loadsnap(oyoulost);
        youwon = loadsnap(oyouwon);
        youwastedem = loadsnap(oyouwastedem);
        gameh = loadsnap(ogameh);
        loadingmusic = loadopsnap(oloadingmusic, i, 76);
        star[0] = loadopsnap(ostar[0], i, 0);
        star[1] = loadopsnap(ostar[1], i, 0);
        flaot = loadopsnap(oflaot, i, 1);
    }

    static private void sortcars(final int i) {
        if (i != 0) {
            int lastcar = nplayers;

            // get boss car if player is not in the mad party, since that one has no boss car (you play as dr monstaa)
            if (sc[0] != 7 + (i + 1) / 2 && i != nTracks) {
                sc[6] = 7 + (i + 1) / 2;
                if (sc[6] >= nCars) {
                    sc[6] = nCars - 1; // you could put -= 5 or something here
                }
                lastcar--; //boss car won't be randomized
            }

            // DEBUG: Prints the range of possible cars to the console
            //System.out.println("Minimum car: " + stat.names[(i - 1) / 2] + ", maximum car: " + stat.names[nplayers + ((i - 1) / 2)] + ", therefore: " + (((i - 1) / 2) - (nplayers + ((i - 1) / 2))) + " car difference");

            // create a list of car ids, each item completely unique
            final ArrayList<Integer> list = new ArrayList<>();
            for (int k = (i - 1) / 2; k < nplayers + (i - 1) / 2; k++) {
                if (k == sc[0]) {
                    continue;
                }
                list.add(k);
            }

            // randomize the order of this list (shuffle it like a deck of cards)
            Collections.shuffle(list);

            // which item of the list should be picked
            int k = 0;

            for (int j = 1; j < lastcar; j++) {

                // get an item from the "deck" - this can be any item as long as it's unique
                sc[j] = list.get(k);
                k++;

                // if there are more cars than tracks, reduce the car index number until it fits.
                // unfortunately i have no idea how to make this work properly so we'll just have to ignore the duplicates here
                while (sc[j] >= nCars) {
                    System.out.println("Car " + j + " is out of bounds");
                    sc[j] -= ThreadLocalRandom.current().nextDouble() * 5F;
                }
                System.out.println("sc of " + j + " is " + sc[j]);
            }
        }
        // this error will never be thrown in a deployment environment
        // it is only here for extra safety
        for (int j = 0; j < nplayers; j++) {
            if (sc[j] > nCars)
                throw new Error("there are too many tracks and not enough cars");
        }
    }

    static private void sparkeng(int i, final int i263) {
        if (lcn != i263) {
            for (int i264 = 0; i264 < 5; i264++)
                if (pengs[i264]) {
                    engs[CarDefine.enginsignature[lcn]][i264].stop();
                    pengs[i264] = false;
                }
            lcn = i263;
        }
        i++;
        for (int i265 = 0; i265 < 5; i265++)
            if (i == i265) {
                if (!pengs[i265]) {
                    engs[CarDefine.enginsignature[i263]][i265].loop();
                    pengs[i265] = true;
                }
            } else if (pengs[i265]) {
                engs[CarDefine.enginsignature[i263]][i265].stop();
                pengs[i265] = false;
            }
    }

    static void stageselect(final Control control, final int i, final int i39, final boolean bool) {
        rd.drawImage(br, 65, 25, null);
        rd.drawImage(select, 338, 35, null);
        if (testdrive != 3 && testdrive != 4) {
            if (CheckPoints.stage > 0 && CarDefine.staction == 0) {
                if (CheckPoints.stage != 1 && CheckPoints.stage != 11) {
                    rd.drawImage(back[pback], 115, 135, null);
                }
                if (CheckPoints.stage != nTracks) {
                    rd.drawImage(next[pnext], 625, 135, null);
                }
            }
            if (gmode == 0) {
                boolean bool40 = false;
                int i41 = 0;
                if (nfmtab != GameSparker.sgame.getSelectedIndex()) {
                    nfmtab = GameSparker.sgame.getSelectedIndex();
                    //app.snfm1.select(0);
                    //app.snfm2.select(0);
                    GameSparker.mstgs.select(0);
                    app.requestFocus();
                    bool40 = true;
                }
                if (CarDefine.staction == 5) {
                    if (lfrom == 0) {
                        CarDefine.staction = 0;
                        removeds = 1;
                        bool40 = true;
                    } else {
                        CarDefine.onstage = CheckPoints.name;
                        CarDefine.staction = 2;
                        dnload = 2;
                    }
                    nickname = GameSparker.tnick.getText();
                    backlog = nickname;
                    nickey = CarDefine.tnickey;
                    clan = CarDefine.tclan;
                    clankey = CarDefine.tclankey;
                    GameSparker.setloggedcookie();
                    logged = true;
                    gotlog = true;
                    if (CarDefine.reco == 0) {
                        acexp = 0;
                    }
                    if (CarDefine.reco > 10) {
                        acexp = CarDefine.reco - 10;
                    }
                    if (CarDefine.reco == 3) {
                        acexp = -1;
                    }
                    if (CarDefine.reco == 111)
                        if (!backlog.equalsIgnoreCase(nickname)) {
                            acexp = -3;
                        } else {
                            acexp = 0;
                        }
                }
                if (nfmtab == 2 && CarDefine.staction == 0 && removeds == 1) {
                    CheckPoints.stage = -3;
                }
                if (GameSparker.openm && CarDefine.staction == 3) {
                    GameSparker.tnick.setVisible(false);
                    GameSparker.tpass.setVisible(false);
                    CarDefine.staction = 0;
                }
                int i42 = 0;
                GameSparker.sgame.setSize(131);
                //if (app.sgame.getSelectedIndex() == 0)
                //	i42 = 400 - (app.sgame.getWidth() + 6 + app.snfm1.getWidth()) / 2;
                //if (app.sgame.getSelectedIndex() == 1)
                //	i42 = 400 - (app.sgame.getWidth() + 6 + app.snfm2.getWidth()) / 2;
                if (GameSparker.sgame.getSelectedIndex() == 2) {
                    GameSparker.mstgs.setSize(338);
                    if (bool40)
                        if (logged) {
                            if (CarDefine.msloaded != 1) {
                                GameSparker.mstgs.removeAll();
                                GameSparker.mstgs.add(rd, "Loading your stages now, please wait...");
                                GameSparker.mstgs.select(0);
                                i41 = 1;
                            }
                        } else {
                            GameSparker.mstgs.removeAll();
                            GameSparker.mstgs.add(rd, "Please login first to load your stages...");
                            GameSparker.mstgs.select(0);
                            CarDefine.msloaded = 0;
                            lfrom = 0;
                            CarDefine.staction = 3;
                            showtf = false;
                            tcnt = 0;
                            cntflock = 0;
                            CarDefine.reco = -2;
                        }
                    i42 = 400 - (GameSparker.sgame.getWidth() + 6 + GameSparker.mstgs.getWidth()) / 2;
                }
                if (GameSparker.sgame.getSelectedIndex() == 3) {
                    GameSparker.mstgs.setSize(338);
                    if (bool40 && CarDefine.msloaded != 3) {
                        GameSparker.mstgs.removeAll();
                        GameSparker.mstgs.add(rd, "Loading Top20 list, please wait...");
                        GameSparker.mstgs.select(0);
                        i41 = 3;
                    }
                    i42 = 400 - (GameSparker.sgame.getWidth() + 6 + GameSparker.mstgs.getWidth()) / 2;
                }
                if (GameSparker.sgame.getSelectedIndex() == 4) {
                    GameSparker.mstgs.setSize(338);
                    if (bool40 && CarDefine.msloaded != 4) {
                        GameSparker.mstgs.removeAll();
                        GameSparker.mstgs.add(rd, "Loading Top20 list, please wait...");
                        GameSparker.mstgs.select(0);
                        i41 = 4;
                    }
                    i42 = 400 - (GameSparker.sgame.getWidth() + 6 + GameSparker.mstgs.getWidth()) / 2;
                }
                if (GameSparker.sgame.getSelectedIndex() == 5) {
                    if (CarDefine.staction != 0) {
                        GameSparker.tnick.setVisible(false);
                        GameSparker.tpass.setVisible(false);
                        CarDefine.staction = 0;
                    }
                    GameSparker.mstgs.setSize(338);
                    if (bool40 && CarDefine.msloaded != 2) {
                        GameSparker.mstgs.removeAll();
                        GameSparker.mstgs.add(rd, "Loading Stage Maker stages, please wait...");
                        GameSparker.mstgs.select(0);
                        i41 = 2;
                    }
                    i42 = 400 - (GameSparker.sgame.getWidth() + 6 + GameSparker.mstgs.getWidth()) / 2;
                }
                if (!GameSparker.sgame.isShowing()) {
                    GameSparker.sgame.setVisible(true);
                }
                GameSparker.sgame.move(i42, 62);
                /*if (nfmtab == 0) {
                	if (!app.snfm1.isShowing()) {
                		app.snfm1.setVisible(true);
                		if (!bool40 && checkpoints.stage > 0)
                			app.snfm1.select(checkpoints.stage);
                	}
                	app.snfm1.move(i42, 62);
                	if (app.snfm2.isShowing())
                		app.snfm2.setVisible(false);
                	if (app.mstgs.isShowing())
                		app.mstgs.setVisible(false);
                }*/
                //if (nfmtab == 1) {
                /*if (!app.snfm2.isShowing()) {
                	app.snfm2.setVisible(true);
                	if (!bool40 && checkpoints.stage > 10)
                		app.snfm2.select(checkpoints.stage - 10);
                }
                app.snfm2.move(i42, 62);
                if (app.snfm1.isShowing())
                	app.snfm1.setVisible(false);
                if (app.mstgs.isShowing())
                	app.mstgs.setVisible(false);*/
                //}
                /*if (nfmtab == 2 || nfmtab == 3 || nfmtab == 4 || nfmtab == 5) {
                	if (!app.mstgs.isShowing()) {
                		app.mstgs.setVisible(true);
                		if (!bool40)
                			app.mstgs.select(checkpoints.name);
                	}
                	app.mstgs.move(i42, 62);
                	if (app.snfm1.isShowing())
                		app.snfm1.setVisible(false);
                	if (app.snfm2.isShowing())
                		app.snfm2.setVisible(false);
                }*/
                rd.setFont(new Font("Arial", 1, 13));
                ftm = rd.getFontMetrics();
                if (CarDefine.staction == 0 || CarDefine.staction == 6)
                    if (CheckPoints.stage != -3) {
                        String string = "";
                        if (CheckPoints.top20 >= 3) {
                            string = "N#" + CheckPoints.nto + "  ";
                        }
                        if (aflk) {
                            drawcs(132, "" + string + CheckPoints.name, 240, 240, 240, 3);
                            aflk = false;
                        } else {
                            drawcs(132, "" + string + CheckPoints.name, 176, 176, 176, 3);
                            aflk = true;
                        }
                        if (CheckPoints.stage == -2 && CarDefine.staction == 0) {
                            rd.setFont(new Font("Arial", 1, 11));
                            ftm = rd.getFontMetrics();
                            rd.setColor(new Color(255, 176, 85));
                            if (CheckPoints.maker.equals(nickname)) {
                                rd.drawString("Created by You", 70, 115);
                            } else {
                                rd.drawString("Created by :  " + CheckPoints.maker + "", 70, 115);
                            }
                            if (CheckPoints.top20 >= 3) {
                                rd.drawString("Added by :  " + CarDefine.top20adds[CheckPoints.nto - 1] + " Players", 70, 135);
                            }
                        }
                    } else if (removeds != 1) {
                        rd.setFont(new Font("Arial", 1, 13));
                        ftm = rd.getFontMetrics();
                        drawcs(132, "Failed to load stage...", 255, 138, 0, 3);
                        rd.setFont(new Font("Arial", 1, 11));
                        ftm = rd.getFontMetrics();
                        if (nfmtab == 5) {
                            drawcs(155, "Please Test Drive this stage in the Stage Maker to make sure it can be loaded!", 255, 138, 0, 3);
                        }
                        if (nfmtab == 2 || nfmtab == 3 || nfmtab == 4) {
                            drawcs(155, "It could be a connection error, please try again later.", 255, 138, 0, 3);
                        }
                        if (nfmtab == 1 || nfmtab == 0) {
                            drawcs(155, "Will try to load another stage...", 255, 138, 0, 3);
                            //app.repaint();
                            try {
                                Thread.sleep(5000L);
                            } catch (final InterruptedException ignored) {

                            }
                            //if (nfmtab == 0)
                            //	app.snfm1.select(1 + (int) (ThreadLocalRandom.current().nextDouble() * 10.0));
                            //if (nfmtab == 1)
                            //	app.snfm2.select(1 + (int) (ThreadLocalRandom.current().nextDouble() * 17.0));
                        }
                    }
                if (CarDefine.staction == 3) {
                    drawdprom(145, 170);
                    if (CarDefine.reco == -2)
                        if (lfrom == 0) {
                            drawcs(171, "Login to Retrieve your Account Stages", 0, 0, 0, 3);
                        } else {
                            drawcs(171, "Login to add this stage to your account.", 0, 0, 0, 3);
                        }
                    if (CarDefine.reco == -1) {
                        drawcs(171, "Unable to connect to server, try again later!", 0, 8, 0, 3);
                    }
                    if (CarDefine.reco == 1) {
                        drawcs(171, "Sorry.  The Nickname you have entered is incorrect.", 0, 0, 0, 3);
                    }
                    if (CarDefine.reco == 2) {
                        drawcs(171, "Sorry.  The Password you have entered is incorrect.", 0, 0, 0, 3);
                    }
                    if (CarDefine.reco == -167 || CarDefine.reco == -177) {
                        if (CarDefine.reco == -167) {
                            nickname = GameSparker.tnick.getText();
                            backlog = nickname;
                            CarDefine.reco = -177;
                        }
                        drawcs(171, "You are currently using a trial account.", 0, 0, 0, 3);
                    }
                    if (CarDefine.reco == -3 && (tcnt % 3 != 0 || tcnt > 20)) {
                        drawcs(171, "Please enter your Nickname!", 0, 0, 0, 3);
                    }
                    if (CarDefine.reco == -4 && (tcnt % 3 != 0 || tcnt > 20)) {
                        drawcs(171, "Please enter your Password!", 0, 0, 0, 3);
                    }
                    if (!showtf) {
                        GameSparker.tnick.setBackground(new Color(206, 237, 255));
                        if (CarDefine.reco != 1) {
                            if (CarDefine.reco != 2) {
                                GameSparker.tnick.setText(nickname);
                            }
                            GameSparker.tnick.setForeground(new Color(0, 0, 0));
                        } else {
                            GameSparker.tnick.setForeground(new Color(255, 0, 0));
                        }
                        GameSparker.tnick.requestFocus();
                        GameSparker.tpass.setBackground(new Color(206, 237, 255));
                        if (CarDefine.reco != 2) {
                            if (!autolog) {
                                GameSparker.tpass.setText("");
                            }
                            GameSparker.tpass.setForeground(new Color(0, 0, 0));
                        } else {
                            GameSparker.tpass.setForeground(new Color(255, 0, 0));
                        }
                        if (!GameSparker.tnick.getText().equals("") && CarDefine.reco != 1) {
                            GameSparker.tpass.requestFocus();
                        }
                        showtf = true;
                    }
                    rd.drawString("Nickname:", 376 - ftm.stringWidth("Nickname:") - 14, 201);
                    rd.drawString("Password:", 376 - ftm.stringWidth("Password:") - 14, 231);
                    GameSparker.movefieldd(GameSparker.tnick, 376, 185, 129, 23, true);
                    GameSparker.movefieldd(GameSparker.tpass, 376, 215, 129, 23, true);
                    if (tcnt < 30) {
                        tcnt++;
                        if (tcnt == 30) {
                            if (CarDefine.reco == 2) {
                                GameSparker.tpass.setText("");
                            }
                            GameSparker.tnick.setForeground(new Color(0, 0, 0));
                            GameSparker.tpass.setForeground(new Color(0, 0, 0));
                        }
                    }
                    if (CarDefine.reco != -177) {
                        if ((drawcarb(true, null, "       Login       ", 347, 247, i, i39, bool) || control.handb || control.enter) && tcnt > 5) {
                            tcnt = 0;
                            if (!GameSparker.tnick.getText().equals("") && !GameSparker.tpass.getText().equals("")) {
                                autolog = false;
                                GameSparker.tnick.setVisible(false);
                                GameSparker.tpass.setVisible(false);
                                app.requestFocus();
                                CarDefine.staction = 4;
                                CarDefine.sparkstageaction();
                            } else {
                                if (GameSparker.tpass.getText().equals("")) {
                                    CarDefine.reco = -4;
                                }
                                if (GameSparker.tnick.getText().equals("")) {
                                    CarDefine.reco = -3;
                                }
                            }
                        }
                    } else if (drawcarb(true, null, "  Upgrade to have your own stages!  ", 277, 247, i, i39, bool) && cntflock == 0) {
                        GameSparker.editlink(nickname, true);
                        cntflock = 100;
                    }
                    if (drawcarb(true, null, "  Cancel  ", 409, 282, i, i39, bool)) {
                        GameSparker.tnick.setVisible(false);
                        GameSparker.tpass.setVisible(false);
                        app.requestFocus();
                        CarDefine.staction = 0;
                    }
                    if (drawcarb(true, null, "  Register!  ", 316, 282, i, i39, bool)) {
                        if (cntflock == 0) {
                            GameSparker.reglink();
                            cntflock = 100;
                        }
                    } else if (cntflock != 0) {
                        cntflock--;
                    }
                }
                if (CarDefine.staction == 4) {
                    drawdprom(145, 170);
                    drawcs(195, "Logging in to your account...", 0, 0, 0, 3);
                }
                if (CheckPoints.stage == -2 && CarDefine.msloaded == 1 && CheckPoints.top20 < 3 && !GameSparker.openm && drawcarb(true, null, "X", 609, 113, i, i39, bool)) {
                    CarDefine.staction = 6;
                }
                if (CarDefine.staction == -1 && CheckPoints.top20 < 3) {
                    removeds = 0;
                    drawdprom(145, 95);
                    drawcs(175, "Failed to remove stage from your account, try again later.", 0, 0, 0, 3);
                    if (drawcarb(true, null, " OK ", 379, 195, i, i39, bool)) {
                        CarDefine.staction = 0;
                    }
                }
                if (CarDefine.staction == 1) {
                    drawdprom(145, 95);
                    drawcs(195, "Removing stage from your account...", 0, 0, 0, 3);
                    removeds = 1;
                }
                if (CarDefine.staction == 6) {
                    drawdprom(145, 95);
                    drawcs(175, "Remove this stage from your account?", 0, 0, 0, 3);
                    if (drawcarb(true, null, " Yes ", 354, 195, i, i39, bool)) {
                        CarDefine.onstage = GameSparker.mstgs.getSelectedItem();
                        CarDefine.staction = 1;
                        CarDefine.sparkstageaction();
                    }
                    if (drawcarb(true, null, " No ", 408, 195, i, i39, bool)) {
                        CarDefine.staction = 0;
                    }
                }
                if (i41 == 1) {
                    GameSparker.drawms();
                    //app.repaint();
                    CarDefine.loadmystages();
                }
                if (i41 >= 3) {
                    GameSparker.drawms();
                    //app.repaint();
                    CarDefine.loadtop20(i41);
                }
                if (i41 == 2) {
                    GameSparker.drawms();
                    //app.repaint();
                    CarDefine.loadstagemaker();
                }
                if (CheckPoints.stage != -3 && CarDefine.staction == 0 && CheckPoints.top20 < 3) {
                    rd.drawImage(contin[pcontin], 355, 360, null);
                } else {
                    pcontin = 0;
                }
                if (CheckPoints.top20 >= 3 && CarDefine.staction != 3 && CarDefine.staction != 4) {
                    rd.setFont(new Font("Arial", 1, 11));
                    ftm = rd.getFontMetrics();
                    if (dnload == 0 && drawcarb(true, null, " Add to My Stages ", 334, 355, i, i39, bool))
                        if (logged) {
                            CarDefine.onstage = CheckPoints.name;
                            CarDefine.staction = 2;
                            CarDefine.sparkstageaction();
                            dnload = 2;
                        } else {
                            lfrom = 1;
                            CarDefine.staction = 3;
                            showtf = false;
                            tcnt = 0;
                            cntflock = 0;
                            CarDefine.reco = -2;
                        }
                    if (dnload == 2) {
                        drawcs(370, "Adding stage please wait...", 193, 106, 0, 3);
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
                        if (dnload != 2) {
                            CarDefine.staction = 0;
                        }
                    }
                    if (dnload == 3) {
                        drawcs(370, "Stage has been successfully added to your stages!", 193, 106, 0, 3);
                    }
                    if (dnload == 4) {
                        drawcs(370, "You already have this stage!", 193, 106, 0, 3);
                    }
                    if (dnload == 5) {
                        drawcs(370, "Cannot add more then 20 stages to your account!", 193, 106, 0, 3);
                    }
                    if (dnload == 6) {
                        drawcs(370, "Failed to add stage, unknown error, please try again later.", 193, 106, 0, 3);
                    }
                }
                if (testdrive == 0 && CheckPoints.top20 < 3) {
                    if (!GameSparker.gmode.isShowing()) {
                        GameSparker.gmode.select(0);
                        GameSparker.gmode.setVisible(true);
                    }
                    GameSparker.gmode.move(400 - GameSparker.gmode.getWidth() / 2, 395);
                    if (GameSparker.gmode.getSelectedIndex() == 0 && nplayers != 7) {
                        nplayers = 7;
                        fase = 2;
                        app.requestFocus();
                    }
                    if (GameSparker.gmode.getSelectedIndex() == 1 && nplayers != 1) {
                        nplayers = 1;
                        fase = 2;
                        app.requestFocus();
                    }
                } else if (GameSparker.gmode.isShowing()) {
                    GameSparker.gmode.setVisible(false);
                }
                /*if (nfmtab == 0 && app.snfm1.getSelectedIndex() != checkpoints.stage
                		&& app.snfm1.getSelectedIndex() != 0) {
                	checkpoints.stage = app.snfm1.getSelectedIndex();
                	checkpoints.top20 = 0;
                	checkpoints.nto = 0;
                	hidos();
                	fase = 2;
                	app.requestFocus();
                }
                if (nfmtab == 1 && app.snfm2.getSelectedIndex() != checkpoints.stage - 10
                		&& app.snfm2.getSelectedIndex() != 0) {
                	checkpoints.stage = app.snfm2.getSelectedIndex() + 10;
                	checkpoints.top20 = 0;
                	checkpoints.nto = 0;
                	hidos();
                	fase = 2;
                	app.requestFocus();
                }*/
                if ((nfmtab == 2 || nfmtab == 5) && !GameSparker.mstgs.getSelectedItem().equals(CheckPoints.name) && GameSparker.mstgs.getSelectedIndex() != 0) {
                    if (nfmtab == 2) {
                        CheckPoints.stage = -2;
                    } else {
                        CheckPoints.stage = -1;
                    }
                    CheckPoints.name = GameSparker.mstgs.getSelectedItem();
                    CheckPoints.top20 = 0;
                    CheckPoints.nto = 0;
                    hidos();
                    fase = 2;
                    app.requestFocus();
                }
                if (nfmtab == 3 || nfmtab == 4) {
                    String string = "";
                    final int i43 = GameSparker.mstgs.getSelectedItem().indexOf(' ') + 1;
                    if (i43 > 0) {
                        string = GameSparker.mstgs.getSelectedItem().substring(i43);
                    }
                    if (!string.equals("") && !string.equals(CheckPoints.name) && GameSparker.mstgs.getSelectedIndex() != 0) {
                        CheckPoints.stage = -2;
                        CheckPoints.name = string;
                        CheckPoints.top20 = -CarDefine.msloaded;
                        CheckPoints.nto = GameSparker.mstgs.getSelectedIndex();
                        hidos();
                        fase = 2;
                        app.requestFocus();
                    }
                }
            } else {
                rd.setFont(new Font("SansSerif", 1, 13));
                ftm = rd.getFontMetrics();
                if (CheckPoints.stage != nTracks) {
                    final int i44 = CheckPoints.stage;
                    //if (i44 > 10)
                    //	i44 -= 10;
                    drawcs(80, "Stage " + i44 + "  >", 255, 128, 0, 3);
                } else {
                    drawcs(80, "Final Party Stage  >", 255, 128, 0, 3);
                }
                if (aflk) {
                    drawcs(100, "| " + CheckPoints.name + " |", 240, 240, 240, 3);
                    aflk = false;
                } else {
                    drawcs(100, "| " + CheckPoints.name + " |", 176, 176, 176, 3);
                    aflk = true;
                }
                if (CheckPoints.stage != -3) {
                    rd.drawImage(contin[pcontin], 355, 360, null);
                } else {
                    pcontin = 0;
                }
            }
            if (CarDefine.staction == 0) {
                if ((control.handb || control.enter) && CheckPoints.stage != -3 && CheckPoints.top20 < 3) {
                    GameSparker.gmode.setVisible(false);
                    hidos();
                    dudo = 150;
                    fase = 5;
                    control.handb = false;
                    control.enter = false;
                    intertrack.setPaused(true);
                    intertrack.unload();
                }
                if (CheckPoints.stage > 0) {
                    if (control.right) {
                        if (gmode == 0 /*|| gmode == 1 && checkpoints.stage != unlocked[0]*/
                        || gmode == 2 && CheckPoints.stage != unlocked/* + 10*/
                        || CheckPoints.stage == nTracks) {
                            if (CheckPoints.stage != nTracks) {
                                hidos();
                                CheckPoints.stage++;
                                //if (gmode == 1 && checkpoints.stage == 11)
                                //	checkpoints.stage = 27;
                                if (CheckPoints.stage > 10) {
                                    GameSparker.sgame.select(1);
                                    nfmtab = 1;
                                } else {
                                    GameSparker.sgame.select(0);
                                    nfmtab = 0;
                                }
                                fase = 2;
                            }
                        } else {
                            fase = 4;
                            lockcnt = 100;
                        }
                        control.right = false;
                    }
                    if (control.left && CheckPoints.stage != 1/* && (checkpoints.stage != 11 || gmode != 2)*/) {
                        hidos();
                        CheckPoints.stage--;
                        //if (gmode == 1 && checkpoints.stage == 26)
                        //	checkpoints.stage = 10;
                        if (CheckPoints.stage > 10) {
                            GameSparker.sgame.select(1);
                            nfmtab = 1;
                        } else {
                            GameSparker.sgame.select(0);
                            nfmtab = 0;
                        }
                        fase = 2;
                        control.left = false;
                    }
                }
            }
        } else {
            if (aflk) {
                drawcs(132, CheckPoints.name, 240, 240, 240, 3);
                aflk = false;
            } else {
                drawcs(132, CheckPoints.name, 176, 176, 176, 3);
                aflk = true;
            }
            rd.drawImage(contin[pcontin], 355, 360, null);
            if (control.handb || control.enter) {
                dudo = 150;
                fase = 5;
                control.handb = false;
                control.enter = false;
                intertrack.setPaused(true);
                intertrack.unload();
            }
        }
        if (drawcarb(true, null, " Exit X ", 670, 30, i, i39, bool)) {
            fase = 103;
            //fase = 102;
            if (gmode == 0) {
                opselect = 3;
            }
            //if (gmode == 1)
            //	opselect = 0;
            if (gmode == 2) {
                opselect = 1;
            }
            GameSparker.gmode.setVisible(false);
            hidos();
            GameSparker.tnick.setVisible(false);
            GameSparker.tpass.setVisible(false);
            intertrack.setPaused(true);
        }
    }

    static void stat(final Mad mad, final ContO conto, final Control control, final boolean bool) {
        if (holdit) {
            int i = 250;
            if (fase == 7001)
                if (exitm != 4) {
                    exitm = 0;
                    i = 600;
                } else {
                    i = 1200;
                }
            if (exitm != 4 || !lan || im != 0) {
                holdcnt++;
                if ((control.enter || holdcnt > i) && (control.chatup == 0 || fase != 7001)) {
                    fase = -2;
                    control.enter = false;
                }
            } else if (control.enter) {
                control.enter = false;
            }
        } else {
            if (holdcnt != 0) {
                holdcnt = 0;
            }
            if (control.enter || control.exit) {
                if (fase == 0) {
                    if (loadedt) {
                        strack.setPaused(true);
                    }
                    SoundClip.stopAll();
                    fase = -6;
                } else if (starcnt == 0 && control.chatup == 0 && (multion < 2 || !lan))
                    if (exitm == 0) {
                        exitm = 1;
                    } else {
                        exitm = 0;
                    }
                if (control.chatup == 0 || fase != 7001) {
                    control.enter = false;
                }
                control.exit = false;
            }
        }
        if (exitm == 2) {
            fase = -2;
            winner = false;
        }
        if (fase != -2) {
            holdit = false;
            if (CheckPoints.haltall) {
                CheckPoints.haltall = false;
            }
            boolean bool184 = false;
            String string = "";
            String string185 = "";
            if (clangame != 0 && (!mad.dest || multion >= 2)) {
                bool184 = true;
                for (int i = 0; i < nplayers; i++)
                    if (CheckPoints.dested[i] == 0)
                        if (string.equals("")) {
                            string = pclan[i];
                        } else if (!string.equalsIgnoreCase(pclan[i])) {
                            bool184 = false;
                            break;
                        }
            }
            if (clangame > 1) {
                boolean bool186 = false;
                String string187 = "";
                if (bool184) {
                    for (int i = 0; i < nplayers; i++)
                        if (!string.equalsIgnoreCase(pclan[i])) {
                            string185 = pclan[i];
                            break;
                        }
                    if (clangame == 2) {
                        bool186 = true;
                        string187 = "Clan " + string185 + " wasted, nobody won becuase this is a racing only game!";
                    }
                    if (clangame == 4 && !string.equalsIgnoreCase(gaclan)) {
                        bool186 = true;
                        string187 = "Clan " + string185 + " wasted, nobody won becuase " + string + " should have raced in this racing vs wasting game!";
                    }
                    if (clangame == 5 && string.equalsIgnoreCase(gaclan)) {
                        bool186 = true;
                        string187 = "Clan " + string185 + " wasted, nobody won becuase " + string + " should have raced in this racing vs wasting game!";
                    }
                }
                for (int i = 0; i < nplayers; i++)
                    if (CheckPoints.clear[i] == CheckPoints.nlaps * CheckPoints.nsp && CheckPoints.pos[i] == 0) {
                        if (clangame == 3) {
                            bool186 = true;
                            string187 = "" + plnames[i] + " of clan " + pclan[i] + " finished first, nobody won becuase this is a wasting only game!";
                        }
                        if (clangame == 4 && pclan[i].equalsIgnoreCase(gaclan)) {
                            bool186 = true;
                            string187 = "" + plnames[i] + " of clan " + pclan[i] + " finished first, nobody won becuase " + pclan[i] + " should have wasted in this racing vs wasting game!";
                        }
                        if (clangame == 5 && !pclan[i].equalsIgnoreCase(gaclan)) {
                            bool186 = true;
                            string187 = "" + plnames[i] + " of clan " + pclan[i] + " finished first, nobody won becuase " + pclan[i] + " should have wasted in this racing vs wasting game!";
                        }
                    }
                if (bool186) {
                    drawhi(gamefinished, 70);
                    if (aflk) {
                        drawcs(120, string187, 0, 0, 0, 0);
                        aflk = false;
                    } else {
                        drawcs(120, string187, 0, 128, 255, 0);
                        aflk = true;
                    }
                    drawcs(350, "Press  [ Enter ]  to continue", 0, 0, 0, 0);
                    CheckPoints.haltall = true;
                    holdit = true;
                    winner = false;
                }
            }
            if (multion < 2) {
                if (!holdit && (CheckPoints.wasted == nplayers - 1 && nplayers != 1 || bool184)) {
                    drawhi(youwastedem, 70);
                    if (!bool184) {
                        if (aflk) {
                            drawcs(120, "You Won, all cars have been wasted!", 0, 0, 0, 0);
                            aflk = false;
                        } else {
                            drawcs(120, "You Won, all cars have been wasted!", 0, 128, 255, 0);
                            aflk = true;
                        }
                    } else if (aflk) {
                        drawcs(120, "Your clan " + string + " has wasted all the cars!", 0, 0, 0, 0);
                        aflk = false;
                    } else {
                        drawcs(120, "Your clan " + string + " has wasted all the cars!", 0, 128, 255, 0);
                        aflk = true;
                    }
                    drawcs(350, "Press  [ Enter ]  to continue", 0, 0, 0, 0);
                    CheckPoints.haltall = true;
                    holdit = true;
                    winner = true;
                }
                if (!holdit && mad.dest && cntwis[im] == 8) {
                    if (discon != 240) {
                        drawhi(yourwasted, 70);
                    } else {
                        drawhi(disco, 70);
                        stopchat();
                    }
                    boolean bool188 = false;
                    if (lan) {
                        bool188 = true;
                        for (int i = 0; i < nplayers; i++)
                            if (i != im && dested[i] == 0 && !plnames[i].contains("MadBot")) {
                                bool188 = false;
                            }
                    }
                    if (fase == 7001 && nplayers - (CheckPoints.wasted + 1) >= 2 && discon != 240 && !bool188) {
                        exitm = 4;
                    } else {
                        if (exitm == 4) {
                            exitm = 0;
                        }
                        drawcs(350, "Press  [ Enter ]  to continue", 0, 0, 0, 0);
                    }
                    holdit = true;
                    winner = false;
                }
                if (!holdit) {
                    for (int i = 0; i < nplayers; i++)
                        if (CheckPoints.clear[i] == CheckPoints.nlaps * CheckPoints.nsp && CheckPoints.pos[i] == 0) {
                            // it is stopped later on
                            if (clangame == 0) {
                                if (i == im) {
                                    drawhi(youwon, 70);
                                    if (aflk) {
                                        drawcs(120, "You finished first, nice job!", 0, 0, 0, 0);
                                        aflk = false;
                                    } else {
                                        drawcs(120, "You finished first, nice job!", 0, 128, 255, 0);
                                        aflk = true;
                                    }
                                    winner = true;
                                } else {
                                    drawhi(youlost, 70);
                                    if (fase != 7001) {
                                        if (aflk) {
                                            drawcs(120, "" + CarDefine.names[sc[i]] + " finished first, race over!", 0, 0, 0, 0);
                                            aflk = false;
                                        } else {
                                            drawcs(120, "" + CarDefine.names[sc[i]] + " finished first, race over!", 0, 128, 255, 0);
                                            aflk = true;
                                        }
                                    } else if (aflk) {
                                        drawcs(120, "" + plnames[i] + " finished first, race over!", 0, 0, 0, 0);
                                        aflk = false;
                                    } else {
                                        drawcs(120, "" + plnames[i] + " finished first, race over!", 0, 128, 255, 0);
                                        aflk = true;
                                    }
                                    winner = false;
                                }
                            } else if (pclan[i].equalsIgnoreCase(pclan[im])) {
                                drawhi(youwon, 70);
                                if (aflk) {
                                    drawcs(120, "Your clan " + pclan[im] + " finished first, nice job!", 0, 0, 0, 0);
                                    aflk = false;
                                } else {
                                    drawcs(120, "Your clan " + pclan[im] + " finished first, nice job!", 0, 128, 255, 0);
                                    aflk = true;
                                }
                                winner = true;
                            } else {
                                drawhi(youlost, 70);
                                if (aflk) {
                                    drawcs(120, "" + plnames[i] + " of clan " + pclan[i] + " finished first, race over!", 0, 0, 0, 0);
                                    aflk = false;
                                } else {
                                    drawcs(120, "" + plnames[i] + " of clan " + pclan[i] + " finished first, race over!", 0, 128, 255, 0);
                                    aflk = true;
                                }
                                winner = false;
                            }
                            drawcs(350, "Press  [ Enter ]  to continue", 0, 0, 0, 0);
                            CheckPoints.haltall = true;
                            holdit = true;
                        }
                }
            } else {
                if (!holdit && (CheckPoints.wasted >= nplayers - 1 || bool184)) {
                    String string189 = "Someone";
                    if (!bool184) {
                        for (int i = 0; i < nplayers; i++)
                            if (CheckPoints.dested[i] == 0) {
                                string189 = plnames[i];
                            }
                    } else {
                        string189 = "Clan " + string + "";
                    }
                    drawhi(gamefinished, 70);
                    if (aflk) {
                        drawcs(120, "" + string189 + " has wasted all the cars!", 0, 0, 0, 0);
                        aflk = false;
                    } else {
                        drawcs(120, "" + string189 + " has wasted all the cars!", 0, 128, 255, 0);
                        aflk = true;
                    }
                    drawcs(350, "Press  [ Enter ]  to continue", 0, 0, 0, 0);
                    CheckPoints.haltall = true;
                    holdit = true;
                    winner = false;
                }
                if (!holdit) {
                    for (int i = 0; i < nplayers; i++)
                        if (CheckPoints.clear[i] == CheckPoints.nlaps * CheckPoints.nsp && CheckPoints.pos[i] == 0) {
                            drawhi(gamefinished, 70);
                            if (clangame == 0) {
                                if (aflk) {
                                    drawcs(120, "" + plnames[i] + " finished first, race over!", 0, 0, 0, 0);
                                    aflk = false;
                                } else {
                                    drawcs(120, "" + plnames[i] + " finished first, race over!", 0, 128, 255, 0);
                                    aflk = true;
                                }
                            } else if (aflk) {
                                drawcs(120, "Clan " + pclan[i] + " finished first, race over!", 0, 0, 0, 0);
                                aflk = false;
                            } else {
                                drawcs(120, "Clan " + pclan[i] + " finished first, race over!", 0, 128, 255, 0);
                                aflk = true;
                            }
                            drawcs(350, "Press  [ Enter ]  to continue", 0, 0, 0, 0);
                            CheckPoints.haltall = true;
                            holdit = true;
                            winner = false;
                        }
                }
                if (!holdit && discon == 240) {
                    drawhi(gamefinished, 70);
                    if (aflk) {
                        drawcs(120, "Game got disconnected!", 0, 0, 0, 0);
                        aflk = false;
                    } else {
                        drawcs(120, "Game got disconnected!", 0, 128, 255, 0);
                        aflk = true;
                    }
                    drawcs(350, "Press  [ Enter ]  to continue", 0, 0, 0, 0);
                    CheckPoints.haltall = true;
                    holdit = true;
                    winner = false;
                }
                if (!holdit) {
                    rd.drawImage(wgame, 311, 20, null);
                    if (!clanchat) {
                        drawcs(397, "Click any player on the right to follow!", 0, 0, 0, 0);
                        if (!lan) {
                            drawcs(412, "Press [V] to change view.  Press [Enter] to exit.", 0, 0, 0, 0);
                        } else {
                            drawcs(412, "Press [V] to change view.", 0, 0, 0, 0);
                        }
                    }
                }
            }
            if (bool) {
                if (CheckPoints.stage != 10 && multion < 2 && nplayers != 1 && arrace != control.arrace) {
                    arrace = control.arrace;
                    if (multion == 1 && arrace) {
                        control.radar = true;
                    }
                    if (arrace) {
                        wasay = true;
                        say = " Arrow now pointing at >  CARS";
                        if (multion == 1) {
                            say = say + "    Press [S] to toggle Radar!";
                        }
                        tcnt = -5;
                    }
                    if (!arrace) {
                        wasay = false;
                        say = " Arrow now pointing at >  TRACK";
                        if (multion == 1) {
                            say = say + "    Press [S] to toggle Radar!";
                        }
                        tcnt = -5;
                        cntan = 20;
                        alocked = -1;
                        alocked = -1;
                    }
                }
                if (!holdit && fase != -6 && starcnt == 0 && multion < 2 && CheckPoints.stage != 10) {
                    arrow(mad.point, mad.missedcp, arrace);
                    if (!arrace) {
                        if (auscnt == 45 && mad.capcnt == 0 && exitm == 0)
                            if (mad.missedcp > 0) {
                                if (mad.missedcp > 15 && mad.missedcp < 50)
                                    if (flk) {
                                        drawcs(70, "Checkpoint Missed!", 255, 0, 0, 0);
                                    } else {
                                        drawcs(70, "Checkpoint Missed!", 255, 150, 0, 2);
                                    }
                                mad.missedcp++;
                                if (mad.missedcp == 70) {
                                    mad.missedcp = -2;
                                }
                            } else if (mad.mtouch && cntovn < 70) {
                                if (Math.abs(ana) > 100) {
                                    cntan++;
                                } else if (cntan != 0) {
                                    cntan--;
                                }
                                if (cntan > 40) {
                                    cntovn++;
                                    cntan = 40;
                                    if (flk) {
                                        drawcs(70, "Wrong Way!", 255, 150, 0, 0);
                                        flk = false;
                                    } else {
                                        drawcs(70, "Wrong Way!", 255, 0, 0, 2);
                                        flk = true;
                                    }
                                }
                            }
                    } else if (alocked != lalocked) {
                        if (alocked != -1) {
                            wasay = true;
                            say = " Arrow Locked on >  " + plnames[alocked] + "";
                            tcnt = -5;
                        } else {
                            wasay = true;
                            say = "Arrow Unlocked!";
                            tcnt = 10;
                        }
                        lalocked = alocked;
                    }
                }
                if (Medium.darksky) {
                    Color color = new Color(Medium.csky[0], Medium.csky[1], Medium.csky[2]);
                    final float[] fs = new float[3];
                    Color.RGBtoHSB(Medium.csky[0], Medium.csky[1], Medium.csky[2], fs);
                    fs[2] = 0.6F;
                    color = Color.getHSBColor(fs[0], fs[1], fs[2]);
                    rd.setColor(color);
                    rd.fillRect(602, 9, 54, 14);
                    rd.drawLine(601, 10, 601, 21);
                    rd.drawLine(600, 12, 600, 19);
                    rd.fillRect(607, 29, 49, 14);
                    rd.drawLine(606, 30, 606, 41);
                    rd.drawLine(605, 32, 605, 39);
                    rd.fillRect(18, 6, 155, 14);
                    rd.drawLine(17, 7, 17, 18);
                    rd.drawLine(16, 9, 16, 16);
                    rd.drawLine(173, 7, 173, 18);
                    rd.drawLine(174, 9, 174, 16);
                    rd.fillRect(40, 26, 107, 21);
                    rd.drawLine(39, 27, 39, 45);
                    rd.drawLine(38, 29, 38, 43);
                    rd.drawLine(147, 27, 147, 45);
                    rd.drawLine(148, 29, 148, 43);
                }
                rd.drawImage(dmg, 600, 7, null);
                rd.drawImage(pwr, 600, 27, null);
                rd.drawImage(lap, 19, 7, null);
                rd.setColor(new Color(0, 0, 100));
                rd.drawString("" + (mad.nlaps + 1) + " / " + CheckPoints.nlaps + "", 51, 18);
                rd.drawImage(was, 92, 7, null);
                rd.setColor(new Color(0, 0, 100));
                rd.drawString("" + CheckPoints.wasted + " / " + (nplayers - 1) + "", 150, 18);
                rd.drawImage(pos, 42, 27, null);
                rd.drawImage(rank[CheckPoints.pos[mad.im]], 110, 28, null);
                drawstat(CarDefine.maxmag[mad.cn], mad.hitmag, mad.power);
                if (control.radar && CheckPoints.stage != 10) {
                    radarstat(mad, conto);
                }
            }
            if (!holdit) {
                if (starcnt != 0 && starcnt <= 35) {
                    if (starcnt == 35 && !mutes) {
                        three.play();
                    }
                    if (starcnt == 24) {
                        gocnt = 2;
                        if (!mutes) {
                            two.play();
                        }
                    }
                    if (starcnt == 13) {
                        gocnt = 1;
                        if (!mutes) {
                            one.play();
                        }
                    }
                    if (starcnt == 2) {
                        gocnt = 0;
                        if (!mutes) {
                            go.play();
                        }
                    }
                    duds = 0;
                    if (starcnt <= 37 && starcnt > 32) {
                        duds = 1;
                    }
                    if (starcnt <= 26 && starcnt > 21) {
                        duds = 1;
                    }
                    if (starcnt <= 15 && starcnt > 10) {
                        duds = 1;
                    }
                    if (starcnt <= 4) {
                        duds = 2;
                    }
                    if (dudo != -1) {
                        rd.setComposite(AlphaComposite.getInstance(3, 0.3F));
                        rd.drawImage(dude[duds], dudo, 0, null);
                        rd.setComposite(AlphaComposite.getInstance(3, 1.0F));
                    }
                    if (gocnt != 0) {
                        rd.drawImage(cntdn[gocnt], 385, 50, null);
                    } else {
                        rd.drawImage(cntdn[gocnt], 363, 50, null);
                    }
                }
                if (looped != 0 && mad.loop == 2) {
                    looped = 0;
                }
                if (mad.power < 45.0F) {
                    if (tcnt == 30 && auscnt == 45 && mad.mtouch && mad.capcnt == 0 && exitm == 0) {
                        if (looped != 2) {
                            if (pwcnt < 70 || pwcnt < 100 && looped != 0)
                                if (pwflk) {
                                    drawcs(110, "Power low, perform stunt!", 0, 0, 200, 0);
                                    pwflk = false;
                                } else {
                                    drawcs(110, "Power low, perform stunt!", 255, 100, 0, 0);
                                    pwflk = true;
                                }
                        } else if (pwcnt < 100) {
                            String string192 = "";
                            if (multion == 0) {
                                string192 = "  (Press Enter)";
                            }
                            if (pwflk) {
                                drawcs(110, "Please read the Game Instructions!" + string192 + "", 0, 0, 200, 0);
                                pwflk = false;
                            } else {
                                drawcs(110, "Please read the Game Instructions!" + string192 + "", 255, 100, 0, 0);
                                pwflk = true;
                            }
                        }
                        pwcnt++;
                        if (pwcnt == 300) {
                            pwcnt = 0;
                            if (looped != 0) {
                                looped++;
                                if (looped == 4) {
                                    looped = 2;
                                }
                            }
                        }
                    }
                } else if (pwcnt != 0) {
                    pwcnt = 0;
                }
                if (mad.capcnt == 0) {
                    if (tcnt < 30) {
                        if (exitm == 0)
                            if (tflk) {
                                if (!wasay) {
                                    drawcs(105, say, 0, 0, 0, 0);
                                } else {
                                    drawcs(105, say, 0, 0, 0, 0);
                                }
                                tflk = false;
                            } else {
                                if (!wasay) {
                                    drawcs(105, say, 0, 128, 255, 0);
                                } else {
                                    drawcs(105, say, 255, 128, 0, 0);
                                }
                                tflk = true;
                            }
                        tcnt++;
                    } else if (wasay) {
                        wasay = false;
                    }
                    if (auscnt < 45) {
                        if (exitm == 0)
                            if (aflk) {
                                drawcs(85, asay, 98, 176, 255, 0);
                                aflk = false;
                            } else {
                                drawcs(85, asay, 0, 128, 255, 0);
                                aflk = true;
                            }
                        auscnt++;
                    }
                } else if (exitm == 0)
                    if (tflk) {
                        drawcs(110, "Bad Landing!", 0, 0, 200, 0);
                        tflk = false;
                    } else {
                        drawcs(110, "Bad Landing!", 255, 100, 0, 0);
                        tflk = true;
                    }
                if (mad.trcnt == 10) {
                    loop = "";
                    spin = "";
                    asay = "";
                    int i = 0;
                    while (mad.travzy > 225) {
                        mad.travzy -= 360;
                        i++;
                    }
                    while (mad.travzy < -225) {
                        mad.travzy += 360;
                        i--;
                    }
                    if (i == 1) {
                        loop = "Forward loop";
                    }
                    if (i == 2) {
                        loop = "double Forward";
                    }
                    if (i == 3) {
                        loop = "triple Forward";
                    }
                    if (i >= 4) {
                        loop = "massive Forward looping";
                    }
                    if (i == -1) {
                        loop = "Backloop";
                    }
                    if (i == -2) {
                        loop = "double Back";
                    }
                    if (i == -3) {
                        loop = "triple Back";
                    }
                    if (i <= -4) {
                        loop = "massive Back looping";
                    }
                    if (i == 0)
                        if (mad.ftab && mad.btab) {
                            loop = "Tabletop and reversed Tabletop";
                        } else if (mad.ftab || mad.btab) {
                            loop = "Tabletop";
                        }
                    if (i > 0 && mad.btab) {
                        loop = "Hanged " + loop;
                    }
                    if (i < 0 && mad.ftab) {
                        loop = "Hanged " + loop;
                    }
                    if (!Objects.equals(loop, "")) {
                        asay = asay + " " + loop;
                    }
                    i = 0;
                    mad.travxy = Math.abs(mad.travxy);
                    while (mad.travxy > 270) {
                        mad.travxy -= 360;
                        i++;
                    }
                    if (i == 0 && mad.rtab)
                        if (Objects.equals(loop, "")) {
                            spin = "Tabletop";
                        } else {
                            spin = "Flipside";
                        }
                    if (i == 1) {
                        spin = "Rollspin";
                    }
                    if (i == 2) {
                        spin = "double Rollspin";
                    }
                    if (i == 3) {
                        spin = "triple Rollspin";
                    }
                    if (i >= 4) {
                        spin = "massive Roll spinning";
                    }
                    i = 0;
                    boolean bool194 = false;
                    mad.travxz = Math.abs(mad.travxz);
                    while (mad.travxz > 90) {
                        mad.travxz -= 180;
                        i += 180;
                        if (i > 900) {
                            i = 900;
                            bool194 = true;
                        }
                    }
                    if (i != 0) {
                        if (Objects.equals(loop, "") && Objects.equals(spin, "")) {
                            asay = asay + " " + i;
                            if (bool194) {
                                asay = asay + " and beyond";
                            }
                        } else {
                            if (!Objects.equals(spin, ""))
                                if (Objects.equals(loop, "")) {
                                    asay = asay + " " + spin;
                                } else {
                                    asay = asay + " with " + spin;
                                }
                            asay = asay + " by " + i;
                            if (bool194) {
                                asay = asay + " and beyond";
                            }
                        }
                    } else if (!Objects.equals(spin, ""))
                        if (Objects.equals(loop, "")) {
                            asay = asay + " " + spin;
                        } else {
                            asay = asay + " by " + spin;
                        }
                    if (!Objects.equals(asay, "")) {
                        auscnt -= 15;
                    }
                    if (!Objects.equals(loop, "")) {
                        auscnt -= 25;
                    }
                    if (!Objects.equals(spin, "")) {
                        auscnt -= 25;
                    }
                    if (i != 0) {
                        auscnt -= 25;
                    }
                    if (auscnt < 45) {
                        if (!mutes) {
                            powerup.play();
                        }
                        if (auscnt < -20) {
                            auscnt = -20;
                        }
                        int i205 = 0;
                        if (mad.powerup > 20.0F) {
                            i205 = 1;
                        }
                        if (mad.powerup > 40.0F) {
                            i205 = 2;
                        }
                        if (mad.powerup > 150.0F) {
                            i205 = 3;
                        }
                        if (mad.surfer) {
                            asay = " " + adj[4][(int) (Medium.random() * 3.0F)] + asay;
                        }
                        if (i205 != 3) {
                            asay = "" + adj[i205][(int) (Medium.random() * 3.0F)] + asay + exlm[i205];
                        } else {
                            asay = adj[i205][(int) (Medium.random() * 3.0F)];
                        }
                        if (!wasay) {
                            tcnt = auscnt;
                            if (mad.power != 98.0F) {
                                say = "Power Up " + (int) (100.0F * mad.powerup / 98.0F) + "%";
                            } else {
                                say = "Power To The MAX";
                            }
                            skidup = !skidup;
                        }
                    }
                }
                if (mad.newcar) {
                    if (!wasay) {
                        say = "Car Fixed";
                        tcnt = 0;
                    }
                    crashup = !crashup;
                }
                for (int i = 0; i < nplayers; i++)
                    if (dested[i] != CheckPoints.dested[i] && i != im) {
                        dested[i] = CheckPoints.dested[i];
                        if (fase != 7001) {
                            if (dested[i] == 1) {
                                wasay = true;
                                say = "" + CarDefine.names[sc[i]] + " has been wasted!";
                                tcnt = -15;
                            }
                            if (dested[i] == 2) {
                                wasay = true;
                                say = "You wasted " + CarDefine.names[sc[i]] + "!";
                                tcnt = -15;
                            }
                        } else {
                            if (dested[i] == 1) {
                                wasay = true;
                                say = "" + plnames[i] + " has been wasted!";
                                tcnt = -15;
                            }
                            if (dested[i] == 2) {
                                wasay = true;
                                if (multion < 2) {
                                    say = "You wasted " + plnames[i] + "!";
                                } else {
                                    say = "" + plnames[im] + " wasted " + plnames[i] + "!";
                                }
                                tcnt = -15;
                            }
                            if (dested[i] == 3) {
                                wasay = true;
                                say = "" + plnames[i] + " has been wasted! (Disconnected)";
                                tcnt = -15;
                            }
                        }
                    }
                if (multion >= 2 && alocked != lalocked) {
                    if (alocked != -1) {
                        wasay = false;
                        say = "Now following " + plnames[alocked] + "!";
                        tcnt = -15;
                    }
                    lalocked = alocked;
                    clear = mad.clear;
                }
                if (clear != mad.clear && mad.clear != 0) {
                    if (!wasay) {
                        say = "Checkpoint!";
                        tcnt = 15;
                    }
                    clear = mad.clear;
                    if (!mutes) {
                        checkpoint.play();
                    }
                    cntovn = 0;
                    if (cntan != 0) {
                        cntan = 0;
                    }
                }
            }
        }
        if (Medium.lightn != -1) {
            //final int i = strack.sClip.stream.available();
            Medium.lton = false;
            //if (i <= 6380001 && i > 5368001)
            //	m.lton = true;
            //if (i <= 2992001 && i > 1320001)
            //	m.lton = true;
        }
    }

    static private void stopairs() {
        for (int i = 0; i < 6; i++) {
            air[i].stop();
        }
    }

    static void stopallnow() {
        if (runner != null) {
            runner.interrupt();
            runner = null;
        }
        runtyp = 0;
        if (loadedt) {
            strack.unload();
            strack = null;
            loadedt = false;
        }
        for (int i = 0; i < 5; i++) {
            for (int i19 = 0; i19 < 5; i19++) {
                if (engs[i][i19] != null) {
                    engs[i][i19].stop();
                }
                engs[i][i19] = null;
            }
        }
        for (int i = 0; i < 6; i++) {
            if (air[i] != null) {
                air[i].stop();
            }
            air[i] = null;
        }
        wastd.stop();
        if (intertrack != null) {
            intertrack.unload();
        }
        intertrack = null;
    }

    static void stopchat() {
        clanchat = false;
        clangame = 0;
        if (runtyp == -101) {
            runtyp = 0;
            try {
                socket.close();
                socket = null;
                din.close();
                din = null;
                dout.close();
                dout = null;
            } catch (final Exception ignored) {

            }
        }
    }

    static void stoploading() {
        loading();
        //app.repaint();
        runtyp = 0;
    }

    static void trackbg(final boolean bool) {
        int i = 0;
        trkl++;
        if (trkl > trklim) {
            i = 1;
            trklim = (int) (ThreadLocalRandom.current().nextDouble() * 40.0);
            trkl = 0;
        }
        if (bool) {
            i = 0;
        }
        for (int i25 = 0; i25 < 2; i25++) {
            rd.drawImage(trackbg[i], trkx[i25], 25, null);
            trkx[i25] -= 10;
            if (trkx[i25] <= -605) {
                trkx[i25] = 735;
            }
        }
        rd.setColor(new Color(0, 0, 0));
        rd.fillRect(0, 0, 65, 450);
        rd.fillRect(735, 0, 65, 450);
        rd.fillRect(65, 0, 670, 25);
        rd.fillRect(65, 425, 670, 25);
    }

    static void waitenter() {
        if (forstart < 690) {
            rd.setFont(new Font("Arial", 1, 13));
            ftm = rd.getFontMetrics();
            drawcs(70, "Waiting for all players to finish loading!", 0, 0, 0, 0);
            if (forstart <= 640) {
                drawcs(90, "" + (640 - forstart) / 32 + "", 0, 0, 0, 0);
            } else {
                drawcs(90, "Your connection to game may have been lost...", 0, 0, 0, 0);
            }
            rd.setFont(new Font("Arial", 1, 11));
            ftm = rd.getFontMetrics();
            if (tflk) {
                drawcs(125, "Get Ready!", 0, 0, 0, 0);
                tflk = false;
            } else {
                drawcs(125, "Get Ready!", 0, 128, 255, 0);
                tflk = true;
            }
        }
        forstart++;
        if (forstart == 700) {
            fase = -2;
            winner = false;
        }
    }

    static private int xs(final int i, int i279) {
        if (i279 < 50) {
            i279 = 50;
        }
        return (i279 - Medium.focusPoint) * (Medium.cx - i) / i279 + i;
    }

    static private int ys(final int i, int i280) {
        if (i280 < 50) {
            i280 = 50;
        }
        return (i280 - Medium.focusPoint) * (Medium.cy - i) / i280 + i;
    }
}
