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
    public partial class Transfer_Form : Form
    {
        SqlDataAdapter da;
        SqlCommand cmd;
        SqlConnection con;
        DataSet ds;

        string Constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Bank_Pro\Bank_project\Bank_project\Banking_db.mdf;Integrated Security=True";
        string i, d;

        void connection()
        {
            con = new SqlConnection(Constr);
            con.Open();
        }


        public Transfer_Form()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            Transaction tc = new Transaction();
            tc.Show();
            this.Hide();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Transaction tc = new Transaction();
            tc.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection();
            cmd = new SqlCommand("insert into transfer_tbl (ac_no,name,current_amt,desti_amt,amount) values ('" + acn.Text + "','" + nm.Text + "','" + camt.Text + "','" + damt.Text + "','" + amt.Text + "')", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("deposit successfully ....");
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            connection();
            cmd = new SqlCommand("insert into transfer_tbl (ac_no,name,current_amt,desti_amt,amount) values ('" + acn.Text + "','" + nm.Text + "','" + camt.Text + "','" + damt.Text + "','" + amt.Text + "')", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Transfer  successfully ....");
        }
    }
}
