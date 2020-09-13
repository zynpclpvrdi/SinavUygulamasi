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
    public partial class sinavsonucu : Form
    {
        private VT veritabani;
        public Form1 frm;
        public int dersId;
        public int kullaniciId;
        public static string kullaniciadi;
        public string dersAdi;

        public sinavsonucu(VT veritabani, int kullaniciId,int dersId,Form1 frm)
        {
            InitializeComponent();
            this.veritabani = veritabani;
            this.frm = frm;
            this.kullaniciId = kullaniciId;
            this.dersId = dersId;
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (veritabani.con.State == ConnectionState.Closed)
                    veritabani.con.Open();
                string tablo = "SELECT sinavSonucuId,dersAdi, dogruSayisi,yanlisSayisi,bosSayisi,sinavTarihi " +
                                "FROM sinavsonucu s INNER JOIN dersler d ON (s.dersId = d.dersId) where kullaniciId=" + kullaniciId;
                veritabani.kmt.CommandText = tablo;
                veritabani.adp = new MySqlDataAdapter(veritabani.kmt);
                DataTable dg = new DataTable();
                veritabani.adp.Fill(dg);
                dataGridView1.DataSource = dg;

                dataGridView1.Columns[0].Visible = false;

                dataGridView1.Columns[1].HeaderText = "DERS ADI";
                dataGridView1.Columns[2].HeaderText = "DOĞRU SAYISI";
                dataGridView1.Columns[3].HeaderText = "YANLIŞ SAYISI";
                dataGridView1.Columns[4].HeaderText = "BOŞ SAYISI";
                dataGridView1.Columns[5].HeaderText = "SINAV TARİHİ";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void sinavsonucu_Load(object sender, EventArgs e)
        {
            if (dersId > 0)
            {
                string sorgu = "select d.dersAdi,s.dogruSayisi,s.yanlisSayisi,s.bosSayisi from sinavsonucu s " +
                    "inner join dersler d on(s.dersId=d.dersId)" +
                    "where d.dersId=" + dersId;
                veritabani.kmt.CommandText = sorgu;
                veritabani.kmt.ExecuteNonQuery();
                veritabani.reader = veritabani.kmt.ExecuteReader();
                if (veritabani.reader.Read())
                {
                    lblders.Text = veritabani.reader.GetString(0);
                    lbldogru.Text = veritabani.reader.GetString(1);
                    lblyanlis.Text = veritabani.reader.GetString(2);
                    lblbos.Text = veritabani.reader.GetString(3);
                }
                veritabani.reader.Close();
            }
            else
            {
                panel1.Visible = false;
                dataGridView1.Width = Width;
                dataGridView1.Location = new Point(0, 0);
                button2.PerformClick();
            }
        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int sinavSonucuId = Convert.ToInt32(dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[0].Value.ToString());
            new cevaplar(veritabani, sinavSonucuId).ShowDialog();
        }
    }
}
