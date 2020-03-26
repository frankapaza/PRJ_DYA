using BE_DYA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DYA.Controllers
{
    public class NavigationController : Controller
    {
        //CREANDO EL MENU
        public ActionResult Menu()
        {
            List<BE_MENU> lstMenuBE = (List<BE_MENU>)Session["MENU"];
            return PartialView("_Navigation", lstMenuBE);
        }

        //OBTENIENDO EL USUARIO
        public ActionResult Usuario()
        {
            BE_USUARIO objUsuarioBE = (BE_USUARIO)Session["USUARIO"];
            return PartialView("_User", objUsuarioBE);
        }

        //OBTENIENDO NOMBRE USUARIO
        public ActionResult UsuarioNombre()
        {
            BE_USUARIO objUsuarioBE = (BE_USUARIO)Session["USUARIO"];
            return PartialView("_Username", objUsuarioBE);
        }

        //OBTENIENDO PERFIL
        public ActionResult Perfil()
        {
            BE_USUARIO objUsuarioBE = (BE_USUARIO)Session["USUARIO"];
            return PartialView("_Perfil", objUsuarioBE);
        }
    }
}