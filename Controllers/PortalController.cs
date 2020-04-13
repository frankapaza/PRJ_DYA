using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DYA.Controllers
{
    public class PortalController : Controller
    {
        // GET: Portal
        public ActionResult ContenidoPortal()
        {
            return View();
        }
    }
}