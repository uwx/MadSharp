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

        internal struct ImageIdentifier
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
            new ImageIdentifier("cars.png", ais => { Carsbg = LoadBimage(ais, 1); }),
            new ImageIdentifier("color.png", ais =>
            {
                _cbg1 = LoadBimage(ais, 0);

                if (_cbg1 != null && _cbg2 != null)
{                    Makecarsbgc(_cbg1, _cbg2);
}            }),
            new ImageIdentifier("class.png", ais =>
            {
                _cbg2 = LoadBimage(ais, 0);

                if (_cbg1 != null && _cbg2 != null)
{                    Makecarsbgc(_cbg1, _cbg2);
}            }),
            new ImageIdentifier("smokey.png", ais => { Smokeypix(ais); }),
            new ImageIdentifier("1.png", ais => { Orank[0] = Loadimage(ais); }),
            new ImageIdentifier("gameh.png", ais => { Ogameh = Loadimage(ais); }),
            new ImageIdentifier("wgame.png", ais => { Owgame = Loadimage(ais); }),
            new ImageIdentifier("gameov.png", ais => { Gameov = Loadimage(ais); }),
            new ImageIdentifier("lap.png", ais => { Olap = Loadimage(ais); }),
            new ImageIdentifier("paused.png", ais => { Paused = Loadimage(ais); }),
            new ImageIdentifier("select.png", ais => { Select = Loadimage(ais); }),
            new ImageIdentifier("yourwasted.png", ais => { Oyourwasted = Loadimage(ais); }),
            new ImageIdentifier("disco.png", ais => { Odisco = Loadimage(ais); }),
            new ImageIdentifier("youwastedem.png", ais => { Oyouwastedem = Loadimage(ais); }),
            new ImageIdentifier("gamefinished.png", ais => { Ogamefinished = Loadimage(ais); }),
            new ImageIdentifier("exitgame.png", ais => { Oexitgame = Loadimage(ais); }),
            new ImageIdentifier("pgate.png", ais => { Pgate = Loadimage(ais); }),
            new ImageIdentifier("d1.png", ais => { Dude[0] = Loadimage(ais); }),
            new ImageIdentifier("d2.png", ais => { Dude[1] = Loadimage(ais); }),
            new ImageIdentifier("d3.png", ais => { Dude[2] = Loadimage(ais); }),
            new ImageIdentifier("float.png", ais => { Oflaot = Loadimage(ais); }),
            new ImageIdentifier("1c.png", ais => { Ocntdn[1] = Loadimage(ais); }),
            new ImageIdentifier("2c.png", ais => { Ocntdn[2] = Loadimage(ais); }),
            new ImageIdentifier("3c.png", ais => { Ocntdn[3] = Loadimage(ais); }),
            new ImageIdentifier("2.png", ais => { Orank[1] = Loadimage(ais); }),
            new ImageIdentifier("3.png", ais => { Orank[2] = Loadimage(ais); }),
            new ImageIdentifier("4.png", ais => { Orank[3] = Loadimage(ais); }),
            new ImageIdentifier("5.png", ais => { Orank[4] = Loadimage(ais); }),
            new ImageIdentifier("6.png", ais => { Orank[5] = Loadimage(ais); }),
            new ImageIdentifier("7.png", ais => { Orank[6] = Loadimage(ais); }),
            new ImageIdentifier("8.png", ais => { Orank[7] = Loadimage(ais); }),
            new ImageIdentifier("bgmain.jpg", ais => { Bgmain = LoadBimage(ais, 2); }),
            new ImageIdentifier("br.png", ais => { Br = Loadimage(ais); }),
            new ImageIdentifier("loadingmusic.png", ais => { Oloadingmusic = Loadimage(ais); }),
            new ImageIdentifier("radicalplay.png", ais => { Radicalplay = Loadimage(ais); }),
            new ImageIdentifier("back.png", ais =>
            {
                Back[0] = Loadimage(ais);
                Back[1] = Bressed(Back[0]);
            }),
            new ImageIdentifier("continue.png", ais =>
            {
                Contin[0] = Loadimage(ais);
                Contin[1] = Bressed(Contin[0]);
            }),
            new ImageIdentifier("next.png", ais =>
            {
                Next[0] = Loadimage(ais);
                Next[1] = Bressed(Next[0]);
            }),
            new ImageIdentifier("rpro.png", ais => { Rpro = Loadimage(ais); }),
            new ImageIdentifier("selectcar.png", ais => { Selectcar = Loadimage(ais); }),
            new ImageIdentifier("track.jpg", ais =>
            {
                Trackbg[0] = LoadBimage(ais, 3);
                Trackbg[1] = Dodgen(Trackbg[0]);
            }),
            new ImageIdentifier("youlost.png", ais => { Oyoulost = Loadimage(ais); }),
            new ImageIdentifier("youwon.png", ais => { Oyouwon = Loadimage(ais); }),
            new ImageIdentifier("0c.png", ais => { Ocntdn[0] = Loadimage(ais); }),
            new ImageIdentifier("damage.png", ais => { Odmg = Loadimage(ais); }),
            new ImageIdentifier("power.png", ais => { Opwr = Loadimage(ais); }),
            new ImageIdentifier("position.png", ais => { Opos = Loadimage(ais); }),
            new ImageIdentifier("speed.png", ais => { Osped = Loadimage(ais); }),
            new ImageIdentifier("wasted.png", ais => { Owas = Loadimage(ais); }),
            new ImageIdentifier("start1.png", ais => { Ostar[0] = Loadimage(ais); }),
            new ImageIdentifier("start2.png", ais =>
            {
                Ostar[1] = Loadimage(ais);
                Star[2] = Pressed(Ostar[1]);
            }),
            new ImageIdentifier("congrad.png", ais => { Congrd = Loadimage(ais); }),
            new ImageIdentifier("statb.png", ais => { Statb = Loadimage(ais); }),
            new ImageIdentifier("statbo.png", ais => { Statbo = Loadimage(ais); }),
            new ImageIdentifier("madness.png", ais => { Mdness = Loadude(ais); }),
//            new ImageIdentifier("onfmm.png", (ais) => {
//                onfmm = loadude(ais);
//            }),
            new ImageIdentifier("fixhoop.png", ais => { Fixhoop = Loadimage(ais); }),
            new ImageIdentifier("arrow.png", ais => { Sarrow = Loadimage(ais); }),
            new ImageIdentifier("stunts.png", ais => { Stunts = Loadimage(ais); }),
            new ImageIdentifier("racing.png", ais => { Racing = Loadimage(ais); }),
            new ImageIdentifier("wasting.png", ais => { Wasting = Loadimage(ais); }),
            new ImageIdentifier("plus.png", ais => { Plus = Loadimage(ais); }),
            new ImageIdentifier("space.png", ais => { Space = Loadimage(ais); }),
            new ImageIdentifier("arrows.png", ais => { Arrows = Loadimage(ais); }),
            new ImageIdentifier("chil.png", ais => { Chil = Loadimage(ais); }),
            new ImageIdentifier("ory.png", ais => { Ory = Loadimage(ais); }),
            new ImageIdentifier("kz.png", ais => { Kz = Loadimage(ais); }),
            new ImageIdentifier("kx.png", ais => { Kx = Loadimage(ais); }),
            new ImageIdentifier("kv.png", ais => { Kv = Loadimage(ais); }),
            new ImageIdentifier("km.png", ais => { Km = Loadimage(ais); }),
            new ImageIdentifier("kn.png", ais => { Kn = Loadimage(ais); }),
            new ImageIdentifier("ks.png", ais => { Ks = Loadimage(ais); }),
            new ImageIdentifier("kenter.png", ais => { Kenter = Loadimage(ais); }),
            new ImageIdentifier("nfm.png", ais => { Nfm = Loadimage(ais); }),
            new ImageIdentifier("options.png", ais => { Opti = Loadimage(ais); }),
            new ImageIdentifier("opback.png", ais => { Opback = Loadimage(ais); }),
            new ImageIdentifier("logocars.png", ais => { Logocars = Loadimage(ais); }),
            new ImageIdentifier("logomad.png", ais => { Logomadnes = Loadimage(ais); }),
            new ImageIdentifier("logomadbg.jpg", ais => { Logomadbg = Loadimage(ais); }),
            new ImageIdentifier("byrd.png", ais => { Byrd = Loadimage(ais); }),
            new ImageIdentifier("bggo.jpg", ais => { Bggo = Loadimage(ais); }),
            new ImageIdentifier("nfmcoms.png", ais => { Nfmcoms = Loadimage(ais); }),
            new ImageIdentifier("nfmcom.png", ais => { Nfmcom = LoadBimage(ais, 0); }),
            new ImageIdentifier("brit.png", ais => { Brt = Loadimage(ais); }),
            new ImageIdentifier("arn.png", ais => { Arn = Loadimage(ais); }),
            new ImageIdentifier("mload.png", ais => { Mload = Loadimage(ais); }),
            new ImageIdentifier("login.png", ais => { Login = LoadBimage(ais, 0); }),
            new ImageIdentifier("play.png", ais => { Play = LoadBimage(ais, 0); }),
            new ImageIdentifier("cancel.png", ais => { Cancel = LoadBimage(ais, 0); }),
            new ImageIdentifier("register.png", ais => { Register = LoadBimage(ais, 0); }),
            new ImageIdentifier("upgrade.png", ais => { Upgrade = Loadimage(ais); }),
            new ImageIdentifier("sdets.png", ais => { Sdets = LoadBimage(ais, 0); }),
            new ImageIdentifier("bob.png", ais => { Bob = LoadBimage(ais, 1); }),
            new ImageIdentifier("bot.png", ais => { Bot = LoadBimage(ais, 1); }),
            new ImageIdentifier("bol.png", ais => { Bol = LoadBimage(ais, 0); }),
            new ImageIdentifier("bolp.png", ais => { Bolp = LoadBimage(ais, 0); }),
            new ImageIdentifier("bor.png", ais => { Bor = LoadBimage(ais, 0); }),
            new ImageIdentifier("borp.png", ais => { Borp = LoadBimage(ais, 0); }),
            new ImageIdentifier("logout.png", ais => { Logout = LoadBimage(ais, 0); }),
            new ImageIdentifier("change.png", ais => { Change = LoadBimage(ais, 0); }),
            new ImageIdentifier("pln.png", ais => { Pln = LoadBimage(ais, 0); }),
            new ImageIdentifier("bols.png", ais => { Bols = LoadBimage(ais, 0); }),
            new ImageIdentifier("bolps.png", ais => { Bolps = LoadBimage(ais, 0); }),
            new ImageIdentifier("bors.png", ais => { Bors = LoadBimage(ais, 0); }),
            new ImageIdentifier("borps.png", ais => { Borps = LoadBimage(ais, 0); }),
            new ImageIdentifier("games.png", ais => { Games = LoadBimage(ais, 0); }),
            new ImageIdentifier("exit.png", ais => { Exit = LoadBimage(ais, 0); }),
            new ImageIdentifier("roomp.png", ais => { Roomp = LoadBimage(ais, 0); }),
            new ImageIdentifier("ready.png", ais => { Redy = LoadBimage(ais, 0); }),
            new ImageIdentifier("notreg.png", ais => { Ntrg = LoadBimage(ais, 0); }),
            new ImageIdentifier("cgame.png", ais => { Cgame = LoadBimage(ais, 0); }),
            new ImageIdentifier("ccar.png", ais => { Ccar = LoadBimage(ais, 0); }),
            new ImageIdentifier("lanm.png", ais => { Lanm = LoadBimage(ais, 0); }),
            new ImageIdentifier("asu.png", ais => { Asu = Loadimage(ais); }),
            new ImageIdentifier("asd.png", ais => { Asd = Loadimage(ais); }),
            new ImageIdentifier("pls.png", ais => { Pls = LoadBimage(ais, 0); }),
            new ImageIdentifier("sts.png", ais => { Sts = LoadBimage(ais, 0); }),
            new ImageIdentifier("gmc.png", ais => { Gmc = LoadBimage(ais, 0); }),
            new ImageIdentifier("stg.png", ais => { Stg = LoadBimage(ais, 0); }),
            new ImageIdentifier("crd.png", ais => { Crd = LoadBimage(ais, 0); }),
            new ImageIdentifier("bcl.png", ais => { Bcl[0] = Loadimage(ais); }),
            new ImageIdentifier("bcr.png", ais => { Bcr[0] = Loadimage(ais); }),
            new ImageIdentifier("bc.png", ais => { Bc[0] = Loadimage(ais); }),
            new ImageIdentifier("pbcl.png", ais => { Bcl[1] = Loadimage(ais); }),
            new ImageIdentifier("pbcr.png", ais => { Bcr[1] = Loadimage(ais); }),
            new ImageIdentifier("pbc.png", ais => { Bc[1] = Loadimage(ais); }),
            new ImageIdentifier("yac.png", ais => { Yac = Loadimage(ais); }),
            new ImageIdentifier("ycmc.png", ais => { Ycmc = Loadimage(ais); })
        };
    }
}