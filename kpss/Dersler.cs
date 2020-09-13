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
    public partial class Dersler : Form
    {
        private VT veritabani;
        public Form1 frm;
        public int dersId = -1;
        public int seciliSatir = -1;
        public int aktif;

        public Dersler(VT veritabani, Form1 frm)
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
                string tablo = "select dersId,dersAdi,aktif from dersler";
                veritabani.kmt.CommandText = tablo;
                veritabani.adp = new MySqlDataAdapter(veritabani.kmt);
                DataTable dg = new DataTable();
                veritabani.adp.Fill(dg);
                dataGridView1.DataSource = dg;
                
                dataGridView1.Columns[0].Visible = false;

                dataGridView1.Columns[0].HeaderText = "DERS ID";
                dataGridView1.Columns[1].HeaderText = " DERS ADI";
                dataGridView1.Columns[2].HeaderText = "AKTİFLİK";



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
                if (dersId > 0)
                {

                    string sorgu = "UPDATE Dersler SET dersAdi='" + txtdersadi.Text + "' where dersId=" + dersId;
                    veritabani.kmt.CommandText = sorgu;

                    DialogResult secenek = MessageBox.Show("Değişiklikleri kaydetmek istiyor musunuz?", "Bilgilendirme Penceresi", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);

                    if (secenek == DialogResult.Yes)
                    {
                        veritabani.kmt.ExecuteNonQuery();
                        Baglan();

                        dataGridView1.Rows[seciliSatir].Selected = true;
                        MessageBox.Show("Ders güncellendi.");

                    }

                    else if (secenek == DialogResult.No)
                    {
                        MessageBox.Show("Ders ekleme başarısız.");
                    }
                }
                else
                {
                    string sorgu = "select dersAdi from Dersler where dersAdi='" + txtdersadi.Text + "'";
                    veritabani.kmt.CommandText = sorgu;
                    veritabani.reader = veritabani.kmt.ExecuteReader();

                    if (veritabani.reader.Read())
                    {
                        MessageBox.Show("Ders mevcut.");
                        veritabani.reader.Close();
                        return;
                    }

                    else
                    {

                        DialogResult secenek = MessageBox.Show("Kaydetmek istiyor musunuz ?", "Bilgilendirme Kutusu", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);

                        veritabani.reader.Close();
                        if (secenek == DialogResult.Yes)
                        {
                            string kayit = "insert into Dersler(dersAdi) values('" + txtdersadi.Text + "'); " +
                            " SELECT LAST_INSERT_ID();";
                            veritabani.kmt.CommandText = kayit;
                            dersId = Convert.ToInt32(veritabani.kmt.ExecuteScalar());
                            seciliSatir = dataGridView1.Rows.Count;
                            Baglan();
                            dataGridView1.Rows[seciliSatir].Selected = true;
                            MessageBox.Show("Kayıt eklendi.");
                            button1.Text = "GÜNCELLE";

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            seciliSatir = dataGridView1.SelectedRows[0].Index;
            dersId = Convert.ToInt32(dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[0].Value.ToString());

            dataGridView1.Rows[seciliSatir].Selected = true;
            txtdersadi.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();

            button1.Text = "EKLE";
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
                    dersId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                    string sorgu = "UPDATE dersler SET aktif=0 where dersId=" + dersId;
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

