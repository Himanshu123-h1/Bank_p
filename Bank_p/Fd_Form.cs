using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bank_p
{
    public partial class Fd_Form : Form
    {
        SqlDataAdapter da;
        SqlCommand cmd;
        SqlConnection con;
        DataSet ds;
        DataGridViewCellEventArgs es;

        string Constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\A\Bank_p\Bank_p\Banking_db.mdf;Integrated Security=True";

        void conn()
        {
            con = new SqlConnection(Constr);
            con.Open();
        }
        public Fd_Form()
        {
            InitializeComponent();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            transaction tc = new transaction();
            tc.Show();
            this.Hide();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

        }

        private void Fd_Form_Load(object sender, EventArgs e)
        {
            conn();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            conn();
            cmd = new SqlCommand("insert into fd_tbl (ac_no,mode,ruppess,day_limit,interest) values ('" + acn.Text + "','" + md.Text + "','" + rs.Text + "','" + dlmt.Text + "','" + inte.Text + "')", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("fd  successfully ....");

        }
    }
}
