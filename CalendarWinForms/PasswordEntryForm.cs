using System;
using System.Windows.Forms;
using CalendarLibrary;

namespace CalendarWinForms
{
    public partial class PasswordEntryForm : Form
    {
        
        public string StoredPassword { get; set; }

        public PasswordEntryForm()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string inputPassword = tbPassword.Text.Trim();
            if (inputPassword == StoredPassword)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Неверный пароль. Попробуйте ещё раз.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbPassword.Clear();
                tbPassword.Focus();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void PasswordEntryForm_Load(object sender, EventArgs e)
        {

        }
        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            
            using (var resetForm = new ResetPasswordForm())
            {
                if (resetForm.ShowDialog() == DialogResult.OK)
                {
                    
                    var settings = SettingsStorage.LoadSettings();
                    StoredPassword = settings.EncryptionPassword;
                    MessageBox.Show("Пароль успешно сброшен.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
