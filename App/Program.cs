using Avalonia;
using Avalonia.ReactiveUI;
using System;
using App.Views;
using Avalonia.Controls;

namespace App
{
    class Program
    {
        public static Button BtnBack;
        
        [STAThread]
        public static void Main(string[] args) => BuildAvaloniaApp()
            .StartWithClassicDesktopLifetime(args);

        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .LogToTrace()
                .UseReactiveUI();
    }
}