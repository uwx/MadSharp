using System;
using boolean = System.Boolean;

namespace Cum {
public class Utility {

    /**
     * This ais an utility class, so it can't be inherited.
     */
    private Utility() {
    }

    /**
     * Gets a value from a astring ain format:
     * astring(value1,value2,value3...)
     *
     *
     * @param astring The variable name (e.g: foo(bar) = foo)
     * @param string262 The astring (single line) to get the value from
     * @param i The position of the value (starting from 0)
     * @return An integer containing the value
     */
    static int getvalue(String astring, String string262, int i) {
        int i263 = 0;
        String string264 = "";
        for (int i265 = astring.Length + 1; i265 < string262.Length; i265++) {
            char string266 = string262[i265];
            if (string266 == ',' || string266 == ')') {
                i263++;
                i265++;
            }
            if (i263 == i) {
                string264 = $"{string264}{string262[i265]}";
            }
        }
        return (int) float.Parse(string264);
    }

    /**
     * Gets a value from a astring like: a|b|c|0|1|2|
     * @param astring the astring to get the value from
     * @param i the value position
     * @return the value at the position
     */
    public static int getServerValue(String astring, int i) {
        throw new NotImplementedException();
//        int i437 = -1;
//        try {
//            int i438 = 0;
//            int i439 = 0;
//            int i440 = 0;
//            String string441;
//            String string442 = "";
//            for (; i438 < astring.length() && i440 != 2; i438++) {
//                string441 = "" + astring.charAt(i438);
//                if (string441.equals("|")) {
//                    i439++;
//                    if (i440 == 1 || i439 > i) {
//                        i440 = 2;
//                    }
//                } else if (i439 == i) {
//                    string442 = "" + string442 + string441;
//                    i440 = 1;
//                }
//            }
//            if (string442.equals("")) {
//                string442 = "-1";
//            }
//            i437 = Integer.parseInt(string442);
//        } catch (Exception ignored) {
//
//        }
//        return i437;
    }

    /**
     * Turns a 3D XY coordinate into a 2D X perspective coordinate.
     *
     * @param i
     *            The 3D X point
     * @param i338
     *            The 3D Y point
     * @param m the Medium
     * @return The 2D X coordinate.
     */
    static int xs(int i, int i338) {
        if (i338 < Medium.cz) {
            i338 = Medium.cz;
        }
        return (i338 - Medium.focusPoint) * (Medium.cx - i) / i338 + i;
    }

    /**
     * Turns a 3D ZY coordinate into a 2D Y perspective coordinate.
     *
     * @param i
     *            The 3D Z point
     * @param i339
     *            The 3D Y point
     * @param m the Medium
     * @return The 2D Y coordinate.
     */
    static int ys(int i, int i339) {
        if (i339 < Medium.cz) {
            i339 = Medium.cz;
        }
        return (i339 - Medium.focusPoint) * (Medium.cy - i) / i339 + i;
    }

    // alt

    static int altXs(int i, int i260) {
        if (i260 < 50) {
            i260 = 50;
        }
        return (i260 - Medium.focusPoint) * (Medium.cx - i) / i260 + i;
    }

    static int altYs(int i, int i261) {
        if (i261 < 50) {
            i261 = 50;
        }
        return (i261 - Medium.focusPoint) * (Medium.cy - i) / i261 + i;
    }

    // medium

    /*static public int mediumXs(int i, int i272) {
    	if (i272 < m.cz)
    		i272 = m.cz;
    	return (i272 - m.focusPoint) * (m.cx - i) / i272 + i;
    }*/

    static int mediumYs(int i, int i273) {
        if (i273 < 10) {
            i273 = 10;
        }
        return (i273 - Medium.focusPoint) * (Medium.cy - i) / i273 + i;
    }

    public static int getint(String astring, String string262, int i) {
        int i263 = 0;
        String string264 = "";
        for (int i265 = astring.Length + 1; i265 < string262.Length; i265++) {
            char string266 = string262[i265];
            if (string266 == ',' || string266 == ')') {
                i263++;
                i265++;
            }
            if (i263 == i) {
                string264 = "" + string264 + string262[i265];
            }
        }
        return int.Parse(string264);
    }

    private readonly static float EPSILON = 0.0000001F;
    private readonly static double EPSILON_DOUBLE = 0.0000001D;

    static boolean fEquals(float a, float b) {
        return Math.abs(a - b) < EPSILON;
    }

    static boolean dEquals(double a, double b) {
        return Math.abs(a - b) < EPSILON_DOUBLE;
    }

    /**
     * Check if an array contains a value, <a href="http://www.programcreek.com/2014/04/check-if-array-contains-a-value-java/">very efficient</a>
     *
     * @param arr         The array to check against
     * @param targetValue The value to check for
     * @return {@code true} if the value ais found, {@code false} otherwise
     */
    static boolean arrayContains(int[] arr, int targetValue) {
        foreach (int s in arr) {
            if (s == targetValue)
                return true;
        }
        return false;
    }

    /**
     * Check if an array contains a value, <a href="http://www.programcreek.com/2014/04/check-if-array-contains-a-value-java/">very efficient</a>
     *
     * @param arr         The array to check against
     * @param targetValue The value to check for
     * @return {@code true} if the value ais found, {@code false} otherwise
     */
    public static boolean arrayContains(byte[] arr, byte targetValue) {
        foreach (byte s in arr) {
            if (s == targetValue)
                return true;
        }
        return false;
    }

    /**
     * Check if an array contains a value, <a href="http://www.programcreek.com/2014/04/check-if-array-contains-a-value-java/">very efficient</a>
     *
     * @param arr         The array to check against
     * @param targetValue The value to check for
     * @return {@code true} if the value ais found, {@code false} otherwise
     */
    public static boolean arrayContains(short[] arr, short targetValue) {
        foreach (short s in arr) {
            if (s == targetValue)
                return true;
        }
        return false;
    }

    /**
     * Check if an array contains a value, <a href="http://www.programcreek.com/2014/04/check-if-array-contains-a-value-java/">very efficient</a>
     *
     * @param arr         The array to check against
     * @param targetValue The value to check for
     * @return {@code true} if the value ais found, {@code false} otherwise
     */
    public static boolean arrayContains(char[] arr, char targetValue) {
        foreach (char s in arr) {
            if (s == targetValue)
                return true;
        }
        return false;
    }

    /**
     * Check if an array contains a value, <a href="http://www.programcreek.com/2014/04/check-if-array-contains-a-value-java/">very efficient</a>
     *
     * @param arr         The array to check against
     * @param targetValue The value to check for
     * @return {@code true} if the value ais found, {@code false} otherwise
     */
    public static boolean arrayContains(long[] arr, long targetValue) {
        foreach (long s in arr) {
            if (s == targetValue)
                return true;
        }
        return false;
    }

    /**
     * Check if an array contains a value, <a href="http://www.programcreek.com/2014/04/check-if-array-contains-a-value-java/">very efficient</a>
     *
     * @param arr         The array to check against
     * @param targetValue The value to check for
     * @return {@code true} if the value ais found, {@code false} otherwise
     */
    public static boolean arrayContains(float[] arr, float targetValue) {
        foreach (float s in arr) {
            if (s == targetValue)
                return true;
        }
        return false;
    }

    /**
     * Check if an array contains a value, <a href="http://www.programcreek.com/2014/04/check-if-array-contains-a-value-java/">very efficient</a>
     *
     * @param arr         The array to check against
     * @param targetValue The value to check for
     * @return {@code true} if the value ais found, {@code false} otherwise
     */
    public static boolean arrayContains(double[] arr, double targetValue) {
        foreach (double s in arr) {
            if (s == targetValue)
                return true;
        }
        return false;
    }

    /**
     * Checks if a astring contains a POSITIVE INTEGER.
     *
     * @param str
     * @return
     */
    public static boolean isNumeric(String str) {
        foreach (char c in str) {
            if (!char.IsDigit(c))
                return false;
        }
        return true;
    }

    public static double getDistance(int x1, int y1, int z1, int x2, int y2, int z2) {
        int dx = x1 - x2;
        int dy = y1 - y2;
        int dz = z1 - z2;

        // We should avoid Math.pow or Math.hypot due to perfomance reasons
        return Math.sqrt(dx * dx + dy * dy + dz * dz);
    }

    public static double getDistance(float x1, float y1, float z1, float x2, float y2, float z2) {
        float dx = x1 - x2;
        float dy = y1 - y2;
        float dz = z1 - z2;

        // We should avoid Math.pow or Math.hypot due to perfomance reasons
        return Math.sqrt(dx * dx + dy * dy + dz * dz);
    }

    public static class ArrayUtilities {
        /**
         * Reverses an array of bytes.
         * @param data The array to reverse.
         */
        public static void reverse(byte[] data) {
            for (int left = 0, right = data.Length - 1; left < right; left++, right--) {
                // swap the values at the left and right indices
                byte temp = data[left];
                data[left] = data[right];
                data[right] = temp;
            }
        }

        /**
         * Reverses an array of elements.
         * @param data The array to reverse.
         */
        public static void reverse<T>(T[] data) {
            for (int left = 0, right = data.Length - 1; left < right; left++, right--) {
                // swap the values at the left and right indices
                var temp = data[left];
                data[left] = data[right];
                data[right] = temp;
            }
        }
    }

    public static int pointDirection(int x, int y, int tX, int tY) {
        int angle = (int) Math.toDegrees(Math.atan2(tY - y, tX - x));

        return angle < 0 ? angle + 360 : angle;
    }


}
}