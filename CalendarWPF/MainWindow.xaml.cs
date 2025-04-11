using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using CalendarLibrary;
using Microsoft.Toolkit.Uwp.Notifications; 
using MessageBox = System.Windows.MessageBox;

namespace CalendarWPF
{
    public partial class MainWindow : Window
    {
        private CalendarManager calendar;
        
        private string appId = "CalendarWPF.App";

        public MainWindow()
        {
            InitializeComponent();

            calendar = new CalendarManager();
            calendar.EventTimeReached += Calendar_EventTimeReached;

            
            cbDisplayFormat.Items.Add("Краткий формат");
            cbDisplayFormat.Items.Add("Подробный формат");
            cbDisplayFormat.SelectedIndex = 0;

            RefreshEventList();
        }

        
        private void Calendar_EventTimeReached(CalendarEvent ev)
        {
            
            Dispatcher.Invoke(() => ShowToastNotification(ev));
        }

        
        private void ShowToastNotification(CalendarEvent ev)
        {
            new ToastContentBuilder()
                .AddText("Событие наступило!")
                .AddText(ev.Title)
                .Show();
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
            if (lbEvents.SelectedItem is CalendarEvent ev)
            {
                calendar.RemoveEvent(ev);
                RefreshEventList();
            }
            else
            {
                MessageBox.Show("Выберите событие для удаления.");
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
                    
                    calendar.EditEvent(ev, editor.CalendarEvent);
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
            if (cbDisplayFormat.SelectedIndex == 1)
                return ev.ToDetailedString();
            else
                return ev.ToString();
        }

        private void RefreshEventList()
        {
            lbEvents.ItemsSource = null;
            lbEvents.ItemsSource = calendar.GetEvents().ToList();
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            
            
            e.Cancel = true;
            this.Hide();

            
            new ToastContentBuilder()
                .AddText("Приложение свернуто")
                .AddText("Приложение продолжает работать в фоновом режиме")
                .Show();

            base.OnClosing(e);
        }
    }
}
