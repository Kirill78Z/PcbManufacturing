using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace BusinessLogic
{
    public class QuoteViewModel : ViewModelBase
    {
        private double _timeImpactSummary;
        private double _costImpactSummary;
        public ObservableCollection<QuoteElement> QuoteElements { get; } = new ObservableCollection<QuoteElement>()
        {
            new QuoteElement("Base fabrication", "61.72x148.84mm, 10 layers", 4, 1710, QuoteElementType.Fabrication),
            new QuoteElement("Boards quantity", "20", 0, 538, QuoteElementType.Fabrication),
            new QuoteElement("Surface finish", "ENEPIG", 3, 75, QuoteElementType.Fabrication),

            new QuoteElement("Packages", "Package on Packages", 1, 2679, QuoteElementType.Assembly),
            new QuoteElement("Processes", "Split Assembly", 0, 720.5, QuoteElementType.Assembly),
            new QuoteElement("Minimum pitch", "0.3mm pitch BGA", 0, 804, QuoteElementType.Assembly),

            new QuoteElement("Microchip ATTINY2313-20SU", "2", 0, 48.64, QuoteElementType.Components),
            new QuoteElement("Microchip ATTINY2313-18PC", "1", 0, 22.12, QuoteElementType.Components),
            new QuoteElement("Microchip ATTINY2313-18PC", "1", 0, 22.12, QuoteElementType.Components),
            new QuoteElement("Microchip ATTINY2313-20SU", "2", 0, 48.64, QuoteElementType.Components),
            new QuoteElement("Microchip ATTINY2313-18PC", "1", 0, 22.12, QuoteElementType.Components),
            new QuoteElement("Microchip ATTINY2313-18PC", "1", 0, 22.12, QuoteElementType.Components),
            new QuoteElement("Microchip ATTINY2313-20SU", "2", 0, 48.64, QuoteElementType.Components),
            new QuoteElement("Microchip ATTINY2313-18PC", "1", 0, 22.12, QuoteElementType.Components),
            new QuoteElement("Microchip ATTINY2313-18PC", "1", 0, 22.12, QuoteElementType.Components),
        };


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
            UpdateImpactSummary();
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
    }

    public class QuoteElement : IImpact
    {
        public string Parameter { get; }
        public string Value { get; }
        public double TimeImpact { get; }
        public double CostImpact { get; }
        
        public QuoteElementType QuoteElementType { get; }

        public QuoteElement(
            string parameter, string value,
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
