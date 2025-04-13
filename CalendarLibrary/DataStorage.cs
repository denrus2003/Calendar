using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace CalendarLibrary
{
    public static class DataStorage
    {
        private static string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "events.dat");
        private static string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "error.log");

        public static void SaveEvents(IEnumerable<CalendarEvent> events, bool encryptionEnabled, string password)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(events, options);

            if (encryptionEnabled)
            {
                try
                {
                    json = EncryptString(json, password);
                }
                catch (Exception ex)
                {
                    LogError("Ошибка шифрования: " + ex.Message);
                    
                }
            }

            File.WriteAllText(filePath, json, Encoding.UTF8);
        }

        public static List<CalendarEvent> LoadEvents(bool encryptionEnabled, string password)
        {
            if (!File.Exists(filePath))
                return new List<CalendarEvent>();

            string content = File.ReadAllText(filePath, Encoding.UTF8);
            if (encryptionEnabled)
            {
                if (!IsBase64String(content))
                {
                    LogError("Данные файла не являются корректной строкой Base-64. Файл, возможно, не зашифрован или поврежден.");
                    ResetFile();
                    return new List<CalendarEvent>();
                }

                try
                {
                    content = DecryptString(content, password);
                }
                catch (Exception ex)
                {
                    LogError("Ошибка дешифрования файла событий: " + ex.Message);
                    
                    ResetFile();
                    return new List<CalendarEvent>();
                }
            }

            try
            {
                return JsonSerializer.Deserialize<List<CalendarEvent>>(content);
            }
            catch (Exception ex)
            {
                LogError("Ошибка десериализации JSON: " + ex.Message);
                return new List<CalendarEvent>();
            }
        }

        #region Шифрование / Дешифрование

        private static string EncryptString(string plainText, string password)
        {
            byte[] salt = GenerateRandomBytes(16);
            byte[] iv = GenerateRandomBytes(16);

            string encrypted;

            using (var keyDerivationFunction = new Rfc2898DeriveBytes(password, salt, 10000, HashAlgorithmName.SHA256))
            {
                byte[] key = keyDerivationFunction.GetBytes(32); // 256 бит

                using (Aes aes = Aes.Create())
                {
                    aes.Key = key;
                    aes.IV = iv;
                    aes.Mode = CipherMode.CBC;
                    using (MemoryStream ms = new MemoryStream())
                    {
                        
                        ms.Write(salt, 0, salt.Length);
                        ms.Write(iv, 0, iv.Length);
                        using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            using (StreamWriter sw = new StreamWriter(cs))
                            {
                                sw.Write(plainText);
                            }
                        }
                        encrypted = Convert.ToBase64String(ms.ToArray());
                    }
                }
            }
            return encrypted;
        }

        private static string DecryptString(string cipherText, string password)
        {
            byte[] fullCipher;
            try
            {
                fullCipher = Convert.FromBase64String(cipherText);
            }
            catch (FormatException ex)
            {
                throw new Exception("Ошибка: данные файла не являются корректной строкой Base-64. Возможно, файл не зашифрован или поврежден.", ex);
            }

            byte[] salt = new byte[16];
            byte[] iv = new byte[16];
            Array.Copy(fullCipher, 0, salt, 0, salt.Length);
            Array.Copy(fullCipher, salt.Length, iv, 0, iv.Length);
            byte[] cipher = new byte[fullCipher.Length - salt.Length - iv.Length];
            Array.Copy(fullCipher, salt.Length + iv.Length, cipher, 0, cipher.Length);

            string decrypted;
            using (var keyDerivationFunction = new Rfc2898DeriveBytes(password, salt, 10000, HashAlgorithmName.SHA256))
            {
                byte[] key = keyDerivationFunction.GetBytes(32);
                using (Aes aes = Aes.Create())
                {
                    aes.Key = key;
                    aes.IV = iv;
                    aes.Mode = CipherMode.CBC;
                    using (MemoryStream ms = new MemoryStream(cipher))
                    {
                        using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read))
                        {
                            using (StreamReader reader = new StreamReader(cs))
                            {
                                decrypted = reader.ReadToEnd();
                            }
                        }
                    }
                }
            }
            return decrypted;
        }

        private static byte[] GenerateRandomBytes(int count)
        {
            byte[] bytes = new byte[count];
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(bytes);
            }
            return bytes;
        }

        #endregion

        #region Вспомогательные методы обработки ошибок

        private static void LogError(string message)
        {
            try
            {
                string logEntry = $"{DateTime.Now}: {message}{Environment.NewLine}";
                File.AppendAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "error.log"), logEntry, Encoding.UTF8);
            }
            catch
            {
                
            }
        }

        private static bool IsBase64String(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return false;
            s = s.Trim();
            
            if (s.Length % 4 != 0)
                return false;
            try
            {
                Convert.FromBase64String(s);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private static void ResetFile()
        {
            try
            {
                File.Delete(filePath);
            }
            catch (Exception ex)
            {
                LogError("Не удалось сбросить файл событий: " + ex.Message);
            }
        }

        #endregion
    }
}
