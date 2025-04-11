namespace CalendarWinForms
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // Элементы управления
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.ListBox lbEvents;
        private System.Windows.Forms.FlowLayoutPanel panelBottom;
        private System.Windows.Forms.Button btnAddEvent;
        private System.Windows.Forms.Button btnRemoveEvent;
        private System.Windows.Forms.ComboBox cbDisplayFormat;
        private System.Windows.Forms.NotifyIcon notifyIcon;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Метод, необходимый для поддержки конструктора – не изменяйте 
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.lbEvents = new System.Windows.Forms.ListBox();
            this.panelBottom = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddEvent = new System.Windows.Forms.Button();
            this.btnRemoveEvent = new System.Windows.Forms.Button();
            this.cbDisplayFormat = new System.Windows.Forms.ComboBox();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.tableLayoutPanelMain.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.ColumnCount = 1;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.Controls.Add(this.lbEvents, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.panelBottom, 0, 1);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMain.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 2;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(1048, 506);
            this.tableLayoutPanelMain.TabIndex = 0;
            // 
            // lbEvents
            // 
            this.lbEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbEvents.FormattingEnabled = true;
            this.lbEvents.ItemHeight = 31;
            this.lbEvents.Location = new System.Drawing.Point(6, 6);
            this.lbEvents.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.lbEvents.Name = "lbEvents";
            this.lbEvents.Size = new System.Drawing.Size(1036, 392);
            this.lbEvents.TabIndex = 0;
            this.lbEvents.DoubleClick += new System.EventHandler(this.lbEvents_DoubleClick);
            // 
            // panelBottom
            // 
            this.panelBottom.AutoSize = true;
            this.panelBottom.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelBottom.Controls.Add(this.btnAddEvent);
            this.panelBottom.Controls.Add(this.btnRemoveEvent);
            this.panelBottom.Controls.Add(this.cbDisplayFormat);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBottom.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.panelBottom.Location = new System.Drawing.Point(6, 410);
            this.panelBottom.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(1036, 90);
            this.panelBottom.TabIndex = 1;
            // 
            // btnAddEvent
            // 
            this.btnAddEvent.AutoSize = true;
            this.btnAddEvent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAddEvent.Location = new System.Drawing.Point(745, 19);
            this.btnAddEvent.Margin = new System.Windows.Forms.Padding(20, 19, 20, 19);
            this.btnAddEvent.Name = "btnAddEvent";
            this.btnAddEvent.Size = new System.Drawing.Size(271, 42);
            this.btnAddEvent.TabIndex = 0;
            this.btnAddEvent.Text = "Добавить событие";
            this.btnAddEvent.UseVisualStyleBackColor = true;
            this.btnAddEvent.Click += new System.EventHandler(this.btnAddEvent_Click);
            // 
            // btnRemoveEvent
            // 
            this.btnRemoveEvent.AutoSize = true;
            this.btnRemoveEvent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRemoveEvent.Location = new System.Drawing.Point(453, 19);
            this.btnRemoveEvent.Margin = new System.Windows.Forms.Padding(20, 19, 20, 19);
            this.btnRemoveEvent.Name = "btnRemoveEvent";
            this.btnRemoveEvent.Size = new System.Drawing.Size(252, 42);
            this.btnRemoveEvent.TabIndex = 1;
            this.btnRemoveEvent.Text = "Удалить событие";
            this.btnRemoveEvent.UseVisualStyleBackColor = true;
            this.btnRemoveEvent.Click += new System.EventHandler(this.btnRemoveEvent_Click);
            // 
            // cbDisplayFormat
            // 
            this.cbDisplayFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDisplayFormat.FormattingEnabled = true;
            this.cbDisplayFormat.Location = new System.Drawing.Point(177, 19);
            this.cbDisplayFormat.Margin = new System.Windows.Forms.Padding(20, 19, 20, 19);
            this.cbDisplayFormat.Name = "cbDisplayFormat";
            this.cbDisplayFormat.Size = new System.Drawing.Size(236, 39);
            this.cbDisplayFormat.TabIndex = 2;
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
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1048, 506);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Календарь WinForms";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.tableLayoutPanelMain.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
