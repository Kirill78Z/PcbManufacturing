using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Data;
using BusinessLogic;
using UiModule.Properties;

namespace UiModule.Converters
{
    public class GroupImpactSummaryConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || !(value is CollectionViewGroup collectionViewGroup))
                return DependencyProperty.UnsetValue;

            var impactSum = 0.0;
            var isCostImpact = parameter != null && parameter is bool boolParam && boolParam;
            foreach (var item in collectionViewGroup.Items)
            {
                if (!(item is QuoteElement quoteElement))
                    continue;
                impactSum += isCostImpact ? quoteElement.CostImpact : quoteElement.TimeImpact;
            }
            return isCostImpact ? CostImpactConverter.CostImpactToString(impactSum) : TimeImpactConverter.TimeImpactToString(impactSum);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
