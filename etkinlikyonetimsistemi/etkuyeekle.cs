using System;
using System.Windows.Forms;

namespace etkinlikyonetimsistemi
{
    public partial class etkuyeekle : Form
    {
        private UyeManager uyeManager;

        public etkuyeekle(UyeManager uyeManager)
        {
            InitializeComponent();
            this.uyeManager = uyeManager;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string ad = textBox3.Text;
            string soyad = textBox4.Text;

            if (string.IsNullOrWhiteSpace(ad) || string.IsNullOrWhiteSpace(soyad))
            {
                MessageBox.Show("Lütfen ad ve soyad giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Yeni üye ekle
            uyeManager.UyeEkle(ad, soyad);

            MessageBox.Show("Üye başarıyla eklendi.");
            this.Close();
        }
    }
}
