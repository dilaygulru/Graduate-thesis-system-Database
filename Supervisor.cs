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
    public partial class Supervisor : Form
    {
        public Supervisor()
        {
            InitializeComponent();
        }
        NpgsqlConnection connect = new NpgsqlConnection("server=localhost; port=5432; Database=GraduateThesisSystem; UserId = postgres;  password=17012001");

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "select * from \"Supervisor\"";
            NpgsqlDataAdapter adapt = new NpgsqlDataAdapter(query, connect);
            DataSet ds = new DataSet();
            adapt.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connect.Open();
            NpgsqlCommand command3 = new NpgsqlCommand("UPDATE \"Supervisor\" SET \"person_id\" = @person_id, \"thesis_no\" = @thesis_no WHERE \"supervisor_id\" = @supervisor_id", connect);
            command3.Parameters.AddWithValue("@supervisor_id", int.Parse(textBox1.Text));
            command3.Parameters.AddWithValue("@person_id", int.Parse(textBox2.Text));
            command3.Parameters.AddWithValue("@thesis_no", int.Parse(textBox3.Text));

            int rowsAffected = command3.ExecuteNonQuery();
            connect.Close();

            if (rowsAffected > 0)
            {
                MessageBox.Show("Supervisor updated successfully!");
            }
            else
            {
                MessageBox.Show("Supervisor not found or update failed.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            connect.Open();
            NpgsqlCommand command1 = new NpgsqlCommand("insert into \"Supervisor\" values(@supervisor_id ,@person_id, @thesis_no)", connect);
            command1.Parameters.AddWithValue("@supervisor_id", int.Parse(textBox1.Text));
            command1.Parameters.AddWithValue("@person_id", int.Parse(textBox2.Text));
            command1.Parameters.AddWithValue("@thesis_no", int.Parse(textBox3.Text));

            command1.ExecuteNonQuery();
            connect.Close();

            MessageBox.Show("Supervisor insert operations has been done successfully!");
        }
    }


}
