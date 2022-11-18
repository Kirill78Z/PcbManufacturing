using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Automation.Provider;
using System.Windows.Data;

namespace Common.Converters
{
    public class CostImpactConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || !(value is double costImpact))
                return DependencyProperty.UnsetValue;

            return CostImpactToString(costImpact);
        }

        public static string CostImpactToString(double impactSum)
        {
            return impactSum.ToString("$0.00");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
