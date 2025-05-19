using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE
{
    public class BEDirectorio : BEComponente
    {

        public int IdPadre { get; set; }
        public int IdUsuario { get; set; }

        public string directorioConsola { get; set; }

        public BEDirectorio(string pID, string pNombre, string pIdUsuario, int pIdPagre ) : base(pID, pNombre)
        {

            IdPadre = pIdPagre;
            IdUsuario = int.Parse(pIdUsuario);

        }


        public BEDirectorio(string pNombre, string pIdUsuario, int pIdPagre ) : base( pNombre)
        {

            IdPadre = pIdPagre;
            IdUsuario = int.Parse(pIdUsuario);

        }

        public BEDirectorio() 
        { }




    }
}