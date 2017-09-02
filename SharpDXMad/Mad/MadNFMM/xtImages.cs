using System;
using static Cum.xtImages.Images;
using static Cum.xtGraphics;
using static Cum.xtPart2;

namespace Cum
{
    public class xtImages
    {
        
    internal static class Images {
        internal static Image arn;
        internal static Image arrows;
        internal static Image asd;
        internal static Image asu;
        internal static readonly Image[] back = new Image[2];
        internal static readonly Image[] bc = new Image[2];
        internal static readonly Image[] bcl = new Image[2];
        internal static readonly Image[] bcr = new Image[2];
        internal static Image bggo;
        internal static Image bgmain;
        internal static Image bob;
        internal static Image bol;
        internal static Image bolp;
        internal static Image bolps;
        internal static Image bols;
        internal static Image bor;
        internal static Image borp;
        internal static Image borps;
        internal static Image bors;
        internal static Image bot;
        internal static Image br;
        internal static Image brt;
        internal static Image byrd;
        internal static Image cancel;
        internal static Image carsbg;
        internal static Image carsbgc;
        internal static Image ccar;
        internal static Image cgame;
        internal static Image change;
        internal static Image chil;
        internal static readonly Image[] cntdn = new Image[4];
        internal static Image congrd;
        internal static readonly Image[] contin = new Image[2];
        internal static Image crd;
        internal static Image disco;
        internal static Image dmg;
        internal static readonly Image[] dude = new Image[3];
        internal static Image exit;
        internal static Image exitgame;
        internal static Image fixhoop;
        internal static Image flaot;
        internal static Image fleximg;
        internal static Image gamefinished;
        internal static Image gameh;
        internal static Image gameov;
        internal static Image games;
        internal static Image gmc;
        internal static Image hello;
        internal static Image kenter;
        internal static Image km;
        internal static Image kn;
        internal static Image ks;
        internal static Image kv;
        internal static Image kx;
        internal static Image kz;
        internal static Image lanm;
        internal static Image lap;
        internal static Image loadbar;
        internal static Image loadingmusic;
        internal static Image login;
        internal static Image logocars;
        internal static Image logomadbg;
        internal static Image logomadnes;
        internal static Image logout;
        internal static Image mdness;
        internal static Image mload;
        internal static readonly Image[] next = new Image[2];
        internal static Image nfm;
        internal static Image nfmcom;
        internal static Image nfmcoms;
        internal static Image ntrg;
        internal static readonly Image[] ocntdn = new Image[4];
        internal static Image odisco;
        internal static Image odmg;
        internal static Image oexitgame;
        internal static Image oflaot;
        internal static Image ogamefinished;
        internal static Image ogameh;
        internal static Image olap;
        internal static Image oloadingmusic;
        internal static Image onfmm;
        internal static Image opback;
        internal static Image opos;
        internal static Image opti;
        internal static Image opwr;
        internal static readonly Image[] orank = new Image[8];
        internal static Image ory;
        internal static Image osped;
        internal static readonly Image[] ostar = new Image[2];
        internal static Image owas;
        internal static Image owgame;
        internal static Image oyoulost;
        internal static Image oyourwasted;
        internal static Image oyouwastedem;
        internal static Image oyouwon;
        internal static Image paused;
        internal static Image pgate;
        internal static Image play;
        internal static Image pln;
        internal static Image pls;
        internal static Image plus;
        internal static Image pos;
        internal static Image pwr;
        internal static Image racing;
        internal static Image radicalplay;
        internal static readonly Image[] rank = new Image[8];
        internal static Image redy;
        internal static Image register;
        internal static Image roomp;
        internal static Image rpro;
        internal static Image sarrow;
        internal static Image sdets;
        internal static Image select;
        internal static Image selectcar;
        internal static Image sign;
        internal static Image space;
        internal static Image sped;
        internal static readonly Image[] star = new Image[3];
        internal static Image statb;
        internal static Image statbo;
        internal static Image stg;
        internal static Image sts;
        internal static Image stunts;
        internal static readonly Image[] trackbg = new Image[2];
        internal static Image upgrade;
        internal static Image was;
        internal static Image wasting;
        internal static Image wgame;
        internal static Image yac;
        internal static Image ycmc;
        internal static Image youlost;
        internal static Image yourwasted;
        internal static Image youwastedem;
        internal static Image youwon;

    }

        internal delegate void Accept(byte[] ais);
        
        internal class ImageIdentifier {
            internal readonly String fileName;
            internal readonly Accept cons;
            internal ImageIdentifier(String s, Accept c) {
                cons=c;
                fileName=s;
            }
        }
        
        private static Image cbg1, cbg2;
    
    private static readonly ImageIdentifier[] idts = {

        new ImageIdentifier("cars.gif", (ais) => {
            carsbg = loadBimage(ais, 1);
        }),
        new ImageIdentifier("color.gif", (ais) => {
            cbg1 = loadBimage(ais, 0);
            
            if (cbg1 != null && cbg2 != null)
                makecarsbgc(cbg1, cbg2);
        }),
        new ImageIdentifier("class.gif", (ais) => {
            cbg2 = loadBimage(ais, 0);

            if (cbg1 != null && cbg2 != null)
                makecarsbgc(cbg1, cbg2);
        }),
        new ImageIdentifier("smokey.gif", (ais) => {
            smokeypix(ais);
        }),
        new ImageIdentifier("1.gif", (ais) => {
            orank[0] = loadimage(ais);
        }),
        new ImageIdentifier("gameh.gif", (ais) => {
            ogameh = loadimage(ais);
        }),
        new ImageIdentifier("wgame.gif", (ais) => {
            owgame = loadimage(ais);
        }),
        new ImageIdentifier("gameov.gif", (ais) => {
            gameov = loadimage(ais);
        }),
        new ImageIdentifier("lap.gif", (ais) => {
            olap = loadimage(ais);
        }),
        new ImageIdentifier("paused.gif", (ais) => {
            paused = loadimage(ais);
        }),
        new ImageIdentifier("select.gif", (ais) => {
            select = loadimage(ais);
        }),
        new ImageIdentifier("yourwasted.gif", (ais) => {
            oyourwasted = loadimage(ais);
        }),
        new ImageIdentifier("disco.gif", (ais) => {
            odisco = loadimage(ais);
        }),
        new ImageIdentifier("youwastedem.gif", (ais) => {
            oyouwastedem = loadimage(ais);
        }),
        new ImageIdentifier("gamefinished.gif", (ais) => {
            ogamefinished = loadimage(ais);
        }),
        new ImageIdentifier("exitgame.gif", (ais) => {
            oexitgame = loadimage(ais);
        }),
        new ImageIdentifier("pgate.gif", (ais) => {
            pgate = loadimage(ais);
        }),
        new ImageIdentifier("d1.png", (ais) => {
            dude[0] = loadimage(ais);
        }),
        new ImageIdentifier("d2.png", (ais) => {
            dude[1] = loadimage(ais);
        }),
        new ImageIdentifier("d3.png", (ais) => {
            dude[2] = loadimage(ais);
        }),
        new ImageIdentifier("float.gif", (ais) => {
            oflaot = loadimage(ais);
        }),
        new ImageIdentifier("1c.gif", (ais) => {
            ocntdn[1] = loadimage(ais);
        }),
        new ImageIdentifier("2c.gif", (ais) => {
            ocntdn[2] = loadimage(ais);
        }),
        new ImageIdentifier("3c.gif", (ais) => {
            ocntdn[3] = loadimage(ais);
        }),
        new ImageIdentifier("2.gif", (ais) => {
            orank[1] = loadimage(ais);
        }),
        new ImageIdentifier("3.gif", (ais) => {
            orank[2] = loadimage(ais);
        }),
        new ImageIdentifier("4.gif", (ais) => {
            orank[3] = loadimage(ais);
        }),
        new ImageIdentifier("5.gif", (ais) => {
            orank[4] = loadimage(ais);
        }),
        new ImageIdentifier("6.gif", (ais) => {
            orank[5] = loadimage(ais);
        }),
        new ImageIdentifier("7.gif", (ais) => {
            orank[6] = loadimage(ais);
        }),
        new ImageIdentifier("8.gif", (ais) => {
            orank[7] = loadimage(ais);
        }),
        new ImageIdentifier("bgmain.jpg", (ais) => {
            bgmain = loadBimage(ais, 2);
        }),
        new ImageIdentifier("br.png", (ais) => {
            br = loadimage(ais);
        }),
        new ImageIdentifier("loadingmusic.gif", (ais) => {
            oloadingmusic = loadimage(ais);
        }),
        new ImageIdentifier("radicalplay.gif", (ais) => {
            radicalplay = loadimage(ais);
        }),
        new ImageIdentifier("back.gif", (ais) => {
            back[0] = loadimage(ais);
            back[1] = bressed(back[0]);
        }),
        new ImageIdentifier("continue.gif", (ais) => {
            contin[0] = loadimage(ais);
            contin[1] = bressed(contin[0]);
        }),
        new ImageIdentifier("next.gif", (ais) => {
            next[0] = loadimage(ais);
            next[1] = bressed(next[0]);
        }),
        new ImageIdentifier("rpro.gif", (ais) => {
            rpro = loadimage(ais);
        }),
        new ImageIdentifier("selectcar.gif", (ais) => {
            selectcar = loadimage(ais);
        }),
        new ImageIdentifier("track.jpg", (ais) => {
            trackbg[0] = loadBimage(ais, 3);
            trackbg[1] = dodgen(trackbg[0]);
        }),
        new ImageIdentifier("youlost.gif", (ais) => {
            oyoulost = loadimage(ais);
        }),
        new ImageIdentifier("youwon.gif", (ais) => {
            oyouwon = loadimage(ais);
        }),
        new ImageIdentifier("0c.gif", (ais) => {
            ocntdn[0] = loadimage(ais);
        }),
        new ImageIdentifier("damage.gif", (ais) => {
            odmg = loadimage(ais);
        }),
        new ImageIdentifier("power.gif", (ais) => {
            opwr = loadimage(ais);
        }),
        new ImageIdentifier("position.gif", (ais) => {
            opos = loadimage(ais);
        }),
        new ImageIdentifier("speed.gif", (ais) => {
            osped = loadimage(ais);
        }),
        new ImageIdentifier("wasted.gif", (ais) => {
            owas = loadimage(ais);
        }),
        new ImageIdentifier("start1.gif", (ais) => {
            ostar[0] = loadimage(ais);
        }),
        new ImageIdentifier("start2.gif", (ais) => {
            ostar[1] = loadimage(ais);
            star[2] = pressed(ostar[1]);
        }),
        new ImageIdentifier("congrad.gif", (ais) => {
            congrd = loadimage(ais);
        }),
        new ImageIdentifier("statb.gif", (ais) => {
            statb = loadimage(ais);
        }),
        new ImageIdentifier("statbo.gif", (ais) => {
            statbo = loadimage(ais);
        }),
        new ImageIdentifier("madness.gif", (ais) => {
            mdness = loadude(ais);
        }),
//            new ImageIdentifier("onfmm.gif", (ais) => {
//                onfmm = loadude(ais);
//            }),
        new ImageIdentifier("fixhoop.png", (ais) => {
            fixhoop = loadimage(ais);
        }),
        new ImageIdentifier("arrow.gif", (ais) => {
            sarrow = loadimage(ais);
        }),
        new ImageIdentifier("stunts.png", (ais) => {
            stunts = loadimage(ais);
        }),
        new ImageIdentifier("racing.gif", (ais) => {
            racing = loadimage(ais);
        }),
        new ImageIdentifier("wasting.gif", (ais) => {
            wasting = loadimage(ais);
        }),
        new ImageIdentifier("plus.gif", (ais) => {
            plus = loadimage(ais);
        }),
        new ImageIdentifier("space.gif", (ais) => {
            space = loadimage(ais);
        }),
        new ImageIdentifier("arrows.gif", (ais) => {
            arrows = loadimage(ais);
        }),
        new ImageIdentifier("chil.gif", (ais) => {
            chil = loadimage(ais);
        }),
        new ImageIdentifier("ory.gif", (ais) => {
            ory = loadimage(ais);
        }),
        new ImageIdentifier("kz.gif", (ais) => {
            kz = loadimage(ais);
        }),
        new ImageIdentifier("kx.gif", (ais) => {
            kx = loadimage(ais);
        }),
        new ImageIdentifier("kv.gif", (ais) => {
            kv = loadimage(ais);
        }),
        new ImageIdentifier("km.gif", (ais) => {
            km = loadimage(ais);
        }),
        new ImageIdentifier("kn.gif", (ais) => {
            kn = loadimage(ais);
        }),
        new ImageIdentifier("ks.gif", (ais) => {
            ks = loadimage(ais);
        }),
        new ImageIdentifier("kenter.gif", (ais) => {
            kenter = loadimage(ais);
        }),
        new ImageIdentifier("nfm.gif", (ais) => {
            nfm = loadimage(ais);
        }),
        new ImageIdentifier("options.png", (ais) => {
            opti = loadimage(ais);
        }),
        new ImageIdentifier("opback.png", (ais) => {
            opback = loadimage(ais);
        }),
        new ImageIdentifier("logocars.png", (ais) => {
            logocars = loadimage(ais);
        }),
        new ImageIdentifier("logomad.png", (ais) => {
            logomadnes = loadimage(ais);
        }),
        new ImageIdentifier("logomadbg.jpg", (ais) => {
            logomadbg = loadimage(ais);
        }),
        new ImageIdentifier("byrd.png", (ais) => {
            byrd = loadimage(ais);
        }),
        new ImageIdentifier("bggo.jpg", (ais) => {
            bggo = loadimage(ais);
        }),
        new ImageIdentifier("nfmcoms.png", (ais) => {
            nfmcoms = loadimage(ais);
        }),
        new ImageIdentifier("nfmcom.gif", (ais) => {
            nfmcom = loadBimage(ais, 0);
        }),
        new ImageIdentifier("brit.gif", (ais) => {
            brt = loadimage(ais);
        }),
        new ImageIdentifier("arn.gif", (ais) => {
            arn = loadimage(ais);
        }),
        new ImageIdentifier("mload.gif", (ais) => {
            mload = loadimage(ais);
        }),
        new ImageIdentifier("login.gif", (ais) => {
            login = loadBimage(ais, 0);
        }),
        new ImageIdentifier("play.gif", (ais) => {
            play = loadBimage(ais, 0);
        }),
        new ImageIdentifier("cancel.gif", (ais) => {
            cancel = loadBimage(ais, 0);
        }),
        new ImageIdentifier("register.gif", (ais) => {
            register = loadBimage(ais, 0);
        }),
        new ImageIdentifier("upgrade.gif", (ais) => {
            upgrade = loadimage(ais);
        }),
        new ImageIdentifier("sdets.gif", (ais) => {
            sdets = loadBimage(ais, 0);
        }),
        new ImageIdentifier("bob.gif", (ais) => {
            bob = loadBimage(ais, 1);
        }),
        new ImageIdentifier("bot.gif", (ais) => {
            bot = loadBimage(ais, 1);
        }),
        new ImageIdentifier("bol.gif", (ais) => {
            bol = loadBimage(ais, 0);
        }),
        new ImageIdentifier("bolp.gif", (ais) => {
            bolp = loadBimage(ais, 0);
        }),
        new ImageIdentifier("bor.gif", (ais) => {
            bor = loadBimage(ais, 0);
        }),
        new ImageIdentifier("borp.gif", (ais) => {
            borp = loadBimage(ais, 0);
        }),
        new ImageIdentifier("logout.gif", (ais) => {
            logout = loadBimage(ais, 0);
        }),
        new ImageIdentifier("change.gif", (ais) => {
            change = loadBimage(ais, 0);
        }),
        new ImageIdentifier("pln.gif", (ais) => {
            pln = loadBimage(ais, 0);
        }),
        new ImageIdentifier("bols.gif", (ais) => {
            bols = loadBimage(ais, 0);
        }),
        new ImageIdentifier("bolps.gif", (ais) => {
            bolps = loadBimage(ais, 0);
        }),
        new ImageIdentifier("bors.gif", (ais) => {
            bors = loadBimage(ais, 0);
        }),
        new ImageIdentifier("borps.gif", (ais) => {
            borps = loadBimage(ais, 0);
        }),
        new ImageIdentifier("games.gif", (ais) => {
            games = loadBimage(ais, 0);
        }),
        new ImageIdentifier("exit.gif", (ais) => {
            exit = loadBimage(ais, 0);
        }),
        new ImageIdentifier("roomp.gif", (ais) => {
            roomp = loadBimage(ais, 0);
        }),
        new ImageIdentifier("ready.gif", (ais) => {
            redy = loadBimage(ais, 0);
        }),
        new ImageIdentifier("notreg.gif", (ais) => {
            ntrg = loadBimage(ais, 0);
        }),
        new ImageIdentifier("cgame.gif", (ais) => {
            cgame = loadBimage(ais, 0);
        }),
        new ImageIdentifier("ccar.gif", (ais) => {
            ccar = loadBimage(ais, 0);
        }),
        new ImageIdentifier("lanm.gif", (ais) => {
            lanm = loadBimage(ais, 0);
        }),
        new ImageIdentifier("asu.gif", (ais) => {
            asu = loadimage(ais);
        }),
        new ImageIdentifier("asd.gif", (ais) => {
            asd = loadimage(ais);
        }),
        new ImageIdentifier("pls.gif", (ais) => {
            pls = loadBimage(ais, 0);
        }),
        new ImageIdentifier("sts.gif", (ais) => {
            sts = loadBimage(ais, 0);
        }),
        new ImageIdentifier("gmc.gif", (ais) => {
            gmc = loadBimage(ais, 0);
        }),
        new ImageIdentifier("stg.gif", (ais) => {
            stg = loadBimage(ais, 0);
        }),
        new ImageIdentifier("crd.gif", (ais) => {
            crd = loadBimage(ais, 0);
        }),
        new ImageIdentifier("bcl.gif", (ais) => {
            bcl[0] = loadimage(ais);
        }),
        new ImageIdentifier("bcr.gif", (ais) => {
            bcr[0] = loadimage(ais);
        }),
        new ImageIdentifier("bc.gif", (ais) => {
            bc[0] = loadimage(ais);
        }),
        new ImageIdentifier("pbcl.gif", (ais) => {
            bcl[1] = loadimage(ais);
        }),
        new ImageIdentifier("pbcr.gif", (ais) => {
            bcr[1] = loadimage(ais);
        }),
        new ImageIdentifier("pbc.gif", (ais) => {
            bc[1] = loadimage(ais);
        }),
        new ImageIdentifier("yac.gif", (ais) => {
            yac = loadimage(ais);
        }),
        new ImageIdentifier("ycmc.gif", (ais) => {
            ycmc = loadimage(ais);
        }),
    };
    
    }
}