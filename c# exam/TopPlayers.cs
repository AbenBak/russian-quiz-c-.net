using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static c__exam.Quiz;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
namespace c__exam
{
    public partial class TopPlayers : Form
    {
        List<Rating> ratings;
        private string _name;
        public TopPlayers(string username)
        {
            InitializeComponent();
            _name = username;
        }
        public void ShowTop()
        {
            if (File.Exists("rating.json"))
            {
                string json = File.ReadAllText("rating.json");
                ratings = JsonConvert.DeserializeObject<List<Rating>>(json) ?? new List<Rating>();
                ratings = ratings.OrderByDescending(r => r.Score).ToList();
                listBox1.Items.Clear();
                listBox2.Items.Clear();
                foreach (Rating r in ratings.Where(x => x.Category=="Biology"))
                {
                    listBox1.Items.Add($"{r.User} - {r.Score}");
                }
                foreach (Rating r in ratings.Where(x => x.Category=="Math"))
                {
                    listBox2.Items.Add($"{r.User} - {r.Score}");
                }
                foreach (Rating r in ratings.Where(x => x.Category=="Mixed"))
                {
                    listBox3.Items.Add($"{r.User} - {r.Score}");
                }
            }
        }

        private void TopPlayers_Load(object sender, EventArgs e)
        {
            ShowTop();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Game game = new Game(_name);
            game.Show();
            this.Hide();    
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}