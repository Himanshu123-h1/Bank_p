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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace Bank_p
{
    public partial class deposite : Form
    {

        SqlDataAdapter da;
        SqlCommand cmd;
        SqlConnection con;
        DataSet ds;
        DataGridViewCellEventArgs es;

        string Con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\A\Bank_p\Bank_p\Banking_db.mdf;Integrated Security=True";

        private CrystalDecisions.CrystalReports.Engine.ReportDocument cr = new CrystalDecisions.CrystalReports.Engine.ReportDocument();

        static string Crypath = "";

        void connection()
        {
            con = new SqlConnection(Con);
            con.Open();
        }


        public deposite()
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

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            connection();
            cmd = new SqlCommand("insert into deposit_tbl (Ac_No,Name,Old_Balance,Mode,Deposit_amt) values ('" + txtacn.Text + "','" + txtnm.Text + "','" + txtblnc.Text + "','" + txtmd.Text + "','" + txtamt.Text + "')", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("deposit successfully ....");
        }

        private void deposite_Load(object sender, EventArgs e)
        {
            connection();
        }

        private void upload_Click(object sender, EventArgs e)
        {
            connection();
            da = new SqlDataAdapter("select * from deposit_tbl", con);
            ds = new DataSet();
            da.Fill(ds);
            string xml = @"D:/A/Bank_p/Bank_p/dep_data.xml";
            ds.WriteXmlSchema(xml);

            Crypath = @"D:/A/Bank_p/Bank_p/d_report.rpt";
            cr.Load(Crypath);
            cr.SetDataSource(ds);
            cr.Database.Tables[0].SetDataSource(ds);
            cr.Refresh();
            crystalReportViewer1.ReportSource = cr;

            crystalReportViewer1.Visible = true;
        }
    }
}
