using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Windows.Forms;
using static c__exam.Quiz;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace c__exam
{
    public partial class Mix : Form
    {
        private List<Question> questions;
        private int currentIndex = 0;
        private int score = 0;
        private string _name;
        private Random random = new Random();

        public Mix(string user)
        {
            InitializeComponent();
            _name = user;
            label2.Text = "User: " + _name;

            PrepareQuestions();
            ShowQuestion(currentIndex);
        }

        private void PrepareQuestions()
        {
            string json = File.ReadAllText("questions.json");
            var allQuestions = JsonConvert.DeserializeObject<List<Question>>(json);
            var category1 = allQuestions.Where(x => x.id <= 20).ToList();
            var category2 = allQuestions.Where(x => x.id > 20).ToList();
            questions = new List<Question>();
            questions.AddRange(GetRandomQuestions(category1, 10));
            questions.AddRange(GetRandomQuestions(category2, 10));
            questions = questions.OrderBy(q => random.Next()).ToList();
        }

        private List<Question> GetRandomQuestions(List<Question> source, int count)
        {
            return source.OrderBy(x => random.Next()).Take(count).ToList();
        }

        private void ShowQuestion(int index)
        {
            if (index >= 0 && index < questions.Count)
            {
                label1.Text = questions[index].Text;
            }
        }


        private void SaveRating(string user, int score)
        {
            string filePath = "rating.json";
            List<Rating> ratings = new List<Rating>();

            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                ratings = JsonConvert.DeserializeObject<List<Rating>>(json) ?? new List<Rating>();
            }

            ratings.Add(new Rating { User = user, Score = score, Category = "Mixed" });
            File.WriteAllText(filePath, JsonConvert.SerializeObject(ratings, Formatting.Indented));
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text == questions[currentIndex].Answer)
            {
                score++;
            }
            textBox1.Text = "";
            currentIndex++;
            if (currentIndex < questions.Count)
            {
                ShowQuestion(currentIndex);
            }
            else
            {
                MessageBox.Show($"Тест завершён! Правильных ответов: {score}");
                SaveRating(_name, score);
                Game game = new Game(_name);
                game.Show();
                this.Hide();
            }
        }
    }
}
