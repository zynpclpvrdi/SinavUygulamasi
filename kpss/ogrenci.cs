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
    public partial class ogrenci : Form
    {
        private VT veritabani;
        private int kullaniciID;
        public Form1 frm;

        public ogrenci(VT veritabani, int kullaniciID, Form1 frm)
        {
            InitializeComponent();
            this.veritabani = veritabani;
            this.kullaniciID = kullaniciID;
            this.frm = frm;
        }

        private void ogrenci_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sorularr soru = new sorularr(veritabani,kullaniciID,frm);
            soru.ShowDialog();
        }

        private void ogrenci_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bilgilerim blg = new bilgilerim(veritabani, kullaniciID, frm);
            blg.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new sinavsonucu(veritabani, kullaniciID, -1, frm).ShowDialog();
        }
    }
}
