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
using Newtonsoft.Json;
namespace c__exam
{
    public partial class Auth : Form
    {
        public Auth()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Register reg = new Register();
            reg.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string log = textBox1.Text;
            string pass=textBox2.Text;
            DateTime date = dateTimePicker1.Value;
            string path = "users.json";
            if (!File.Exists(path))
            {
                MessageBox.Show("No users registered yet!");
                return;
            }
            string json = File.ReadAllText(path);
            List<User> users = JsonConvert.DeserializeObject<List<User>>(json) ?? new List<User>();
            bool found = false;
            foreach (User u in users)
            {
                if (u.name == log && u.pass == pass && u.date.Date==date.Date)
                {
                    found = true;
                    break;
                }
            }

            if (found)
            {
                MessageBox.Show("Login successful!");
                Game game = new Game(log);
                game.Show();
                this.Hide();
                // Здесь открываем главное окно
            }
            else
            {
                MessageBox.Show("Wrong username or password or even birth_date");
            }
        }
    }
}
