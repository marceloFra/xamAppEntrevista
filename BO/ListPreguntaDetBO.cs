using BE;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class ListPreguntaDetBO
    {
        public static List<ListPreguntaDet> ListPreguntaDetByListPreg(int idListPregunta)
        {
            List<ListPreguntaDet> rpta = new List<ListPreguntaDet>();

            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dypa = new DynamicParameters();
                dypa.Add("@idListPregunta", idListPregunta);
                rpta = cn.Query<ListPreguntaDet>("xamApp.xam_sp_ListPreguntaDetByListPreg", dypa, commandType: CommandType.StoredProcedure).ToList();
            }
            catch (Exception e)
            {
                //ListPreguntaDetByListPreg
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

                sw.WriteLine("\t From ListPreguntaDetBO.ListPreguntaDetByListPreg(idListPregunta:" + idListPregunta + ")");

                sw.WriteLine("\t Message Error: " + error);

                sw.WriteLine("---------------------------------");

                sw.Close();
                #endregion

                rpta = new List<ListPreguntaDet>();

            }
            finally
            {
                cn.Close();
                cn.Dispose();
            }

            return rpta;
        }

        public static List<MVListaDePreguntas> traerPreguntasDeUnaListaDeListPreg(List<ListPreguntaCab> listListPreguntaCab)
        {
            List<MVListaDePreguntas> rpta = new List<MVListaDePreguntas>();

            SqlConnection cn = new SqlConnection(Conexion.cn);
            cn.Open();
            SqlTransaction tran = cn.BeginTransaction(IsolationLevel.Serializable);
            try
            {
                MVListaDePreguntas objSubRpta = new MVListaDePreguntas(); ;
                foreach (var item in listListPreguntaCab)
                {
                    objSubRpta = new MVListaDePreguntas();
                    DynamicParameters dypa = new DynamicParameters();
                    dypa.Add("@idListPregunta", item.idListPregunta);
                    objSubRpta.listPreguntaDet = cn.Query<ListPreguntaDet>
                        ("xamApp.xam_sp_ListPreguntaDetByListPreg", dypa, tran, commandType: CommandType.StoredProcedure).ToList();

                    objSubRpta.idListPregunta = item.idListPregunta;
                    objSubRpta.nombreListPregunta = item.nombreListPregunta;
                    objSubRpta.creador = item.creador;
                    objSubRpta.fechaCreado = item.fechaCreado;
                    objSubRpta.flagEstadoListPregCab = item.flagEstadoListPregCab;

                    rpta.Add(objSubRpta);
                }

                tran.Commit();
            }
            catch (Exception e)
            {

                //traerPreguntasDeUnaListaDeListPreg
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

                sw.WriteLine("\t From ListPreguntaDetBO.traerPreguntasDeUnaListaDeListPreg(List<ListPreguntaCab>:" + listListPreguntaCab + ")");

                sw.WriteLine("\t Message Error: " + error);

                sw.WriteLine("---------------------------------");

                sw.Close();
                #endregion

                tran.Rollback();
                rpta = new List<MVListaDePreguntas>();

            }
            finally
            {
                cn.Close();
                cn.Dispose();
            }

            return rpta;
        }

        #region NuevosCambiosListPreguntaDetBO

        public static int updateDelPregOfArrayDePregByPostReqPreg(int idPostulante, int idRequerimiento, string PregsStr)
        {
            int rpta = 1;

            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dypa = new DynamicParameters();
                dypa.Add("@idPostulante", idPostulante);
                dypa.Add("@idRequerimiento", idRequerimiento);
                dypa.Add("@PregsStr", PregsStr);
                cn.Query("xamApp.xam_sp_updateArrayOfPregsOfPostReq", dypa, commandType: CommandType.StoredProcedure);
            }
            catch (Exception e)
            {
                //updateDelPregOfArrayDePregByPostReqPreg
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

                sw.WriteLine("\t From ListPreguntaDetBO.updateDelPregOfArrayDePregByPostReqPreg(idPostulante:" + idPostulante + ", idRequerimiento:" + idRequerimiento + "," +
                    "PregsStr:" + PregsStr + ")");

                sw.WriteLine("\t Message Error: " + error);

                sw.WriteLine("---------------------------------");

                sw.Close();
                #endregion

                rpta = 0;
            }
            finally
            {
                cn.Close();
                cn.Dispose();
            }

            return rpta;
        }

        //Listo
        public static string selectArrayOfPregs(int idPostulante, int idRequerimiento)
        {
            string rpta = ":D";

            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dypa = new DynamicParameters();
                dypa.Add("@idPostulante", idPostulante);
                dypa.Add("@idRequerimiento", idRequerimiento);
                rpta = cn.QueryFirst<string>("xamApp.xam_sp_ListArrayOfPregs", dypa, commandType: CommandType.StoredProcedure).ToString();
            }
            catch (Exception e)
            {
                //ListPreguntaDetByListPreg
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

                sw.WriteLine("\t From ListPreguntaDetBO.selectArrayOfPregs(idListPregunta:" + idPostulante + ",idRequerimiento :" + idRequerimiento + ")");

                sw.WriteLine("\t Message Error: " + error);

                sw.WriteLine("---------------------------------");

                sw.Close();
                #endregion

                rpta = "[]";

            }
            finally
            {
                cn.Close();
                cn.Dispose();
            }

            return rpta;
        }

        #endregion
    }
}
