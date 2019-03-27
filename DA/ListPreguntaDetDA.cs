using BE;
using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA
{
    public class ListPreguntaDetDA
    {
        public List<ListPreguntaDet> ListPreguntaDetByListPreg(int idListPregunta)
        {
            return ListPreguntaDetBO.ListPreguntaDetByListPreg(idListPregunta);
        }

        public List<MVListaDePreguntas> traerPreguntasDeUnaListaDeListPreg(List<ListPreguntaCab> listListPreguntaCab)
        {
            return ListPreguntaDetBO.traerPreguntasDeUnaListaDeListPreg(listListPreguntaCab);
        }

        #region NuevosCambios

        public int updateDelPregOfArrayDePregByPostReqPreg(int idPostulante, int idRequerimiento, string arrayPreguntasStr)
        {
            return ListPreguntaDetBO.updateDelPregOfArrayDePregByPostReqPreg(idPostulante, idRequerimiento, arrayPreguntasStr);
        }

        public string selectArrayOfPregs(int idPostulante, int idRequerimiento)
        {
            return ListPreguntaDetBO.selectArrayOfPregs(idPostulante, idRequerimiento);
        }
        #endregion
    }
}
