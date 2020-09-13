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
    public partial class ekle : Form
    {
        private VT veritabani;
        private Form1 frm;

        public ekle(VT veritabani, Form1 frm)
        {
            InitializeComponent();
            this.veritabani = veritabani;
            this.frm = frm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                string kayit = "insert into KullaniciTablosu(adi,soyadi,kullaniciAdi,sifre,eposta,kullaniciTipi) values('"+textBox1.Text+"','"+textBox2.Text+"','"+textBox3.Text+"','"+textBox4.Text+"','"+textBox5.Text+"',2)";
                veritabani.kmt.CommandText = kayit;
                veritabani.kmt.ExecuteNonQuery();
                MessageBox.Show("Kayıt Başarılı.");
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
