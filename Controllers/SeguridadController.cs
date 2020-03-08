using BE_DYA;
using BL_DYA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DYA.Controllers
{
    public class SeguridadController : Controller
    {
        // GET: Seguridad
        public ActionResult IngresoSistema()
        {
            return View();
        }

        public ActionResult Logout()
        {
            HttpContext.Session["USUARIO"] = null;
            //HttpContext.Session["MENU"] = null;

            if (Request.Cookies["COO_DYA"] != null)
            {
                Response.Cookies["COO_DYA"].Expires = DateTime.Now.AddDays(-1);
            }

            return RedirectToAction("IngresoSistema", "Seguridad");
        }

        /***
         * REGISTRAR USUARIO
         */
        [HttpPost]
        public JsonResult login(BE_USUARIO objUsuarioBE)
        {
            //KeyValuePair<int, string> resultado = new KeyValuePair<int, string>();

            BL_USUARIO objUsuarioBL = new BL_USUARIO();
            objUsuarioBL.login(objUsuarioBE);

            if (objUsuarioBE.objResBE.Key == 1) {
                HttpCookie myCookie = new HttpCookie("COO_DYA");
                myCookie.Values.Add("USUARIO_CRYPT", Convert.ToString(objUsuarioBE.ID_USU_IN_CRYPT));
                //myCookie.Values.Add("PERFIL", Convert.ToString(objSeguridadBE.ID_PER_IN));
                myCookie.Expires = DateTime.Now.AddDays(30d);
                HttpContext.Response.Cookies.Add(myCookie);

                /*OBTENER MENU*/
                //MENU[] lstMenuBE = ws.obtenerMenu(objSeguridadBE);

                HttpContext.Session["USUARIO"] = objUsuarioBE;
                //HttpContext.Session["MENU"] = lstMenuBE;
            }

            return Json(objUsuarioBE, JsonRequestBehavior.AllowGet);
        }
    }
}