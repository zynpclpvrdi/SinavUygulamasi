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
    public partial class cevaplar : Form
    {
        public VT veritabani;
        public int sinavSonucuId;
        public ArrayList soruId;
        
        public cevaplar(VT veritabani, int sinavSonucuId)
        {
            InitializeComponent();
            this.veritabani = veritabani;
            this.sinavSonucuId = sinavSonucuId;
        }

        private void cevaplar_Load(object sender, EventArgs e)
        {
            soruId = new ArrayList();
            string sorgu = "select soruId,isaretliSecenek,dogruSecenek from cevaplar where sinavSonucuId=" + sinavSonucuId;
            veritabani.kmt.CommandText = sorgu;
            veritabani.adp = new MySqlDataAdapter(veritabani.kmt);
            veritabani.reader = veritabani.kmt.ExecuteReader();
            while (veritabani.reader.Read())
            {
                soruId.Add(veritabani.reader.GetInt32("soruId"));
                listBox1.Items.Add(veritabani.reader["isaretliSecenek"]
                .ToString() + "  -  " + veritabani.reader["dogruSecenek"].ToString());
            }
            veritabani.reader.Close();

        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            int seciliSecenek = listBox1.SelectedIndex;
            int soru = Convert.ToInt32(soruId[seciliSecenek]);
            string sorgu = "select * from sorular where soruId = " + soru;
            if (veritabani.con.State == ConnectionState.Closed)
                veritabani.con.Open();
            veritabani.kmt.CommandText = sorgu;
            veritabani.reader = veritabani.kmt.ExecuteReader();
            if (veritabani.reader.Read())
            {
                txtSoru.Text = veritabani.reader.GetString("soruAdi");
                txtA.Text = veritabani.reader.GetString("secenekA");
                txtB.Text = veritabani.reader.GetString("secenekB");
                txtC.Text = veritabani.reader.GetString("secenekC");
                txtD.Text = veritabani.reader.GetString("secenekD");
            }
            veritabani.reader.Close();
        }
    }
}
