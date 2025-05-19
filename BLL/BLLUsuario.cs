using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
    public class BLLUsuario : IUserRegistered
    {
        

        DALUsuario dalUsuario = new DALUsuario();
        Directorio raiz = new Directorio("/");

        public bool UserRegistered(string nombre, string password, out BEUsuario usuario)
        {
            bool registrado = false;
            usuario = null;

            foreach(BEUsuario usr in Listar()) 
            {
                if (usr.Nombre == nombre && usr.Password == password) 
                { 
                   registrado = true;
                   usuario = usr;
                }

            }
            

            return registrado;
        }

        public List<BEUsuario> Listar()
        {
            return dalUsuario.Listar();
        }

        public List<Componente> ObtenerDirectorios()
        {
            throw new System.NotImplementedException();
        }
    }
}
