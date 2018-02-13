using System;
using System.Collections.Generic;

namespace Cum
{
    public static class HansenData
    {
        public static void SetCookie(string[] lines)
        {
            System.IO.File.WriteAllLines("data/user.data", lines);
        }

        internal static void ReadCookie(IReadOnlyList<ContO> contos)
        {
            XTGraphics.Nickname = "";
            try
            {
                var strings = System.IO.File.ReadAllLines("data/user.data");
                foreach (var s in strings)
                {
                    if (s.StartsWith("saved"))
                    {
                        var i = GameSparker.Getint("saved", s, 0);
                        if (i >= 0 && i < XTGraphics.NCars)
                        {
                            XTGraphics.Scm = i;
                            XTGraphics.Firstime = false;
                        }
                        i = GameSparker.Getint("saved", s, 1);
                        if (i >= 1 && i <= XTGraphics.NTracks)
                        {
                            XTGraphics.Unlocked = i;
                        }
                    } else if (s.StartsWith("lastcar"))
                    {
                        var i = GameSparker.Getint("lastcar", s, 0);
                        if (i < 0 || i >= XTGraphics.NCars) continue;
                        XTGraphics.Osc = i;
                        XTGraphics.Firstime = false;
                    } else if (s.StartsWith("carname")) {
                        CarDefine.Lastcar = GameSparker.Getastring("carname", s, 0);
                    } else if (s.StartsWith("carcolor1")) {
                        for (var j = 0; j < 3; j++)
                        {
                            var i = GameSparker.Getint("carcolor1", s, j);
                            if (i < 0 || i > 100) continue;
                            XTGraphics.Arnp[j] = i / 100.0F;
                        }
                        
                        if (XTGraphics.Osc < 0 || XTGraphics.Osc > XTGraphics.NCars-1) continue;
                        var c1 = Color.GetHSBColor(XTGraphics.Arnp[0], XTGraphics.Arnp[1], 1.0F - XTGraphics.Arnp[2]);
                        for (var j = 0; j < contos[XTGraphics.Osc].Npl; j++)
                        {
                            if (contos[XTGraphics.Osc].P[j].Colnum != 1) continue;
                            contos[XTGraphics.Osc].P[j].C[0] = c1.R;
                            contos[XTGraphics.Osc].P[j].C[1] = c1.G;
                            contos[XTGraphics.Osc].P[j].C[2] = c1.B;
                        }

                    } else if (s.StartsWith("carcolor2")) {
                        for (var j = 0; j < 3; j++)
                        {
                            var i = GameSparker.Getint("carcolor2", s, j);
                            if (i < 0 || i > 100) continue;
                            XTGraphics.Arnp[j + 3] = i / 100.0F;
                        }

                        if (XTGraphics.Osc < 0 || XTGraphics.Osc > XTGraphics.NCars-1) continue;
                        var c2 = Color.GetHSBColor(XTGraphics.Arnp[3], XTGraphics.Arnp[4], 1.0F - XTGraphics.Arnp[5]);
                        for (var j = 0; j < contos[XTGraphics.Osc].Npl; j++)
                        {
                            if (contos[XTGraphics.Osc].P[j].Colnum != 2) continue;
                            contos[XTGraphics.Osc].P[j].C[0] = c2.R;
                            contos[XTGraphics.Osc].P[j].C[1] = c2.G;
                            contos[XTGraphics.Osc].P[j].C[2] = c2.B;
                        }
                    } else if (s.StartsWith("volume"))
                    {
                        GameSparker.SetAllVolumes(GameSparker.Getint("volume", s, 0) / 100f);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}