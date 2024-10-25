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
    public partial class Login_form : Form
    {
        SqlDataAdapter da;
        SqlCommand cmd;
        SqlConnection con;
        DataSet ds;
        DataGridViewCellEventArgs es;

        string Constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Bank_Pro\Bank_Project\Bank_project\Banking_db.mdf;Integrated Security=True";

        

        void conn()
        {
            con = new SqlConnection(Constr);
            con.Open();
        }
        public Login_form()
        {
            InitializeComponent();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (txtuname.Text == "" && txtpwd.Text == "")
            {
                MessageBox.Show("Enter valid Username and Password", "error");
            }
            else
            {
                conn();
                da = new SqlDataAdapter("select count(*) from Login_tbl where Username = '" + txtuname.Text + "' and Password = '" + txtpwd.Text + "' ",con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if(dt.Rows[0][0].ToString() == "1")
                {
                    Menu obj = new Menu();
                    obj.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("invalid Username and Password");
                }
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Sign_up sgn = new Sign_up();
            sgn.Show();
            this.Hide();
        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            Sign_up sg = new Sign_up();
            sg.Show();
            this.Hide();
        }
    }
}
