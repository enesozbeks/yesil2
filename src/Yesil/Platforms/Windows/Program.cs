using System;
using Microsoft.UI.Xaml;

namespace Yesil.WinUI;

public static class Program
{
    [STAThread]
    public static void Main(string[] args)
    {
        MauiWinUIApplication.Main(args, typeof(App));
    }
}
