using System;
using System.Windows.Forms;

namespace etkinlikyonetimsistemi
{
    public partial class etksecim : Form
    {
        private Etkinlikler etkinlikVerisi;

        public etksecim()
        {
            InitializeComponent();
            etkinlikVerisi = new Etkinlikler(); // Etkinlikler nesnesi burada başlatılıyor
        }

        private void etksecim_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            etkuye etkuye = new etkuye();
            etkuye.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            etklist etklistForm = new etklist(etkinlikVerisi);
            etklistForm.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            biletsat biletsat = new biletsat();
            biletsat.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            biletsil biletsil = new biletsil(etkinlikVerisi);
            biletsil.Show();
            this.Hide();
        }
    }
}
