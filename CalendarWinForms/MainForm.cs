using System;
using System.Windows.Forms;
using CalendarLibrary;

namespace CalendarWinForms
{
    public partial class MainForm : Form
    {
        private CalendarManager calendar;

        public MainForm()
        {
            InitializeComponent();
            calendar = new CalendarManager();
            RefreshEvents();
        }

        private void btnAddEvent_Click(object sender, EventArgs e)
        {
            // В этом примере для простоты события добавляются с текущей датой и фиксированными данными.
            DateTime date = DateTime.Now;
            string title = "Новое событие";
            string description = "Описание события";

            calendar.AddEvent(new CalendarEvent(date, title, description));
            RefreshEvents();
        }

        private void RefreshEvents()
        {
            // Обновляем источник данных для ListBox.
            listBoxEvents.DataSource = null;
            listBoxEvents.DataSource = new BindingSource { DataSource = calendar.GetEvents() };
        }
    }
}