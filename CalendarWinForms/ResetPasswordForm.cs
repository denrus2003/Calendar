using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CalendarLibrary;

namespace CalendarWinForms
{
    public partial class ResetPasswordForm : Form
    {
        
        private List<SecurityQuestion> securityQuestions;
        
        private Dictionary<SecurityQuestion, TextBox> answerControls;

        public ResetPasswordForm()
        {
            InitializeComponent();
            answerControls = new Dictionary<SecurityQuestion, TextBox>();

            
            securityQuestions = SecurityQuestionsStorage.LoadQuestions();

            
            PopulateQuestions();
        }

        private void PopulateQuestions()
        {
            panelQuestions.Controls.Clear();
            answerControls.Clear();

            int yOffset = 10;
            foreach (var question in securityQuestions)
            {
                
                Label lblQuestion = new Label();
                lblQuestion.AutoSize = true;
                lblQuestion.Location = new Point(10, yOffset);
                lblQuestion.Text = question.Question;
                panelQuestions.Controls.Add(lblQuestion);

                yOffset += lblQuestion.Height + 5;

                
                TextBox tbAnswer = new TextBox();
                tbAnswer.Location = new Point(10, yOffset);
                tbAnswer.Width = panelQuestions.Width - 20;
                panelQuestions.Controls.Add(tbAnswer);

                answerControls[question] = tbAnswer;

                yOffset += tbAnswer.Height + 15;
            }
        }

        
        private bool ValidateControlQuestions()
        {
            foreach (var pair in answerControls)
            {
                SecurityQuestion question = pair.Key;
                string userAnswer = pair.Value.Text.Trim();
                if (string.IsNullOrEmpty(userAnswer))
                {
                    MessageBox.Show($"Ответ на вопрос \"{question.Question}\" не должен быть пустым.",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (!userAnswer.Equals(question.Answer, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show($"Неверный ответ на вопрос: \"{question.Question}\"",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }

        
        private void btnReset_Click(object sender, EventArgs e)
        {
            if (!ValidateControlQuestions())
                return;

            
            string newPassword = tbNewPassword.Text.Trim();
            string confirmPassword = tbConfirmPassword.Text.Trim();

            if (string.IsNullOrEmpty(newPassword))
            {
                MessageBox.Show("Новый пароль не может быть пустым.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (newPassword.Length < 6)
            {
                MessageBox.Show("Пароль должен содержать не менее 6 символов.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!newPassword.Equals(confirmPassword))
            {
                MessageBox.Show("Пароль и подтверждение не совпадают.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            var newSettings = new EncryptionSettings
            {
                EncryptionEnabled = true,
                EncryptionPassword = newPassword
            };

            SettingsStorage.SaveSettings(newSettings);
            MessageBox.Show("Пароль успешно сброшен.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            Close();
        }

        
        private void btnDisableEncryption_Click(object sender, EventArgs e)
        {
            if (!ValidateControlQuestions())
                return;

            
            DialogResult dr = MessageBox.Show("Вы уверены, что хотите отключить шифрование данных событий?\nДанные будут сохранены в открытом виде.",
                "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr != DialogResult.Yes)
                return;

            var newSettings = new EncryptionSettings
            {
                EncryptionEnabled = false,
                EncryptionPassword = string.Empty
            };

            SettingsStorage.SaveSettings(newSettings);
            MessageBox.Show("Шифрование отключено.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ResetPasswordForm_Load(object sender, EventArgs e)
        {

        }
    }
}
