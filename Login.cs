using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Un_caso_práctico
{

    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        baseDeDatos bd = new baseDeDatos();
        public bool inicioSesion = false;
        private void Login_Load(object sender, EventArgs e)
        {
            
        }

        private void enter_Click(object sender, EventArgs e)
        {
            try
            {
                bd.abrir();

                string querty = "SELECT * FROM Usuario WHERE Usuario='" + txtUsuario.Text + "' AND Clave='" + txtPass.Text + "'";
                SqlCommand cmd = new SqlCommand(querty, bd.conectar);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    MessageBox.Show("Acceso concedido");
                    inicioSesion = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Usuario no encontrado");
                    inicioSesion = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
