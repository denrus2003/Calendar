using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace CalendarLibrary
{
    public class SecurityQuestion
    {
        public string Question { get; set; }
        
        public string Answer { get; set; }
    }

    public static class SecurityQuestionsStorage
    {
        private static readonly string questionsFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "securityQuestions.json");

        public static List<SecurityQuestion> LoadQuestions()
        {
            if (!File.Exists(questionsFilePath))
            {
                
                var defaultQuestions = new List<SecurityQuestion>
                {
                    new SecurityQuestion { Question = "Как зовут вашего питомца?", Answer = "Fluffy" },
                    new SecurityQuestion { Question = "В каком городе вы родились?", Answer = "Moscow" }
                };
                SaveQuestions(defaultQuestions);
                return defaultQuestions;
            }
            string json = File.ReadAllText(questionsFilePath, Encoding.UTF8);
            try
            {
                return JsonSerializer.Deserialize<List<SecurityQuestion>>(json);
            }
            catch
            {
                return new List<SecurityQuestion>();
            }
        }

        public static void SaveQuestions(List<SecurityQuestion> questions)
        {
            string json = JsonSerializer.Serialize(questions, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(questionsFilePath, json, Encoding.UTF8);
        }
    }
}
