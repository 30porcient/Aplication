using Modelo.DAL;
using Modelo.Entidades;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace TallerDespliegue.Controllers
{
    public class ClienteController : Controller
    {
        private DBConexion db = new DBConexion();
        // GET: Cliente
        public ActionResult Index()
        {
            return View(db.cliente.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Cliente client)
        {
            bool busqueda = db.cliente.Any(x => x.ClienteId == client.ClienteId);
            if (busqueda == false)
            {
                if (ModelState.IsValid)
                {
                    db.cliente.Add(client);
                    db.SaveChanges();
                }
            }
            else
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            client = null;
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            Cliente clients = db.cliente.Find(id);
            return View(clients);
        }

        [HttpPost]
        public ActionResult Edit(Cliente client, int id)
        {
            client.ClienteId = id;
            if (ModelState.IsValid)
            {
                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(client);
        }

        public ActionResult Details(int id)
        {
            Cliente clients = db.cliente.Find(id);
            return View(clients);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente client = db.cliente.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult confirmarEliminar(int? id)
        {
            Cliente client = db.cliente.Find(id);
            db.cliente.Remove(client);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}