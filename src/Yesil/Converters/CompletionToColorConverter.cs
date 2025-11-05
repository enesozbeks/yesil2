using System.Globalization;

namespace Yesil.Converters;

public class CompletionToColorConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is bool tamamlandi && tamamlandi)
        {
            return Color.FromArgb("#1FAB54");
        }
        return Color.FromArgb("#B71C1C");
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        => throw new NotSupportedException();
}
