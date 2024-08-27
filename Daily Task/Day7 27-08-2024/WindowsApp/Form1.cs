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

namespace GridViewApp
{
    public partial class Form1 : Form
    {
        static SqlConnection conn;
        static SqlCommand cmd;
        static void getConnection()
        {
            conn = new SqlConnection("data source =PTSQLTESTDB01;database=Sports_Sidd;integrated security=true;");
            conn.Open();
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            getConnection();
            int id = Convert.ToInt32(textBox1.Text);
            string name = textBox2.Text;
            cmd = new SqlCommand("Update Product Set ProName =@name where ProId=@id",conn);
            cmd.Parameters.AddWithValue("id", id);
            cmd.Parameters.AddWithValue("name", name);
            cmd.ExecuteNonQuery();
            Form1_Load(sender, e);
            conn.Close();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            getConnection();
            cmd = new SqlCommand("Select * from product",conn);
            SqlDataReader sdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();

            dt.Load(sdr);

            dataGridView1.DataSource= dt;
            conn.Close();   
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            getConnection();
                int id = Convert.ToInt32(textBox1.Text);
                string name = textBox2.Text;
                cmd = new SqlCommand("insert into Product values(@id,@name)", conn);
                cmd.Parameters.AddWithValue("id", id);
                cmd.Parameters.AddWithValue("name", name);
                cmd.ExecuteNonQuery();
                Form1_Load(sender, e);
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            getConnection();
            int id = Convert.ToInt32(textBox1.Text);
            cmd = new SqlCommand("select * from Product where ProId=@id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader sdr = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(sdr);
            dataGridView1.DataSource = dt;

            //if (sdr.Read())
            //{
            //    textBox2.Text = sdr[1].ToString();
            //}
            //else
            //{
            //    textBox2.Text = "No data found";
            //}
            conn.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            getConnection();
            cmd = new SqlCommand("Select count(*) from product", conn);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            MessageBox.Show("Total number of Products :"+count);
            conn.Close();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            getConnection();
            int id = Convert.ToInt32(textBox1.Text);
             cmd = new SqlCommand("Delete from Product where ProId=@id", conn);
            cmd.Parameters.AddWithValue("id", id);
            cmd.ExecuteNonQuery();
            Form1_Load(sender, e);
            conn.Close();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            getConnection();
            cmd = new SqlCommand("Select * from product", conn);
            SqlDataReader sdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();

            dt.Load(sdr);

            dataGridView1.DataSource = dt;
            conn.Close();
        }
    }
}
