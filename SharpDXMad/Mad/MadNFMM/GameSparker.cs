package nfm.open;
/* GameSparker - Decompiled by JODE
 * Visit http://jode.sourceforge.net/
 */

import javax.swing.*;
import javax.swing.Timer;

import nfm.open.xtGraphics.Images;
import nfm.open.util.FileUtil;

import java.awt.*;
import java.awt.event.*;
import java.awt.image.BufferedImage;
import java.io.*;
import java.net.URI;
import java.net.URL;
import java.util.*;
import java.util.concurrent.ThreadLocalRandom;
import java.util.zip.ZipEntry;
import java.util.zip.ZipInputStream;

class GameSparker extends JPanel
        implements KeyListener, MouseListener, MouseMotionListener, FocusListener {
    /**
     *
     */
    private static final long serialVersionUID = -5976860556958716653L;

    private static final Comparator<int[]> contoComparator = (arg0, arg1) -> Integer.compare(arg1[1], arg0[1]);

    /**
     * Game size multiplier
     */
    static private float apmult = 1.0F;

    /**
     * Whether JVM vendor is Apple or not
     */
    static boolean applejava = false;

    /**
     * Game's X position in window
     */
    static private int apx = 0;

    /**
     * Game's Y position in window
     */
    static private int apy = 0;
    static private Image blb;
    static private final Image[] carmaker = new Image[2];
    static private final Image[] chkbx = new Image[2];
    static private final Smenu clanlev = new Smenu(8);
    static private final Smenu clcars = new Smenu(707);
    static TextField cmsg;
    static private final Smenu datat = new Smenu(26);
    static private boolean exwist = false;
    static private int fcscnt = 0;
    static private Image fulls;
    static final Smenu gmode = new Smenu(3);
    static private final Smenu icars = new Smenu(5);
    static private final Smenu ilaps = new Smenu(18);
    static Checkbox keplo;
    static private int lasth = 0;
    static private int lastw = 0;
    static private int lmxz = 0;
    static private boolean lostfcs = false;
    static final Smenu mcars = new Smenu(707);
    static private int mload = 1;
    static private TextArea mmsg;
    /**
     * 0 = Motion effects off
     * 1 = Motion effects on
     */
    static int moto = 0;
    static private boolean moused = false;
    static int mouses = 0;
    static private int mousew = 0;
    static final Smenu mstgs = new Smenu(707);
    /**
     * Applies transparency to every polygon (20 is 20% opacity, 100 is 100% opacity)
     */
    static private int mvect = 100;
    static Checkbox mycar;
    static private int nob = 0;
    static private int notb = 0;
    static Checkbox notp;
    static final BufferedImage offImage = createOffImage();
    static private boolean onbar = false;
    static private boolean oncarm = false;
    static private boolean onfulls = false;
    static private boolean onstgm = false;
    static boolean openm = false;
    static final Smenu pgame = new Smenu(11);
    static private final Smenu proitem = new Smenu(707);
    final static Graphics2D rd = offImage.createGraphics();;
    static private float reqmult = 0.0F;
    static final Smenu rooms = new Smenu(7);
    static final Smenu scars = new Smenu(4);
    static final Smenu sclass = new Smenu(7);
    static private final Smenu senditem = new Smenu(707);
    static private final Smenu sendtyp = new Smenu(6);
    static final Smenu sfix = new Smenu(7);
    static final Smenu sgame = new Smenu(8);
    static private int shaka = 0;
    static private int showsize = 0;
    static private Image sizebar;
    static final Smenu slaps = new Smenu(17);
    static private int smooth = 1;
    static final Smenu snbts = new Smenu(8);
    //Smenu snfm1 = new Smenu(12);
    //Smenu snfm2 = new Smenu(19);
    static final Smenu snfmm = new Smenu(xtGraphics.nTracks + 2);
    static final Smenu snpls = new Smenu(9);
    static private final Image[] stagemaker = new Image[2];
    static final Smenu swait = new Smenu(6);
    static TextField temail;
    static TextField tnick;
    static TextField tpass;
    static final Control[] u = new Control[8];
    static private int view = 0;
    static final Smenu vnpls = new Smenu(5);
    static final Smenu vtyp = new Smenu(6);
    static final Smenu warb = new Smenu(102);
    static final Smenu wgame = new Smenu(4);
    static private int xm = 0;
    static private int ym = 0;

    /**
     * Used for internal time measurement (usage is analogous to System.currentTimeMilis())
     */
    static private Date date;
    static private int clicknowtime;
    /**
     * ContO array for cars
     */
    static private ContO[] carContos;
    /**
     * ContO array for track pieces
     */
    static private ContO[] contos;
    /**
     * ContO array for the current stage's contents themselves
     */
    static private ContO[] stageContos;
    static Mad[] mads;
    static private Login login = null;
    static private Lobby lobby = null;
    //private Globe globe = null;
    static private final UDPMistro udpmistro = new UDPMistro();
    static private boolean bool = false;
    static private int recordtime;
    static private int finishrecording;
    static private int wastedpoint;
    static private boolean flashingscreen;

    /* Also for time measurement: */
    static private long l1;
    static private float f2;
    static private boolean bool3;
    static private int i4;
    static private int i5;
    static private float f;

    /**
     * List of car .rad files.
     */
    private final static String[] carRads = {
            "2000tornados", "formula7", "canyenaro", "lescrab", "nimi", "maxrevenge", "leadoxide", "koolkat", "drifter",
            "policecops", "mustang", "king", "audir8", "masheen", "radicalone", "drmonster"
    };
    /**
     * List of track part .rad files.
     */
    public final static String[] stageRads = {
            "road", "froad", "twister2", "twister1", "turn", "offroad", "bumproad", "offturn", "nroad", "nturn",
            "roblend", "noblend", "rnblend", "roadend", "offroadend", "hpground", "ramp30", "cramp35", "dramp15",
            "dhilo15", "slide10", "takeoff", "sramp22", "offbump", "offramp", "sofframp", "halfpipe", "spikes", "rail",
            "thewall", "checkpoint", "fixpoint", "offcheckpoint", "sideoff", "bsideoff", "uprise", "riseroad", "sroad",
            "soffroad", "tside", "launchpad", "thenet", "speedramp", "offhill", "slider", "uphill", "roll1", "roll2",
            "roll3", "roll4", "roll5", "roll6", "opile1", "opile2", "aircheckpoint", "tree1", "tree2", "tree3", "tree4",
            "tree5", "tree6", "tree7", "tree8", "cac1", "cac2", "cac3", "8sroad", "8soffroad"
    };

    /**
     * Triple-buffer for motion effects
     */
    static private BufferedImage tribuffer;
    /**
     * {@link #tribuffer}'s Graphics2D object
     */
    static private Graphics2D tg;

    private final static GraphicsConfiguration gfxConfig = GraphicsEnvironment.getLocalGraphicsEnvironment().getDefaultScreenDevice().getDefaultConfiguration();

    static private boolean gameLoaded = false;

    private static GameSparker gsPanel;

    /**
     * Loads models.zip
     */
    static private void loadbase() {
        if (carRads.length < xtGraphics.nCars)
            throw new RuntimeException("too many cars and not enough rad files!");
        int totalSize = 0;
        xtGraphics.dnload += 6;
        try {
            FileUtil.loadFiles("data/cars", carRads, prep -> {
                return new File(prep.parent, prep.file + ".rad").toPath();
            }, (is, id) -> {
                carContos[id] = new ContO(is);
                if (!carContos[id].shadow) {
                    throw new RuntimeException("car " + CarDefine.names[id] + " does not have a shadow");
                }
            });

            FileUtil.loadFiles("data/stageparts", stageRads, prep -> {
                return new File(prep.parent, prep.file + ".rad").toPath();
            }, (is, id) -> {
                contos[id] = new ContO(is);
            });
            
            xtGraphics.dnload++;
            
            for (int i = 0; i < stageRads.length; i++) {
                if (contos[i] == null) {
                    throw new Error("No valid ContO (Stage Part) has been assigned to ID " + i + " (" + stageRads[i] + ")");
                }
            }
            for (int i = 0; i < carRads.length; i++) {
                if (carContos[i] == null) {
                    throw new Error("No valid ContO (Vehicle) has been assigned to ID " + i + " (" + stageRads[i] + ")");
                }
            }

        } catch (final Exception exception) {
            if (exception instanceof RuntimeException)
                throw new RuntimeException("Intentional error loading models.zip", exception);
            else {
                System.err.println("Error Reading Models: " + exception);
                exception.printStackTrace();
                new Thread(() -> {
                    new Thread(() -> { // if no response in 20s, force terminate
                        try {
                            Thread.sleep(20_000L);
                        } catch (InterruptedException ignored) {
                        }
                        System.exit(1);
                    });
                    JOptionPane.showMessageDialog(null, "Fatal error loading models.zip:\n" + exception + "\n(Stack trace in console)", "Fatal error", JOptionPane.ERROR_MESSAGE);
                    System.exit(1);
                }).start();
            }
        }
        System.gc();
        if (mload != -1 && totalSize != 615671) {
            mload = 2;
        }
    }

    private static BufferedImage createOffImage() {
        try {
            BufferedImage _offImage = gfxConfig.createCompatibleImage(800, 450, Transparency.OPAQUE);

            if (_offImage == null)
                throw new AssertionError("this should never happen");
            return _offImage;
        } catch (final Throwable e) { //fallback image creation
            e.printStackTrace();

            return new BufferedImage(800, 450, BufferedImage.TYPE_INT_RGB);
        }
    }

    /**
     * Loads stage currently set by checkpoints.stage onto stageContos
     */
    static private void loadstage() {
        if (xtGraphics.testdrive == 2 || xtGraphics.testdrive == 4) {
            xtGraphics.nplayers = 1;
        }
        xtGraphics.nplayers = 7;
        /*if (xtgraphics.gmode == 1) {
        	xtgraphics.nplayers = 5;
        	xtgraphics.xstart[4] = 0;
        	xtgraphics.zstart[4] = 760;
        }*/
        Trackers.nt = 0;
        nob = xtGraphics.nplayers;
        notb = 0;
        CheckPoints.n = 0;
        CheckPoints.nsp = 0;
        CheckPoints.fn = 0;
        CheckPoints.trackname = "";
        CheckPoints.haltall = false;
        CheckPoints.wasted = 0;
        CheckPoints.catchfin = 0;
        Medium.resdown = 0;
        Medium.rescnt = 5;
        Medium.lightson = false;
        Medium.noelec = 0;
        Medium.ground = 250;
        Medium.trk = 0;
        view = 0;
        int i = 0;
        int k = 100;
        int l = 0;
        int m = 100;
        xtGraphics.newparts = false;
        String string = "";
        try {
            BufferedReader stageDataReader;
            if (xtGraphics.multion == 0 && CheckPoints.stage != -2) {
                String customStagePath = "stages/" + CheckPoints.stage + "";
                if (CheckPoints.stage == -1) {
                    customStagePath = "mystages/" + CheckPoints.name + "";
                }
                final File customStageFile = new File("" + Madness.fpath + "" + customStagePath + ".txt");
                stageDataReader = new BufferedReader(new InputStreamReader(new DataInputStream(new FileInputStream(customStageFile))));
            } else if (CheckPoints.stage > 0) {
                final URL url = new URL("http://multiplayer.needformadness.com/stages/" + CheckPoints.stage + ".txt");
                stageDataReader = new BufferedReader(new InputStreamReader(new DataInputStream(url.openStream())));
            } else {
                String stagelink = "http://multiplayer.needformadness.com/tracks/" + CheckPoints.name + ".radq";
                stagelink = stagelink.replace(' ', '_');
                final URL url = new URL(stagelink);
                final int connectionlength = url.openConnection().getContentLength();
                final DataInputStream datainputstream = new DataInputStream(url.openStream());
                final byte[] is = new byte[connectionlength];
                datainputstream.readFully(is);
                ZipInputStream zipinputstream;
                if (is[0] == 80 && is[1] == 75 && is[2] == 3) {
                    zipinputstream = new ZipInputStream(new ByteArrayInputStream(is));
                } else {
                    final byte[] is2 = new byte[connectionlength - 40];
                    for (int n = 0; n < connectionlength - 40; n++) {
                        int o = 20;
                        if (n >= 500) {
                            o = 40;
                        }
                        is2[n] = is[n + o];
                    }
                    zipinputstream = new ZipInputStream(new ByteArrayInputStream(is2));
                }
                final ZipEntry zipentry = zipinputstream.getNextEntry();
                int n = Integer.parseInt(zipentry.getName());
                final byte[] is2 = new byte[n];
                int o = 0;
                int p;
                for (; n > 0; n -= p) {
                    p = zipinputstream.read(is2, o, n);
                    o += p;
                }
                zipinputstream.close();
                datainputstream.close();
                stageDataReader = new BufferedReader(new InputStreamReader(new DataInputStream(new ByteArrayInputStream(is2))));
            }
            String line;
            while ((line = stageDataReader.readLine()) != null) {
                string = "" + line.trim();
                if (string.startsWith("snap")) {
                    Medium.setsnap(getint("snap", string, 0), getint("snap", string, 1), getint("snap", string, 2));
                }
                if (string.startsWith("sky")) {
                    Medium.setsky(getint("sky", string, 0), getint("sky", string, 1), getint("sky", string, 2));
                    xtGraphics.snap(CheckPoints.stage);
                }
                if (string.startsWith("ground")) {
                    Medium.setgrnd(getint("ground", string, 0), getint("ground", string, 1), getint("ground", string, 2));
                }
                if (string.startsWith("polys")) {
                    Medium.setpolys(getint("polys", string, 0), getint("polys", string, 1), getint("polys", string, 2));
                }
                if (string.startsWith("fog")) {
                    Medium.setfade(getint("fog", string, 0), getint("fog", string, 1), getint("fog", string, 2));
                }
                if (string.startsWith("texture")) {
                    Medium.setexture(getint("texture", string, 0), getint("texture", string, 1), getint("texture", string, 2), getint("texture", string, 3));
                }
                if (string.startsWith("clouds")) {
                    Medium.setcloads(getint("clouds", string, 0), getint("clouds", string, 1), getint("clouds", string, 2), getint("clouds", string, 3), getint("clouds", string, 4));
                }
                if (string.startsWith("density")) {
                    Medium.fogd = (getint("density", string, 0) + 1) * 2 - 1;
                    if (Medium.fogd < 1) {
                        Medium.fogd = 1;
                    }
                    if (Medium.fogd > 30) {
                        Medium.fogd = 30;
                    }
                }
                if (string.startsWith("fadefrom")) {
                    Medium.fadfrom(getint("fadefrom", string, 0));
                }
                if (string.startsWith("lightson")) {
                    Medium.lightson = true;
                }
                if (string.startsWith("mountains")) {
                    Medium.mgen = getint("mountains", string, 0);
                }
                if (string.startsWith("set")) {
                    int setindex = getint("set", string, 0);
                    if (xtGraphics.nplayers == 8) {
                        if (setindex == 47) {
                            setindex = 76;
                        }
                        if (setindex == 48) {
                            setindex = 77;
                        }
                    }
                    boolean bool = true;
                    if (setindex >= 65 && setindex <= 75 && CheckPoints.notb) {
                        bool = false;
                    }
                    if (bool) {
                        if (setindex == 49 || setindex == 64 || setindex >= 56 && setindex <= 61) {
                            xtGraphics.newparts = true;
                        }
                        if ((CheckPoints.stage < 0 || CheckPoints.stage >= 28) && setindex >= 10 && setindex <= 25) {
                            Medium.loadnew = true;
                        }
                        setindex -= 10;
                        System.out.println("Setindex is: " + setindex);
                        stageContos[nob] = new ContO(contos[setindex], getint("set", string, 1), Medium.ground - contos[setindex].grat, getint("set", string, 2), getint("set", string, 3));
                        if (string.contains(")p")) {
                            CheckPoints.x[CheckPoints.n] = getint("set", string, 1);
                            CheckPoints.z[CheckPoints.n] = getint("set", string, 2);
                            CheckPoints.y[CheckPoints.n] = 0;
                            CheckPoints.typ[CheckPoints.n] = 0;
                            if (string.contains(")pt")) {
                                CheckPoints.typ[CheckPoints.n] = -1;
                            }
                            if (string.contains(")pr")) {
                                CheckPoints.typ[CheckPoints.n] = -2;
                            }
                            if (string.contains(")po")) {
                                CheckPoints.typ[CheckPoints.n] = -3;
                            }
                            if (string.contains(")ph")) {
                                CheckPoints.typ[CheckPoints.n] = -4;
                            }
                            if (string.contains("out")) {
                                System.out.println("out: " + CheckPoints.n);
                            }
                            CheckPoints.n++;
                            notb = nob + 1;
                        }
                        nob++;
                        if (Medium.loadnew) {
                            Medium.loadnew = false;
                        }
                    }
                }
                if (string.startsWith("chk")) {
                    int chkindex = getint("chk", string, 0);
                    chkindex -= 10;
                    int chkheight = Medium.ground - contos[chkindex].grat;
                    if (chkindex == 110) {
                        chkheight = getint("chk", string, 4);
                    }
                    stageContos[nob] = new ContO(contos[chkindex], getint("chk", string, 1), chkheight, getint("chk", string, 2), getint("chk", string, 3));
                    CheckPoints.x[CheckPoints.n] = getint("chk", string, 1);
                    CheckPoints.z[CheckPoints.n] = getint("chk", string, 2);
                    CheckPoints.y[CheckPoints.n] = chkheight;
                    if (getint("chk", string, 3) == 0) {
                        CheckPoints.typ[CheckPoints.n] = 1;
                    } else {
                        CheckPoints.typ[CheckPoints.n] = 2;
                    }
                    CheckPoints.pcs = CheckPoints.n;
                    CheckPoints.n++;
                    stageContos[nob].checkpoint = CheckPoints.nsp + 1;
                    CheckPoints.nsp++;
                    nob++;
                    notb = nob;
                }
                if (CheckPoints.nfix != 5 && string.startsWith("fix")) {
                    int fixindex = getint("fix", string, 0);
                    fixindex -= 10;
                    stageContos[nob] = new ContO(contos[fixindex], getint("fix", string, 1), getint("fix", string, 3), getint("fix", string, 2), getint("fix", string, 4));
                    CheckPoints.fx[CheckPoints.fn] = getint("fix", string, 1);
                    CheckPoints.fz[CheckPoints.fn] = getint("fix", string, 2);
                    CheckPoints.fy[CheckPoints.fn] = getint("fix", string, 3);
                    stageContos[nob].elec = true;
                    if (getint("fix", string, 4) != 0) {
                        CheckPoints.roted[CheckPoints.fn] = true;
                        stageContos[nob].roted = true;
                    } else {
                        CheckPoints.roted[CheckPoints.fn] = false;
                    }
                    CheckPoints.special[CheckPoints.fn] = string.indexOf(")s") != -1;
                    CheckPoints.fn++;
                    nob++;
                    notb = nob;
                }
                if (!CheckPoints.notb && string.startsWith("pile")) {
                    stageContos[nob] = new ContO(getint("pile", string, 0), getint("pile", string, 1), getint("pile", string, 2), getint("pile", string, 3), getint("pile", string, 4), Medium.ground);
                    nob++;
                }
                if (xtGraphics.multion == 0 && string.startsWith("nlaps")) {
                    CheckPoints.nlaps = getint("nlaps", string, 0);
                }
                //if (checkpoints.nlaps < 1)
                //	checkpoints.nlaps = 1;
                //if (checkpoints.nlaps > 15)
                //	checkpoints.nlaps = 15;
                if (CheckPoints.stage > 0 && string.startsWith("name")) {
                    CheckPoints.name = getstring("name", string, 0).replace('|', ',');
                }
                if (string.startsWith("stagemaker")) {
                    CheckPoints.maker = getstring("stagemaker", string, 0);
                }
                if (string.startsWith("publish")) {
                    CheckPoints.pubt = getint("publish", string, 0);
                }
                if (string.startsWith("soundtrack")) {
                    CheckPoints.trackname = getstring("soundtrack", string, 0);
                    CheckPoints.trackvol = getint("soundtrack", string, 1);
                    if (CheckPoints.trackvol < 50) {
                        CheckPoints.trackvol = 50;
                    }
                    if (CheckPoints.trackvol > 300) {
                        CheckPoints.trackvol = 300;
                    }
                    xtGraphics.sndsize[32] = getint("soundtrack", string, 2);
                }
                if (string.startsWith("maxr")) {
                    final int n = getint("maxr", string, 0);
                    final int o = getint("maxr", string, 1);
                    i = o;
                    final int p = getint("maxr", string, 2);
                    for (int q = 0; q < n; q++) {
                        stageContos[nob] = new ContO(contos[29], o, Medium.ground - contos[29].grat, //29 may need to be 85 or xtgraphics.nCars - 16
                        q * 4800 + p, 0);
                        nob++;
                    }
                    Trackers.y[Trackers.nt] = -5000;
                    Trackers.rady[Trackers.nt] = 7100;
                    Trackers.x[Trackers.nt] = o + 500;
                    Trackers.radx[Trackers.nt] = 600;
                    Trackers.z[Trackers.nt] = n * 4800 / 2 + p - 2400;
                    Trackers.radz[Trackers.nt] = n * 4800 / 2;
                    Trackers.xy[Trackers.nt] = 90;
                    Trackers.zy[Trackers.nt] = 0;
                    Trackers.dam[Trackers.nt] = 167;
                    Trackers.decor[Trackers.nt] = false;
                    Trackers.skd[Trackers.nt] = 0;
                    Trackers.nt++;
                }
                if (string.startsWith("maxl")) {
                    final int n = getint("maxl", string, 0);
                    final int o = getint("maxl", string, 1);
                    k = o;
                    final int p = getint("maxl", string, 2);
                    for (int q = 0; q < n; q++) {
                        stageContos[nob] = new ContO(contos[29], o, Medium.ground - contos[29].grat, q * 4800 + p, 180);
                        nob++;
                    }
                    Trackers.y[Trackers.nt] = -5000;
                    Trackers.rady[Trackers.nt] = 7100;
                    Trackers.x[Trackers.nt] = o - 500;
                    Trackers.radx[Trackers.nt] = 600;
                    Trackers.z[Trackers.nt] = n * 4800 / 2 + p - 2400;
                    Trackers.radz[Trackers.nt] = n * 4800 / 2;
                    Trackers.xy[Trackers.nt] = -90;
                    Trackers.zy[Trackers.nt] = 0;
                    Trackers.dam[Trackers.nt] = 167;
                    Trackers.decor[Trackers.nt] = false;
                    Trackers.skd[Trackers.nt] = 0;
                    Trackers.nt++;
                }
                if (string.startsWith("maxt")) {
                    final int n = getint("maxt", string, 0);
                    final int o = getint("maxt", string, 1);
                    l = o;
                    final int p = getint("maxt", string, 2);
                    for (int q = 0; q < n; q++) {
                        stageContos[nob] = new ContO(contos[29], q * 4800 + p, Medium.ground - contos[29].grat, o, 90);
                        nob++;
                    }
                    Trackers.y[Trackers.nt] = -5000;
                    Trackers.rady[Trackers.nt] = 7100;
                    Trackers.z[Trackers.nt] = o + 500;
                    Trackers.radz[Trackers.nt] = 600;
                    Trackers.x[Trackers.nt] = n * 4800 / 2 + p - 2400;
                    Trackers.radx[Trackers.nt] = n * 4800 / 2;
                    Trackers.zy[Trackers.nt] = 90;
                    Trackers.xy[Trackers.nt] = 0;
                    Trackers.dam[Trackers.nt] = 167;
                    Trackers.decor[Trackers.nt] = false;
                    Trackers.skd[Trackers.nt] = 0;
                    Trackers.nt++;
                }
                if (string.startsWith("maxb")) {
                    final int n = getint("maxb", string, 0);
                    final int o = getint("maxb", string, 1);
                    m = o;
                    final int p = getint("maxb", string, 2);
                    for (int q = 0; q < n; q++) {
                        stageContos[nob] = new ContO(contos[29], q * 4800 + p, Medium.ground - contos[29].grat, o, -90);
                        nob++;
                    }
                    Trackers.y[Trackers.nt] = -5000;
                    Trackers.rady[Trackers.nt] = 7100;
                    Trackers.z[Trackers.nt] = o - 500;
                    Trackers.radz[Trackers.nt] = 600;
                    Trackers.x[Trackers.nt] = n * 4800 / 2 + p - 2400;
                    Trackers.radx[Trackers.nt] = n * 4800 / 2;
                    Trackers.zy[Trackers.nt] = -90;
                    Trackers.xy[Trackers.nt] = 0;
                    Trackers.dam[Trackers.nt] = 167;
                    Trackers.decor[Trackers.nt] = false;
                    Trackers.skd[Trackers.nt] = 0;
                    Trackers.nt++;
                }
            }
            stageDataReader.close();
            Medium.newpolys(k, i - k, m, l - m,  notb);
            Medium.newclouds(k, i, m, l);
            Medium.newmountains(k, i, m, l);
            Medium.newstars();
            Trackers.devidetrackers(k, i - k, m, l - m);
        } catch (final Exception exception) {
            System.out.println("Error in stage " + CheckPoints.stage);
            System.out.println("At line: " + string);
            CheckPoints.stage = -3;
            exception.printStackTrace();
        }
        if (CheckPoints.nsp < 2) {
            CheckPoints.stage = -3;
        }
        if (Medium.nrw * Medium.ncl >= 16000) {
            CheckPoints.stage = -3;
        }
        if (CheckPoints.stage != -3) {
            CheckPoints.top20 = Math.abs(CheckPoints.top20);
            if (CheckPoints.stage == 26) {
                Medium.lightn = 0;
            } else {
                Medium.lightn = -1;
            }
            Medium.nochekflk = !(CheckPoints.stage == 1 || CheckPoints.stage == 11);
            for (int n = 0; n < xtGraphics.nplayers; n++) {
                u[n].reset(xtGraphics.sc[n]);
                mads[n].setStat(new Stat(xtGraphics.sc[n]));
            }
            xtGraphics.resetstat(CheckPoints.stage);
            CheckPoints.calprox();

            for (int j = 0; j < xtGraphics.nplayers; j++) {

                if (xtGraphics.fase == 22) {
                    xtGraphics.colorCar(carContos[xtGraphics.sc[j]], j);
                }
                stageContos[j] = new ContO(carContos[xtGraphics.sc[j]], xtGraphics.xstart[j], 250 - carContos[xtGraphics.sc[j]].grat, xtGraphics.zstart[j], 0);
                mads[j].reseto(xtGraphics.sc[j], stageContos[j]);
            }
            if (xtGraphics.fase == 2 || xtGraphics.fase == -22) {
                Medium.trx = (k + i) / 2;
                Medium.trz = (l + m) / 2;
                Medium.ptr = 0;
                Medium.ptcnt = -10;
                Medium.hit = 45000;
                Medium.fallen = 0;
                Medium.nrnd = 0;
                Medium.trk = 1;
                Medium.ih = 25;
                Medium.iw = 65;
                Medium.h = 425;
                Medium.w = 735;
                xtGraphics.fase = 1;
                mouses = 0;
            }
            if (xtGraphics.fase == 22) {
                Medium.crs = false;
                xtGraphics.fase = 5;
            }
            if (CheckPoints.stage > 0) {
                xtGraphics.asay = "Stage " + CheckPoints.stage + ":  " + CheckPoints.name + " ";
            } else {
                xtGraphics.asay = "Custom Stage:  " + CheckPoints.name + " ";
            }
            Record.reset(stageContos);
        } else if (xtGraphics.fase == 2) {
            xtGraphics.fase = 1;
        }
        System.gc();
    }

    static private boolean loadstagePreview(final int i, final String string, final ContO[] contos, final ContO[] contos147) {
        boolean bool = true;
        if (i < 100) {
            CheckPoints.stage = i;
            if (CheckPoints.stage < 0) {
                CheckPoints.name = string;
            }
        } else {
            CheckPoints.stage = -2;
            if (sgame.getSelectedIndex() == 3 || sgame.getSelectedIndex() == 4) {
                CheckPoints.name = mstgs.getSelectedItem();
            } else {
                final int i148 = mstgs.getSelectedItem().indexOf(' ') + 1;
                if (i148 > 0) {
                    CheckPoints.name = mstgs.getSelectedItem().substring(i148);
                }
            }
        }
        nob = 0;
        CheckPoints.n = 0;
        CheckPoints.nsp = 0;
        CheckPoints.fn = 0;
        CheckPoints.haltall = false;
        CheckPoints.wasted = 0;
        CheckPoints.catchfin = 0;
        Medium.ground = 250;
        view = 0;
        Medium.trx = 0L;
        Medium.trz = 0L;
        int i149 = 0;
        int i150 = 100;
        int i151 = 0;
        int i152 = 100;
        String string153 = "";
        try {
            BufferedReader datainputstream;
            if (CheckPoints.stage > 0) {
                final URL url = new URL("http://multiplayer.needformadness.com/stages/" + CheckPoints.stage + ".txt");
                datainputstream = new BufferedReader(new InputStreamReader(new DataInputStream(url.openStream())));
            } else {
                String string154 = "http://multiplayer.needformadness.com/tracks/" + CheckPoints.name + ".radq";
                string154 = string154.replace(' ', '_');
                final URL url = new URL(string154);
                final int i155 = url.openConnection().getContentLength();
                final DataInputStream datainputstream156 = new DataInputStream(url.openStream());
                final byte[] is = new byte[i155];
                datainputstream156.readFully(is);
                ZipInputStream zipinputstream;
                if (is[0] == 80 && is[1] == 75 && is[2] == 3) {
                    zipinputstream = new ZipInputStream(new ByteArrayInputStream(is));
                } else {
                    final byte[] is157 = new byte[i155 - 40];
                    for (int i158 = 0; i158 < i155 - 40; i158++) {
                        int i159 = 20;
                        if (i158 >= 500) {
                            i159 = 40;
                        }
                        is157[i158] = is[i158 + i159];
                    }
                    zipinputstream = new ZipInputStream(new ByteArrayInputStream(is157));
                }
                final ZipEntry zipentry = zipinputstream.getNextEntry();
                int i160 = Integer.parseInt(zipentry.getName());
                final byte[] is161 = new byte[i160];
                int i162 = 0;
                int i163;
                for (; i160 > 0; i160 -= i163) {
                    i163 = zipinputstream.read(is161, i162, i160);
                    i162 += i163;
                }
                zipinputstream.close();
                datainputstream156.close();
                datainputstream = new BufferedReader(new InputStreamReader(new DataInputStream(new ByteArrayInputStream(is161))));
            }
            String string164;
            while ((string164 = datainputstream.readLine()) != null) {
                string153 = "" + string164.trim();
                if (string153.startsWith("snap")) {
                    Medium.setsnap(getint("snap", string153, 0), getint("snap", string153, 1), getint("snap", string153, 2));
                }
                if (string153.startsWith("sky")) {
                    Medium.setsky(getint("sky", string153, 0), getint("sky", string153, 1), getint("sky", string153, 2));
                }
                if (string153.startsWith("ground")) {
                    Medium.setgrnd(getint("ground", string153, 0), getint("ground", string153, 1), getint("ground", string153, 2));
                }
                if (string153.startsWith("polys")) {
                    Medium.setpolys(getint("polys", string153, 0), getint("polys", string153, 1), getint("polys", string153, 2));
                }
                if (string153.startsWith("fog")) {
                    Medium.setfade(getint("fog", string153, 0), getint("fog", string153, 1), getint("fog", string153, 2));
                }
                if (string153.startsWith("texture")) {
                    Medium.setexture(getint("texture", string153, 0), getint("texture", string153, 1), getint("texture", string153, 2), getint("texture", string153, 3));
                }
                if (string153.startsWith("clouds")) {
                    Medium.setcloads(getint("clouds", string153, 0), getint("clouds", string153, 1), getint("clouds", string153, 2), getint("clouds", string153, 3), getint("clouds", string153, 4));
                }
                if (string153.startsWith("density")) {
                    Medium.fogd = (getint("density", string153, 0) + 1) * 2 - 1;
                    if (Medium.fogd < 1) {
                        Medium.fogd = 1;
                    }
                    if (Medium.fogd > 30) {
                        Medium.fogd = 30;
                    }
                }
                if (string153.startsWith("fadefrom")) {
                    Medium.fadfrom(getint("fadefrom", string153, 0));
                }
                if (string153.startsWith("lightson")) {
                    Medium.lightson = true;
                }
                if (string153.startsWith("mountains")) {
                    Medium.mgen = getint("mountains", string153, 0);
                }
                if (string153.startsWith("soundtrack")) {
                    CheckPoints.trackname = getstring("soundtrack", string153, 0);
                    CheckPoints.trackvol = getint("soundtrack", string153, 1);
                    if (CheckPoints.trackvol < 50) {
                        CheckPoints.trackvol = 50;
                    }
                    if (CheckPoints.trackvol > 300) {
                        CheckPoints.trackvol = 300;
                    }
                }
                if (string153.startsWith("set")) {
                    int i165 = getint("set", string153, 0);
                    i165 -= 10;
                    contos[nob] = new ContO(contos147[i165], getint("set", string153, 1), Medium.ground - contos147[i165].grat, getint("set", string153, 2), getint("set", string153, 3));
                    Trackers.nt = 0;
                    if (string153.contains(")p")) {
                        CheckPoints.x[CheckPoints.n] = getint("chk", string153, 1);
                        CheckPoints.z[CheckPoints.n] = getint("chk", string153, 2);
                        CheckPoints.y[CheckPoints.n] = 0;
                        CheckPoints.typ[CheckPoints.n] = 0;
                        if (string153.contains(")pt")) {
                            CheckPoints.typ[CheckPoints.n] = -1;
                        }
                        if (string153.contains(")pr")) {
                            CheckPoints.typ[CheckPoints.n] = -2;
                        }
                        if (string153.contains(")po")) {
                            CheckPoints.typ[CheckPoints.n] = -3;
                        }
                        if (string153.contains(")ph")) {
                            CheckPoints.typ[CheckPoints.n] = -4;
                        }
                        if (string153.contains("out")) {
                            System.out.println("out: " + CheckPoints.n);
                        }
                        CheckPoints.n++;
                    }
                    nob++;
                }
                if (string153.startsWith("chk")) {
                    int i166 = getint("chk", string153, 0);
                    i166 -= 10;
                    int i167 = Medium.ground - contos147[i166].grat;
                    if (i166 == 110) {
                        i167 = getint("chk", string153, 4);
                    }
                    contos[nob] = new ContO(contos147[i166], getint("chk", string153, 1), i167, getint("chk", string153, 2), getint("chk", string153, 3));
                    CheckPoints.x[CheckPoints.n] = getint("chk", string153, 1);
                    CheckPoints.z[CheckPoints.n] = getint("chk", string153, 2);
                    CheckPoints.y[CheckPoints.n] = i167;
                    if (getint("chk", string153, 3) == 0) {
                        CheckPoints.typ[CheckPoints.n] = 1;
                    } else {
                        CheckPoints.typ[CheckPoints.n] = 2;
                    }
                    CheckPoints.pcs = CheckPoints.n;
                    CheckPoints.n++;
                    contos[nob].checkpoint = CheckPoints.nsp + 1;
                    CheckPoints.nsp++;
                    nob++;
                }
                if (string153.startsWith("fix")) {
                    int i168 = getint("fix", string153, 0);
                    i168 -= 10;
                    contos[nob] = new ContO(contos147[i168], getint("fix", string153, 1), getint("fix", string153, 3), getint("fix", string153, 2), getint("fix", string153, 4));
                    CheckPoints.fx[CheckPoints.fn] = getint("fix", string153, 1);
                    CheckPoints.fz[CheckPoints.fn] = getint("fix", string153, 2);
                    CheckPoints.fy[CheckPoints.fn] = getint("fix", string153, 3);
                    contos[nob].elec = true;
                    if (getint("fix", string153, 4) != 0) {
                        CheckPoints.roted[CheckPoints.fn] = true;
                        contos[nob].roted = true;
                    } else {
                        CheckPoints.roted[CheckPoints.fn] = false;
                    }
                    CheckPoints.special[CheckPoints.fn] = string153.contains(")s");
                    CheckPoints.fn++;
                    nob++;
                }
                if (string153.startsWith("nlaps")) {
                    CheckPoints.nlaps = getint("nlaps", string153, 0);
                    if (CheckPoints.nlaps < 1) {
                        CheckPoints.nlaps = 1;
                    }
                    if (CheckPoints.nlaps > 15) {
                        CheckPoints.nlaps = 15;
                    }
                }
                if (CheckPoints.stage > 0 && string153.startsWith("name")) {
                    CheckPoints.name = getstring("name", string153, 0).replace('|', ',');
                }
                if (string153.startsWith("stagemaker")) {
                    CheckPoints.maker = getstring("stagemaker", string153, 0);
                }
                if (string153.startsWith("publish")) {
                    CheckPoints.pubt = getint("publish", string153, 0);
                }
                if (string153.startsWith("maxr")) {
                    i149 = getint("maxr", string153, 1);
                }
                //i149 = i169;
                if (string153.startsWith("maxl")) {
                    i150 = getint("maxl", string153, 1);
                }
                //i150 = i170;
                if (string153.startsWith("maxt")) {
                    i151 = getint("maxt", string153, 1);
                }
                //i151 = i171;
                if (string153.startsWith("maxb")) {
                    i152 = getint("maxb", string153, 1);
                    //i152 = i172;
                }
            }
            datainputstream.close();
            Medium.newpolys(i150, i149 - i150, i152, i151 - i152, notb);
            Medium.newclouds(i150, i149, i152, i151);
            Medium.newmountains(i150, i149, i152, i151);
            Medium.newstars();
        } catch (final Exception exception) {
            bool = false;
            System.out.println("Error in stage " + CheckPoints.stage);
            System.out.println("" + exception);
            System.out.println("At line: " + string153);
        }
        if (CheckPoints.nsp < 2) {
            bool = false;
        }
        if (Medium.nrw * Medium.ncl >= 16000) {
            bool = false;
        }
        Medium.trx = (i150 + i149) / 2;
        Medium.trz = (i151 + i152) / 2;
        System.gc();
        return bool;
    }

    /**
     * handles clicking the 'Radical Play' link
     */
    static private void catchlink() {
        if (!lostfcs)
            if (xm > 65 && xm < 735 && ym > 135 && ym < 194 || xm > 275 && xm < 525 && ym > 265 && ym < 284) {
                gsPanel.setCursor(new Cursor(12));
                if (mouses == 2) {
                    openurl("http://www.radicalplay.com/");
                }
            } else {
                gsPanel.setCursor(new Cursor(0));
            }
    }

    static private void checkmemory() {
        if (applejava || Runtime.getRuntime().freeMemory() / 1048576L < 50L) {
            xtGraphics.badmac = true;
        }
    }

    /**
     * I forgot what this does lmao
     *
     * @param graphics2d graphics2d object
     * @param x X position
     * @param y Y position
     */
    static private void cropit(final Graphics2D graphics2d, final int x, final int y) {
        if (x != 0 || y != 0) {
            graphics2d.setComposite(AlphaComposite.getInstance(3, 1.0F));
            graphics2d.setColor(new Color(0, 0, 0));
        }
        if (x != 0)
            if (x < 0) {
                graphics2d.fillRect(apx + x, apy - (int) (25.0F * apmult), Math.abs(x), (int) (500.0F * apmult));
            } else {
                graphics2d.fillRect(apx + (int) (800.0F * apmult), apy - (int) (25.0F * apmult), x, (int) (500.0F * apmult));
            }
        if (y != 0)
            if (y < 0) {
                graphics2d.fillRect(apx - (int) (25.0F * apmult), apy + y, (int) (850.0F * apmult), Math.abs(y));
            } else {
                graphics2d.fillRect(apx - (int) (25.0F * apmult), apy + (int) (450.0F * apmult), (int) (850.0F * apmult), y);
            }
    }

    /**
     * Draws SMenus
     */
    static void drawms() {
        openm = gmode.draw(rd, xm, ym, moused, 450, true);
        if (swait.draw(rd, xm, ym, moused, 450, false)) {
            openm = true;
        }
        if (slaps.draw(rd, xm, ym, moused, 450, false)) {
            openm = true;
        }
        if (snpls.draw(rd, xm, ym, moused, 450, false)) {
            openm = true;
        }
        if (snbts.draw(rd, xm, ym, moused, 450, false)) {
            openm = true;
        }
        if (scars.draw(rd, xm, ym, moused, 450, false)) {
            openm = true;
        }
        if (sgame.draw(rd, xm, ym, moused, 450, false)) {
            openm = true;
        }
        //if (snfm1.draw(rd, xm, ym, moused, 450, false))
        //  openm = true;
        //if (snfm2.draw(rd, xm, ym, moused, 450, false))
        //  openm = true;
        if (snfmm.draw(rd, xm, ym, moused, 450, false)) {
            openm = true;
        }
        if (mstgs.draw(rd, xm, ym, moused, 450, false)) {
            openm = true;
        }
        if (mcars.draw(rd, xm, ym, moused, 450, false)) {
            openm = true;
        }
        if (pgame.draw(rd, xm, ym, moused, 450, false)) {
            openm = true;
        }
        if (vnpls.draw(rd, xm, ym, moused, 450, false)) {
            openm = true;
        }
        if (vtyp.draw(rd, xm, ym, moused, 450, false)) {
            openm = true;
        }
        if (warb.draw(rd, xm, ym, moused, 450, false)) {
            openm = true;
        }
        if (wgame.draw(rd, xm, ym, moused, 450, false)) {
            openm = true;
        }
        if (rooms.draw(rd, xm, ym, moused, 450, false)) {
            openm = true;
        }
        if (sendtyp.draw(rd, xm, ym, moused, 450, true)) {
            openm = true;
        }
        if (senditem.draw(rd, xm, ym, moused, 450, true)) {
            openm = true;
        }
        if (datat.draw(rd, xm, ym, moused, 450, true)) {
            openm = true;
        }
        if (clanlev.draw(rd, xm, ym, moused, 450, false)) {
            openm = true;
        }
        if (clcars.draw(rd, xm, ym, moused, 450, false)) {
            openm = true;
        }
        if (ilaps.draw(rd, xm, ym, moused, 450, true)) {
            openm = true;
        }
        if (icars.draw(rd, xm, ym, moused, 450, true)) {
            openm = true;
        }
        if (proitem.draw(rd, xm, ym, moused, 450, false)) {
            openm = true;
        }
        if (sfix.draw(rd, xm, ym, moused, 450, false)) {
            openm = true;
        }
        if (sclass.draw(rd, xm, ym, moused, 450, false)) {
            openm = true;
        }
    }

    static void editlink(final String accountid, final boolean isLogged) {
        String logged = "";
        if (isLogged) {
            logged = "?display=upgrade";
        }
        openurl("http://multiplayer.needformadness.com/edit.pl" + logged + "#" + accountid + "");
    }

    static private int getint(final String string, final String string4, final int i) {
        int j = 0;
        String string2 = "";
        for (int k = string.length() + 1; k < string4.length(); k++) {
            final String string3 = "" + string4.charAt(k);
            if (string3.equals(",") || string3.equals(")")) {
                j++;
                k++;
            }
            if (j == i) {
                string2 = string2 + string4.charAt(k);
            }
        }
        return Integer.parseInt(string2);
    }

    /**
     * Gets string in format: {@code <string2>} string(A,B,1231,{@code i},C,1.5) {@code </string2>}
     *
     * @param string the tag
     * @param string2 the whole line
     * @param i the position of the string
     * @return tthe string at the position
     */
    static private String getstring(final String string, final String string2, final int i) {
        int j = 0;
        String string3 = "";
        for (int k = string.length() + 1; k < string2.length(); k++) {
            final String string4 = "" + string2.charAt(k);
            if (string4.equals(",") || string4.equals(")")) {
                j++;
                k++;
            }
            if (j == i) {
                string3 = string3 + string2.charAt(k);
            }
        }
        return string3;
    }

    /**
     * Hides SMenus
     */
    static private void hidefields() {
        ilaps.setVisible(false);
        icars.setVisible(false);
        proitem.setVisible(false);
        clcars.setVisible(false);
        clanlev.setVisible(false);
        mmsg.setVisible(false);
        datat.setVisible(false);
        senditem.setVisible(false);
        sendtyp.setVisible(false);
        rooms.setVisible(false);
        mcars.setVisible(false);
        mstgs.setVisible(false);
        gmode.setVisible(false);
        sclass.setVisible(false);
        scars.setVisible(false);
        sfix.setVisible(false);
        mycar.setVisible(false);
        notp.setVisible(false);
        keplo.setVisible(false);
        tnick.setVisible(false);
        tpass.setVisible(false);
        temail.setVisible(false);
        cmsg.setVisible(false);
        sgame.setVisible(false);
        wgame.setVisible(false);
        pgame.setVisible(false);
        vnpls.setVisible(false);
        vtyp.setVisible(false);
        warb.setVisible(false);
        slaps.setVisible(false);
        //snfm1.setVisible(false);
        snfmm.setVisible(false);
        //snfm2.setVisible(false);
        snpls.setVisible(false);
        snbts.setVisible(false);
        swait.setVisible(false);
    }

    //@Override
    static private void initFields() {
        tnick = new TextField("Nickbname");
        tnick.setFont(new Font("Arial", 1, 13));
        tpass = new TextField("");
        tpass.setFont(new Font("Arial", 1, 13));
        tpass.setEchoChar('*');
        temail = new TextField("");
        temail.setFont(new Font("Arial", 1, 13));
        cmsg = new TextField("");
        if (System.getProperty("java.vendor").toLowerCase().contains("oracle")) {
            cmsg.addKeyListener(new KeyAdapter() {
                @Override
                public void keyPressed(final KeyEvent e) {
                    if (e.getKeyCode() == 10 && u[0] != null) {
                        u[0].enter = true;
                    }
                }
            });
        }
        mmsg = new TextArea("", 200, 20, 3);
        cmsg.setFont(new Font("Tahoma", 0, 11));
        mmsg.setFont(new Font("Tahoma", 0, 11));
        mycar = new Checkbox("Sword of Justice Game!");
        notp = new Checkbox("No Trees & Piles");
        keplo = new Checkbox("Stay logged in");
        keplo.setState(true);
        gsPanel.add(tnick);
        gsPanel.add(tpass);
        gsPanel.add(temail);
        gsPanel.add(cmsg);
        gsPanel.add(mmsg);
        gsPanel.add(mycar);
        gsPanel.add(notp);
        gsPanel.add(keplo);
        sgame.setFont();
        wgame.setFont();
        warb.setFont();
        pgame.setFont();
        vnpls.setFont();
        vtyp.setFont();
        snfmm.setFont();
        //snfm1.setFont(new Font("Arial", 1, 13));
        //snfm2.setFont(new Font("Arial", 1, 13));
        mstgs.setFont();
        mcars.setFont();
        slaps.setFont();
        snpls.setFont();
        snbts.setFont();
        swait.setFont();
        sclass.setFont();
        scars.setFont();
        sfix.setFont();
        mycar.setFont(new Font("Arial", 1, 12));
        notp.setFont(new Font("Arial", 1, 12));
        keplo.setFont(new Font("Arial", 1, 12));
        gmode.setFont();
        rooms.setFont();
        sendtyp.setFont();
        senditem.setFont();
        datat.setFont();
        clanlev.setFont();
        clcars.setFont();
        clcars.alphad = true;
        ilaps.setFont();
        icars.setFont();
        proitem.setFont();
    }
    
    static void madlink() {
        openurl("http://www.needformadness.com/");
    }

    static public void mouseW(final int i) {
        if (!exwist) {
            mousew += i * 4;
        }
    }

    static void movefield(final Component component, int i, int i99, final int i100, final int i101) {
        if (i100 == 360 || i100 == 576) {
            i = (int) (i * apmult + apx + component.getWidth() / 2 * (apmult - 1.0F));
            i99 = (int) (i99 * apmult + apy + 12.0F * (apmult - 1.0F));
        } else {
            i = (int) (i * apmult + apx);
            i99 = (int) (i99 * apmult + apy + 12.0F * (apmult - 1.0F));
        }
        if (component.getX() != i || component.getY() != i99) {
            component.setBounds(i, i99, i100, i101);
        }
    }

    static public void movefielda(final TextArea textarea, int i, int i105, final int i106, final int i107) {
        if (applejava) {
            if (xm > i && xm < i + i106 && ym > i105 && ym < i105 + i107 || !textarea.getText().equals(" ")) {
                if (!textarea.isShowing()) {
                    textarea.setVisible(true);
                    textarea.requestFocus();
                }
                if (i106 == 360 || i106 == 576) {
                    i = (int) (i * apmult + apx + textarea.getWidth() / 2 * (apmult - 1.0F));
                    i105 = (int) (i105 * apmult + apy + 12.0F * (apmult - 1.0F));
                } else {
                    i = (int) (i * apmult + apx);
                    i105 = (int) (i105 * apmult + apy + 12.0F * (apmult - 1.0F));
                }
                if (textarea.getX() != i || textarea.getY() != i105) {
                    textarea.setBounds(i, i105, i106, i107);
                }
            } else {
                if (textarea.isShowing()) {
                    textarea.setVisible(false);
                    gsPanel.requestFocus();
                }
                rd.setColor(textarea.getBackground());
                rd.fillRect(i, i105, i106 - 1, i107 - 1);
                rd.setColor(textarea.getBackground().darker());
                rd.drawRect(i, i105, i106 - 1, i107 - 1);
            }
        } else {
            if (!textarea.isShowing()) {
                textarea.setVisible(true);
            }
            movefield(textarea, i, i105, i106, i107);
        }
    }

    static void movefieldd(final TextField textfield, int i, int i102, final int i103, final int i104, final boolean bool) {
        if (applejava) {
            if (bool)
                if (xm > i && xm < i + i103 && ym > i102 && ym < i102 + i104 || !textfield.getText().equals("")) {
                    if (!textfield.isShowing()) {
                        textfield.setVisible(true);
                        textfield.requestFocus();
                    }
                    if (i103 == 360 || i103 == 576) {
                        i = (int) (i * apmult + apx + textfield.getWidth() / 2 * (apmult - 1.0F));
                        i102 = (int) (i102 * apmult + apy + 12.0F * (apmult - 1.0F));
                    } else {
                        i = (int) (i * apmult + apx);
                        i102 = (int) (i102 * apmult + apy + 12.0F * (apmult - 1.0F));
                    }
                    if (textfield.getX() != i || textfield.getY() != i102) {
                        textfield.setBounds(i, i102, i103, i104);
                    }
                } else {
                    if (textfield.isShowing()) {
                        textfield.setVisible(false);
                        gsPanel.requestFocus();
                    }
                    rd.setColor(textfield.getBackground());
                    rd.fillRect(i, i102, i103 - 1, i104 - 1);
                    rd.setColor(textfield.getBackground().darker());
                    rd.drawRect(i, i102, i103 - 1, i104 - 1);
                }
        } else {
            if (bool && !textfield.isShowing()) {
                textfield.setVisible(true);
            }
            movefield(textfield, i, i102, i103, i104);
        }
    }

    static void multlink() {
        openurl("http://multiplayer.needformadness.com/");
    }

    static void musiclink() {
        openurl("http://multiplayer.needformadness.com/music.html");
    }

    static void onfmmlink() {
        openurl("https://github.com/chrishansen69/OpenNFMM");
    }

    static private void openurl(final String string) {
        if (Desktop.isDesktopSupported()) {
            try {
                Desktop.getDesktop().browse(new URI(string));
            } catch (final Exception ignored) {

            }
        } else {
            try {
                Runtime.getRuntime().exec("" + Madness.urlopen() + " " + string + "");
            } catch (final Exception ignored) {

            }
        }
    }

    static private void trash() {
        rd.dispose();
        xtGraphics.stopallnow();
        //cardefine.stopallnow();
        //udpmistro.UDPquit();
        System.gc();
    }

    @Override
    public void paintComponent(final Graphics g) {
        final Graphics2D g2 = (Graphics2D) g;
        g.setColor(Color.BLACK);
        g.fillRect(0, 0, getWidth(), getHeight());

        try {
            gameTick();
        } catch (final Exception e) {
            e.printStackTrace();
            exwist = true;
            trash();
            System.exit(3);
        }
        if (lastw != getWidth() || lasth != getHeight()) {
            lastw = getWidth();
            lasth = getHeight();
            showsize = 100;
            if (lastw <= 800 || lasth <= 550) {
                reqmult = 0.0F;
            }
            if (Madness.fullscreen) {
                apx = (int) (getWidth() / 2 - 400.0F * apmult);
                apy = (int) (getHeight() / 2 - 225.0F * apmult);
            }
        }
        int i = 0;
        int i97 = 0;
        if (moto == 1 && shaka > 0) {
            i = (int) ((shaka * 2 * ThreadLocalRandom.current().nextDouble() - shaka) * apmult);
            i97 = (int) ((shaka * 2 * ThreadLocalRandom.current().nextDouble() - shaka) * apmult);
            shaka--;
        }
        if (!Madness.fullscreen) {
            if (showsize != 0) {
                float f = (getWidth() - 40) / 800.0F - 1.0F;
                if (f > (getHeight() - 70) / 450.0F - 1.0F) {
                    f = (getHeight() - 70) / 450.0F - 1.0F;
                }
                if (f > 1.0F) {
                    f = 1.0F;
                }
                if (f < 0.0F) {
                    f = 0.0F;
                }
                apmult = 1.0F + f * reqmult;
                if (!oncarm) {
                    g2.drawImage(carmaker[0], 50, 14, this);
                } else {
                    g2.drawImage(carmaker[1], 50, 14, this);
                }
                if (!onstgm) {
                    g2.drawImage(stagemaker[0], getWidth() - 208, 14, this);
                } else {
                    g2.drawImage(stagemaker[1], getWidth() - 208, 14, this);
                }
                g2.drawImage(sizebar, getWidth() / 2 - 230, 23, this);
                g2.drawImage(blb, (int) (getWidth() / 2 - 222 + 141.0F * reqmult), 23, this);
                g2.drawImage(chkbx[smooth], getWidth() / 2 - 53, 23, this);
                g2.setFont(new Font("Arial", 1, 11));
                g2.setColor(new Color(74, 99, 125));
                g2.drawString("Screen Size:", getWidth() / 2 - 224, 17);
                g2.drawString("Smooth", getWidth() / 2 - 36, 34);
                g2.drawImage(fulls, getWidth() / 2 + 27, 15, this);
                g2.setColor(new Color(94, 126, 159));
                g2.drawString("Fullscreen", getWidth() / 2 + 63, 30);
                g2.drawImage(chkbx[Madness.anti], getWidth() / 2 + 135, 9, this);
                g2.drawString("Antialiasing", getWidth() / 2 + 152, 20);
                g2.drawImage(chkbx[moto], getWidth() / 2 + 135, 26, this);
                g2.drawString("Motion Effects", getWidth() / 2 + 152, 37);
                g2.setColor(new Color(0, 0, 0));
                g2.fillRect(getWidth() / 2 - 153, 5, 80, 16);
                g2.setColor(new Color(121, 135, 152));
                String string = "" + (int) (apmult * 100.0F) + "%";
                if (reqmult == 0.0F) {
                    string = "Original";
                }
                if (reqmult == 1.0F) {
                    string = "Maximum";
                }
                g2.drawString(string, getWidth() / 2 - 150, 17);
                if (!oncarm && !onstgm) {
                    showsize--;
                }
                if (showsize == 0) {
                    g2.setColor(new Color(0, 0, 0));
                    g2.fillRect(getWidth() / 2 - 260, 0, 520, 40);
                    g2.fillRect(50, 14, 142, 23);
                    g2.fillRect(getWidth() - 208, 14, 158, 23);
                }
            }
            apx = (int) (getWidth() / 2 - 400.0F * apmult);
            apy = (int) (getHeight() / 2 - 225.0F * apmult - 50.0F);
            if (apy < 50) {
                apy = 50;
            }
            if (apmult > 1.0F) {
                if (smooth == 1) {
                    g2.setRenderingHint(RenderingHints.KEY_INTERPOLATION, RenderingHints.VALUE_INTERPOLATION_BILINEAR);
                    if (moto == 1) {
                        rd.setRenderingHint(RenderingHints.KEY_ALPHA_INTERPOLATION, RenderingHints.VALUE_ALPHA_INTERPOLATION_SPEED);
                        g2.drawImage(tribuffer, apx + i, apy + i97, (int) (800.0F * apmult), (int) (450.0F * apmult), this);
                        cropit(g2, i, i97);
                        tg.setComposite(AlphaComposite.getInstance(3, mvect / 100.0F));
                        tg.drawImage(offImage, 0, 0, null);
                    } else {
                        g2.drawImage(offImage, apx, apy, (int) (800.0F * apmult), (int) (450.0F * apmult), this);
                    }
                } else if (moto == 1) {
                    rd.setRenderingHint(RenderingHints.KEY_ALPHA_INTERPOLATION, RenderingHints.VALUE_ALPHA_INTERPOLATION_SPEED);
                    g2.drawImage(tribuffer, apx + i, apy + i97, (int) (800.0F * apmult), (int) (450.0F * apmult), this);
                    cropit(g2, i, i97);
                } else {
                    g2.drawImage(offImage, apx, apy, (int) (800.0F * apmult), (int) (450.0F * apmult), this);
                }
            } else if (moto == 1) {
                rd.setRenderingHint(RenderingHints.KEY_ALPHA_INTERPOLATION, RenderingHints.VALUE_ALPHA_INTERPOLATION_SPEED);
                g2.drawImage(tribuffer, apx + i, apy + i97, this);
                cropit(g2, i, i97);
                tg.setComposite(AlphaComposite.getInstance(3, mvect / 100.0F));
                tg.drawImage(offImage, 0, 0, null);
            } else {
                g2.drawImage(offImage, apx, apy, this);
            }
        } else if (moto == 1) {
            rd.setRenderingHint(RenderingHints.KEY_ALPHA_INTERPOLATION, RenderingHints.VALUE_ALPHA_INTERPOLATION_SPEED);
            g2.drawImage(tribuffer, apx + i, apy + i97, this);
            cropit(g2, i, i97);
            tg.setComposite(AlphaComposite.getInstance(3, mvect / 100.0F));
            tg.drawImage(offImage, 0, 0, null);
        } else {
            g2.drawImage(offImage, apx, apy, this);
        }
    }

    static private void readcookies(final ContO[] contos) {
        xtGraphics.nickname = "";
        try {
            final File file = new File("" + Madness.fpath + "data/user.data");
            final String[] strings = {
                    "", "", "", "", ""
            };
            if (file.exists()) {
                final BufferedReader bufferedreader = new BufferedReader(new FileReader(file));
                String string;
                for (int i = 0; (string = bufferedreader.readLine()) != null && i < 5; i++) {
                    strings[i] = string;
                }
                bufferedreader.close();
            }
            if (strings[0].startsWith("lastuser")) {
                xtGraphics.nickname = getstring("lastuser", strings[0], 0);
                if (!xtGraphics.nickname.equals("")) {
                    xtGraphics.opselect = 1;
                }
                String string;
                try {
                    string = getstring("lastuser", strings[0], 1);
                } catch (final Exception exception) {
                    string = "";
                }
                if (!string.equals("")) {
                    tnick.setText(xtGraphics.nickname);
                    tpass.setText(string);
                    xtGraphics.autolog = true;
                }
            }
            if (strings[2].startsWith("saved")) {
                int i = getint("saved", strings[2], 0);
                if (i >= 0 && i < xtGraphics.nCars) {
                    xtGraphics.scm = i;
                    xtGraphics.firstime = false;
                }
                i = getint("saved", strings[2], 1);
                if (i >= 1 && i <= xtGraphics.nTracks) {
                    xtGraphics.unlocked = i;
                }
            }
            if (strings[4].startsWith("graphics")) {
                int i = getint("graphics", strings[4], 0);
                if (i == 0 || i == 1) {
                    moto = i;
                    if (i == 1) {
                        makeTriBuffer();
                    }
                }
                i = getint("graphics", strings[4], 1);
                if (i >= 0 && i <= 1) {
                    Madness.anti = i;
                }
            }
            if (strings[1].startsWith("lastcar")) {
                int i = getint("lastcar", strings[1], 0);
                CarDefine.lastcar = getstring("lastcar", strings[1], 7);
                if (i >= 0 && i < 36) {
                    xtGraphics.osc = i;
                    xtGraphics.firstime = false;
                }
                int i198 = 0;
                for (int i199 = 0; i199 < 6; i199++) {
                    i = getint("lastcar", strings[1], i199 + 1);
                    if (i >= 0 && i <= 100) {
                        xtGraphics.arnp[i199] = i / 100.0F;
                        i198++;
                    }
                }
                if (i198 == 6 && xtGraphics.osc >= 0 && xtGraphics.osc <= 15) {
                    final Color color = Color.getHSBColor(xtGraphics.arnp[0], xtGraphics.arnp[1], 1.0F - xtGraphics.arnp[2]);
                    final Color color200 = Color.getHSBColor(xtGraphics.arnp[3], xtGraphics.arnp[4], 1.0F - xtGraphics.arnp[5]);
                    for (int i201 = 0; i201 < contos[xtGraphics.osc].npl; i201++)
                        if (contos[xtGraphics.osc].p[i201].colnum == 1) {
                            contos[xtGraphics.osc].p[i201].c[0] = color.getRed();
                            contos[xtGraphics.osc].p[i201].c[1] = color.getGreen();
                            contos[xtGraphics.osc].p[i201].c[2] = color.getBlue();
                        }
                    for (int i202 = 0; i202 < contos[xtGraphics.osc].npl; i202++)
                        if (contos[xtGraphics.osc].p[i202].colnum == 2) {
                            contos[xtGraphics.osc].p[i202].c[0] = color200.getRed();
                            contos[xtGraphics.osc].p[i202].c[1] = color200.getGreen();
                            contos[xtGraphics.osc].p[i202].c[2] = color200.getBlue();
                        }
                }
            }
        } catch (final Exception ignored) {

        }
    }

    static void reglink() {
        openurl("http://multiplayer.needformadness.com/register.html?ref=game");
    }

    static void regnew() {
        openurl("http://multiplayer.needformadness.com/registernew.pl");
    }

    static private void makeMenus() {
        rd.setRenderingHint(RenderingHints.KEY_TEXT_ANTIALIASING, RenderingHints.VALUE_TEXT_ANTIALIAS_ON);
        rd.setRenderingHint(RenderingHints.KEY_ANTIALIASING, RenderingHints.VALUE_ANTIALIAS_ON);
        sgame.add(rd, " NFM 1     ");
        sgame.add(rd, " NFM 2     ");
        sgame.add(rd, " My Stages ");
        sgame.add(rd, " Weekly Top20 ");
        sgame.add(rd, " Monthly Top20 ");
        sgame.add(rd, " All Time Top20 ");
        sgame.add(rd, " Stage Maker ");
        wgame.add(rd, " Normal Game");
        wgame.add(rd, " War / Battle");
        wgame.add(rd, " War / Battle - Practice");
        warb.add(rd, " Loading your clan's wars and battles, please wait...");
        pgame.add(rd, " Select the game you want to practice");
        vnpls.add(rd, "Players");
        vnpls.add(rd, " 2 VS 2");
        vnpls.add(rd, " 3 VS 3");
        vnpls.add(rd, " 4 VS 4");
        vtyp.add(rd, "Normal clan game");
        vtyp.add(rd, "Racing only");
        vtyp.add(rd, "Wasting only");
        vtyp.add(rd, "Racers VS Wasters - my clan wastes");
        vtyp.add(rd, "Racers VS Wasters - my clan races");
        snfmm.add(rd, "Select Stage");
        //snfm1.add(rd, "Select Stage");
        //snfm2.add(rd, "Select Stage");
        mstgs.add(rd, "Suddenly the King becomes Santa's Little Helper");
        mcars.add(rd, "Sword of Justice");
        snpls.add(rd, "Select");
        swait.add(rd, "1 Minute");
        ilaps.add(rd, "Laps");
        ilaps.add(rd, "1 Lap");
        for (int i = 0; i < xtGraphics.nTracks; i++) {
            snfmm.add(rd, " Stage " + (i + 1) + "");
        }
        /*for (int i = 0; i < 10; i++)
        	snfm1.add(rd, "" + (" Stage ") + (i + 1) + (""));
        for (int i = 0; i < 17; i++)
        	snfm2.add(rd, "" + (" Stage ") + (i + 1) + (""));*/
        for (int i = 0; i < 7; i++) {
            snpls.add(rd, "    " + (i + 2) + "");
        }
        for (int i = 0; i < 7; i++) {
            snbts.add(rd, "    " + i + "    ");
        }
        for (int i = 0; i < 2; i++) {
            swait.add(rd, "" + (i + 2) + " Minutes");
        }
        for (int i = 0; i < 15; i++) {
            slaps.add(rd, "" + (i + 1) + "");
        }
        for (int i = 0; i < 14; i++) {
            ilaps.add(rd, "" + (i + 2) + " Laps");
        }
        sclass.add(rd, "All Classes");
        sclass.add(rd, "Class C Cars");
        sclass.add(rd, "Class B & C Cars");
        sclass.add(rd, "Class B Cars");
        sclass.add(rd, "Class A & B Cars");
        sclass.add(rd, "Class A Cars");
        scars.add(rd, "All Cars");
        scars.add(rd, "Custom Cars");
        scars.add(rd, "Game Cars");
        sfix.add(rd, "Unlimited Fixing");
        sfix.add(rd, "4 Fixes");
        sfix.add(rd, "3 Fixes");
        sfix.add(rd, "2 Fixes");
        sfix.add(rd, "1 Fix");
        sfix.add(rd, "No Fixing");
        icars.add(rd, "Type of Cars");
        icars.add(rd, "All Cars");
        icars.add(rd, "Clan Cars");
        icars.add(rd, "Game Cars");
        icars.w = 140;
        gmode.add(rd, " Normal Game ");
        gmode.add(rd, " Practice Game ");
        rooms.rooms = true;
        rooms.add(rd, "Ghostrider :: 1");
        sendtyp.add(rd, "Write a Message");
        sendtyp.add(rd, "Share a Custom Car");
        sendtyp.add(rd, "Share a Custom Stage");
        sendtyp.add(rd, "Send a Clan Invitation");
        sendtyp.add(rd, "Share a Relative Date");
        senditem.add(rd, "Suddenly the King becomes Santa's Little Helper");
        for (int i = 0; i < 6; i++) {
            clanlev.add(rd, "" + (i + 1) + "");
        }
        clanlev.add(rd, "7 - Admin");
        hidefields();
    }
    
    private GameSparker() { super(); }

    static public GameSparker create() {
        gsPanel = new GameSparker();
        
        BASSLoader.initializeBASS();
        initFields();

        gsPanel.setBorder(BorderFactory.createLineBorder(Color.black));
        //
        gsPanel.setBackground(Color.black);
        gsPanel.setOpaque(true);
        //
        gsPanel.setLayout(null);

        makeMenus();

        preloadGame();

        new Thread(GameSparker::loadGame).start();

        gsPanel.addKeyListener(gsPanel);
        gsPanel.addMouseListener(gsPanel);
        gsPanel.addMouseMotionListener(gsPanel);
        gsPanel.addFocusListener(gsPanel);
        gsPanel.setFocusable(true);
        gsPanel.requestFocusInWindow();
        gsPanel.setIgnoreRepaint(true);

        // disable Swing's double buffering. we don't need it since we have our own offscreen image (offImage)
        // this means we get a slight performance gain
        // ("You may find that your numbers for direct rendering far exceed those for double-buffering" from https://docs.oracle.com/javase/tutorial/extra/fullscreen/doublebuf.html)
        // for zero graphical loss.
        gsPanel.setDoubleBuffered(false);

        final Timer timer = new Timer(46, ae -> gsPanel.repaint());

        timer.start();
        return gsPanel;
    }

    static private void preloadGame() {
        if (System.getProperty("java.vendor").toLowerCase().contains("apple")) {
            applejava = true;
        }

        new Medium();
        new Trackers();
        new CheckPoints();
        carContos = new ContO[carRads.length];
        contos = new ContO[stageRads.length];
        CarDefine.create(contos);
        xtGraphics.create(rd, gsPanel);

        new Record();
        mads = new Mad[8];
        for (int i = 0; i < 8; i++) {
            mads[i] = new Mad(null, i);
            u[i] = new Control();
        }

        date = new Date();
        l1 = date.getTime();
        f2 = 30.0F;
        bool3 = false;
        i4 = 530;
        i5 = 0;
        recordtime = 0;
        clicknowtime = 0;
        finishrecording = 0;
        wastedpoint = 0;
        flashingscreen = false;
    }

    //@Override
    static private void loadGame() {
        gsPanel.requestFocus();
        try {
            sizebar = xtGraphics.getImage("data/baseimages/sizebar.gif");
            blb = xtGraphics.getImage("data/baseimages/b.gif");
            fulls = xtGraphics.getImage("data/baseimages/fullscreen.gif");
            chkbx[0] = xtGraphics.getImage("data/baseimages/checkbox1.gif");
            chkbx[1] = xtGraphics.getImage("data/baseimages/checkbox2.gif");
            carmaker[0] = xtGraphics.getImage("data/baseimages/carmaker1.gif");
            carmaker[1] = xtGraphics.getImage("data/baseimages/carmaker2.gif");
            stagemaker[0] = xtGraphics.getImage("data/baseimages/stagemaker1.gif");
            stagemaker[1] = xtGraphics.getImage("data/baseimages/stagemaker2.gif");
        } catch (IOException e) {
            e.printStackTrace();
        }
        xtGraphics.loaddata();

        loadbase();

        stageContos = new ContO[10000];

        f = 47.0F;
        readcookies(  contos);
        xtGraphics.testdrive = Madness.testdrive;
        if (xtGraphics.testdrive != 0)
            if (xtGraphics.testdrive <= 2) {
                xtGraphics.sc[0] = CarDefine.loadcar(Madness.testcar, 16);
                if (xtGraphics.sc[0] != -1) {
                    xtGraphics.fase = -9;
                } else {
                    Madness.testcar = "Failx12";
                    Madness.carmaker();
                }
            } else {
                CheckPoints.name = Madness.testcar;
                xtGraphics.fase = -9;
            }
        xtGraphics.stoploading();
        gsPanel.requestFocus();
        if (xtGraphics.testdrive == 0 && xtGraphics.firstime) {
            setupini();
        }
        System.gc();

        gameLoaded = true;
    }

    static private void gameTick() {

        date = new Date();
        date.getTime();
        if (xtGraphics.fase == 1111) {
            xtGraphics.loading();
            if (gameLoaded) {
                xtGraphics.fase = 111;
            }
        }
        if (xtGraphics.fase == 111) {
            if (mouses == 1) {
                clicknowtime = 800;
            }
            if (clicknowtime < 800) {
                xtGraphics.clicknow();
                clicknowtime++;
            } else {
                clicknowtime = 0;
                if (!exwist) {
                    xtGraphics.fase = 9;
                }
                mouses = 0;
                lostfcs = false;
            }
        }
        if (xtGraphics.fase == 9)
            if (clicknowtime < 76) {
                xtGraphics.rad(clicknowtime);
                catchlink();
                if (mouses == 2) {
                    mouses = 0;
                }
                if (mouses == 1) {
                    mouses = 2;
                }
                clicknowtime++;
                if (u[0].enter) {
                    u[0].enter = false;
                    clicknowtime = 76;
                }
            } else {
                clicknowtime = 0;
                xtGraphics.fase = 10;
                mouses = 0;
                u[0].falseo(0);
            }
        if (xtGraphics.fase == -9) {
            if (xtGraphics.loadedt) {
                xtGraphics.mainbg(-101);
                rd.setColor(new Color(0, 0, 0));
                rd.fillRect(0, 0, 800, 450);
                //repaint();
                xtGraphics.strack.unload();
                xtGraphics.strack = null;
                xtGraphics.flexpix = null;
                Images.fleximg = null;
                System.gc();
                xtGraphics.loadedt = false;
            }
            if (clicknowtime < 2) {
                xtGraphics.mainbg(-101);
                rd.setColor(new Color(0, 0, 0));
                rd.fillRect(65, 25, 670, 400);
                clicknowtime++;
            } else {
                checkmemory();
                xtGraphics.inishcarselect(carContos);
                clicknowtime = 0;
                xtGraphics.fase = 7;
                mvect = 50;
                mouses = 0;
            }
        }
        if (xtGraphics.fase == 8) {
            xtGraphics.credits(u[0], xm, ym, mouses);
            xtGraphics.ctachm(xm, ym, mouses, u[0]);
            if (xtGraphics.flipo <= 100) {
                catchlink();
            }
            if (mouses == 2) {
                mouses = 0;
            }
            if (mouses == 1) {
                mouses = 2;
            }
        }
        if (xtGraphics.fase == 10) {
            mvect = 100;
            xtGraphics.maini(u[0]);
            xtGraphics.ctachm(xm, ym, mouses, u[0]);
            if (mouses == 2) {
                mouses = 0;
            }
            if (mouses == 1) {
                mouses = 2;
            }
        }
        if (xtGraphics.fase == 103) {
            mvect = 100;
            if (xtGraphics.loadedt) {
                rd.setColor(new Color(0, 0, 0));
                rd.fillRect(0, 0, 800, 450);
                //repaint();
                checkmemory();
                xtGraphics.strack.unload();
                xtGraphics.strack = null;
                xtGraphics.flexpix = null;
                Images.fleximg = null;
                System.gc();
                xtGraphics.loadedt = false;
            }
            if (xtGraphics.testdrive == 1 || xtGraphics.testdrive == 2) {
                Madness.carmaker();
            }
            if (xtGraphics.testdrive == 3 || xtGraphics.testdrive == 4) {
                Madness.stagemaker();
            }
            xtGraphics.maini(u[0]);
            xtGraphics.fase = 10;
            if (mouses == 2) {
                mouses = 0;
            }
            if (mouses == 1) {
                mouses = 2;
            }
        }
        if (xtGraphics.fase == 102) {
            mvect = 100;
            if (xtGraphics.loadedt) {
                rd.setColor(new Color(0, 0, 0));
                rd.fillRect(0, 0, 800, 450);
                //repaint();
                checkmemory();
                xtGraphics.strack.unload();
                xtGraphics.strack = null;
                xtGraphics.flexpix = null;
                Images.fleximg = null;
                System.gc();
                xtGraphics.loadedt = false;
            }
            if (xtGraphics.testdrive == 1 || xtGraphics.testdrive == 2) {
                Madness.carmaker();
            }
            if (xtGraphics.testdrive == 3 || xtGraphics.testdrive == 4) {
                Madness.stagemaker();
            }
            xtGraphics.maini2();
            xtGraphics.ctachm(xm, ym, mouses, u[0]);
            if (mouses == 2) {
                mouses = 0;
            }
            if (mouses == 1) {
                mouses = 2;
            }
        }
        if (xtGraphics.fase == -22) {
            CheckPoints.name = Madness.testcar;
            CheckPoints.stage = -1;
            loadstage();
            if (CheckPoints.stage == -3) {
                Madness.testcar = "Failx12";
                Madness.stagemaker();
            }
        }
        if (xtGraphics.fase == 11) {
            xtGraphics.inst(u[0]);
            xtGraphics.ctachm(xm, ym, mouses, u[0]);
            if (mouses == 2) {
                mouses = 0;
            }
            if (mouses == 1) {
                mouses = 2;
            }
        }
        if (xtGraphics.fase == -5) {
            mvect = 100;
            xtGraphics.finish( carContos, u[0], xm, ym, moused); // TODO carContos or contos here?
            xtGraphics.ctachm(xm, ym, mouses, u[0]);
            if (mouses == 2) {
                mouses = 0;
            }
            if (mouses == 1) {
                mouses = 2;
            }
        }
        if (xtGraphics.fase == 7) {
            xtGraphics.carselect(u[0], carContos, xm, ym, moused);
            xtGraphics.ctachm(xm, ym, mouses, u[0]);
            if (mouses == 2) {
                mouses = 0;
            }
            if (mouses == 1) {
                mouses = 2;
            }
            drawms();
        }
        if (xtGraphics.fase == 6) {
            xtGraphics.musicomp(CheckPoints.stage, u[0]);
            xtGraphics.ctachm(xm, ym, mouses, u[0]);
            if (mouses == 2) {
                mouses = 0;
            }
            if (mouses == 1) {
                mouses = 2;
            }
        }
        if (xtGraphics.fase == 5) {
            mvect = 100;
            xtGraphics.loadmusic(CheckPoints.stage, CheckPoints.trackname, CheckPoints.trackvol);
        }
        if (xtGraphics.fase == 4) {
            xtGraphics.cantgo(u[0]);
            xtGraphics.ctachm(xm, ym, mouses, u[0]);
            if (mouses == 2) {
                mouses = 0;
            }
            if (mouses == 1) {
                mouses = 2;
            }
        }
        if (xtGraphics.fase == 3) {
            rd.setColor(new Color(0, 0, 0));
            rd.fillRect(65, 25, 670, 400);
            //repaint();
            xtGraphics.inishstageselect();
        }
        if (xtGraphics.fase == 2) {
            mvect = 100;
            xtGraphics.loadingstage(true);
            CheckPoints.nfix = 0;
            CheckPoints.notb = false;
            loadstage();
            u[0].falseo(0);
            udpmistro.freg = 0.0F;
            mvect = 20;
        }
        if (xtGraphics.fase == 1) {
            xtGraphics.trackbg(false);
            rd.setRenderingHint(RenderingHints.KEY_ANTIALIASING, RenderingHints.VALUE_ANTIALIAS_OFF);
            if (CheckPoints.stage != -3) {
                Medium.aroundtrack();
                if (Medium.hit == 5000 && mvect < 40) {
                    mvect++;
                }
                final int[][] ai = new int[notb][2];
                for (int k7 = xtGraphics.nplayers; k7 < notb; k7++) {
                    ai[k7][0] = k7;
                    ai[k7][1] = stageContos[k7].dist;
                }

                Arrays.sort(ai, contoComparator);

                for (int i14 = 0; i14 < notb; i14++) {
                    stageContos[ai[i14][0]].d(rd);
                }
            }
            if (!openm) {
                xtGraphics.ctachm(xm, ym, mouses, u[0]);
            }
            if (mouses == 2) {
                mouses = 0;
            }
            if (mouses == 1) {
                mouses = 2;
            }
            rd.setRenderingHint(RenderingHints.KEY_ANTIALIASING, RenderingHints.VALUE_ANTIALIAS_ON);
            xtGraphics.stageselect( u[0], xm, ym, moused);
            drawms();
        }
        if (xtGraphics.fase == 1177) {
            mvect = 100;
            if (!bool) {
                if (xtGraphics.loadedt) {
                    rd.setColor(new Color(0, 0, 0));
                    rd.fillRect(0, 0, 800, 450);
                    //repaint();
                    checkmemory();
                    xtGraphics.strack.unload();
                    xtGraphics.strack = null;
                    xtGraphics.flexpix = null;
                    Images.fleximg = null;
                    System.gc();
                    xtGraphics.loadedt = false;
                }
                xtGraphics.intertrack.unload();
                rd.setColor(new Color(0, 0, 0));
                rd.fillRect(65, 25, 670, 400);
                if (mload > 0) {
                    rd.drawImage(Images.mload, 259, 195, gsPanel);
                }
                //repaint();
                if (mload == 2) {
                    CarDefine.loadready();
                    loadbase();
                    readcookies(  contos);
                    mload = -1;
                }
                System.gc();
                login = new Login(rd, gsPanel);
                //globe = new Globe(rd,   login,   contos, contos0,
                //		this);
                lobby = new Lobby(rd, login, gsPanel);
                bool = true;
            }
            if (login.fase != 18) {
                final boolean bool20 = false;
                if (login.fase == 0) {
                    login.inishmulti();
                }
                if (login.fase >= 1 && login.fase <= 11) {
                    login.multistart(contos, xm, ym, moused);
                }
                if (login.fase >= 12 && login.fase <= 17) {
                    //if (globe.open != 452)
                    login.multimode(contos);
                }
                //else
                //	bool20 = true;
                //globe.dome(0, xm, ym, moused, u[0]);
                if (login.justlog) {
                    //if (!xtgraphics.clan.equals(""))
                    //	globe.itab = 2;
                    login.justlog = false;
                }
                if (!bool20) {
                    login.ctachm(xm, ym, mouses, u[0], lobby);
                    mvect = 50;
                } else {
                    drawms();
                    mvect = 100;
                }
                if (mouses == 1) {
                    mouses = 11;
                }
                if (mouses <= -1) {
                    mouses--;
                    if (mouses == -4) {
                        mouses = 0;
                    }
                }
                if (mousew != 0)
                    if (mousew > 0) {
                        mousew--;
                    } else {
                        mousew++;
                    }
            } else {
                if (lobby.fase == 0) {
                    lobby.inishlobby();
                    mvect = 100;
                }
                if (lobby.fase == 1) {
                    /*if (globe.open >= 2 && globe.open < 452)
                    	openm = true;
                    if (globe.open != 452)*/
                    lobby.lobby(xm, ym, moused, mousew, u[0], contos);
                    /*else
                    	bool21 = true;
                    globe.dome(lobby.conon, xm, ym, moused, u[0]);*/
                    if (lobby.loadstage > 0) {
                        gsPanel.setCursor(new Cursor(3));
                        drawms();
                        //repaint();
                        Trackers.nt = 0;
                        if (loadstagePreview(lobby.loadstage, "", stageContos, contos)) {
                            lobby.gstagename = CheckPoints.name;
                            lobby.gstagelaps = CheckPoints.nlaps;
                            lobby.loadstage = -lobby.loadstage;
                        } else {
                            lobby.loadstage = 0;
                            CheckPoints.name = "";
                        }
                        gsPanel.setCursor(new Cursor(0));
                    }
                    if (lobby.msload != 0) {
                        gsPanel.setCursor(new Cursor(3));
                        drawms();
                        //repaint();
                        if (lobby.msload == 1) {
                            CarDefine.loadmystages();
                        }
                        if (lobby.msload == 7) {
                            CarDefine.loadclanstages(xtGraphics.clan);
                        }
                        if (lobby.msload == 3 || lobby.msload == 4) {
                            CarDefine.loadtop20(lobby.msload);
                        }
                        lobby.msload = 0;
                        gsPanel.setCursor(new Cursor(0));
                    }
                }
                if (lobby.fase == 3) {
                    xtGraphics.trackbg(false);
                    Medium.trk = 0;
                    Medium.focusPoint = 400;
                    Medium.crs = true;
                    Medium.x = -335;
                    Medium.y = 0;
                    Medium.z = -50;
                    Medium.xz = 0;
                    Medium.zy = 20;
                    Medium.ground = -2000;
                    mvect = 100;
                    lobby.fase = 1;
                }
                if (lobby.fase == 4) {
                    mvect = 50;
                    rd.setRenderingHint(RenderingHints.KEY_ANTIALIASING, RenderingHints.VALUE_ANTIALIAS_OFF);
                    Medium.d(rd);
                    Medium.aroundtrack();
                    int j = 0;
                    final int[] is = new int[1000];
                    for (int k = 0; k < nob; k++)
                        if (stageContos[k].dist != 0) {
                            is[j] = k;
                            j++;
                        } else {
                            stageContos[k].d(rd);
                        }
                    final int[] is2 = new int[j];
                    for (int k = 0; k < j; k++) {
                        is2[k] = 0;
                    }
                    for (int k = 0; k < j; k++) {
                        for (int l = k + 1; l < j; l++)
                            if (stageContos[is[k]].dist != stageContos[is[l]].dist) {
                                if (stageContos[is[k]].dist < stageContos[is[l]].dist) {
                                    is2[k]++;
                                } else {
                                    is2[l]++;
                                }
                            } else if (l > k) {
                                is2[k]++;
                            } else {
                                is2[l]++;
                            }
                    }
                    for (int k = 0; k < j; k++) {
                        for (int l = 0; l < j; l++)
                            if (is2[l] == k) {
                                stageContos[is[l]].d(rd);
                            }
                    }
                    rd.setRenderingHint(RenderingHints.KEY_ANTIALIASING, RenderingHints.VALUE_ANTIALIAS_ON);
                    lobby.stageselect(u[0], xm, ym, moused);
                    if (lobby.plsndt == 1) {
                        mvect = 70;
                        //repaint();
                        gsPanel.setCursor(new Cursor(3));
                        xtGraphics.loadstrack(CheckPoints.stage, CheckPoints.trackname, CheckPoints.trackvol);
                        xtGraphics.strack.play();
                        lobby.plsndt = 2;
                        moused = false;
                        mouses = 0;
                    }
                }
                if (lobby.fase == 2) {
                    int j = 0;
                    for (int k = 0; k < lobby.ngm; k++)
                        if (lobby.ongame == lobby.gnum[k]) {
                            j = k;
                        }
                    boolean flag = false;
                    if (lobby.gstgn[j] > 0) {
                        if (lobby.gstgn[j] == -lobby.loadstage) {
                            flag = true;
                        }
                    } else if (lobby.gstages[j].equals(CheckPoints.name)) {
                        flag = true;
                    }
                    if (flag) {
                        lobby.fase = 4;
                        lobby.addstage = 0;
                    } else {
                        xtGraphics.loadingstage(false);
                        Trackers.nt = 0;
                        if (loadstagePreview(lobby.gstgn[j], lobby.gstages[j], stageContos, contos)) {
                            lobby.loadstage = -lobby.gstgn[j];
                            lobby.fase = 4;
                            lobby.addstage = 0;
                        } else {
                            lobby.loadstage = 0;
                            CheckPoints.name = "";
                            lobby.fase = 3;
                        }
                    }
                }
                if (lobby.fase == 76) {
                    CheckPoints.nlaps = lobby.laps;
                    CheckPoints.stage = lobby.stage;
                    CheckPoints.name = lobby.stagename;
                    CheckPoints.nfix = lobby.nfix;
                    CheckPoints.notb = lobby.notb;
                    xtGraphics.fase = 21;
                    u[0].multion = xtGraphics.multion;
                }
                /*if (globe.loadwbgames == 7) {
                	//repaint();
                	globe.redogame();
                }*/
                if (!openm) {
                    lobby.ctachm(xm, ym, mouses, u[0]);
                } else {
                    mouses = 0;
                }
                drawms();
                if (lobby.fase == 1) {
                    lobby.preforma(xm, ym);
                }
                if (lobby.loadwarb) {
                    //repaint();
                    //globe.loadwarb();
                    lobby.loadwarb = false;
                }
                /*if (globe.loadwbgames == 1) {
                	//repaint();
                	globe.loadwgames();
                }*/
                if (mouses == 1) {
                    mouses = 11;
                }
                if (mouses <= -1) {
                    mouses--;
                    if (mouses == -4) {
                        mouses = 0;
                    }
                }
                if (mousew != 0) {
                    if (mousew > 0) {
                        mousew--;
                    } else {
                        mousew++;
                    }
                    if (!lobby.zeromsw) {
                        mousew = 0;
                    }
                }
            }
        }
        if (xtGraphics.fase == 24) {
            login.endcons();
            login = null;
            lobby = null;
            //globe = null;
            bool = false;
            System.gc();
            System.runFinalization();
            if (!xtGraphics.mtop) {
                xtGraphics.fase = 102;
                xtGraphics.opselect = 2;
            } else {
                xtGraphics.fase = 10;
                xtGraphics.opselect = 1;
            }
        }
        if (xtGraphics.fase == 23) {
            if (login.fase == 18) {
                xtGraphics.playingame = -101;
            }
            login.stopallnow();
            lobby.stopallnow();
            //globe.stopallnow();
            login = null;
            lobby = null;
            //globe = null;
            hidefields();
            bool = false;
            System.gc();
            System.runFinalization();
            xtGraphics.fase = -9;
        }
        if (xtGraphics.fase == 22) {
            loadstage();
            if (CheckPoints.stage != -3) {
                if (xtGraphics.lan && xtGraphics.im == 0) {
                    udpmistro.UDPLanServer(xtGraphics.server, xtGraphics.servport, xtGraphics.playingame);
                }
                u[0].falseo(2);
                gsPanel.requestFocus();
            } else {
                xtGraphics.fase = 1177;
            }
        }
        if (xtGraphics.fase == 21) {
            login.endcons();
            login = null;
            lobby = null;
            //globe = null;
            bool = false;
            System.gc();
            System.runFinalization();
            xtGraphics.fase = 22;
        }
        if (xtGraphics.fase == 0) {
            for (int player = 0; player < xtGraphics.nplayers; player++)
                if (mads[player].newcar) {
                    final int i34 = stageContos[player].xz;
                    final int i35 = stageContos[player].xy;
                    final int i36 = stageContos[player].zy;
                    stageContos[player] = new ContO(carContos[mads[player].cn], stageContos[player].x, stageContos[player].y, stageContos[player].z, 0);
                    stageContos[player].xz = i34;
                    stageContos[player].xy = i35;
                    stageContos[player].zy = i36;
                    mads[player].newcar = false;
                }
            Medium.d(rd);

            final int[][] ai = new int[nob][2];
            for (int k7 = 0; k7 < nob; k7++) {
                ai[k7][0] = k7;
                ai[k7][1] = stageContos[k7].dist;
            }

            Arrays.sort(ai, contoComparator);

            for (int i14 = 0; i14 < nob; i14++) {
                stageContos[ai[i14][0]].d(rd);
            }
            
            if (xtGraphics.starcnt == 0) {
                for (int k = 0; k < xtGraphics.nplayers; k++) {
                    for (int l = 0; l < xtGraphics.nplayers; l++)
                        if (l != k) {
                            mads[k].colide(stageContos[k], mads[l], stageContos[l]);
                        }
                }
                for (int k = 0; k < xtGraphics.nplayers; k++) {
                    mads[k].drive(u[k], stageContos[k]);
                }
                for (int k = 0; k < xtGraphics.nplayers; k++) {
                    Record.rec(stageContos[k], k, mads[k].squash, mads[k].lastcolido, mads[k].cntdest, 0);
                }
                CheckPoints.checkstat(mads, stageContos,  xtGraphics.nplayers, xtGraphics.im, 0);
                for (int k = 1; k < xtGraphics.nplayers; k++) {
                    u[k].preform(mads[k], stageContos[k]);
                }
            } else {
                if (xtGraphics.starcnt == 130) {
                    Medium.adv = 1900;
                    Medium.zy = 40;
                    Medium.vxz = 70;
                    rd.setColor(new Color(255, 255, 255));
                    rd.fillRect(0, 0, 800, 450);
                }
                if (xtGraphics.starcnt != 0) {
                    xtGraphics.starcnt--;
                }
            }
            if (xtGraphics.starcnt < 38) {
                if (view == 0) {
                    Medium.follow(stageContos[0], mads[0].cxz, u[0].lookback);
                    xtGraphics.stat(mads[0], stageContos[0],  u[0], true);
                    if (mads[0].outshakedam > 0) {
                        shaka = mads[0].outshakedam / 20;
                        if (shaka > 25) {
                            shaka = 25;
                        }
                    }
                    mvect = 65 + Math.abs(lmxz - Medium.xz) / 5 * 100;
                    if (mvect > 90) {
                        mvect = 90;
                    }
                    lmxz = Medium.xz;
                }
                if (view == 1) {
                    Medium.around(stageContos[0], false);
                    xtGraphics.stat(mads[0], stageContos[0],  u[0], false);
                    mvect = 80;
                }
                if (view == 2) {
                    Medium.watch(stageContos[0], mads[0].mxz);
                    xtGraphics.stat(mads[0], stageContos[0],  u[0], false);
                    mvect = 65 + Math.abs(lmxz - Medium.xz) / 5 * 100;
                    if (mvect > 90) {
                        mvect = 90;
                    }
                    lmxz = Medium.xz;
                }
                if (mouses == 1) {
                    u[0].enter = true;
                    mouses = 0;
                }
            } else {
                int k = 3;
                if (xtGraphics.nplayers == 1) {
                    k = 0;
                }
                Medium.around(stageContos[k], true);
                mvect = 80;
                if (u[0].enter || u[0].handb) {
                    xtGraphics.starcnt = 38;
                    u[0].enter = false;
                    u[0].handb = false;
                }
                if (xtGraphics.starcnt == 38) {
                    mouses = 0;
                    Medium.vert = false;
                    Medium.adv = 900;
                    Medium.vxz = 180;
                    CheckPoints.checkstat(mads, stageContos,  xtGraphics.nplayers, xtGraphics.im, 0);
                    Medium.follow(stageContos[0], mads[0].cxz, 0);
                    xtGraphics.stat(mads[0], stageContos[0],  u[0], true);
                    rd.setColor(new Color(255, 255, 255));
                    rd.fillRect(0, 0, 800, 450);
                }
            }
        }
        if (xtGraphics.fase == 7001) {
            for (int player = 0; player < xtGraphics.nplayers; player++)
                if (mads[player].newedcar == 0 && mads[player].newcar) {
                    final int i52 = stageContos[player].xz;
                    final int i53 = stageContos[player].xy;
                    final int i54 = stageContos[player].zy;
                    xtGraphics.colorCar(contos[mads[player].cn], player);
                    stageContos[player] = new ContO(contos[mads[player].cn], stageContos[player].x, stageContos[player].y, stageContos[player].z, 0);
                    stageContos[player].xz = i52;
                    stageContos[player].xy = i53;
                    stageContos[player].zy = i54;
                    mads[player].newedcar = 20;
                }
            Medium.d(rd);
            int j = 0;
            final int[] is = new int[10000];
            for (int k = 0; k < nob; k++)
                if (stageContos[k].dist != 0) {
                    is[j] = k;
                    j++;
                } else {
                    stageContos[k].d(rd);
                }
            final int[] is2 = new int[j];
            final int[] is3 = new int[j];
            for (int k = 0; k < j; k++) {
                is2[k] = 0;
            }
            for (int k = 0; k < j; k++) {
                for (int l = k + 1; l < j; l++)
                    if (stageContos[is[k]].dist < stageContos[is[l]].dist) {
                        is2[k]++;
                    } else {
                        is2[l]++;
                    }
                is3[is2[k]] = k;
            }
            for (int k = 0; k < j; k++) {
                if (is[is3[k]] < xtGraphics.nplayers && is[is3[k]] != xtGraphics.im) {
                    udpmistro.readContOinfo(stageContos[is[is3[k]]], is[is3[k]]);
                }
                stageContos[is[is3[k]]].d(rd);
            }
            if (xtGraphics.starcnt == 0) {
                if (xtGraphics.multion == 1) {
                    int k = 1;
                    for (int l = 0; l < xtGraphics.nplayers; l++)
                        if (xtGraphics.im != l) {
                            udpmistro.readinfo(mads[l], stageContos[l], u[k], l, CheckPoints.dested);
                            k++;
                        }
                } else {
                    for (int l = 0; l < xtGraphics.nplayers; l++) {
                        udpmistro.readinfo(mads[l], stageContos[l], u[l], l, CheckPoints.dested);
                    }
                }
                for (int k = 0; k < xtGraphics.nplayers; k++) {
                    for (int l = 0; l < xtGraphics.nplayers; l++)
                        if (l != k) {
                            mads[k].colide(stageContos[k], mads[l], stageContos[l]);
                        }
                }
                if (xtGraphics.multion == 1) {
                    int k = 1;
                    for (int l = 0; l < xtGraphics.nplayers; l++)
                        if (xtGraphics.im != l) {
                            mads[l].drive(u[k], stageContos[l]);
                            k++;
                        } else {
                            mads[l].drive(u[0], stageContos[l]);
                        }
                    for (int l = 0; l < xtGraphics.nplayers; l++) {
                        Record.rec(stageContos[l], l, mads[l].squash, mads[l].lastcolido, mads[l].cntdest, xtGraphics.im);
                    }
                } else {
                    for (int k = 0; k < xtGraphics.nplayers; k++) {
                        mads[k].drive(u[k], stageContos[k]);
                    }
                }
                CheckPoints.checkstat(mads, stageContos,  xtGraphics.nplayers, xtGraphics.im, xtGraphics.multion);
            } else {
                if (xtGraphics.starcnt == 130) {
                    Medium.adv = 1900;
                    Medium.zy = 40;
                    Medium.vxz = 70;
                    rd.setColor(new Color(255, 255, 255));
                    rd.fillRect(0, 0, 800, 450);
                    //repaint();
                    if (xtGraphics.lan) {
                        udpmistro.UDPConnectLan(xtGraphics.localserver, xtGraphics.nplayers, xtGraphics.im);
                        if (xtGraphics.im == 0) {
                            xtGraphics.setbots(udpmistro.isbot);
                        }
                    } else {
                        udpmistro.UDPConnectOnline(xtGraphics.server, xtGraphics.gameport, xtGraphics.nplayers, xtGraphics.im);
                    }
                    if (xtGraphics.multion >= 2) {
                        xtGraphics.im = (int) (ThreadLocalRandom.current().nextDouble() * xtGraphics.nplayers);
                        xtGraphics.starcnt = 0;
                    }
                }
                if (xtGraphics.starcnt == 50) {
                    udpmistro.frame[udpmistro.im][0] = 0;
                }
                if (xtGraphics.starcnt != 39 && xtGraphics.starcnt != 0) {
                    xtGraphics.starcnt--;
                }
                if (udpmistro.go && xtGraphics.starcnt >= 39) {
                    xtGraphics.starcnt = 38;
                    if (xtGraphics.lan) {
                        int k = CheckPoints.stage;
                        if (k < 0) {
                        }
                        if (xtGraphics.loadedt) {
                            xtGraphics.strack.play();
                        }
                    }
                }
            }
            if (xtGraphics.lan && udpmistro.im == 0) {
                for (int k = 2; k < xtGraphics.nplayers; k++)
                    if (udpmistro.isbot[k]) {
                        u[k].preform(mads[k], stageContos[k]);
                        udpmistro.setinfo(mads[k], stageContos[k], u[k], CheckPoints.pos[k], CheckPoints.magperc[k], false, k);
                    }
            }
            if (xtGraphics.starcnt < 38) {
                if (xtGraphics.multion == 1) {
                    udpmistro.setinfo(mads[xtGraphics.im], stageContos[xtGraphics.im], u[0], CheckPoints.pos[xtGraphics.im], CheckPoints.magperc[xtGraphics.im], xtGraphics.holdit, xtGraphics.im);
                    if (view == 0) {
                        Medium.follow(stageContos[xtGraphics.im], mads[xtGraphics.im].cxz, u[0].lookback);
                        xtGraphics.stat(mads[xtGraphics.im], stageContos[xtGraphics.im],  u[0], true);
                        if (mads[xtGraphics.im].outshakedam > 0) {
                            shaka = mads[xtGraphics.im].outshakedam / 20;
                            if (shaka > 25) {
                                shaka = 25;
                            }
                        }
                        mvect = 65 + Math.abs(lmxz - Medium.xz) / 5 * 100;
                        if (mvect > 90) {
                            mvect = 90;
                        }
                        lmxz = Medium.xz;
                    }
                    if (view == 1) {
                        Medium.around(stageContos[xtGraphics.im], false);
                        xtGraphics.stat(mads[xtGraphics.im], stageContos[xtGraphics.im],  u[0], false);
                        mvect = 80;
                    }
                    if (view == 2) {
                        Medium.watch(stageContos[xtGraphics.im], mads[xtGraphics.im].mxz);
                        xtGraphics.stat(mads[xtGraphics.im], stageContos[xtGraphics.im],  u[0], false);
                        mvect = 65 + Math.abs(lmxz - Medium.xz) / 5 * 100;
                        if (mvect > 90) {
                            mvect = 90;
                        }
                        lmxz = Medium.xz;
                    }
                } else {
                    if (view == 0) {
                        Medium.getaround(stageContos[xtGraphics.im]);
                        mvect = 80;
                    }
                    if (view == 1) {
                        Medium.getfollow(stageContos[xtGraphics.im], mads[xtGraphics.im].cxz, u[0].lookback);
                        mvect = 65 + Math.abs(lmxz - Medium.xz) / 5 * 100;
                        if (mvect > 90) {
                            mvect = 90;
                        }
                        lmxz = Medium.xz;
                    }
                    if (view == 2) {
                        Medium.watch(stageContos[xtGraphics.im], mads[xtGraphics.im].mxz);
                        mvect = 65 + Math.abs(lmxz - Medium.xz) / 5 * 100;
                        if (mvect > 90) {
                            mvect = 90;
                        }
                        lmxz = Medium.xz;
                    }
                    xtGraphics.stat(mads[xtGraphics.im], stageContos[xtGraphics.im],  u[0], true);
                }
                if (mouses == 1) {
                    if (xtGraphics.holdit && xtGraphics.exitm != 4 && xtGraphics.multion == 1) {
                        u[0].enter = true;
                    }
                    mouses = 0;
                }
            } else {
                Medium.around(stageContos[xtGraphics.im], true);
                mvect = 80;
                if (xtGraphics.starcnt == 39) {
                    xtGraphics.waitenter();
                }
                if (xtGraphics.starcnt == 38) {
                    xtGraphics.forstart = 0;
                    mouses = 0;
                    Medium.vert = false;
                    Medium.adv = 900;
                    Medium.vxz = 180;
                    CheckPoints.checkstat(mads, stageContos,  xtGraphics.nplayers, xtGraphics.im, xtGraphics.multion);
                    Medium.follow(stageContos[xtGraphics.im], mads[xtGraphics.im].cxz, 0);
                    xtGraphics.stat(mads[xtGraphics.im], stageContos[xtGraphics.im],  u[0], true);
                    rd.setColor(new Color(255, 255, 255));
                    rd.fillRect(0, 0, 800, 450);
                }
            }
            xtGraphics.multistat(u[0],  xm, ym, moused, udpmistro);
        }
        if (xtGraphics.fase == -1) {
            if (recordtime == 0) {
                for (int j = 0; j < xtGraphics.nplayers; j++) {
                    Record.ocar[j] = new ContO(stageContos[j], 0, 0, 0, 0);
                    stageContos[j] = new ContO(Record.car[0][j], 0, 0, 0, 0);
                }
            }
            Medium.d(rd);
            int j = 0;
            final int[] is = new int[10000];
            for (int k = 0; k < nob; k++)
                if (stageContos[k].dist != 0) {
                    is[j] = k;
                    j++;
                } else {
                    stageContos[k].d(rd);
                }
            final int[] is2 = new int[j];
            for (int k = 0; k < j; k++) {
                is2[k] = 0;
            }
            for (int k = 0; k < j; k++) {
                for (int l = k + 1; l < j; l++)
                    if (stageContos[is[k]].dist != stageContos[is[l]].dist) {
                        if (stageContos[is[k]].dist < stageContos[is[l]].dist) {
                            is2[k]++;
                        } else {
                            is2[l]++;
                        }
                    } else if (l > k) {
                        is2[k]++;
                    } else {
                        is2[l]++;
                    }
            }
            for (int k = 0; k < j; k++) {
                for (int l = 0; l < j; l++)
                    if (is2[l] == k) {
                        stageContos[is[l]].d(rd);
                    }
            }
            if (u[0].enter || u[0].handb || mouses == 1) {
                recordtime = 299;
                u[0].enter = false;
                u[0].handb = false;
                mouses = 0;
            }
            for (int k = 0; k < xtGraphics.nplayers; k++) {
                if (Record.fix[k] == recordtime)
                    if (stageContos[k].dist == 0) {
                        stageContos[k].fcnt = 8;
                    } else {
                        stageContos[k].fix = true;
                    }
                if (stageContos[k].fcnt == 7 || stageContos[k].fcnt == 8) {
                    stageContos[k] = new ContO(contos[mads[k].cn], 0, 0, 0, 0);
                    Record.cntdest[k] = 0;
                }
                if (recordtime == 299) {
                    stageContos[k] = new ContO(Record.ocar[k], 0, 0, 0, 0);
                }
                Record.play(stageContos[k], mads[k], k, recordtime);
            }
            if (++recordtime == 300) {
                recordtime = 0;
                xtGraphics.fase = -6;
            } else {
                xtGraphics.replyn();
            }
            Medium.around(stageContos[0], false);
        }
        if (xtGraphics.fase == -2) {
            if (xtGraphics.multion >= 2) {
                Record.hcaught = false;
            }
            u[0].falseo(3);
            if (Record.hcaught && Record.wasted == 0 && Record.whenwasted != 229 && (CheckPoints.stage == 1 || CheckPoints.stage == 2) && xtGraphics.looped != 0) {
                Record.hcaught = false;
            }
            if (Record.hcaught) {
                rd.setColor(new Color(0, 0, 0));
                rd.fillRect(0, 0, 800, 450);
                //repaint();
            }
            if (xtGraphics.multion != 0) {
                udpmistro.UDPquit();
                xtGraphics.stopchat();
                if (cmsg.isShowing()) {
                    cmsg.setVisible(false);
                }
                cmsg.setText("");
                gsPanel.requestFocus();
            }
            if (Record.hcaught) {
                Medium.vert = Medium.random() <= 0.45;
                Medium.adv = (int) (900.0F * Medium.random());
                Medium.vxz = (int) (360.0F * Medium.random());
                recordtime = 0;
                xtGraphics.fase = -3;
                clicknowtime = 0;
                finishrecording = 0;
            } else {
                recordtime = -2;
                xtGraphics.fase = -4;
            }
        }
        if (xtGraphics.fase == -3) {
            if (recordtime == 0) {
                if (Record.wasted == 0) {
                    if (Record.whenwasted == 229) {
                        wastedpoint = 67;
                        Medium.vxz += 90;
                    } else {
                        wastedpoint = (int) (Medium.random() * 4.0F);
                        if (wastedpoint == 1 || wastedpoint == 3) {
                            wastedpoint = 69;
                        }
                        if (wastedpoint == 2 || wastedpoint == 4) {
                            wastedpoint = 30;
                        }
                    }
                } else if (Record.closefinish != 0 && finishrecording != 0) {
                    Medium.vxz += 90;
                }
                for (int j = 0; j < xtGraphics.nplayers; j++) {
                    stageContos[j] = new ContO(Record.starcar[j], 0, 0, 0, 0);
                }
            }
            Medium.d(rd);
            int j = 0;
            final int[] is = new int[10000];
            for (int k = 0; k < nob; k++)
                if (stageContos[k].dist != 0) {
                    is[j] = k;
                    j++;
                } else {
                    stageContos[k].d(rd);
                }
            final int[] is2 = new int[j];
            for (int k = 0; k < j; k++) {
                is2[k] = 0;
            }
            for (int k = 0; k < j; k++) {
                for (int l = k + 1; l < j; l++)
                    if (stageContos[is[k]].dist != stageContos[is[l]].dist) {
                        if (stageContos[is[k]].dist < stageContos[is[l]].dist) {
                            is2[k]++;
                        } else {
                            is2[l]++;
                        }
                    } else if (l > k) {
                        is2[k]++;
                    } else {
                        is2[l]++;
                    }
            }
            for (int k = 0; k < j; k++) {
                for (int l = 0; l < j; l++)
                    if (is2[l] == k) {
                        stageContos[is[l]].d(rd);
                    }
            }
            for (int k = 0; k < xtGraphics.nplayers; k++) {
                if (Record.hfix[k] == recordtime)
                    if (stageContos[k].dist == 0) {
                        stageContos[k].fcnt = 8;
                    } else {
                        stageContos[k].fix = true;
                    }
                if (stageContos[k].fcnt == 7 || stageContos[k].fcnt == 8) {
                    stageContos[k] = new ContO(contos[mads[k].cn], 0, 0, 0, 0);
                    Record.cntdest[k] = 0;
                }
                Record.playh(stageContos[k], mads[k], k, recordtime, xtGraphics.im);
            }
            if (finishrecording == 2 && recordtime == 299) {
                u[0].enter = true;
            }
            if (u[0].enter || u[0].handb) {
                xtGraphics.fase = -4;
                u[0].enter = false;
                u[0].handb = false;
                recordtime = -7;
            } else {
                xtGraphics.levelhigh(Record.wasted, Record.whenwasted, Record.closefinish, recordtime, CheckPoints.stage);
                if (recordtime == 0 || recordtime == 1 || recordtime == 2) {
                    rd.setColor(new Color(0, 0, 0));
                    rd.fillRect(0, 0, 800, 450);
                }
                if (Record.wasted != xtGraphics.im) {
                    if (Record.closefinish == 0) {
                        if (clicknowtime == 9 || clicknowtime == 11) {
                            rd.setColor(new Color(255, 255, 255));
                            rd.fillRect(0, 0, 800, 450);
                        }
                        if (clicknowtime == 0) {
                            Medium.around(stageContos[xtGraphics.im], false);
                        }
                        if (clicknowtime > 0 && clicknowtime < 20) {
                            Medium.transaround(stageContos[xtGraphics.im], stageContos[Record.wasted], clicknowtime);
                        }
                        if (clicknowtime == 20) {
                            Medium.around(stageContos[Record.wasted], false);
                        }
                        if (recordtime > Record.whenwasted && clicknowtime != 20) {
                            clicknowtime++;
                        }
                        if ((clicknowtime == 0 || clicknowtime == 20) && ++recordtime == 300) {
                            recordtime = 0;
                            clicknowtime = 0;
                            finishrecording++;
                        }
                    } else if (Record.closefinish == 1) {
                        if (clicknowtime == 0) {
                            Medium.around(stageContos[xtGraphics.im], false);
                        }
                        if (clicknowtime > 0 && clicknowtime < 20) {
                            Medium.transaround(stageContos[xtGraphics.im], stageContos[Record.wasted], clicknowtime);
                        }
                        if (clicknowtime == 20) {
                            Medium.around(stageContos[Record.wasted], false);
                        }
                        if (clicknowtime > 20 && clicknowtime < 40) {
                            Medium.transaround(stageContos[Record.wasted], stageContos[xtGraphics.im], clicknowtime - 20);
                        }
                        if (clicknowtime == 40) {
                            Medium.around(stageContos[xtGraphics.im], false);
                        }
                        if (clicknowtime > 40 && clicknowtime < 60) {
                            Medium.transaround(stageContos[xtGraphics.im], stageContos[Record.wasted], clicknowtime - 40);
                        }
                        if (clicknowtime == 60) {
                            Medium.around(stageContos[Record.wasted], false);
                        }
                        if (recordtime > 160 && clicknowtime < 20) {
                            clicknowtime++;
                        }
                        if (recordtime > 230 && clicknowtime < 40) {
                            clicknowtime++;
                        }
                        if (recordtime > 280 && clicknowtime < 60) {
                            clicknowtime++;
                        }
                        if ((clicknowtime == 0 || clicknowtime == 20 || clicknowtime == 40 || clicknowtime == 60) && ++recordtime == 300) {
                            recordtime = 0;
                            clicknowtime = 0;
                            finishrecording++;
                        }
                    } else {
                        if (clicknowtime == 0) {
                            Medium.around(stageContos[xtGraphics.im], false);
                        }
                        if (clicknowtime > 0 && clicknowtime < 20) {
                            Medium.transaround(stageContos[xtGraphics.im], stageContos[Record.wasted], clicknowtime);
                        }
                        if (clicknowtime == 20) {
                            Medium.around(stageContos[Record.wasted], false);
                        }
                        if (clicknowtime > 20 && clicknowtime < 40) {
                            Medium.transaround(stageContos[Record.wasted], stageContos[xtGraphics.im], clicknowtime - 20);
                        }
                        if (clicknowtime == 40) {
                            Medium.around(stageContos[xtGraphics.im], false);
                        }
                        if (clicknowtime > 40 && clicknowtime < 60) {
                            Medium.transaround(stageContos[xtGraphics.im], stageContos[Record.wasted], clicknowtime - 40);
                        }
                        if (clicknowtime == 60) {
                            Medium.around(stageContos[Record.wasted], false);
                        }
                        if (clicknowtime > 60 && clicknowtime < 80) {
                            Medium.transaround(stageContos[Record.wasted], stageContos[xtGraphics.im], clicknowtime - 60);
                        }
                        if (clicknowtime == 80) {
                            Medium.around(stageContos[xtGraphics.im], false);
                        }
                        if (recordtime > 90 && clicknowtime < 20) {
                            clicknowtime++;
                        }
                        if (recordtime > 160 && clicknowtime < 40) {
                            clicknowtime++;
                        }
                        if (recordtime > 230 && clicknowtime < 60) {
                            clicknowtime++;
                        }
                        if (recordtime > 280 && clicknowtime < 80) {
                            clicknowtime++;
                        }
                        if ((clicknowtime == 0 || clicknowtime == 20 || clicknowtime == 40 || clicknowtime == 60 || clicknowtime == 80) && ++recordtime == 300) {
                            recordtime = 0;
                            clicknowtime = 0;
                            finishrecording++;
                        }
                    }
                } else {
                    if (wastedpoint == 67 && (clicknowtime == 3 || clicknowtime == 31 || clicknowtime == 66)) {
                        rd.setColor(new Color(255, 255, 255));
                        rd.fillRect(0, 0, 800, 450);
                    }
                    if (wastedpoint == 69 && (clicknowtime == 3 || clicknowtime == 5 || clicknowtime == 31 || clicknowtime == 33 || clicknowtime == 66 || clicknowtime == 68)) {
                        rd.setColor(new Color(255, 255, 255));
                        rd.fillRect(0, 0, 800, 450);
                    }
                    if (wastedpoint == 30 && clicknowtime >= 1 && clicknowtime < 30)
                        if (clicknowtime % (int) (2.0F + Medium.random() * 3.0F) == 0 && !flashingscreen) {
                            rd.setColor(new Color(255, 255, 255));
                            rd.fillRect(0, 0, 800, 450);
                            flashingscreen = true;
                        } else {
                            flashingscreen = false;
                        }
                    if (recordtime > Record.whenwasted && clicknowtime != wastedpoint) {
                        clicknowtime++;
                    }
                    Medium.around(stageContos[xtGraphics.im], false);
                    if ((clicknowtime == 0 || clicknowtime == wastedpoint) && ++recordtime == 300) {
                        recordtime = 0;
                        clicknowtime = 0;
                        finishrecording++;
                    }
                }
            }
        }
        if (xtGraphics.fase == -4) {
            if (recordtime == 0) {
                xtGraphics.sendwin();
                if (xtGraphics.winner && xtGraphics.multion == 0 && xtGraphics.gmode != 0 && CheckPoints.stage != xtGraphics.nTracks && CheckPoints.stage == xtGraphics.unlocked) {
                    xtGraphics.unlocked++;
                    setcarcookie(xtGraphics.sc[0], CarDefine.names[xtGraphics.sc[0]], xtGraphics.arnp, xtGraphics.gmode, xtGraphics.unlocked);
                    xtGraphics.unlocked--;
                }
            }
            if (recordtime <= 0) {
                rd.drawImage(Images.mdness, 289, 30, null);
                rd.drawImage(Images.dude[0], 135, 10, null);
            }
            if (recordtime >= 0) {
                xtGraphics.fleximage(offImage, recordtime);
            }
            if (++recordtime == 7) {
                xtGraphics.fase = -5;
                rd.setRenderingHint(RenderingHints.KEY_TEXT_ANTIALIASING, RenderingHints.VALUE_TEXT_ANTIALIAS_ON);
                rd.setRenderingHint(RenderingHints.KEY_ANTIALIASING, RenderingHints.VALUE_ANTIALIAS_ON);
            }
        }
        if (xtGraphics.fase == -6) {
            //repaint();
            xtGraphics.pauseimage(offImage);
            xtGraphics.fase = -7;
            mouses = 0;
        }
        if (xtGraphics.fase == -7) {
            xtGraphics.pausedgame(u[0]);
            if (recordtime != 0) {
                recordtime = 0;
            }
            xtGraphics.ctachm(xm, ym, mouses, u[0]);
            if (mouses == 2) {
                mouses = 0;
            }
            if (mouses == 1) {
                mouses = 2;
            }
        }
        if (xtGraphics.fase == -8) {
            xtGraphics.cantreply();
            if (++recordtime == 150 || u[0].enter || u[0].handb || mouses == 1) {
                xtGraphics.fase = -7;
                mouses = 0;
                u[0].enter = false;
                u[0].handb = false;
            }
        }
        if (lostfcs && xtGraphics.fase == 7001)
            if (fcscnt == 0) {
                if (u[0].chatup == 0) {
                    gsPanel.requestFocus();
                }
                fcscnt = 10;
            } else {
                fcscnt--;
            }
        if (xtGraphics.im > -1 && xtGraphics.im < 8) {
            int j = 0;
            if (xtGraphics.multion == 2 || xtGraphics.multion == 3) {
                j = xtGraphics.im;
                u[j].mutem = u[0].mutem;
                u[j].mutes = u[0].mutes;
            }
            if (xtGraphics.fase==0) {
                for (int i = 0; i < xtGraphics.nplayers; i++) {
                    xtGraphics.playsounds(i, mads[i], u[i], stageContos[0], stageContos[i]);
                }
            }
        }
        date = new Date();
        final long l = date.getTime();
        if (xtGraphics.fase == 0 || xtGraphics.fase == -1 || xtGraphics.fase == -3 || xtGraphics.fase == 7001) {
            if (!bool3) {
                f2 = f;
                if (f2 < 30.0F) {
                    f2 = 30.0F;
                }
                bool3 = true;
                i5 = 0;
            }
            if (i5 == 10) {
                float f = (i4 + udpmistro.freg - (l - l1)) / 20.0F;
                if (f > 40.0F) {
                    f = 40.0F;
                }
                if (f < -40.0F) {
                    f = -40.0F;
                }
                f2 += f;
                if (f2 < 5.0F) {
                    f2 = 5.0F;
                }
                Medium.adjstfade(f2, f, xtGraphics.starcnt, gsPanel);
                l1 = l;
                i5 = 0;
            } else {
                i5++;
            }
        } else {
            if (bool3) {
                f = f2;
                bool3 = false;
                i5 = 0;
            }
            if (i5 == 10) {
                if (l - l1 < 400L) {
                    f2 += 3.5;
                } else {
                    f2 -= 3.5;
                    if (f2 < 5.0F) {
                        f2 = 5.0F;
                    }
                }
                l1 = l;
                i5 = 0;
            } else {
                i5++;
            }
        }
        if (exwist) {
            trash();
        }

    }

    static void setcarcookie(final int i, final String string, final float[] fs, final int gamemode, final int is) {
        try {
            final File file = new File("" + Madness.fpath + "data/user.data");
            final String[] lines = {
                    "", "", "", "", ""
            };
            if (file.exists()) {
                final BufferedReader bufferedreader = new BufferedReader(new FileReader(file));
                String line;
                for (int j = 0; (line = bufferedreader.readLine()) != null && j < 5; j++) {
                    lines[j] = line;
                }
                bufferedreader.close();
            }
            if (gamemode == 0) {
                lines[1] = "lastcar(" + i + "," + (int) (fs[0] * 100.0F) + "," + (int) (fs[1] * 100.0F) + "," + (int) (fs[2] * 100.0F) + "," + (int) (fs[3] * 100.0F) + "," + (int) (fs[4] * 100.0F) + "," + (int) (fs[5] * 100.0F) + "," + string + ")";
            }
            if (gamemode == 1 || gamemode == 2) {
                lines[2] = "saved(" + i + "," + is + ")";
            }
            //if (i191 == 2)
            //	strings[3] = "" + ("NFM2(") + (i) + (")")
            //			;
            lines[4] = "graphics(" + moto + "," + Madness.anti + ")";
            final BufferedWriter bufferedwriter = new BufferedWriter(new FileWriter(file));
            for (int j = 0; j < 5; j++) {
                bufferedwriter.write(lines[j]);
                bufferedwriter.newLine();
            }
            bufferedwriter.close();
        } catch (final Exception ignored) {

        }
    }

    static void setloggedcookie() {
        try {
            final File file = new File("" + Madness.fpath + "data/user.data");
            final String[] lines = {
                    "", "", "", "", ""
            };
            if (file.exists()) {
                final BufferedReader bufferedreader = new BufferedReader(new FileReader(file));
                String line;
                for (int i = 0; (line = bufferedreader.readLine()) != null && i < 5; i++) {
                    lines[i] = line;
                }
                bufferedreader.close();
            }
            if (keplo.getState()) {
                lines[0] = "lastuser(" + tnick.getText() + "," + tpass.getText() + ")";
            } else {
                lines[0] = "lastuser(" + tnick.getText() + ")";
            }
            final BufferedWriter bufferedwriter = new BufferedWriter(new FileWriter(file));
            for (int i = 0; i < 5; i++) {
                bufferedwriter.write(lines[i]);
                bufferedwriter.newLine();
            }
            bufferedwriter.close();
        } catch (final Exception ignored) {

        }
    }

    static private void setupini() {
        Madness.inisetup = true;
        try {
            final File file = new File("" + Madness.fpath + "Madness.ini");
            if (file.exists()) {
                final String[] liness = new String[40];
                int i = 0;
                final BufferedReader bufferedreader = new BufferedReader(new FileReader(file));
                String line;
                for (; (line = bufferedreader.readLine()) != null && i < 40; i++) {
                    liness[i] = line;
                    if (liness[i].startsWith("Class Path"))
                        if (liness[i].contains("madapps.jar")) {
                            liness[i] = "Class Path=\\data\\madapps.jar;";
                        } else {
                            liness[i] = "Class Path=\\data\\madapp.jar;";
                        }
                    if (liness[i].startsWith("JRE Path")) {
                        liness[i] = "JRE Path=data\\jre\\";
                    }
                }
                bufferedreader.close();
                final BufferedWriter bufferedwriter = new BufferedWriter(new FileWriter(file));
                for (int j = 0; j < i; j++) {
                    bufferedwriter.write(liness[j]);
                    bufferedwriter.newLine();
                }
                bufferedwriter.close();
            }
        } catch (final Exception ignored) {

        }
        Madness.inisetup = false;
    }

    static private void sizescreen(final int x, final int y) {
        if (x > gsPanel.getWidth() / 2 - 230 && x < gsPanel.getWidth() / 2 - 68 && y > 21 && y < 39 || onbar) {
            reqmult = (x - (gsPanel.getWidth() / 2 - 222)) / 141.0F;
            if (reqmult < 0.1) {
                reqmult = 0.0F;
            }
            if (reqmult > 1.0F) {
                reqmult = 1.0F;
            }
            onbar = true;
            showsize = 100;
        }
    }

    /*-@Override
    static public void start() {
    	if (gamer == null)
    		gamer = new Thread(this);
    	gamer.start();
    }

    @Override
    static public void stop() {
    	if (exwist && gamer != null) {
    		System.gc();
    		gamer.interrupt();
    		gamer = null;
    	}
    	exwist = true;
    }*/

    /*@Override
    static public void update(final Graphics graphics) {
    	paint(graphics);
    }*/

    @Override
    public void keyTyped(final KeyEvent e) {
    }

    @Override
    public void keyPressed(final KeyEvent e) {
        if (!exwist) {
            //115 114 99
            if (e.getKeyCode() == KeyEvent.VK_UP) {
                u[0].up = true;
            }
            if (e.getKeyCode() == KeyEvent.VK_DOWN) {
                u[0].down = true;
            }
            if (e.getKeyCode() == KeyEvent.VK_RIGHT) {
                u[0].right = true;
            }
            if (e.getKeyCode() == KeyEvent.VK_LEFT) {
                u[0].left = true;
            }
            if (e.getKeyCode() == KeyEvent.VK_SPACE) {
                u[0].handb = true;
            }
            if (e.getKeyCode() == KeyEvent.VK_ENTER) {
                u[0].enter = true;
            }
            if (e.getKeyCode() == KeyEvent.VK_Z) {
                u[0].lookback = -1;
            }
            if (e.getKeyCode() == KeyEvent.VK_X) {
                u[0].lookback = 1;
            }
            if (e.getKeyCode() == KeyEvent.VK_M)
                u[0].mutem = !u[0].mutem;
            if (e.getKeyCode() == KeyEvent.VK_N)
                u[0].mutes = !u[0].mutes;
            if (e.getKeyCode() == KeyEvent.VK_A)
                u[0].arrace = !u[0].arrace;
            if (e.getKeyCode() == KeyEvent.VK_S)
                u[0].radar = !u[0].radar;
            if (e.getKeyCode() == KeyEvent.VK_V) {
                view++;
                if (view == 3) {
                    view = 0;
                }
            }
        }
    }

    @Override
    public void keyReleased(final KeyEvent e) {
        if (!exwist) {
            if (u[0].multion < 2) {
                if (e.getKeyCode() == KeyEvent.VK_UP) {
                    u[0].up = false;
                }
                if (e.getKeyCode() == KeyEvent.VK_DOWN) {
                    u[0].down = false;
                }
                if (e.getKeyCode() == KeyEvent.VK_RIGHT) {
                    u[0].right = false;
                }
                if (e.getKeyCode() == KeyEvent.VK_LEFT) {
                    u[0].left = false;
                }
                if (e.getKeyCode() == KeyEvent.VK_SPACE) {
                    u[0].handb = false;
                }
            }
            if (e.getKeyCode() == 27) {
                u[0].exit = false;
                if (Madness.fullscreen) {
                    Madness.exitfullscreen();
                }
            }
            if (e.getKeyCode() == KeyEvent.VK_X || e.getKeyCode() == KeyEvent.VK_Z) {
                u[0].lookback = 0;
            }
        }
    }

    @Override
    public void mouseDragged(final MouseEvent e) {
        final int x = e.getX();
        final int y = e.getY();
        if (!exwist && !lostfcs) {
            xm = (int) ((x - apx) / apmult);
            ym = (int) ((y - apy) / apmult);
        }
        if (!Madness.fullscreen) {
            sizescreen(x, y);
        }
    }

    @Override
    public void mouseMoved(final MouseEvent e) {
        final int x = e.getX();
        final int y = e.getY();
        if (!exwist && !lostfcs) {
            xm = (int) ((x - apx) / apmult);
            ym = (int) ((y - apy) / apmult);
        }
        if (!Madness.fullscreen) {
            if (showsize < 20) {
                showsize = 20;
            }
            if (x > 50 && x < 192 && y > 14 && y < 37) {
                if (!oncarm) {
                    oncarm = true;
                    setCursor(new Cursor(12));
                }
            } else if (oncarm) {
                oncarm = false;
                setCursor(new Cursor(0));
            }
            if (x > getWidth() - 208 && x < getWidth() - 50 && y > 14 && y < 37) {
                if (!onstgm) {
                    onstgm = true;
                    setCursor(new Cursor(12));
                }
            } else if (onstgm) {
                onstgm = false;
                setCursor(new Cursor(0));
            }
            if (x > getWidth() / 2 + 22 && x < getWidth() / 2 + 122 && y > 14 && y < 37) {
                if (!onfulls) {
                    onfulls = true;
                    setCursor(new Cursor(12));
                }
            } else if (onfulls) {
                onfulls = false;
                setCursor(new Cursor(0));
            }
        }
    }

    @Override
    public void mouseClicked(final MouseEvent e) {
    }

    @Override
    public void mousePressed(final MouseEvent e) {
        final int x = e.getX();
        final int y = e.getY();
        requestFocus();
        if (!exwist) {
            if (mouses == 0) {
                xm = (int) ((x - apx) / apmult);
                ym = (int) ((y - apy) / apmult);
                mouses = 1;
            }
            moused = true;
        }
        if (!Madness.fullscreen) {
            sizescreen(x, y);
        }
    }

    @Override
    public void mouseReleased(final MouseEvent e) {
        final int x = e.getX();
        final int y = e.getY();
        if (!exwist) {
            if (mouses == 11) {
                xm = (int) ((x - apx) / apmult);
                ym = (int) ((y - apy) / apmult);
                mouses = -1;
            }
            moused = false;
        }
        if (!Madness.fullscreen) {
            if (x > getWidth() / 2 - 55 && x < getWidth() / 2 + 7 && y > 21 && y < 38 && !onbar) {
                if (smooth == 1) {
                    smooth = 0;
                } else {
                    smooth = 1;
                }
                showsize = 60;
            }
            if (x > getWidth() / 2 + 133 && x < getWidth() / 2 + 231 && y > 7 && y < 24 && !onbar) {
                if (Madness.anti == 0) {
                    Madness.anti = 1;
                } else {
                    Madness.anti = 0;
                }
                showsize = 60;
            }
            if (x > getWidth() / 2 + 133 && x < getWidth() / 2 + 231 && y > 24 && y < 41 && !onbar) {
                if (moto == 0) {
                    moto = 1;
                    
                    // create a new triple buffer
                    makeTriBuffer();
                } else {
                    moto = 0;
                    
                    // dispose of the triple buffer
                    tg.dispose();
                    tribuffer.flush();
                }
                showsize = 60;
            }
            if (onfulls) {
                Madness.gofullscreen();
            }
            if (oncarm) {
                Madness.carmaker();
            }
            if (onstgm) {
                Madness.stagemaker();
            }
            onbar = false;
        }
    }

    static private void makeTriBuffer() {
        tribuffer = new BufferedImage(800, 450, BufferedImage.TYPE_INT_ARGB);
        if (tribuffer != null) {
            tg = tribuffer.createGraphics();
        } else {
            throw new IllegalAccessError("failed to create TriBuffer image");
        }
    }

    @Override
    public void mouseEntered(final MouseEvent e) {
    }

    @Override
    public void mouseExited(final MouseEvent e) {
    }

    @Override
    public void focusGained(final FocusEvent e) {
        if (!exwist && lostfcs) {
            lostfcs = false;
        }
    }

    @Override
    public void focusLost(final FocusEvent e) {
        if (!exwist && !lostfcs) {
            lostfcs = true;
            fcscnt = 10;
            if (u[0] != null) {
                if (u[0].multion == 0) {
                    u[0].falseo(1);
                } else if (u[0].chatup == 0) {
                    requestFocus();
                }
                setCursor(new Cursor(0));
            }
        }
    }

}
