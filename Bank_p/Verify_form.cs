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
    public partial class Verify_form : Form
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

        public Verify_form()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            New_ac na = new New_ac();
            na.Show();
            this.Hide();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            conn();
            cmd = new SqlCommand("insert into verify_tbl (addhar_no,pan_no) values ('" + txtadhar.Text + "','" + txtpan.Text + "')", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("New Account Created Successfully....");

        }
    }
}
