using System;
using System.Globalization;
using System.Windows.Data;

namespace ScoreReader.Client.Wpf.Common.Converters
{
    public class BooleanToOpacityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? 1 : 0.4;
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}