using denemeotel.DAL;
using denemeotel.ENTİTYLAYER;
using System;

namespace denemeotel.BL
{
    public class blmüşterikayıt
    {
        private readonly dalmüşterikayıt _dalMusteriKayit;

        public blmüşterikayıt()
        {
            _dalMusteriKayit = new dalmüşterikayıt();
        }

        public bool MüşteriEkle(string adi, string soyadi, string telefonNo, string tcKimlikNo)
        {
            try
            {
                var müşteri = new elmüşterikayıt
                {
                    ADI = adi,
                    SOYADI = soyadi,
                    TELEFONNO = telefonNo,
                    TCKİMLİKNO = tcKimlikNo
                };
                return _dalMusteriKayit.MüşteriEkle(müşteri);
            }
            catch (Exception ex)
            {
                throw new Exception($"Müşteri ekleme hatası: {ex.Message}");
            }
        }

        public bool MusteriGuncelle(int musteriId, string adi, string soyadi, string telefonNo, string tcKimlikNo)
        {
            try
            {
                var müşteri = new elmüşterikayıt
                {
                    ADI = adi,
                    SOYADI = soyadi,
                    TELEFONNO = telefonNo,
                    TCKİMLİKNO = tcKimlikNo
                };
                return _dalMusteriKayit.MusteriGuncelle(müşteri, musteriId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Müşteri güncelleme hatası: {ex.Message}");
            }
        }

        public bool MusteriSil(int musteriId)
        {
            try
            {
                return _dalMusteriKayit.MusteriSil(musteriId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Müşteri silme hatası: {ex.Message}");
            }
        }

        public bool OdaDurumunuGüncelle(string odaNo, string durum)
        {
            try
            {
                return _dalMusteriKayit.OdaDurumunuGüncelle(odaNo, durum);
            }
            catch (Exception ex)
            {
                throw new Exception($"Oda durumu güncelleme hatası: {ex.Message}");
            }
        }

        public int RezervasyonOlustur(int musteriId, string odaNumarasi, DateTime girisTarihi, DateTime cikisTarihi, decimal ucret)
        {
            var rezervasyon = new Rezervasyon
            {
                MusteriAdi = musteriId.ToString(),  
                OdaNumarasi = odaNumarasi,
                GirisTarihi = girisTarihi,
                CikisTarihi = cikisTarihi,
                ToplamUcret = ucret
            };
            return _dalMusteriKayit.RezervasyonOlustur(rezervasyon);
        }


        public bool RezervasyonIptal(int rezervasyonId)
        {
            try
            {
                return _dalMusteriKayit.RezervasyonIptal(rezervasyonId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Rezervasyon iptal hatası: {ex.Message}");
            }
        }

        public bool RezervasyonGuncelle(int rezervasyonId, DateTime? yeniGirisTarihi = null, DateTime? yeniCikisTarihi = null, decimal? yeniUcret = null)
        {
            var rezervasyon = new Rezervasyon
            {
                RezervasyonId = rezervasyonId,
                GirisTarihi = yeniGirisTarihi ?? default(DateTime),
                CikisTarihi = yeniCikisTarihi ?? default(DateTime),
                ToplamUcret = yeniUcret ?? 0
            };
            return _dalMusteriKayit.RezervasyonGuncelle(rezervasyon);
        }

    }
}
