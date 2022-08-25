using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using Avalonia;
using Avalonia.Data.Converters;
using Avalonia.Platform;

namespace App.Views.Converters;

public class TextValueConverter : IValueConverter
{
    public static TextValueConverter Instance = new();

    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        switch (value)
        {
            case null:
                return null;
            case string rawUri when targetType.IsAssignableFrom(typeof(string)):
            {
                Uri? uri = null;

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

                var assets = AvaloniaLocator.Current.GetService<IAssetLoader>();
                if (uri != null)
                {
                    var asset = assets?.Open(uri);

                    if (asset != null)
                    {
                        using var streamReader = new StreamReader(asset, Encoding.UTF8);
                        var result = streamReader.ReadToEnd();
                        streamReader.Close();

                        return result;
                    }
                }

                break;
            }
            default:
                throw new NotSupportedException();
        }

        throw new InvalidOperationException();
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }
}