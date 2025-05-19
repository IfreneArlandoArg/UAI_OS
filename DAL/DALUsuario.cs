using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using BE;

namespace DAL
{
    public class DALUsuario
    {
        string connectionString = "Integrated Security = SSPI; Initial Catalog = UAIOS_DB; Data Source = .;";

        public List<BEUsuario> Listar()
        {
            List<BEUsuario> tmp = new List<BEUsuario>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("LISTAR_USUARIOS", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {

                    tmp.Add(new BEUsuario(reader["IDUSUARIO"].ToString(), reader["NOMBRE"].ToString(), reader["PASSWORD"].ToString()));

                }


            }


            return tmp;
        }
    }
}
