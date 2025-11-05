using System;

namespace Yesil.WinUI;

public static class Program
{
    [STAThread]
    public static void Main(string[] args)
    {
        var app = new App();
        app.Run(args);
    }
}
