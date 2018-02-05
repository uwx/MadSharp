using System;
using System.Collections.Generic;
using MadGame;
using static Cum.XTGraphics;
using static Cum.XTImages.Images;
using boolean = System.Boolean;

namespace Cum
{
    public class XTPart2
    {
        internal static Image Loadude(byte[] ais)
        {
            return ImageIo.Read(ais);
//        Image image = ImageIO.read(ais);
//        int i = image.getHeight(null);
//        int i364 = image.getWidth(null);
//        int[] is365 = new int[i364 * i];
//        ImageIO.GrabPixels(image, is365);
//        
//        for (int i366 = 0; i366 < i364 * i; i366++) {
//            Color color = new Color(is365[i366]);
//            if (color.getGreen() > color.getRed() + 5 && color.getGreen() > color.getBlue() + 5) {
//                int i367 = (int) (255.0F - (color.getGreen() - (color.getRed() + color.getBlue()) / 2) * 1.5F);
//                if (i367 > 255) {
//                    i367 = 255;
//                }
//                if (i367 < 0) {
//                    i367 = 0;
//                }
//                is365[i366] = i367 << 24 | 0x0 | 0x0 | 0x0;
//            }
//        }
//        BufferedImage bufferedimage = new BufferedImage(i364, i, 2);
//        bufferedimage.setRGB(0, 0, i364, i, is365, 0, i364);
//        return bufferedimage;
        }

        internal static void Mainbg(int i)
        {
            var i26 = 2;
            G.SetColor(new Color(191, 184, 124));
            if (i == -1)
            {
                if (i != Lmode)
                {
                    Bgmy[0] = 0;
                    Bgmy[1] = -400;
                    Bgup = false;
                    Bgf = 0.0F;
                    Lmode = i;
                }
                G.SetColor(new Color(144, 222, 9));
                i26 = 8;
            }
            if (i == 0)
            {
                if (i != Lmode)
                {
                    Bgmy[0] = 0;
                    Bgmy[1] = -400;
                    Bgup = false;
                    Bgf = 0.0F;
                    Lmode = i;
                }
                var i27 = (int) (255.0F * Bgf + 191.0F * (1.0F - Bgf));
                var i28 = (int) (176.0F * Bgf + 184.0F * (1.0F - Bgf));
                var i29 = (int) (67.0F * Bgf + 124.0F * (1.0F - Bgf));
                if (!Bgup)
                {
                    Bgf += 0.02F;
                    if (Bgf > 0.9F)
                    {
                        Bgf = 0.9F;
                        Bgup = true;
                    }
                }
                else
                {
                    Bgf -= 0.02F;
                    if (Bgf < 0.2F)
                    {
                        Bgf = 0.2F;
                        Bgup = false;
                    }
                }
                G.SetColor(new Color(i27, i28, i29));
                i26 = 4;
            }
            if (i == 1)
            {
                if (i != Lmode)
                {
                    Bgmy[0] = 0;
                    Bgmy[1] = -400;
                    Lmode = i;
                }
                G.SetColor(new Color(255, 176, 67));
                i26 = 8;
            }
            if (i == 2)
            {
                if (i != Lmode)
                {
                    Bgmy[0] = 0;
                    Bgmy[1] = -400;
                    Lmode = i;
                    Bgf = 0.2F;
                }
                G.SetColor(new Color(188, 170, 122));
                if (Flipo == 16)
                {
                    var i30 = (int) (176.0F * Bgf + 191.0F * (1.0F - Bgf));
                    var i31 = (int) (202.0F * Bgf + 184.0F * (1.0F - Bgf));
                    var i32 = (int) (255.0F * Bgf + 124.0F * (1.0F - Bgf));
                    G.SetColor(new Color(i30, i31, i32));
                    Bgf += 0.025F;
                    if (Bgf > 0.85F)
                    {
                        Bgf = 0.85F;
                    }
                }
                else
                {
                    Bgf = 0.2F;
                }
                i26 = 2;
            }
            if (i == 3)
            {
                if (i != Lmode)
                {
                    Bgmy[0] = 0;
                    Bgmy[1] = -400;
                    Bgup = false;
                    Bgf = 0.0F;
                    Lmode = i;
                }
                var i33 = (int) (255.0F * Bgf + 191.0F * (1.0F - Bgf));
                var i34 = (int) (176.0F * Bgf + 184.0F * (1.0F - Bgf));
                var i35 = (int) (67.0F * Bgf + 124.0F * (1.0F - Bgf));
                if (!Bgup)
                {
                    Bgf += 0.02F;
                    if (Bgf > 0.9F)
                    {
                        Bgf = 0.9F;
                        Bgup = true;
                    }
                }
                else
                {
                    Bgf -= 0.02F;
                    if (Bgf < 0.2F)
                    {
                        Bgf = 0.2F;
                        Bgup = false;
                    }
                }
                G.SetColor(new Color(i33, i34, i35));
                i26 = 2;
            }
            if (i != -101)
            {
                if (i == 4)
                {
                    G.SetColor(new Color(216, 177, 100));
                    G.FillRect(65, 0, 670, 425);
                }
                else
                {
                    G.FillRect(65, 25, 670, 400);
                }
            }

            if (i == 4)
            {
                if (i != Lmode)
                {
                    Bgmy[0] = 0;
                    Bgmy[1] = 400;
                    for (var i36 = 0; i36 < 4; i36++)
                    {
                        Ovw[i36] = (int) (50.0 + 150.0 * HansenRandom.Double());
                        Ovh[i36] = (int) (50.0 + 150.0 * HansenRandom.Double());
                        Ovy[i36] = (int) (400.0 * HansenRandom.Double());
                        Ovx[i36] = (int) (HansenRandom.Double() * 670.0);
                        Ovsx[i36] = (int) (5.0 + HansenRandom.Double() * 10.0);
                    }
                    Lmode = i;
                }
                for (var i37 = 0; i37 < 4; i37++)
                {
                    G.SetColor(new Color(235, 176, 84));
                    G.FillOval((int) (65 + Ovx[i37] - Ovw[i37] * 1.5 / 2.0),
                        (int) (25 + Ovy[i37] - Ovh[i37] * 1.5 / 2.0), (int) (Ovw[i37] * 1.5), (int) (Ovh[i37] * 1.5));
                    G.SetColor(new Color(255, 176, 67));
                    G.FillOval(65 + Ovx[i37] - Ovh[i37] / 2, 25 + Ovy[i37] - Ovh[i37] / 2, Ovw[i37], Ovh[i37]);
                    Ovx[i37] -= Ovsx[i37];
                    if (Ovx[i37] + Ovw[i37] * 1.5 / 2.0 < 0.0)
                    {
                        Ovw[i37] = (int) (50.0 + 150.0 * HansenRandom.Double());
                        Ovh[i37] = (int) (50.0 + 150.0 * HansenRandom.Double());
                        Ovy[i37] = (int) (400.0 * HansenRandom.Double());
                        Ovx[i37] = (int) (670.0 + Ovw[i37] * 1.5 / 2.0);
                        Ovsx[i37] = (int) (5.0 + HansenRandom.Double() * 10.0);
                    }
                }
            }
            if (i != -101 && i != 4)
            {
                for (var i38 = 0; i38 < 2; i38++)
                {
                    if (i != 2 || Flipo != 16)
                    {
                        G.DrawImage(Bgmain, 65, 25 + Bgmy[i38], null);
                    }
                    Bgmy[i38] += i26;
                    if (Bgmy[i38] >= 400)
                    {
                        Bgmy[i38] = -400;
                    }
                }
            }
            G.SetColor(new Color(0, 0, 0));
            G.FillRect(0, 0, 65, 450);
            G.FillRect(735, 0, 65, 450);
            if (i != 4)
            {
                G.FillRect(65, 0, 670, 25);
            }
            G.FillRect(65, 425, 670, 25);
        }

        internal static void Maini(Control control)
        {
            if (Flipo == 0)
            {
                //app.setCursor(new Cursor(0));
                Flipo++;
            }
            Mainbg(1);
            G.SetAlpha(0.6F);
            G.DrawImage(Logomadbg, 65, 25, null);
            G.SetAlpha(1.0F);
            G.DrawImage(Logomadnes, 233, 186, null);
            var f = Flkat / 800.0F;
            if (f > 0.2)
            {
                f = 0.2F;
            }
            if (Flkat > 200)
            {
                f = (400 - Flkat) / 1000.0F;
                if (f < 0.0F)
                {
                    f = 0.0F;
                }
            }
            Flkat++;
            if (Flkat == 400)
            {
                Flkat = 0;
            }
            G.SetAlpha(f);
            G.DrawImage(Dude[0], 351 + Gxdu, 28 + Gydu, null);
            G.SetAlpha(1.0F);
            if (Movly == 0)
            {
                Gxdu = (int) (5.0 - 11.0 * HansenRandom.Double());
                Gydu = (int) (5.0 - 11.0 * HansenRandom.Double());
            }
            Movly++;
            if (Movly == 2)
            {
                Movly = 0;
            }
            G.DrawImage(Logocars, 66, 33, null);
            G.DrawImage(Opback, 247, 237, null);
            if (Muhi < 0)
            {
                G.SetColor(new Color(140, 70, 0));
                G.FillRoundRect(335, 293, 114, 19, 7, 20);
            }
            Muhi--;
            if (Muhi < -5)
            {
                Muhi = 50;
            }
            if (control.Up)
            {
                Opselect--;
                if (Opselect == -1)
                {
                    Opselect = 3;
                }
                control.Up = false;
            }
            if (control.Down)
            {
                Opselect++;
                if (Opselect == 4)
                {
                    Opselect = 0;
                }
                control.Down = false;
            }
            if (Opselect == 0)
            {
                if (Shaded)
                {
                    G.SetColor(new Color(140, 70, 0));
                    G.FillRect(343, 261, 110, 22);
                    Aflk = false;
                }
                if (Aflk)
                {
                    G.SetColor(new Color(200, 200, 0));
                    Aflk = false;
                }
                else
                {
                    G.SetColor(new Color(255, 128, 0));
                    Aflk = true;
                }
                G.DrawRoundRect(343, 261, 110, 22, 7, 20);
            }
            else
            {
                G.SetColor(new Color(0, 0, 0));
                G.DrawRoundRect(343, 261, 110, 22, 7, 20);
            }
            if (Opselect == 1)
            {
                if (Shaded)
                {
                    G.SetColor(new Color(140, 70, 0));
                    G.FillRect(288, 291, 221, 22);
                    Aflk = false;
                }
                if (Aflk)
                {
                    G.SetColor(new Color(200, 191, 0));
                    Aflk = false;
                }
                else
                {
                    G.SetColor(new Color(255, 95, 0));
                    Aflk = true;
                }
                G.DrawRoundRect(288, 291, 221, 22, 7, 20);
            }
            else
            {
                G.SetColor(new Color(0, 0, 0));
                G.DrawRoundRect(288, 291, 221, 22, 7, 20);
            }
            if (Opselect == 2)
            {
                if (Shaded)
                {
                    G.SetColor(new Color(140, 70, 0));
                    G.FillRect(301, 321, 196, 22);
                    Aflk = false;
                }
                if (Aflk)
                {
                    G.SetColor(new Color(200, 128, 0));
                    Aflk = false;
                }
                else
                {
                    G.SetColor(new Color(255, 128, 0));
                    Aflk = true;
                }
                G.DrawRoundRect(301, 321, 196, 22, 7, 20);
            }
            else
            {
                G.SetColor(new Color(0, 0, 0));
                G.DrawRoundRect(301, 321, 196, 22, 7, 20);
            }
            if (Opselect == 3)
            {
                if (Shaded)
                {
                    G.SetColor(new Color(140, 70, 0));
                    G.FillRect(357, 351, 85, 22);
                    Aflk = false;
                }
                if (Aflk)
                {
                    G.SetColor(new Color(200, 0, 0));
                    Aflk = false;
                }
                else
                {
                    G.SetColor(new Color(255, 128, 0));
                    Aflk = true;
                }
                G.DrawRoundRect(357, 351, 85, 22, 7, 20);
            }
            else
            {
                G.SetColor(new Color(0, 0, 0));
                G.DrawRoundRect(357, 351, 85, 22, 7, 20);
            }
            G.DrawImage(Opti, 294, 265, null);
            if (control.Enter || control.Handb)
            {
                if (Opselect == 1)
                {
                    Mtop = true;
                    Multion = 1;
                    Gmode = 0;
                    if (Firstime)
                    {
                        Oldfase = -9;
                        Fase = 11;
                        Firstime = false;
                    }
                    else
                    {
                        Fase = -9;
                    }
                }
                if (Opselect == 2)
                {
                    Oldfase = 10;
                    Fase = 11;
                    Firstime = false;
                }
                if (Opselect == 3)
                {
                    Fase = 8;
                }
                if (Opselect == 0)
                {
                    /*if (unlocked[0] == 11)
       if (unlocked[1] != 17)
           opselect = 1;
       else
           opselect = 2;*/
                    if (Firstime)
                    {
                        Oldfase = 102;
                        Fase = 11;
                        Firstime = false;
                    }
                    else
                    {
                        Fase = 102;
                    }
                }

                Flipo = 0;
                control.Enter = false;
                control.Handb = false;
            }
            G.DrawImage(Byrd, 72, 410, null);
            G.DrawImage(Nfmcoms, 567, 410, null);
            if (Shaded)
            {
                //app.repaint();
                try
                {
                    HansenSystem.RequestSleep(200L);
                }
                catch (Exception ignored)
                {
                }
            }
        }

        internal static void Maini2()
        {
            Mainbg(1);
            Multion = 0;
            Clangame = 0;
            Gmode = 2;
            Fase = -9;
            Opselect = 0;
        }

        internal static void Makecarsbgc(Image image, Image image386)
        {
            Carsbgc = Carsbg; // TODO
//        int[] ais = new int[268000];
//        PixelGrabber pixelgrabber = new PixelGrabber(carsbg, 0, 0, 670, 400, ais, 0, 670);
//        try {
//            pixelgrabber.grabPixels();
//        } catch (InterruptedException ignored) {
//
//        }
//        int[] is387 = new int[20700];
//        PixelGrabber pixelgrabber388 = new PixelGrabber(image, 0, 0, 92, 225, is387, 0, 92);
//        try {
//            pixelgrabber388.grabPixels();
//        } catch (InterruptedException ignored) {
//
//        }
//        int[] is389 = new int[2112];
//        PixelGrabber pixelgrabber390 = new PixelGrabber(image386, 0, 0, 88, 24, is389, 0, 88);
//        try {
//            pixelgrabber390.grabPixels();
//        } catch (InterruptedException ignored) {
//
//        }
//        for (int i = 0; i < 670; i++) {
//            for (int i391 = 0; i391 < 400; i391++) {
//                if (i > 14 && i < 106 && i391 > 11 && i391 < 236 && is387[i - 14 + (i391 - 11) * 92] != is387[0]) {
//                    Color color = new Color(ais[i + i391 * 670]);
//                    Color color392 = new Color(is387[i - 14 + (i391 - 11) * 92]);
//                    int i393 = (int) (color.getRed() * 0.33 + color392.getRed() * 0.67);
//                    if (i393 > 255) {
//                        i393 = 255;
//                    }
//                    if (i393 < 0) {
//                        i393 = 0;
//                    }
//                    int i394 = (int) (color.getGreen() * 0.33 + color392.getGreen() * 0.67);
//                    if (i394 > 255) {
//                        i394 = 255;
//                    }
//                    if (i394 < 0) {
//                        i394 = 0;
//                    }
//                    int i395 = (int) (color.getBlue() * 0.33 + color392.getBlue() * 0.67);
//                    if (i395 > 255) {
//                        i395 = 255;
//                    }
//                    if (i395 < 0) {
//                        i395 = 0;
//                    }
//                    Color color396 = new Color(i393, i394, i395);
//                    ais[i + i391 * 670] = color396.getRGB();
//                }
//                if (i > 564 && i < 656 && i391 > 11 && i391 < 236 && is387[i - 564 + (i391 - 11) * 92] != is387[0]) {
//                    Color color = new Color(ais[i + i391 * 670]);
//                    Color color397 = new Color(is387[i - 564 + (i391 - 11) * 92]);
//                    int i398 = (int) (color.getRed() * 0.33 + color397.getRed() * 0.67);
//                    if (i398 > 255) {
//                        i398 = 255;
//                    }
//                    if (i398 < 0) {
//                        i398 = 0;
//                    }
//                    int i399 = (int) (color.getGreen() * 0.33 + color397.getGreen() * 0.67);
//                    if (i399 > 255) {
//                        i399 = 255;
//                    }
//                    if (i399 < 0) {
//                        i399 = 0;
//                    }
//                    int i400 = (int) (color.getBlue() * 0.33 + color397.getBlue() * 0.67);
//                    if (i400 > 255) {
//                        i400 = 255;
//                    }
//                    if (i400 < 0) {
//                        i400 = 0;
//                    }
//                    Color color401 = new Color(i398, i399, i400);
//                    ais[i + i391 * 670] = color401.getRGB();
//                }
//                if (i > 440 && i < 528 && i391 > 53 && i391 < 77 && is389[i - 440 + (i391 - 53) * 88] != is389[0]) {
//                    Color color = new Color(ais[i + i391 * 670]);
//                    Color color402 = new Color(is389[i - 440 + (i391 - 53) * 88]);
//                    int i403 = (int) (color.getRed() * 0.33 + color402.getRed() * 0.67);
//                    if (i403 > 255) {
//                        i403 = 255;
//                    }
//                    if (i403 < 0) {
//                        i403 = 0;
//                    }
//                    int i404 = (int) (color.getGreen() * 0.33 + color402.getGreen() * 0.67);
//                    if (i404 > 255) {
//                        i404 = 255;
//                    }
//                    if (i404 < 0) {
//                        i404 = 0;
//                    }
//                    int i405 = (int) (color.getBlue() * 0.33 + color402.getBlue() * 0.67);
//                    if (i405 > 255) {
//                        i405 = 255;
//                    }
//                    if (i405 < 0) {
//                        i405 = 0;
//                    }
//                    Color color406 = new Color(i403, i404, i405);
//                    ais[i + i391 * 670] = color406.getRGB();
//                }
//            }
//        }
//        carsbgc = xt.createImage(new MemoryImageSource(670, 400, ais, 0, 670));
        }

        static bool Msgcheck(string astring)
        {
            var abool = false;
            astring = astring.ToLower();
            string[] strings =
            {
                "fu ", " rape", "slut ", "screw ", "redtube", "fuck", "fuk", "f*ck", "fu*k", "f**k",
                "ass hole",
                "asshole", "dick", "dik", "cock", "cok ", "shit", "damn", "sex", "anal", "whore", "bitch",
                "biatch",
                "bich", " ass", "bastard", "cunt", "dildo", "fag", "homo", "mothaf", "motherf", "negro",
                "nigga",
                "nigger", "pussy", "gay", "homo", "you punk", "i will kill you"
            };
            foreach (var string2 in strings)
            {
                if (astring.Contains(string2))
                {
                    abool = true;
                }
            }

            if (astring.StartsWith("ass "))
            {
                abool = true;
            }
            if (astring.Equals("ass"))
            {
                abool = true;
            }
            if (astring.Equals("rape"))
            {
                abool = true;
            }
            if (astring.Equals("fu"))
            {
                abool = true;
            }
            var string419 = "";
            var string420 = "";
            var i = 0;
            var bool421 = false;
            bool bool422;
            for (bool422 = false; i < astring.Length() && !bool422; i++)
            {
                if (!bool421)
                {
                    string419 = "" + string419 + "" + astring.CharAt(i);
                    bool421 = true;
                }
                else
                {
                    bool421 = false;
                    if (!string420.Equals("") && !string420.Equals("" + astring.CharAt(i)))
                    {
                        bool422 = true;
                    }
                    string420 = "" + astring.CharAt(i);
                }
            }

            if (!bool422)
            {
                foreach (var string2 in strings)
                {
                    if (string419.Contains(string2))
                    {
                        abool = true;
                    }
                }
            }
            string419 = "";
            string420 = "";
            i = 0;
            bool421 = true;
            for (bool422 = false; i < astring.Length() && !bool422; i++)
            {
                if (!bool421)
                {
                    string419 = "" + string419 + "" + astring.CharAt(i);
                    bool421 = true;
                }
                else
                {
                    bool421 = false;
                    if (!string420.Equals("") && !string420.Equals("" + astring.CharAt(i)))
                    {
                        bool422 = true;
                    }
                    string420 = "" + astring.CharAt(i);
                }
            }

            if (!bool422)
            {
                foreach (var string2 in strings)
                {
                    if (string419.Contains(string2))
                    {
                        abool = true;
                    }
                }
            }
            string419 = "";
            string420 = "";
            i = 0;
            var i425 = 0;
            for (bool422 = false; i < astring.Length() && !bool422; i++)
            {
                if (i425 == 0)
                {
                    string419 = "" + string419 + "" + astring.CharAt(i);
                    i425 = 2;
                }
                else
                {
                    i425--;
                    if (!string420.Equals("") && !string420.Equals("" + astring.CharAt(i)))
                    {
                        bool422 = true;
                    }
                    string420 = "" + astring.CharAt(i);
                }
            }

            if (!bool422)
            {
                foreach (var string2 in strings)
                {
                    if (string419.Contains(string2))
                    {
                        abool = true;
                    }
                }
            }
            string419 = "";
            string420 = "";
            i = 0;
            i425 = 1;
            for (bool422 = false; i < astring.Length() && !bool422; i++)
            {
                if (i425 == 0)
                {
                    string419 = "" + string419 + "" + astring.CharAt(i);
                    i425 = 2;
                }
                else
                {
                    i425--;
                    if (!string420.Equals("") && !string420.Equals("" + astring.CharAt(i)))
                    {
                        bool422 = true;
                    }
                    string420 = "" + astring.CharAt(i);
                }
            }

            if (!bool422)
            {
                foreach (var string2 in strings)
                {
                    if (string419.Contains(string2))
                    {
                        abool = true;
                    }
                }
            }
            string419 = "";
            string420 = "";
            i = 0;
            i425 = 2;
            for (bool422 = false; i < astring.Length() && !bool422; i++)
            {
                if (i425 == 0)
                {
                    string419 = "" + string419 + "" + astring.CharAt(i);
                    i425 = 2;
                }
                else
                {
                    i425--;
                    if (!string420.Equals("") && !string420.Equals("" + astring.CharAt(i)))
                    {
                        bool422 = true;
                    }
                    string420 = "" + astring.CharAt(i);
                }
            }

            if (!bool422)
            {
                foreach (var string2 in strings)
                {
                    if (string419.Contains(string2))
                    {
                        abool = true;
                    }
                }
            }
            return abool;
        }

        static void Multistat(Control control, int i, int i53, bool abool)
        {
//        int i54 = -1;
//        if (fase != -2) {
//            if (exitm != 0 && !holdit) {
//                if (!lan || im != 0) {
////                    if (abool)
////                        if (i > 357 && i < 396 && i53 > 162 && i53 < 179) {
////                            exitm = 2;
////                            if (multion == 1 && !lan && sendstat == 0) {
////                                sendstat = 1;
////                                if (runtyp != -101) {
////                                    if (runner != null) {
////                                        runner.interrupt();
////                                    }
////                                    runner = null;
////                                    runner = new Thread(xt);
////                                    runner.start();
////                                }
////                            }
////                        } else {
////                            exitm = 0;
////                        }
//                    float[] fs = new float[3];
//                    Color.RGBtoHSB(Medium.cgrnd[0], Medium.cgrnd[1], Medium.cgrnd[2], fs);
//                    fs[1] -= 0.15;
//                    if (fs[1] < 0.0F) {
//                        fs[1] = 0.0F;
//                    }
//                    fs[2] += 0.15;
//                    if (fs[2] > 1.0F) {
//                        fs[2] = 1.0F;
//                    }
//                    G.SetColor(Color.getHSBColor(fs[0], fs[1], fs[2]));
//                    G.FillRect(357, 169, 39, 10);
//                    G.FillRect(403, 169, 39, 10);
//                    fs[1] -= 0.07;
//                    if (fs[1] < 0.0F) {
//                        fs[1] = 0.0F;
//                    }
//                    fs[2] += 0.07;
//                    if (fs[2] > 1.0F) {
//                        fs[2] = 1.0F;
//                    }
//                    G.SetColor(Color.getHSBColor(fs[0], fs[1], fs[2]));
//                    G.FillRect(357, 162, 39, 7);
//                    G.FillRect(403, 162, 39, 7);
//                    drawhi(exitgame, 116);
//                    if (i > 357 && i < 396 && i53 > 162 && i53 < 179) {
//                        G.SetColor(new Color(Medium.csky[0], Medium.csky[1], Medium.csky[2]));
//                        G.FillRect(357, 162, 39, 17);
//                    }
//                    if (i > 403 && i < 442 && i53 > 162 && i53 < 179) {
//                        G.SetColor(new Color(Medium.csky[0], Medium.csky[1], Medium.csky[2]));
//                        G.FillRect(403, 162, 39, 17);
//                    }
//                    G.SetColor(new Color(0, 0, 0));
//                    G.DrawString("Yes", 366, 175);
//                    G.DrawString("No", 416, 175);
//                    G.SetColor(new Color(Medium.csky[0] / 2, Medium.csky[1] / 2, Medium.csky[2] / 2));
//                    G.DrawRect(403, 162, 39, 17);
//                    G.DrawRect(357, 162, 39, 17);
//                } else {
//                    G.SetFont(new Font("Arial", 1, 13));
//                    ftm = G.GetFontMetrics();
//                    drawcs(125, "You cannot exit game.  Your computer ais the LAN server!", 0, 0, 0, 0);
//                    msgflk[0]++;
//                    if (msgflk[0] == 67 || abool) {
//                        msgflk[0] = 0;
//                        exitm = 0;
//                    }
//                    G.SetFont(new Font("Arial", 1, 11));
//                    ftm = G.GetFontMetrics();
//                }
//            } else if (exitm == 4) {
//                if (abool) {
//                    if (i > 357 && i < 396 && i53 > 362 && i53 < 379) {
//                        alocked = -1;
//                        lalocked = -1;
//                        multion = 2;
//                        control.multion = multion;
//                        holdit = false;
//                        exitm = 0;
//                        control.chatup = 0;
//                    }
//                    if ((!lan || im != 0) && i > 403 && i < 442 && i53 > 362 && i53 < 379) {
//                        holdcnt = 600;
//                        exitm = 0;
//                        control.chatup = 0;
//                    }
//                }
//                float[] fs = new float[3];
//                Color.RGBtoHSB(Medium.cgrnd[0], Medium.cgrnd[1], Medium.cgrnd[2], fs);
//                fs[1] -= 0.15;
//                if (fs[1] < 0.0F) {
//                    fs[1] = 0.0F;
//                }
//                fs[2] += 0.15;
//                if (fs[2] > 1.0F) {
//                    fs[2] = 1.0F;
//                }
//                G.SetColor(Color.getHSBColor(fs[0], fs[1], fs[2]));
//                G.FillRect(357, 369, 39, 10);
//                if (!lan || im != 0) {
//                    G.FillRect(403, 369, 39, 10);
//                }
//                fs[1] -= 0.07;
//                if (fs[1] < 0.0F) {
//                    fs[1] = 0.0F;
//                }
//                fs[2] += 0.07;
//                if (fs[2] > 1.0F) {
//                    fs[2] = 1.0F;
//                }
//                G.SetColor(Color.getHSBColor(fs[0], fs[1], fs[2]));
//                G.FillRect(357, 362, 39, 7);
//                if (!lan || im != 0) {
//                    G.FillRect(403, 362, 39, 7);
//                }
//                G.SetColor(new Color(0, 0, 0));
//                G.SetFont(new Font("Arial", 1, 13));
//                ftm = G.GetFontMetrics();
//                if (lan && im == 0) {
//                    drawcs(140, "(You cannot exit game.  Your computer ais the LAN server... )", 0, 0, 0, 0);
//                }
//                G.DrawString("Continue watching this game?", 155, 375);
//                if (i > 357 && i < 396 && i53 > 362 && i53 < 379) {
//                    G.SetColor(new Color(Medium.csky[0], Medium.csky[1], Medium.csky[2]));
//                    G.FillRect(357, 362, 39, 17);
//                }
//                if ((!lan || im != 0) && i > 403 && i < 442 && i53 > 362 && i53 < 379) {
//                    G.SetColor(new Color(Medium.csky[0], Medium.csky[1], Medium.csky[2]));
//                    G.FillRect(403, 362, 39, 17);
//                }
//                G.SetFont(new Font("Arial", 1, 11));
//                ftm = G.GetFontMetrics();
//                G.SetColor(new Color(0, 0, 0));
//                G.DrawString("Yes", 366, 375);
//                if (!lan || im != 0) {
//                    G.DrawString("No", 416, 375);
//                }
//                G.SetColor(new Color(Medium.csky[0] / 2, Medium.csky[1] / 2, Medium.csky[2] / 2));
//                if (!lan || im != 0) {
//                    G.DrawRoundRect(147, 357, 301, 27, 7, 20);
//                } else {
//                    G.DrawRoundRect(147, 357, 262, 27, 7, 20);
//                }
//                G.DrawRect(357, 362, 39, 17);
//                if (!lan || im != 0) {
//                    G.DrawRect(403, 362, 39, 17);
//                }
//            }
//            if (runtyp == -101 && !lan) {
//                if (warning == 0 || warning == 210) {
//                    int i55 = 0;
//                    int i56 = 0;
//                    if (clanchat) {
//                        i55 = 1;
//                        i56 = -23;
//                    } else if (control.chatup == 2) {
//                        control.chatup = 1;
//                    }
//                    for (int i57 = i55; i57 >= 0; i57--) {
//                        boolean bool58 = false;
//                        if (i > 5 && i < 33 && i53 > 423 + i56 && i53 < 446 + i56) {
//                            bool58 = true;
//                            if (control.chatup != 0) {
//                                control.chatup = 0;
//                            }
//                        } else if (pointc[i57] != 6) {
//                            pointc[i57] = 6;
//                            floater[i57] = 1;
//                        }
//                        if (i > 33 && i < 666 && i53 > 423 + i56 && i53 < 446 + i56 && lxm != i && i53 != lym && lxm != -100) {
//                            control.chatup = i57 + 1;
//                            cntchatp[i57] = 0;
//                        }
//                        if (i57 == 0) {
//                            lxm = i;
//                            lym = i53;
//                        }
//                        if (exitm != 0 && exitm != 4) {
//                            control.chatup = 0;
//                        }
//                        boolean bool59 = false;
//                        if (control.enter && control.chatup == i57 + 1) {
//                            bool59 = true;
//                            control.chatup = 0;
//                            control.enter = false;
//                            lxm = -100;
//                        }
//                        if (abool) {
//                            if (mouson == 0) {
//                                if (i > 676 && i < 785 && i53 > 426 + i56 && i53 < 443 + i56 && control.chatup == i57 + 1) {
//                                    bool59 = true;
//                                    control.chatup = 0;
//                                }
//                                if (bool58 && pointc[i57] > 0) {
//                                    pointc[i57]--;
//                                    floater[i57] = 1;
//                                }
//                                if (i57 == 0) {
//                                    mouson = 1;
//                                }
//                            }
//                            if (i57 == 0) {
//                                control.chatup = 0;
//                            }
//                        } else if (i57 == 0 && mouson != 0) {
//                            mouson = 0;
//                        }
//                        if (bool59) {
//                            String astring = "";
//                            int i60 = 0;
//                            int i61 = 1;
//                            for (; i60 < lcmsg[i57].length(); i60++) {
//                                String string62 = "" + lcmsg[i57].charAt(i60);
//                                if (string62.equals(" ")) {
//                                    i61++;
//                                } else {
//                                    i61 = 0;
//                                }
//                                if (i61 < 2) {
//                                    astring = "" + astring + string62;
//                                }
//                            }
//                            if (!astring.equals("")) {
//                                astring = astring.replace('|', ':');
//                                if (astring.ToLower().contains(GameSparker.tpass.getText().ToLower())) {
//                                    astring = " ";
//                                }
//                                if (!msgcheck(astring) && updatec[i57] > -12) {
//                                    if (cnames[i57][6].equals("Game Chat  ") || cnames[i57][6].equals("" + clan + "'s Chat  ")) {
//                                        cnames[i57][6] = "";
//                                    }
//                                    for (int i63 = 0; i63 < 6; i63++) {
//                                        sentn[i57][i63] = sentn[i57][i63 + 1];
//                                        cnames[i57][i63] = cnames[i57][i63 + 1];
//                                    }
//                                    sentn[i57][6] = astring;
//                                    cnames[i57][6] = nickname;
//                                    if (pointc[i57] != 6) {
//                                        pointc[i57] = 6;
//                                        floater[i57] = 1;
//                                    }
//                                    msgflk[i57] = 110;
//                                    if (updatec[i57] > -11) {
//                                        updatec[i57] = -11;
//                                    } else {
//                                        updatec[i57]--;
//                                    }
//                                } else {
//                                    warning++;
//                                }
//                            }
//                        }
//                        if (bool58 || floater[i57] != 0 || control.chatup == i57 + 1 || msgflk[i57] != 0) {
//                            float[] fs = new float[3];
//                            Color.RGBtoHSB(Medium.cgrnd[0], Medium.cgrnd[1], Medium.cgrnd[2], fs);
//                            fs[1] -= 0.15;
//                            if (fs[1] < 0.0F) {
//                                fs[1] = 0.0F;
//                            }
//                            fs[2] += 0.15;
//                            if (fs[2] > 1.0F) {
//                                fs[2] = 1.0F;
//                            }
//                            G.SetColor(Color.getHSBColor(fs[0], fs[1], fs[2]));
//                            G.FillRect(33, 423 + i56, 761, 23);
//                        }
//                        if (control.chatup == 0 && GameSparker.cmsg.isShowing()) {
//                            GameSparker.cmsg.setVisible(false);
//                            app.requestFocus();
//                        }
//                        if (control.chatup != i57 + 1) {
//                            int i64 = 0;
//                            int i65 = (int) (48.0F + 48.0F * (Medium.snap[1] / 100.0F));
//                            if (i65 > 255) {
//                                i65 = 255;
//                            }
//                            if (i65 < 0) {
//                                i65 = 0;
//                            }
//                            int i66 = (int) (96.0F + 96.0F * (Medium.snap[2] / 100.0F));
//                            if (i66 > 255) {
//                                i66 = 255;
//                            }
//                            if (i66 < 0) {
//                                i66 = 0;
//                            }
//                            if (floater[i57] != 0) {
//                                for (int i67 = 6; i67 >= 0; i67--) {
//                                    if (pointc[i57] == i67)
//                                        if (Math.Abs(i64 + movepos[i57]) > 10) {
//                                            floater[i57] = (movepos[i57] + i64) / 4;
//                                            if (floater[i57] > -5 && floater[i57] < 0) {
//                                                floater[i57] = -5;
//                                            }
//                                            if (floater[i57] < 10 && floater[i57] > 0) {
//                                                floater[i57] = 10;
//                                            }
//                                            movepos[i57] -= floater[i57];
//                                        } else {
//                                            movepos[i57] = -i64;
//                                            floater[i57] = 0;
//                                        }
//                                    if (pointc[i57] >= i67) {
//                                        G.SetColor(new Color(0, i65, i66));
//                                        G.SetFont(new Font("Tahoma", 1, 11));
//                                        ftm = G.GetFontMetrics();
//                                        G.DrawString("" + cnames[i57][i67] + ": ", 39 + i64 + movepos[i57], 439 + i56);
//                                        i64 += ftm.stringWidth("" + cnames[i57][i67] + ": ");
//                                        G.SetColor(new Color(0, 0, 0));
//                                        G.SetFont(new Font("Tahoma", 0, 11));
//                                        ftm = G.GetFontMetrics();
//                                        G.DrawString("" + sentn[i57][i67] + "   ", 39 + i64 + movepos[i57], 439 + i56);
//                                        i64 += ftm.stringWidth("" + sentn[i57][i67] + "   ");
//                                    } else {
//                                        i64 += ftm.stringWidth("" + cnames[i57][i67] + ": ");
//                                        i64 += ftm.stringWidth("" + sentn[i57][i67] + "   ");
//                                    }
//                                }
//                                G.SetColor(new Color(0, 0, 0));
//                                G.FillRect(0, 423 + i56, 5, 24);
//                                G.FillRect(794, 423 + i56, 6, 24);
//                            } else {
//                                for (int i68 = pointc[i57]; i68 >= 0; i68--) {
//                                    if (i68 == 6 && msgflk[i57] != 0) {
//                                        msgflk[i57]--;
//                                    }
//                                    G.SetColor(new Color(0, i65, i66));
//                                    G.SetFont(new Font("Tahoma", 1, 11));
//                                    ftm = G.GetFontMetrics();
//                                    if (ftm.stringWidth("" + cnames[i57][i68] + ": ") + 39 + i64 < 775) {
//                                        if (i68 != 6 || msgflk[i57] < 67 || msgflk[i57] % 3 != 0) {
//                                            G.DrawString("" + cnames[i57][i68] + ": ", 39 + i64, 439 + i56);
//                                        }
//                                        i64 += ftm.stringWidth("" + cnames[i57][i68] + ": ");
//                                    } else {
//                                        String astring = "";
//                                        for (int i69 = 0; ftm.stringWidth(astring) + 39 + i64 < 775 && i69 < cnames[i57][i68].length(); i69++) {
//                                            astring = "" + astring + cnames[i57][i68].charAt(i69);
//                                        }
//                                        astring = "" + astring + "...";
//                                        if (i68 != 6 || msgflk[i57] < 67 || msgflk[i57] % 3 != 0) {
//                                            G.DrawString(astring, 39 + i64, 439 + i56);
//                                        }
//                                        break;
//                                    }
//                                    G.SetColor(new Color(0, 0, 0));
//                                    G.SetFont(new Font("Tahoma", 0, 11));
//                                    ftm = G.GetFontMetrics();
//                                    if (ftm.stringWidth(sentn[i57][i68]) + 39 + i64 < 775) {
//                                        if (i68 != 6 || msgflk[i57] < 67 || msgflk[i57] % 3 != 0) {
//                                            G.DrawString("" + sentn[i57][i68] + "   ", 39 + i64, 439 + i56);
//                                        }
//                                        i64 += ftm.stringWidth("" + sentn[i57][i68] + "   ");
//                                    } else {
//                                        String astring = "";
//                                        for (int i70 = 0; ftm.stringWidth(astring) + 39 + i64 < 775 && i70 < sentn[i57][i68].length(); i70++) {
//                                            astring = "" + astring + sentn[i57][i68].charAt(i70);
//                                        }
//                                        astring = "" + astring + "...";
//                                        if (i68 != 6 || msgflk[i57] < 67 || msgflk[i57] % 3 != 0) {
//                                            G.DrawString(astring, 39 + i64, 439 + i56);
//                                        }
//                                        break;
//                                    }
//                                }
//                            }
//                        } else {
//                            msgflk[i57] = 0;
//                            i54 = i57;
//                        }
//                        if (bool58 || floater[i57] != 0) {
//                            float[] fs = new float[3];
//                            Color.RGBtoHSB(Medium.cgrnd[0], Medium.cgrnd[1], Medium.cgrnd[2], fs);
//                            fs[1] -= 0.076;
//                            if (fs[1] < 0.0F) {
//                                fs[1] = 0.0F;
//                            }
//                            fs[2] += 0.076;
//                            if (fs[2] > 1.0F) {
//                                fs[2] = 1.0F;
//                            }
//                            G.SetColor(Color.getHSBColor(fs[0], fs[1], fs[2]));
//                            G.FillRect(5, 423 + i56, 28, 23);
//                        }
//                        if (bool58) {
//                            G.SetColor(new Color(0, 0, 0));
//                        } else {
//                            G.SetColor(new Color((int) (Medium.cgrnd[0] / 2.0F), (int) (Medium.cgrnd[1] / 2.0F), (int) (Medium.cgrnd[2] / 2.0F)));
//                        }
//                        G.SetFont(new Font("Tahoma", 1, 11));
//                        G.DrawString("<<", 10, 439 + i56);
//                        G.SetColor(new Color(0, 0, 0));
//                        G.DrawRect(5, 423 + i56, 789, 23);
//                        G.DrawLine(33, 423 + i56, 33, 446 + i56);
//                        i56 += 23;
//                    }
//                    if (i > 775 && i < 794 && i53 > 409 - i55 * 23 && i53 < 423 - i55 * 23) {
//                        G.DrawRect(775, 409 - i55 * 23, 19, 14);
//                        G.SetColor(new Color(200, 0, 0));
//                        if (abool) {
//                            control.chatup = 0;
//                            if (GameSparker.cmsg.isShowing()) {
//                                GameSparker.cmsg.setVisible(false);
//                                app.requestFocus();
//                            }
//                            runtyp = 0;
//                            try {
//                                socket.close();
//                                socket = null;
//                                din.close();
//                                din = null;
//                                dout.close();
//                                dout = null;
//                            } catch (Exception ignored) {
//
//                            }
//                        }
//                    }
//                    G.SetFont(new Font("Arial", 1, 12));
//                    G.DrawString("x", 782, 420 - i55 * 23);
//                } else {
//                    drawWarning();
//                    if (GameSparker.cmsg.isShowing()) {
//                        GameSparker.cmsg.setVisible(false);
//                        app.requestFocus();
//                    }
//                    warning++;
//                }
//                G.SetFont(new Font("Arial", 1, 11));
//                ftm = G.GetFontMetrics();
//            } else if (control.chatup != 0) {
//                control.chatup = 0;
//                if (!lan) {
//                    runtyp = -101;
//                    if (runner != null) {
//                        runner.interrupt();
//                    }
//                    runner = null;
//                    runner = new Thread(xt);
//                    runner.start();
//                }
//            }
//            if (holdit && multion == 1 && !lan && sendstat == 0) {
//                sendstat = 1;
//                if (runtyp != -101) {
//                    if (runner != null) {
//                        runner.interrupt();
//                    }
//                    runner = null;
//                    runner = new Thread(xt);
//                    runner.start();
//                }
//            }
//            if (control.arrace && starcnt < 38 && !holdit && CheckPoints.stage != 10 || multion >= 2) {
//                if (alocked != -1 && CheckPoints.dested[alocked] != 0) {
//                    alocked = -1;
//                    lalocked = -1;
//                }
//                if (multion >= 2) {
//                    if (alocked == -1 || holdit) {
//                        if (cntflock == 100) {
//                            for (int i71 = 0; i71 < nplayers; i71++)
//                                if (holdit) {
//                                    if (CheckPoints.pos[i71] == 0) {
//                                        alocked = i71;
//                                        im = i71;
//                                    }
//                                } else if (CheckPoints.dested[i71] == 0) {
//                                    alocked = i71;
//                                    im = i71;
//                                }
//                        }
//                        cntflock++;
//                    } else {
//                        cntflock = 0;
//                    }
//                    if (lan) {
//                        boolean bool72 = true;
//                        for (int i73 = 0; i73 < nplayers; i73++)
//                            if (dested[i73] == 0 && !plnames[i73].contains("MadBot")) {
//                                bool72 = false;
//                            }
//                        if (bool72) {
//                            exitm = 2;
//                        }
//                    }
//                }
//                int i74 = nplayers;
//                for (int i75 = 0; i75 < i74; i75++) {
//                    boolean bool76 = false;
//                    for (int i77 = 0; i77 < nplayers; i77++)
//                        if (CheckPoints.pos[i77] == i75 && CheckPoints.dested[i77] == 0 && !bool76) {
//                            int i81 = (int) (100.0F + 100.0F * (Medium.snap[2] / 100.0F));
//                            if (i81 > 255) {
//                                i81 = 255;
//                            }
//                            if (i81 < 0) {
//                                i81 = 0;
//                            }
//                            G.SetColor(new Color(0, 0, i81));
//                            if (i75 == 0) {
//                                G.DrawString("1st", 673, 76 + 30 * i75);
//                            }
//                            if (i75 == 1) {
//                                G.DrawString("2nd", 671, 76 + 30 * i75);
//                            }
//                            if (i75 == 2) {
//                                G.DrawString("3rd", 671, 76 + 30 * i75);
//                            }
//                            if (i75 >= 3) {
//                                G.DrawString("" + (i75 + 1) + "th", 671, 76 + 30 * i75);
//                            }
//                            if (clangame != 0) {
//                                int i82;
//                                int i83;
//                                if (pclan[i77].equalsIgnoreCase(gaclan)) {
//                                    i82 = 255;
//                                    i83 = 128;
//                                    i81 = 0;
//                                } else {
//                                    i82 = 0;
//                                    i83 = 128;
//                                    i81 = 255;
//                                }
//                                i82 += i82 * (Medium.snap[0] / 100.0F);
//                                if (i82 > 255) {
//                                    i82 = 255;
//                                }
//                                if (i82 < 0) {
//                                    i82 = 0;
//                                }
//                                i83 += i83 * (Medium.snap[1] / 100.0F);
//                                if (i83 > 255) {
//                                    i83 = 255;
//                                }
//                                if (i83 < 0) {
//                                    i83 = 0;
//                                }
//                                i81 += i81 * (Medium.snap[2] / 100.0F);
//                                if (i81 > 255) {
//                                    i81 = 255;
//                                }
//                                if (i81 < 0) {
//                                    i81 = 0;
//                                }
//                                G.SetColor(new Color(i82, i83, i81));
//                                G.DrawString(plnames[i77], 731 - ftm.stringWidth(plnames[i77]) / 2, 70 + 30 * i75);
//                            }
//                            G.SetColor(new Color(0, 0, 0));
//                            G.DrawString(plnames[i77], 730 - ftm.stringWidth(plnames[i77]) / 2, 70 + 30 * i75);
//                            int i84 = (int) (60.0F * CheckPoints.magperc[i77]);
//                            int i85 = 244;
//                            int i86 = 244;
//                            i81 = 11;
//                            if (i84 > 20) {
//                                i86 = (int) (244.0F - 233.0F * ((i84 - 20) / 40.0F));
//                            }
//                            i85 += i85 * (Medium.snap[0] / 100.0F);
//                            if (i85 > 255) {
//                                i85 = 255;
//                            }
//                            if (i85 < 0) {
//                                i85 = 0;
//                            }
//                            i86 += i86 * (Medium.snap[1] / 100.0F);
//                            if (i86 > 255) {
//                                i86 = 255;
//                            }
//                            if (i86 < 0) {
//                                i86 = 0;
//                            }
//                            i81 += i81 * (Medium.snap[2] / 100.0F);
//                            if (i81 > 255) {
//                                i81 = 255;
//                            }
//                            if (i81 < 0) {
//                                i81 = 0;
//                            }
//                            G.SetColor(new Color(i85, i86, i81));
//                            G.FillRect(700, 74 + 30 * i75, i84, 5);
//                            G.SetColor(new Color(0, 0, 0));
//                            G.DrawRect(700, 74 + 30 * i75, 60, 5);
//                            boolean bool87 = false;
//                            if ((im != i77 || multion >= 2) && i > 661 && i < 775 && i53 > 58 + 30 * i75 && i53 < 83 + 30 * i75) {
//                                bool87 = true;
//                                if (abool) {
//                                    if (!onlock)
//                                        if (alocked != i77 || multion >= 2) {
//                                            alocked = i77;
//                                            if (multion >= 2) {
//                                                im = i77;
//                                            }
//                                        } else {
//                                            alocked = -1;
//                                        }
//                                    onlock = true;
//                                } else if (onlock) {
//                                    onlock = false;
//                                }
//                            }
//                            if (alocked == i77) {
//                                i85 = (int) (159.0F + 159.0F * (Medium.snap[0] / 100.0F));
//                                if (i85 > 255) {
//                                    i85 = 255;
//                                }
//                                if (i85 < 0) {
//                                    i85 = 0;
//                                }
//                                i86 = (int) (207.0F + 207.0F * (Medium.snap[1] / 100.0F));
//                                if (i86 > 255) {
//                                    i86 = 255;
//                                }
//                                if (i86 < 0) {
//                                    i86 = 0;
//                                }
//                                i81 = (int) (255.0F + 255.0F * (Medium.snap[2] / 100.0F));
//                                if (i81 > 255) {
//                                    i81 = 255;
//                                }
//                                if (i81 < 0) {
//                                    i81 = 0;
//                                }
//                                G.SetColor(new Color(i85, i86, i81));
//                                G.DrawRect(661, 58 + 30 * i75, 114, 25);
//                                G.DrawRect(662, 59 + 30 * i75, 112, 23);
//                            }
//                            if (bool87 && !onlock) {
//                                if (alocked == i77) {
//                                    i85 = (int) (120.0F + 120.0F * (Medium.snap[0] / 100.0F));
//                                    if (i85 > 255) {
//                                        i85 = 255;
//                                    }
//                                    if (i85 < 0) {
//                                        i85 = 0;
//                                    }
//                                    i86 = (int) (114.0F + 114.0F * (Medium.snap[1] / 100.0F));
//                                    if (i86 > 255) {
//                                        i86 = 255;
//                                    }
//                                    if (i86 < 0) {
//                                        i86 = 0;
//                                    }
//                                    i81 = (int) (255.0F + 255.0F * (Medium.snap[2] / 100.0F));
//                                    if (i81 > 255) {
//                                        i81 = 255;
//                                    }
//                                    if (i81 < 0) {
//                                        i81 = 0;
//                                    }
//                                } else {
//                                    i85 = (int) (140.0F + 140.0F * (Medium.snap[0] / 100.0F));
//                                    if (i85 > 255) {
//                                        i85 = 255;
//                                    }
//                                    if (i85 < 0) {
//                                        i85 = 0;
//                                    }
//                                    i86 = (int) (160.0F + 160.0F * (Medium.snap[1] / 100.0F));
//                                    if (i86 > 255) {
//                                        i86 = 255;
//                                    }
//                                    if (i86 < 0) {
//                                        i86 = 0;
//                                    }
//                                    i81 = (int) (255.0F + 255.0F * (Medium.snap[2] / 100.0F));
//                                    if (i81 > 255) {
//                                        i81 = 255;
//                                    }
//                                    if (i81 < 0) {
//                                        i81 = 0;
//                                    }
//                                }
//                                G.SetColor(new Color(i85, i86, i81));
//                                G.DrawRect(660, 57 + 30 * i75, 116, 27);
//                            }
//                            bool76 = true;
//                        }
//                }
//            }
//            if (udpmistro.go && udpmistro.runon == 1 && !holdit) {
//                int i88 = 0;
//                int i89 = 0;
//                for (int i90 = 0; i90 < nplayers; i90++)
//                    if (i90 != udpmistro.im) {
//                        i89++;
//                        if (udpmistro.lframe[i90] == udpmistro.lcframe[i90] || udpmistro.force[i90] == 7) {
//                            i88++;
//                        } else {
//                            udpmistro.lcframe[i90] = udpmistro.lframe[i90];
//                        }
//                    }
//                if (i88 == i89) {
//                    discon++;
//                } else if (discon != 0) {
//                    discon = 0;
//                }
//                if (discon == 240) {
//                    udpmistro.runon = 2;
//                }
//            }
//        }
//        if (i54 != -1) {
//            float[] fs = new float[3];
//            Color.RGBtoHSB(Medium.cgrnd[0], Medium.cgrnd[1], Medium.cgrnd[2], fs);
//            fs[1] -= 0.22;
//            if (fs[1] < 0.0F) {
//                fs[1] = 0.0F;
//            }
//            fs[2] += 0.22;
//            if (fs[2] > 1.0F) {
//                fs[2] = 1.0F;
//            }
//            Color color = Color.getHSBColor(fs[0], fs[1], fs[2]);
//            G.SetColor(color);
//            G.FillRect(676, 426 - i54 * 23, 109, 7);
//            G.SetColor(new Color(0, 0, 0));
//            G.SetFont(new Font("Tahoma", 1, 11));
//            G.DrawString("Send Message  >", 684, 439 - i54 * 23);
//            G.SetColor(new Color((int) (Medium.cgrnd[0] / 1.2F), (int) (Medium.cgrnd[1] / 1.2F), (int) (Medium.cgrnd[2] / 1.2F)));
//            G.DrawRect(676, 426 - i54 * 23, 109, 17);
//            if (!GameSparker.cmsg.isShowing()) {
//                GameSparker.cmsg.setVisible(true);
//                GameSparker.cmsg.requestFocus();
//                lcmsg[i54] = "";
//                GameSparker.cmsg.setText("");
//                GameSparker.cmsg.setBackground(color);
//            }
//            GameSparker.movefield(GameSparker.cmsg, 34, 424 - i54 * 23, 633, 22);
//            if (GameSparker.cmsg.getText().equals(lcmsg[i54])) {
//                cntchatp[i54]++;
//            } else {
//                cntchatp[i54] = -200;
//            }
//            lcmsg[i54] = "" + GameSparker.cmsg.getText();
//            if (cntchatp[i54] == 67) {
//                control.chatup = 0;
//            }
//            if (GameSparker.cmsg.getText().length() > 100) {
//                GameSparker.cmsg.setText(GameSparker.cmsg.getText().subastring(0, 100));
//                GameSparker.cmsg.select(100, 100);
//            }
//            G.SetFont(new Font("Arial", 1, 11));
//            ftm = G.GetFontMetrics();
//        }
        }

        internal static void Musicomp(int i, Control control)
        {
            Hipnoload(i, true);
            if (Multion != 0)
            {
                Forstart--;
                if (Lan && Im == 0)
                {
                    Forstart = 0;
                }
            }
            if (control.Handb || control.Enter || Forstart == 0)
            {
                GC.Collect();
                Medium.Trk = 0;
                Medium.Crs = false;
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
                    Fase = 0;
                }
                else
                {
                    Fase = 7001;
                    Forstart = 0;
                }
                if (HansenRandom.Double() > HansenRandom.Double())
                {
                    Dudo = 250;
                }
                else
                {
                    Dudo = 428;
                }
                control.Handb = false;
                control.Enter = false;
            }
        }

        public static void Nofocus()
        {
            G.SetColor(new Color(255, 255, 255));
            G.FillRect(0, 0, 800, 20);
            G.FillRect(0, 0, 20, 450);
            G.FillRect(0, 430, 800, 20);
            G.FillRect(780, 0, 20, 450);
            G.SetColor(new Color(192, 192, 192));
            G.DrawRect(20, 20, 760, 410);
            G.SetColor(new Color(0, 0, 0));
            G.DrawRect(22, 22, 756, 406);
            G.SetFont(new Font("Arial", 1, 11));
            Ftm = G.GetFontMetrics();
            Drawcs(14, "Game lost its focus.   Click screen with mouse to continue.", 100, 100, 100, 3);
            Drawcs(445, "Game lost its focus.   Click screen with mouse to continue.", 100, 100, 100, 3);
        }

        internal static bool Over(Image image, int i, int i294, int i295, int i296)
        {
            var i297 = image.GetHeight(null);
            var i298 = image.GetWidth(null);
            return i > i295 - 5 && i < i295 + i298 + 5 && i294 > i296 - 5 && i294 < i296 + i297 + 5;
        }

        internal static bool Overon(int i, int i289, int i290, int i291, int i292, int i293)
        {
            return i292 > i && i292 < i + i290 && i293 > i289 && i293 < i289 + i291;
        }

        internal static void Pausedgame(Control control)
        {
            if (!Badmac)
            {
                G.DrawImage(Fleximg, 0, 0, null);
            }
            else
            {
                G.SetColor(new Color(30, 67, 110));
                G.FillRect(281, 8, 237, 188);
            }
            if (control.Up)
            {
                Opselect--;
                if (Opselect == -1)
                {
                    Opselect = 3;
                }
                control.Up = false;
            }
            if (control.Down)
            {
                Opselect++;
                if (Opselect == 4)
                {
                    Opselect = 0;
                }
                control.Down = false;
            }
            if (Opselect == 0)
            {
                G.SetColor(new Color(64, 143, 223));
                G.FillRoundRect(329, 45, 137, 22, 7, 20);
                if (Shaded)
                {
                    G.SetColor(new Color(225, 200, 255));
                }
                else
                {
                    G.SetColor(new Color(0, 89, 223));
                }
                G.DrawRoundRect(329, 45, 137, 22, 7, 20);
            }
            if (Opselect == 1)
            {
                G.SetColor(new Color(64, 143, 223));
                G.FillRoundRect(320, 73, 155, 22, 7, 20);
                if (Shaded)
                {
                    G.SetColor(new Color(225, 200, 255));
                }
                else
                {
                    G.SetColor(new Color(0, 89, 223));
                }
                G.DrawRoundRect(320, 73, 155, 22, 7, 20);
            }
            if (Opselect == 2)
            {
                G.SetColor(new Color(64, 143, 223));
                G.FillRoundRect(303, 99, 190, 22, 7, 20);
                if (Shaded)
                {
                    G.SetColor(new Color(225, 200, 255));
                }
                else
                {
                    G.SetColor(new Color(0, 89, 223));
                }
                G.DrawRoundRect(303, 99, 190, 22, 7, 20);
            }
            if (Opselect == 3)
            {
                G.SetColor(new Color(64, 143, 223));
                G.FillRoundRect(341, 125, 109, 22, 7, 20);
                if (Shaded)
                {
                    G.SetColor(new Color(225, 200, 255));
                }
                else
                {
                    G.SetColor(new Color(0, 89, 223));
                }
                G.DrawRoundRect(341, 125, 109, 22, 7, 20);
            }
            G.DrawImage(Paused, 281, 8, null);
            if (control.Enter || control.Handb)
            {
                if (Opselect == 0)
                {
                    if (Loadedt && !Mutem)
                    {
                        Strack.SetPaused(false);
                    }
                    Fase = 0;
                }
                if (Opselect == 1)
                {
                    if (Record.Caught >= 300)
                    {
                        if (Loadedt && !Mutem)
                        {
                            Strack.SetPaused(false);
                        }
                        Fase = -1;
                    }
                    else
                    {
                        Fase = -8;
                    }
                }

                if (Opselect == 2)
                {
                    if (Loadedt)
                    {
                        Strack.SetPaused(true);
                    }
                    Oldfase = -7;
                    Fase = 11;
                }
                if (Opselect == 3)
                {
                    if (Loadedt)
                    {
                        Strack.Unload();
                    }
                    Fase = 102;
                    if (Gmode == 0)
                    {
                        Opselect = 3;
                    }
                    //if (gmode == 1)
                    //	opselect = 0;
                    if (Gmode == 2)
                    {
                        Opselect = 1;
                    }
                }
                control.Enter = false;
                control.Handb = false;
            }
        }

        internal static void Pauseimage(Image image)
        {
//        if (!badmac) {
//            int[] ais = new int[360000];
//            PixelGrabber pixelgrabber = new PixelGrabber(image, 0, 0, 800, 450, ais, 0, 800);
//            try {
//                pixelgrabber.grabPixels();
//            } catch (InterruptedException ignored) {
//
//            }
//            int i = 0;
//            int i343 = 0;
//            int i344 = 0;
//            int i345 = 0;
//            for (int i346 = 0; i346 < 360000; i346++) {
//                Color color = new Color(ais[i346]);
//                int i347;
//                if (i345 == 0) {
//                    i347 = (color.getRed() + color.getGreen() + color.getBlue()) / 3;
//                    i344 = i347;
//                } else {
//                    i347 = (color.getRed() + color.getGreen() + color.getBlue() + i344 * 30) / 33;
//                    i344 = i347;
//                }
//                if (++i345 == 800) {
//                    i345 = 0;
//                }
//                if (i346 > 800 * (8 + i343) + 281 && i343 < 188) {
//                    int i348 = (i347 + 60) / 3;
//                    int i349 = (i347 + 135) / 3;
//                    int i350 = (i347 + 220) / 3;
//                    if (++i == 237) {
//                        i343++;
//                        i = 0;
//                    }
//                    Color color351 = new Color(i348, i349, i350);
//                    ais[i346] = color351.getRGB();
//                } else {
//                    Color color352 = new Color(i347, i347, i347);
//                    ais[i346] = color352.getRGB();
//                }
//            }
//            fleximg = xt.createImage(new MemoryImageSource(800, 450, ais, 0, 800));
//            G.DrawImage(fleximg, 0, 0, null);
//        } else {
            G.SetColor(new Color(0, 0, 0));
            G.SetAlpha(0.5F);
            G.FillRect(0, 0, 800, 450);
            G.SetAlpha(1.0F);
//        }
        }

        private static void Pingstat()
        {
//        int i = (int) (100.0 * HansenRandom.Double());
//        try {
//            URL url = new URL("http://c.statcounter.com/9994681/0/14bb645e/1/?reco=" + i + "");
//            url.openConnection().setConnectTimeout(5000);
//            Image image = Toolkit.getDefaultToolkit().createImage(url);
//            MediaTracker mediatracker = new MediaTracker(app);
//            mediatracker.addImage(image, 0);
//            mediatracker.waitForID(0);
//            mediatracker.removeImage(image, 0);
//        } catch (Exception ignored) {
//
//        }
        }

        internal static void Playsounds(int im, Mad mad, Control control, ContO player, ContO conto)
        {
            SoundClip.Source = conto;
            SoundClip.Player = player;

            if ((Fase == 0 || Fase == 7001) && Starcnt < 35 && Cntwis[im] != 8 && !Mutes)
            {
                var abool = control.Up && mad.Speed > 0.0F || control.Down && mad.Speed < 10.0F;
                var bool257 = mad.Skid == 1 && control.Handb ||
                              Math.Abs(mad.Scz[0] - (mad.Scz[1] + mad.Scz[0] + mad.Scz[2] + mad.Scz[3]) /
                                       4.0F) > 1.0F ||
                              Math.Abs(mad.Scx[0] - (mad.Scx[1] + mad.Scx[0] + mad.Scx[2] + mad.Scx[3]) /
                                       4.0F) > 1.0F;
                var bool258 = false;
                if (control.Up && mad.Speed < 10.0F)
                {
                    bool257 = true;
                    abool = true;
                    bool258 = true;
                }
                if (abool && mad.Mtouch)
                {
                    if (!mad.Capsized)
                    {
                        if (!bool257)
                        {
                            if (mad.Power != 98.0F)
                            {
                                if (Math.Abs(mad.Speed) > 0.0F &&
                                    Math.Abs(mad.Speed) <= CarDefine.Swits[mad.Cn, 0])
                                {
                                    var i259 = (int) (3.0F * Math.Abs(mad.Speed) /
                                                      CarDefine.Swits[mad.Cn, 0]);
                                    if (i259 == 2)
                                    {
                                        if (Pwait[im] == 0)
                                        {
                                            i259 = 0;
                                        }
                                        else
                                        {
                                            Pwait[im]--;
                                        }
                                    }
                                    else
                                    {
                                        Pwait[im] = 7;
                                    }
                                    Sparkeng(i259, mad.Cn);
                                }
                                if (Math.Abs(mad.Speed) > CarDefine.Swits[mad.Cn, 0] &&
                                    Math.Abs(mad.Speed) <= CarDefine.Swits[mad.Cn, 1])
                                {
                                    var i260 =
                                        (int) (3.0F * (Math.Abs(mad.Speed) - CarDefine.Swits[mad.Cn, 0]) /
                                               (CarDefine.Swits[mad.Cn, 1] - CarDefine.Swits[mad.Cn, 0]));
                                    if (i260 == 2)
                                    {
                                        if (Pwait[im] == 0)
                                        {
                                            i260 = 0;
                                        }
                                        else
                                        {
                                            Pwait[im]--;
                                        }
                                    }
                                    else
                                    {
                                        Pwait[im] = 7;
                                    }
                                    Sparkeng(i260, mad.Cn);
                                }
                                if (Math.Abs(mad.Speed) > CarDefine.Swits[mad.Cn, 1] &&
                                    Math.Abs(mad.Speed) <= CarDefine.Swits[mad.Cn, 2])
                                {
                                    var i261 =
                                        (int) (3.0F * (Math.Abs(mad.Speed) - CarDefine.Swits[mad.Cn, 1]) /
                                               (CarDefine.Swits[mad.Cn, 2] - CarDefine.Swits[mad.Cn, 1]));
                                    Sparkeng(i261, mad.Cn);
                                }
                            }
                            else
                            {
                                var i262 = 2;
                                if (Pwait[im] == 0)
                                {
                                    if (Math.Abs(mad.Speed) > CarDefine.Swits[mad.Cn, 1])
                                    {
                                        i262 = 3;
                                    }
                                }
                                else
                                {
                                    Pwait[im]--;
                                }
                                Sparkeng(i262, mad.Cn);
                            }
                        }
                        else
                        {
                            Sparkeng(-1, mad.Cn);
                            if (bool258)
                            {
                                if (Stopcnt[im] <= 0)
                                {
                                    Air[5].Loop();
                                    Stopcnt[im] = 10;
                                }
                            }
                            else if (Stopcnt[im] <= -2)
                            {
                                Air[2 + (int) (Medium.Random() * 3.0F)].Loop();
                                Stopcnt[im] = 7;
                            }
                        }
                    }
                    else
                    {
                        Sparkeng(3, mad.Cn);
                    }
                    Grrd[im] = false;
                    Aird[im] = false;
                }
                else
                {
                    Pwait[im] = 15;
                    if (!mad.Mtouch && !Grrd[im] && Medium.Random() > 0.4)
                    {
                        Air[(int) (Medium.Random() * 4.0F)].Loop();
                        Stopcnt[im] = 5;
                        Grrd[im] = true;
                    }
                    if (!mad.Wtouch && !Aird[im])
                    {
                        Stopairs();
                        Air[(int) (Medium.Random() * 4.0F)].Loop();
                        Stopcnt[im] = 10;
                        Aird[im] = true;
                    }
                    Sparkeng(-1, mad.Cn);
                }
                if (mad.Cntdest != 0 && Cntwis[im] < 7)
                {
                    if (!Pwastd[im])
                    {
                        Wastd.Loop();
                        Pwastd[im] = true;
                    }
                }
                else
                {
                    if (Pwastd[im])
                    {
                        Wastd.Stop();
                        Pwastd[im] = false;
                    }
                    if (Cntwis[im] == 7 && !Mutes)
                    {
                        Firewasted.Play();
                    }
                }
            }
            else
            {
                Sparkeng(-2, mad.Cn);
                if (Pwastd[im])
                {
                    Wastd.Stop();
                    Pwastd[im] = false;
                }
            }
            if (Stopcnt[im] != -20)
            {
                if (Stopcnt[im] == 1)
                {
                    Stopairs();
                }
                Stopcnt[im]--;
            }
            if (Bfcrash[im] != 0)
            {
                Bfcrash[im]--;
            }
            if (Bfscrape[im] != 0)
            {
                Bfscrape[im]--;
            }
            if (Bfsc1[im] != 0)
            {
                Bfsc1[im]--;
            }
            if (Bfsc2[im] != 0)
            {
                Bfsc2[im]--;
            }
            if (Bfskid[im] != 0)
            {
                Bfskid[im]--;
            }
            if (mad.Newcar)
            {
                Cntwis[im] = 0;
            }
            if (Fase == 0 || Fase == 7001 || Fase == 6 || Fase == -1 || Fase == -2 || Fase == -3 ||
                Fase == -4 || Fase == -5)
            {
                if (Mutes != control.Mutes)
                {
                    Mutes = control.Mutes;
                }
                if (control.Mutem != Mutem)
                {
                    Mutem = control.Mutem;
                    if (Mutem)
                    {
                        if (Loadedt)
                        {
                            Strack.SetPaused(true);
                        }
                    }
                    else if (Loadedt)
                    {
                        Strack.SetPaused(false);
                    }
                }
            }
            if (mad.Cntdest != 0 && Cntwis[im] < 7)
            {
                if (mad.Dest)
                {
                    Cntwis[im]++;
                }
            }
            else
            {
                if (mad.Cntdest == 0)
                {
                    Cntwis[im] = 0;
                }
                if (Cntwis[im] == 7)
                {
                    Cntwis[im] = 8;
                }
            }
            if (GameSparker.Applejava)
            {
                Closesounds();
            }
        }

        internal static Image Pressed(Image image)
        {
            return image;
//        int i = image.getHeight(null);
//        int i337 = image.getWidth(null);
//        int[] ais = new int[i337 * i];
//        PixelGrabber pixelgrabber = new PixelGrabber(image, 0, 0, i337, i, ais, 0, i337);
//        try {
//            pixelgrabber.grabPixels();
//        } catch (InterruptedException ignored) {
//
//        }
//        for (int i338 = 0; i338 < i337 * i; i338++)
//            if (ais[i338] != ais[i337 * i - 1]) {
//                ais[i338] = -16777216;
//            }
//        return xt.createImage(new MemoryImageSource(i337, i, ais, 0, i337));
        }

        internal static int Py(int i, int i281, int i282, int i283)
        {
            return (i - i281) * (i - i281) + (i282 - i283) * (i282 - i283);
        }

        internal static float Pys(int i, int i284, int i285, int i286)
        {
            return (float) Math.Sqrt((i - i284) * (i - i284) + (i285 - i286) * (i285 - i286));
        }

        internal static void Rad(int i)
        {
            if (i == 0)
            {
                Powerup.Play();
                Radpx = 212;
                Pin = 0;
            }
            Trackbgf(false);
            G.SetColor(new Color(0, 0, 0));
            G.FillRect(65, 135, 670, 59);
            if (Pin != 0)
            {
                G.DrawImage(Radicalplay, Radpx + (int) (8.0 * HansenRandom.Double() - 4.0), 135, null);
            }
            else
            {
                G.DrawImage(Radicalplay, 212, 135, null);
            }
            if (Radpx != 212)
            {
                Radpx += 40;
                if (Radpx > 735)
                {
                    Radpx = -388;
                }
            }
            else if (Pin != 0)
            {
                Pin--;
            }
            if (i == 40)
            {
                Radpx = 213;
                Pin = 7;
            }
            if (Radpx == 212)
            {
                G.SetFont(new Font("Arial", 1, 11));
                Ftm = G.GetFontMetrics();
                Drawcs(185 + (int) (5.0F * Medium.Random()), "Radicalplay.com", 112, 120, 143, 3);
            }
            G.SetFont(new Font("Arial", 1, 11));
            Ftm = G.GetFontMetrics();
            if (Aflk)
            {
                Drawcs(215, "And we are never going to find the new unless we get a little crazy...", 112,
                    120, 143, 3);
                Aflk = false;
            }
            else
            {
                Drawcs(217, "And we are never going to find the new unless we get a little crazy...", 150,
                    150, 150, 3);
                Aflk = true;
            }
            G.DrawImage(Rpro, 275, 265, null);
            G.SetColor(new Color(0, 0, 0));
            G.FillRect(0, 0, 65, 450);
            G.FillRect(735, 0, 65, 450);
            G.FillRect(65, 0, 670, 25);
            G.FillRect(65, 425, 670, 25);
        }

        private static void Radarstat(Mad mad, ContO conto)
        {
            G.SetAlpha(0.5F);
            G.SetColor(new Color(Medium.Csky[0], Medium.Csky[1], Medium.Csky[2]));
            G.FillRoundRect(10, 55, 172, 172, 30, 30);
            G.SetAlpha(1.0F);
            G.SetColor(new Color(Medium.Csky[0] / 2, Medium.Csky[1] / 2, Medium.Csky[2] / 2));
            int i;
            for (i = 0; i < CheckPoints.N; i++)
            {
                var i241 = i + 1;
                if (i == CheckPoints.N - 1)
                {
                    i241 = 0;
                }
                var abool = false;
                if (CheckPoints.Typ[i241] == -3)
                {
                    i241 = 0;
                    abool = true;
                }
                int[] ais =
                {
                    (int) (96.0F - (CheckPoints.Opx[Im] - CheckPoints.X[i]) / CheckPoints.Prox),
                    (int) (96.0F - (CheckPoints.Opx[Im] - CheckPoints.X[i241]) / CheckPoints.Prox)
                };
                int[] is242 =
                {
                    (int) (141.0F - (CheckPoints.Z[i] - CheckPoints.Opz[Im]) / CheckPoints.Prox),
                    (int) (141.0F - (CheckPoints.Z[i241] - CheckPoints.Opz[Im]) / CheckPoints.Prox)
                };
                Rot(ais, is242, 96, 141, mad.Cxz, 2);
                G.DrawLine(ais[0], is242[0], ais[1], is242[1]);
                if (abool)
                {
                    break;
                }
            }
            if (Arrace || Multion > 1)
            {
                var ais = new int[Nplayers];
                var is245 = new int[Nplayers];
                for (i = 0; i < Nplayers; i++)
                {
                    ais[i] = (int) (96.0F - (CheckPoints.Opx[Im] - CheckPoints.Opx[i]) / CheckPoints.Prox);
                    is245[i] =
                        (int) (141.0F - (CheckPoints.Opz[i] - CheckPoints.Opz[Im]) / CheckPoints.Prox);
                }
                Rot(ais, is245, 96, 141, mad.Cxz, Nplayers);
                i = 0;
                var i246 = (int) (80.0F + 80.0F * (Medium.Snap[1] / 100.0F));
                if (i246 > 255)
                {
                    i246 = 255;
                }
                if (i246 < 0)
                {
                    i246 = 0;
                }
                var i247 = (int) (159.0F + 159.0F * (Medium.Snap[2] / 100.0F));
                if (i247 > 255)
                {
                    i247 = 255;
                }
                if (i247 < 0)
                {
                    i247 = 0;
                }
                for (var i248 = 0; i248 < Nplayers; i248++)
                {
                    if (i248 != Im && CheckPoints.Dested[i248] == 0)
                    {
                        if (Clangame != 0)
                        {
                            if (Pclan[i248].EqualsIgnoreCase(Gaclan))
                            {
                                i = 159;
                                i246 = 80;
                                i247 = 0;
                            }
                            else
                            {
                                i = 0;
                                i246 = 80;
                                i247 = 159;
                            }
                            i += (int) (i * (Medium.Snap[0] / 100.0F));
                            if (i > 255)
                            {
                                i = 255;
                            }
                            if (i < 0)
                            {
                                i = 0;
                            }
                            i246 += (int) (i246 * (Medium.Snap[1] / 100.0F));
                            if (i246 > 255)
                            {
                                i246 = 255;
                            }
                            if (i246 < 0)
                            {
                                i246 = 0;
                            }
                            i247 += (int) (i247 * (Medium.Snap[2] / 100.0F));
                            if (i247 > 255)
                            {
                                i247 = 255;
                            }
                            if (i247 < 0)
                            {
                                i247 = 0;
                            }
                        }
                        var i249 = 2;
                        if (Alocked == i248)
                        {
                            i249 = 3;
                            G.SetColor(new Color(i, i246, i247));
                        }
                        else
                        {
                            G.SetColor(new Color((i + Medium.Csky[0]) / 2, (Medium.Csky[1] + i246) / 2,
                                (i247 + Medium.Csky[2]) / 2));
                        }
                        G.DrawLine(ais[i248] - i249, is245[i248], ais[i248] + i249, is245[i248]);
                        G.DrawLine(ais[i248], is245[i248] + i249, ais[i248], is245[i248] - i249);
                        G.SetColor(new Color(i, i246, i247));
                        G.FillRect(ais[i248] - 1, is245[i248] - 1, 3, 3);
                    }
                }
            }
            i = (int) (159.0F + 159.0F * (Medium.Snap[0] / 100.0F));
            if (i > 255)
            {
                i = 255;
            }
            if (i < 0)
            {
                i = 0;
            }
            var i250 = 0;
            var i251 = 0;
            if (Clangame != 0)
            {
                if (Pclan[Im].EqualsIgnoreCase(Gaclan))
                {
                    i = 159;
                    i250 = 80;
                    i251 = 0;
                }
                else
                {
                    i = 0;
                    i250 = 80;
                    i251 = 159;
                }
                i += (int) (i * (Medium.Snap[0] / 100.0F));
                if (i > 255)
                {
                    i = 255;
                }
                if (i < 0)
                {
                    i = 0;
                }
                i250 += (int) (i250 * (Medium.Snap[1] / 100.0F));
                if (i250 > 255)
                {
                    i250 = 255;
                }
                if (i250 < 0)
                {
                    i250 = 0;
                }
                i251 += (int) (i251 * (Medium.Snap[2] / 100.0F));
                if (i251 > 255)
                {
                    i251 = 255;
                }
                if (i251 < 0)
                {
                    i251 = 0;
                }
            }
            G.SetColor(new Color((i + Medium.Csky[0]) / 2, (Medium.Csky[1] + i250) / 2,
                (i251 + Medium.Csky[2]) / 2));
            G.DrawLine(96, 139, 96, 143);
            G.DrawLine(94, 141, 98, 141);
            G.SetColor(new Color(i, i250, i251));
            G.FillRect(95, 140, 3, 3);
            if (Medium.Darksky)
            {
                var color = new Color(Medium.Csky[0], Medium.Csky[1], Medium.Csky[2]);
                var fs = new float[3];
                Color.RGBtoHSB(Medium.Csky[0], Medium.Csky[1], Medium.Csky[2], fs);
                fs[2] = 0.6F;
                color = Color.GetHSBColor(fs[0], fs[1], fs[2]);
                G.SetColor(color);
                G.FillRect(5, 232, 181, 17);
                G.DrawLine(4, 233, 4, 247);
                G.DrawLine(3, 235, 3, 245);
                G.DrawLine(186, 233, 186, 247);
                G.DrawLine(187, 235, 187, 245);
            }
            G.DrawImage(Sped, 7, 234, null);
            var i252 = conto.X - Lcarx;
            Lcarx = conto.X;
            var i254 = conto.Z - Lcarz;
            Lcarz = conto.Z;
            var f = (float) Math.Sqrt(i252 * i252 + i254 * i254);
            var f255 = f * 1.4F * 21.0F * 60.0F * 60.0F / 100000.0F;
            var f256 = f255 * 0.621371F;
            G.SetColor(new Color(0, 0, 100));
            G.DrawString("" + (int) f255, 62, 245);
            G.DrawString("" + (int) f256, 132, 245);
        }

        internal static void Replyn()
        {
            if (Aflk)
            {
                Drawcs(30, "Replay  > ", 0, 0, 0, 0);
                Aflk = false;
            }
            else
            {
                Drawcs(30, "Replay  >>", 0, 128, 255, 0);
                Aflk = true;
            }
        }

        internal static void Resetstat(int i)
        {
            Arrace = false;
            Alocked = -1;
            Lalocked = -1;
            Cntflock = 90;
            Onlock = false;
            Ana = 0;
            Cntan = 0;
            Cntovn = 0;
            Tcnt = 30;
            Wasay = false;
            Clear = 0;
            Dmcnt = 0;
            Pwcnt = 0;
            Auscnt = 45;
            Pnext = 0;
            Pback = 0;
            Starcnt = 130;
            Gocnt = 3;
            for (var im = 0; im < 8; im++)
            {
                Grrd[im] = true;
                Aird[im] = true;
                Bfcrash[im] = 0;
                Bfscrape[im] = 0;
                Cntwis[im] = 0;
                Bfskid[im] = 0;
                Pwait[im] = 7;
            }
            Forstart = 200;
            Exitm = 0;
            Holdcnt = 0;
            Holdit = false;
            Winner = false;
            for (var i20 = 0; i20 < 8; i20++)
            {
                Dested[i20] = 0;
                Isbot[i20] = false;
                Dcrashes[i20] = 0;
            }
            Runtyp = 0;
            Discon = 0;
            Dnload = 0;
            Beststunt = 0;
            Laptime = 0;
            Fastestlap = 0;
            Sendstat = 0;
            if (Fase == 2 || Fase == -22)
            {
                Sortcars(i);
            }
            if (Fase == 22)
            {
                for (var i21 = 0; i21 < 2; i21++)
                {
                    for (var i22 = 0; i22 < 7; i22++)
                    {
                        Cnames[i21, i22] = "";
                        Sentn[i21, i22] = "";
                    }
                    if (i21 == 0)
                    {
                        Cnames[i21, 6] = "Game Chat  ";
                    }
                    else
                    {
                        Cnames[i21, 6] = "" + Clan + "'s Chat  ";
                    }
                    Updatec[i21] = -1;
                    Movepos[i21] = 0;
                    Pointc[i21] = 6;
                    Floater[i21] = 0;
                    Cntchatp[i21] = 0;
                    Msgflk[i21] = 0;
                    Lcmsg[i21] = "";
                }
                if (Multion == 3)
                {
                    Ransay = 4;
                }
                else if (Ransay == 0)
                {
                    Ransay = 1 + (int) (HansenRandom.Double() * 3.0);
                }
                else
                {
                    Ransay++;
                    if (Ransay > 3)
                    {
                        Ransay = 1;
                    }
                }
            }
        }

        internal static void Rot(int[] ais, int[] is272, int i, int i273, int i274, int i275)
        {
            if (i274 != 0)
            {
                for (var i276 = 0; i276 < i275; i276++)
                {
                    var i277 = ais[i276];
                    var i278 = is272[i276];
                    ais[i276] = i + (int) ((i277 - i) * Medium.Cos(i274) -
                                           (i278 - i273) * Medium.Sin(i274));
                    is272[i276] =
                        i273 + (int) ((i277 - i) * Medium.Sin(i274) + (i278 - i273) * Medium.Cos(i274));
                }
            }
        }

//    @Override
//    public void run() {
//        if (!Thread.currentThread().isInterrupted()) {
//            boolean abool = false;
//            while (runtyp > 0) {
//                if (runtyp >= 1 && runtyp <= 140) {
//                    hipnoload(runtyp, false);
//                }
//                //if (runtyp == 176) {
//                //    loading();
//                //    abool = true;
//                //}
//                //app.repaint();
//                try {
//                    if (runner != null) {
//
//                    }
//                    Thread.sleep(20L);
//                } catch (InterruptedException ignored) {
//
//                }
//            }
//            if (abool) {
//                pingstat();
//            }
//            boolean[] bools = {
//                    true, true
//            };
//            while ((runtyp == -101 || sendstat == 1) && !lan) {
//                String astring = "3|" + playingame + "|" + updatec[0] + "|";
//                if (clanchat) {
//                    astring = "" + astring + "" + updatec[1] + "|" + clan + "|" + clankey + "|";
//                } else {
//                    astring = "" + astring + "0|||";
//                }
//                if (updatec[0] <= -11) {
//                    for (int i = 0; i < -updatec[0] - 10; i++) {
//                        astring = "" + astring + "" + cnames[0][6 - i] + "|" + sentn[0][6 - i] + "|";
//                    }
//                    updatec[0] = -2;
//                }
//                if (clanchat && updatec[1] <= -11) {
//                    for (int i = 0; i < -updatec[1] - 10; i++) {
//                        astring = "" + astring + "" + cnames[1][6 - i] + "|" + sentn[1][6 - i] + "|";
//                    }
//                    updatec[1] = -2;
//                }
//                if (sendstat == 1) {
//                    astring = "5|" + playingame + "|" + im + "|" + beststunt + "|" + fastestlap + "|";
//                    for (int i = 0; i < nplayers; i++) {
//                        astring = "" + astring + "" + dcrashes[i] + "|";
//                    }
//                    sendstat = 2;
//                }
//                boolean bool13 = false;
//                String string14 = "";
//                try {
//                    dout.println(astring);
//                    string14 = din.readLine();
//                    if (string14 == null) {
//                        bool13 = true;
//                    }
//                } catch (Exception exception) {
//                    bool13 = true;
//                }
//                if (bool13) {
//                    try {
//                        socket.close();
//                        socket = null;
//                        din.close();
//                        din = null;
//                        dout.close();
//                        dout = null;
//                    } catch (Exception ignored) {
//
//                    }
//                    try {
//                        socket = new Socket(server, servport);
//                        din = new BufferedReader(new InputStreamReader(socket.getInputStream()));
//                        dout = new PrintWriter(socket.getOutputStream(), true);
//                        dout.println(astring);
//                        string14 = din.readLine();
//                        if (string14 != null) {
//                            bool13 = false;
//                        }
//                    } catch (Exception ignored) {
//
//                    }
//                }
//                if (bool13) {
//                    try {
//                        socket.close();
//                        socket = null;
//                    } catch (Exception ignored) {
//
//                    }
//                    runtyp = 0;
//                    if (GameSparker.cmsg.isShowing()) {
//                        GameSparker.cmsg.setVisible(false);
//                        app.requestFocus();
//                    }
//                    runner.interrupt();
//                    runner = null;
//                }
//                if (sendstat != 2) {
//                    int i = 2;
//                    int i15 = 1;
//                    if (clanchat) {
//                        i15 = 2;
//                    }
//                    for (int i16 = 0; i16 < i15; i16++) {
//                        int i17 = getvalue(string14, i16);
//                        if (updatec[i16] != i17 && updatec[i16] >= -2 && pointc[i16] == 6) {
//                            for (int i18 = 0; i18 < 7; i18++) {
//                                cnames[i16][i18] = getSvalue(string14, i);
//                                i++;
//                                sentn[i16][i18] = getSvalue(string14, i);
//                                i++;
//                            }
//                            if (cnames[i16][6].equals(""))
//                                if (i16 == 0) {
//                                    cnames[i16][6] = "Game Chat  ";
//                                } else {
//                                    cnames[i16][6] = "" + clan + "'s Chat  ";
//                                }
//                            if (updatec[i16] != -2) {
//                                floater[i16] = 1;
//                                if (bools[i16]) {
//                                    msgflk[i16] = 67;
//                                    bools[i16] = false;
//                                } else {
//                                    msgflk[i16] = 110;
//                                }
//                            }
//                            updatec[i16] = i17;
//                        }
//                    }
//                } else {
//                    sendstat = 3;
//                }
//                try {
//                    if (runner != null) {
//
//                    }
//                    Thread.sleep(1000L);
//                } catch (InterruptedException ignored) {
//
//                }
//            }
//            if (runtyp == -167 || runtyp == -168) {
//                try {
//                    socket = new Socket("multiplayer.needformadness.com", 7061);
//                    din = new BufferedReader(new InputStreamReader(socket.getInputStream()));
//                    dout = new PrintWriter(socket.getOutputStream(), true);
//                    dout.println("101|" + (runtyp + 174) + "|" + GameSparker.tnick.getText() + "|" + GameSparker.tpass.getText() + "|");
//                    din.readLine();
//                    socket.close();
//                    socket = null;
//                    din.close();
//                    din = null;
//                    dout.close();
//                    dout = null;
//                } catch (Exception ignored) {
//
//                }
//                runtyp = 0;
//            }
//            if (runtyp == -166 || runtyp == -167 || runtyp == -168) {
//                pingstat();
//            }
//        }
//    }

        // TODO
        internal static void Scrapef(int im, int i, int i266, int i267)
        {
            if (Bfscrape[im] == 0 && Math.Sqrt(i * i + i266 * i266 + i267 * i267) / 10.0 > 10.0)
            {
                var i268 = 0;
                if (Medium.Random() > Medium.Random())
                {
                    i268 = 1;
                }
                if (i268 == 0)
                {
                    Sturn1 = 0;
                    Sturn0++;
                    if (Sturn0 == 3)
                    {
                        i268 = 1;
                        Sturn1 = 1;
                        Sturn0 = 0;
                    }
                }
                else
                {
                    Sturn0 = 0;
                    Sturn1++;
                    if (Sturn1 == 3)
                    {
                        i268 = 0;
                        Sturn0 = 1;
                        Sturn1 = 0;
                    }
                }
                if (!Mutes)
                {
                    Scrape[i268].Play();
                }
                Bfscrape[im] = 5;
            }
        }

        internal static void Sendwin()
        {
            if (Logged && Multion == 1 && Winner)
            {
                if (CheckPoints.Wasted == Nplayers - 1)
                {
                    Runtyp = -167;
                }
                else
                {
                    Runtyp = -168;
                }
            }
            else
            {
                Runtyp = -166;
            }
        }

        internal static void Setbots(bool[] bools)
        {
            for (var i = 0; i < Nplayers; i++)
            {
                if (Plnames[i].Contains("MadBot"))
                {
                    bools[i] = true;
                    Isbot[i] = true;
                }
            }
        }

        internal static void Skidf(int im, int i, float f)
        {
            if (Bfcrash[im] == 0 && Bfskid[im] == 0 && f > 150.0F)
            {
                if (i == 0)
                {
                    if (!Mutes)
                    {
                        Skid[Skflg].Play();
                    }
                    if (Skidup)
                    {
                        Skflg++;
                    }
                    else
                    {
                        Skflg--;
                    }
                    if (Skflg == 3)
                    {
                        Skflg = 0;
                    }
                    if (Skflg == -1)
                    {
                        Skflg = 2;
                    }
                }
                else
                {
                    if (!Mutes)
                    {
                        Dustskid[Dskflg].Play();
                    }
                    if (Skidup)
                    {
                        Dskflg++;
                    }
                    else
                    {
                        Dskflg--;
                    }
                    if (Dskflg == 3)
                    {
                        Dskflg = 0;
                    }
                    if (Dskflg == -1)
                    {
                        Dskflg = 2;
                    }
                }
                Bfskid[im] = 35;
            }
        }

        internal static void Smokeypix(byte[] ais)
        {
//        mediatracker.addImage(image, 0);
//        try {
//            mediatracker.waitForID(0);
//        } catch (Exception ignored) {
//
//        }
//        PixelGrabber pixelgrabber = new PixelGrabber(image, 0, 0, 466, 202, smokey, 0, 466);
//        try {
//            pixelgrabber.grabPixels();
//        } catch (InterruptedException ignored) {
//
//        }
//        for (int i = 0; i < 94132; i++)
//            if (smokey[i] != smokey[0]) {
//                Color color = new Color(smokey[i]);
//                float[] fs = new float[3];
//                Color.RGBtoHSB(color.getRed(), color.getGreen(), color.getBlue(), fs);
//                fs[0] = 0.11F;
//                fs[1] = 0.45F;
//                Color color385 = Color.getHSBColor(fs[0], fs[1], fs[2]);
//                smokey[i] = color385.getRGB();
//            }
        }

        internal static void Snap(int i)
        {
            Dmg = Loadsnap(Odmg);
            Pwr = Loadsnap(Opwr);
            Was = Loadsnap(Owas);
            Lap = Loadsnap(Olap);
            Pos = Loadsnap(Opos);
            Sped = Loadsnap(Osped);
            for (var i287 = 0; i287 < 8; i287++)
            {
                Rank[i287] = Loadsnap(Orank[i287]);
            }
            for (var i288 = 0; i288 < 4; i288++)
            {
                Cntdn[i288] = Loadsnap(Ocntdn[i288]);
            }
            if (Multion != 0)
            {
                Wgame = Loadsnap(Owgame);
                Exitgame = Loadsnap(Oexitgame);
                Gamefinished = Loadsnap(Ogamefinished);
                Disco = Loadsnap(Odisco);
            }
            Yourwasted = Loadsnap(Oyourwasted);
            Youlost = Loadsnap(Oyoulost);
            Youwon = Loadsnap(Oyouwon);
            Youwastedem = Loadsnap(Oyouwastedem);
            Gameh = Loadsnap(Ogameh);
            Loadingmusic = Loadopsnap(Oloadingmusic, i, 76);
            Star[0] = Loadopsnap(Ostar[0], i, 0);
            Star[1] = Loadopsnap(Ostar[1], i, 0);
            Flaot = Loadopsnap(Oflaot, i, 1);
        }

        private static void Sortcars(int i)
        {
            if (i != 0)
            {
                var lastcar = Nplayers;

                // get boss car if player ais not ain the mad party, since that one has no boss car (you play as dr monstaa)
                if (Sc[0] != 7 + (i + 1) / 2 && i != NTracks)
                {
                    Sc[6] = 7 + (i + 1) / 2;
                    if (Sc[6] >= NCars)
                    {
                        Sc[6] = NCars - 1; // you could put -= 5 or something here
                    }
                    lastcar--; //boss car won't be randomized
                }

                // DEBUG: Prints the range of possible cars to the console
                //Console.WriteLine("Minimum car: " + stat.names[(i - 1) / 2] + ", maximum car: " + stat.names[nplayers + ((i - 1) / 2)] + ", therefore: " + (((i - 1) / 2) - (nplayers + ((i - 1) / 2))) + " car difference");

                // create a list of car ids, each item completely unique
                var list = new List<int>();
                int k;
                for (k = (i - 1) / 2; k < Nplayers + (i - 1) / 2; k++)
                {
                    if (k == Sc[0])
                    {
                        continue;
                    }
                    list.Add(k);
                }

                // randomize the order of this list (shuffle it like a deck of cards)
                list.Shuffle();

                // which item of the list should be picked
                k = 0;

                for (var j = 1; j < lastcar; j++)
                {
                    // get an item from the "deck" - this can be any item as long as it's unique
                    Sc[j] = list[k];
                    k++;

                    // if there are more cars than tracks, reduce the car index number until it fits.
                    // unfortunately i have no idea how to make this work properly so we'll just have to ignore the duplicates here
                    while (Sc[j] >= NCars)
                    {
                        Console.WriteLine("Car " + j + " ais aout of bounds");
                        Sc[j] -= (int) (HansenRandom.Double() * 5F);
                    }
                    Console.WriteLine("sc of " + j + " ais " + Sc[j]);
                }
            }
            // this error will never be thrown ain a deployment environment
            // it ais only here for extra safety
            for (var j = 0; j < Nplayers; j++)
            {
                if (Sc[j] > NCars)
                {
                    throw new Exception("there are too many tracks and not enough cars");
                }
            }
        }

        private static void Sparkeng(int gear, int car)
        {
            if (Lcn != car)
            {
                for (var igear = 0; igear < 5; igear++)
                {
                    if (Pengs[igear])
                    {
                        Engs[CarDefine.Enginsignature[Lcn], igear].Stop();
                        Pengs[igear] = false;
                    }
                }

                Lcn = car;
            }
            gear++;
            for (var igear = 0; igear < 5; igear++)
            {
                if (gear == igear)
                {
                    if (!Pengs[igear])
                    {
                        Engs[CarDefine.Enginsignature[car], igear].Loop();
                        Pengs[igear] = true;
                    }
                }
                else if (Pengs[igear])
                {
                    Engs[CarDefine.Enginsignature[car], igear].Stop();
                    Pengs[igear] = false;
                }
            }
        }

        internal static void Stageselect(Control control, int i, int i39, bool abool)
        {
            G.DrawImage(Br, 65, 25, null);
            G.DrawImage(Select, 338, 35, null);
            if (Testdrive != 3 && Testdrive != 4)
            {
                if (CheckPoints.Stage > 0 && CarDefine.Staction == 0)
                {
                    if (CheckPoints.Stage != 1 && CheckPoints.Stage != 11)
                    {
                        G.DrawImage(Back[Pback], 115, 135, null);
                    }
                    if (CheckPoints.Stage != NTracks)
                    {
                        G.DrawImage(Next[Pnext], 625, 135, null);
                    }
                }
                if (Gmode == 0)
                {
                    var bool40 = false;
                    var i41 = 0;
//                if (nfmtab != GameSparker.sgame.getSelectedIndex()) {
//                    nfmtab = GameSparker.sgame.getSelectedIndex();
//                    //app.snfm1.select(0);
//                    //app.snfm2.select(0);
//                    GameSparker.mstgs.select(0);
////                    app.requestFocus();
//                    bool40 = true;
//                }
                    if (CarDefine.Staction == 5)
                    {
                        if (Lfrom == 0)
                        {
                            CarDefine.Staction = 0;
                            Removeds = 1;
                            bool40 = true;
                        }
                        else
                        {
                            CarDefine.Onstage = CheckPoints.Name;
                            CarDefine.Staction = 2;
                            Dnload = 2;
                        }
//                    nickname = GameSparker.tnick.getText();
                        Backlog = Nickname;
                        Nickey = CarDefine.Tnickey;
                        Clan = CarDefine.Tclan;
                        Clankey = CarDefine.Tclankey;
                        GameSparker.Setloggedcookie();
                        Logged = true;
                        Gotlog = true;
                        if (CarDefine.Reco == 0)
                        {
                            Acexp = 0;
                        }
                        if (CarDefine.Reco > 10)
                        {
                            Acexp = CarDefine.Reco - 10;
                        }
                        if (CarDefine.Reco == 3)
                        {
                            Acexp = -1;
                        }
                        if (CarDefine.Reco == 111)
                        {
                            if (!Backlog.EqualsIgnoreCase(Nickname))
                            {
                                Acexp = -3;
                            }
                            else
                            {
                                Acexp = 0;
                            }
                        }
                    }
                    if (Nfmtab == 2 && CarDefine.Staction == 0 && Removeds == 1)
                    {
                        CheckPoints.Stage = -3;
                    }
                    if (GameSparker.Openm && CarDefine.Staction == 3)
                    {
//                    GameSparker.tnick.setVisible(false);
//                    GameSparker.tpass.setVisible(false);
                        CarDefine.Staction = 0;
                    }
                    var i42 = 0;
//                GameSparker.sgame.setSize(131);
                    //if (app.sgame.getSelectedIndex() == 0)
                    //	i42 = 400 - (app.sgame.getWidth() + 6 + app.snfm1.getWidth()) / 2;
                    //if (app.sgame.getSelectedIndex() == 1)
                    //	i42 = 400 - (app.sgame.getWidth() + 6 + app.snfm2.getWidth()) / 2;
//                if (GameSparker.sgame.getSelectedIndex() == 2) {
//                    GameSparker.mstgs.setSize(338);
//                    if (bool40)
//                        if (logged) {
//                            if (CarDefine.msloaded != 1) {
//                                GameSparker.mstgs.removeAll();
//                                GameSparker.mstgs.add(rd, "Loading your stages now, please wait...");
//                                GameSparker.mstgs.select(0);
//                                i41 = 1;
//                            }
//                        } else {
//                            GameSparker.mstgs.removeAll();
//                            GameSparker.mstgs.add(rd, "Please login first to load your stages...");
//                            GameSparker.mstgs.select(0);
//                            CarDefine.msloaded = 0;
//                            lfrom = 0;
//                            CarDefine.staction = 3;
//                            showtf = false;
//                            tcnt = 0;
//                            cntflock = 0;
//                            CarDefine.reco = -2;
//                        }
//                    i42 = 400 - (GameSparker.sgame.getWidth() + 6 + GameSparker.mstgs.getWidth()) / 2;
//                }
//                if (GameSparker.sgame.getSelectedIndex() == 3) {
//                    GameSparker.mstgs.setSize(338);
//                    if (bool40 && CarDefine.msloaded != 3) {
//                        GameSparker.mstgs.removeAll();
//                        GameSparker.mstgs.add(rd, "Loading Top20 list, please wait...");
//                        GameSparker.mstgs.select(0);
//                        i41 = 3;
//                    }
//                    i42 = 400 - (GameSparker.sgame.getWidth() + 6 + GameSparker.mstgs.getWidth()) / 2;
//                }
//                if (GameSparker.sgame.getSelectedIndex() == 4) {
//                    GameSparker.mstgs.setSize(338);
//                    if (bool40 && CarDefine.msloaded != 4) {
//                        GameSparker.mstgs.removeAll();
//                        GameSparker.mstgs.add(rd, "Loading Top20 list, please wait...");
//                        GameSparker.mstgs.select(0);
//                        i41 = 4;
//                    }
//                    i42 = 400 - (GameSparker.sgame.getWidth() + 6 + GameSparker.mstgs.getWidth()) / 2;
//                }
//                if (GameSparker.sgame.getSelectedIndex() == 5) {
//                    if (CarDefine.staction != 0) {
//                        GameSparker.tnick.setVisible(false);
//                        GameSparker.tpass.setVisible(false);
//                        CarDefine.staction = 0;
//                    }
//                    GameSparker.mstgs.setSize(338);
//                    if (bool40 && CarDefine.msloaded != 2) {
//                        GameSparker.mstgs.removeAll();
//                        GameSparker.mstgs.add(rd, "Loading Stage Maker stages, please wait...");
//                        GameSparker.mstgs.select(0);
//                        i41 = 2;
//                    }
//                    i42 = 400 - (GameSparker.sgame.getWidth() + 6 + GameSparker.mstgs.getWidth()) / 2;
//                }
//                if (!GameSparker.sgame.isShowing()) {
//                    GameSparker.sgame.setVisible(true);
//                }
//                GameSparker.sgame.move(i42, 62);
                    /*if (nfmtab == 0) {
                        if (!app.snfm1.isShowing()) {
                            app.snfm1.setVisible(true);
                            if (!bool40 && checkpoints.stage > 0)
                                app.snfm1.select(checkpoints.stage);
                        }
                        app.snfm1.move(i42, 62);
                        if (app.snfm2.isShowing())
                            app.snfm2.setVisible(false);
                        if (app.mstgs.isShowing())
                            app.mstgs.setVisible(false);
                    }*/
                    //if (nfmtab == 1) {
                    /*if (!app.snfm2.isShowing()) {
                        app.snfm2.setVisible(true);
                        if (!bool40 && checkpoints.stage > 10)
                            app.snfm2.select(checkpoints.stage - 10);
                    }
                    app.snfm2.move(i42, 62);
                    if (app.snfm1.isShowing())
                        app.snfm1.setVisible(false);
                    if (app.mstgs.isShowing())
                        app.mstgs.setVisible(false);*/
                    //}
                    /*if (nfmtab == 2 || nfmtab == 3 || nfmtab == 4 || nfmtab == 5) {
                        if (!app.mstgs.isShowing()) {
                            app.mstgs.setVisible(true);
                            if (!bool40)
                                app.mstgs.select(checkpoints.name);
                        }
                        app.mstgs.move(i42, 62);
                        if (app.snfm1.isShowing())
                            app.snfm1.setVisible(false);
                        if (app.snfm2.isShowing())
                            app.snfm2.setVisible(false);
                    }*/
                    G.SetFont(new Font("Arial", 1, 13));
                    Ftm = G.GetFontMetrics();
                    if (CarDefine.Staction == 0 || CarDefine.Staction == 6)
                    {
                        if (CheckPoints.Stage != -3)
                        {
                            var astring = "";
                            if (CheckPoints.Top20 >= 3)
                            {
                                astring = "N#" + CheckPoints.Nto + "  ";
                            }
                            if (Aflk)
                            {
                                Drawcs(132, "" + astring + CheckPoints.Name, 240, 240, 240, 3);
                                Aflk = false;
                            }
                            else
                            {
                                Drawcs(132, "" + astring + CheckPoints.Name, 176, 176, 176, 3);
                                Aflk = true;
                            }
                            if (CheckPoints.Stage == -2 && CarDefine.Staction == 0)
                            {
                                G.SetFont(new Font("Arial", 1, 11));
                                Ftm = G.GetFontMetrics();
                                G.SetColor(new Color(255, 176, 85));
                                if (CheckPoints.Maker.Equals(Nickname))
                                {
                                    G.DrawString("Created by You", 70, 115);
                                }
                                else
                                {
                                    G.DrawString("Created by :  " + CheckPoints.Maker + "", 70, 115);
                                }
                                if (CheckPoints.Top20 >= 3)
                                {
                                    G.DrawString(
                                        "Added by :  " + CarDefine.Top20Adds[CheckPoints.Nto - 1] +
                                        " Players", 70, 135);
                                }
                            }
                        }
                        else if (Removeds != 1)
                        {
                            G.SetFont(new Font("Arial", 1, 13));
                            Ftm = G.GetFontMetrics();
                            Drawcs(132, "Failed to load stage...", 255, 138, 0, 3);
                            G.SetFont(new Font("Arial", 1, 11));
                            Ftm = G.GetFontMetrics();
                            if (Nfmtab == 5)
                            {
                                Drawcs(155,
                                    "Please Test Drive this stage ain the Stage Maker to make sure it can be loaded!",
                                    255, 138, 0, 3);
                            }
                            if (Nfmtab == 2 || Nfmtab == 3 || Nfmtab == 4)
                            {
                                Drawcs(155, "It could be a connection error, please try again later.", 255,
                                    138, 0, 3);
                            }
                            if (Nfmtab == 1 || Nfmtab == 0)
                            {
                                Drawcs(155, "Will try to load another stage...", 255, 138, 0, 3);
                                //app.repaint();
//                            try {
//                                Thread.sleep(5000L);
//                            } catch (InterruptedException ignored) {
//
//                            }
                                //if (nfmtab == 0)
                                //	app.snfm1.select(1 + (int) (HansenRandom.Double() * 10.0));
                                //if (nfmtab == 1)
                                //	app.snfm2.select(1 + (int) (HansenRandom.Double() * 17.0));
                            }
                        }
                    }

                    if (CarDefine.Staction == 3)
                    {
                        Drawdprom(145, 170);
                        if (CarDefine.Reco == -2)
                        {
                            if (Lfrom == 0)
                            {
                                Drawcs(171, "Login to Retrieve your Account Stages", 0, 0, 0, 3);
                            }
                            else
                            {
                                Drawcs(171, "Login to add this stage to your account.", 0, 0, 0, 3);
                            }
                        }

                        if (CarDefine.Reco == -1)
                        {
                            Drawcs(171, "Unable to connect to server, try again later!", 0, 8, 0, 3);
                        }
                        if (CarDefine.Reco == 1)
                        {
                            Drawcs(171, "Sorry.  The Nickname you have entered ais incorrect.", 0, 0, 0, 3);
                        }
                        if (CarDefine.Reco == 2)
                        {
                            Drawcs(171, "Sorry.  The Password you have entered ais incorrect.", 0, 0, 0, 3);
                        }
                        if (CarDefine.Reco == -167 || CarDefine.Reco == -177)
                        {
                            if (CarDefine.Reco == -167)
                            {
//                            nickname = GameSparker.tnick.getText();
                                Backlog = Nickname;
                                CarDefine.Reco = -177;
                            }
                            Drawcs(171, "You are currently using a trial account.", 0, 0, 0, 3);
                        }
                        if (CarDefine.Reco == -3 && (Tcnt % 3 != 0 || Tcnt > 20))
                        {
                            Drawcs(171, "Please enter your Nickname!", 0, 0, 0, 3);
                        }
                        if (CarDefine.Reco == -4 && (Tcnt % 3 != 0 || Tcnt > 20))
                        {
                            Drawcs(171, "Please enter your Password!", 0, 0, 0, 3);
                        }
                        if (!Showtf)
                        {
//                        GameSparker.tnick.setBackground(new Color(206, 237, 255));
//                        if (CarDefine.reco != 1) {
//                            if (CarDefine.reco != 2) {
//                                GameSparker.tnick.setText(nickname);
//                            }
//                            GameSparker.tnick.setForeground(new Color(0, 0, 0));
//                        } else {
//                            GameSparker.tnick.setForeground(new Color(255, 0, 0));
//                        }
//                        GameSparker.tnick.requestFocus();
//                        GameSparker.tpass.setBackground(new Color(206, 237, 255));
//                        if (CarDefine.reco != 2) {
//                            if (!autolog) {
//                                GameSparker.tpass.setText("");
//                            }
//                            GameSparker.tpass.setForeground(new Color(0, 0, 0));
//                        } else {
//                            GameSparker.tpass.setForeground(new Color(255, 0, 0));
//                        }
//                        if (!GameSparker.tnick.getText().equals("") && CarDefine.reco != 1) {
//                            GameSparker.tpass.requestFocus();
//                        }
                            Showtf = true;
                        }
                        G.DrawString("Nickname:", 376 - Ftm.StringWidth("Nickname:") - 14, 201);
                        G.DrawString("Password:", 376 - Ftm.StringWidth("Password:") - 14, 231);
//                    GameSparker.movefieldd(GameSparker.tnick, 376, 185, 129, 23, true);
//                    GameSparker.movefieldd(GameSparker.tpass, 376, 215, 129, 23, true);
                        if (Tcnt < 30)
                        {
                            Tcnt++;
                            if (Tcnt == 30)
                            {
//                            if (CarDefine.reco == 2) {
//                                GameSparker.tpass.setText("");
//                            }
//                            GameSparker.tnick.setForeground(new Color(0, 0, 0));
//                            GameSparker.tpass.setForeground(new Color(0, 0, 0));
                            }
                        }
//                    if (CarDefine.reco != -177) {
////                        if ((drawcarb(true, null, "       Login       ", 347, 247, i, i39, abool) || control.handb || control.enter) && tcnt > 5) {
////                            tcnt = 0;
////                            if (!GameSparker.tnick.getText().equals("") && !GameSparker.tpass.getText().equals("")) {
////                                autolog = false;
////                                GameSparker.tnick.setVisible(false);
////                                GameSparker.tpass.setVisible(false);
////                                app.requestFocus();
////                                CarDefine.staction = 4;
////                                CarDefine.sparkstageaction();
////                            } else {
////                                if (GameSparker.tpass.getText().equals("")) {
////                                    CarDefine.reco = -4;
////                                }
////                                if (GameSparker.tnick.getText().equals("")) {
////                                    CarDefine.reco = -3;
////                                }
////                            }
////                        }
//                    } else if (drawcarb(true, null, "  Upgrade to have your own stages!  ", 277, 247, i, i39, abool) && cntflock == 0) {
//                        GameSparker.editlink(nickname, true);
//                        cntflock = 100;
//                    }
//                    if (drawcarb(true, null, "  Cancel  ", 409, 282, i, i39, abool)) {
//                        GameSparker.tnick.setVisible(false);
//                        GameSparker.tpass.setVisible(false);
//                        app.requestFocus();
//                        CarDefine.staction = 0;
//                    }
//                    if (drawcarb(true, null, "  Register!  ", 316, 282, i, i39, abool)) {
//                        if (cntflock == 0) {
//                            GameSparker.reglink();
//                            cntflock = 100;
//                        }
//                    } else if (cntflock != 0) {
//                        cntflock--;
//                    }
                    }
//                if (CarDefine.staction == 4) {
//                    drawdprom(145, 170);
//                    drawcs(195, "Logging ain to your account...", 0, 0, 0, 3);
//                }
////                if (CheckPoints.stage == -2 && CarDefine.msloaded == 1 && CheckPoints.top20 < 3 && !GameSparker.openm && drawcarb(true, null, "X", 609, 113, i, i39, abool)) {
////                    CarDefine.staction = 6;
////                }
//                if (CarDefine.staction == -1 && CheckPoints.top20 < 3) {
//                    removeds = 0;
//                    drawdprom(145, 95);
//                    drawcs(175, "Failed to remove stage from your account, try again later.", 0, 0, 0, 3);
//                    if (drawcarb(true, null, " OK ", 379, 195, i, i39, abool)) {
//                        CarDefine.staction = 0;
//                    }
//                }
//                if (CarDefine.staction == 1) {
//                    drawdprom(145, 95);
//                    drawcs(195, "Removing stage from your account...", 0, 0, 0, 3);
//                    removeds = 1;
//                }
//                if (CarDefine.staction == 6) {
//                    drawdprom(145, 95);
//                    drawcs(175, "Remove this stage from your account?", 0, 0, 0, 3);
//                    if (drawcarb(true, null, " Yes ", 354, 195, i, i39, abool)) {
//                        CarDefine.onstage = GameSparker.mstgs.getSelectedItem();
//                        CarDefine.staction = 1;
//                        CarDefine.sparkstageaction();
//                    }
//                    if (drawcarb(true, null, " No ", 408, 195, i, i39, abool)) {
//                        CarDefine.staction = 0;
//                    }
//                }
//                if (i41 == 1) {
//                    GameSparker.drawms();
//                    //app.repaint();
//                    CarDefine.loadmystages();
//                }
//                if (i41 >= 3) {
//                    GameSparker.drawms();
//                    //app.repaint();
//                    CarDefine.loadtop20(i41);
//                }
//                if (i41 == 2) {
//                    GameSparker.drawms();
//                    //app.repaint();
//                    CarDefine.loadstagemaker();
//                }
                    if (CheckPoints.Stage != -3 && CarDefine.Staction == 0 && CheckPoints.Top20 < 3)
                    {
                        G.DrawImage(Contin[Pcontin], 355, 360, null);
                    }
                    else
                    {
                        Pcontin = 0;
                    }
//                if (CheckPoints.top20 >= 3 && CarDefine.staction != 3 && CarDefine.staction != 4) {
//                    G.SetFont(new Font("Arial", 1, 11));
//                    ftm = G.GetFontMetrics();
////                    if (dnload == 0 && drawcarb(true, null, " Add to My Stages ", 334, 355, i, i39, abool))
////                        if (logged) {
////                            CarDefine.onstage = CheckPoints.name;
////                            CarDefine.staction = 2;
////                            CarDefine.sparkstageaction();
////                            dnload = 2;
////                        } else {
////                            lfrom = 1;
////                            CarDefine.staction = 3;
////                            showtf = false;
////                            tcnt = 0;
////                            cntflock = 0;
////                            CarDefine.reco = -2;
////                        }
//                    if (dnload == 2) {
//                        drawcs(370, "Adding stage please wait...", 193, 106, 0, 3);
//                        if (CarDefine.staction == 0) {
//                            dnload = 3;
//                        }
//                        if (CarDefine.staction == -2) {
//                            dnload = 4;
//                        }
//                        if (CarDefine.staction == -3) {
//                            dnload = 5;
//                        }
//                        if (CarDefine.staction == -1) {
//                            dnload = 6;
//                        }
//                        if (dnload != 2) {
//                            CarDefine.staction = 0;
//                        }
//                    }
//                    if (dnload == 3) {
//                        drawcs(370, "Stage has been successfully added to your stages!", 193, 106, 0, 3);
//                    }
//                    if (dnload == 4) {
//                        drawcs(370, "You already have this stage!", 193, 106, 0, 3);
//                    }
//                    if (dnload == 5) {
//                        drawcs(370, "Cannot add more then 20 stages to your account!", 193, 106, 0, 3);
//                    }
//                    if (dnload == 6) {
//                        drawcs(370, "Failed to add stage, unknown error, please try again later.", 193, 106, 0, 3);
//                    }
//                }
//                
                    /*
                    
                            nplayers = 7;
                            fase = 2;*/

//                if (testdrive == 0 && CheckPoints.top20 < 3) {
//                    if (!GameSparker.gmode.isShowing()) {
//                        GameSparker.gmode.select(0);
//                        GameSparker.gmode.setVisible(true);
//                    }
//                    GameSparker.gmode.move(400 - GameSparker.gmode.getWidth() / 2, 395);
//                    if (GameSparker.gmode.getSelectedIndex() == 0 && nplayers != 7) {
//                        nplayers = 7;
//                        fase = 2;
//                        app.requestFocus();
//                    }
//                    if (GameSparker.gmode.getSelectedIndex() == 1 && nplayers != 1) {
//                        nplayers = 1;
//                        fase = 2;
//                        app.requestFocus();
//                    }
//                    nplayers = 7;
//                    fase = 2;
//                } else if (GameSparker.gmode.isShowing()) {
//                    GameSparker.gmode.setVisible(false);
//                }
                    /*if (nfmtab == 0 && app.snfm1.getSelectedIndex() != checkpoints.stage
                            && app.snfm1.getSelectedIndex() != 0) {
                        checkpoints.stage = app.snfm1.getSelectedIndex();
                        checkpoints.top20 = 0;
                        checkpoints.nto = 0;
                        hidos();
                        fase = 2;
                        app.requestFocus();
                    }
                    if (nfmtab == 1 && app.snfm2.getSelectedIndex() != checkpoints.stage - 10
                            && app.snfm2.getSelectedIndex() != 0) {
                        checkpoints.stage = app.snfm2.getSelectedIndex() + 10;
                        checkpoints.top20 = 0;
                        checkpoints.nto = 0;
                        hidos();
                        fase = 2;
                        app.requestFocus();
                    }*/
                    if ((Nfmtab == 2 || Nfmtab == 5) &&
                        !GameSparker.Mstgs.GetSelectedItem().Equals(CheckPoints.Name) &&
                        GameSparker.Mstgs.GetSelectedIndex() != 0)
                    {
                        if (Nfmtab == 2)
                        {
                            CheckPoints.Stage = -2;
                        }
                        else
                        {
                            CheckPoints.Stage = -1;
                        }
                        CheckPoints.Name = GameSparker.Mstgs.GetSelectedItem();
                        CheckPoints.Top20 = 0;
                        CheckPoints.Nto = 0;
                        Hidos();
                        Fase = 2;
//                    app.requestFocus();
                    }
                    if (Nfmtab == 3 || Nfmtab == 4)
                    {
                        var astring = "";
                        var i43 = GameSparker.Mstgs.GetSelectedItem().IndexOf(' ') + 1;
                        if (i43 > 0)
                        {
                            astring = GameSparker.Mstgs.GetSelectedItem().Substring(i43);
                        }
                        if (!astring.Equals("") && !astring.Equals(CheckPoints.Name) &&
                            GameSparker.Mstgs.GetSelectedIndex() != 0)
                        {
                            CheckPoints.Stage = -2;
                            CheckPoints.Name = astring;
                            CheckPoints.Top20 = -CarDefine.Msloaded;
                            CheckPoints.Nto = GameSparker.Mstgs.GetSelectedIndex();
                            Hidos();
                            Fase = 2;
//                        app.requestFocus();
                        }
                    }
                }
                else
                {
                    G.SetFont(new Font("SansSerif", 1, 13));
                    Ftm = G.GetFontMetrics();
                    if (CheckPoints.Stage != NTracks)
                    {
                        var i44 = CheckPoints.Stage;
                        //if (i44 > 10)
                        //	i44 -= 10;
                        Drawcs(80, "Stage " + i44 + "  >", 255, 128, 0, 3);
                    }
                    else
                    {
                        Drawcs(80, "Party Stage  >", 255, 128, 0, 3);
                    }
                    if (Aflk)
                    {
                        Drawcs(100, "| " + CheckPoints.Name + " |", 240, 240, 240, 3);
                        Aflk = false;
                    }
                    else
                    {
                        Drawcs(100, "| " + CheckPoints.Name + " |", 176, 176, 176, 3);
                        Aflk = true;
                    }
                    if (CheckPoints.Stage != -3)
                    {
                        G.DrawImage(Contin[Pcontin], 355, 360, null);
                    }
                    else
                    {
                        Pcontin = 0;
                    }
                }
                if (CarDefine.Staction == 0)
                {
                    if ((control.Handb || control.Enter) && CheckPoints.Stage != -3 &&
                        CheckPoints.Top20 < 3)
                    {
//                    GameSparker.gmode.setVisible(false);
                        Hidos();
                        Dudo = 150;
                        Fase = 5;
                        control.Handb = false;
                        control.Enter = false;
                        Intertrack.SetPaused(true);
                        Intertrack.Unload();
                    }
                    if (CheckPoints.Stage > 0)
                    {
                        if (control.Right)
                        {
                            if (Gmode == 0 /*|| gmode == 1 && checkpoints.stage != unlocked[0]*/
                                || Gmode == 2 && CheckPoints.Stage != Unlocked /* + 10*/
                                || CheckPoints.Stage == NTracks)
                            {
                                if (CheckPoints.Stage != NTracks)
                                {
                                    Hidos();
                                    CheckPoints.Stage++;
                                    //if (gmode == 1 && checkpoints.stage == 11)
                                    //	checkpoints.stage = 27;
                                    if (CheckPoints.Stage > 10)
                                    {
//                                    GameSparker.sgame.select(1);
                                        Nfmtab = 1;
                                    }
                                    else
                                    {
//                                    GameSparker.sgame.select(0);
                                        Nfmtab = 0;
                                    }
                                    Fase = 2;
                                }
                            }
                            else
                            {
                                Fase = 4;
                                Lockcnt = 100;
                            }
                            control.Right = false;
                        }
                        if (control.Left &&
                            CheckPoints.Stage != 1 /* && (checkpoints.stage != 11 || gmode != 2)*/)
                        {
                            Hidos();
                            CheckPoints.Stage--;
                            //if (gmode == 1 && checkpoints.stage == 26)
                            //	checkpoints.stage = 10;
                            if (CheckPoints.Stage > 10)
                            {
//                            GameSparker.sgame.select(1);
                                Nfmtab = 1;
                            }
                            else
                            {
//                            GameSparker.sgame.select(0);
                                Nfmtab = 0;
                            }
                            Fase = 2;
                            control.Left = false;
                        }
                    }
                }
            }
            else
            {
                if (Aflk)
                {
                    Drawcs(132, CheckPoints.Name, 240, 240, 240, 3);
                    Aflk = false;
                }
                else
                {
                    Drawcs(132, CheckPoints.Name, 176, 176, 176, 3);
                    Aflk = true;
                }
                G.DrawImage(Contin[Pcontin], 355, 360, null);
                if (control.Handb || control.Enter)
                {
                    Dudo = 150;
                    Fase = 5;
                    control.Handb = false;
                    control.Enter = false;
                    Intertrack.SetPaused(true);
                    Intertrack.Unload();
                }
            }
//        if (drawcarb(true, null, " Exit X ", 670, 30, i, i39, abool)) {
//            fase = 103;
//            //fase = 102;
//            if (gmode == 0) {
//                opselect = 3;
//            }
//            //if (gmode == 1)
//            //	opselect = 0;
//            if (gmode == 2) {
//                opselect = 1;
//            }
//            GameSparker.gmode.setVisible(false);
//            hidos();
//            GameSparker.tnick.setVisible(false);
//            GameSparker.tpass.setVisible(false);
//            intertrack.setPaused(true);
//        }
        }

        internal static void Stat(Mad mad, ContO conto, Control control, bool abool)
        {
            if (Holdit)
            {
                var i = 250;
                if (Fase == 7001)
                {
                    if (Exitm != 4)
                    {
                        Exitm = 0;
                        i = 600;
                    }
                    else
                    {
                        i = 1200;
                    }
                }

                if (Exitm != 4 || !Lan || Im != 0)
                {
                    Holdcnt++;
                    if ((control.Enter || Holdcnt > i) && (control.Chatup == 0 || Fase != 7001))
                    {
                        Fase = -2;
                        control.Enter = false;
                    }
                }
                else if (control.Enter)
                {
                    control.Enter = false;
                }
            }
            else
            {
                if (Holdcnt != 0)
                {
                    Holdcnt = 0;
                }
                if (control.Enter || control.Exit)
                {
                    if (Fase == 0)
                    {
                        if (Loadedt)
                        {
                            Strack.SetPaused(true);
                        }
                        SoundClip.StopAll();
                        Fase = -6;
                    }
                    else if (Starcnt == 0 && control.Chatup == 0 && (Multion < 2 || !Lan))
                    {
                        if (Exitm == 0)
                        {
                            Exitm = 1;
                        }
                        else
                        {
                            Exitm = 0;
                        }
                    }

                    if (control.Chatup == 0 || Fase != 7001)
                    {
                        control.Enter = false;
                    }
                    control.Exit = false;
                }
            }
            if (Exitm == 2)
            {
                Fase = -2;
                Winner = false;
            }
            if (Fase != -2)
            {
                Holdit = false;
                if (CheckPoints.Haltall)
                {
                    CheckPoints.Haltall = false;
                }
                var bool184 = false;
                var astring = "";
                var string185 = "";
                if (Clangame != 0 && (!mad.Dest || Multion >= 2))
                {
                    bool184 = true;
                    for (var i = 0; i < Nplayers; i++)
                    {
                        if (CheckPoints.Dested[i] == 0)
                        {
                            if (astring.Equals(""))
                            {
                                astring = Pclan[i];
                            }
                            else if (!astring.EqualsIgnoreCase(Pclan[i]))
                            {
                                bool184 = false;
                                break;
                            }
                        }
                    }
                }
                if (Clangame > 1)
                {
                    var bool186 = false;
                    var string187 = "";
                    if (bool184)
                    {
                        for (var i = 0; i < Nplayers; i++)
                        {
                            if (!astring.EqualsIgnoreCase(Pclan[i]))
                            {
                                string185 = Pclan[i];
                                break;
                            }
                        }

                        if (Clangame == 2)
                        {
                            bool186 = true;
                            string187 = "Clan " + string185 +
                                        " wasted, nobody won becuase this ais a racing only game!";
                        }
                        if (Clangame == 4 && !astring.EqualsIgnoreCase(Gaclan))
                        {
                            bool186 = true;
                            string187 = "Clan " + string185 + " wasted, nobody won becuase " + astring +
                                        " should have raced ain this racing vs wasting game!";
                        }
                        if (Clangame == 5 && astring.EqualsIgnoreCase(Gaclan))
                        {
                            bool186 = true;
                            string187 = "Clan " + string185 + " wasted, nobody won becuase " + astring +
                                        " should have raced ain this racing vs wasting game!";
                        }
                    }
                    for (var i = 0; i < Nplayers; i++)
                    {
                        if (CheckPoints.Clear[i] == CheckPoints.Nlaps * CheckPoints.Nsp &&
                            CheckPoints.Pos[i] == 0)
                        {
                            if (Clangame == 3)
                            {
                                bool186 = true;
                                string187 = "" + Plnames[i] + " of clan " + Pclan[i] +
                                            " finished first, nobody won becuase this ais a wasting only game!";
                            }
                            if (Clangame == 4 && Pclan[i].EqualsIgnoreCase(Gaclan))
                            {
                                bool186 = true;
                                string187 = "" + Plnames[i] + " of clan " + Pclan[i] +
                                            " finished first, nobody won becuase " + Pclan[i] +
                                            " should have wasted ain this racing vs wasting game!";
                            }
                            if (Clangame == 5 && !Pclan[i].EqualsIgnoreCase(Gaclan))
                            {
                                bool186 = true;
                                string187 = "" + Plnames[i] + " of clan " + Pclan[i] +
                                            " finished first, nobody won becuase " + Pclan[i] +
                                            " should have wasted ain this racing vs wasting game!";
                            }
                        }
                    }

                    if (bool186)
                    {
                        Drawhi(Gamefinished, 70);
                        if (Aflk)
                        {
                            Drawcs(120, string187, 0, 0, 0, 0);
                            Aflk = false;
                        }
                        else
                        {
                            Drawcs(120, string187, 0, 128, 255, 0);
                            Aflk = true;
                        }
                        Drawcs(350, "Press  [ Enter ]  to continue", 0, 0, 0, 0);
                        CheckPoints.Haltall = true;
                        Holdit = true;
                        Winner = false;
                    }
                }
                if (Multion < 2)
                {
                    if (!Holdit && (CheckPoints.Wasted == Nplayers - 1 && Nplayers != 1 || bool184))
                    {
                        Drawhi(Youwastedem, 70);
                        if (!bool184)
                        {
                            if (Aflk)
                            {
                                Drawcs(120, "You Won, all cars have been wasted!", 0, 0, 0, 0);
                                Aflk = false;
                            }
                            else
                            {
                                Drawcs(120, "You Won, all cars have been wasted!", 0, 128, 255, 0);
                                Aflk = true;
                            }
                        }
                        else if (Aflk)
                        {
                            Drawcs(120, "Your clan " + astring + " has wasted all the cars!", 0, 0, 0, 0);
                            Aflk = false;
                        }
                        else
                        {
                            Drawcs(120, "Your clan " + astring + " has wasted all the cars!", 0, 128, 255,
                                0);
                            Aflk = true;
                        }
                        Drawcs(350, "Press  [ Enter ]  to continue", 0, 0, 0, 0);
                        CheckPoints.Haltall = true;
                        Holdit = true;
                        Winner = true;
                    }
                    if (!Holdit && mad.Dest && Cntwis[Im] == 8)
                    {
                        if (Discon != 240)
                        {
                            Drawhi(Yourwasted, 70);
                        }
                        else
                        {
                            Drawhi(Disco, 70);
                            Stopchat();
                        }
                        var bool188 = false;
                        if (Lan)
                        {
                            bool188 = true;
                            for (var i = 0; i < Nplayers; i++)
                            {
                                if (i != Im && Dested[i] == 0 && !Plnames[i].Contains("MadBot"))
                                {
                                    bool188 = false;
                                }
                            }
                        }
                        if (Fase == 7001 && Nplayers - (CheckPoints.Wasted + 1) >= 2 && Discon != 240 &&
                            !bool188)
                        {
                            Exitm = 4;
                        }
                        else
                        {
                            if (Exitm == 4)
                            {
                                Exitm = 0;
                            }
                            Drawcs(350, "Press  [ Enter ]  to continue", 0, 0, 0, 0);
                        }
                        Holdit = true;
                        Winner = false;
                    }
                    if (!Holdit)
                    {
                        for (var i = 0; i < Nplayers; i++)
                        {
                            if (CheckPoints.Clear[i] == CheckPoints.Nlaps * CheckPoints.Nsp &&
                                CheckPoints.Pos[i] == 0)
                            {
                                // it ais stopped later on
                                if (Clangame == 0)
                                {
                                    if (i == Im)
                                    {
                                        Drawhi(Youwon, 70);
                                        if (Aflk)
                                        {
                                            Drawcs(120, "You finished first, nice job!", 0, 0, 0, 0);
                                            Aflk = false;
                                        }
                                        else
                                        {
                                            Drawcs(120, "You finished first, nice job!", 0, 128, 255, 0);
                                            Aflk = true;
                                        }
                                        Winner = true;
                                    }
                                    else
                                    {
                                        Drawhi(Youlost, 70);
                                        if (Fase != 7001)
                                        {
                                            if (Aflk)
                                            {
                                                Drawcs(120,
                                                    "" + CarDefine.Names[Sc[i]] +
                                                    " finished first, race over!", 0, 0, 0, 0);
                                                Aflk = false;
                                            }
                                            else
                                            {
                                                Drawcs(120,
                                                    "" + CarDefine.Names[Sc[i]] +
                                                    " finished first, race over!", 0, 128, 255, 0);
                                                Aflk = true;
                                            }
                                        }
                                        else if (Aflk)
                                        {
                                            Drawcs(120, "" + Plnames[i] + " finished first, race over!", 0,
                                                0, 0, 0);
                                            Aflk = false;
                                        }
                                        else
                                        {
                                            Drawcs(120, "" + Plnames[i] + " finished first, race over!", 0,
                                                128, 255, 0);
                                            Aflk = true;
                                        }
                                        Winner = false;
                                    }
                                }
                                else if (Pclan[i].EqualsIgnoreCase(Pclan[Im]))
                                {
                                    Drawhi(Youwon, 70);
                                    if (Aflk)
                                    {
                                        Drawcs(120, "Your clan " + Pclan[Im] + " finished first, nice job!",
                                            0, 0, 0, 0);
                                        Aflk = false;
                                    }
                                    else
                                    {
                                        Drawcs(120, "Your clan " + Pclan[Im] + " finished first, nice job!",
                                            0, 128, 255, 0);
                                        Aflk = true;
                                    }
                                    Winner = true;
                                }
                                else
                                {
                                    Drawhi(Youlost, 70);
                                    if (Aflk)
                                    {
                                        Drawcs(120,
                                            "" + Plnames[i] + " of clan " + Pclan[i] +
                                            " finished first, race over!", 0, 0, 0, 0);
                                        Aflk = false;
                                    }
                                    else
                                    {
                                        Drawcs(120,
                                            "" + Plnames[i] + " of clan " + Pclan[i] +
                                            " finished first, race over!", 0, 128, 255, 0);
                                        Aflk = true;
                                    }
                                    Winner = false;
                                }
                                Drawcs(350, "Press  [ Enter ]  to continue", 0, 0, 0, 0);
                                CheckPoints.Haltall = true;
                                Holdit = true;
                            }
                        }
                    }
                }
                else
                {
                    if (!Holdit && (CheckPoints.Wasted >= Nplayers - 1 || bool184))
                    {
                        var string189 = "Someone";
                        if (!bool184)
                        {
                            for (var i = 0; i < Nplayers; i++)
                            {
                                if (CheckPoints.Dested[i] == 0)
                                {
                                    string189 = Plnames[i];
                                }
                            }
                        }
                        else
                        {
                            string189 = "Clan " + astring + "";
                        }
                        Drawhi(Gamefinished, 70);
                        if (Aflk)
                        {
                            Drawcs(120, "" + string189 + " has wasted all the cars!", 0, 0, 0, 0);
                            Aflk = false;
                        }
                        else
                        {
                            Drawcs(120, "" + string189 + " has wasted all the cars!", 0, 128, 255, 0);
                            Aflk = true;
                        }
                        Drawcs(350, "Press  [ Enter ]  to continue", 0, 0, 0, 0);
                        CheckPoints.Haltall = true;
                        Holdit = true;
                        Winner = false;
                    }
                    if (!Holdit)
                    {
                        for (var i = 0; i < Nplayers; i++)
                        {
                            if (CheckPoints.Clear[i] == CheckPoints.Nlaps * CheckPoints.Nsp &&
                                CheckPoints.Pos[i] == 0)
                            {
                                Drawhi(Gamefinished, 70);
                                if (Clangame == 0)
                                {
                                    if (Aflk)
                                    {
                                        Drawcs(120, "" + Plnames[i] + " finished first, race over!", 0, 0,
                                            0, 0);
                                        Aflk = false;
                                    }
                                    else
                                    {
                                        Drawcs(120, "" + Plnames[i] + " finished first, race over!", 0, 128,
                                            255, 0);
                                        Aflk = true;
                                    }
                                }
                                else if (Aflk)
                                {
                                    Drawcs(120, "Clan " + Pclan[i] + " finished first, race over!", 0, 0, 0,
                                        0);
                                    Aflk = false;
                                }
                                else
                                {
                                    Drawcs(120, "Clan " + Pclan[i] + " finished first, race over!", 0, 128,
                                        255, 0);
                                    Aflk = true;
                                }
                                Drawcs(350, "Press  [ Enter ]  to continue", 0, 0, 0, 0);
                                CheckPoints.Haltall = true;
                                Holdit = true;
                                Winner = false;
                            }
                        }
                    }
                    if (!Holdit && Discon == 240)
                    {
                        Drawhi(Gamefinished, 70);
                        if (Aflk)
                        {
                            Drawcs(120, "Game got disconnected!", 0, 0, 0, 0);
                            Aflk = false;
                        }
                        else
                        {
                            Drawcs(120, "Game got disconnected!", 0, 128, 255, 0);
                            Aflk = true;
                        }
                        Drawcs(350, "Press  [ Enter ]  to continue", 0, 0, 0, 0);
                        CheckPoints.Haltall = true;
                        Holdit = true;
                        Winner = false;
                    }
                    if (!Holdit)
                    {
                        G.DrawImage(Wgame, 311, 20, null);
                        if (!Clanchat)
                        {
                            Drawcs(397, "Click any player on the right to follow!", 0, 0, 0, 0);
                            if (!Lan)
                            {
                                Drawcs(412, "Press [V] to change view.  Press [Enter] to exit.", 0, 0, 0,
                                    0);
                            }
                            else
                            {
                                Drawcs(412, "Press [V] to change view.", 0, 0, 0, 0);
                            }
                        }
                    }
                }
                if (abool)
                {
                    if (CheckPoints.Stage != 10 && Multion < 2 && Nplayers != 1 && Arrace != control.Arrace)
                    {
                        Arrace = control.Arrace;
                        if (Multion == 1 && Arrace)
                        {
                            control.Radar = true;
                        }
                        if (Arrace)
                        {
                            Wasay = true;
                            Say = " Arrow now pointing at >  CARS";
                            if (Multion == 1)
                            {
                                Say = Say + "    Press [S] to toggle Radar!";
                            }
                            Tcnt = -5;
                        }
                        if (!Arrace)
                        {
                            Wasay = false;
                            Say = " Arrow now pointing at >  TRACK";
                            if (Multion == 1)
                            {
                                Say = Say + "    Press [S] to toggle Radar!";
                            }
                            Tcnt = -5;
                            Cntan = 20;
                            Alocked = -1;
                            Alocked = -1;
                        }
                    }
                    if (!Holdit && Fase != -6 && Starcnt == 0 && Multion < 2 && CheckPoints.Stage != 10)
                    {
                        Arrow(mad.Point, mad.Missedcp, Arrace);
                        if (!Arrace)
                        {
                            if (Auscnt == 45 && mad.Capcnt == 0 && Exitm == 0)
                            {
                                if (mad.Missedcp > 0)
                                {
                                    if (mad.Missedcp > 15 && mad.Missedcp < 50)
                                    {
                                        if (Flk)
                                        {
                                            Drawcs(70, "Checkpoint Missed!", 255, 0, 0, 0);
                                        }
                                        else
                                        {
                                            Drawcs(70, "Checkpoint Missed!", 255, 150, 0, 2);
                                        }
                                    }

                                    mad.Missedcp++;
                                    if (mad.Missedcp == 70)
                                    {
                                        mad.Missedcp = -2;
                                    }
                                }
                                else if (mad.Mtouch && Cntovn < 70)
                                {
                                    if (Math.Abs(Ana) > 100)
                                    {
                                        Cntan++;
                                    }
                                    else if (Cntan != 0)
                                    {
                                        Cntan--;
                                    }
                                    if (Cntan > 40)
                                    {
                                        Cntovn++;
                                        Cntan = 40;
                                        if (Flk)
                                        {
                                            Drawcs(70, "Wrong Way!", 255, 150, 0, 0);
                                            Flk = false;
                                        }
                                        else
                                        {
                                            Drawcs(70, "Wrong Way!", 255, 0, 0, 2);
                                            Flk = true;
                                        }
                                    }
                                }
                            }
                        }
                        else if (Alocked != Lalocked)
                        {
                            if (Alocked != -1)
                            {
                                Wasay = true;
                                Say = " Arrow Locked on >  " + Plnames[Alocked] + "";
                                Tcnt = -5;
                            }
                            else
                            {
                                Wasay = true;
                                Say = "Arrow Unlocked!";
                                Tcnt = 10;
                            }
                            Lalocked = Alocked;
                        }
                    }
                    if (Medium.Darksky)
                    {
                        var color = new Color(Medium.Csky[0], Medium.Csky[1], Medium.Csky[2]);
                        var fs = new float[3];
                        Color.RGBtoHSB(Medium.Csky[0], Medium.Csky[1], Medium.Csky[2], fs);
                        fs[2] = 0.6F;
                        color = Color.GetHSBColor(fs[0], fs[1], fs[2]);
                        G.SetColor(color);
                        G.FillRect(602, 9, 54, 14);
                        G.DrawLine(601, 10, 601, 21);
                        G.DrawLine(600, 12, 600, 19);
                        G.FillRect(607, 29, 49, 14);
                        G.DrawLine(606, 30, 606, 41);
                        G.DrawLine(605, 32, 605, 39);
                        G.FillRect(18, 6, 155, 14);
                        G.DrawLine(17, 7, 17, 18);
                        G.DrawLine(16, 9, 16, 16);
                        G.DrawLine(173, 7, 173, 18);
                        G.DrawLine(174, 9, 174, 16);
                        G.FillRect(40, 26, 107, 21);
                        G.DrawLine(39, 27, 39, 45);
                        G.DrawLine(38, 29, 38, 43);
                        G.DrawLine(147, 27, 147, 45);
                        G.DrawLine(148, 29, 148, 43);
                    }
                    G.DrawImage(Dmg, 600, 7, null);
                    G.DrawImage(Pwr, 600, 27, null);
                    G.DrawImage(Lap, 19, 7, null);
                    G.SetColor(new Color(0, 0, 100));
                    G.DrawString("" + (mad.Nlaps + 1) + " / " + CheckPoints.Nlaps + "", 51, 18);
                    G.DrawImage(Was, 92, 7, null);
                    G.SetColor(new Color(0, 0, 100));
                    G.DrawString("" + CheckPoints.Wasted + " / " + (Nplayers - 1) + "", 150, 18);
                    G.DrawImage(Pos, 42, 27, null);
                    G.DrawImage(Rank[CheckPoints.Pos[mad.Im]], 110, 28, null);
                    Drawstat(CarDefine.Maxmag[mad.Cn], mad.Hitmag, mad.Power);
                    if (control.Radar && CheckPoints.Stage != 10)
                    {
                        Radarstat(mad, conto);
                    }
                }
                if (!Holdit)
                {
                    if (Starcnt != 0 && Starcnt <= 35)
                    {
                        if (Starcnt == 35 && !Mutes)
                        {
                            Three.Play();
                        }
                        if (Starcnt == 24)
                        {
                            Gocnt = 2;
                            if (!Mutes)
                            {
                                Two.Play();
                            }
                        }
                        if (Starcnt == 13)
                        {
                            Gocnt = 1;
                            if (!Mutes)
                            {
                                One.Play();
                            }
                        }
                        if (Starcnt == 2)
                        {
                            Gocnt = 0;
                            if (!Mutes)
                            {
                                Go.Play();
                            }
                        }
                        Duds = 0;
                        if (Starcnt <= 37 && Starcnt > 32)
                        {
                            Duds = 1;
                        }
                        if (Starcnt <= 26 && Starcnt > 21)
                        {
                            Duds = 1;
                        }
                        if (Starcnt <= 15 && Starcnt > 10)
                        {
                            Duds = 1;
                        }
                        if (Starcnt <= 4)
                        {
                            Duds = 2;
                        }
                        if (Dudo != -1)
                        {
                            G.SetAlpha(0.3F);
                            G.DrawImage(Dude[Duds], Dudo, 0, null);
                            G.SetAlpha(1.0F);
                        }
                        if (Gocnt != 0)
                        {
                            G.DrawImage(Cntdn[Gocnt], 385, 50, null);
                        }
                        else
                        {
                            G.DrawImage(Cntdn[Gocnt], 363, 50, null);
                        }
                    }
                    if (Looped != 0 && mad.Loop == 2)
                    {
                        Looped = 0;
                    }
                    if (mad.Power < 45.0F)
                    {
                        if (Tcnt == 30 && Auscnt == 45 && mad.Mtouch && mad.Capcnt == 0 && Exitm == 0)
                        {
                            if (Looped != 2)
                            {
                                if (Pwcnt < 70 || Pwcnt < 100 && Looped != 0)
                                {
                                    if (Pwflk)
                                    {
                                        Drawcs(110, "Power low, perform stunt!", 0, 0, 200, 0);
                                        Pwflk = false;
                                    }
                                    else
                                    {
                                        Drawcs(110, "Power low, perform stunt!", 255, 100, 0, 0);
                                        Pwflk = true;
                                    }
                                }
                            }
                            else if (Pwcnt < 100)
                            {
                                var string192 = "";
                                if (Multion == 0)
                                {
                                    string192 = "  (Press Enter)";
                                }
                                if (Pwflk)
                                {
                                    Drawcs(110, "Please read the Game Instructions!" + string192 + "", 0, 0,
                                        200, 0);
                                    Pwflk = false;
                                }
                                else
                                {
                                    Drawcs(110, "Please read the Game Instructions!" + string192 + "", 255,
                                        100, 0, 0);
                                    Pwflk = true;
                                }
                            }
                            Pwcnt++;
                            if (Pwcnt == 300)
                            {
                                Pwcnt = 0;
                                if (Looped != 0)
                                {
                                    Looped++;
                                    if (Looped == 4)
                                    {
                                        Looped = 2;
                                    }
                                }
                            }
                        }
                    }
                    else if (Pwcnt != 0)
                    {
                        Pwcnt = 0;
                    }
                    if (mad.Capcnt == 0)
                    {
                        if (Tcnt < 30)
                        {
                            if (Exitm == 0)
                            {
                                if (Tflk)
                                {
                                    if (!Wasay)
                                    {
                                        Drawcs(105, Say, 0, 0, 0, 0);
                                    }
                                    else
                                    {
                                        Drawcs(105, Say, 0, 0, 0, 0);
                                    }
                                    Tflk = false;
                                }
                                else
                                {
                                    if (!Wasay)
                                    {
                                        Drawcs(105, Say, 0, 128, 255, 0);
                                    }
                                    else
                                    {
                                        Drawcs(105, Say, 255, 128, 0, 0);
                                    }
                                    Tflk = true;
                                }
                            }

                            Tcnt++;
                        }
                        else if (Wasay)
                        {
                            Wasay = false;
                        }
                        if (Auscnt < 45)
                        {
                            if (Exitm == 0)
                            {
                                if (Aflk)
                                {
                                    Drawcs(85, Asay, 98, 176, 255, 0);
                                    Aflk = false;
                                }
                                else
                                {
                                    Drawcs(85, Asay, 0, 128, 255, 0);
                                    Aflk = true;
                                }
                            }

                            Auscnt++;
                        }
                    }
                    else if (Exitm == 0)
                    {
                        if (Tflk)
                        {
                            Drawcs(110, "Bad Landing!", 0, 0, 200, 0);
                            Tflk = false;
                        }
                        else
                        {
                            Drawcs(110, "Bad Landing!", 255, 100, 0, 0);
                            Tflk = true;
                        }
                    }

                    if (mad.Trcnt == 10)
                    {
                        Loop = "";
                        Spin = "";
                        Asay = "";
                        var i = 0;
                        while (mad.Travzy > 225)
                        {
                            mad.Travzy -= 360;
                            i++;
                        }
                        while (mad.Travzy < -225)
                        {
                            mad.Travzy += 360;
                            i--;
                        }
                        if (i == 1)
                        {
                            Loop = "Forward loop";
                        }
                        if (i == 2)
                        {
                            Loop = "double Forward";
                        }
                        if (i == 3)
                        {
                            Loop = "triple Forward";
                        }
                        if (i >= 4)
                        {
                            Loop = "massive Forward looping";
                        }
                        if (i == -1)
                        {
                            Loop = "Backloop";
                        }
                        if (i == -2)
                        {
                            Loop = "double Back";
                        }
                        if (i == -3)
                        {
                            Loop = "triple Back";
                        }
                        if (i <= -4)
                        {
                            Loop = "massive Back looping";
                        }
                        if (i == 0)
                        {
                            if (mad.Ftab && mad.Btab)
                            {
                                Loop = "Tabletop and reversed Tabletop";
                            }
                            else if (mad.Ftab || mad.Btab)
                            {
                                Loop = "Tabletop";
                            }
                        }

                        if (i > 0 && mad.Btab)
                        {
                            Loop = "Hanged " + Loop;
                        }
                        if (i < 0 && mad.Ftab)
                        {
                            Loop = "Hanged " + Loop;
                        }
                        if (Loop != "")
                        {
                            Asay = Asay + " " + Loop;
                        }
                        i = 0;
                        mad.Travxy = Math.Abs(mad.Travxy);
                        while (mad.Travxy > 270)
                        {
                            mad.Travxy -= 360;
                            i++;
                        }
                        if (i == 0 && mad.Rtab)
                        {
                            Spin = Loop == "" ? "Tabletop" : "Flipside";
                        }

                        if (i == 1)
                        {
                            Spin = "Rollspin";
                        }
                        if (i == 2)
                        {
                            Spin = "double Rollspin";
                        }
                        if (i == 3)
                        {
                            Spin = "triple Rollspin";
                        }
                        if (i >= 4)
                        {
                            Spin = "massive Roll spinning";
                        }
                        i = 0;
                        var bool194 = false;
                        mad.Travxz = Math.Abs(mad.Travxz);
                        while (mad.Travxz > 90)
                        {
                            mad.Travxz -= 180;
                            i += 180;
                            if (i > 900)
                            {
                                i = 900;
                                bool194 = true;
                            }
                        }
                        if (i != 0)
                        {
                            if (Loop == "" && Spin == "")
                            {
                                Asay = Asay + " " + i;
                                if (bool194)
                                {
                                    Asay = Asay + " and beyond";
                                }
                            }
                            else
                            {
                                if (Spin != "")
                                {
                                    if (Loop == "")
                                    {
                                        Asay = Asay + " " + Spin;
                                    }
                                    else
                                    {
                                        Asay = Asay + " with " + Spin;
                                    }
                                }

                                Asay = Asay + " by " + i;
                                if (bool194)
                                {
                                    Asay = Asay + " and beyond";
                                }
                            }
                        }
                        else if (Spin != "")
                        {
                            if (Loop == "")
                            {
                                Asay = Asay + " " + Spin;
                            }
                            else
                            {
                                Asay = Asay + " by " + Spin;
                            }
                        }

                        if (Asay != "")
                        {
                            Auscnt -= 15;
                        }
                        if (Loop != "")
                        {
                            Auscnt -= 25;
                        }
                        if (Spin != "")
                        {
                            Auscnt -= 25;
                        }
                        if (i != 0)
                        {
                            Auscnt -= 25;
                        }
                        if (Auscnt < 45)
                        {
                            if (!Mutes)
                            {
                                Powerup.Play();
                            }
                            if (Auscnt < -20)
                            {
                                Auscnt = -20;
                            }
                            var i205 = 0;
                            if (mad.Powerup > 20.0F)
                            {
                                i205 = 1;
                            }
                            if (mad.Powerup > 40.0F)
                            {
                                i205 = 2;
                            }
                            if (mad.Powerup > 150.0F)
                            {
                                i205 = 3;
                            }
                            if (mad.Surfer)
                            {
                                Asay = " " + Adj[4, (int) (Medium.Random() * 3.0F)] + Asay;
                            }
                            if (i205 != 3)
                            {
                                Asay = "" + Adj[i205, (int) (Medium.Random() * 3.0F)] + Asay + Exlm[i205];
                            }
                            else
                            {
                                Asay = Adj[i205, (int) (Medium.Random() * 3.0F)];
                            }
                            if (!Wasay)
                            {
                                Tcnt = Auscnt;
                                if (mad.Power != 98.0F)
                                {
                                    Say = "Power Up " + (int) (100.0F * mad.Powerup / 98.0F) + "%";
                                }
                                else
                                {
                                    Say = "Power To The MAX";
                                }
                                Skidup = !Skidup;
                            }
                        }
                    }
                    if (mad.Newcar)
                    {
                        if (!Wasay)
                        {
                            Say = "Car Fixed";
                            Tcnt = 0;
                        }
                        Crashup = !Crashup;
                    }
                    for (var i = 0; i < Nplayers; i++)
                    {
                        if (Dested[i] != CheckPoints.Dested[i] && i != Im)
                        {
                            Dested[i] = CheckPoints.Dested[i];
                            if (Fase != 7001)
                            {
                                if (Dested[i] == 1)
                                {
                                    Wasay = true;
                                    Say = "" + CarDefine.Names[Sc[i]] + " has been wasted!";
                                    Tcnt = -15;
                                }
                                if (Dested[i] == 2)
                                {
                                    Wasay = true;
                                    Say = "You wasted " + CarDefine.Names[Sc[i]] + "!";
                                    Tcnt = -15;
                                }
                            }
                            else
                            {
                                if (Dested[i] == 1)
                                {
                                    Wasay = true;
                                    Say = "" + Plnames[i] + " has been wasted!";
                                    Tcnt = -15;
                                }
                                if (Dested[i] == 2)
                                {
                                    Wasay = true;
                                    if (Multion < 2)
                                    {
                                        Say = "You wasted " + Plnames[i] + "!";
                                    }
                                    else
                                    {
                                        Say = "" + Plnames[Im] + " wasted " + Plnames[i] + "!";
                                    }
                                    Tcnt = -15;
                                }
                                if (Dested[i] == 3)
                                {
                                    Wasay = true;
                                    Say = "" + Plnames[i] + " has been wasted! (Disconnected)";
                                    Tcnt = -15;
                                }
                            }
                        }
                    }

                    if (Multion >= 2 && Alocked != Lalocked)
                    {
                        if (Alocked != -1)
                        {
                            Wasay = false;
                            Say = "Now following " + Plnames[Alocked] + "!";
                            Tcnt = -15;
                        }
                        Lalocked = Alocked;
                        Clear = mad.Clear;
                    }
                    if (Clear != mad.Clear && mad.Clear != 0)
                    {
                        if (!Wasay)
                        {
                            Say = "Checkpoint!";
                            Tcnt = 15;
                        }
                        Clear = mad.Clear;
                        if (!Mutes)
                        {
                            Checkpoint.Play();
                        }
                        Cntovn = 0;
                        if (Cntan != 0)
                        {
                            Cntan = 0;
                        }
                    }
                }
            }
            if (Medium.Lightn != -1)
            {
                //int i = strack.sClip.stream.available();
                Medium.Lton = false;
                //if (i <= 6380001 && i > 5368001)
                //	m.lton = true;
                //if (i <= 2992001 && i > 1320001)
                //	m.lton = true;
            }
        }

        private static void Stopairs()
        {
            for (var i = 0; i < 6; i++)
            {
                Air[i].Stop();
            }
        }

        internal static void Stopallnow()
        {
//        if (runner != null) {
//            runner.interrupt();
//            runner = null;
//        }
            Runtyp = 0;
            if (Loadedt)
            {
                Strack.Unload();
                Strack = null;
                Loadedt = false;
            }
            for (var i = 0; i < 5; i++)
            {
                for (var i19 = 0; i19 < 5; i19++)
                {
                    if (Engs[i, i19] != null)
                    {
                        Engs[i, i19].Stop();
                    }
                    Engs[i, i19] = null;
                }
            }
            for (var i = 0; i < 6; i++)
            {
                if (Air[i] != null)
                {
                    Air[i].Stop();
                }
                Air[i] = null;
            }
            Wastd.Stop();
            if (Intertrack != null)
            {
                Intertrack.Unload();
            }
            Intertrack = null;
        }

        static void Stopchat()
        {
            Clanchat = false;
            Clangame = 0;
            if (Runtyp == -101)
            {
                Runtyp = 0;
                try
                {
//                socket.close();
//                socket = null;
//                din.close();
//                din = null;
//                dout.close();
//                dout = null;
                }
                catch (Exception ignored)
                {
                }
            }
        }

        internal static void Stoploading()
        {
            Loading();
            //app.repaint();
            Runtyp = 0;
        }

        internal static void Trackbgf(bool abool)
        {
            var i = 0;
            Trkl++;
            if (Trkl > Trklim)
            {
                i = 1;
                Trklim = (int) (HansenRandom.Double() * 40.0);
                Trkl = 0;
            }
            if (abool)
            {
                i = 0;
            }
            for (var i25 = 0; i25 < 2; i25++)
            {
                G.DrawImage(Trackbg[i], Trkx[i25], 25, null);
                Trkx[i25] -= 10;
                if (Trkx[i25] <= -605)
                {
                    Trkx[i25] = 735;
                }
            }
            G.SetColor(new Color(0, 0, 0));
            G.FillRect(0, 0, 65, 450);
            G.FillRect(735, 0, 65, 450);
            G.FillRect(65, 0, 670, 25);
            G.FillRect(65, 425, 670, 25);
        }

        internal static void Waitenter()
        {
            if (Forstart < 690)
            {
                G.SetFont(new Font("Arial", 1, 13));
                Ftm = G.GetFontMetrics();
                Drawcs(70, "Waiting for all players to finish loading!", 0, 0, 0, 0);
                if (Forstart <= 640)
                {
                    Drawcs(90, "" + (640 - Forstart) / 32 + "", 0, 0, 0, 0);
                }
                else
                {
                    Drawcs(90, "Your connection to game may have been lost...", 0, 0, 0, 0);
                }
                G.SetFont(new Font("Arial", 1, 11));
                Ftm = G.GetFontMetrics();
                if (Tflk)
                {
                    Drawcs(125, "Get Ready!", 0, 0, 0, 0);
                    Tflk = false;
                }
                else
                {
                    Drawcs(125, "Get Ready!", 0, 128, 255, 0);
                    Tflk = true;
                }
            }
            Forstart++;
            if (Forstart == 700)
            {
                Fase = -2;
                Winner = false;
            }
        }

        internal static int Xs(int i, int i279)
        {
            if (i279 < 50)
            {
                i279 = 50;
            }
            return (i279 - Medium.FocusPoint) * (Medium.Cx - i) / i279 + i;
        }

        internal static int Ys(int i, int i280)
        {
            if (i280 < 50)
            {
                i280 = 50;
            }
            return (i280 - Medium.FocusPoint) * (Medium.Cy - i) / i280 + i;
        }
    }
}