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
         * REGISTRAR USUARIO VERIFICACION
         */
        [HttpPost]
        public JsonResult registrarVerificacion(BE_USUARIO objUsuarioBE)
        {
            bool resultado = false;
            BL_USUARIO objUsuarioBL = new BL_USUARIO();
            resultado = objUsuarioBL.registrarVerificacion(objUsuarioBE);

            if (resultado) {
                Dictionary<string, string> correos = new Dictionary<string, string>();
                correos.Add(objUsuarioBE.COR_COR_VC, objUsuarioBE.NOM_PER_VC + " " + objUsuarioBE.APE_PER_VC);

                UTILITARIO.EMAIL.enviarCorreo(correos, 
                    "Verificación de Correo | DYA, Usuario: " + objUsuarioBE.LOG_USU_VC,
                    "Bienvenido " + objUsuarioBE.NOM_PER_VC + " " + objUsuarioBE.APE_PER_VC, 
                    "Para validar su correo haga click <a href='" + 
                    "https://localhost:44357/Usuario/verificarCorreo?p=" + objUsuarioBE.ID_USU_IN_CRYPT + "'>Aquí</a>,ó ingresar a la siguiente ruta " +
                    "https://localhost:44357/Usuario/verificarCorreo?p=" + objUsuarioBE.ID_USU_IN_CRYPT, "MANAR PERU");
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult verificarCorreo(string p)
        {
            bool resultado = false;
            BL_USUARIO objUsuarioBL = new BL_USUARIO();
            resultado = objUsuarioBL.verificarCorreo(p);
            return View();
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