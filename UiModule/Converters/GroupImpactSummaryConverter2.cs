using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using BusinessLogic;

namespace UiModule.Converters
{
    public class GroupImpactSummaryConverter2 : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || !(value is CollectionViewGroup collectionViewGroup))
                return DependencyProperty.UnsetValue;

            var isCostImpact = parameter != null && parameter is bool boolParam && boolParam;
            var type = (QuoteElementType)collectionViewGroup.Name;
            //don't use collectionViewGroup to calculate summary values to avoid duplicate calculations
            var impactSum = MainViewModel.Instance.QuoteViewModel.GetSummary(type, isCostImpact);
            
            return isCostImpact ? CostImpactConverter.CostImpactToString(impactSum) : TimeImpactConverter.TimeImpactToString(impactSum);
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
