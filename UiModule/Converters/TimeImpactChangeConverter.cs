using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Data;
using UiModule.Properties;

namespace UiModule.Converters
{
    public class TimeImpactChangeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || !(value is double timeImpact))
                return DependencyProperty.UnsetValue;

            return TmeImpactToString(timeImpact);
        }

        public static string TmeImpactToString(double timeImpact)
        {
            return timeImpact.ToString($"+# {Resources.DaysShort};-# {Resources.DaysShort};#");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
