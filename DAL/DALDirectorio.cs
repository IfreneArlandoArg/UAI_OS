using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace DAL
{
    public class DALDirectorio
    {
        string connectionString = "Integrated Security = SSPI; Initial Catalog = UAIOS_DB; Data Source = .;";

        public void Alta(BEDirectorio pBEDirectorio)
        {
           using (SqlConnection conn = new SqlConnection(connectionString)) 
           {
                SqlCommand cmd = new SqlCommand("ALTA_DIRECTORIO", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@IDPADRE", pBEDirectorio.IdPadre));
                cmd.Parameters.Add(new SqlParameter("@IDUSUARIO", pBEDirectorio.IdUsuario));
                cmd.Parameters.Add(new SqlParameter("@NOMBRE", pBEDirectorio.Nombre));

                conn.Open();

                cmd.ExecuteNonQuery();
            
           }
        }

       

        public List<BEDirectorio> ListarDirectoriosUsuario(BEUsuario pBEUsuario, int pIdPadre)
        {
            List<BEDirectorio> tmp = new List<BEDirectorio>();


            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("LISTAR_DIRECTORIOS_USUARIO_DIRECTORIO", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@IDUSUARIO", pBEUsuario.Id));
                cmd.Parameters.Add(new SqlParameter("@IDPADRE", pIdPadre) );
                

                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read()) 
                {
                    tmp.Add( new BEDirectorio(reader["ID_DIRECTORIO"].ToString(), reader["NOMBRE"].ToString(), reader["ID_USUARIO"].ToString(), int.Parse(reader["ID_PADRE"].ToString()) ) );
                }

            }


            return tmp;
        }
    }
}