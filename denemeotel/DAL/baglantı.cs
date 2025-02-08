using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace denemeotel.DAL
{
    public class baglantı
    {
        public static MySqlConnection getir()
        {
            MySqlConnection baglanti = new MySqlConnection("Server=172.21.54.253; Database=25_132330047; Uid=25_132330047; Pwd=!nif.ogr47YI");
            baglanti.Open();
            return baglanti;
        }
    }
}
