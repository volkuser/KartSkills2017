using Avalonia;
using Avalonia.ReactiveUI;
using System;
using System.Globalization;
using System.Threading;
using Avalonia.Controls;

namespace App
{
    class Program
    { 
        public static Button BtnBack;

        [STAThread]
        public static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("ru-RU");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("ru-RU");
            BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
        }

        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .LogToTrace()
                .UseReactiveUI();
    }
}