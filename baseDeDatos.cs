using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Un_caso_práctico
{
    class baseDeDatos
    {
        string cadena = "Data Source=DESKTOP-U1TV8IU\\SQLEXPRESS;Initial Catalog=Creación de la Base de Datos;Integrated Security=true";
        public SqlConnection conectar = new SqlConnection();

        public baseDeDatos()
        {
            conectar.ConnectionString = cadena;
        }

        public void abrir()
        {
            try
            {
                conectar.Open();
                Console.WriteLine("Conexion Abierta");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error al abrir la base de datos " + ex.Message);
            }
        }

        public void cerrar()
        {
            conectar.Close();
        }
    }
}
