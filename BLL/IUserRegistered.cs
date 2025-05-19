using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BE;

namespace BLL
{
    public interface IUserRegistered
    {
        bool UserRegistered(string nombre, string password, out BEUsuario usuario);
    }
}