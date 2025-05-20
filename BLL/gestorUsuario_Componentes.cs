using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using BE;
using DAL;

namespace BLL
{
    public class gestorUsuario_Componentes
    {

        

        DALDirectorio dALDirectorio = new DALDirectorio();
        DALArchivo dalArchivo = new DALArchivo();


        public string Alta(BEArchivo pBEArchivo)
        {


            foreach(BEArchivo tmpArchivo in dalArchivo.ListarArchivosDirectorio(LoginSession.Instancia.UsuarioActual.DirectorioActual, LoginSession.Instancia.UsuarioActual)) 
            {
                if (tmpArchivo.Nombre == pBEArchivo.Nombre) 
                {
                    return $"El archivo {pBEArchivo.Nombre}, ya existe...\n";
                }
              
            }

            dalArchivo.Alta(pBEArchivo, LoginSession.Instancia.UsuarioActual);

            return $"Archivo : {pBEArchivo.Nombre} creado...\n";
        }


        public string Alta(BEDirectorio pBEDirectorio)
        {
            

            foreach (BEDirectorio pBeDir in dALDirectorio.ListarDirectoriosUsuario(LoginSession.Instancia.UsuarioActual, LoginSession.Instancia.UsuarioActual.DirectorioActual.Id))
            {
                if(pBeDir.Nombre == pBEDirectorio.Nombre) 
                {
                    return $"El directorio, {pBEDirectorio.Nombre} ya existe...\n";
                }
            }

            Componente tmp = new Directorio(pBEDirectorio.Nombre);

            dALDirectorio.Alta(pBEDirectorio);

            return $"Directorio : {pBEDirectorio.Nombre} creado...\n";
        }
        
        public string ListarDirectoriosUsuario(BEUsuario pBEUsuario)
        {
            string returnValue = string.Empty;


            Componente directorioActualTmp = new Directorio(LoginSession.Instancia.UsuarioActual.DirectorioActual.Nombre);

            foreach (BEArchivo bEArchivo in dalArchivo.ListarArchivosDirectorio(LoginSession.Instancia.UsuarioActual.DirectorioActual, LoginSession.Instancia.UsuarioActual))
            {
                Componente archivoTmp = new Archivo(bEArchivo.Nombre, bEArchivo.Tamaño);


                directorioActualTmp.AgregarHijo(archivoTmp);


            }




            foreach (BEDirectorio pBeDir in dALDirectorio.ListarDirectoriosUsuario(pBEUsuario, LoginSession.Instancia.UsuarioActual.DirectorioActual.Id)) 
            { 
               Componente tmp = new Directorio(pBeDir.Nombre);
               
               foreach(BEArchivo bEArchivo in dalArchivo.ListarArchivosDirectorio(pBeDir, LoginSession.Instancia.UsuarioActual)) 
               { 
                  Componente archivoTmp = new Archivo(bEArchivo.Nombre, bEArchivo.Tamaño);
                  
                    tmp.AgregarHijo(archivoTmp);
               }

                
                returnValue += $"{tmp.Nombre}, {tmp.ObtenerTamaño}KB\n";
            }




            foreach (Componente pComDir in directorioActualTmp.ObtenerHijos()) 
            {
                returnValue += $"Archivo : {pComDir.Nombre}, {pComDir.ObtenerTamaño}KB\n";
            }





            if (returnValue == string.Empty)
                returnValue = "No hay directorios disponibles";

            return returnValue;
        
        }

        public string CambiarDirectorio(string pNombreDirectorio)
        {
            string returnValue = string.Empty;
            

            foreach (BEDirectorio pBeDir in dALDirectorio.ListarDirectoriosUsuario(LoginSession.Instancia.UsuarioActual, LoginSession.Instancia.UsuarioActual.DirectorioActual.Id))
            {
                if(pBeDir.Nombre == pNombreDirectorio) 
                {
                    string tmp = LoginSession.Instancia.UsuarioActual.DirectorioActual.directorioConsola;

                    LoginSession.Instancia.UsuarioActual.DirectorioActual = pBeDir;

                    LoginSession.Instancia.UsuarioActual.DirectorioActual.directorioConsola = $"{tmp}{LoginSession.Instancia.UsuarioActual.DirectorioActual.Nombre}/";



                    


                    return "¡Directorio cambiado!";
                }
            }

          

            return $"¡¡¡{pNombreDirectorio}, no existe en el directorio actual comó \"DIRECTORIO\"!!!";
        }
    }
}