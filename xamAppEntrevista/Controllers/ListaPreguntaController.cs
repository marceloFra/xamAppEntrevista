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
    public class ListaPreguntaController : ApiController
    {
        ListPreguntaCabDA getListPreguntaCabDA = new ListPreguntaCabDA();

        // GET: api/ListaPregunta
        public IHttpActionResult Get()
        {
            List<ListPreguntaCab> obj = new List<ListPreguntaCab>();
            obj = getListPreguntaCabDA.listPreguntaCab();
            var resultado = obj; 
            return Json(resultado); ;
        }

        // GET: api/ListaPregunta/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ListaPregunta
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ListaPregunta/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ListaPregunta/5
        public void Delete(int id)
        {
        }
    }
}
