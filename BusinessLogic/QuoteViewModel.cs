using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace BusinessLogic
{
    public interface IQuoteViewModel
    {
        double TimeImpactSummary { get; }
        double CostImpactSummary { get; }

        double FabricationTimeImpactSummary { get; }
        double AssemblyTimeImpactSummary { get; }
        double ComponentsTimeImpactSummary { get; }

        double FabricationCostImpactSummary { get; }
        double AssemblyCostImpactSummary { get; }
        double ComponentsCostImpactSummary { get; }

        double GetSummary(QuoteElementType type, bool isCost);

        void UpdateQuote(IPreferencesViewModel preferences);
    }
    public class QuoteViewModel : ViewModelBase, IQuoteViewModel
    {
        private double _timeImpactSummary;
        private double _costImpactSummary;
        private double _fabricationTimeImpactSummary;
        private double _assemblyTimeImpactSummary;
        private double _componentsTimeImpactSummary;
        private double _fabricationCostImpactSummary;
        private double _assemblyCostImpactSummary;
        private double _componentsCostImpactSummary;

        private ImpactProportions _impactProportions;

        public ObservableCollection<QuoteElement> QuoteElements { get; } = new ObservableCollection<QuoteElement>();


        public double TimeImpactSummary
        {
            get => _timeImpactSummary;
        }

        public double CostImpactSummary
        {
            get => _costImpactSummary;
        }


        public double FabricationTimeImpactSummary
        {
            get => _fabricationTimeImpactSummary;
        }

        public double AssemblyTimeImpactSummary
        {
            get => _assemblyTimeImpactSummary;
        }

        public double ComponentsTimeImpactSummary
        {
            get => _componentsTimeImpactSummary;
        }


        public double FabricationCostImpactSummary
        {
            get => _fabricationCostImpactSummary;
        }

        public double AssemblyCostImpactSummary
        {
            get => _assemblyCostImpactSummary;
        }

        public double ComponentsCostImpactSummary
        {
            get => _componentsCostImpactSummary;
        }

        public ImpactProportions ImpactProportions
        {
            get => _impactProportions;
        }

        public double GetSummary(QuoteElementType type, bool isCost)
        {
            switch (type)
            {
                case QuoteElementType.Fabrication:
                    return isCost ? FabricationCostImpactSummary : FabricationTimeImpactSummary;
                case QuoteElementType.Assembly:
                    return isCost ? AssemblyCostImpactSummary : AssemblyTimeImpactSummary;
                case QuoteElementType.Components:
                    return isCost ? ComponentsCostImpactSummary : ComponentsTimeImpactSummary;
                default:
                    throw new ArgumentException("Unknown quote element type", nameof(type));
            }
        }

        public QuoteViewModel()
        {

        }

        private void UpdateImpactSummary()
        {
            _timeImpactSummary = 0;
            _costImpactSummary = 0;
            _fabricationTimeImpactSummary = 0;
            _assemblyTimeImpactSummary = 0;
            _componentsTimeImpactSummary = 0;
            _fabricationCostImpactSummary = 0;
            _assemblyCostImpactSummary = 0;
            _componentsCostImpactSummary = 0;
            foreach (var item in QuoteElements)
            {
                _timeImpactSummary += item.TimeImpact;
                _costImpactSummary += item.CostImpact;
                switch (item.QuoteElementType)
                {
                    case QuoteElementType.Fabrication:
                        _fabricationTimeImpactSummary+= item.TimeImpact;
                        _fabricationCostImpactSummary += item.CostImpact;
                        break;
                    case QuoteElementType.Assembly:
                        _assemblyTimeImpactSummary += item.TimeImpact;
                        _assemblyCostImpactSummary += item.CostImpact;
                        break;
                    case QuoteElementType.Components:
                        _componentsTimeImpactSummary += item.TimeImpact;
                        _componentsCostImpactSummary += item.CostImpact;
                        break;
                }
            }
            OnPropertyChanged(nameof(TimeImpactSummary));
            OnPropertyChanged(nameof(CostImpactSummary));

            OnPropertyChanged(nameof(FabricationTimeImpactSummary));
            OnPropertyChanged(nameof(AssemblyTimeImpactSummary));
            OnPropertyChanged(nameof(ComponentsTimeImpactSummary));
            OnPropertyChanged(nameof(FabricationCostImpactSummary));
            OnPropertyChanged(nameof(AssemblyCostImpactSummary));
            OnPropertyChanged(nameof(ComponentsCostImpactSummary));

            _impactProportions = new ImpactProportions(this);
            OnPropertyChanged(nameof(ImpactProportions));
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

    public class ImpactProportions
    {
        public double FabricationTimeImpactProportion { get; }
        public double AssemblyTimeImpactProportion { get; }
        public double ComponentsTimeImpactProportion { get; }
        public double FabricationCostImpactProportion { get; }
        public double AssemblyCostImpactProportion { get; }
        public double ComponentsCostImpactProportion { get; }


        public double TimeImpactAbsolute { get; }
        public double CostImpactAbsolute { get; }

        public double FabricationTimeImpactAbsolute { get; }
        public double AssemblyTimeImpactAbsolute { get; }
        public double ComponentsTimeImpactAbsolute { get; }

        public double FabricationCostImpactAbsolute { get; }
        public double AssemblyCostImpactAbsolute { get; }
        public double ComponentsCostImpactAbsolute { get; }

        public ImpactProportions(IQuoteViewModel quote)
        {
            FabricationTimeImpactProportion = quote.FabricationTimeImpactSummary / quote.TimeImpactSummary;
            AssemblyTimeImpactProportion = quote.AssemblyTimeImpactSummary / quote.TimeImpactSummary;
            ComponentsTimeImpactProportion = quote.ComponentsTimeImpactSummary / quote.TimeImpactSummary;

            FabricationCostImpactProportion = quote.FabricationCostImpactSummary / quote.CostImpactSummary;
            AssemblyCostImpactProportion = quote.AssemblyCostImpactSummary / quote.CostImpactSummary;
            ComponentsCostImpactProportion = quote.ComponentsCostImpactSummary / quote.CostImpactSummary;

            TimeImpactAbsolute = quote.TimeImpactSummary;
            CostImpactAbsolute = quote.CostImpactSummary;

            FabricationTimeImpactAbsolute = quote.FabricationTimeImpactSummary;
            AssemblyTimeImpactAbsolute = quote.AssemblyTimeImpactSummary;
            ComponentsTimeImpactAbsolute = quote.ComponentsTimeImpactSummary;
            FabricationCostImpactAbsolute = quote.FabricationCostImpactSummary;
            AssemblyCostImpactAbsolute = quote.AssemblyCostImpactSummary;
            ComponentsCostImpactAbsolute = quote.ComponentsCostImpactSummary;
        }
    }

}
