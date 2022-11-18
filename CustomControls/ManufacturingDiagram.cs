using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BusinessLogic;
using Common.Converters;

namespace CustomControls
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:CustomControls"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:CustomControls;assembly=CustomControls"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:CustomControl1/>
    ///
    /// </summary>
    public class ManufacturingDiagram : Control
    {
        static ManufacturingDiagram()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ManufacturingDiagram), new FrameworkPropertyMetadata(typeof(ManufacturingDiagram)));
        }

        private Rectangle _fabricationRectangle;
        private Rectangle _assemblyRectangle;
        private Rectangle _componentsRectangle;
        private TextBlock _fabricationText;
        private TextBlock _assemblyText;
        private TextBlock _componentsText;

        public static readonly DependencyProperty ImpactProportionsProperty =
            DependencyProperty.Register(nameof(ImpactProportions), typeof(ImpactProportions),
                typeof(ManufacturingDiagram), new PropertyMetadata(null, OnImpactProportionsChanged));

        private static void OnImpactProportionsChanged(DependencyObject dependencyObject,
            DependencyPropertyChangedEventArgs e)
        {
            ManufacturingDiagram diagram = (ManufacturingDiagram)dependencyObject;
            diagram.SetDiagramData(diagram);
        }
        public ImpactProportions ImpactProportions
        {
            get { return (ImpactProportions)GetValue(ImpactProportionsProperty); }
            set { SetValue(ImpactProportionsProperty, value); }
        }


        public static readonly DependencyPropertyKey FabricationLengthPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(FabricationLength), typeof(double),
                typeof(ManufacturingDiagram), new PropertyMetadata(0.0));

        public static readonly DependencyProperty FabricationLengthProperty =
            FabricationLengthPropertyKey.DependencyProperty;
        public double FabricationLength
        {
            get { return (double)GetValue(FabricationLengthProperty); }
            private set { SetValue(FabricationLengthPropertyKey, value); }
        }


        public static readonly DependencyPropertyKey AssemblyLengthPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(AssemblyLength), typeof(double),
                typeof(ManufacturingDiagram), new PropertyMetadata(0.0));

        public static readonly DependencyProperty AssemblyLengthProperty =
            AssemblyLengthPropertyKey.DependencyProperty;
        public double AssemblyLength
        {
            get { return (double)GetValue(AssemblyLengthProperty); }
            private set { SetValue(AssemblyLengthPropertyKey, value); }
        }


        public static readonly DependencyPropertyKey ComponentsLengthPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(ComponentsLength), typeof(double),
                typeof(ManufacturingDiagram), new PropertyMetadata(0.0));

        public static readonly DependencyProperty ComponentsLengthProperty =
            ComponentsLengthPropertyKey.DependencyProperty;
        public double ComponentsLength
        {
            get { return (double)GetValue(ComponentsLengthProperty); }
            private set { SetValue(ComponentsLengthPropertyKey, value); }
        }


        public static readonly DependencyProperty IsShowCostProperty =
            DependencyProperty.Register(nameof(IsShowCost), typeof(bool),
                typeof(ManufacturingDiagram), new PropertyMetadata(false, OnImpactProportionsChanged));

        public bool IsShowCost
        {
            get { return (bool)GetValue(IsShowCostProperty); }
            set { SetValue(IsShowCostProperty, value); }
        }



        public static readonly DependencyPropertyKey SummaryAbsolutePropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(SummaryAbsolute), typeof(string),
                typeof(ManufacturingDiagram), new PropertyMetadata(null));
        public static readonly DependencyProperty SummaryAbsoluteProperty =
            SummaryAbsolutePropertyKey.DependencyProperty;
        public string SummaryAbsolute
        {
            get { return (string)GetValue(SummaryAbsoluteProperty); }
            set { SetValue(SummaryAbsolutePropertyKey, value); }
        }


        public static readonly DependencyPropertyKey FabricationAbsolutePropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(FabricationAbsolute), typeof(string),
                typeof(ManufacturingDiagram), new PropertyMetadata(null));
        public static readonly DependencyProperty FabricationAbsoluteProperty =
            FabricationAbsolutePropertyKey.DependencyProperty;
        public string FabricationAbsolute
        {
            get { return (string)GetValue(FabricationAbsoluteProperty); }
            set { SetValue(FabricationAbsolutePropertyKey, value); }
        }

        public static readonly DependencyPropertyKey FabricationVisibilityPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(FabricationVisibility), typeof(Visibility),
                typeof(ManufacturingDiagram), new PropertyMetadata(Visibility.Visible));
        public static readonly DependencyProperty FabricationVisibilityProperty =
            FabricationVisibilityPropertyKey.DependencyProperty;
        public Visibility FabricationVisibility
        {
            get { return (Visibility)GetValue(FabricationVisibilityProperty); }
            set { SetValue(FabricationVisibilityPropertyKey, value); }
        }

        public static readonly DependencyPropertyKey FabricationProportionPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(FabricationProportion), typeof(double),
                typeof(ManufacturingDiagram), new PropertyMetadata(0.0));
        public static readonly DependencyProperty FabricationProportionProperty =
            FabricationProportionPropertyKey.DependencyProperty;
        public double FabricationProportion
        {
            get { return (double)GetValue(FabricationProportionProperty); }
            set { SetValue(FabricationProportionPropertyKey, value); }
        }


        public static readonly DependencyPropertyKey AssemblyAbsolutePropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(AssemblyAbsolute), typeof(string),
                typeof(ManufacturingDiagram), new PropertyMetadata(null));
        public static readonly DependencyProperty AssemblyAbsoluteProperty =
            AssemblyAbsolutePropertyKey.DependencyProperty;
        public string AssemblyAbsolute
        {
            get { return (string)GetValue(AssemblyAbsoluteProperty); }
            set { SetValue(AssemblyAbsolutePropertyKey, value); }
        }


        public static readonly DependencyPropertyKey AssemblyVisibilityPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(AssemblyVisibility), typeof(Visibility),
                typeof(ManufacturingDiagram), new PropertyMetadata(Visibility.Visible));
        public static readonly DependencyProperty AssemblyVisibilityProperty =
            AssemblyVisibilityPropertyKey.DependencyProperty;
        public Visibility AssemblyVisibility
        {
            get { return (Visibility)GetValue(AssemblyVisibilityProperty); }
            set { SetValue(AssemblyVisibilityPropertyKey, value); }
        }


        public static readonly DependencyPropertyKey AssemblyProportionPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(AssemblyProportion), typeof(double),
                typeof(ManufacturingDiagram), new PropertyMetadata(0.0));
        public static readonly DependencyProperty AssemblyProportionProperty =
            AssemblyProportionPropertyKey.DependencyProperty;
        public double AssemblyProportion
        {
            get { return (double)GetValue(AssemblyProportionProperty); }
            set { SetValue(AssemblyProportionPropertyKey, value); }
        }


        public static readonly DependencyPropertyKey ComponentsAbsolutePropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(ComponentsAbsolute), typeof(string),
                typeof(ManufacturingDiagram), new PropertyMetadata(null));
        public static readonly DependencyProperty ComponentsAbsoluteProperty =
            ComponentsAbsolutePropertyKey.DependencyProperty;
        public string ComponentsAbsolute
        {
            get { return (string)GetValue(ComponentsAbsoluteProperty); }
            set { SetValue(ComponentsAbsolutePropertyKey, value); }
        }


        public static readonly DependencyPropertyKey ComponentsVisibilityPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(ComponentsVisibility), typeof(Visibility),
                typeof(ManufacturingDiagram), new PropertyMetadata(Visibility.Visible));
        public static readonly DependencyProperty ComponentsVisibilityProperty =
            ComponentsVisibilityPropertyKey.DependencyProperty;
        public Visibility ComponentsVisibility
        {
            get { return (Visibility)GetValue(ComponentsVisibilityProperty); }
            set { SetValue(ComponentsVisibilityPropertyKey, value); }
        }


        public static readonly DependencyPropertyKey ComponentsProportionPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(ComponentsProportion), typeof(double),
                typeof(ManufacturingDiagram), new PropertyMetadata(0.0));
        public static readonly DependencyProperty ComponentsProportionProperty =
            ComponentsProportionPropertyKey.DependencyProperty;
        public double ComponentsProportion
        {
            get { return (double)GetValue(ComponentsProportionProperty); }
            set { SetValue(ComponentsProportionPropertyKey, value); }
        }


        public ManufacturingDiagram()
        {
            SizeChanged += Components_SizeChanged;
        }

        private void Components_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (e.WidthChanged)
                SetDiagramData(this);
        }

        public override void OnApplyTemplate()
        {
            _fabricationRectangle = (Rectangle)Template.FindName("FabricationRectangle", this);
            _assemblyRectangle = (Rectangle)Template.FindName("AssemblyRectangle", this);
            _componentsRectangle = (Rectangle)Template.FindName("ComponentsRectangle", this);

            _fabricationText = (TextBlock)Template.FindName("FabricationText", this);
            _assemblyText = (TextBlock)Template.FindName("AssemblyText", this);
            _assemblyText.SizeChanged += Components_SizeChanged;
            _componentsText = (TextBlock)Template.FindName("ComponentsText", this);
            _componentsText.SizeChanged += Components_SizeChanged;

            SetDiagramData(this);
        }
        private void SetDiagramData(ManufacturingDiagram diagram)
        {
            if (ImpactProportions == null
                || _fabricationRectangle == null || _assemblyRectangle == null || _componentsRectangle == null
                || _fabricationText == null || _assemblyText == null || _componentsText == null)
                return;
            if (diagram.IsShowCost)
            {
                diagram.FabricationLength = Math.Floor(ImpactProportions.FabricationCostImpactProportion * diagram.ActualWidth);
                diagram.AssemblyLength = Math.Floor(ImpactProportions.AssemblyCostImpactProportion * diagram.ActualWidth);
                diagram.ComponentsLength = Math.Floor(ImpactProportions.ComponentsCostImpactProportion * diagram.ActualWidth);


                diagram.SummaryAbsolute = CostImpactConverter.CostImpactToString(ImpactProportions.CostImpactAbsolute);
                diagram.FabricationAbsolute = CostImpactConverter.CostImpactToString(ImpactProportions.FabricationCostImpactAbsolute);
                diagram.AssemblyAbsolute = CostImpactConverter.CostImpactToString(ImpactProportions.AssemblyCostImpactAbsolute);
                diagram.ComponentsAbsolute = CostImpactConverter.CostImpactToString(ImpactProportions.ComponentsCostImpactAbsolute);

                diagram.FabricationProportion = ImpactProportions.FabricationCostImpactProportion;
                diagram.AssemblyProportion = ImpactProportions.AssemblyCostImpactProportion;
                diagram.ComponentsProportion = ImpactProportions.ComponentsCostImpactProportion;
            }
            else
            {
                diagram.FabricationLength = Math.Floor(ImpactProportions.FabricationTimeImpactProportion * diagram.ActualWidth);
                diagram.AssemblyLength = Math.Floor(ImpactProportions.AssemblyTimeImpactProportion * diagram.ActualWidth);
                diagram.ComponentsLength = Math.Floor(ImpactProportions.ComponentsTimeImpactProportion * diagram.ActualWidth);

                diagram.SummaryAbsolute = TimeImpactConverter.TimeImpactToString(ImpactProportions.TimeImpactAbsolute);
                diagram.FabricationAbsolute = TimeImpactConverter.TimeImpactToString(ImpactProportions.FabricationTimeImpactAbsolute);
                diagram.AssemblyAbsolute = TimeImpactConverter.TimeImpactToString(ImpactProportions.AssemblyTimeImpactAbsolute);
                diagram.ComponentsAbsolute = TimeImpactConverter.TimeImpactToString(ImpactProportions.ComponentsTimeImpactAbsolute);

                diagram.FabricationProportion = ImpactProportions.FabricationTimeImpactProportion;
                diagram.AssemblyProportion = ImpactProportions.AssemblyTimeImpactProportion;
                diagram.ComponentsProportion = ImpactProportions.ComponentsTimeImpactProportion;
            }

            FabricationVisibility = diagram.FabricationLength > 0 ? Visibility.Visible : Visibility.Collapsed;
            AssemblyVisibility = diagram.AssemblyLength > 0 ? Visibility.Visible : Visibility.Collapsed;
            ComponentsVisibility = diagram.ComponentsLength > 0 ? Visibility.Visible : Visibility.Collapsed;

            var componentsLeft = diagram.FabricationLength + diagram.AssemblyLength;
            Canvas.SetLeft(_fabricationRectangle, 0);
            Canvas.SetLeft(_assemblyRectangle, diagram.FabricationLength);
            Canvas.SetLeft(_componentsRectangle, componentsLeft);

            Canvas.SetTop(_fabricationText, 18);
            Canvas.SetTop(_assemblyText, 18);
            Canvas.SetTop(_componentsText, 18);

            Canvas.SetLeft(_fabricationText, 0);
            Canvas.SetLeft(_assemblyText,
                _assemblyText.ActualWidth > diagram.AssemblyLength ?
                    diagram.FabricationLength + diagram.AssemblyLength - _assemblyText.ActualWidth
                    : diagram.FabricationLength);
            Canvas.SetLeft(_componentsText,
                _componentsText.ActualWidth > diagram.ComponentsLength ?
                    componentsLeft + diagram.ComponentsLength - _componentsText.ActualWidth
                    : componentsLeft);
        }
    }
}
