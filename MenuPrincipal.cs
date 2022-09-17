using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Un_caso_práctico
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }
        Login log = new Login();
        user us = new user();
        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            baseDeDatos conexion = new baseDeDatos();
            conexion.abrir();
        }

        private void login_Click(object sender, EventArgs e)
        {
            log.MdiParent = this;
            log.Show();

        }

        private void usuario_Click(object sender, EventArgs e)
        {
            if(log.inicioSesion == true)
            {
                us.MdiParent = this;
                us.Show();
            }
            else
            {
                MessageBox.Show("Debe iniciar sesion primero");
            }

        }

        private void salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
