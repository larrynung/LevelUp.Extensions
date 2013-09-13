﻿using System;
using System.Reflection;
using System.Windows.Forms;

public static class NotifyIconExtension
{
    public static void SetNotifyIconText(this NotifyIcon ni, string text)
    {
        if (text.Length >= 128) throw new ArgumentOutOfRangeException("Text limited to 127 characters");
        Type t = typeof(NotifyIcon);
        BindingFlags hidden = BindingFlags.NonPublic | BindingFlags.Instance;
        t.GetField("text", hidden).SetValue(ni, text);
        if ((bool)t.GetField("added", hidden).GetValue(ni))
            t.GetMethod("UpdateIcon", hidden).Invoke(ni, new object[] { true });
    }
}
