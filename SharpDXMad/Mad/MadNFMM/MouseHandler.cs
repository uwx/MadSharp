package nfm.open;
/* MouseHandler - Decompiled by JODE
 * Visit http://jode.sourceforge.net/
 */
import java.awt.PopupMenu;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;

class MouseHandler extends MouseAdapter {
    private final int id;
    private final PopupMenu popupMenu;

    public MouseHandler(final PopupMenu popupmenu, final int i) {
        popupMenu = popupmenu;
        id = i;
    }

    @Override
    public void mousePressed(final MouseEvent mouseevent) {
        if (mouseevent.isPopupTrigger()) {
            popupMenu.show(mouseevent.getComponent(), mouseevent.getX(), mouseevent.getY());
            Madness.textid = id;
            mouseevent.consume();
        }
    }

    @Override
    public void mouseReleased(final MouseEvent mouseevent) {
        if (mouseevent.isPopupTrigger()) {
            popupMenu.show(mouseevent.getComponent(), mouseevent.getX(), mouseevent.getY());
            Madness.textid = id;
            mouseevent.consume();
        }
    }
}
