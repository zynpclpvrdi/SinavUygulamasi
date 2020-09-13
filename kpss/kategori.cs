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
    public partial class kategori : Form
    {
        private VT veritabani;
        public Form1 frm;
        public int kategoriId = -1;
        public int seciliSatir = -1;
        public int aktif;
        public int dersId;

        public kategori(VT veritabani, Form1 frm)
        {
            InitializeComponent();
            this.veritabani = veritabani;
            this.frm = frm;
            Baglan();
        }

        public void Baglan()
        {
            try
            {
                if (veritabani.con.State == ConnectionState.Closed)
                    veritabani.con.Open();
                string tablo = "select kategoriId,kategoriAdi,dersId,aktif from kategoriler";
                veritabani.kmt.CommandText = tablo;
                veritabani.adp = new MySqlDataAdapter(veritabani.kmt);
                DataTable dg = new DataTable();
                veritabani.adp.Fill(dg);
                dataGridView1.DataSource = dg;

                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[2].Visible = false;

                dataGridView1.Columns[0].HeaderText = "KATEGORİ ID";
                dataGridView1.Columns[1].HeaderText = " KATEGORİ ADI";
                dataGridView1.Columns[2].HeaderText = "DERS ID";
                dataGridView1.Columns[3].HeaderText = "AKTİFLİK";

                string dersSorgu = "Select dersId, dersAdi from dersler where aktif=1";
                veritabani.kmt.CommandText = dersSorgu;
                veritabani.adp = new MySqlDataAdapter(veritabani.kmt);
                DataTable dt = new DataTable();
                veritabani.adp.Fill(dt);
                cmbDersAdi.DataSource = dt;
                cmbDersAdi.DisplayMember = "dersAdi";
                cmbDersAdi.ValueMember = "dersId";
                veritabani.reader.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (kategoriId > 0)
                {

                    string sorgu = "UPDATE kategoriler SET kategoriAdi='" + txtkAdi.Text + "' where kategoriId=" + kategoriId;
                    veritabani.kmt.CommandText = sorgu;

                    DialogResult secenek = MessageBox.Show("Değişiklikleri kaydetmek istiyor musunuz?", "Bilgilendirme Penceresi", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);

                    if (secenek == DialogResult.Yes)
                    {
                        veritabani.kmt.ExecuteNonQuery();
                        Baglan();

                        dataGridView1.Rows[seciliSatir].Selected = true;
                        MessageBox.Show("Kategori güncellendi.");

                    }

                    else if (secenek == DialogResult.No)
                    {
                        MessageBox.Show("Kategori ekleme başarısız.");
                    }
                }
                else
                {
                    string sorgu = "select kategoriAdi from kategoriler where kategoriAdi='" + txtkAdi.Text + "'";
                    veritabani.kmt.CommandText = sorgu;
                    veritabani.reader = veritabani.kmt.ExecuteReader();

                    if (veritabani.reader.Read())
                    {
                        MessageBox.Show("Kategori mevcut.");
                        veritabani.reader.Close();
                        return;
                    }

                    else
                    {
                        DialogResult secenek = MessageBox.Show("Kaydetmek istiyor musunuz ?", "Bilgilendirme Kutusu", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);

                        veritabani.reader.Close();
                        if (secenek == DialogResult.Yes)
                        {
                            dersId = Convert.ToInt32(cmbDersAdi.SelectedValue);
                            string kayit = "insert into kategoriler(kategoriAdi,dersId) values('" + txtkAdi.Text + "','" + dersId + "'); " +
                            " SELECT LAST_INSERT_ID();";
                            veritabani.kmt.CommandText = kayit;
                            kategoriId = Convert.ToInt32(veritabani.kmt.ExecuteScalar());
                            seciliSatir = dataGridView1.Rows.Count;
                            Baglan();
                            dataGridView1.Rows[seciliSatir].Selected = true;
                            MessageBox.Show("Kategori eklendi.");
                            button1.Text = "EKLE";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView1_RowHeaderMouseDoubleClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            seciliSatir = dataGridView1.SelectedRows[0].Index;
            kategoriId = Convert.ToInt32(dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[0].Value.ToString());
            txtkAdi.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();

            seciliSatir = dataGridView1.SelectedRows[0].Index;
            dersId = Convert.ToInt32(dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[0].Value.ToString());
            dataGridView1.Rows[seciliSatir].Selected = true;
            cmbDersAdi.SelectedValue = dataGridView1.SelectedRows[0].Cells[2].Value;
            button1.Text = "GÜNCELLE";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Onay = new DialogResult();

                Onay = MessageBox.Show("Emin misiniz?", " ", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);

                if (Onay == DialogResult.Yes)
                {
                    seciliSatir = dataGridView1.SelectedRows[0].Index;
                    kategoriId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                    string sorgu = "UPDATE kategoriler kategoriAdi SET aktif=0 where kategoriId=" + kategoriId;
                    veritabani.kmt.CommandText = sorgu;
                    veritabani.kmt.ExecuteNonQuery();
                    Baglan();
                    dataGridView1.Rows[seciliSatir].Selected = true;
                    MessageBox.Show("Ders pasife çekildi.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
