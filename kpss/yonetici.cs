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
    public partial class yonetici : Form
    {
        public VT veritabani;
        private Form1 frm;

        public yonetici(VT veritabani, Form1 frm)
        {
            InitializeComponent();
            this.veritabani = veritabani;
            this.frm = frm;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new kayitekle(veritabani,frm).Show();
        }

        private void yonetici_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            soru yeni = new soru(veritabani, frm);
            yeni.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Dersler yeni = new Dersler(veritabani,frm);
            yeni.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            kategori kat = new kategori(veritabani, frm);
            kat.ShowDialog();
        }
    }
}
