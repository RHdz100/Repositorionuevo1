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

namespace Productosres
{
    public partial class Venta : Form
    {
        MySqlConnection conn = new MySqlConnection("server=localhost;database=restaurante; Uid=root;pwd=santoslaguna;");
        MySqlDataReader dr = null;
        MySqlCommand cmd = null;
        public Venta()
        {
            InitializeComponent();
        }

        private void Venta_Load(object sender, EventArgs e)
        {
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            if (txtplatillo.Text  != "")
            {
                cmd = new MySqlCommand("select Nombre,Precio from platillos where id = '" + txtplatillo.Text + "'", conn);
                conn.Open();

                try
                {
                    dr = cmd.ExecuteReader();
                    if (dr.Read() == true)
                    {

                        lblNombre.Text = dr["Nombre"].ToString();
                        lblPrecio.Text = "$" + dr["Precio"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Id incorrecto");
                    }

                }
                catch (Exception)
                {

                    
                }
                finally
                {
                    conn.Close();
                }
            }

           
    }
    }
}
