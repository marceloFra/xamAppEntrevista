using BE;
using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA
{
    public class LoginDA
    {
        public Postulante logeoPostulante(string correo, string codDePostulanteGenerado)
        {
            return LoginBO.logeoPostulante(correo, codDePostulanteGenerado);
        }

        public string logeoUsuario(string nomUsuario, string contrasena)
        {
            return LoginBO.logeoUsuario(nomUsuario, contrasena);
        }
    }
}
