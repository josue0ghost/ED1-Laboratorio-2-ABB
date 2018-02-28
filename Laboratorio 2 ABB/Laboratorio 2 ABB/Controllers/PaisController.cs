using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Laboratorio_2_ABB.Clases;

namespace Laboratorio_2_ABB.Controllers
{
    public class PaisController : Controller
    {
        public ActionResult Home()
        {
            return View();
        }
            // GET: Pais
            public ActionResult IndexPais()
        {
            Data.Instance.listaPaises.Add(new Models.Pais { id = Data.Instance.listaPaises.Count(), Nombre = "Guate", Grupo = "A" });
            return View(Data.Instance.listaPaises);
        }
        // GET: int
        public ActionResult IndexInt()
        {
            Data.Instance.listaInt.Add(new Models.IntNode { id = Data.Instance.listaInt.Count(), value = 4});
            return View(Data.Instance.listaInt);
        }

        // GET: String
        public ActionResult IndexString()
        {
            Data.Instance.listaString.Add(new Models.StringNode { id = Data.Instance.listaInt.Count(), value = "ValorUno" });
            return View(Data.Instance.listaString);
        }

        // GET: Pais/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Pais/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pais/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pais/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Pais/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pais/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Pais/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
