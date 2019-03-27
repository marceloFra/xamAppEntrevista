using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Requerimiento
    {
        public int idRequerimiento { get; set; }
        public string nombreRequerimiento { get; set; }
        public DateTime fechaTentativa { get; set; }
        public string empresa { get; set; }
        public string estadoRequerimiento { get; set; }
        public string puesto { get; set; }
    }
}
