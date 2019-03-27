using BE;
using DA;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace xamAppEntrevista.Controllers
{
    public class LoginController : ApiController
    {
        LoginDA getLogin = new LoginDA();


        [HttpGet]
        [Route("loginPostulante/{correo}/{codDePostGen}")]
        public IHttpActionResult loginPostulante(string correo, string codDePostGen)
        {
            Postulante postulante = new Postulante();
            try
            {
                #region Validando
                postulante = getLogin.logeoPostulante(correo, codDePostGen);
                #endregion
            }
            catch (Exception e)
            {

                var rsp = "error: " + e;
                return Json(rsp);
            }
            return Json(new { postulante.idRequerimiento, postulante.idPostulante, postulante.nombre ,postulante.flagEstadoRespuestas});
        }

        [HttpGet]
        [Route("loginAdministrador/{nomUsuario}/{contrasena}")]
        public IHttpActionResult loginAdministrador(string nomUsuario, string contrasena)
        {
            var flagConfirmacion = "";
            try
            {
                #region Validando
                flagConfirmacion = getLogin.logeoUsuario(nomUsuario, contrasena);
                #endregion

            }
            catch(Exception e)
            {
            }

            var confirmacion = flagConfirmacion;
            return Json(  confirmacion ); 
        }

    }
}
