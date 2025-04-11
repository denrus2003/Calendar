using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CalendarLibrary;

namespace CalendarWinForms
{
    public partial class MainForm : Form
    {
        private CalendarManager calendar;
        private Timer notificationTimer;

        public MainForm()
        {
            InitializeComponent();
            calendar = new CalendarManager();
            cbDisplayFormat.Items.AddRange(new string[] { "Краткий формат", "Подробный формат" });
            cbDisplayFormat.SelectedIndex = 0;
            notificationTimer = new Timer();
            notificationTimer.Interval = 60000; 
            notificationTimer.Tick += NotificationTimer_Tick;
            notificationTimer.Start();
            notifyIcon.Icon = Properties.Resources.Dakirby309_Windows_8_Metro_Apps_Calendar_Metro;
            notifyIcon.Visible = true;
            this.Icon = Properties.Resources.Dakirby309_Windows_8_Metro_Apps_Calendar_Metro;
            RefreshEvents();
        }

        private void NotificationTimer_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            DateTime nextCheck = now.AddMilliseconds(notificationTimer.Interval);

            foreach (var ev in calendar.GetEvents())
            {
                if (!ev.Notified && ev.Date >= now && ev.Date <= nextCheck)
                {
                    ev.Notified = true;
                    notifyIcon.BalloonTipTitle = "Событие наступило!";
                    notifyIcon.BalloonTipText = ev.Title;
                    notifyIcon.ShowBalloonTip(5000); 
                }
            }
        }


        private void btnAddEvent_Click(object sender, EventArgs e)
        {
            using (var editor = new EventEditorForm())
            {
                if (editor.ShowDialog() == DialogResult.OK)
                {
                    calendar.AddEvent(editor.CalendarEvent);
                    RefreshEvents();
                }
            }
        }

        // Обработчик нажатия кнопки "Удалить событие"
        private void btnRemoveEvent_Click(object sender, EventArgs e)
        {
            if (listBoxEvents.SelectedItem is CalendarEvent selectedEvent)
            {
                calendar.RemoveEvent(selectedEvent);
                RefreshEvents();
            }
            else
            {
                MessageBox.Show("Выберите событие для удаления.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void listBoxEvents_DoubleClick(object sender, EventArgs e)
        {
            int index = listBoxEvents.SelectedIndex;
            List<CalendarEvent> events = new List<CalendarEvent>(calendar.GetEvents());
            if (index >= 0 && index < events.Count)
            {
                CalendarEvent selectedEvent = events[index];
                using (var editor = new EventEditorForm())
                {
                    // Передаем текущее событие в редактор для редактирования
                    editor.SetEvent(selectedEvent);
                    if (editor.ShowDialog() == DialogResult.OK)
                    {
                        // Обновляем свойства события
                        selectedEvent.Date = editor.CalendarEvent.Date;
                        selectedEvent.Title = editor.CalendarEvent.Title;
                        selectedEvent.Description = editor.CalendarEvent.Description;
                        selectedEvent.Geolocation = editor.CalendarEvent.Geolocation;
                        selectedEvent.Attachments = editor.CalendarEvent.Attachments;
                        selectedEvent.Notified = false; // Сброс уведомления
                        RefreshEvents();
                    }
                }
            }
        }

        // Изменение формата отображения – вызывается при изменении выбранного значения в ComboBox
        private void cbDisplayFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshEvents();
        }

        // Метод для форматирования отображения события в зависимости от выбранного формата
        private string FormatEvent(CalendarEvent ev)
        {
            if (cbDisplayFormat.SelectedIndex == 1)
            {
                return ev.ToDetailedString();
            }
            else
            {
                return ev.ToString();
            }
        }

        private void RefreshEvents()
        {
            // Обновляем источник данных для ListBox.
            listBoxEvents.DataSource = null;
            listBoxEvents.DataSource = new BindingSource { DataSource = calendar.GetEvents() };
        }

        private void listBoxEvents_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void MainForm_Load_1(object sender, EventArgs e)
        {

        }

        private void listBoxEvents_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;  
                this.Hide();      
                notifyIcon.ShowBalloonTip(2000, "Приложение свернуто", "Приложение продолжает работать в системном трее", ToolTipIcon.Info);
            }
            base.OnFormClosing(e);
        }

        
        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void listBoxEvents_SelectedIndexChanged_2(object sender, EventArgs e)
        {

        }
    }
}
    
