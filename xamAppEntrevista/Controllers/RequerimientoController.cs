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
    public class RequerimientoController : ApiController
    {
        RequerimientoDA GetRequerimientoBO = new RequerimientoDA();

        // GET: api/Requerimiento
        public IHttpActionResult Get()
        {
            List<Requerimiento> listRequerimiento = new List<Requerimiento>();

            //GettingListOfListaDePregDet : Este Objeto almacenará la ListaDePregDet
            listRequerimiento = GetRequerimientoBO.listRequerimiento();

            var resultado = listRequerimiento;
            return Json(resultado);
        }

        // GET: api/Requerimiento/5
        public IHttpActionResult Get(int id)
        {
            Requerimiento objRequerimiento = new Requerimiento();

            //GettingListOfListaDePregDet : Este Objeto almacenará la ListaDePregDet
            objRequerimiento = GetRequerimientoBO.listRequerimientoByIdReq(id);

            var resultado = objRequerimiento;
            return Json(resultado);
        }

        // POST: api/Requerimiento
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Requerimiento/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Requerimiento/5
        public void Delete(int id)
        {
        }

        [HttpGet]
        [Route("Requerimiento/listRequerimiento")]
        public IHttpActionResult listRequerimiento()
        {
            List<Requerimiento> listRequerimiento = new List<Requerimiento>();

            //GettingListOfListaDePregDet : Este Objeto almacenará la ListaDePregDet
            listRequerimiento = GetRequerimientoBO.listRequerimiento();

            var resultado = listRequerimiento;
            return Json(resultado);
        }

        [HttpGet]
        [Route("Requerimiento/listRequerimientoByIdReq/{idRequerimiento}")]
        public IHttpActionResult listRequerimientoByIdReq(int idRequerimiento)
        {
            Requerimiento objRequerimiento = new Requerimiento();

            //GettingListOfListaDePregDet : Este Objeto almacenará la ListaDePregDet
            objRequerimiento = GetRequerimientoBO.listRequerimientoByIdReq(idRequerimiento);

            var resultado = objRequerimiento;
            return Json(resultado);
        }


        [HttpGet]
        [Route("Requerimiento/listRequerimientoByIdPos/{idPostulante}")]
        public IHttpActionResult listRequerimiento(int idPostulante)
        {
            List<Requerimiento> listRequerimiento = new List<Requerimiento>();

            //GettingListOfListaDePregDet : Este Objeto almacenará la ListaDePregDet
            listRequerimiento = GetRequerimientoBO.listRequerimientoByIdPos(idPostulante);

            var resultado = listRequerimiento;
            return Json(resultado);
        }

    }
}
