using BE_DYA;
using BL_DYA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DYA.Controllers
{
    public class UsuarioController : Controller
    {
        /***
         * REGISTRAR USUARIO
         */
        [HttpPost]
        public JsonResult registrar(BE_USUARIO objUsuarioBE)
        {
            bool resultado = false;
            SessionValidate objSessionValidate = new SessionValidate();
            if (objSessionValidate.isSuccess())
            {
                BL_USUARIO objUsuarioBL = new BL_USUARIO();
                objUsuarioBE.USU_CRE_IN = objSessionValidate.obtenerIdUsuario();
                resultado = objUsuarioBL.registrar(objUsuarioBE);
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        /***
         * LISTAR USUARIO
         */
        [HttpPost]
        public JsonResult listar(BE_FILTRO objFiltroBE)
        {
            List<BE_USUARIO> lstUsuarioBE = new List<BE_USUARIO>();
            SessionValidate objSessionValidate = new SessionValidate();
            if (objSessionValidate.isSuccess())
            {
                BL_USUARIO objUsuarioBL = new BL_USUARIO();
                lstUsuarioBE = objUsuarioBL.listar(objFiltroBE);
            }
            return Json(lstUsuarioBE, JsonRequestBehavior.AllowGet);
        }

        /***
         * ELIMINAR USUARIO
         */
        [HttpPost]
        public JsonResult eliminar(BE_USUARIO objUsuarioBE)
        {
            bool resultado = false;
            SessionValidate objSessionValidate = new SessionValidate();
            if (objSessionValidate.isSuccess())
            {
                BL_USUARIO objUsuarioBL = new BL_USUARIO();
                objUsuarioBE.USU_UPD_IN = objSessionValidate.obtenerIdUsuario();
                resultado = objUsuarioBL.eliminar(objUsuarioBE);
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
    }
}