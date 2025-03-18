using System.Collections.Generic;

namespace CalendarLibrary
{
    public class CalendarManager
    {
        private List<CalendarEvent> _events;

        public CalendarManager()
        {
            _events = new List<CalendarEvent>();
        }

        public void AddEvent(CalendarEvent calendarEvent)
        {
            _events.Add(calendarEvent);
        }

        public bool RemoveEvent(CalendarEvent calendarEvent)
        {
            return _events.Remove(calendarEvent);
        }

        public IEnumerable<CalendarEvent> GetEvents()
        {
            return _events;
        }
    }
}