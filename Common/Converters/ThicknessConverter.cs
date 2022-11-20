using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Data;
using Common.Properties;

namespace Common.Converters
{
    public class ThicknessConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || !(value is float thickness))
                return DependencyProperty.UnsetValue;

            return thickness.ToString($"0.00 {Resources.MilimetersShort}");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || !(value is string thickness))
                return DependencyProperty.UnsetValue;
            var match = Regex.Match(thickness.Replace(',', '.'), @"[0-9]*\.?[0-9]+");
            if (match.Success)
                return float.Parse(match.Groups[0].Value, CultureInfo.InvariantCulture);


            return DependencyProperty.UnsetValue;
        }
    }
}
