using System;
using System.Windows.Forms;

namespace etkinlikyonetimsistemi
{
    public partial class etklistekle : Form
    {
        private Etkinlikler etkinlikVerisi;

        public etklistekle(Etkinlikler etkinliklerNesnesi)
        {
            InitializeComponent();
            etkinlikVerisi = etkinliklerNesnesi;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ad = textBoxAd.Text;
            string mekan = textBoxMekan.Text;
            DateTime tarih = dateTimePickerTarih.Value;

            if (string.IsNullOrWhiteSpace(ad) || string.IsNullOrWhiteSpace(mekan))
            {
                MessageBox.Show("Etkinlik adı ve mekanını boş bırakmayın!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (tarih < DateTime.Today)
            {
                MessageBox.Show("Lütfen geçerli bir tarih giriniz. Etkinlik tarihi bugünden önce olamaz.", "Geçersiz Tarih", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            etkinlikVerisi.EtkinlikEkle(ad, tarih, mekan);
            etkinlikVerisi.EtkinlikleriKaydet();

            MessageBox.Show("Etkinlik başarıyla eklendi!");
            this.Close();
        }

        private void textBoxAd_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
