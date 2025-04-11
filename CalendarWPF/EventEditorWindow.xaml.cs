using System;
using System.Collections.Generic;
using System.Device.Location; 
using System.Globalization;
using System.Windows;
using Microsoft.Win32; 
using CalendarLibrary;

namespace CalendarWPF
{
    public partial class EventEditorWindow : Window
    {
        

        public CalendarEvent CalendarEvent { get; private set; }

        public EventEditorWindow()
        {
            InitializeComponent();
            
            dpDate.SelectedDate = DateTime.Now.Date;
            tbTime.Text = DateTime.Now.ToString("HH:mm");
            CalendarEvent = new CalendarEvent(DateTime.Now, "", "");
        }

        
        public void SetEvent(CalendarEvent ev)
        {
            CalendarEvent = ev;
            dpDate.SelectedDate = ev.Date.Date;
            tbTime.Text = ev.Date.ToString("HH:mm");
            tbTitle.Text = ev.Title;
            tbDescription.Text = ev.Description;
            tbGeolocation.Text = ev.Geolocation;
            lbAttachments.Items.Clear();
            foreach (var file in ev.Attachments)
            {
                lbAttachments.Items.Add(file);
            }
        }

        
        private void btnAddAttachment_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog();
            dlg.Multiselect = false;
            if (dlg.ShowDialog() == true)
            {
                string filePath = dlg.FileName;
                lbAttachments.Items.Add(filePath);
            }
        }

        
        private void btnRemoveAttachment_Click(object sender, RoutedEventArgs e)
        {
            if (lbAttachments.SelectedItem != null)
            {
                lbAttachments.Items.Remove(lbAttachments.SelectedItem);
            }
        }

        
        private void btnGetCurrentLocation_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                GeoCoordinateWatcher watcher = new GeoCoordinateWatcher(GeoPositionAccuracy.Default);
                
                bool started = watcher.TryStart(false, TimeSpan.FromSeconds(5));
                if (started)
                {
                    var coord = watcher.Position.Location;
                    if (coord.IsUnknown)
                    {
                        MessageBox.Show("Не удалось определить текущее местоположение.", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        
                        tbGeolocation.Text = $"Lat: {coord.Latitude:F6}, Lon: {coord.Longitude:F6}";
                    }
                }
                else
                {
                    MessageBox.Show("Не удалось запустить определение местоположения.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при получении местоположения: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbTitle.Text))
            {
                MessageBox.Show("Заголовок не может быть пустым.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (!dpDate.SelectedDate.HasValue)
            {
                MessageBox.Show("Выберите дату.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            DateTime date = dpDate.SelectedDate.Value;
            if (!DateTime.TryParseExact(tbTime.Text, "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime time))
            {
                MessageBox.Show("Неверный формат времени. Используйте формат HH:mm.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            
            DateTime eventDateTime = new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, 0);


            var attachments = new List<string>();
            foreach (var item in lbAttachments.Items)
            {
                attachments.Add(item.ToString());
            }

            CalendarEvent = new CalendarEvent(
                eventDateTime,
                tbTitle.Text.Trim(),
                tbDescription.Text.Trim(),
                tbGeolocation.Text.Trim(),
                attachments
            );
            DialogResult = true;
            Close();
        }

        
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
