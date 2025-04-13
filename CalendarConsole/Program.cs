using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CalendarLibrary;

namespace CalendarConsole
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            Console.Title = "Консольный календарь";
            Console.WriteLine("Добро пожаловать в консольный календарь!");

            var settings = SettingsStorage.LoadSettings();

            if (settings.EncryptionEnabled && !string.IsNullOrEmpty(settings.EncryptionPassword))
            {
                bool authenticated = false;
                while (!authenticated)
                {
                    Console.Write("Введите пароль (или введите RESET для сброса): ");
                    var input = Console.ReadLine();

                    if (input == "RESET")
                    {
                        if (TryResetPassword())
                        {
                            settings = SettingsStorage.LoadSettings();
                            authenticated = true;
                        }
                        else
                        {
                            Console.WriteLine("Сброс не удался. Повторите попытку.");
                        }
                    }
                    else if (input == settings.EncryptionPassword)
                    {
                        authenticated = true;
                    }
                    else
                    {
                        Console.WriteLine("Неверный пароль.");
                    }
                }
            }

            var calendar = new CalendarManager();
            try
            {
                var loadedEvents = DataStorage.LoadEvents(settings.EncryptionEnabled, settings.EncryptionPassword);
                foreach (var ev in loadedEvents)
                    calendar.AddEvent(ev);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка загрузки событий: " + ex.Message);
            }

            while (true)
            {
                Console.WriteLine("\nМеню:");
                Console.WriteLine("1 - Добавить событие");
                Console.WriteLine("2 - Показать события");
                Console.WriteLine("3 - Удалить событие");
                Console.WriteLine("4 - Изменить настройки шифрования");
                Console.WriteLine("5 - Выход");

                Console.Write("Выбор: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddEvent(calendar);
                        break;
                    case "2":
                        ShowEvents(calendar);
                        break;
                    case "3":
                        DeleteEvent(calendar);
                        break;
                    case "4":
                        ChangeEncryptionSettings();
                        break;
                    case "5":
                        SaveAndExit(calendar, settings);
                        return;
                    default:
                        Console.WriteLine("Неверный выбор.");
                        break;
                }
            }
        }

        static void AddEvent(CalendarManager calendar)
        {
            Console.Write("Дата (гггг-мм-дд): ");
            string input = Console.ReadLine();
            if (!DateTime.TryParse(input, out DateTime date))
            {
                Console.WriteLine("Неверный формат.");
                return;
            }

            Console.Write("Заголовок: ");
            string title = Console.ReadLine();
            Console.Write("Описание: ");
            string desc = Console.ReadLine();

            calendar.AddEvent(new CalendarEvent(date, title, desc));
            Console.WriteLine("Событие добавлено.");
        }

        static void ShowEvents(CalendarManager calendar)
        {
            var events = calendar.GetEvents().ToList();
            if (events.Count == 0)
            {
                Console.WriteLine("Событий нет.");
                return;
            }

            Console.WriteLine("Список событий:");
            for (int i = 0; i < events.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {events[i].ToDetailedString()}");
            }
        }

        static void DeleteEvent(CalendarManager calendar)
        {
            var events = calendar.GetEvents().ToList();
            if (!events.Any())
            {
                Console.WriteLine("Нет событий для удаления.");
                return;
            }

            ShowEvents(calendar);
            Console.Write("Введите номер события для удаления: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= events.Count)
            {
                calendar.RemoveEvent(events[index - 1]);
                Console.WriteLine("Событие удалено.");
            }
            else
            {
                Console.WriteLine("Неверный индекс.");
            }
        }

        static void SaveAndExit(CalendarManager calendar, EncryptionSettings settings)
        {
            try
            {
                DataStorage.SaveEvents(calendar.GetEvents(), settings.EncryptionEnabled, settings.EncryptionPassword);
                Console.WriteLine("События сохранены. До свидания!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при сохранении: " + ex.Message);
            }
        }

        static bool TryResetPassword()
        {
            var questions = SecurityQuestionsStorage.LoadQuestions();
            Console.WriteLine("Для сброса пароля ответьте на контрольные вопросы:");
            foreach (var q in questions)
            {
                Console.Write(q.Question + " ");
                if (!Console.ReadLine().Trim().Equals(q.Answer, StringComparison.OrdinalIgnoreCase))
                    return false;
            }

            Console.Write("Введите новый пароль: ");
            string newPwd = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(newPwd) || newPwd.Length < 6)
            {
                Console.WriteLine("Пароль должен быть не менее 6 символов.");
                return false;
            }

            var newSettings = new EncryptionSettings
            {
                EncryptionEnabled = true,
                EncryptionPassword = newPwd
            };
            SettingsStorage.SaveSettings(newSettings);
            return true;
        }

        static void ChangeEncryptionSettings()
        {
            Console.Write("Включить шифрование? (да/нет): ");
            string enable = Console.ReadLine().ToLower();
            if (enable == "да")
            {
                Console.Write("Введите новый пароль: ");
                string pwd = Console.ReadLine();
                if (pwd.Length < 6)
                {
                    Console.WriteLine("Пароль слишком короткий.");
                    return;
                }

                var newSettings = new EncryptionSettings
                {
                    EncryptionEnabled = true,
                    EncryptionPassword = pwd
                };
                SettingsStorage.SaveSettings(newSettings);
                Console.WriteLine("Шифрование включено.");
            }
            else
            {
                Console.WriteLine("Ответьте на контрольные вопросы для отключения шифрования:");
                if (TryResetPassword())
                {
                    var newSettings = new EncryptionSettings
                    {
                        EncryptionEnabled = false,
                        EncryptionPassword = string.Empty
                    };
                    SettingsStorage.SaveSettings(newSettings);
                    Console.WriteLine("Шифрование отключено.");
                }
                else
                {
                    Console.WriteLine("Неверные ответы.");
                }
            }
        }
    }
}
