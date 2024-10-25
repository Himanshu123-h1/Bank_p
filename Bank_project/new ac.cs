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
    public partial class new_ac : Form
    {
        SqlDataAdapter da;
        SqlCommand cmd;
        SqlConnection con;
        DataSet ds;
        DataGridViewCellEventArgs es;

        string Constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Bank_Pro\Bank_Project\Bank_project\Banking_db.mdf;Integrated Security=True";
        string i, d;

        void connection()
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
            catch(Exception e)
            {

            }
        }

        void fillg()
        {
            connection();
            da = new SqlDataAdapter("select * from ac_tbl ", con);
            ds = new DataSet();
            da.Fill(ds);
            //DataGridView1.DataSource = ds.Tables[0];
        }

        public new_ac()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

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
            Verify_Form vr = new Verify_Form();
            vr.Show();
            this.Hide();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            uploadimage();
        }

        private void new_ac_Load(object sender, EventArgs e)
        {
            connection();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            connection();

            string dt = DateTime.Now.ToBinary().ToString();

            d = Application.StartupPath + "\\images\\" + dt + "_" + openFileDialog1.SafeFileName.ToString();
            System.IO.File.Copy(i, d);

            cmd = new SqlCommand("insert into ac_tbl (Ac_No , Name , Father_name , Mother_name , Dob , phone , dist , gender , address , state , email , image) values ('" + txtacn.Text + "','" + txtnm.Text + "','" + txtfnm.Text + "','" + txtmnm.Text + "','" + txtdob.Text + "','" + txtphn.Text + "','" + txtdist.Text + "','" + txtgen.Text + "','" + txtadd.Text + "','" + txtste.Text + "','" + txteml.Text + "','" + d + "')", con);

            cmd.ExecuteNonQuery();

            MessageBox.Show("Saved Successfully ...");
        }
    }
}
