using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Laboratorio_2_ABB.Clases;
using Laboratorio_2_ABB.Models;
using Estructuras_de_datos;


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
        public ActionResult IsBalancedPais()
        {
            bool bal = Data.Instance.ABB.IsBalanced();
            if (bal)
            {
                ViewBag.Message = string.Format("El arbol que se muestra esta balanceado");
            }
            else
            {
                ViewBag.Message = string.Format("El arbol que se muestra no esta balanceado");
            }
            return View("IndexPais", Data.Instance.listaPaises);
        }

        public ActionResult IsBalancedInt()
        {
            bool bal = Data.Instance.intABB.IsBalanced();
            if (bal)
            {
                ViewBag.Message = string.Format("El arbol que se muestra esta balanceado");
            }
            else
            {
                ViewBag.Message = string.Format("El arbol que se muestra no esta balanceado");
            }
            return View("IndexInt", Data.Instance.listaInt);
        }

        public ActionResult IsBalancedString()
        {
            bool bal = Data.Instance.stringABB.IsBalanced();
            if (bal)
            {
                ViewBag.Message = string.Format("El arbol que se muestra esta balanceado");
            }
            else
            {
                ViewBag.Message = string.Format("El arbol que se muestra no esta balanceado");
            }
            return View("IndexString", Data.Instance.listaString);
        }

        public ActionResult IsDegeneratePais()
        {
            bool bal = Data.Instance.ABB.IsDegenerate();
            if (bal)
            {
                ViewBag.Message = string.Format("El arbol que se muestra es un arbol degenerado");
            }
            else
            {
                ViewBag.Message = string.Format("El arbol que se muestra no es un arbol degenerado");
            }
            return View("IndexPais", Data.Instance.listaPaises);
        }

        public ActionResult IsDegenerateInt()
        {
            bool bal = Data.Instance.intABB.IsDegenerate();
            if (bal)
            {
                ViewBag.Message = string.Format("El arbol que se muestra es un arbol degenerado");
            }
            else
            {
                ViewBag.Message = string.Format("El arbol que se muestra no es un arbol degenerado");
            }
            return View("IndexInt", Data.Instance.listaInt);
        }

        public ActionResult IsDegenerateString()
        {
            bool bal = Data.Instance.stringABB.IsDegenerate();
            if (bal)
            {
                ViewBag.Message = string.Format("El arbol que se muestra es un arbol degenerado");
            }
            else
            {
                ViewBag.Message = string.Format("El arbol que se muestra no es un arbol degenerado");
            }
            return View("IndexString", Data.Instance.listaString);
        }

        // GET: Pais/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Pais/AddPais
        public ActionResult AddPais()
        {
            return View();
        }

        // POST: Pais/AddPais
        [HttpPost]
        public ActionResult AddPais(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                Data.Instance.ABB.Insert(new Pais
                {
                    id = Data.Instance.ABB.GetHeight(null),
                    Nombre = collection["Nombre"],
                    Grupo = collection["Grupo"]
                });
                Data.Instance.listaPaises = Data.Instance.ABB.Orders("InOrder");

                return RedirectToAction("IndexPais");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pais/AddInt
        public ActionResult AddInt()
        {
            return View();
        }

        // POST: Pais/AddInt
        [HttpPost]
        public ActionResult AddInt(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                Data.Instance.intABB.Insert(Convert.ToInt32(collection["Valor"]));
                Data.Instance.listaInt = Data.Instance.intABB.Orders("InOrder");

                return RedirectToAction("IndexInt");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pais/AddString
        public ActionResult AddString()
        {
            return View();
        }

        // POST: Pais/AddString
        [HttpPost]
        public ActionResult AddString(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                Data.Instance.stringABB.Insert(collection["Valor"]);
                Data.Instance.listaString = Data.Instance.stringABB.Orders("InOrder");

                return RedirectToAction("IndexString");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pais/Edit/5
        public ActionResult Edit(int id)
        {
            var pais = Data.Instance.listaPaises.Find(x => x.id == id);
            return View(pais);
        }

        // POST: Pais/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                Pais pais = Data.Instance.listaPaises.Find(x => x.id == id);
                Data.Instance.ABB.Eliminar(pais);
                Data.Instance.listaPaises.Insert(id, pais);
                return RedirectToAction("IndexPais");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pais/DeletePais/5
        public ActionResult DeletePais(int id)
        {
            var pais = Data.Instance.listaPaises.Find(x => x.id == id);
            return View(pais);
        }

        // POST: Pais/DeletePais/5
        [HttpPost]
        public ActionResult DeletePais(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Pais pais = Data.Instance.listaPaises.Find(x => x.id == id);
                Data.Instance.ABB.Eliminar(pais);
                Data.Instance.listaPaises = Data.Instance.ABB.Orders("InOrder");
                return RedirectToAction("IndexPais");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pais/DeleteInt/5
        public ActionResult DeleteInt(int id)
        {
            var valor = Data.Instance.listaInt.Find(x => x == id);
            return View(valor);
        }

        // POST: Pais/DeleteInt/5
        [HttpPost]
        public ActionResult DeleteInt(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var valor = Data.Instance.listaInt.Find(x => x == id);
                Data.Instance.intABB.Eliminar(valor);
                Data.Instance.listaInt = Data.Instance.intABB.Orders("InOrder");
                return RedirectToAction("IndexInt");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pais/DeleteString/5
        public ActionResult DeleteString(string id)
        {
            var valor = Data.Instance.listaString.Find(x => x == id);
            return View(valor);
        }

        // POST: Pais/DeleteString/5
        [HttpPost]
        public ActionResult DeleteString(string id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var valor = Data.Instance.listaString.Find(x => x == id);
                Data.Instance.stringABB.Eliminar(valor);
                Data.Instance.listaString = Data.Instance.stringABB.Orders("InOrder");
                return RedirectToAction("IndexString");
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
