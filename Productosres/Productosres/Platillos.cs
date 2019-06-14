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
    public partial class Platillos : Form
    {
        MySqlConnection conn = new MySqlConnection("server=localhost;database=restaurante; Uid=root;pwd=santoslaguna;");
        MySqlDataReader dr = null;
        MySqlCommand cmd = null;
        int idplatillo;
        public Platillos()
        {
            InitializeComponent();
        }

        public bool platillosconect()
        {
            string constring = null;
            MySqlConnection conexion;
            constring = "server=localhost;database=restaurante; Uid=root;pwd=santoslaguna;";
            conexion = new MySqlConnection(constring);
            try
            {
                conexion.Open();
                conexion.Close();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }


        public bool Insertar( string nombre, double precio)
        {
            try
            {
                string constring = "server=localhost;database=restaurante; Uid=root;pwd=santoslaguna;";
                string query = "insert into platillos( Nombre, Precio) values ( '" + nombre + "','" + precio + "')";
                
                //string query = "select * from perfiles where usuario ='" + usuario + "' and contraseña '" + contraseña + "'";

                MySqlConnection conexion = new MySqlConnection(constring);
                MySqlCommand command = new MySqlCommand(query, conexion);
                MySqlDataReader dr;
                conexion.Open();
                dr = command.ExecuteReader();
                
                conexion.Close();
                return true;
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
                return false;
            }

        }

        public bool Eliminar(int idplatillos)
        {
            try
            {
                string constring = "server=localhost;database=restaurante; Uid=root;pwd=santoslaguna;";
                string query = "delete from platillos where id = '" + idplatillos +"'";

                //string query = "select * from perfiles where usuario ='" + usuario + "' and contraseña '" + contraseña + "'";
                //"select id,Nombre,Precio from platillos where id = '" + txtbuscarid.Text + "'", conn
                MySqlConnection conexion = new MySqlConnection(constring);
                MySqlCommand command = new MySqlCommand(query, conexion);
                MySqlDataReader dr;
                conexion.Open();
                dr = command.ExecuteReader();

                conexion.Close();
                return true;
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
                return false;
            }
        }

        public bool Buscar(string Nombre)
        {
            try
            {
                string constring = "server=localhost;database=restaurante; Uid=root;pwd=santoslaguna;";
                string query = "select id,Nombre,Precio from platillos where id = '" + Nombre + "'";
;

                //string query = "select * from perfiles where usuario ='" + usuario + "' and contraseña '" + contraseña + "'";
                MySqlConnection conexion = new MySqlConnection(constring);
                MySqlCommand command = new MySqlCommand(query, conexion);
                MySqlDataReader dr;
                conexion.Open();
                dr = command.ExecuteReader();

                conexion.Close();
                return true;
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
                return false;
            }
        }

        public bool Actualizar(string nombre,double precio,int id)
        {
            try
            {
                string constring = "server=localhost;database=restaurante; Uid=root;pwd=santoslaguna;";
                string query = "update platillos set Nombre = '" + nombre + "', Precio = '" + precio +"' where id = '" + id + "'";
                

                //string query = "select * from perfiles where usuario ='" + usuario + "' and contraseña '" + contraseña + "'";
                MySqlConnection conexion = new MySqlConnection(constring);
                MySqlCommand command = new MySqlCommand(query, conexion);
                MySqlDataReader dr;
                conexion.Open();
                dr = command.ExecuteReader();

                conexion.Close();
                return true;
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
                return false;
            }
        }


        private void btnregistar_Click(object sender, EventArgs e)
        {
            conexion.Registrar("insert into platillos(Nombre,Precio) values ( '" + txtnomb.Text + "','" + double.Parse(txtpre.Text) + "')");
            dataGridView1.DataSource = conexion.Consultas("select * from platillos");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           dataGridView1.DataSource = conexion.Consultas("select * from platillos");
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            conexion.Registrar($"delete from platillos where id = {idplatillo}");
            dataGridView1.DataSource = conexion.Consultas("select * from platillos");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idplatillo = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());

        }

        private void txtbusc_TextChanged(object sender, EventArgs e)
        {
            if (txtbusc.Text != "")
            {
               dataGridView1.DataSource = conexion.Consultas("select * from platillos where Nombre like '%" + txtbusc.Text + "%'");

            }
            else
            {
                dataGridView1.DataSource = conexion.Consultas("select * from platillos");
            }
        }

        private void btnir_Click(object sender, EventArgs e)
        {
            Venta v = new Venta();
            v.Show();
           
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            if (txtbuscarid.Text != "")
            {
                cmd = new MySqlCommand("select id,Nombre,Precio from platillos where id = '" + txtbuscarid.Text + "'", conn);
                conn.Open();

                try
                {
                    dr = cmd.ExecuteReader();
                    if (dr.Read() == true)
                    {
                        txtid.Text = dr["id"].ToString();
                        txtnomb.Text = dr["Nombre"].ToString();
                        txtpre.Text = "$" + dr["Precio"].ToString();
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

        private void btnactualizar_Click(object sender, EventArgs e)
        {

        }
    }
}
