using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace UiModule
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = MainViewModel.Instance;

            if (MainViewModel.Instance.PreferencesViewModel is INotifyPropertyChanged preferencesNotifier)
                preferencesNotifier.PropertyChanged += Preferences_PropertyChanged;
        }

        private void Preferences_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //tried to implement this by triggers but that worked unstable
            if (e.PropertyName.Equals(nameof(MainViewModel.Instance.PreferencesViewModel.IsConfirmed))
                && MainViewModel.Instance.PreferencesViewModel.IsConfirmed)
            {
                PreferencesExpander.IsExpanded = false;
                QuoteExpander.IsExpanded = true;
            }
        }
    }
}
