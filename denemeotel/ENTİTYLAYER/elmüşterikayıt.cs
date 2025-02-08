using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace denemeotel.ENTİTYLAYER
{
    public class elmüşterikayıt
    {
       
        public int Id { get; set; }  
        public string ADI { get; set; }
        public string SOYADI { get; set; }
        public string TELEFONNO { get; set; }
        public string TCKİMLİKNO { get; set; }

        
        public elmüşterikayıt(string Adı, string Soyadı, string TelefonNo, string TCKimlikNo)
        {
            this.ADI = Adı;
            this.SOYADI = Soyadı;
            this.TELEFONNO = TelefonNo;
            this.TCKİMLİKNO = TCKimlikNo;
        }

        
        public elmüşterikayıt() { }

        public override string ToString()
        {
            return $"{ADI}-{SOYADI}-{TELEFONNO}-{TCKİMLİKNO}";
        }
    }

    public class Oda
    {
        public string OdaNo { get; set; } 
        public string Durum { get; set; }  

        
        public Oda(string odaNo, string durum)
        {
            this.OdaNo = odaNo;
            this.Durum = durum;
        }

        
        public Oda() { }

        public override string ToString()
        {
            return $"{OdaNo} - {Durum}";
        }
    }

    public class Rezervasyon
    {
        public int RezervasyonId { get; set; }  
        public int MusteriId { get; set; }  
        public string MusteriAdi { get; set; }  
        public string OdaNumarasi { get; set; } 
        public DateTime GirisTarihi { get; set; }  
        public DateTime CikisTarihi { get; set; }  
        public decimal ToplamUcret { get; set; }  

        
        public Rezervasyon(int musteriId, string odaNumarasi, DateTime girisTarihi, DateTime cikisTarihi, decimal toplamUcret, string musteriAdi)
        {
            this.MusteriId = musteriId;
            this.OdaNumarasi = odaNumarasi;
            this.GirisTarihi = girisTarihi;
            this.CikisTarihi = cikisTarihi;
            this.ToplamUcret = toplamUcret;
            this.MusteriAdi = musteriAdi;  
        }

        
        public Rezervasyon() { }

        public override string ToString()
        {
            return $"{MusteriAdi} - {OdaNumarasi} - {GirisTarihi.ToShortDateString()} - {CikisTarihi.ToShortDateString()} - {ToplamUcret} TL";
        }
    }
}