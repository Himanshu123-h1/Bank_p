using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace Bank_project
{
    public partial class Verify_Form : Form
    {
        SqlDataAdapter da;
        SqlCommand cmd;
        SqlConnection con;
        DataSet ds;
        DataGridViewCellEventArgs es;

        string Constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Bank_Pro\Bank_Project\Bank_project\Banking_db.mdf;Integrated Security=True";

        void connection()
        {
            con = new SqlConnection(Constr);
            con.Open();
        }
        public Verify_Form()
        {
            InitializeComponent();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            connection();
            cmd = new SqlCommand("insert into verify_tbl (addhar_no,pan_no) values ('" + txtadhar.Text + "','" + txtpan.Text + "')", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("New Account Created Successfully....");
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            new_ac na = new new_ac();
            na.Show();
            this.Hide();
        }
    }
}
