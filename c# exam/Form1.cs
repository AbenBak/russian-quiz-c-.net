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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void reg(object sender, EventArgs e)
        {
            Register regForm=new Register();
            regForm.Show();
            this.Hide();
        }

        private void authForm(object sender, EventArgs e)
        {
            Auth authFOrm = new Auth();
            authFOrm.Show();
            this.Hide();
        }
    }
}
