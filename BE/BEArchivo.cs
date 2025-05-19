using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE
{
    public class BEArchivo : BEComponente
    {
       
        public int Tamaño { get; set; }
        public int IdDirectorio { get; set; }


        public BEArchivo(string pID, string pNombre, string pTamaño, string pIdDirectorio) : base(pID, pNombre)
        {
            Tamaño = int.Parse(pTamaño);
            IdDirectorio = int.Parse(pIdDirectorio);
        }

        public BEArchivo( string pNombre, string pTamaño, string pIdDirectorio) : base( pNombre)
        {
            Tamaño = int.Parse(pTamaño);
            IdDirectorio = int.Parse(pIdDirectorio);
        }

    }
}