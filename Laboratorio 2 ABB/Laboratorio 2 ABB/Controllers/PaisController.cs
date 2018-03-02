using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Laboratorio_2_ABB.Clases;
using Laboratorio_2_ABB.Models;
using ClassLibary1;

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
            return View(Data.Instance.listaPaises);
        }
        // GET: int
        public ActionResult IndexInt()
        {
            return View(Data.Instance.listaInt);
        }

        // GET: String
        public ActionResult IndexString()
        {
            return View(Data.Instance.listaString);
        }
        public ActionResult OrdenInt(string order)
        {
            Data.Instance.listaInt = Data.Instance.intABB.Orders(order);
            return RedirectToAction("IndexInt");
        }
        public ActionResult OrdenString(string order)
        {
            Data.Instance.listaString = Data.Instance.stringABB.Orders(order);
            return RedirectToAction("IndexString");
        }
        public ActionResult OrdenPais(string order)
        {
            Data.Instance.listaPaises = Data.Instance.ABB.Orders(order);
            return RedirectToAction("IndexPais");
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

        public ActionResult UploadInt()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UploadInt(HttpPostedFileBase file)
        {
            try
            {
                if (!file.FileName.EndsWith(".json"))
                    return View();
                if(file.ContentLength > 0)
                {
                    var json = new JsonConverter<int>();
                    BinaryTreeNode<int> raiz = json.datosJson(file.InputStream);
                    Data.Instance.intABB.Root = raiz;
                    Data.Instance.listaInt = Data.Instance.intABB.Orders("InOrder");
                    return RedirectToAction("IndexInt");
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return View();
        }

        public ActionResult UploadString()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UploadString(HttpPostedFileBase file)
        {
            try
            {
                if (!file.FileName.EndsWith(".json"))
                    return View();
                if (file.ContentLength > 0)
                {
                    var json = new JsonConverter<string>();
                    BinaryTreeNode<string> raiz = json.datosJson(file.InputStream);
                    Data.Instance.stringABB.Root = raiz;
                    Data.Instance.listaString = Data.Instance.stringABB.Orders("InOrder");
                    return RedirectToAction("IndexString");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View();
        }

        public ActionResult UploadPais()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UploadPais(HttpPostedFileBase file)
        {
            try
            {
                if (!file.FileName.EndsWith(".json"))
                    return View();
                if (file.ContentLength > 0)
                {
                    var json = new JsonConverter<Pais>();
                    BinaryTreeNode<Pais> raiz = json.datosJson(file.InputStream);
                    Data.Instance.ABB.Root = raiz;
                    Data.Instance.listaPaises = Data.Instance.ABB.Orders("InOrder");
                    return RedirectToAction("IndexPais");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View();
        }
    }
}
