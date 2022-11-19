using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CustomControls
{
    public class ImpactRateDiagram : Control
    {
        private static readonly Brush EmptyBrush = new SolidColorBrush(Colors.DarkGray);
        private static readonly Brush DefaultFilledBrush = new SolidColorBrush(Colors.Red);
        static ImpactRateDiagram()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ImpactRateDiagram), new FrameworkPropertyMetadata(typeof(ImpactRateDiagram)));
        }

        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register(nameof(Value),
                typeof(double), typeof(ImpactRateDiagram),
                new PropertyMetadata(0.0, OnValueChanged, CoerceValue));
        private static object CoerceValue(DependencyObject dependencyObject, object value)
        {
            return Math.Clamp((double)value, 0.0, 1.0);
        }
        private static void OnValueChanged(DependencyObject dependencyObject,
            DependencyPropertyChangedEventArgs e)
        {
            ImpactRateDiagram diagram = (ImpactRateDiagram)dependencyObject;
            diagram.SetCircleColors(diagram);
        }
        public double Value
        {
            get { return (double)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }


        public static readonly DependencyProperty FilledBrushProperty =
            DependencyProperty.Register(nameof(FilledBrush),
                typeof(Brush), typeof(ImpactRateDiagram),
                new PropertyMetadata(DefaultFilledBrush, OnValueChanged));

        public Brush FilledBrush
        {
            get { return (Brush)GetValue(FilledBrushProperty); }
            set { SetValue(FilledBrushProperty, value); }
        }


        public static readonly DependencyPropertyKey Circle0FillPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(Circle0Fill), typeof(Brush),
                typeof(ImpactRateDiagram), new PropertyMetadata(EmptyBrush));
        public static readonly DependencyProperty Circle0FillProperty =
            Circle0FillPropertyKey.DependencyProperty;
        public Brush Circle0Fill
        {
            get { return (Brush)GetValue(Circle0FillProperty); }
            private set { SetValue(Circle0FillPropertyKey, value); }
        }


        public static readonly DependencyPropertyKey Circle1FillPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(Circle1Fill), typeof(Brush),
                typeof(ImpactRateDiagram), new PropertyMetadata(EmptyBrush));
        public static readonly DependencyProperty Circle1FillProperty =
            Circle1FillPropertyKey.DependencyProperty;
        public Brush Circle1Fill
        {
            get { return (Brush)GetValue(Circle1FillProperty); }
            private set { SetValue(Circle1FillPropertyKey, value); }
        }


        public static readonly DependencyPropertyKey Circle2FillPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(Circle2Fill), typeof(Brush),
                typeof(ImpactRateDiagram), new PropertyMetadata(EmptyBrush));
        public static readonly DependencyProperty Circle2FillProperty =
            Circle2FillPropertyKey.DependencyProperty;
        public Brush Circle2Fill
        {
            get { return (Brush)GetValue(Circle2FillProperty); }
            private set { SetValue(Circle2FillPropertyKey, value); }
        }


        public static readonly DependencyPropertyKey Circle3FillPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(Circle3Fill), typeof(Brush),
                typeof(ImpactRateDiagram), new PropertyMetadata(EmptyBrush));
        public static readonly DependencyProperty Circle3FillProperty =
            Circle3FillPropertyKey.DependencyProperty;
        public Brush Circle3Fill
        {
            get { return (Brush)GetValue(Circle3FillProperty); }
            private set { SetValue(Circle3FillPropertyKey, value); }
        }


        public static readonly DependencyPropertyKey Circle4FillPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(Circle4Fill), typeof(Brush),
                typeof(ImpactRateDiagram), new PropertyMetadata(EmptyBrush));
        public static readonly DependencyProperty Circle4FillProperty =
            Circle4FillPropertyKey.DependencyProperty;
        public Brush Circle4Fill
        {
            get { return (Brush)GetValue(Circle4FillProperty); }
            private set { SetValue(Circle4FillPropertyKey, value); }
        }


        public override void OnApplyTemplate()
        {
            SetCircleColors(this);
        }
        private void SetCircleColors(ImpactRateDiagram diagram)
        {
            Circle0Fill = FilledBrush;

            if (diagram.Value > 0.2)
                Circle1Fill = FilledBrush;
            else
                Circle1Fill = EmptyBrush;

            if (diagram.Value > 0.4)
                Circle2Fill = FilledBrush;
            else
                Circle2Fill = EmptyBrush;

            if (diagram.Value > 0.6)
                Circle3Fill = FilledBrush;
            else
                Circle3Fill = EmptyBrush;

            if (diagram.Value > 0.8)
                Circle4Fill = FilledBrush;
            else
                Circle4Fill = EmptyBrush;
        }
    }
}
