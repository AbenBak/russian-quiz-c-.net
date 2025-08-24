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
using System.IO;
namespace c__exam
{
    public partial class Settings : Form
    {
        private string _user;
        public Settings(string user)
        {
            InitializeComponent();
            _user = user;
            label1.Text = _user;
            string json = File.ReadAllText("users.json");
            List<User> users = JsonConvert.DeserializeObject<List<User>>(json) ?? new List<User>();
            var userToEdit = users.FirstOrDefault(u => u.name == _user);
            label3.Text = $"current password:{userToEdit.pass}";
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Game game = new Game(_user);
            game.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string json = File.ReadAllText("users.json");
            List<User> users = JsonConvert.DeserializeObject<List<User>>(json) ?? new List<User>();
            var userToEdit = users.FirstOrDefault(u => u.name == _user);
            if (userToEdit != null) {
                if (textBox1.Text==userToEdit.pass)
                {
                    MessageBox.Show("the same password can`t be changed");
                }
                else
                {
                    userToEdit.pass=textBox1.Text;
                    File.WriteAllText("users.json", JsonConvert.SerializeObject(users, Formatting.Indented));
                    MessageBox.Show("Password changed successfully!");
                    Form1 form1 = new Form1();
                    form1.Show();
                    this.Hide();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string json = File.ReadAllText("users.json");
            List<User> users = JsonConvert.DeserializeObject<List<User>>(json) ?? new List<User>();
            var userToEdit = users.FirstOrDefault(u => u.name == _user);
            if (userToEdit != null)
            {
                if (dateTimePicker1.Value.Date==userToEdit.date.Date)
                {
                    MessageBox.Show("the same date can`t be changed");
                }
                else
                {
                    userToEdit.date=dateTimePicker1.Value;
                    File.WriteAllText("users.json", JsonConvert.SerializeObject(users, Formatting.Indented));
                    MessageBox.Show("Date changed successfully!"); 
                    Form1 form1 = new Form1();
                    form1.Show();
                    this.Hide();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
