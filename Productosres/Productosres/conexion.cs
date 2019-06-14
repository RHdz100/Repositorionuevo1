using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace Productosres
{
    class conexion
    {
        public static MySqlConnection con = new MySqlConnection("server=localhost;database=restaurante; Uid=root;pwd=santoslaguna;");


        public static void Registrar(string R)
        {
            MySqlCommand cmd = new MySqlCommand(R, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

            }
            finally
            {
                con.Close();
            }
        }


        public static DataTable Consultas(string C)
        {
            MySqlDataAdapter da = new MySqlDataAdapter(C, con);
            DataTable ct = new DataTable();
            try
            {
                con.Open();
                da.Fill(ct);
                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

            }
            finally
            {
                con.Close();
            }
            return ct;
        }
    }
}
