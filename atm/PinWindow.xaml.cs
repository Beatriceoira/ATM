using System;
using System.Windows;
using System.Windows.Media;

namespace WpfApp
{
    public partial class PinWindow : Window
    {
        private readonly Account account;
        private readonly Action onSuccess;
        private int attempts;

        public PinWindow(Account account, Action onSuccess)
        {
            InitializeComponent();
            this.account = account;
            this.onSuccess = onSuccess;
            attempts = 0;
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            if (PinBox.Password == account.GetPIN())
            {
       
                PinBox.Background = Brushes.LightGreen; 
                onSuccess();
                Close();
            }
            else
            {
                attempts++;
                if (attempts >= 3)
                {
                    Application.Current.Shutdown();
                }
                else
                {
                    MessageBox.Show($"Invalid PIN. {3 - attempts} attempts left.");
                }
            }
        }
    }
}
