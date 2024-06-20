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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GTS
{
    public partial class University : Form
    {
        public University()
        {
            InitializeComponent();
        }

        NpgsqlConnection connect = new NpgsqlConnection("server=localhost; port=5432; Database=GraduateThesisSystem; UserId = postgres;  password=17012001");

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "select * from \"University\"";
            NpgsqlDataAdapter adapt = new NpgsqlDataAdapter(query, connect);
            DataSet ds = new DataSet();
            adapt.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connect.Open();
            NpgsqlCommand command3 = new NpgsqlCommand("UPDATE \"University\" SET \"university_name\" = @university_name WHERE \"university_id\" = @university_id", connect);
            command3.Parameters.AddWithValue("@university_id", int.Parse(textBox1.Text));
            command3.Parameters.AddWithValue("@university_name", textBox2.Text);
            
            int rowsAffected = command3.ExecuteNonQuery();
            connect.Close();

            if (rowsAffected > 0)
            {
                MessageBox.Show("University updated successfully!");
            }
            else
            {
                MessageBox.Show("University not found or update failed.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            connect.Open();
            NpgsqlCommand command1 = new NpgsqlCommand("insert into \"University\" values(@university_id ,@university_name)", connect);
            command1.Parameters.AddWithValue("@university_id", int.Parse(textBox1.Text));
            command1.Parameters.AddWithValue("@university_name", (textBox2.Text));

            command1.ExecuteNonQuery();
            connect.Close();

            MessageBox.Show("University insert operations has been done successfully!");
        }
    }
}
