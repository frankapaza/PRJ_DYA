using BE_DYA;
using BL_DYA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DYA.Controllers
{
    public class DashboardController : Controller
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

        /***
         * DemograficoUbicacion
         */
        [HttpPost]
        public JsonResult DemograficoUbicacion()
        {
            List<BE_DATO> resultado = null;
            SessionValidate objSessionValidate = new SessionValidate();
            if (objSessionValidate.isSuccess())
            {
                BL_DASHBOARD objDashboardBL = new BL_DASHBOARD();
                resultado = objDashboardBL.DemograficoUbicacion();
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        /***
         * DemograficoUbicacion
         */
        [HttpPost]
        public JsonResult DemograficoSexo()
        {
            List<BE_DATO> resultado = null;
            SessionValidate objSessionValidate = new SessionValidate();
            if (objSessionValidate.isSuccess())
            {
                BL_DASHBOARD objDashboardBL = new BL_DASHBOARD();
                resultado = objDashboardBL.DemograficoSexo();
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        /***
         * DemograficoUbicacion
         */
        [HttpPost]
        public JsonResult DemograficoEdad()
        {
            List<BE_DATO> resultado = null;
            SessionValidate objSessionValidate = new SessionValidate();
            if (objSessionValidate.isSuccess())
            {
                BL_DASHBOARD objDashboardBL = new BL_DASHBOARD();
                resultado = objDashboardBL.DemograficoEdad();
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
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

        /***
         * EmpresaUbicacion
         */
        [HttpPost]
        public JsonResult EmpresaUbicacion()
        {
            List<BE_DATO> resultado = null;
            SessionValidate objSessionValidate = new SessionValidate();
            if (objSessionValidate.isSuccess())
            {
                BL_DASHBOARD objDashboardBL = new BL_DASHBOARD();
                resultado = objDashboardBL.EmpresaUbicacion();
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        /***
         * EmpresaUbicacion
         */
        [HttpPost]
        public JsonResult EmpresaEstado()
        {
            List<BE_DATO> resultado = null;
            SessionValidate objSessionValidate = new SessionValidate();
            if (objSessionValidate.isSuccess())
            {
                BL_DASHBOARD objDashboardBL = new BL_DASHBOARD();
                resultado = objDashboardBL.EmpresaEstado();
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        /***
         * EmpresaUbicacion
         */
        [HttpPost]
        public JsonResult EmpresaTipo()
        {
            List<BE_DATO> resultado = null;
            SessionValidate objSessionValidate = new SessionValidate();
            if (objSessionValidate.isSuccess())
            {
                BL_DASHBOARD objDashboardBL = new BL_DASHBOARD();
                resultado = objDashboardBL.EmpresaTipo();
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        /***
         * EmpresaUbicacion
         */
        [HttpPost]
        public JsonResult EmpresaGiro()
        {
            List<BE_DATO> resultado = null;
            SessionValidate objSessionValidate = new SessionValidate();
            if (objSessionValidate.isSuccess())
            {
                BL_DASHBOARD objDashboardBL = new BL_DASHBOARD();
                resultado = objDashboardBL.EmpresaGiro();
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
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

        /***
         * AutomotorAnioFabricacion
         */
        [HttpPost]
        public JsonResult AutomotorAnioFabricacion()
        {
            List<BE_DATO> resultado = null;
            SessionValidate objSessionValidate = new SessionValidate();
            if (objSessionValidate.isSuccess())
            {
                BL_DASHBOARD objDashboardBL = new BL_DASHBOARD();
                resultado = objDashboardBL.AutomotorAnioFabricacion();
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        /***
         * AutomotorMarca
         */
        [HttpPost]
        public JsonResult AutomotorMarca()
        {
            List<BE_DATO> resultado = null;
            SessionValidate objSessionValidate = new SessionValidate();
            if (objSessionValidate.isSuccess())
            {
                BL_DASHBOARD objDashboardBL = new BL_DASHBOARD();
                resultado = objDashboardBL.AutomotorMarca();
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        /***
         * AutomotorTipoPersona
         */
        [HttpPost]
        public JsonResult AutomotorTipoPersona()
        {
            List<BE_DATO> resultado = null;
            SessionValidate objSessionValidate = new SessionValidate();
            if (objSessionValidate.isSuccess())
            {
                BL_DASHBOARD objDashboardBL = new BL_DASHBOARD();
                resultado = objDashboardBL.AutomotorTipoPersona();
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        /***
         * AutomotorTipoVehiculo
         */
        [HttpPost]
        public JsonResult AutomotorTipoVehiculo()
        {
            List<BE_DATO> resultado = null;
            SessionValidate objSessionValidate = new SessionValidate();
            if (objSessionValidate.isSuccess())
            {
                BL_DASHBOARD objDashboardBL = new BL_DASHBOARD();
                resultado = objDashboardBL.AutomotorTipoVehiculo();
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        /***
         * AutomotorTipoVehiculo
         */
        [HttpPost]
        public JsonResult AutomotorUbicacion()
        {
            List<BE_DATO> resultado = null;
            SessionValidate objSessionValidate = new SessionValidate();
            if (objSessionValidate.isSuccess())
            {
                BL_DASHBOARD objDashboardBL = new BL_DASHBOARD();
                resultado = objDashboardBL.AutomotorUbicacion();
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
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

        /***
         * SoatSeguro
         */
        [HttpPost]
        public JsonResult SoatSeguro()
        {
            List<BE_DATO> resultado = null;
            SessionValidate objSessionValidate = new SessionValidate();
            if (objSessionValidate.isSuccess())
            {
                BL_DASHBOARD objDashboardBL = new BL_DASHBOARD();
                resultado = objDashboardBL.SoatSeguro();
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        /***
         * SoatTipo
         */
        [HttpPost]
        public JsonResult SoatTipo()
        {
            List<BE_DATO> resultado = null;
            SessionValidate objSessionValidate = new SessionValidate();
            if (objSessionValidate.isSuccess())
            {
                BL_DASHBOARD objDashboardBL = new BL_DASHBOARD();
                resultado = objDashboardBL.SoatTipo();
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        /***
         * SoatTipoVehiculo
         */
        [HttpPost]
        public JsonResult SoatTipoVehiculo()
        {
            List<BE_DATO> resultado = null;
            SessionValidate objSessionValidate = new SessionValidate();
            if (objSessionValidate.isSuccess())
            {
                BL_DASHBOARD objDashboardBL = new BL_DASHBOARD();
                resultado = objDashboardBL.SoatTipoVehiculo();
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        /***
         * SoatVencimiento
         */
        [HttpPost]
        public JsonResult SoatVencimiento()
        {
            List<BE_DATO> resultado = null;
            SessionValidate objSessionValidate = new SessionValidate();
            if (objSessionValidate.isSuccess())
            {
                BL_DASHBOARD objDashboardBL = new BL_DASHBOARD();
                resultado = objDashboardBL.SoatVencimiento();
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
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

        /***
         * MedicosUbicacion
         */
        [HttpPost]
        public JsonResult MedicosUbicacion()
        {
            List<BE_DATO> resultado = null;
            SessionValidate objSessionValidate = new SessionValidate();
            if (objSessionValidate.isSuccess())
            {
                BL_DASHBOARD objDashboardBL = new BL_DASHBOARD();
                resultado = objDashboardBL.MedicosUbicacion();
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        /***
         * MedicosEstado
         */
        [HttpPost]
        public JsonResult MedicosEstado()
        {
            List<BE_DATO> resultado = null;
            SessionValidate objSessionValidate = new SessionValidate();
            if (objSessionValidate.isSuccess())
            {
                BL_DASHBOARD objDashboardBL = new BL_DASHBOARD();
                resultado = objDashboardBL.MedicosEstado();
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        /***
         * MedicosEspecialidad
         */
        [HttpPost]
        public JsonResult MedicosEspecialidad()
        {
            List<BE_DATO> resultado = null;
            SessionValidate objSessionValidate = new SessionValidate();
            if (objSessionValidate.isSuccess())
            {
                BL_DASHBOARD objDashboardBL = new BL_DASHBOARD();
                resultado = objDashboardBL.MedicosEspecialidad();
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        /***
         * MedicosEstado
         */
        [HttpPost]
        public JsonResult MedicosGrado()
        {
            List<BE_DATO> resultado = null;
            SessionValidate objSessionValidate = new SessionValidate();
            if (objSessionValidate.isSuccess())
            {
                BL_DASHBOARD objDashboardBL = new BL_DASHBOARD();
                resultado = objDashboardBL.MedicosGrado();
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
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

        /***
         * TelecomunicacionesMarketshare
         */
        [HttpPost]
        public JsonResult TelecomunicacionesMarketshare()
        {
            List<BE_DATO> resultado = null;
            SessionValidate objSessionValidate = new SessionValidate();
            if (objSessionValidate.isSuccess())
            {
                BL_DASHBOARD objDashboardBL = new BL_DASHBOARD();
                resultado = objDashboardBL.TelecomunicacionesMarketshare();
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
    }
}