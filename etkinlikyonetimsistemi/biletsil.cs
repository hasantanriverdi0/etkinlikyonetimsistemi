using System;
using System.Windows.Forms;
using System.Linq;


namespace etkinlikyonetimsistemi
{
    public partial class biletsil : Form
    {
        private Etkinlikler etkinlikVerisi;

        public biletsil()
        {
            InitializeComponent();
        }

        private void biletsil_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            // GlobalData'dan seçilen biletleri listBox1'e ekleyin
            foreach (string bilet in GlobalData.SelectedTickets)
            {
                listBox1.Items.Add(bilet);
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
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            etksecim etksecim = new etksecim();
            etksecim.Show();
            this.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public biletsil(Etkinlikler etkinliklerNesnesi)
        {
            InitializeComponent();
            etkinlikVerisi = etkinliklerNesnesi;
        }


        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string secilenBilet = listBox1.SelectedItem.ToString();
                listBox1.Items.Remove(secilenBilet);
                GlobalData.SelectedTickets.Remove(secilenBilet); // Seçilen bileti sil
            }
            else
            {
                MessageBox.Show("Lütfen silinecek bir bilet seçiniz.");
            }
        }

        private void biletsil_Load_1(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            // GlobalData'dan seçilen biletleri listBox1'e ekleyin
            foreach (string bilet in GlobalData.SelectedTickets)
            {
                listBox1.Items.Add(bilet);
            }
        }
        private void GuncelleListe()
        {
            // Null kontrolü ekleyerek güvenli bir şekilde işlem yapıyoruz.
            if (etkinlikVerisi != null && etkinlikVerisi.EtkinlikListesi != null)
            {
                listBox1.Items.Clear();
                foreach (var etkinlik in etkinlikVerisi.EtkinlikListesi)
                {
                    listBox1.Items.Add(etkinlik.ToString());
                }
            }
            else
            {
                MessageBox.Show("Etkinlik verileri yüklenemedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
