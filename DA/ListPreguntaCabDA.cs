using BE;
using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA
{
    public class ListPreguntaCabDA
    {
        public List<ListPreguntaCab> listPreguntaCabByIdPostulante(int idPostulante)
        {
            return ListPreguntaCabBO.listPreguntaCabByIdPostulante(idPostulante);
        }

        public List<ListPreguntaCab> listPreguntasCabByPost_Token(int idPostulante, string token)
        {
            return ListPreguntaCabBO.listPreguntasCabByPost_Token(idPostulante, token);
        }

        public List<ListPreguntaCab> listPreguntaCab()
        {
            return ListPreguntaCabBO.listPreguntaCab();
        }

        public List<ListPreguntaCab> listPreguntasCabByReq(int idRequerimiento)
        {
            return ListPreguntaCabBO.listPreguntasCabByReq(idRequerimiento);
        }

        public List<ListPreguntaDet> listPreguntaDetByIdPostulante(int idPostulante)
        {
            return ListPreguntaCabBO.listPreguntaDetByIdPostulante(idPostulante);
        }

        public List<ListPreguntaDet> listPreguntaDetByIdPostIdReq(int idPostulante, int idRequerimiento)
        {
            return ListPreguntaCabBO.listPreguntaDetByIdPostIdReq(idPostulante, idRequerimiento);
        }

        public int updateAddListPreguntasOfReq(int idListPregunta, int idRequerimiento)
        {
            return ListPreguntaCabBO.updateAddListPreguntasOfReq(idListPregunta, idRequerimiento);
        }

        public int updateDelListPreguntasOfReq(int idListPregunta, int idRequerimiento)
        {
            return ListPreguntaCabBO.updateDelListPreguntasOfReq(idListPregunta, idRequerimiento);
        }
    }
}
