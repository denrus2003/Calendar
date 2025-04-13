using System;
using System.Collections.Generic;
using System.Threading;

namespace CalendarLibrary
{
    public class CalendarManager
    {
       
        private List<CalendarEvent> _events;
       
        private Dictionary<CalendarEvent, Timer> _eventTimers;

        
        public event Action<CalendarEvent> EventTimeReached;

        public CalendarManager()
        {
            _events = new List<CalendarEvent>();
            _eventTimers = new Dictionary<CalendarEvent, Timer>();
        }

        
        public void AddEvent(CalendarEvent ev)
        {
            _events.Add(ev);
            if (ev.Date > DateTime.Now)
            {
                CreateTimerForEvent(ev);
            }
            else if (!ev.Notified)
            {
                
                ev.Notified = true;
                OnEventTimeReached(ev);
            }
        }


        private void CreateTimerForEvent(CalendarEvent ev)
        {
            double ms = (ev.Date - DateTime.Now).TotalMilliseconds;
            if (ms < 0)
                ms = 0; 

            
            int dueTime = ms > int.MaxValue ? int.MaxValue : (int)ms;

            Timer timer = new Timer((state) =>
            {
                ev.Notified = true;
                OnEventTimeReached(ev);
                RemoveTimer(ev);
            }, null, dueTime, Timeout.Infinite);

            _eventTimers[ev] = timer;
        }


        private void OnEventTimeReached(CalendarEvent ev)
        {
            EventTimeReached?.Invoke(ev);
        }

        
        private void RemoveTimer(CalendarEvent ev)
        {
            if (_eventTimers.ContainsKey(ev))
            {
                _eventTimers[ev].Dispose();
                _eventTimers.Remove(ev);
            }
        }

        
        public void RemoveEvent(CalendarEvent ev)
        {
            _events.Remove(ev);
            if (_eventTimers.ContainsKey(ev))
            {
                _eventTimers[ev].Dispose();
                _eventTimers.Remove(ev);
            }
        }

        
        public void EditEvent(CalendarEvent oldEvent, CalendarEvent newEvent)
        {
            RemoveEvent(oldEvent);
            AddEvent(newEvent);
        }

        public IEnumerable<CalendarEvent> GetEvents()
        {
            return _events;
        }
    }
}
