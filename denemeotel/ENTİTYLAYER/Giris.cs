using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace denemeotel.ENTİTYLAYER
{
    internal class Giris
    {
        private string kullanıcıAdı;
        private string kullanıcıSifre;

        public string KULLANICIADI { get { return kullanıcıAdı;} set { kullanıcıAdı = value; } }
        public string KULLANICISIFRE{ get { return kullanıcıSifre; } set { kullanıcıSifre = value; } }

        public Giris(string kullanıcıAdı, string kullanıcıSifre)
        {
            this.kullanıcıAdı = kullanıcıAdı;
            this.kullanıcıSifre = kullanıcıSifre;
            

        }
        public override string ToString()
        {
            return this.kullanıcıAdı + "-" + this.kullanıcıSifre;
        }
    }
}
