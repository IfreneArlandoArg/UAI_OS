using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class LoginSession
    {

        public BEUsuario UsuarioActual { get; private set; }
      


        private static LoginSession instancia;
        public static LoginSession Instancia
        {
            get
            {
                if (instancia == null)
                    instancia = new LoginSession();

                return instancia;
            }

        }

        private LoginSession()
        { }

        public void Login(BEUsuario usuario)
        {
            UsuarioActual = usuario;
            
        }

        public void Logout()
        {
            UsuarioActual = null;
            instancia = null;
        }

       

    }
}