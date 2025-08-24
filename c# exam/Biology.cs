using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static c__exam.Quiz;
namespace c__exam
{
    public partial class Biology : Form
    {
        private List<Question> questions;
        private int currentIndex = 0;
        int score=0;
        private string _name;
        public Biology(string name)
        {
            InitializeComponent();
            label2.Text = name;
            _name=name;
            string json = File.ReadAllText("questions.json");
            questions = JsonConvert.DeserializeObject<List<Question>>(json)
            .Where(x => x.id > 20)
            .ToList();
            ShowQuestion(currentIndex);
        }
        private void ShowQuestion(int a)
        {
            if (a >= 0 && a < questions.Count)
            {
                label1.Text = questions[a].Text;
            }

        }

        private void button1_Click(object sender, EventArgs e)
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
                SaveRating(label2.Text.Replace("User:", ""), score);
                Game game=new Game(_name);
                game.Show();
                this.Hide();
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

            ratings.Add(new Rating { User = user, Score = score, Category="Biology"});
            File.WriteAllText(filePath, JsonConvert.SerializeObject(ratings, Formatting.Indented));
        }
        public class UserHistory
        {
            public string User { get; set; }
            public List<Rating> Results { get; set; } = new List<Rating>();
        }
    }
}
