package nfm.open;

import javax.swing.*;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.util.Map;
import java.util.Objects;
import java.util.Vector;
import java.util.concurrent.ThreadLocalRandom;
import java.util.zip.ZipEntry;
import java.util.zip.ZipInputStream;

public final class Utility {

    /**
     * This is an utility class, so it can't be inherited.
     */
    private Utility() {
    }

    /**
     * Gets a value from a string in format:
     * string(value1,value2,value3...)
     *
     *
     * @param string The variable name (e.g: foo(bar) = foo)
     * @param string262 The string (single line) to get the value from
     * @param i The position of the value (starting from 0)
     * @return An integer containing the value
     */
    static int getvalue(final String string, final String string262, final int i) {
        int i263 = 0;
        String string264 = "";
        for (int i265 = string.length() + 1; i265 < string262.length(); i265++) {
            final String string266 = "" + string262.charAt(i265);
            if (string266.equals(",") || string266.equals(")")) {
                i263++;
                i265++;
            }
            if (i263 == i) {
                string264 = "" + string264 + string262.charAt(i265);
            }
        }
        return (int) Float.parseFloat(string264);
    }

    /**
     * Gets a value from a string like: a|b|c|0|1|2|
     * @param string the string to get the value from
     * @param i the value position
     * @return the value at the position
     */
    public static int getServerValue(final String string, final int i) {
        int i437 = -1;
        try {
            int i438 = 0;
            int i439 = 0;
            int i440 = 0;
            String string441;
            String string442 = "";
            for (; i438 < string.length() && i440 != 2; i438++) {
                string441 = "" + string.charAt(i438);
                if (string441.equals("|")) {
                    i439++;
                    if (i440 == 1 || i439 > i) {
                        i440 = 2;
                    }
                } else if (i439 == i) {
                    string442 = "" + string442 + string441;
                    i440 = 1;
                }
            }
            if (string442.equals("")) {
                string442 = "-1";
            }
            i437 = Integer.parseInt(string442);
        } catch (final Exception ignored) {

        }
        return i437;
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
    static int xs(final int i, int i338) {
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
    static int ys(final int i, int i339) {
        if (i339 < Medium.cz) {
            i339 = Medium.cz;
        }
        return (i339 - Medium.focusPoint) * (Medium.cy - i) / i339 + i;
    }

    // alt

    static int altXs(final int i, int i260) {
        if (i260 < 50) {
            i260 = 50;
        }
        return (i260 - Medium.focusPoint) * (Medium.cx - i) / i260 + i;
    }

    static int altYs(final int i, int i261) {
        if (i261 < 50) {
            i261 = 50;
        }
        return (i261 - Medium.focusPoint) * (Medium.cy - i) / i261 + i;
    }

    // medium

    /*static public int mediumXs(final int i, int i272) {
    	if (i272 < m.cz)
    		i272 = m.cz;
    	return (i272 - m.focusPoint) * (m.cx - i) / i272 + i;
    }*/

    static int mediumYs(final int i, int i273) {
        if (i273 < 10) {
            i273 = 10;
        }
        return (i273 - Medium.focusPoint) * (Medium.cy - i) / i273 + i;
    }

    public static int getint(final String string, final String string262, final int i) {
        int i263 = 0;
        String string264 = "";
        for (int i265 = string.length() + 1; i265 < string262.length(); i265++) {
            final String string266 = "" + string262.charAt(i265);
            if (string266.equals(",") || string266.equals(")")) {
                i263++;
                i265++;
            }
            if (i263 == i) {
                string264 = "" + string264 + string262.charAt(i265);
            }
        }
        return Integer.parseInt(string264);
    }

    private final static float EPSILON = 0.0000001F;
    private final static double EPSILON_DOUBLE = 0.0000001D;

    static boolean fEquals(final float a, final float b) {
        return Math.abs(a - b) < EPSILON;
    }

    static boolean dEquals(final double a, final double b) {
        return Math.abs(a - b) < EPSILON_DOUBLE;
    }

    /**
     * Check if an array contains a value, <a href="http://www.programcreek.com/2014/04/check-if-array-contains-a-value-java/">very efficient</a>
     *
     * @param arr         The array to check against
     * @param targetValue The value to check for
     * @return {@code true} if the value is found, {@code false} otherwise
     */
    public static <E> boolean arrayContains(final E[] arr, final E targetValue) {
        for (final E s : arr) {
            if (s.equals(targetValue))
                return true;
        }
        return false;
    }

    /**
     * Check if an array contains a value, <a href="http://www.programcreek.com/2014/04/check-if-array-contains-a-value-java/">very efficient</a>
     *
     * @param arr         The array to check against
     * @param targetValue The value to check for
     * @return {@code true} if the value is found, {@code false} otherwise
     */
    static boolean arrayContains(final int[] arr, final int targetValue) {
        for (final int s : arr) {
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
     * @return {@code true} if the value is found, {@code false} otherwise
     */
    public static boolean arrayContains(final byte[] arr, final byte targetValue) {
        for (final byte s : arr) {
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
     * @return {@code true} if the value is found, {@code false} otherwise
     */
    public static boolean arrayContains(final short[] arr, final short targetValue) {
        for (final short s : arr) {
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
     * @return {@code true} if the value is found, {@code false} otherwise
     */
    public static boolean arrayContains(final char[] arr, final char targetValue) {
        for (final char s : arr) {
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
     * @return {@code true} if the value is found, {@code false} otherwise
     */
    public static boolean arrayContains(final long[] arr, final long targetValue) {
        for (final long s : arr) {
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
     * @return {@code true} if the value is found, {@code false} otherwise
     */
    public static boolean arrayContains(final float[] arr, final float targetValue) {
        for (final float s : arr) {
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
     * @return {@code true} if the value is found, {@code false} otherwise
     */
    public static boolean arrayContains(final double[] arr, final double targetValue) {
        for (final double s : arr) {
            if (s == targetValue)
                return true;
        }
        return false;
    }


    /**
     * Unsafe subclass of ByteArrayOutputStream that doesn't copy array on output
     *
     * @author http://stackoverflow.com/users/80002/mark
     */
    public static class UnsafeByteArrayOutputStream extends ByteArrayOutputStream {

        public UnsafeByteArrayOutputStream() {
        }

        public UnsafeByteArrayOutputStream(final int size) {
            super(size);
        }

        public int getByteCount() {
            return count;
        }

        public byte[] getDataBuffer() {
            return buf;
        }
    }

    /* for proper .length access and stuff */
    public static UnsafeByteArrayOutputStream streamNoSize(final ZipInputStream zipinputstream, final ZipEntry zipentry, final int entrySize) throws IOException {
        final UnsafeByteArrayOutputStream bytes = new UnsafeByteArrayOutputStream(entrySize < 0 ? 8192 : entrySize);
        System.out.println(zipentry.getName() + "; size = " + zipentry.getSize());

        while (true) {
            final int b = zipinputstream.read();
            if (b == -1) {
                break;
            }
            bytes.write(b);
        }
        return bytes;
    }


    /**
     * Checks if a string contains a POSITIVE INTEGER.
     *
     * @param str
     * @return
     */
    public static boolean isNumeric(final String str) {
        for (final char c : str.toCharArray()) {
            if (!Character.isDigit(c))
                return false;
        }
        return true;
    }

    public static <T, E> T getKeyByValue(final Map<T, E> map, final E value) {
        for (final Map.Entry<T, E> entry : map.entrySet()) {
            if (Objects.equals(value, entry.getValue()))
                return entry.getKey();
        }
        return null;
    }

    public static <E> boolean listModelEquals(final ListModel<E> lm, final ListModel<E> lm2) {
        for (int i = 0; i < lm.getSize(); i++) {
            if (!lm.getElementAt(i).equals(lm2.getElementAt(i)))
                return false;
        }
        return true;
    }

    public static <E> boolean listModelEquals(final ListModel<E> lm, final E[] e2) {
        for (int i = 0; i < lm.getSize(); i++) {
            if (!lm.getElementAt(i).equals(e2))
                return false;
        }
        return true;
    }

    public static <E> boolean listModelEquals(final ListModel<E> lm, final Vector<E> lm2) {
        for (int i = 0; i < lm.getSize(); i++) {
            if (!lm.getElementAt(i).equals(lm2.elementAt(i)))
                return false;
        }
        return false;
    }

//    /**
//     * Pick an item from an array.
//     *
//     * @param is The array.
//     * @return The item.
//     * @author Rafael
//     */
//    public static int choose(final int... is) {
//        return is[ThreadLocalRandom.current().nextInt(is.length)];
//    }

    /**
     * Pick an item from an array.
     *
     * @param is The array.
     * @return The item.
     * @author Rafael
     */
    @SafeVarargs
    public static <E> E choose(final E... is) {
        return is[ThreadLocalRandom.current().nextInt(is.length)];
    }

    public static double getDistance(final int x1, final int y1, final int z1, final int x2, final int y2, final int z2) {
        final int dx = x1 - x2;
        final int dy = y1 - y2;
        final int dz = z1 - z2;

        // We should avoid Math.pow or Math.hypot due to perfomance reasons
        return Math.sqrt(dx * dx + dy * dy + dz * dz);
    }

    public static double getDistance(final float x1, final float y1, final float z1, final float x2, final float y2, final float z2) {
        final float dx = x1 - x2;
        final float dy = y1 - y2;
        final float dz = z1 - z2;

        // We should avoid Math.pow or Math.hypot due to perfomance reasons
        return Math.sqrt(dx * dx + dy * dy + dz * dz);
    }

    public static class ArrayUtilities {
        /**
         * Reverses an array of bytes.
         * @param data The array to reverse.
         */
        public static void reverse(byte[] data) {
            for (int left = 0, right = data.length - 1; left < right; left++, right--) {
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
        public static <E> void reverse(E[] data) {
            for (int left = 0, right = data.length - 1; left < right; left++, right--) {
                // swap the values at the left and right indices
                E temp = data[left];
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
