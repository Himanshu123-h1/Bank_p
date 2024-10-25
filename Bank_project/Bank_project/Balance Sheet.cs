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
    public partial class Balance_Sheet : Form
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

        void showDiposite()
        {
            connection();
            da = new SqlDataAdapter("select * from deposit_tbl",con);
            ds = new DataSet();
            da.Fill(ds);
            Diposite_Grid.DataSource = ds.Tables[0];
        }
        public Balance_Sheet()
        {
            InitializeComponent();
            showDiposite();
            showtransfer();
            
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            View v = new View();
            v.Show();
            this.Hide();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        void showtransfer()
        {
            connection();
            da = new SqlDataAdapter("select * from transfer_tbl", con);
            ds = new DataSet();
            da.Fill(ds);
            transfer_grid.DataSource = ds.Tables[0];
        }

       
    }
}
