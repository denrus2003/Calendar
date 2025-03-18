using System;
using CalendarLibrary;

namespace CalendarConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            CalendarManager calendar = new CalendarManager();
            Console.WriteLine("Календарь. Консольное приложение");
            while (true)
            {
                Console.WriteLine("\nВыберите опцию:");
                Console.WriteLine("1 - Добавить событие");
                Console.WriteLine("2 - Показать события");
                Console.WriteLine("3 - Выход");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.Write("Введите дату (гггг-мм-дд): ");
                    string dateInput = Console.ReadLine();
                    if (DateTime.TryParse(dateInput, out DateTime date))
                    {
                        Console.Write("Введите заголовок: ");
                        string title = Console.ReadLine();
                        Console.Write("Введите описание: ");
                        string description = Console.ReadLine();

                        calendar.AddEvent(new CalendarEvent(date, title, description));
                        Console.WriteLine("Событие добавлено!");
                    }
                    else
                    {
                        Console.WriteLine("Неверный формат даты.");
                    }
                }
                else if (choice == "2")
                {
                    Console.WriteLine("Список событий:");
                    foreach (var ev in calendar.GetEvents())
                    {
                        Console.WriteLine(ev.ToString());
                    }
                }
                else if (choice == "3")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Неверный выбор, попробуйте ещё раз.");
                }
            }
        }
    }
}