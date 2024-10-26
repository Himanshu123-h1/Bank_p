using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bank_p
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Account ac = new Account();
            ac.Show();
            this.Hide();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            transaction tc = new transaction();
            tc.Show();
            this.Hide();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Login_form lg = new Login_form();
            lg.Show();
            this.Hide();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            View v = new View();
            v.Show();
            this.Hide();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }
    }
}
