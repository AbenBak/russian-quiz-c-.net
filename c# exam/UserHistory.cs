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
namespace c__exam
{
    public partial class UserHistory : Form
    {
        private string _user;
        List<Rating> ratings;
        private FlowLayoutPanel flowPanel;
        public UserHistory(string username)
        {
            InitializeComponent();
            _user = username;
        }
        public void ShowRating()
        {
            flowLayoutPanel1.Controls.Clear();

            if (File.Exists("rating.json"))
            {
                string json = File.ReadAllText("rating.json");
                ratings = JsonConvert.DeserializeObject<List<Rating>>(json) ?? new List<Rating>();

                foreach (var r in ratings.Where(x => x.User == _user))
                {
                    Label lbl = new Label();
                    lbl.Text =$"-----------------"+
                        $"Category: {r.Category}  " +
                        $"  |  " +
                        $"    {r.User} - {r.Score}" +
                        $"  |  " +
                        $"Time:{r.Date}" +
                        $"-----------------";
                    lbl.AutoSize = true;
                    flowLayoutPanel1.Controls.Add(lbl);
                }
            }
            else
            {
                Label lbl = new Label();
                lbl.Text = "Пока нет данных.";
                lbl.AutoSize = true;
                flowLayoutPanel1.Controls.Add(lbl);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Game game= new Game(_user);
            game.Show();
            this.Hide();
        }

        private void UserHistory_Load(object sender, EventArgs e)
        {
            ShowRating();
        }
    }
}
