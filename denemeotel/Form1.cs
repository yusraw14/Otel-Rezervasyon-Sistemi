using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

using System.Windows.Forms;
using denemeotel.BL;
using denemeotel.DAL;

namespace denemeotel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        MySqlConnection conn = baglantı.getir();

        private void button1_Click(object sender, EventArgs e)
        {
            (new blgiris()).giris(TxtKullanıcıAdı.Text,TxtSifreGiris.Text);
            MySqlCommand komut = new MySqlCommand("select * from yönetici where Kullanıcıad =@y2 and Kullanıcışifre=@y1", baglantı.getir());
            komut.Parameters.AddWithValue("@y2", TxtKullanıcıAdı.Text);
            komut.Parameters.AddWithValue("@y1", TxtSifreGiris.Text);
            MySqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                FrmYeniMusteri fr = new FrmYeniMusteri();
                fr.Show();
                this.Hide();


            }
            else
            {
                MessageBox.Show("Giriş Bilgileriniz Hatalıdır");
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
