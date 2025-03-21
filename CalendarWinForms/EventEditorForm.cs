// EventEditorForm.cs
// Форма для ввода данных события (дата, заголовок, описание) в WinForms.
using System;
using System.Windows.Forms;
using CalendarLibrary;

namespace CalendarWinForms
{
    public partial class EventEditorForm : Form
    {
        // Свойство для хранения созданного события
        public CalendarEvent CalendarEvent { get; private set; }

        public EventEditorForm()
        {
            InitializeComponent(); // Инициализация элементов формы (генерируется через Designer)
        }

        // Обработчик нажатия кнопки "Сохранить"
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Валидация введенных данных
            if (!DateTime.TryParse(txtDate.Text, out DateTime date))
            {
                MessageBox.Show("Неверный формат даты. Используйте формат гггг-мм-дд.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string title = txtTitle.Text.Trim();
            if (string.IsNullOrEmpty(title))
            {
                MessageBox.Show("Заголовок не может быть пустым.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string description = txtDescription.Text.Trim();

            // Создаем событие и закрываем форму с результатом OK
            CalendarEvent = new CalendarEvent(date, title, description);
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}