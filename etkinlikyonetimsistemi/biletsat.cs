using System;
using System.Windows.Forms;
using etkinlikyonetimsistemi;  // UyeManager sınıfının bulunduğu namespace

namespace etkinlikyonetimsistemi
{
    public partial class biletsat : Form
    {
        public biletsat()
        {
            InitializeComponent();
        }

        private void biletsat_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            // Üyeleri listBox1'e ekleyin
            UyeManager uyeManager = new UyeManager();
            foreach (Uye uye in uyeManager.UyeListele())
            {
                listBox1.Items.Add(uye.ToString());
            }

            // Etkinlikleri listBox2'ye ekleyin
            Etkinlikler etkinlikler = new Etkinlikler();
            foreach (Etkinlik etkinlik in etkinlikler.GetEtkinlikListesi())
            {
                listBox2.Items.Add(etkinlik.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            biletsil biletsil = new biletsil();
            biletsil.Show();
            this.Hide();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            etksecim etksecim = new etksecim();
            etksecim.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string secilenUye = (string)listBox1.SelectedItem;
            string secilenEtkinlik = (string)listBox2.SelectedItem;

            if (secilenUye != null && secilenEtkinlik != null)
            {
                DialogResult result = MessageBox.Show(
                    "Bilet Satışı Yapılacak Üye: " + secilenUye + "\n\nEtkinlik Bilgileri: " + secilenEtkinlik,
                    "Bilet Satışı",
                    MessageBoxButtons.OKCancel);

                if (result == DialogResult.OK)
                {
                    string bilet = $"{secilenUye} - {secilenEtkinlik}";
                    GlobalData.SelectedTickets.Add(bilet);  // Bilet verisini global listede tut
                    MessageBox.Show("Bilet satışı başarıyla tamamlandı.", "Başarılı");
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir üye ve etkinlik seçiniz.");
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
