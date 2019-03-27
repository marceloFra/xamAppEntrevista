using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class ListPreguntaDet
    {
        public int idPregunta { get; set; }
        public int idListPregunta { get; set; }
        public string pregunta { get; set; }
        public string creador { get; set; }
        public int flagEstadoListPregDet { get; set; }
        public int idRequerimiento { get; set; }
        public int numero { get; set; }
    }
}
