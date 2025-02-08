using System;
using System.Data.SqlClient;
using System.Windows.Forms;

public partial class MusteriKayit : Form
{
    private string connectionString = "YourConnectionStringHere";

    public MusteriKayit()
    {
        InitializeComponent();
    }

    private void MusteriKayit_Load(object sender, EventArgs e)
    {
        MusteriListesiniGuncelle();
    }

    private void MusteriListesiniGuncelle()
    {
        listBox1.Items.Clear();
        
        using (SqlConnection baglanti = new SqlConnection(connectionString))
        {
            baglanti.Open();
            string sorgu = "SELECT MusteriID, Ad, Soyad FROM Musteriler";
            
            using (SqlCommand komut = new SqlCommand(sorgu, baglanti))
            {
                using (SqlDataReader okuyucu = komut.ExecuteReader())
                {
                    while (okuyucu.Read())
                    {
                        string musteriBilgisi = $"{okuyucu["MusteriID"]} - {okuyucu["Ad"]} {okuyucu["Soyad"]}";
                        listBox1.Items.Add(musteriBilgisi);
                    }
                }
            }
        }
    }

    private void btnKaydet_Click(object sender, EventArgs e)
    {
        
        
        MusteriListesiniGuncelle();
    }
} 