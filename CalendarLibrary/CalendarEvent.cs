using System;
using System.Collections.Generic;

namespace CalendarLibrary
{
    public class CalendarEvent
    {
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public string Geolocation {  get; set; }
        public List<string> Attachments { get; set; }
        public bool Notified { get; set; }

        public CalendarEvent(DateTime date, string title, string description, string geolocation = "", List<string> attachments = null)
        {
            Date = date;
            Title = title;
            Description = description;
            Geolocation = geolocation;
            Attachments = attachments ?? new List<string>();
            Notified = false;


        }

        public override string ToString()
        {
            return $"{Date.ToString("g")} - {Title}";
        }

        public string ToDetailedString()
        {
            string attachmentsStr = (Attachments != null && Attachments.Count > 0) ? string.Join(", ", Attachments) : "Нет";
            return $"Дата: {Date.ToString("f")}\nЗаголовок: {Title}\nОписание: {Description}\nМестоположение: {Geolocation}\nВложения: {attachmentsStr}";
        }

    }
}