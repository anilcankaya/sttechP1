using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace introDotnetCore.Models
{
    public static class UrunKoleksiyonu
    {
        private static List<Urun> urunler = new List<Urun>();
        public static void UrunEkle(Urun urun)
        {
            urunler.Add(urun);
        }

        public static List<Urun> UrunleriGetir()
        {
            
            return urunler;
        }
    }
}
