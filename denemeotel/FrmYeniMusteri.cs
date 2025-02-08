using denemeotel.BL;
using denemeotel.DAL;
using denemeotel.ENTİTYLAYER;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace denemeotel
{
    public partial class FrmYeniMusteri : Form
    {
        private readonly blmüşterikayıt _blMusteriKayit;

        public FrmYeniMusteri()
        {
            InitializeComponent();
            _blMusteriKayit = new blmüşterikayıt();

            
            foreach (Control item in groupBox2.Controls)
            {
                if (item is Button btn && btn.Name.StartsWith("btnOda"))
                {
                    btn.Click += OdaButonu_Click;
                    btn.BackColor = Color.LightGreen; 
                }
            }
        }

        private void FrmYeniMusteri_Load(object sender, EventArgs e)
        {
            
            LoadCustomers();
            LoadRooms();
            LoadCustomerDataGrid();
            LoadReservationDataGrid();
            UpdateRoomColors();
        }

        private void UpdateRoomColors()
        {
            foreach (Control item in groupBox2.Controls)
            {
                if (item is Button btn && btn.Name.StartsWith("btnOda"))
                {
                    bool isOccupied = IsRoomOccupied(btn.Text, dtpGiris.Value, dtpCikis.Value);
                    btn.BackColor = isOccupied ? Color.Red : Color.LightGreen;
                    btn.Enabled = !isOccupied;
                }
            }
        }

        private bool IsRoomOccupied(string roomNo, DateTime checkIn, DateTime checkOut)
        {
            using (MySqlConnection conn = baglantı.getir())
            {
                string query = @"
            SELECT COUNT(*) 
            FROM Rezervasyonlar 
            WHERE OdaNo = @odaNo 
            AND ((GirisTarihi BETWEEN @checkIn AND @checkOut) 
            OR (CikisTarihi BETWEEN @checkIn AND @checkOut)
            OR (@checkIn BETWEEN GirisTarihi AND CikisTarihi))";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@odaNo", roomNo);
                    cmd.Parameters.AddWithValue("@checkIn", checkIn);
                    cmd.Parameters.AddWithValue("@checkOut", checkOut);
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }

        private void OdaButonu_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            cmbOda.SelectedItem = btn.Text; 
        }

        
        private void btnRezEkle_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbMusteri.SelectedItem == null || cmbOda.SelectedItem == null)
                {
                    MessageBox.Show("Lütfen müşteri ve oda seçin.", "Uyarı");
                    return;
                }

                string odaNumarasi = cmbOda.SelectedItem.ToString();
                if (IsRoomOccupied(odaNumarasi, dtpGiris.Value, dtpCikis.Value))
                {
                    MessageBox.Show("Seçilen tarih aralığında oda dolu!", "Uyarı");
                    return;
                }

                
                var selectedMusteri = (dynamic)cmbMusteri.SelectedItem;
                int musteriId = selectedMusteri.Value; 

                
                DateTime girisTarihi = dtpGiris.Value;
                DateTime cikisTarihi = dtpCikis.Value;

                
                int gunSayisi = Math.Max(1, (cikisTarihi - girisTarihi).Days);

                
                decimal toplamUcret = 250m * gunSayisi;

                
                string query = @"
                    INSERT INTO Rezervasyonlar (MusteriId, OdaNo, GirisTarihi, CikisTarihi, Ucret) 
                    VALUES (@MusteriId, @OdaNo, @GirisTarihi, @CikisTarihi, @Ucret)";

                using (MySqlConnection conn = baglantı.getir()) 
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MusteriId", musteriId);
                    cmd.Parameters.AddWithValue("@OdaNo", odaNumarasi);
                    cmd.Parameters.AddWithValue("@GirisTarihi", girisTarihi);
                    cmd.Parameters.AddWithValue("@CikisTarihi", cikisTarihi);
                    cmd.Parameters.AddWithValue("@Ucret", toplamUcret);

                    cmd.ExecuteNonQuery(); 
                }

                
                MessageBox.Show("Rezervasyon başarıyla oluşturuldu.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadReservationDataGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       >
        private void LoadCustomers()
        {
            string query = "SELECT Id, CONCAT(Ad, ' ', Soyad) AS FullName FROM Musteriler";
            using (MySqlConnection conn = baglantı.getir())
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                cmbMusteri.Items.Clear(); 
                while (reader.Read())
                {
                    cmbMusteri.Items.Add(new { Text = reader["FullName"].ToString(), Value = reader["Id"] });
                }
            }
        }

       
        private void LoadRooms()
        {
            string query = "SELECT OdaNo FROM Odalar";
            using (MySqlConnection conn = baglantı.getir())
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                cmbOda.Items.Clear(); 
                while (reader.Read())
                {
                    cmbOda.Items.Add(reader["OdaNo"].ToString());
                }
            }
        }

       
        private void LoadCustomerDataGrid()
        {
            string query = "SELECT Id, Ad, Soyad, Telefon, TcKimlikNo FROM Musteriler";
            using (MySqlConnection conn = baglantı.getir())
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                da.Fill(dt); 
                dgMusteriler.DataSource = dt; 
            }
        }

        
        private void LoadReservationDataGrid()
        {
            try
            {
                string query = @"
                    SELECT r.Id, m.Ad, m.Soyad, r.OdaNo, r.GirisTarihi, r.CikisTarihi, r.Ucret 
                    FROM Rezervasyonlar r 
                    JOIN Musteriler m ON r.MusteriId = m.Id";

                using (MySqlConnection conn = baglantı.getir())
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt); 
                    dgRezervasyonlar.DataSource = dt; 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      
        private void btnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMusteriEkle_Click(object sender, EventArgs e)
        {
            try
            {
  
                if (string.IsNullOrWhiteSpace(TxtAdi.Text) ||
                    string.IsNullOrWhiteSpace(TxtSoyadi.Text) ||
                    string.IsNullOrWhiteSpace(maskedTextBox1.Text) ||
                    string.IsNullOrWhiteSpace(TxtTCkimlik.Text))
                {
                    MessageBox.Show("Lütfen tüm alanları doldurunuz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                
                var müşteriKayıt = new blmüşterikayıt();

                
                bool sonuç = müşteriKayıt.MüşteriEkle(
                    TxtAdi.Text.Trim(),
                    TxtSoyadi.Text.Trim(),
                    maskedTextBox1.Text.Trim(),
                    TxtTCkimlik.Text.Trim()
                );

                if (sonuç)
                {
                    LoadCustomers(); 
                    Temizle();
                    MessageBox.Show("Müşteri başarıyla kaydedildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMusteriGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgMusteriler.CurrentRow == null)
                {
                    MessageBox.Show("Lütfen güncellenecek müşteriyi seçin.");
                    return;
                }

                int musteriId = Convert.ToInt32(dgMusteriler.CurrentRow.Cells["Id"].Value);
                var müşteriKayıt = new blmüşterikayıt();

                bool sonuç = müşteriKayıt.MusteriGuncelle(
                    musteriId,
                    TxtAdi.Text.Trim(),
                    TxtSoyadi.Text.Trim(),
                    maskedTextBox1.Text.Trim(),
                    TxtTCkimlik.Text.Trim()
                );

                if (sonuç)
                {
                    LoadCustomers();
                    LoadCustomerDataGrid();
                    Temizle();
                    MessageBox.Show("Müşteri güncellendi!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void btnMusteriSil_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgMusteriler.CurrentRow == null)
                {
                    MessageBox.Show("Lütfen silinecek müşteriyi seçin.");
                    return;
                }

                int musteriId = Convert.ToInt32(dgMusteriler.CurrentRow.Cells["Id"].Value);
                var müşteriKayıt = new blmüşterikayıt();

                if (MessageBox.Show("Müşteriyi silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    bool sonuç = müşteriKayıt.MusteriSil(musteriId);
                    if (sonuç)
                    {
                        LoadCustomers();
                        LoadCustomerDataGrid();
                        Temizle();
                        MessageBox.Show("Müşteri silindi!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void btnRezGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgRezervasyonlar.CurrentRow == null)
                {
                    MessageBox.Show("Lütfen güncellenecek rezervasyonu seçin.");
                    return;
                }

                int rezervasyonId = Convert.ToInt32(dgRezervasyonlar.CurrentRow.Cells["Id"].Value);
                var rezervasyonIslem = new blmüşterikayıt();

                bool sonuç = rezervasyonIslem.RezervasyonGuncelle(
                    rezervasyonId,
                    dtpGiris.Value,
                    dtpCikis.Value,
                    UcretHesapla(dtpGiris.Value, dtpCikis.Value)
                );

                if (sonuç)
                {
                    LoadReservationDataGrid();
                    UpdateRoomColors();
                    Temizle();
                    MessageBox.Show("Rezervasyon güncellendi!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void btnRezSil_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgRezervasyonlar.CurrentRow == null)
                {
                    MessageBox.Show("Lütfen silinecek rezervasyonu seçin.");
                    return;
                }

                int rezervasyonId = Convert.ToInt32(dgRezervasyonlar.CurrentRow.Cells["Id"].Value);
                var rezervasyonIslem = new blmüşterikayıt();

                if (MessageBox.Show("Rezervasyonu iptal etmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    bool sonuç = rezervasyonIslem.RezervasyonIptal(rezervasyonId);
                    if (sonuç)
                    {
                        LoadReservationDataGrid();
                        UpdateRoomColors();
                        Temizle();
                        MessageBox.Show("Rezervasyon iptal edildi!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private decimal UcretHesapla(DateTime girisTarihi, DateTime cikisTarihi)
        {
            decimal gecelikUcret = 250; 
            int geceSayisi = (cikisTarihi.Date - girisTarihi.Date).Days;
            geceSayisi = Math.Max(1, geceSayisi); 
            return geceSayisi * gecelikUcret;
        }

        private void Temizle()
        {
            TxtAdi.Clear();
            TxtSoyadi.Clear();
            maskedTextBox1.Clear();
            TxtTCkimlik.Clear();
            cmbMusteri.SelectedIndex = -1;
            cmbOda.SelectedIndex = -1;
            dtpGiris.Value = DateTime.Now;
            dtpCikis.Value = DateTime.Now;
        }

        private int GetRezervasyonIdForMusteri(int musteriId, string odaNo)
        {
            using (MySqlConnection conn = baglantı.getir())
            {
                string query = @"
            SELECT Id 
            FROM Rezervasyonlar 
            WHERE MusteriId = @musteriId AND OdaNo = @odaNo";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@musteriId", musteriId);
                    cmd.Parameters.AddWithValue("@odaNo", odaNo);
                    var result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : throw new Exception("Rezervasyon bulunamadı.");
                }
            }
        }

        private void dtpGiris_ValueChanged(object sender, EventArgs e)
        {
            UpdateRoomColors();
        }

        private void dtpCikis_ValueChanged(object sender, EventArgs e)
        {
            UpdateRoomColors();
        }

        private void dgMusteriler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgMusteriler.Rows[e.RowIndex];

                TxtAdi.Text = row.Cells["Ad"].Value.ToString();
                TxtSoyadi.Text = row.Cells["Soyad"].Value.ToString();
                maskedTextBox1.Text = row.Cells["Telefon"].Value.ToString();
                TxtTCkimlik.Text = row.Cells["TcKimlikNo"].Value.ToString();

               
                foreach (var item in cmbMusteri.Items)
                {
                    dynamic customer = item;
                    if (customer.Text == $"{TxtAdi.Text} {TxtSoyadi.Text}")
                    {
                        cmbMusteri.SelectedItem = item;
                        break;
                    }
                }
            }
        }

        private void dgRezervasyonlar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgRezervasyonlar.Rows[e.RowIndex];

                string customerName = $"{row.Cells["Ad"].Value} {row.Cells["Soyad"].Value}";
                cmbOda.SelectedItem = row.Cells["OdaNo"].Value.ToString();
                dtpGiris.Value = Convert.ToDateTime(row.Cells["GirisTarihi"].Value);
                dtpCikis.Value = Convert.ToDateTime(row.Cells["CikisTarihi"].Value);

                
                foreach (var item in cmbMusteri.Items)
                {
                    dynamic customer = item;
                    if (customer.Text == customerName)
                    {
                        cmbMusteri.SelectedItem = item;
                        break;
                    }
                }
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
}