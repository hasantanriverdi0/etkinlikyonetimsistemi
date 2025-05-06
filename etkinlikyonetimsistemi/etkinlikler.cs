using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace etkinlikyonetimsistemi
{
    public class Etkinlik
    {
        public string Ad { get; set; }
        public DateTime Tarih { get; set; }
        public string Mekan { get; set; }

        public Etkinlik(string ad, DateTime tarih, string mekan)
        {
            Ad = ad;
            Tarih = tarih;
            Mekan = mekan;
        }

        public override string ToString()
        {
            return $"{Ad}, Tarih: {Tarih.ToShortDateString()}, Mekan: {Mekan}";
        }
    }

    public class Etkinlikler
    {
        public List<Etkinlik> EtkinlikListesi { get; } = new List<Etkinlik>();

        private string filePath = "etkinlikler.txt";

        public Etkinlikler()
        {
            EtkinlikleriYukle();
        }

        public void EtkinlikleriYukle()
        {
            EtkinlikListesi.Clear(); // Listeyi temizlemeden yükleme yapma

            if (File.Exists(filePath))
            {
                var etkinliklerVerisi = File.ReadAllLines(filePath);

                foreach (var etkinlikVerisi in etkinliklerVerisi)
                {
                    var etkinlikBilgileri = etkinlikVerisi.Split(',');

                    if (etkinlikBilgileri.Length == 3)
                    {
                        var ad = etkinlikBilgileri[0];
                        var tarih = DateTime.Parse(etkinlikBilgileri[1]);
                        var mekan = etkinlikBilgileri[2];

                        EtkinlikListesi.Add(new Etkinlik(ad, tarih, mekan));
                    }
                }
            }
        }

        public void EtkinlikleriKaydet()
        {
            List<string> etkinliklerStr = new List<string>();

            foreach (var etkinlik in EtkinlikListesi)
            {
                etkinliklerStr.Add($"{etkinlik.Ad},{etkinlik.Tarih.ToShortDateString()},{etkinlik.Mekan}");
            }

            File.WriteAllLines(filePath, etkinliklerStr);
        }

        public void EtkinlikEkle(string ad, DateTime tarih, string mekan)
        {
            if (!EtkinlikListesi.Any(e => e.Ad == ad && e.Tarih == tarih && e.Mekan == mekan))
            {
                EtkinlikListesi.Add(new Etkinlik(ad, tarih, mekan));
                EtkinlikleriKaydet();  // Yeni etkinliği kaydet
            }
        }

        public void EtkinlikSil(Etkinlik etkinlik)
        {
            EtkinlikListesi.Remove(etkinlik);
            EtkinlikleriKaydet();  // Silinen etkinliği kaydet
        }

        // Etkinlikleri listeleme fonksiyonu
        public List<Etkinlik> GetEtkinlikListesi()
        {
            return EtkinlikListesi;
        }
    }
}
