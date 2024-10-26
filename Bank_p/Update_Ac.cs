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
    public partial class Update_Ac : Form
    {
        public Update_Ac()
        {
            InitializeComponent();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            Account ac = new Account();
            ac.Show();
            this.Hide();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void update_Click(object sender, EventArgs e)
        {

        }
    }
}
