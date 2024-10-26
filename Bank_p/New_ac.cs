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
    public partial class New_ac : Form
    {
        SqlDataAdapter da;
        SqlCommand cmd;
        SqlConnection con;
        DataSet ds;
        DataGridViewCellEventArgs es;

        string i, d;

        string Constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\A\Bank_p\Bank_p\Banking_db.mdf;Integrated Security=True";

        private CrystalDecisions.CrystalReports.Engine.ReportDocument cr = new CrystalDecisions.CrystalReports.Engine.ReportDocument();

        static string Crypath = "";

        void conn()
        {
            con = new SqlConnection(Constr);
            con.Open();
        }

        void uploadimage()
        {
            openFileDialog1.ShowDialog();
            try
            {
                i = openFileDialog1.FileName.ToString();
                pctimg.Load();
            }
            catch (Exception e)
            {

            }
        }

        public New_ac()
        {
            InitializeComponent();
        }

        void fillg()
        {
            conn();
            da = new SqlDataAdapter("select * from ac_tbl ", con);
            ds = new DataSet();
            da.Fill(ds);
            
        }


        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            Account ac = new Account();
            ac.Show();
            this.Hide();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Verify_form v = new Verify_form();
            v.Show();
            this.Hide();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            uploadimage();

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            conn();
            da = new SqlDataAdapter("select * from ac_tbl", con);
            ds = new DataSet();
            da.Fill(ds);
            string xml = @"D:/A/Bank_p/Bank_p/data.xml";
            ds.WriteXmlSchema(xml);

            Crypath = @"D:/A/Bank_p/Bank_p/ac_report.rpt";
            cr.Load(Crypath);
            cr.SetDataSource(ds);
            cr.Database.Tables[0].SetDataSource(ds);
            cr.Refresh();
            crystalReportViewer1.ReportSource = cr;

            crystalReportViewer1.Visible = true;
        }

        private void save_Click(object sender, EventArgs e)
        {
            conn();

            string dt = DateTime.Now.ToBinary().ToString();

            d = Application.StartupPath + "\\images\\" + dt + "_" + openFileDialog1.SafeFileName.ToString();
            System.IO.File.Copy(i, d);

            cmd = new SqlCommand("insert into ac_tbl (Ac_No , Name , Father_name , Mother_name , Dob , phone , dist , gender , address , state , email , image) values ('" + txtacn.Text + "','" + txtnm.Text + "','" + txtfnm.Text + "','" + txtmnm.Text + "','" + txtdob.Text + "','" + txtphn.Text + "','" + txtdist.Text + "','" + txtgen.Text + "','" + txtadd.Text + "','" + txtste.Text + "','" + txteml.Text + "','" + d + "')", con);

            cmd.ExecuteNonQuery();

            MessageBox.Show("Saved Successfully ...");

        }
    }
}
