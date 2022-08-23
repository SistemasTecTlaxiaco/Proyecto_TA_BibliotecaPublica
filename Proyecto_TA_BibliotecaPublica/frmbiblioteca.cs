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
    public partial class frmbiblioteca : Form
    {
        public frmbiblioteca()
        {
            InitializeComponent();
            //Aquí indico que mi formulario va ser padre de otras ventanas MDI
            IsMdiContainer = true;
        }

        public void ViewUsuarios()
        {
            Usuarios fmrUsuarios = new Usuarios();
            fmrUsuarios.MdiParent = this;
            fmrUsuarios.Show();
        }

        public void ExitApplication()
        {

            if (MessageBox.Show("Seguro que deseas salir?", "Biblioteca",
                  MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                  == DialogResult.Yes)
            {
                MessageBox.Show("!!!... Gracias vuelva pronto ...!!!");
                Application.Exit();
            }
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewUsuarios();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExitApplication();
        }
    }
}
