using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Prueba_MVC.Herramientas.Almacen;
using Prueba_MVC.Models;
using System.IO;

namespace Prueba_MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Elección de archivo.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Flow(HttpPostedFileBase postedFile)
        {
      
            string filePath = string.Empty;
            if(postedFile != null)
            {
                string path = Server.MapPath("~/Cargas/");
                if(!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                filePath = path + Path.GetFileName(postedFile.FileName);
                string extension = Path.GetExtension(postedFile.FileName);
                postedFile.SaveAs(filePath);
            }
            using (var filestream = new FileStream(filePath, FileMode.Open))
            {

                using (var streamReader = new StreamReader(filestream))
                {
                    string lector = streamReader.ReadLine();
                          lector = streamReader.ReadLine();
                    while (lector != null)
                    {
                        int pos = int.Parse(filestream.Position.ToString());
                        string[] cajatext = lector.Split(Convert.ToChar(","));
                        mFarmaco nuevo = new mFarmaco();
                        nuevo.Nombre = cajatext[1];
                        string delsimb = cajatext[(cajatext.Length - 2)];
                        var precio_simb = "";
                        for(int i=1; i<delsimb.Length;i++)
                        {
                            precio_simb += delsimb[i];
                        }
                        nuevo.Precio = double.Parse(precio_simb);
                        nuevo.Linea = pos;
                        Caja_arbol.Instance.arbolFarm.Agregar(nuevo, mFarmaco.ComparName);
                         lector = streamReader.ReadLine();
                    }

                }
            }


            return View("Index");
        }
    }
}