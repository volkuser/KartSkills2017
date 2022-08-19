using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using Avalonia;
using Avalonia.Data.Converters;
using Avalonia.Platform;

namespace App.Views;

public class TextValueConverter : IValueConverter
{
    public static TextValueConverter Instance = new TextValueConverter();

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value == null) return null;

        if (value is string rawUri && targetType.IsAssignableFrom(typeof(string)))
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

            var assets = AvaloniaLocator.Current.GetService<IAssetLoader>();
            var asset = assets.Open(uri);

            using var streamReader = new StreamReader(asset, Encoding.UTF8);
            var result = streamReader.ReadToEnd();
            streamReader.Close();

            return result;
        }

        throw new NotSupportedException();
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }
}