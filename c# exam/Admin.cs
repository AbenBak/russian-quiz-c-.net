using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
namespace c__exam
{
    public partial class Admin : Form
    {
        private string Ad_log = "Tetter";
        private string Ad_pass = "13579";
        public Admin()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text==Ad_log&& textBox2.Text==Ad_pass)
            {
                MessageBox.Show("Login to Admin have been succesfull");
                Admin_Cg admin_Cg = new Admin_Cg();
                admin_Cg.Show();
                this.Hide();
            }
        }
    }
}
