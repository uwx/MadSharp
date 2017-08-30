using System;
using SharpDX.Text;
using boolean = System.Boolean;
using Encoding = System.Text.Encoding;

namespace Cum {
class CarDefine {

    public static readonly int THIRTY_SIX = 36; // MAX CUSTOM CARS - NCARS
    public static readonly int SIXTEEN = 16; // NCARS
    public static readonly int FIFTY_SIX = 56; // NCARS + MAX CUSTOM CARS
    public static readonly int FORTY = 40; // MAX CUSTOM CARS LOAD

    private static ContO[] bco;
    
    static readonly int[,] swits = {
            {
                    50, 185, 282
            }, {
                    100, 200, 310
            }, {
                    60, 180, 275
            }, {
                    76, 195, 298
            }, {
                    70, 170, 275
            }, {
                    70, 202, 293
            }, {
                    60, 170, 289
            }, {
                    70, 206, 291
            }, {
                    90, 210, 295
            }, {
                    90, 190, 276
            }, {
                    70, 200, 295
            }, {
                    50, 160, 270
            }, {
                    90, 200, 305
            }, {
                    50, 130, 210
            }, {
                    80, 200, 300
            }, {
                    70, 210, 290
            }, {
                    0, 0, 0
            }, {
                    0, 0, 0
            }, {
                    0, 0, 0
            }, {
                    0, 0, 0
            }, {
                    0, 0, 0
            }, {
                    0, 0, 0
            }, {
                    0, 0, 0
            }, {
                    0, 0, 0
            }, {
                    0, 0, 0
            }, {
                    0, 0, 0
            }, {
                    0, 0, 0
            }, {
                    0, 0, 0
            }, {
                    0, 0, 0
            }, {
                    0, 0, 0
            }, {
                    0, 0, 0
            }, {
                    0, 0, 0
            }, {
                    0, 0, 0
            }, {
                    0, 0, 0
            }, {
                    0, 0, 0
            }, {
                    0, 0, 0
            }, {
                    0, 0, 0
            }, {
                    0, 0, 0
            }, {
                    0, 0, 0
            }, {
                    0, 0, 0
            }, {
                    0, 0, 0
            }, {
                    0, 0, 0
            }, {
                    0, 0, 0
            }, {
                    0, 0, 0
            }, {
                    0, 0, 0
            }, {
                    0, 0, 0
            }, {
                    0, 0, 0
            }, {
                    0, 0, 0
            }, {
                    0, 0, 0
            }, {
                    0, 0, 0
            }, {
                    0, 0, 0
            }, {
                    0, 0, 0
            }, {
                    0, 0, 0
            }, {
                    0, 0, 0
            }, {
                    0, 0, 0
            }, {
                    0, 0, 0
            }
    };
    static readonly float[,] acelf = {
            {
                    11.0F, 5.0F, 3.0F
            }, {
                    14.0F, 7.0F, 5.0F
            }, {
                    10.0F, 5.0F, 3.5F
            }, {
                    11.0F, 6.0F, 3.5F
            }, {
                    10.0F, 5.0F, 3.5F
            }, {
                    12.0F, 6.0F, 3.0F
            }, {
                    7.0F, 9.0F, 4.0F
            }, {
                    11.0F, 5.0F, 3.0F
            }, {
                    12.0F, 7.0F, 4.0F
            }, {
                    12.0F, 7.0F, 3.5F
            }, {
                    11.5F, 6.5F, 3.5F
            }, {
                    9.0F, 5.0F, 3.0F
            }, {
                    13.0F, 7.0F, 4.5F
            }, {
                    7.5F, 3.5F, 3.0F
            }, {
                    11.0F, 7.5F, 4.0F
            }, {
                    12.0F, 6.0F, 3.5F
            }, {
                    0.0F, 0.0F, 0.0F
            }, {
                    0.0F, 0.0F, 0.0F
            }, {
                    0.0F, 0.0F, 0.0F
            }, {
                    0.0F, 0.0F, 0.0F
            }, {
                    0.0F, 0.0F, 0.0F
            }, {
                    0.0F, 0.0F, 0.0F
            }, {
                    0.0F, 0.0F, 0.0F
            }, {
                    0.0F, 0.0F, 0.0F
            }, {
                    0.0F, 0.0F, 0.0F
            }, {
                    0.0F, 0.0F, 0.0F
            }, {
                    0.0F, 0.0F, 0.0F
            }, {
                    0.0F, 0.0F, 0.0F
            }, {
                    0.0F, 0.0F, 0.0F
            }, {
                    0.0F, 0.0F, 0.0F
            }, {
                    0.0F, 0.0F, 0.0F
            }, {
                    0.0F, 0.0F, 0.0F
            }, {
                    0.0F, 0.0F, 0.0F
            }, {
                    0.0F, 0.0F, 0.0F
            }, {
                    0.0F, 0.0F, 0.0F
            }, {
                    0.0F, 0.0F, 0.0F
            }, {
                    0.0F, 0.0F, 0.0F
            }, {
                    0.0F, 0.0F, 0.0F
            }, {
                    0.0F, 0.0F, 0.0F
            }, {
                    0.0F, 0.0F, 0.0F
            }, {
                    0.0F, 0.0F, 0.0F
            }, {
                    0.0F, 0.0F, 0.0F
            }, {
                    0.0F, 0.0F, 0.0F
            }, {
                    0.0F, 0.0F, 0.0F
            }, {
                    0.0F, 0.0F, 0.0F
            }, {
                    0.0F, 0.0F, 0.0F
            }, {
                    0.0F, 0.0F, 0.0F
            }, {
                    0.0F, 0.0F, 0.0F
            }, {
                    0.0F, 0.0F, 0.0F
            }, {
                    0.0F, 0.0F, 0.0F
            }, {
                    0.0F, 0.0F, 0.0F
            }, {
                    0.0F, 0.0F, 0.0F
            }, {
                    0.0F, 0.0F, 0.0F
            }, {
                    0.0F, 0.0F, 0.0F
            }, {
                    0.0F, 0.0F, 0.0F
            }, {
                    0.0F, 0.0F, 0.0F
            }
    };
    static readonly int[] handb = {
            7, 10, 7, 15, 12, 8, 9, 10, 5, 7, 8, 10, 8, 12, 7, 7, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0
    };
    static readonly float[] airs = {
            1.0F, 1.2F, 0.95F, 1.0F, 2.2F, 1.0F, 0.9F, 0.8F, 1.0F, 0.9F, 1.15F, 0.8F, 1.0F, 0.3F, 1.3F, 1.0F, 0.0F,
            0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F,
            0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F,
            0.0F, 0.0F, 0.0F
    };
    static readonly int[] airc = {
            70, 30, 40, 40, 30, 50, 40, 90, 40, 50, 75, 10, 50, 0, 100, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0
    };
    static readonly int[] turn = {
            6, 9, 5, 7, 8, 7, 5, 5, 9, 7, 7, 4, 6, 5, 7, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0
    };
    static readonly float[] grip = {
            20.0F, 27.0F, 18.0F, 22.0F, 19.0F, 20.0F, 25.0F, 20.0F, 19.0F, 24.0F, 22.5F, 25.0F, 30.0F, 27.0F, 25.0F,
            27.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F,
            0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F,
            0.0F, 0.0F, 0.0F, 0.0F, 0.0F
    };
    static readonly float[] bounce = {
            1.2F, 1.05F, 1.3F, 1.15F, 1.3F, 1.2F, 1.15F, 1.1F, 1.2F, 1.1F, 1.15F, 0.8F, 1.05F, 0.8F, 1.1F, 1.15F, 0.0F,
            0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F,
            0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F,
            0.0F, 0.0F, 0.0F
    };
    static readonly float[] simag = {
            0.9F, 0.85F, 1.05F, 0.9F, 0.85F, 0.9F, 1.05F, 0.9F, 1.0F, 1.05F, 0.9F, 1.1F, 0.9F, 1.3F, 0.9F, 1.15F, 0.0F,
            0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F,
            0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F,
            0.0F, 0.0F, 0.0F
    };
    static readonly float[] moment = {
            1.3F, 0.75F, 1.4F, 1.2F, 1.1F, 1.38F, 1.43F, 1.48F, 1.35F, 1.7F, 1.42F, 2.0F, 1.26F, 3.0F, 1.5F, 2.0F, 0.0F,
            0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F,
            0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F,
            0.0F, 0.0F, 0.0F
    };
    static readonly float[] comprad = {
            0.5F, 0.4F, 0.8F, 0.5F, 0.4F, 0.5F, 0.5F, 0.5F, 0.5F, 0.8F, 0.5F, 1.5F, 0.5F, 0.8F, 0.5F, 0.8F, 0.0F, 0.0F,
            0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F,
            0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F,
            0.0F, 0.0F
    };
    static readonly int[] push = {
            2, 2, 3, 3, 2, 2, 2, 4, 2, 2, 2, 4, 2, 2, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0
    };
    static readonly int[] revpush = {
            2, 3, 2, 2, 2, 2, 2, 1, 2, 1, 2, 1, 2, 2, 2, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0
    };
    static readonly int[] lift = {
            0, 30, 0, 20, 0, 30, 0, 0, 20, 0, 0, 0, 10, 0, 30, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0
    };
    static readonly int[] revlift = {
            0, 0, 15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 32, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0
    };
    static readonly int[] powerloss = {
            2500000, 2500000, 3500000, 2500000, 4000000, 2500000, 3200000, 3200000, 2750000, 5500000, 2750000, 4500000,
            3500000, 16700000, 3000000, 5500000, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0
    };
    static readonly int[] flipy = {
            -50, -60, -92, -44, -60, -57, -54, -60, -77, -57, -82, -85, -28, -100, -63, -127, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0
    };
    static readonly int[] msquash = {
            7, 4, 7, 2, 8, 4, 6, 4, 3, 8, 4, 10, 3, 20, 3, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0
    };
    static readonly int[] clrad = {
            3300, 1700, 4700, 3000, 2000, 4500, 3500, 5000, 10000, 15000, 4000, 7000, 10000, 15000, 5500, 5000, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0
    };
    static readonly float[] dammult = {
            0.75F, 0.8F, 0.45F, 0.8F, 0.42F, 0.7F, 0.72F, 0.6F, 0.58F, 0.41F, 0.67F, 0.45F, 0.61F, 0.25F, 0.38F, 0.52F,
            0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F,
            0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F,
            0.0F, 0.0F, 0.0F, 0.0F
    };
    static readonly int[] maxmag = {
            7600, 4200, 7200, 6000, 6000, 15000, 17200, 17000, 18000, 11000, 19000, 10700, 13000, 45000, 5800, 18000, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0
    };
    static readonly float[] dishandle = {
            0.65F, 0.6F, 0.55F, 0.77F, 0.62F, 0.9F, 0.6F, 0.72F, 0.45F, 0.8F, 0.95F, 0.4F, 0.87F, 0.42F, 1.0F, 0.95F,
            0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F,
            0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F,
            0.0F, 0.0F, 0.0F, 0.0F
    };
    static readonly float[] outdam = {
            0.68F, 0.35F, 0.8F, 0.5F, 0.42F, 0.76F, 0.82F, 0.76F, 0.72F, 0.62F, 0.79F, 0.95F, 0.77F, 1.0F, 0.85F, 1.0F,
            0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F,
            0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F,
            0.0F, 0.0F, 0.0F, 0.0F
    };
    static readonly int[] cclass = {
            0, 0, 0, 0, 0, 1, 2, 2, 2, 2, 3, 4, 4, 4, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0
    };
    static readonly String[] names = {
            "Tornado Shark", "Formula 7", "Wow Caninaro", "La Vita Crab", "Nimi", "MAX Revenge", "Lead Oxide",
            "Kool Kat", "Drifter X", "Sword of Justice", "High Rider", "EL KING", "Mighty Eight", "M A S H E E N",
            "Radical One", "DR Monstaa", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "",
            "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", ""
    };
    static readonly int[] enginsignature = {
            0, 1, 2, 1, 0, 3, 2, 2, 1, 0, 3, 4, 1, 4, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0
    };
    static int lastload = 0;
    static private int nlcars = 0;
    static int nlocars = 0;
    static private int xnlocars = 0;
    static readonly boolean[] include = new boolean[FORTY];
    static readonly String[] createdby = new String[FORTY];
    static readonly int[] publish = new int[FORTY];
    static readonly String[] loadnames = new String[20];
    static int nl = 0;
    static int action = 0;
    static private boolean carlon = false;
    static int reco = -2;
    static readonly int[] lcardate = {
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0
    };
    static int haltload = 0;
    static int ac = -1;
    static private String acname = "Radical One";
    static private String fails = "";
    static String tnickey = "";
    static String tclan = "";
    static String tclankey = "";
    static private readonly int[] adds = {
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0
    };
    static String viewname = "";
    static int staction = 0;
    static String onstage = "";
    static private int roundslot = 0;
    static String lastcar = "";
    static int msloaded = 0;
    private static CarDefine thread;
    static readonly int[] top20adds = new int[20];

    private CarDefine()
    {
        
    }
    static CarDefine create(ContO[] contos) {
        thread = new CarDefine();
        bco = contos;
        return thread;
    }

    static private void loadstat(byte[] _is, string str, int i, int i0, int i1, int i2) {
        names[i2] = str;
        boolean abool = false;
        boolean bool3 = false;
        int[] statValues = {
                128, 128, 128, 128, 128
        };
        int i6 = 640;
        int[] physicsValues = {
                50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50
        };
        int[] is8 = {
                50, 50, 50
        };
        enginsignature[i2] = 0;
        float f = 0.0F;
        publish[i2 - SIXTEEN] = 0;
        createdby[i2 - SIXTEEN] = "Unkown User";
        try {
            foreach (var aline in Encoding.Default.GetString(_is).Split('\n'))
            {
                var line = aline.Trim();
                if (line.StartsWith("stat(")) {
                    try {
                        i6 = 0;
                        for (int i9 = 0; i9 < 5; i9++) {
                            statValues[i9] = getvalue("stat", line, i9);
                            if (statValues[i9] > 200) {
                                statValues[i9] = 200;
                            }
                            if (statValues[i9] < 16) {
                                statValues[i9] = 16;
                            }
                            i6 += statValues[i9];
                        }
                        abool = true;
                    } catch (Exception exception) {
                        abool = false;
                    }
                }
                if (line.StartsWith("physics(")) {
                    try {
                        for (int i10 = 0; i10 < 11; i10++) {
                            physicsValues[i10] = getvalue("physics", line, i10);
                            if (physicsValues[i10] > 100) {
                                physicsValues[i10] = 100;
                            }
                            if (physicsValues[i10] < 0) {
                                physicsValues[i10] = 0;
                            }
                        }
                        for (int i11 = 0; i11 < 3; i11++) {
                            is8[i11] = getvalue("physics", line, i11 + 11);
                            if (i11 != 0 && is8[i11] > 100) {
                                is8[i11] = 100;
                            }
                            if (is8[i11] < 0) {
                                is8[i11] = 0;
                            }
                        }
                        enginsignature[i2] = getvalue("physics", line, 14);
                        if (enginsignature[i2] > 4) {
                            enginsignature[i2] = 0;
                        }
                        if (enginsignature[i2] < 0) {
                            enginsignature[i2] = 0;
                        }
                        f = getvalue("physics", line, 15);
                        if (f > 0.0F) {
                            bool3 = true;
                        }
                    } catch (Exception exception) {
                        bool3 = false;
                    }
                }
                if (line.StartsWith("handling(")) {
                    try {
                        int i12 = getvalue("handling", line, 0);
                        if (i12 > 200) {
                            i12 = 200;
                        }
                        if (i12 < 50) {
                            i12 = 50;
                        }
                        dishandle[i2] = i12 / 200.0F;
                    } catch (Exception ignored) {

                    }
                }
                if (line.StartsWith("carmaker(")) {
                    createdby[i2 - SIXTEEN] = getSvalue("carmaker", line, 0);
                }
                if (line.StartsWith("publish(")) {
                    publish[i2 - SIXTEEN] = getvalue("publish", line, 0);
                }
            }
        } catch (Exception exception) {
            Console.WriteLine("Error Loading Car Stat: " + exception);
        }
        if (abool && bool3) {
            int i13 = 0;
            if (i6 > 680) {
                i13 = 680 - i6;
            }
            if (i6 > 640 && i6 < 680) {
                i13 = 640 - i6;
            }
            if (i6 > 600 && i6 < 640) {
                i13 = 600 - i6;
            }
            if (i6 > 560 && i6 < 600) {
                i13 = 560 - i6;
            }
            if (i6 > 520 && i6 < 560) {
                i13 = 520 - i6;
            }
            if (i6 < 520) {
                i13 = 520 - i6;
            }
            while (i13 != 0) {
                for (int i14 = 0; i14 < 5; i14++) {
                    if (i13 > 0 && statValues[i14] < 200) {
                        statValues[i14]++;
                        i13--;
                    }
                    if (i13 < 0 && statValues[i14] > 16) {
                        statValues[i14]--;
                        i13++;
                    }
                }
            }
            i6 = 0;
            for (int i15 = 0; i15 < 5; i15++) {
                i6 += statValues[i15];
            }
            if (i6 == 520) {
                cclass[i2] = 0;
            }
            if (i6 == 560) {
                cclass[i2] = 1;
            }
            if (i6 == 600) {
                cclass[i2] = 2;
            }
            if (i6 == 640) {
                cclass[i2] = 3;
            }
            if (i6 == 680) {
                cclass[i2] = 4;
            }
            int i16 = 0;
            int i17 = 0;
            float f18 = 0.5F;
            if (statValues[0] == 200) {
                i16 = 1;
                i17 = 1;
            }
            if (statValues[0] > 192 && statValues[0] < 200) {
                i16 = 12;
                i17 = 1;
                f18 = (statValues[0] - 192) / 8.0F;
            }
            if (statValues[0] == 192) {
                i16 = 12;
                i17 = 12;
            }
            if (statValues[0] > 148 && statValues[0] < 192) {
                i16 = 14;
                i17 = 12;
                f18 = (statValues[0] - 148) / 44.0F;
            }
            if (statValues[0] == 148) {
                i16 = 14;
                i17 = 14;
            }
            if (statValues[0] > 133 && statValues[0] < 148) {
                i16 = 10;
                i17 = 14;
                f18 = (statValues[0] - 133) / 15.0F;
            }
            if (statValues[0] == 133) {
                i16 = 10;
                i17 = 10;
            }
            if (statValues[0] > 112 && statValues[0] < 133) {
                i16 = 15;
                i17 = 10;
                f18 = (statValues[0] - 112) / 21.0F;
            }
            if (statValues[0] == 112) {
                i16 = 15;
                i17 = 15;
            }
            if (statValues[0] > 107 && statValues[0] < 112) {
                i16 = 11;
                i17 = 15;
                f18 = (statValues[0] - 107) / 5.0F;
            }
            if (statValues[0] == 107) {
                i16 = 11;
                i17 = 11;
            }
            if (statValues[0] > 88 && statValues[0] < 107) {
                i16 = 13;
                i17 = 11;
                f18 = (statValues[0] - 88) / 19.0F;
            }
            if (statValues[0] == 88) {
                i16 = 13;
                i17 = 13;
            }
            if (statValues[0] > 88) {
                swits[i2,0] = (int) ((swits[i17,0] - swits[i16,0]) * f18 + swits[i16,0]);
                swits[i2,1] = (int) ((swits[i17,1] - swits[i16,1]) * f18 + swits[i16,1]);
                swits[i2,2] = (int) ((swits[i17,2] - swits[i16,2]) * f18 + swits[i16,2]);
            } else {
                f18 = statValues[0] / 88.0F;
                if (f18 < 0.76) {
                    f18 = 0.76F;
                }
                swits[i2,0] = (int) (50.0F * f18);
                swits[i2,1] = (int) (130.0F * f18);
                swits[i2,2] = (int) (210.0F * f18);
            }
            i16 = 0;
            i17 = 0;
            f18 = 0.5F;
            if (statValues[1] == 200) {
                i16 = 1;
                i17 = 1;
            }
            if (statValues[1] > 150 && statValues[1] < 200) {
                i16 = 14;
                i17 = 1;
                f18 = (statValues[1] - 150) / 50.0F;
            }
            if (statValues[1] == 150) {
                i16 = 14;
                i17 = 14;
            }
            if (statValues[1] > 144 && statValues[1] < 150) {
                i16 = 9;
                i17 = 14;
                f18 = (statValues[1] - 144) / 6.0F;
            }
            if (statValues[1] == 144) {
                i16 = 9;
                i17 = 9;
            }
            if (statValues[1] > 139 && statValues[1] < 144) {
                i16 = 6;
                i17 = 9;
                f18 = (statValues[1] - 139) / 5.0F;
            }
            if (statValues[1] == 139) {
                i16 = 6;
                i17 = 6;
            }
            if (statValues[1] > 128 && statValues[1] < 139) {
                i16 = 15;
                i17 = 6;
                f18 = (statValues[1] - 128) / 11.0F;
            }
            if (statValues[1] == 128) {
                i16 = 15;
                i17 = 15;
            }
            if (statValues[1] > 122 && statValues[1] < 128) {
                i16 = 10;
                i17 = 15;
                f18 = (statValues[1] - 122) / 6.0F;
            }
            if (statValues[1] == 122) {
                i16 = 10;
                i17 = 10;
            }
            if (statValues[1] > 119 && statValues[1] < 122) {
                i16 = 3;
                i17 = 10;
                f18 = (statValues[1] - 119) / 3.0F;
            }
            if (statValues[1] == 119) {
                i16 = 3;
                i17 = 3;
            }
            if (statValues[1] > 98 && statValues[1] < 119) {
                i16 = 5;
                i17 = 3;
                f18 = (statValues[1] - 98) / 21.0F;
            }
            if (statValues[1] == 98) {
                i16 = 5;
                i17 = 5;
            }
            if (statValues[1] > 81 && statValues[1] < 98) {
                i16 = 0;
                i17 = 5;
                f18 = (statValues[1] - 81) / 17.0F;
            }
            if (statValues[1] == 81) {
                i16 = 0;
                i17 = 0;
            }
            if (statValues[1] <= 80) {
                i16 = 2;
                i17 = 2;
            }
            if (statValues[0] <= 88) {
                i16 = 13;
                i17 = 13;
            }
            acelf[i2,0] = (acelf[i17,0] - acelf[i16,0]) * f18 + acelf[i16,0];
            acelf[i2,1] = (acelf[i17,1] - acelf[i16,1]) * f18 + acelf[i16,1];
            acelf[i2,2] = (acelf[i17,2] - acelf[i16,2]) * f18 + acelf[i16,2];
            if (statValues[1] <= 70 && statValues[0] > 88) {
                acelf[i2,0] = 9.0F;
                acelf[i2,1] = 4.0F;
                acelf[i2,2] = 3.0F;
            }
            f18 = (statValues[2] - 88) / 109.0F;
            if (f18 > 1.0F) {
                f18 = 1.0F;
            }
            if (f18 < -0.55) {
                f18 = -0.55F;
            }
            airs[i2] = 0.55F + 0.45F * f18 + 0.4F * (physicsValues[9] / 100.0F);
            if (airs[i2] < 0.3) {
                airs[i2] = 0.3F;
            }
            airc[i2] = (int) (10.0F + 70.0F * f18 + 30.0F * (physicsValues[10] / 100.0F));
            if (airc[i2] < 0) {
                airc[i2] = 0;
            }
            int i19 = (int) (670.0F - (physicsValues[9] + physicsValues[10]) / 200.0F * 420.0F);
            if (statValues[0] <= 88) {
                i19 = (int) (1670.0F - (physicsValues[9] + physicsValues[10]) / 200.0F * 1420.0F);
            }
            if (statValues[2] > 190 && i19 < 300) {
                i19 = 300;
            }
            powerloss[i2] = i19 * 10000;
            moment[i2] = 0.7F + (statValues[3] - 16) / 184.0F * 1.0F;
            if (statValues[0] < 110) {
                moment[i2] = 0.75F + (statValues[3] - 16) / 184.0F * 1.25F;
            }
            if (statValues[3] == 200 && statValues[4] == 200 && statValues[0] <= 88) {
                moment[i2] = 3.0F;
            }
            float f20 = 0.9F + (statValues[4] - 90) * 0.01F;
            if (f20 < 0.6) {
                f20 = 0.6F;
            }
            if (statValues[4] == 200 && statValues[0] <= 88) {
                f20 = 3.0F;
            }
            maxmag[i2] = (int) (f * f20);
            outdam[i2] = 0.35F + (f20 - 0.6F) * 0.5F;
            if (outdam[i2] < 0.35) {
                outdam[i2] = 0.35F;
            }
            if (outdam[i2] > 1.0F) {
                outdam[i2] = 1.0F;
            }
            clrad[i2] = (int) (is8[0] * is8[0] * 1.5);
            if (clrad[i2] < 1000) {
                clrad[i2] = 1000;
            }
            dammult[i2] = 0.3F + is8[1] * 0.005F;
            msquash[i2] = (int) (2.0 + is8[2] / 7.6);
            flipy[i2] = i0;
            handb[i2] = (int) (7.0F + physicsValues[0] / 100.0F * 8.0F);
            turn[i2] = (int) (4.0F + physicsValues[1] / 100.0F * 6.0F);
            grip[i2] = 16.0F + physicsValues[2] / 100.0F * 14.0F;
            if (grip[i2] < 21.0F) {
                swits[i2,0] += (int)(40.0F * ((21.0F - grip[i2]) / 5.0F));
                if (swits[i2,0] > 100) {
                    swits[i2,0] = 100;
                }
            }
            bounce[i2] = 0.8F + physicsValues[3] / 100.0F * 0.6F;
            if (physicsValues[3] > 67) {
                airs[i2] *= 0.76F + (1.0F - physicsValues[3] / 100.0F) * 0.24F;
                airc[i2] = (int) (airc[i2] * 0.76F + (1.0F - physicsValues[3] / 100.0F) * 0.24F);
            }
            lift[i2] = (int) ((float) physicsValues[5] * (float) physicsValues[5] / 10000.0F * 30.0F);
            revlift[i2] = (int) (physicsValues[6] / 100.0F * 32.0F);
            push[i2] = (int) (2.0F + physicsValues[7] / 100.0F * 2.0F * ((30 - lift[i2]) / 30f));
            revpush[i2] = (int) (1.0F + physicsValues[8] / 100.0F * 2.0F);
            comprad[i2] = i / 400.0F + (statValues[3] - 16) / 184.0F * 0.2F;
            if (comprad[i2] < 0.4) {
                comprad[i2] = 0.4F;
            }
            simag[i2] = (i1 - 17) * 0.0167F + 0.85F;
        } else {
            names[i2] = "";
        }
    }

    static private int getvalue(String str, String string21, int i) {
        int i22 = 0;
        String string23 = "";
        for (int i24 = str.Length + 1; i24 < string21.Length; i24++) {
            String string25 = $"{string21[i24]}";
            if (string25.Equals(",") || string25.Equals(")")) {
                i22++;
                i24++;
            }
            if (i22 == i) {
                string23 = "" + string23 + string21[i24];
            }
        }
        return (int) float.Parse(string23);
    }

    static private String getSvalue(String str, String string26, int i) {
        String string27 = "";
        int i28 = 0;
        for (int i29 = str.Length + 1; i29 < string26.Length && i28 <= i; i29++) {
            String string30 = $"{string26[i29]}";
            if (string30.Equals(",") || string30.Equals(")")) {
                i28++;
            } else if (i28 == i) {
                string27 = "" + string27 + string30;
            }
        }
        return string27;
    }
}

}