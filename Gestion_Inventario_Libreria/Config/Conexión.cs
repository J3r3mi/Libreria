using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Gestion_Inventario_Libreria.Config
{
    internal class Conexión
    {
        private readonly string cadenaConexion =
            "Server=(local); database=Gestion_inventario_libreria; Integrated Security=True;";

        public SqlConnection obtenerConexion()
        {
            return new SqlConnection(cadenaConexion);
        }
    }
}
