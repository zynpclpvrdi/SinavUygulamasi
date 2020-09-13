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
    public partial class Form1 : Form
    {
        public VT veritabani;
        public int kullaniciTipi;
        public int kullaniciID;
        public static string adi;
        public static string soyadi;
        public int aktif;

        public Form1()
        {
            InitializeComponent();
            veritabani = new VT();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
        private void button2_Click(object sender, EventArgs e)
        {
            ekle yeni = new ekle(veritabani, this);
            yeni.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sorgu = "SELECT * from kullanicitablosu where kullaniciAdi='" + txtkuladi.Text.Trim() + "' and sifre='" + txtsif.Text.Trim() + "'";
            veritabani.kmt.CommandText = sorgu;
            veritabani.reader = veritabani.kmt.ExecuteReader();
            if (veritabani.reader.Read())
            {
                kullaniciID = veritabani.reader.GetInt32(0);
                adi = veritabani.reader.GetString(3);
                soyadi = veritabani.reader.GetString(4);
                kullaniciTipi = veritabani.reader.GetInt32(6);
                aktif = veritabani.reader.GetInt32(7);
                veritabani.reader.Close();

                if(aktif == 0)
                {
                    MessageBox.Show("Sistemde kaydınız bulunmamaktadır.");
                    return;
                }

                if (kullaniciTipi == 1)
                    new yonetici(veritabani, this).Show();
                else
                    new ogrenci(veritabani, kullaniciID,this).Show();
                Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre hatalı.");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}