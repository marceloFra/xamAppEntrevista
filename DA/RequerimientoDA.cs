using BE;
using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA
{
    public class RequerimientoDA
    {
        public List<Requerimiento> listRequerimiento()
        {
            return RequerimientoBO.listRequerimiento();
        }

        public Requerimiento listRequerimientoByIdReq(int idRequerimiento)
        {
            return RequerimientoBO.listRequerimientoByIdReq(idRequerimiento);
        }

        public List<Requerimiento> listRequerimientoByIdPos(int idPostulante)
        {
            return RequerimientoBO.listRequerimientoByIdPos(idPostulante);
        }


    }
}
