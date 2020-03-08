using BE_DYA;
using BL_DYA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DYA.Controllers
{
    public class RolController : Controller
    {
        /***
         * LISTAR ROL
         */
        [HttpPost]
        public JsonResult listarRolCombo()
        {
            BE_COMBO lstRolBE = new BE_COMBO();
            SessionValidate objSessionValidate = new SessionValidate();
            if (objSessionValidate.isSuccess())
            {
                BL_ROL objRolBL = new BL_ROL();
                lstRolBE = objRolBL.listarRolCombo();
            }
            return Json(lstRolBE, JsonRequestBehavior.AllowGet);
        }
    }
}