using AulaModelo.Modelo.DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace AulaModelo.Modelo.Utils
{
    public class LoginUtils
    {
        public static Usuario Usuario
        {
            get
            {
                if (HttpContext.Current.Session["Usuario"] != null)
                {
                    return (Usuario)HttpContext.Current.Session["Usuario"];
                }
                return null;
            }
        }


        public static void Logar(String usuario, string senha)
        {
            if ((usuario == "admin") && (senha == "123456"))
            {
               
                HttpContext.Current.Session["Usuario"] = new Usuario();
            }
        }
        public static void Deslogar(String usuario, string senha)
        {

            HttpContext.Current.Session["Usuario"] = null;
            HttpContext.Current.Session.Remove("Usuario");
        }
    }
}
