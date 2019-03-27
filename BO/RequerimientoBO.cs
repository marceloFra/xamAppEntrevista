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
    public class RequerimientoBO
    {
        public static List<Requerimiento> listRequerimiento()
        {
            List<Requerimiento> listRequerimiento = new List<Requerimiento>();

            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dypa = new DynamicParameters();
                listRequerimiento=cn.Query<Requerimiento>("xamApp.xam_sp_listRequerimiento", dypa, commandType: CommandType.StoredProcedure).ToList();
            }
            catch (Exception e)
            {
                //listRequerimiento
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

                sw.WriteLine("\t From RequerimientoBO.listRequerimiento();");

                sw.WriteLine("\t Message Error: " + error);

                sw.WriteLine("---------------------------------");

                sw.Close();
                #endregion

                listRequerimiento = new List<Requerimiento>();                
            }
            finally
            {
                cn.Close();
                cn.Dispose();
            }

            return listRequerimiento;
        }

        public static Requerimiento listRequerimientoByIdReq(int idRequerimiento)
        {
            Requerimiento listRequerimiento = new Requerimiento();

            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dypa = new DynamicParameters();
                dypa.Add("@idRequerimiento", idRequerimiento);
                listRequerimiento = cn.QueryFirst<Requerimiento>("xamApp.xam_sp_listRequerimientoByIdReq", dypa, commandType: CommandType.StoredProcedure);
            }
            catch (Exception e)
            {
                //listRequerimiento
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

                sw.WriteLine("\t From RequerimientoBO.listRequerimientoByIdReq(idRequerimiento"+ idRequerimiento + ");");

                sw.WriteLine("\t Message Error: " + error);

                sw.WriteLine("---------------------------------");

                sw.Close();
                #endregion

                listRequerimiento = new Requerimiento();
            }
            finally
            {
                cn.Close();
                cn.Dispose();
            }

            return listRequerimiento;
        }


        public static List<Requerimiento> listRequerimientoByIdPos(int idPostulante)
        {
            List<Requerimiento> listRequerimiento = new List<Requerimiento>();

            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dypa = new DynamicParameters();
                dypa.Add("@idPostulante", idPostulante);
                listRequerimiento = cn.Query<Requerimiento>("xamApp.xam_sp_listRequerimientoByIdPos", dypa, commandType: CommandType.StoredProcedure).ToList();
            }
            catch (Exception e)
            {
                //listRequerimientoByIdPos
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

                sw.WriteLine("\t From RequerimientoBO.listRequerimientoByIdPos(" + idPostulante + ");");

                sw.WriteLine("\t Message Error: " + error);

                sw.WriteLine("---------------------------------");

                sw.Close();
                #endregion

                listRequerimiento = new List<Requerimiento>();
            }
            finally
            {
                cn.Close();
                cn.Dispose();
            }

            return listRequerimiento;
        }



    }
}
