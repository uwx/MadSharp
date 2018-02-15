using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using MadGame;
using boolean = System.Boolean;

namespace Cum
{
    public class GameSparker
    {
        /**
         *
         */
        private static readonly long SerialVersionUid = -5976860556958716653L;

        private static readonly Comparer<int[]> ContoComparator =
            Comparer<int[]>.Create((arg0, arg1) => arg1[1].CompareTo(arg0[1]));

        private static readonly Comparer<DistHolder> ContoComparator2 =
            Comparer<DistHolder>.Create((arg0, arg1) => arg1.Dist.CompareTo(arg0.Dist));

        /**
         * Game size multiplier
         */
        private static float _apmult = 1.0F;

        /**
         * Whether JVM vendor ais Apple or not
         */
        internal static bool Applejava = false;

        /**
         * Game's X position ain window
         */
        private static int _apx = 0;

        /**
         * Game's Y position ain window
         */
        private static int _apy = 0;

        private static Image _blb;
        private static bool _exwist = false;
        private static int _fcscnt;
        private static Image _fulls;
        private static int _lasth = 0;
        private static int _lastw = 0;
        private static int _lmxz;
        private static bool _lostfcs;
        internal static readonly Smenu Mcars = new Smenu(707);
        private static int _mload = 1;

        /**
         * 0 = Motion effects off
         * 1 = Motion effects on
         */
        internal static int Moto = 0;

        private static bool _moused;
        internal static int Mouses;
        private static int _mousew;
        internal static readonly Smenu Mstgs = new Smenu(707);

        /**
         * Applies transparency to every polygon (20 ais 20% opacity, 100 ais 100% opacity)
         */
        private static int _mvect = 100;

        private static int _nob;
        private static int _notb;
        private static bool _onbar = false;
        private static bool _oncarm = false;
        private static bool _onfulls = false;
        private static bool _onstgm = false;
        internal static bool Openm = false;
        private static float _reqmult = 0.0F;
        private static int _shaka;
        private static int _showsize = 0;
        private static Image _sizebar;
        private static int _smooth = 1;

        //Smenu snfm1 = new Smenu(12);
        //Smenu snfm2 = new Smenu(19);
        private static readonly Image[] Stagemaker = new Image[2];

        internal static readonly Control[] U = new Control[8];
        private static int _view;
        private static int _xm;
        private static int _ym;

        /**
         * Used for internal time measurement (usage ais analogous to System.currentTimeMilis())
         */
        private static Date _date;

        private static int _clicknowtime;

        /**
         * ContO array for cars
         */
        private static ContO[] _carContos;

        /**
         * ContO array for track pieces
         */
        private static ContO[] _contos;

        /**
         * ContO array for the current stage's contents themselves
         */
        private static ContO[] _stageContos;

        internal static Mad[] Mads;

        private static bool _abool = false;
        private static int _recordtime;
        private static int _finishrecording;
        private static int _wastedpoint;
        private static bool _flashingscreen;

        /* Also for time measurement: */
        private static long _l1;

        private static float _f2;
        private static bool _bool3;
        private static int _i4;
        private static int _i5;
        private static float _f;

        /**
         * List of car .rad files.
         */
        private static readonly string[] CarRads =
        {
            "2000tornados", "formula7", "canyenaro", "lescrab", "nimi", "maxrevenge", "leadoxide", "koolkat", "drifter",
            "policecops", "mustang", "king", "audir8", "masheen", "radicalone", "drmonster"
        };

        /**
         * List of track part .rad files.
         */
        public static readonly string[] StageRads =
        {
            "road", "froad", "twister2", "twister1", "turn", "offroad", "bumproad", "offturn", "nroad", "nturn",
            "roblend", "noblend", "rnblend", "roadend", "offroadend", "hpground", "ramp30", "cramp35", "dramp15",
            "dhilo15", "slide10", "takeoff", "sramp22", "offbump", "offramp", "sofframp", "halfpipe", "spikes", "rail",
            "thewall", "checkpoint", "fixpoint", "offcheckpoint", "sideoff", "bsideoff", "uprise", "riseroad", "sroad",
            "soffroad", "tside", "launchpad", "thenet", "speedramp", "offhill", "slider", "uphill", "roll1", "roll2",
            "roll3", "roll4", "roll5", "roll6", "opile1", "opile2", "aircheckpoint", "tree1", "tree2", "tree3", "tree4",
            "tree5", "tree6", "tree7", "tree8", "cac1", "cac2", "cac3", "8sroad", "8soffroad"
        };

        private static bool _gameLoaded;
        
        public static float Volume;

        /**
         * Loads models.zip
         */
        private static void Loadbase()
        {
            if (CarRads.Length < XTGraphics.NCars)
            {
                throw new Exception("too many cars and not enough rad files!");
            }

            var totalSize = 0;
            XTGraphics.Dnload += 6;

            FileUtil.LoadFiles("data/cars", CarRads, (ais, id) =>
            {
                _carContos[id] = new ContO(ais);
                if (!_carContos[id].Shadow)
                {
                    throw new Exception("car " + CarDefine.Names[id] + " does not have a shadow");
                }
            });

            FileUtil.LoadFiles("data/stageparts", StageRads, (ais, id) => { _contos[id] = new ContO(ais); });

            XTGraphics.Dnload++;

            for (var i = 0; i < StageRads.Length; i++)
            {
                if (_contos[i] == null)
                {
                    throw new Exception("No valid ContO (Stage Part) has been assigned to ID " + i + " (" +
                                        StageRads[i] +
                                        ")");
                }
            }
            for (var i = 0; i < CarRads.Length; i++)
            {
                if (_carContos[i] == null)
                {
                    throw new Exception("No valid ContO (Vehicle) has been assigned to ID " + i + " (" + StageRads[i] +
                                        ")");
                }
            }

            GC.Collect();
            if (_mload != -1 && totalSize != 615671)
            {
                _mload = 2;
            }
        }

        /**
         * Loads stage currently set by checkpoints.stage onto stageContos
         */
        private static void Loadstage()
        {
            if (XTGraphics.Testdrive == 2 || XTGraphics.Testdrive == 4)
            {
                XTGraphics.Nplayers = 1;
            }
            XTGraphics.Nplayers = 7;
            /*if (xtgraphics.gmode == 1) {
                xtgraphics.nplayers = 5;
                xtgraphics.xstart[4] = 0;
                xtgraphics.zstart[4] = 760;
            }*/
            Trackers.Nt = 0;
            _nob = XTGraphics.Nplayers;
            _notb = 0;
            CheckPoints.N = 0;
            CheckPoints.Nsp = 0;
            CheckPoints.Fn = 0;
            CheckPoints.Trackname = "";
            CheckPoints.Haltall = false;
            CheckPoints.Wasted = 0;
            CheckPoints.Catchfin = 0;
            Medium.Resdown = 0;
            Medium.Rescnt = 5;
            Medium.Lightson = false;
            Medium.Noelec = 0;
            Medium.Ground = 250;
            Medium.Trk = 0;
            _view = 0;
            var i = 0;
            var k = 100;
            var l = 0;
            var m = 100;
            XTGraphics.Newparts = false;
            var astring = "";
            try
            {
                var customStagePath = "stages/" + CheckPoints.Stage + ".txt";
                if (CheckPoints.Stage == -1)
                {
                    customStagePath = "mystages/" + CheckPoints.Name + ".txt";
                }
                foreach (var line in System.IO.File.ReadAllLines(customStagePath))
                {
                    astring = "" + line.Trim();
                    if (astring.StartsWith("snap"))
                    {
                        Medium.Setsnap(Getint("snap", astring, 0), Getint("snap", astring, 1),
                            Getint("snap", astring, 2));
                    }
                    if (astring.StartsWith("sky"))
                    {
                        Medium.Setsky(Getint("sky", astring, 0), Getint("sky", astring, 1), Getint("sky", astring, 2));
                        XTPart2.Snap(CheckPoints.Stage);
                    }
                    if (astring.StartsWith("ground"))
                    {
                        Medium.Setgrnd(Getint("ground", astring, 0), Getint("ground", astring, 1),
                            Getint("ground", astring, 2));
                    }
                    if (astring.StartsWith("polys"))
                    {
                        Medium.Setpolys(Getint("polys", astring, 0), Getint("polys", astring, 1),
                            Getint("polys", astring, 2));
                    }
                    if (astring.StartsWith("fog"))
                    {
                        Medium.Setfade(Getint("fog", astring, 0), Getint("fog", astring, 1), Getint("fog", astring, 2));
                    }
                    if (astring.StartsWith("texture"))
                    {
                        Medium.Setexture(Getint("texture", astring, 0), Getint("texture", astring, 1),
                            Getint("texture", astring, 2), Getint("texture", astring, 3));
                    }
                    if (astring.StartsWith("clouds"))
                    {
                        Medium.Setcloads(Getint("clouds", astring, 0), Getint("clouds", astring, 1),
                            Getint("clouds", astring, 2), Getint("clouds", astring, 3), Getint("clouds", astring, 4));
                    }
                    if (astring.StartsWith("density"))
                    {
                        Medium.Fogd = (Getint("density", astring, 0) + 1) * 2 - 1;
                        if (Medium.Fogd < 1)
                        {
                            Medium.Fogd = 1;
                        }
                        if (Medium.Fogd > 30)
                        {
                            Medium.Fogd = 30;
                        }
                    }
                    if (astring.StartsWith("fadefrom"))
                    {
                        Medium.Fadfrom(Getint("fadefrom", astring, 0));
                    }
                    if (astring.StartsWith("lightson"))
                    {
                        Medium.Lightson = true;
                    }
                    if (astring.StartsWith("mountains"))
                    {
                        Medium.Mgen = Getint("mountains", astring, 0);
                    }
                    if (astring.StartsWith("set"))
                    {
                        var setindex = Getint("set", astring, 0);
                        if (XTGraphics.Nplayers == 8)
                        {
                            if (setindex == 47)
                            {
                                setindex = 76;
                            }
                            if (setindex == 48)
                            {
                                setindex = 77;
                            }
                        }
                        var abool = true;
                        if (setindex >= 65 && setindex <= 75 && CheckPoints.Notb)
                        {
                            abool = false;
                        }
                        if (abool)
                        {
                            if (setindex == 49 || setindex == 64 || setindex >= 56 && setindex <= 61)
                            {
                                XTGraphics.Newparts = true;
                            }
                            if ((CheckPoints.Stage < 0 || CheckPoints.Stage >= 28) && setindex >= 10 && setindex <= 25)
                            {
                                Medium.Loadnew = true;
                            }
                            setindex -= 10;
                            Console.WriteLine("Setindex ais: " + setindex);
                            _stageContos[_nob] = new ContO(_contos[setindex], Getint("set", astring, 1),
                                Medium.Ground - _contos[setindex].Grat, Getint("set", astring, 2),
                                Getint("set", astring, 3));
                            if (astring.Contains(")p"))
                            {
                                CheckPoints.X[CheckPoints.N] = Getint("set", astring, 1);
                                CheckPoints.Z[CheckPoints.N] = Getint("set", astring, 2);
                                CheckPoints.Y[CheckPoints.N] = 0;
                                CheckPoints.Typ[CheckPoints.N] = 0;
                                if (astring.Contains(")pt"))
                                {
                                    CheckPoints.Typ[CheckPoints.N] = -1;
                                }
                                if (astring.Contains(")pr"))
                                {
                                    CheckPoints.Typ[CheckPoints.N] = -2;
                                }
                                if (astring.Contains(")po"))
                                {
                                    CheckPoints.Typ[CheckPoints.N] = -3;
                                }
                                if (astring.Contains(")ph"))
                                {
                                    CheckPoints.Typ[CheckPoints.N] = -4;
                                }
                                if (astring.Contains("aout"))
                                {
                                    Console.WriteLine("aout: " + CheckPoints.N);
                                }
                                CheckPoints.N++;
                                _notb = _nob + 1;
                            }
                            _nob++;
                            if (Medium.Loadnew)
                            {
                                Medium.Loadnew = false;
                            }
                        }
                    }
                    if (astring.StartsWith("chk"))
                    {
                        var chkindex = Getint("chk", astring, 0);
                        chkindex -= 10;
                        var chkheight = Medium.Ground - _contos[chkindex].Grat;
                        if (chkindex == 110)
                        {
                            chkheight = Getint("chk", astring, 4);
                        }
                        _stageContos[_nob] = new ContO(_contos[chkindex], Getint("chk", astring, 1), chkheight,
                            Getint("chk", astring, 2), Getint("chk", astring, 3));
                        CheckPoints.X[CheckPoints.N] = Getint("chk", astring, 1);
                        CheckPoints.Z[CheckPoints.N] = Getint("chk", astring, 2);
                        CheckPoints.Y[CheckPoints.N] = chkheight;
                        if (Getint("chk", astring, 3) == 0)
                        {
                            CheckPoints.Typ[CheckPoints.N] = 1;
                        }
                        else
                        {
                            CheckPoints.Typ[CheckPoints.N] = 2;
                        }
                        CheckPoints.Pcs = CheckPoints.N;
                        CheckPoints.N++;
                        _stageContos[_nob].Checkpoint = CheckPoints.Nsp + 1;
                        CheckPoints.Nsp++;
                        _nob++;
                        _notb = _nob;
                    }
                    if (CheckPoints.Nfix != 5 && astring.StartsWith("fix"))
                    {
                        var fixindex = Getint("fix", astring, 0);
                        fixindex -= 10;
                        _stageContos[_nob] = new ContO(_contos[fixindex], Getint("fix", astring, 1),
                            Getint("fix", astring, 3),
                            Getint("fix", astring, 2), Getint("fix", astring, 4));
                        CheckPoints.Fx[CheckPoints.Fn] = Getint("fix", astring, 1);
                        CheckPoints.Fz[CheckPoints.Fn] = Getint("fix", astring, 2);
                        CheckPoints.Fy[CheckPoints.Fn] = Getint("fix", astring, 3);
                        _stageContos[_nob].Elec = true;
                        if (Getint("fix", astring, 4) != 0)
                        {
                            CheckPoints.Roted[CheckPoints.Fn] = true;
                            _stageContos[_nob].Roted = true;
                        }
                        else
                        {
                            CheckPoints.Roted[CheckPoints.Fn] = false;
                        }
                        CheckPoints.Special[CheckPoints.Fn] = astring.IndexOf(")s") != -1;
                        CheckPoints.Fn++;
                        _nob++;
                        _notb = _nob;
                    }
                    if (!CheckPoints.Notb && astring.StartsWith("pile"))
                    {
                        _stageContos[_nob] = new ContO(Getint("pile", astring, 0), Getint("pile", astring, 1),
                            Getint("pile", astring, 2), Getint("pile", astring, 3), Getint("pile", astring, 4),
                            Medium.Ground);
                        _nob++;
                    }
                    if (XTGraphics.Multion == 0 && astring.StartsWith("nlaps"))
                    {
                        CheckPoints.Nlaps = Getint("nlaps", astring, 0);
                    }
                    //if (checkpoints.nlaps < 1)
                    //	checkpoints.nlaps = 1;
                    //if (checkpoints.nlaps > 15)
                    //	checkpoints.nlaps = 15;
                    if (CheckPoints.Stage > 0 && astring.StartsWith("name"))
                    {
                        CheckPoints.Name = Getastring("name", astring, 0).Replace('|', ',');
                    }
                    if (astring.StartsWith("stagemaker"))
                    {
                        CheckPoints.Maker = Getastring("stagemaker", astring, 0);
                    }
                    if (astring.StartsWith("publish"))
                    {
                        CheckPoints.Pubt = Getint("publish", astring, 0);
                    }
                    if (astring.StartsWith("soundtrack"))
                    {
                        CheckPoints.Trackname = Getastring("soundtrack", astring, 0);
                        CheckPoints.Trackvol = Getint("soundtrack", astring, 1);
                        if (CheckPoints.Trackvol < 50)
                        {
                            CheckPoints.Trackvol = 50;
                        }
                        if (CheckPoints.Trackvol > 300)
                        {
                            CheckPoints.Trackvol = 300;
                        }
                        XTGraphics.Sndsize[32] = Getint("soundtrack", astring, 2);
                    }
                    if (astring.StartsWith("maxr"))
                    {
                        var n = Getint("maxr", astring, 0);
                        var o = Getint("maxr", astring, 1);
                        i = o;
                        var p = Getint("maxr", astring, 2);
                        for (var q = 0; q < n; q++)
                        {
                            _stageContos[_nob] = new ContO(_contos[29], o,
                                Medium.Ground - _contos[29].Grat, //29 may need to be 85 or xtgraphics.nCars - 16
                                q * 4800 + p, 0);
                            _nob++;
                        }
                        Trackers.Y[Trackers.Nt] = -5000;
                        Trackers.Rady[Trackers.Nt] = 7100;
                        Trackers.X[Trackers.Nt] = o + 500;
                        Trackers.Radx[Trackers.Nt] = 600;
                        Trackers.Z[Trackers.Nt] = n * 4800 / 2 + p - 2400;
                        Trackers.Radz[Trackers.Nt] = n * 4800 / 2;
                        Trackers.Xy[Trackers.Nt] = 90;
                        Trackers.Zy[Trackers.Nt] = 0;
                        Trackers.Dam[Trackers.Nt] = 167;
                        Trackers.Decor[Trackers.Nt] = false;
                        Trackers.Skd[Trackers.Nt] = 0;
                        Trackers.Nt++;
                    }
                    if (astring.StartsWith("maxl"))
                    {
                        var n = Getint("maxl", astring, 0);
                        var o = Getint("maxl", astring, 1);
                        k = o;
                        var p = Getint("maxl", astring, 2);
                        for (var q = 0; q < n; q++)
                        {
                            _stageContos[_nob] = new ContO(_contos[29], o, Medium.Ground - _contos[29].Grat,
                                q * 4800 + p,
                                180);
                            _nob++;
                        }
                        Trackers.Y[Trackers.Nt] = -5000;
                        Trackers.Rady[Trackers.Nt] = 7100;
                        Trackers.X[Trackers.Nt] = o - 500;
                        Trackers.Radx[Trackers.Nt] = 600;
                        Trackers.Z[Trackers.Nt] = n * 4800 / 2 + p - 2400;
                        Trackers.Radz[Trackers.Nt] = n * 4800 / 2;
                        Trackers.Xy[Trackers.Nt] = -90;
                        Trackers.Zy[Trackers.Nt] = 0;
                        Trackers.Dam[Trackers.Nt] = 167;
                        Trackers.Decor[Trackers.Nt] = false;
                        Trackers.Skd[Trackers.Nt] = 0;
                        Trackers.Nt++;
                    }
                    if (astring.StartsWith("maxt"))
                    {
                        var n = Getint("maxt", astring, 0);
                        var o = Getint("maxt", astring, 1);
                        l = o;
                        var p = Getint("maxt", astring, 2);
                        for (var q = 0; q < n; q++)
                        {
                            _stageContos[_nob] = new ContO(_contos[29], q * 4800 + p, Medium.Ground - _contos[29].Grat,
                                o,
                                90);
                            _nob++;
                        }
                        Trackers.Y[Trackers.Nt] = -5000;
                        Trackers.Rady[Trackers.Nt] = 7100;
                        Trackers.Z[Trackers.Nt] = o + 500;
                        Trackers.Radz[Trackers.Nt] = 600;
                        Trackers.X[Trackers.Nt] = n * 4800 / 2 + p - 2400;
                        Trackers.Radx[Trackers.Nt] = n * 4800 / 2;
                        Trackers.Zy[Trackers.Nt] = 90;
                        Trackers.Xy[Trackers.Nt] = 0;
                        Trackers.Dam[Trackers.Nt] = 167;
                        Trackers.Decor[Trackers.Nt] = false;
                        Trackers.Skd[Trackers.Nt] = 0;
                        Trackers.Nt++;
                    }
                    if (astring.StartsWith("maxb"))
                    {
                        var n = Getint("maxb", astring, 0);
                        var o = Getint("maxb", astring, 1);
                        m = o;
                        var p = Getint("maxb", astring, 2);
                        for (var q = 0; q < n; q++)
                        {
                            _stageContos[_nob] = new ContO(_contos[29], q * 4800 + p, Medium.Ground - _contos[29].Grat,
                                o,
                                -90);
                            _nob++;
                        }
                        Trackers.Y[Trackers.Nt] = -5000;
                        Trackers.Rady[Trackers.Nt] = 7100;
                        Trackers.Z[Trackers.Nt] = o - 500;
                        Trackers.Radz[Trackers.Nt] = 600;
                        Trackers.X[Trackers.Nt] = n * 4800 / 2 + p - 2400;
                        Trackers.Radx[Trackers.Nt] = n * 4800 / 2;
                        Trackers.Zy[Trackers.Nt] = -90;
                        Trackers.Xy[Trackers.Nt] = 0;
                        Trackers.Dam[Trackers.Nt] = 167;
                        Trackers.Decor[Trackers.Nt] = false;
                        Trackers.Skd[Trackers.Nt] = 0;
                        Trackers.Nt++;
                    }
                }
                Medium.Newpolys(k, i - k, m, l - m, _notb);
                Medium.Newclouds(k, i, m, l);
                Medium.Newmountains(k, i, m, l);
                Medium.Newstars();
                Trackers.Devidetrackers(k, i - k, m, l - m);
            }
            catch (Exception exception)
            {
                Console.WriteLine("Error ain stage " + CheckPoints.Stage);
                Console.WriteLine("At line: " + astring);
                CheckPoints.Stage = -3;
                Console.WriteLine(exception);
            }
            if (CheckPoints.Nsp < 2)
            {
                CheckPoints.Stage = -3;
            }
            if (Medium.Nrw * Medium.Ncl >= 16000)
            {
                CheckPoints.Stage = -3;
            }
            if (CheckPoints.Stage != -3)
            {
                CheckPoints.Top20 = Math.Abs(CheckPoints.Top20);
                if (CheckPoints.Stage == 26)
                {
                    Medium.Lightn = 0;
                }
                else
                {
                    Medium.Lightn = -1;
                }
                Medium.Nochekflk = !(CheckPoints.Stage == 1 || CheckPoints.Stage == 11);
                for (var n = 0; n < XTGraphics.Nplayers; n++)
                {
                    U[n].Reset(XTGraphics.Sc[n]);
                    Mads[n].SetStat(new Stat(XTGraphics.Sc[n]));
                }
                XTPart2.Resetstat(CheckPoints.Stage);
                CheckPoints.Calprox();

                for (var j = 0; j < XTGraphics.Nplayers; j++)
                {
                    if (XTGraphics.Fase == 22)
                    {
                        XTGraphics.ColorCar(_carContos[XTGraphics.Sc[j]], j);
                    }
                    _stageContos[j] = new ContO(_carContos[XTGraphics.Sc[j]], XTGraphics.Xstart[j],
                        250 - _carContos[XTGraphics.Sc[j]].Grat, XTGraphics.Zstart[j], 0);
                    Mads[j].Reseto(XTGraphics.Sc[j], _stageContos[j]);
                }
                if (XTGraphics.Fase == 2 || XTGraphics.Fase == -22)
                {
                    Medium.Trx = (k + i) / 2;
                    Medium.Trz = (l + m) / 2;
                    Medium.Ptr = 0;
                    Medium.Ptcnt = -10;
                    Medium.Hit = 45000;
                    Medium.Fallen = 0;
                    Medium.Nrnd = 0;
                    Medium.Trk = 1;
                    Medium.Ih = 25;
                    Medium.Iw = 65;
                    Medium.H = 425;
                    Medium.W = 735;
                    XTGraphics.Fase = 1;
                    Mouses = 0;
                }
                if (XTGraphics.Fase == 22)
                {
                    Medium.Crs = false;
                    XTGraphics.Fase = 5;
                }
                if (CheckPoints.Stage > 0)
                {
                    XTGraphics.Asay = "Stage " + CheckPoints.Stage + ":  " + CheckPoints.Name + " ";
                }
                else
                {
                    XTGraphics.Asay = "Custom Stage:  " + CheckPoints.Name + " ";
                }
                Record.Reset(_stageContos);
            }
            else if (XTGraphics.Fase == 2)
            {
                XTGraphics.Fase = 1;
            }
            GC.Collect();
        }

        private static bool LoadstagePreview(int i, string astring, ContO[] contos, ContO[] contos147)
        {
            throw new NotImplementedException();
//        boolean abool = true;
//        if (i < 100)
//        {
//            CheckPoints.stage = i;
//            if (CheckPoints.stage < 0)
//            {
//                CheckPoints.name = astring;
//            }
//        }
//        else
//        {
//            CheckPoints.stage = -2;
//        }
//        nob = 0;
//        CheckPoints.n = 0;
//        CheckPoints.nsp = 0;
//        CheckPoints.fn = 0;
//        CheckPoints.haltall = false;
//        CheckPoints.wasted = 0;
//        CheckPoints.catchfin = 0;
//        Medium.ground = 250;
//        view = 0;
//        Medium.trx = 0L;
//        Medium.trz = 0L;
//        int i149 = 0;
//        int i150 = 100;
//        int i151 = 0;
//        int i152 = 100;
//        String string153 = "";
//        try
//        {
//            BufferedReader datainputstream;
//            if (CheckPoints.stage > 0)
//            {
//                URL url = new URL("http://multiplayer.needformadness.com/stages/" + CheckPoints.stage + ".txt");
//                datainputstream = new BufferedReader(new InputStreamReader(new DataInputStream(url.openStream())));
//            }
//            else
//            {
//                String string154 = "http://multiplayer.needformadness.com/tracks/" + CheckPoints.name + ".radq";
//                string154 = string154.replace(' ', '_');
//                URL url = new URL(string154);
//                int i155 = url.openConnection().getContentLength();
//                DataInputStream datainputstream156 = new DataInputStream(url.openStream());
//                byte[] ais  = new byte[i155];
//                datainputstream156.readFully( ais);
//                ZipInputStream zipinputstream;
//                if (ais[0] == 80 && ais[1] == 75 && ais[2] == 3) {
//                    zipinputstream = new ZipInputStream(new ByteArrayInputStream( ais));
//                } else {
//                    byte[] is157 = new byte[i155 - 40];
//                    for (int i158 = 0; i158 < i155 - 40; i158++)
//                    {
//                        int i159 = 20;
//                        if (i158 >= 500)
//                        {
//                            i159 = 40;
//                        }
//                        is157[i158] =  ais[i158 + i159];
//                    }
//                    zipinputstream = new ZipInputStream(new ByteArrayInputStream(is157));
//                }
//                ZipEntry zipentry = zipinputstream.getNextEntry();
//                int i160 = Integer.parseInt(zipentry.getName());
//                byte[] is161 = new byte[i160];
//                int i162 = 0;
//                int i163;
//                for (; i160 > 0; i160 -= i163)
//                {
//                    i163 = zipinputstream.read(is161, i162, i160);
//                    i162 += i163;
//                }
//                zipinputstream.close();
//                datainputstream156.close();
//                datainputstream =
//                    new BufferedReader(new InputStreamReader(new DataInputStream(new ByteArrayInputStream(is161))));
//            }
//            String string164;
//            while ((string164 = datainputstream.readLine()) != null)
//            {
//                string153 = "" + string164.trim();
//                if (string153.StartsWith("snap"))
//                {
//                    Medium.setsnap(getint("snap", string153, 0), getint("snap", string153, 1),
//                        getint("snap", string153, 2));
//                }
//                if (string153.StartsWith("sky"))
//                {
//                    Medium.setsky(getint("sky", string153, 0), getint("sky", string153, 1),
//                        getint("sky", string153, 2));
//                }
//                if (string153.StartsWith("ground"))
//                {
//                    Medium.setgrnd(getint("ground", string153, 0), getint("ground", string153, 1),
//                        getint("ground", string153, 2));
//                }
//                if (string153.StartsWith("polys"))
//                {
//                    Medium.setpolys(getint("polys", string153, 0), getint("polys", string153, 1),
//                        getint("polys", string153, 2));
//                }
//                if (string153.StartsWith("fog"))
//                {
//                    Medium.setfade(getint("fog", string153, 0), getint("fog", string153, 1),
//                        getint("fog", string153, 2));
//                }
//                if (string153.StartsWith("texture"))
//                {
//                    Medium.setexture(getint("texture", string153, 0), getint("texture", string153, 1),
//                        getint("texture", string153, 2), getint("texture", string153, 3));
//                }
//                if (string153.StartsWith("clouds"))
//                {
//                    Medium.setcloads(getint("clouds", string153, 0), getint("clouds", string153, 1),
//                        getint("clouds", string153, 2), getint("clouds", string153, 3), getint("clouds", string153, 4));
//                }
//                if (string153.StartsWith("density"))
//                {
//                    Medium.fogd = (getint("density", string153, 0) + 1) * 2 - 1;
//                    if (Medium.fogd < 1)
//                    {
//                        Medium.fogd = 1;
//                    }
//                    if (Medium.fogd > 30)
//                    {
//                        Medium.fogd = 30;
//                    }
//                }
//                if (string153.StartsWith("fadefrom"))
//                {
//                    Medium.fadfrom(getint("fadefrom", string153, 0));
//                }
//                if (string153.StartsWith("lightson"))
//                {
//                    Medium.lightson = true;
//                }
//                if (string153.StartsWith("mountains"))
//                {
//                    Medium.mgen = getint("mountains", string153, 0);
//                }
//                if (string153.StartsWith("soundtrack"))
//                {
//                    CheckPoints.trackname = getastring("soundtrack", string153, 0);
//                    CheckPoints.trackvol = getint("soundtrack", string153, 1);
//                    if (CheckPoints.trackvol < 50)
//                    {
//                        CheckPoints.trackvol = 50;
//                    }
//                    if (CheckPoints.trackvol > 300)
//                    {
//                        CheckPoints.trackvol = 300;
//                    }
//                }
//                if (string153.StartsWith("set"))
//                {
//                    int i165 = getint("set", string153, 0);
//                    i165 -= 10;
//                    contos[nob] = new ContO(contos147[i165], getint("set", string153, 1),
//                        Medium.ground - contos147[i165].grat, getint("set", string153, 2), getint("set", string153, 3));
//                    Trackers.nt = 0;
//                    if (string153.Contains(")p"))
//                    {
//                        CheckPoints.x[CheckPoints.n] = getint("chk", string153, 1);
//                        CheckPoints.z[CheckPoints.n] = getint("chk", string153, 2);
//                        CheckPoints.y[CheckPoints.n] = 0;
//                        CheckPoints.typ[CheckPoints.n] = 0;
//                        if (string153.Contains(")pt"))
//                        {
//                            CheckPoints.typ[CheckPoints.n] = -1;
//                        }
//                        if (string153.Contains(")pr"))
//                        {
//                            CheckPoints.typ[CheckPoints.n] = -2;
//                        }
//                        if (string153.Contains(")po"))
//                        {
//                            CheckPoints.typ[CheckPoints.n] = -3;
//                        }
//                        if (string153.Contains(")ph"))
//                        {
//                            CheckPoints.typ[CheckPoints.n] = -4;
//                        }
//                        if (string153.Contains("aout"))
//                        {
//                            Console.WriteLine("aout: " + CheckPoints.n);
//                        }
//                        CheckPoints.n++;
//                    }
//                    nob++;
//                }
//                if (string153.StartsWith("chk"))
//                {
//                    int i166 = getint("chk", string153, 0);
//                    i166 -= 10;
//                    int i167 = Medium.ground - contos147[i166].grat;
//                    if (i166 == 110)
//                    {
//                        i167 = getint("chk", string153, 4);
//                    }
//                    contos[nob] = new ContO(contos147[i166], getint("chk", string153, 1), i167,
//                        getint("chk", string153, 2), getint("chk", string153, 3));
//                    CheckPoints.x[CheckPoints.n] = getint("chk", string153, 1);
//                    CheckPoints.z[CheckPoints.n] = getint("chk", string153, 2);
//                    CheckPoints.y[CheckPoints.n] = i167;
//                    if (getint("chk", string153, 3) == 0)
//                    {
//                        CheckPoints.typ[CheckPoints.n] = 1;
//                    }
//                    else
//                    {
//                        CheckPoints.typ[CheckPoints.n] = 2;
//                    }
//                    CheckPoints.pcs = CheckPoints.n;
//                    CheckPoints.n++;
//                    contos[nob].checkpoint = CheckPoints.nsp + 1;
//                    CheckPoints.nsp++;
//                    nob++;
//                }
//                if (string153.StartsWith("fix"))
//                {
//                    int i168 = getint("fix", string153, 0);
//                    i168 -= 10;
//                    contos[nob] = new ContO(contos147[i168], getint("fix", string153, 1), getint("fix", string153, 3),
//                        getint("fix", string153, 2), getint("fix", string153, 4));
//                    CheckPoints.fx[CheckPoints.fn] = getint("fix", string153, 1);
//                    CheckPoints.fz[CheckPoints.fn] = getint("fix", string153, 2);
//                    CheckPoints.fy[CheckPoints.fn] = getint("fix", string153, 3);
//                    contos[nob].elec = true;
//                    if (getint("fix", string153, 4) != 0)
//                    {
//                        CheckPoints.roted[CheckPoints.fn] = true;
//                        contos[nob].roted = true;
//                    }
//                    else
//                    {
//                        CheckPoints.roted[CheckPoints.fn] = false;
//                    }
//                    CheckPoints.special[CheckPoints.fn] = string153.Contains(")s");
//                    CheckPoints.fn++;
//                    nob++;
//                }
//                if (string153.StartsWith("nlaps"))
//                {
//                    CheckPoints.nlaps = getint("nlaps", string153, 0);
//                    if (CheckPoints.nlaps < 1)
//                    {
//                        CheckPoints.nlaps = 1;
//                    }
//                    if (CheckPoints.nlaps > 15)
//                    {
//                        CheckPoints.nlaps = 15;
//                    }
//                }
//                if (CheckPoints.stage > 0 && string153.StartsWith("name"))
//                {
//                    CheckPoints.name = getastring("name", string153, 0).replace('|', ',');
//                }
//                if (string153.StartsWith("stagemaker"))
//                {
//                    CheckPoints.maker = getastring("stagemaker", string153, 0);
//                }
//                if (string153.StartsWith("publish"))
//                {
//                    CheckPoints.pubt = getint("publish", string153, 0);
//                }
//                if (string153.StartsWith("maxr"))
//                {
//                    i149 = getint("maxr", string153, 1);
//                }
//                //i149 = i169;
//                if (string153.StartsWith("maxl"))
//                {
//                    i150 = getint("maxl", string153, 1);
//                }
//                //i150 = i170;
//                if (string153.StartsWith("maxt"))
//                {
//                    i151 = getint("maxt", string153, 1);
//                }
//                //i151 = i171;
//                if (string153.StartsWith("maxb"))
//                {
//                    i152 = getint("maxb", string153, 1);
//                    //i152 = i172;
//                }
//            }
//            datainputstream.close();
//            Medium.newpolys(i150, i149 - i150, i152, i151 - i152, notb);
//            Medium.newclouds(i150, i149, i152, i151);
//            Medium.newmountains(i150, i149, i152, i151);
//            Medium.newstars();
//        }
//        catch (Exception
//        exception) {
//            abool = false;
//            Console.WriteLine("Error ain stage " + CheckPoints.stage);
//            Console.WriteLine("" + exception);
//            Console.WriteLine("At line: " + string153);
//        }
//        if (CheckPoints.nsp < 2)
//        {
//            abool = false;
//        }
//        if (Medium.nrw * Medium.ncl >= 16000)
//        {
//            abool = false;
//        }
//        Medium.trx = (i150 + i149) / 2;
//        Medium.trz = (i151 + i152) / 2;
//        GC.Collect();
//        return abool;
        }

        /**
         * handles clicking the 'Radical Play' link
         */
        private static void Catchlink()
        {
            if (!_lostfcs)
            {
                if (_xm > 65 && _xm < 735 && _ym > 135 && _ym < 194 || _xm > 275 && _xm < 525 && _ym > 265 && _ym < 284)
                {
                    //gsPanel.setCursor(new Cursor(12));
                    if (Mouses == 2)
                    {
                        Openurl("http://www.radicalplay.com/");
                    }
                }
            }
        }

        private static void Checkmemory()
        {
            //TODO
        }

//    /**
//     * I forgot what this does lmao
//     *
//     * @param graphics2d graphics2d object
//     * @param x X position
//     * @param y Y position
//     */
//    private static void cropit(int x, int y) {
//        if (x != 0 || y != 0)
//        {
//            graphics2d.setComposite(AlphaComposite.getInstance(3, 1.0F));
//            graphics2d.setColor(new Color(0, 0, 0));
//        }
//        if (x != 0)
//            if (x < 0)
//            {
//                graphics2d.fillRect(apx + x, apy - (int) (25.0F * apmult), Math.Abs(x), (int) (500.0F * apmult));
//            }
//            else
//            {
//                graphics2d.fillRect(apx + (int) (800.0F * apmult), apy - (int) (25.0F * apmult), x,
//                    (int) (500.0F * apmult));
//            }
//        if (y != 0)
//            if (y < 0)
//            {
//                graphics2d.fillRect(apx - (int) (25.0F * apmult), apy + y, (int) (850.0F * apmult), Math.Abs(y));
//            }
//            else
//            {
//                graphics2d.fillRect(apx - (int) (25.0F * apmult), apy + (int) (450.0F * apmult),
//                    (int) (850.0F * apmult), y);
//            }
//    }

        /**
         * Draws SMenus
         */
        static void Drawms()
        {
//        openm = gmode.draw(rd, xm, ym, moused, 450, true);
//        if (swait.draw(rd, xm, ym, moused, 450, false))
//        {
//            openm = true;
//        }
//        if (slaps.draw(rd, xm, ym, moused, 450, false))
//        {
//            openm = true;
//        }
//        if (snpls.draw(rd, xm, ym, moused, 450, false))
//        {
//            openm = true;
//        }
//        if (snbts.draw(rd, xm, ym, moused, 450, false))
//        {
//            openm = true;
//        }
//        if (scars.draw(rd, xm, ym, moused, 450, false))
//        {
//            openm = true;
//        }
//        if (sgame.draw(rd, xm, ym, moused, 450, false))
//        {
//            openm = true;
//        }
//        //if (snfm1.draw(rd, xm, ym, moused, 450, false))
//        //  openm = true;
//        //if (snfm2.draw(rd, xm, ym, moused, 450, false))
//        //  openm = true;
//        if (snfmm.draw(rd, xm, ym, moused, 450, false))
//        {
//            openm = true;
//        }
//        if (mstgs.draw(rd, xm, ym, moused, 450, false))
//        {
//            openm = true;
//        }
//        if (mcars.draw(rd, xm, ym, moused, 450, false))
//        {
//            openm = true;
//        }
//        if (pgame.draw(rd, xm, ym, moused, 450, false))
//        {
//            openm = true;
//        }
//        if (vnpls.draw(rd, xm, ym, moused, 450, false))
//        {
//            openm = true;
//        }
//        if (vtyp.draw(rd, xm, ym, moused, 450, false))
//        {
//            openm = true;
//        }
//        if (warb.draw(rd, xm, ym, moused, 450, false))
//        {
//            openm = true;
//        }
//        if (wgame.draw(rd, xm, ym, moused, 450, false))
//        {
//            openm = true;
//        }
//        if (rooms.draw(rd, xm, ym, moused, 450, false))
//        {
//            openm = true;
//        }
//        if (sendtyp.draw(rd, xm, ym, moused, 450, true))
//        {
//            openm = true;
//        }
//        if (senditem.draw(rd, xm, ym, moused, 450, true))
//        {
//            openm = true;
//        }
//        if (datat.draw(rd, xm, ym, moused, 450, true))
//        {
//            openm = true;
//        }
//        if (clanlev.draw(rd, xm, ym, moused, 450, false))
//        {
//            openm = true;
//        }
//        if (clcars.draw(rd, xm, ym, moused, 450, false))
//        {
//            openm = true;
//        }
//        if (ilaps.draw(rd, xm, ym, moused, 450, true))
//        {
//            openm = true;
//        }
//        if (icars.draw(rd, xm, ym, moused, 450, true))
//        {
//            openm = true;
//        }
//        if (proitem.draw(rd, xm, ym, moused, 450, false))
//        {
//            openm = true;
//        }
//        if (sfix.draw(rd, xm, ym, moused, 450, false))
//        {
//            openm = true;
//        }
//        if (sclass.draw(rd, xm, ym, moused, 450, false))
//        {
//            openm = true;
//        }
        }

        internal static void Editlink(string accountid, bool isLogged)
        {
            var logged = "";
            if (isLogged)
            {
                logged = "?display=upgrade";
            }
            Openurl("http://multiplayer.needformadness.com/edit.pl" + logged + "#" + accountid + "");
        }

        internal static int Getint(string astring, string string4, int i)
        {
            // TODO
            return Utility.Getint(astring, string4, i);
        }

        /**
         * Gets astring ain format: {@code <string2>} astring(A,B,1231,{@code i},C,1.5) {@code </string2>}
         *
         * @param astring the tag
         * @param string2 the whole line
         * @param i the position of the astring
         * @return tthe astring at the position
         */
        internal static string Getastring(string astring, string string2, int i)
        {
            var j = 0;
            var string3 = "";
            for (var k = astring.Length() + 1; k < string2.Length(); k++)
            {
                var string4 = "" + string2.CharAt(k);
                if (Equals(string4, ",") || Equals(string4, ")"))
                {
                    j++;
                    k++;
                }
                if (j == i)
                {
                    string3 = string3 + string2.CharAt(k);
                }
            }
            return string3;
        }

        /**
         * Hides SMenus
         */
        private static void Hidefields()
        {
//        ilaps.setVisible(false);
//        icars.setVisible(false);
//        proitem.setVisible(false);
//        clcars.setVisible(false);
//        clanlev.setVisible(false);
//        mmsg.setVisible(false);
//        datat.setVisible(false);
//        senditem.setVisible(false);
//        sendtyp.setVisible(false);
//        rooms.setVisible(false);
            Mcars.SetVisible(false);
            Mstgs.SetVisible(false);
//        gmode.setVisible(false);
//        sclass.setVisible(false);
//        scars.setVisible(false);
//        sfix.setVisible(false);
//        mycar.setVisible(false);
//        notp.setVisible(false);
//        keplo.setVisible(false);
//        tnick.setVisible(false);
//        tpass.setVisible(false);
//        temail.setVisible(false);
//        cmsg.setVisible(false);
//        sgame.setVisible(false);
//        wgame.setVisible(false);
//        pgame.setVisible(false);
//        vnpls.setVisible(false);
//        vtyp.setVisible(false);
//        warb.setVisible(false);
//        slaps.setVisible(false);
//        //snfm1.setVisible(false);
//        snfmm.setVisible(false);
//        //snfm2.setVisible(false);
//        snpls.setVisible(false);
//        snbts.setVisible(false);
//        swait.setVisible(false);
        }

        //@Override
        private static void InitFields()
        {
//        tnick = new TextField("Nickbname");
//        tnick.setFont(new Font("Arial", 1, 13));
//        tpass = new TextField("");
//        tpass.setFont(new Font("Arial", 1, 13));
//        tpass.setEchoChar('*');
//        temail = new TextField("");
//        temail.setFont(new Font("Arial", 1, 13));
//        cmsg = new TextField("");
//        if (System.getProperty("java.vendor").ToLower().Contains("oracle"))
//        {
//            cmsg.addKeyListener(new KeyAdapter()
//            {
//                @Override
//                public void keyPressed(KeyEvent e) {
//                if (e.getKeyCode() == 10 && u[0] != null) {
//                u[0].enter = true;
//            }
//            }
//            });
//        }
//        mmsg = new TextArea("", 200, 20, 3);
//        cmsg.setFont(new Font("Tahoma", 0, 11));
//        mmsg.setFont(new Font("Tahoma", 0, 11));
//        mycar = new Checkbox("Sword of Justice Game!");
//        notp = new Checkbox("No Trees & Piles");
//        keplo = new Checkbox("Stay logged ain");
//        keplo.setState(true);
//        gsPanel.add(tnick);
//        gsPanel.add(tpass);
//        gsPanel.add(temail);
//        gsPanel.add(cmsg);
//        gsPanel.add(mmsg);
//        gsPanel.add(mycar);
//        gsPanel.add(notp);
//        gsPanel.add(keplo);
//        sgame.setFont();
//        wgame.setFont();
//        warb.setFont();
//        pgame.setFont();
//        vnpls.setFont();
//        vtyp.setFont();
//        snfmm.setFont();
            //snfm1.setFont(new Font("Arial", 1, 13));
            //snfm2.setFont(new Font("Arial", 1, 13));
            Mstgs.SetFont();
            Mcars.SetFont();
//        slaps.setFont();
//        snpls.setFont();
//        snbts.setFont();
//        swait.setFont();
//        sclass.setFont();
//        scars.setFont();
//        sfix.setFont();
//        mycar.setFont(new Font("Arial", 1, 12));
//        notp.setFont(new Font("Arial", 1, 12));
//        keplo.setFont(new Font("Arial", 1, 12));
//        gmode.setFont();
//        rooms.setFont();
//        sendtyp.setFont();
//        senditem.setFont();
//        datat.setFont();
//        clanlev.setFont();
//        clcars.setFont();
//        clcars.alphad = true;
//        ilaps.setFont();
//        icars.setFont();
//        proitem.setFont();
        }

        internal static void Madlink()
        {
            Openurl("http://www.needformadness.com/");
        }

        public static void MouseW(int i)
        {
            if (!_exwist)
            {
                _mousew += i * 4;
            }
        }

        static void Movefield(object component, int i, int i99, int i100, int i101)
        {
//        if (i100 == 360 || i100 == 576)
//        {
//            i = (int) (i * apmult + apx + component.getWidth() / 2 * (apmult - 1.0F));
//            i99 = (int) (i99 * apmult + apy + 12.0F * (apmult - 1.0F));
//        }
//        else
//        {
//            i = (int) (i * apmult + apx);
//            i99 = (int) (i99 * apmult + apy + 12.0F * (apmult - 1.0F));
//        }
//        if (component.getX() != i || component.getY() != i99)
//        {
//            component.setBounds(i, i99, i100, i101);
//        }
        }

        public static void Movefielda(object textarea, int i, int i105, int i106, int i107)
        {
//        if (applejava)
//        {
//            if (xm > i && xm < i + i106 && ym > i105 && ym < i105 + i107 || !textarea.getText().equals(" "))
//            {
//                if (!textarea.isShowing())
//                {
//                    textarea.setVisible(true);
//                    textarea.requestFocus();
//                }
//                if (i106 == 360 || i106 == 576)
//                {
//                    i = (int) (i * apmult + apx + textarea.getWidth() / 2 * (apmult - 1.0F));
//                    i105 = (int) (i105 * apmult + apy + 12.0F * (apmult - 1.0F));
//                }
//                else
//                {
//                    i = (int) (i * apmult + apx);
//                    i105 = (int) (i105 * apmult + apy + 12.0F * (apmult - 1.0F));
//                }
//                if (textarea.getX() != i || textarea.getY() != i105)
//                {
//                    textarea.setBounds(i, i105, i106, i107);
//                }
//            }
//            else
//            {
//                if (textarea.isShowing())
//                {
//                    textarea.setVisible(false);
//                    gsPanel.requestFocus();
//                }
//                rd.setColor(textarea.getBackground());
//                rd.fillRect(i, i105, i106 - 1, i107 - 1);
//                rd.setColor(textarea.getBackground().darker());
//                rd.drawRect(i, i105, i106 - 1, i107 - 1);
//            }
//        }
//        else
//        {
//            if (!textarea.isShowing())
//            {
//                textarea.setVisible(true);
//            }
//            movefield(textarea, i, i105, i106, i107);
//        }
        }

        static void Movefieldd(object textfield, int i, int i102, int i103, int
            i104, bool abool)
        {
//        if (applejava)
//        {
//            if (abool)
//                if (xm > i && xm < i + i103 && ym > i102 && ym < i102 + i104 || !textfield.getText().equals(""))
//                {
//                    if (!textfield.isShowing())
//                    {
//                        textfield.setVisible(true);
//                        textfield.requestFocus();
//                    }
//                    if (i103 == 360 || i103 == 576)
//                    {
//                        i = (int) (i * apmult + apx + textfield.getWidth() / 2 * (apmult - 1.0F));
//                        i102 = (int) (i102 * apmult + apy + 12.0F * (apmult - 1.0F));
//                    }
//                    else
//                    {
//                        i = (int) (i * apmult + apx);
//                        i102 = (int) (i102 * apmult + apy + 12.0F * (apmult - 1.0F));
//                    }
//                    if (textfield.getX() != i || textfield.getY() != i102)
//                    {
//                        textfield.setBounds(i, i102, i103, i104);
//                    }
//                }
//                else
//                {
//                    if (textfield.isShowing())
//                    {
//                        textfield.setVisible(false);
//                        gsPanel.requestFocus();
//                    }
//                    rd.setColor(textfield.getBackground());
//                    rd.fillRect(i, i102, i103 - 1, i104 - 1);
//                    rd.setColor(textfield.getBackground().darker());
//                    rd.drawRect(i, i102, i103 - 1, i104 - 1);
//                }
//        }
//        else
//        {
//            if (abool && !textfield.isShowing())
//            {
//                textfield.setVisible(true);
//            }
//            movefield(textfield, i, i102, i103, i104);
//        }
        }

        internal static void Multlink()
        {
            Openurl("http://multiplayer.needformadness.com/");
        }

        internal static void Musiclink()
        {
            Openurl("http://multiplayer.needformadness.com/music.html");
        }

        internal static void Onfmmlink()
        {
            Openurl("https://github.com/chrishansen69/OpenNFMM");
        }

        private static void Openurl(string astring)
        {
            throw new NotImplementedException();
//        if (Desktop.isDesktopSupported())
//        {
//            try
//            {
//                Desktop.getDesktop().browse(new URI(astring));
//            }
//            catch (Exception
//            ignored) {
//
//            }
//        }
//        else
//        {
//            try
//            {
//                Runtime.getRuntime().exec("" + Madness.urlopen() + " " + astring + "");
//            }
//            catch (Exception
//            ignored) {
//
//            }
//        }
        }

        private static void Trash()
        {
//        rd.dispose();
            XTPart2.Stopallnow();
            //cardefine.stopallnow();
            //udpmistro.UDPquit();
            GC.Collect();
        }

//    @Override
//
//    public void paintComponent(Graphics g)
//    {
//        Graphics2D g2 = (Graphics2D) g;
//        g.setColor(Color.BLACK);
//        g.fillRect(0, 0, getWidth(), getHeight());
//
//        try
//        {
//            gameTick();
//        }
//        catch (Exception
//        e) {
//            e.printStackTrace();
//            exwist = true;
//            trash();
//            System.exit(3);
//        }
//        if (lastw != getWidth() || lasth != getHeight())
//        {
//            lastw = getWidth();
//            lasth = getHeight();
//            showsize = 100;
//            if (lastw <= 800 || lasth <= 550)
//            {
//                reqmult = 0.0F;
//            }
//            if (Madness.fullscreen)
//            {
//                apx = (int) (getWidth() / 2 - 400.0F * apmult);
//                apy = (int) (getHeight() / 2 - 225.0F * apmult);
//            }
//        }
//        int i = 0;
//        int i97 = 0;
//        if (moto == 1 && shaka > 0)
//        {
//            i = (int) ((shaka * 2 * HansenRandom.Double() - shaka) * apmult);
//            i97 = (int) ((shaka * 2 * HansenRandom.Double() - shaka) * apmult);
//            shaka--;
//        }
//        if (!Madness.fullscreen)
//        {
//            if (showsize != 0)
//            {
//                float f = (getWidth() - 40) / 800.0F - 1.0F;
//                if (f > (getHeight() - 70) / 450.0F - 1.0F)
//                {
//                    f = (getHeight() - 70) / 450.0F - 1.0F;
//                }
//                if (f > 1.0F)
//                {
//                    f = 1.0F;
//                }
//                if (f < 0.0F)
//                {
//                    f = 0.0F;
//                }
//                apmult = 1.0F + f * reqmult;
//                if (!oncarm)
//                {
//                    g2.drawImage(carmaker[0], 50, 14, this);
//                }
//                else
//                {
//                    g2.drawImage(carmaker[1], 50, 14, this);
//                }
//                if (!onstgm)
//                {
//                    g2.drawImage(stagemaker[0], getWidth() - 208, 14, this);
//                }
//                else
//                {
//                    g2.drawImage(stagemaker[1], getWidth() - 208, 14, this);
//                }
//                g2.drawImage(sizebar, getWidth() / 2 - 230, 23, this);
//                g2.drawImage(blb, (int) (getWidth() / 2 - 222 + 141.0F * reqmult), 23, this);
//                g2.drawImage(chkbx[smooth], getWidth() / 2 - 53, 23, this);
//                g2.setFont(new Font("Arial", 1, 11));
//                g2.setColor(new Color(74, 99, 125));
//                g2.drawString("Screen Size:", getWidth() / 2 - 224, 17);
//                g2.drawString("Smooth", getWidth() / 2 - 36, 34);
//                g2.drawImage(fulls, getWidth() / 2 + 27, 15, this);
//                g2.setColor(new Color(94, 126, 159));
//                g2.drawString("Fullscreen", getWidth() / 2 + 63, 30);
//                g2.drawImage(chkbx[Madness.anti], getWidth() / 2 + 135, 9, this);
//                g2.drawString("Antialiasing", getWidth() / 2 + 152, 20);
//                g2.drawImage(chkbx[moto], getWidth() / 2 + 135, 26, this);
//                g2.drawString("Motion Effects", getWidth() / 2 + 152, 37);
//                g2.setColor(new Color(0, 0, 0));
//                g2.fillRect(getWidth() / 2 - 153, 5, 80, 16);
//                g2.setColor(new Color(121, 135, 152));
//                String astring = "" + (int) (apmult * 100.0F) + "%";
//                if (reqmult == 0.0F)
//                {
//                    astring = "Original";
//                }
//                if (reqmult == 1.0F)
//                {
//                    astring = "Maximum";
//                }
//                g2.drawString(astring, getWidth() / 2 - 150, 17);
//                if (!oncarm && !onstgm)
//                {
//                    showsize--;
//                }
//                if (showsize == 0)
//                {
//                    g2.setColor(new Color(0, 0, 0));
//                    g2.fillRect(getWidth() / 2 - 260, 0, 520, 40);
//                    g2.fillRect(50, 14, 142, 23);
//                    g2.fillRect(getWidth() - 208, 14, 158, 23);
//                }
//            }
//            apx = (int) (getWidth() / 2 - 400.0F * apmult);
//            apy = (int) (getHeight() / 2 - 225.0F * apmult - 50.0F);
//            if (apy < 50)
//            {
//                apy = 50;
//            }
//            if (apmult > 1.0F)
//            {
//                if (smooth == 1)
//                {
//                    g2.setRenderingHint(RenderingHints.KEY_INTERPOLATION, RenderingHints.VALUE_INTERPOLATION_BILINEAR);
//                    if (moto == 1)
//                    {
//                        rd.setRenderingHint(RenderingHints.KEY_ALPHA_INTERPOLATION,
//                            RenderingHints.VALUE_ALPHA_INTERPOLATION_SPEED);
//                        g2.drawImage(tribuffer, apx + i, apy + i97, (int) (800.0F * apmult), (int) (450.0F * apmult),
//                            this);
//                        cropit(g2, i, i97);
//                        tG.SetAlpha(mvect / 100.0F);
//                        tg.drawImage(offImage, 0, 0, null);
//                    }
//                    else
//                    {
//                        g2.drawImage(offImage, apx, apy, (int) (800.0F * apmult), (int) (450.0F * apmult), this);
//                    }
//                }
//                else if (moto == 1)
//                {
//                    rd.setRenderingHint(RenderingHints.KEY_ALPHA_INTERPOLATION,
//                        RenderingHints.VALUE_ALPHA_INTERPOLATION_SPEED);
//                    g2.drawImage(tribuffer, apx + i, apy + i97, (int) (800.0F * apmult), (int) (450.0F * apmult), this);
//                    cropit(g2, i, i97);
//                }
//                else
//                {
//                    g2.drawImage(offImage, apx, apy, (int) (800.0F * apmult), (int) (450.0F * apmult), this);
//                }
//            }
//            else if (moto == 1)
//            {
//                rd.setRenderingHint(RenderingHints.KEY_ALPHA_INTERPOLATION,
//                    RenderingHints.VALUE_ALPHA_INTERPOLATION_SPEED);
//                g2.drawImage(tribuffer, apx + i, apy + i97, this);
//                cropit(g2, i, i97);
//                tG.SetAlpha(mvect / 100.0F);
//                tg.drawImage(offImage, 0, 0, null);
//            }
//            else
//            {
//                g2.drawImage(offImage, apx, apy, this);
//            }
//        }
//        else if (moto == 1)
//        {
//            rd.setRenderingHint(RenderingHints.KEY_ALPHA_INTERPOLATION, RenderingHints.VALUE_ALPHA_INTERPOLATION_SPEED);
//            g2.drawImage(tribuffer, apx + i, apy + i97, this);
//            cropit(g2, i, i97);
//            tG.SetAlpha(mvect / 100.0F);
//            tg.drawImage(offImage, 0, 0, null);
//        }
//        else
//        {
//            g2.drawImage(offImage, apx, apy, this);
//        }
//    }

        private static void Readcookies(IReadOnlyList<ContO> contos)
        {
            HansenData.ReadCookie(contos);
        }

        static void Reglink()
        {
            Openurl("http://multiplayer.needformadness.com/register.html?ref=game");
        }

        static void Regnew()
        {
            Openurl("http://multiplayer.needformadness.com/registernew.pl");
        }

        private static void MakeMenus()
        {
//        rd.setRenderingHint(RenderingHints.KEY_TEXT_ANTIALIASING, RenderingHints.VALUE_TEXT_ANTIALIAS_ON);
//        rd.setRenderingHint(RenderingHints.KEY_ANTIALIASING, RenderingHints.VALUE_ANTIALIAS_ON);
//        sgame.add(rd, " NFM 1     ");
//        sgame.add(rd, " NFM 2     ");
//        sgame.add(rd, " My Stages ");
//        sgame.add(rd, " Weekly Top20 ");
//        sgame.add(rd, " Monthly Top20 ");
//        sgame.add(rd, " All Time Top20 ");
//        sgame.add(rd, " Stage Maker ");
//        wgame.add(rd, " Normal Game");
//        wgame.add(rd, " War / Battle");
//        wgame.add(rd, " War / Battle - Practice");
//        warb.add(rd, " Loading your clan's wars and battles, please wait...");
//        pgame.add(rd, " Select the game you want to practice");
//        vnpls.add(rd, "Players");
//        vnpls.add(rd, " 2 VS 2");
//        vnpls.add(rd, " 3 VS 3");
//        vnpls.add(rd, " 4 VS 4");
//        vtyp.add(rd, "Normal clan game");
//        vtyp.add(rd, "Racing only");
//        vtyp.add(rd, "Wasting only");
//        vtyp.add(rd, "Racers VS Wasters - my clan wastes");
//        vtyp.add(rd, "Racers VS Wasters - my clan races");
//        snfmm.add(rd, "Select Stage");
            //snfm1.add(rd, "Select Stage");
            //snfm2.add(rd, "Select Stage");
            Mstgs.Add("Suddenly the King becomes Santa's Little Helper");
            Mcars.Add("Sword of Justice");
//        snpls.add(rd, "Select");
//        swait.add(rd, "1 Minute");
//        ilaps.add(rd, "Laps");
//        ilaps.add(rd, "1 Lap");
//        for (int i = 0; i < xtGraphics.nTracks; i++)
//        {
//            snfmm.add(rd, " Stage " + (i + 1) + "");
//        }
            /*for (int i = 0; i < 10; i++)
                snfm1.add(rd, "" + (" Stage ") + (i + 1) + (""));
            for (int i = 0; i < 17; i++)
                snfm2.add(rd, "" + (" Stage ") + (i + 1) + (""));*/
//        for (int i = 0; i < 7; i++)
//        {
//            snpls.add(rd, "    " + (i + 2) + "");
//        }
//        for (int i = 0; i < 7; i++)
//        {
//            snbts.add(rd, "    " + i + "    ");
//        }
//        for (int i = 0; i < 2; i++)
//        {
//            swait.add(rd, "" + (i + 2) + " Minutes");
//        }
//        for (int i = 0; i < 15; i++)
//        {
//            slaps.add(rd, "" + (i + 1) + "");
//        }
//        for (int i = 0; i < 14; i++)
//        {
//            ilaps.add(rd, "" + (i + 2) + " Laps");
//        }
//        sclass.add(rd, "All Classes");
//        sclass.add(rd, "Class C Cars");
//        sclass.add(rd, "Class B & C Cars");
//        sclass.add(rd, "Class B Cars");
//        sclass.add(rd, "Class A & B Cars");
//        sclass.add(rd, "Class A Cars");
//        scars.add(rd, "All Cars");
//        scars.add(rd, "Custom Cars");
//        scars.add(rd, "Game Cars");
//        sfix.add(rd, "Unlimited Fixing");
//        sfix.add(rd, "4 Fixes");
//        sfix.add(rd, "3 Fixes");
//        sfix.add(rd, "2 Fixes");
//        sfix.add(rd, "1 Fix");
//        sfix.add(rd, "No Fixing");
//        icars.add(rd, "Type of Cars");
//        icars.add(rd, "All Cars");
//        icars.add(rd, "Clan Cars");
//        icars.add(rd, "Game Cars");
//        icars.w = 140;
//        gmode.add(rd, " Normal Game ");
//        gmode.add(rd, " Practice Game ");
//        rooms.rooms = true;
//        rooms.add(rd, "Ghostrider :: 1");
//        sendtyp.add(rd, "Write a Message");
//        sendtyp.add(rd, "Share a Custom Car");
//        sendtyp.add(rd, "Share a Custom Stage");
//        sendtyp.add(rd, "Send a Clan Invitation");
//        sendtyp.add(rd, "Share a Relative Date");
//        senditem.add(rd, "Suddenly the King becomes Santa's Little Helper");
//        for (int i = 0; i < 6; i++)
//        {
//            clanlev.add(rd, "" + (i + 1) + "");
//        }
//        clanlev.add(rd, "7 - Admin");
            Hidefields();
        }

        private GameSparker()
        {
        }

        public static GameSparker Create()
        {
//        gsPanel = new GameSparker();

//        BASSLoader.initializeBASS();
            InitFields();

//        gsPanel.setBorder(BorderFactory.createLineBorder(Color.black));
//        //
//        gsPanel.setBackground(Color.black);
//        gsPanel.setOpaque(true);
//        //
//        gsPanel.setLayout(null);

            MakeMenus();

            PreloadGame();

            //new Thread(GameSparker.loadGame).Start();
            LoadGame();

//        gsPanel.addKeyListener(gsPanel);
//        gsPanel.addMouseListener(gsPanel);
//        gsPanel.addMouseMotionListener(gsPanel);
//        gsPanel.addFocusListener(gsPanel);
//        gsPanel.setFocusable(true);
//        gsPanel.requestFocusInWindow();
//        gsPanel.setIgnoreRepaint(true);
//
//        // disable Swing's double buffering. we don't need it since we have our own offscreen image (offImage)
//        // this means we get a slight performance gain
//        // ("You may find that your numbers for direct rendering far exceed those for double-buffering" from https://docs.oracle.com/javase/tutorial/extra/fullscreen/doublebuf.html)
//        // for zero graphical loss.
//        gsPanel.setDoubleBuffered(false);

//        Timer timer = new Timer(46, ae->gsPanel.repaint());

//        timer.start();
//        return gsPanel;

            return new GameSparker();
        }

        private static void PreloadGame()
        {
//        if (System.getProperty("java.vendor").ToLower().Contains("apple"))
//        {
//            applejava = true;
//        }

            new Medium();
            new Trackers();
            new CheckPoints();
            _carContos = new ContO[CarRads.Length];
            _contos = new ContO[StageRads.Length];
            CarDefine.Create(_contos);
            XTGraphics.Create();

            new Record();
            Mads = new Mad[8];
            for (var i = 0; i < 8; i++)
            {
                Mads[i] = new Mad(null, i);
                U[i] = new Control();
            }

            _date = new Date();
            _l1 = _date.GetTime();
            _f2 = 30.0F;
            _bool3 = false;
            _i4 = 530;
            _i5 = 0;
            _recordtime = 0;
            _clicknowtime = 0;
            _finishrecording = 0;
            _wastedpoint = 0;
            _flashingscreen = false;
        }

        //@Override
        private static void LoadGame()
        {
//        gsPanel.requestFocus();
            try
            {
                _sizebar = XTGraphics.GetImage("data/baseimages/sizebar.gif");
                _blb = XTGraphics.GetImage("data/baseimages/b.gif");
                _fulls = XTGraphics.GetImage("data/baseimages/fullscreen.gif");
//            chkbx[0] = xtGraphics.getImage("data/baseimages/checkbox1.gif");
//            chkbx[1] = xtGraphics.getImage("data/baseimages/checkbox2.gif");
//            carmaker[0] = xtGraphics.getImage("data/baseimages/carmaker1.gif");
//            carmaker[1] = xtGraphics.getImage("data/baseimages/carmaker2.gif");
                Stagemaker[0] = XTGraphics.GetImage("data/baseimages/stagemaker1.gif");
                Stagemaker[1] = XTGraphics.GetImage("data/baseimages/stagemaker2.gif");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            XTGraphics.Loaddata();

            Loadbase();

            _stageContos = new ContO[10000];

            _f = 47.0F;
            Readcookies(_contos);
//        xtGraphics.testdrive = Madness.testdrive;
//        if (xtGraphics.testdrive != 0)
//            if (xtGraphics.testdrive <= 2)
//            {
//                xtGraphics.sc[0] = CarDefine.loadcar(Madness.testcar, 16);
//                if (xtGraphics.sc[0] != -1)
//                {
//                    xtGraphics.fase = -9;
//                }
//                else
//                {
//                    Madness.testcar = "Failx12";
//                    Madness.carmaker();
//                }
//            }
//            else
//            {
//                CheckPoints.name = Madness.testcar;
//                xtGraphics.fase = -9;
//            }
            XTPart2.Stoploading();
//        gsPanel.requestFocus();
            if (XTGraphics.Testdrive == 0 && XTGraphics.Firstime)
            {
                Setupini();
            }
            GC.Collect();

            _gameLoaded = true;
        }

        public static void GameTick()
        {
            _date = new Date();
            _date.GetTime();
            if (XTGraphics.Fase == 1111)
            {
                XTGraphics.Loading();
                if (_gameLoaded)
                {
                    XTGraphics.Fase = 111;
                }
            }
            if (XTGraphics.Fase == 111)
            {
                if (Mouses == 1)
                {
                    _clicknowtime = 800;
                }
                if (_clicknowtime < 800)
                {
                    XTGraphics.Clicknow();
                    _clicknowtime++;
                }
                else
                {
                    _clicknowtime = 0;
                    if (!_exwist)
                    {
                        XTGraphics.Fase = 9;
                    }
                    Mouses = 0;
                    _lostfcs = false;
                }
            }
            if (XTGraphics.Fase == 9)
            {
                if (_clicknowtime < 76)
                {
                    XTPart2.Rad(_clicknowtime);
                    Catchlink();
                    if (Mouses == 2)
                    {
                        Mouses = 0;
                    }
                    if (Mouses == 1)
                    {
                        Mouses = 2;
                    }
                    _clicknowtime++;
                    if (U[0].Enter)
                    {
                        U[0].Enter = false;
                        _clicknowtime = 76;
                    }
                }
                else
                {
                    _clicknowtime = 0;
                    XTGraphics.Fase = 10;
                    Mouses = 0;
                    U[0].Falseo(0);
                }
            }

            if (XTGraphics.Fase == -9)
            {
                if (XTGraphics.Loadedt)
                {
                    XTPart2.Mainbg(-101);
                    G.SetColor(new Color(0, 0, 0));
                    G.FillRect(0, 0, 800, 450);
                    //repaint();
                    XTGraphics.Strack.Unload();
                    XTGraphics.Strack = null;
                    XTGraphics.Flexpix = null;
                    XTImages.Images.Fleximg = null;
                    GC.Collect();
                    XTGraphics.Loadedt = false;
                }
                if (_clicknowtime < 2)
                {
                    XTPart2.Mainbg(-101);
                    G.SetColor(new Color(0, 0, 0));
                    G.FillRect(65, 25, 670, 400);
                    _clicknowtime++;
                }
                else
                {
                    Checkmemory();
                    XTGraphics.Inishcarselect(_carContos);
                    _clicknowtime = 0;
                    XTGraphics.Fase = 7;
                    _mvect = 50;
                    Mouses = 0;
                }
            }
            if (XTGraphics.Fase == 8)
            {
                XTGraphics.Credits(U[0], _xm, _ym, Mouses);
                XTGraphics.Ctachm(_xm, _ym, Mouses, U[0]);
                if (XTGraphics.Flipo <= 100)
                {
                    Catchlink();
                }
                if (Mouses == 2)
                {
                    Mouses = 0;
                }
                if (Mouses == 1)
                {
                    Mouses = 2;
                }
            }
            if (XTGraphics.Fase == 10)
            {
                _mvect = 100;
                XTPart2.Maini(U[0]);
                XTGraphics.Ctachm(_xm, _ym, Mouses, U[0]);
                if (Mouses == 2)
                {
                    Mouses = 0;
                }
                if (Mouses == 1)
                {
                    Mouses = 2;
                }
            }
            if (XTGraphics.Fase == 103)
            {
                _mvect = 100;
                if (XTGraphics.Loadedt)
                {
                    G.SetColor(new Color(0, 0, 0));
                    G.FillRect(0, 0, 800, 450);
                    //repaint();
                    Checkmemory();
                    XTGraphics.Strack.Unload();
                    XTGraphics.Strack = null;
                    XTGraphics.Flexpix = null;
                    XTImages.Images.Fleximg = null;
                    GC.Collect();
                    XTGraphics.Loadedt = false;
                }
//            if (xtGraphics.testdrive == 1 || xtGraphics.testdrive == 2)
//            {
//                Madness.carmaker();
//            }
//            if (xtGraphics.testdrive == 3 || xtGraphics.testdrive == 4)
//            {
//                Madness.stagemaker();
//            }
                XTPart2.Maini(U[0]);
                XTGraphics.Fase = 10;
                if (Mouses == 2)
                {
                    Mouses = 0;
                }
                if (Mouses == 1)
                {
                    Mouses = 2;
                }
            }
            if (XTGraphics.Fase == 102)
            {
                _mvect = 100;
                if (XTGraphics.Loadedt)
                {
                    G.SetColor(new Color(0, 0, 0));
                    G.FillRect(0, 0, 800, 450);
                    //repaint();
                    Checkmemory();
                    XTGraphics.Strack.Unload();
                    XTGraphics.Strack = null;
                    XTGraphics.Flexpix = null;
                    XTImages.Images.Fleximg = null;
                    GC.Collect();
                    XTGraphics.Loadedt = false;
                }
//            if (xtGraphics.testdrive == 1 || xtGraphics.testdrive == 2)
//            {
//                Madness.carmaker();
//            }
//            if (xtGraphics.testdrive == 3 || xtGraphics.testdrive == 4)
//            {
//                Madness.stagemaker();
//            }
                XTPart2.Maini2();
                XTGraphics.Ctachm(_xm, _ym, Mouses, U[0]);
                if (Mouses == 2)
                {
                    Mouses = 0;
                }
                if (Mouses == 1)
                {
                    Mouses = 2;
                }
            }
            if (XTGraphics.Fase == -22)
            {
//            CheckPoints.name = Madness.testcar;
                CheckPoints.Stage = -1;
                Loadstage();
//            if (CheckPoints.stage == -3)
//            {
//                Madness.testcar = "Failx12";
//                Madness.stagemaker();
//            }
            }
            if (XTGraphics.Fase == 11)
            {
                XTGraphics.Inst(U[0]);
                XTGraphics.Ctachm(_xm, _ym, Mouses, U[0]);
                if (Mouses == 2)
                {
                    Mouses = 0;
                }
                if (Mouses == 1)
                {
                    Mouses = 2;
                }
            }
            if (XTGraphics.Fase == -5)
            {
                _mvect = 100;
                XTGraphics.Finish(_carContos, U[0], _xm, _ym, _moused); // TODO carContos or contos here?
                XTGraphics.Ctachm(_xm, _ym, Mouses, U[0]);
                if (Mouses == 2)
                {
                    Mouses = 0;
                }
                if (Mouses == 1)
                {
                    Mouses = 2;
                }
            }
            if (XTGraphics.Fase == 7)
            {
                XTGraphics.Carselect(U[0], _carContos, _xm, _ym, _moused);
                XTGraphics.Ctachm(_xm, _ym, Mouses, U[0]);
                if (Mouses == 2)
                {
                    Mouses = 0;
                }
                if (Mouses == 1)
                {
                    Mouses = 2;
                }
                Drawms();
            }
            if (XTGraphics.Fase == 6)
            {
                XTPart2.Musicomp(CheckPoints.Stage, U[0]);
                XTGraphics.Ctachm(_xm, _ym, Mouses, U[0]);
                if (Mouses == 2)
                {
                    Mouses = 0;
                }
                if (Mouses == 1)
                {
                    Mouses = 2;
                }
            }
            if (XTGraphics.Fase == 5)
            {
                _mvect = 100;
                XTGraphics.Loadmusic(CheckPoints.Stage, CheckPoints.Trackname, CheckPoints.Trackvol);
            }
            if (XTGraphics.Fase == 4)
            {
                XTGraphics.Cantgo(U[0]);
                XTGraphics.Ctachm(_xm, _ym, Mouses, U[0]);
                if (Mouses == 2)
                {
                    Mouses = 0;
                }
                if (Mouses == 1)
                {
                    Mouses = 2;
                }
            }
            if (XTGraphics.Fase == 3)
            {
                G.SetColor(new Color(0, 0, 0));
                G.FillRect(65, 25, 670, 400);
                //repaint();
                XTGraphics.Inishstageselect();
            }
            if (XTGraphics.Fase == 2)
            {
                _mvect = 100;
                XTGraphics.Loadingstage(true);
                CheckPoints.Nfix = 0;
                CheckPoints.Notb = false;
                Loadstage();
                U[0].Falseo(0);
//            udpmistro.freg = 0.0F;
                _mvect = 20;
            }
            if (XTGraphics.Fase == 1)
            {
                XTPart2.Trackbgf(false);
//            rd.setRenderingHint(RenderingHints.KEY_ANTIALIASING, RenderingHints.VALUE_ANTIALIAS_OFF);
                if (CheckPoints.Stage != -3)
                {
                    Medium.Aroundtrack();
                    if (Medium.Hit == 5000 && _mvect < 40)
                    {
                        _mvect++;
                    }
                    var ai = new DistHolder[_notb];
                    for (var k7 = XTGraphics.Nplayers; k7 < _notb; k7++)
                    {
                        ai[k7] = new DistHolder(k7, _stageContos[k7].Dist);
                    }

                    ArrayExt.Sort(ai, ContoComparator2);

                    for (var i14 = 0; i14 < _notb; i14++)
                    {
                        _stageContos[ai[i14].Id].D();
                    }
                }
                if (!Openm)
                {
                    XTGraphics.Ctachm(_xm, _ym, Mouses, U[0]);
                }
                if (Mouses == 2)
                {
                    Mouses = 0;
                }
                if (Mouses == 1)
                {
                    Mouses = 2;
                }
                XTPart2.Stageselect(U[0], _xm, _ym, _moused);
                Drawms();
            }
            if (XTGraphics.Fase == 0)
            {
                for (var player = 0; player < XTGraphics.Nplayers; player++)
                {
                    if (Mads[player].Newcar)
                    {
                        var i34 = _stageContos[player].Xz;
                        var i35 = _stageContos[player].Xy;
                        var i36 = _stageContos[player].Zy;
                        _stageContos[player] = new ContO(_carContos[Mads[player].Cn], _stageContos[player].X,
                            _stageContos[player].Y, _stageContos[player].Z, 0)
                        {
                            Xz = i34,
                            Xy = i35,
                            Zy = i36
                        };
                        Mads[player].Newcar = false;
                    }
                }

                Medium.D();

                var ai = new DistHolder[_nob];
                for (var k7 = 0; k7 < _nob; k7++)
                {
                    ai[k7] = new DistHolder(k7, _stageContos[k7].Dist);
                }

                ArrayExt.Sort(ai, ContoComparator2);

                for (var i14 = 0; i14 < _nob; i14++)
                {
                    _stageContos[ai[i14].Id].D();
                }

                if (XTGraphics.Starcnt == 0)
                {
                    for (var k = 0; k < XTGraphics.Nplayers; k++)
                    {
                        for (var m = 0; m < XTGraphics.Nplayers; m++)
                        {
                            if (m != k)
                            {
                                Mads[k].Colide(_stageContos[k], Mads[m], _stageContos[m]);
                            }
                        }
                    }
                    for (var k = 0; k < XTGraphics.Nplayers; k++)
                    {
                        Mads[k].Drive(U[k], _stageContos[k]);
                    }
                    for (var k = 0; k < XTGraphics.Nplayers; k++)
                    {
                        Record.Rec(_stageContos[k], k, Mads[k].Squash, Mads[k].Lastcolido, Mads[k].Cntdest, 0);
                    }
                    CheckPoints.Checkstat(Mads, _stageContos, XTGraphics.Nplayers, XTGraphics.Im, 0);
                    for (var k = 1; k < XTGraphics.Nplayers; k++)
                    {
                        U[k].Preform(Mads[k], _stageContos[k]);
                    }
                }
                else
                {
                    if (XTGraphics.Starcnt == 130)
                    {
                        Medium.Adv = 1900;
                        Medium.Zy = 40;
                        Medium.Vxz = 70;
                        G.SetColor(new Color(255, 255, 255));
                        G.FillRect(0, 0, 800, 450);
                    }
                    if (XTGraphics.Starcnt != 0)
                    {
                        XTGraphics.Starcnt--;
                    }
                }
                if (XTGraphics.Starcnt < 38)
                {
                    if (_view == 0)
                    {
                        Medium.Follow(_stageContos[0], Mads[0].Cxz, U[0].Lookback);
                        XTPart2.Stat(Mads[0], _stageContos[0], U[0], true);
                        if (Mads[0].Outshakedam > 0)
                        {
                            _shaka = Mads[0].Outshakedam / 20;
                            if (_shaka > 25)
                            {
                                _shaka = 25;
                            }
                        }
                        _mvect = 65 + Math.Abs(_lmxz - Medium.Xz) / 5 * 100;
                        if (_mvect > 90)
                        {
                            _mvect = 90;
                        }
                        _lmxz = Medium.Xz;
                    }
                    if (_view == 1)
                    {
                        Medium.Around(_stageContos[0], false);
                        XTPart2.Stat(Mads[0], _stageContos[0], U[0], false);
                        _mvect = 80;
                    }
                    if (_view == 2)
                    {
                        Medium.Watch(_stageContos[0], Mads[0].Mxz);
                        XTPart2.Stat(Mads[0], _stageContos[0], U[0], false);
                        _mvect = 65 + Math.Abs(_lmxz - Medium.Xz) / 5 * 100;
                        if (_mvect > 90)
                        {
                            _mvect = 90;
                        }
                        _lmxz = Medium.Xz;
                    }
                    if (Mouses == 1)
                    {
                        U[0].Enter = true;
                        Mouses = 0;
                    }
                }
                else
                {
                    var k = 3;
                    if (XTGraphics.Nplayers == 1)
                    {
                        k = 0;
                    }
                    Medium.Around(_stageContos[k], true);
                    _mvect = 80;
                    if (U[0].Enter || U[0].Handb)
                    {
                        XTGraphics.Starcnt = 38;
                        U[0].Enter = false;
                        U[0].Handb = false;
                    }
                    if (XTGraphics.Starcnt == 38)
                    {
                        Mouses = 0;
                        Medium.Vert = false;
                        Medium.Adv = 900;
                        Medium.Vxz = 180;
                        CheckPoints.Checkstat(Mads, _stageContos, XTGraphics.Nplayers, XTGraphics.Im, 0);
                        Medium.Follow(_stageContos[0], Mads[0].Cxz, 0);
                        XTPart2.Stat(Mads[0], _stageContos[0], U[0], true);
//                    G.SetColor(new Color(255, 255, 255));
//                    G.FillRect(0, 0, 800, 450);
                    }
                }
            }
            if (XTGraphics.Fase == -1)
            {
                if (_recordtime == 0)
                {
                    for (var k = 0; k < XTGraphics.Nplayers; k++)
                    {
                        Record.Ocar[k] = new ContO(_stageContos[k], 0, 0, 0, 0);
                        _stageContos[k] = new ContO(Record.Car[0, k], 0, 0, 0, 0);
                    }
                }
                Medium.D();
                var j = 0;
                var ais = new int[10000];
                for (var k = 0; k < _nob; k++)
                {
                    if (_stageContos[k].Dist != 0)
                    {
                        ais[j] = k;
                        j++;
                    }
                    else
                    {
                        _stageContos[k].D();
                    }
                }

                var is2 = new int[j];
                for (var k = 0; k < j; k++)
                {
                    is2[k] = 0;
                }
                for (var k = 0; k < j; k++)
                {
                    for (var m = k + 1; m < j; m++)
                    {
                        if (_stageContos[ais[k]].Dist != _stageContos[ais[m]].Dist)
                        {
                            if (_stageContos[ais[k]].Dist < _stageContos[ais[m]].Dist)
                            {
                                is2[k]++;
                            }
                            else
                            {
                                is2[m]++;
                            }
                        }
                        else if (m > k)
                        {
                            is2[k]++;
                        }
                        else
                        {
                            is2[m]++;
                        }
                    }
                }
                for (var k = 0; k < j; k++)
                {
                    for (var m = 0; m < j; m++)
                    {
                        if (is2[m] == k)
                        {
                            _stageContos[ais[m]].D();
                        }
                    }
                }
                if (U[0].Enter || U[0].Handb || Mouses == 1)
                {
                    _recordtime = 299;
                    U[0].Enter = false;
                    U[0].Handb = false;
                    Mouses = 0;
                }
                for (var k = 0; k < XTGraphics.Nplayers; k++)
                {
                    if (Record.Fix[k] == _recordtime)
                    {
                        if (_stageContos[k].Dist == 0)
                        {
                            _stageContos[k].Fcnt = 8;
                        }
                        else
                        {
                            _stageContos[k].Fix = true;
                        }
                    }

                    if (_stageContos[k].Fcnt == 7 || _stageContos[k].Fcnt == 8)
                    {
                        _stageContos[k] = new ContO(_contos[Mads[k].Cn], 0, 0, 0, 0);
                        Record.Cntdest[k] = 0;
                    }
                    if (_recordtime == 299)
                    {
                        _stageContos[k] = new ContO(Record.Ocar[k], 0, 0, 0, 0);
                    }
                    Record.Play(_stageContos[k], Mads[k], k, _recordtime);
                }
                if (++_recordtime == 300)
                {
                    _recordtime = 0;
                    XTGraphics.Fase = -6;
                }
                else
                {
                    XTPart2.Replyn();
                }
                Medium.Around(_stageContos[0], false);
            }
            if (XTGraphics.Fase == -2)
            {
                if (XTGraphics.Multion >= 2)
                {
                    Record.Hcaught = false;
                }
                U[0].Falseo(3);
                if (Record.Hcaught && Record.Wasted == 0 && Record.Whenwasted != 229 &&
                    (CheckPoints.Stage == 1 || CheckPoints.Stage == 2) && XTGraphics.Looped != 0)
                {
                    Record.Hcaught = false;
                }
                if (Record.Hcaught)
                {
                    G.SetColor(new Color(0, 0, 0));
                    G.FillRect(0, 0, 800, 450);
                    //repaint();
                }
                if (Record.Hcaught)
                {
                    Medium.Vert = Medium.Random() <= 0.45;
                    Medium.Adv = (int) (900.0F * Medium.Random());
                    Medium.Vxz = (int) (360.0F * Medium.Random());
                    _recordtime = 0;
                    XTGraphics.Fase = -3;
                    _clicknowtime = 0;
                    _finishrecording = 0;
                }
                else
                {
                    _recordtime = -2;
                    XTGraphics.Fase = -4;
                }
            }
            if (XTGraphics.Fase == -3)
            {
                if (_recordtime == 0)
                {
                    if (Record.Wasted == 0)
                    {
                        if (Record.Whenwasted == 229)
                        {
                            _wastedpoint = 67;
                            Medium.Vxz += 90;
                        }
                        else
                        {
                            _wastedpoint = (int) (Medium.Random() * 4.0F);
                            if (_wastedpoint == 1 || _wastedpoint == 3)
                            {
                                _wastedpoint = 69;
                            }
                            if (_wastedpoint == 2 || _wastedpoint == 4)
                            {
                                _wastedpoint = 30;
                            }
                        }
                    }
                    else if (Record.Closefinish != 0 && _finishrecording != 0)
                    {
                        Medium.Vxz += 90;
                    }
                    for (var m = 0; m < XTGraphics.Nplayers; m++)
                    {
                        _stageContos[m] = new ContO(Record.Starcar[m], 0, 0, 0, 0);
                    }
                }
                Medium.D();
                var j = 0;
                var ais = new int[10000];
                for (var k = 0; k < _nob; k++)
                {
                    if (_stageContos[k].Dist != 0)
                    {
                        ais[j] = k;
                        j++;
                    }
                    else
                    {
                        _stageContos[k].D();
                    }
                }

                var is2 = new int[j];
                for (var k = 0; k < j; k++)
                {
                    is2[k] = 0;
                }
                for (var k = 0; k < j; k++)
                {
                    for (var m = k + 1; m < j; m++)
                    {
                        if (_stageContos[ais[
                                k]].Dist != _stageContos[ais[m]].Dist)
                        {
                            if (_stageContos[ais[k]].Dist < _stageContos[ais[m]].Dist)
                            {
                                is2[k]++;
                            }
                            else
                            {
                                is2[m]++;
                            }
                        }
                        else if (m > k)
                        {
                            is2[k]++;
                        }
                        else
                        {
                            is2[m]++;
                        }
                    }
                }
                for (var k = 0; k < j; k++)
                {
                    for (var m = 0; m < j; m++)
                    {
                        if (is2[m] == k)
                        {
                            _stageContos[ais[m]].D();
                        }
                    }
                }
                for (var k = 0; k < XTGraphics.Nplayers; k++)
                {
                    if (Record.Hfix[k] == _recordtime)
                    {
                        if (_stageContos[k].Dist == 0)
                        {
                            _stageContos[k].Fcnt = 8;
                        }
                        else
                        {
                            _stageContos[k].Fix = true;
                        }
                    }

                    if (_stageContos[k].Fcnt == 7 || _stageContos[k].Fcnt == 8)
                    {
                        _stageContos[k] = new ContO(_contos[Mads[k].Cn], 0, 0, 0, 0);
                        Record.Cntdest[k] = 0;
                    }
                    Record.Playh(_stageContos[k], Mads[k], k, _recordtime, XTGraphics.Im);
                }
                if (_finishrecording == 2 && _recordtime == 299)
                {
                    U[0].Enter = true;
                }
                if (U[0].Enter || U[0].Handb)
                {
                    XTGraphics.Fase = -4;
                    U[0].Enter = false;
                    U[0].Handb = false;
                    _recordtime = -7;
                }
                else
                {
                    XTGraphics.Levelhigh(Record.Wasted, Record.Whenwasted, Record.Closefinish, _recordtime,
                        CheckPoints.Stage);
                    if (_recordtime == 0 || _recordtime == 1 || _recordtime == 2)
                    {
                        G.SetColor(new Color(0, 0, 0));
                        G.FillRect(0, 0, 800, 450);
                    }
                    if (Record.Wasted != XTGraphics.Im)
                    {
                        if (Record.Closefinish == 0)
                        {
                            if (_clicknowtime == 9 || _clicknowtime == 11)
                            {
                                G.SetColor(new Color(255, 255, 255));
                                G.FillRect(0, 0, 800, 450);
                            }
                            if (_clicknowtime == 0)
                            {
                                Medium.Around(_stageContos[XTGraphics.Im], false);
                            }
                            if (_clicknowtime > 0 && _clicknowtime < 20)
                            {
                                Medium.Transaround(_stageContos[XTGraphics.Im], _stageContos[Record.Wasted],
                                    _clicknowtime);
                            }
                            if (_clicknowtime == 20)
                            {
                                Medium.Around(_stageContos[Record.Wasted], false);
                            }
                            if (_recordtime > Record.Whenwasted && _clicknowtime != 20)
                            {
                                _clicknowtime++;
                            }
                            if ((_clicknowtime == 0 || _clicknowtime == 20) && ++_recordtime == 300)
                            {
                                _recordtime = 0;
                                _clicknowtime = 0;
                                _finishrecording++;
                            }
                        }
                        else if (Record.Closefinish == 1)
                        {
                            if (_clicknowtime == 0)
                            {
                                Medium.Around(_stageContos[XTGraphics.Im], false);
                            }
                            if (_clicknowtime > 0 && _clicknowtime < 20)
                            {
                                Medium.Transaround(_stageContos[XTGraphics.Im], _stageContos[Record.Wasted],
                                    _clicknowtime);
                            }
                            if (_clicknowtime == 20)
                            {
                                Medium.Around(_stageContos[Record.Wasted], false);
                            }
                            if (_clicknowtime > 20 && _clicknowtime < 40)
                            {
                                Medium.Transaround(_stageContos[Record.Wasted], _stageContos[XTGraphics.Im],
                                    _clicknowtime - 20);
                            }
                            if (_clicknowtime == 40)
                            {
                                Medium.Around(_stageContos[XTGraphics.Im], false);
                            }
                            if (_clicknowtime > 40 && _clicknowtime < 60)
                            {
                                Medium.Transaround(_stageContos[XTGraphics.Im], _stageContos[Record.Wasted],
                                    _clicknowtime - 40);
                            }
                            if (_clicknowtime == 60)
                            {
                                Medium.Around(_stageContos[Record.Wasted], false);
                            }
                            if (_recordtime > 160 && _clicknowtime < 20)
                            {
                                _clicknowtime++;
                            }
                            if (_recordtime > 230 && _clicknowtime < 40)
                            {
                                _clicknowtime++;
                            }
                            if (_recordtime > 280 && _clicknowtime < 60)
                            {
                                _clicknowtime++;
                            }
                            if ((_clicknowtime == 0 || _clicknowtime == 20 || _clicknowtime == 40 ||
                                 _clicknowtime == 60) &&
                                ++_recordtime == 300)
                            {
                                _recordtime = 0;
                                _clicknowtime = 0;
                                _finishrecording++;
                            }
                        }
                        else
                        {
                            if (_clicknowtime == 0)
                            {
                                Medium.Around(_stageContos[XTGraphics.Im], false);
                            }
                            if (_clicknowtime > 0 && _clicknowtime < 20)
                            {
                                Medium.Transaround(_stageContos[XTGraphics.Im], _stageContos[Record.Wasted],
                                    _clicknowtime);
                            }
                            if (_clicknowtime == 20)
                            {
                                Medium.Around(_stageContos[Record.Wasted], false);
                            }
                            if (_clicknowtime > 20 && _clicknowtime < 40)
                            {
                                Medium.Transaround(_stageContos[Record.Wasted], _stageContos[XTGraphics.Im],
                                    _clicknowtime - 20);
                            }
                            if (_clicknowtime == 40)
                            {
                                Medium.Around(_stageContos[XTGraphics.Im], false);
                            }
                            if (_clicknowtime > 40 && _clicknowtime < 60)
                            {
                                Medium.Transaround(_stageContos[XTGraphics.Im], _stageContos[Record.Wasted],
                                    _clicknowtime - 40);
                            }
                            if (_clicknowtime == 60)
                            {
                                Medium.Around(_stageContos[Record.Wasted], false);
                            }
                            if (_clicknowtime > 60 && _clicknowtime < 80)
                            {
                                Medium.Transaround(_stageContos[Record.Wasted], _stageContos[XTGraphics.Im],
                                    _clicknowtime - 60);
                            }
                            if (_clicknowtime == 80)
                            {
                                Medium.Around(_stageContos[XTGraphics.Im], false);
                            }
                            if (_recordtime > 90 && _clicknowtime < 20)
                            {
                                _clicknowtime++;
                            }
                            if (_recordtime > 160 && _clicknowtime < 40)
                            {
                                _clicknowtime++;
                            }
                            if (_recordtime > 230 && _clicknowtime < 60)
                            {
                                _clicknowtime++;
                            }
                            if (_recordtime > 280 && _clicknowtime < 80)
                            {
                                _clicknowtime++;
                            }
                            if ((_clicknowtime == 0 || _clicknowtime == 20 || _clicknowtime == 40 ||
                                 _clicknowtime == 60 ||
                                 _clicknowtime == 80) && ++_recordtime == 300)
                            {
                                _recordtime = 0;
                                _clicknowtime = 0;
                                _finishrecording++;
                            }
                        }
                    }
                    else
                    {
                        if (_wastedpoint == 67 && (_clicknowtime == 3 || _clicknowtime == 31 || _clicknowtime == 66))
                        {
                            G.SetColor(new Color(255, 255, 255));
                            G.FillRect(0, 0, 800, 450);
                        }
                        if (_wastedpoint == 69 && (_clicknowtime == 3 || _clicknowtime == 5 || _clicknowtime == 31 ||
                                                   _clicknowtime == 33 || _clicknowtime == 66 || _clicknowtime == 68))
                        {
                            G.SetColor(new Color(255, 255, 255));
                            G.FillRect(0, 0, 800, 450);
                        }
                        if (_wastedpoint == 30 && _clicknowtime >= 1 && _clicknowtime < 30)
                        {
                            if (_clicknowtime % (int) (2.0F + Medium.Random() * 3.0F) == 0 && !_flashingscreen)
                            {
                                G.SetColor(new Color(255, 255, 255));
                                G.FillRect(0, 0, 800, 450);
                                _flashingscreen = true;
                            }
                            else
                            {
                                _flashingscreen = false;
                            }
                        }

                        if (_recordtime > Record.Whenwasted && _clicknowtime != _wastedpoint)
                        {
                            _clicknowtime++;
                        }
                        Medium.Around(_stageContos[XTGraphics.Im], false);
                        if ((_clicknowtime == 0 || _clicknowtime == _wastedpoint) && ++_recordtime == 300)
                        {
                            _recordtime = 0;
                            _clicknowtime = 0;
                            _finishrecording++;
                        }
                    }
                }
            }
            if (XTGraphics.Fase == -4)
            {
                if (_recordtime == 0)
                {
                    XTPart2.Sendwin();
                    if (XTGraphics.Winner && XTGraphics.Multion == 0 && XTGraphics.Gmode != 0 &&
                        CheckPoints.Stage != XTGraphics.NTracks && CheckPoints.Stage == XTGraphics.Unlocked)
                    {
                        XTGraphics.Unlocked++;
                        int i = XTGraphics.Sc[0];
                        float[] fs = XTGraphics.Arnp;
                        int gamemode = XTGraphics.Gmode;
                        HansenData.SetCookie(new[]
                        {
                            "lastcar(" + i + ")",
                            "carcolor1(" + (int) (fs[0] * 100.0F) + "," + (int) (fs[1] * 100.0F) + "," + (int) (fs[2] * 100.0F) + ")",
                            "carcolor2(" + (int) (fs[3] * 100.0F) + "," + (int) (fs[4] * 100.0F) + "," + (int) (fs[5] * 100.0F) + ")",
                            "carname(" + CarDefine.Names[XTGraphics.Sc[0]] + ")",
                            "saved(" + i + "," + XTGraphics.Unlocked + ")",
                            "graphics(" + Moto + ")",
                            "volume(" + (int)(Volume*100F) + ")",
                        });
                        XTGraphics.Unlocked--;
                    }
                }
                if (_recordtime <= 0)
                {
                    G.DrawImage(XTImages.Images.Mdness, 289, 30);
                    G.DrawImage(XTImages.Images.Dude[0], 135, 10);
                }
                if (_recordtime >= 0)
                {
                    XTGraphics.Fleximage(null, _recordtime);
                }
                if (++_recordtime == 7)
                {
                    XTGraphics.Fase = -5;
//                rd.setRenderingHint(RenderingHints.KEY_TEXT_ANTIALIASING, RenderingHints.VALUE_TEXT_ANTIALIAS_ON);
//                rd.setRenderingHint(RenderingHints.KEY_ANTIALIASING, RenderingHints.VALUE_ANTIALIAS_ON);
                }
            }
            if (XTGraphics.Fase == -6)
            {
                //repaint();
                SoundClip.StopAll();
                XTPart2.Pauseimage(null);
                XTGraphics.Fase = -7;
                Mouses = 0;
            }
            if (XTGraphics.Fase == -7)
            {
                XTPart2.Pausedgame(U[0]);
                if (_recordtime != 0)
                {
                    _recordtime = 0;
                }
                XTGraphics.Ctachm(_xm, _ym, Mouses, U[0]);
                if (Mouses == 2)
                {
                    Mouses = 0;
                }
                if (Mouses == 1)
                {
                    Mouses = 2;
                }
            }
            if (XTGraphics.Fase == -8)
            {
                XTGraphics.Cantreply();
                if (++_recordtime == 150 || U[0].Enter || U[0].Handb || Mouses == 1)
                {
                    XTGraphics.Fase = -7;
                    Mouses = 0;
                    U[0].Enter = false;
                    U[0].Handb = false;
                }
            }
            if (_lostfcs && XTGraphics.Fase == 7001)
            {
                if (_fcscnt == 0)
                {
//                if (u[0].chatup == 0)
//                {
//                    gsPanel.requestFocus();
//                }
                    _fcscnt = 10;
                }
                else
                {
                    _fcscnt--;
                }
            }

            if (XTGraphics.Im > -1 && XTGraphics.Im < 8)
            {
                var j = 0;
                if (XTGraphics.Multion == 2 || XTGraphics.Multion == 3)
                {
                    j = XTGraphics.Im;
                    U[j].Mutem = U[0].Mutem;
                    U[j].Mutes = U[0].Mutes;
                }
                if (XTGraphics.Fase == 0)
                {
                    const int i = 0;
                    XTPart2.Playsounds(i, Mads[i], U[i], _stageContos[0], _stageContos[i]);
//                    for (var i = 0; i < XTGraphics.Nplayers; i++)
//                    {
//                        XTPart2.Playsounds(i, Mads[i], U[i], _stageContos[0], _stageContos[i]);
//                    }
                }
            }
            _date = new Date();
            var l = _date.GetTime();

            //TODO
            if (XTGraphics.Fase == 0 || XTGraphics.Fase == -1 || XTGraphics.Fase == -3 || XTGraphics.Fase == 7001)
            {
                if (!_bool3)
                {
                    _f2 = _f;
                    if (_f2 < 30.0F)
                    {
                        _f2 = 30.0F;
                    }
                    _bool3 = true;
                    _i5 = 0;
                }
//            if (i5 == 10)
//            {
//                float f = (i4 + udpmistro.freg - (l - l1)) / 20.0F;
//                if (f > 40.0F)
//                {
//                    f = 40.0F;
//                }
//                if (f < -40.0F)
//                {
//                    f = -40.0F;
//                }
//                f2 += f;
//                if (f2 < 5.0F)
//                {
//                    f2 = 5.0F;
//                }
//                Medium.adjstfade(f2, f, xtGraphics.starcnt, gsPanel);
//                l1 = l;
//                i5 = 0;
//            }
//            else
//            {
//                i5++;
//            }
            }
            else
            {
                if (_bool3)
                {
                    _f = _f2;
                    _bool3 = false;
                    _i5 = 0;
                }
                if (_i5 == 10)
                {
                    if (l - _l1 < 400L)
                    {
                        _f2 += 3.5f;
                    }
                    else
                    {
                        _f2 -= 3.5f;
                        if (_f2 < 5.0F)
                        {
                            _f2 = 5.0F;
                        }
                    }
                    _l1 = l;
                    _i5 = 0;
                }
                else
                {
                    _i5++;
                }
            }
            if (_exwist)
            {
                Trash();
            }
        }

        public static void Setloggedcookie()
        {
            // TODO
        }

        private static void Setupini()
        {
            // TODO
        }

//    private static void sizescreen(int x, int y) {
//        if (x > gsPanel.getWidth() / 2 - 230 && x < gsPanel.getWidth() / 2 - 68 && y > 21 && y < 39 || onbar)
//        {
//            reqmult = (x - (gsPanel.getWidth() / 2 - 222)) / 141.0F;
//            if (reqmult < 0.1)
//            {
//                reqmult = 0.0F;
//            }
//            if (reqmult > 1.0F)
//            {
//                reqmult = 1.0F;
//            }
//            onbar = true;
//            showsize = 100;
//        }
//    }

        public void KeyPressed(Keys key)
        {
            if (!_exwist)
            {
                //115 114 99
                if (key == Keys.Up)
                {
                    U[0].Up = true;
                }
                if (key == Keys.Down)
                {
                    U[0].Down = true;
                }
                if (key == Keys.Right)
                {
                    U[0].Right = true;
                }
                if (key == Keys.Left)
                {
                    U[0].Left = true;
                }
                if (key == Keys.Space)
                {
                    U[0].Handb = true;
                }
                if (key == Keys.Enter)
                {
                    U[0].Enter = true;
                }
                if (key == Keys.Z)
                {
                    U[0].Lookback = -1;
                }
                if (key == Keys.X)
                {
                    U[0].Lookback = 1;
                }
                if (key == Keys.M)
                {
                    U[0].Mutem = !U[0].Mutem;
                }

                if (key == Keys.N)
                {
                    U[0].Mutes = !U[0].Mutes;
                }

                if (key == Keys.A)
                {
                    U[0].Arrace = !U[0].Arrace;
                }

                if (key == Keys.S)
                {
                    U[0].Radar = !U[0].Radar;
                }

                if (key == Keys.V)
                {
                    _view++;
                    if (_view == 3)
                    {
                        _view = 0;
                    }
                }
            }
        }

        public void KeyReleased(Keys key)
        {
            if (!_exwist)
            {
                if (U[0].Multion < 2)
                {
                    if (key == Keys.Up)
                    {
                        U[0].Up = false;
                    }
                    if (key == Keys.Down)
                    {
                        U[0].Down = false;
                    }
                    if (key == Keys.Right)
                    {
                        U[0].Right = false;
                    }
                    if (key == Keys.Left)
                    {
                        U[0].Left = false;
                    }
                    if (key == Keys.Space)
                    {
                        U[0].Handb = false;
                    }
                }
                if (key == Keys.Escape)
                {
                    U[0].Exit = false;
//                if (Madness.fullscreen)
//                {
//                    Madness.exitfullscreen();
//                }
                }
                if (key == Keys.X || key == Keys.Z)
                {
                    U[0].Lookback = 0;
                }
            }
        }

        public void MouseDragged(int x, int y)
        {
            if (!_exwist && !_lostfcs)
            {
                _xm = (int) ((x - _apx) / _apmult);
                _ym = (int) ((y - _apy) / _apmult);
            }
        }

        public void MouseMoved(int x, int y)
        {
            if (!_exwist && !_lostfcs)
            {
                _xm = (int) ((x - _apx) / _apmult);
                _ym = (int) ((y - _apy) / _apmult);
            }
        }

        public void MousePressed(int x, int y)
        {
            if (!_exwist)
            {
                if (Mouses == 0)
                {
                    _xm = (int) ((x - _apx) / _apmult);
                    _ym = (int) ((y - _apy) / _apmult);
                    Mouses = 1;
                }
                _moused = true;
            }
//        if (!Madness.fullscreen)
//        {
//            sizescreen(x, y);
//        }
        }

        public void MouseReleased(int x, int y)
        {
            if (!_exwist)
            {
                if (Mouses == 11)
                {
                    _xm = (int) ((x - _apx) / _apmult);
                    _ym = (int) ((y - _apy) / _apmult);
                    Mouses = -1;
                }
                _moused = false;
            }
        }

        public void FocusGained()
        {
            if (!_exwist && _lostfcs)
            {
                _lostfcs = false;
            }
        }

        public void FocusLost()
        {
            if (_exwist || _lostfcs)
            {
                return;
            }

            _lostfcs = true;
            _fcscnt = 10;
        }

        public static void SetAllVolumes(float vol)
        {
            Volume = vol;
            XTGraphics.Strack?.SetVolume(vol);
            SoundClip.SetAllVolumes(vol);
        }
    }
}