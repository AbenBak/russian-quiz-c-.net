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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
namespace c__exam
{

    public partial class Game : Form
    {
        private string _user;
        public Game(string username)
        {
            InitializeComponent();
            label1.Text = username;
            _user= username;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user=label1.Text;
            Quiz quiz = new Quiz(user);
            quiz.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UserHistory userHistory = new UserHistory(label1.Text);    
            userHistory.Show(); 
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            TopPlayers t=new TopPlayers(_user);
            t.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Settings settings=new Settings(_user);
            settings.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
