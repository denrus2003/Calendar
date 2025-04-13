using System;
using System.Windows.Forms;
using CalendarLibrary;

namespace CalendarWinForms
{
    public partial class EncryptionSettingsForm : Form
    {
        public EncryptionSettingsForm()
        {
            InitializeComponent();
            
            var settings = SettingsStorage.LoadSettings();
            chkEnableEncryption.Checked = settings.EncryptionEnabled;
            tbNewPassword.Text = "";
            tbConfirmPassword.Text = "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool enabled = chkEnableEncryption.Checked;
            string pwd = tbNewPassword.Text;
            string pwdConfirm = tbConfirmPassword.Text;

            if (enabled)
            {
                if (string.IsNullOrWhiteSpace(pwd))
                {
                    MessageBox.Show("Пароль не может быть пустым.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (pwd.Length < 6)
                {
                    MessageBox.Show("Пароль должен содержать не менее 6 символов.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (pwd != pwdConfirm)
                {
                    MessageBox.Show("Пароль и подтверждение не совпадают.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            var newSettings = new EncryptionSettings
            {
                EncryptionEnabled = enabled,
                EncryptionPassword = enabled ? pwd : string.Empty
            };
            SettingsStorage.SaveSettings(newSettings);
            MessageBox.Show("Настройки шифрования сохранены.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void EncryptionSettingsForm_Load(object sender, EventArgs e)
        {

        }
    }
}
