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


        public static readonly DependencyPropertyKey FabricationGridLengthPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(FabricationGridLength), typeof(GridLength),
                typeof(ManufacturingDiagram), new PropertyMetadata(new GridLength()));

        public static readonly DependencyProperty FabricationGridLengthProperty =
            FabricationGridLengthPropertyKey.DependencyProperty;
        public GridLength FabricationGridLength
        {
            get { return (GridLength)GetValue(FabricationGridLengthProperty); }
            private set { SetValue(FabricationGridLengthPropertyKey, value); }
        }


        public static readonly DependencyPropertyKey AssemblyGridLengthPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(AssemblyGridLength), typeof(GridLength),
                typeof(ManufacturingDiagram), new PropertyMetadata(new GridLength()));

        public static readonly DependencyProperty AssemblyGridLengthProperty =
            AssemblyGridLengthPropertyKey.DependencyProperty;
        public GridLength AssemblyGridLength
        {
            get { return (GridLength)GetValue(AssemblyGridLengthProperty); }
            private set { SetValue(AssemblyGridLengthPropertyKey, value); }
        }


        public static readonly DependencyPropertyKey ComponentsGridLengthPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(ComponentsGridLength), typeof(GridLength),
                typeof(ManufacturingDiagram), new PropertyMetadata(new GridLength()));

        public static readonly DependencyProperty ComponentsGridLengthProperty =
            ComponentsGridLengthPropertyKey.DependencyProperty;
        public GridLength ComponentsGridLength
        {
            get { return (GridLength)GetValue(ComponentsGridLengthProperty); }
            private set { SetValue(ComponentsGridLengthPropertyKey, value); }
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
            DependencyProperty.RegisterReadOnly(nameof(SummaryAbsolute), typeof(double),
                typeof(ManufacturingDiagram), new PropertyMetadata(0.0));
        public static readonly DependencyProperty SummaryAbsoluteProperty =
            SummaryAbsolutePropertyKey.DependencyProperty;
        public double SummaryAbsolute
        {
            get { return (double)GetValue(SummaryAbsoluteProperty); }
            set { SetValue(SummaryAbsolutePropertyKey, value); }
        }


        public static readonly DependencyPropertyKey FabricationAbsolutePropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(FabricationAbsolute), typeof(double),
                typeof(ManufacturingDiagram), new PropertyMetadata(0.0));
        public static readonly DependencyProperty FabricationAbsoluteProperty =
            FabricationAbsolutePropertyKey.DependencyProperty;
        public double FabricationAbsolute
        {
            get { return (double)GetValue(FabricationAbsoluteProperty); }
            set { SetValue(FabricationAbsolutePropertyKey, value); }
        }


        public static readonly DependencyPropertyKey AssemblyAbsolutePropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(AssemblyAbsolute), typeof(double),
                typeof(ManufacturingDiagram), new PropertyMetadata(0.0));
        public static readonly DependencyProperty AssemblyAbsoluteProperty =
            AssemblyAbsolutePropertyKey.DependencyProperty;
        public double AssemblyAbsolute
        {
            get { return (double)GetValue(AssemblyAbsoluteProperty); }
            set { SetValue(AssemblyAbsolutePropertyKey, value); }
        }


        public static readonly DependencyPropertyKey ComponentsAbsolutePropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(ComponentsAbsolute), typeof(double),
                typeof(ManufacturingDiagram), new PropertyMetadata(0.0));
        public static readonly DependencyProperty ComponentsAbsoluteProperty =
            ComponentsAbsolutePropertyKey.DependencyProperty;
        public double ComponentsAbsolute
        {
            get { return (double)GetValue(ComponentsAbsoluteProperty); }
            set { SetValue(ComponentsAbsolutePropertyKey, value); }
        }

        public override void OnApplyTemplate()
        {
            SetDiagramData(this);
        }
        private void SetDiagramData(ManufacturingDiagram diagram)
        {
            if (ImpactProportions == null)
                return;
            if (diagram.IsShowCost)
            {
                diagram.FabricationGridLength = new GridLength(ImpactProportions.FabricationCostImpactProportion, GridUnitType.Star);
                diagram.AssemblyGridLength = new GridLength(ImpactProportions.AssemblyCostImpactProportion, GridUnitType.Star);
                diagram.ComponentsGridLength = new GridLength(ImpactProportions.ComponentsCostImpactProportion, GridUnitType.Star);

                diagram.SummaryAbsolute = ImpactProportions.CostImpactAbsolute;
                diagram.FabricationAbsolute = ImpactProportions.FabricationCostImpactAbsolute;
                diagram.AssemblyAbsolute = ImpactProportions.AssemblyCostImpactAbsolute;
                diagram.ComponentsAbsolute = ImpactProportions.ComponentsCostImpactAbsolute;
            }
            else
            {
                diagram.FabricationGridLength = new GridLength(ImpactProportions.FabricationTimeImpactProportion, GridUnitType.Star);
                diagram.AssemblyGridLength = new GridLength(ImpactProportions.AssemblyTimeImpactProportion, GridUnitType.Star);
                diagram.ComponentsGridLength = new GridLength(ImpactProportions.ComponentsTimeImpactProportion, GridUnitType.Star);

                diagram.SummaryAbsolute = ImpactProportions.TimeImpactAbsolute;
                diagram.FabricationAbsolute = ImpactProportions.FabricationTimeImpactAbsolute;
                diagram.AssemblyAbsolute = ImpactProportions.AssemblyTimeImpactAbsolute;
                diagram.ComponentsAbsolute = ImpactProportions.ComponentsTimeImpactAbsolute;
            }
        }
    }
}
