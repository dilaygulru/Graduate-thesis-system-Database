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
    public partial class Thesis : Form
    {
        public Thesis()
        {
            InitializeComponent();
        }
        NpgsqlConnection connect = new NpgsqlConnection("server=localhost; port=5432; Database=GraduateThesisSystem; UserId = postgres;  password=17012001");

        private void button2_Click(object sender, EventArgs e)
        {
            connect.Open();
            NpgsqlCommand command1 = new NpgsqlCommand("insert into \"Thesis\" values(@thesis_no ,@title, @abstract, @author, @year, @type, @university, @institute, @num_pages, @language, @submission_date)", connect);
            command1.Parameters.AddWithValue("@thesis_no", int.Parse(textBox2.Text));
            command1.Parameters.AddWithValue("@institute", int.Parse(textBox3.Text));
            command1.Parameters.AddWithValue("@university", int.Parse(textBox4.Text));
            command1.Parameters.AddWithValue("@title", (textBox5.Text));
            command1.Parameters.AddWithValue("@submission_date", (dateTimePicker1.Value));
            command1.Parameters.AddWithValue("@year", int.Parse(textBox6.Text));
            command1.Parameters.AddWithValue("@author", int.Parse(textBox7.Text));
            command1.Parameters.AddWithValue("@num_pages", int.Parse(textBox8.Text));
            command1.Parameters.AddWithValue("@abstract", (textBox9.Text));
            command1.Parameters.AddWithValue("@language", (comboBox1.Text));
            command1.Parameters.AddWithValue("@type", (comboBox2.Text));


            command1.ExecuteNonQuery();
            connect.Close();

            MessageBox.Show("Thesis insert operations has been done successfully!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string searchQuery = "SELECT * FROM \"Thesis\" WHERE ";
            if (!string.IsNullOrEmpty(textBox5.Text))
            {
                searchQuery += "\"title\" ILIKE @title AND ";
            }

            if (!string.IsNullOrEmpty(textBox7.Text))
            {
                searchQuery += "\"author\" = @author AND ";
            }

            searchQuery = searchQuery.TrimEnd(' ', 'A', 'N', 'D');
            
            NpgsqlCommand searchCommand = new NpgsqlCommand(searchQuery, connect);

           
            if (!string.IsNullOrEmpty(textBox5.Text))
            {
                searchCommand.Parameters.AddWithValue("@title", textBox5.Text);
            }

            if (!string.IsNullOrEmpty(textBox7.Text))
            {
                searchCommand.Parameters.AddWithValue("@author", int.Parse(textBox7.Text));
            }
            
            connect.Open();
            NpgsqlDataAdapter adapt = new NpgsqlDataAdapter(searchCommand);
            DataSet ds = new DataSet();
            adapt.Fill(ds);
            connect.Close();

            dataGridView1.DataSource = ds.Tables[0];

           
            if (ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("No search results found.");
            }
            else
            {
                MessageBox.Show("Search completed successfully!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string query = "select * from \"Thesis\" ";
            NpgsqlDataAdapter adapt = new NpgsqlDataAdapter(query, connect);
            DataSet ds = new DataSet();
            adapt.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) 
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                
                string title = selectedRow.Cells["title"].Value.ToString();
                string abstractText = selectedRow.Cells["abstract"].Value.ToString();
                int year = Convert.ToInt32(selectedRow.Cells["year"].Value);
                string type = selectedRow.Cells["type"].Value.ToString();
                int numPages = Convert.ToInt32(selectedRow.Cells["num_pages"].Value);
                string language = selectedRow.Cells["language"].Value.ToString();
                DateTime submissionDate = Convert.ToDateTime(selectedRow.Cells["submission_date"].Value);

                
                MessageBox.Show($"Title: {title}\nAbstract: {abstractText}\nYear: {year}\nType: {type}\nNum Pages: {numPages}\nLanguage: {language}\nSubmission Date: {submissionDate}");
            }
        }
    }

}
