using denemeotel.ENTİTYLAYER;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace denemeotel.DAL
{
    internal class dalmüşterikayıt
    {
        MySqlConnection conn = baglantı.getir();


        public bool MüşteriEkle(elmüşterikayıt müşteri)
        {
            using (MySqlConnection conn = baglantı.getir())
            {
                string query = "INSERT INTO Musteriler (Ad, Soyad, Telefon, TcKimlikNo) VALUES (@Ad, @Soyad, @Telefon, @TcKimlikNo)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Ad", müşteri.ADI);
                cmd.Parameters.AddWithValue("@Soyad", müşteri.SOYADI);
                cmd.Parameters.AddWithValue("@Telefon", müşteri.TELEFONNO);
                cmd.Parameters.AddWithValue("@TcKimlikNo", müşteri.TCKİMLİKNO);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool MusteriGuncelle(elmüşterikayıt müşteri, int musteriId)
        {
            using (MySqlConnection conn = baglantı.getir())
            {
                string query = "UPDATE Musteriler SET Ad=@Ad, Soyad=@Soyad, Telefon=@Telefon, TcKimlikNo=@TcKimlikNo WHERE Id=@Id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", musteriId);
                cmd.Parameters.AddWithValue("@Ad", müşteri.ADI);
                cmd.Parameters.AddWithValue("@Soyad", müşteri.SOYADI);
                cmd.Parameters.AddWithValue("@Telefon", müşteri.TELEFONNO);
                cmd.Parameters.AddWithValue("@TcKimlikNo", müşteri.TCKİMLİKNO);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool MusteriSil(int musteriId)
        {
            using (MySqlConnection conn = baglantı.getir())
            {
                string query = "DELETE FROM Musteriler WHERE Id=@Id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", musteriId);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool OdaDurumunuGüncelle(string odaNo, string durum)
        {
            using (MySqlConnection conn = baglantı.getir())
            {
                string query = "UPDATE Odalar SET Durum=@Durum WHERE OdaNo=@OdaNo";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@OdaNo", odaNo);
                cmd.Parameters.AddWithValue("@Durum", durum);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public int RezervasyonOlustur(Rezervasyon rezervasyon)
        {
            using (MySqlConnection conn = baglantı.getir())
            {
                string query = "INSERT INTO Rezervasyonlar (MusteriAdi, OdaNumarasi, GirisTarihi, CikisTarihi, Ucret) VALUES (@MusteriAdi, @OdaNumarasi, @GirisTarihi, @CikisTarihi, @Ucret)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MusteriAdi", rezervasyon.MusteriAdi);
                cmd.Parameters.AddWithValue("@OdaNumarasi", rezervasyon.OdaNumarasi);
                cmd.Parameters.AddWithValue("@GirisTarihi", rezervasyon.GirisTarihi);
                cmd.Parameters.AddWithValue("@CikisTarihi", rezervasyon.CikisTarihi);
                cmd.Parameters.AddWithValue("@Ucret", rezervasyon.ToplamUcret);

                cmd.ExecuteNonQuery();
                return (int)cmd.LastInsertedId;
            }
        }

        public bool RezervasyonIptal(int rezervasyonId)
        {
            using (MySqlConnection conn = baglantı.getir())
            {
                string query = "DELETE FROM Rezervasyonlar WHERE Id=@Id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", rezervasyonId);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool RezervasyonGuncelle(Rezervasyon rezervasyon)
        {
            using (MySqlConnection conn = baglantı.getir())
            {
                string query = "UPDATE Rezervasyonlar SET GirisTarihi=@GirisTarihi, CikisTarihi=@CikisTarihi, Ucret=@Ucret WHERE Id=@Id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", rezervasyon.RezervasyonId);
                cmd.Parameters.AddWithValue("@GirisTarihi", rezervasyon.GirisTarihi);
                cmd.Parameters.AddWithValue("@CikisTarihi", rezervasyon.CikisTarihi);
                cmd.Parameters.AddWithValue("@Ucret", rezervasyon.ToplamUcret);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

    }
}