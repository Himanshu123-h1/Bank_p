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
    public partial class Update_ac : Form
    {
        
        SqlDataAdapter da;
        SqlCommand cmd;
        SqlConnection con;
        DataSet ds;
        DataGridViewCellEventArgs es;

        string Constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Bank_Pro\Bank_Project\Bank_project\Banking_db.mdf;Integrated Security=True";
        string i, d;

        int id;
        int indexrow;

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
            catch (Exception e)
            {

            }
        }

        void fillg()
        {
            connection();

            da = new SqlDataAdapter("select Ac_No , Name , Father_name , Mother_name , Dob , phone , dist , gender , address , state , email , image from ac_tbl  ", con);
            DataTable dt = new DataTable();
            da.Fill(dt);


            dt.Columns.Add("images", Type.GetType("System.Byte[]"));

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            foreach(DataRow drow in dt.Rows)
            {
                drow["images"] = File.ReadAllBytes(drow["images"].ToString());
            }
            dataGridView1.DataSource = dt;
        }

        public Update_ac()
        {
            InitializeComponent();
            datashow();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            Account ac = new Account();
            ac.Show();
            this.Hide();
        }

        private void guna2Button5_Click_1(object sender, EventArgs e)
        {
            Account ac = new Account();
            ac.Show();
            this.Hide();

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            uploadimage();
        }

        private void Update_ac_Load(object sender, EventArgs e)
        {
            connection();
            fillg();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridView1.Columns[e.ColumnIndex].HeaderText == "Update")
            {
                update.Text = "Update";
                connection();

                id = Convert.ToInt16(dataGridView1.Rows[e.RowIndex].Cells["Ac_Id"].Value);

                string Ac_No, Name, Father_name, Mother_name, Dob, phone, dist, gender, address, state, email;

                Ac_No = (dataGridView1.Rows[e.RowIndex].Cells["Ac_No"].Value).ToString();
                Name = (dataGridView1.Rows[e.RowIndex].Cells["Name"].Value).ToString();
                Father_name = (dataGridView1.Rows[e.RowIndex].Cells["Father_name"].Value).ToString();
                Mother_name = (dataGridView1.Rows[e.RowIndex].Cells["Mother_name"].Value).ToString();
                Dob = (dataGridView1.Rows[e.RowIndex].Cells["Dob"].Value).ToString();
                phone = (dataGridView1.Rows[e.RowIndex].Cells["phone"].Value).ToString();
                dist = (dataGridView1.Rows[e.RowIndex].Cells["dist"].Value).ToString();
                gender = (dataGridView1.Rows[e.RowIndex].Cells["gender"].Value).ToString();
                address = (dataGridView1.Rows[e.RowIndex].Cells["address"].Value).ToString();
                state = (dataGridView1.Rows[e.RowIndex].Cells["state"].Value).ToString();
                email = (dataGridView1.Rows[e.RowIndex].Cells["email"].Value).ToString();


                txtacn.Text = Ac_No;
                txtnm.Text = Name;
                txtfnm.Text = Father_name;
                txtmnm.Text = Mother_name;
                txtdob.Text = Dob;
                txtphn.Text = phone;
                txtdist.Text = dist;
                txtgen.Text = gender;
                txtadd.Text = address;
                txtste.Text = state;
                txteml.Text = email;
            }
        }

        void datashow()
        {
            connection();
            da = new SqlDataAdapter("Select *  from ac_tbl", con);
            ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void update_Click(object sender, EventArgs e)
        {
            if (update.Text == "update")
            {
                connection();

                string dt = DateTime.Now.ToBinary().ToString();

                d = Application.StartupPath + "\\images\\" + dt + "_" + openFileDialog1.SafeFileName.ToString();
                System.IO.File.Copy(i, d);

                cmd = new SqlCommand("insert into ac_tbl (Ac_No , Name , Father_name , Mother_name , Dob , phone , dist , gender , address , state , email , image) values ('" + txtacn.Text + "','" + txtnm.Text + "','" + txtfnm.Text + "','" + txtmnm.Text + "','" + txtdob.Text + "','" + txtphn.Text + "','" + txtdist.Text + "','" + txtgen.Text + "','" + txtadd.Text + "','" + txtste.Text + "','" + txteml.Text + "','" + d + "')", con);

                cmd.ExecuteNonQuery();
            }
            else
            {
                connection();

                cmd = new SqlCommand("update into ac_tbl set Ac_No = '" + txtacn.Text + "', Name = '" + txtnm.Text + "' , Father_name = '" + txtfnm.Text + "' , Mother_name = '" + txtmnm.Text + "' , Dob = '" + txtdob.Text + "' , phone = '" + txtphn.Text + "', dist = '" + txtdist.Text
                    + "', gender = '" + txtgen.Text + "' , address = '" + txtadd.Text + "', state = '" + txtste.Text + "' , email = '" + txteml.Text + "' where Ac_Id = '" + id + "'" , con);

                cmd.ExecuteNonQuery();
            }
            fillg();
        }
    }
}
