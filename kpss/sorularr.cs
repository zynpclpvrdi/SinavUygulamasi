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
using System.Collections;

namespace kpss
{
    public partial class sorularr : Form
    {
        public VT veritabani;
        public int kullaniciID;
        int _Saniye = 0, _Dakika = 0, _Saat = 0;
        public int dersId;
        public int soruId;
        public int kategoriId;
        public Form1 frm;
        public int secilenSinav;
        public string dersAdi;
        int sayac = 0;
        int dogruSayisi = 0;
        int yanlisSayisi = 0;
        int bosSayisi = 0;
        char isaretliSecenek;
        char dogruSecenek;
        private ArrayList secenekler;

        public sorularr(VT veritabani, int kullaniciID, Form1 frm)
        {
            InitializeComponent();
            this.veritabani = veritabani;
            this.kullaniciID = kullaniciID;
            this.frm = frm;
        }

        private void sorularr_Load(object sender, EventArgs e)
        {

            string dersSorgu = "Select dersId, dersAdi from dersler";
            veritabani.kmt.CommandText = dersSorgu;
            veritabani.adp = new MySqlDataAdapter(veritabani.kmt);
            DataTable dt1 = new DataTable();
            veritabani.adp.Fill(dt1);

            DataRow dr = dt1.NewRow();
            dr.ItemArray = new object[] { -1, "-- Sınav Seçiniz --" };
            dt1.Rows.InsertAt(dr, 0);

            cmbsinav.DisplayMember = "dersAdi";
            cmbsinav.ValueMember = "dersId";
            cmbsinav.DataSource = dt1;

            veritabani.reader.Close();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            secilenSinav = cmbsinav.SelectedIndex;

            if (secilenSinav < 1)
            {
                MessageBox.Show("Sınav yapılacak dersi seçmelisiniz");
                cmbsinav.Focus();
                return;
            }

            secenekler = new ArrayList();
            sayac = 0;
            _Saniye = 0;
            _Dakika = 0;
            _Saat = 0;
            dogruSayisi = 0;
            yanlisSayisi = 0;
            bosSayisi = 0;
            timer1.Enabled = true;
            button2.Enabled = true;
            cmbsinav.Enabled = false;
            button1.Enabled = false;

            dersId = Convert.ToInt32(cmbsinav.SelectedValue);
            SinavYap(dersId);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dersId = Convert.ToInt32(cmbsinav.SelectedValue);
            SinavYap(dersId);
            rdbtnA.Checked = false;
            rdbtnB.Checked = false;
            rdbtnC.Checked = false;
            rdbtnD.Checked = false;
        }
        
        private void button5_Click(object sender, EventArgs e)
        {
            secilenSinav = cmbsinav.SelectedIndex;

            if (secilenSinav < 1)
            {
                MessageBox.Show("Sınav yapılacak dersi seçmelisiniz");
                cmbsinav.Focus();
                return;
            }
            dersId = Convert.ToInt32(cmbsinav.SelectedValue);
            MessageBox.Show(cmbsinav.Text + " Sınavı sona ermiştir.\r\n " +
                "\r\nSüreniz : " + label3.Text);

            timer1.Enabled = false;
            button2.Enabled = false;
            cmbsinav.Enabled = true;
            button1.Enabled = true;

            string sinavSonuc = "Insert into sinavSonucu (kullaniciId, dersId, dogruSayisi, yanlisSayisi, bosSayisi, sinavTarihi) values (" +
                kullaniciID + ", " + dersId + ", " + dogruSayisi + ", " + yanlisSayisi + ", " + bosSayisi + ", NOW()); SELECT LAST_INSERT_ID();";
            if (veritabani.con.State == ConnectionState.Closed)
                veritabani.con.Open();
            veritabani.kmt.CommandText = sinavSonuc;
            int sinavSonucuId = Convert.ToInt32(veritabani.kmt.ExecuteScalar());

            foreach(var s in secenekler)
            {
                string sinavCevaplar = "Insert into cevaplar (sinavSonucuId, soruId, isaretliSecenek, dogruSecenek) values (" +
                    sinavSonucuId + ", " + s.ToString().Split('-')[0] + ", '" + s.ToString().Split('-')[1] + "', '" + s.ToString().Split('-')[2] + "');";
                if (veritabani.con.State == ConnectionState.Closed)
                    veritabani.con.Open();
                veritabani.kmt.CommandText = sinavCevaplar;
                veritabani.kmt.ExecuteNonQuery();
            }


            string sorgu = "update sorular set soruldu = 0;";
            if (veritabani.con.State == ConnectionState.Closed)
                veritabani.con.Open();
            veritabani.kmt.CommandText = sorgu;
            veritabani.kmt.ExecuteNonQuery();
            
            sinavsonucu cevap = new sinavsonucu(veritabani, kullaniciID,dersId,frm);
            cevap.ShowDialog();
            
            sayac = 0;
            _Saniye = 0;
            _Dakika = 0;
            _Saat = 0;
            dogruSayisi = 0;
            yanlisSayisi = 0;
            bosSayisi = 0;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        public void SinavYap(int dersId)
        {
            if (sayac > 0)
            {
                //if (!rdbtnA.Checked && !rdbtnB.Checked && !rdbtnC.Checked && !rdbtnD.Checked)
                //    bosSayisi++;
                //else
                //{
                char secenek = ' ';
                string dogruCevap = "select dogruSecenek FROM sorular where soruId=" + soruId;
                if (veritabani.con.State == ConnectionState.Closed)
                    veritabani.con.Open();
                veritabani.kmt.CommandText = dogruCevap;
                veritabani.reader = veritabani.kmt.ExecuteReader();
                if (veritabani.reader.Read())
                {
                    secenek = veritabani.reader.GetChar("dogruSecenek");
                }
                veritabani.reader.Close();
                if (rdbtnA.Checked) { isaretliSecenek = 'A'; }
                else if(rdbtnB.Checked) { isaretliSecenek = 'B'; }
                else if (rdbtnC.Checked) { isaretliSecenek = 'C'; }
                else if (rdbtnD.Checked) { isaretliSecenek = 'D'; }
                else { isaretliSecenek = 'X'; bosSayisi++; }

                switch (secenek)
                {
                    case 'A': if (rdbtnA.Checked) { dogruSayisi++; } else yanlisSayisi++; break;
                    case 'B': if (rdbtnB.Checked) { dogruSayisi++; } else yanlisSayisi++; break;
                    case 'C': if (rdbtnC.Checked) { dogruSayisi++; } else yanlisSayisi++; break;
                    case 'D': if (rdbtnD.Checked) { dogruSayisi++; } else yanlisSayisi++; break;
                    default: break;
                }

                secenekler.Add(soruId + "-" + isaretliSecenek + "-" + dogruSecenek);
               // }
            }
            string sorgu = "";

            if(dersId > 1)
            {
                sorgu = "SELECT s.soruId, d.dersId, d.dersAdi, k.kategoriAdi, s.soruAdi, s.secenekA, s.secenekB, " +
                            "s.secenekC, s.secenekD, s.dogruSecenek, s.aktif, s.soruldu FROM sorular s " +
                            "INNER JOIN kategoriler k ON(s.kategoriId = k.kategoriId) " +
                            "INNER JOIN dersler d ON(k.dersId = d.dersId) " +
                            "WHERE d.dersId = " + dersId + " and s.soruldu=0 and s.aktif=1 ORDER BY RAND() LIMIT 1;";
            }
            else if(dersId == 1) 
            {
                if(sayac >= 0 && sayac < 30)
                    sorgu = "SELECT s.soruId, d.dersId, d.dersAdi, k.kategoriAdi, s.soruAdi, s.secenekA, s.secenekB, " +
                                "s.secenekC, s.secenekD, s.dogruSecenek, s.aktif, s.soruldu FROM sorular s " +
                                "INNER JOIN kategoriler k ON(s.kategoriId = k.kategoriId) " +
                                "INNER JOIN dersler d ON(k.dersId = d.dersId) " +
                                "WHERE s.soruldu=0 and d.dersId=2 and s.aktif=1 ORDER BY RAND() LIMIT 1;";

                if (sayac >= 30 && sayac < 48)
                    sorgu = "SELECT s.soruId, d.dersId, d.dersAdi, k.kategoriAdi, s.soruAdi, s.secenekA, s.secenekB, " +
                                "s.secenekC, s.secenekD, s.dogruSecenek, s.aktif, s.soruldu FROM sorular s " +
                                "INNER JOIN kategoriler k ON(s.kategoriId = k.kategoriId) " +
                                "INNER JOIN dersler d ON(k.dersId = d.dersId) " +
                                "WHERE s.soruldu=0 and d.dersId=3 and s.aktif=1 ORDER BY RAND() LIMIT 1;";

                if (sayac >= 48 && sayac < 60)
                    sorgu = "SELECT s.soruId, d.dersId, d.dersAdi, k.kategoriAdi, s.soruAdi, s.secenekA, s.secenekB, " +
                                "s.secenekC, s.secenekD, s.dogruSecenek, s.aktif, s.soruldu FROM sorular s " +
                                "INNER JOIN kategoriler k ON(s.kategoriId = k.kategoriId) " +
                                "INNER JOIN dersler d ON(k.dersId = d.dersId) " +
                                " WHERE s.soruldu=0 and d.dersId=4 and s.aktif=1 ORDER BY RAND() LIMIT 1;";
            }
            sayac++;

            if (veritabani.con.State == ConnectionState.Closed)
                veritabani.con.Open();
            veritabani.kmt.CommandText = sorgu;
            veritabani.reader = veritabani.kmt.ExecuteReader();
            if (veritabani.reader.Read())
            {
                soruId = veritabani.reader.GetInt32("soruId");
                txtSoru.Text = veritabani.reader.GetString("soruAdi");
                txtA.Text = veritabani.reader.GetString("secenekA");
                txtB.Text = veritabani.reader.GetString("secenekB");
                txtC.Text = veritabani.reader.GetString("secenekC");
                txtD.Text = veritabani.reader.GetString("secenekD");
                dogruSecenek = veritabani.reader.GetChar("dogruSecenek");
            }
            veritabani.reader.Close();

            sorgu = "update sorular set soruldu = 1 where soruId=" + soruId;
            if (veritabani.con.State == ConnectionState.Closed)
                veritabani.con.Open();
            veritabani.kmt.CommandText = sorgu;
            veritabani.kmt.ExecuteNonQuery();
            
            if (dersId == 0 && sayac == 60)
            {
                MessageBox.Show("Genel Kültür Sınavı sona ermiştir.\r\nSüreniz:" + label3.Text);
                timer1.Enabled = false;
                button2.Enabled = false;
                cmbsinav.Enabled = true;
                button1.Enabled = true;
            }
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            _Saniye++;
            if (_Saniye == 60)
            {
                _Saniye = 0;
                _Dakika++;
            }


            if (_Dakika == 60)
            {
                _Dakika = 0;
                _Saat++;
            }
            if (_Saat == 24)
            {
                _Saat = 0;
                _Dakika = 0;
                _Saniye = 0;
            }
            label3.Text = string.Format("{0:00} : {1:00} : {2:00}", _Saat, _Dakika, _Saniye);
        }
    }
}
