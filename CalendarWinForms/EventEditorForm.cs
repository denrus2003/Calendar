using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CalendarLibrary;
using System.Device.Location;

namespace CalendarWinForms
{
    public partial class EventEditorForm : Form
    {
       
        public CalendarEvent CalendarEvent { get; private set; }

        public EventEditorForm()
        {
            InitializeComponent();
            // Если создаётся новое событие, устанавливаем начальные значения
            CalendarEvent = new CalendarEvent(DateTime.Now, "", "", "");
        }

        
        public void SetEvent(CalendarEvent ev)
        {
            CalendarEvent = ev;
            dtpDate.Value = ev.Date;
            txtTitle.Text = ev.Title;
            txtDescription.Text = ev.Description;
            txtGeolocation.Text = ev.Geolocation;
            lbAttachments.Items.Clear();
            foreach (var file in ev.Attachments)
            {
                lbAttachments.Items.Add(file);
            }
        }

        
        private void btnAddAttachment_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFile = new OpenFileDialog())
            {
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFile.FileName;
                    lbAttachments.Items.Add(filePath);
                }
            }
        }

        
        private void btnRemoveAttachment_Click(object sender, EventArgs e)
        {
            if (lbAttachments.SelectedItem != null)
            {
                lbAttachments.Items.Remove(lbAttachments.SelectedItem);
            }
        }

        
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Проверка: заголовок не может быть пустым
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Заголовок не может быть пустым.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
            var attachments = new List<string>();
            foreach (var item in lbAttachments.Items)
            {
                attachments.Add(item.ToString());
            }

            
            CalendarEvent = new CalendarEvent(
                dtpDate.Value,
                txtTitle.Text.Trim(),
                txtDescription.Text.Trim(),
                txtGeolocation.Text.Trim(),
                attachments
            );
            DialogResult = DialogResult.OK;
            Close();
        }
        private void btnGetCurrentLocation_Click(object sender, EventArgs e)
        {
            try
            {
                // Создаем наблюдатель за геопозицией
                GeoCoordinateWatcher watcher = new GeoCoordinateWatcher(GeoPositionAccuracy.Default);
                // Пытаемся запустить наблюдение (таймаут 5 секунд)
                bool started = watcher.TryStart(false, TimeSpan.FromSeconds(5));
                if (started)
                {
                    var coord = watcher.Position.Location;
                    if (coord.IsUnknown)
                    {
                        MessageBox.Show("Не удалось определить текущее местоположение.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // Устанавливаем в поле геопозиции координаты в формате "Lat: <широта>, Lon: <долгота>"
                        txtGeolocation.Text = $"Lat: {coord.Latitude:F6}, Lon: {coord.Longitude:F6}";
                    }
                }
                else
                {
                    MessageBox.Show("Не удалось запустить определение местоположения.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при получении местоположения: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
