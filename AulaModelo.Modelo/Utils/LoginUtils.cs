using AulaModelo.Modelo.DB;
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
        public static Boolean condicao = false;
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


        public static void Logar(String login, string senha)
        {
            var usuario = DbFactory.Instance.UsuarioRepository.Login(login, senha);
            if (usuario != null)
            {
                HttpContext.Current.Session["Usuario"] = usuario;
                HttpContext.Current.Session["UsuarioID"] = usuario.Id;
            }
            else
            {
                condicao = true;
            }

        }
       
        public static void Deslogar()
        {

            HttpContext.Current.Session["Usuario"] = null;
            HttpContext.Current.Session.Remove("Usuario");
        }
    }
}
