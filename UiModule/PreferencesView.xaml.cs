using System;
using System.Collections.Generic;
using System.Text;
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
    /// Interaction logic for PreferencesView.xaml
    /// </summary>
    public partial class PreferencesView : UserControl
    {
        public PreferencesView()
        {
            InitializeComponent();
        }

        private void TextBox_OnLostKeyBoardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            UpdateConfirmBtn(sender);
        }

        private void TextBox_OnTargetUpdated(object sender, DataTransferEventArgs e)
        {
            UpdateConfirmBtn(sender);
        }

        private void UpdateConfirmBtn(object sender)
        {
            ((Control)sender).GetBindingExpression(TextBox.TextProperty).UpdateSource();

            var err = Validation.GetHasError(ZipCodeTextBox)
                      || Validation.GetHasError(BoardsQuantityTextBox)
                      || Validation.GetHasError(BoardThicknessTextBox);

            ConfirmBtn.IsEnabled = !err;
        }
    }
}
