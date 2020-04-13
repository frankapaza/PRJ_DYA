using BE_DYA;
using BL_DYA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DYA.Controllers
{
    public class DemoController : Controller
    {
        // GET: Demo
        public ActionResult Index()
        {
            BL_USUARIO objUsuarioBL = new BL_USUARIO();
            BE_USUARIO objUsuarioBE = new BE_USUARIO();
            objUsuarioBE.ID_USU_IN = 22;//CAMBIAR ACA EL ID_USUARIO de la tabla TBL_USUARIO
            objUsuarioBL.loguearsePorIdUsuario(objUsuarioBE);

            if (objUsuarioBE.objResBE.Key == 1)
            {
                HttpCookie myCookie = new HttpCookie("COO_DYA");
                myCookie.Values.Add("USUARIO_CRYPT", Convert.ToString(objUsuarioBE.ID_USU_IN_CRYPT));
                myCookie.Values.Add("PERFIL", Convert.ToString(objUsuarioBE.objRolBE.ID_ROL_IN));
                myCookie.Values.Add("TIPO_CUENTA", Convert.ToString(objUsuarioBE.objTipoCuentaBE.ID_TIP_CUE_IN));
                myCookie.Expires = DateTime.Now.AddDays(30d);
                HttpContext.Response.Cookies.Add(myCookie);

                /*OBTENER MENU*/
                BL_MENU objMenuBL = new BL_MENU();
                List<BE_MENU> lstMenuBE = objMenuBL.listarMenu(objUsuarioBE);

                HttpContext.Session["USUARIO"] = objUsuarioBE;
                HttpContext.Session["MENU"] = lstMenuBE;
            }

            return View();
        }
    }
}