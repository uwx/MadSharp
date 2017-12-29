using static Cum.XTImages.Images;
using static Cum.XTGraphics;
using static Cum.XTPart2;

namespace Cum
{
    public class XTImages
    {
        internal static class Images
        {
            internal static Image Arn;
            internal static Image Arrows;
            internal static Image Asd;
            internal static Image Asu;
            internal static readonly Image[] Back = new Image[2];
            internal static readonly Image[] Bc = new Image[2];
            internal static readonly Image[] Bcl = new Image[2];
            internal static readonly Image[] Bcr = new Image[2];
            internal static Image Bggo;
            internal static Image Bgmain;
            internal static Image Bob;
            internal static Image Bol;
            internal static Image Bolp;
            internal static Image Bolps;
            internal static Image Bols;
            internal static Image Bor;
            internal static Image Borp;
            internal static Image Borps;
            internal static Image Bors;
            internal static Image Bot;
            internal static Image Br;
            internal static Image Brt;
            internal static Image Byrd;
            internal static Image Cancel;
            internal static Image Carsbg;
            internal static Image Carsbgc;
            internal static Image Ccar;
            internal static Image Cgame;
            internal static Image Change;
            internal static Image Chil;
            internal static readonly Image[] Cntdn = new Image[4];
            internal static Image Congrd;
            internal static readonly Image[] Contin = new Image[2];
            internal static Image Crd;
            internal static Image Disco;
            internal static Image Dmg;
            internal static readonly Image[] Dude = new Image[3];
            internal static Image Exit;
            internal static Image Exitgame;
            internal static Image Fixhoop;
            internal static Image Flaot;
            internal static Image Fleximg;
            internal static Image Gamefinished;
            internal static Image Gameh;
            internal static Image Gameov;
            internal static Image Games;
            internal static Image Gmc;
            internal static Image Hello;
            internal static Image Kenter;
            internal static Image Km;
            internal static Image Kn;
            internal static Image Ks;
            internal static Image Kv;
            internal static Image Kx;
            internal static Image Kz;
            internal static Image Lanm;
            internal static Image Lap;
            internal static Image Loadbar;
            internal static Image Loadingmusic;
            internal static Image Login;
            internal static Image Logocars;
            internal static Image Logomadbg;
            internal static Image Logomadnes;
            internal static Image Logout;
            internal static Image Mdness;
            internal static Image Mload;
            internal static readonly Image[] Next = new Image[2];
            internal static Image Nfm;
            internal static Image Nfmcom;
            internal static Image Nfmcoms;
            internal static Image Ntrg;
            internal static readonly Image[] Ocntdn = new Image[4];
            internal static Image Odisco;
            internal static Image Odmg;
            internal static Image Oexitgame;
            internal static Image Oflaot;
            internal static Image Ogamefinished;
            internal static Image Ogameh;
            internal static Image Olap;
            internal static Image Oloadingmusic;
            internal static Image Onfmm;
            internal static Image Opback;
            internal static Image Opos;
            internal static Image Opti;
            internal static Image Opwr;
            internal static readonly Image[] Orank = new Image[8];
            internal static Image Ory;
            internal static Image Osped;
            internal static readonly Image[] Ostar = new Image[2];
            internal static Image Owas;
            internal static Image Owgame;
            internal static Image Oyoulost;
            internal static Image Oyourwasted;
            internal static Image Oyouwastedem;
            internal static Image Oyouwon;
            internal static Image Paused;
            internal static Image Pgate;
            internal static Image Play;
            internal static Image Pln;
            internal static Image Pls;
            internal static Image Plus;
            internal static Image Pos;
            internal static Image Pwr;
            internal static Image Racing;
            internal static Image Radicalplay;
            internal static readonly Image[] Rank = new Image[8];
            internal static Image Redy;
            internal static Image Register;
            internal static Image Roomp;
            internal static Image Rpro;
            internal static Image Sarrow;
            internal static Image Sdets;
            internal static Image Select;
            internal static Image Selectcar;
            internal static Image Sign;
            internal static Image Space;
            internal static Image Sped;
            internal static readonly Image[] Star = new Image[3];
            internal static Image Statb;
            internal static Image Statbo;
            internal static Image Stg;
            internal static Image Sts;
            internal static Image Stunts;
            internal static readonly Image[] Trackbg = new Image[2];
            internal static Image Upgrade;
            internal static Image Was;
            internal static Image Wasting;
            internal static Image Wgame;
            internal static Image Yac;
            internal static Image Ycmc;
            internal static Image Youlost;
            internal static Image Yourwasted;
            internal static Image Youwastedem;
            internal static Image Youwon;
        }

        internal delegate void Accept(byte[] ais);

        internal class ImageIdentifier
        {
            internal readonly string FileName;
            internal readonly Accept Cons;

            internal ImageIdentifier(string s, Accept c)
            {
                Cons = c;
                FileName = s;
            }
        }

        private static Image _cbg1, _cbg2;

        internal static readonly ImageIdentifier[] Idts =
        {
            new ImageIdentifier("cars.gif", ais => { Carsbg = LoadBimage(ais, 1); }),
            new ImageIdentifier("color.gif", ais =>
            {
                _cbg1 = LoadBimage(ais, 0);

                if (_cbg1 != null && _cbg2 != null)
{                    Makecarsbgc(_cbg1, _cbg2);
}            }),
            new ImageIdentifier("class.gif", ais =>
            {
                _cbg2 = LoadBimage(ais, 0);

                if (_cbg1 != null && _cbg2 != null)
{                    Makecarsbgc(_cbg1, _cbg2);
}            }),
            new ImageIdentifier("smokey.gif", ais => { Smokeypix(ais); }),
            new ImageIdentifier("1.gif", ais => { Orank[0] = Loadimage(ais); }),
            new ImageIdentifier("gameh.gif", ais => { Ogameh = Loadimage(ais); }),
            new ImageIdentifier("wgame.gif", ais => { Owgame = Loadimage(ais); }),
            new ImageIdentifier("gameov.gif", ais => { Gameov = Loadimage(ais); }),
            new ImageIdentifier("lap.gif", ais => { Olap = Loadimage(ais); }),
            new ImageIdentifier("paused.gif", ais => { Paused = Loadimage(ais); }),
            new ImageIdentifier("select.gif", ais => { Select = Loadimage(ais); }),
            new ImageIdentifier("yourwasted.gif", ais => { Oyourwasted = Loadimage(ais); }),
            new ImageIdentifier("disco.gif", ais => { Odisco = Loadimage(ais); }),
            new ImageIdentifier("youwastedem.gif", ais => { Oyouwastedem = Loadimage(ais); }),
            new ImageIdentifier("gamefinished.gif", ais => { Ogamefinished = Loadimage(ais); }),
            new ImageIdentifier("exitgame.gif", ais => { Oexitgame = Loadimage(ais); }),
            new ImageIdentifier("pgate.gif", ais => { Pgate = Loadimage(ais); }),
            new ImageIdentifier("d1.png", ais => { Dude[0] = Loadimage(ais); }),
            new ImageIdentifier("d2.png", ais => { Dude[1] = Loadimage(ais); }),
            new ImageIdentifier("d3.png", ais => { Dude[2] = Loadimage(ais); }),
            new ImageIdentifier("float.gif", ais => { Oflaot = Loadimage(ais); }),
            new ImageIdentifier("1c.gif", ais => { Ocntdn[1] = Loadimage(ais); }),
            new ImageIdentifier("2c.gif", ais => { Ocntdn[2] = Loadimage(ais); }),
            new ImageIdentifier("3c.gif", ais => { Ocntdn[3] = Loadimage(ais); }),
            new ImageIdentifier("2.gif", ais => { Orank[1] = Loadimage(ais); }),
            new ImageIdentifier("3.gif", ais => { Orank[2] = Loadimage(ais); }),
            new ImageIdentifier("4.gif", ais => { Orank[3] = Loadimage(ais); }),
            new ImageIdentifier("5.gif", ais => { Orank[4] = Loadimage(ais); }),
            new ImageIdentifier("6.gif", ais => { Orank[5] = Loadimage(ais); }),
            new ImageIdentifier("7.gif", ais => { Orank[6] = Loadimage(ais); }),
            new ImageIdentifier("8.gif", ais => { Orank[7] = Loadimage(ais); }),
            new ImageIdentifier("bgmain.jpg", ais => { Bgmain = LoadBimage(ais, 2); }),
            new ImageIdentifier("br.png", ais => { Br = Loadimage(ais); }),
            new ImageIdentifier("loadingmusic.gif", ais => { Oloadingmusic = Loadimage(ais); }),
            new ImageIdentifier("radicalplay.gif", ais => { Radicalplay = Loadimage(ais); }),
            new ImageIdentifier("back.gif", ais =>
            {
                Back[0] = Loadimage(ais);
                Back[1] = Bressed(Back[0]);
            }),
            new ImageIdentifier("continue.gif", ais =>
            {
                Contin[0] = Loadimage(ais);
                Contin[1] = Bressed(Contin[0]);
            }),
            new ImageIdentifier("next.gif", ais =>
            {
                Next[0] = Loadimage(ais);
                Next[1] = Bressed(Next[0]);
            }),
            new ImageIdentifier("rpro.gif", ais => { Rpro = Loadimage(ais); }),
            new ImageIdentifier("selectcar.gif", ais => { Selectcar = Loadimage(ais); }),
            new ImageIdentifier("track.jpg", ais =>
            {
                Trackbg[0] = LoadBimage(ais, 3);
                Trackbg[1] = Dodgen(Trackbg[0]);
            }),
            new ImageIdentifier("youlost.gif", ais => { Oyoulost = Loadimage(ais); }),
            new ImageIdentifier("youwon.gif", ais => { Oyouwon = Loadimage(ais); }),
            new ImageIdentifier("0c.gif", ais => { Ocntdn[0] = Loadimage(ais); }),
            new ImageIdentifier("damage.gif", ais => { Odmg = Loadimage(ais); }),
            new ImageIdentifier("power.gif", ais => { Opwr = Loadimage(ais); }),
            new ImageIdentifier("position.gif", ais => { Opos = Loadimage(ais); }),
            new ImageIdentifier("speed.gif", ais => { Osped = Loadimage(ais); }),
            new ImageIdentifier("wasted.gif", ais => { Owas = Loadimage(ais); }),
            new ImageIdentifier("start1.gif", ais => { Ostar[0] = Loadimage(ais); }),
            new ImageIdentifier("start2.gif", ais =>
            {
                Ostar[1] = Loadimage(ais);
                Star[2] = Pressed(Ostar[1]);
            }),
            new ImageIdentifier("congrad.gif", ais => { Congrd = Loadimage(ais); }),
            new ImageIdentifier("statb.gif", ais => { Statb = Loadimage(ais); }),
            new ImageIdentifier("statbo.gif", ais => { Statbo = Loadimage(ais); }),
            new ImageIdentifier("madness.gif", ais => { Mdness = Loadude(ais); }),
//            new ImageIdentifier("onfmm.gif", (ais) => {
//                onfmm = loadude(ais);
//            }),
            new ImageIdentifier("fixhoop.png", ais => { Fixhoop = Loadimage(ais); }),
            new ImageIdentifier("arrow.gif", ais => { Sarrow = Loadimage(ais); }),
            new ImageIdentifier("stunts.png", ais => { Stunts = Loadimage(ais); }),
            new ImageIdentifier("racing.gif", ais => { Racing = Loadimage(ais); }),
            new ImageIdentifier("wasting.gif", ais => { Wasting = Loadimage(ais); }),
            new ImageIdentifier("plus.gif", ais => { Plus = Loadimage(ais); }),
            new ImageIdentifier("space.gif", ais => { Space = Loadimage(ais); }),
            new ImageIdentifier("arrows.gif", ais => { Arrows = Loadimage(ais); }),
            new ImageIdentifier("chil.gif", ais => { Chil = Loadimage(ais); }),
            new ImageIdentifier("ory.gif", ais => { Ory = Loadimage(ais); }),
            new ImageIdentifier("kz.gif", ais => { Kz = Loadimage(ais); }),
            new ImageIdentifier("kx.gif", ais => { Kx = Loadimage(ais); }),
            new ImageIdentifier("kv.gif", ais => { Kv = Loadimage(ais); }),
            new ImageIdentifier("km.gif", ais => { Km = Loadimage(ais); }),
            new ImageIdentifier("kn.gif", ais => { Kn = Loadimage(ais); }),
            new ImageIdentifier("ks.gif", ais => { Ks = Loadimage(ais); }),
            new ImageIdentifier("kenter.gif", ais => { Kenter = Loadimage(ais); }),
            new ImageIdentifier("nfm.gif", ais => { Nfm = Loadimage(ais); }),
            new ImageIdentifier("options.png", ais => { Opti = Loadimage(ais); }),
            new ImageIdentifier("opback.png", ais => { Opback = Loadimage(ais); }),
            new ImageIdentifier("logocars.png", ais => { Logocars = Loadimage(ais); }),
            new ImageIdentifier("logomad.png", ais => { Logomadnes = Loadimage(ais); }),
            new ImageIdentifier("logomadbg.jpg", ais => { Logomadbg = Loadimage(ais); }),
            new ImageIdentifier("byrd.png", ais => { Byrd = Loadimage(ais); }),
            new ImageIdentifier("bggo.jpg", ais => { Bggo = Loadimage(ais); }),
            new ImageIdentifier("nfmcoms.png", ais => { Nfmcoms = Loadimage(ais); }),
            new ImageIdentifier("nfmcom.gif", ais => { Nfmcom = LoadBimage(ais, 0); }),
            new ImageIdentifier("brit.gif", ais => { Brt = Loadimage(ais); }),
            new ImageIdentifier("arn.gif", ais => { Arn = Loadimage(ais); }),
            new ImageIdentifier("mload.gif", ais => { Mload = Loadimage(ais); }),
            new ImageIdentifier("login.gif", ais => { Login = LoadBimage(ais, 0); }),
            new ImageIdentifier("play.gif", ais => { Play = LoadBimage(ais, 0); }),
            new ImageIdentifier("cancel.gif", ais => { Cancel = LoadBimage(ais, 0); }),
            new ImageIdentifier("register.gif", ais => { Register = LoadBimage(ais, 0); }),
            new ImageIdentifier("upgrade.gif", ais => { Upgrade = Loadimage(ais); }),
            new ImageIdentifier("sdets.gif", ais => { Sdets = LoadBimage(ais, 0); }),
            new ImageIdentifier("bob.gif", ais => { Bob = LoadBimage(ais, 1); }),
            new ImageIdentifier("bot.gif", ais => { Bot = LoadBimage(ais, 1); }),
            new ImageIdentifier("bol.gif", ais => { Bol = LoadBimage(ais, 0); }),
            new ImageIdentifier("bolp.gif", ais => { Bolp = LoadBimage(ais, 0); }),
            new ImageIdentifier("bor.gif", ais => { Bor = LoadBimage(ais, 0); }),
            new ImageIdentifier("borp.gif", ais => { Borp = LoadBimage(ais, 0); }),
            new ImageIdentifier("logout.gif", ais => { Logout = LoadBimage(ais, 0); }),
            new ImageIdentifier("change.gif", ais => { Change = LoadBimage(ais, 0); }),
            new ImageIdentifier("pln.gif", ais => { Pln = LoadBimage(ais, 0); }),
            new ImageIdentifier("bols.gif", ais => { Bols = LoadBimage(ais, 0); }),
            new ImageIdentifier("bolps.gif", ais => { Bolps = LoadBimage(ais, 0); }),
            new ImageIdentifier("bors.gif", ais => { Bors = LoadBimage(ais, 0); }),
            new ImageIdentifier("borps.gif", ais => { Borps = LoadBimage(ais, 0); }),
            new ImageIdentifier("games.gif", ais => { Games = LoadBimage(ais, 0); }),
            new ImageIdentifier("exit.gif", ais => { Exit = LoadBimage(ais, 0); }),
            new ImageIdentifier("roomp.gif", ais => { Roomp = LoadBimage(ais, 0); }),
            new ImageIdentifier("ready.gif", ais => { Redy = LoadBimage(ais, 0); }),
            new ImageIdentifier("notreg.gif", ais => { Ntrg = LoadBimage(ais, 0); }),
            new ImageIdentifier("cgame.gif", ais => { Cgame = LoadBimage(ais, 0); }),
            new ImageIdentifier("ccar.gif", ais => { Ccar = LoadBimage(ais, 0); }),
            new ImageIdentifier("lanm.gif", ais => { Lanm = LoadBimage(ais, 0); }),
            new ImageIdentifier("asu.gif", ais => { Asu = Loadimage(ais); }),
            new ImageIdentifier("asd.gif", ais => { Asd = Loadimage(ais); }),
            new ImageIdentifier("pls.gif", ais => { Pls = LoadBimage(ais, 0); }),
            new ImageIdentifier("sts.gif", ais => { Sts = LoadBimage(ais, 0); }),
            new ImageIdentifier("gmc.gif", ais => { Gmc = LoadBimage(ais, 0); }),
            new ImageIdentifier("stg.gif", ais => { Stg = LoadBimage(ais, 0); }),
            new ImageIdentifier("crd.gif", ais => { Crd = LoadBimage(ais, 0); }),
            new ImageIdentifier("bcl.gif", ais => { Bcl[0] = Loadimage(ais); }),
            new ImageIdentifier("bcr.gif", ais => { Bcr[0] = Loadimage(ais); }),
            new ImageIdentifier("bc.gif", ais => { Bc[0] = Loadimage(ais); }),
            new ImageIdentifier("pbcl.gif", ais => { Bcl[1] = Loadimage(ais); }),
            new ImageIdentifier("pbcr.gif", ais => { Bcr[1] = Loadimage(ais); }),
            new ImageIdentifier("pbc.gif", ais => { Bc[1] = Loadimage(ais); }),
            new ImageIdentifier("yac.gif", ais => { Yac = Loadimage(ais); }),
            new ImageIdentifier("ycmc.gif", ais => { Ycmc = Loadimage(ais); })
        };
    }
}