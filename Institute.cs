using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GTS
{
    public partial class Institute : Form
    {
        public Institute()
        {
            InitializeComponent();
        }

        NpgsqlConnection connect = new NpgsqlConnection("server=localhost; port=5432; Database=GraduateThesisSystem; UserId = postgres;  password=17012001");

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "select * from \"Institute\"";
            NpgsqlDataAdapter adapt = new NpgsqlDataAdapter(query, connect);
            DataSet ds = new DataSet();
            adapt.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connect.Open();
            NpgsqlCommand command3 = new NpgsqlCommand("UPDATE \"Institute\" SET \"institute_name\" = @institute_name, \"university_id\" = @university_id  WHERE \"institute_id\" = @institute_id", connect);
            command3.Parameters.AddWithValue("@institute_id", int.Parse(textBox1.Text));
            command3.Parameters.AddWithValue("@university_id", int.Parse(textBox2.Text));
            command3.Parameters.AddWithValue("@institute_name", textBox3.Text);

            int rowsAffected = command3.ExecuteNonQuery();
            connect.Close();

            if (rowsAffected > 0)
            {
                MessageBox.Show("Institute updated successfully!");
            }
            else
            {
                MessageBox.Show("Institute not found or update failed.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            connect.Open();
            NpgsqlCommand command1 = new NpgsqlCommand("insert into \"Institute\" values(@institute_id ,@university_id ,@institute_name)", connect);
            command1.Parameters.AddWithValue("@institute_id", int.Parse(textBox1.Text));
            command1.Parameters.AddWithValue("@university_id", int.Parse(textBox2.Text));
            command1.Parameters.AddWithValue("@institute_name", (textBox3.Text));

            command1.ExecuteNonQuery();
            connect.Close();

            MessageBox.Show("Institute insert operations has been done successfully!");
        }
    }


}
