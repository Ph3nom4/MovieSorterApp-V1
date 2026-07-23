using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

public class NoScrollFlowLayoutPanel : FlowLayoutPanel 
{
    [DllImport("user32.dll")]
    private static extern bool ShowScrollBar(IntPtr hWnd, int wBar, bool bShow);

    private const int SB_BOTH = 3;

    protected override void OnHandleCreated(EventArgs e)
    {
        base.OnHandleCreated(e);
        ShowScrollBar(this.Handle, SB_BOTH, false);
    }

    protected override void WndProc(ref Message m)
    {
        base.WndProc(ref m);

        // Hide the scrollbars after Windows redraws them
        ShowScrollBar(this.Handle, SB_BOTH, false);
    }
}