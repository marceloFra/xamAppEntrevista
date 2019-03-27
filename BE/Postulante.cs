using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Postulante
    {
        public int idPostulante { get; set; }
        public string nombre { get; set; }
        public string correo { get; set; }
        public string numero { get; set; }
        public string tituloPuesto { get; set; }
        public int flagEstadoPostulante { get; set; }
        public int flagEstadoRespuestas { get; set; }
        public string codPostu { get; set; }
        public int idRequerimiento { get; set; }
    }
}
