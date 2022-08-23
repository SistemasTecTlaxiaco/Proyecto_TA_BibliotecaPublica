using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Proyecto_TA_BibliotecaPublica
{
    public partial class Login : Form
    {
        Conexion Biblioconex = new Conexion();
        public Login()
        {
            InitializeComponent();
            try
            {
                Biblioconex.Connect();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        public void Acceder()
        {
            //SELECT `IdUsuario`, `Contraseña`, FROM `usuarios` WHERE
            String sql = String.Format(@"select IdUsuario,Contraseña from usuarios where IdUsuario = '" + textBox1.Text + "' and Contraseña='" + textBox2.Text + "'");
            DataRow fila = Biblioconex.getRow(sql);
            if (fila != null)
            {
                MessageBox.Show("!!!... Bienvenido a Biblioteca " + textBox1.Text + " ...!!!");
                frmbiblioteca abrir = new frmbiblioteca();
                abrir.Show();
                this.Hide();
            }

            else
            {
                MessageBox.Show("!!!... Error, usuario invalidos, verifique ...!!!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Acceder();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Usuarios frmUsuarios = new Usuarios();
            frmUsuarios.Show();
            this.Hide();
        }
    }
}
