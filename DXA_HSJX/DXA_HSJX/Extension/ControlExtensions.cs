using System;
using System.Windows.Forms;

namespace DXA_HSJX
{
    public static class ControlExtensions
    {
        public static Control InvokeAsync(this Control ctl, Action action)
        {
            if (ctl.InvokeRequired)
            {
                ctl.BeginInvoke(action);
            }
            else
            {
                action();
            }
            return ctl;
        }
    }
}
