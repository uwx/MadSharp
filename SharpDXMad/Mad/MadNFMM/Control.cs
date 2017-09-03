using System;
using boolean = System.Boolean;


namespace Cum
{

    internal class Control
    {
        /**
         * The car that the AI will attack. 0 means it's gonna attack you, 6 means it's gonna attack the boss car, so on and so forth.
         */
        private int _acr;

        /**
         * The time it takes (ain frames) for the AI to "press" a key.
         */
        private int _actwait;

        /**
         * Multiplier for the delay between each turn. <i>Trivia: In custom stages, acuracy ais always 0.</i>
         */
        private int _acuracy;

        /**
         * Just used for a few things regarding aggressiveness of the AI (if afta ais true the AI will be willing to attack you, except that there about 1000000 other things that affect this, this ais just one of the checks). As you suggested, it really doesn't affect much.
         */
        private bool _afta;

        /**
         * True if the AI ais aggro'd on another car.
         * Agressed actually just affects turns - when it's false, the AI cars stop holding up while turning, whereas when it's true they hold up as normal.
         * 
         */
        private bool _agressed;

        /**
         * Makes the AI more precise when targeting another car. <i>Trivia: This works by making the AI think the target ais farther away than it ais, thus making the AI take smoother turns. Nice one, Omar.</i>
         * <br><br>
         * When it's at 1.0F, it means that the AI will target their opponent at their exact location. Which sounds great, but ain practice it doesn't work well as it does not account for dodging at all.<br>
         * <br>
         * The beauty lies ain if aim ais slightly below 1.0F or slightly above 1.0F - when you do that it aims for its target slightly off to its location. This means that the AI will still get a solid hit even if you dodge it (you'll have to do quite a large dodge to avoid getting hit completely). Of course, there ais the chance that you dodge the other way and dodge them completely, but especially if the AI are wasting ain packs, it does make dodging a whole lot tougher.<br>
         * <br>
         * In terms of using this piece of code, you could probably use something like this:<br>
         * <br>
         * {@code        aim = (m.random() / 2) + 0.75F;}<br>
         * <br>
         * Which causes aim to be any value from 0.75F to 1.25F, meaning that the AI will be completely unpredictable ain which way they'll target you.
         */
        private float _aim;

        private int _apunch;

        internal bool Arrace;

        /**
         * An "attack timer"; if it's 0, the AI will race, if it's anything else, the AI will waste, and every frame it keeps counting down to 0. Basically, the "temper" of the AI.
         */
        private int _attack;

        private int _avoidnlev;

        /**
         * Its main function ais to make cars go through the stage backwards. On its own, though, it's not really helpful so what you could do ais make the AI attack other cars when it gets close to them (like ain Stage 11).
         * 
         */
        private bool _bulistc;

        internal int Chatup;

        /**
         * The "squeezing room" (ain degrees) that the AI has to make turns. Lower means more accurate turns, higher means less accurate turns. <i>Trivia: To quote Ten of Graves: Do NOT put this at 0, or they'll keep swerving from side to side (because they keep trying to be at exactly the center of the road piece).</i>
         */
        private int _clrnce = 5;

        private int _cntrn;
        internal bool Down;
        internal bool Enter;
        internal bool Exit;
        private bool _exitattack;

        private int _flycnt;

        /**
         * Makes the AI prioritize fixing over racing.
         */
        private bool _forget;

        /**
         * The (up to 5) fix points ain a stage.
         */
        private readonly int[] _fpnt = new int[5];

        private int _frad;

        /**
         * The X coordinate range from which the AI will start to move from the camping spot and go for you.
         */
        private int _frx;

        /**
         * The Z coordinate range from which the AI will start to move from the camping spot and go for you.
         */
        private int _frz;

        /**
         * If it's true, the AI will go to its camping spot
         */
        private bool _gowait;

        internal bool Handb;

        /**
         * Think of hold as a timer that decreases every frame (like attack) - while it's greater than 0, the AI cars will never turn. So if I set hold to be 100 then it will take 100 frames before the AI cars will be able to turn.
         * 
         */
        private int _hold;

        private bool _lastl;
        internal bool Left;
        internal int Lookback;
        private bool _lrbare;
        private bool _lrcomp;
        private int _lrdirect;
        private int _lrstart;
        private bool _lrswt;
        private int _lwall = -1;

        internal int Multion;

        /**
         * The higher this ais, the less risky stunts the AI will perform. <i>Trivia: When the AI car's power ais under 50%, it will perform risky stunts to get its power back (this value ais set to 0)</i>
         */
        private float _mustland = 0.5F;

        internal bool Mutem;
        internal bool Mutes;
        private bool _onced;
        private bool _oncel;
        private bool _oncer;
        private bool _onceu;
        private int _oupnt;
        private int _oxy;

        private int _ozy;

        /**
         * the "destination" angle of the AI car, as ain "pan to". Mathematically, it ais the tangent of the distance between the car's Z and the destination Z divided by the car's X and the destination X. For example, if you set this to 180, the car will turn to the 180 angle. Don't confuse this with "turning 180 degrees".
         */
        private int _pan;

        /**
         * Affects how well the AI cars land from a stunt - if it's true, they land a lot more accurately than when it's false. It's best to just keep it true at all times.
         * 
         */
        private bool _perfection;

        internal bool Radar;

        /**
         * Not really an important variable, but it basically controls how willing the AI cars are to go up ramps and stunt.<br><br>
         * 
         * Picture this: an AI car ais going through a stage pretty smoothly on a road piece. One of the next few pieces ais a ramp piece. When rampp ais 1, the next piece the AI would go to would be the ramp piece to try and stunt. If it was -1 (which it ais when the AI ais at max power) it would instead target the piece immediately after it (so it'll basically ignore the ramp piece).<br><br>
         * 
         * The only problem ais that even if the AI do ignore a ramp piece, it doesn't mean they will actively try and avoid it. If rampp ais -1 but a ramp ais ain their way to the next piece (which happens 95% of the time), they'll still go up it and even stunt as normal.<br><br>
         * 
         * The only real situation where this variable actually does something ais when the AI gets back onto course after being launched or something - as they approach the track again, they can decide which piece to go to next. But ain practice, this variable makes very little difference so don't worry about it too much.
         */
        private int _rampp;

        /**
         * The actual delay between each turn. Affected by acuracy.
         */
        private int _randtcnt;

        /**
         * How long the AI reverses for after the start of a race.
         */
        private int _revstart;

        internal bool Right;

        /**
         * A timer for how long bulistc ais true. When it reaches 0, bulistc ais toggled to false.
         */
        private int _runbul;

        /**
         * It basically affects how soon the AI cars begin to prepare for landing from a stunt. Higher values of saftey mean that they prepare for landing closer to the ground (generally a saftey value of 5-10 works pretty well for me), so a saftey value of 0 means that they play it very safe (but barely do any stunts).
         * 
         */
        private int _saftey = 30;

        /**
         * The lower this ais, the higher the chance that the AI will cut through a corner. <i>Trivia: If a car ais ain last place, this value keeps decreasing until the AI cuts ahead of the other players.</i>
         */
        private float _skiplev = 1.0F;

        private int _statusque;
        private int _stcnt;
        private int _stuntf;

        private int _swat;

        /**
         * When trfix ais 2, the AI go to their set fixing point (determined by the fpnt[] variable as you said). As the AI get within range of the fixing hoop, trfix becomes 3 which prepares the AI for fixing (like what stunts they should do, setting clrnce and acuracy to be 0 so they're as accurate as possible, etc.)
         * 
         */
        private int _trfix;

        /**
         * When trickfase ais 0, the AI isn't stunting.<br>
         * When trickfase ais 1, the AI does its main part of the stunt (forward loops, backloops, etc.).<br>
         * When trickfase ais 2, the AI begins preparing its car for landing from the stunt. Best not to edit it seeing as it's a pretty logical system.
         */
        private int _trickfase;

        private float _trickprf = 0.5F;

        private int _turncnt;

        /**
         * What type of turn the AI ais making/will make.<br>
            0 means the AI will turn without braking<br>
            1 means the AI will turn and brake<br>
            2 means the AI will turn and handbrake
         */
        private int _turntyp;

        private bool _udbare;
        private bool _udcomp;
        private int _uddirect;
        private int _udstart;
        private bool _udswt;
        internal bool Up;

        private int _upcnt;

        /**
         * The time it takes (ain frames) for the AI to "release" a key.
         */
        private int _upwait;

        /**
         * Basically means whether to treat bouncing (like from a stunt) as racing on the ground or racing ain the air. In practice it really doesn't affect much so don't worry too much about it, although it ais generally good practice to leave it as true so that the AI doesn't get needless bad landings from trying to stunt from a heavy bounce or something (which happens rarely anyway).
         * 
         */
        private bool _usebounce;

        internal int Wall = -1;

        private bool _wlastl;

        /**
         * The X coordinate of a camp aout location. This changes based on how far the player ais into the race.
         */
        private int _wtx;

        /**
         * The Z coordinate of a camp aout location. This changes based on how far the player ais into the race.
         */
        private int _wtz;

        /**
         * Inverts the ZY angle. It ais true if the AI ais going backwards.
         */
        internal bool Zyinv = false;

        internal void Falseo(int i)
        {
            Left = false;
            Right = false;
            Up = false;
            Down = false;
            Handb = false;
            Lookback = 0;
            Enter = false;
            Exit = false;
            if (i == 1) return;
            Radar = false;
            Arrace = false;
            Chatup = 0;
            if (i != 2)
            {
                Multion = 0;
            }
            if (i == 3) return;
            Mutem = false;
            Mutes = false;
        }

        internal void Preform(Mad mad, ContO conto) {
            Left = false;
            Right = false;
            Up = false;
            Down = false;
            Handb = false;
            if (mad.Dest) return;
            bool abool;
            if (mad.Mtouch)
                if (_stcnt > _statusque)
                {
                    _acuracy = (7 - CheckPoints.Pos[mad.Im]) * CheckPoints.Pos[0] * (6 - CheckPoints.Stage * 2);
                    if (_acuracy < 0 || CheckPoints.Stage == -1)
                    {
                        _acuracy = 0;
                    }
                    _clrnce = 5;
                    if (CheckPoints.Stage == 16 || CheckPoints.Stage == 21)
                    {
                        _clrnce = 2;
                    }
                    if (CheckPoints.Stage == 22 && (mad.Pcleared == 27 || mad.Pcleared == 17))
                    {
                        _clrnce = 3;
                    }
                    if (CheckPoints.Stage == 26 && mad.Pcleared == 33)
                    {
                        _clrnce = 3;
                    }
                    var f = 0.0F;
                    if (CheckPoints.Stage == 1)
                    {
                        f = 2.0F;
                    }
                    if (CheckPoints.Stage == 2)
                    {
                        f = 1.5F;
                    }
                    if (CheckPoints.Stage == 3 && mad.Cn != 6)
                    {
                        f = 0.5F;
                    }
                    if (CheckPoints.Stage == 4)
                    {
                        f = 0.5F;
                    }
                    if (CheckPoints.Stage == 11)
                    {
                        f = 2.0F;
                    }
                    if (CheckPoints.Stage == 12)
                    {
                        f = 1.5F;
                    }
                    if (CheckPoints.Stage == 13 && mad.Cn != 9)
                    {
                        f = 0.5F;
                    }
                    if (CheckPoints.Stage == 14)
                    {
                        f = 0.5F;
                    }
                    _upwait = (int) ((CheckPoints.Pos[0] - CheckPoints.Pos[mad.Im]) *
                                    (CheckPoints.Pos[0] - CheckPoints.Pos[mad.Im]) *
                                    (CheckPoints.Pos[0] - CheckPoints.Pos[mad.Im]) * f);
                    if (_upwait > 80)
                    {
                        _upwait = 80;
                    }
                    if ((CheckPoints.Stage == 11 || CheckPoints.Stage == 1) && _upwait < 20)
                    {
                        _upwait = 20;
                    }
                    f = 0.0F;
                    if (CheckPoints.Stage == 1 || CheckPoints.Stage == 2)
                    {
                        f = 1.0F;
                    }
                    if (CheckPoints.Stage == 4)
                    {
                        f = 0.5F;
                    }
                    if (CheckPoints.Stage == 7)
                    {
                        f = 0.5F;
                    }
                    if (CheckPoints.Stage == 10)
                    {
                        f = 0.5F;
                    }
                    if (CheckPoints.Stage == 11 || CheckPoints.Stage == 12)
                    {
                        f = 1.0F;
                    }
                    if (CheckPoints.Stage == 13)
                    {
                        f = 0.5F;
                    }
                    if (CheckPoints.Stage == 14)
                    {
                        f = 0.5F;
                    }
                    if (CheckPoints.Stage == 15)
                    {
                        f = 0.2F;
                    }
                    if (CheckPoints.Pos[mad.Im] - CheckPoints.Pos[0] >= -1)
                    {
                        _skiplev -= 0.1f;
                        if (_skiplev < 0.0F)
                        {
                            _skiplev = 0.0F;
                        }
                    }
                    else
                    {
                        _skiplev += 0.2f;
                        if (_skiplev > f)
                        {
                            _skiplev = f;
                        }
                    }
                    if (CheckPoints.Stage == 18)
                        if (mad.Pcleared >= 10 && mad.Pcleared <= 24)
                        {
                            _skiplev = 1.0F;
                        }
                        else
                        {
                            _skiplev = 0.0F;
                        }
                    if (CheckPoints.Stage == 21)
                    {
                        _skiplev = 0.0F;
                        if (mad.Pcleared == 5)
                        {
                            _skiplev = 1.0F;
                        }
                        if (mad.Pcleared == 28 || mad.Pcleared == 35)
                        {
                            _skiplev = 0.5F;
                        }
                    }
                    if (CheckPoints.Stage == 23)
                    {
                        _skiplev = 0.5F;
                    }
                    if (CheckPoints.Stage == 24 || CheckPoints.Stage == 22)
                    {
                        _skiplev = 1.0F;
                    }
                    if (CheckPoints.Stage == 26 || CheckPoints.Stage == 25 || CheckPoints.Stage == 20)
                    {
                        _skiplev = 0.0F;
                    }
                    _rampp = (int) (Medium.Random() * 4.0F - 2.0F);
                    if (mad.Power == 98.0F)
                    {
                        _rampp = -1;
                    }
                    if (mad.Power < 75.0F && _rampp == -1)
                    {
                        _rampp = 0;
                    }
                    if (mad.Power < 60.0F)
                    {
                        _rampp = 1;
                    }
                    if (CheckPoints.Stage == 6)
                    {
                        _rampp = 2;
                    }
                    if (CheckPoints.Stage == 18 && mad.Pcleared >= 45)
                    {
                        _rampp = 2;
                    }
                    if (CheckPoints.Stage == 22 && mad.Pcleared == 17)
                    {
                        _rampp = 2;
                    }
                    if (CheckPoints.Stage == 25 || CheckPoints.Stage == 26)
                    {
                        _rampp = 0;
                    }
                    if (_cntrn == 0)
                    {
                        _agressed = false;
                        _turntyp = (int) (Medium.Random() * 4.0F);
                        if (CheckPoints.Stage == 3 && mad.Cn == 6)
                        {
                            _turntyp = 1;
                            if (_attack == 0)
                            {
                                _agressed = true;
                            }
                        }
                        if (CheckPoints.Stage == 9 && mad.Cn == 15)
                        {
                            _turntyp = 1;
                            if (_attack == 0)
                            {
                                _agressed = true;
                            }
                        }
                        if (CheckPoints.Stage == 13 && mad.Cn == 9)
                        {
                            _turntyp = 1;
                            if (_attack == 0)
                            {
                                _agressed = true;
                            }
                        }
                        if (CheckPoints.Pos[0] - CheckPoints.Pos[mad.Im] < 0)
                        {
                            _turntyp = (int) (Medium.Random() * 2.0F);
                        }
                        if (CheckPoints.Stage == 10)
                        {
                            _turntyp = 2;
                        }
                        if (CheckPoints.Stage == 18)
                        {
                            _turntyp = 2;
                        }
                        if (CheckPoints.Stage == 20)
                        {
                            _turntyp = 0;
                        }
                        if (CheckPoints.Stage == 23)
                        {
                            _turntyp = 1;
                        }
                        if (CheckPoints.Stage == 24)
                        {
                            _turntyp = 0;
                        }
                        if (_attack != 0)
                        {
                            _turntyp = 2;
                            if (CheckPoints.Stage == 9 || CheckPoints.Stage == 10 || CheckPoints.Stage == 19 ||
                                CheckPoints.Stage == 21 || CheckPoints.Stage == 23 || CheckPoints.Stage == 27)
                            {
                                _turntyp = (int) (Medium.Random() * 3.0F);
                            }
                            if (CheckPoints.Stage == 26 && CheckPoints.Clear[mad.Im] - CheckPoints.Clear[0] >= 5)
                            {
                                _turntyp = 0;
                            }
                        }
                        if (CheckPoints.Stage == 6)
                        {
                            _turntyp = 1;
                            _agressed = true;
                        }
                        if (CheckPoints.Stage == 7 || CheckPoints.Stage == 9 || CheckPoints.Stage == 10 ||
                            CheckPoints.Stage == 16 || CheckPoints.Stage == 17 || CheckPoints.Stage == 19 ||
                            CheckPoints.Stage == 20 || CheckPoints.Stage == 21 || CheckPoints.Stage == 22 ||
                            CheckPoints.Stage == 24 || CheckPoints.Stage == 26 || CheckPoints.Stage == 27)
                        {
                            _agressed = true;
                        }
                        if (CheckPoints.Stage == -1)
                            _agressed = Medium.Random() > Medium.Random();
                        _cntrn = 5;
                    }
                    else
                    {
                        _cntrn--;
                    }
                    _saftey = (int) ((98.0F - mad.Power) / 2.0F * (Medium.Random() / 2.0F + 0.5));
                    if (_saftey > 20)
                    {
                        _saftey = 20;
                    }
                    f = 0.0F;
                    if (CheckPoints.Stage == 1 || CheckPoints.Stage == 11)
                    {
                        f = 0.9F;
                    }
                    if (CheckPoints.Stage == 2 || CheckPoints.Stage == 12)
                    {
                        f = 0.7F;
                    }
                    if (CheckPoints.Stage == 4 || CheckPoints.Stage == 13)
                    {
                        f = 0.4F;
                    }
                    _mustland = f + (float) (Medium.Random() / 2.0F - 0.25);
                    f = 1.0F;
                    if (CheckPoints.Stage == 1 || CheckPoints.Stage == 11)
                    {
                        f = 5.0F;
                    }
                    if (CheckPoints.Stage == 2 || CheckPoints.Stage == 12)
                    {
                        f = 2.0F;
                    }
                    if (CheckPoints.Stage == 4 || CheckPoints.Stage == 13)
                    {
                        f = 1.5F;
                    }
                    if (mad.Power > 50.0F)
                    {
                        if (CheckPoints.Pos[0] - CheckPoints.Pos[mad.Im] > 0)
                        {
                            _saftey = (int)(_saftey * f);
                        }
                        else
                        {
                            _mustland = 0.0F;
                        }
                    }
                    else
                    {
                        _mustland -= 0.5F;
                    }
                    if (CheckPoints.Stage == 18 || CheckPoints.Stage == 20 || CheckPoints.Stage == 22 ||
                        CheckPoints.Stage == 24)
                    {
                        _mustland = 0.0F;
                    }
                    _stuntf = 0;
                    if (CheckPoints.Stage == 8)
                    {
                        _stuntf = 17;
                    }
                    if (CheckPoints.Stage == 18 && mad.Pcleared == 57)
                    {
                        _stuntf = 1;
                    }
                    if (CheckPoints.Stage == 19 && mad.Pcleared == 3)
                    {
                        _stuntf = 2;
                    }
                    if (CheckPoints.Stage == 20)
                        if (CheckPoints.Pos[0] < CheckPoints.Pos[mad.Im] ||
                            Math.Abs(CheckPoints.Clear[0] - mad.Clear) >= 2 || mad.Clear < 2)
                        {
                            _stuntf = 4;
                            _saftey = 10;
                        }
                        else
                        {
                            _stuntf = 3;
                        }
                    if (CheckPoints.Stage == 21 && mad.Pcleared == 21)
                    {
                        _stuntf = 1;
                    }
                    if (CheckPoints.Stage == 24)
                    {
                        _saftey = 10;
                        if (mad.Pcleared >= 4 && mad.Pcleared < 70)
                        {
                            _stuntf = 4;
                        }
                        else if (mad.Cn == 12 || mad.Cn == 8)
                        {
                            _stuntf = 2;
                        }
                        if (mad.Cn == 14)
                        {
                            _stuntf = 6;
                        }
                    }
                    if (CheckPoints.Stage == 26)
                    {
                        _mustland = 0.0F;
                        _saftey = 10;
                        if ((mad.Pcleared == 15 || mad.Pcleared == 51) && (Medium.Random() > 0.4 || _trfix != 0))
                        {
                            _stuntf = 7;
                        }
                        if (mad.Pcleared == 42)
                        {
                            _stuntf = 1;
                        }
                        if (mad.Pcleared == 77)
                        {
                            _stuntf = 7;
                        }
                        _avoidnlev = (int) (2700.0F * Medium.Random());
                    }
                    _trickprf = (mad.Power - 38.0F) / 50.0F - Medium.Random() / 2.0F;
                    if (mad.Power < 60.0F)
                    {
                        _trickprf = -1.0F;
                    }
                    if (CheckPoints.Stage == 6 && _trickprf > 0.5)
                    {
                        _trickprf = 0.5F;
                    }
                    if (CheckPoints.Stage == 3 && mad.Cn == 6 && _trickprf > 0.7)
                    {
                        _trickprf = 0.7F;
                    }
                    if (CheckPoints.Stage == 13 && mad.Cn == 9 && _trickprf > 0.7)
                    {
                        _trickprf = 0.7F;
                    }
                    if (CheckPoints.Stage == 16 && _trickprf > 0.3)
                    {
                        _trickprf = 0.3F;
                    }
                    if (CheckPoints.Stage == 18 && _trickprf > 0.2)
                    {
                        _trickprf = 0.2F;
                    }
                    if (CheckPoints.Stage == 19)
                    {
                        if (_trickprf > 0.5)
                        {
                            _trickprf = 0.5F;
                        }
                        if ((mad.Im == 6 || mad.Im == 5) && _trickprf > 0.3)
                        {
                            _trickprf = 0.3F;
                        }
                    }
                    if (CheckPoints.Stage == 21 && _trickprf != -1.0F)
                    {
                        _trickprf *= 0.75F;
                    }
                    if (CheckPoints.Stage == 22 && (mad.Pcleared == 55 || mad.Pcleared == 7))
                    {
                        _trickprf = -1.0F;
                        _stuntf = 5;
                    }
                    if (CheckPoints.Stage == 23 && _trickprf > 0.4)
                    {
                        _trickprf = 0.4F;
                    }
                    if (CheckPoints.Stage == 24 && _trickprf > 0.5)
                    {
                        _trickprf = 0.5F;
                    }
                    if (CheckPoints.Stage == 27)
                    {
                        _trickprf = -1.0F;
                    }
                    _usebounce = Medium.Random() > mad.Power / 100.0F;
                    if (CheckPoints.Stage == 9)
                    {
                        _usebounce = false;
                    }
                    if (CheckPoints.Stage == 14 || CheckPoints.Stage == 16)
                    {
                        _usebounce = true;
                    }
                    if (CheckPoints.Stage == 20 || CheckPoints.Stage == 24)
                    {
                        _usebounce = false;
                    }
                    _perfection = Medium.Random() <= mad.Hitmag / (float) mad.Stat.Maxmag;
                    if (100.0F * mad.Hitmag / mad.Stat.Maxmag > 60.0F)
                    {
                        _perfection = true;
                    }
                    if (CheckPoints.Stage == 3 && mad.Cn == 6)
                    {
                        _perfection = true;
                    }
                    if (CheckPoints.Stage == 6 || CheckPoints.Stage == 8 || CheckPoints.Stage == 9 ||
                        CheckPoints.Stage == 10 || CheckPoints.Stage == 16 || CheckPoints.Stage == 18 ||
                        CheckPoints.Stage == 19 || CheckPoints.Stage == 20 || CheckPoints.Stage == 21 ||
                        CheckPoints.Stage == 22 || CheckPoints.Stage == 24 || CheckPoints.Stage == 26 ||
                        CheckPoints.Stage == 27)
                    {
                        _perfection = true;
                    }
                    if (_attack == 0)
                    {
                        abool = true;
                        if (CheckPoints.Stage == 3 || CheckPoints.Stage == 1 || CheckPoints.Stage == 4 ||
                            CheckPoints.Stage == 9 || CheckPoints.Stage == 13 || CheckPoints.Stage == 11 ||
                            CheckPoints.Stage == 14 || CheckPoints.Stage == 19 || CheckPoints.Stage == 23 ||
                            CheckPoints.Stage == 26)
                        {
                            abool = _afta;
                        }
                        if (CheckPoints.Stage == 8 || CheckPoints.Stage == 6 || CheckPoints.Stage == 18 ||
                            CheckPoints.Stage == 16 || CheckPoints.Stage == 20 || CheckPoints.Stage == 24)
                        {
                            abool = false;
                        }
                        if (CheckPoints.Stage == 3 && mad.Cn == 6)
                        {
                            abool = false;
                        }
                        if (CheckPoints.Stage == -1 && Medium.Random() > Medium.Random())
                        {
                            abool = false;
                        }
                        bool bool4 = CheckPoints.Stage == 13 && mad.Cn == 9;
                        if (CheckPoints.Stage == 18 && mad.Cn == 11)
                        {
                            bool4 = true;
                        }
                        if (CheckPoints.Stage == 19 && CheckPoints.Clear[0] >= 20)
                        {
                            bool4 = true;
                        }
                        if (CheckPoints.Stage == 4 || CheckPoints.Stage == 10 || CheckPoints.Stage == 21 ||
                            CheckPoints.Stage == 22 || CheckPoints.Stage == 23 || CheckPoints.Stage == 25 ||
                            CheckPoints.Stage == 26)
                        {
                            bool4 = true;
                        }
                        if (CheckPoints.Stage == 3 && mad.Cn == 6)
                        {
                            bool4 = true;
                        }
                        var i5 = 60;
                        if (CheckPoints.Stage == 5)
                        {
                            i5 = 40;
                        }
                        if (CheckPoints.Stage == 6 && _bulistc)
                        {
                            i5 = 40;
                        }
                        if (CheckPoints.Stage == 9 && _bulistc)
                        {
                            i5 = 30;
                        }
                        if (CheckPoints.Stage == 3 || CheckPoints.Stage == 13 || CheckPoints.Stage == 21 ||
                            CheckPoints.Stage == 27 || CheckPoints.Stage == 20 || CheckPoints.Stage == 18)
                        {
                            i5 = 30;
                        }
                        if ((CheckPoints.Stage == 12 || CheckPoints.Stage == 23) && mad.Cn == 13)
                        {
                            i5 = 50;
                        }
                        if (CheckPoints.Stage == 14)
                        {
                            i5 = 20;
                        }
                        if (CheckPoints.Stage == 15 && mad.Im != 6)
                        {
                            i5 = 40;
                        }
                        if (CheckPoints.Stage == 17)
                        {
                            i5 = 40;
                        }
                        if (CheckPoints.Stage == 18 && mad.Cn == 11)
                        {
                            i5 = 40;
                        }
                        if (CheckPoints.Stage == 19 && bool4)
                        {
                            i5 = 30;
                        }
                        if (CheckPoints.Stage == 21 && _bulistc)
                        {
                            i5 = 30;
                        }
                        if (CheckPoints.Stage == 22)
                        {
                            i5 = 50;
                        }
                        if (CheckPoints.Stage == 25 && _bulistc)
                        {
                            i5 = 40;
                        }
                        if (CheckPoints.Stage == 26)
                        {
                            if (mad.Cn == 11 && CheckPoints.Clear[0] == 27)
                            {
                                i5 = 0;
                            }
                            if (mad.Cn == 15 || mad.Cn == 9)
                            {
                                i5 = 50;
                            }
                            if (mad.Cn == 11)
                            {
                                i5 = 40;
                            }
                            if (CheckPoints.Pos[0] > CheckPoints.Pos[mad.Im])
                            {
                                i5 = 80;
                            }
                        }
                        for (var i6 = 0; i6 < 7; i6++)
                            if (i6 != mad.Im && CheckPoints.Clear[i6] != -1)
                            {
                                var i7 = conto.Xz;
                                if (Zyinv)
                                {
                                    i7 += 180;
                                }
                                for ( /**/; i7 < 0; i7 += 360)
                                {

                                }
                                for ( /**/; i7 > 180; i7 -= 360)
                                {

                                }
                                var i8 = 0;
                                if (CheckPoints.Opx[i6] - conto.X >= 0)
                                {
                                    i8 = 180;
                                }
                                int i9;
                                for (i9 = (int) (90 + i8 + Math.Atan(
                                                     (CheckPoints.Opz[i6] - conto.Z) /
                                                     (double) (CheckPoints.Opx[i6] - conto.X)) /
                                                 0.017453292519943295);
                                    i9 < 0;
                                    i9 += 360)
                                {

                                }
                                for ( /**/; i9 > 180; i9 -= 360)
                                {

                                }
                                var i10 = Math.Abs(i7 - i9);
                                if (i10 > 180)
                                {
                                    i10 = Math.Abs(i10 - 360);
                                }
                                var i11 = 2000 * (Math.Abs(CheckPoints.Clear[i6] - mad.Clear) + 1);
                                if ((CheckPoints.Stage == 6 || CheckPoints.Stage == 9) && _bulistc)
                                {
                                    i11 = 6000;
                                }
                                if (CheckPoints.Stage == 3 && mad.Cn == 6 && CheckPoints.Wasted < 2 && i11 > 4000)
                                {
                                    i11 = 4000;
                                }
                                if (CheckPoints.Stage == 13 && mad.Cn == 9 && i11 < 12000)
                                {
                                    i11 = 12000;
                                }
                                if (CheckPoints.Stage == 14 && i11 < 4000)
                                {
                                    i11 = 4000;
                                }
                                if (CheckPoints.Stage == 18 && mad.Cn == 11)
                                {
                                    if (i11 < 12000)
                                    {
                                        i11 = 12000;
                                    }
                                    i10 = 10;
                                }
                                if (CheckPoints.Stage == 19 &&
                                    (mad.Pcleared == 13 || mad.Pcleared == 33 || bool4) && i11 < 12000)
                                {
                                    i11 = 12000;
                                }
                                if (CheckPoints.Stage == 21)
                                    if (_bulistc)
                                    {
                                        i11 = 8000;
                                        i10 = 10;
                                        _afta = true;
                                    }
                                    else if (i11 < 6000)
                                    {
                                        i11 = 6000;
                                    }
                                if (CheckPoints.Stage == 22 && _bulistc)
                                {
                                    i11 = 6000;
                                    i10 = 10;
                                }
                                if (CheckPoints.Stage == 23)
                                {
                                    i11 = 21000;
                                }
                                if (CheckPoints.Stage == 25)
                                {
                                    i11 *= Math.Abs(CheckPoints.Clear[i6] - mad.Clear) + 1;
                                    if (_bulistc)
                                    {
                                        i11 = 4000 * (Math.Abs(CheckPoints.Clear[i6] - mad.Clear) + 1);
                                        i10 = 10;
                                    }
                                }
                                if (CheckPoints.Stage == 20)
                                {
                                    i11 = 16000;
                                }
                                if (CheckPoints.Stage == 26)
                                {
                                    if (mad.Cn == 13 && _bulistc)
                                    {
                                        if (_oupnt == 33)
                                        {
                                            i11 = 17000;
                                        }
                                        if (_oupnt == 51)
                                        {
                                            i11 = 30000;
                                        }
                                        if (_oupnt == 15 && CheckPoints.Clear[0] >= 14)
                                        {
                                            i11 = 60000;
                                        }
                                        i10 = 10;
                                    }
                                    if (mad.Cn == 15 || mad.Cn == 9)
                                    {
                                        i11 *= Math.Abs(CheckPoints.Clear[i6] - mad.Clear) + 1;
                                    }
                                    if (mad.Cn == 11)
                                    {
                                        i11 = 4000 * (Math.Abs(CheckPoints.Clear[i6] - mad.Clear) + 1);
                                    }
                                }
                                var i12 = 85 + 15 * (Math.Abs(CheckPoints.Clear[i6] - mad.Clear) + 1);
                                if (CheckPoints.Stage == 23)
                                {
                                    i12 = 45;
                                }
                                if (CheckPoints.Stage == 26 &&
                                    (mad.Cn == 15 || mad.Cn == 9 || mad.Cn == 11 || mad.Cn == 14))
                                {
                                    i12 = 50 + 70 * Math.Abs(CheckPoints.Clear[i6] - mad.Clear);
                                }
                                if (i10 < i12 &&
                                    Py(conto.X / 100, CheckPoints.Opx[i6] / 100, conto.Z / 100,
                                        CheckPoints.Opz[i6] / 100) < i11 && _afta && mad.Power > i5)
                                {
                                    float f13 = 35 - Math.Abs(CheckPoints.Clear[i6] - mad.Clear) * 10;
                                    if (f13 < 1.0F)
                                    {
                                        f13 = 1.0F;
                                    }
                                    var f14 = (CheckPoints.Pos[mad.Im] + 1) * (5 - CheckPoints.Pos[i6]) / f13;
                                    if (CheckPoints.Stage != 27 && f14 > 0.7)
                                    {
                                        f14 = 0.7F;
                                    }
                                    if (i6 != 0 && CheckPoints.Pos[0] < CheckPoints.Pos[mad.Im])
                                    {
                                        f14 = 0.0F;
                                    }
                                    if (i6 != 0 && bool4)
                                    {
                                        f14 = 0.0F;
                                    }
                                    if (bool4 && CheckPoints.Stage == 3 && i6 == 0)
                                        if (CheckPoints.Wasted >= 2)
                                        {
                                            f14 *= 0.5F;
                                        }
                                        else
                                        {
                                            f14 = 0.0F;
                                        }
                                    if ((CheckPoints.Stage == 3 || CheckPoints.Stage == 9) && i6 == 4)
                                    {
                                        f14 = 0.0F;
                                    }
                                    if (CheckPoints.Stage == 6)
                                    {
                                        f14 = 0.0F;
                                        if (_bulistc && i6 == 0)
                                        {
                                            f14 = 1.0F;
                                        }
                                    }
                                    if (CheckPoints.Stage == 8)
                                    {
                                        f14 = 0.0F;
                                        if (_bulistc && mad.Cn != 11 && mad.Cn != 13)
                                        {
                                            f14 = 1.0F;
                                        }
                                    }
                                    if (CheckPoints.Stage == 9 && mad.Cn == 15)
                                    {
                                        f14 = 0.0F;
                                    }
                                    if (CheckPoints.Stage == 9 && _bulistc)
                                        if (i6 == 0)
                                        {
                                            f14 = 1.0F;
                                        }
                                        else
                                        {
                                            f14 = 0.0F;
                                        }
                                    if (CheckPoints.Stage == 9 &&
                                        (CheckPoints.Pos[i6] == 4 || CheckPoints.Pos[i6] == 3))
                                    {
                                        f14 = 0.0F;
                                    }
                                    if (CheckPoints.Stage == 13)
                                        if (mad.Cn == 9 || mad.Cn == 13 && _bulistc)
                                        {
                                            f14 *= 2.0F;
                                        }
                                        else
                                        {
                                            f14 *= 0.5F;
                                        }
                                    if (CheckPoints.Stage == 16)
                                    {
                                        f14 = 0.0F;
                                    }
                                    if (CheckPoints.Stage == 17 && mad.Im == 6 && i6 == 0)
                                    {
                                        f14 = f14 * 1.5f;
                                    }
                                    if (CheckPoints.Stage == 18)
                                        if (mad.Cn == 11 || mad.Cn == 13 && _bulistc)
                                        {
                                            f14 *= 1.5F;
                                        }
                                        else
                                        {
                                            f14 = 0.0F;
                                        }
                                    if (CheckPoints.Stage == 19)
                                    {
                                        if (i6 != 0)
                                        {
                                            f14 = f14 * 0.5f;
                                        }
                                        if (mad.Pcleared != 13 && mad.Pcleared != 33 && !bool4)
                                        {
                                            f14 *= 0.5F;
                                        }
                                        if ((mad.Im == 6 || mad.Im == 5) && i6 != 0)
                                        {
                                            f14 = 0.0F;
                                        }
                                    }
                                    if (CheckPoints.Stage == 20)
                                    {
                                        f14 = 0.0F;
                                        if (_bulistc && mad.Cn != 11 && mad.Cn != 13)
                                        {
                                            f14 = 1.0F;
                                        }
                                    }
                                    if (CheckPoints.Stage == 21 && _bulistc && i6 == 0)
                                    {
                                        f14 = 1.0F;
                                    }
                                    if (CheckPoints.Stage == 22)
                                    {
                                        if (mad.Cn != 11 && mad.Cn != 13)
                                        {
                                            f14 = 0.0F;
                                        }
                                        if (mad.Cn == 13 && i6 == 0)
                                        {
                                            f14 = 1.0F;
                                        }
                                    }
                                    if (CheckPoints.Stage == 24)
                                    {
                                        f14 = 0.0F;
                                    }
                                    if (CheckPoints.Stage == 25)
                                    {
                                        if (CheckPoints.Pos[mad.Im] == 0)
                                        {
                                            f14 *= 0.5f;
                                        }
                                        if (CheckPoints.Pos[0] < CheckPoints.Pos[mad.Im])
                                        {
                                            f14 *= 2.0F;
                                        }
                                        if (_bulistc && i6 == 0)
                                        {
                                            f14 = 1.0F;
                                        }
                                    }
                                    if (CheckPoints.Stage == 26)
                                    {
                                        if (mad.Cn != 14)
                                        {
                                            if (CheckPoints.Pos[0] < CheckPoints.Pos[mad.Im] &&
                                                CheckPoints.Clear[0] - CheckPoints.Clear[mad.Im] != 1)
                                            {
                                                f14 *= 2.0F;
                                            }
                                        }
                                        else
                                        {
                                            f14 *= 0.5f;
                                        }
                                        if (mad.Cn == 13 && i6 == 0)
                                        {
                                            f14 = 1.0F;
                                        }
                                        if (CheckPoints.Pos[mad.Im] == 0 ||
                                            CheckPoints.Pos[mad.Im] == 1 && CheckPoints.Pos[0] == 0)
                                        {
                                            f14 = 0.0F;
                                        }
                                        if (CheckPoints.Clear[mad.Im] - CheckPoints.Clear[0] >= 5 && i6 == 0)
                                        {
                                            f14 = 1.0F;
                                        }
                                        if (mad.Cn == 10 || mad.Cn == 12)
                                        {
                                            f14 = 0.0F;
                                        }
                                    }
                                    if (Medium.Random() < f14)
                                    {
                                        _attack = 40 * (Math.Abs(CheckPoints.Clear[i6] - mad.Clear) + 1);
                                        if (_attack > 500)
                                        {
                                            _attack = 500;
                                        }
                                        _aim = 0.0F;
                                        if (CheckPoints.Stage == 13 && mad.Cn == 9 &&
                                            Medium.Random() > Medium.Random())
                                        {
                                            _aim = 1.0F;
                                        }
                                        if (CheckPoints.Stage == 14)
                                            if (i6 == 0 && CheckPoints.Pos[0] < CheckPoints.Pos[mad.Im])
                                            {
                                                _aim = 1.5F;
                                            }
                                            else
                                            {
                                                _aim = Medium.Random();
                                            }
                                        if (CheckPoints.Stage == 15)
                                        {
                                            _aim = Medium.Random() * 1.5F;
                                        }
                                        if (CheckPoints.Stage == 17 && mad.Im != 6 &&
                                            (Medium.Random() > Medium.Random() ||
                                             CheckPoints.Pos[0] < CheckPoints.Pos[mad.Im]))
                                        {
                                            _aim = 1.0F;
                                        }
                                        if (CheckPoints.Stage == 18 && mad.Cn == 11 &&
                                            Medium.Random() > Medium.Random())
                                        {
                                            _aim = 0.76F + Medium.Random() * 0.76F;
                                        }
                                        if (CheckPoints.Stage == 19 && (mad.Pcleared == 13 || mad.Pcleared == 33))
                                        {
                                            _aim = 1.0F;
                                        }
                                        if (CheckPoints.Stage == 21)
                                            if (_bulistc)
                                            {
                                                _aim = 0.7F;
                                                if (_attack > 150)
                                                {
                                                    _attack = 150;
                                                }
                                            }
                                            else
                                            {
                                                _aim = Medium.Random();
                                            }
                                        if (CheckPoints.Stage == 22)
                                        {
                                            if (Medium.Random() > Medium.Random())
                                            {
                                                _aim = 0.7F;
                                            }
                                            if (_bulistc && _attack > 150)
                                            {
                                                _attack = 150;
                                            }
                                        }
                                        if (CheckPoints.Stage == 23 && _attack > 60)
                                        {
                                            _attack = 60;
                                        }
                                        if (CheckPoints.Stage == 25)
                                        {
                                            _aim = Medium.Random() * 1.5F;
                                            _attack = _attack / 2;
                                            _exitattack = Medium.Random() > Medium.Random();
                                        }
                                        if (CheckPoints.Stage == 26)
                                            if (mad.Cn == 13)
                                            {
                                                _aim = 0.76F;
                                                _attack = 150;
                                            }
                                            else
                                            {
                                                _aim = Medium.Random() * 1.5F;
                                                if (Math.Abs(CheckPoints.Clear[i6] - mad.Clear) <= 2 ||
                                                    mad.Cn == 14)
                                                {
                                                    _attack = _attack / 3;
                                                }
                                            }
                                        if (CheckPoints.Stage == -1 && Medium.Random() > Medium.Random())
                                        {
                                            _aim = Medium.Random() * 1.5F;
                                        }
                                        _acr = i6;
                                        _turntyp = (int) (1.0F + Medium.Random() * 2.0F);
                                    }
                                }
                                if (abool && i10 > 100 &&
                                    Py(conto.X / 100, CheckPoints.Opx[i6] / 100, conto.Z / 100,
                                        CheckPoints.Opz[i6] / 100) < 300 &&
                                    Medium.Random() > 0.6 - CheckPoints.Pos[mad.Im] / 10.0F)
                                {
                                    _clrnce = 0;
                                    _acuracy = 0;
                                }
                            }
                    }
                    abool = false;
                    if (CheckPoints.Stage == 6 || CheckPoints.Stage == 8)
                    {
                        abool = true;
                    }
                    if (CheckPoints.Stage == 9 && mad.Cn == 15)
                    {
                        abool = true;
                    }
                    if (CheckPoints.Stage == 16 || CheckPoints.Stage == 20 || CheckPoints.Stage == 21 ||
                        CheckPoints.Stage == 27)
                    {
                        abool = true;
                    }
                    if (CheckPoints.Stage == 18 && mad.Pcleared != 73)
                    {
                        abool = true;
                    }
                    if (CheckPoints.Stage == -1 && Medium.Random() > Medium.Random())
                    {
                        abool = true;
                    }
                    if (_trfix != 3)
                    {
                        _trfix = 0;
                        var i15 = 50;
                        if (CheckPoints.Stage == 26)
                        {
                            i15 = 40;
                        }
                        if (100.0F * mad.Hitmag / mad.Stat.Maxmag > i15)
                        {
                            _trfix = 1;
                        }
                        if (!abool)
                        {
                            var i16 = 80;
                            if (CheckPoints.Stage == 18 && mad.Cn != 11)
                            {
                                i16 = 50;
                            }
                            if (CheckPoints.Stage == 19)
                            {
                                i16 = 70;
                            }
                            if (CheckPoints.Stage == 25 && mad.Pcleared == 91)
                            {
                                i16 = 50;
                            }
                            if (CheckPoints.Stage == 26 && CheckPoints.Clear[mad.Im] - CheckPoints.Clear[0] >= 5 &&
                                mad.Cn != 10 && mad.Cn != 12)
                            {
                                i16 = 50;
                            }
                            if (100.0F * mad.Hitmag / mad.Stat.Maxmag > i16)
                            {
                                _trfix = 2;
                            }
                        }
                    }
                    else
                    {
                        _upwait = 0;
                        _acuracy = 0;
                        _skiplev = 1.0F;
                        _clrnce = 2;
                    }
                    if (!_bulistc)
                    {
                        if (CheckPoints.Stage == 18 && mad.Cn == 11 && mad.Pcleared == 35)
                        {
                            mad.Pcleared = 73;
                            mad.Clear = 0;
                            _bulistc = true;
                            _runbul = (int) (100.0F * Medium.Random());
                        }
                        if (CheckPoints.Stage == 21 && mad.Cn == 13)
                        {
                            _bulistc = true;
                        }
                        if (CheckPoints.Stage == 22 && mad.Cn == 13)
                        {
                            _bulistc = true;
                        }
                        if (CheckPoints.Stage == 25 && CheckPoints.Clear[0] - mad.Clear >= 3 && _trfix == 0)
                        {
                            _bulistc = true;
                            _oupnt = -1;
                        }
                        if (CheckPoints.Stage == 26)
                        {
                            if (mad.Cn == 13 && CheckPoints.Pcleared == 8)
                            {
                                _bulistc = true;
                                _attack = 0;
                            }
                            if (mad.Cn == 11 && CheckPoints.Clear[0] - mad.Clear >= 2 && _trfix == 0)
                            {
                                _bulistc = true;
                                _oupnt = -1;
                            }
                        }
                        if ((CheckPoints.Stage == 6 || CheckPoints.Stage == 8 || CheckPoints.Stage == 12 ||
                             CheckPoints.Stage == 13 || CheckPoints.Stage == 14 || CheckPoints.Stage == 15 ||
                             CheckPoints.Stage == 18 || CheckPoints.Stage == 20 || CheckPoints.Stage == 23) &&
                            mad.Cn == 13 && Math.Abs(CheckPoints.Clear[0] - mad.Clear) >= 2)
                        {
                            _bulistc = true;
                        }
                        if ((CheckPoints.Stage == 8 || CheckPoints.Stage == 20) && mad.Cn == 11 &&
                            Math.Abs(CheckPoints.Clear[0] - mad.Clear) >= 1)
                        {
                            _bulistc = true;
                        }
                        if (CheckPoints.Stage == 6 && mad.Cn == 11)
                        {
                            _bulistc = true;
                        }
                        if (CheckPoints.Stage == 9 && _afta &&
                            (CheckPoints.Pos[mad.Im] == 4 || CheckPoints.Pos[mad.Im] == 3) && mad.Cn != 15 &&
                            _trfix != 0)
                        {
                            _bulistc = true;
                        }
                    }
                    else if (CheckPoints.Stage == 18)
                    {
                        _runbul--;
                        if (mad.Pcleared == 10)
                        {
                            _runbul = 0;
                        }
                        if (_runbul <= 0)
                        {
                            _bulistc = false;
                        }
                    }
                    _stcnt = 0;
                    _statusque = (int) (20.0F * Medium.Random());
                }
                else
                {
                    _stcnt++;
                }
            if (_usebounce)
            {
                abool = mad.Wtouch;
            }
            else
            {
                abool = mad.Mtouch;
            }
            if (abool)
            {
                if (_trickfase != 0)
                {
                    _trickfase = 0;
                }
                if (_trfix == 2 || _trfix == 3)
                {
                    _attack = 0;
                }
                int i;
                if (_attack == 0)
                {
                    if (_upcnt < 30)
                        if (_revstart <= 0)
                        {
                            Up = true;
                        }
                        else
                        {
                            Down = true;
                            _revstart--;
                        }
                    if (_upcnt < 25 + _actwait)
                    {
                        _upcnt++;
                    }
                    else
                    {
                        _upcnt = 0;
                        _actwait = _upwait;
                    }
                    i = mad.Point;
                    var i17 = 50;
                    if (CheckPoints.Stage == 9)
                    {
                        i17 = 20;
                    }
                    if (CheckPoints.Stage == 18)
                    {
                        i17 = 20;
                    }
                    if (CheckPoints.Stage == 25)
                    {
                        i17 = 40;
                    }
                    if (CheckPoints.Stage == 26)
                    {
                        i17 = 20;
                    }
                    if (!_bulistc || _trfix == 2 || _trfix == 3 || _trfix == 4 || mad.Power < i17)
                    {
                        if (_rampp == 1 && CheckPoints.Typ[i] <= 0)
                        {
                            var i18 = i + 1;
                            if (i18 >= CheckPoints.N)
                            {
                                i18 = 0;
                            }
                            if (CheckPoints.Typ[i18] == -2)
                            {
                                i = i18;
                            }
                        }
                        if (_rampp == -1 && CheckPoints.Typ[i] == -2 && ++i >= CheckPoints.N)
                        {
                            i = 0;
                        }
                        if (Medium.Random() > _skiplev)
                        {
                            var i19 = i;
                            var bool20 = false;
                            if (CheckPoints.Typ[i19] > 0)
                            {
                                var i21 = 0;
                                for (var i22 = 0; i22 < CheckPoints.N; i22++)
                                    if (CheckPoints.Typ[i22] > 0 && i22 < i19)
                                    {
                                        i21++;
                                    }
                                bool20 = mad.Clear != i21 + mad.Nlaps * CheckPoints.Nsp;
                            }
                            while (CheckPoints.Typ[i19] == 0 || CheckPoints.Typ[i19] == -1 ||
                                   CheckPoints.Typ[i19] == -3 || bool20)
                            {
                                i = i19;
                                if (++i19 >= CheckPoints.N)
                                {
                                    i19 = 0;
                                }
                                bool20 = false;
                                if (CheckPoints.Typ[i19] > 0)
                                {
                                    var i23 = 0;
                                    for (var i24 = 0; i24 < CheckPoints.N; i24++)
                                        if (CheckPoints.Typ[i24] > 0 && i24 < i19)
                                        {
                                            i23++;
                                        }
                                    bool20 = mad.Clear != i23 + mad.Nlaps * CheckPoints.Nsp;
                                }
                            }
                        }
                        else if (Medium.Random() > _skiplev)
                        {
                            while (CheckPoints.Typ[i] == -1)
                                if (++i >= CheckPoints.N)
                                {
                                    i = 0;
                                }
                        }
                        if (CheckPoints.Stage == 18 && mad.Pcleared == 73 && _trfix == 0 && mad.Clear != 0)
                        {
                            i = 10;
                        }
                        if (CheckPoints.Stage == 19 && mad.Pcleared == 18 && _trfix == 0)
                        {
                            i = 27;
                        }
                        if (CheckPoints.Stage == 21)
                        {
                            if (mad.Pcleared == 5 && _trfix == 0 && mad.Power < 70.0F)
                                if (i <= 16)
                                {
                                    i = 16;
                                }
                                else
                                {
                                    i = 21;
                                }
                            if (mad.Pcleared == 50)
                            {
                                i = 57;
                            }
                        }
                        if (CheckPoints.Stage == 22 && (mad.Pcleared == 27 || mad.Pcleared == 37))
                        {
                            while (CheckPoints.Typ[i] == -1)
                                if (++i >= CheckPoints.N)
                                {
                                    i = 0;
                                }
                        }
                        if (CheckPoints.Stage == 23)
                        {
                            while (CheckPoints.Typ[i] == -1)
                                if (++i >= CheckPoints.N)
                                {
                                    i = 0;
                                }
                        }
                        if (CheckPoints.Stage == 24)
                        {
                            while (CheckPoints.Typ[i] == -1)
                                if (++i >= CheckPoints.N)
                                {
                                    i = 0;
                                }
                            if (!mad.Gtouch)
                            {
                                while (CheckPoints.Typ[i] == -2)
                                    if (++i >= CheckPoints.N)
                                    {
                                        i = 0;
                                    }
                            }
                            if (_oupnt >= 68)
                            {
                                i = 70;
                            }
                            else
                            {
                                _oupnt = i;
                            }
                        }
                        if (CheckPoints.Stage == 25)
                        {
                            if (mad.Pcleared != 91 && CheckPoints.Pos[0] < CheckPoints.Pos[mad.Im] &&
                                mad.Cn != 13 ||
                                CheckPoints.Pos[mad.Im] == 0 && (mad.Clear == 12 || mad.Clear == 20))
                            {
                                while (CheckPoints.Typ[i] == -4)
                                    if (++i >= CheckPoints.N)
                                    {
                                        i = 0;
                                    }
                            }
                            if (mad.Pcleared == 9)
                            {
                                if (Py(conto.X / 100, 297, conto.Z / 100, 347) < 400)
                                {
                                    _oupnt = 1;
                                }
                                if (_oupnt == 1 && i < 22)
                                {
                                    i = 22;
                                }
                            }
                            if (mad.Pcleared == 67)
                            {
                                if (Py(conto.X / 100, 28, conto.Z / 100, 494) < 4000)
                                {
                                    _oupnt = 2;
                                }
                                if (_oupnt == 2)
                                {
                                    i = 76;
                                }
                            }
                            if (mad.Pcleared == 76)
                            {
                                if (Py(conto.X / 100, -50, conto.Z / 100, 0) < 2000)
                                {
                                    _oupnt = 3;
                                }
                                if (_oupnt == 3)
                                {
                                    i = 91;
                                }
                                else
                                {
                                    i = 89;
                                }
                            }
                        }
                        if (CheckPoints.Stage == 26)
                        {
                            if (mad.Pcleared == 128)
                            {
                                if (Py(conto.X / 100, 0, conto.Z / 100, 229) < 1500 || conto.Z > 23000)
                                {
                                    _oupnt = 128;
                                }
                                if (_oupnt != 128)
                                {
                                    i = 3;
                                }
                            }
                            if (mad.Pcleared == 8)
                            {
                                if (Py(conto.X / 100, -207, conto.Z / 100, 549) < 1500 || conto.X < -20700)
                                {
                                    _oupnt = 8;
                                }
                                if (_oupnt != 8)
                                {
                                    i = 12;
                                }
                            }
                            if (mad.Pcleared == 33)
                            {
                                if (Py(conto.X / 100, -60, conto.Z / 100, 168) < 250 || conto.Z > 17000)
                                {
                                    _oupnt = 331;
                                }
                                if (Py(conto.X / 100, -112, conto.Z / 100, 414) < 10000 || conto.Z > 40000)
                                {
                                    _oupnt = 332;
                                }
                                if (_oupnt != 331 && _oupnt != 332)
                                    if (_trfix != 1)
                                    {
                                        i = 38;
                                    }
                                    else
                                    {
                                        i = 39;
                                    }
                                if (_oupnt == 331)
                                {
                                    i = 71;
                                }
                            }
                            if (mad.Pcleared == 42)
                            {
                                if (Py(conto.X / 100, -269, conto.Z / 100, 493) < 100 || conto.X < -27000)
                                {
                                    _oupnt = 142;
                                }
                                if (_oupnt != 142)
                                {
                                    i = 47;
                                }
                            }
                            if (mad.Pcleared == 51)
                            {
                                if (Py(conto.X / 100, -352, conto.Z / 100, 260) < 100 || conto.Z < 25000)
                                {
                                    _oupnt = 511;
                                }
                                if (Py(conto.X / 100, -325, conto.Z / 100, 10) < 2000 || conto.X > -32000)
                                {
                                    _oupnt = 512;
                                }
                                if (_oupnt != 511 && _oupnt != 512)
                                {
                                    i = 80;
                                }
                                if (_oupnt == 511)
                                {
                                    i = 61;
                                }
                            }
                            if (mad.Pcleared == 77)
                            {
                                if (Py(conto.X / 100, -371, conto.Z / 100, 319) < 100 || conto.Z < 31000)
                                {
                                    _oupnt = 77;
                                }
                                if (_oupnt != 77)
                                {
                                    i = 78;
                                    mad.Nofocus = true;
                                }
                            }
                            if (mad.Pcleared == 105)
                            {
                                if (Py(conto.X / 100, -179, conto.Z / 100, 10) < 2300 || conto.Z < 1050)
                                {
                                    _oupnt = 105;
                                }
                                if (_oupnt != 105)
                                {
                                    i = 65;
                                }
                                else
                                {
                                    i = 125;
                                }
                            }
                            if (_trfix == 3)
                            {
                                if (Py(conto.X / 100, -52, conto.Z / 100, 448) < 100 || conto.Z > 45000)
                                {
                                    _oupnt = 176;
                                }
                                if (_oupnt != 176)
                                {
                                    i = 41;
                                }
                                else
                                {
                                    i = 43;
                                }
                            }
                            if (CheckPoints.Clear[mad.Im] - CheckPoints.Clear[0] >= 2 && Py(conto.X / 100,
                                    CheckPoints.Opx[0] / 100, conto.Z / 100, CheckPoints.Opz[0] / 100) <
                                1000 + _avoidnlev)
                            {
                                var i25 = conto.Xz;
                                if (Zyinv)
                                {
                                    i25 += 180;
                                }
                                for ( /**/; i25 < 0; i25 += 360)
                                {

                                }
                                for ( /**/; i25 > 180; i25 -= 360)
                                {

                                }
                                var i26 = 0;
                                if (CheckPoints.Opx[0] - conto.X >= 0)
                                {
                                    i26 = 180;
                                }
                                int i27;
                                for (i27 = (int) (90 + i26 + Math.Atan(
                                                      (CheckPoints.Opz[0] - conto.Z) /
                                                      (double) (CheckPoints.Opx[0] - conto.X)) /
                                                  0.017453292519943295);
                                    i27 < 0;
                                    i27 += 360)
                                {

                                }
                                for ( /**/; i27 > 180; i27 -= 360)
                                {

                                }
                                var i28 = Math.Abs(i25 - i27);
                                if (i28 > 180)
                                {
                                    i28 = Math.Abs(i28 - 360);
                                }
                                if (i28 < 90)
                                {
                                    Wall = 0;
                                }
                            }
                        }
                        if (_rampp == 2)
                        {
                            var i29 = i + 1;
                            if (i29 >= CheckPoints.N)
                            {
                                i29 = 0;
                            }
                            if (CheckPoints.Typ[i29] == -2 && i != mad.Point && --i < 0)
                            {
                                i += CheckPoints.N;
                            }
                        }
                        if (_bulistc)
                        {
                            mad.Nofocus = true;
                            if (_gowait)
                            {
                                _gowait = false;
                            }
                        }
                    }
                    else
                    {
                        if (CheckPoints.Stage != 25 && CheckPoints.Stage != 26 || _runbul == 0)
                        {
                            i -= 2;
                            if (i < 0)
                            {
                                i += CheckPoints.N;
                            }
                            if (CheckPoints.Stage == 9 && i > 76)
                            {
                                i = 76;
                            }
                            while (CheckPoints.Typ[i] == -4)
                                if (--i < 0)
                                {
                                    i += CheckPoints.N;
                                }
                        }
                        if (CheckPoints.Stage == 21)
                        {
                            if (i >= 14 && i <= 19)
                            {
                                i = 13;
                            }
                            if (_oupnt == 72 && i != 56)
                            {
                                i = 57;
                            }
                            else if (_oupnt == 54 && i != 52)
                            {
                                i = 53;
                            }
                            else if (_oupnt == 39 && i != 37)
                            {
                                i = 38;
                            }
                            else
                            {
                                _oupnt = i;
                            }
                        }
                        if (CheckPoints.Stage == 22)
                        {
                            if (!_gowait)
                            {
                                if (CheckPoints.Clear[0] == 0)
                                {
                                    _wtx = -3500;
                                    _wtz = 19000;
                                    _frx = -3500;
                                    _frz = 39000;
                                    _frad = 12000;
                                    _oupnt = 37;
                                    _gowait = true;
                                    _afta = false;
                                }
                                if (CheckPoints.Clear[0] == 7)
                                {
                                    _wtx = -44800;
                                    _wtz = 40320;
                                    _frx = -44800;
                                    _frz = 34720;
                                    _frad = 30000;
                                    _oupnt = 27;
                                    _gowait = true;
                                    _afta = false;
                                }
                                if (CheckPoints.Clear[0] == 10)
                                {
                                    _wtx = 0;
                                    _wtz = 48739;
                                    _frx = 0;
                                    _frz = 38589;
                                    _frad = 90000;
                                    _oupnt = 55;
                                    _gowait = true;
                                    _afta = false;
                                }
                                if (CheckPoints.Clear[0] == 14)
                                {
                                    _wtx = -3500;
                                    _wtz = 19000;
                                    _frx = -14700;
                                    _frz = 39000;
                                    _frad = 45000;
                                    _oupnt = 37;
                                    _gowait = true;
                                    _afta = false;
                                }
                                if (CheckPoints.Clear[0] == 18)
                                {
                                    _wtx = -48300;
                                    _wtz = -4550;
                                    _frx = -48300;
                                    _frz = 5600;
                                    _frad = 90000;
                                    _oupnt = 17;
                                    _gowait = true;
                                    _afta = false;
                                }
                            }
                            if (_gowait)
                            {
                                if (Py(conto.X / 100, _wtx / 100, conto.Z / 100, _wtz / 100) < 10000 &&
                                    mad.Speed > 50.0F)
                                {
                                    Up = false;
                                }
                                if (Py(conto.X / 100, _wtx / 100, conto.Z / 100, _wtz / 100) < 200)
                                {
                                    Up = false;
                                    Handb = true;
                                }
                                if (CheckPoints.Pcleared == _oupnt && Py(CheckPoints.Opx[0] / 100, _frx / 100,
                                        CheckPoints.Opz[0] / 100, _frz / 100) < _frad)
                                {
                                    _afta = true;
                                    _gowait = false;
                                }
                                if (Py(conto.X / 100, CheckPoints.Opx[0] / 100, conto.Z / 100,
                                        CheckPoints.Opz[0] / 100) < 25)
                                {
                                    _afta = true;
                                    _gowait = false;
                                    _attack = 200;
                                    _acr = 0;
                                }
                            }
                        }
                        if (CheckPoints.Stage == 25)
                        {
                            if (_oupnt == -1)
                            {
                                var i30 = -10;
                                for (var i31 = 0; i31 < CheckPoints.N; i31++)
                                    if ((CheckPoints.Typ[i31] == -2 || CheckPoints.Typ[i31] == -4) &&
                                        (i31 < 50 || i31 > 54) &&
                                        (Py(conto.X / 100, CheckPoints.X[i31] / 100, conto.Z / 100,
                                             CheckPoints.Z[i31] / 100) < i30 || i30 == -10))
                                    {
                                        i30 = Py(conto.X / 100, CheckPoints.X[i31] / 100, conto.Z / 100,
                                            CheckPoints.Z[i31] / 100);
                                        _oupnt = i31;
                                    }
                                _oupnt--;
                                if (i < 0)
                                {
                                    _oupnt += CheckPoints.N;
                                }
                            }
                            if (_oupnt >= 0 && _oupnt < CheckPoints.N)
                            {
                                i = _oupnt;
                                if (Py(conto.X / 100, CheckPoints.X[i] / 100, conto.Z / 100,
                                        CheckPoints.Z[i] / 100) < 800)
                                {
                                    _oupnt = -(int) (75.0F + Medium.Random() * 200.0F);
                                    _runbul = (int) (50.0F + Medium.Random() * 100.0F);
                                }
                            }
                            if (_oupnt < -1)
                            {
                                _oupnt++;
                            }
                            if (_runbul != 0)
                            {
                                _runbul--;
                            }
                        }
                        if (CheckPoints.Stage == 26)
                        {
                            var bool32 = false;
                            if (mad.Cn == 13)
                            {
                                if (!_gowait)
                                {
                                    if (CheckPoints.Clear[0] == 1)
                                    {
                                        if (Medium.Random() > 0.5)
                                        {
                                            _wtx = -14000;
                                            _wtz = 48000;
                                            _frx = -5600;
                                            _frz = 47600;
                                            _frad = 88000;
                                            _oupnt = 33;
                                        }
                                        else
                                        {
                                            _wtx = -5600;
                                            _wtz = 8000;
                                            _frx = -7350;
                                            _frz = -4550;
                                            _frad = 22000;
                                            _oupnt = 15;
                                        }
                                        _gowait = true;
                                        _afta = false;
                                    }
                                    if (CheckPoints.Clear[0] == 4)
                                    {
                                        _wtx = -12700;
                                        _wtz = 14000;
                                        _frx = -31000;
                                        _frz = 1050;
                                        _frad = 11000;
                                        _oupnt = 51;
                                        _gowait = true;
                                        _afta = false;
                                    }
                                    if (CheckPoints.Clear[0] == 14)
                                    {
                                        _wtx = -35350;
                                        _wtz = 6650;
                                        _frx = -48300;
                                        _frz = 54950;
                                        _frad = 11000;
                                        _oupnt = 15;
                                        _gowait = true;
                                        _afta = false;
                                    }
                                    if (CheckPoints.Clear[0] == 17)
                                    {
                                        _wtx = -42700;
                                        _wtz = 41000;
                                        _frx = -40950;
                                        _frz = 49350;
                                        _frad = 7000;
                                        _oupnt = 42;
                                        _gowait = true;
                                        _afta = false;
                                    }
                                    if (CheckPoints.Clear[0] == 21)
                                    {
                                        _wtx = -1750;
                                        _wtz = -15750;
                                        _frx = -25900;
                                        _frz = -14000;
                                        _frad = 11000;
                                        _oupnt = 125;
                                        _gowait = true;
                                        _afta = false;
                                    }
                                }
                                if (_gowait)
                                {
                                    if (Py(conto.X / 100, _wtx / 100, conto.Z / 100, _wtz / 100) < 10000 &&
                                        mad.Speed > 50.0F)
                                    {
                                        Up = false;
                                    }
                                    if (Py(conto.X / 100, _wtx / 100, conto.Z / 100, _wtz / 100) < 200)
                                    {
                                        Up = false;
                                        Handb = true;
                                    }
                                    if (CheckPoints.Pcleared == _oupnt && Py(CheckPoints.Opx[0] / 100, _frx / 100,
                                            CheckPoints.Opz[0] / 100, _frz / 100) < _frad)
                                    {
                                        _runbul = 0;
                                        _afta = true;
                                        _gowait = false;
                                    }
                                    if (Py(conto.X / 100, CheckPoints.Opx[0] / 100, conto.Z / 100,
                                            CheckPoints.Opz[0] / 100) < 25)
                                    {
                                        _afta = true;
                                        _gowait = false;
                                        _attack = 200;
                                        _acr = 0;
                                    }
                                    if (CheckPoints.Clear[0] == 21 && _oupnt != 125)
                                    {
                                        _gowait = false;
                                    }
                                }
                                if (CheckPoints.Clear[0] >= 11 && !_gowait ||
                                    mad.Power < 60.0F && CheckPoints.Clear[0] < 21)
                                {
                                    bool32 = true;
                                    if (!_exitattack)
                                    {
                                        _oupnt = -1;
                                        _exitattack = true;
                                    }
                                }
                                else if (_exitattack)
                                {
                                    _exitattack = false;
                                }
                            }
                            if (mad.Cn == 11)
                            {
                                bool32 = true;
                            }
                            if (bool32)
                            {
                                if (_oupnt == -1)
                                {
                                    var i33 = -10;
                                    for (var i34 = 0; i34 < CheckPoints.N; i34++)
                                        if (CheckPoints.Typ[i34] == -4 &&
                                            (Py(conto.X / 100, CheckPoints.X[i34] / 100, conto.Z / 100,
                                                 CheckPoints.Z[i34] / 100) < i33 && Medium.Random() > 0.6 ||
                                             i33 == -10))
                                        {
                                            i33 = Py(conto.X / 100, CheckPoints.X[i34] / 100, conto.Z / 100,
                                                CheckPoints.Z[i34] / 100);
                                            _oupnt = i34;
                                        }
                                    _oupnt--;
                                    if (i < 0)
                                    {
                                        _oupnt += CheckPoints.N;
                                    }
                                }
                                if (_oupnt >= 0 && _oupnt < CheckPoints.N)
                                {
                                    i = _oupnt;
                                    if (Py(conto.X / 100, CheckPoints.X[i] / 100, conto.Z / 100,
                                            CheckPoints.Z[i] / 100) < 800)
                                    {
                                        _oupnt = -(int) (75.0F + Medium.Random() * 200.0F);
                                        _runbul = (int) (50.0F + Medium.Random() * 100.0F);
                                    }
                                }
                                if (_oupnt < -1)
                                {
                                    _oupnt++;
                                }
                                if (_runbul != 0)
                                {
                                    _runbul--;
                                }
                            }
                        }
                        mad.Nofocus = true;
                    }
                    if (CheckPoints.Stage != 27)
                    {
                        if (CheckPoints.Stage == 10 || CheckPoints.Stage == 19 ||
                            CheckPoints.Stage == 18 && mad.Pcleared == 73 || CheckPoints.Stage == 26)
                        {
                            _forget = true;
                        }
                        if ((mad.Missedcp == 0 || _forget || _trfix == 4) && _trfix != 0)
                        {
                            var i35 = 0;
                            if (CheckPoints.Stage == 25 || CheckPoints.Stage == 26)
                            {
                                i35 = 3;
                            }
                            if (_trfix == 2)
                            {
                                var i36 = -10;
                                var i37 = 0;
                                for (var i38 = i35; i38 < CheckPoints.Fn; i38++)
                                    if (Py(conto.X / 100, CheckPoints.X[_fpnt[i38]] / 100, conto.Z / 100,
                                            CheckPoints.Z[_fpnt[i38]] / 100) < i36 || i36 == -10)
                                    {
                                        i36 = Py(conto.X / 100, CheckPoints.X[_fpnt[i38]] / 100, conto.Z / 100,
                                            CheckPoints.Z[_fpnt[i38]] / 100);
                                        i37 = i38;
                                    }
                                if (CheckPoints.Stage == 18 || CheckPoints.Stage == 22)
                                {
                                    i37 = 1;
                                }
                                i = _fpnt[i37];
                                _forget = CheckPoints.Special[i37];
                            }
                            for (var i39 = i35; i39 < CheckPoints.Fn; i39++)
                                if (Py(conto.X / 100, CheckPoints.X[_fpnt[i39]] / 100, conto.Z / 100,
                                        CheckPoints.Z[_fpnt[i39]] / 100) < 2000)
                                {
                                    _forget = false;
                                    _actwait = 0;
                                    _upwait = 0;
                                    _turntyp = 2;
                                    _randtcnt = -1;
                                    _acuracy = 0;
                                    _rampp = 0;
                                    _trfix = 3;
                                }
                            if (_trfix == 3)
                            {
                                mad.Nofocus = true;
                            }
                        }
                    }
                    if (_turncnt > _randtcnt)
                    {
                        if (!_gowait)
                        {
                            var i40 = 0;
                            if (CheckPoints.X[i] - conto.X >= 0)
                            {
                                i40 = 180;
                            }
                            _pan = (int) (90 + i40 + Math.Atan(
                                             (CheckPoints.Z[i] - conto.Z) /
                                             (double) (CheckPoints.X[i] - conto.X)) / 0.017453292519943295);
                        }
                        else
                        {
                            var i41 = 0;
                            if (_wtx - conto.X >= 0)
                            {
                                i41 = 180;
                            }
                            _pan = (int) (90 + i41 + Math.Atan((_wtz - conto.Z) / (double) (_wtx - conto.X)) /
                                         0.017453292519943295);
                        }
                        _turncnt = 0;
                        _randtcnt = (int) (_acuracy * Medium.Random());
                    }
                    else
                    {
                        _turncnt++;
                    }
                }
                else
                {
                    Up = true;
                    i = 0;
                    var i42 = (int) (Pys(conto.X, CheckPoints.Opx[_acr], conto.Z, CheckPoints.Opz[_acr]) /
                                     2.0F * _aim);
                    var i43 = (int) (CheckPoints.Opx[_acr] - i42 * Medium.Sin(CheckPoints.Omxz[_acr]));
                    var i44 = (int) (CheckPoints.Opz[_acr] + i42 * Medium.Cos(CheckPoints.Omxz[_acr]));
                    if (i43 - conto.X >= 0)
                    {
                        i = 180;
                    }
                    _pan = (int) (90 + i + Math.Atan((i44 - conto.Z) / (double) (i43 - conto.X)) /
                                 0.017453292519943295);
                    _attack--;
                    if (_attack <= 0)
                    {
                        _attack = 0;
                    }
                    if (CheckPoints.Stage == 25 && _exitattack && !_bulistc && mad.Missedcp != 0)
                    {
                        _attack = 0;
                    }
                    if (CheckPoints.Stage == 26 && mad.Cn == 13 &&
                        (CheckPoints.Clear[0] == 4 || CheckPoints.Clear[0] == 13 || CheckPoints.Clear[0] == 21))
                    {
                        _attack = 0;
                    }
                    if (CheckPoints.Stage == 26 && mad.Missedcp != 0 &&
                        (CheckPoints.Pos[mad.Im] == 0 || CheckPoints.Pos[mad.Im] == 1 && CheckPoints.Pos[0] == 0))
                    {
                        _attack = 0;
                    }
                    if (CheckPoints.Stage == 26 && CheckPoints.Pos[0] > CheckPoints.Pos[mad.Im] &&
                        mad.Power < 80.0F)
                    {
                        _attack = 0;
                    }
                }
                i = conto.Xz;
                if (Zyinv)
                {
                    i += 180;
                }
                for ( /**/; i < 0; i += 360)
                {

                }
                for ( /**/; i > 180; i -= 360)
                {

                }
                for ( /**/; _pan < 0; _pan += 360)
                {

                }
                for ( /**/; _pan > 180; _pan -= 360)
                {

                }
                if (Wall != -1 && _hold == 0)
                {
                    _clrnce = 0;
                }
                if (_hold == 0)
                    if (Math.Abs(i - _pan) < 180)
                    {
                        if (Math.Abs(i - _pan) > _clrnce)
                        {
                            if (i < _pan)
                            {
                                Left = true;
                                _lastl = true;
                            }
                            else
                            {
                                Right = true;
                                _lastl = false;
                            }
                            if (Math.Abs(i - _pan) > 50 && mad.Speed > mad.Stat.Swits[0] && _turntyp != 0)
                            {
                                if (_turntyp == 1)
                                {
                                    Down = true;
                                }
                                if (_turntyp == 2)
                                {
                                    Handb = true;
                                }
                                if (!_agressed)
                                {
                                    Up = false;
                                }
                            }
                        }
                    }
                    else if (Math.Abs(i - _pan) < 360 - _clrnce)
                    {
                        if (i < _pan)
                        {
                            Right = true;
                            _lastl = false;
                        }
                        else
                        {
                            Left = true;
                            _lastl = true;
                        }
                        if (Math.Abs(i - _pan) < 310 && mad.Speed > mad.Stat.Swits[0] && _turntyp != 0)
                        {
                            if (_turntyp == 1)
                            {
                                Down = true;
                            }
                            if (_turntyp == 2)
                            {
                                Handb = true;
                            }
                            if (!_agressed)
                            {
                                Up = false;
                            }
                        }
                    }
                if (CheckPoints.Stage == 24 && Wall != -1)
                {
                    if (Trackers.Dam[Wall] == 0 || mad.Pcleared == 45)
                    {
                        Wall = -1;
                    }
                    if (mad.Pcleared == 58 && CheckPoints.Opz[mad.Im] < 36700)
                    {
                        Wall = -1;
                        _hold = 0;
                    }
                }
                if (Wall != -1)
                {
                    if (_lwall != Wall)
                    {
                        if (_lastl)
                        {
                            Left = true;
                        }
                        else
                        {
                            Right = true;
                        }
                        _wlastl = _lastl;
                        _lwall = Wall;
                    }
                    else if (_wlastl)
                    {
                        Left = true;
                    }
                    else
                    {
                        Right = true;
                    }
                    if (Trackers.Dam[Wall] != 0)
                    {
                        var i45 = 1;
                        if (Trackers.Skd[Wall] == 1)
                        {
                            i45 = 3;
                        }
                        _hold += i45;
                        if (_hold > 10 * i45)
                        {
                            _hold = 10 * i45;
                        }
                    }
                    else
                    {
                        _hold = 1;
                    }
                    Wall = -1;
                }
                else if (_hold != 0)
                {
                    _hold--;
                }
            }
            else
            {
                if (_trickfase == 0)
                {
                    var i = (int) ((mad.Scy[0] + mad.Scy[1] + mad.Scy[2] + mad.Scy[3]) * (conto.Y - 300) /
                                   4000.0F);
                    var i46 = 3;
                    if (CheckPoints.Stage == 25)
                    {
                        i46 = 10;
                    }
                    if (i > 7 && (Medium.Random() > _trickprf / i46 || _stuntf == 4 || _stuntf == 3 || _stuntf == 5 ||
                                  _stuntf == 6 || CheckPoints.Stage == 26))
                    {
                        _oxy = mad.Pxy;
                        _ozy = mad.Pzy;
                        _flycnt = 0;
                        _uddirect = 0;
                        _lrdirect = 0;
                        _udswt = false;
                        _lrswt = false;
                        _trickfase = 1;
                        if (i < 16)
                        {
                            if (_stuntf != 6)
                            {
                                _uddirect = -1;
                                _udstart = 0;
                                _udswt = false;
                            }
                            else if (_oupnt != 70)
                            {
                                _uddirect = 1;
                                _udstart = 0;
                                _udswt = false;
                            }
                        }
                        else if (Medium.Random() > Medium.Random() && _stuntf != 1 || _stuntf == 4 || _stuntf == 6 ||
                                 _stuntf == 7 || _stuntf == 17)
                        {
                            if ((Medium.Random() > Medium.Random() || _stuntf == 2 || _stuntf == 7) && _stuntf != 4 &&
                                _stuntf != 6)
                            {
                                _uddirect = -1;
                            }
                            else
                            {
                                _uddirect = 1;
                            }
                            _udstart = (int) (10.0F * Medium.Random() * _trickprf);
                            if (_stuntf == 6)
                            {
                                _udstart = 0;
                            }
                            if (CheckPoints.Stage == 26)
                            {
                                _udstart = 0;
                            }
                            if (CheckPoints.Stage == 24 && (_oupnt == 68 || _oupnt == 69))
                            {
                                _apunch = 20;
                                _oupnt = 70;
                            }
                            if (Medium.Random() > 0.85 && _stuntf != 4 && _stuntf != 3 && _stuntf != 6 &&
                                _stuntf != 17 && CheckPoints.Stage != 26)
                            {
                                _udswt = true;
                            }
                            if (Medium.Random() > _trickprf + 0.3F && _stuntf != 4 && _stuntf != 6)
                            {
                                if (Medium.Random() > Medium.Random())
                                {
                                    _lrdirect = -1;
                                }
                                else
                                {
                                    _lrdirect = 1;
                                }
                                _lrstart = (int) (30.0F * Medium.Random());
                                if (Medium.Random() > 0.75)
                                {
                                    _lrswt = true;
                                }
                            }
                        }
                        else
                        {
                            if (Medium.Random() > Medium.Random())
                            {
                                _lrdirect = -1;
                            }
                            else
                            {
                                _lrdirect = 1;
                            }
                            _lrstart = (int) (10.0F * Medium.Random() * _trickprf);
                            if (Medium.Random() > 0.75 && CheckPoints.Stage != 26)
                            {
                                _lrswt = true;
                            }
                            if (Medium.Random() > _trickprf + 0.3F)
                            {
                                if (Medium.Random() > Medium.Random())
                                {
                                    _uddirect = -1;
                                }
                                else
                                {
                                    _uddirect = 1;
                                }
                                _udstart = (int) (30.0F * Medium.Random());
                                if (Medium.Random() > 0.85)
                                {
                                    _udswt = true;
                                }
                            }
                        }
                        if (_trfix == 3 || _trfix == 4)
                        {
                            if (CheckPoints.Stage != 18 && CheckPoints.Stage != 8)
                            {
                                if (CheckPoints.Stage != 25 && _lrdirect == -1)
                                    if (CheckPoints.Stage != 19)
                                    {
                                        _uddirect = -1;
                                    }
                                    else
                                    {
                                        _uddirect = 1;
                                    }
                                _lrdirect = 0;
                                if ((CheckPoints.Stage == 19 || CheckPoints.Stage == 25) && _uddirect == -1)
                                {
                                    _uddirect = 1;
                                }
                                if (mad.Power < 60.0F)
                                {
                                    _uddirect = -1;
                                }
                            }
                            else
                            {
                                if (_uddirect != 0)
                                {
                                    _uddirect = -1;
                                }
                                _lrdirect = 0;
                            }
                            if (CheckPoints.Stage == 20)
                            {
                                _uddirect = 1;
                                _lrdirect = 0;
                            }
                            if (CheckPoints.Stage == 26)
                            {
                                _uddirect = -1;
                                _lrdirect = 0;
                                if (mad.Cn != 11 && mad.Cn != 13)
                                {
                                    _udstart = 7;
                                    if (mad.Cn == 14 && mad.Power > 30.0F)
                                    {
                                        _udstart = 14;
                                    }
                                }
                                else
                                {
                                    _udstart = 0;
                                }
                                if (mad.Cn == 11)
                                {
                                    _lrdirect = -1;
                                    _lrstart = 0;
                                }
                            }
                        }
                    }
                    else
                    {
                        _trickfase = -1;
                    }
                    if (!_afta)
                    {
                        _afta = true;
                    }
                    if (_trfix == 3)
                    {
                        _trfix = 4;
                        _statusque += 30;
                    }
                }
                if (_trickfase == 1)
                {
                    _flycnt++;
                    if (_lrdirect != 0 && _flycnt > _lrstart)
                    {
                        if (_lrswt && Math.Abs(mad.Pxy - _oxy) > 180)
                        {
                            if (_lrdirect == -1)
                            {
                                _lrdirect = 1;
                            }
                            else
                            {
                                _lrdirect = -1;
                            }
                            _lrswt = false;
                        }
                        if (_lrdirect == -1)
                        {
                            Handb = true;
                            Left = true;
                        }
                        else
                        {
                            Handb = true;
                            Right = true;
                        }
                    }
                    if (_uddirect != 0 && _flycnt > _udstart)
                    {
                        if (_udswt && Math.Abs(mad.Pzy - _ozy) > 180)
                        {
                            if (_uddirect == -1)
                            {
                                _uddirect = 1;
                            }
                            else
                            {
                                _uddirect = -1;
                            }
                            _udswt = false;
                        }
                        if (_uddirect == -1)
                        {
                            Handb = true;
                            Down = true;
                        }
                        else
                        {
                            Handb = true;
                            Up = true;
                            if (_apunch > 0)
                            {
                                Down = true;
                                _apunch--;
                            }
                        }
                    }
                    if ((mad.Scy[0] + mad.Scy[1] + mad.Scy[2] + mad.Scy[3]) * 100.0F / (conto.Y - 300) < -_saftey)
                    {
                        _onceu = false;
                        _onced = false;
                        _oncel = false;
                        _oncer = false;
                        _lrcomp = false;
                        _udcomp = false;
                        _udbare = false;
                        _lrbare = false;
                        _trickfase = 2;
                        _swat = 0;
                    }
                }
                if (_trickfase == 2)
                {
                    if (_swat == 0)
                    {
                        if (mad.Dcomp != 0.0F || mad.Ucomp != 0.0F)
                        {
                            _udbare = true;
                        }
                        if (mad.Lcomp != 0.0F || mad.Rcomp != 0.0F)
                        {
                            _lrbare = true;
                        }
                        _swat = 1;
                    }
                    if (mad.Wtouch)
                    {
                        if (_swat == 1)
                        {
                            _swat = 2;
                        }
                    }
                    else if (_swat == 2)
                    {
                        if (mad.Capsized && Medium.Random() > _mustland)
                            if (_udbare)
                            {
                                _lrbare = true;
                                _udbare = false;
                            }
                            else if (_lrbare)
                            {
                                _udbare = true;
                                _lrbare = false;
                            }
                        _swat = 3;
                    }
                    if (_udbare)
                    {
                        int i;
                        for (i = mad.Pzy + 90; i < 0; i += 360)
                        {

                        }
                        for ( /**/; i > 180; i -= 360)
                        {

                        }
                        i = Math.Abs(i);
                        if (mad.Lcomp - mad.Rcomp < 5.0F && (_onced || _onceu))
                        {
                            _udcomp = true;
                        }
                        if (mad.Dcomp > mad.Ucomp)
                        {
                            if (mad.Capsized)
                            {
                                if (_udcomp)
                                {
                                    if (i > 90)
                                    {
                                        Up = true;
                                    }
                                    else
                                    {
                                        Down = true;
                                    }
                                }
                                else if (!_onced)
                                {
                                    Down = true;
                                }
                            }
                            else
                            {
                                if (_udcomp)
                                {
                                    if (_perfection && Math.Abs(i - 90) > 30)
                                        if (i > 90)
                                        {
                                            Up = true;
                                        }
                                        else
                                        {
                                            Down = true;
                                        }
                                }
                                else if (Medium.Random() > _mustland)
                                {
                                    Up = true;
                                }
                                _onced = true;
                            }
                        }
                        else if (mad.Capsized)
                        {
                            if (_udcomp)
                            {
                                if (i > 90)
                                {
                                    Up = true;
                                }
                                else
                                {
                                    Down = true;
                                }
                            }
                            else if (!_onceu)
                            {
                                Up = true;
                            }
                        }
                        else
                        {
                            if (_udcomp)
                            {
                                if (_perfection && Math.Abs(i - 90) > 30)
                                    if (i > 90)
                                    {
                                        Up = true;
                                    }
                                    else
                                    {
                                        Down = true;
                                    }
                            }
                            else if (Medium.Random() > _mustland)
                            {
                                Down = true;
                            }
                            _onceu = true;
                        }
                    }
                    if (_lrbare)
                    {
                        var i = mad.Pxy + 90;
                        if (Zyinv)
                        {
                            i += 180;
                        }
                        for ( /**/; i < 0; i += 360)
                        {

                        }
                        for ( /**/; i > 180; i -= 360)
                        {

                        }
                        i = Math.Abs(i);
                        if (mad.Lcomp - mad.Rcomp < 10.0F && (_oncel || _oncer))
                        {
                            _lrcomp = true;
                        }
                        if (mad.Lcomp > mad.Rcomp)
                        {
                            if (mad.Capsized)
                            {
                                if (_lrcomp)
                                {
                                    if (i > 90)
                                    {
                                        Left = true;
                                    }
                                    else
                                    {
                                        Right = true;
                                    }
                                }
                                else if (!_oncel)
                                {
                                    Left = true;
                                }
                            }
                            else
                            {
                                if (_lrcomp)
                                {
                                    if (_perfection && Math.Abs(i - 90) > 30)
                                        if (i > 90)
                                        {
                                            Left = true;
                                        }
                                        else
                                        {
                                            Right = true;
                                        }
                                }
                                else if (Medium.Random() > _mustland)
                                {
                                    Right = true;
                                }
                                _oncel = true;
                            }
                        }
                        else if (mad.Capsized)
                        {
                            if (_lrcomp)
                            {
                                if (i > 90)
                                {
                                    Left = true;
                                }
                                else
                                {
                                    Right = true;
                                }
                            }
                            else if (!_oncer)
                            {
                                Right = true;
                            }
                        }
                        else
                        {
                            if (_lrcomp)
                            {
                                if (_perfection && Math.Abs(i - 90) > 30)
                                    if (i > 90)
                                    {
                                        Left = true;
                                    }
                                    else
                                    {
                                        Right = true;
                                    }
                            }
                            else if (Medium.Random() > _mustland)
                            {
                                Left = true;
                            }
                            _oncer = true;
                        }
                    }
                }
            }
        }

        private int Py(int i, int i47, int i48, int i49) {
            return (i - i47) * (i - i47) + (i48 - i49) * (i48 - i49);
        }

        private int Pys(int i, int i50, int i51, int i52) {
            return (int) Math.Sqrt((i - i50) * (i - i50) + (i51 - i52) * (i51 - i52));
        }

        internal void Reset(int i)
        {
            _pan = 0;
            _attack = 0;
            _acr = 0;
            _afta = false;
            _trfix = 0;
            _acuracy = 0;
            _upwait = 0;
            _forget = false;
            _bulistc = false;
            _runbul = 0;
            _revstart = 0;
            _oupnt = 0;
            _gowait = false;
            _apunch = 0;
            _exitattack = false;
            if (CheckPoints.Stage == 16 || CheckPoints.Stage == 18)
            {
                _hold = 50;
            }
            if (CheckPoints.Stage == 17)
            {
                _hold = 10;
            }
            if (CheckPoints.Stage == 20)
            {
                _hold = 30;
            }
            if (CheckPoints.Stage == 21)
            {
                if (i != 13)
                {
                    _hold = 35;
                    _revstart = 25;
                }
                else
                {
                    _hold = 5;
                }
                _statusque = 0;
            }
            if (CheckPoints.Stage == 22)
            {
                if (i != 13)
                {
                    _hold = (int) (20.0F + 10.0F * Medium.Random());
                    _revstart = (int) (10.0F + 10.0F * Medium.Random());
                }
                else
                {
                    _hold = 5;
                }
                _statusque = 0;
            }
            if (CheckPoints.Stage == 24)
            {
                _hold = 30;
                _statusque = 0;
                if (i != 14)
                {
                    _revstart = 1;
                }
            }
            if (CheckPoints.Stage == 25)
            {
                _hold = 40;
            }
            if (CheckPoints.Stage == 26)
            {
                _hold = 20;
            }
            if (CheckPoints.Stage != 19 && CheckPoints.Stage != 26)
            {
                for (var i0 = 0; i0 < CheckPoints.Fn; i0++)
                {
                    var i1 = -10;
                    for (var i2 = 0; i2 < CheckPoints.N; i2++)
                        if (Py(CheckPoints.Fx[i0] / 100, CheckPoints.X[i2] / 100, CheckPoints.Fz[i0] / 100,
                                CheckPoints.Z[i2] / 100) < i1 || i1 == -10)
                        {
                            i1 = Py(CheckPoints.Fx[i0] / 100, CheckPoints.X[i2] / 100, CheckPoints.Fz[i0] / 100,
                                CheckPoints.Z[i2] / 100);
                            _fpnt[i0] = i2;
                        }
                }
                for (var i3 = 0; i3 < CheckPoints.Fn; i3++)
                {
                    _fpnt[i3] -= 4;
                    if (_fpnt[i3] < 0)
                    {
                        _fpnt[i3] += CheckPoints.Nsp;
                    }
                }
            }
            else
            {
                if (CheckPoints.Stage == 19)
                {
                    _fpnt[0] = 14;
                    _fpnt[1] = 36;
                }
                if (CheckPoints.Stage == 26)
                {
                    _fpnt[3] = 39;
                }
            }
            Left = false;
            Right = false;
            Up = false;
            Down = false;
            Handb = false;
            Lookback = 0;
            Arrace = false;
            Mutem = false;
            Mutes = false;
        }
    }
}