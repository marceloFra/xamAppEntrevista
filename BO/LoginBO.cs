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
    public class LoginBO
    {
        public static Postulante logeoPostulante(string correo, string codDePostulanteGenerado)
        {
            Postulante rpts = new Postulante();
            SqlConnection cn = new SqlConnection(Conexion.cn);

            try
            {
                DynamicParameters dypa = new DynamicParameters();
                dypa.Add("@correo", correo);
                dypa.Add("@codPos", codDePostulanteGenerado);
                rpts = cn.QueryFirst<Postulante>("xamApp.xam_LoginPostulante", dypa, commandType: CommandType.StoredProcedure);

                if (rpts.nombre == null)
                {
                    rpts.nombre = "No existe";
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

                sw.WriteLine("\t From LoginBO.logeoPostulante(" + correo + ","+ codDePostulanteGenerado + ");");

                sw.WriteLine("\t Message Error: " + error);

                sw.WriteLine("---------------------------------");

                sw.Close();
                #endregion
                rpts = new Postulante();
                rpts.nombre = "Error: " + e;
            }
            finally
            {
                cn.Close();
                cn.Dispose();
            }
            return rpts;
        }

        public static string logeoUsuario(string nomUsuario, string contrasena)
        {
            string resultado = "Error";
            Usuarios rpts = new Usuarios();
            SqlConnection cn = new SqlConnection(Conexion.cn);

            try
            {
                DynamicParameters dypa = new DynamicParameters();
                dypa.Add("@nomUsuario", nomUsuario);
                dypa.Add("@contraUsuario", contrasena);
                var nombreUsuario = cn.ExecuteScalar("xamApp.xam_LoginUsuario", dypa, commandType: CommandType.StoredProcedure);

                if (nombreUsuario != null)
                {
                    resultado = nombreUsuario+"";
                }else{
                    resultado = "No existe usuario";
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

                sw.WriteLine("\t From LoginBO.logeoUsuario();");

                sw.WriteLine("\t Message Error: " + error);

                sw.WriteLine("---------------------------------");

                sw.Close();
                #endregion
                rpts = null;
                resultado = "Error: " + e;
            }
            finally
            {
                cn.Close();
                cn.Dispose();
            }
            return resultado;
        }
        
    }
}
