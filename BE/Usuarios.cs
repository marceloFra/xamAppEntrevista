using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Usuarios
    {
        public int IdUsuario { get; set; }

        public string Nombres { get; set; }

        public string ApellidoPaterno { get; set; }

        public string ApellidoMaterno { get; set; }

        public string Correo { get; set; }

        public string DNI { get; set; }

        public string Usuario { get; set; }

        public string Contrasenia { get; set; }

        public string ImagenUsu { get; set; }

        public int Intentos { get; set; }

        public bool Bloqueado { get; set; }
    }
}
