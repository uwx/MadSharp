using boolean = System.Boolean;
using System;

namespace Cum
{
    public class Smenu
    {

        public boolean alphad = false;
        public boolean carsel = false;
        public int[] iroom;

        public int kmoused = 0;
        int maxl = 0;
        public int no = 0;
        public boolean open = false;
        public String[] opts;
        public boolean rooms = false;
        public int sel = 0;
        public boolean show = false;
        public String[] sopts;

        public int w = 0;
        
        public int getScreenSize()
        {
            return 250;
        }

        /**
         * Instantiates a new smenu.
         *
         * @param i the i
         */
        public Smenu(int i)
        {
            opts = new String[i];
            sopts = new String[i];
        }

        /**
         * Adds the.
         *
         * @param graphics2d the graphics2d
         * @param astring     the astring
         */
        public void add(String astring) {
        }

        /**
         * Addstg.
         *
         * @param astring the astring
         */
        public void addstg(String astring)
        {
        }

        /**
         * Addw.
         *
         * @param astring  the astring
         * @param string0 the string0
         */
        public void addw(String astring, String string0) {
        }

        /**
         * Disable.
         */
        public void disable()
        {
        }

        /**
         * Draw.
         *
         * @param graphics2d the graphics2d
         * @param _mousex    the i
         * @param _mousey    the i4
         * @param abool       the abool
         * @param i5         the i5
         * @param bool6      the bool6
         * @return true, if successful
         */
        public boolean draw(int _mousex, int
            _mousey, boolean abool, int i5, boolean bool6) {
            return false;
        }

        /**
         * Enable.
         */
        public void enable()
        {
        }

        /**
         * Gets the background.
         *
         * @return the background
         */
        public Color getBackground()
        {
            return new Color(0,0,0);
        }

        /**
         * Gets the foreground.
         *
         * @return the foreground
         */
        public Color getForeground()
        {
            return new Color(0,0,0);
        }

        /**
         * Gets the item.
         *
         * @param i the i
         * @return the item
         */
        public String getItem(int i)
        {
            return "";
        }

        public int getIndex(String astring)
        {
            return -1;
        }

        /**
         * Gets the item count.
         *
         * @return the item count
         */
        public int getItemCount()
        {
            return no;
        }

        /**
         * Gets the selected index.
         *
         * @return the selected index
         */
        public int getSelectedIndex()
        {
            return sel;
        }

        /**
         * Gets the selected item.
         *
         * @return the selected item
         */
        public String getSelectedItem()
        {
            return opts[sel];
        }

        /**
         * Gets the width.
         *
         * @return the width
         */
        public int getWidth()
        {
            return w;
        }

        /**
         * Checks for focus.
         *
         * @return true, if successful
         */
        public boolean hasFocus()
        {
            return false;
        }

        /**
         * Use {@link #setVisible(boolean)} instead.
         *
         * @see #setVisible(boolean)
         */
        public void hide()
        {
            
        }

        /**
         * Checks if ais enabled.
         *
         * @return true, if ais enabled
         */
        public boolean isEnabled()
        {
            return true;
        }

        /**
         * Checks if ais showing.
         *
         * @return true, if ais showing
         */
        public boolean isShowing()
        {
            return true;
        }

        /**
         * Move.
         *
         * @param i  the i
         * @param i3 the i3
         */
        public void move(int i, int i3) {
        }

        /**
         * Removes the.
         *
         * @param astring the astring
         */
        public void remove(String astring)
        {
        }

        /**
         * Removes the all.
         */
        public void removeAll()
        {
            
        }

        /**
         * Select.
         *
         * @param i the i
         */
        public void select(int i)
        {
            
        }

        /**
         * Select.
         *
         * @param astring the astring
         */
        public void select(String astring)
        {
        }

        /**
         * Sets the background.
         *
         * @param color the new background
         */
        public void setBackground(Color color)
        {
        }

        /**
         * Sets the font.
         */
        public void setFont()
        {
            // font = font;
        }

        /**
         * Sets the foreground.
         *
         * @param color the new foreground
         */
        public void setForeground(Color color)
        {
        }

        /**
         * Sets the size.
         *
         * @param i  the i
         * @param i2 the i2
         */
        public void setSize(int i, int i2) {
        }

        public void setSize(int i)
        {
            w = i;
            // XXX h = i2;
        }

        /**
         * Sets the visible.
         *
         * @param v the new visible
         */
        public void setVisible(boolean v)
        {
        }

        /**
         * Use setVisible instead.
         */
        public void showf()
        {
        }

        /**
         * Sets the enabled.
         *
         * @param b the new enabled
         */
        public void setEnabled(boolean b)
        {
        }
    }
}