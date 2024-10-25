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
    public partial class FD_Form : Form
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

        public FD_Form()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Transaction ts = new Transaction();
            ts.Show();
            this.Hide();
        }

        private void FD_Form_Load(object sender, EventArgs e)
        {
            connection();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            connection();
            cmd = new SqlCommand("insert into fd_tbl (ac_no,mode,ruppess,day_limit,interest) values ('" + acn.Text + "','" + md.Text + "','" + rs.Text + "','" + dlmt.Text + "','" + inte.Text + "')", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("fd  successfully ....");
        }
    }
}
