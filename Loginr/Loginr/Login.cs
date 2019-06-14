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





namespace Loginr
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblhora.Text = DateTime.Now.ToString("h:mm:ss");
            lblfecha.Text = DateTime.Now.ToLongDateString();
        }


        public bool Conexion()
        {
            string constring = null;
            MySqlConnection conexion;
            constring = "server=localhost;database=cuentas; Uid=root;pwd=santoslaguna;";
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

        public bool Acceso(string usuario,string contraseña)
        {
            try
            {
                string constring = "server=localhost;database=cuentas; Uid=root;pwd=santoslaguna;";
                string query = "select usuario,contraseña from perfiles where usuario ='" + usuario + "' and contraseña ='" + contraseña + "'";
                //string query = "select * from perfiles where usuario ='" + usuario + "' and contraseña '" + contraseña + "'";

                MySqlConnection conexion = new MySqlConnection(constring);
                MySqlCommand command = new MySqlCommand(query, conexion);
                MySqlDataReader dr;
                conexion.Open();
                dr = command.ExecuteReader();
                bool exists = false;

                while (dr.Read()) 
                {
                    exists = true;
                }
                conexion.Close();
                return exists;
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
                return false;
            }
           
        }
        private void btniniciar_Click(object sender, EventArgs e)
        {

            MySqlConnection conectar = new MySqlConnection("server=localhost;database=cuentas; Uid=root;pwd=santoslaguna; ");
            conectar.Open();

            MySqlCommand cmd = new MySqlCommand();
            MySqlConnection con = new MySqlConnection();
            cmd.Connection = conectar;
            cmd.CommandText = ("select usuario, contraseña from perfiles where usuario='" + txtusuario.Text + "' and contraseña='" + txtcontraseña.Text + "'");
            MySqlDataReader lec = cmd.ExecuteReader();
            if (lec.Read())
            {
                MessageBox.Show("ACCESO ACEPTADO..");
                prueba pr = new prueba();
                this.Hide();
                pr.Show();
            }
            else
            {
                MessageBox.Show("ACCESO DENEGADO");
            }
            conectar.Close();
        }
    

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
