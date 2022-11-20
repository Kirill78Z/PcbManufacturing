using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace CustomControls
{
    public class CustomMainWindow : Window
    {
        public Grid LayoutRoot { get; private set; }
        static CustomMainWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomMainWindow), new FrameworkPropertyMetadata(typeof(CustomMainWindow)));
        }

        public static readonly DependencyProperty Title2Property =
            DependencyProperty.Register(nameof(Title2),
                typeof(string), typeof(CustomMainWindow),
                new PropertyMetadata(string.Empty));
        public string Title2
        {
            get { return (string)GetValue(Title2Property); }
            set { SetValue(Title2Property, value); }
        }


        public static readonly DependencyProperty StatusHeaderProperty = DependencyProperty.Register(
            nameof(StatusHeader), typeof(object), typeof(CustomMainWindow), new PropertyMetadata(default(object)));

        public object StatusHeader
        {
            get { return (object)GetValue(StatusHeaderProperty); }
            set { SetValue(StatusHeaderProperty, value); }
        }

        public static readonly DependencyProperty StatusHeaderTemplateProperty = DependencyProperty.Register(
            nameof(StatusHeaderTemplate), typeof(DataTemplate), typeof(CustomMainWindow), new PropertyMetadata(default(DataTemplate)));

        public DataTemplate StatusHeaderTemplate
        {
            get { return (DataTemplate)GetValue(StatusHeaderTemplateProperty); }
            set { SetValue(StatusHeaderTemplateProperty, value); }
        }


        public CustomMainWindow()
        {
            base.StateChanged += new EventHandler(this.OnStateChanged);
        }

        public override void OnApplyTemplate()
        {
            this.LayoutRoot = (Grid)this.GetTemplateChild("LayoutRoot");

        }


        private void OnStateChanged(object sender, EventArgs e)
        {
            if (this.WindowState != WindowState.Maximized)
                this.LayoutRoot.Margin = new Thickness(0);
            else
                this.LayoutRoot.Margin = new Thickness(8);
        }
    }
}
