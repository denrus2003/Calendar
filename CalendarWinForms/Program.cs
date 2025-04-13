using System;
using System.Windows.Forms;
using CalendarLibrary;

namespace CalendarWinForms
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            
            var encryptionSettings = SettingsStorage.LoadSettings();

            
            if (encryptionSettings.EncryptionEnabled && !string.IsNullOrEmpty(encryptionSettings.EncryptionPassword))
            {
                using (var passForm = new PasswordEntryForm())
                {
                    
                    passForm.StoredPassword = encryptionSettings.EncryptionPassword;
                    
                    if (passForm.ShowDialog() != DialogResult.OK)
                        return;
                }
            }

            Application.Run(new MainForm());
        }
    }
}
