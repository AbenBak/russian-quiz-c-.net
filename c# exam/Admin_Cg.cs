using Newtonsoft.Json.Linq;
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
    public partial class Admin_Cg : Form
    {
        private int index;
        public Admin_Cg()
        {
            InitializeComponent();
        }
        public void ShowQuestions()
        {
            if (File.Exists("questions.json"))
            {
                string json = File.ReadAllText("questions.json");
                JArray arr = JArray.Parse(json);
                listBox1.Items.Clear();
                foreach (JObject question in arr)
                {
                    listBox1.Items.Add($"{question["id"]}) Category:{question["Category"]} | Question: {question["Question"]} | Answer:{question["Answer"]}" );
                }
            }
        }

        private void Admin_Cg_Load(object sender, EventArgs e)
        {
            ShowQuestions();
        }

        private void Admin_Cg_Loads(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                string json = File.ReadAllText("questions.json");
                JArray arr = JArray.Parse(json);
                JObject selectedQuestion = (JObject)arr[listBox1.SelectedIndex];
                textBox1.Text = selectedQuestion["Question"].ToString();
                textBox2.Text = selectedQuestion["Answer"].ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите вопрос для изменения!");
                return;
            }

            string json = File.ReadAllText("questions.json");
            JArray arr = JArray.Parse(json);
            JObject selectedQuestion = (JObject)arr[listBox1.SelectedIndex];
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
                selectedQuestion["Question"] = textBox1.Text;
            if (!string.IsNullOrWhiteSpace(textBox2.Text))
                selectedQuestion["Answer"] = textBox2.Text;
            File.WriteAllText("questions.json", arr.ToString());
            MessageBox.Show("Изменения сохранены!");
            ShowQuestions();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();  
            form1.Show();
            this.Hide();
        }
    }
}
