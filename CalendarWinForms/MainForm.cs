using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CalendarLibrary;
using CalendarWinForms.Properties;

namespace CalendarWinForms
{
    public partial class MainForm : Form
    {
        private CalendarManager calendar;
        private EncryptionSettings encryptionSettings;
        private Timer notificationTimer;
        private string eventsFile = Path.Combine(Application.StartupPath, "events.dat");

        private void MainForm_Load(object sender, EventArgs e) { }

        public MainForm()
        {
            InitializeComponent();

            
            encryptionSettings = SettingsStorage.LoadSettings();
            
            if (!encryptionSettings.EncryptionEnabled && string.IsNullOrEmpty(encryptionSettings.EncryptionPassword))
            {
                DialogResult dr = MessageBox.Show("Вы хотите включить шифрование данных событий? Если да, настройте пароль.",
                    "Настройка шифрования", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    using (var frm = new EncryptionSettingsForm())
                    {
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            encryptionSettings = SettingsStorage.LoadSettings();
                        }
                    }
                }
            }

            calendar = new CalendarManager();
            List<CalendarEvent> loadedEvents = DataStorage.LoadEvents(encryptionSettings.EncryptionEnabled, encryptionSettings.EncryptionPassword);
            foreach (var ev in loadedEvents)
                calendar.AddEvent(ev);

            cbDisplayFormat.Items.AddRange(new string[] { "Краткий формат", "Подробный формат" });
            cbDisplayFormat.SelectedIndex = 0;

            notificationTimer = new Timer();
            notificationTimer.Interval = 60000;
            notificationTimer.Tick += NotificationTimer_Tick;
            notificationTimer.Start();

            notifyIcon.Icon = Properties.Resources.Dakirby309_Windows_8_Metro_Apps_Calendar_Metro;
            notifyIcon.Visible = true;
            this.Icon = Properties.Resources.Dakirby309_Windows_8_Metro_Apps_Calendar_Metro;

            RefreshEventList();
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
                    RefreshEventList();
                }
            }
        }

        private void btnRemoveEvent_Click(object sender, EventArgs e)
        {
            if (lbEvents.SelectedItem is CalendarEvent selectedEvent)
            {
                calendar.RemoveEvent(selectedEvent);
                RefreshEventList();
            }
            else
            {
                MessageBox.Show("Выберите событие для удаления.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void lbEvents_DoubleClick(object sender, EventArgs e)
        {
            if (lbEvents.SelectedItem is CalendarEvent ev)
            {
                using (var editor = new EventEditorForm())
                {
                    editor.SetEvent(ev);
                    if (editor.ShowDialog() == DialogResult.OK)
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
        }

        private void cbDisplayFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshEventList();
        }

        private void RefreshEventList()
        {
            lbEvents.DataSource = null;
            lbEvents.DataSource = calendar.GetEvents().ToList();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DataStorage.SaveEvents(calendar.GetEvents(), encryptionSettings.EncryptionEnabled, encryptionSettings.EncryptionPassword);
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

        private void lbEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
