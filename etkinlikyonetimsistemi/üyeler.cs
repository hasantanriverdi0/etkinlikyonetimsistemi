using System;
using System.Collections.Generic;
using System.IO;

namespace etkinlikyonetimsistemi
{
    public class Uye
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string No { get; set; }

        public Uye(string ad, string soyad, string no)
        {
            Ad = ad;
            Soyad = soyad;
            No = no;
        }

        public override string ToString()
        {
            return $"{Ad} {Soyad}, No: {No}";
        }
    }

    public class UyeManager
    {
        private List<Uye> uyeListesi;
        private string filePath = "uyeler.txt";  // Üyelerin dosyada saklanacağı dosya yolu

        public UyeManager()
        {
            uyeListesi = new List<Uye>();
            UyeYukle();  // Başlangıçta üyeleri dosyadan yükle
        }

        // Üyeleri dosyaya kaydet
        public void UyeKaydet()
        {
            List<string> uyeStrListesi = new List<string>();

            foreach (var uye in uyeListesi)
            {
                uyeStrListesi.Add($"{uye.Ad},{uye.Soyad},{uye.No}");
            }

            File.WriteAllLines(filePath, uyeStrListesi);
        }

        // Üyeleri dosyadan yükle
        public void UyeYukle()
        {
            if (File.Exists(filePath))
            {
                var uyeVerisi = File.ReadAllLines(filePath);
                foreach (var uyeStr in uyeVerisi)
                {
                    var uyeBilgileri = uyeStr.Split(',');

                    if (uyeBilgileri.Length == 3)
                    {
                        var ad = uyeBilgileri[0];
                        var soyad = uyeBilgileri[1];
                        var no = uyeBilgileri[2];

                        uyeListesi.Add(new Uye(ad, soyad, no));
                    }
                }
            }
        }

        // Üye ekle
        public void UyeEkle(string ad, string soyad)
        {
            string no = (uyeListesi.Count + 1).ToString("D2");  // No'yu otomatik olarak artır
            uyeListesi.Add(new Uye(ad, soyad, no));
            UyeKaydet();  // Yeni üyeyi kaydet
        }

        // Üye sil
        public void UyeSil(Uye uye)
        {
            uyeListesi.Remove(uye);
            UyeKaydet();  // Silinen üyeyi kaydet
        }

        // Üyeleri listele
        public List<Uye> UyeListele()
        {
            return uyeListesi;
        }
    }
}
