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

namespace Bank_project
{
    public partial class All_customer : Form
    {
        SqlDataAdapter da;
        SqlCommand cmd;
        SqlConnection con;
        DataSet ds;

        string Constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Bank_Pro\Bank_project\Bank_project\Banking_db.mdf;Integrated Security=True";


        void connection()
        {
            con = new SqlConnection(Constr);
            con.Open();
        }

        void showac()
        {
            connection();
            da = new SqlDataAdapter("select * from ac_tbl", con);
            ds = new DataSet();
            da.Fill(ds);
            AC_Grid.DataSource = ds.Tables[0];
        }
        public All_customer()
        {
            InitializeComponent();
            showac();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Account ac = new Account();
            ac.Show();
            this.Hide();
        }
    }
}
