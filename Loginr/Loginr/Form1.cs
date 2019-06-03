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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblhora.Text = DateTime.Now.ToString("h:mm:ss");
            lblfecha.Text = DateTime.Now.ToLongDateString();
        }

        private void btniniciar_Click(object sender, EventArgs e)
        {

            MySqlConnection conectar = new MySqlConnection("server=localhost;database=logineje; Uid=root;pwd=; ");
            conectar.Open();

            MySqlCommand cmd = new MySqlCommand();
            MySqlConnection con = new MySqlConnection();
            cmd.Connection = conectar;
            cmd.CommandText = ("select user, pass from log where user='" + txtusuario.Text + "' and pass='" + txtcontraseña.Text + "'");
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
    }
}
