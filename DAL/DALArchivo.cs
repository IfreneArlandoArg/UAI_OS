using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BE;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DALArchivo
    {
        string connectionString = "Integrated Security = SSPI; Initial Catalog = UAIOS_DB; Data Source = .;";

        public void Alta(BEArchivo pBeArchivo)
        {
            using(SqlConnection conn = new SqlConnection(connectionString)) 
            {
                SqlCommand cmd = new SqlCommand("ALTA_ARCHIVO",conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@NOMBRE",pBeArchivo.Nombre));
                cmd.Parameters.Add(new SqlParameter("@TAMANO", pBeArchivo.Tamaño));
                cmd.Parameters.Add(new SqlParameter("@ID_DIRECTORIO", pBeArchivo.IdDirectorio));

                conn.Open();

                cmd.ExecuteNonQuery();

            }
        }

        public List<BEArchivo> ListarArchivosDirectorio(BEDirectorio pBeDirectorio)
        {
            List<BEArchivo> tmp = new List<BEArchivo>();

            //Listar todos los archivos qué tienen ID_Directorio el "ID" del directorio actual mandado cómo parametro...

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("LISTAR_ARCHIVOS_DIRECTORIO", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@ID_DIRECTORIO", pBeDirectorio.Id));

                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read()) 
                {

                    tmp.Add( new BEArchivo(reader["ID_ARCHIVO"].ToString(), reader["NOMBRE"].ToString(), reader["TAMANO"].ToString(), reader["ID_DIRECTORIO"].ToString()    ) );
                   
                }


            }


            return tmp;
        }
    }
}