using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_TA_BibliotecaPublica
{
    public partial class Usuarios : Form
    {
        Conexion Biblioconex = new Conexion();
        public Usuarios()
        {
            InitializeComponent();
        }
        public void Cancelar()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
        }

        public void Guardar()
        {
            if (textBox1.Text.Trim() == String.Empty && textBox2.Text.Trim() == String.Empty && textBox3.Text.Trim() == String.Empty && textBox4.Text.Trim() == String.Empty && textBox5.Text.Trim() == String.Empty && textBox6.Text.Trim() == String.Empty && textBox7.Text.Trim() == String.Empty)

                if (textBox1.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("Debes ingresar un IdUsuario");
                    return;
                }

            if (textBox2.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Debes ingresar un Nombre");
                return;
            }

            if (textBox3.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Debes ingresar Ap_Paterno");
                return;
            }

            if (textBox4.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Debes ingresar Ap_Materno");
                return;
            }

            if (textBox5.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Debes ingresar Direccion");
                return;
            }

            if (textBox6.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Debes ingresar Telefono");
                return;
            }

            if (textBox7.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Debes ingresar el Contraseña");
                return;
            }

            //INSERT INTO `usuarios`(`IdUsuario`, `Nombre`, `Ap_paterno`, `Ap_Materno`, `Direccion`, `Contraseña`, `Telefono`) 
            //VALUES('[value-1]', '[value-2]', '[value-3]', '[value-4]', '[value-5]', '[value-6]', '[value-7]')

            String sql = String.Format("INSERT INTO usuarios (IdUsuario, Nombre, Ap_Paterno, Ap_Materno, Direccion, Contraseña, Telefono)  " +
                                                     " values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')",
                          textBox1.Text.Trim(), textBox2.Text.Trim(), textBox3.Text.Trim(), textBox4.Text.Trim(), textBox5.Text.Trim(),
                          textBox7.Text.Trim(), textBox6.Text.Trim());

            try
            {

                if (Biblioconex.Query(sql) == 1)
                {
                    MessageBox.Show("!!!... Registro de usuario éxitoso ...!!!");
                }
                else
                {
                    MessageBox.Show("!!!... ERROR, NO se pudo registar ...!!!");
                }

                Cancelar();

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cancelar();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Login frmLogin = new Login();
            frmLogin.Show();
            this.Hide();
        }
    }
}
