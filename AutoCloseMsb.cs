using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Timer = System.Threading.Timer;

namespace Poker
{
    public class AutoCloseMsb
    {
        readonly string _caption;

        private AutoCloseMsb(string text, string caption, int timeout)
        {
            _caption = caption;
            var timeoutTimer = new Timer(OnTimerElapsed,
                null, timeout, Timeout.Infinite);
            MessageBox.Show(text, caption);
            timeoutTimer.Change(Timeout.Infinite, Timeout.Infinite);
            timeoutTimer.Dispose();
        }
        public static void Show(string text, string caption, int timeout) => new AutoCloseMsb(text, caption, timeout);

        private void OnTimerElapsed(object state)
        {
            IntPtr mbWnd = FindWindow("#32770", _caption);
            if (mbWnd != IntPtr.Zero)
                SendMessage(mbWnd, WmClose, IntPtr.Zero, IntPtr.Zero);
        }

        private const int WmClose = 0x0010;
        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);
    }
}
