using BE_DYA;
using BL_DYA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DYA.Controllers
{
    public class MantenimientoController : Controller
    {
        // GET: Mantenimiento
        [SessionExpireFilter]
        public ActionResult Usuario()
        {
            BL_ROL objRolBL = new BL_ROL();
            BL_TIPO_CUENTA objTipoCuentaBL = new BL_TIPO_CUENTA();

            BE_COMBO lstRolBE = objRolBL.listarRolCombo();
            BE_COMBO lstTipoCuentaBE = objTipoCuentaBL.listarRolCombo();

            ViewData["lstRolBE"] = lstRolBE;
            ViewData["lstTipoCuentaBE"] = lstTipoCuentaBE;
            return View();
        }
    }
}