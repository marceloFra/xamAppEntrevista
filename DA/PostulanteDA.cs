using BE;
using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA
{
    public class PostulanteDA
    {
        public List<Postulante> listPostulante()
        {
            return PostulanteBO.listPostulante();
        }

        public Postulante listPostulanteByIdPos(int idPostulante)
        {
            return PostulanteBO.listPostulanteByIdPos(idPostulante);
        }

        public List<Postulante> listPostulanteByIdReq(int idRequerimiento)
        {
            return PostulanteBO.listPostulanteByIdReq(idRequerimiento);
        }

        public int updatePostulantePregOfReqFinished(int idPostulante, int idRequerimiento, int flagEstadoRespuesta)
        {
            return PostulanteBO.updatePostulantePregOfReqFinished(idPostulante, idRequerimiento, flagEstadoRespuesta);
        }

    }
}
