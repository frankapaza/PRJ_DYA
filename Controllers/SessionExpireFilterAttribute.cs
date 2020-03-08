using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DYA.Controllers
{
    public class SessionExpireFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContext ctx = HttpContext.Current;

            if (ctx.Session == null || ctx.Session["USUARIO"] == null)
            {
                HttpCookie myCookie = HttpContext.Current.Request.Cookies["COO_DYA"];
                if (myCookie == null)
                {
                    ctx.Response.Redirect("~/Seguridad/IngresoSistema");
                }
                else
                {
                    string idUsuario = HttpContext.Current.Server.UrlDecode(myCookie.Values["USUARIO_CRYPT"]);
                    if (idUsuario != "")
                    {
                        SessionValidate objSessionValidate = new SessionValidate();
                        if (objSessionValidate.ObtenerUsuarioPorId(idUsuario))
                        {
                            bool paginaPermitida = false;
                            //string rutaActual = ctx.Request.Url.AbsolutePath;
                            //MENU[] lstMenuBE = (MENU[])ctx.Session["MENU"];


                            //foreach (MENU objMenuBE in lstMenuBE)
                            //{
                            //    if (rutaActual == objMenuBE.URL_WEB_VC)
                            //    {
                            //        paginaPermitida = true;
                            //        break;
                            //    }
                            //    else
                            //    {
                            //        foreach (MENU objMenuHijo in objMenuBE.lstMenuHijoBE)
                            //        {
                            //            if (rutaActual == objMenuHijo.URL_WEB_VC)
                            //            {
                            //                paginaPermitida = true;
                            //                break;
                            //            }
                            //        }
                            //    }
                            //}

                            if (!paginaPermitida)
                            {
                                ctx.Response.Redirect("~/Seguridad/IngresoSistema");
                            }
                        }
                        else
                        {
                            ctx.Response.Redirect("~/Seguridad/IngresoSistema");
                        }
                    }
                    else
                    {
                        ctx.Response.Redirect("~/Seguridad/IngresoSistema");
                    }
                }
            }

            base.OnActionExecuting(filterContext);
        }
    }
}