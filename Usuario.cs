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


namespace Un_caso_práctico
{
    public partial class user : Form
    {
        public user()
        {
            InitializeComponent();
        }
        baseDeDatos bd = new baseDeDatos();
        DataSet ds = new DataSet();
        DataView dv;
        int pos;
        string id;
        private void user_Load(object sender, EventArgs e)
        {
            string querty = "SELECT * FROM Usuario";
            SqlDataAdapter adapter = new SqlDataAdapter(querty, bd.conectar);
            //DataTable dt = new DataTable();
            adapter.Fill(ds, "Usuario");
            dv = ((DataTable)ds.Tables["Usuario"]).DefaultView;
            tblUsuarios.DataSource = dv;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string querty = "INSERT INTO Usuario (Usuario,Clave,Nombre,Apellido,Correo,Estatus,Fecha_Creado) VALUES(@Usuario,@Clave,@Nombre,@Apellido,@Correo,@Estatus,@Fecha)";
            bd.abrir();
            SqlCommand com = new SqlCommand(querty, bd.conectar);
            com.Parameters.AddWithValue("@Usuario", txtUsuario.Text);
            com.Parameters.AddWithValue("@Clave", txtClave.Text);
            com.Parameters.AddWithValue("@Nombre", txtNombre.Text);
            com.Parameters.AddWithValue("@Apellido", txtApellido.Text);
            com.Parameters.AddWithValue("@Correo", txtCorreo.Text);
            com.Parameters.AddWithValue("@Estatus", Estatus.Checked);
            com.Parameters.AddWithValue("@Fecha", Fecha.Value);
            com.ExecuteNonQuery();
            MessageBox.Show("Insertado correctamente");
        }

        private void Consultar_Click(object sender, EventArgs e)
        {
            string busqueda = "";
            string[] buscarPalabra = txtBuscar.Text.Split(' ');

            foreach (string item in buscarPalabra)
            {
                if(busqueda.Length == 0)
                {
                    busqueda = "(Usuario LIKE '%" + item + "%')";
                }
                else
                {
                    busqueda += "AND (Usuario LIKE '%" + item + "%')";
                }
            }

            dv.RowFilter = busqueda;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = "UPDATE Usuario SET Usuario = @usuario, Clave = @clave, Nombre = @nombre, Apellido = @apellido, Correo = @correo, Estatus = @estatus WHERE ID = @codigo";
            bd.abrir();
            SqlCommand com = new SqlCommand(query, bd.conectar);
            com.Parameters.AddWithValue("@codigo", Int32.Parse(id));

            if (Estatus.Checked)
            {
                com.Parameters.AddWithValue("@estatus", "Activo");
            }
            else
            {
                com.Parameters.AddWithValue("@estatus", "Inactivo");
            }
            com.Parameters.AddWithValue("@usuario", txtUsuario.Text);
            com.Parameters.AddWithValue("@clave", txtClave.Text);
            com.Parameters.AddWithValue("@nombre", txtNombre.Text);
            com.Parameters.AddWithValue("@apellido", txtApellido.Text);
            com.Parameters.AddWithValue("@correo", txtCorreo.Text);
            com.ExecuteNonQuery();
            bd.cerrar();
            MessageBox.Show("Actualizado correctamente");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            pos = tblUsuarios.CurrentRow.Index;

            txtID.Text = tblUsuarios[0, pos].Value.ToString();
            txtUsuario.Text = tblUsuarios[1, pos].Value.ToString();
            txtClave.Text = tblUsuarios[2, pos].Value.ToString();
            txtNombre.Text = tblUsuarios[3, pos].Value.ToString();
            txtApellido.Text = tblUsuarios[4, pos].Value.ToString();
            txtCorreo.Text = tblUsuarios[5, pos].Value.ToString();

            id = tblUsuarios[0, pos].Value.ToString();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string borrar = "DELETE FROM Usuario WHERE ID = @id";
            bd.abrir();
            SqlCommand cmd = new SqlCommand(borrar, bd.conectar);
            cmd.Parameters.AddWithValue("@id", Int32.Parse(txtID.Text));
            cmd.ExecuteNonQuery();
            bd.cerrar();
            MessageBox.Show("Eliminado con Exito");
        }
    }
}
