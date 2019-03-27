using BE;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace BO
{
    public class ListPreguntaCabBO
    {
        public static List<ListPreguntaCab> listPreguntaCabByIdPostulante(int idPostulante)
        {
            List<ListPreguntaCab> rpta = new List<ListPreguntaCab>();

            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dypa = new DynamicParameters();
                dypa.Add("@idPostulante", idPostulante);
                rpta = cn.Query<ListPreguntaCab>("xamApp.xam_sp_listPreguntasCabByPost", dypa, commandType: CommandType.StoredProcedure).ToList();
            }
            catch (Exception e)
            {
                //listPreguntaCabByIdPostulante
                #region Imprimiendo Log
                string error = e.Message;
                string carpeta_Log = ConfigurationManager.AppSettings["ruta_log"];

                StreamWriter sw = File.AppendText(carpeta_Log);

                DateTime Hoy = DateTime.Now;

                var minuto = Hoy.Minute;
                var hora = Hoy.Hour;
                string fecha_Hoy = Hoy.ToString("dd-MM-yyyy");

                sw.WriteLine("---------------------------------");

                sw.WriteLine("EXCEPTION - Date: "+ fecha_Hoy + " "+hora+":"+minuto+")");

                sw.WriteLine("\t From ListPreguntaCabBO.listPreguntaCabByIdPostulante(idPostulante:" + idPostulante + ")");

                sw.WriteLine("\t Message Error: "+error);

                sw.WriteLine("---------------------------------");

                sw.Close();
                #endregion

                rpta = new List<ListPreguntaCab>();

            }
            finally
            {
                cn.Close();
                cn.Dispose();
            }

            return rpta;
        }

        public static List<ListPreguntaCab> listPreguntasCabByPost_Token(int idPostulante, string token)
        {
            List < ListPreguntaCab> rpta = new List<ListPreguntaCab>();

            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dypa = new DynamicParameters();
                dypa.Add("@idPostulante", idPostulante);
                dypa.Add("@codPostu", token);
                rpta = cn.Query<ListPreguntaCab>("xamApp.xam_sp_listPreguntasCabByPost_Token", dypa, commandType: CommandType.StoredProcedure).ToList();
            }
            catch (Exception e)
            {
                //listPreguntasByPost_Token
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

                sw.WriteLine("\t From ListPreguntaCabBO.listPreguntasByPost_Token(idPostulante:" + idPostulante + ", token:"+ token + ")");

                sw.WriteLine("\t Message Error: " + error);

                sw.WriteLine("---------------------------------");

                sw.Close();
                #endregion

                rpta = new List<ListPreguntaCab>();

            }
            finally
            {
                cn.Close();
                cn.Dispose();
            }

            return rpta;
        }

        public static List<ListPreguntaCab> listPreguntaCab()
        {
            List<ListPreguntaCab> rpta = new List<ListPreguntaCab>();

            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dypa = new DynamicParameters();
                rpta = cn.Query<ListPreguntaCab>("xamApp.xam_sp_ListPreguntaCab", dypa, commandType: CommandType.StoredProcedure).ToList();
            }
            catch (Exception e)
            {
                //listPregunta
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

                sw.WriteLine("\t From ListPreguntaCabBO.listPregunta()");

                sw.WriteLine("\t Message Error: " + error);

                sw.WriteLine("---------------------------------");

                sw.Close();
                #endregion

                rpta = new List<ListPreguntaCab>();

            }
            finally
            {
                cn.Close();
                cn.Dispose();
            }

            return rpta;
        }

        public static List<ListPreguntaCab> listPreguntasCabByReq(int idRequerimiento)
        {
            List<ListPreguntaCab> rpta = new List<ListPreguntaCab>();

            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dypa = new DynamicParameters();
                dypa.Add("@idRequerimiento", idRequerimiento);
                rpta = cn.Query<ListPreguntaCab>("xamApp.xam_sp_listPreguntasCabByReq", dypa, commandType: CommandType.StoredProcedure).ToList();
            }
            catch (Exception e)
            {
                //listPreguntasCabByReq
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

                sw.WriteLine("\t From ListPreguntaCabBO.listPreguntasCabByReq(idRequerimiento:" + idRequerimiento + ")");

                sw.WriteLine("\t Message Error: " + error);

                sw.WriteLine("---------------------------------");

                sw.Close();
                #endregion

                rpta = new List<ListPreguntaCab>();

            }
            finally
            {
                cn.Close();
                cn.Dispose();
            }

            return rpta;
        }

        public static List<ListPreguntaDet> listPreguntaDetByIdPostulante(int idPostulante)
        {
            List<ListPreguntaDet> rpta = new List<ListPreguntaDet>();

            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dypa = new DynamicParameters();
                dypa.Add("@idPostulante", idPostulante);
                rpta = cn.Query<ListPreguntaDet>("xamApp.xam_sp_listPreguntasDetByPost", dypa, commandType: CommandType.StoredProcedure).ToList();

                int cantidad = 0;

                foreach (ListPreguntaDet i in rpta)
                {
                    cantidad++;
                    i.numero = cantidad;
                }


            }
            catch (Exception e)
            {
                //listPreguntaDetByIdPostulante
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

                sw.WriteLine("\t From ListPreguntaCabBO.listPreguntaDetByIdPostulante(idPostulante:" + idPostulante + ")");

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

        //INICIO
        public static List<ListPreguntaDet> listPreguntaDetByIdPostIdReq(int idPostulante, int idRequerimiento)
        {
            List<ListPreguntaDet> rpta = new List<ListPreguntaDet>();

            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dypa = new DynamicParameters();
                dypa.Add("@idPostulante", idPostulante);
                dypa.Add("@idRequerimiento", idRequerimiento);
                rpta = cn.Query<ListPreguntaDet>("xamApp.xam_sp_listPregDetByPostReq", dypa, commandType: CommandType.StoredProcedure).ToList();


                int cantidad = 0;

                foreach (ListPreguntaDet i in rpta)
                {
                    cantidad++;
                    i.numero = cantidad;
                }


            }
            catch (Exception e)
            {
                //listPreguntaDetByIdPostulante
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

                sw.WriteLine("\t From ListPreguntaCabBO.listPreguntaDetByIdPostulante(idPostulante:" + idPostulante + ")");

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

        public static int updateAddListPreguntasOfReq(int idListPregunta, int idRequerimiento)
        {
            int rpta=1;

            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dypa = new DynamicParameters();
                dypa.Add("@idListPregunta", idListPregunta);
                dypa.Add("@idRequerimiento", idRequerimiento);
                cn.Query("xamApp.xam_sp_updateAddListPregOfReq", dypa, commandType: CommandType.StoredProcedure);
            }
            catch (Exception e)
            {
                //updateAddListPreguntasOfReq
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

                sw.WriteLine("\t From ListPreguntaCabBO.updateAddListPreguntasOfReq(idListPregunta:" + idListPregunta + ", idRequerimiento:"+ idRequerimiento + ")");

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

        public static int updateDelListPreguntasOfReq(int idListPregunta, int idRequerimiento)
        {
            int rpta = 1;

            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dypa = new DynamicParameters();
                dypa.Add("@idListPregunta", idListPregunta);
                dypa.Add("@idRequerimiento", idRequerimiento);
                cn.Query("xamApp.xam_sp_updateDelListPreguntasOfReq", dypa, commandType: CommandType.StoredProcedure);
            }
            catch (Exception e)
            {
                //updateAddListPreguntasOfReq
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

                sw.WriteLine("\t From ListPreguntaCabBO.updateDelListPreguntasOfReq(idListPregunta:" + idListPregunta + ", idRequerimiento:" + idRequerimiento + ")");

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
