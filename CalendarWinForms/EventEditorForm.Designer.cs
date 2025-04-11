// EventEditorForm.Designer.cs
namespace CalendarWinForms
{
    partial class EventEditorForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DateTimePicker dtpDate; 
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtGeolocation; 
        private System.Windows.Forms.ListBox lbAttachments; 
        private System.Windows.Forms.Button btnAddAttachment; 
        private System.Windows.Forms.Button btnRemoveAttachment; 
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblGeolocation;
        private System.Windows.Forms.Label lblAttachments;
        private System.Windows.Forms.Button btnGetCurrentLocation;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtGeolocation = new System.Windows.Forms.TextBox();
            this.lbAttachments = new System.Windows.Forms.ListBox();
            this.btnAddAttachment = new System.Windows.Forms.Button();
            this.btnRemoveAttachment = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblGeolocation = new System.Windows.Forms.Label();
            this.lblAttachments = new System.Windows.Forms.Label();
            this.btnGetCurrentLocation = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(12, 15);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(120, 17);
            this.lblDate.TabIndex = 0;
            this.lblDate.Text = "Дата и время:";
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(150, 12);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(200, 22);
            this.dtpDate.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(12, 50);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(70, 17);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Заголовок:";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(150, 47);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(200, 22);
            this.txtTitle.TabIndex = 3;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(12, 85);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(76, 17);
            this.lblDescription.TabIndex = 4;
            this.lblDescription.Text = "Описание:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(150, 82);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(200, 60);
            this.txtDescription.TabIndex = 5;
            // 
            // lblGeolocation
            // 
            this.lblGeolocation.AutoSize = true;
            this.lblGeolocation.Location = new System.Drawing.Point(12, 155);
            this.lblGeolocation.Name = "lblGeolocation";
            this.lblGeolocation.Size = new System.Drawing.Size(90, 17);
            this.lblGeolocation.TabIndex = 6;
            this.lblGeolocation.Text = "Геопозиция:";
            // 
            // txtGeolocation
            // 
            this.txtGeolocation.Location = new System.Drawing.Point(150, 152);
            this.txtGeolocation.Name = "txtGeolocation";
            this.txtGeolocation.Size = new System.Drawing.Size(200, 22);
            this.txtGeolocation.TabIndex = 7;
            // 
            // lblAttachments
            // 
            this.lblAttachments.AutoSize = true;
            this.lblAttachments.Location = new System.Drawing.Point(12, 190);
            this.lblAttachments.Name = "lblAttachments";
            this.lblAttachments.Size = new System.Drawing.Size(85, 17);
            this.lblAttachments.TabIndex = 8;
            this.lblAttachments.Text = "Вложения:";
            // 
            // lbAttachments
            // 
            this.lbAttachments.FormattingEnabled = true;
            this.lbAttachments.ItemHeight = 16;
            this.lbAttachments.Location = new System.Drawing.Point(150, 190);
            this.lbAttachments.Name = "lbAttachments";
            this.lbAttachments.Size = new System.Drawing.Size(200, 60);
            this.lbAttachments.TabIndex = 9;
            // 
            // btnAddAttachment
            // 
            this.btnAddAttachment.Location = new System.Drawing.Point(150, 260);
            this.btnAddAttachment.Name = "btnAddAttachment";
            this.btnAddAttachment.Size = new System.Drawing.Size(95, 30);
            this.btnAddAttachment.TabIndex = 10;
            this.btnAddAttachment.Text = "Добавить";
            this.btnAddAttachment.UseVisualStyleBackColor = true;
            this.btnAddAttachment.Click += new System.EventHandler(this.btnAddAttachment_Click);
            // 
            // btnRemoveAttachment
            // 
            this.btnRemoveAttachment.Location = new System.Drawing.Point(255, 260);
            this.btnRemoveAttachment.Name = "btnRemoveAttachment";
            this.btnRemoveAttachment.Size = new System.Drawing.Size(95, 30);
            this.btnRemoveAttachment.TabIndex = 11;
            this.btnRemoveAttachment.Text = "Удалить";
            this.btnRemoveAttachment.UseVisualStyleBackColor = true;
            this.btnRemoveAttachment.Click += new System.EventHandler(this.btnRemoveAttachment_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(150, 310);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // EventEditorForm
            // 
            this.ClientSize = new System.Drawing.Size(370, 360);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnRemoveAttachment);
            this.Controls.Add(this.btnAddAttachment);
            this.Controls.Add(this.lbAttachments);
            this.Controls.Add(this.lblAttachments);
            this.Controls.Add(this.txtGeolocation);
            this.Controls.Add(this.lblGeolocation);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.lblDate);
            this.Name = "EventEditorForm";
            this.Text = "Редактор события";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}