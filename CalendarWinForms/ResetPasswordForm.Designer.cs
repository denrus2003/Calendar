namespace CalendarWinForms
{
    partial class ResetPasswordForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        
        private System.Windows.Forms.Panel panelQuestions;
        private System.Windows.Forms.Label lblNewPassword;
        private System.Windows.Forms.TextBox tbNewPassword;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.TextBox tbConfirmPassword;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnDisableEncryption;
        private System.Windows.Forms.Button btnCancel;

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

        private void InitializeComponent()
        {
            this.panelQuestions = new System.Windows.Forms.Panel();
            this.lblNewPassword = new System.Windows.Forms.Label();
            this.tbNewPassword = new System.Windows.Forms.TextBox();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.tbConfirmPassword = new System.Windows.Forms.TextBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnDisableEncryption = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panelQuestions
            // 
            this.panelQuestions.AutoScroll = true;
            this.panelQuestions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelQuestions.Location = new System.Drawing.Point(24, 23);
            this.panelQuestions.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.panelQuestions.Name = "panelQuestions";
            this.panelQuestions.Size = new System.Drawing.Size(718, 289);
            this.panelQuestions.TabIndex = 0;
            // 
            // lblNewPassword
            // 
            this.lblNewPassword.AutoSize = true;
            this.lblNewPassword.Location = new System.Drawing.Point(24, 339);
            this.lblNewPassword.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblNewPassword.Name = "lblNewPassword";
            this.lblNewPassword.Size = new System.Drawing.Size(211, 32);
            this.lblNewPassword.TabIndex = 1;
            this.lblNewPassword.Text = "Новый пароль:";
            // 
            // tbNewPassword
            // 
            this.tbNewPassword.Location = new System.Drawing.Point(258, 333);
            this.tbNewPassword.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tbNewPassword.Name = "tbNewPassword";
            this.tbNewPassword.Size = new System.Drawing.Size(482, 38);
            this.tbNewPassword.TabIndex = 2;
            this.tbNewPassword.UseSystemPasswordChar = true;
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.Location = new System.Drawing.Point(24, 407);
            this.lblConfirmPassword.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(297, 32);
            this.lblConfirmPassword.TabIndex = 3;
            this.lblConfirmPassword.Text = "Подтвердите пароль:";
            // 
            // tbConfirmPassword
            // 
            this.tbConfirmPassword.Location = new System.Drawing.Point(336, 401);
            this.tbConfirmPassword.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tbConfirmPassword.Name = "tbConfirmPassword";
            this.tbConfirmPassword.Size = new System.Drawing.Size(404, 38);
            this.tbConfirmPassword.TabIndex = 4;
            this.tbConfirmPassword.UseSystemPasswordChar = true;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(24, 475);
            this.btnReset.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(300, 58);
            this.btnReset.TabIndex = 5;
            this.btnReset.Text = "Сбросить пароль";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnDisableEncryption
            // 
            this.btnDisableEncryption.Location = new System.Drawing.Point(360, 475);
            this.btnDisableEncryption.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnDisableEncryption.Name = "btnDisableEncryption";
            this.btnDisableEncryption.Size = new System.Drawing.Size(300, 58);
            this.btnDisableEncryption.TabIndex = 6;
            this.btnDisableEncryption.Text = "Отключить шифрование";
            this.btnDisableEncryption.UseVisualStyleBackColor = true;
            this.btnDisableEncryption.Click += new System.EventHandler(this.btnDisableEncryption_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(700, 475);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(300, 58);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ResetPasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 572);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDisableEncryption);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.tbConfirmPassword);
            this.Controls.Add(this.lblConfirmPassword);
            this.Controls.Add(this.tbNewPassword);
            this.Controls.Add(this.lblNewPassword);
            this.Controls.Add(this.panelQuestions);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "ResetPasswordForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Сброс пароля";
            this.Load += new System.EventHandler(this.ResetPasswordForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
