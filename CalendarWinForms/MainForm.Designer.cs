// MainForm.Designer.cs
// Дизайнерский файл для MainForm. Здесь создаются и размещаются элементы управления.
namespace CalendarWinForms
{
    partial class MainForm
    {
        // Обязательная переменная конструктора.
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListBox listBoxEvents;
        private System.Windows.Forms.Button btnAddEvent;
        private System.Windows.Forms.Button btnRemoveEvent;
        private System.Windows.Forms.ComboBox cbDisplayFormat; 
        private System.Windows.Forms.NotifyIcon notifyIcon;  

        // Очистка ресурсов.
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        // Метод, автоматически созданный конструктором форм.
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.listBoxEvents = new System.Windows.Forms.ListBox();
            this.btnAddEvent = new System.Windows.Forms.Button();
            this.btnRemoveEvent = new System.Windows.Forms.Button();
            this.cbDisplayFormat = new System.Windows.Forms.ComboBox();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.SuspendLayout();
            // 
            // listBoxEvents
            // 
            this.listBoxEvents.FormattingEnabled = true;
            this.listBoxEvents.ItemHeight = 31;
            this.listBoxEvents.Location = new System.Drawing.Point(12, 12);
            this.listBoxEvents.Name = "listBoxEvents";
            this.listBoxEvents.Size = new System.Drawing.Size(500, 159);
            this.listBoxEvents.TabIndex = 0;
            this.listBoxEvents.SelectedIndexChanged += new System.EventHandler(this.listBoxEvents_SelectedIndexChanged_2);
            this.listBoxEvents.DoubleClick += new System.EventHandler(this.listBoxEvents_DoubleClick);
            // 
            // btnAddEvent
            // 
            this.btnAddEvent.Location = new System.Drawing.Point(12, 210);
            this.btnAddEvent.Name = "btnAddEvent";
            this.btnAddEvent.Size = new System.Drawing.Size(150, 30);
            this.btnAddEvent.TabIndex = 1;
            this.btnAddEvent.Text = "Добавить событие";
            this.btnAddEvent.UseVisualStyleBackColor = true;
            this.btnAddEvent.Click += new System.EventHandler(this.btnAddEvent_Click);
            // 
            // btnRemoveEvent
            // 
            this.btnRemoveEvent.Location = new System.Drawing.Point(362, 210);
            this.btnRemoveEvent.Name = "btnRemoveEvent";
            this.btnRemoveEvent.Size = new System.Drawing.Size(150, 30);
            this.btnRemoveEvent.TabIndex = 2;
            this.btnRemoveEvent.Text = "Удалить событие";
            this.btnRemoveEvent.UseVisualStyleBackColor = true;
            this.btnRemoveEvent.Click += new System.EventHandler(this.btnRemoveEvent_Click);
            // 
            // cbDisplayFormat
            // 
            this.cbDisplayFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDisplayFormat.FormattingEnabled = true;
            this.cbDisplayFormat.Location = new System.Drawing.Point(180, 215);
            this.cbDisplayFormat.Name = "cbDisplayFormat";
            this.cbDisplayFormat.Size = new System.Drawing.Size(170, 39);
            this.cbDisplayFormat.TabIndex = 3;
            this.cbDisplayFormat.SelectedIndexChanged += new System.EventHandler(this.cbDisplayFormat_SelectedIndexChanged);
            // 
            // notifyIcon
            // 
            this.notifyIcon.Text = "Calendar Notifications";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(524, 261);
            this.Controls.Add(this.cbDisplayFormat);
            this.Controls.Add(this.btnRemoveEvent);
            this.Controls.Add(this.btnAddEvent);
            this.Controls.Add(this.listBoxEvents);
            this.Name = "MainForm";
            this.Text = "Календарь WinForms";
            this.ResumeLayout(false);

        }
    }
}