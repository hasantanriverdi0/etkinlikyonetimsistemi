using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace etkinlikyonetimsistemi
{
    public partial class etkana : Form
    {
        public etkana()
        {
            InitializeComponent();
        }

        Dictionary<string, string> adminBilgileri = new Dictionary<string, string>()
        {
             {"admin1", "admingiris34"},
             {"admin2", "kütüphane1"},
             {"admin3", "admingiris3"},
             {"admin4", "mahmut3434"},
             {"admin5", "deneme1"},
             {"a","a" }
        };

        private void etkana_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = textBox1.Text;
            string sifre = textBox2.Text;

            if (adminBilgileri.ContainsKey(kullaniciAdi) && adminBilgileri[kullaniciAdi] == sifre)
            {
                etksecim etksecim = new etksecim();
                etksecim.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre hatalı!");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.PasswordChar = '\0';
            }
            else 
            {
                textBox2.PasswordChar = '*';
            }
        }
    }    
}
