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
    public partial class Account : Form
    {
        public Account()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            New_ac na = new New_ac();
            na.Show();
            this.Hide();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            Menu m = new Menu();
            m.Show();
            this.Hide();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Update_Ac u = new Update_Ac();
            u.Show();
            this.Hide();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            All_customer a = new All_customer();
            a.Show();
            this.Show();
        }
    }
}
