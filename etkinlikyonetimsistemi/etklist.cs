using System;
using System.Linq;
using System.Windows.Forms;
using etkinlikyonetimsistemi;

namespace etkinlikyonetimsistemi
{
    public partial class etklist : Form
    {
        private Etkinlikler etkinlikVerisi;

        public etklist(Etkinlikler etkinliklerNesnesi)
        {
            InitializeComponent();
            etkinlikVerisi = etkinliklerNesnesi;
        }

        private void etklist_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            etkinlikVerisi.EtkinlikleriYukle();
            GuncelleListe();
        }

        public void GuncelleListe()
        {
            listBox1.Items.Clear();
            foreach (var etkinlik in etkinlikVerisi.EtkinlikListesi)
            {
                listBox1.Items.Add(etkinlik.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            etksecim etksecim = new etksecim();
            etksecim.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string secilenEtkinlikStr = listBox1.SelectedItem.ToString();
                var silinecek = etkinlikVerisi.EtkinlikListesi.FirstOrDefault(etk => etk.ToString() == secilenEtkinlikStr);

                if (silinecek != null)
                {
                    etkinlikVerisi.EtkinlikSil(silinecek);
                    listBox1.Items.Remove(listBox1.SelectedItem);
                    MessageBox.Show("Etkinlik başarıyla silindi.");
                }
            }
            else
            {
                MessageBox.Show("Lütfen silinecek bir etkinlik seçiniz.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            etklistekle etkinlikEklemeFormu = new etklistekle(etkinlikVerisi);
            etkinlikEklemeFormu.ShowDialog();
            etkinlikVerisi.EtkinlikleriYukle();
            GuncelleListe();
        }
    }
}
