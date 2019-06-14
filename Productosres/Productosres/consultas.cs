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
    public partial class consultas : Form
    {
        public consultas()
        {
            InitializeComponent();
        }

        private void consultas_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = conexion.Consultas("select * from platillos");

        }
    }
}
