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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        NpgsqlConnection connect = new NpgsqlConnection("server=localhost; port=5432; Database=GraduateThesisSystem; UserId = postgres;  password=17012001");

        private void FormGetir(Form frm)
        {
            panel4.Controls.Clear();
            frm.MdiParent = this;
            frm.FormBorderStyle = FormBorderStyle.None;
            panel4.Controls.Add(frm);
            frm.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            University ekle = new University();
            FormGetir(ekle);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Institute ekle = new Institute();
            FormGetir(ekle);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Keyword ekle = new Keyword();
            FormGetir(ekle);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Person ekle = new Person();
            FormGetir(ekle);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Supervisor ekle = new Supervisor();
            FormGetir(ekle);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SubjectTopic ekle = new SubjectTopic();
            FormGetir(ekle);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Thesis ekle = new Thesis();
            FormGetir(ekle);
        }




        

        
    }
}
