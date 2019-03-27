using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public static class Conexion
    {
        public static string cn
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["cn"].ToString();
            }
        }

        public static string cnu
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["cnu"].ToString();
            }
        }
    }
}
