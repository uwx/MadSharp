using System;
using System.Collections.Generic;

namespace Cum
{
    public class HansenData
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
                        var i = GameSparker.Getint("saved", strings[2], 0);
                        if (i >= 0 && i < XTGraphics.NCars)
                        {
                            XTGraphics.Scm = i;
                            XTGraphics.Firstime = false;
                        }
                        i = GameSparker.Getint("saved", strings[2], 1);
                        if (i >= 1 && i <= XTGraphics.NTracks)
                        {
                            XTGraphics.Unlocked = i;
                        }
                    } else if (s.StartsWith("lastcar"))
                    {
                        var i = GameSparker.Getint("lastcar", strings[1], 0);
                        CarDefine.Lastcar = GameSparker.Getastring("lastcar", strings[1], 7);
                        if (i >= 0 && i < 36)
                        {
                            XTGraphics.Osc = i;
                            XTGraphics.Firstime = false;
                        }
                        var i198 = 0;
                        for (var i199 = 0; i199 < 6; i199++)
                        {
                            i = GameSparker.Getint("lastcar", strings[1], i199 + 1);
                            if (i < 0 || i > 100) continue;
                            XTGraphics.Arnp[i199] = i / 100.0F;
                            i198++;
                        }
                        if (i198 == 6 && XTGraphics.Osc >= 0 && XTGraphics.Osc <= 15)
                        {
                            var color = Color.GetHSBColor(XTGraphics.Arnp[0], XTGraphics.Arnp[1],
                                1.0F - XTGraphics.Arnp[2]);
                            var color200 = Color.GetHSBColor(XTGraphics.Arnp[3], XTGraphics.Arnp[4],
                                1.0F - XTGraphics.Arnp[5]);
                            for (var i201 = 0; i201 < contos[XTGraphics.Osc].Npl; i201++)
                                if (contos[XTGraphics.Osc].P[i201].Colnum == 1)
                                {
                                    contos[XTGraphics.Osc].P[i201].C[0] = color.GetRed();
                                    contos[XTGraphics.Osc].P[i201].C[1] = color.GetGreen();
                                    contos[XTGraphics.Osc].P[i201].C[2] = color.GetBlue();
                                }
                            for (var i202 = 0; i202 < contos[XTGraphics.Osc].Npl; i202++)
                                if (contos[XTGraphics.Osc].P[i202].Colnum == 2)
                                {
                                    contos[XTGraphics.Osc].P[i202].C[0] = color200.GetRed();
                                    contos[XTGraphics.Osc].P[i202].C[1] = color200.GetGreen();
                                    contos[XTGraphics.Osc].P[i202].C[2] = color200.GetBlue();
                                }
                        }
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