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

namespace Bank_project
{
    public partial class Sign_up : Form
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

        public Sign_up()
        {
            InitializeComponent();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            connection();
            cmd = new SqlCommand("insert into Login_tbl (Username,Password) values ('" + txtuname.Text + "','" + txtpwd.Text + "')",con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("added Successfully");

            Login_form lg = new Login_form();
            lg.Show();
            this.Hide();
            
           
        }
    }
}
