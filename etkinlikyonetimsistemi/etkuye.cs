using System;
using System.Linq;
using System.Windows.Forms;

namespace etkinlikyonetimsistemi
{
    public partial class etkuye : Form
    {
        private UyeManager uyeManager;

        public etkuye()
        {
            InitializeComponent();
            uyeManager = new UyeManager();  // Üye yöneticisini oluştur
        }

        private void etkuye_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            // Üyeleri yükle ve listeyi güncelle
            GuncelleListe();
        }

        // Listeyi güncelleyen metod
        private void GuncelleListe()
        {
            listBox1.Items.Clear();  // Önceki öğeleri temizle

            foreach (var uye in uyeManager.UyeListele())
            {
                listBox1.Items.Add(uye.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string secilenUyeStr = listBox1.SelectedItem.ToString();
                var silinecekUye = uyeManager.UyeListele()
                    .FirstOrDefault(uye => uye.ToString() == secilenUyeStr);

                if (silinecekUye != null)
                {
                    uyeManager.UyeSil(silinecekUye);  // Üyeyi sil
                    GuncelleListe();  // Listeyi güncelle

                    MessageBox.Show("Üye başarıyla silindi.");
                }
            }
            else
            {
                MessageBox.Show("Lütfen silinecek bir üye seçiniz.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            etkuyeekle etkuyeEkleFormu = new etkuyeekle(uyeManager);
            etkuyeEkleFormu.ShowDialog();
            GuncelleListe();  // Üye eklendikten sonra listeyi güncelle
        }

        private void button3_Click(object sender, EventArgs e)
        {
            etksecim etksecim = new etksecim();
            etksecim.Show();
            this.Hide();
        }
    }
}
