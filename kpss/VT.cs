using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace kpss
{
    public class VT
    {
        public MySqlConnection con;
        public MySqlCommand kmt;
        public MySqlDataAdapter adp;
        public MySqlDataReader reader;

        public VT()
        {
            try
            {
                string bag = "server=localhost; database=kpss; user id=root; password=; persistsecurityinfo=True; SslMode=none";
                con = new MySqlConnection(bag);
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