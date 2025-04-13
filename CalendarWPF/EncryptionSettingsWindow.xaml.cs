using System.Windows;
using CalendarLibrary;

namespace CalendarWPF
{
    public partial class EncryptionSettingsWindow : Window
    {
        public EncryptionSettingsWindow()
        {
            InitializeComponent();

            // Загружаем текущие настройки
            var settings = SettingsStorage.LoadSettings();
            chkEnableEncryption.IsChecked = settings.EncryptionEnabled;
            pbNewPassword.Password = "";
            pbConfirmPassword.Password = "";
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            bool enabled = chkEnableEncryption.IsChecked ?? false;
            string pwd = pbNewPassword.Password;
            string pwdConfirm = pbConfirmPassword.Password;

            if (enabled)
            {
                if (string.IsNullOrWhiteSpace(pwd))
                {
                    MessageBox.Show("Пароль не может быть пустым.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                if (pwd.Length < 6)
                {
                    MessageBox.Show("Пароль должен содержать не менее 6 символов.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                if (pwd != pwdConfirm)
                {
                    MessageBox.Show("Пароль и подтверждение не совпадают.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
            }
            var newSettings = new EncryptionSettings
            {
                EncryptionEnabled = enabled,
                EncryptionPassword = enabled ? pwd : string.Empty
            };
            SettingsStorage.SaveSettings(newSettings);
            MessageBox.Show("Настройки шифрования сохранены.", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            DialogResult = true;
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
