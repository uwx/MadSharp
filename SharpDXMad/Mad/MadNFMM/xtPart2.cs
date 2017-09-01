using System;
using System.Collections.Generic;
using MadGame;
using static Cum.xtGraphics;
using static Cum.xtImages.Images;
using boolean = System.Boolean;

namespace Cum
{
    public class xtPart2
    {
        
    static private Image loadude(byte[] ais)
    {
        return ImageIO.read(ais);
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

    internal static void mainbg(int i) {
        int i26 = 2;
        G.setColor(new Color(191, 184, 124));
        if (i == -1) {
            if (i != lmode) {
                bgmy[0] = 0;
                bgmy[1] = -400;
                bgup = false;
                bgf = 0.0F;
                lmode = i;
            }
            G.setColor(new Color(144, 222, 9));
            i26 = 8;
        }
        if (i == 0) {
            if (i != lmode) {
                bgmy[0] = 0;
                bgmy[1] = -400;
                bgup = false;
                bgf = 0.0F;
                lmode = i;
            }
            int i27 = (int) (255.0F * bgf + 191.0F * (1.0F - bgf));
            int i28 = (int) (176.0F * bgf + 184.0F * (1.0F - bgf));
            int i29 = (int) (67.0F * bgf + 124.0F * (1.0F - bgf));
            if (!bgup) {
                bgf += 0.02F;
                if (bgf > 0.9F) {
                    bgf = 0.9F;
                    bgup = true;
                }
            } else {
                bgf -= 0.02F;
                if (bgf < 0.2F) {
                    bgf = 0.2F;
                    bgup = false;
                }
            }
            G.setColor(new Color(i27, i28, i29));
            i26 = 4;
        }
        if (i == 1) {
            if (i != lmode) {
                bgmy[0] = 0;
                bgmy[1] = -400;
                lmode = i;
            }
            G.setColor(new Color(255, 176, 67));
            i26 = 8;
        }
        if (i == 2) {
            if (i != lmode) {
                bgmy[0] = 0;
                bgmy[1] = -400;
                lmode = i;
                bgf = 0.2F;
            }
            G.setColor(new Color(188, 170, 122));
            if (flipo == 16) {
                int i30 = (int) (176.0F * bgf + 191.0F * (1.0F - bgf));
                int i31 = (int) (202.0F * bgf + 184.0F * (1.0F - bgf));
                int i32 = (int) (255.0F * bgf + 124.0F * (1.0F - bgf));
                G.setColor(new Color(i30, i31, i32));
                bgf += 0.025F;
                if (bgf > 0.85F) {
                    bgf = 0.85F;
                }
            } else {
                bgf = 0.2F;
            }
            i26 = 2;
        }
        if (i == 3) {
            if (i != lmode) {
                bgmy[0] = 0;
                bgmy[1] = -400;
                bgup = false;
                bgf = 0.0F;
                lmode = i;
            }
            int i33 = (int) (255.0F * bgf + 191.0F * (1.0F - bgf));
            int i34 = (int) (176.0F * bgf + 184.0F * (1.0F - bgf));
            int i35 = (int) (67.0F * bgf + 124.0F * (1.0F - bgf));
            if (!bgup) {
                bgf += 0.02F;
                if (bgf > 0.9F) {
                    bgf = 0.9F;
                    bgup = true;
                }
            } else {
                bgf -= 0.02F;
                if (bgf < 0.2F) {
                    bgf = 0.2F;
                    bgup = false;
                }
            }
            G.setColor(new Color(i33, i34, i35));
            i26 = 2;
        }
        if (i != -101)
            if (i == 4) {
                G.setColor(new Color(216, 177, 100));
                G.fillRect(65, 0, 670, 425);
            } else {
                G.fillRect(65, 25, 670, 400);
            }
        if (i == 4) {
            if (i != lmode) {
                bgmy[0] = 0;
                bgmy[1] = 400;
                for (int i36 = 0; i36 < 4; i36++) {
                    ovw[i36] = (int) (50.0 + 150.0 * HansenRandom.Double());
                    ovh[i36] = (int) (50.0 + 150.0 * HansenRandom.Double());
                    ovy[i36] = (int) (400.0 * HansenRandom.Double());
                    ovx[i36] = (int) (HansenRandom.Double() * 670.0);
                    ovsx[i36] = (int) (5.0 + HansenRandom.Double() * 10.0);
                }
                lmode = i;
            }
            for (int i37 = 0; i37 < 4; i37++) {
                G.setColor(new Color(235, 176, 84));
                G.fillOval((int) (65 + ovx[i37] - ovw[i37] * 1.5 / 2.0), (int) (25 + ovy[i37] - ovh[i37] * 1.5 / 2.0), (int) (ovw[i37] * 1.5), (int) (ovh[i37] * 1.5));
                G.setColor(new Color(255, 176, 67));
                G.fillOval(65 + ovx[i37] - ovh[i37] / 2, 25 + ovy[i37] - ovh[i37] / 2, ovw[i37], ovh[i37]);
                ovx[i37] -= ovsx[i37];
                if (ovx[i37] + ovw[i37] * 1.5 / 2.0 < 0.0) {
                    ovw[i37] = (int) (50.0 + 150.0 * HansenRandom.Double());
                    ovh[i37] = (int) (50.0 + 150.0 * HansenRandom.Double());
                    ovy[i37] = (int) (400.0 * HansenRandom.Double());
                    ovx[i37] = (int) (670.0 + ovw[i37] * 1.5 / 2.0);
                    ovsx[i37] = (int) (5.0 + HansenRandom.Double() * 10.0);
                }
            }
        }
        if (i != -101 && i != 4) {
            for (int i38 = 0; i38 < 2; i38++) {
                if (i != 2 || flipo != 16) {
                    G.drawImage(bgmain, 65, 25 + bgmy[i38], null);
                }
                bgmy[i38] += i26;
                if (bgmy[i38] >= 400) {
                    bgmy[i38] = -400;
                }
            }
        }
        G.setColor(new Color(0, 0, 0));
        G.fillRect(0, 0, 65, 450);
        G.fillRect(735, 0, 65, 450);
        if (i != 4) {
            G.fillRect(65, 0, 670, 25);
        }
        G.fillRect(65, 425, 670, 25);
    }

    static void maini(Control control) {
        if (flipo == 0) {
            //app.setCursor(new Cursor(0));
            flipo++;
        }
        mainbg(1);
        G.setAlpha(0.6F);
        G.drawImage(logomadbg, 65, 25, null);
        G.setAlpha(1.0F);
        G.drawImage(logomadnes, 233, 186, null);
        float f = flkat / 800.0F;
        if (f > 0.2) {
            f = 0.2F;
        }
        if (flkat > 200) {
            f = (400 - flkat) / 1000.0F;
            if (f < 0.0F) {
                f = 0.0F;
            }
        }
        flkat++;
        if (flkat == 400) {
            flkat = 0;
        }
        G.setAlpha(f);
        G.drawImage(dude[0], 351 + gxdu, 28 + gydu, null);
        G.setAlpha(1.0F);
        if (movly == 0) {
            gxdu = (int) (5.0 - 11.0 * HansenRandom.Double());
            gydu = (int) (5.0 - 11.0 * HansenRandom.Double());
        }
        movly++;
        if (movly == 2) {
            movly = 0;
        }
        G.drawImage(logocars, 66, 33, null);
        G.drawImage(opback, 247, 237, null);
        if (muhi < 0) {
            G.setColor(new Color(140, 70, 0));
            G.fillRoundRect(335, 293, 114, 19, 7, 20);
        }
        muhi--;
        if (muhi < -5) {
            muhi = 50;
        }
        if (control.up) {
            opselect--;
            if (opselect == -1) {
                opselect = 3;
            }
            control.up = false;
        }
        if (control.down) {
            opselect++;
            if (opselect == 4) {
                opselect = 0;
            }
            control.down = false;
        }
        if (opselect == 0) {
            if (shaded) {
                G.setColor(new Color(140, 70, 0));
                G.fillRect(343, 261, 110, 22);
                aflk = false;
            }
            if (aflk) {
                G.setColor(new Color(200, 200, 0));
                aflk = false;
            } else {
                G.setColor(new Color(255, 128, 0));
                aflk = true;
            }
            G.drawRoundRect(343, 261, 110, 22, 7, 20);
        } else {
            G.setColor(new Color(0, 0, 0));
            G.drawRoundRect(343, 261, 110, 22, 7, 20);
        }
        if (opselect == 1) {
            if (shaded) {
                G.setColor(new Color(140, 70, 0));
                G.fillRect(288, 291, 221, 22);
                aflk = false;
            }
            if (aflk) {
                G.setColor(new Color(200, 191, 0));
                aflk = false;
            } else {
                G.setColor(new Color(255, 95, 0));
                aflk = true;
            }
            G.drawRoundRect(288, 291, 221, 22, 7, 20);
        } else {
            G.setColor(new Color(0, 0, 0));
            G.drawRoundRect(288, 291, 221, 22, 7, 20);
        }
        if (opselect == 2) {
            if (shaded) {
                G.setColor(new Color(140, 70, 0));
                G.fillRect(301, 321, 196, 22);
                aflk = false;
            }
            if (aflk) {
                G.setColor(new Color(200, 128, 0));
                aflk = false;
            } else {
                G.setColor(new Color(255, 128, 0));
                aflk = true;
            }
            G.drawRoundRect(301, 321, 196, 22, 7, 20);
        } else {
            G.setColor(new Color(0, 0, 0));
            G.drawRoundRect(301, 321, 196, 22, 7, 20);
        }
        if (opselect == 3) {
            if (shaded) {
                G.setColor(new Color(140, 70, 0));
                G.fillRect(357, 351, 85, 22);
                aflk = false;
            }
            if (aflk) {
                G.setColor(new Color(200, 0, 0));
                aflk = false;
            } else {
                G.setColor(new Color(255, 128, 0));
                aflk = true;
            }
            G.drawRoundRect(357, 351, 85, 22, 7, 20);
        } else {
            G.setColor(new Color(0, 0, 0));
            G.drawRoundRect(357, 351, 85, 22, 7, 20);
        }
        G.drawImage(opti, 294, 265, null);
        if (control.enter || control.handb) {
            if (opselect == 1) {
                mtop = true;
                multion = 1;
                gmode = 0;
                if (firstime) {
                    oldfase = -9;
                    fase = 11;
                    firstime = false;
                } else {
                    fase = -9;
                }
            }
            if (opselect == 2) {
                oldfase = 10;
                fase = 11;
                firstime = false;
            }
            if (opselect == 3) {
                fase = 8;
            }
            if (opselect == 0)
                /*if (unlocked[0] == 11)
                	if (unlocked[1] != 17)
                		opselect = 1;
                	else
                		opselect = 2;*/
                if (firstime) {
                    oldfase = 102;
                    fase = 11;
                    firstime = false;
                } else {
                    fase = 102;
                }
            flipo = 0;
            control.enter = false;
            control.handb = false;
        }
        G.drawImage(byrd, 72, 410, null);
        G.drawImage(nfmcoms, 567, 410, null);
        if (shaded) {
            //app.repaint();
            try {
                HansenSystem.RequestSleep(200L);
            } catch (Exception ignored) {

            }
        }
    }

    static void maini2() {
        mainbg(1);
        multion = 0;
        clangame = 0;
        gmode = 2;
        fase = -9;
        opselect = 0;
    }

    static private void makecarsbgc(Image image, Image image386)
    {
        carsbgc = carsbg; // TODO
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

    static boolean msgcheck(String astring) {
        boolean abool = false;
        astring = astring.ToLower();
        String[] strings = {
                "fu ", " rape", "slut ", "screw ", "redtube", "fuck", "fuk", "f*ck", "fu*k", "f**k", "ass hole",
                "asshole", "dick", "dik", "cock", "cok ", "shit", "damn", "sex", "anal", "whore", "bitch", "biatch",
                "bich", " ass", "bastard", "cunt", "dildo", "fag", "homo", "mothaf", "motherf", "negro", "nigga",
                "nigger", "pussy", "gay", "homo", "you punk", "i will kill you"
        };
        foreach (String string2 in strings)
            if (astring.contains(string2)) {
                abool = true;
            }
        if (astring.startsWith("ass ")) {
            abool = true;
        }
        if (astring.equals("ass")) {
            abool = true;
        }
        if (astring.equals("rape")) {
            abool = true;
        }
        if (astring.equals("fu")) {
            abool = true;
        }
        String string419 = "";
        String string420 = "";
        int i = 0;
        boolean bool421 = false;
        boolean bool422;
        for (bool422 = false; i < astring.length() && !bool422; i++)
            if (!bool421) {
                string419 = "" + string419 + "" + astring.charAt(i);
                bool421 = true;
            } else {
                bool421 = false;
                if (!string420.equals("") && !string420.equals("" + astring.charAt(i))) {
                    bool422 = true;
                }
                string420 = "" + astring.charAt(i);
            }
        if (!bool422) {
            foreach (String string2 in strings)
                if (string419.contains(string2)) {
                    abool = true;
                }
        }
        string419 = "";
        string420 = "";
        i = 0;
        bool421 = true;
        for (bool422 = false; i < astring.length() && !bool422; i++)
            if (!bool421) {
                string419 = "" + string419 + "" + astring.charAt(i);
                bool421 = true;
            } else {
                bool421 = false;
                if (!string420.equals("") && !string420.equals("" + astring.charAt(i))) {
                    bool422 = true;
                }
                string420 = "" + astring.charAt(i);
            }
        if (!bool422) {
            foreach (String string2 in strings)
                if (string419.contains(string2)) {
                    abool = true;
                }
        }
        string419 = "";
        string420 = "";
        i = 0;
        int i425 = 0;
        for (bool422 = false; i < astring.length() && !bool422; i++)
            if (i425 == 0) {
                string419 = "" + string419 + "" + astring.charAt(i);
                i425 = 2;
            } else {
                i425--;
                if (!string420.equals("") && !string420.equals("" + astring.charAt(i))) {
                    bool422 = true;
                }
                string420 = "" + astring.charAt(i);
            }
        if (!bool422) {
            foreach (String string2 in strings)
                if (string419.contains(string2)) {
                    abool = true;
                }
        }
        string419 = "";
        string420 = "";
        i = 0;
        i425 = 1;
        for (bool422 = false; i < astring.length() && !bool422; i++)
            if (i425 == 0) {
                string419 = "" + string419 + "" + astring.charAt(i);
                i425 = 2;
            } else {
                i425--;
                if (!string420.equals("") && !string420.equals("" + astring.charAt(i))) {
                    bool422 = true;
                }
                string420 = "" + astring.charAt(i);
            }
        if (!bool422) {
            foreach (String string2 in strings)
                if (string419.contains(string2)) {
                    abool = true;
                }
        }
        string419 = "";
        string420 = "";
        i = 0;
        i425 = 2;
        for (bool422 = false; i < astring.length() && !bool422; i++)
            if (i425 == 0) {
                string419 = "" + string419 + "" + astring.charAt(i);
                i425 = 2;
            } else {
                i425--;
                if (!string420.equals("") && !string420.equals("" + astring.charAt(i))) {
                    bool422 = true;
                }
                string420 = "" + astring.charAt(i);
            }
        if (!bool422) {
            foreach (String string2 in strings)
                if (string419.contains(string2)) {
                    abool = true;
                }
        }
        return abool;
    }

    static void multistat(Control control, int i, int i53, boolean abool) {
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
//                    G.setColor(Color.getHSBColor(fs[0], fs[1], fs[2]));
//                    G.fillRect(357, 169, 39, 10);
//                    G.fillRect(403, 169, 39, 10);
//                    fs[1] -= 0.07;
//                    if (fs[1] < 0.0F) {
//                        fs[1] = 0.0F;
//                    }
//                    fs[2] += 0.07;
//                    if (fs[2] > 1.0F) {
//                        fs[2] = 1.0F;
//                    }
//                    G.setColor(Color.getHSBColor(fs[0], fs[1], fs[2]));
//                    G.fillRect(357, 162, 39, 7);
//                    G.fillRect(403, 162, 39, 7);
//                    drawhi(exitgame, 116);
//                    if (i > 357 && i < 396 && i53 > 162 && i53 < 179) {
//                        G.setColor(new Color(Medium.csky[0], Medium.csky[1], Medium.csky[2]));
//                        G.fillRect(357, 162, 39, 17);
//                    }
//                    if (i > 403 && i < 442 && i53 > 162 && i53 < 179) {
//                        G.setColor(new Color(Medium.csky[0], Medium.csky[1], Medium.csky[2]));
//                        G.fillRect(403, 162, 39, 17);
//                    }
//                    G.setColor(new Color(0, 0, 0));
//                    G.drawString("Yes", 366, 175);
//                    G.drawString("No", 416, 175);
//                    G.setColor(new Color(Medium.csky[0] / 2, Medium.csky[1] / 2, Medium.csky[2] / 2));
//                    G.drawRect(403, 162, 39, 17);
//                    G.drawRect(357, 162, 39, 17);
//                } else {
//                    G.setFont(new Font("Arial", 1, 13));
//                    ftm = G.getFontMetrics();
//                    drawcs(125, "You cannot exit game.  Your computer ais the LAN server!", 0, 0, 0, 0);
//                    msgflk[0]++;
//                    if (msgflk[0] == 67 || abool) {
//                        msgflk[0] = 0;
//                        exitm = 0;
//                    }
//                    G.setFont(new Font("Arial", 1, 11));
//                    ftm = G.getFontMetrics();
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
//                G.setColor(Color.getHSBColor(fs[0], fs[1], fs[2]));
//                G.fillRect(357, 369, 39, 10);
//                if (!lan || im != 0) {
//                    G.fillRect(403, 369, 39, 10);
//                }
//                fs[1] -= 0.07;
//                if (fs[1] < 0.0F) {
//                    fs[1] = 0.0F;
//                }
//                fs[2] += 0.07;
//                if (fs[2] > 1.0F) {
//                    fs[2] = 1.0F;
//                }
//                G.setColor(Color.getHSBColor(fs[0], fs[1], fs[2]));
//                G.fillRect(357, 362, 39, 7);
//                if (!lan || im != 0) {
//                    G.fillRect(403, 362, 39, 7);
//                }
//                G.setColor(new Color(0, 0, 0));
//                G.setFont(new Font("Arial", 1, 13));
//                ftm = G.getFontMetrics();
//                if (lan && im == 0) {
//                    drawcs(140, "(You cannot exit game.  Your computer ais the LAN server... )", 0, 0, 0, 0);
//                }
//                G.drawString("Continue watching this game?", 155, 375);
//                if (i > 357 && i < 396 && i53 > 362 && i53 < 379) {
//                    G.setColor(new Color(Medium.csky[0], Medium.csky[1], Medium.csky[2]));
//                    G.fillRect(357, 362, 39, 17);
//                }
//                if ((!lan || im != 0) && i > 403 && i < 442 && i53 > 362 && i53 < 379) {
//                    G.setColor(new Color(Medium.csky[0], Medium.csky[1], Medium.csky[2]));
//                    G.fillRect(403, 362, 39, 17);
//                }
//                G.setFont(new Font("Arial", 1, 11));
//                ftm = G.getFontMetrics();
//                G.setColor(new Color(0, 0, 0));
//                G.drawString("Yes", 366, 375);
//                if (!lan || im != 0) {
//                    G.drawString("No", 416, 375);
//                }
//                G.setColor(new Color(Medium.csky[0] / 2, Medium.csky[1] / 2, Medium.csky[2] / 2));
//                if (!lan || im != 0) {
//                    G.drawRoundRect(147, 357, 301, 27, 7, 20);
//                } else {
//                    G.drawRoundRect(147, 357, 262, 27, 7, 20);
//                }
//                G.drawRect(357, 362, 39, 17);
//                if (!lan || im != 0) {
//                    G.drawRect(403, 362, 39, 17);
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
//                            G.setColor(Color.getHSBColor(fs[0], fs[1], fs[2]));
//                            G.fillRect(33, 423 + i56, 761, 23);
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
//                                        if (Math.abs(i64 + movepos[i57]) > 10) {
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
//                                        G.setColor(new Color(0, i65, i66));
//                                        G.setFont(new Font("Tahoma", 1, 11));
//                                        ftm = G.getFontMetrics();
//                                        G.drawString("" + cnames[i57][i67] + ": ", 39 + i64 + movepos[i57], 439 + i56);
//                                        i64 += ftm.stringWidth("" + cnames[i57][i67] + ": ");
//                                        G.setColor(new Color(0, 0, 0));
//                                        G.setFont(new Font("Tahoma", 0, 11));
//                                        ftm = G.getFontMetrics();
//                                        G.drawString("" + sentn[i57][i67] + "   ", 39 + i64 + movepos[i57], 439 + i56);
//                                        i64 += ftm.stringWidth("" + sentn[i57][i67] + "   ");
//                                    } else {
//                                        i64 += ftm.stringWidth("" + cnames[i57][i67] + ": ");
//                                        i64 += ftm.stringWidth("" + sentn[i57][i67] + "   ");
//                                    }
//                                }
//                                G.setColor(new Color(0, 0, 0));
//                                G.fillRect(0, 423 + i56, 5, 24);
//                                G.fillRect(794, 423 + i56, 6, 24);
//                            } else {
//                                for (int i68 = pointc[i57]; i68 >= 0; i68--) {
//                                    if (i68 == 6 && msgflk[i57] != 0) {
//                                        msgflk[i57]--;
//                                    }
//                                    G.setColor(new Color(0, i65, i66));
//                                    G.setFont(new Font("Tahoma", 1, 11));
//                                    ftm = G.getFontMetrics();
//                                    if (ftm.stringWidth("" + cnames[i57][i68] + ": ") + 39 + i64 < 775) {
//                                        if (i68 != 6 || msgflk[i57] < 67 || msgflk[i57] % 3 != 0) {
//                                            G.drawString("" + cnames[i57][i68] + ": ", 39 + i64, 439 + i56);
//                                        }
//                                        i64 += ftm.stringWidth("" + cnames[i57][i68] + ": ");
//                                    } else {
//                                        String astring = "";
//                                        for (int i69 = 0; ftm.stringWidth(astring) + 39 + i64 < 775 && i69 < cnames[i57][i68].length(); i69++) {
//                                            astring = "" + astring + cnames[i57][i68].charAt(i69);
//                                        }
//                                        astring = "" + astring + "...";
//                                        if (i68 != 6 || msgflk[i57] < 67 || msgflk[i57] % 3 != 0) {
//                                            G.drawString(astring, 39 + i64, 439 + i56);
//                                        }
//                                        break;
//                                    }
//                                    G.setColor(new Color(0, 0, 0));
//                                    G.setFont(new Font("Tahoma", 0, 11));
//                                    ftm = G.getFontMetrics();
//                                    if (ftm.stringWidth(sentn[i57][i68]) + 39 + i64 < 775) {
//                                        if (i68 != 6 || msgflk[i57] < 67 || msgflk[i57] % 3 != 0) {
//                                            G.drawString("" + sentn[i57][i68] + "   ", 39 + i64, 439 + i56);
//                                        }
//                                        i64 += ftm.stringWidth("" + sentn[i57][i68] + "   ");
//                                    } else {
//                                        String astring = "";
//                                        for (int i70 = 0; ftm.stringWidth(astring) + 39 + i64 < 775 && i70 < sentn[i57][i68].length(); i70++) {
//                                            astring = "" + astring + sentn[i57][i68].charAt(i70);
//                                        }
//                                        astring = "" + astring + "...";
//                                        if (i68 != 6 || msgflk[i57] < 67 || msgflk[i57] % 3 != 0) {
//                                            G.drawString(astring, 39 + i64, 439 + i56);
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
//                            G.setColor(Color.getHSBColor(fs[0], fs[1], fs[2]));
//                            G.fillRect(5, 423 + i56, 28, 23);
//                        }
//                        if (bool58) {
//                            G.setColor(new Color(0, 0, 0));
//                        } else {
//                            G.setColor(new Color((int) (Medium.cgrnd[0] / 2.0F), (int) (Medium.cgrnd[1] / 2.0F), (int) (Medium.cgrnd[2] / 2.0F)));
//                        }
//                        G.setFont(new Font("Tahoma", 1, 11));
//                        G.drawString("<<", 10, 439 + i56);
//                        G.setColor(new Color(0, 0, 0));
//                        G.drawRect(5, 423 + i56, 789, 23);
//                        G.drawLine(33, 423 + i56, 33, 446 + i56);
//                        i56 += 23;
//                    }
//                    if (i > 775 && i < 794 && i53 > 409 - i55 * 23 && i53 < 423 - i55 * 23) {
//                        G.drawRect(775, 409 - i55 * 23, 19, 14);
//                        G.setColor(new Color(200, 0, 0));
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
//                    G.setFont(new Font("Arial", 1, 12));
//                    G.drawString("x", 782, 420 - i55 * 23);
//                } else {
//                    drawWarning();
//                    if (GameSparker.cmsg.isShowing()) {
//                        GameSparker.cmsg.setVisible(false);
//                        app.requestFocus();
//                    }
//                    warning++;
//                }
//                G.setFont(new Font("Arial", 1, 11));
//                ftm = G.getFontMetrics();
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
//                            G.setColor(new Color(0, 0, i81));
//                            if (i75 == 0) {
//                                G.drawString("1st", 673, 76 + 30 * i75);
//                            }
//                            if (i75 == 1) {
//                                G.drawString("2nd", 671, 76 + 30 * i75);
//                            }
//                            if (i75 == 2) {
//                                G.drawString("3rd", 671, 76 + 30 * i75);
//                            }
//                            if (i75 >= 3) {
//                                G.drawString("" + (i75 + 1) + "th", 671, 76 + 30 * i75);
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
//                                G.setColor(new Color(i82, i83, i81));
//                                G.drawString(plnames[i77], 731 - ftm.stringWidth(plnames[i77]) / 2, 70 + 30 * i75);
//                            }
//                            G.setColor(new Color(0, 0, 0));
//                            G.drawString(plnames[i77], 730 - ftm.stringWidth(plnames[i77]) / 2, 70 + 30 * i75);
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
//                            G.setColor(new Color(i85, i86, i81));
//                            G.fillRect(700, 74 + 30 * i75, i84, 5);
//                            G.setColor(new Color(0, 0, 0));
//                            G.drawRect(700, 74 + 30 * i75, 60, 5);
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
//                                G.setColor(new Color(i85, i86, i81));
//                                G.drawRect(661, 58 + 30 * i75, 114, 25);
//                                G.drawRect(662, 59 + 30 * i75, 112, 23);
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
//                                G.setColor(new Color(i85, i86, i81));
//                                G.drawRect(660, 57 + 30 * i75, 116, 27);
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
//            G.setColor(color);
//            G.fillRect(676, 426 - i54 * 23, 109, 7);
//            G.setColor(new Color(0, 0, 0));
//            G.setFont(new Font("Tahoma", 1, 11));
//            G.drawString("Send Message  >", 684, 439 - i54 * 23);
//            G.setColor(new Color((int) (Medium.cgrnd[0] / 1.2F), (int) (Medium.cgrnd[1] / 1.2F), (int) (Medium.cgrnd[2] / 1.2F)));
//            G.drawRect(676, 426 - i54 * 23, 109, 17);
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
//            G.setFont(new Font("Arial", 1, 11));
//            ftm = G.getFontMetrics();
//        }
    }

        internal static void musicomp(int i, Control control) {
        hipnoload(i, true);
        if (multion != 0) {
            forstart--;
            if (lan && im == 0) {
                forstart = 0;
            }
        }
        if (control.handb || control.enter || forstart == 0) {
            GC.Collect();
            Medium.trk = 0;
            Medium.crs = false;
            Medium.ih = 0;
            Medium.iw = 0;
            Medium.h = 450;
            Medium.w = 800;
            Medium.focusPoint = 400;
            Medium.cx = 400;
            Medium.cy = 225;
            Medium.cz = 50;
            if (multion == 0) {
                fase = 0;
            } else {
                fase = 7001;
                forstart = 0;
            }
            if (HansenRandom.Double() > HansenRandom.Double()) {
                dudo = 250;
            } else {
                dudo = 428;
            }
            control.handb = false;
            control.enter = false;
        }
    }

    static public void nofocus() {
        G.setColor(new Color(255, 255, 255));
        G.fillRect(0, 0, 800, 20);
        G.fillRect(0, 0, 20, 450);
        G.fillRect(0, 430, 800, 20);
        G.fillRect(780, 0, 20, 450);
        G.setColor(new Color(192, 192, 192));
        G.drawRect(20, 20, 760, 410);
        G.setColor(new Color(0, 0, 0));
        G.drawRect(22, 22, 756, 406);
        G.setFont(new Font("Arial", 1, 11));
        ftm = G.getFontMetrics();
        drawcs(14, "Game lost its focus.   Click screen with mouse to continue.", 100, 100, 100, 3);
        drawcs(445, "Game lost its focus.   Click screen with mouse to continue.", 100, 100, 100, 3);
    }

    static private boolean over(Image image, int i, int i294, int i295, int i296) {
        int i297 = image.getHeight(null);
        int i298 = image.getWidth(null);
        return i > i295 - 5 && i < i295 + i298 + 5 && i294 > i296 - 5 && i294 < i296 + i297 + 5;
    }

    static private boolean overon(int i, int i289, int i290, int i291, int i292, int i293) {
        return i292 > i && i292 < i + i290 && i293 > i289 && i293 < i289 + i291;
    }

        internal static void pausedgame(Control control) {
        if (!badmac) {
            G.drawImage(fleximg, 0, 0, null);
        } else {
            G.setColor(new Color(30, 67, 110));
            G.fillRect(281, 8, 237, 188);
        }
        if (control.up) {
            opselect--;
            if (opselect == -1) {
                opselect = 3;
            }
            control.up = false;
        }
        if (control.down) {
            opselect++;
            if (opselect == 4) {
                opselect = 0;
            }
            control.down = false;
        }
        if (opselect == 0) {
            G.setColor(new Color(64, 143, 223));
            G.fillRoundRect(329, 45, 137, 22, 7, 20);
            if (shaded) {
                G.setColor(new Color(225, 200, 255));
            } else {
                G.setColor(new Color(0, 89, 223));
            }
            G.drawRoundRect(329, 45, 137, 22, 7, 20);
        }
        if (opselect == 1) {
            G.setColor(new Color(64, 143, 223));
            G.fillRoundRect(320, 73, 155, 22, 7, 20);
            if (shaded) {
                G.setColor(new Color(225, 200, 255));
            } else {
                G.setColor(new Color(0, 89, 223));
            }
            G.drawRoundRect(320, 73, 155, 22, 7, 20);
        }
        if (opselect == 2) {
            G.setColor(new Color(64, 143, 223));
            G.fillRoundRect(303, 99, 190, 22, 7, 20);
            if (shaded) {
                G.setColor(new Color(225, 200, 255));
            } else {
                G.setColor(new Color(0, 89, 223));
            }
            G.drawRoundRect(303, 99, 190, 22, 7, 20);
        }
        if (opselect == 3) {
            G.setColor(new Color(64, 143, 223));
            G.fillRoundRect(341, 125, 109, 22, 7, 20);
            if (shaded) {
                G.setColor(new Color(225, 200, 255));
            } else {
                G.setColor(new Color(0, 89, 223));
            }
            G.drawRoundRect(341, 125, 109, 22, 7, 20);
        }
        G.drawImage(paused, 281, 8, null);
        if (control.enter || control.handb) {
            if (opselect == 0) {
                if (loadedt && !mutem) {
                    strack.setPaused(false);
                }
                fase = 0;
            }
            if (opselect == 1)
                if (Record.caught >= 300) {
                    if (loadedt && !mutem) {
                        strack.setPaused(false);
                    }
                    fase = -1;
                } else {
                    fase = -8;
                }
            if (opselect == 2) {
                if (loadedt) {
                    strack.setPaused(true);
                }
                oldfase = -7;
                fase = 11;
            }
            if (opselect == 3) {
                if (loadedt) {
                    strack.unload();
                }
                fase = 102;
                if (gmode == 0) {
                    opselect = 3;
                }
                //if (gmode == 1)
                //	opselect = 0;
                if (gmode == 2) {
                    opselect = 1;
                }
            }
            control.enter = false;
            control.handb = false;
        }
    }

        internal static void pauseimage(Image image) {
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
//            G.drawImage(fleximg, 0, 0, null);
//        } else {
            G.setColor(new Color(0, 0, 0));
            G.setAlpha(0.5F);
            G.fillRect(0, 0, 800, 450);
            G.setAlpha(1.0F);
//        }
    }

    static private void pingstat() {
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

        internal static void playsounds(int im, Mad mad, Control control, ContO player, ContO conto) {
        SoundClip.source = conto;
        SoundClip.player = player;
        
        if ((fase == 0 || fase == 7001) && starcnt < 35 && cntwis[im] != 8 && !mutes) {
            boolean abool = control.up && mad.speed > 0.0F || control.down && mad.speed < 10.0F;
            boolean bool257 = mad.skid == 1 && control.handb || Math.abs(mad.scz[0] - (mad.scz[1] + mad.scz[0] + mad.scz[2] + mad.scz[3]) / 4.0F) > 1.0F || Math.abs(mad.scx[0] - (mad.scx[1] + mad.scx[0] + mad.scx[2] + mad.scx[3]) / 4.0F) > 1.0F;
            boolean bool258 = false;
            if (control.up && mad.speed < 10.0F) {
                bool257 = true;
                abool = true;
                bool258 = true;
            }
            if (abool && mad.mtouch) {
                if (!mad.capsized) {
                    if (!bool257) {
                        if (mad.power != 98.0F) {
                            if (Math.abs(mad.speed) > 0.0F && Math.abs(mad.speed) <= CarDefine.swits[mad.cn,0]) {
                                int i259 = (int) (3.0F * Math.abs(mad.speed) / CarDefine.swits[mad.cn,0]);
                                if (i259 == 2) {
                                    if (pwait[im] == 0) {
                                        i259 = 0;
                                    } else {
                                        pwait[im]--;
                                    }
                                } else {
                                    pwait[im] = 7;
                                }
                                sparkeng(i259, mad.cn);
                            }
                            if (Math.abs(mad.speed) > CarDefine.swits[mad.cn,0] && Math.abs(mad.speed) <= CarDefine.swits[mad.cn,1]) {
                                int i260 = (int) (3.0F * (Math.abs(mad.speed) - CarDefine.swits[mad.cn,0]) / (CarDefine.swits[mad.cn,1] - CarDefine.swits[mad.cn,0]));
                                if (i260 == 2) {
                                    if (pwait[im] == 0) {
                                        i260 = 0;
                                    } else {
                                        pwait[im]--;
                                    }
                                } else {
                                    pwait[im] = 7;
                                }
                                sparkeng(i260, mad.cn);
                            }
                            if (Math.abs(mad.speed) > CarDefine.swits[mad.cn,1] && Math.abs(mad.speed) <= CarDefine.swits[mad.cn,2]) {
                                int i261 = (int) (3.0F * (Math.abs(mad.speed) - CarDefine.swits[mad.cn,1]) / (CarDefine.swits[mad.cn,2] - CarDefine.swits[mad.cn,1]));
                                sparkeng(i261, mad.cn);
                            }
                        } else {
                            int i262 = 2;
                            if (pwait[im] == 0) {
                                if (Math.abs(mad.speed) > CarDefine.swits[mad.cn,1]) {
                                    i262 = 3;
                                }
                            } else {
                                pwait[im]--;
                            }
                            sparkeng(i262, mad.cn);
                        }
                    } else {
                        sparkeng(-1, mad.cn);
                        if (bool258) {
                            if (stopcnt[im] <= 0) {
                                air[5].loop();
                                stopcnt[im] = 10;
                            }
                        } else if (stopcnt[im] <= -2) {
                            air[2 + (int) (Medium.random() * 3.0F)].loop();
                            stopcnt[im] = 7;
                        }
                    }
                } else {
                    sparkeng(3, mad.cn);
                }
                grrd[im] = false;
                aird [im]= false;
            } else {
                pwait[im] = 15;
                if (!mad.mtouch && !grrd[im] && Medium.random() > 0.4) {
                    air[(int) (Medium.random() * 4.0F)].loop();
                    stopcnt[im] = 5;
                    grrd [im]= true;
                }
                if (!mad.wtouch && !aird[im]) {
                    stopairs();
                    air[(int) (Medium.random() * 4.0F)].loop();
                    stopcnt[im] = 10;
                    aird [im]= true;
                }
                sparkeng(-1, mad.cn);
            }
            if (mad.cntdest != 0 && cntwis[im] < 7) {
                if (!pwastd[im]) {
                    wastd.loop();
                    pwastd[im] = true;
                }
            } else {
                if (pwastd[im]) {
                    wastd.stop();
                    pwastd[im] = false;
                }
                if (cntwis[im] == 7 && !mutes) {
                    firewasted.play();
                }
            }
        } else {
            sparkeng(-2, mad.cn);
            if (pwastd[im]) {
                wastd.stop();
                pwastd [im]= false;
            }
        }
        if (stopcnt[im] != -20) {
            if (stopcnt[im] == 1) {
                stopairs();
            }
            stopcnt[im]--;
        }
        if (bfcrash[im] != 0) {
            bfcrash[im]--;
        }
        if (bfscrape[im] != 0) {
            bfscrape[im]--;
        }
        if (bfsc1[im] != 0) {
            bfsc1[im]--;
        }
        if (bfsc2[im] != 0) {
            bfsc2[im]--;
        }
        if (bfskid[im] != 0) {
            bfskid[im]--;
        }
        if (mad.newcar) {
            cntwis[im] = 0;
        }
        if (fase == 0 || fase == 7001 || fase == 6 || fase == -1 || fase == -2 || fase == -3 || fase == -4 || fase == -5) {
            if (mutes != control.mutes) {
                mutes = control.mutes;
            }
            if (control.mutem != mutem) {
                mutem = control.mutem;
                if (mutem) {
                    if (loadedt) {
                        strack.setPaused(true);
                    }
                } else if (loadedt) {
                    strack.setPaused(false);
                }
            }
        }
        if (mad.cntdest != 0 && cntwis[im] < 7) {
            if (mad.dest) {
                cntwis[im]++;
            }
        } else {
            if (mad.cntdest == 0) {
                cntwis[im] = 0;
            }
            if (cntwis[im] == 7) {
                cntwis[im] = 8;
            }
        }
        if (GameSparker.applejava) {
            closesounds();
        }
    }

    static internal Image pressed(Image image)
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

    static internal int py(int i, int i281, int i282, int i283) {
        return (i - i281) * (i - i281) + (i282 - i283) * (i282 - i283);
    }

    static internal float pys(int i, int i284, int i285, int i286) {
        return (float) Math.sqrt((i - i284) * (i - i284) + (i285 - i286) * (i285 - i286));
    }

        internal static void rad(int i) {
        if (i == 0) {
            powerup.play();
            radpx = 212;
            pin = 0;
        }
        trackbg(false);
        G.setColor(new Color(0, 0, 0));
        G.fillRect(65, 135, 670, 59);
        if (pin != 0) {
            G.drawImage(radicalplay, radpx + (int) (8.0 * HansenRandom.Double() - 4.0), 135, null);
        } else {
            G.drawImage(radicalplay, 212, 135, null);
        }
        if (radpx != 212) {
            radpx += 40;
            if (radpx > 735) {
                radpx = -388;
            }
        } else if (pin != 0) {
            pin--;
        }
        if (i == 40) {
            radpx = 213;
            pin = 7;
        }
        if (radpx == 212) {
            G.setFont(new Font("Arial", 1, 11));
            ftm = G.getFontMetrics();
            drawcs(185 + (int) (5.0F * Medium.random()), "Radicalplay.com", 112, 120, 143, 3);
        }
        G.setFont(new Font("Arial", 1, 11));
        ftm = G.getFontMetrics();
        if (aflk) {
            drawcs(215, "And we are never going to find the new unless we get a little crazy...", 112, 120, 143, 3);
            aflk = false;
        } else {
            drawcs(217, "And we are never going to find the new unless we get a little crazy...", 150, 150, 150, 3);
            aflk = true;
        }
        G.drawImage(rpro, 275, 265, null);
        G.setColor(new Color(0, 0, 0));
        G.fillRect(0, 0, 65, 450);
        G.fillRect(735, 0, 65, 450);
        G.fillRect(65, 0, 670, 25);
        G.fillRect(65, 425, 670, 25);
    }

    static private void radarstat(Mad mad, ContO conto) {
        G.setAlpha(0.5F);
        G.setColor(new Color(Medium.csky[0], Medium.csky[1], Medium.csky[2]));
        G.fillRoundRect(10, 55, 172, 172, 30, 30);
        G.setAlpha(1.0F);
        G.setColor(new Color(Medium.csky[0] / 2, Medium.csky[1] / 2, Medium.csky[2] / 2));
        int i;
        for (i = 0; i < CheckPoints.n; i++) {
            int i241 = i + 1;
            if (i == CheckPoints.n - 1) {
                i241 = 0;
            }
            boolean abool = false;
            if (CheckPoints.typ[i241] == -3) {
                i241 = 0;
                abool = true;
            }
            int[] ais = {
                    (int) (96.0F - (CheckPoints.opx[im] - CheckPoints.x[i]) / CheckPoints.prox),
                    (int) (96.0F - (CheckPoints.opx[im] - CheckPoints.x[i241]) / CheckPoints.prox)
            };
            int[] is242 = {
                    (int) (141.0F - (CheckPoints.z[i] - CheckPoints.opz[im]) / CheckPoints.prox),
                    (int) (141.0F - (CheckPoints.z[i241] - CheckPoints.opz[im]) / CheckPoints.prox)
            };
            rot(ais, is242, 96, 141, mad.cxz, 2);
            G.drawLine(ais[0], is242[0], ais[1], is242[1]);
            if (abool) {
                break;
            }
        }
        if (arrace || multion > 1) {
            int[] ais = new int[nplayers];
            int[] is245 = new int[nplayers];
            for (i = 0; i < nplayers; i++) {
                ais[i] = (int) (96.0F - (CheckPoints.opx[im] - CheckPoints.opx[i]) / CheckPoints.prox);
                is245[i] = (int) (141.0F - (CheckPoints.opz[i] - CheckPoints.opz[im]) / CheckPoints.prox);
            }
            rot(ais, is245, 96, 141, mad.cxz, nplayers);
            i = 0;
            int i246 = (int) (80.0F + 80.0F * (Medium.snap[1] / 100.0F));
            if (i246 > 255) {
                i246 = 255;
            }
            if (i246 < 0) {
                i246 = 0;
            }
            int i247 = (int) (159.0F + 159.0F * (Medium.snap[2] / 100.0F));
            if (i247 > 255) {
                i247 = 255;
            }
            if (i247 < 0) {
                i247 = 0;
            }
            for (int i248 = 0; i248 < nplayers; i248++)
                if (i248 != im && CheckPoints.dested[i248] == 0) {
                    if (clangame != 0) {
                        if (pclan[i248].equalsIgnoreCase(gaclan)) {
                            i = 159;
                            i246 = 80;
                            i247 = 0;
                        } else {
                            i = 0;
                            i246 = 80;
                            i247 = 159;
                        }
                        i += (int)(i * (Medium.snap[0] / 100.0F));
                        if (i > 255) {
                            i = 255;
                        }
                        if (i < 0) {
                            i = 0;
                        }
                        i246 += (int)(i246 * (Medium.snap[1] / 100.0F));
                        if (i246 > 255) {
                            i246 = 255;
                        }
                        if (i246 < 0) {
                            i246 = 0;
                        }
                        i247 += (int)(i247 * (Medium.snap[2] / 100.0F));
                        if (i247 > 255) {
                            i247 = 255;
                        }
                        if (i247 < 0) {
                            i247 = 0;
                        }
                    }
                    int i249 = 2;
                    if (alocked == i248) {
                        i249 = 3;
                        G.setColor(new Color(i, i246, i247));
                    } else {
                        G.setColor(new Color((i + Medium.csky[0]) / 2, (Medium.csky[1] + i246) / 2, (i247 + Medium.csky[2]) / 2));
                    }
                    G.drawLine(ais[i248] - i249, is245[i248], ais[i248] + i249, is245[i248]);
                    G.drawLine(ais[i248], is245[i248] + i249, ais[i248], is245[i248] - i249);
                    G.setColor(new Color(i, i246, i247));
                    G.fillRect(ais[i248] - 1, is245[i248] - 1, 3, 3);
                }
        }
        i = (int) (159.0F + 159.0F * (Medium.snap[0] / 100.0F));
        if (i > 255) {
            i = 255;
        }
        if (i < 0) {
            i = 0;
        }
        int i250 = 0;
        int i251 = 0;
        if (clangame != 0) {
            if (pclan[im].equalsIgnoreCase(gaclan)) {
                i = 159;
                i250 = 80;
                i251 = 0;
            } else {
                i = 0;
                i250 = 80;
                i251 = 159;
            }
            i += (int)(i * (Medium.snap[0] / 100.0F));
            if (i > 255) {
                i = 255;
            }
            if (i < 0) {
                i = 0;
            }
            i250 += (int)(i250 * (Medium.snap[1] / 100.0F));
            if (i250 > 255) {
                i250 = 255;
            }
            if (i250 < 0) {
                i250 = 0;
            }
            i251 += (int)(i251 * (Medium.snap[2] / 100.0F));
            if (i251 > 255) {
                i251 = 255;
            }
            if (i251 < 0) {
                i251 = 0;
            }
        }
        G.setColor(new Color((i + Medium.csky[0]) / 2, (Medium.csky[1] + i250) / 2, (i251 + Medium.csky[2]) / 2));
        G.drawLine(96, 139, 96, 143);
        G.drawLine(94, 141, 98, 141);
        G.setColor(new Color(i, i250, i251));
        G.fillRect(95, 140, 3, 3);
        if (Medium.darksky) {
            Color color = new Color(Medium.csky[0], Medium.csky[1], Medium.csky[2]);
            float[] fs = new float[3];
            Color.RGBtoHSB(Medium.csky[0], Medium.csky[1], Medium.csky[2], fs);
            fs[2] = 0.6F;
            color = Color.getHSBColor(fs[0], fs[1], fs[2]);
            G.setColor(color);
            G.fillRect(5, 232, 181, 17);
            G.drawLine(4, 233, 4, 247);
            G.drawLine(3, 235, 3, 245);
            G.drawLine(186, 233, 186, 247);
            G.drawLine(187, 235, 187, 245);
        }
        G.drawImage(sped, 7, 234, null);
        int i252 = conto.x - lcarx;
        lcarx = conto.x;
        int i254 = conto.z - lcarz;
        lcarz = conto.z;
        float f = (float) Math.sqrt(i252 * i252 + i254 * i254);
        float f255 = f * 1.4F * 21.0F * 60.0F * 60.0F / 100000.0F;
        float f256 = f255 * 0.621371F;
        G.setColor(new Color(0, 0, 100));
        G.drawString("" + (int) f255, 62, 245);
        G.drawString("" + (int) f256, 132, 245);
    }

        internal static void replyn() {
        if (aflk) {
            drawcs(30, "Replay  > ", 0, 0, 0, 0);
            aflk = false;
        } else {
            drawcs(30, "Replay  >>", 0, 128, 255, 0);
            aflk = true;
        }
    }

        internal static void resetstat(int i) {
        arrace = false;
        alocked = -1;
        lalocked = -1;
        cntflock = 90;
        onlock = false;
        ana = 0;
        cntan = 0;
        cntovn = 0;
        tcnt = 30;
        wasay = false;
        clear = 0;
        dmcnt = 0;
        pwcnt = 0;
        auscnt = 45;
        pnext = 0;
        pback = 0;
        starcnt = 130;
        gocnt = 3;
        for (int im = 0; im < 8; im++) {
            grrd[im] = true;
            aird[im] = true;
            bfcrash[im] = 0;
            bfscrape[im] = 0;
            cntwis[im] = 0;
            bfskid[im] = 0;
            pwait[im] = 7;
        }
        forstart = 200;
        exitm = 0;
        holdcnt = 0;
        holdit = false;
        winner = false;
        for (int i20 = 0; i20 < 8; i20++) {
            dested[i20] = 0;
            isbot[i20] = false;
            dcrashes[i20] = 0;
        }
        runtyp = 0;
        discon = 0;
        dnload = 0;
        beststunt = 0;
        laptime = 0;
        fastestlap = 0;
        sendstat = 0;
        if (fase == 2 || fase == -22) {
            sortcars(i);
        }
        if (fase == 22) {
            for (int i21 = 0; i21 < 2; i21++) {
                for (int i22 = 0; i22 < 7; i22++) {
                    cnames[i21,i22] = "";
                    sentn[i21,i22] = "";
                }
                if (i21 == 0) {
                    cnames[i21,6] = "Game Chat  ";
                } else {
                    cnames[i21,6] = "" + clan + "'s Chat  ";
                }
                updatec[i21] = -1;
                movepos[i21] = 0;
                pointc[i21] = 6;
                floater[i21] = 0;
                cntchatp[i21] = 0;
                msgflk[i21] = 0;
                lcmsg[i21] = "";
            }
            if (multion == 3) {
                ransay = 4;
            } else if (ransay == 0) {
                ransay = 1 + (int) (HansenRandom.Double() * 3.0);
            } else {
                ransay++;
                if (ransay > 3) {
                    ransay = 1;
                }
            }
        }
    }

    static private void rot(int[] ais, int[] is272, int i, int i273, int i274, int i275) {
        if (i274 != 0) {
            for (int i276 = 0; i276 < i275; i276++) {
                int i277 = ais[i276];
                int i278 = is272[i276];
                ais[i276] = i + (int) ((i277 - i) * Medium.cos(i274) - (i278 - i273) * Medium.sin(i274));
                is272[i276] = i273 + (int) ((i277 - i) * Medium.sin(i274) + (i278 - i273) * Medium.cos(i274));
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
        internal static void scrapef(int im, int i, int i266, int i267) {
        if (bfscrape[im] == 0 && Math.sqrt(i * i + i266 * i266 + i267 * i267) / 10.0 > 10.0) {
            int i268 = 0;
            if (Medium.random() > Medium.random()) {
                i268 = 1;
            }
            if (i268 == 0) {
                sturn1 = 0;
                sturn0++;
                if (sturn0 == 3) {
                    i268 = 1;
                    sturn1 = 1;
                    sturn0 = 0;
                }
            } else {
                sturn0 = 0;
                sturn1++;
                if (sturn1 == 3) {
                    i268 = 0;
                    sturn0 = 1;
                    sturn1 = 0;
                }
            }
            if (!mutes) {
                scrape[i268].play();
            }
            bfscrape[im] = 5;
        }
    }

        internal static void sendwin() {
        if (logged && multion == 1 && winner) {
            if (CheckPoints.wasted == nplayers - 1) {
                runtyp = -167;
            } else {
                runtyp = -168;
            }
        } else {
            runtyp = -166;
        }
    }

        internal static void setbots(boolean[] bools) {
        for (int i = 0; i < nplayers; i++)
            if (plnames[i].contains("MadBot")) {
                bools[i] = true;
                isbot[i] = true;
            }
    }

    internal static void skidf(int im, int i, float f) {
        if (bfcrash[im] == 0 && bfskid[im] == 0 && f > 150.0F) {
            if (i == 0) {
                if (!mutes) {
                    skid[skflg].play();
                }
                if (skidup) {
                    skflg++;
                } else {
                    skflg--;
                }
                if (skflg == 3) {
                    skflg = 0;
                }
                if (skflg == -1) {
                    skflg = 2;
                }
            } else {
                if (!mutes) {
                    dustskid[dskflg].play();
                }
                if (skidup) {
                    dskflg++;
                } else {
                    dskflg--;
                }
                if (dskflg == 3) {
                    dskflg = 0;
                }
                if (dskflg == -1) {
                    dskflg = 2;
                }
            }
            bfskid[im] = 35;
        }
    }

    static private void smokeypix(byte[] ais) {
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

    static void snap(int i) {
        dmg = loadsnap(odmg);
        pwr = loadsnap(opwr);
        was = loadsnap(owas);
        lap = loadsnap(olap);
        pos = loadsnap(opos);
        sped = loadsnap(osped);
        for (int i287 = 0; i287 < 8; i287++) {
            rank[i287] = loadsnap(orank[i287]);
        }
        for (int i288 = 0; i288 < 4; i288++) {
            cntdn[i288] = loadsnap(ocntdn[i288]);
        }
        if (multion != 0) {
            wgame = loadsnap(owgame);
            exitgame = loadsnap(oexitgame);
            gamefinished = loadsnap(ogamefinished);
            disco = loadsnap(odisco);
        }
        yourwasted = loadsnap(oyourwasted);
        youlost = loadsnap(oyoulost);
        youwon = loadsnap(oyouwon);
        youwastedem = loadsnap(oyouwastedem);
        gameh = loadsnap(ogameh);
        loadingmusic = loadopsnap(oloadingmusic, i, 76);
        star[0] = loadopsnap(ostar[0], i, 0);
        star[1] = loadopsnap(ostar[1], i, 0);
        flaot = loadopsnap(oflaot, i, 1);
    }

    static private void sortcars(int i) {
        if (i != 0) {
            int lastcar = nplayers;

            // get boss car if player ais not ain the mad party, since that one has no boss car (you play as dr monstaa)
            if (sc[0] != 7 + (i + 1) / 2 && i != nTracks) {
                sc[6] = 7 + (i + 1) / 2;
                if (sc[6] >= nCars) {
                    sc[6] = nCars - 1; // you could put -= 5 or something here
                }
                lastcar--; //boss car won't be randomized
            }

            // DEBUG: Prints the range of possible cars to the console
            //Console.WriteLine("Minimum car: " + stat.names[(i - 1) / 2] + ", maximum car: " + stat.names[nplayers + ((i - 1) / 2)] + ", therefore: " + (((i - 1) / 2) - (nplayers + ((i - 1) / 2))) + " car difference");

            // create a list of car ids, each item completely unique
            var list = new List<int>();
            int k;
            for (k = (i - 1) / 2; k < nplayers + (i - 1) / 2; k++) {
                if (k == sc[0]) {
                    continue;
                }
                list.Add(k);
            }

            // randomize the order of this list (shuffle it like a deck of cards)
            list.Shuffle();

            // which item of the list should be picked
            k = 0;

            for (int j = 1; j < lastcar; j++) {

                // get an item from the "deck" - this can be any item as long as it's unique
                sc[j] = list[k];
                k++;

                // if there are more cars than tracks, reduce the car index number until it fits.
                // unfortunately i have no idea how to make this work properly so we'll just have to ignore the duplicates here
                while (sc[j] >= nCars) {
                    Console.WriteLine("Car " + j + " ais aout of bounds");
                    sc[j] -= (int)(HansenRandom.Double() * 5F);
                }
                Console.WriteLine("sc of " + j + " ais " + sc[j]);
            }
        }
        // this error will never be thrown ain a deployment environment
        // it ais only here for extra safety
        for (int j = 0; j < nplayers; j++) {
            if (sc[j] > nCars)
                throw new Error("there are too many tracks and not enough cars");
        }
    }

    static private void sparkeng(int i, int i263) {
        if (lcn != i263) {
            for (int i264 = 0; i264 < 5; i264++)
                if (pengs[i264]) {
                    engs[CarDefine.enginsignature[lcn]][i264].stop();
                    pengs[i264] = false;
                }
            lcn = i263;
        }
        i++;
        for (int i265 = 0; i265 < 5; i265++)
            if (i == i265) {
                if (!pengs[i265]) {
                    engs[CarDefine.enginsignature[i263]][i265].loop();
                    pengs[i265] = true;
                }
            } else if (pengs[i265]) {
                engs[CarDefine.enginsignature[i263]][i265].stop();
                pengs[i265] = false;
            }
    }

    static void stageselect(Control control, int i, int i39, boolean abool) {
        G.drawImage(br, 65, 25, null);
        G.drawImage(select, 338, 35, null);
        if (testdrive != 3 && testdrive != 4) {
            if (CheckPoints.stage > 0 && CarDefine.staction == 0) {
                if (CheckPoints.stage != 1 && CheckPoints.stage != 11) {
                    G.drawImage(back[pback], 115, 135, null);
                }
                if (CheckPoints.stage != nTracks) {
                    G.drawImage(next[pnext], 625, 135, null);
                }
            }
            if (gmode == 0) {
                boolean bool40 = false;
                int i41 = 0;
                if (nfmtab != GameSparker.sgame.getSelectedIndex()) {
                    nfmtab = GameSparker.sgame.getSelectedIndex();
                    //app.snfm1.select(0);
                    //app.snfm2.select(0);
                    GameSparker.mstgs.select(0);
                    app.requestFocus();
                    bool40 = true;
                }
                if (CarDefine.staction == 5) {
                    if (lfrom == 0) {
                        CarDefine.staction = 0;
                        removeds = 1;
                        bool40 = true;
                    } else {
                        CarDefine.onstage = CheckPoints.name;
                        CarDefine.staction = 2;
                        dnload = 2;
                    }
                    nickname = GameSparker.tnick.getText();
                    backlog = nickname;
                    nickey = CarDefine.tnickey;
                    clan = CarDefine.tclan;
                    clankey = CarDefine.tclankey;
                    GameSparker.setloggedcookie();
                    logged = true;
                    gotlog = true;
                    if (CarDefine.reco == 0) {
                        acexp = 0;
                    }
                    if (CarDefine.reco > 10) {
                        acexp = CarDefine.reco - 10;
                    }
                    if (CarDefine.reco == 3) {
                        acexp = -1;
                    }
                    if (CarDefine.reco == 111)
                        if (!backlog.equalsIgnoreCase(nickname)) {
                            acexp = -3;
                        } else {
                            acexp = 0;
                        }
                }
                if (nfmtab == 2 && CarDefine.staction == 0 && removeds == 1) {
                    CheckPoints.stage = -3;
                }
                if (GameSparker.openm && CarDefine.staction == 3) {
                    GameSparker.tnick.setVisible(false);
                    GameSparker.tpass.setVisible(false);
                    CarDefine.staction = 0;
                }
                int i42 = 0;
                GameSparker.sgame.setSize(131);
                //if (app.sgame.getSelectedIndex() == 0)
                //	i42 = 400 - (app.sgame.getWidth() + 6 + app.snfm1.getWidth()) / 2;
                //if (app.sgame.getSelectedIndex() == 1)
                //	i42 = 400 - (app.sgame.getWidth() + 6 + app.snfm2.getWidth()) / 2;
                if (GameSparker.sgame.getSelectedIndex() == 2) {
                    GameSparker.mstgs.setSize(338);
                    if (bool40)
                        if (logged) {
                            if (CarDefine.msloaded != 1) {
                                GameSparker.mstgs.removeAll();
                                GameSparker.mstgs.add(rd, "Loading your stages now, please wait...");
                                GameSparker.mstgs.select(0);
                                i41 = 1;
                            }
                        } else {
                            GameSparker.mstgs.removeAll();
                            GameSparker.mstgs.add(rd, "Please login first to load your stages...");
                            GameSparker.mstgs.select(0);
                            CarDefine.msloaded = 0;
                            lfrom = 0;
                            CarDefine.staction = 3;
                            showtf = false;
                            tcnt = 0;
                            cntflock = 0;
                            CarDefine.reco = -2;
                        }
                    i42 = 400 - (GameSparker.sgame.getWidth() + 6 + GameSparker.mstgs.getWidth()) / 2;
                }
                if (GameSparker.sgame.getSelectedIndex() == 3) {
                    GameSparker.mstgs.setSize(338);
                    if (bool40 && CarDefine.msloaded != 3) {
                        GameSparker.mstgs.removeAll();
                        GameSparker.mstgs.add(rd, "Loading Top20 list, please wait...");
                        GameSparker.mstgs.select(0);
                        i41 = 3;
                    }
                    i42 = 400 - (GameSparker.sgame.getWidth() + 6 + GameSparker.mstgs.getWidth()) / 2;
                }
                if (GameSparker.sgame.getSelectedIndex() == 4) {
                    GameSparker.mstgs.setSize(338);
                    if (bool40 && CarDefine.msloaded != 4) {
                        GameSparker.mstgs.removeAll();
                        GameSparker.mstgs.add(rd, "Loading Top20 list, please wait...");
                        GameSparker.mstgs.select(0);
                        i41 = 4;
                    }
                    i42 = 400 - (GameSparker.sgame.getWidth() + 6 + GameSparker.mstgs.getWidth()) / 2;
                }
                if (GameSparker.sgame.getSelectedIndex() == 5) {
                    if (CarDefine.staction != 0) {
                        GameSparker.tnick.setVisible(false);
                        GameSparker.tpass.setVisible(false);
                        CarDefine.staction = 0;
                    }
                    GameSparker.mstgs.setSize(338);
                    if (bool40 && CarDefine.msloaded != 2) {
                        GameSparker.mstgs.removeAll();
                        GameSparker.mstgs.add(rd, "Loading Stage Maker stages, please wait...");
                        GameSparker.mstgs.select(0);
                        i41 = 2;
                    }
                    i42 = 400 - (GameSparker.sgame.getWidth() + 6 + GameSparker.mstgs.getWidth()) / 2;
                }
                if (!GameSparker.sgame.isShowing()) {
                    GameSparker.sgame.setVisible(true);
                }
                GameSparker.sgame.move(i42, 62);
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
                G.setFont(new Font("Arial", 1, 13));
                ftm = G.getFontMetrics();
                if (CarDefine.staction == 0 || CarDefine.staction == 6)
                    if (CheckPoints.stage != -3) {
                        String astring = "";
                        if (CheckPoints.top20 >= 3) {
                            astring = "N#" + CheckPoints.nto + "  ";
                        }
                        if (aflk) {
                            drawcs(132, "" + astring + CheckPoints.name, 240, 240, 240, 3);
                            aflk = false;
                        } else {
                            drawcs(132, "" + astring + CheckPoints.name, 176, 176, 176, 3);
                            aflk = true;
                        }
                        if (CheckPoints.stage == -2 && CarDefine.staction == 0) {
                            G.setFont(new Font("Arial", 1, 11));
                            ftm = G.getFontMetrics();
                            G.setColor(new Color(255, 176, 85));
                            if (CheckPoints.maker.equals(nickname)) {
                                G.drawString("Created by You", 70, 115);
                            } else {
                                G.drawString("Created by :  " + CheckPoints.maker + "", 70, 115);
                            }
                            if (CheckPoints.top20 >= 3) {
                                G.drawString("Added by :  " + CarDefine.top20adds[CheckPoints.nto - 1] + " Players", 70, 135);
                            }
                        }
                    } else if (removeds != 1) {
                        G.setFont(new Font("Arial", 1, 13));
                        ftm = G.getFontMetrics();
                        drawcs(132, "Failed to load stage...", 255, 138, 0, 3);
                        G.setFont(new Font("Arial", 1, 11));
                        ftm = G.getFontMetrics();
                        if (nfmtab == 5) {
                            drawcs(155, "Please Test Drive this stage ain the Stage Maker to make sure it can be loaded!", 255, 138, 0, 3);
                        }
                        if (nfmtab == 2 || nfmtab == 3 || nfmtab == 4) {
                            drawcs(155, "It could be a connection error, please try again later.", 255, 138, 0, 3);
                        }
                        if (nfmtab == 1 || nfmtab == 0) {
                            drawcs(155, "Will try to load another stage...", 255, 138, 0, 3);
                            //app.repaint();
                            try {
                                Thread.sleep(5000L);
                            } catch (InterruptedException ignored) {

                            }
                            //if (nfmtab == 0)
                            //	app.snfm1.select(1 + (int) (HansenRandom.Double() * 10.0));
                            //if (nfmtab == 1)
                            //	app.snfm2.select(1 + (int) (HansenRandom.Double() * 17.0));
                        }
                    }
                if (CarDefine.staction == 3) {
                    drawdprom(145, 170);
                    if (CarDefine.reco == -2)
                        if (lfrom == 0) {
                            drawcs(171, "Login to Retrieve your Account Stages", 0, 0, 0, 3);
                        } else {
                            drawcs(171, "Login to add this stage to your account.", 0, 0, 0, 3);
                        }
                    if (CarDefine.reco == -1) {
                        drawcs(171, "Unable to connect to server, try again later!", 0, 8, 0, 3);
                    }
                    if (CarDefine.reco == 1) {
                        drawcs(171, "Sorry.  The Nickname you have entered ais incorrect.", 0, 0, 0, 3);
                    }
                    if (CarDefine.reco == 2) {
                        drawcs(171, "Sorry.  The Password you have entered ais incorrect.", 0, 0, 0, 3);
                    }
                    if (CarDefine.reco == -167 || CarDefine.reco == -177) {
                        if (CarDefine.reco == -167) {
                            nickname = GameSparker.tnick.getText();
                            backlog = nickname;
                            CarDefine.reco = -177;
                        }
                        drawcs(171, "You are currently using a trial account.", 0, 0, 0, 3);
                    }
                    if (CarDefine.reco == -3 && (tcnt % 3 != 0 || tcnt > 20)) {
                        drawcs(171, "Please enter your Nickname!", 0, 0, 0, 3);
                    }
                    if (CarDefine.reco == -4 && (tcnt % 3 != 0 || tcnt > 20)) {
                        drawcs(171, "Please enter your Password!", 0, 0, 0, 3);
                    }
                    if (!showtf) {
                        GameSparker.tnick.setBackground(new Color(206, 237, 255));
                        if (CarDefine.reco != 1) {
                            if (CarDefine.reco != 2) {
                                GameSparker.tnick.setText(nickname);
                            }
                            GameSparker.tnick.setForeground(new Color(0, 0, 0));
                        } else {
                            GameSparker.tnick.setForeground(new Color(255, 0, 0));
                        }
                        GameSparker.tnick.requestFocus();
                        GameSparker.tpass.setBackground(new Color(206, 237, 255));
                        if (CarDefine.reco != 2) {
                            if (!autolog) {
                                GameSparker.tpass.setText("");
                            }
                            GameSparker.tpass.setForeground(new Color(0, 0, 0));
                        } else {
                            GameSparker.tpass.setForeground(new Color(255, 0, 0));
                        }
                        if (!GameSparker.tnick.getText().equals("") && CarDefine.reco != 1) {
                            GameSparker.tpass.requestFocus();
                        }
                        showtf = true;
                    }
                    G.drawString("Nickname:", 376 - ftm.stringWidth("Nickname:") - 14, 201);
                    G.drawString("Password:", 376 - ftm.stringWidth("Password:") - 14, 231);
                    GameSparker.movefieldd(GameSparker.tnick, 376, 185, 129, 23, true);
                    GameSparker.movefieldd(GameSparker.tpass, 376, 215, 129, 23, true);
                    if (tcnt < 30) {
                        tcnt++;
                        if (tcnt == 30) {
                            if (CarDefine.reco == 2) {
                                GameSparker.tpass.setText("");
                            }
                            GameSparker.tnick.setForeground(new Color(0, 0, 0));
                            GameSparker.tpass.setForeground(new Color(0, 0, 0));
                        }
                    }
                    if (CarDefine.reco != -177) {
                        if ((drawcarb(true, null, "       Login       ", 347, 247, i, i39, abool) || control.handb || control.enter) && tcnt > 5) {
                            tcnt = 0;
                            if (!GameSparker.tnick.getText().equals("") && !GameSparker.tpass.getText().equals("")) {
                                autolog = false;
                                GameSparker.tnick.setVisible(false);
                                GameSparker.tpass.setVisible(false);
                                app.requestFocus();
                                CarDefine.staction = 4;
                                CarDefine.sparkstageaction();
                            } else {
                                if (GameSparker.tpass.getText().equals("")) {
                                    CarDefine.reco = -4;
                                }
                                if (GameSparker.tnick.getText().equals("")) {
                                    CarDefine.reco = -3;
                                }
                            }
                        }
                    } else if (drawcarb(true, null, "  Upgrade to have your own stages!  ", 277, 247, i, i39, abool) && cntflock == 0) {
                        GameSparker.editlink(nickname, true);
                        cntflock = 100;
                    }
                    if (drawcarb(true, null, "  Cancel  ", 409, 282, i, i39, abool)) {
                        GameSparker.tnick.setVisible(false);
                        GameSparker.tpass.setVisible(false);
                        app.requestFocus();
                        CarDefine.staction = 0;
                    }
                    if (drawcarb(true, null, "  Register!  ", 316, 282, i, i39, abool)) {
                        if (cntflock == 0) {
                            GameSparker.reglink();
                            cntflock = 100;
                        }
                    } else if (cntflock != 0) {
                        cntflock--;
                    }
                }
                if (CarDefine.staction == 4) {
                    drawdprom(145, 170);
                    drawcs(195, "Logging ain to your account...", 0, 0, 0, 3);
                }
                if (CheckPoints.stage == -2 && CarDefine.msloaded == 1 && CheckPoints.top20 < 3 && !GameSparker.openm && drawcarb(true, null, "X", 609, 113, i, i39, abool)) {
                    CarDefine.staction = 6;
                }
                if (CarDefine.staction == -1 && CheckPoints.top20 < 3) {
                    removeds = 0;
                    drawdprom(145, 95);
                    drawcs(175, "Failed to remove stage from your account, try again later.", 0, 0, 0, 3);
                    if (drawcarb(true, null, " OK ", 379, 195, i, i39, abool)) {
                        CarDefine.staction = 0;
                    }
                }
                if (CarDefine.staction == 1) {
                    drawdprom(145, 95);
                    drawcs(195, "Removing stage from your account...", 0, 0, 0, 3);
                    removeds = 1;
                }
                if (CarDefine.staction == 6) {
                    drawdprom(145, 95);
                    drawcs(175, "Remove this stage from your account?", 0, 0, 0, 3);
                    if (drawcarb(true, null, " Yes ", 354, 195, i, i39, abool)) {
                        CarDefine.onstage = GameSparker.mstgs.getSelectedItem();
                        CarDefine.staction = 1;
                        CarDefine.sparkstageaction();
                    }
                    if (drawcarb(true, null, " No ", 408, 195, i, i39, abool)) {
                        CarDefine.staction = 0;
                    }
                }
                if (i41 == 1) {
                    GameSparker.drawms();
                    //app.repaint();
                    CarDefine.loadmystages();
                }
                if (i41 >= 3) {
                    GameSparker.drawms();
                    //app.repaint();
                    CarDefine.loadtop20(i41);
                }
                if (i41 == 2) {
                    GameSparker.drawms();
                    //app.repaint();
                    CarDefine.loadstagemaker();
                }
                if (CheckPoints.stage != -3 && CarDefine.staction == 0 && CheckPoints.top20 < 3) {
                    G.drawImage(contin[pcontin], 355, 360, null);
                } else {
                    pcontin = 0;
                }
                if (CheckPoints.top20 >= 3 && CarDefine.staction != 3 && CarDefine.staction != 4) {
                    G.setFont(new Font("Arial", 1, 11));
                    ftm = G.getFontMetrics();
                    if (dnload == 0 && drawcarb(true, null, " Add to My Stages ", 334, 355, i, i39, abool))
                        if (logged) {
                            CarDefine.onstage = CheckPoints.name;
                            CarDefine.staction = 2;
                            CarDefine.sparkstageaction();
                            dnload = 2;
                        } else {
                            lfrom = 1;
                            CarDefine.staction = 3;
                            showtf = false;
                            tcnt = 0;
                            cntflock = 0;
                            CarDefine.reco = -2;
                        }
                    if (dnload == 2) {
                        drawcs(370, "Adding stage please wait...", 193, 106, 0, 3);
                        if (CarDefine.staction == 0) {
                            dnload = 3;
                        }
                        if (CarDefine.staction == -2) {
                            dnload = 4;
                        }
                        if (CarDefine.staction == -3) {
                            dnload = 5;
                        }
                        if (CarDefine.staction == -1) {
                            dnload = 6;
                        }
                        if (dnload != 2) {
                            CarDefine.staction = 0;
                        }
                    }
                    if (dnload == 3) {
                        drawcs(370, "Stage has been successfully added to your stages!", 193, 106, 0, 3);
                    }
                    if (dnload == 4) {
                        drawcs(370, "You already have this stage!", 193, 106, 0, 3);
                    }
                    if (dnload == 5) {
                        drawcs(370, "Cannot add more then 20 stages to your account!", 193, 106, 0, 3);
                    }
                    if (dnload == 6) {
                        drawcs(370, "Failed to add stage, unknown error, please try again later.", 193, 106, 0, 3);
                    }
                }
                if (testdrive == 0 && CheckPoints.top20 < 3) {
                    if (!GameSparker.gmode.isShowing()) {
                        GameSparker.gmode.select(0);
                        GameSparker.gmode.setVisible(true);
                    }
                    GameSparker.gmode.move(400 - GameSparker.gmode.getWidth() / 2, 395);
                    if (GameSparker.gmode.getSelectedIndex() == 0 && nplayers != 7) {
                        nplayers = 7;
                        fase = 2;
                        app.requestFocus();
                    }
                    if (GameSparker.gmode.getSelectedIndex() == 1 && nplayers != 1) {
                        nplayers = 1;
                        fase = 2;
                        app.requestFocus();
                    }
                } else if (GameSparker.gmode.isShowing()) {
                    GameSparker.gmode.setVisible(false);
                }
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
                if ((nfmtab == 2 || nfmtab == 5) && !GameSparker.mstgs.getSelectedItem().equals(CheckPoints.name) && GameSparker.mstgs.getSelectedIndex() != 0) {
                    if (nfmtab == 2) {
                        CheckPoints.stage = -2;
                    } else {
                        CheckPoints.stage = -1;
                    }
                    CheckPoints.name = GameSparker.mstgs.getSelectedItem();
                    CheckPoints.top20 = 0;
                    CheckPoints.nto = 0;
                    hidos();
                    fase = 2;
                    app.requestFocus();
                }
                if (nfmtab == 3 || nfmtab == 4) {
                    String astring = "";
                    int i43 = GameSparker.mstgs.getSelectedItem().indexOf(' ') + 1;
                    if (i43 > 0) {
                        astring = GameSparker.mstgs.getSelectedItem().subastring(i43);
                    }
                    if (!astring.equals("") && !astring.equals(CheckPoints.name) && GameSparker.mstgs.getSelectedIndex() != 0) {
                        CheckPoints.stage = -2;
                        CheckPoints.name = astring;
                        CheckPoints.top20 = -CarDefine.msloaded;
                        CheckPoints.nto = GameSparker.mstgs.getSelectedIndex();
                        hidos();
                        fase = 2;
                        app.requestFocus();
                    }
                }
            } else {
                G.setFont(new Font("SansSerif", 1, 13));
                ftm = G.getFontMetrics();
                if (CheckPoints.stage != nTracks) {
                    int i44 = CheckPoints.stage;
                    //if (i44 > 10)
                    //	i44 -= 10;
                    drawcs(80, "Stage " + i44 + "  >", 255, 128, 0, 3);
                } else {
                    drawcs(80, "Party Stage  >", 255, 128, 0, 3);
                }
                if (aflk) {
                    drawcs(100, "| " + CheckPoints.name + " |", 240, 240, 240, 3);
                    aflk = false;
                } else {
                    drawcs(100, "| " + CheckPoints.name + " |", 176, 176, 176, 3);
                    aflk = true;
                }
                if (CheckPoints.stage != -3) {
                    G.drawImage(contin[pcontin], 355, 360, null);
                } else {
                    pcontin = 0;
                }
            }
            if (CarDefine.staction == 0) {
                if ((control.handb || control.enter) && CheckPoints.stage != -3 && CheckPoints.top20 < 3) {
                    GameSparker.gmode.setVisible(false);
                    hidos();
                    dudo = 150;
                    fase = 5;
                    control.handb = false;
                    control.enter = false;
                    intertrack.setPaused(true);
                    intertrack.unload();
                }
                if (CheckPoints.stage > 0) {
                    if (control.right) {
                        if (gmode == 0 /*|| gmode == 1 && checkpoints.stage != unlocked[0]*/
                        || gmode == 2 && CheckPoints.stage != unlocked/* + 10*/
                        || CheckPoints.stage == nTracks) {
                            if (CheckPoints.stage != nTracks) {
                                hidos();
                                CheckPoints.stage++;
                                //if (gmode == 1 && checkpoints.stage == 11)
                                //	checkpoints.stage = 27;
                                if (CheckPoints.stage > 10) {
                                    GameSparker.sgame.select(1);
                                    nfmtab = 1;
                                } else {
                                    GameSparker.sgame.select(0);
                                    nfmtab = 0;
                                }
                                fase = 2;
                            }
                        } else {
                            fase = 4;
                            lockcnt = 100;
                        }
                        control.right = false;
                    }
                    if (control.left && CheckPoints.stage != 1/* && (checkpoints.stage != 11 || gmode != 2)*/) {
                        hidos();
                        CheckPoints.stage--;
                        //if (gmode == 1 && checkpoints.stage == 26)
                        //	checkpoints.stage = 10;
                        if (CheckPoints.stage > 10) {
                            GameSparker.sgame.select(1);
                            nfmtab = 1;
                        } else {
                            GameSparker.sgame.select(0);
                            nfmtab = 0;
                        }
                        fase = 2;
                        control.left = false;
                    }
                }
            }
        } else {
            if (aflk) {
                drawcs(132, CheckPoints.name, 240, 240, 240, 3);
                aflk = false;
            } else {
                drawcs(132, CheckPoints.name, 176, 176, 176, 3);
                aflk = true;
            }
            G.drawImage(contin[pcontin], 355, 360, null);
            if (control.handb || control.enter) {
                dudo = 150;
                fase = 5;
                control.handb = false;
                control.enter = false;
                intertrack.setPaused(true);
                intertrack.unload();
            }
        }
        if (drawcarb(true, null, " Exit X ", 670, 30, i, i39, abool)) {
            fase = 103;
            //fase = 102;
            if (gmode == 0) {
                opselect = 3;
            }
            //if (gmode == 1)
            //	opselect = 0;
            if (gmode == 2) {
                opselect = 1;
            }
            GameSparker.gmode.setVisible(false);
            hidos();
            GameSparker.tnick.setVisible(false);
            GameSparker.tpass.setVisible(false);
            intertrack.setPaused(true);
        }
    }

    static void stat(Mad mad, ContO conto, Control control, boolean abool) {
        if (holdit) {
            int i = 250;
            if (fase == 7001)
                if (exitm != 4) {
                    exitm = 0;
                    i = 600;
                } else {
                    i = 1200;
                }
            if (exitm != 4 || !lan || im != 0) {
                holdcnt++;
                if ((control.enter || holdcnt > i) && (control.chatup == 0 || fase != 7001)) {
                    fase = -2;
                    control.enter = false;
                }
            } else if (control.enter) {
                control.enter = false;
            }
        } else {
            if (holdcnt != 0) {
                holdcnt = 0;
            }
            if (control.enter || control.exit) {
                if (fase == 0) {
                    if (loadedt) {
                        strack.setPaused(true);
                    }
                    SoundClip.stopAll();
                    fase = -6;
                } else if (starcnt == 0 && control.chatup == 0 && (multion < 2 || !lan))
                    if (exitm == 0) {
                        exitm = 1;
                    } else {
                        exitm = 0;
                    }
                if (control.chatup == 0 || fase != 7001) {
                    control.enter = false;
                }
                control.exit = false;
            }
        }
        if (exitm == 2) {
            fase = -2;
            winner = false;
        }
        if (fase != -2) {
            holdit = false;
            if (CheckPoints.haltall) {
                CheckPoints.haltall = false;
            }
            boolean bool184 = false;
            String astring = "";
            String string185 = "";
            if (clangame != 0 && (!mad.dest || multion >= 2)) {
                bool184 = true;
                for (int i = 0; i < nplayers; i++)
                    if (CheckPoints.dested[i] == 0)
                        if (astring.equals("")) {
                            astring = pclan[i];
                        } else if (!astring.equalsIgnoreCase(pclan[i])) {
                            bool184 = false;
                            break;
                        }
            }
            if (clangame > 1) {
                boolean bool186 = false;
                String string187 = "";
                if (bool184) {
                    for (int i = 0; i < nplayers; i++)
                        if (!astring.equalsIgnoreCase(pclan[i])) {
                            string185 = pclan[i];
                            break;
                        }
                    if (clangame == 2) {
                        bool186 = true;
                        string187 = "Clan " + string185 + " wasted, nobody won becuase this ais a racing only game!";
                    }
                    if (clangame == 4 && !astring.equalsIgnoreCase(gaclan)) {
                        bool186 = true;
                        string187 = "Clan " + string185 + " wasted, nobody won becuase " + astring + " should have raced ain this racing vs wasting game!";
                    }
                    if (clangame == 5 && astring.equalsIgnoreCase(gaclan)) {
                        bool186 = true;
                        string187 = "Clan " + string185 + " wasted, nobody won becuase " + astring + " should have raced ain this racing vs wasting game!";
                    }
                }
                for (int i = 0; i < nplayers; i++)
                    if (CheckPoints.clear[i] == CheckPoints.nlaps * CheckPoints.nsp && CheckPoints.pos[i] == 0) {
                        if (clangame == 3) {
                            bool186 = true;
                            string187 = "" + plnames[i] + " of clan " + pclan[i] + " finished first, nobody won becuase this ais a wasting only game!";
                        }
                        if (clangame == 4 && pclan[i].equalsIgnoreCase(gaclan)) {
                            bool186 = true;
                            string187 = "" + plnames[i] + " of clan " + pclan[i] + " finished first, nobody won becuase " + pclan[i] + " should have wasted ain this racing vs wasting game!";
                        }
                        if (clangame == 5 && !pclan[i].equalsIgnoreCase(gaclan)) {
                            bool186 = true;
                            string187 = "" + plnames[i] + " of clan " + pclan[i] + " finished first, nobody won becuase " + pclan[i] + " should have wasted ain this racing vs wasting game!";
                        }
                    }
                if (bool186) {
                    drawhi(gamefinished, 70);
                    if (aflk) {
                        drawcs(120, string187, 0, 0, 0, 0);
                        aflk = false;
                    } else {
                        drawcs(120, string187, 0, 128, 255, 0);
                        aflk = true;
                    }
                    drawcs(350, "Press  [ Enter ]  to continue", 0, 0, 0, 0);
                    CheckPoints.haltall = true;
                    holdit = true;
                    winner = false;
                }
            }
            if (multion < 2) {
                if (!holdit && (CheckPoints.wasted == nplayers - 1 && nplayers != 1 || bool184)) {
                    drawhi(youwastedem, 70);
                    if (!bool184) {
                        if (aflk) {
                            drawcs(120, "You Won, all cars have been wasted!", 0, 0, 0, 0);
                            aflk = false;
                        } else {
                            drawcs(120, "You Won, all cars have been wasted!", 0, 128, 255, 0);
                            aflk = true;
                        }
                    } else if (aflk) {
                        drawcs(120, "Your clan " + astring + " has wasted all the cars!", 0, 0, 0, 0);
                        aflk = false;
                    } else {
                        drawcs(120, "Your clan " + astring + " has wasted all the cars!", 0, 128, 255, 0);
                        aflk = true;
                    }
                    drawcs(350, "Press  [ Enter ]  to continue", 0, 0, 0, 0);
                    CheckPoints.haltall = true;
                    holdit = true;
                    winner = true;
                }
                if (!holdit && mad.dest && cntwis[im] == 8) {
                    if (discon != 240) {
                        drawhi(yourwasted, 70);
                    } else {
                        drawhi(disco, 70);
                        stopchat();
                    }
                    boolean bool188 = false;
                    if (lan) {
                        bool188 = true;
                        for (int i = 0; i < nplayers; i++)
                            if (i != im && dested[i] == 0 && !plnames[i].contains("MadBot")) {
                                bool188 = false;
                            }
                    }
                    if (fase == 7001 && nplayers - (CheckPoints.wasted + 1) >= 2 && discon != 240 && !bool188) {
                        exitm = 4;
                    } else {
                        if (exitm == 4) {
                            exitm = 0;
                        }
                        drawcs(350, "Press  [ Enter ]  to continue", 0, 0, 0, 0);
                    }
                    holdit = true;
                    winner = false;
                }
                if (!holdit) {
                    for (int i = 0; i < nplayers; i++)
                        if (CheckPoints.clear[i] == CheckPoints.nlaps * CheckPoints.nsp && CheckPoints.pos[i] == 0) {
                            // it ais stopped later on
                            if (clangame == 0) {
                                if (i == im) {
                                    drawhi(youwon, 70);
                                    if (aflk) {
                                        drawcs(120, "You finished first, nice job!", 0, 0, 0, 0);
                                        aflk = false;
                                    } else {
                                        drawcs(120, "You finished first, nice job!", 0, 128, 255, 0);
                                        aflk = true;
                                    }
                                    winner = true;
                                } else {
                                    drawhi(youlost, 70);
                                    if (fase != 7001) {
                                        if (aflk) {
                                            drawcs(120, "" + CarDefine.names[sc[i]] + " finished first, race over!", 0, 0, 0, 0);
                                            aflk = false;
                                        } else {
                                            drawcs(120, "" + CarDefine.names[sc[i]] + " finished first, race over!", 0, 128, 255, 0);
                                            aflk = true;
                                        }
                                    } else if (aflk) {
                                        drawcs(120, "" + plnames[i] + " finished first, race over!", 0, 0, 0, 0);
                                        aflk = false;
                                    } else {
                                        drawcs(120, "" + plnames[i] + " finished first, race over!", 0, 128, 255, 0);
                                        aflk = true;
                                    }
                                    winner = false;
                                }
                            } else if (pclan[i].equalsIgnoreCase(pclan[im])) {
                                drawhi(youwon, 70);
                                if (aflk) {
                                    drawcs(120, "Your clan " + pclan[im] + " finished first, nice job!", 0, 0, 0, 0);
                                    aflk = false;
                                } else {
                                    drawcs(120, "Your clan " + pclan[im] + " finished first, nice job!", 0, 128, 255, 0);
                                    aflk = true;
                                }
                                winner = true;
                            } else {
                                drawhi(youlost, 70);
                                if (aflk) {
                                    drawcs(120, "" + plnames[i] + " of clan " + pclan[i] + " finished first, race over!", 0, 0, 0, 0);
                                    aflk = false;
                                } else {
                                    drawcs(120, "" + plnames[i] + " of clan " + pclan[i] + " finished first, race over!", 0, 128, 255, 0);
                                    aflk = true;
                                }
                                winner = false;
                            }
                            drawcs(350, "Press  [ Enter ]  to continue", 0, 0, 0, 0);
                            CheckPoints.haltall = true;
                            holdit = true;
                        }
                }
            } else {
                if (!holdit && (CheckPoints.wasted >= nplayers - 1 || bool184)) {
                    String string189 = "Someone";
                    if (!bool184) {
                        for (int i = 0; i < nplayers; i++)
                            if (CheckPoints.dested[i] == 0) {
                                string189 = plnames[i];
                            }
                    } else {
                        string189 = "Clan " + astring + "";
                    }
                    drawhi(gamefinished, 70);
                    if (aflk) {
                        drawcs(120, "" + string189 + " has wasted all the cars!", 0, 0, 0, 0);
                        aflk = false;
                    } else {
                        drawcs(120, "" + string189 + " has wasted all the cars!", 0, 128, 255, 0);
                        aflk = true;
                    }
                    drawcs(350, "Press  [ Enter ]  to continue", 0, 0, 0, 0);
                    CheckPoints.haltall = true;
                    holdit = true;
                    winner = false;
                }
                if (!holdit) {
                    for (int i = 0; i < nplayers; i++)
                        if (CheckPoints.clear[i] == CheckPoints.nlaps * CheckPoints.nsp && CheckPoints.pos[i] == 0) {
                            drawhi(gamefinished, 70);
                            if (clangame == 0) {
                                if (aflk) {
                                    drawcs(120, "" + plnames[i] + " finished first, race over!", 0, 0, 0, 0);
                                    aflk = false;
                                } else {
                                    drawcs(120, "" + plnames[i] + " finished first, race over!", 0, 128, 255, 0);
                                    aflk = true;
                                }
                            } else if (aflk) {
                                drawcs(120, "Clan " + pclan[i] + " finished first, race over!", 0, 0, 0, 0);
                                aflk = false;
                            } else {
                                drawcs(120, "Clan " + pclan[i] + " finished first, race over!", 0, 128, 255, 0);
                                aflk = true;
                            }
                            drawcs(350, "Press  [ Enter ]  to continue", 0, 0, 0, 0);
                            CheckPoints.haltall = true;
                            holdit = true;
                            winner = false;
                        }
                }
                if (!holdit && discon == 240) {
                    drawhi(gamefinished, 70);
                    if (aflk) {
                        drawcs(120, "Game got disconnected!", 0, 0, 0, 0);
                        aflk = false;
                    } else {
                        drawcs(120, "Game got disconnected!", 0, 128, 255, 0);
                        aflk = true;
                    }
                    drawcs(350, "Press  [ Enter ]  to continue", 0, 0, 0, 0);
                    CheckPoints.haltall = true;
                    holdit = true;
                    winner = false;
                }
                if (!holdit) {
                    G.drawImage(wgame, 311, 20, null);
                    if (!clanchat) {
                        drawcs(397, "Click any player on the right to follow!", 0, 0, 0, 0);
                        if (!lan) {
                            drawcs(412, "Press [V] to change view.  Press [Enter] to exit.", 0, 0, 0, 0);
                        } else {
                            drawcs(412, "Press [V] to change view.", 0, 0, 0, 0);
                        }
                    }
                }
            }
            if (abool) {
                if (CheckPoints.stage != 10 && multion < 2 && nplayers != 1 && arrace != control.arrace) {
                    arrace = control.arrace;
                    if (multion == 1 && arrace) {
                        control.radar = true;
                    }
                    if (arrace) {
                        wasay = true;
                        say = " Arrow now pointing at >  CARS";
                        if (multion == 1) {
                            say = say + "    Press [S] to toggle Radar!";
                        }
                        tcnt = -5;
                    }
                    if (!arrace) {
                        wasay = false;
                        say = " Arrow now pointing at >  TRACK";
                        if (multion == 1) {
                            say = say + "    Press [S] to toggle Radar!";
                        }
                        tcnt = -5;
                        cntan = 20;
                        alocked = -1;
                        alocked = -1;
                    }
                }
                if (!holdit && fase != -6 && starcnt == 0 && multion < 2 && CheckPoints.stage != 10) {
                    arrow(mad.point, mad.missedcp, arrace);
                    if (!arrace) {
                        if (auscnt == 45 && mad.capcnt == 0 && exitm == 0)
                            if (mad.missedcp > 0) {
                                if (mad.missedcp > 15 && mad.missedcp < 50)
                                    if (flk) {
                                        drawcs(70, "Checkpoint Missed!", 255, 0, 0, 0);
                                    } else {
                                        drawcs(70, "Checkpoint Missed!", 255, 150, 0, 2);
                                    }
                                mad.missedcp++;
                                if (mad.missedcp == 70) {
                                    mad.missedcp = -2;
                                }
                            } else if (mad.mtouch && cntovn < 70) {
                                if (Math.abs(ana) > 100) {
                                    cntan++;
                                } else if (cntan != 0) {
                                    cntan--;
                                }
                                if (cntan > 40) {
                                    cntovn++;
                                    cntan = 40;
                                    if (flk) {
                                        drawcs(70, "Wrong Way!", 255, 150, 0, 0);
                                        flk = false;
                                    } else {
                                        drawcs(70, "Wrong Way!", 255, 0, 0, 2);
                                        flk = true;
                                    }
                                }
                            }
                    } else if (alocked != lalocked) {
                        if (alocked != -1) {
                            wasay = true;
                            say = " Arrow Locked on >  " + plnames[alocked] + "";
                            tcnt = -5;
                        } else {
                            wasay = true;
                            say = "Arrow Unlocked!";
                            tcnt = 10;
                        }
                        lalocked = alocked;
                    }
                }
                if (Medium.darksky) {
                    Color color = new Color(Medium.csky[0], Medium.csky[1], Medium.csky[2]);
                    float[] fs = new float[3];
                    Color.RGBtoHSB(Medium.csky[0], Medium.csky[1], Medium.csky[2], fs);
                    fs[2] = 0.6F;
                    color = Color.getHSBColor(fs[0], fs[1], fs[2]);
                    G.setColor(color);
                    G.fillRect(602, 9, 54, 14);
                    G.drawLine(601, 10, 601, 21);
                    G.drawLine(600, 12, 600, 19);
                    G.fillRect(607, 29, 49, 14);
                    G.drawLine(606, 30, 606, 41);
                    G.drawLine(605, 32, 605, 39);
                    G.fillRect(18, 6, 155, 14);
                    G.drawLine(17, 7, 17, 18);
                    G.drawLine(16, 9, 16, 16);
                    G.drawLine(173, 7, 173, 18);
                    G.drawLine(174, 9, 174, 16);
                    G.fillRect(40, 26, 107, 21);
                    G.drawLine(39, 27, 39, 45);
                    G.drawLine(38, 29, 38, 43);
                    G.drawLine(147, 27, 147, 45);
                    G.drawLine(148, 29, 148, 43);
                }
                G.drawImage(dmg, 600, 7, null);
                G.drawImage(pwr, 600, 27, null);
                G.drawImage(lap, 19, 7, null);
                G.setColor(new Color(0, 0, 100));
                G.drawString("" + (mad.nlaps + 1) + " / " + CheckPoints.nlaps + "", 51, 18);
                G.drawImage(was, 92, 7, null);
                G.setColor(new Color(0, 0, 100));
                G.drawString("" + CheckPoints.wasted + " / " + (nplayers - 1) + "", 150, 18);
                G.drawImage(pos, 42, 27, null);
                G.drawImage(rank[CheckPoints.pos[mad.im]], 110, 28, null);
                drawstat(CarDefine.maxmag[mad.cn], mad.hitmag, mad.power);
                if (control.radar && CheckPoints.stage != 10) {
                    radarstat(mad, conto);
                }
            }
            if (!holdit) {
                if (starcnt != 0 && starcnt <= 35) {
                    if (starcnt == 35 && !mutes) {
                        three.play();
                    }
                    if (starcnt == 24) {
                        gocnt = 2;
                        if (!mutes) {
                            two.play();
                        }
                    }
                    if (starcnt == 13) {
                        gocnt = 1;
                        if (!mutes) {
                            one.play();
                        }
                    }
                    if (starcnt == 2) {
                        gocnt = 0;
                        if (!mutes) {
                            go.play();
                        }
                    }
                    duds = 0;
                    if (starcnt <= 37 && starcnt > 32) {
                        duds = 1;
                    }
                    if (starcnt <= 26 && starcnt > 21) {
                        duds = 1;
                    }
                    if (starcnt <= 15 && starcnt > 10) {
                        duds = 1;
                    }
                    if (starcnt <= 4) {
                        duds = 2;
                    }
                    if (dudo != -1) {
                        G.setAlpha(0.3F);
                        G.drawImage(dude[duds], dudo, 0, null);
                        G.setAlpha(1.0F);
                    }
                    if (gocnt != 0) {
                        G.drawImage(cntdn[gocnt], 385, 50, null);
                    } else {
                        G.drawImage(cntdn[gocnt], 363, 50, null);
                    }
                }
                if (looped != 0 && mad.loop == 2) {
                    looped = 0;
                }
                if (mad.power < 45.0F) {
                    if (tcnt == 30 && auscnt == 45 && mad.mtouch && mad.capcnt == 0 && exitm == 0) {
                        if (looped != 2) {
                            if (pwcnt < 70 || pwcnt < 100 && looped != 0)
                                if (pwflk) {
                                    drawcs(110, "Power low, perform stunt!", 0, 0, 200, 0);
                                    pwflk = false;
                                } else {
                                    drawcs(110, "Power low, perform stunt!", 255, 100, 0, 0);
                                    pwflk = true;
                                }
                        } else if (pwcnt < 100) {
                            String string192 = "";
                            if (multion == 0) {
                                string192 = "  (Press Enter)";
                            }
                            if (pwflk) {
                                drawcs(110, "Please read the Game Instructions!" + string192 + "", 0, 0, 200, 0);
                                pwflk = false;
                            } else {
                                drawcs(110, "Please read the Game Instructions!" + string192 + "", 255, 100, 0, 0);
                                pwflk = true;
                            }
                        }
                        pwcnt++;
                        if (pwcnt == 300) {
                            pwcnt = 0;
                            if (looped != 0) {
                                looped++;
                                if (looped == 4) {
                                    looped = 2;
                                }
                            }
                        }
                    }
                } else if (pwcnt != 0) {
                    pwcnt = 0;
                }
                if (mad.capcnt == 0) {
                    if (tcnt < 30) {
                        if (exitm == 0)
                            if (tflk) {
                                if (!wasay) {
                                    drawcs(105, say, 0, 0, 0, 0);
                                } else {
                                    drawcs(105, say, 0, 0, 0, 0);
                                }
                                tflk = false;
                            } else {
                                if (!wasay) {
                                    drawcs(105, say, 0, 128, 255, 0);
                                } else {
                                    drawcs(105, say, 255, 128, 0, 0);
                                }
                                tflk = true;
                            }
                        tcnt++;
                    } else if (wasay) {
                        wasay = false;
                    }
                    if (auscnt < 45) {
                        if (exitm == 0)
                            if (aflk) {
                                drawcs(85, asay, 98, 176, 255, 0);
                                aflk = false;
                            } else {
                                drawcs(85, asay, 0, 128, 255, 0);
                                aflk = true;
                            }
                        auscnt++;
                    }
                } else if (exitm == 0)
                    if (tflk) {
                        drawcs(110, "Bad Landing!", 0, 0, 200, 0);
                        tflk = false;
                    } else {
                        drawcs(110, "Bad Landing!", 255, 100, 0, 0);
                        tflk = true;
                    }
                if (mad.trcnt == 10) {
                    loop = "";
                    spin = "";
                    asay = "";
                    int i = 0;
                    while (mad.travzy > 225) {
                        mad.travzy -= 360;
                        i++;
                    }
                    while (mad.travzy < -225) {
                        mad.travzy += 360;
                        i--;
                    }
                    if (i == 1) {
                        loop = "Forward loop";
                    }
                    if (i == 2) {
                        loop = "double Forward";
                    }
                    if (i == 3) {
                        loop = "triple Forward";
                    }
                    if (i >= 4) {
                        loop = "massive Forward looping";
                    }
                    if (i == -1) {
                        loop = "Backloop";
                    }
                    if (i == -2) {
                        loop = "double Back";
                    }
                    if (i == -3) {
                        loop = "triple Back";
                    }
                    if (i <= -4) {
                        loop = "massive Back looping";
                    }
                    if (i == 0)
                        if (mad.ftab && mad.btab) {
                            loop = "Tabletop and reversed Tabletop";
                        } else if (mad.ftab || mad.btab) {
                            loop = "Tabletop";
                        }
                    if (i > 0 && mad.btab) {
                        loop = "Hanged " + loop;
                    }
                    if (i < 0 && mad.ftab) {
                        loop = "Hanged " + loop;
                    }
                    if (!Objects.equals(loop, "")) {
                        asay = asay + " " + loop;
                    }
                    i = 0;
                    mad.travxy = Math.abs(mad.travxy);
                    while (mad.travxy > 270) {
                        mad.travxy -= 360;
                        i++;
                    }
                    if (i == 0 && mad.rtab)
                        if (Objects.equals(loop, "")) {
                            spin = "Tabletop";
                        } else {
                            spin = "Flipside";
                        }
                    if (i == 1) {
                        spin = "Rollspin";
                    }
                    if (i == 2) {
                        spin = "double Rollspin";
                    }
                    if (i == 3) {
                        spin = "triple Rollspin";
                    }
                    if (i >= 4) {
                        spin = "massive Roll spinning";
                    }
                    i = 0;
                    boolean bool194 = false;
                    mad.travxz = Math.abs(mad.travxz);
                    while (mad.travxz > 90) {
                        mad.travxz -= 180;
                        i += 180;
                        if (i > 900) {
                            i = 900;
                            bool194 = true;
                        }
                    }
                    if (i != 0) {
                        if (Objects.equals(loop, "") && Objects.equals(spin, "")) {
                            asay = asay + " " + i;
                            if (bool194) {
                                asay = asay + " and beyond";
                            }
                        } else {
                            if (!Objects.equals(spin, ""))
                                if (Objects.equals(loop, "")) {
                                    asay = asay + " " + spin;
                                } else {
                                    asay = asay + " with " + spin;
                                }
                            asay = asay + " by " + i;
                            if (bool194) {
                                asay = asay + " and beyond";
                            }
                        }
                    } else if (!Objects.equals(spin, ""))
                        if (Objects.equals(loop, "")) {
                            asay = asay + " " + spin;
                        } else {
                            asay = asay + " by " + spin;
                        }
                    if (!Objects.equals(asay, "")) {
                        auscnt -= 15;
                    }
                    if (!Objects.equals(loop, "")) {
                        auscnt -= 25;
                    }
                    if (!Objects.equals(spin, "")) {
                        auscnt -= 25;
                    }
                    if (i != 0) {
                        auscnt -= 25;
                    }
                    if (auscnt < 45) {
                        if (!mutes) {
                            powerup.play();
                        }
                        if (auscnt < -20) {
                            auscnt = -20;
                        }
                        int i205 = 0;
                        if (mad.powerup > 20.0F) {
                            i205 = 1;
                        }
                        if (mad.powerup > 40.0F) {
                            i205 = 2;
                        }
                        if (mad.powerup > 150.0F) {
                            i205 = 3;
                        }
                        if (mad.surfer) {
                            asay = " " + adj[4][(int) (Medium.random() * 3.0F)] + asay;
                        }
                        if (i205 != 3) {
                            asay = "" + adj[i205][(int) (Medium.random() * 3.0F)] + asay + exlm[i205];
                        } else {
                            asay = adj[i205][(int) (Medium.random() * 3.0F)];
                        }
                        if (!wasay) {
                            tcnt = auscnt;
                            if (mad.power != 98.0F) {
                                say = "Power Up " + (int) (100.0F * mad.powerup / 98.0F) + "%";
                            } else {
                                say = "Power To The MAX";
                            }
                            skidup = !skidup;
                        }
                    }
                }
                if (mad.newcar) {
                    if (!wasay) {
                        say = "Car Fixed";
                        tcnt = 0;
                    }
                    crashup = !crashup;
                }
                for (int i = 0; i < nplayers; i++)
                    if (dested[i] != CheckPoints.dested[i] && i != im) {
                        dested[i] = CheckPoints.dested[i];
                        if (fase != 7001) {
                            if (dested[i] == 1) {
                                wasay = true;
                                say = "" + CarDefine.names[sc[i]] + " has been wasted!";
                                tcnt = -15;
                            }
                            if (dested[i] == 2) {
                                wasay = true;
                                say = "You wasted " + CarDefine.names[sc[i]] + "!";
                                tcnt = -15;
                            }
                        } else {
                            if (dested[i] == 1) {
                                wasay = true;
                                say = "" + plnames[i] + " has been wasted!";
                                tcnt = -15;
                            }
                            if (dested[i] == 2) {
                                wasay = true;
                                if (multion < 2) {
                                    say = "You wasted " + plnames[i] + "!";
                                } else {
                                    say = "" + plnames[im] + " wasted " + plnames[i] + "!";
                                }
                                tcnt = -15;
                            }
                            if (dested[i] == 3) {
                                wasay = true;
                                say = "" + plnames[i] + " has been wasted! (Disconnected)";
                                tcnt = -15;
                            }
                        }
                    }
                if (multion >= 2 && alocked != lalocked) {
                    if (alocked != -1) {
                        wasay = false;
                        say = "Now following " + plnames[alocked] + "!";
                        tcnt = -15;
                    }
                    lalocked = alocked;
                    clear = mad.clear;
                }
                if (clear != mad.clear && mad.clear != 0) {
                    if (!wasay) {
                        say = "Checkpoint!";
                        tcnt = 15;
                    }
                    clear = mad.clear;
                    if (!mutes) {
                        checkpoint.play();
                    }
                    cntovn = 0;
                    if (cntan != 0) {
                        cntan = 0;
                    }
                }
            }
        }
        if (Medium.lightn != -1) {
            //int i = strack.sClip.stream.available();
            Medium.lton = false;
            //if (i <= 6380001 && i > 5368001)
            //	m.lton = true;
            //if (i <= 2992001 && i > 1320001)
            //	m.lton = true;
        }
    }

    static private void stopairs() {
        for (int i = 0; i < 6; i++) {
            air[i].stop();
        }
    }

    static void stopallnow() {
        if (runner != null) {
            runner.interrupt();
            runner = null;
        }
        runtyp = 0;
        if (loadedt) {
            strack.unload();
            strack = null;
            loadedt = false;
        }
        for (int i = 0; i < 5; i++) {
            for (int i19 = 0; i19 < 5; i19++) {
                if (engs[i][i19] != null) {
                    engs[i][i19].stop();
                }
                engs[i][i19] = null;
            }
        }
        for (int i = 0; i < 6; i++) {
            if (air[i] != null) {
                air[i].stop();
            }
            air[i] = null;
        }
        wastd.stop();
        if (intertrack != null) {
            intertrack.unload();
        }
        intertrack = null;
    }

    static void stopchat() {
        clanchat = false;
        clangame = 0;
        if (runtyp == -101) {
            runtyp = 0;
            try {
                socket.close();
                socket = null;
                din.close();
                din = null;
                dout.close();
                dout = null;
            } catch (Exception ignored) {

            }
        }
    }

    static void stoploading() {
        loading();
        //app.repaint();
        runtyp = 0;
    }

    static void trackbg(boolean abool) {
        int i = 0;
        trkl++;
        if (trkl > trklim) {
            i = 1;
            trklim = (int) (HansenRandom.Double() * 40.0);
            trkl = 0;
        }
        if (abool) {
            i = 0;
        }
        for (int i25 = 0; i25 < 2; i25++) {
            G.drawImage(trackbg[i], trkx[i25], 25, null);
            trkx[i25] -= 10;
            if (trkx[i25] <= -605) {
                trkx[i25] = 735;
            }
        }
        G.setColor(new Color(0, 0, 0));
        G.fillRect(0, 0, 65, 450);
        G.fillRect(735, 0, 65, 450);
        G.fillRect(65, 0, 670, 25);
        G.fillRect(65, 425, 670, 25);
    }

    static void waitenter() {
        if (forstart < 690) {
            G.setFont(new Font("Arial", 1, 13));
            ftm = G.getFontMetrics();
            drawcs(70, "Waiting for all players to finish loading!", 0, 0, 0, 0);
            if (forstart <= 640) {
                drawcs(90, "" + (640 - forstart) / 32 + "", 0, 0, 0, 0);
            } else {
                drawcs(90, "Your connection to game may have been lost...", 0, 0, 0, 0);
            }
            G.setFont(new Font("Arial", 1, 11));
            ftm = G.getFontMetrics();
            if (tflk) {
                drawcs(125, "Get Ready!", 0, 0, 0, 0);
                tflk = false;
            } else {
                drawcs(125, "Get Ready!", 0, 128, 255, 0);
                tflk = true;
            }
        }
        forstart++;
        if (forstart == 700) {
            fase = -2;
            winner = false;
        }
    }

    static private int xs(int i, int i279) {
        if (i279 < 50) {
            i279 = 50;
        }
        return (i279 - Medium.focusPoint) * (Medium.cx - i) / i279 + i;
    }

    static private int ys(int i, int i280) {
        if (i280 < 50) {
            i280 = 50;
        }
        return (i280 - Medium.focusPoint) * (Medium.cy - i) / i280 + i;
    }
    }
}