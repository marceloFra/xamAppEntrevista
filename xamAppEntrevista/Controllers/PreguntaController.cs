using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BE;
using DA;

namespace xamAppEntrevista.Controllers
{
    public class PreguntaController : ApiController
    {
        ListPreguntaCabDA GetListPreguntaCabDA = new ListPreguntaCabDA();
        ListPreguntaDetDA GetListPreguntaDetDA = new ListPreguntaDetDA();


        // GET: api/Pregunta
        public IHttpActionResult Get()
        {
            var listListPreguntas = new List<ListPreguntaDet>();

            #region Getting Data
            ListPreguntaDet obj1 = new ListPreguntaDet(){ idPregunta=1, idListPregunta = 1 , pregunta ="Como te llamas?", creador ="Victor", flagEstadoListPregDet = 150};
            ListPreguntaDet obj2 = new ListPreguntaDet(){ idPregunta = 2, idListPregunta = 1, pregunta = "Cuantos años tienes?", creador = "Victor", flagEstadoListPregDet = 150 };
            ListPreguntaDet obj3 = new ListPreguntaDet() { idPregunta = 3, idListPregunta = 1, pregunta = "En que lenguaje te especializas?", creador = "Victor", flagEstadoListPregDet = 150 };
    
            listListPreguntas.Add(obj1); listListPreguntas.Add(obj2); listListPreguntas.Add(obj3);
            #endregion

            return Json(listListPreguntas);
        }

        // GET: api/Pregunta/5
        public IHttpActionResult Get(int id)
        {
            var resultado = "Get(" + id + ")";
            return Json(new { data3 = resultado.ToString() }); ;
        }

        [HttpGet]
        [Route("pregunta/listPregFullByPost/{idPostulante}")]
        public IHttpActionResult listPreguntasByPost(int idPostulante)
        {
            List<MVListaDePreguntas> listObjMVListaDePreguntas = new List<MVListaDePreguntas>();


            MVListaDePreguntas objMVListaDePreguntas = new MVListaDePreguntas();

            #region CallingList<ListPregCab>
            //Este Objeto almacenará la CabeceraDeLaListaDePreguntas
            List<ListPreguntaCab> objListPregCab = new List<ListPreguntaCab>();
            objListPregCab = GetListPreguntaCabDA.listPreguntaCabByIdPostulante(idPostulante);

            foreach (var item in objListPregCab)
            {
                objMVListaDePreguntas = new MVListaDePreguntas();

                objMVListaDePreguntas.idListPregunta = item.idListPregunta;
                objMVListaDePreguntas.nombreListPregunta = item.nombreListPregunta;
                objMVListaDePreguntas.creador = item.creador;
                objMVListaDePreguntas.fechaCreado = item.fechaCreado;
                objMVListaDePreguntas.flagEstadoListPregCab = item.flagEstadoListPregCab;

                #region CallingObjListPregDet
                //Trayendo el Detalle De La ListaDePreguntas (Preguntas)
                List<ListPreguntaDet> listListPreguntaDet = new List<ListPreguntaDet>();
                listListPreguntaDet = GetListPreguntaDetDA.ListPreguntaDetByListPreg(item.idListPregunta);
                //Colocando
                objMVListaDePreguntas.listPreguntaDet = listListPreguntaDet;
                #endregion

                listObjMVListaDePreguntas.Add(objMVListaDePreguntas);
            }
            #endregion



            var resultado = listObjMVListaDePreguntas;
            return Json(resultado); ;
        }

        [HttpGet]
        [Route("pregunta/listPregFullByPost_token/{idPostulante}/{token}")]
        public IHttpActionResult listPreguntasByPost_token(int idPostulante, string token)
        {
            List<MVListaDePreguntas> listObjMVListaDePreguntas = new List<MVListaDePreguntas>();

            MVListaDePreguntas objMVListaDePreguntas = new MVListaDePreguntas();

            #region GettingAllQuestionsQueueOfAQuestionList
            //Este Objeto almacenará la CabeceraDeLaListaDePreguntas
            List <ListPreguntaCab> objListPregCab = new List<ListPreguntaCab>();
            objListPregCab = GetListPreguntaCabDA.listPreguntasCabByPost_Token(idPostulante,token);
            //Agregarle los listPregDet a cada listPregCab
            listObjMVListaDePreguntas = GetListPreguntaDetDA.traerPreguntasDeUnaListaDeListPreg(listListPreguntaCab: objListPregCab);

            #endregion
            
            var resultado = listObjMVListaDePreguntas;
            return Json(resultado); ;
        }
        
        [HttpGet]
        [Route("pregunta/listPregDetByListPreg/{idListPregunta}")]
        public IHttpActionResult listPreguntasByListPreg(int idListPregunta)
        {
            List<ListPreguntaDet> listListPreguntaDet = new List<ListPreguntaDet>();
            listListPreguntaDet = GetListPreguntaDetDA.ListPreguntaDetByListPreg(idListPregunta);
            
            var resultado = listListPreguntaDet;
            return Json(resultado); ;
        }

        [HttpGet]
        [Route("pregunta/listPregCabByReq/{idRequerimiento}")]
        public IHttpActionResult listPreguntasCabByReq(int idRequerimiento)
        {
            List<ListPreguntaCab> listListPreguntaCab = new List<ListPreguntaCab>();
            listListPreguntaCab = GetListPreguntaCabDA.listPreguntasCabByReq(idRequerimiento);

            var resultado = listListPreguntaCab;
            return Json(resultado);
        }

        [HttpGet]
        [Route("pregunta/listPregDetByPost/{idPostulante}")]
        public IHttpActionResult listPregDetByPost(int idPostulante)
        {
            List<ListPreguntaDet> listListaDePregDet = new List<ListPreguntaDet>();

            //GettingListOfListaDePregDet : Este Objeto almacenará la ListaDePregDet
            listListaDePregDet = GetListPreguntaCabDA.listPreguntaDetByIdPostulante(idPostulante);

            var resultado = listListaDePregDet;
            return Json(resultado);
        }

        [HttpGet]
        [Route("pregunta/listPregDetByPostAndReq/{idPostulante}/{idRequerimiento}")]
        public IHttpActionResult listPregDetByPostNotResponsed(int idPostulante, int idRequerimiento)
        {
            List<ListPreguntaDet> listListaDePregDet = new List<ListPreguntaDet>();

            //GettingListOfListaDePregDet : Este Objeto almacenará la ListaDePregDet
            listListaDePregDet = GetListPreguntaCabDA.listPreguntaDetByIdPostIdReq(idPostulante, idRequerimiento);

            var resultado = listListaDePregDet;
            return Json(resultado);
        }

        [HttpPut]
        [Route("pregunta/updateDelListPregCabAndIdReq/{idListPregunta}/{idRequerimiento}")]
        public IHttpActionResult updateDelListPreguntasOfReq(int idListPregunta, int idRequerimiento)
        {
            int confirmacion;

            //GettingListOfListaDePregDet : Este Objeto almacenará la ListaDePregDet
            confirmacion = GetListPreguntaCabDA.updateDelListPreguntasOfReq(idListPregunta, idRequerimiento);

            var resultado = confirmacion;
            return Json(resultado);
        }

        [HttpPut]
        [Route("pregunta/updateAddListPregCabAndIdReq/{idListPregunta}/{idRequerimiento}")]
        public IHttpActionResult updateAddListPreguntasOfReq(int idListPregunta, int idRequerimiento)
        {
            int confirmacion;

            //GettingListOfListaDePregDet : Este Objeto almacenará la ListaDePregDet
            confirmacion = GetListPreguntaCabDA.updateAddListPreguntasOfReq(idListPregunta, idRequerimiento);

            var resultado = confirmacion;
            return Json(resultado);
        }

        // POST: api/Pregunta
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Pregunta/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Pregunta/5
        public void Delete(int id)
        {
        }
    }
}
