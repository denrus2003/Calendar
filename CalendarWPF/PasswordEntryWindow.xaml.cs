using System.Windows;
using CalendarLibrary;

namespace CalendarWPF
{
    public partial class PasswordEntryWindow : Window
    {
        
        public string StoredPassword { get; set; }

        public PasswordEntryWindow()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            string inputPassword = pbPassword.Password.Trim();
            if (inputPassword == StoredPassword)
            {
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Неверный пароль. Попробуйте ещё раз.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                pbPassword.Clear();
                pbPassword.Focus();
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void btnResetPassword_Click(object sender, RoutedEventArgs e)
        {
            
            var resetWindow = new ResetPasswordWindow();
            if (resetWindow.ShowDialog() == true)
            {
                
                var settings = SettingsStorage.LoadSettings();
                StoredPassword = settings.EncryptionPassword;
                MessageBox.Show("Пароль успешно сброшен.", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
