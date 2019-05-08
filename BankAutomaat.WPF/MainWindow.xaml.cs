using Bank.Lib;
using System;
using System.Windows;

namespace BankAutomaat.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BankRekening bankRekening = new BankRekening();

        public MainWindow()
        {
            InitializeComponent();
        }

        #region METHODS

        private void UpdateCurrentAmountLabel()
        {
            lblTotalAmount.Content = $"€ {bankRekening.Balance}";
        }

        private void ClearInputMoneyAmount()
        {
            txtMoney.Clear();
            txtMoney.Focus();
        }

        private decimal GetMoneyAmountFromUser()
        {
            return decimal.Parse(txtMoney.Text);
        }

        #endregion

        #region EVENTS

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateCurrentAmountLabel();
            txtMoney.Focus();
        }

        private void BtnAddMoney_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bankRekening.AddMoneyToBankAccount(GetMoneyAmountFromUser());
                UpdateCurrentAmountLabel();
                ClearInputMoneyAmount();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fout: {ex.Message}", "Fout!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnGetMoney_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bankRekening.TakeMoneyFromBankAccount(GetMoneyAmountFromUser());
                UpdateCurrentAmountLabel();
                ClearInputMoneyAmount();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fout: {ex.Message}", "Fout!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        #endregion
    }
}
