using System;
using System.Globalization;
using System.Windows.Data;

namespace ScoreReader.Client.Wpf.Common.Converters
{
    public class BooleanToInverseBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !(bool?)value ?? true;
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
