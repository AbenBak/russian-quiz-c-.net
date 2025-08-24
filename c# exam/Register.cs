using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
namespace c__exam
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Auth auth = new Auth();
            auth.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string log = textBox1.Text;
            string password = textBox2.Text;
            DateTime birth_date = dateTimePicker1.Value;
            string Path = "users.json";
            List<User> users = new List<User>();
            if (string.IsNullOrWhiteSpace(log) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter username and password");
                return;
            }
            if (File.Exists(Path))
            {
                string existingJson = File.ReadAllText(Path);
                users = JsonConvert.DeserializeObject<List<User>>(existingJson) ?? new List<User>();
            }
            if (birth_date > DateTime.Now)
            {
                MessageBox.Show("Error: wrong date");
                return;
            }

            if (users.Any(u => u.name == log))
            {
                MessageBox.Show("User already exists");
                return;
            }
            users.Add(new User
            {
                name = log,
                pass = password,
                date = birth_date,
            });
            string json = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText(Path, json);
            MessageBox.Show("User saved successfully!");
            Auth auth = new Auth();
            auth.Show();
            this.Hide();    
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }
    }
}
