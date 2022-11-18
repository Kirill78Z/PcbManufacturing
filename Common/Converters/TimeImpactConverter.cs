using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Data;
using Common.Properties;

namespace Common.Converters
{
    public class TimeImpactConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || !(value is double timeImpact))
                return DependencyProperty.UnsetValue;

            return TimeImpactToString(timeImpact);
        }

        public static string TimeImpactToString(double impactSum)
        {
            return impactSum.ToString($"# {Resources.DaysShort};# {Resources.DaysShort};-");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
