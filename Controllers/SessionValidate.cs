using BE_DYA;
using DA_DYA;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Web;
using UTILITARIO;

namespace DYA.Controllers
{
    public class SessionValidate
    {
        public string key_crypt = ConfigurationManager.AppSettings["KEY_CRYPT"].ToString();

        public bool isSuccess()
        {
            bool result = true;
            HttpContext ctx = HttpContext.Current;

            if (ctx.Session == null || ctx.Session["USUARIO"] == null)
            {
                HttpCookie myCookie = HttpContext.Current.Request.Cookies["COO_DYA"];
                if (myCookie == null)
                {
                    result = false;
                }
                else
                {
                    string idUsuario = HttpContext.Current.Server.UrlDecode(myCookie.Values["USUARIO_CRYPT"]);
                    if (idUsuario != "")
                    {
                        if (ObtenerUsuarioPorId(idUsuario))
                        {
                            result = true;
                        }
                        else
                        {
                            result = false;
                        }
                    }
                    else
                    {
                        result = false;
                    }
                }
            }

            return result;
        }

        public bool ObtenerUsuarioPorId(string idUsuario)
        {
            Boolean respuesta = false;
            HttpCookie myCookie = HttpContext.Current.Request.Cookies["COO_DYA"];

            BE_USUARIO objUsuarioBE = new BE_USUARIO();
            objUsuarioBE.ID_USU_IN_CRYPT = myCookie.Values["USUARIO_CRYPT"];
            objUsuarioBE.objRolBE.ID_ROL_IN = Int32.Parse(myCookie.Values["PERFIL"]);
            DA_USUARIO objUsuarioDA = new DA_USUARIO();
            objUsuarioDA.loguearsePorIdUsuario(objUsuarioBE);

            if (objUsuarioBE.objResBE.Key == 1)
            {
                /*OBTENER MENU*/
                //MENU[] lstMenuBE = ws.obtenerMenu(objSeguridadBE);

                HttpContext.Current.Session["USUARIO"] = objUsuarioBE;
                //HttpContext.Current.Session["MENU"] = lstMenuBE;
                respuesta = true;
            }
            return respuesta;
        }

        public int obtenerIdUsuario()
        {
            int result = 0;

            if (isSuccess())
            {
                try
                {
                    BE_USUARIO objUsuarioBE = new BE_USUARIO();
                    objUsuarioBE = (BE_USUARIO)HttpContext.Current.Session["USUARIO"];
                    result = Convert.ToInt32(HttpUtility.UrlEncode(FUNCIONES.DecryptTripleDES(objUsuarioBE.ID_USU_IN_CRYPT, key_crypt)));
                }
                catch (Exception ex)
                {
                    result = 0;
                }
            }

            return result;
        }

        public int obtenerIdRol()
        {
            int result = 0;

            if (isSuccess())
            {
                try
                {
                    BE_USUARIO objUsuarioBE = new BE_USUARIO();
                    objUsuarioBE = (BE_USUARIO)HttpContext.Current.Session["USUARIO"];
                    result = objUsuarioBE.objRolBE.ID_ROL_IN;
                }
                catch (Exception)
                {
                    result = 0;
                }
            }

            return result;
        }

        public string obtenerIpMaquina()
        {
            string result = "0.0.0.0";
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    result = ip.ToString();
                }
            }
            return result;
        }
    }
}