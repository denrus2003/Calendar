using System;
using System.Windows;
using CalendarLibrary;

namespace CalendarWPF
{
    public partial class MainWindow : Window
    {
        private CalendarManager calendar;

        public MainWindow()
        {
            InitializeComponent();
            calendar = new CalendarManager();
            RefreshEvents();
        }

        private void btnAddEvent_Click(object sender, RoutedEventArgs e)
        {
           
            DateTime date = DateTime.Now;
            string title = "Новое событие";
            string description = "Описание события";
            calendar.AddEvent(new CalendarEvent(date, title, description));
            RefreshEvents();
        }

        private void RefreshEvents()
        {
            lbEvents.ItemsSource = null;
            lbEvents.ItemsSource = calendar.GetEvents();
        }
    }
}