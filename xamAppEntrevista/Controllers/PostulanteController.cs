using BE;
using DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace xamAppEntrevista.Controllers
{
    public class PostulanteController : ApiController
    {
        PostulanteDA GetPostulanteDA = new PostulanteDA();
        ListPreguntaCabDA getListPreguntaCab = new ListPreguntaCabDA();
        ListPreguntaDetDA getListPreguntaDet = new ListPreguntaDetDA();



      
        // GET: api/Postulante
        public IHttpActionResult Get()
        {
            List<Postulante> listPostulante = new List<Postulante>();

            //GettingListOfListaDePregDet : Este Objeto almacenará la ListaDePregDet
            listPostulante = GetPostulanteDA.listPostulante();

            var resultado = listPostulante;
            return Json(resultado);
        }

        // GET: api/Postulante/{id}
        public IHttpActionResult Get(int id)
        {
            Postulante objPostulante = new Postulante();

            //GettingListOfListaDePregDet : Este Objeto almacenará la ListaDePregDet
            objPostulante = GetPostulanteDA.listPostulanteByIdPos(id);

            var resultado = objPostulante;
            return Json(resultado);
        }





        [HttpGet]
        [Route("postulante/listPostulanteByIdReq/{idRequerimiento}")]
        public IHttpActionResult listPostulanteByIdReq(int idRequerimiento)
        {
            List<Postulante> listPostulante = new List<Postulante>();
            listPostulante = GetPostulanteDA.listPostulanteByIdReq(idRequerimiento);

            var resultado = listPostulante;
            return Json(resultado);
        }

        /// <summary>
        /// PARA EDITAR EL ESTADO DE LA TABLA REQUE BY POST PARA QUE ESTE EN PROCESO DEL EXAMEN 
        /// </summary>
        /// <param name="idPostulante"></param>
        /// <param name="idRequerimiento"></param>
        /// <param name="flagEstadoRespuesta"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("postulante/updatePostulantePregOfReqFinished/{idPostulante}/{idRequerimiento}/{flagEstadoRespuesta}")]
        public IHttpActionResult updatePostulanteTerminada(int idPostulante, int idRequerimiento, int flagEstadoRespuesta)
        {
            int confirmacion;

            //GettingListOfListaDePregDet : Este Objeto almacenará la ListaDePregDet
            confirmacion = GetPostulanteDA.updatePostulantePregOfReqFinished(idPostulante, idRequerimiento, flagEstadoRespuesta);

            var resultado = confirmacion;
            return Json(resultado); ;
        }


        /*NUEVOS*/
        /* ARMA LA LISTA*/
        #region NuevosCambios
        [HttpGet]
        [Route("postulante/ListPregAvailableByPostReq/{idPostulante}/{idRequerimiento}")]
        public IHttpActionResult ListPregAvailableByPostReq(int idPostulante, int idRequerimiento)
        {
            #region armandoLaLista
            List<ListPreguntaDet> listPreguntaCab = getListPreguntaCab.listPreguntaDetByIdPostIdReq(idPostulante, idRequerimiento);

            string arrayDePregStr = getListPreguntaDet.selectArrayOfPregs(idPostulante, idRequerimiento);

            string[] arrayDePreg = arrayDePregStr.Split(',');

            List<string> ListDePregOfArray = new List<string>();//Aca se almacenaran temporalmente las preguntas del array traido por arrayDePregStr

            int numPreguntas = arrayDePreg.Length;

            for (int i = 0; i < numPreguntas; i++)
            {
                ListDePregOfArray.Add(arrayDePreg[i].ToString());
            }

            List<ListPreguntaDet> listPregCabResultado = new List<ListPreguntaDet>();

            foreach (var itemsito in ListDePregOfArray)
            {
                foreach (var itemsaso in listPreguntaCab)
                {
                    if (int.Parse(itemsito) == itemsaso.idPregunta)
                    {
                        listPregCabResultado.Add(itemsaso);
                    }
                }
            }
            #endregion

            var resultado = listPregCabResultado;
            return Json(resultado); ;
        }

        /// <summary>
        /// *SACA LAS PREGUNTAS CONTESTADAS*/
        /// </summary>
        /// <param name="idPostulante"></param>
        /// <param name="idRequerimiento"></param>
        /// <param name="idPregunta"></param>
        /// <returns>LISTA DE POREGUNTAS QUE FALTA POR CONTESTAR</returns>
        [HttpGet]
        [Route("postulante/updateDelPregOfArrayDePregByPostReqPreg/{idPostulante}/{idRequerimiento}/{idPregunta}")]
        public IHttpActionResult updateDelPregOfArrayDePregByPostReqPreg(int idPostulante, int idRequerimiento, int idPregunta)
        {
            int confirmacion;

            #region QuitaElElementoDelArray
            string arrayDePregStrOld = getListPreguntaDet.selectArrayOfPregs(idPostulante, idRequerimiento);

            string[] OldarrayDePreg = arrayDePregStrOld.Split(',');
            string[] NewArrayDePregPass = new string[OldarrayDePreg.Length - 1];

            string NewarrayDePreg = "";

            int contJ = 0;
            for (int i = 0; i < OldarrayDePreg.Length; i++)
            {
                if (int.Parse(OldarrayDePreg[i]) != idPregunta)
                {
                    NewArrayDePregPass[contJ] = OldarrayDePreg[i];
                    NewarrayDePreg += OldarrayDePreg[i] + ",";
                    contJ++;
                }
            }

            if (NewarrayDePreg.Length - 1 > 0)
            {
                NewarrayDePreg = NewarrayDePreg.Substring(0, NewarrayDePreg.Length - 1);
            }
            else
            {
                NewarrayDePreg = "";
            }

            confirmacion = getListPreguntaDet.updateDelPregOfArrayDePregByPostReqPreg(idPostulante, idRequerimiento, NewarrayDePreg);
            #endregion

            List<ListPreguntaDet> listPreguntaCab = new List<ListPreguntaDet>();
            List<ListPreguntaDet> listPregCabResultado = new List<ListPreguntaDet>();

            if (NewarrayDePreg == "")
            {
                listPregCabResultado = new List<ListPreguntaDet>();
            }
            else
            {
                #region armandoLaLista
                listPreguntaCab = getListPreguntaCab.listPreguntaDetByIdPostIdReq(idPostulante, idRequerimiento);

                string[] arrayDePreg = NewArrayDePregPass;

                List<string> ListDePregOfArray = new List<string>();

                int numPreguntas = arrayDePreg.Length;

                for (int i = 0; i < numPreguntas; i++)
                {
                    ListDePregOfArray.Add(arrayDePreg[i].ToString());
                }

                listPregCabResultado = new List<ListPreguntaDet>();

                foreach (var itemsito in ListDePregOfArray)
                {
                    foreach (var itemsaso in listPreguntaCab)
                    {
                        if (int.Parse(itemsito) == itemsaso.idPregunta)
                        {
                            listPregCabResultado.Add(itemsaso);
                        }
                    }
                }
                #endregion
            }

            var resultado = listPregCabResultado;
            return Json(resultado); ;
        }
        /// <summary>
        /// RELLENA LA COLUMNA DE  LAS PREGUNTAS CORRESPONDIENTES DE PREGUNTAS CON REQU
        /// </summary>
        /// <param name="idPostulante"></param>
        /// <param name="idRequerimiento"></param>
        /// <returns> RETORNA TODA LA LISTA DE LAS PREGUNTAS </returns>
        [HttpGet]
        [Route("postulante/updateFillPregInArrayDePregByPostReq/{idPostulante}/{idRequerimiento}")]
        public IHttpActionResult updateFillPregInArrayDePregByPostReq(int idPostulante, int idRequerimiento)
        {
            int confirmacion;

            #region AgregarLasPreguntasAlArray

            List<ListPreguntaDet> listPreguntaCab = getListPreguntaCab.listPreguntaDetByIdPostIdReq(idPostulante, idRequerimiento);

            string[] arrayDePreg = new string[listPreguntaCab.Count];

            string arrayDePregStr = "";

            foreach (var item in listPreguntaCab)
            {
                arrayDePregStr += item.idPregunta.ToString() + ",";
            }

            if (arrayDePregStr.Length-1>0)
            {
                arrayDePregStr = arrayDePregStr.Substring(0, arrayDePregStr.Length - 1);
            }
            else
            {
                arrayDePregStr = "";
            }

            confirmacion = getListPreguntaDet.updateDelPregOfArrayDePregByPostReqPreg(idPostulante, idRequerimiento, arrayDePregStr);
            #endregion

            var resultado = listPreguntaCab;
            return Json(resultado);
        }
        #endregion

    }
}
