using MantClientes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MantClientes.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetClientes()
        {
            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                var clientes = dc.Clientes.OrderBy(a => a.Nombre).ToList();
                return Json(new { data = clientes }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult Save(int id)
        {
            using (MyDatabaseEntities db = new MyDatabaseEntities())
            {
                var v = db.Clientes.Where(a => a.ClienteID == id).FirstOrDefault();
                return View(v);
            }
        }

        [HttpPost]
        public ActionResult Save(Cliente cliente)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                using (MyDatabaseEntities db = new MyDatabaseEntities())
                {
                    if (cliente.ClienteID > 0)
                    {
                        //Edit 
                        var v = db.Clientes.Where(a => a.ClienteID == cliente.ClienteID).FirstOrDefault();
                        if (v != null)
                        {
                            v.Nombre = cliente.Nombre;
                            v.Telefono = cliente.Telefono;
                            v.Direccion = cliente.Direccion;
                        }
                    }
                    else
                    {
                        //Save
                        db.Clientes.Add(cliente);
                    }
                    db.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult { Data = new { status = status } };
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            using (MyDatabaseEntities db = new MyDatabaseEntities())
            {
                var v = db.Clientes.Where(a => a.ClienteID == id).FirstOrDefault();
                if (v != null)
                {
                    return View(v);
                }
                else
                {
                    return HttpNotFound();
                }
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteCliente(int id)
        {
            bool status = false;
            using (MyDatabaseEntities db = new MyDatabaseEntities())
            {
                var v = db.Clientes.Where(a => a.ClienteID == id).FirstOrDefault();
                if (v != null)
                {
                    db.Clientes.Remove(v);
                    db.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult { Data = new { status = status } };
        }

    }


}