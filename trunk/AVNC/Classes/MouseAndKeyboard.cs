using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Text;

namespace AVNC.Classes
{
    public class SendMK
    {
        [DllImport("user32.dll")]
        static extern bool SetCursorPos(int X, int Y);

        [DllImport("user32.dll")]
        static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData,  int dwExtraInfo);

        [Flags]
        public enum MouseEventFlags
        {
            LEFTDOWN   = 0x00000002,
            LEFTUP     = 0x00000004,
            MIDDLEDOWN = 0x00000020,
            MIDDLEUP   = 0x00000040,
            MOVE       = 0x00000001,
            ABSOLUTE   = 0x00008000,
            RIGHTDOWN  = 0x00000008,
            RIGHTUP    = 0x00000010
        }

        public SendMK()
        {

        }

        public static void sendMouseR(int x, int y)
        {
            SetCursorPos(x, y);
            mouse_event((uint)MouseEventFlags.RIGHTDOWN, 0, 0, 0, 0);
            mouse_event((uint)MouseEventFlags.RIGHTUP, 0, 0, 0, 0);
        }

        public static void sendMouseL(int x, int y)
        {
            SetCursorPos(x, y);
            mouse_event((uint)MouseEventFlags.LEFTDOWN, 0, 0, 0, 0);
            mouse_event((uint)MouseEventFlags.LEFTUP, 0, 0, 0, 0);
        }

        public static void sendDrag(int startx, int endx, int starty, int endy, int button)
        {
            uint buttonDN = (uint)MouseEventFlags.RIGHTDOWN;
            uint buttonUP = (uint)MouseEventFlags.RIGHTUP;

            if (button == 1)
            {
                buttonDN = (uint)MouseEventFlags.LEFTDOWN;
                buttonUP = (uint)MouseEventFlags.LEFTUP;
            }

            SetCursorPos(startx, starty);
            System.Threading.Thread.Sleep(10);

            mouse_event(buttonDN, 0, 0, 0, 0);
            System.Threading.Thread.Sleep(10);

            SetCursorPos(endx, endy);
            System.Threading.Thread.Sleep(10);

            mouse_event(buttonUP, 0, 0, 0, 0);
        }

        public static void sendKeystroke(string key)
        {
            //byte[] b = { Convert.ToByte(key) };
            //string str = Encoding.ASCII.GetString(b);

            SendKeys.SendWait(key);
        }
    }
}