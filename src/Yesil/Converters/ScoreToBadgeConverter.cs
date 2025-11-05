using System.Globalization;

namespace Yesil.Converters;

public class ScoreToBadgeConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is double skor)
        {
            if (skor >= 90)
            {
                return "Altın";
            }
            if (skor >= 75)
            {
                return "Gümüş";
            }
            return "Bronz";
        }

        return "Belirsiz";
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        => throw new NotSupportedException();
}
