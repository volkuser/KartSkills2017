using System;
using System.Globalization;
using System.Reflection;
using Avalonia;
using Avalonia.Data.Converters;
using Avalonia.Media.Imaging;
using Avalonia.Platform;

namespace App.Views;

public class BitmapValueConverter : IValueConverter
{
    public static BitmapValueConverter Instance = new BitmapValueConverter();

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value == null) return null;

        if (value is string rawUri && targetType.IsAssignableFrom(typeof(Bitmap)))
        {
            Uri uri = null;

            // Allow for assembly overrides
            if (rawUri.StartsWith("avares://"))
            {
                uri = new Uri(rawUri);
            }
            else if (rawUri.StartsWith("/Assets/"))
            {
                string assemblyName = Assembly.GetEntryAssembly().GetName().Name;
                uri = new Uri($"avares://{assemblyName}{rawUri}");
            }
            else return new Bitmap((string)value);

            var assets = AvaloniaLocator.Current.GetService<IAssetLoader>();
            var asset = assets.Open(uri);

            return new Bitmap(asset);
        }

        throw new NotSupportedException();
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }
}