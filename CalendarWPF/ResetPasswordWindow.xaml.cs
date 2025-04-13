using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using CalendarLibrary;

namespace CalendarWPF
{
    public partial class ResetPasswordWindow : Window
    {
        
        private List<SecurityQuestion> securityQuestions;
        
        private Dictionary<SecurityQuestion, TextBox> answerControls;

        public ResetPasswordWindow()
        {
            InitializeComponent();
            answerControls = new Dictionary<SecurityQuestion, TextBox>();

            
            securityQuestions = SecurityQuestionsStorage.LoadQuestions();
            PopulateQuestions();
        }

        private void PopulateQuestions()
        {
            stackPanelQuestions.Children.Clear();
            answerControls.Clear();

            foreach (var question in securityQuestions)
            {
                
                var tbQuestion = new TextBlock
                {
                    Text = question.Question,
                    Margin = new Thickness(5),
                    TextWrapping = TextWrapping.Wrap
                };
                stackPanelQuestions.Children.Add(tbQuestion);

                
                var tbAnswer = new TextBox
                {
                    Margin = new Thickness(5),
                    Width = 400
                };
                stackPanelQuestions.Children.Add(tbAnswer);

                answerControls[question] = tbAnswer;
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
                    MessageBox.Show($"Ответ на вопрос \"{question.Question}\" не может быть пустым.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return false;
                }
                if (!userAnswer.Equals(question.Answer, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show($"Неверный ответ на вопрос: \"{question.Question}\"", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
            return true;
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateControlQuestions())
                return;

            string newPassword = pbNewPassword.Password.Trim();
            string confirmPassword = pbConfirmPassword.Password.Trim();

            if (string.IsNullOrEmpty(newPassword))
            {
                MessageBox.Show("Новый пароль не может быть пустым.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (newPassword.Length < 6)
            {
                MessageBox.Show("Пароль должен содержать не менее 6 символов.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (!newPassword.Equals(confirmPassword))
            {
                MessageBox.Show("Пароль и подтверждение не совпадают.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var newSettings = new EncryptionSettings
            {
                EncryptionEnabled = true,
                EncryptionPassword = newPassword
            };

            SettingsStorage.SaveSettings(newSettings);
            MessageBox.Show("Пароль успешно сброшен.", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            DialogResult = true;
            Close();
        }

        private void btnDisableEncryption_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateControlQuestions())
                return;

            MessageBoxResult dr = MessageBox.Show("Вы уверены, что хотите отключить шифрование данных событий?\nДанные будут сохранены в открытом виде.",
                "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (dr != MessageBoxResult.Yes)
                return;

            var newSettings = new EncryptionSettings
            {
                EncryptionEnabled = false,
                EncryptionPassword = string.Empty
            };

            SettingsStorage.SaveSettings(newSettings);
            MessageBox.Show("Шифрование отключено.", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            DialogResult = true;
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
