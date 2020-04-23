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
        // GET: Demografico
        [SessionExpireFilter]
        public ActionResult Demografico()
        {
            SessionValidate objSessionValidate = new SessionValidate();
            if (objSessionValidate.isSuccess())
            {
                ViewBag.IdPerfilIN = objSessionValidate.obtenerIdRol();
            }
            return View();
        }

        // GET: Empresas
        [SessionExpireFilter]
        public ActionResult Empresa()
        {
            SessionValidate objSessionValidate = new SessionValidate();
            if (objSessionValidate.isSuccess())
            {
                ViewBag.IdPerfilIN = objSessionValidate.obtenerIdRol();
            }
            return View();
        }

        // GET: Automotor
        [SessionExpireFilter]
        public ActionResult Automotor()
        {
            SessionValidate objSessionValidate = new SessionValidate();
            if (objSessionValidate.isSuccess())
            {
                ViewBag.IdPerfilIN = objSessionValidate.obtenerIdRol();
            }
            return View();
        }

        // GET: Soat
        [SessionExpireFilter]
        public ActionResult Soat()
        {
            SessionValidate objSessionValidate = new SessionValidate();
            if (objSessionValidate.isSuccess())
            {
                ViewBag.IdPerfilIN = objSessionValidate.obtenerIdRol();
            }
            return View();
        }

        // GET: Medicos
        [SessionExpireFilter]
        public ActionResult Medicos()
        {
            SessionValidate objSessionValidate = new SessionValidate();
            if (objSessionValidate.isSuccess())
            {
                ViewBag.IdPerfilIN = objSessionValidate.obtenerIdRol();
            }
            return View();
        }

        // GET: Telecomunicaciones
        [SessionExpireFilter]
        public ActionResult Telecomunicaciones()
        {
            SessionValidate objSessionValidate = new SessionValidate();
            if (objSessionValidate.isSuccess())
            {
                ViewBag.IdPerfilIN = objSessionValidate.obtenerIdRol();
            }
            return View();
        }

    }
}