using System;

namespace CalendarLibrary
{
    public class CalendarEvent
    {
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public CalendarEvent(DateTime date, string title, string description)
        {
            Date = date;
            Title = title;
            Description = description;
        }

        public override string ToString()
        {
            return $"{Date.ToShortDateString()} - {Title}";
        }
    }
}