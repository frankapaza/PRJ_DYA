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
            List<BE_MENU> lstMenuBE = (List<BE_MENU>) Session["MENU"];
            return PartialView("_Navigation", lstMenuBE);
        }
    }
}