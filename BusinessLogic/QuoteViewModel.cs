using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace BusinessLogic
{
    public interface IQuoteViewModel
    {
        void UpdateQuote(IPreferencesViewModel preferences);
    }
    public class QuoteViewModel : ViewModelBase, IQuoteViewModel
    {
        private double _timeImpactSummary;
        private double _costImpactSummary;
        public ObservableCollection<QuoteElement> QuoteElements { get; } = new ObservableCollection<QuoteElement>();


        public double TimeImpactSummary
        {
            get => _timeImpactSummary;
        }

        public double CostImpactSummary
        {
            get => _costImpactSummary;
        }

        public QuoteViewModel()
        {

        }

        private void UpdateImpactSummary()
        {
            _timeImpactSummary = 0;
            _costImpactSummary = 0;
            foreach (var item in QuoteElements)
            {
                _timeImpactSummary += item.TimeImpact;
                _costImpactSummary += item.CostImpact;
            }
            OnPropertyChanged(nameof(TimeImpactSummary));
            OnPropertyChanged(nameof(CostImpactSummary));
        }

        public void UpdateQuote(IPreferencesViewModel preferences)
        {
            //There we should implement some complex logic for analyzing Preferences somehow and costs calculation for displaying in Quote.
            //But for this test WPF project it is not needed.
            //So we just emulate some interaction between two program entities as a demonstration.

            QuoteElements.Clear();

            QuoteElements.Add(new QuoteElement("Base fabrication", "61.72x148.84mm, 10 layers", 4, 1710, QuoteElementType.Fabrication));
            QuoteElements.Add(new QuoteElement("Boards quantity", preferences.BoardsQuantity, 0, preferences.BoardsQuantity * 26.9, QuoteElementType.Fabrication));
            QuoteElements.Add(new QuoteElement("Surface finish", preferences.SurfaceFinish, preferences.SurfaceFinish.TimeImpact, preferences.SurfaceFinish.CostImpact, QuoteElementType.Fabrication));

            QuoteElements.Add(new QuoteElement("Packages", "Package on Packages", 1, 2679, QuoteElementType.Assembly));
            QuoteElements.Add(new QuoteElement("Processes", "Split Assembly", 0, 720.5, QuoteElementType.Assembly));
            QuoteElements.Add(new QuoteElement("Minimum pitch", "0.3mm pitch BGA", 0, 804, QuoteElementType.Assembly));

            QuoteElements.Add(new QuoteElement("Microchip ATTINY2313-20SU", "2", 0, 48.64, QuoteElementType.Components));
            QuoteElements.Add(new QuoteElement("Microchip ATTINY2313-18PC", "1", 0, 22.12, QuoteElementType.Components));
            QuoteElements.Add(new QuoteElement("Microchip ATTINY2313-18PC", "1", 0, 22.12, QuoteElementType.Components));
            QuoteElements.Add(new QuoteElement("Microchip ATTINY2313-20SU", "2", 0, 48.64, QuoteElementType.Components));
            QuoteElements.Add(new QuoteElement("Microchip ATTINY2313-18PC", "1", 0, 22.12, QuoteElementType.Components));
            QuoteElements.Add(new QuoteElement("Microchip ATTINY2313-18PC", "1", 0, 22.12, QuoteElementType.Components));
            QuoteElements.Add(new QuoteElement("Microchip ATTINY2313-20SU", "2", 0, 48.64, QuoteElementType.Components));
            QuoteElements.Add(new QuoteElement("Microchip ATTINY2313-18PC", "1", 0, 22.12, QuoteElementType.Components));
            QuoteElements.Add(new QuoteElement("Microchip ATTINY2313-18PC", "1", 0, 22.12, QuoteElementType.Components));

            UpdateImpactSummary();
        }
    }

    public class QuoteElement : IImpact
    {
        public string Parameter { get; }
        public object Value { get; }
        public double TimeImpact { get; }
        public double CostImpact { get; }

        public QuoteElementType QuoteElementType { get; }

        public QuoteElement(
            string parameter, object value,
            double timeImpact, double costImpact,
            QuoteElementType quoteElementType)
        {
            Parameter = parameter;
            Value = value;
            CostImpact = costImpact;
            TimeImpact = timeImpact;
            QuoteElementType = quoteElementType;
        }
    }



}
