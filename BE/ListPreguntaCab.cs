using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class ListPreguntaCab
    {
        public int idListPregunta { get; set; }
        public string nombreListPregunta { get; set; }
        public string creador { get; set; }
        public DateTime fechaCreado { get; set; }
        public int flagEstadoListPregCab { get; set; }
    }
}
