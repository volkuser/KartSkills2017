using System;
using System.Globalization;
using System.Reflection;
using Avalonia;
using Avalonia.Data.Converters;
using Avalonia.Media.Imaging;
using Avalonia.Platform;

namespace App.Views.Converters;

public class BitmapValueConverter : IValueConverter
{
    public static BitmapValueConverter Instance = new();

    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        switch (value)
        {
            case null:
                return null;
            case string rawUri when targetType.IsAssignableFrom(typeof(Bitmap)):
            {
                Uri? uri;

                // Allow for assembly overrides
                if (rawUri.StartsWith("avares://"))
                {
                    uri = new Uri(rawUri);
                }
                else if (rawUri.StartsWith("/Assets/"))
                {
                    string? assemblyName = Assembly.GetEntryAssembly()?.GetName().Name;
                    uri = new Uri($"avares://{assemblyName}{rawUri}");
                }
                else return new Bitmap(rawUri);

                var assets = AvaloniaLocator.Current.GetService<IAssetLoader>();
                var asset = assets?.Open(uri);

                return new Bitmap(asset);
            }
            default:
                throw new NotSupportedException();
        }
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }
}