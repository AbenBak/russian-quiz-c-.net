using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace c__exam
{
    public partial class Quiz : Form

    {
        private string _user;
        public Quiz(string user)
        {
            InitializeComponent();
            _user=user;
            label1.Text=$"User:{user}";
        }

        public class Question
        {
            public int id { get; set; }
            public string Category { get; set; }
            [JsonProperty("Question")]
            public string Text { get; set; }
            public string Answer { get; set; }
        }

        public class Category
        {
            public string Name { get; set; }
            public List<Question> Questions { get; set; } = new List<Question>();
        }

        public class QuizData
        {
            public List<Category> Categories { get; set; } = new List<Category>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Biology biology = new Biology(_user);
            biology.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Math math = new Math(_user);
            math.Show();
            this.Hide();
        }
        public class Rating
        {
            public string User { get; set; }
            public string Category { get; set; }
            public int Score { get; set; }
            public DateTime Date { get; set; } = DateTime.Now;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Mix mix = new Mix(_user);
            mix.Show();
            this.Hide();
        }
    }
}
