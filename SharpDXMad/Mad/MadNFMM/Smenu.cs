using boolean = System.Boolean;

namespace Cum
{
    public class Smenu
    {
        public bool Alphad = false;
        public bool Carsel = false;
        public int[] Iroom;

        public int Kmoused = 0;
        int _maxl = 0;
        public int No = 0;
        public bool Open = false;
        public string[] Opts;
        public bool Rooms = false;
        public int Sel = 0;
        public bool Show = false;
        public string[] Sopts;

        public int W;

        public int GetScreenSize()
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
            Opts = new string[i];
            Sopts = new string[i];
        }

        /**
         * Adds the.
         *
         * @param graphics2d the graphics2d
         * @param astring     the astring
         */
        public void Add(string astring)
        {
        }

        /**
         * Addstg.
         *
         * @param astring the astring
         */
        public void Addstg(string astring)
        {
        }

        /**
         * Addw.
         *
         * @param astring  the astring
         * @param string0 the string0
         */
        public void Addw(string astring, string string0)
        {
        }

        /**
         * Disable.
         */
        public void Disable()
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
        public bool Draw(int mousex, int
            mousey, bool abool, int i5, bool bool6)
        {
            return false;
        }

        /**
         * Enable.
         */
        public void Enable()
        {
        }

        /**
         * Gets the background.
         *
         * @return the background
         */
        public Color GetBackground()
        {
            return new Color(0, 0, 0);
        }

        /**
         * Gets the foreground.
         *
         * @return the foreground
         */
        public Color GetForeground()
        {
            return new Color(0, 0, 0);
        }

        /**
         * Gets the item.
         *
         * @param i the i
         * @return the item
         */
        public string GetItem(int i)
        {
            return "";
        }

        public int GetIndex(string astring)
        {
            return -1;
        }

        /**
         * Gets the item count.
         *
         * @return the item count
         */
        public int GetItemCount()
        {
            return No;
        }

        /**
         * Gets the selected index.
         *
         * @return the selected index
         */
        public int GetSelectedIndex()
        {
            return Sel;
        }

        /**
         * Gets the selected item.
         *
         * @return the selected item
         */
        public string GetSelectedItem()
        {
            return Opts[Sel];
        }

        /**
         * Gets the width.
         *
         * @return the width
         */
        public int GetWidth()
        {
            return W;
        }

        /**
         * Checks for focus.
         *
         * @return true, if successful
         */
        public bool HasFocus()
        {
            return false;
        }

        /**
         * Use {@link #setVisible(boolean)} instead.
         *
         * @see #setVisible(boolean)
         */
        public void Hide()
        {
        }

        /**
         * Checks if ais enabled.
         *
         * @return true, if ais enabled
         */
        public bool IsEnabled()
        {
            return true;
        }

        /**
         * Checks if ais showing.
         *
         * @return true, if ais showing
         */
        public bool IsShowing()
        {
            return true;
        }

        /**
         * Move.
         *
         * @param i  the i
         * @param i3 the i3
         */
        public void Move(int i, int i3)
        {
        }

        /**
         * Removes the.
         *
         * @param astring the astring
         */
        public void Remove(string astring)
        {
        }

        /**
         * Removes the all.
         */
        public void RemoveAll()
        {
        }

        /**
         * Select.
         *
         * @param i the i
         */
        public void Select(int i)
        {
        }

        /**
         * Select.
         *
         * @param astring the astring
         */
        public void Select(string astring)
        {
        }

        /**
         * Sets the background.
         *
         * @param color the new background
         */
        public void SetBackground(Color color)
        {
        }

        /**
         * Sets the font.
         */
        public void SetFont()
        {
            // font = font;
        }

        /**
         * Sets the foreground.
         *
         * @param color the new foreground
         */
        public void SetForeground(Color color)
        {
        }

        /**
         * Sets the size.
         *
         * @param i  the i
         * @param i2 the i2
         */
        public void SetSize(int i, int i2)
        {
        }

        public void SetSize(int i)
        {
            W = i;
            // XXX h = i2;
        }

        /**
         * Sets the visible.
         *
         * @param v the new visible
         */
        public void SetVisible(bool v)
        {
        }

        /**
         * Use setVisible instead.
         */
        public void Showf()
        {
        }

        /**
         * Sets the enabled.
         *
         * @param b the new enabled
         */
        public void SetEnabled(bool b)
        {
        }
    }
}