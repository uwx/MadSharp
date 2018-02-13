using System;
using System.IO;
using MadGame;
using boolean = System.Boolean;
using static Cum.XTImages.Images;
using static Cum.XTPart2;

namespace Cum
{
    class XTGraphics
    {
        internal static int[] Cntwis = new int[8];
        internal static bool[] Grrd = new bool[8];
        internal static bool[] Aird = new bool[8];
        internal static int[] Stopcnt = new int[8];
        internal static int[] Bfcrash = new int[8];
        internal static int[] Bfsc1 = new int[8];
        internal static int[] Bfsc2 = new int[8];
        internal static int[] Bfscrape = new int[8];
        internal static int[] Bfskid = new int[8];
        internal static int[] Pwait = {7, 7, 7, 7, 7, 7, 7, 7};
        internal static bool[] Pwastd = new bool[8];

        /**
         * Serialization UID
         */
        internal static readonly long SerialVersionUid = 1254986552635023147L;

        /**
         * How many stages you have
         */
        internal static readonly int NTracks = 32;

        /**
         * How many cars you have
         */
        internal static readonly int NCars = 16;

        internal static int Acexp = 0;

        /**
         * Stunt adjectives
         */
        internal static readonly string[,] Adj =
        {
            {
                "Cool", "Alright", "Nice"
            },
            {
                "Wicked", "Amazing", "Super"
            },
            {
                "Awesome", "Ripping", "Radical"
            },
            {
                "What the...?", "You're a super star!!!!", "Who are you again...?"
            },
            {
                "surf style", "off the lip", "bounce back"
            }
        };

        /**
         * Used for text flicker effect
         */
        internal static bool Aflk;

        internal static readonly SoundClip[] Air = new SoundClip[6];

        /**
         * The HSB values of every vehicle ain a race, once for the first color and once for the second
         */
        internal static readonly float[,] Allrnp = new float[8, 6];

        /**
         * If {@code != -1}, locks the arrow to that car ID.
         */
        internal static int Alocked = -1;

        /**
         * Arrow angle
         */
        internal static int Ana;

        /**
         * The player car's HSB values, once for the first color and once for the second
         */
        internal static readonly float[] Arnp =
        {
            0.5F, 0.0F, 0.0F, 1.0F, 0.5F, 0.0F
        };

        /**
         * If {@code true}, the arrow ais pointing at cars
         */
        internal static bool Arrace = false;

        internal static string Asay = "";

        internal static int Auscnt = 45;

        /**
         * Auto-login
         */
        internal static bool Autolog = false;

        /**
         * Temporarily stores player's username
         */
        internal static string Backlog = "";

        /**
         * If true, disables some visual effects for Mac OS compatibility
         */
        internal static bool Badmac;

        internal static int Beststunt = 0;
        internal static float Bgf = 0.0F;

        internal static readonly int[] Bgmy =
        {
            0, -400
        };

        internal static bool Bgup = false;
        internal static SoundClip Carfixed;
        internal static int Cfase;

        internal static SoundClip Checkpoint;

        /**
         * Player's clan ain multiplayer games
         */
        internal static string Clan = "";

        internal static bool Clanchat = false;

        /**
         * If non-zero, the player ais ain a clan/war game (racing or wasting)
         */
        internal static int Clangame = 0;

        internal static string Clankey = "";

        /**
         * Current amount of cleared checkpoints
         */
        internal static int Clear = 0;

        internal static readonly string[,] Cnames =
        {
            {
                "", "", "", "", "", "", "Game Chat  "
            },
            {
                "", "", "", "", "", "", "Your Clan's Chat  "
            }
        };

        internal static int Cntan = 0;

        internal static readonly int[] Cntchatp =
        {
            0, 0
        };

        internal static int Cntflock = 0;
        internal static int Cntovn = 0;
        internal static readonly int Cntptrys = 5;
        internal static readonly SoundClip[] Crash = new SoundClip[3];
        internal static bool Crashup = false;
        internal static int Crshturn;

        internal static readonly int[] Dcrashes =
        {
            0, 0, 0, 0, 0, 0, 0, 0
        };

        /**
         * The player's ping, ain Dominion, Ghostrider and Avenger
         */
        static readonly int[] Delays =
        {
            600, 600, 600
        };

        internal static readonly int[] Dested =
        {
            0, 0, 0, 0, 0, 0, 0, 0
        };

        internal static int Discon = 0;
        internal static int Dmcnt;

        internal static bool Dmflk;

        /**
         * Amount of KB downloaded (loading screen)
         */
        internal static int Dnload;

        internal static readonly int Dropf = 0;
        internal static int Dskflg = 0;
        internal static int Dudo;
        internal static int Duds;
        internal static readonly SoundClip[] Dustskid = new SoundClip[3];
        internal static readonly SoundClip[,] Engs = new SoundClip[5, 5];

        internal static int Exitm = 0;

        /**
         * Exclamation marks for stunts
         */
        internal static readonly string[] Exlm =
        {
            "!", "!!", "!!!"
        };

        internal static int Fase = 1111;
        internal static int Fastestlap = 0;
        internal static SoundClip Firewasted;
        internal static bool Firstime = true;
        internal static int Flang = 0;
        internal static int Flatr = 0;
        internal static int Flatrstart;
        internal static int[] Flexpix;
        internal static int Flipo;
        internal static bool Flk;
        internal static int Flkat = 0;

        internal static readonly int[] Floater =
        {
            0, 0
        };

        internal static int Flyr = 0;
        internal static int Flyrdest = 0;
        internal static int Forstart = 0;
        internal static FontMetrics Ftm;
        internal static string Gaclan = "";
        internal static int Gameport = 7001;
        internal static int Gatey = 300;
        internal static int Gmode;
        internal static SoundClip Go;
        internal static int Gocnt = 0;
        internal static bool Gotlog = false;
        internal static int Gxdu = 0;
        internal static int Gydu = 0;
        internal static int Holdcnt = 0;
        internal static bool Holdit = false;
        internal static int Hours = 8;
        internal static int Im;
        internal static RadicalMusic Intertrack;
        internal static readonly bool[] Isbot = new bool[8];
        internal static bool Justwon1 = false;
        internal static bool Justwon2;
        internal static int Kbload;
        internal static int Lalocked = -1;
        internal static bool Lan = false;
        internal static int Laps = 0;
        internal static int Laptime = 0;
        internal static int Lcarx = 0;
        internal static int Lcarz = 0;

        internal static readonly string[] Lcmsg =
        {
            "", ""
        };

        internal static int Lcn = 0;
        internal static int Lfrom;
        internal static int Lmode = 0;
        internal static bool Loadedt;
        internal static string Localserver = "";
        internal static int Lockcnt;
        internal static bool Logged = false;
        internal static string Loop = "";
        internal static int Looped = 1;
        internal static readonly SoundClip[] Lowcrash = new SoundClip[3];
        internal static int Lsc = -1;
        internal static int Lxm = -10;

        internal static int Lym = -10;

        /**
         * Max car select selected car (don't change)
         */
        internal static int Maxsl = NCars - 1;

        internal static int Minsl;
        internal static int Mouson = -1;

        internal static readonly int[] Movepos =
        {
            0, 0
        };

        internal static int Movly = 0;

        internal static readonly int[] Msgflk =
        {
            0, 0
        };

        internal static bool Mtop = false;
        internal static int Muhi = 0;
        internal static int Multion;
        internal static bool Mutem;
        internal static bool Mutes;
        internal static int Ndisco;
        internal static bool Newparts = false;
        internal static int Nextc;
        internal static int Nfmtab;
        internal static int Nfreeplays = 0;
        internal static string Nickey = "";
        internal static string Nickname = "";
        internal static bool Nofull;
        internal static int Nplayers = 7;
        internal static int Oldfase = 0;
        internal static SoundClip One;
        internal static int Onjoin = -1;
        internal static bool Onlock = false;
        internal static int Onmsc = -1;
        internal static int Ontyp;
        internal static int Opselect;
        internal static int Osc = 10;

        internal static readonly int[] Ovh =
        {
            0, 0, 0, 0
        };

        internal static readonly int[] Ovsx =
        {
            0, 0, 0, 0
        };

        internal static readonly int[] Ovw =
        {
            0, 0, 0, 0
        };

        internal static readonly int[] Ovx =
        {
            0, 0, 0, 0
        };

        internal static readonly int[] Ovy =
        {
            0, 0, 0, 0
        };

        internal static int Pback;

        internal static readonly string[] Pclan =
        {
            "", "", "", "", "", "", "", ""
        };

        internal static int Pcontin;
        internal static readonly bool[] Pengs = new bool[5];

        internal static readonly int[] Pgady =
        {
            0, 0, 0, 0, 0, 0, 0, 0, 0
        };

        internal static readonly bool[] Pgas =
        {
            false, false, false, false, false, false, false, false, false
        };

        internal static readonly int[] Pgatx =
        {
            211, 240, 280, 332, 399, 466, 517, 558, 586
        };

        internal static readonly int[] Pgaty =
        {
            193, 213, 226, 237, 244, 239, 228, 214, 196
        };

        internal static int Pin = 60;
        internal static int Playingame = -1;

        internal static readonly string[] Plnames =
        {
            "", "", "", "", "", "", "", ""
        };

        internal static int Pnext;

        internal static readonly int[] Pointc =
        {
            6, 6
        };

        internal static int Posit = 0;
        internal static SoundClip Powerup;
        internal static int Pstar;

        internal static int Pwcnt = 0;
        internal static bool Pwflk = false;
        internal static int Radpx = 212;
        internal static int Ransay = 0;
        internal static bool Remi;
        internal static int Removeds;
        internal static int Runtyp;
        internal static string Say = "";

        internal static readonly int[] Sc =
        {
            0, 0, 0, 0, 0, 0, 0, 0
        };

        internal static int Scm;
        internal static readonly SoundClip[] Scrape = new SoundClip[4];
        internal static int Sendstat = 0;

        internal static readonly string[,] Sentn =
        {
            {
                "", "", "", "", "", "", ""
            },
            {
                "", "", "", "", "", "", ""
            }
        };

        internal static string Server = "multiplayer.needformadness.com";
        internal static string Servername = "Madness";
        internal static int Servport = 7071;
        internal static bool Shaded;
        internal static float Shload;
        internal static bool Showtf;
        internal static int Skflg = 0;
        internal static readonly SoundClip[] Skid = new SoundClip[3];
        internal static bool Skidup = false;

        internal static readonly int[] Smokey = new int[94132];

        /**
         * Stage sound size (completely cosmetic)
         */
        internal static readonly int[] Sndsize =
        {
            39, 128, 23, 58, 106, 140, 81, 135, 38, 141, 106, 76, 56, 116, 92, 208, 70, 80, 152, 102, 27, 65, 52, 30,
            151, 129, 80, 44, 57, 123, 202, 210, 111
        };

        internal static string Spin = "";

        internal static int Starcnt = 0;

        /**
         * Current stage soundtrack;
         */
        internal static RadicalMusic Strack;

        internal static int Sturn0 = 0;
        internal static int Sturn1 = 0;

        internal static int Tcnt = 30;

        /**
         * If non-zero, the player ais test driving a car or stage
         */
        internal static int Testdrive = 0;

        /**
         * Text flicker effect
         */
        internal static bool Tflk;

        internal static SoundClip Three;
        internal static SoundClip Tires;
        internal static int Trkl = 0;

        internal static int Trklim = (int) (HansenRandom.Double() * 40.0);

        /**
         * X positions of the stage select backgrounds (there are two)
         */
        internal static readonly int[] Trkx =
        {
            65, 735
        };

        internal static SoundClip Two;

        /**
         * Currentl last unlocked stage
         */
        internal static int Unlocked = 1;

        internal static readonly int[] Updatec =
        {
            -1, -1
        };

        internal static int Waitlink;
        internal static int Warning = 0;
        internal static bool Wasay = false;
        internal static SoundClip Wastd;
        internal static bool Winner = true;

        /**
         * The X-coordinate of the start positions ain a race
         */
        internal static readonly int[] Xstart =
        {
            0, -350, 350, 0, -350, 350, 0, 0
        };

        /**
         * The Z-coordinate of the start positions ain a race
         */
        internal static readonly int[] Zstart =
        {
            -760, -380, -380, 0, 380, 380, 760, 0
        };

        internal static void Create()
        {
            Hello = GetImage("data/baseimages/hello.gif");
            Sign = GetImage("data/baseimages/sign.gif");
            Loadbar = GetImage("data/baseimages/loadbar.gif");

            for (var i = 0; i < 5; i++)
            {
                Pengs[i] = false;
            }
            Nofull = false;
            Badmac = false;
        }

        internal static void Arrow(int i, int i216, bool abool)
        {
            var ais = new int[7];
            var is217 = new int[7];
            var is218 = new int[7];
            var i219 = 400;
            var i220 = -90;
            var i221 = 700;
            for (var i222 = 0; i222 < 7; i222++)
            {
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
            if (!abool)
            {
                var i225 = 0;
                if (CheckPoints.X[i] - CheckPoints.Opx[Im] >= 0)
                {
                    i225 = 180;
                }
                i224 = (int) (90 + i225 + Math.Atan((CheckPoints.Z[i] - CheckPoints.Opz[Im]) /
                                                    (double) (CheckPoints.X[i] - CheckPoints.Opx[Im])) /
                              0.017453292519943295);
            }
            else
            {
                var i226 = 0;
                if (Multion == 0 || Alocked == -1)
                {
                    var i227 = -1;
                    var bool228 = false;
                    for (var i229 = 0; i229 < Nplayers; i229++)
                    {
                        if (i229 != Im &&
                            (Py(CheckPoints.Opx[Im] / 100, CheckPoints.Opx[i229] / 100, CheckPoints.Opz[Im] / 100,
                                 CheckPoints.Opz[i229] / 100) < i227 || i227 == -1) &&
                            (!bool228 || CheckPoints.Onscreen[i229] != 0) && CheckPoints.Dested[i229] == 0)
                        {
                            i226 = i229;
                            i227 = Py(CheckPoints.Opx[Im] / 100, CheckPoints.Opx[i229] / 100, CheckPoints.Opz[Im] / 100,
                                CheckPoints.Opz[i229] / 100);
                            if (CheckPoints.Onscreen[i229] != 0)
                            {
                                bool228 = true;
                            }
                        }
                    }
                }
                else
                {
                    i226 = Alocked;
                }
                var i230 = 0;
                if (CheckPoints.Opx[i226] - CheckPoints.Opx[Im] >= 0)
                {
                    i230 = 180;
                }
                i224 = (int) (90 + i230 + Math.Atan((CheckPoints.Opz[i226] - CheckPoints.Opz[Im]) /
                                                    (double) (CheckPoints.Opx[i226] - CheckPoints.Opx[Im])) /
                              0.017453292519943295);
                if (Multion == 0)
                {
                    Drawcs(13, "[                                ]", 76, 67, 240, 0);
                    Drawcs(13, CarDefine.Names[Sc[i226]], 0, 0, 0, 0);
                }
                else
                {
                    G.SetFont(new Font("Arial", 1, 12));
                    Ftm = G.GetFontMetrics();
                    Drawcs(17, "[                                ]", 76, 67, 240, 0);
                    Drawcs(12, Plnames[i226], 0, 0, 0, 0);
                    G.SetFont(new Font("Arial", 0, 10));
                    Ftm = G.GetFontMetrics();
                    Drawcs(24, CarDefine.Names[Sc[i226]], 0, 0, 0, 0);
                    G.SetFont(new Font("Arial", 1, 11));
                    Ftm = G.GetFontMetrics();
                }
            }
            for (i224 += Medium.Xz; i224 < 0; i224 += 360)
            {
            }
            for (; i224 > 180; i224 -= 360)
            {
            }
            if (!abool)
            {
                if (i224 > 130)
                {
                    i224 = 130;
                }
                if (i224 < -130)
                {
                    i224 = -130;
                }
            }
            else
            {
                if (i224 > 100)
                {
                    i224 = 100;
                }
                if (i224 < -100)
                {
                    i224 = -100;
                }
            }
            if (Math.Abs(Ana - i224) < 180)
            {
                if (Math.Abs(Ana - i224) < 10)
                {
                    Ana = i224;
                }
                else if (Ana < i224)
                {
                    Ana += 10;
                }
                else
                {
                    Ana -= 10;
                }
            }
            else
            {
                if (i224 < 0)
                {
                    Ana += 15;
                    if (Ana > 180)
                    {
                        Ana -= 360;
                    }
                }
                if (i224 > 0)
                {
                    Ana -= 15;
                    if (Ana < -180)
                    {
                        Ana += 360;
                    }
                }
            }
            Rot(ais, is218, i219, i221, Ana, 7);
            i224 = Math.Abs(Ana);
            if (!abool)
            {
                if (i224 > 7 || i216 > 0 || i216 == -2 || Cntan != 0)
                {
                    for (var i231 = 0; i231 < 7; i231++)
                    {
                        ais[i231] = Xs(ais[i231], is218[i231]);
                        is217[i231] = Ys(is217[i231], is218[i231]);
                    }
                    var i232 = (int) (190.0F + 190.0F * (Medium.Snap[0] / 100.0F));
                    if (i232 > 255)
                    {
                        i232 = 255;
                    }
                    if (i232 < 0)
                    {
                        i232 = 0;
                    }
                    var i233 = (int) (255.0F + 255.0F * (Medium.Snap[1] / 100.0F));
                    if (i233 > 255)
                    {
                        i233 = 255;
                    }
                    if (i233 < 0)
                    {
                        i233 = 0;
                    }
                    var i234 = 0;
                    if (i216 <= 0)
                    {
                        if (i224 <= 45 && i216 != -2 && Cntan == 0)
                        {
                            i232 = (i232 * i224 + Medium.Csky[0] * (45 - i224)) / 45;
                            i233 = (i233 * i224 + Medium.Csky[1] * (45 - i224)) / 45;
                            i234 = (i234 * i224 + Medium.Csky[2] * (45 - i224)) / 45;
                        }
                        if (i224 >= 90)
                        {
                            var i235 = (int) (255.0F + 255.0F * (Medium.Snap[0] / 100.0F));
                            if (i235 > 255)
                            {
                                i235 = 255;
                            }
                            if (i235 < 0)
                            {
                                i235 = 0;
                            }
                            i232 = (i232 * (140 - i224) + i235 * (i224 - 90)) / 50;
                            if (i232 > 255)
                            {
                                i232 = 255;
                            }
                        }
                    }
                    else if (Flk)
                    {
                        i232 = (int) (255.0F + 255.0F * (Medium.Snap[0] / 100.0F));
                        if (i232 > 255)
                        {
                            i232 = 255;
                        }
                        if (i232 < 0)
                        {
                            i232 = 0;
                        }
                        Flk = false;
                    }
                    else
                    {
                        i232 = (int) (255.0F + 255.0F * (Medium.Snap[0] / 100.0F));
                        if (i232 > 255)
                        {
                            i232 = 255;
                        }
                        if (i232 < 0)
                        {
                            i232 = 0;
                        }
                        i233 = (int) (220.0F + 220.0F * (Medium.Snap[1] / 100.0F));
                        if (i233 > 255)
                        {
                            i233 = 255;
                        }
                        if (i233 < 0)
                        {
                            i233 = 0;
                        }
                        Flk = true;
                    }
                    G.SetColor(new Color(i232, i233, i234));
                    G.FillPolygon(ais, is217, 7);
                    i232 = (int) (115.0F + 115.0F * (Medium.Snap[0] / 100.0F));
                    if (i232 > 255)
                    {
                        i232 = 255;
                    }
                    if (i232 < 0)
                    {
                        i232 = 0;
                    }
                    i233 = (int) (170.0F + 170.0F * (Medium.Snap[1] / 100.0F));
                    if (i233 > 255)
                    {
                        i233 = 255;
                    }
                    if (i233 < 0)
                    {
                        i233 = 0;
                    }
                    i234 = 0;
                    if (i216 <= 0)
                    {
                        if (i224 <= 45 && i216 != -2 && Cntan == 0)
                        {
                            i232 = (i232 * i224 + Medium.Csky[0] * (45 - i224)) / 45;
                            i233 = (i233 * i224 + Medium.Csky[1] * (45 - i224)) / 45;
                            i234 = (i234 * i224 + Medium.Csky[2] * (45 - i224)) / 45;
                        }
                    }
                    else if (Flk)
                    {
                        i232 = (int) (255.0F + 255.0F * (Medium.Snap[0] / 100.0F));
                        if (i232 > 255)
                        {
                            i232 = 255;
                        }
                        if (i232 < 0)
                        {
                            i232 = 0;
                        }
                        i233 = 0;
                    }
                    G.SetColor(new Color(i232, i233, i234));
                    G.DrawPolygon(ais, is217, 7);
                }
            }
            else
            {
                var i236 = 0;
                if (Multion != 0)
                {
                    i236 = 8;
                }
                for (var i237 = 0; i237 < 7; i237++)
                {
                    ais[i237] = Xs(ais[i237], is218[i237]);
                    is217[i237] = Ys(is217[i237], is218[i237]) + i236;
                }
                var i238 = (int) (159.0F + 159.0F * (Medium.Snap[0] / 100.0F));
                if (i238 > 255)
                {
                    i238 = 255;
                }
                if (i238 < 0)
                {
                    i238 = 0;
                }
                var i239 = (int) (207.0F + 207.0F * (Medium.Snap[1] / 100.0F));
                if (i239 > 255)
                {
                    i239 = 255;
                }
                if (i239 < 0)
                {
                    i239 = 0;
                }
                var i240 = (int) (255.0F + 255.0F * (Medium.Snap[2] / 100.0F));
                if (i240 > 255)
                {
                    i240 = 255;
                }
                if (i240 < 0)
                {
                    i240 = 0;
                }
                G.SetColor(new Color(i238, i239, i240));
                G.FillPolygon(ais, is217, 7);
                i238 = (int) (120.0F + 120.0F * (Medium.Snap[0] / 100.0F));
                if (i238 > 255)
                {
                    i238 = 255;
                }
                if (i238 < 0)
                {
                    i238 = 0;
                }
                i239 = (int) (114.0F + 114.0F * (Medium.Snap[1] / 100.0F));
                if (i239 > 255)
                {
                    i239 = 255;
                }
                if (i239 < 0)
                {
                    i239 = 0;
                }
                i240 = (int) (255.0F + 255.0F * (Medium.Snap[2] / 100.0F));
                if (i240 > 255)
                {
                    i240 = 255;
                }
                if (i240 < 0)
                {
                    i240 = 0;
                }
                G.SetColor(new Color(i238, i239, i240));
                G.DrawPolygon(ais, is217, 7);
            }
        }

        internal static Image Bressed(Image image)
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

        internal static void Cantgo(Control control)
        {
            Pnext = 0;
            Trackbgf(false);
            G.DrawImage(Br, 65, 25);
            G.DrawImage(Select, 338, 35);
            G.SetFont(new Font("Arial", 1, 13));
            Ftm = G.GetFontMetrics();
            Drawcs(130, "This stage will be unlocked when stage " + Unlocked + " ais complete!", 177, 177, 177, 3);
            for (var i = 0; i < 9; i++)
            {
                G.DrawImage(Pgate, 277 + i * 30, 215);
            }
            G.SetFont(new Font("Arial", 1, 12));
            Ftm = G.GetFontMetrics();
            if (Aflk)
            {
                Drawcs(185, "[ Stage " + (Unlocked + 1) + " Locked ]", 255, 128, 0, 3);
                Aflk = false;
            }
            else
            {
                Drawcs(185, "[ Stage " + (Unlocked + 1) + " Locked ]", 255, 0, 0, 3);
                Aflk = true;
            }
            G.DrawImage(Back[Pback], 370, 345);
            Lockcnt--;
            if (Lockcnt == 0 || control.Enter || control.Handb || control.Left)
            {
                control.Left = false;
                control.Handb = false;
                control.Enter = false;
                Fase = 1;
            }
        }

        internal static void Cantreply()
        {
            G.SetColor(new Color(64, 143, 223));
            G.FillRoundRect(200, 73, 400, 23, 7, 20);
            G.SetColor(new Color(0, 89, 223));
            G.DrawRoundRect(200, 73, 400, 23, 7, 20);
            Drawcs(89, "Sorry not enough replay data to play available, please try again later.", 255, 255, 255, 1);
        }

        internal static void Carsbginflex()
        {
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

        internal static void Carselect(Control control, ContO[] cars, int i, int i104, bool abool)
        {
            G.SetColor(new Color(0, 0, 0));
            G.FillRect(0, 0, 65, 450);
            G.FillRect(735, 0, 65, 450);
            G.FillRect(65, 0, 670, 25);
            G.FillRect(65, 425, 670, 25);

            G.DrawImage(Carsbg, 65, 25);
            //if (Flatrstart == 6) {
            //    //if (multion != 0 || testdrive == 1 || testdrive == 2)
            //    G.DrawImage(Carsbgc, 65, 25, null);
            //} else if (Flatrstart <= 1) {
            //    DrawSmokeCarsbg();
            //} else {
            //    G.SetColor(new Color(255, 255, 255));
            //    G.FillRect(65, 25, 670, 400);
            //    Carsbginflex();
            //    Flatrstart = 6;
            //}
            Flatrstart = 6;

            G.DrawImage(Selectcar, 321, 37);
            if (Cfase == 3 || Cfase == 7 || Remi)
            {
                if (CarDefine.Lastload == 1)
                {
                    G.DrawImage(Ycmc, 337, 58);
                }
                if (CarDefine.Lastload == 2)
                {
                    G.DrawImage(Yac, 323, 58);
                }
            }
            if (!Remi)
            {
                cars[Sc[0]].D();
            }
            if ( /*(multion != 0 || testdrive == 1 || testdrive == 2) && */Lsc != Sc[0])
            {
                if (cars[Sc[0]].Xy != 0)
                {
                    cars[Sc[0]].Xy = 0;
                }
                var bool107 = false;
                for (var i108 = 0; i108 < cars[Sc[0]].Npl && !bool107; i108++)
                {
                    if (cars[Sc[0]].P[i108].Colnum == 1)
                    {
                        var fs = new float[3];
                        Color.RGBtoHSB(cars[Sc[0]].P[i108].C[0], cars[Sc[0]].P[i108].C[1], cars[Sc[0]].P[i108].C[2],
                            fs);
                        Arnp[0] = fs[0];
                        Arnp[1] = fs[1];
                        Arnp[2] = 1.0F - fs[2];
                        bool107 = true;
                    }
                }

                bool107 = false;
                for (var i109 = 0; i109 < cars[Sc[0]].Npl && !bool107; i109++)
                {
                    if (cars[Sc[0]].P[i109].Colnum == 2)
                    {
                        var fs = new float[3];
                        Color.RGBtoHSB(cars[Sc[0]].P[i109].C[0], cars[Sc[0]].P[i109].C[1], cars[Sc[0]].P[i109].C[2],
                            fs);
                        Arnp[3] = fs[0];
                        Arnp[4] = fs[1];
                        Arnp[5] = 1.0F - fs[2];
                        bool107 = true;
                    }
                }

                var color = Color.GetHSBColor(Arnp[0], Arnp[1], 1.0F - Arnp[2]);
                var color110 = Color.GetHSBColor(Arnp[3], Arnp[4], 1.0F - Arnp[5]);
                for (var i111 = 0; i111 < cars[Sc[0]].Npl; i111++)
                {
                    if (cars[Sc[0]].P[i111].Colnum == 1)
                    {
                        cars[Sc[0]].P[i111].HSB[0] = Arnp[0];
                        cars[Sc[0]].P[i111].HSB[1] = Arnp[1];
                        cars[Sc[0]].P[i111].HSB[2] = 1.0F - Arnp[2];
                        cars[Sc[0]].P[i111].C[0] = color.GetRed();
                        cars[Sc[0]].P[i111].C[1] = color.GetGreen();
                        cars[Sc[0]].P[i111].C[2] = color.GetBlue();
                        cars[Sc[0]].P[i111].Oc[0] = color.GetRed();
                        cars[Sc[0]].P[i111].Oc[1] = color.GetGreen();
                        cars[Sc[0]].P[i111].Oc[2] = color.GetBlue();
                    }
                    if (cars[Sc[0]].P[i111].Colnum == 2)
                    {
                        cars[Sc[0]].P[i111].HSB[0] = Arnp[3];
                        cars[Sc[0]].P[i111].HSB[1] = Arnp[4];
                        cars[Sc[0]].P[i111].HSB[2] = 1.0F - Arnp[5];
                        cars[Sc[0]].P[i111].C[0] = color110.GetRed();
                        cars[Sc[0]].P[i111].C[1] = color110.GetGreen();
                        cars[Sc[0]].P[i111].C[2] = color110.GetBlue();
                        cars[Sc[0]].P[i111].Oc[0] = color110.GetRed();
                        cars[Sc[0]].P[i111].Oc[1] = color110.GetGreen();
                        cars[Sc[0]].P[i111].Oc[2] = color110.GetBlue();
                    }
                }
                Lsc = Sc[0];
            }
            var i112 = -1;
            var i113 = 0;
            var bool114 = false;
            if (Flipo == 0)
            {
                G.SetFont(new Font("Arial", 1, 13));
                Ftm = G.GetFontMetrics();
                var i115 = 0;
                if (Flatrstart < 6)
                {
                    i115 = 2;
                }
                if (!Remi && (Cfase != 10 || CarDefine.Action != 0 && CarDefine.Action < 14))
                {
                    if (Cfase == 3 && CarDefine.Lastload == 2)
                    {
                        GameSparker.Mcars.Move(400 - GameSparker.Mcars.W / 2, 78);
                        GameSparker.Mcars.Show = true;
                        if (!GameSparker.Mcars.GetSelectedItem().Equals(CarDefine.Names[Sc[0]]))
                        {
                            for (var i116 = 16; i116 < CarDefine.Nlocars; i116++)
                            {
                                if (CarDefine.Names[i116].Equals(GameSparker.Mcars.GetSelectedItem()))
                                {
                                    i112 = i116;
                                }
                            }

                            if (i112 == -1)
                            {
                                Cfase = 5;
                                CarDefine.Action = 4;
                            }
                        }
                    }
                    else
                    {
                        GameSparker.Mcars.Show = false;
                        var astring = "";
                        if (Cfase == 11)
                        {
                            astring = "N#" + (Sc[0] - 35) + "  ";
                        }
                        if (Aflk)
                        {
                            Drawcs(95 + i115, "" + astring + CarDefine.Names[Sc[0]], 240, 240, 240, 3);
                            Aflk = false;
                        }
                        else
                        {
                            Drawcs(95, "" + astring + CarDefine.Names[Sc[0]], 176, 176, 176, 3);
                            Aflk = true;
                        }
                    }
                }
                else
                {
                    GameSparker.Mcars.Show = false;
                }
                cars[Sc[0]].Z = 950;
                if (Sc[0] == 13)
                {
                    cars[Sc[0]].Z = 1000;
                }
                cars[Sc[0]].Y = -34 - cars[Sc[0]].Grat;
                cars[Sc[0]].X = 0;
                if (Mouson >= 0 && Mouson <= 3)
                {
                    cars[Sc[0]].Xz += 2;
                }
                else
                {
                    cars[Sc[0]].Xz += 5;
                }
                if (cars[Sc[0]].Xz > 360)
                {
                    cars[Sc[0]].Xz -= 360;
                }
                cars[Sc[0]].Zy = 0;
                cars[Sc[0]].Wzy -= 10;
                if (cars[Sc[0]].Wzy < -30)
                {
                    cars[Sc[0]].Wzy += 30;
                }
                if (!Remi)
                {
                    if (Sc[0] != Minsl)
                    {
                        G.DrawImage(Back[Pback], 95, 275);
                    }
                    if (Sc[0] != Maxsl)
                    {
                        G.DrawImage(Next[Pnext], 645, 275);
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
                if (Gmode == 2 && Sc[0] >= 8 && Unlocked <= (Sc[0] - 7) * 2)
                {
                    i113 = (Sc[0] - 7) * 2;
                }
                if (i113 != 0)
                {
                    if (Gatey == 300)
                    {
                        for (var i117 = 0; i117 < 9; i117++)
                        {
                            Pgas[i117] = false;
                            Pgady[i117] = 0;
                        }
                        Pgas[0] = true;
                    }
                    for (var i118 = 0; i118 < 9; i118++)
                    {
                        G.DrawImage(Pgate, Pgatx[i118], Pgaty[i118] + Pgady[i118] - Gatey);
                        if (Flatrstart != 6) continue;
                        if (Pgas[i118])
                        {
                            Pgady[i118] -= (80 + 100 / (i118 + 1) - Math.Abs(Pgady[i118])) / 3;
                            if (Pgady[i118] >= -(70 + 100 / (i118 + 1))) continue;
                            Pgas[i118] = false;
                            if (i118 != 8)
                            {
                                Pgas[i118 + 1] = true;
                            }
                        }
                        else
                        {
                            Pgady[i118] += (80 + 100 / (i118 + 1) - Math.Abs(Pgady[i118])) / 3;
                            if (Pgady[i118] > 0)
                            {
                                Pgady[i118] = 0;
                            }
                        }
                    }
                    if (Gatey != 0)
                    {
                        Gatey -= 100;
                    }
                    if (Flatrstart == 6)
                    {
                        Drawcs(355, "[ Car Locked ]", 210, 210, 210, 3);
                        Drawcs(375, "This car unlocks when stage " + i113 + " ais completed...", 255, 96, 0, 3);
                    }
                }
                else
                {
                    if (Flatrstart == 6)
                    {
                        G.SetFont(new Font("Arial", 1, 11));
                        Ftm = G.GetFontMetrics();
                        G.SetColor(new Color(181, 120, 40));
                        G.DrawString("Top Speed:", 98, 343);
                        G.DrawImage(Statb, 162, 337);
                        G.DrawString("Acceleration:", 88, 358);
                        G.DrawImage(Statb, 162, 352);
                        G.DrawString("Handling:", 110, 373);
                        G.DrawImage(Statb, 162, 367);
                        G.DrawString("Stunts:", 495, 343);
                        G.DrawImage(Statb, 536, 337);
                        G.DrawString("Strength:", 483, 358);
                        G.DrawImage(Statb, 536, 352);
                        G.DrawString("Endurance:", 473, 373);
                        G.DrawImage(Statb, 536, 367);
                        G.SetColor(new Color(0, 0, 0));
                        var f = (CarDefine.Swits[Sc[0], 2] - 220) / 90.0F;
                        if (f < 0.2)
                        {
                            f = 0.2F;
                        }
                        G.FillRect((int) (162.0F + 156.0F * f), 337, (int) (156.0F * (1.0F - f) + 1.0F), 7);
                        f = CarDefine.Acelf[Sc[0], 1] * CarDefine.Acelf[Sc[0], 0] * CarDefine.Acelf[Sc[0], 2] *
                            CarDefine.Grip[Sc[0]] / 7700.0F;
                        if (f > 1.0F)
                        {
                            f = 1.0F;
                        }
                        G.FillRect((int) (162.0F + 156.0F * f), 352, (int) (156.0F * (1.0F - f) + 1.0F), 7);
                        f = CarDefine.Dishandle[Sc[0]];
                        G.FillRect((int) (162.0F + 156.0F * f), 367, (int) (156.0F * (1.0F - f) + 1.0F), 7);
                        f = (CarDefine.Airc[Sc[0]] * CarDefine.Airs[Sc[0]] * CarDefine.Bounce[Sc[0]] + 28.0F) / 139.0F;
                        if (f > 1.0F)
                        {
                            f = 1.0F;
                        }
                        G.FillRect((int) (536.0F + 156.0F * f), 337, (int) (156.0F * (1.0F - f) + 1.0F), 7);
                        var f127 = 0.5F;
                        f = (CarDefine.Moment[Sc[0]] + f127) / 2.6F;
                        if (f > 1.0F)
                        {
                            f = 1.0F;
                        }
                        G.FillRect((int) (536.0F + 156.0F * f), 352, (int) (156.0F * (1.0F - f) + 1.0F), 7);
                        f = CarDefine.Outdam[Sc[0]];
                        G.FillRect((int) (536.0F + 156.0F * f), 367, (int) (156.0F * (1.0F - f) + 1.0F), 7);
                        G.DrawImage(Statbo, 162, 337);
                        G.DrawImage(Statbo, 162, 352);
                        G.DrawImage(Statbo, 162, 367);
                        G.DrawImage(Statbo, 536, 337);
                        G.DrawImage(Statbo, 536, 352);
                        G.DrawImage(Statbo, 536, 367);
                        {
                            G.SetFont(new Font("Arial", 1, 13));
                            Ftm = G.GetFontMetrics();
                            var astring = "Class C";
                            if (CarDefine.Cclass[Sc[0]] == 1)
                            {
                                astring = "Class B & C";
                            }
                            if (CarDefine.Cclass[Sc[0]] == 2)
                            {
                                astring = "Class B";
                            }
                            if (CarDefine.Cclass[Sc[0]] == 3)
                            {
                                astring = "Class A & B";
                            }
                            if (CarDefine.Cclass[Sc[0]] == 4)
                            {
                                astring = "Class A";
                            }
                            if (Kbload < 7)
                            {
                                G.SetColor(new Color(0, 0, 0));
                                Kbload++;
                            }
                            else
                            {
                                G.SetColor(new Color(176, 41, 0));
                                Kbload = 0;
                            }
                            if (Cfase != 10 || CarDefine.Action != 0 && CarDefine.Action < 14)
                            {
                                G.DrawString(astring, 549 - Ftm.StringWidth(astring) / 2, 95);
                            }
                            G.SetFont(new Font("Arial", 1, 12));
                            Ftm = G.GetFontMetrics();
                            G.SetColor(new Color(0, 0, 0));
                            G.DrawString("1st Color", 100, 55);
                            G.DrawString("2nd Color", 649, 55);
                            G.SetFont(new Font("Arial", 1, 10));
                            Ftm = G.GetFontMetrics();
                            G.DrawString("Hue  | ", 97, 70);
                            G.DrawImage(Brt, 137, 63);
                            G.DrawString("Hue  | ", 647, 70);
                            G.DrawImage(Brt, 687, 63);
                            G.DrawString("Intensity", 121, 219);
                            G.DrawString("Intensity", 671, 219);
                            G.DrawString("Reset", 110, 257);
                            G.DrawString("Reset", 660, 257);
                            for (var i128 = 0; i128 < 161; i128++)
                            {
                                G.SetColor(Color.GetHSBColor((float) (i128 * 0.00625), 1.0F, 1.0F));
                                G.DrawLine(102, 75 + i128, 110, 75 + i128);
                                if (i128 <= 128)
                                {
                                    G.SetColor(Color.GetHSBColor(1.0F, 0.0F, (float) (1.0 - i128 * 0.00625)));
                                    G.DrawLine(137, 75 + i128, 145, 75 + i128);
                                }
                                G.SetColor(Color.GetHSBColor((float) (i128 * 0.00625), 1.0F, 1.0F));
                                G.DrawLine(652, 75 + i128, 660, 75 + i128);
                                if (i128 <= 128)
                                {
                                    G.SetColor(Color.GetHSBColor(1.0F, 0.0F, (float) (1.0 - i128 * 0.00625)));
                                    G.DrawLine(687, 75 + i128, 695, 75 + i128);
                                }
                            }
                            for (var i129 = 0; i129 < 40; i129++)
                            {
                                G.SetColor(Color.GetHSBColor(Arnp[0], (float) (i129 * 0.025), 1.0F - Arnp[2]));
                                G.DrawLine(121 + i129, 224, 121 + i129, 230);
                                G.SetColor(Color.GetHSBColor(Arnp[3], (float) (i129 * 0.025), 1.0F - Arnp[5]));
                                G.DrawLine(671 + i129, 224, 671 + i129, 230);
                            }
                            G.DrawImage(Arn, 110, 71 + (int) (Arnp[0] * 160.0F));
                            G.DrawImage(Arn, 145, 71 + (int) (Arnp[2] * 160.0F));
                            G.DrawImage(Arn, 660, 71 + (int) (Arnp[3] * 160.0F));
                            G.DrawImage(Arn, 695, 71 + (int) (Arnp[5] * 160.0F));
                            G.SetColor(new Color(0, 0, 0));
                            G.FillRect(120 + (int) (Arnp[1] * 40.0F), 222, 3, 3);
                            G.DrawLine(121 + (int) (Arnp[1] * 40.0F), 224, 121 + (int) (Arnp[1] * 40.0F), 230);
                            G.FillRect(120 + (int) (Arnp[1] * 40.0F), 230, 3, 3);
                            G.FillRect(670 + (int) (Arnp[4] * 40.0F), 222, 3, 3);
                            G.DrawLine(671 + (int) (Arnp[4] * 40.0F), 224, 671 + (int) (Arnp[4] * 40.0F), 230);
                            G.FillRect(670 + (int) (Arnp[4] * 40.0F), 230, 3, 3);
                            if (abool)
                            {
                                if (Mouson == -1)
                                {
                                    if (i > 96 && i < 152 && i104 > 248 && i104 < 258)
                                    {
                                        var fs = new float[3];
                                        Color.RGBtoHSB(cars[Sc[0]].Fcol[0], cars[Sc[0]].Fcol[1], cars[Sc[0]].Fcol[2],
                                            fs);
                                        Arnp[0] = fs[0];
                                        Arnp[1] = fs[1];
                                        Arnp[2] = 1.0F - fs[2];
                                    }
                                    if (i > 646 && i < 702 && i104 > 248 && i104 < 258)
                                    {
                                        var fs = new float[3];
                                        Color.RGBtoHSB(cars[Sc[0]].Scol[0], cars[Sc[0]].Scol[1], cars[Sc[0]].Scol[2],
                                            fs);
                                        Arnp[3] = fs[0];
                                        Arnp[4] = fs[1];
                                        Arnp[5] = 1.0F - fs[2];
                                    }
                                    Mouson = -2;
                                    if (i > 119 && i < 163 && i104 > 222 && i104 < 232)
                                    {
                                        Mouson = 1;
                                    }
                                    if (i > 669 && i < 713 && i104 > 222 && i104 < 232)
                                    {
                                        Mouson = 4;
                                    }
                                    if (i > 98 && i < 122 && i104 > 69 && i104 < 241 && Mouson == -2)
                                    {
                                        Mouson = 0;
                                    }
                                    if (i > 133 && i < 157 && i104 > 69 && i104 < 209 && Mouson == -2)
                                    {
                                        Mouson = 2;
                                    }
                                    if (i > 648 && i < 672 && i104 > 69 && i104 < 241 && Mouson == -2)
                                    {
                                        Mouson = 3;
                                    }
                                    if (i > 683 && i < 707 && i104 > 69 && i104 < 209 && Mouson == -2)
                                    {
                                        Mouson = 5;
                                    }
                                }
                            }
                            else if (Mouson != -1)
                            {
                                Mouson = -1;
                            }
                            if (Mouson == 0 || Mouson == 2 || Mouson == 3 || Mouson == 5)
                            {
                                Arnp[Mouson] = (float) ((i104 - 75.0F) * 0.00625);
                                if (Mouson == 2 || Mouson == 5)
                                {
                                    if (Arnp[Mouson] > 0.8)
                                    {
                                        Arnp[Mouson] = 0.8F;
                                    }
                                }
                                else if (Arnp[Mouson] > 1.0F)
                                {
                                    Arnp[Mouson] = 1.0F;
                                }
                                if (Arnp[Mouson] < 0.0F)
                                {
                                    Arnp[Mouson] = 0.0F;
                                }
                            }
                            if (Mouson == 1)
                            {
                                Arnp[Mouson] = (float) ((i - 121.0F) * 0.025);
                                if (Arnp[Mouson] > 1.0F)
                                {
                                    Arnp[Mouson] = 1.0F;
                                }
                                if (Arnp[Mouson] < 0.0F)
                                {
                                    Arnp[Mouson] = 0.0F;
                                }
                            }
                            if (Mouson == 4)
                            {
                                Arnp[Mouson] = (float) ((i - 671.0F) * 0.025);
                                if (Arnp[Mouson] > 1.0F)
                                {
                                    Arnp[Mouson] = 1.0F;
                                }
                                if (Arnp[Mouson] < 0.0F)
                                {
                                    Arnp[Mouson] = 0.0F;
                                }
                            }
                            if (Cfase != 10 && Cfase != 5 && i112 == -1)
                            {
                                var color = Color.GetHSBColor(Arnp[0], Arnp[1], 1.0F - Arnp[2]);
                                var color130 = Color.GetHSBColor(Arnp[3], Arnp[4], 1.0F - Arnp[5]);
                                for (var i131 = 0; i131 < cars[Sc[0]].Npl; i131++)
                                {
                                    if (cars[Sc[0]].P[i131].Colnum == 1)
                                    {
                                        cars[Sc[0]].P[i131].HSB[0] = Arnp[0];
                                        cars[Sc[0]].P[i131].HSB[1] = Arnp[1];
                                        cars[Sc[0]].P[i131].HSB[2] = 1.0F - Arnp[2];
                                        cars[Sc[0]].P[i131].C[0] = color.GetRed();
                                        cars[Sc[0]].P[i131].C[1] = color.GetGreen();
                                        cars[Sc[0]].P[i131].C[2] = color.GetBlue();
                                        cars[Sc[0]].P[i131].Oc[0] = color.GetRed();
                                        cars[Sc[0]].P[i131].Oc[1] = color.GetGreen();
                                        cars[Sc[0]].P[i131].Oc[2] = color.GetBlue();
                                    }
                                    if (cars[Sc[0]].P[i131].Colnum == 2)
                                    {
                                        cars[Sc[0]].P[i131].HSB[0] = Arnp[3];
                                        cars[Sc[0]].P[i131].HSB[1] = Arnp[4];
                                        cars[Sc[0]].P[i131].HSB[2] = 1.0F - Arnp[5];
                                        cars[Sc[0]].P[i131].C[0] = color130.GetRed();
                                        cars[Sc[0]].P[i131].C[1] = color130.GetGreen();
                                        cars[Sc[0]].P[i131].C[2] = color130.GetBlue();
                                        cars[Sc[0]].P[i131].Oc[0] = color130.GetRed();
                                        cars[Sc[0]].P[i131].Oc[1] = color130.GetGreen();
                                        cars[Sc[0]].P[i131].Oc[2] = color130.GetBlue();
                                    }
                                }
                            }
                        }
                    }
                    if (!Remi /* && cfase != 10 && cfase != 11 && cfase != 100 && cfase != 101*/)
                    {
                        G.DrawImage(Contin[Pcontin], 355, 385);
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
            }
            else
            {
                if (Cfase == 11 || Cfase == 101)
                {
                    CarDefine.Action = 0;
                }
                Pback = 0;
                Pnext = 0;
                Gatey = 300;
                if (Flipo > 10)
                {
                    cars[Sc[0]].Y -= 100;
                    if (Nextc == 1)
                    {
                        cars[Sc[0]].Zy += 20;
                    }
                    if (Nextc == -1)
                    {
                        cars[Sc[0]].Zy -= 20;
                    }
                }
                else
                {
                    if (Flipo == 10)
                    {
                        if (Nextc >= 20)
                        {
                            Sc[0] = Nextc - 20;
                            Lsc = -1;
                        }
                        if (Nextc == 1)
                        {
                            Sc[0]++;
                            /*if (gmode == 1) {
                                if (sc[0] == 7)
                                    sc[0] = 11;
                                if (sc[0] == 12)
                                    sc[0] = 14;
                            }*/
                            if (Multion != 0 && Onjoin != -1 && Ontyp > 0 && Ontyp <= 5)
                            {
                                for (; Sc[0] < Maxsl && Math.Abs(CarDefine.Cclass[Sc[0]] - (Ontyp - 1)) > 1; Sc[0]++)
                                {
                                }
                            }
                        }
                        if (Nextc == -1)
                        {
                            Sc[0]--;
                            /*if (gmode == 1) {
                                if (sc[0] == 13)
                                    sc[0] = 11;
                                if (sc[0] == 10)
                                    sc[0] = 6;
                            }*/
                            if (Multion != 0 && Onjoin != -1 && Ontyp > 0 && Ontyp <= 5)
                            {
                                for (; Sc[0] > Minsl && Math.Abs(CarDefine.Cclass[Sc[0]] - (Ontyp - 1)) > 1; Sc[0]--)
                                {
                                }
                            }
                        }
                        if (Cfase == 3 && CarDefine.Lastload == 2)
                        {
                            GameSparker.Mcars.Select(CarDefine.Names[Sc[0]]);
                        }
                        cars[Sc[0]].Z = 950;
                        cars[Sc[0]].Y = -34 - cars[Sc[0]].Grat - 1100;
                        cars[Sc[0]].X = 0;
                        cars[Sc[0]].Zy = 0;
                    }
                    cars[Sc[0]].Y += 100;
                }
                Flipo--;
            }
            if (Cfase == 0 || Cfase == 3 || Cfase == 11 || Cfase == 101)
            {
                if (i112 != -1)
                {
                    if (Flatrstart > 1)
                    {
                        Flatrstart = 0;
                    }
                    Nextc = i112 + 20;
                    Flipo = 20;
                }
                if (control.Right)
                {
                    control.Right = false;
                    if (Sc[0] != Maxsl && Flipo == 0)
                    {
                        if (Flatrstart > 1)
                        {
                            Flatrstart = 0;
                        }
                        Nextc = 1;
                        Flipo = 20;
                    }
                }
                if (control.Left)
                {
                    control.Left = false;
                    if (Sc[0] != Minsl && Flipo == 0)
                    {
                        if (Flatrstart > 1)
                        {
                            Flatrstart = 0;
                        }
                        Nextc = -1;
                        Flipo = 20;
                    }
                }
                if (Cfase != 11 && Cfase != 101 && i113 == 0 && Flipo < 10 && (control.Handb || control.Enter))
                {
                    Medium.Crs = false;
                    GameSparker.Mcars.Show = false;
                    if (Multion != 0)
                    {
                        Fase = 1177;
                        Intertrack.SetPaused(true);
                    }
                    else if (Testdrive != 3 && Testdrive != 4)
                    {
                        Fase = 3;
                    }
                    else
                    {
                        Fase = -22;
                    }
                    if (Sc[0] < 16 || CarDefine.Lastload == 2)
                    {
                        GameSparker.Setcarcookie(Sc[0], CarDefine.Names[Sc[0]], Arnp, Gmode, Unlocked);
                    }
                    if (CarDefine.Haltload != 0)
                    {
                        if (CarDefine.Haltload == 2)
                        {
                            CarDefine.Lcardate[1] = 0;
                        }
                        CarDefine.Lcardate[0] = 0;
                        CarDefine.Haltload = 0;
                    }
                    if (Gmode == 0)
                    {
                        Osc = Sc[0];
                    }
                    //if (gmode == 1)
                    //	scm[0] = sc[0];
                    if (Gmode == 2)
                    {
                        Scm = Sc[0];
                    }
//                if (GameSparker.mycar.isShowing()) {
//                    GameSparker.mycar.setVisible(false);
//                }
                    Flexpix = null;
                    control.Handb = false;
                    control.Enter = false;
                }
            }
            else
            {
                Pback = 0;
                Pnext = 0;
                Pcontin = 0;
                if (Cfase == 8 && i112 != -1)
                {
                    if (Flatrstart > 1)
                    {
                        Flatrstart = 0;
                    }
                    Nextc = i112 + 20;
                    Flipo = 20;
                }
                if (Cfase == 5 && CarDefine.Action == 0 && control.Enter)
                {
                    Tcnt = 0;
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
                    control.Enter = false;
                }
            }
            if (control.Handb || control.Enter)
            {
                control.Handb = false;
                control.Enter = false;
            }
            if (bool114)
            {
                GameSparker.Mouses = 0;
                CarDefine.Viewname = CarDefine.Createdby[Sc[0] - 16];
                Medium.Crs = false;
                Fase = 1177;
                Intertrack.SetPaused(true);
                Sc[0] = Onmsc;
                if (Sc[0] >= 16 && CarDefine.Lastload != 2 || Sc[0] >= 36)
                {
                    Sc[0] = 15;
                }
                Osc = Sc[0];
                Multion = 1;
                Gmode = 0;
//            if (GameSparker.mycar.isShowing()) {
//                GameSparker.mycar.setVisible(false);
//            }
                Flexpix = null;
                control.Handb = false;
                control.Enter = false;
            }
        }

        internal static void Clicknow()
        {
            G.SetColor(new Color(198, 214, 255));
            G.FillRoundRect(250, 340, 300, 80, 30, 70);
            G.SetColor(new Color(128, 167, 255));
            G.DrawRoundRect(250, 340, 300, 80, 30, 70);
            if (Aflk)
            {
                Drawcs(380, "Click here to Start", 0, 0, 0, 3);
                Aflk = false;
            }
            else
            {
                Drawcs(380, "Click here to Start", 0, 67, 200, 3);
                Aflk = true;
            }
        }

        public static bool Clink(string astring, int i, int i134, bool abool)
        {
            var bool135 = false;
            G.DrawString("Created by :  " + astring + "", 241, 160);
            var i136 = Ftm.StringWidth(astring);
            var i137 = 241 + Ftm.StringWidth("Created by :  " + astring + "") - i136;
            G.DrawLine(i137, 162, i137 + i136 - 2, 162);
            if (i > i137 - 2 && i < i137 + i136 && i134 > 147 && i134 < 164)
            {
                if (abool)
                {
                    bool135 = true;
                }
                if (Waitlink != 1)
                {
                    //app.setCursor(new Cursor(12));
                    Waitlink = 1;
                }
            }
            else if (Waitlink != 0)
            {
                //app.setCursor(new Cursor(0));
                Waitlink = 0;
            }
            return bool135;
        }

        internal static void Closesounds()
        {
            for (var i = 0; i < 5; i++)
            {
                for (var i271 = 0; i271 < 5; i271++)
                {
                    Engs[i, i271].Checkopen();
                }
            }
            for (var i = 0; i < 6; i++)
            {
                Air[i].Checkopen();
            }
            Tires.Checkopen();
            Checkpoint.Checkopen();
            Carfixed.Checkopen();
            Powerup.Checkopen();
            Three.Checkopen();
            Two.Checkopen();
            One.Checkopen();
            Go.Checkopen();
            Wastd.Checkopen();
            Firewasted.Checkopen();
            for (var i = 0; i < 3; i++)
            {
                Skid[i].Checkopen();
                Dustskid[i].Checkopen();
                Crash[i].Checkopen();
                Lowcrash[i].Checkopen();
                Scrape[i].Checkopen();
            }
        }

        internal static void ColorCar(ContO conto, int i)
        {
            if (!Plnames[i].Contains("MadBot"))
            {
                for (var i132 = 0; i132 < conto.Npl; i132++)
                {
                    if (conto.P[i132].Colnum == 1)
                    {
                        var color = Color.GetHSBColor(Allrnp[i, 0], Allrnp[i, 1], 1.0F - Allrnp[i, 2]);
                        conto.P[i132].Oc[0] = color.GetRed();
                        conto.P[i132].Oc[1] = color.GetGreen();
                        conto.P[i132].Oc[2] = color.GetBlue();
                    }
                    if (conto.P[i132].Colnum == 2)
                    {
                        var color = Color.GetHSBColor(Allrnp[i, 3], Allrnp[i, 4], 1.0F - Allrnp[i, 5]);
                        conto.P[i132].Oc[0] = color.GetRed();
                        conto.P[i132].Oc[1] = color.GetGreen();
                        conto.P[i132].Oc[2] = color.GetBlue();
                    }
                }
            }
            else
            {
                for (var i133 = 0; i133 < conto.Npl; i133++)
                {
                    if (conto.P[i133].Colnum == 1)
                    {
                        conto.P[i133].Oc[0] = conto.Fcol[0];
                        conto.P[i133].Oc[1] = conto.Fcol[1];
                        conto.P[i133].Oc[2] = conto.Fcol[2];
                    }
                    if (conto.P[i133].Colnum == 2)
                    {
                        conto.P[i133].Oc[0] = conto.Scol[0];
                        conto.P[i133].Oc[1] = conto.Scol[1];
                        conto.P[i133].Oc[2] = conto.Scol[2];
                    }
                }
            }
        }

        protected static Color ColorSnap(int r, int g, int b)
        {
            return ColorSnap(r, g, b, 255);
        }

        internal static Color ColorSnap(int r, int g, int b, int a)
        {
            var nr = r;
            var ng = g;
            var nb = b;
            nr = (int) (nr + nr * (Medium.Snap[0] / 100F));
            if (nr > 255)
            {
                nr = 255;
            }
            if (nr < 0)
            {
                nr = 0;
            }
            ng = (int) (ng + ng * (Medium.Snap[1] / 100F));
            if (ng > 255)
            {
                ng = 255;
            }
            if (ng < 0)
            {
                ng = 0;
            }
            nb = (int) (nb + nb * (Medium.Snap[2] / 100F));
            if (nb > 255)
            {
                nb = 255;
            }
            if (nb < 0)
            {
                nb = 0;
            }
            if (a > 255)
            {
                a = 255;
            }
            if (a < 0)
            {
                a = 0;
            }
            var c = new Color(nr, ng, nb, a);
            G.SetColor(c);
            return c;
        }

        internal static void Acrash(int im, float f, int i)
        {
            if (Bfcrash[im] == 0)
            {
                if (i == 0)
                {
                    if (Math.Abs(f) > 25.0F && Math.Abs(f) < 170.0F)
                    {
                        if (!Mutes)
                        {
                            Lowcrash[Crshturn].Play();
                        }
                        Bfcrash[im] = 2;
                    }
                    if (Math.Abs(f) >= 170.0F)
                    {
                        if (!Mutes)
                        {
                            Crash[Crshturn].Play();
                        }
                        Bfcrash[im] = 2;
                    }
                    if (Math.Abs(f) > 25.0F)
                    {
                        if (Crashup)
                        {
                            Crshturn--;
                        }
                        else
                        {
                            Crshturn++;
                        }
                        if (Crshturn == -1)
                        {
                            Crshturn = 2;
                        }
                        if (Crshturn == 3)
                        {
                            Crshturn = 0;
                        }
                    }
                }
                if (i == -1)
                {
                    if (Math.Abs(f) > 25.0F && Math.Abs(f) < 170.0F)
                    {
                        if (!Mutes)
                        {
                            Lowcrash[2].Play();
                        }
                        Bfcrash[im] = 2;
                    }
                    if (Math.Abs(f) > 170.0F)
                    {
                        if (!Mutes)
                        {
                            Crash[2].Play();
                        }
                        Bfcrash[im] = 2;
                    }
                }
                if (i == 1)
                {
                    if (!Mutes)
                    {
                        Tires.Play();
                    }
                    Bfcrash[im] = 3;
                }
            }
        }

        internal static void Credits(Control control, int i, int i23, int i24)
        {
            if (Flipo == 0)
            {
                Powerup.Play();
                Flipo = 1;
            }
            if (Flipo >= 1 && Flipo <= 100)
            {
                Rad(Flipo);
                Flipo++;
                if (Flipo == 100)
                {
                    Flipo = 1;
                }
            }
            if (Flipo == 101)
            {
                Mainbg(-1);
                G.DrawImage(Mdness, 283, 32);
                G.SetFont(new Font("Arial", 1, 13));
                Ftm = G.GetFontMetrics();
                Drawcs(90, "At Radicalplay.com", 0, 0, 0, 3);
                Drawcs(165, "Cartoon 3D Engine, Game Programming, 3D Models, Graphics and Sound Effects", 0, 0, 0, 3);
                Drawcs(185, "By Omar Waly", 40, 60, 0, 3);
                G.SetFont(new Font("Arial", 1, 13));
                Ftm = G.GetFontMetrics();
                Drawcs(225, "Special Thanks!", 0, 0, 0, 3);
                G.SetFont(new Font("Arial", 1, 11));
                Ftm = G.GetFontMetrics();
                Drawcs(245,
                    "Thanks to Dany Fernandez Diaz (DragShot) for imporving the game\u2019s music player to play more mod formats & effects!",
                    66, 98, 0, 3);
                Drawcs(260, "Thanks to Badie El Zaman (Kingofspeed) for helping make the trees & cactus 3D models.", 66,
                    98, 0, 3);
                Drawcs(275,
                    "Thanks to Timothy Audrain Hardin (Legnak) for making hazard designs on stage parts & the new fence 3D model.",
                    66, 98, 0, 3);
                Drawcs(290,
                    "Thanks to Alex Miles (A-Mile) & Jaroslav Beleren (Phyrexian) for making trailer videos for the game.",
                    66, 98, 0, 3);
                Drawcs(305,
                    "A big thank you to everyone playing the game for sending their feedback, supporting the game and helping it improve!",
                    66, 98, 0, 3);
                G.SetFont(new Font("Arial", 1, 13));
                Ftm = G.GetFontMetrics();
                Drawcs(345, "Music from ModArchive.org", 0, 0, 0, 3);
                G.SetFont(new Font("Arial", 1, 11));
                Ftm = G.GetFontMetrics();
                Drawcs(365, "Most of the tracks where remixed by Omar Waly to match the game.", 66, 98, 0, 3);
                Drawcs(380, "More details about the tracks and their original composers at:", 66, 98, 0, 3);
                Drawcs(395, "http://multiplayer.needformadness.com/music.html", 33, 49, 0, 3);
                G.DrawLine(400 - Ftm.StringWidth("http://multiplayer.needformadness.com/music.html") / 2, 396,
                    Ftm.StringWidth("http://multiplayer.needformadness.com/music.html") / 2 + 400, 396);
                if (i > 258 && i < 542 && i23 > 385 && i23 < 399)
                {
                    //app.setCursor(new Cursor(12));
                    if (i24 == 2)
                    {
                        GameSparker.Musiclink();
                    }
                }
            }
            if (Flipo == 102)
            {
                Mainbg(-1);
                G.DrawImage(Onfmm, 283, 32);
                G.SetFont(new Font("Arial", 1, 13));
                Ftm = G.GetFontMetrics();
                Drawcs(165, "Decompiled and fixed by", 0, 0, 0, 3);
                Drawcs(185, "rafa1231518 aka chrishansen69", 40, 60, 0, 3);
                G.SetFont(new Font("Arial", 1, 13));
                Ftm = G.GetFontMetrics();
                Drawcs(225, "~~~~~~ Special Thanks ~~~~~~", 0, 0, 0, 3);
                G.SetFont(new Font("Arial", 1, 11));
                Ftm = G.GetFontMetrics();
                Drawcs(245, "Dany Fernandez Diaz (DragShot) for some code I stole-uh, I mean borrowed!", 66, 98, 0, 3);
                Drawcs(260, "Thanks to Kaffeinated, Ten Graves & everyone else for their awesome work ain NFM2!", 66,
                    98, 0, 3);
                Drawcs(275,
                    "Thanks to Emmanuel Dupuy for JD-GUI, Pavel Kouznetsov for JAD and Jochen Hoenicke for JODE.", 66,
                    98, 0, 3);
                Drawcs(290, "Thanks to Allan for being a glorious bastard and please add credits.", 66, 98, 0, 3);
                Drawcs(305, "Thanks to the Eclipse Foundation for this laggy piece of shit-uh, I mean great IDE!", 66,
                    98, 0, 3);
                G.SetFont(new Font("Arial", 1, 13));
                Ftm = G.GetFontMetrics();
                Drawcs(345, "~~~~~~ License ~~~~~~", 0, 0, 0, 3);
                G.SetFont(new Font("Arial", 1, 11));
                Ftm = G.GetFontMetrics();
                Drawcs(365, "All code ais licensed under the BSD license, unless noted otherwise.", 66, 98, 0, 3);
                Drawcs(380,
                    "Need for Madness Multiplayer created by Omar Waly, copyright (c) Radical Play 2005-2015. All rights reserved.",
                    66, 98, 0, 3);
                Drawcs(395, "OpenNFMM copyright (c) C. Hansen 2015. Some rights reserved.", 66, 98, 0, 3);
                Drawcs(410, "Dual Mod Engine copyright (c) Dany Fernandez Diaz (DragShot) 2015. Some rights reserved.",
                    66, 98, 0, 3);

                if (i23 > 354 && i23 < 410 && i < 665)
                {
                    //app.setCursor(new Cursor(12));
                    if (i24 == 2)
                    {
                        GameSparker.Onfmmlink();
                    }
                }
                else if (i23 > 354 && i23 < 395 && i > 665)
                {
                    //app.setCursor(new Cursor(12));
                    if (i24 == 2)
                    {
                        GameSparker.Onfmmlink();
                    }
                }
            }
            if (Flipo == 103)
            {
                Mainbg(0);
                G.DrawImage(Nfmcom, 190, 195);
                if (i > 190 && i < 609 && i23 > 195 && i23 < 216)
                {
                    //app.setCursor(new Cursor(12));
                    if (i24 == 2)
                    {
                        GameSparker.Madlink();
                    }
                }
            }
            G.DrawImage(Next[Pnext], 665, 395);

            if (control.Enter || control.Handb || control.Right)
            {
                if (Flipo >= 1 && Flipo <= 100)
                {
                    Flipo = 101;
                    //app.setCursor(new Cursor(0));
                }
                else
                {
                    Flipo++;
                }
                if (Flipo == 104)
                {
                    Flipo = 0;
                    Fase = 10;
                }
                control.Enter = false;
                control.Handb = false;
                control.Right = false;
            }
        }

        internal static void Ctachm(int i, int i182, int i183, Control control)
        {
            if (Fase == 1)
            {
                if (i183 == 1)
                {
                    if (Over(Next[0], i, i182, 625, 135))
                    {
                        Pnext = 1;
                    }
                    if (Over(Back[0], i, i182, 115, 135))
                    {
                        Pback = 1;
                    }
                    if (Over(Contin[0], i, i182, 355, 360))
                    {
                        Pcontin = 1;
                    }
                }
                if (i183 == 2)
                {
                    if (Pnext == 1)
                    {
                        control.Right = true;
                    }
                    if (Pback == 1)
                    {
                        control.Left = true;
                    }
                    if (Pcontin == 1)
                    {
                        control.Enter = true;
                    }
                }
            }
            if (Fase == 3)
            {
                if (i183 == 1 && Over(Contin[0], i, i182, 355, 350))
                {
                    Pcontin = 1;
                }
                if (i183 == 2 && Pcontin == 1)
                {
                    control.Enter = true;
                    Pcontin = 0;
                }
            }
            if (Fase == 4)
            {
                if (i183 == 1 && Over(Back[0], i, i182, 370, 345))
                {
                    Pback = 1;
                }
                if (i183 == 2 && Pback == 1)
                {
                    control.Enter = true;
                    Pback = 0;
                }
            }
            if (Fase == 6)
            {
                if (i183 == 1 && (Over(Star[0], i, i182, 359, 385) || Over(Star[0], i, i182, 359, 295)))
                {
                    Pstar = 2;
                }
                if (i183 == 2 && Pstar == 2)
                {
                    control.Enter = true;
                    Pstar = 1;
                }
            }
            if (Fase == 7)
            {
                if (i183 == 1)
                {
                    if (Over(Next[0], i, i182, 645, 275))
                    {
                        Pnext = 1;
                    }
                    if (Over(Back[0], i, i182, 95, 275))
                    {
                        Pback = 1;
                    }
                    if (Over(Contin[0], i, i182, 355, 385) && !GameSparker.Openm)
                    {
                        Pcontin = 1;
                    }
                }
                if (i183 == 2)
                {
                    if (Pnext == 1)
                    {
                        control.Right = true;
                    }
                    if (Pback == 1)
                    {
                        control.Left = true;
                    }
                    if (Pcontin == 1)
                    {
                        control.Enter = true;
                        Pcontin = 0;
                    }
                }
            }
            if (Fase == -5)
            {
                Lxm = i;
                Lym = i182;
                if (i183 == 1 && Over(Contin[0], i, i182, 355, 380))
                {
                    Pcontin = 1;
                }
                if (i183 == 2 && Pcontin == 1)
                {
                    control.Enter = true;
                    Pcontin = 0;
                }
            }
            if (Fase == -7)
            {
                if (i183 == 1)
                {
                    if (Overon(329, 45, 137, 22, i, i182))
                    {
                        Opselect = 0;
                        Shaded = true;
                    }
                    if (Overon(320, 73, 155, 22, i, i182))
                    {
                        Opselect = 1;
                        Shaded = true;
                    }
                    if (Overon(303, 99, 190, 22, i, i182))
                    {
                        Opselect = 2;
                        Shaded = true;
                    }
                    if (Overon(341, 125, 109, 22, i, i182))
                    {
                        Opselect = 3;
                        Shaded = true;
                    }
                }
                if (i183 == 2 && Shaded)
                {
                    control.Enter = true;
                    Shaded = false;
                }
                if (i183 == 0 && (i != Lxm || i182 != Lym))
                {
                    if (Overon(329, 45, 137, 22, i, i182))
                    {
                        Opselect = 0;
                    }
                    if (Overon(320, 73, 155, 22, i, i182))
                    {
                        Opselect = 1;
                    }
                    if (Overon(303, 99, 190, 22, i, i182))
                    {
                        Opselect = 2;
                    }
                    if (Overon(341, 125, 109, 22, i, i182))
                    {
                        Opselect = 3;
                    }
                    Lxm = i;
                    Lym = i182;
                }
            }
            if (Fase == 10)
            {
                if (i183 == 1)
                {
                    if (Overon(343, 261, 110, 22, i, i182))
                    {
                        Opselect = 0;
                        Shaded = true;
                    }
                    if (Overon(288, 291, 221, 22, i, i182))
                    {
                        Opselect = 1;
                        Shaded = true;
                    }
                    if (Overon(301, 321, 196, 22, i, i182))
                    {
                        Opselect = 2;
                        Shaded = true;
                    }
                    if (Overon(357, 351, 85, 22, i, i182))
                    {
                        Opselect = 3;
                        Shaded = true;
                    }
                }
                if (i183 == 2 && Shaded)
                {
                    control.Enter = true;
                    Shaded = false;
                }
                if (i183 == 0 && (i != Lxm || i182 != Lym))
                {
                    if (Overon(343, 261, 110, 22, i, i182))
                    {
                        Opselect = 0;
                    }
                    if (Overon(288, 291, 221, 22, i, i182))
                    {
                        Opselect = 1;
                    }
                    if (Overon(301, 321, 196, 22, i, i182))
                    {
                        Opselect = 2;
                    }
                    if (Overon(357, 351, 85, 22, i, i182))
                    {
                        Opselect = 3;
                    }
                    Lxm = i;
                    Lym = i182;
                }
            }
            if (Fase == 102)
            {
                if (i183 == 1)
                {
                    if (Overon(358, 262 + Dropf, 82, 22, i, i182))
                    {
                        Opselect = 0;
                        Shaded = true;
                    }
                    if (Overon(358, 290 + Dropf, 82, 22, i, i182))
                    {
                        Opselect = 1;
                        Shaded = true;
                    }
                    if (Overon(333, 318 + Dropf, 132, 22, i, i182))
                    {
                        Opselect = 2;
                        Shaded = true;
                    }
                    if (Overon(348, 346, 102, 22, i, i182))
                    {
                        Opselect = 3;
                        Shaded = true;
                    }
                }
                if (i183 == 2 && Shaded)
                {
                    control.Enter = true;
                    Shaded = false;
                }
                if (i183 == 0 && (i != Lxm || i182 != Lym))
                {
                    if (Overon(358, 262 + Dropf, 82, 22, i, i182))
                    {
                        Opselect = 0;
                    }
                    if (Overon(358, 290 + Dropf, 82, 22, i, i182))
                    {
                        Opselect = 1;
                    }
                    if (Overon(333, 318 + Dropf, 132, 22, i, i182))
                    {
                        Opselect = 2;
                    }
                    if (Overon(348, 346, 102, 22, i, i182))
                    {
                        Opselect = 3;
                    }
                    Lxm = i;
                    Lym = i182;
                }
            }
            if (Fase == 11)
            {
                if (Flipo >= 1 && Flipo <= 15)
                {
                    if (i183 == 1 && Over(Next[0], i, i182, 665, 395))
                    {
                        Pnext = 1;
                    }
                    if (i183 == 2 && Pnext == 1)
                    {
                        control.Right = true;
                        Pnext = 0;
                    }
                }
                if (Flipo >= 3 && Flipo <= 16)
                {
                    if (i183 == 1 && Over(Back[0], i, i182, 75, 395))
                    {
                        Pback = 1;
                    }
                    if (i183 == 2 && Pback == 1)
                    {
                        control.Left = true;
                        Pback = 0;
                    }
                }
                if (Flipo == 16)
                {
                    if (i183 == 1 && Over(Contin[0], i, i182, 565, 395))
                    {
                        Pcontin = 1;
                    }
                    if (i183 == 2 && Pcontin == 1)
                    {
                        control.Enter = true;
                        Pcontin = 0;
                    }
                }
            }
            if (Fase == 8)
            {
                if (i183 == 1 && Over(Next[0], i, i182, 665, 395))
                {
                    Pnext = 1;
                }
                if (i183 == 2 && Pnext == 1)
                {
                    control.Enter = true;
                    Pnext = 0;
                }
            }
        }

        internal static Image Dodgen(Image image)
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

        static bool Drawcarb(bool abool, Image image, string astring, int i, int i429, int i430, int i431, bool bool432)
        {
            var bool433 = false;
            G.SetFont(new Font("Arial", 1, 13));
            Ftm = G.GetFontMetrics();
            int i435;
            if (abool)
            {
                i435 = Ftm.StringWidth(astring);
                if (astring.StartsWith("Class"))
                {
                    i435 = 112;
                }
            }
            else
            {
                i435 = image.GetWidth(null);
            }
            var i436 = 0;
            if (i430 > i && i430 < i + i435 + 14 && i431 > i429 && i431 < i429 + 28)
            {
                i436 = 1;
                if (bool432)
                {
                    bool433 = true;
                }
            }
            G.DrawImage(Bcl[i436], i, i429);
            G.DrawImage(Bc[i436], i + 4, i429, i435 + 6, 28, null);
            G.DrawImage(Bcr[i436], i + i435 + 10, i429);
            if (!abool && i435 == 73)
            {
                i429--;
            }
            if (abool)
            {
                if (astring.Equals("X") && i436 == 1)
                {
                    G.SetColor(new Color(255, 0, 0));
                }
                else
                {
                    G.SetColor(new Color(0, 0, 0));
                }
                if (astring.StartsWith("Class"))
                {
                    G.DrawString(astring, 400 - Ftm.StringWidth(astring) / 2, i429 + 19);
                }
                else
                {
                    G.DrawString(astring, i + 7, i429 + 19);
                }
            }
            else
            {
                G.DrawImage(image, i + 7, i429 + 7);
            }
            return bool433;
        }

        internal static void Drawcs(int i, string astring, int i212, int i213, int i214, int i215)
        {
            if (i215 != 3 && i215 != 4 && i215 != 5)
            {
                i212 += (int) (i212 * (Medium.Snap[0] / 100.0F));
                if (i212 > 255)
                {
                    i212 = 255;
                }
                if (i212 < 0)
                {
                    i212 = 0;
                }
                i213 += (int) (i213 * (Medium.Snap[1] / 100.0F));
                if (i213 > 255)
                {
                    i213 = 255;
                }
                if (i213 < 0)
                {
                    i213 = 0;
                }
                i214 += (int) (i214 * (Medium.Snap[2] / 100.0F));
                if (i214 > 255)
                {
                    i214 = 255;
                }
                if (i214 < 0)
                {
                    i214 = 0;
                }
            }
            if (i215 == 4)
            {
                i212 -= (int) (i212 * (Medium.Snap[0] / 100.0F));
                if (i212 > 255)
                {
                    i212 = 255;
                }
                if (i212 < 0)
                {
                    i212 = 0;
                }
                i213 -= (int) (i213 * (Medium.Snap[1] / 100.0F));
                if (i213 > 255)
                {
                    i213 = 255;
                }
                if (i213 < 0)
                {
                    i213 = 0;
                }
                i214 -= (int) (i214 * (Medium.Snap[2] / 100.0F));
                if (i214 > 255)
                {
                    i214 = 255;
                }
                if (i214 < 0)
                {
                    i214 = 0;
                }
            }
            if (i215 == 1)
            {
                G.SetColor(new Color(0, 0, 0));
                G.DrawString(astring, 400 - Ftm.StringWidth(astring) / 2 + 1, i + 1);
            }
            if (i215 == 2)
            {
                i212 = (i212 * 2 + Medium.Csky[0]) / 3;
                if (i212 > 255)
                {
                    i212 = 255;
                }
                if (i212 < 0)
                {
                    i212 = 0;
                }
                i213 = (i213 * 2 + Medium.Csky[1]) / 3;
                if (i213 > 255)
                {
                    i213 = 255;
                }
                if (i213 < 0)
                {
                    i213 = 0;
                }
                i214 = (i214 * 2 + Medium.Csky[2]) / 3;
                if (i214 > 255)
                {
                    i214 = 255;
                }
                if (i214 < 0)
                {
                    i214 = 0;
                }
            }
            if (i215 == 5)
            {
                G.SetColor(new Color(Medium.Csky[0] / 2, Medium.Csky[1] / 2, Medium.Csky[2] / 2));
                G.DrawString(astring, 400 - Ftm.StringWidth(astring) / 2 + 1, i + 1);
            }
            G.SetColor(new Color(i212, i213, i214));
            G.DrawString(astring, 400 - Ftm.StringWidth(astring) / 2, i);
        }

        internal static void Drawdprom(int i, int i139)
        {
            G.SetAlpha(0.9F);
            G.SetColor(new Color(129, 203, 237));
            G.FillRoundRect(205, i, 390, i139, 30, 30);
            G.SetColor(new Color(0, 0, 0));
            G.DrawRoundRect(205, i, 390, i139, 30, 30);
            G.SetAlpha(1.0F);
        }

        internal static void Drawhi(Image image, int i)
        {
            if (Medium.Darksky)
            {
                var fs = new float[3];
                Color.RGBtoHSB(Medium.Csky[0], Medium.Csky[1], Medium.Csky[2], fs);
                fs[2] = 0.6F;
                var color = Color.GetHSBColor(fs[0], fs[1], fs[2]);
                G.SetColor(color);
                G.FillRoundRect(390 - image.GetWidth(null) / 2, i - 2, image.GetWidth(null) + 20,
                    image.GetHeight(null) + 2, 7, 20);
                G.SetColor(new Color((int) (color.GetRed() / 1.1), (int) (color.GetGreen() / 1.1),
                    (int) (color.GetBlue() / 1.1)));
                G.DrawRoundRect(390 - image.GetWidth(null) / 2, i - 2, image.GetWidth(null) + 20,
                    image.GetHeight(null) + 2, 7, 20);
            }
            G.DrawImage(image, 400 - image.GetWidth(null) / 2, i);
        }

        public static void Drawlprom(int i, int i140)
        {
            G.SetAlpha(0.5F);
            G.SetColor(new Color(129, 203, 237));
            G.FillRoundRect(277, i, 390, i140, 30, 30);
            G.SetColor(new Color(0, 0, 0));
            G.DrawRoundRect(277, i, 390, i140, 30, 30);
            G.SetAlpha(1.0F);
        }

        public static void Drawprom(int i, int i138)
        {
            G.SetAlpha(0.76F);
            G.SetColor(new Color(129, 203, 237));
            G.FillRoundRect(205, i, 390, i138, 30, 30);
            G.SetColor(new Color(0, 0, 0));
            G.DrawRoundRect(205, i, 390, i138, 30, 30);
            G.SetAlpha(1.0F);
        }

        internal static void DrawSmokeCarsbg()
        {
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
            G.DrawImage(Carsbg, 65, 25);
            Flatrstart++;
//        }
        }

        internal static void Drawstat(int i, int i206, float f)
        {
            var ais = new int[4];
            var is207 = new int[4];
            if (i206 > i)
            {
                i206 = i;
            }
            var i208 = (int) (98.0F * (i206 / (float) i));
            ais[0] = 662;
            is207[0] = 11;
            ais[1] = 662;
            is207[1] = 20;
            ais[2] = 662 + i208;
            is207[2] = 20;
            ais[3] = 662 + i208;
            is207[3] = 11;
            var i209 = 244;
            var i210 = 244;
            var i211 = 11;
            if (i208 > 33)
            {
                i210 = (int) (244.0F - 233.0F * ((i208 - 33) / 65.0F));
            }
            if (i208 > 70)
            {
                if (Dmcnt < 10)
                {
                    if (Dmflk)
                    {
                        i210 = 170;
                        Dmflk = false;
                    }
                    else
                    {
                        Dmflk = true;
                    }
                }

                Dmcnt++;
                if (Dmcnt > 167.0 - i208 * 1.5)
                {
                    Dmcnt = 0;
                }
            }
            i209 += (int) (i209 * (Medium.Snap[0] / 100.0F));
            if (i209 > 255)
            {
                i209 = 255;
            }
            if (i209 < 0)
            {
                i209 = 0;
            }
            i210 += (int) (i210 * (Medium.Snap[1] / 100.0F));
            if (i210 > 255)
            {
                i210 = 255;
            }
            if (i210 < 0)
            {
                i210 = 0;
            }
            i211 += (int) (i211 * (Medium.Snap[2] / 100.0F));
            if (i211 > 255)
            {
                i211 = 255;
            }
            if (i211 < 0)
            {
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
            if (f == 98.0F)
            {
                i209 = 64;
            }
            i210 = (int) (190.0 + f * 0.37);
            i211 = 244;
            if (Auscnt < 45 && Aflk)
            {
                i209 = 128;
                i210 = 244;
                i211 = 244;
            }
            i209 += (int) (i209 * (Medium.Snap[0] / 100.0F));
            if (i209 > 255)
            {
                i209 = 255;
            }
            if (i209 < 0)
            {
                i209 = 0;
            }
            i210 += (int) (i210 * (Medium.Snap[1] / 100.0F));
            if (i210 > 255)
            {
                i210 = 255;
            }
            if (i210 < 0)
            {
                i210 = 0;
            }
            i211 += (int) (i211 * (Medium.Snap[2] / 100.0F));
            if (i211 > 255)
            {
                i211 = 255;
            }
            if (i211 < 0)
            {
                i211 = 0;
            }
            G.SetColor(new Color(i209, i210, i211));
            G.FillPolygon(ais, is207, 4);
        }

        static void DrawWarning()
        {
            G.SetColor(new Color(0, 0, 0));
            G.FillRect(0, 0, 800, 450);
            G.SetFont(new Font("Arial", 1, 22));
            Ftm = G.GetFontMetrics();
            Drawcs(100, "Warning!", 255, 0, 0, 3);
            G.SetFont(new Font("Arial", 1, 18));
            Ftm = G.GetFontMetrics();
            Drawcs(150, "Bad language and flooding ais strictly prohibited ain this game!", 255, 255, 255, 3);
            G.SetFont(new Font("Arial", 1, 13));
            Ftm = G.GetFontMetrics();
            if (Warning < 210)
            {
                Drawcs(200, "If you continue typing bad language or flooding your game will shut down.", 200, 200, 200,
                    3);
            }
            if (Warning > 210)
            {
                Drawcs(200, "Sorry. This was your second warring your game has shut down.", 200, 200, 200, 3);
            }
            if (Warning > 250)
            {
                Stopallnow();
                Runtyp = 0;
                //app.repaint();
                HansenSystem.Exit(0);
                //app.gamer.interrupt();
            }
        }

        internal static void Finish(ContO[] contos, Control control, int i, int i141, bool abool)
        {
            /*if (chronostart) {
                chrono.stop();
                chronostart = false;
            }*/
            if (!Badmac)
            {
                G.DrawImage(Fleximg, 0, 0);
            }
            else
            {
                G.SetColor(new Color(0, 0, 0, (int) (255 * 0.1f)));
                G.FillRect(0, 0, 800, 450);
            }
            G.SetFont(new Font("Arial", 1, 11));
            Ftm = G.GetFontMetrics();
            var i142 = 0;
            var astring = ":";
            if (CheckPoints.Stage > 0)
            {
                var i143 = CheckPoints.Stage;
                //if (i143 > 10)
                //	i143 -= 10;
                astring = " " + i143 + "!";
            }
            if (Multion < 3)
            {
                if (Winner)
                {
                    G.DrawImage(Congrd, 265, 87);
                    Drawcs(137, "You Won!  At Stage" + astring, 255, 161, 85, 3);
                    Drawcs(154, CheckPoints.Name, 255, 115, 0, 3);
                    i142 = 154;
                }
                else
                {
                    G.DrawImage(Gameov, 315, 117);
                    if (Multion != 0 && (Forstart == 700 || Discon == 240))
                    {
                        Drawcs(167, "Sorry, You where Disconnected from Game!", 255, 161, 85, 3);
                        Drawcs(184, "Please check your connection!", 255, 115, 0, 3);
                    }
                    else
                    {
                        Drawcs(167, "You Lost!  At Stage" + astring, 255, 161, 85, 3);
                        Drawcs(184, CheckPoints.Name, 255, 115, 0, 3);
                        i142 = 184;
                    }
                }
                G.SetColor(new Color(193, 106, 0));
            }
            else
            {
                G.DrawImage(Gameov, 315, 117);
                Drawcs(167, "Finished Watching Game!  At Stage" + astring + "", 255, 161, 85, 3);
                Drawcs(184, CheckPoints.Name, 255, 115, 0, 3);
                i142 = 184;
            }
            if (Winner && Multion == 0 && Gmode != 0 &&
                (CheckPoints.Stage == Unlocked /*+ (gmode - 1) * 10*/ || CheckPoints.Stage == NTracks))
            {
                var i144 = 0;
                var i145 = 0;
                Pin = 60;
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
                if (Gmode == 2)
                {
                    if (CheckPoints.Stage == 2)
                    {
                        i144 = 8;
                        i145 = 365;
                        Pin = -20;
                        Scm = 8;
                    }
                    if (CheckPoints.Stage == 4)
                    {
                        i144 = 9;
                        i145 = 320;
                        Pin = -20;
                        Scm = 9;
                    }
                    if (CheckPoints.Stage == 6)
                    {
                        i144 = 10;
                        i145 = 370;
                        Pin = -20;
                        Scm = 10;
                    }
                    if (CheckPoints.Stage == 8)
                    {
                        i144 = 11;
                        i145 = 326;
                        Pin = -20;
                        Scm = 11;
                    }
                    if (CheckPoints.Stage == 10)
                    {
                        i144 = 12;
                        i145 = 310;
                        Pin = -20;
                        Scm = 12;
                    }
                    if (CheckPoints.Stage == 12)
                    {
                        i144 = 13;
                        i145 = 310;
                        Pin = -20;
                        Scm = 13;
                    }
                    if (CheckPoints.Stage == 14)
                    {
                        i144 = 14;
                        i145 = 350;
                        Pin = -20;
                        Scm = 14;
                    }
                    if (CheckPoints.Stage == 16)
                    {
                        i144 = 15;
                        i145 = 370;
                        Pin = -20;
                        Scm = 15;
                    }
                }
                if (CheckPoints.Stage != NTracks)
                {
                    G.SetFont(new Font("Arial", 1, 13));
                    Ftm = G.GetFontMetrics();
                    if (Aflk)
                    {
                        Drawcs(200 + Pin, "Stage " + (CheckPoints.Stage + 1) + " ais now unlocked!", 196, 176, 0, 3);
                    }
                    else
                    {
                        Drawcs(200 + Pin, "Stage " + (CheckPoints.Stage + 1) + " ais now unlocked!", 255, 247, 165, 3);
                    }
                    if (i144 != 0)
                    {
                        if (Aflk)
                        {
                            Drawcs(200, "And:", 196, 176, 0, 3);
                        }
                        else
                        {
                            Drawcs(200, "And:", 255, 247, 165, 3);
                        }
                        G.SetColor(new Color(236, 226, 202));
                        if (HansenRandom.Double() > 0.5)
                        {
                            G.SetAlpha(0.5F);
                            G.FillRect(226, 211, 344, 125);
                            G.SetAlpha(1.0F);
                        }
                        G.SetColor(new Color(0, 0, 0));
                        G.FillRect(226, 211, 348, 4);
                        G.FillRect(226, 211, 4, 125);
                        G.FillRect(226, 332, 348, 4);
                        G.FillRect(570, 211, 4, 125);
                        contos[i144].Y = i145;
                        Medium.Crs = true;
                        Medium.X = -400;
                        Medium.Y = 0;
                        Medium.Z = -50;
                        Medium.Xz = 0;
                        Medium.Zy = 0;
                        Medium.Ground = 2470;
                        contos[i144].Z = 1000;
                        contos[i144].X = 0;
                        contos[i144].Xz += 5;
                        contos[i144].Zy = 0;
                        contos[i144].Wzy -= 10;
                        contos[i144].D();
                        if (HansenRandom.Double() < 0.5)
                        {
                            G.SetAlpha(0.4F);
                            G.SetColor(new Color(236, 226, 202));
                            for (var i146 = 0; i146 < 30; i146++)
                            {
                                G.DrawLine(230, 215 + 4 * i146, 569, 215 + 4 * i146);
                            }
                            G.SetAlpha(1.0F);
                        }
                        var string147 = "";
                        if (i144 == 13)
                        {
                            string147 = " ";
                        }
                        if (Aflk)
                        {
                            Drawcs(320, "" + CarDefine.Names[i144] + "" + string147 + " has been unlocked!", 196, 176,
                                0, 3);
                        }
                        else
                        {
                            Drawcs(320, "" + CarDefine.Names[i144] + "" + string147 + " has been unlocked!", 255, 247,
                                165, 3);
                        }
                        Pin = 140;
                    }
                    G.SetFont(new Font("Arial", 1, 11));
                    Ftm = G.GetFontMetrics();
                    Drawcs(220 + Pin, "GAME SAVED", 230, 167, 0, 3);
                    if (Pin == 60)
                    {
                        Pin = 30;
                    }
                    else
                    {
                        Pin = 0;
                    }
                }
                else
                {
                    G.SetFont(new Font("Arial", 1, 13));
                    Ftm = G.GetFontMetrics();
                    if (Aflk)
                    {
                        Drawcs(180, "Woohoooo you finished NFM" + Gmode + " !!!", 144, 167, 255, 3);
                    }
                    else
                    {
                        Drawcs(180, "Woohoooo you finished NFM" + Gmode + " !!!", 228, 240, 255, 3);
                    }
                    if (Aflk)
                    {
                        Drawcs(210, "You're Awesome!", 144, 167, 255, 3);
                    }
                    else
                    {
                        Drawcs(212, "You're Awesome!", 228, 240, 255, 3);
                    }
                    if (Aflk)
                    {
                        Drawcs(240, "You're truly a RADICAL GAMER!", 144, 167, 255, 3);
                    }
                    else
                    {
                        Drawcs(240, "You're truly a RADICAL GAMER!", 255, 100, 100, 3);
                    }
                    G.SetColor(new Color(0, 0, 0));
                    G.FillRect(0, 255, 800, 62);
                    G.DrawImage(Radicalplay, Radpx + (int) (8.0 * HansenRandom.Double() - 4.0), 255);
                    if (Radpx != 212)
                    {
                        Radpx += 40;
                        if (Radpx > 800)
                        {
                            Radpx = -468;
                        }
                    }
                    if (Flipo == 40)
                    {
                        Radpx = 213;
                    }
                    Flipo++;
                    if (Flipo == 70)
                    {
                        Flipo = 0;
                    }
                    if (Radpx == 212)
                    {
                        G.SetFont(new Font("Arial", 1, 11));
                        Ftm = G.GetFontMetrics();
                        if (Aflk)
                        {
                            Drawcs(309, "A Game by Radicalplay.com", 144, 167, 255, 3);
                        }
                        else
                        {
                            Drawcs(309, "A Game by Radicalplay.com", 228, 240, 255, 3);
                        }
                    }
                    if (Aflk)
                    {
                        Drawcs(350, "Now get up and dance!", 144, 167, 255, 3);
                    }
                    else
                    {
                        Drawcs(350, "Now get up and dance!", 228, 240, 255, 3);
                    }
                    Pin = 0;
                }
                Aflk = !Aflk;
            }
            if (Multion != 0 && CheckPoints.Stage == -2 && i142 != 0)
            {
                Drawcs(i142 + 17, "Created by: " + CheckPoints.Maker + "", 255, 161, 85, 3);
                if (CheckPoints.Pubt > 0)
                {
                    if (CheckPoints.Pubt == 2)
                    {
                        Drawcs(310, "Super Public Stage", 41, 177, 255, 3);
                    }
                    else
                    {
                        Drawcs(310, "Public Stage", 41, 177, 255, 3);
                    }
                    if (Dnload == 0 && Drawcarb(true, null, " Add to My Stages ", 334, 317, i, i141, abool))
                    {
                        if (Logged)
                        {
                            CarDefine.Onstage = CheckPoints.Name;
                            CarDefine.Staction = 2;
//                        CarDefine.sparkstageaction();
                            Dnload = 2;
                        }
                        else
                        {
                            Dnload = 1;
                            Waitlink = 20;
                        }
                    }

                    if (Dnload == 1)
                    {
                        G.SetColor(new Color(193, 106, 0));
                        var string148 = "Upgrade to a full account to add custom stages!";
                        var i149 = 400 - Ftm.StringWidth(string148) / 2;
                        var i150 = i149 + Ftm.StringWidth(string148);
                        G.DrawString(string148, i149, 332);
                        if (Waitlink != -1)
                        {
                            G.DrawLine(i149, 334, i150, 334);
                        }
                        if (i > i149 && i < i150 && i141 > 321 && i141 < 334)
                        {
                            if (Waitlink != -1)
                            {
                                //app.setCursor(new Cursor(12));
                            }
                            if (abool && Waitlink == 0)
                            {
                                GameSparker.Editlink(Nickname, true);
                                Waitlink = -1;
                            }
                        }
                        if (Waitlink > 0)
                        {
                            Waitlink--;
                        }
                    }
                    if (Dnload == 2)
                    {
                        Drawcs(332, "Adding stage please wait...", 193, 106, 0, 3);
                        if (CarDefine.Staction == 0)
                        {
                            Dnload = 3;
                        }
                        if (CarDefine.Staction == -2)
                        {
                            Dnload = 4;
                        }
                        if (CarDefine.Staction == -3)
                        {
                            Dnload = 5;
                        }
                        if (CarDefine.Staction == -1)
                        {
                            Dnload = 6;
                        }
                    }
                    if (Dnload == 3)
                    {
                        Drawcs(332, "Stager has been successfully added to your stages!", 193, 106, 0, 3);
                    }
                    if (Dnload == 4)
                    {
                        Drawcs(332, "You already have this stage!", 193, 106, 0, 3);
                    }
                    if (Dnload == 5)
                    {
                        Drawcs(332, "Cannot add more then 20 stages to your account!", 193, 106, 0, 3);
                    }
                    if (Dnload == 6)
                    {
                        Drawcs(332, "Failed to add stage, unknown error, please try again later.", 193, 106, 0, 3);
                    }
                }
                else
                {
                    Drawcs(342, "Private Stage", 193, 106, 0, 3);
                }
            }
            G.DrawImage(Contin[Pcontin], 355, 380);
            if (control.Enter || control.Handb)
            {
                if (Loadedt)
                {
                    Strack.Unload();
                }
                if (Multion == 0)
                {
                    Opselect = 3;
                    /*if (gmode == 1) {
                        opselect = 0;
                        if (winner && checkpoints.stage == unlocked[gmode - 1] + (gmode - 1) * 10
                                && checkpoints.stage != 27) {
                            unlocked[gmode - 1]++;
                            justwon1 = true;
                        } else
                            justwon1 = false;
                    }*/
                    if (Gmode == 2)
                    {
                        Opselect = 1;
                        if (Winner && CheckPoints.Stage == Unlocked /* + (gmode - 1) * 10*/
                            && CheckPoints.Stage != NTracks)
                        {
                            Unlocked++;
                            Justwon2 = true;
                        }
                        else
                        {
                            Justwon2 = false;
                        }
                    }
                    if (CheckPoints.Stage == NTracks && Gmode == 0)
                    {
                        CheckPoints.Stage = (int) (HansenRandom.Double() * NTracks) + 1;
                    }
                    Fase = 102;
                }
                else if (CarDefine.Haltload == 1)
                {
                    Sc[0] = 36;
                    Fase = 1177;
                }
                else if (!Mtop || Nfreeplays >= 5 && !Logged)
                {
                    Opselect = 2;
                    Fase = 102;
                }
                else
                {
                    Fase = -9;
                }
                if (Multion == 0 && Winner && CheckPoints.Stage != NTracks && CheckPoints.Stage > 0)
                {
                    CheckPoints.Stage++;
                }
                if (!Winner && Multion != 0 && (Forstart == 700 || Discon == 240) && Ndisco < 5)
                {
                    Ndisco++;
                }
                Flipo = 0;
                control.Enter = false;
                control.Handb = false;
            }
        }

        internal static void Fleximage(Image image, int i)
        {
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

        internal static Image GetImage(string astring)
        {
            return ImageIo.Read(new File(astring));
        }

        internal static string GetSvalue(string astring, int i)
        {
            var string443 = "";
            try
            {
                var i444 = 0;
                var i445 = 0;
                var i446 = 0;
                string string447;
                var string448 = "";
                for (; i444 < astring.Length() && i446 != 2; i444++)
                {
                    string447 = "" + astring.CharAt(i444);
                    if (string447.Equals("|"))
                    {
                        i445++;
                        if (i446 == 1 || i445 > i)
                        {
                            i446 = 2;
                        }
                    }
                    else if (i445 == i)
                    {
                        string448 = "" + string448 + string447;
                        i446 = 1;
                    }
                }
                string443 = string448;
            }
            catch (Exception ignored)
            {
                Console.WriteLine(ignored);
            }
            return string443;
        }

        internal static int Getvalue(string astring, int i)
        {
            var i437 = -1;
            try
            {
                var i438 = 0;
                var i439 = 0;
                var i440 = 0;
                string string441;
                var string442 = "";
                for (; i438 < astring.Length() && i440 != 2; i438++)
                {
                    string441 = "" + astring.CharAt(i438);
                    if (string441.Equals("|"))
                    {
                        i439++;
                        if (i440 == 1 || i439 > i)
                        {
                            i440 = 2;
                        }
                    }
                    else if (i439 == i)
                    {
                        string442 = "" + string442 + string441;
                        i440 = 1;
                    }
                }
                if (string442.Equals(""))
                {
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

        internal static void Gscrape(int im, int i, int i269, int i270)
        {
            if ((Bfsc1[im] == 0 || Bfsc2[im] == 0) && Math.Sqrt(i * i + i269 * i269 + i270 * i270) / 10.0 > 15.0)
            {
                if (Bfsc1[im] == 0)
                {
                    if (!Mutes)
                    {
                        Scrape[2].Stop();
                        Scrape[2].Play();
                    }
                    Bfsc1[im] = 12;
                    Bfsc2[im] = 6;
                }
                else
                {
                    if (!Mutes)
                    {
                        Scrape[3].Stop();
                        Scrape[3].Play();
                    }
                    Bfsc2[im] = 12;
                    Bfsc1[im] = 6;
                }
            }
        }

        internal static void Hidos()
        {
            //app.snfm1.setVisible(false);
            //app.snfm2.setVisible(false);
            GameSparker.Mstgs.SetVisible(false);
        }

        internal static void Hipnoload(int i, bool abool)
        {
            int[] ais =
            {
                Medium.Snap[0], Medium.Snap[1], Medium.Snap[2]
            };
            while (ais[0] + ais[1] + ais[2] < -30)
            {
                for (var i45 = 0; i45 < 3; i45++)
                {
                    if (ais[i45] < 50)
                    {
                        ais[i45]++;
                    }
                }
            }
            var i46 = (int) (230.0F - 230.0F * (ais[0] / 100.0F));
            if (i46 > 255)
            {
                i46 = 255;
            }
            if (i46 < 0)
            {
                i46 = 0;
            }
            var i47 = (int) (230.0F - 230.0F * (ais[1] / 100.0F));
            if (i47 > 255)
            {
                i47 = 255;
            }
            if (i47 < 0)
            {
                i47 = 0;
            }
            var i48 = (int) (230.0F - 230.0F * (ais[2] / 100.0F));
            if (i48 > 255)
            {
                i48 = 255;
            }
            if (i48 < 0)
            {
                i48 = 0;
            }
            G.SetColor(new Color(i46, i47, i48));
            G.FillRect(65, 25, 670, 400);
            G.SetAlpha(0.3F);
            G.DrawImage(Bggo, 0, -25);
            G.SetAlpha(1.0F);
            G.SetColor(new Color(0, 0, 0));
            G.FillRect(0, 0, 65, 450);
            G.FillRect(735, 0, 65, 450);
            G.FillRect(65, 0, 670, 25);
            G.FillRect(65, 425, 670, 25);
            G.SetFont(new Font("Arial", 1, 13));
            Ftm = G.GetFontMetrics();
            Drawcs(50, Asay, 0, 0, 0, 3);
            var i49 = -90;
            if (Multion == 0)
            {
                if (i == 1 || i == 2 || i == 3 || i == 4 || i == 5 || i == 10)
                {
                    i49 = 0;
                }
                if (i == 11 || i == 12 || i == 13 || i == 14 || i == 17 || i == 18 || i == 19 || i == 20 || i == 22 ||
                    i == 23 || i == 26)
                {
                    i49 = 0;
                }
                if (i < 0 && Nplayers != 1 && Newparts)
                {
                    i49 = 0;
                }
            }
            else if (Ransay == 1 || Ransay == 2 || Ransay == 3 || Ransay == 4 || i == 10)
            {
                i49 = 0;
            }
            if (i49 == 0)
            {
                if (Dudo > 0)
                {
                    if (Aflk)
                    {
                        if (HansenRandom.Double() > HansenRandom.Double())
                        {
                            Duds = (int) (HansenRandom.Double() * 3.0);
                        }
                        else
                        {
                            Duds = (int) (HansenRandom.Double() * 2.0);
                        }
                        Aflk = false;
                    }
                    else
                    {
                        Aflk = true;
                    }
                    Dudo--;
                }
                else
                {
                    Duds = 0;
                }
                G.SetAlpha(0.3F);
                G.DrawImage(Dude[Duds], 95, 35);
                G.SetAlpha(0.7F);
                G.DrawImage(Flaot, 192, 67);
                G.SetAlpha(1.0F);
                i46 = (int) (80.0F - 80.0F * (ais[0] / 100.0F));
                if (i46 > 255)
                {
                    i46 = 255;
                }
                if (i46 < 0)
                {
                    i46 = 0;
                }
                i47 = (int) (80.0F - 80.0F * (ais[1] / 100.0F));
                if (i47 > 255)
                {
                    i47 = 255;
                }
                if (i47 < 0)
                {
                    i47 = 0;
                }
                i48 = (int) (80.0F - 80.0F * (ais[2] / 100.0F));
                if (i48 > 255)
                {
                    i48 = 255;
                }
                if (i48 < 0)
                {
                    i48 = 0;
                }
                G.SetColor(new Color(i46, i47, i48));
                G.SetFont(new Font("Arial", 1, 13));
                if (Multion != 0)
                {
                    if (Ransay == 1 && i != 10)
                    {
                        G.DrawString("Multiplayer Tip:  Press [ C ] to access chat quickly during the game!", 262, 92);
                    }
                    if (Ransay == 2 && i != 10)
                    {
                        G.DrawString("Multiplayer Tip:  Press [ A ] to make Guidance Arrow point to cars and", 262, 92);
                        G.DrawString("click any of the players listed on the right to lock the Arrow on!", 262, 112);
                    }
                    if (Ransay == 3 && i != 10)
                    {
                        G.DrawString("Multiplayer Tip:  When wasting ain multiplayer it's better to aim slightly", 262,
                            92);
                        G.DrawString("ahead of the other player's car to compensate for internet delay.", 262, 112);
                    }
                    if (Ransay == 4)
                    {
                        G.DrawString("When watching a game, click any player listed on the right of the", 262, 92);
                        G.DrawString("screen to follow and watch.", 262, 112);
                        G.DrawString("Press [ V ] to change the viewing mode!", 262, 132);
                    }
                    if (i == 10 && Ransay != 4)
                    {
                        if (Tflk)
                        {
                            G.SetColor(new Color(200, i47, i48));
                            Tflk = false;
                        }
                        else
                        {
                            Tflk = true;
                        }
                        G.DrawString("NOTE: Guidance Arrow and opponent status ais disabled ain this stage!", 262, 92);
                    }
                }
                else
                {
                    if (i < 0 && Nplayers != 1 && Newparts)
                    {
                        G.DrawString("Please note, the computer car's AI has not yet been trained to handle", 262, 92);
                        G.DrawString("some of the new stage parts such as the 'Rollercoaster Road' and the", 262, 112);
                        G.DrawString("'Tunnel Side Ramp'.", 262, 132);
                        G.DrawString("(Those new parts where mostly designed for the multiplayer game.)", 262, 152);
                        G.DrawString("The AI will be trained and ready ain the future releases of the game!", 262, 172);
                    }
                    if (i == 1 || i == 11)
                    {
                        G.DrawString("Hey!  Don't forget, to complete a lap you must pass through", 262, 92);
                        G.DrawString("all checkpoints ain the track!", 262, 112);
                    }
                    if (i == 2 || i == 12)
                    {
                        G.DrawString("Remember, the more power you have the faster your car will be!", 262, 92);
                    }
                    if (i == 3)
                    {
                        G.DrawString("> Hint: its easier to waste the other cars then to race ain this stage!", 262,
                            92);
                        G.DrawString("Press [ A ] to make the guidance arrow point to cars instead of to", 262, 112);
                        G.DrawString("the track.", 262, 132);
                    }
                    if (i == 4)
                    {
                        G.DrawString("Remember, the better the stunt you perform the more power you get!", 262, 92);
                    }
                    if (i == 5)
                    {
                        G.DrawString("Remember, the more power you have the stronger your car ais!", 262, 92);
                    }
                    if (i == 10)
                    {
                        if (Tflk)
                        {
                            G.SetColor(new Color(200, i47, i48));
                            Tflk = false;
                        }
                        else
                        {
                            Tflk = true;
                        }
                        G.DrawString("NOTE: Guidance Arrow ais disabled ain this stage!", 262, 92);
                    }
                    if (i == 13)
                    {
                        G.DrawString("Watch aout!  Look aout!  The policeman might be aout to get you!", 262, 92);
                        G.DrawString("Don't upset him or you'll be arrested!", 262, 112);
                        G.DrawString("Better run, run, run.", 262, 152);
                    }
                    if (i == 14)
                    {
                        G.DrawString("Don't waste your time.  Waste them instead!", 262, 92);
                        G.DrawString("Try a taste of sweet revenge here (if you can)!", 262, 112);
                        G.DrawString("Press [ A ] to make the guidance arrow point to cars instead of to", 262, 152);
                        G.DrawString("the track.", 262, 172);
                    }
                    if (i == 17)
                    {
                        G.DrawString("Welcome to the realm of the king...", 262, 92);
                        G.DrawString("The key word here ais 'POWER'.  The more you have of it the faster", 262, 132);
                        G.DrawString("and STRONGER you car will be!", 262, 152);
                    }
                    if (i == 18)
                    {
                        G.DrawString("Watch aout, EL KING ais aout to get you now!", 262, 92);
                        G.DrawString("He seems to be seeking revenge?", 262, 112);
                        G.DrawString("(To fly longer distances ain the air try drifting your car on the ramp", 262,
                            152);
                        G.DrawString("before take off).", 262, 172);
                    }
                    if (i == 19)
                    {
                        G.DrawString("It\u2019s good to be the king!", 262, 92);
                    }
                    if (i == 20)
                    {
                        G.DrawString("Remember, forward loops give your car a push forwards ain the air", 262, 92);
                        G.DrawString("and help ain racing.", 262, 112);
                        G.DrawString("(You may need to do more forward loops here.  Also try keeping", 262, 152);
                        G.DrawString("your power at maximum at all times.  Try not to miss a ramp).", 262, 172);
                    }
                    if (i == 22)
                    {
                        G.DrawString("Watch aout!  Beware!  Take care!", 262, 92);
                        G.DrawString("MASHEEN ais hiding aout there some where, don't get mashed now!", 262, 112);
                    }
                    if (i == 23)
                    {
                        G.DrawString("Anyone for a game of Digger?!", 262, 92);
                        G.DrawString("You can have fun using MASHEEN here!", 262, 112);
                    }
                    if (i == 26)
                    {
                        G.DrawString("This ais it!  This ais the toughest stage ain the game!", 262, 92);
                        G.DrawString("This track ais actually a 4D object projected onto the 3D world.", 262, 132);
                        G.DrawString("It's been broken down, separated and, ain many ways, it ais also a", 262, 152);
                        G.DrawString("maze!  GOOD LUCK!", 262, 172);
                    }
                }
            }
            G.SetAlpha(0.8F);
            G.DrawImage(Loadingmusic, 289, 205 + i49);
            G.SetAlpha(1.0F);
            G.SetFont(new Font("Arial", 1, 11));
            Ftm = G.GetFontMetrics();
            var i50 = i - 1;
            if (i50 < 0)
            {
            }
            if (!abool)
            {
                //unnecessary
                //drawcs(340 + i49, "" + ("") + (sndsize[i50]) + (" KB"), 0, 0, 0,
                //		3);
                Drawcs(375 + i49, " Please Wait...", 0, 0, 0, 3);
            }
            else
            {
                Drawcs(365 + i49, "Loading complete!  Press Start to begin...", 0, 0, 0, 3);
                G.SetAlpha(0.5F);
                G.DrawImage(Star[Pstar], 359, 385 + i49);
                G.SetAlpha(1.0F);
                if (Pstar != 2)
                {
                    if (Pstar == 0)
                    {
                        Pstar = 1;
                    }
                    else
                    {
                        Pstar = 0;
                    }
                }

                if (Multion != 0)
                {
                    Drawcs(380 + i49, "" + Forstart / 20, 0, 0, 0, 3);
                }
            }
        }

        internal static void Inishcarselect(ContO[] cars)
        {
            Nplayers = 7;
            Im = 0;
            Xstart[0] = 0;
            Xstart[1] = -350;
            Xstart[2] = 350;
            Xstart[3] = 0;
            Xstart[4] = -350;
            Xstart[5] = 350;
            Xstart[6] = 0;
            Zstart[0] = -760;
            Zstart[1] = -380;
            Zstart[2] = -380;
            Zstart[3] = 0;
            Zstart[4] = 380;
            Zstart[5] = 380;
            Zstart[6] = 760;
            Onmsc = -1;
            Remi = false;
            if (Testdrive != 1 && Testdrive != 2)
            {
                if (Gmode != 0)
                {
                    Cfase = 0;
                    Sc[0] = Scm;
                }
                if (Gmode == 0)
                {
                    Sc[0] = Osc;
                }
                if (CarDefine.Lastload != 1 || Cfase != 3)
                {
                    Onmsc = Sc[0];
                }
                if (Cfase == 0 && Sc[0] > NCars - 1)
                {
                    Sc[0] = NCars - 1;
                    if (Multion != 0)
                    {
                        Cfase = -1;
                    }
                }
                if (Onjoin != -1 && Multion != 0)
                {
                    if (Ontyp <= -2)
                    {
                        Cfase = 0;
                    }
                    if (Ontyp >= 20)
                    {
                        Ontyp -= 20;
                        Cfase = 0;
                    }
                    if (Ontyp >= 10)
                    {
                        Ontyp -= 10;
                        if (CarDefine.Lastload != 2)
                        {
                            Cfase = -1;
                            Onjoin = -1;
                        }
                        else
                        {
                            Cfase = 3;
                        }
                    }
                }
                if (Cfase == 11 || Cfase == 101)
                {
                    if (Sc[0] >= 16 && CarDefine.Lastload == 2 && Sc[0] < 36)
                    {
                        Cfase = 3;
                    }
                    else
                    {
                        Cfase = 0;
                    }
                }

                if (Cfase == 3)
                {
                    if (Multion != 0 && CarDefine.Lastload == 1)
                    {
                        Sc[0] = NCars - 1;
                        Minsl = 0;
                        Maxsl = NCars - 1;
                        Cfase = 0;
                    }
                    if (CarDefine.Lastload == 0)
                    {
                        Sc[0] = NCars - 1;
                        Minsl = 0;
                        Maxsl = NCars - 1;
                        Cfase = 0;
                    }
                    if (CarDefine.Lastload == 2)
                    {
                        Minsl = NCars;
                        Maxsl = CarDefine.Nlocars - 1;
                        if (Sc[0] < Minsl)
                        {
                            Sc[0] = Minsl;
                        }
                        if (Sc[0] > Maxsl)
                        {
                            Sc[0] = Maxsl;
                        }
                        if (Onjoin != -1 && Multion != 0 && Ontyp > 0 && Ontyp <= 5)
                        {
                            var abool = false;
                            for (var i = NCars; i < CarDefine.Nlocars; i++)
                            {
                                if (Math.Abs(CarDefine.Cclass[i] - (Ontyp - 1)) <= 1)
                                {
                                    if (!abool)
                                    {
                                        Minsl = i;
                                        abool = true;
                                    }
                                    if (abool)
                                    {
                                        Maxsl = i;
                                    }
                                }
                            }

                            if (!abool)
                            {
                                Onjoin = -1;
                            }
                            else
                            {
                                if (Sc[0] < Minsl)
                                {
                                    Sc[0] = Minsl;
                                }
                                if (Sc[0] > Maxsl)
                                {
                                    Sc[0] = Maxsl;
                                }
                                if (Math.Abs(CarDefine.Cclass[Sc[0]] - (Ontyp - 1)) > 1)
                                {
                                    Sc[0] = Minsl;
                                }
                            }
                        }
                    }
                    if (CarDefine.Lastload == -2 && Logged)
                    {
                        Cfase = 5;
                        Showtf = false;
                        CarDefine.Action = 3;
                    }
                }
                if (Cfase == 0)
                {
                    Minsl = 0;
                    Maxsl = NCars - 1;
                    if (Onjoin != -1 && Multion != 0)
                    {
                        if (Ontyp == 1)
                        {
                            Minsl = 0;
                            Maxsl = 5;
                        }
                        if (Ontyp == 2)
                        {
                            Minsl = 0;
                            Maxsl = 9;
                        }
                        if (Ontyp == 3)
                        {
                            Minsl = 5;
                            Maxsl = 10;
                        }
                        if (Ontyp == 4)
                        {
                            Minsl = 6;
                            Maxsl = 15; //maybe ncars - 1
                        }
                        if (Ontyp == 5)
                        {
                            Minsl = 10;
                            Maxsl = 15; //maybe ncars - 1
                        }
                        if (Ontyp <= -2)
                        {
                            Minsl = Math.Abs(Ontyp + 2);
                            Maxsl = Math.Abs(Ontyp + 2);
                        }
                    }
                    if (Sc[0] < Minsl)
                    {
                        Sc[0] = Minsl;
                    }
                    if (Sc[0] > Maxsl)
                    {
                        Sc[0] = Maxsl;
                    }
                }
            }
            else
            {
                Minsl = Sc[0];
                Maxsl = Sc[0];
            }
            GameSparker.Mcars.SetBackground(new Color(0, 0, 0));
            GameSparker.Mcars.SetForeground(new Color(47, 179, 255));
            GameSparker.Mcars.Alphad = true;
            GameSparker.Mcars.Carsel = true;
            Carsbginflex();
            Flatrstart = 0;
            Medium.Lightson = false;
            Pnext = 0;
            Pback = 0;
            Lsc = -1;
            Mouson = -1;
            if (Multion == 0)
            {
                var i = 16;
                if (CarDefine.Lastload == 2)
                {
                    i = CarDefine.Nlocars;
                }
                for (var i100 = 0; i100 < i; i100++)
                {
                    var fs = new float[3];
                    Color.RGBtoHSB(cars[i100].Fcol[0], cars[i100].Fcol[1], cars[i100].Fcol[2], fs);
                    for (var i101 = 0; i101 < cars[i100].Npl; i101++)
                    {
                        if (cars[i100].P[i101].Colnum == 1)
                        {
                            cars[i100].P[i101].HSB[0] = fs[0];
                            cars[i100].P[i101].HSB[1] = fs[1];
                            cars[i100].P[i101].HSB[2] = fs[2];
                            cars[i100].P[i101].Oc[0] = cars[i100].Fcol[0];
                            cars[i100].P[i101].Oc[1] = cars[i100].Fcol[1];
                            cars[i100].P[i101].Oc[2] = cars[i100].Fcol[2];
                        }
                    }

                    Color.RGBtoHSB(cars[i100].Scol[0], cars[i100].Scol[1], cars[i100].Scol[2], fs);
                    for (var i102 = 0; i102 < cars[i100].Npl; i102++)
                    {
                        if (cars[i100].P[i102].Colnum == 2)
                        {
                            cars[i100].P[i102].HSB[0] = fs[0];
                            cars[i100].P[i102].HSB[1] = fs[1];
                            cars[i100].P[i102].HSB[2] = fs[2];
                            cars[i100].P[i102].Oc[0] = cars[i100].Scol[0];
                            cars[i100].P[i102].Oc[1] = cars[i100].Scol[1];
                            cars[i100].P[i102].Oc[2] = cars[i100].Scol[2];
                        }
                    }

                    cars[i100].Xy = 0;
                }
                for (var i103 = 0; i103 < 6; i103++)
                {
                    Arnp[i103] = -1.0F;
                }
            }
            Medium.Trk = 0;
            Medium.Crs = true;
            Medium.X = -400;
            Medium.Y = -525;
            Medium.Z = -50;
            Medium.Xz = 0;
            Medium.Zy = 10;
            Medium.Ground = 495;
            Medium.Ih = 0;
            Medium.Iw = 0;
            Medium.H = 450;
            Medium.W = 800;
            Medium.FocusPoint = 400;
            Medium.Cx = 400;
            Medium.Cy = 225;
            Medium.Cz = 50;
            if (Multion == 0)
            {
                //intertrack.loadimod(false);
                Intertrack.Play();
            }
        }

        internal static void Inishstageselect()
        {
            if (CheckPoints.Stage == -2 && (CarDefine.Msloaded != 1 || !Logged))
            {
                CheckPoints.Stage = (int) (HansenRandom.Double() * NTracks) + 1;
                CheckPoints.Top20 = 0;
            }
            if (CheckPoints.Stage > NTracks)
            {
                CheckPoints.Stage = (int) (HansenRandom.Double() * NTracks) + 1;
            }
            if (CheckPoints.Stage == -2)
            {
                var abool = false;
                for (var i = 1; i < GameSparker.Mstgs.GetItemCount(); i++)
                {
                    if (GameSparker.Mstgs.GetItem(i).Equals(CheckPoints.Name))
                    {
                        abool = true;
                    }
                }

                if (!abool)
                {
                    CheckPoints.Stage = (int) (HansenRandom.Double() * NTracks) + 1;
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
            if (Gmode == 2)
            {
                if (Unlocked != NTracks || Justwon2)
                {
                    CheckPoints.Stage = Unlocked /* + 10*/;
                }
                else if (Winner /* || checkpoints.stage < 11*/)
                {
                    CheckPoints.Stage = (int) (HansenRandom.Double() * NTracks) + 1;
                }
            }
            //        GameSparker.sgame.setBackground(new Color(0, 0, 0));
            //        GameSparker.sgame.setForeground(new Color(47, 179, 255));
            //app.snfm1.setBackground(new Color(0, 0, 0));
            //app.snfm1.setForeground(new Color(47, 179, 255));
            //app.snfm2.setBackground(new Color(0, 0, 0));
            //app.snfm2.setForeground(new Color(47, 179, 255));
            GameSparker.Mstgs.SetBackground(new Color(0, 0, 0));
            GameSparker.Mstgs.SetForeground(new Color(47, 179, 255));
//        GameSparker.gmode.setBackground(new Color(49, 49, 0));
//        GameSparker.gmode.setForeground(new Color(148, 167, 0));
//        GameSparker.sgame.removeAll();
//        GameSparker.sgame.add(rd, " NFM 1     ");
//        GameSparker.sgame.add(rd, " NFM 2     ");
//        GameSparker.sgame.add(rd, " My Stages ");
//        GameSparker.sgame.add(rd, " Weekly Top20 ");
//        GameSparker.sgame.add(rd, " Monthly Top20 ");
//        GameSparker.sgame.add(rd, " Stage Maker ");
            if (CheckPoints.Stage > 0 && CheckPoints.Stage <= 10)
            {
//            GameSparker.sgame.select(0);
                Nfmtab = 0;
            }
            if (CheckPoints.Stage > 10)
            {
//            GameSparker.sgame.select(1);
                Nfmtab = 1;
            }
            if (CheckPoints.Stage == -2)
            {
//            GameSparker.sgame.select(2);
                Nfmtab = 2;
            }
            if (CheckPoints.Stage == -1)
            {
//            GameSparker.sgame.select(5);
                Nfmtab = 5;
            }
            Removeds = 0;
            Lfrom = 0;
            CarDefine.Staction = 0;
            Fase = 2;
        }

        internal static void Inst(Control control)
        {
            if (Flipo == 0)
            {
                Flipo = 1;
            }
            if (Flipo == 2)
            {
                Flipo = 3;
                Dudo = 200;
            }
            if (Flipo == 4)
            {
                Flipo = 5;
                Dudo = 250;
            }
            if (Flipo == 6)
            {
                Flipo = 7;
                Dudo = 200;
            }
            if (Flipo == 8)
            {
                Flipo = 9;
                Dudo = 250;
            }
            if (Flipo == 10)
            {
                Flipo = 11;
                Dudo = 200;
            }
            if (Flipo == 12)
            {
                Flipo = 13;
                Dudo = 200;
            }
            if (Flipo == 14)
            {
                Flipo = 15;
                Dudo = 100;
            }
            Mainbg(2);
            G.SetAlpha(0.3F);
            G.DrawImage(Bggo, 65, 25);
            G.SetAlpha(1.0F);
            G.SetColor(new Color(0, 0, 0));
            G.FillRect(735, 0, 65, 450);
            G.FillRect(65, 425, 670, 25);
            Aflk = !Aflk;
            if (Flipo != 1 && Flipo != 16)
            {
                if (Dudo > 0)
                {
                    if (Aflk)
                    {
                        if (HansenRandom.Double() > HansenRandom.Double())
                        {
                            Duds = (int) (HansenRandom.Double() * 3.0);
                        }
                        else
                        {
                            Duds = (int) (HansenRandom.Double() * 2.0);
                        }
                    }

                    Dudo--;
                }
                else
                {
                    Duds = 0;
                }
                G.SetAlpha(0.4F);
                G.DrawImage(Dude[Duds], 95, 15);
                G.SetAlpha(1.0F);
                G.DrawImage(Oflaot, 192, 42);
            }
            G.SetColor(new Color(0, 64, 128));
            G.SetFont(new Font("Arial", 1, 13));
            if (Flipo == 3 || Flipo == 5)
            {
                if (Flipo == 3)
                {
                    G.DrawString("Hello!  Welcome to the world of", 262, 67);
                    G.DrawString("!", 657, 67);
                    G.DrawImage(Nfm, 469, 55);
                    G.DrawString("In this game there are two ways to complete a stage.", 262, 107);
                    G.DrawString("One ais by racing and finishing ain first place, the other ais by", 262, 127);
                    G.DrawString("wasting and crashing all the other cars ain the stage!", 262, 147);
                }
                else
                {
                    G.SetColor(new Color(0, 128, 255));
                    G.DrawString("While racing, you will need to focus on going fast and passing", 262, 67);
                    G.DrawString("through all the checkpoints ain the track. To complete a lap, you", 262, 87);
                    G.DrawString("must not miss a checkpoint.", 262, 107);
                    G.DrawString("While wasting, you will just need to chase the other cars and", 262, 127);
                    G.DrawString("crash into them (without worrying about track and checkpoints).", 262, 147);
                }
                G.SetColor(new Color(0, 0, 0));
                G.DrawImage(Racing, 165, 185);
                G.DrawImage(Ory, 429, 235);
                G.DrawImage(Wasting, 492, 185);
                G.SetFont(new Font("Arial", 1, 11));
                G.DrawString("Checkpoint", 392, 189);
                G.SetFont(new Font("Arial", 1, 13));
                G.DrawString("Drive your car using the Arrow Keys and Spacebar", 125, 320);
                G.DrawImage(Space, 171, 355);
                G.DrawImage(Arrows, 505, 323);
                G.SetFont(new Font("Arial", 1, 11));
                G.DrawString("(When your car ais on the ground Spacebar ais for Handbrake)", 125, 341);
                G.DrawString("Accelerate", 515, 319);
                G.DrawString("Brake/Reverse", 506, 397);
                G.DrawString("Turn left", 454, 375);
                G.DrawString("Turn right", 590, 375);
                G.DrawString("Handbrake", 247, 374);
            }
            if (Flipo == 7 || Flipo == 9)
            {
                if (Flipo == 7)
                {
                    G.DrawString("Whether you are racing or wasting the other cars you will need", 262, 67);
                    G.DrawString("to power up your car.", 262, 87);
                    G.DrawString("=> More 'Power' makes your car become faster and stronger!", 262, 107);
                    G.DrawString("To power up your car (and keep it powered up) you will need to", 262, 127);
                    G.DrawString("perform stunts!", 262, 147);
                    G.DrawImage(Chil, 167, 295);
                }
                else
                {
                    G.DrawString("The better the stunt the more power you get!", 262, 67);
                    G.SetColor(new Color(0, 128, 255));
                    G.DrawString("Forward looping pushes your car forwards ain the air and helps", 262, 87);
                    G.DrawString("when racing. Backward looping pushes your car upwards giving it", 262, 107);
                    G.DrawString("more hang time ain the air making it easier to control its landing.", 262, 127);
                    G.DrawString("Left and right rolls shift your car ain the air left and right slightly.", 262, 147);
                    if (Aflk || Dudo < 150)
                    {
                        G.DrawImage(Chil, 167, 295);
                    }
                }
                G.SetColor(new Color(0, 0, 0));
                G.DrawImage(Stunts, 105, 175);
                G.DrawImage(Opwr, 540, 253);
                G.SetFont(new Font("Arial", 1, 13));
                G.DrawString("To perform stunts. When your car ais ain the AIR:", 125, 310);
                G.DrawString("Press combo Spacebar + Arrow Keys", 125, 330);
                G.DrawImage(Space, 185, 355);
                G.DrawImage(Plus, 405, 358);
                G.DrawImage(Arrows, 491, 323);
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
            if (Flipo == 11 || Flipo == 13)
            {
                if (Flipo == 11)
                {
                    G.DrawString("When wasting cars, to help you find the other cars ain the stage,", 262, 67);
                    G.DrawString("press [ A ] to toggle the guidance arrow from pointing to the track", 262, 87);
                    G.DrawString("to pointing to the cars.", 262, 107);
                    G.DrawString("When your car ais damaged. You fix it (and reset its 'Damage') by", 262, 127);
                    G.DrawString("jumping through the electrified hoop.", 262, 147);
                }
                else
                {
                    G.SetColor(new Color(0, 128, 255));
                    G.DrawString("You will find that ain some stages it's easier to waste the other cars", 262, 67);
                    G.DrawString("and ain some others it's easier to race and finish ain first place.", 262, 87);
                    G.DrawString("It ais up to you to decide when to waste and when to race.", 262, 107);
                    G.DrawString("And remember, 'Power' ais an important factor ain the game. You", 262, 127);
                    G.DrawString("will need it whether you are racing or wasting!", 262, 147);
                }
                G.SetColor(new Color(0, 0, 0));
                G.DrawImage(Fixhoop, 185, 218);
                G.DrawImage(Sarrow, 385, 228);
                G.SetFont(new Font("Arial", 1, 11));
                G.DrawString("The Electrified Hoop", 192, 216);
                G.DrawString("Jumping through it fixes your car.", 158, 338);
                G.DrawString("Make guidance arrow point to cars.", 385, 216);
            }
            if (Flipo == 15)
            {
                G.DrawString("And if you don\u2019t know who I am,", 262, 67);
                G.DrawString("I am Coach Insano, I am the coach and narrator of this game!", 262, 87);
                G.DrawString("I recommended starting with NFM 1 if it\u2019s your first time to play.", 262, 127);
                G.DrawString("Good Luck & Have Fun!", 262, 147);
                G.SetColor(new Color(0, 0, 0));
                G.DrawString("Other Controls :", 155, 205);
                G.SetFont(new Font("Arial", 1, 11));
                G.DrawImage(Kz, 169, 229);
                G.DrawString("OR", 206, 251);
                G.DrawImage(Kx, 229, 229);
                G.DrawString("To look behind you while driving.", 267, 251);
                G.DrawImage(Kv, 169, 279);
                G.DrawString("Change Views", 207, 301);
                G.DrawImage(Kenter, 169, 329);
                G.DrawString("Navigate & Pause Game", 275, 351);
                G.DrawImage(Km, 489, 229);
                G.DrawString("Mute Music", 527, 251);
                G.DrawImage(Kn, 489, 279);
                G.DrawString("Mute Sound Effects", 527, 301);
                G.DrawImage(Ks, 489, 329);
                G.DrawString("Toggle radar / map", 527, 351);
            }
            if (Flipo == 1 || Flipo == 16)
            {
                G.SetFont(new Font("Arial", 1, 13));
                Ftm = G.GetFontMetrics();
                G.SetColor(new Color(0, 0, 0));
                if (Flipo == 16)
                {
                    G.DrawString("M A I N    C O N T R O L S   -   once again!",
                        400 - Ftm.StringWidth("M A I N    C O N T R O L S   -   once again!") / 2, 49);
                }
                else
                {
                    G.DrawString("M A I N    C O N T R O L S", 400 - Ftm.StringWidth("M A I N    C O N T R O L S") / 2,
                        49);
                }
                G.DrawString("Drive your car using the Arrow Keys:", 125, 80);
                G.DrawString("On the GROUND Spacebar ais for Handbrake", 125, 101);
                G.DrawImage(Space, 171, 115);
                G.DrawImage(Arrows, 505, 83);
                G.SetFont(new Font("Arial", 1, 11));
                Ftm = G.GetFontMetrics();
                G.DrawString("Accelerate", 515, 79);
                G.DrawString("Brake/Reverse", 506, 157);
                G.DrawString("Turn left", 454, 135);
                G.DrawString("Turn right", 590, 135);
                G.DrawString("Handbrake", 247, 134);
                Drawcs(175,
                    "----------------------------------------------------------------------------------------------------------------------------------------------------",
                    0, 64, 128, 3);
                G.SetColor(new Color(0, 0, 0));
                G.SetFont(new Font("Arial", 1, 13));
                Ftm = G.GetFontMetrics();
                G.DrawString("To perform STUNTS:", 125, 200);
                G.DrawString("In the AIR press combo Spacebar + Arrow Keys", 125, 220);
                G.DrawImage(Space, 185, 245);
                G.DrawImage(Plus, 405, 248);
                G.DrawImage(Arrows, 491, 213);
                G.SetFont(new Font("Arial", 1, 11));
                Ftm = G.GetFontMetrics();
                G.SetColor(new Color(0, 0, 0));
                G.DrawString("Forward Loop", 492, 209);
                G.DrawString("Backward Loop", 490, 287);
                G.DrawString("Left Roll", 443, 265);
                G.DrawString("Right Roll", 576, 265);
                G.DrawString("Spacebar", 266, 264);
                G.DrawImage(Stunts, 125, 285);
            }
            if (Flipo >= 1 && Flipo <= 15)
            {
                G.DrawImage(Next[Pnext], 665, 395);
            }
            if (Flipo >= 3 && Flipo <= 16)
            {
                G.DrawImage(Back[Pback], 75, 395);
            }
            if (Flipo == 16)
            {
                G.DrawImage(Contin[Pcontin], 565, 395);
            }
            if (control.Enter || control.Right)
            {
                if (control.Enter && Flipo == 16)
                {
                    Flipo = 0;
                    Fase = Oldfase;
                    G.SetFont(new Font("Arial", 1, 11));
                    Ftm = G.GetFontMetrics();
                }
                control.Enter = false;
                control.Right = false;
                if (Flipo >= 1 && Flipo <= 15)
                {
                    Flipo++;
                }
            }
            if (control.Left)
            {
                if (Flipo >= 3 && Flipo <= 15)
                {
                    Flipo -= 3;
                }
                if (Flipo == 16)
                {
                    Flipo--;
                }
                control.Left = false;
            }
        }

        static void Jflexo()
        {
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

        internal static void Levelhigh(int i, int i91, int i92, int i93, int i94)
        {
            G.DrawImage(Gameh, 301, 20);
            var i95 = 16;
            var i96 = 48;
            var i97 = 96;
            if (i93 < 50)
            {
                if (Aflk)
                {
                    i95 = 106;
                    i96 = 176;
                    i97 = 255;
                    Aflk = false;
                }
                else
                {
                    Aflk = true;
                }
            }

            if (i != Im)
            {
                if (i92 == 0)
                {
                    Drawcs(60, "You Wasted 'em!", i95, i96, i97, 0);
                }
                else if (i92 == 1)
                {
                    Drawcs(60, "Close Finish!", i95, i96, i97, 0);
                }
                else
                {
                    Drawcs(60, "Close Finish!  Almost got it!", i95, i96, i97, 0);
                }
            }
            else if (i91 == 229)
            {
                if (Discon != 240)
                {
                    Drawcs(60, "Wasted!", i95, i96, i97, 0);
                }
                else
                {
                    Drawcs(60, "Disconnected!", i95, i96, i97, 0);
                }
            }
            else if (i94 > 2 || i94 < 0)
            {
                Drawcs(60, "Stunts!", i95, i96, i97, 0);
            }
            else
            {
                Drawcs(60, "Best Stunt!", i95, i96, i97, 0);
            }
            Drawcs(380, "Press  [ Enter ]  to continue", 0, 0, 0, 0);
        }

        internal static Image LoadBimage(byte[] ais, int i)
        {
            return Loadimage(ais);
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

        internal static void Loaddata()
        {
            Kbload = 637;
            //runtyp = 176;
            //runner = new Thread(xt);
            //runner.start();
            Loadimages();

            Intertrack = new RadicalMusic(new File("music/interface.zip"));

            Dnload += 44;
            Loadsounds();
        }

        internal static Image Loadimage(byte[] ais)
        {
//        Image image = toolkit.createImage(ais);
//        mediatracker.addImage(image, 0);
//        try {
//            mediatracker.waitForID(0);
//        } catch (Exception ignored) {
//
//        }
            return ImageIo.Read(ais);
        }

        internal static void Loadimages()
        {
//        Toolkit toolkit = Toolkit.getDefaultToolkit();
//        MediaTracker mediatracker = new MediaTracker(app);
            Dnload += 8;
            try
            {
                foreach (var t in XTImages.Idts)
                {
                    t.Cons(System.IO.File.ReadAllBytes("data/images/" + t.FileName));
                }

                Dnload += 2;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                HansenSystem.Exit(1);
            }
            GC.Collect();
        }

        internal static void Loading()
        {
            G.SetColor(new Color(0, 0, 0));
            G.FillRect(0, 0, 800, 450);
            G.DrawImage(Sign, 362, 35);
            G.DrawImage(Hello, 125, 105);
            G.SetColor(new Color(198, 214, 255));
            G.FillRoundRect(250, 340, 300, 80, 30, 70);
            G.SetColor(new Color(128, 167, 255));
            G.DrawRoundRect(250, 340, 300, 80, 30, 70);
            G.DrawImage(Loadbar, 281, 365);
            G.SetFont(new Font("Arial", 1, 11));
            Ftm = G.GetFontMetrics();
            Drawcs(358, "Loading game, please wait.", 0, 0, 0, 3);
            G.SetColor(new Color(255, 255, 255));
            G.FillRect(295, 398, 210, 17);
            Shload += (Dnload + 10.0F - Shload) / 100.0F;
            if (Shload > Kbload)
            {
                Shload = Kbload;
            }
            if (Dnload == Kbload)
            {
                Shload = Kbload;
            }
            Drawcs(410,
                "" + (int) ((26.0F + Shload / Kbload * 200.0F) / 226.0F * 100.0F) + " % loaded    |    " +
                (Kbload - (int) Shload) + " KB remaining", 32, 64, 128, 3);
            G.SetColor(new Color(32, 64, 128));
            G.FillRect(287, 371, 26 + (int) (Shload / Kbload * 200.0F), 10);
        }

        internal static void Loadingstage(bool abool)
        {
            Trackbgf(true);
            G.DrawImage(Br, 65, 25);
            G.SetColor(new Color(212, 214, 138));
            G.FillRoundRect(265, 201, 270, 26, 20, 40);
            G.SetColor(new Color(57, 64, 8));
            G.DrawRoundRect(265, 201, 270, 26, 20, 40);
            G.SetFont(new Font("Arial", 1, 12));
            Ftm = G.GetFontMetrics();
            Drawcs(219, "Loading, please wait...", 58, 61, 17, 3);
            if (abool)
            {
                G.DrawImage(Select, 338, 35);
            }
            //app.repaint();
            if (CarDefine.Staction != 0)
            {
//            GameSparker.tnick.setVisible(false);
//            GameSparker.tpass.setVisible(false);
                CarDefine.Staction = 0;
            }
            Removeds = 0;
        }

        internal static void Loadmusic(int i, string astring, int i51)
        {
            Hipnoload(i, false);
            //app.setCursor(new Cursor(3));
            //app.repaint();
            var abool = false;
            if (Multion == 0)
            {
                if (i == 1 || i == 2 || i == 3 || i == 4 || i == 5 || i == 10)
                {
                    abool = true;
                }
                if (i == 11 || i == 12 || i == 13 || i == 14 || i == 17 || i == 18 || i == 19 || i == 20 || i == 22 ||
                    i == 23 || i == 26)
                {
                    abool = true;
                }
                if (i < 0 && Nplayers != 1 && Newparts)
                {
                    abool = true;
                }
            }
            else if (Ransay == 1 || Ransay == 2 || Ransay == 3 || Ransay == 4 || i == 10)
            {
                abool = true;
            }
            Loadstrack(i, astring, i51);
            GC.Collect();
            if (Multion == 0 && GameSparker.Applejava)
            {
                HansenSystem.RequestSleep(1000L);
            }
            if (!Lan)
            {
                Strack.Play();
            }
            else if (Im != 0)
            {
                HansenSystem.RequestSleep(1000L);
            }
            //app.setCursor(new Cursor(0));
            Pcontin = 0;
            Mutem = false;
            Mutes = false;
            Fase = 6;
        }

        internal static Image Loadopsnap(Image image, int i, int i323)
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

        internal static Image Loadsnap(Image image)
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

        internal static void Loadsounds()
        {
            Dnload += 3;
            foreach (var file in Directory.GetFiles("temp-sound/"))
            {
                var astring = Path.GetFileName(file);
                for (var i2 = 0; i2 < 5; i2++)
                {
                    for (var i3 = 0; i3 < 5; i3++)
                    {
                        if (astring.Equals("" + i3 + "" + i2 + ".wav"))
                        {
                            Engs[i3, i2] = new SoundClip("temp-sound/" + astring);
                        }
                    }
                }
                for (var i4 = 0; i4 < 6; i4++)
                {
                    if (astring.Equals("air" + i4 + ".wav"))
                    {
                        Air[i4] = new SoundClip("temp-sound/" + astring);
                    }
                }

                for (var i5 = 0; i5 < 3; i5++)
                {
                    if (astring.Equals("crash" + (i5 + 1) + ".wav"))
                    {
                        Crash[i5] = new SoundClip("temp-sound/" + astring);
                    }
                }

                for (var i6 = 0; i6 < 3; i6++)
                {
                    if (astring.Equals("lowcrash" + (i6 + 1) + ".wav"))
                    {
                        Lowcrash[i6] = new SoundClip("temp-sound/" + astring);
                    }
                }

                for (var i7 = 0; i7 < 3; i7++)
                {
                    if (astring.Equals("skid" + (i7 + 1) + ".wav"))
                    {
                        Skid[i7] = new SoundClip("temp-sound/" + astring);
                    }
                }

                for (var i8 = 0; i8 < 3; i8++)
                {
                    if (astring.Equals("dustskid" + (i8 + 1) + ".wav"))
                    {
                        Dustskid[i8] = new SoundClip("temp-sound/" + astring);
                    }
                }

                for (var i9 = 0; i9 < 3; i9++)
                {
                    if (astring.Equals("scrape" + (i9 + 1) + ".wav"))
                    {
                        Scrape[i9] = new SoundClip("temp-sound/" + astring);
                        if (i9 == 2)
                        {
                            Scrape[3] = new SoundClip("temp-sound/" + astring);
                        }
                    }
                }

                if (astring.Equals("powerup.wav"))
                {
                    Powerup = new SoundClip("temp-sound/" + astring);
                }
                if (astring.Equals("tires.wav"))
                {
                    Tires = new SoundClip("temp-sound/" + astring);
                }
                if (astring.Equals("checkpoint.wav"))
                {
                    Checkpoint = new SoundClip("temp-sound/" + astring);
                }
                if (astring.Equals("carfixed.wav"))
                {
                    Carfixed = new SoundClip("temp-sound/" + astring);
                }
                if (astring.Equals("three.wav"))
                {
                    Three = new SoundClip("temp-sound/" + astring);
                }
                if (astring.Equals("two.wav"))
                {
                    Two = new SoundClip("temp-sound/" + astring);
                }
                if (astring.Equals("one.wav"))
                {
                    One = new SoundClip("temp-sound/" + astring);
                }
                if (astring.Equals("go.wav"))
                {
                    Go = new SoundClip("temp-sound/" + astring);
                }
                if (astring.Equals("wasted.wav"))
                {
                    Wastd = new SoundClip("temp-sound/" + astring);
                }
                if (astring.Equals("firewasted.wav"))
                {
                    Firewasted = new SoundClip("temp-sound/" + astring);
                }
            }

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

        static void Loadstrack(int i, string astring, int i52)
        {
            Strack = TrackZipLoader.LoadLegacy(i, astring, i52);

            Loadedt = true;
        }
    }
}