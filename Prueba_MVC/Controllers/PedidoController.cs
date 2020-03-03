using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Prueba_MVC.Herramientas.Almacen;
using Prueba_MVC.Models;
using System.IO;
using System.Text.RegularExpressions;

namespace Prueba_MVC.Controllers
{
    public class PedidoController : Controller
    {
        // GET: Pedido
        public ActionResult Venta()
        {
            return View();
        }
        public ActionResult BuscarFarmaco()
        {
          
            return View();
        }


       
        public ActionResult Busqueda(string Texto)
        {
            mFarmaco farmaco = new mFarmaco();
            farmaco.Nombre = Texto;
            farmaco = Caja_arbol.Instance.arbolFarm.Buscar(farmaco, mFarmaco.ComparName);
            int linea_buscad = farmaco.Linea;
            string info_farmaco = "";
            using (FileStream archivo = new FileStream(Caja_arbol.Instance.direccion_archivo_arbol, FileMode.Open))
            {
                using (StreamReader lector = new StreamReader(archivo))
                {
                    archivo.Seek(linea_buscad, SeekOrigin.Begin);
                    info_farmaco = lector.ReadLine();
                }
            }
            Regex regx = new Regex("," + "(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");
            string[] infor_separada = regx.Split(info_farmaco);
            ViewBag.Nombre = infor_separada[1];
            ViewBag.Descripción = infor_separada[2];
            ViewBag.Productora = infor_separada[3];
            ViewBag.Precio = infor_separada[4];
            ViewBag.Existencia = infor_separada[5];
            return View("BuscarFarmaco");
        }




        // GET: Pedido/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pedido/Create
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

        // GET: Pedido/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Pedido/Edit/5
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

        // GET: Pedido/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Pedido/Delete/5
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
