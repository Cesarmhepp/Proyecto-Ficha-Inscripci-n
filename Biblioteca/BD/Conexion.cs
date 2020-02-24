using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Conexion
    {
        public SqlConnection con;
        public SqlCommand sen;
        public SqlDataReader rs;

        public Conexion() {
            con = new SqlConnection("Data Source=localhost;" + "Initial Catalog=DB_M1;" + "Integrated Security=True");
        }
    }
}
