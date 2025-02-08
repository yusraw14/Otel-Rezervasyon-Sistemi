using denemeotel.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace denemeotel.BL
{
    internal class blgiris
    {
        internal void giris ( string kullanıcıAdı, string kullanıcıSifre)
        {
            (new dalgiris()).giris(new ENTİTYLAYER.Giris(kullanıcıAdı, kullanıcıSifre));
        }

    }
}
