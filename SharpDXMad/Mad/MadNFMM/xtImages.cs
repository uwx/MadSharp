namespace Cum
{
    public class xtImages
    {
        
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

    }private static Image cbg1, cbg2;
    
    private static final ImageIdentifier[] idts = {

        new ImageIdentifier("cars.gif", (ais, mediatracker, toolkit) -> {
            carsbg = loadBimage(ais, mediatracker, toolkit, 1);
        }),
        new ImageIdentifier("color.gif", (ais, mediatracker, toolkit) -> {
            cbg1 = loadBimage(ais, mediatracker, toolkit, 0);
            
            if (cbg1 != null && cbg2 != null)
                makecarsbgc(cbg1, cbg2);
        }),
        new ImageIdentifier("class.gif", (ais, mediatracker, toolkit) -> {
            cbg2 = loadBimage(ais, mediatracker, toolkit, 0);

            if (cbg1 != null && cbg2 != null)
                makecarsbgc(cbg1, cbg2);
        }),
        new ImageIdentifier("smokey.gif", (ais, mediatracker, toolkit) -> {
            smokeypix(ais, mediatracker, toolkit);
        }),
        new ImageIdentifier("1.gif", (ais, mediatracker, toolkit) -> {
            orank[0] = loadimage(ais, mediatracker, toolkit);
        }),
        new ImageIdentifier("gameh.gif", (ais, mediatracker, toolkit) -> {
            ogameh = loadimage(ais, mediatracker, toolkit);
        }),
        new ImageIdentifier("wgame.gif", (ais, mediatracker, toolkit) -> {
            owgame = loadimage(ais, mediatracker, toolkit);
        }),
        new ImageIdentifier("gameov.gif", (ais, mediatracker, toolkit) -> {
            gameov = loadimage(ais, mediatracker, toolkit);
        }),
        new ImageIdentifier("lap.gif", (ais, mediatracker, toolkit) -> {
            olap = loadimage(ais, mediatracker, toolkit);
        }),
        new ImageIdentifier("paused.gif", (ais, mediatracker, toolkit) -> {
            paused = loadimage(ais, mediatracker, toolkit);
        }),
        new ImageIdentifier("select.gif", (ais, mediatracker, toolkit) -> {
            select = loadimage(ais, mediatracker, toolkit);
        }),
        new ImageIdentifier("yourwasted.gif", (ais, mediatracker, toolkit) -> {
            oyourwasted = loadimage(ais, mediatracker, toolkit);
        }),
        new ImageIdentifier("disco.gif", (ais, mediatracker, toolkit) -> {
            odisco = loadimage(ais, mediatracker, toolkit);
        }),
        new ImageIdentifier("youwastedem.gif", (ais, mediatracker, toolkit) -> {
            oyouwastedem = loadimage(ais, mediatracker, toolkit);
        }),
        new ImageIdentifier("gamefinished.gif", (ais, mediatracker, toolkit) -> {
            ogamefinished = loadimage(ais, mediatracker, toolkit);
        }),
        new ImageIdentifier("exitgame.gif", (ais, mediatracker, toolkit) -> {
            oexitgame = loadimage(ais, mediatracker, toolkit);
        }),
        new ImageIdentifier("pgate.gif", (ais, mediatracker, toolkit) -> {
            pgate = loadimage(ais, mediatracker, toolkit);
        }),
        new ImageIdentifier("d1.png", (ais, mediatracker, toolkit) -> {
            dude[0] = loadimage(ais, mediatracker, toolkit);
        }),
        new ImageIdentifier("d2.png", (ais, mediatracker, toolkit) -> {
            dude[1] = loadimage(ais, mediatracker, toolkit);
        }),
        new ImageIdentifier("d3.png", (ais, mediatracker, toolkit) -> {
            dude[2] = loadimage(ais, mediatracker, toolkit);
        }),
        new ImageIdentifier("float.gif", (ais, mediatracker, toolkit) -> {
            oflaot = loadimage(ais, mediatracker, toolkit);
        }),
        new ImageIdentifier("1c.gif", (ais, mediatracker, toolkit) -> {
            ocntdn[1] = loadimage(ais, mediatracker, toolkit);
        }),
        new ImageIdentifier("2c.gif", (ais, mediatracker, toolkit) -> {
            ocntdn[2] = loadimage(ais, mediatracker, toolkit);
        }),
        new ImageIdentifier("3c.gif", (ais, mediatracker, toolkit) -> {
            ocntdn[3] = loadimage(ais, mediatracker, toolkit);
        }),
        new ImageIdentifier("2.gif", (ais, mediatracker, toolkit) -> {
            orank[1] = loadimage(ais, mediatracker, toolkit);
        }),
        new ImageIdentifier("3.gif", (ais, mediatracker, toolkit) -> {
            orank[2] = loadimage(ais, mediatracker, toolkit);
        }),
        new ImageIdentifier("4.gif", (ais, mediatracker, toolkit) -> {
            orank[3] = loadimage(ais, mediatracker, toolkit);
        }),
        new ImageIdentifier("5.gif", (ais, mediatracker, toolkit) -> {
            orank[4] = loadimage(ais, mediatracker, toolkit);
        }),
        new ImageIdentifier("6.gif", (ais, mediatracker, toolkit) -> {
            orank[5] = loadimage(ais, mediatracker, toolkit);
        }),
        new ImageIdentifier("7.gif", (ais, mediatracker, toolkit) -> {
            orank[6] = loadimage(ais, mediatracker, toolkit);
        }),
        new ImageIdentifier("8.gif", (ais, mediatracker, toolkit) -> {
            orank[7] = loadimage(ais, mediatracker, toolkit);
        }),
        new ImageIdentifier("bgmain.jpg", (ais, mediatracker, toolkit) -> {
            bgmain = loadBimage(ais, mediatracker, toolkit, 2);
        }),
        new ImageIdentifier("br.png", (ais, mediatracker, toolkit) -> {
            br = loadimage(ais, mediatracker, toolkit);
        }),
        new ImageIdentifier("loadingmusic.gif", (ais, mediatracker, toolkit) -> {
            oloadingmusic = loadimage(ais, mediatracker, toolkit);
        }),
        new ImageIdentifier("radicalplay.gif", (ais, mediatracker, toolkit) -> {
            radicalplay = loadimage(ais, mediatracker, toolkit);
        }),
        new ImageIdentifier("back.gif", (ais, mediatracker, toolkit) -> {
            back[0] = loadimage(ais, mediatracker, toolkit);
            back[1] = bressed(back[0]);
        }),
        new ImageIdentifier("continue.gif", (ais, mediatracker, toolkit) -> {
            contin[0] = loadimage(ais, mediatracker, toolkit);
            contin[1] = bressed(contin[0]);
        }),
        new ImageIdentifier("next.gif", (ais, mediatracker, toolkit) -> {
            next[0] = loadimage(ais, mediatracker, toolkit);
            next[1] = bressed(next[0]);
        }),
        new ImageIdentifier("rpro.gif", (ais, mediatracker, toolkit) -> {
            rpro = loadimage(ais, mediatracker, toolkit);
        }),
        new ImageIdentifier("selectcar.gif", (ais, mediatracker, toolkit) -> {
            selectcar = loadimage(ais, mediatracker, toolkit);
        }),
        new ImageIdentifier("track.jpg", (ais, mediatracker, toolkit) -> {
            trackbg[0] = loadBimage(ais, mediatracker, toolkit, 3);
            trackbg[1] = dodgen(trackbg[0]);
        }),
        new ImageIdentifier("youlost.gif", (ais, mediatracker, toolkit) -> {
            oyoulost = loadimage(ais, mediatracker, toolkit);
        }),
        new ImageIdentifier("youwon.gif", (ais, mediatracker, toolkit) -> {
            oyouwon = loadimage(ais, mediatracker, toolkit);
        }),
        new ImageIdentifier("0c.gif", (ais, mediatracker, toolkit) -> {
            ocntdn[0] = loadimage(ais, mediatracker, toolkit);
        }),
        new ImageIdentifier("damage.gif", (ais, mediatracker, toolkit) -> {
            odmg = loadimage(ais, mediatracker, toolkit);
        }),
        new ImageIdentifier("power.gif", (ais, mediatracker, toolkit) -> {
            opwr = loadimage(ais, mediatracker, toolkit);
        }),
        new ImageIdentifier("position.gif", (ais, mediatracker, toolkit) -> {
            opos = loadimage(ais, mediatracker, toolkit);
        }),
        new ImageIdentifier("speed.gif", (ais, mediatracker, toolkit) -> {
            osped = loadimage(ais, mediatracker, toolkit);
        }),
        new ImageIdentifier("wasted.gif", (ais, mediatracker, toolkit) -> {
            owas = loadimage(ais, mediatracker, toolkit);
        }),
        new ImageIdentifier("start1.gif", (ais, mediatracker, toolkit) -> {
            ostar[0] = loadimage(ais, mediatracker, toolkit);
        }),
        new ImageIdentifier("start2.gif", (ais, mediatracker, toolkit) -> {
            ostar[1] = loadimage(ais, mediatracker, toolkit);
            star[2] = pressed(ostar[1]);
        }),
        new ImageIdentifier("congrad.gif", (ais, mediatracker, toolkit) -> {
            congrd = loadimage(ais, mediatracker, toolkit);
        }),
        new ImageIdentifier("statb.gif", (ais, mediatracker, toolkit) -> {
            statb = loadimage(ais, mediatracker, toolkit);
        }),
        new ImageIdentifier("statbo.gif", (ais, mediatracker, toolkit) -> {
            statbo = loadimage(ais, mediatracker, toolkit);
        }),
        new ImageIdentifier("madness.gif", (ais, mediatracker, toolkit) -> {
            mdness = loadude(ais, mediatracker, toolkit);
        }),
//            new ImageIdentifier("onfmm.gif", (ais, mediatracker, toolkit) -> {
//                onfmm = loadude(ais, mediatracker, toolkit);
//            }),
        new ImageIdentifier("fixhoop.png", (ais, mediatracker, toolkit) -> {
            fixhoop = loadimage(ais, mediatracker, toolkit);
        }),
        new ImageIdentifier("arrow.gif", (ais, mediatracker, toolkit) -> {
            sarrow = loadimage(ais, mediatracker, toolkit);
        }),
        new ImageIdentifier("stunts.png", (ais, mediatracker, toolkit) -> {
            stunts = loadimage(ais, mediatracker, toolkit);
        }),
        new ImageIdentifier("racing.gif", (ais, mediatracker, toolkit) -> {
            racing = loadimage(ais, mediatracker, toolkit);
        }),
        new ImageIdentifier("wasting.gif", (ais, mediatracker, toolkit) -> {
            wasting = loadimage(ais, mediatracker, toolkit);
        }),
        new ImageIdentifier("plus.gif", (ais, mediatracker, toolkit) -> {
            plus = loadimage(ais, mediatracker, toolkit);
        }),
        new ImageIdentifier("space.gif", (ais, mediatracker, toolkit) -> {
            space = loadimage(ais, mediatracker, toolkit);
        }),
        new ImageIdentifier("arrows.gif", (ais, mediatracker, toolkit) -> {
            arrows = loadimage(ais, mediatracker, toolkit);
        }),
        new ImageIdentifier("chil.gif", (ais, mediatracker, toolkit) -> {
            chil = loadimage(ais, mediatracker, toolkit);
        }),
        new ImageIdentifier("ory.gif", (ais, mediatracker, toolkit) -> {
            ory = loadimage(ais, mediatracker, toolkit);
        }),
        new ImageIdentifier("kz.gif", (ais, mediatracker, toolkit) -> {
            kz = loadimage(ais, mediatracker, toolkit);
        }),
        new ImageIdentifier("kx.gif", (ais, mediatracker, toolkit) -> {
            kx = loadimage(ais, mediatracker, toolkit);
        }),
        new ImageIdentifier("kv.gif", (ais, mediatracker, toolkit) -> {
            kv = loadimage(ais, mediatracker, toolkit);
        }),
        new ImageIdentifier("km.gif", (ais, mediatracker, toolkit) -> {
            km = loadimage(ais, mediatracker, toolkit);
        }),
        new ImageIdentifier("kn.gif", (ais, mediatracker, toolkit) -> {
            kn = loadimage(ais, mediatracker, toolkit);
        }),
        new ImageIdentifier("ks.gif", (ais, mediatracker, toolkit) -> {
            ks = loadimage(ais, mediatracker, toolkit);
        }),
        new ImageIdentifier("kenter.gif", (ais, mediatracker, toolkit) -> {
            kenter = loadimage(ais, mediatracker, toolkit);
        }),
        new ImageIdentifier("nfm.gif", (ais, mediatracker, toolkit) -> {
            nfm = loadimage(ais, mediatracker, toolkit);
        }),
        new ImageIdentifier("options.png", (ais, mediatracker, toolkit) -> {
            opti = loadimage(ais, mediatracker, toolkit);
        }),
        new ImageIdentifier("opback.png", (ais, mediatracker, toolkit) -> {
            opback = loadimage(ais, mediatracker, toolkit);
        }),
        new ImageIdentifier("logocars.png", (ais, mediatracker, toolkit) -> {
            logocars = loadimage(ais, mediatracker, toolkit);
        }),
        new ImageIdentifier("logomad.png", (ais, mediatracker, toolkit) -> {
            logomadnes = loadimage(ais, mediatracker, toolkit);
        }),
        new ImageIdentifier("logomadbg.jpg", (ais, mediatracker, toolkit) -> {
            logomadbg = loadimage(ais, mediatracker, toolkit);
        }),
        new ImageIdentifier("byrd.png", (ais, mediatracker, toolkit) -> {
            byrd = loadimage(ais, mediatracker, toolkit);
        }),
        new ImageIdentifier("bggo.jpg", (ais, mediatracker, toolkit) -> {
            bggo = loadimage(ais, mediatracker, toolkit);
        }),
        new ImageIdentifier("nfmcoms.png", (ais, mediatracker, toolkit) -> {
            nfmcoms = loadimage(ais, mediatracker, toolkit);
        }),
        new ImageIdentifier("nfmcom.gif", (ais, mediatracker, toolkit) -> {
            nfmcom = loadBimage(ais, mediatracker, toolkit, 0);
        }),
        new ImageIdentifier("brit.gif", (ais, mediatracker, toolkit) -> {
            brt = loadimage(ais, mediatracker, toolkit);
        }),
        new ImageIdentifier("arn.gif", (ais, mediatracker, toolkit) -> {
            arn = loadimage(ais, mediatracker, toolkit);
        }),
        new ImageIdentifier("mload.gif", (ais, mediatracker, toolkit) -> {
            mload = loadimage(ais, mediatracker, toolkit);
        }),
        new ImageIdentifier("login.gif", (ais, mediatracker, toolkit) -> {
            login = loadBimage(ais, mediatracker, toolkit, 0);
        }),
        new ImageIdentifier("play.gif", (ais, mediatracker, toolkit) -> {
            play = loadBimage(ais, mediatracker, toolkit, 0);
        }),
        new ImageIdentifier("cancel.gif", (ais, mediatracker, toolkit) -> {
            cancel = loadBimage(ais, mediatracker, toolkit, 0);
        }),
        new ImageIdentifier("register.gif", (ais, mediatracker, toolkit) -> {
            register = loadBimage(ais, mediatracker, toolkit, 0);
        }),
        new ImageIdentifier("upgrade.gif", (ais, mediatracker, toolkit) -> {
            upgrade = loadimage(ais, mediatracker, toolkit);
        }),
        new ImageIdentifier("sdets.gif", (ais, mediatracker, toolkit) -> {
            sdets = loadBimage(ais, mediatracker, toolkit, 0);
        }),
        new ImageIdentifier("bob.gif", (ais, mediatracker, toolkit) -> {
            bob = loadBimage(ais, mediatracker, toolkit, 1);
        }),
        new ImageIdentifier("bot.gif", (ais, mediatracker, toolkit) -> {
            bot = loadBimage(ais, mediatracker, toolkit, 1);
        }),
        new ImageIdentifier("bol.gif", (ais, mediatracker, toolkit) -> {
            bol = loadBimage(ais, mediatracker, toolkit, 0);
        }),
        new ImageIdentifier("bolp.gif", (ais, mediatracker, toolkit) -> {
            bolp = loadBimage(ais, mediatracker, toolkit, 0);
        }),
        new ImageIdentifier("bor.gif", (ais, mediatracker, toolkit) -> {
            bor = loadBimage(ais, mediatracker, toolkit, 0);
        }),
        new ImageIdentifier("borp.gif", (ais, mediatracker, toolkit) -> {
            borp = loadBimage(ais, mediatracker, toolkit, 0);
        }),
        new ImageIdentifier("logout.gif", (ais, mediatracker, toolkit) -> {
            logout = loadBimage(ais, mediatracker, toolkit, 0);
        }),
        new ImageIdentifier("change.gif", (ais, mediatracker, toolkit) -> {
            change = loadBimage(ais, mediatracker, toolkit, 0);
        }),
        new ImageIdentifier("pln.gif", (ais, mediatracker, toolkit) -> {
            pln = loadBimage(ais, mediatracker, toolkit, 0);
        }),
        new ImageIdentifier("bols.gif", (ais, mediatracker, toolkit) -> {
            bols = loadBimage(ais, mediatracker, toolkit, 0);
        }),
        new ImageIdentifier("bolps.gif", (ais, mediatracker, toolkit) -> {
            bolps = loadBimage(ais, mediatracker, toolkit, 0);
        }),
        new ImageIdentifier("bors.gif", (ais, mediatracker, toolkit) -> {
            bors = loadBimage(ais, mediatracker, toolkit, 0);
        }),
        new ImageIdentifier("borps.gif", (ais, mediatracker, toolkit) -> {
            borps = loadBimage(ais, mediatracker, toolkit, 0);
        }),
        new ImageIdentifier("games.gif", (ais, mediatracker, toolkit) -> {
            games = loadBimage(ais, mediatracker, toolkit, 0);
        }),
        new ImageIdentifier("exit.gif", (ais, mediatracker, toolkit) -> {
            exit = loadBimage(ais, mediatracker, toolkit, 0);
        }),
        new ImageIdentifier("roomp.gif", (ais, mediatracker, toolkit) -> {
            roomp = loadBimage(ais, mediatracker, toolkit, 0);
        }),
        new ImageIdentifier("ready.gif", (ais, mediatracker, toolkit) -> {
            redy = loadBimage(ais, mediatracker, toolkit, 0);
        }),
        new ImageIdentifier("notreg.gif", (ais, mediatracker, toolkit) -> {
            ntrg = loadBimage(ais, mediatracker, toolkit, 0);
        }),
        new ImageIdentifier("cgame.gif", (ais, mediatracker, toolkit) -> {
            cgame = loadBimage(ais, mediatracker, toolkit, 0);
        }),
        new ImageIdentifier("ccar.gif", (ais, mediatracker, toolkit) -> {
            ccar = loadBimage(ais, mediatracker, toolkit, 0);
        }),
        new ImageIdentifier("lanm.gif", (ais, mediatracker, toolkit) -> {
            lanm = loadBimage(ais, mediatracker, toolkit, 0);
        }),
        new ImageIdentifier("asu.gif", (ais, mediatracker, toolkit) -> {
            asu = loadimage(ais, mediatracker, toolkit);
        }),
        new ImageIdentifier("asd.gif", (ais, mediatracker, toolkit) -> {
            asd = loadimage(ais, mediatracker, toolkit);
        }),
        new ImageIdentifier("pls.gif", (ais, mediatracker, toolkit) -> {
            pls = loadBimage(ais, mediatracker, toolkit, 0);
        }),
        new ImageIdentifier("sts.gif", (ais, mediatracker, toolkit) -> {
            sts = loadBimage(ais, mediatracker, toolkit, 0);
        }),
        new ImageIdentifier("gmc.gif", (ais, mediatracker, toolkit) -> {
            gmc = loadBimage(ais, mediatracker, toolkit, 0);
        }),
        new ImageIdentifier("stg.gif", (ais, mediatracker, toolkit) -> {
            stg = loadBimage(ais, mediatracker, toolkit, 0);
        }),
        new ImageIdentifier("crd.gif", (ais, mediatracker, toolkit) -> {
            crd = loadBimage(ais, mediatracker, toolkit, 0);
        }),
        new ImageIdentifier("bcl.gif", (ais, mediatracker, toolkit) -> {
            bcl[0] = loadimage(ais, mediatracker, toolkit);
        }),
        new ImageIdentifier("bcr.gif", (ais, mediatracker, toolkit) -> {
            bcr[0] = loadimage(ais, mediatracker, toolkit);
        }),
        new ImageIdentifier("bc.gif", (ais, mediatracker, toolkit) -> {
            bc[0] = loadimage(ais, mediatracker, toolkit);
        }),
        new ImageIdentifier("pbcl.gif", (ais, mediatracker, toolkit) -> {
            bcl[1] = loadimage(ais, mediatracker, toolkit);
        }),
        new ImageIdentifier("pbcr.gif", (ais, mediatracker, toolkit) -> {
            bcr[1] = loadimage(ais, mediatracker, toolkit);
        }),
        new ImageIdentifier("pbc.gif", (ais, mediatracker, toolkit) -> {
            bc[1] = loadimage(ais, mediatracker, toolkit);
        }),
        new ImageIdentifier("yac.gif", (ais, mediatracker, toolkit) -> {
            yac = loadimage(ais, mediatracker, toolkit);
        }),
        new ImageIdentifier("ycmc.gif", (ais, mediatracker, toolkit) -> {
            ycmc = loadimage(ais, mediatracker, toolkit);
        }),
    };
    
    }
}