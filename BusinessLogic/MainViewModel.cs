using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class MainViewModel : ViewModelBase
    {
        private static MainViewModel _instance;
        public static MainViewModel Instance
        {
            get { return _instance ?? (_instance = new MainViewModel()); }
        }
        public IPreferencesViewModel PreferencesViewModel { get; }

        public IQuoteViewModel QuoteViewModel { get; }

        public IStatusHeaderViewModel StatusHeaderViewModel { get; }

        private MainViewModel()
        {
            QuoteViewModel = new QuoteViewModel();
            PreferencesViewModel = new PreferencesViewModel(QuoteViewModel);
            StatusHeaderViewModel = new StatusHeaderViewModel();
        }
    }
}
