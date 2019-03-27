using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;
using System.Web.Http.Results;
using xamAppEntrevista.Models;

namespace xamAppEntrevista.Controllers
{ 
 
public class UploadPreguntaController : ApiController
    {
        
        // Guarda el Archivo
        [HttpPost]
        [Route("Upload/Sonidos")]
        public async Task<string> UploadAudios()
        {
            try
            {             
                var httpRequest = HttpContext.Current.Request;

                if (httpRequest.Files.Count > 0)
                {
                    foreach (string file in httpRequest.Files)
                    {
                        var postedFile = httpRequest.Files[file];
                        
                        var fileName = postedFile.FileName.Split('\\').LastOrDefault().Split('/').LastOrDefault();
                        var filePath = HttpContext.Current.Server.MapPath("~/App_Data/" + fileName);
                        //string ruta_audio1 = ConfigurationManager.AppSettings["ruta_audio"];
                        //var filePath = HttpContext.Current.Server.MapPath(ruta_audio1+fileName);
                        postedFile.SaveAs(filePath); 
                        return   fileName;
                    }
                }
            }
            catch (Exception e)
            {
                #region Imprimiendo Log
                string error = e.Message;
                string carpeta_Log = ConfigurationManager.AppSettings["ruta_log"];

                StreamWriter sw = File.AppendText(carpeta_Log);

                DateTime Hoy = DateTime.Now;

                var minuto = Hoy.Minute;
                var hora = Hoy.Hour;
                string fecha_Hoy = Hoy.ToString("dd-MM-yyyy");

                sw.WriteLine("---------------------------------");

                sw.WriteLine("EXCEPTION - Date: " + fecha_Hoy + " " + hora + ":" + minuto + ")");

                sw.WriteLine("\t From UploadPreguntaController.UploadAudios();");

                sw.WriteLine("\t Message Error: " + error);

                sw.WriteLine("---------------------------------");

                sw.Close();
                #endregion
                return e.Message;
            }

            return "no files";
        }

        
        /// Descarga el Archivo
        [HttpGet]
        [Route("Download/Sonidos/{nombreArchivo}")]
        public HttpResponseMessage DownloadFile(string nombreArchivo)
        {
            try
            {
                //  string root = ConfigurationManager.AppSettings["ruta_audio"];
                // string nombreArchivo = GenerarNombre(IdPostulante, idRequerimiento, idListPregunta, idPregunta);
                var fullPath = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/"+ nombreArchivo + ".wav");
                //string ruta_audio = ConfigurationManager.AppSettings["ruta_audio"];
                //var fullPath = System.Web.HttpContext.Current.Server.MapPath(ruta_audio + nombreArchivo + ".wav");
                //var fullPath = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/ARS_recording.wav");
                if (!string.IsNullOrEmpty(fullPath))
                {

                    if (File.Exists(fullPath))
                    {

                        HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                        var fileStream = new FileStream(fullPath, FileMode.Open);
                        response.Content = new StreamContent(fileStream);
                        // buscar uno para la imagen
                        response.Content.Headers.ContentType = new MediaTypeHeaderValue("audio/wav");
                        //response.Content.Headers.ContentType = new MediaTypeHeaderValue("video/mp4");
                        response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
                        response.Content.Headers.ContentDisposition.FileName = fullPath;
                        return response;
                    }
                }

            }
            catch(Exception e)
            {
                #region Imprimiendo Log
                string error = e.Message;
                string carpeta_Log = ConfigurationManager.AppSettings["ruta_log"];

                StreamWriter sw = File.AppendText(carpeta_Log);

                DateTime Hoy = DateTime.Now;

                var minuto = Hoy.Minute;
                var hora = Hoy.Hour;
                string fecha_Hoy = Hoy.ToString("dd-MM-yyyy");

                sw.WriteLine("---------------------------------");

                sw.WriteLine("EXCEPTION - Date: " + fecha_Hoy + " " + hora + ":" + minuto + ")");

                sw.WriteLine("\t From UploadPreguntaController.DownloadFile("+nombreArchivo+");");

                sw.WriteLine("\t Message Error: " + error);

                sw.WriteLine("---------------------------------");

                sw.Close();
                #endregion
            }
            return new HttpResponseMessage(HttpStatusCode.NotFound);
        }



        [HttpGet]
        [Route("Download/Video")]
        public HttpResponseMessage DownloadVideo()
        {
            try
            {
                //  string root = ConfigurationManager.AppSettings["ruta_audio"];

                //var fullPath = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/video.mp4");

                var fullPath = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/000003000002000001000002.wav");
                //string ruta_audio = ConfigurationManager.AppSettings["ruta_audio"];
                //var fullPath = System.Web.HttpContext.Current.Server.MapPath(ruta_audio + "000003000002000001000002.wav");

                if (!string.IsNullOrEmpty(fullPath))
                {

                    if (File.Exists(fullPath))
                    {

                        HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                        var fileStream = new FileStream(fullPath, FileMode.Open);
                        response.Content = new StreamContent(fileStream);
                        // buscar uno para la imagen
                        response.Content.Headers.ContentType = new MediaTypeHeaderValue("audio/wav");
                        // response.Content.Headers.ContentType = new MediaTypeHeaderValue("video/mp4");
                        response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
                        response.Content.Headers.ContentDisposition.FileName = fullPath;
                        return response;
                    }
                }
            }
            catch (Exception e)
            {
                
            }
            return new HttpResponseMessage(HttpStatusCode.NotFound);
        }

 
        public   string GenerarNombre(int IdPostulante, int idRequerimiento, int idListpregunta, int idPregunta)
        {
            var idPosStr = "";

            if (IdPostulante < 10)
            {
                idPosStr = "00000" + IdPostulante;
            }
            else if (IdPostulante < 100)
            {
                idPosStr = "0000" + IdPostulante;
            }
            else if (IdPostulante < 1000)
            {
                idPosStr = "000" + IdPostulante;
            }
            else if (IdPostulante < 1000)
            {
                idPosStr = "00" + IdPostulante;
            }
            else if (IdPostulante < 10000)
            {
                idPosStr = "0" + IdPostulante;
            }
            else
            {
                idPosStr = IdPostulante + "";
            }

            var idReqStr = "";

            if (idRequerimiento < 10)
            {
                idReqStr = "00000" + idRequerimiento;
            }
            else if (idRequerimiento < 100)
            {
                idReqStr = "0000" + idRequerimiento;
            }
            else if (idRequerimiento < 1000)
            {
                idReqStr = "000" + idRequerimiento;
            }
            else if (idRequerimiento < 1000)
            {
                idReqStr = "00" + idRequerimiento;
            }
            else if (idRequerimiento < 10000)
            {
                idReqStr = "0" + idRequerimiento;
            }
            else
            {
                idReqStr = idRequerimiento + "";
            }

            var idListPregStr = "";

            if (idListpregunta < 10)
            {
                idListPregStr = "00000" + idListpregunta;
            }
            else if (idListpregunta < 100)
            {
                idListPregStr = "0000" + idListpregunta;
            }
            else if (idListpregunta < 1000)
            {
                idListPregStr = "000" + idListpregunta;
            }
            else if (idListpregunta < 1000)
            {
                idListPregStr = "00" + idListpregunta;
            }
            else if (idListpregunta < 10000)
            {
                idListPregStr = "0" + idListpregunta;
            }
            else
            {
                idListPregStr = idListpregunta + "";
            }

            var idPregStr = "";

            if (IdPostulante < 10)
            {
                idPregStr = "00000" + idPregunta;
            }
            else if (IdPostulante < 100)
            {
                idPregStr = "0000" + idPregunta;
            }
            else if (IdPostulante < 1000)
            {
                idPregStr = "000" + idPregunta;
            }
            else if (IdPostulante < 1000)
            {
                idPregStr = "00" + idPregunta;
            }
            else if (IdPostulante < 10000)
            {
                idPregStr = "0" + idPregunta;
            }
            else
            {
                idPregStr = idPregunta + "";
            }

            return idPosStr + idReqStr + idListpregunta + idPregStr;

        }
        

    }
}
