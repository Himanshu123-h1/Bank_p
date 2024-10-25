using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace Bank_project
{
    public partial class Deposit_Form : Form
    {
        SqlDataAdapter da;
        SqlCommand cmd;
        SqlConnection con;
        DataSet ds;
        DataGridViewCellEventArgs es;

        string Con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Bank_Pro\Bank_project\Bank_project\Banking_db.mdf;Integrated Security = True";

        void connection()
        {
            con = new SqlConnection(Con);
            con.Open();
        }

        public Deposit_Form()
        {
            InitializeComponent();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            Transaction tc = new Transaction();
            tc.Show();
            this.Hide();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Transaction tc = new Transaction();
            tc.Show();
            this.Hide();
        }

        private void Deposit_Form_Load(object sender, EventArgs e)
        {
            connection();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            connection();
            cmd = new SqlCommand("insert into deposit_tbl (Ac_No,Name,Old_Balance,Mode,Deposit_amt) values ('" + txtacn.Text + "','" + txtnm.Text + "','" + txtblnc.Text + "','" + txtmd.Text + "','" + txtamt.Text + "')", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("deposit successfully ....");
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

        }
    }
}
