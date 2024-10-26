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
    public partial class Balance_sheet : Form
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

        void showDiposite()
        {
            conn();
            da = new SqlDataAdapter("select * from deposit_tbl", con);
            ds = new DataSet();
            da.Fill(ds);
            Diposite_Grid.DataSource = ds.Tables[0];
        }

        void showtransfer()
        {
            conn();
            da = new SqlDataAdapter("select * from transfer_tbl", con);
            ds = new DataSet();
            da.Fill(ds);
            transfer_grid.DataSource = ds.Tables[0];
        }

        public Balance_sheet()
        {
            InitializeComponent();
            showDiposite();
            showtransfer();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            View v = new View();
            v.Show();
            this.Hide();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
