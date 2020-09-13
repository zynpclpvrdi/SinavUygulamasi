using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace kpss
{
    public partial class bilgilerim : Form
    {
        private VT veritabani;
        public Form1 frm;
        public int kullaniciID;

        public bilgilerim(VT veritabani, int kullaniciID, Form1 frm)
        {
            InitializeComponent();
            this.veritabani = veritabani;
            this.kullaniciID = kullaniciID;
            this.frm = frm;
            Baglan();

        }
        public void Baglan()
        {
            try
            {
                if (veritabani.con.State == ConnectionState.Closed)
                    veritabani.con.Open();
                string tablo = "select * from kullanicitablosu where kullaniciid=" + kullaniciID;
                veritabani.kmt.CommandText = tablo;
                veritabani.reader = veritabani.kmt.ExecuteReader();
                if(veritabani.reader.Read())
                {
                    txtadi.Text = veritabani.reader.GetString(3);
                    txtsoyadi.Text = veritabani.reader.GetString(4);
                    txtsifre.Text = veritabani.reader.GetString(2);
                    txtposta.Text = veritabani.reader.GetString(5);                    
                }
                veritabani.reader.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bilgilerim_Load(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!txtsifre.Text.Equals(txtsifretekrari.Text))
            {
                MessageBox.Show("Şifreler uyuşmuyor");
                return;
            }
            string sorgu = "UPDATE kullanicitablosu SET adi='" + txtadi.Text + "', soyadi='" +
                       txtsoyadi.Text + "', sifre='" + txtsifre.Text + "' , eposta='" + txtposta.Text + "' where kullaniciid=" + kullaniciID;
            veritabani.kmt.CommandText = sorgu;
          
                DialogResult secenek = MessageBox.Show("Değişiklikleri kaydetmek istiyor musunuz?", "Bilgilendirme Penceresi", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);

            if (secenek == DialogResult.Yes)
            {
                veritabani.kmt.ExecuteNonQuery();
                Baglan();
                MessageBox.Show("Kayıt güncellendi.");

            }

            else if (secenek == DialogResult.No)
            {
                MessageBox.Show("Güncelleme başarısız.");
            }
        }
    }
}
