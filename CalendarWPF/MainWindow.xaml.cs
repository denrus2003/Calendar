using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using CalendarLibrary;

namespace CalendarWPF
{
    public partial class MainWindow : Window
    {
        private CalendarManager calendar;
        private EncryptionSettings encryptionSettings;
        private System.Windows.Threading.DispatcherTimer notificationTimer;

        
        private string eventsFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "events.dat");

        public MainWindow()
        {
            InitializeComponent();

            
            encryptionSettings = SettingsStorage.LoadSettings();

            
            if (!encryptionSettings.EncryptionEnabled && string.IsNullOrEmpty(encryptionSettings.EncryptionPassword))
            {
                MessageBoxResult dr = MessageBox.Show("Вы хотите включить шифрование данных событий? Если да, настройте пароль.",
                    "Настройка шифрования", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (dr == MessageBoxResult.Yes)
                {
                    var frm = new EncryptionSettingsWindow();
                    if (frm.ShowDialog() == true)
                    {
                        encryptionSettings = SettingsStorage.LoadSettings();
                    }
                }
            }

            
            calendar = new CalendarManager();
            List<CalendarEvent> loadedEvents = DataStorage.LoadEvents(encryptionSettings.EncryptionEnabled, encryptionSettings.EncryptionPassword);
            foreach (var ev in loadedEvents)
            {
                calendar.AddEvent(ev);
            }

            cbDisplayFormat.Items.Add("Краткий формат");
            cbDisplayFormat.Items.Add("Подробный формат");
            cbDisplayFormat.SelectedIndex = 0;

            
            notificationTimer = new System.Windows.Threading.DispatcherTimer();
            notificationTimer.Interval = TimeSpan.FromMinutes(1);
            notificationTimer.Tick += NotificationTimer_Tick;
            notificationTimer.Start();

            RefreshEventList();
        }

        private void NotificationTimer_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            DateTime nextCheck = now.Add(notificationTimer.Interval);
            foreach (var ev in calendar.GetEvents())
            {
                if (!ev.Notified && ev.Date >= now && ev.Date <= nextCheck)
                {
                    ev.Notified = true;
                    
                    MessageBox.Show($"Событие \"{ev.Title}\" наступило!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private void btnAddEvent_Click(object sender, RoutedEventArgs e)
        {
            var editor = new EventEditorWindow();
            if (editor.ShowDialog() == true)
            {
                calendar.AddEvent(editor.CalendarEvent);
                RefreshEventList();
            }
        }

        private void btnRemoveEvent_Click(object sender, RoutedEventArgs e)
        {
            if (lbEvents.SelectedItem is CalendarEvent selectedEvent)
            {
                calendar.RemoveEvent(selectedEvent);
                RefreshEventList();
            }
            else
            {
                MessageBox.Show("Выберите событие для удаления.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        
        private void lbEvents_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lbEvents.SelectedItem is CalendarEvent ev)
            {
                var editor = new EventEditorWindow();
                editor.SetEvent(ev);
                if (editor.ShowDialog() == true)
                {
                    ev.Date = editor.CalendarEvent.Date;
                    ev.Title = editor.CalendarEvent.Title;
                    ev.Description = editor.CalendarEvent.Description;
                    ev.Geolocation = editor.CalendarEvent.Geolocation;
                    ev.Attachments = editor.CalendarEvent.Attachments;
                    ev.Notified = false;
                    RefreshEventList();
                }
            }
        }

        private void cbDisplayFormat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RefreshEventList();
        }

        
        private string FormatEvent(CalendarEvent ev)
        {
            return cbDisplayFormat.SelectedIndex == 1 ? ev.ToDetailedString() : ev.ToString();
        }

        private void RefreshEventList()
        {
            lbEvents.ItemsSource = calendar.GetEvents().ToList();
        }
    }
}
