using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace kpss
{
    class VT
    {
        public MySqlConnection con;
        public MySqlCommand kmt;
        public MySqlDataAdapter adp;

        public VT()
        {
            try
            {
                string bag = "server=localhost; database=kpss; user id=root; password=; persistsecurityinfo=True; SslMode=none";
                MySqlConnection con = new MySqlConnection(bag);
                if (con.State == ConnectionState.Closed)
                    con.Open();
                kmt = new MySqlCommand();
                kmt.Connection = con;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
    
}