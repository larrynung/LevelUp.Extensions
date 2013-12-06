using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

public static class ButtonExtension
{
    #region DllImport
    [DllImport("shell32.dll", EntryPoint = "#680", CharSet = CharSet.Unicode)]
    private static extern bool IsUserAnAdmin();

    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
    private static extern IntPtr SendMessage(HandleRef hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
    #endregion


    #region Const
    const int BCM_SETSHIELD = 0x0000160C;
    #endregion


    #region Private Method
    private static bool AtLeastVista()
    {
        return (Environment.OSVersion.Platform == PlatformID.Win32NT && Environment.OSVersion.Version.Major >= 6);
    }  

    public static void SetButtonShield(Button btn, bool showShield)
    {
        if (!AtLeastVista())
            return;

        btn.FlatStyle = FlatStyle.System;
        SendMessage(new HandleRef(btn, btn.Handle), BCM_SETSHIELD, IntPtr.Zero, showShield ? new IntPtr(1) : IntPtr.Zero);
    }
    #endregion


    #region Public Method
    public static void EnableShieldIcon(this Button button)
    {
        SetButtonShield(button, true);
    } 
    #endregion
}