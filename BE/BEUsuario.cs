using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEUsuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Password { get; set; }

        public BEDirectorio DirectorioActual { get; set; }



        public BEUsuario(string pID, string pNombre, string pPassword) 
        {

            DirectorioActual = new BEDirectorio();
        
            Id = int.Parse(pID);
            Nombre = pNombre;
            Password = pPassword;
        }

    }
}
