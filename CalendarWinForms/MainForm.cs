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
            // Открытие диалогового окна для ввода данных события
            using (var editor = new EventEditorForm())
            {
                if (editor.ShowDialog() == DialogResult.OK)
                {
                    // Добавление события и обновление списка
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
    }
}