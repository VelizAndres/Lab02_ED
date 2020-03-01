using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Prueba_MVC.Models;
using Prueba_MVC.Herramientas.Estructura;
namespace Prueba_MVC.Herramientas.Almacen
{
    public class Caja_arbol
    {
        private static Caja_arbol _instance = null;

        public static Caja_arbol Instance
        {
            get
            {
                if (_instance == null) _instance = new Caja_arbol();
                return _instance;
            }
        }

        public BiArbol<mFarmaco> arbolFarm = new BiArbol<mFarmaco>();

    }
}