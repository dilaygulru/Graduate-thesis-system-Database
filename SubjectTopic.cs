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
    public partial class SubjectTopic : Form
    {
        public SubjectTopic()
        {
            InitializeComponent();
        }
        NpgsqlConnection connect = new NpgsqlConnection("server=localhost; port=5432; Database=GraduateThesisSystem; UserId = postgres;  password=17012001");

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "select * from \"SubjectTopic\"";
            NpgsqlDataAdapter adapt = new NpgsqlDataAdapter(query, connect);
            DataSet ds = new DataSet();
            adapt.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connect.Open();
            NpgsqlCommand command3 = new NpgsqlCommand("UPDATE \"SubjectTopic\" SET \"subject_topic_name\" = @subject_topic_name WHERE \"subject_topic_id\" = @subject_topic_id", connect);
            command3.Parameters.AddWithValue("@subject_topic_id", int.Parse(textBox1.Text));
            command3.Parameters.AddWithValue("@subject_topic_name", textBox2.Text);

            int rowsAffected = command3.ExecuteNonQuery();
            connect.Close();

            if (rowsAffected > 0)
            {
                MessageBox.Show("Subject Topic updated successfully!");
            }
            else
            {
                MessageBox.Show("Subject Topic not found or update failed.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            connect.Open();
            NpgsqlCommand command1 = new NpgsqlCommand("insert into \"SubjectTopic\" values(@subject_topic_id ,@subject_topic_name)", connect);
            command1.Parameters.AddWithValue("@subject_topic_id", int.Parse(textBox1.Text));
            command1.Parameters.AddWithValue("@subject_topic_name", (textBox2.Text));

            command1.ExecuteNonQuery();
            connect.Close();

            MessageBox.Show("Subject Topic insert operations has been done successfully!");
        }
    }
}
