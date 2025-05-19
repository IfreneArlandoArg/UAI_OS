using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE
{
    public class BEComponente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }


        public BEComponente(string pID, string pNombre) 
        { 
            Id = int.Parse(pID);
            Nombre = pNombre;
        
        }

        public BEComponente(string pNombre) 
        { 
          Nombre= pNombre;
        }

        public BEComponente() 
        { }

    }
}