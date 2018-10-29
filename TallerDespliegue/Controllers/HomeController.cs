using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Modelo.Entidades;
using Modelo.DAL;
using System.Diagnostics;

namespace TallerDespliegue.Controllers
{
    public class HomeController : Controller
    {
        private DBConexion db = new DBConexion();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "Usuario,Clave")] SystemUser systemuser)
        {
            string user = systemuser.Usuario;
            string pass = systemuser.Clave;
            if (ModelState.IsValid)
            {
                var logo = db.systemuser.Where(i => i.Usuario == user && i.Clave == pass).ToList();
                if (logo.Count == 0)
                {
                    Session["Login"] = "Usuario o contraseña Incorrecta, Intente nuevamente";
                    Session["LoginUser"] = null;
                    return RedirectToAction("Index");
                }
                else
                {
                    Session["Login"] = null;
                    Session["LoginUser"] = systemuser.Usuario;
                    return RedirectToAction("Index", "Cliente");
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult Logout()
        {
            if (@Session["LoginUser"] != null)
            {
                @Session["LoginUser"] = null;
            }
            return RedirectToAction("Index");
        }
    }
}