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
    public class PostulanteBO
    {
        public static List<Postulante> listPostulante()
        {
            List<Postulante> listPostulante = new List<Postulante>();

            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dypa = new DynamicParameters();
                listPostulante = cn.Query<Postulante>("xamApp.xam_sp_listPostulante", dypa, commandType: CommandType.StoredProcedure).ToList();
            }
            catch (Exception e)
            {
                //listPostulante
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

                sw.WriteLine("\t From PostulanteBO.listPostulante();");

                sw.WriteLine("\t Message Error: " + error);

                sw.WriteLine("---------------------------------");

                sw.Close();
                #endregion

                listPostulante = new List<Postulante>();
            }
            finally
            {
                cn.Close();
                cn.Dispose();
            }

            return listPostulante;
        }

        public static Postulante listPostulanteByIdPos(int idPostulante)
        {
            Postulante listPostulante = new Postulante();

            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dypa = new DynamicParameters();
                dypa.Add("@idPostulante", idPostulante);
                listPostulante = cn.QueryFirst<Postulante>("xamApp.xam_sp_listPostulanteByIdPos", dypa, commandType: CommandType.StoredProcedure);
            }
            catch (Exception e)
            {
                //listPostulanteByIdPos
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

                sw.WriteLine("\t From PostulanteBO.listPostulanteByIdPos(idPostulante" + idPostulante + ");");

                sw.WriteLine("\t Message Error: " + error);

                sw.WriteLine("---------------------------------");

                sw.Close();
                #endregion

                listPostulante = new Postulante();
            }
            finally
            {
                cn.Close();
                cn.Dispose();
            }

            return listPostulante;
        }

        public static List<Postulante> listPostulanteByIdReq(int idRequerimiento)
        {
            List<Postulante> listPostulante = new List<Postulante>();

            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dypa = new DynamicParameters();
                dypa.Add("@idRequerimiento", idRequerimiento);
                listPostulante = cn.Query<Postulante>("xamApp.xam_sp_listPostulanteByIdReq", dypa, commandType: CommandType.StoredProcedure).ToList();
                
            }
            catch (Exception e)
            {
                //listPostulanteByIdPos
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

                sw.WriteLine("\t From PostulanteBO.listPostulanteByIdReq(idRequerimiento" + idRequerimiento + ");");

                sw.WriteLine("\t Message Error: " + error);

                sw.WriteLine("---------------------------------");

                sw.Close();
                #endregion

                listPostulante = new List<Postulante>();
            }
            finally
            {
                cn.Close();
                cn.Dispose();
            }

            return listPostulante;
        }

        public static int updatePostulantePregOfReqFinished(int idPostulante, int idRequerimiento, int flagEstadoRespuesta)
        {
            int rpta = 1;

            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dypa = new DynamicParameters();
                dypa.Add("@idPostulante", idPostulante);
                dypa.Add("@idRequerimiento", idRequerimiento);
                dypa.Add("@flagEstadoRespuesta", flagEstadoRespuesta);
                cn.Query("xamApp.xam_sp_updateFlagPosOfReq", dypa, commandType: CommandType.StoredProcedure);
            }
            catch (Exception e)
            {
                //updatePostulantePregOfReqFinished
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

                sw.WriteLine("\t From PostulanteBO.updatePostulantePregOfReqFinished(idPostulante:" + idPostulante + ", idRequerimiento:" + idRequerimiento + "," +
                    "flagEstadoRespuesta:"+ flagEstadoRespuesta + ")");

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

    }
}
