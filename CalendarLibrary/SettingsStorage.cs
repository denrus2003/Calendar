using System;
using System.IO;
using System.Text;
using System.Text.Json;

namespace CalendarLibrary
{
    public static class SettingsStorage
    {
        
        private static readonly string SettingsFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "encryptionSettings.json");

        public static EncryptionSettings LoadSettings()
        {
            if (!File.Exists(SettingsFilePath))
                return new EncryptionSettings(); 

            string json = File.ReadAllText(SettingsFilePath, Encoding.UTF8);
            try
            {
                return JsonSerializer.Deserialize<EncryptionSettings>(json);
            }
            catch
            {
                
                return new EncryptionSettings();
            }
        }

        public static void SaveSettings(EncryptionSettings settings)
        {
            string json = JsonSerializer.Serialize(settings, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(SettingsFilePath, json, Encoding.UTF8);
        }
    }
}
